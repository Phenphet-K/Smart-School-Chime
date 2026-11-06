"""Separate bundled resources from writable application state."""
import os
import shutil
import sqlite3
import sys
from pathlib import Path

FROZEN = bool(getattr(sys, 'frozen', False))
RESOURCE_DIR = Path(getattr(sys, '_MEIPASS', Path(__file__).resolve().parent))
INSTALL_DIR = Path(sys.executable).resolve().parent if FROZEN else RESOURCE_DIR
STATE_DIR = Path(os.environ.get('CHIME_HOME') or (
    Path(os.environ.get('LOCALAPPDATA', Path.home())) / 'SmartSchoolChime'
    if FROZEN else INSTALL_DIR))
CONFIG_DIR = STATE_DIR / 'Config'
DATA_DIR = STATE_DIR / 'data'
SOUND_DIR = RESOURCE_DIR / 'Sound' if (RESOURCE_DIR / 'Sound').is_dir() else INSTALL_DIR / 'Sound'


def initialize_storage():
    """Migrate a legacy installation once; never overwrite existing user state."""
    CONFIG_DIR.mkdir(parents=True, exist_ok=True)
    DATA_DIR.mkdir(parents=True, exist_ok=True)
    if STATE_DIR.resolve() == INSTALL_DIR.resolve():
        return
    old_db = INSTALL_DIR / 'data' / 'school_time.db'
    new_db = DATA_DIR / 'school_time.db'
    if old_db.is_file() and not new_db.exists():
        temporary = DATA_DIR / 'migration.db.tmp'
        try:
            source = sqlite3.connect(old_db.as_uri() + '?mode=ro', uri=True)
            try:
                target = sqlite3.connect(temporary)
                try:
                    source.backup(target)
                finally:
                    target.close()
            finally:
                source.close()
            os.replace(temporary, new_db)
        finally:
            temporary.unlink(missing_ok=True)
    old_settings = INSTALL_DIR / 'Config' / 'settings.json'
    new_settings = CONFIG_DIR / 'settings.json'
    if old_settings.is_file() and not new_settings.exists():
        shutil.copy2(old_settings, new_settings)
