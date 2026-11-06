import sqlite3
import app_paths
from instance_lock import InstanceLock


def test_legacy_migration_and_existing_state_not_overwritten(tmp_path, monkeypatch):
    installation = tmp_path / 'legacy'
    state = tmp_path / 'user'
    (installation / 'data').mkdir(parents=True)
    (installation / 'Config').mkdir()
    source = sqlite3.connect(installation / 'data' / 'school_time.db')
    source.execute('CREATE TABLE example (value TEXT)')
    source.execute("INSERT INTO example VALUES ('original')")
    source.commit()
    source.close()
    (installation / 'Config' / 'settings.json').write_text('{"voice_lang":"eng"}', encoding='utf-8')
    monkeypatch.setattr(app_paths, 'INSTALL_DIR', installation)
    monkeypatch.setattr(app_paths, 'STATE_DIR', state)
    monkeypatch.setattr(app_paths, 'CONFIG_DIR', state / 'Config')
    monkeypatch.setattr(app_paths, 'DATA_DIR', state / 'data')
    app_paths.initialize_storage()
    connection = sqlite3.connect(state / 'data' / 'school_time.db')
    try:
        assert connection.execute('SELECT value FROM example').fetchone()[0] == 'original'
        connection.execute("UPDATE example SET value='changed'")
        connection.commit()
    finally:
        connection.close()
    (state / 'Config' / 'settings.json').write_text('{"voice_lang":"both"}', encoding='utf-8')
    app_paths.initialize_storage()
    connection = sqlite3.connect(state / 'data' / 'school_time.db')
    try:
        assert connection.execute('SELECT value FROM example').fetchone()[0] == 'changed'
    finally:
        connection.close()
    assert 'both' in (state / 'Config' / 'settings.json').read_text(encoding='utf-8')


def test_single_instance_per_data_directory(tmp_path):
    first = InstanceLock(tmp_path)
    second = InstanceLock(tmp_path)
    other = InstanceLock(tmp_path / 'other')
    try:
        assert first.acquired and not second.acquired and other.acquired
    finally:
        first.close()
        second.close()
        other.close()
    reopened = InstanceLock(tmp_path)
    try:
        assert reopened.acquired
    finally:
        reopened.close()
