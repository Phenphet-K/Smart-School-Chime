"""
Database management module for Smart School Chime
Stores SQLite database in /data/school_time.db
Includes ready-to-use default Thai school schedule and integrates with /config/settings.json
"""

import sqlite3
import json
import os
from contextlib import contextmanager
import app_paths
import config_manager

DATA_DIR = str(app_paths.DATA_DIR)
DB_FILE = os.path.join(DATA_DIR, "school_time.db")

# Standard Thai School Schedule (14 realistic periods)
DEFAULT_PERIODS = [
    {
        "slot_num": 1, "hour": "08", "minute": "00",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "เพลงชาติไทย.wav", "sound_data_eng": "ItTimeToSingTheNationalAnthem.wav",
        "sound_last": 0, "label": "เข้าแถวเคารพธงชาติ"
    },
    {
        "slot_num": 2, "hour": "08", "minute": "30",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "ได้เวลาเข้าห้องเรียน.wav", "sound_data_eng": "ItTimeToGotoClass.wav",
        "sound_last": 0, "label": "เริ่มเรียน คาบที่ 1"
    },
    {
        "slot_num": 3, "hour": "09", "minute": "20",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "หมดเวลาเรียนคาบที่1.wav", "sound_data_eng": "EndOfClassOne.wav",
        "sound_last": 0, "label": "หมดคาบ 1 / เริ่มคาบ 2"
    },
    {
        "slot_num": 4, "hour": "10", "minute": "10",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "หมดเวลาเรียนคาบที่2พัก10นาที.wav", "sound_data_eng": "EndOfClassTwoTimeForTenMinuteBreak.wav",
        "sound_last": 0, "label": "หมดคาบ 2 พักเบรก 10 นาที"
    },
    {
        "slot_num": 5, "hour": "10", "minute": "20",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "ได้เวลาเข้าห้องเรียน.wav", "sound_data_eng": "ItTimeToGotoClass.wav",
        "sound_last": 0, "label": "หมดเวลาพัก / เข้าเรียน คาบที่ 3"
    },
    {
        "slot_num": 6, "hour": "11", "minute": "10",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "หมดเวลาเรียนคาบที่3.wav", "sound_data_eng": "EndOfClassThree.wav",
        "sound_last": 0, "label": "หมดคาบ 3 / เข้าเรียน คาบที่ 4"
    },
    {
        "slot_num": 7, "hour": "12", "minute": "00",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "หมดเวลาเรียนคาบที่4ได้เวลาพักรับประทานอาหารกลางวัน.wav", "sound_data_eng": "EndOfClassFourItTimeToEatLunch.wav",
        "sound_last": 0, "label": "หมดคาบ 4 พักรับประทานอาหารกลางวัน"
    },
    {
        "slot_num": 8, "hour": "12", "minute": "50",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "ได้เวลาเข้าห้องเรียน.wav", "sound_data_eng": "ItTimeToGotoClass.wav",
        "sound_last": 0, "label": "เตือนเตรียมตัวเข้าเรียนภาคบ่าย"
    },
    {
        "slot_num": 9, "hour": "13", "minute": "00",
        "sound_first": 1, "sound_time": 1, "sound_con": 0,
        "sound_data": "", "sound_data_eng": "",
        "sound_last": 0, "label": "เริ่มเรียน คาบที่ 5"
    },
    {
        "slot_num": 10, "hour": "13", "minute": "50",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "หมดเวลาเรียนคาบที่5.wav", "sound_data_eng": "EndOfClassFive.wav",
        "sound_last": 0, "label": "หมดคาบ 5 / เข้าเรียน คาบที่ 6"
    },
    {
        "slot_num": 11, "hour": "14", "minute": "40",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "หมดเวลาเรียนคาบที่6.wav", "sound_data_eng": "EndOfClassSix.wav",
        "sound_last": 0, "label": "หมดคาบ 6 / เข้าเรียน คาบที่ 7"
    },
    {
        "slot_num": 12, "hour": "15", "minute": "30",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "หมดเวลาเรียนคาบที่7ต่อด้วยมาร์ช.wav", "sound_data_eng": "ThisIsTheEndOfTheSevenPeriod.wav",
        "sound_last": 1, "label": "หมดคาบ 7 เลิกเรียน / มาร์ช"
    },
    {
        "slot_num": 13, "hour": "15", "minute": "40",
        "sound_first": 1, "sound_time": 1, "sound_con": 1,
        "sound_data": "ได้เวลาทำความสะอาดเขตพื้นที่รับผิดชอบ.wav", "sound_data_eng": "GoodMorningItTimeToCleanTheClassRoom.wav",
        "sound_last": 0, "label": "ทำความสะอาดเขตพื้นที่รับผิดชอบ"
    },
    {
        "slot_num": 14, "hour": "16", "minute": "30",
        "sound_first": 0, "sound_time": 1, "sound_con": 0,
        "sound_data": "", "sound_data_eng": "",
        "sound_last": 1, "label": "ขานเวลาเลิกงาน / หมดเวลาทำการ"
    }
]


