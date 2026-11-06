import datetime
import queue
import pytest
import main
import database
import audio_player
import broadcast_server
import http.client
import io
import ssl
import wave


ORIGINAL_BROADCAST_START = broadcast_server.BroadcastServer.start


@pytest.fixture
def app(isolated, monkeypatch):
    monkeypatch.setattr(main.BroadcastServer, 'start', lambda self: None)
    monkeypatch.setattr(audio_player.winsound, 'PlaySound', lambda *args: None)
    monkeypatch.setattr(main.nvda, 'speak', lambda *args, **kwargs: False)
    for name in ('showinfo', 'showerror', 'askyesno'):
        monkeypatch.setattr(main.messagebox, name, lambda *args, **kwargs: True)
    instance = main.SmartSchoolChimeApp()
    instance.withdraw()
    yield instance
    instance.on_close()


def drain(app):
    while True:
        try:
            app._ui_queue.get_nowait()()
        except queue.Empty:
            return


def test_gui_load_save_preserves_label(app):
    label = database.get_schedules_for_day(8)[0]['label']
    app.save_current_day_schedule()
    assert database.get_schedules_for_day(8)[0]['label'] == label


def test_duplicate_time_slots_enqueue_and_do_not_replay(app, monkeypatch):
    slots = database.get_schedules_for_day(8)
    slots[1].update(hour='08', minute='00')
    database.save_all_day_slots(8, slots)
    calls = []
    monkeypatch.setattr(app.player, 'play_slot_event', lambda *args, **kwargs: calls.append((args, kwargs)))
    now = datetime.datetime(2026, 11, 5, 8)
    app._check_and_trigger(now)
    app._check_and_trigger(now)
    assert len(calls) == 2
    assert all(kwargs['enqueue'] for _, kwargs in calls)


def test_esc_cancels_broadcast_waiting_for_ui(app, isolated, monkeypatch):
    path = isolated / 'announcement.wav'
    path.write_bytes(b'placeholder')
    calls = []
    app.broadcast_server._files.add(str(path))
    monkeypatch.setattr(app.player, 'play_sequence_async', lambda *args, **kwargs: calls.append(args))
    app.handle_incoming_broadcast('127.0.0.1', str(path), True)
    app.stop_audio()
    drain(app)
    assert not calls
    assert not path.exists()


def test_shutdown_skipped_while_audio_busy(app, monkeypatch):
    app.auto_shutdown.set(True)
    app.shutdown_hour.set('17')
    app.shutdown_min.set('00')
    monkeypatch.setattr(app.player, 'is_playing', lambda: True)
    calls = []
    monkeypatch.setattr(main.subprocess, 'run', lambda *args, **kwargs: calls.append(args))
    app._check_and_trigger(datetime.datetime(2026, 11, 5, 17))
    assert not calls


def test_next_event_searches_following_day(app):
    app._calculate_next_event(8, datetime.datetime(2026, 11, 5, 23))
    assert '06/11 08:00' in app.lbl_next_event.cget('text')


def test_scheduler_retries_transient_database_failure(app, monkeypatch):
    real_datetime = datetime.datetime
    class Clock(real_datetime):
        @classmethod
        def now(cls):
            return cls(2026, 11, 5, 8, 0, 1)
    monkeypatch.setattr(main.datetime, 'datetime', Clock)
    app._minute_scheduler.last_check = real_datetime(2026, 11, 5, 7, 59, 59)
    app.after_cancel(app._scheduler_after)
    calls = []
    def trigger(now):
        calls.append(now)
        if len(calls) == 1:
            raise database.sqlite3.OperationalError('simulated lock')
    monkeypatch.setattr(app, '_check_and_trigger', trigger)
    app._scheduler_loop()
    app.after_cancel(app._scheduler_after)
    app._scheduler_loop()
    assert len(calls) == 2


def test_pairing_can_be_revoked_from_gui(app):
    old = 'Bearer ' + app.broadcast_server._token
    app.refresh_broadcast_pairing()
    assert not app.broadcast_server.authorized(old)


def test_https_upload_reaches_gui_audio_queue_and_cleans_file(app, monkeypatch):
    monkeypatch.setattr(broadcast_server.BroadcastServer, 'start', ORIGINAL_BROADCAST_START)
    server = broadcast_server.BroadcastServer(0, 0, app.handle_incoming_broadcast, host='127.0.0.1')
    app.broadcast_server = server
    server.start()
    played = []
    monkeypatch.setattr(app.player, '_play_file_sync', lambda filename, cancel: played.append(filename))
    output = io.BytesIO()
    with wave.open(output, 'wb') as stream:
        stream.setparams((1, 2, 16000, 0, 'NONE', 'not compressed'))
        stream.writeframes(b'\x00\x00' * 160)
    context = ssl.create_default_context(cafile=str(broadcast_server.CONFIG_DIR) + '/cert.pem')
    connection = http.client.HTTPSConnection('127.0.0.1', server.https_port, context=context, timeout=3)
    try:
        connection.request('POST', '/api/broadcast?chime=1', body=output.getvalue(), headers={
            'Content-Type': 'audio/wav', 'Authorization': 'Bearer ' + server._token})
        response = connection.getresponse()
        assert response.status == 202
        response.read()
    finally:
        connection.close()
    assert not played
    drain(app)
    with app.player._condition:
        assert app.player._condition.wait_for(lambda: not app.player._current and not app.player._queue, timeout=3)
    drain(app)
    assert len(played) == 2  # Chime, followed by the uploaded announcement.
    assert not server._busy and not server._files
    assert 'สำเร็จ' in app.broadcast_listbox.get(app.broadcast_listbox.size() - 1)
