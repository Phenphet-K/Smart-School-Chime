"""
Configuration Manager for Smart School Chime
Handles loading and saving app settings in /config/settings.json
"""

import os
import json
import logging

logger = logging.getLogger("ConfigManager")

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
CONFIG_DIR = os.path.join(BASE_DIR, "config")
CONFIG_FILE = os.path.join(CONFIG_DIR, "settings.json")

DEFAULT_SETTINGS = {
    "app_name": "Smart School Chime",
    "day_mode": "all_day",       # "all_day" or "each_day"
    "bell_pack": "Sound01",       # Sound01..05
    "voice_lang": "thai",         # "thai", "eng", or "both"
    "auto_shutdown": "0",         # "0" or "1"
    "shutdown_hour": "17",
    "shutdown_minute": "00"
}

def init_config():
    """Ensure /config folder and settings.json exist with defaults"""
    os.makedirs(CONFIG_DIR, exist_ok=True)
    if not os.path.exists(CONFIG_FILE):
        try:
            with open(CONFIG_FILE, "w", encoding="utf-8") as f:
                json.dump(DEFAULT_SETTINGS, f, ensure_ascii=False, indent=2)
        except Exception as e:
            logger.error(f"Error creating initial {CONFIG_FILE}: {e}")

def load_all_settings() -> dict:
    """Load settings dictionary from config/settings.json"""
    init_config()
    try:
        with open(CONFIG_FILE, "r", encoding="utf-8") as f:
            data = json.load(f)
            merged = DEFAULT_SETTINGS.copy()
            merged.update(data)
            return merged
    except Exception as e:
        logger.error(f"Error loading {CONFIG_FILE}: {e}")
        return DEFAULT_SETTINGS.copy()

def save_all_settings(settings_dict: dict):
    """Save full settings dictionary into config/settings.json"""
    os.makedirs(CONFIG_DIR, exist_ok=True)
    try:
        with open(CONFIG_FILE, "w", encoding="utf-8") as f:
            json.dump(settings_dict, f, ensure_ascii=False, indent=2)
    except Exception as e:
        logger.error(f"Error writing {CONFIG_FILE}: {e}")

def get_config(key: str, default=None):
    """Get single configuration value"""
    settings = load_all_settings()
    return settings.get(key, default if default is not None else DEFAULT_SETTINGS.get(key))

def set_config(key: str, value):
    """Update single configuration value in config/settings.json"""
    settings = load_all_settings()
    settings[key] = str(value)
    save_all_settings(settings)