def get_connection():
    os.makedirs(DATA_DIR, exist_ok=True)
    return sqlite3.connect(DB_FILE, timeout=5)


@contextmanager
def session():
    connection = get_connection()
    try:
        with connection:
            yield connection
    finally:
        connection.close()


FIELDS = ('day_id', 'slot_num', 'hour', 'minute', 'sound_first', 'sound_time',
          'sound_con', 'sound_data', 'sound_data_eng', 'sound_last', 'label')
FLAGS = ('sound_first', 'sound_time', 'sound_con', 'sound_last')


def bounded_integer(value, minimum, maximum, field):
    text = str(value)
    if not text.isascii() or not text.isdigit() or not minimum <= int(text) <= maximum:
        raise ValueError(f'Invalid {field}: {value}')
    return int(text)


def validate_slot(row, day_id=None):
    if not isinstance(row, dict):
        raise ValueError('Schedule entry must be an object')
    result = dict(row)
    result['day_id'] = bounded_integer(day_id if day_id is not None else row.get('day_id'), 1, 8, 'day_id')
    result['slot_num'] = bounded_integer(row.get('slot_num'), 1, 24, 'slot_num')
    for field, maximum in [('hour', 23), ('minute', 59)]:
        result[field] = f"{bounded_integer(row.get(field, '00'), 0, maximum, field):02d}"
    for field in FLAGS:
        value = row.get(field, 0)
        if value not in (0, 1, False, True, '0', '1'):
            raise ValueError(f'Invalid {field}')
        result[field] = int(value)
    for field in ('sound_data', 'sound_data_eng'):
        name = row.get(field, '') or ''
        if not isinstance(name, str) or len(name) > 255 or any(c in name for c in '/\\:\x00') or name in ('.', '..'):
            raise ValueError(f'Invalid audio filename: {field}')
        if name and not name.lower().endswith('.wav'):
            raise ValueError('Only WAV audio filenames are supported')
        result[field] = name
    label = row.get('label', '') or ''
    if not isinstance(label, str) or len(label) > 500:
        raise ValueError('Invalid label')
    result['label'] = label
    return {field: result[field] for field in FIELDS}


def write_slots(connection, rows):
    connection.executemany(
        'INSERT OR REPLACE INTO schedules (' + ','.join(FIELDS) + ') VALUES (' + ','.join('?' for _ in FIELDS) + ')',
        [tuple(row[field] for field in FIELDS) for row in rows])


def init_db(force_default=False):
    config_manager.init_config()
    with session() as connection:
        connection.execute('CREATE TABLE IF NOT EXISTS settings (key TEXT PRIMARY KEY, value TEXT)')
        connection.execute("""CREATE TABLE IF NOT EXISTS schedules (
            id INTEGER PRIMARY KEY AUTOINCREMENT, day_id INTEGER, slot_num INTEGER,
            hour TEXT, minute TEXT, sound_first INTEGER, sound_time INTEGER,
            sound_con INTEGER, sound_data TEXT, sound_data_eng TEXT,
            sound_last INTEGER, label TEXT DEFAULT '', UNIQUE(day_id,slot_num))""")
        columns = {row[1] for row in connection.execute('PRAGMA table_info(schedules)')}
        if 'label' not in columns:
            connection.execute("ALTER TABLE schedules ADD COLUMN label TEXT DEFAULT ''")
        if 'sound_data_eng' not in columns:
            connection.execute("ALTER TABLE schedules ADD COLUMN sound_data_eng TEXT DEFAULT ''")
        connection.execute("""CREATE TABLE IF NOT EXISTS event_runs (
            occurrence TEXT PRIMARY KEY, status TEXT NOT NULL,
            updated_at TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP)""")
        if force_default or connection.execute('SELECT COUNT(*) FROM schedules').fetchone()[0] == 0:
            apply_default_school_schedule_db(connection)
        connection.execute('PRAGMA user_version=1')


def apply_default_school_schedule_db(connection, target_day_ids=None):
    active = set([8, 2, 3, 4, 5, 6] if target_day_ids is None else target_day_ids)
    periods = {row['slot_num']: row for row in DEFAULT_PERIODS}
    rows = []
    for day in range(1, 9):
        for slot in range(1, 25):
            entry = dict(periods[slot]) if day in active and slot in periods else {'slot_num': slot}
            rows.append(validate_slot(entry, day))
    write_slots(connection, rows)


