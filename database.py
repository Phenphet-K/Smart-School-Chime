"""
Database management module for Smart School Chime
Stores SQLite database in /data/school_time.db
Includes ready-to-use default Thai school schedule and integrates with /config/settings.json
"""

import sqlite3
import json
import os
import shutil
import config_manager

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
DATA_DIR = os.path.join(BASE_DIR, "data")
DB_FILE = os.path.join(DATA_DIR, "school_time.db")

# Ensure /data exists
os.makedirs(DATA_DIR, exist_ok=True)

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
    return sqlite3.connect(DB_FILE)

def init_db(force_default=False):
    # Initialize /config/settings.json
    config_manager.init_config()

    conn = get_connection()
    c = conn.cursor()
    c.execute("""
    CREATE TABLE IF NOT EXISTS settings (
        key TEXT PRIMARY KEY,
        value TEXT
    )
    """)
    c.execute("""
    CREATE TABLE IF NOT EXISTS schedules (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        day_id INTEGER,
        slot_num INTEGER,
        hour TEXT,
        minute TEXT,
        sound_first INTEGER,
        sound_time INTEGER,
        sound_con INTEGER,
        sound_data TEXT,
        sound_data_eng TEXT,
        sound_last INTEGER,
        label TEXT DEFAULT '',
        UNIQUE(day_id, slot_num)
    )
    """)

    # Check column label exists
    c.execute("PRAGMA table_info(schedules)")
    cols = [r[1] for r in c.fetchall()]
    if "label" not in cols:
        try:
            c.execute("ALTER TABLE schedules ADD COLUMN label TEXT DEFAULT ''")
        except Exception:
            pass

    # Check if empty or if force_default
    c.execute("SELECT COUNT(*) FROM schedules WHERE sound_first=1 OR sound_time=1 OR sound_con=1 OR sound_last=1")
    active_count = c.fetchone()[0]

    if active_count == 0 or force_default:
        apply_default_school_schedule_db(conn)

    # Sync settings from config_manager into SQLite settings table
    current_settings = config_manager.load_all_settings()
    for k, v in current_settings.items():
        c.execute("INSERT OR REPLACE INTO settings (key, value) VALUES (?, ?)", (k, str(v)))

    conn.commit()
    conn.close()

def apply_default_school_schedule_db(conn, target_day_ids=None):
    """Populates 24 slots with realistic Thai school timetable into sqlite connection"""
    c = conn.cursor()
    if target_day_ids is None:
        # 8 = All days, 2..6 = Mon..Fri
        target_day_ids = [8, 2, 3, 4, 5, 6]

    period_dict = {p["slot_num"]: p for p in DEFAULT_PERIODS}

    for day in range(1, 9):
        is_active_day = (day in target_day_ids)
        for s in range(1, 25):
            if is_active_day and s in period_dict:
                p = period_dict[s]
                c.execute("""
                INSERT OR REPLACE INTO schedules 
                (day_id, slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_data_eng, sound_last, label)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """, (
                    day, s,
                    p["hour"], p["minute"],
                    p["sound_first"], p["sound_time"], p["sound_con"],
                    p["sound_data"], p["sound_data_eng"], p["sound_last"],
                    p.get("label", "")
                ))
            else:
                c.execute("""
                INSERT OR REPLACE INTO schedules 
                (day_id, slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_data_eng, sound_last, label)
                VALUES (?, ?, '00', '00', 0, 0, 0, '', '', 0, '')
                """, (day, s))

def reset_to_default_schedule(day_id=None):
    """Reset either a specific day or all school days to standard school schedule"""
    conn = get_connection()
    if day_id:
        c = conn.cursor()
        period_dict = {p["slot_num"]: p for p in DEFAULT_PERIODS}
        for s in range(1, 25):
            if s in period_dict:
                p = period_dict[s]
                c.execute("""
                INSERT OR REPLACE INTO schedules 
                (day_id, slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_data_eng, sound_last, label)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
                """, (
                    day_id, s,
                    p["hour"], p["minute"],
                    p["sound_first"], p["sound_time"], p["sound_con"],
                    p["sound_data"], p["sound_data_eng"], p["sound_last"],
                    p.get("label", "")
                ))
            else:
                c.execute("""
                INSERT OR REPLACE INTO schedules 
                (day_id, slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_last, label)
                VALUES (?, ?, '00', '00', 0, 0, 0, '', '', 0, '')
                """, (day_id, s))
        conn.commit()
    else:
        apply_default_school_schedule_db(conn)
        conn.commit()
    conn.close()

