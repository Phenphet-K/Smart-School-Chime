"""Validated, atomic configuration storage. JSON is the source of truth."""
import json
import logging
import os
import tempfile
import threading
from pathlib import Path
import app_paths

logger = logging.getLogger('ConfigManager')
CONFIG_DIR = str(app_paths.CONFIG_DIR)
CONFIG_FILE = str(Path(CONFIG_DIR) / 'settings.json')
_lock = threading.RLock()
DEFAULT_SETTINGS = {
    'app_name': 'Smart School Chime', 'day_mode': 'all_day',
    'bell_pack': 'Sound01', 'voice_lang': 'thai', 'auto_shutdown': '0',
    'shutdown_hour': '17', 'shutdown_minute': '00',
}


def validate_settings(data):
    if not isinstance(data, dict):
        raise ValueError('Settings must be an object')
    result = DEFAULT_SETTINGS.copy()
    result.update({key: str(value) for key, value in data.items()})
    for key, choices in {'day_mode': ('all_day', 'each_day'),
                         'voice_lang': ('thai', 'eng', 'both'),
                         'auto_shutdown': ('0', '1')}.items():
        if result[key] not in choices:
            raise ValueError(f'Invalid setting: {key}')
    for key, maximum in [('shutdown_hour', 23), ('shutdown_minute', 59)]:
        if not result[key].isdigit() or not 0 <= int(result[key]) <= maximum:
            raise ValueError(f'Invalid setting: {key}')
        result[key] = result[key].zfill(2)
    pack = result['bell_pack']
    if not pack or any(c in pack for c in '/\\:') or pack in ('.', '..'):
        raise ValueError('Invalid bell pack')
    return result


def save_all_settings(settings_dict):
    settings = validate_settings(settings_dict)
    with _lock:
        os.makedirs(CONFIG_DIR, exist_ok=True)
        temporary = None
        try:
            with tempfile.NamedTemporaryFile(mode='w', encoding='utf-8',
                                             dir=CONFIG_DIR, delete=False) as stream:
                temporary = stream.name
                json.dump(settings, stream, ensure_ascii=False, indent=2)
                stream.flush()
                os.fsync(stream.fileno())
            os.replace(temporary, CONFIG_FILE)
        finally:
            if temporary and os.path.exists(temporary):
                os.unlink(temporary)


def init_config():
    with _lock:
        if not os.path.exists(CONFIG_FILE):
            save_all_settings(DEFAULT_SETTINGS)


def load_all_settings():
    with _lock:
        init_config()
        try:
            with open(CONFIG_FILE, encoding='utf-8') as stream:
                return validate_settings(json.load(stream))
        except (ValueError, TypeError, OSError):
            logger.exception('Cannot load settings; using safe defaults')
            return DEFAULT_SETTINGS.copy()


def get_config(key, default=None):
    return load_all_settings().get(key, default)


def set_config(key, value):
    with _lock:
        settings = load_all_settings()
        settings[key] = str(value)
        save_all_settings(settings)
