import datetime as dt
import pathlib
import threading
import wave
import pytest
from scheduler import MinuteScheduler
from audio_player import AudioPlayer
import audio_player
from audio_formats import inspect_wave, playable_wave


def time(value):
    return dt.datetime.fromisoformat('2026-11-05 ' + value)


def test_skipped_zero_second_triggers_once():
    clock = MinuteScheduler()
    assert clock.due(time('07:59:59')) == []
    assert clock.due(time('08:00:01')) == [time('08:00:00')]
    assert clock.due(time('08:00:02')) == []


def test_startup_grace_and_expired_events():
    assert MinuteScheduler().due(time('08:00:15')) == [time('08:00:00')]
    assert MinuteScheduler().due(time('08:00:16')) == []
    clock = MinuteScheduler()
    clock.due(time('07:59:59'))
    assert clock.due(time('09:00:30')) == []


def test_backward_clock_no_immediate_replay():
    clock = MinuteScheduler()
    clock.due(time('08:00:00'))
    assert clock.due(time('07:59:00')) == []
    # Re-crossing a boundary is protected by database.claim_event in the app.


def test_midnight_boundary():
    clock = MinuteScheduler()
    clock.due(dt.datetime(2026, 11, 5, 23, 59, 59))
    assert clock.due(dt.datetime(2026, 11, 6, 0, 0, 1)) == [dt.datetime(2026, 11, 6)]


@pytest.fixture
def player(monkeypatch):
    monkeypatch.setattr(audio_player.winsound, 'PlaySound', lambda *args: None)
    instance = AudioPlayer()
    yield instance
    instance.close()
    assert not instance._worker.is_alive()


def test_replacement_never_resumes_cancelled_sequence(player):
    entered, release, done = threading.Event(), threading.Event(), threading.Event()
    calls = []
    def play(filename, cancel):
        calls.append(filename)
        if filename == 'old-first':
            entered.set()
            assert release.wait(3)
    player._play_file_sync = play
    player.play_sequence_async(['old-first', 'old-second'])
    assert entered.wait(3)
    player.play_sequence_async(['new'], on_finish=done.set)
    release.set()
    assert done.wait(3)
    assert calls == ['old-first', 'new']


def test_stop_cancels_current_and_queued_and_cleans_both(player):
    entered, release, cleaned = threading.Event(), threading.Event(), threading.Event()
    calls, cleanup = [], []
    def play(filename, cancel):
        calls.append(filename)
        entered.set()
        assert release.wait(3)
    player._play_file_sync = play
    player.play_sequence_async(['first', 'should-not-play'], on_cleanup=lambda: (cleanup.append('current'), cleaned.set()))
    assert entered.wait(3)
    player.play_sequence_async(['queued'], enqueue=True, on_cleanup=lambda: cleanup.append('queued'))
    player.stop()
    release.set()
    assert cleaned.wait(3)
    assert calls == ['first']
    assert sorted(cleanup) == ['current', 'queued']


def test_queued_sequences_are_serial(player):
    done = threading.Event()
    calls = []
    player._play_file_sync = lambda filename, cancel: calls.append(filename)
    player.play_sequence_async(['one', 'two'], enqueue=True)
    player.play_sequence_async(['three'], enqueue=True, on_finish=done.set)
    assert done.wait(3)
    assert calls == ['one', 'two', 'three']


def test_missing_audio_reports_failure_not_success(player, tmp_path):
    failed, success, cleanup = threading.Event(), threading.Event(), threading.Event()
    player.play_sequence_async([tmp_path / 'missing.wav'], on_finish=success.set,
                               on_error=lambda error: failed.set(), on_cleanup=cleanup.set)
    assert failed.wait(3) and cleanup.wait(3)
    assert not success.is_set()


def test_all_shipped_wav_headers_are_readable():
    files = list((pathlib.Path(__file__).resolve().parents[1] / 'Sound').rglob('*.wav'))
    assert len(files) == 198
    for filename in files:
        info = inspect_wave(filename)
        assert info.duration > 0


def test_float_assets_convert_without_changing_original():
    filename = pathlib.Path(__file__).resolve().parents[1] / 'Sound' / 'Bell' / 'Sound01' / 'First.wav'
    before = filename.read_bytes()
    with playable_wave(filename, threading.Event()) as (converted, duration):
        with wave.open(converted, 'rb') as stream:
            assert stream.getsampwidth() == 2
            assert stream.getnframes() / stream.getframerate() == duration
        assert pathlib.Path(converted).exists()
    assert not pathlib.Path(converted).exists()
    assert filename.read_bytes() == before