def reset_to_default_schedule(day_id=None):
    if day_id is None:
        with session() as connection:
            apply_default_school_schedule_db(connection)
    else:
        day_id = bounded_integer(day_id, 1, 8, 'day_id')
        periods = {row['slot_num']: row for row in DEFAULT_PERIODS}
        rows = [validate_slot(dict(periods.get(slot, {'slot_num': slot})), day_id)
                for slot in range(1, 25)]
        with session() as connection:
            write_slots(connection, rows)


def get_setting(key, default=None):
    return config_manager.get_config(key, default)


def set_setting(key, value):
    config_manager.set_config(key, value)


def get_schedules_for_day(day_id):
    day_id = bounded_integer(day_id, 1, 8, 'day_id')
    with session() as connection:
        connection.row_factory = sqlite3.Row
        rows = {row['slot_num']: dict(row) for row in connection.execute(
            'SELECT ' + ','.join(FIELDS[1:]) + ' FROM schedules WHERE day_id=? ORDER BY slot_num', (day_id,))}
    return [rows.get(slot) or {key: value for key, value in validate_slot({'slot_num': slot}, day_id).items() if key != 'day_id'}
            for slot in range(1, 25)]


def save_all_day_slots(day_id, slots_list):
    day_id = bounded_integer(day_id, 1, 8, 'day_id')
    existing = {row['slot_num']: row for row in get_schedules_for_day(day_id)}
    rows = []
    seen = set()
    for row in slots_list:
        entry = dict(row)
        if 'label' not in entry:
            entry['label'] = existing.get(entry.get('slot_num'), {}).get('label', '')
        validated = validate_slot(entry, day_id)
        if validated['slot_num'] in seen:
            raise ValueError('Duplicate slot number')
        seen.add(validated['slot_num'])
        rows.append(validated)
    with session() as connection:
        write_slots(connection, rows)


def copy_day_to_all_days(source_day_id):
    slots = get_schedules_for_day(source_day_id)
    rows = [validate_slot(row, day) for day in range(1, 9) if day != source_day_id for row in slots]
    with session() as connection:
        write_slots(connection, rows)


def export_to_json(file_path):
    with session() as connection:
        connection.row_factory = sqlite3.Row
        rows = [dict(row) for row in connection.execute('SELECT ' + ','.join(FIELDS) + ' FROM schedules ORDER BY day_id,slot_num')]
    payload = {'version': 1, 'schedules': rows, 'settings': config_manager.load_all_settings()}
    with open(file_path, 'w', encoding='utf-8') as stream:
        json.dump(payload, stream, ensure_ascii=False, indent=2)


def import_from_json(file_path):
    if os.path.getsize(file_path) > 2 * 1024 * 1024:
        raise ValueError('Backup exceeds 2 MB')
    with open(file_path, encoding='utf-8-sig') as stream:
        data = json.load(stream)
    settings = None
    full_restore = isinstance(data, dict)
    if full_restore:
        if data.get('version') != 1:
            raise ValueError('Unsupported backup version')
        settings = config_manager.validate_settings(data.get('settings', {}))
        data = data.get('schedules')
    if not isinstance(data, list) or not 1 <= len(data) <= 192:
        raise ValueError('Backup must contain 1 to 192 schedule entries')
    rows = [validate_slot(row) for row in data]
    keys = {(row['day_id'], row['slot_num']) for row in rows}
    if len(keys) != len(rows):
        raise ValueError('Duplicate schedule entries')
    if full_restore and len(keys) != 192:
        raise ValueError('Full backup must contain all 192 slots')
    old_settings = config_manager.load_all_settings()
    try:
        with session() as connection:
            if full_restore:
                connection.execute('DELETE FROM schedules')
            write_slots(connection, rows)
            if settings is not None:
                config_manager.save_all_settings(settings)
    except Exception:
        if settings is not None:
            config_manager.save_all_settings(old_settings)
        raise


def claim_event(occurrence):
    with session() as connection:
        cursor = connection.execute('INSERT OR IGNORE INTO event_runs (occurrence,status) VALUES (?,?)', (occurrence, 'accepted'))
        return cursor.rowcount == 1


def finish_event(occurrence, status):
    with session() as connection:
        connection.execute('UPDATE event_runs SET status=?,updated_at=CURRENT_TIMESTAMP WHERE occurrence=?', (status, occurrence))


def finish_event_if_pending(occurrence, status):
    with session() as connection:
        connection.execute("UPDATE event_runs SET status=?,updated_at=CURRENT_TIMESTAMP WHERE occurrence=? AND status='accepted'", (status, occurrence))
