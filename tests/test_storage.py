import json
import sqlite3
import pytest
import config_manager as config
import database as db


def test_disabled_schedules_survive_restart(isolated):
    with db.session() as connection:
        connection.execute('UPDATE schedules SET sound_first=0,sound_time=0,sound_con=0,sound_last=0')
    db.init_db()
    with db.session() as connection:
        assert connection.execute('SELECT COUNT(*) FROM schedules WHERE sound_first OR sound_time OR sound_con OR sound_last').fetchone()[0] == 0


def test_reset_one_day_and_preserve_other_days(isolated):
    slots = db.get_schedules_for_day(3)
    slots[0]['hour'] = '09'
    db.save_all_day_slots(3, slots)
    db.reset_to_default_schedule(2)
    assert db.get_schedules_for_day(3)[0]['hour'] == '09'
    assert db.get_schedules_for_day(2)[0]['hour'] == '08'
    assert db.get_schedules_for_day(2)[14]['sound_data_eng'] == ''
    # A fresh writer can acquire the DB immediately after reset.
    with db.session() as connection:
        connection.execute('UPDATE schedules SET label=label')


def test_gui_save_preserves_labels(isolated):
    slots = db.get_schedules_for_day(8)
    label = slots[0]['label']
    for slot in slots:
        slot.pop('label')
    db.save_all_day_slots(8, slots)
    assert db.get_schedules_for_day(8)[0]['label'] == label


@pytest.mark.parametrize('field,value', [('hour', '99'), ('minute', '-1'), ('slot_num', 25),
    ('sound_time', 'false'), ('sound_data', '../secret.wav'), ('sound_data', 'C:\\secret.wav'),
    ('sound_data_eng', 'bad.mp3'), ('label', 123)])
def test_invalid_save_is_atomic(isolated, field, value):
    before = db.get_schedules_for_day(8)
    rows = [dict(row) for row in before]
    rows[0]['hour'] = '07'
    rows[1][field] = value
    with pytest.raises(ValueError):
        db.save_all_day_slots(8, rows)
    assert db.get_schedules_for_day(8) == before


def test_failed_transaction_rolls_back_and_closes(isolated):
    with pytest.raises(sqlite3.OperationalError):
        with db.session() as connection:
            connection.execute("UPDATE schedules SET label='incorrect'")
            connection.execute('INSERT INTO nonexistent VALUES (1)')
    assert db.get_schedules_for_day(8)[0]['label'] != 'incorrect'
    db.reset_to_default_schedule(2)


def test_full_backup_roundtrip(isolated):
    filename = isolated / 'backup.json'
    config.set_config('voice_lang', 'both')
    before = db.get_schedules_for_day(8)
    db.export_to_json(filename)
    db.reset_to_default_schedule(7)
    config.set_config('voice_lang', 'eng')
    db.import_from_json(filename)
    assert db.get_schedules_for_day(8) == before
    assert config.get_config('voice_lang') == 'both'
    assert not any(row['sound_first'] for row in db.get_schedules_for_day(7))


@pytest.mark.parametrize('payload', [[], {'version': 999}, [{'slot_num': 1, 'day_id': 8, 'hour': '99'}],
    [{'slot_num': 1, 'day_id': 8}, {'slot_num': 1, 'day_id': 8}]])
def test_invalid_import_leaves_database_unchanged(isolated, payload):
    filename = isolated / 'invalid.json'
    filename.write_text(json.dumps(payload), encoding='utf-8')
    before = db.get_schedules_for_day(8)
    with pytest.raises(ValueError):
        db.import_from_json(filename)
    assert db.get_schedules_for_day(8) == before


def test_legacy_import_merges_only_supplied_rows(isolated):
    filename = isolated / 'legacy.json'
    filename.write_text(json.dumps([{'day_id': 8, 'slot_num': 1, 'hour': '07'}]), encoding='utf-8')
    db.import_from_json(filename)
    assert db.get_schedules_for_day(8)[0]['hour'] == '07'
    assert db.get_schedules_for_day(8)[1]['hour'] == '08'


def test_atomic_settings_write_failure_preserves_previous_file(isolated, monkeypatch):
    before = config.load_all_settings()
    def fail(*args):
        raise OSError('simulated disk failure')
    monkeypatch.setattr(config.os, 'replace', fail)
    with pytest.raises(OSError):
        config.set_config('voice_lang', 'eng')
    assert config.load_all_settings() == before
    assert len(list((isolated / 'Config').iterdir())) == 1


@pytest.mark.parametrize('field,value', [('auto_shutdown', 'yes'), ('voice_lang', 'xx'),
    ('shutdown_hour', '99'), ('bell_pack', '../Bell'), ('day_mode', 'wrong')])
def test_invalid_settings_rejected(isolated, field, value):
    before = config.load_all_settings()
    with pytest.raises(ValueError):
        config.set_config(field, value)
    assert config.load_all_settings() == before


def test_corrupt_settings_have_safe_defaults_and_keep_original(isolated):
    filename = isolated / 'Config' / 'settings.json'
    filename.write_text('{broken', encoding='utf-8')
    assert config.load_all_settings()['auto_shutdown'] == '0'
    assert filename.read_text(encoding='utf-8') == '{broken'


def test_occurrence_deduplication_survives_restart(isolated):
    assert db.claim_event('2026-11-05 08:00/slot/1')
    db.init_db()
    assert not db.claim_event('2026-11-05 08:00/slot/1')
    assert db.claim_event('2026-11-06 08:00/slot/1')


def test_cleanup_does_not_overwrite_completed_event(isolated):
    db.claim_event('example')
    db.finish_event('example', 'completed')
    db.finish_event_if_pending('example', 'cancelled')
    with db.session() as connection:
        assert connection.execute('SELECT status FROM event_runs WHERE occurrence=?', ('example',)).fetchone()[0] == 'completed'