def get_setting(key, default=None):
    """Read setting first from /config/settings.json, fallback to SQLite"""
    val = config_manager.get_config(key)
    if val is not None:
        return val

    conn = get_connection()
    c = conn.cursor()
    c.execute("SELECT value FROM settings WHERE key = ?", (key,))
    row = c.fetchone()
    conn.close()
    if row:
        return row[0]
    return default

def set_setting(key, value):
    """Save setting to both /config/settings.json and SQLite"""
    config_manager.set_config(key, str(value))
    conn = get_connection()
    c = conn.cursor()
    c.execute("INSERT OR REPLACE INTO settings (key, value) VALUES (?, ?)", (key, str(value)))
    conn.commit()
    conn.close()

def get_schedules_for_day(day_id):
    """
    Returns list of 24 dicts for the specified day_id (1..8).
    1=Sun, 2=Mon, 3=Tue, 4=Wed, 5=Thu, 6=Fri, 7=Sat, 8=AllDay
    """
    conn = get_connection()
    conn.row_factory = sqlite3.Row
    c = conn.cursor()
    c.execute("""
    SELECT slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_data_eng, sound_last, label
    FROM schedules
    WHERE day_id = ?
    ORDER BY slot_num ASC
    """, (day_id,))
    rows = [dict(r) for r in c.fetchall()]
    conn.close()

    slot_map = {r["slot_num"]: r for r in rows}
    full_slots = []
    for s in range(1, 25):
        if s in slot_map:
            full_slots.append(slot_map[s])
        else:
            full_slots.append({
                "slot_num": s,
                "hour": "00",
                "minute": "00",
                "sound_first": 0,
                "sound_time": 0,
                "sound_con": 0,
                "sound_data": "",
                "sound_data_eng": "",
                "sound_last": 0,
                "label": ""
            })
    return full_slots

def save_all_day_slots(day_id, slots_list):
    conn = get_connection()
    c = conn.cursor()
    for s in slots_list:
        c.execute("""
        INSERT OR REPLACE INTO schedules 
        (day_id, slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_data_eng, sound_last, label)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
        """, (
            day_id,
            s.get("slot_num"),
            str(s.get("hour", "00")).zfill(2),
            str(s.get("minute", "00")).zfill(2),
            1 if s.get("sound_first") else 0,
            1 if s.get("sound_time") else 0,
            1 if s.get("sound_con") else 0,
            s.get("sound_data", "") or "",
            s.get("sound_data_eng", "") or "",
            1 if s.get("sound_last") else 0,
            s.get("label", "") or ""
        ))
    conn.commit()
    conn.close()

def copy_day_to_all_days(source_day_id):
    """Copies schedule from one day_id to all other days (1..7 and 8)"""
    slots = get_schedules_for_day(source_day_id)
    conn = get_connection()
    c = conn.cursor()
    for d in range(1, 9):
        if d == source_day_id:
            continue
        for s in slots:
            c.execute("""
            INSERT OR REPLACE INTO schedules 
            (day_id, slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_data_eng, sound_last, label)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            """, (
                d,
                s.get("slot_num"),
                str(s.get("hour", "00")).zfill(2),
                str(s.get("minute", "00")).zfill(2),
                s.get("sound_first", 0),
                s.get("sound_time", 0),
                s.get("sound_con", 0),
                s.get("sound_data", ""),
                s.get("sound_data_eng", ""),
                s.get("sound_last", 0),
                s.get("label", "")
            ))
    conn.commit()
    conn.close()

def export_to_json(file_path):
    conn = get_connection()
    conn.row_factory = sqlite3.Row
    c = conn.cursor()
    c.execute("SELECT * FROM schedules ORDER BY day_id, slot_num")
    rows = [dict(r) for r in c.fetchall()]
    conn.close()
    with open(file_path, "w", encoding="utf-8") as f:
        json.dump(rows, f, ensure_ascii=False, indent=2)

def import_from_json(file_path):
    with open(file_path, "r", encoding="utf-8") as f:
        data = json.load(f)
    conn = get_connection()
    c = conn.cursor()
    for row in data:
        c.execute("""
        INSERT OR REPLACE INTO schedules 
        (day_id, slot_num, hour, minute, sound_first, sound_time, sound_con, sound_data, sound_data_eng, sound_last, label)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
        """, (
            row.get('day_id', 8),
            row.get('slot_num', 1),
            str(row.get('hour', '00')).zfill(2),
            str(row.get('minute', '00')).zfill(2),
            row.get('sound_first', 0),
            row.get('sound_time', 0),
            row.get('sound_con', 0),
            row.get('sound_data', ''),
            row.get('sound_data_eng', ''),
            row.get('sound_last', 0),
            row.get('label', '')
        ))
    conn.commit()
    conn.close()
