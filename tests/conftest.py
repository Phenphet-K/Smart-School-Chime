import pathlib
import sys

sys.path.insert(0, str(pathlib.Path(__file__).resolve().parents[1]))

import pytest
import app_paths
import config_manager
import database
import broadcast_server


@pytest.fixture
def isolated(tmp_path, monkeypatch):
    config = tmp_path / 'Config'
    data = tmp_path / 'data'
    monkeypatch.setattr(app_paths, 'STATE_DIR', tmp_path)
    monkeypatch.setattr(app_paths, 'CONFIG_DIR', config)
    monkeypatch.setattr(app_paths, 'DATA_DIR', data)
    monkeypatch.setattr(config_manager, 'CONFIG_DIR', str(config))
    monkeypatch.setattr(config_manager, 'CONFIG_FILE', str(config / 'settings.json'))
    monkeypatch.setattr(database, 'DATA_DIR', str(data))
    monkeypatch.setattr(database, 'DB_FILE', str(data / 'school_time.db'))
    monkeypatch.setattr(broadcast_server, 'CONFIG_DIR', str(config))
    monkeypatch.setattr(broadcast_server, 'DATA_DIR', str(data))
    monkeypatch.setattr(broadcast_server, 'get_local_lan_ip', lambda: '127.0.0.1')
    database.init_db()
    return tmp_path
