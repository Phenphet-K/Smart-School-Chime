"""
Smart School Chime (ระบบเสียงสัญญาณและประกาศเวลาโรงเรียนอัจฉริยะ)
Automated School Bell, Chime Announcement, and Wireless Live LAN Broadcast System
Features:
- Full widescreen layout (100% width, no wasted blank space on right)
- High readability, large eye-friendly fonts (11-12pt) and comfortable padding
- Mobile Push-to-Talk Announcement via QR Code / LAN URL
- Authenticated record-and-send announcements with serialized audio playback
- Silent background NVDA screen reader compatibility
"""

import os
import sys
from pathlib import Path
import datetime
import subprocess
import json
import webbrowser
import queue
import logging
import threading
from logging.handlers import RotatingFileHandler
import app_paths
from scheduler import MinuteScheduler
import updater
import tkinter as tk
from tkinter import ttk, messagebox, filedialog

try:
    import qrcode
    HAS_QRCODE = True
except ImportError:
    HAS_QRCODE = False

try:
    from PIL import Image, ImageTk
    HAS_PIL = True
    RESAMPLE_FILTER = getattr(getattr(Image, 'Resampling', None), 'LANCZOS', getattr(Image, 'LANCZOS', 1))
except ImportError:
    HAS_PIL = False
    RESAMPLE_FILTER = None

import database
import config_manager
from audio_player import AudioPlayer
from nvda_client import nvda
from broadcast_server import BroadcastServer, get_local_lan_ip

APP_TITLE = "Smart School Chime - ระบบเสียงสัญญาณและประกาศเวลาโรงเรียนอัจฉริยะ"

DAYS_MAP = [
    (8, "🌟 ทุกวัน (All Days)", "#1e3a8a", "Alt+8"),
    (2, "🟡 วันจันทร์ (Mon)", "#d97706", "Alt+2"),
    (3, "🔴 วันอังคาร (Tue)", "#dc2626", "Alt+3"),
    (4, "🟢 วันพุธ (Wed)", "#16a34a", "Alt+4"),
    (5, "🟠 วันพฤหัสฯ (Thu)", "#ea580c", "Alt+5"),
    (6, "🔵 วันศุกร์ (Fri)", "#2563eb", "Alt+6"),
    (7, "🟣 วันเสาร์ (Sat)", "#7c3aed", "Alt+7"),
    (1, "🔴 วันอาทิตย์ (Sun)", "#b91c1c", "Alt+1")
]

THAI_DAYS = ["วันจันทร์", "วันอังคาร", "วันพุธ", "วันพฤหัสบดี", "วันศุกร์", "วันเสาร์", "วันอาทิตย์"]
THAI_MONTHS = ["", "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"]

class SmartSchoolChimeApp(tk.Tk):
    def __init__(self):
        super().__init__()
        self.base_dir = getattr(sys, '_MEIPASS', os.path.dirname(os.path.abspath(__file__)))
        self.title(APP_TITLE)
        self._set_window_icon()

        # Maximize window by default (ขยายเต็มจอเป็นค่าเริ่มต้น)
        self.geometry("1300x850")
        self.minsize(1100, 700)
        try:
            self.state('zoomed')
        except Exception:
            pass

        # Make combobox popup list font large and clear
        self.option_add("*TCombobox*Listbox.font", ("Segoe UI", 11))
        self.option_add("*TCombobox*Listbox.selectBackground", "#2563eb")
        self.option_add("*TCombobox*Listbox.selectForeground", "#ffffff")

        # Runtime writes belong outside the onefile extraction directory.
        app_paths.initialize_storage()
        log_dir = app_paths.STATE_DIR / 'logs'
        log_dir.mkdir(parents=True, exist_ok=True)
        handler = RotatingFileHandler(log_dir / 'chime.log', maxBytes=2_000_000, backupCount=3, encoding='utf-8')
        handler.setFormatter(logging.Formatter('%(asctime)s %(levelname)s %(name)s %(message)s'))
        logging.getLogger().addHandler(handler)
        self._log_handler = handler
        logging.getLogger().setLevel(logging.INFO)
        self._ui_queue = queue.Queue(maxsize=128)
        self._audio_generation = 0
        self._minute_scheduler = MinuteScheduler()
        self._scheduler_after = None
        self._queue_after = None
        database.init_db()
        self.player = AudioPlayer()

        # Load Audio Lists
        self.bell_packs = self.player.get_bell_packs()
        self.thai_clips = ["(ไม่มีเสียง)"] + self.player.get_thai_announcements()
        self.eng_clips = ["(None)"] + self.player.get_eng_announcements()

        # State Variables
        self.current_day_id = 8  # Default: ทุกวัน (All Days)
        self.current_focused_slot = 1
        self.day_mode = tk.StringVar(value=database.get_setting("day_mode", "all_day"))
        self.bell_pack = tk.StringVar(value=database.get_setting("bell_pack", "Sound01"))
        self.voice_lang = tk.StringVar(value=database.get_setting("voice_lang", "thai"))
        self.auto_shutdown = tk.BooleanVar(value=bool(int(database.get_setting("auto_shutdown", "0"))))
        self.shutdown_hour = tk.StringVar(value=database.get_setting("shutdown_hour", "17"))
        self.shutdown_min = tk.StringVar(value=database.get_setting("shutdown_minute", "00"))

        self.last_triggered_minute = ""
        self.is_running = True

        # Accessibility Status string
        self.accessible_status = tk.StringVar(value="พร้อมใช้งาน ยินดีต้อนรับสู่ Smart School Chime")

        # Start Wireless LAN Live Broadcast Web Server
        self.broadcast_server = BroadcastServer(
            http_port=5000,
            https_port=5443,
            on_broadcast_received=self.handle_incoming_broadcast
        )
        self.broadcast_server.start()

        # Setup Styling & Build GUI Components
        self._setup_style()
        self._build_native_menu()
        self._build_header()
        self._build_tabs()
        self._build_statusbar()

        # Setup Keyboard Shortcuts
        self._bind_shortcuts()

        # Load initial schedule
        self.load_schedule_for_day(self.current_day_id, announce=False)

        # Tk variables and widgets are only accessed on the UI thread.
        self._queue_after = self.after(50, self._drain_ui_queue)
        self._scheduler_after = self.after(100, self._scheduler_loop)

        self.protocol("WM_DELETE_WINDOW", self.on_close)

        # Background speech announcement for screen reader users
        self._initial_after = self.after(600, self._initial_announce)

        # Background auto-check for updates from GitHub Releases
        self._update_check_after = self.after(4000, self._check_update_background)

    def _initial_announce(self):
        urls = self.broadcast_server.get_urls()
        msg = f"ยินดีต้อนรับสู่ {APP_TITLE} สแกน QR Code ในหน้าประกาศเพื่อจับคู่มือถือ กด F1 เพื่อฟังคู่มือคีย์ลัด"
        nvda.speak(msg)
        self.set_log("เปิดโปรแกรมสำเร็จ หน้าจอขยายเต็มจอพร้อมใช้งาน")

    def _set_window_icon(self):
        """Set window and taskbar icon from icon.ico / icon.png / logo.png / logo.ico"""
        base_dir = getattr(sys, '_MEIPASS', os.path.dirname(os.path.abspath(__file__)))

        # Windows taskbar AppUserModelID to group and display the custom icon properly
        try:
            import ctypes
            ctypes.windll.shell32.SetCurrentProcessExplicitAppUserModelID("SmartSchoolChime.App.1.0")
        except Exception:
            pass

        candidates = [
            os.path.join(base_dir, "icon.ico"),
            os.path.join(base_dir, "logo.ico"),
            os.path.join(base_dir, "icon.png"),
            os.path.join(base_dir, "logo.png"),
            os.path.join(base_dir, "assets", "stt-icon.ico"),
            os.path.join(os.getcwd(), "icon.ico"),
            os.path.join(os.getcwd(), "logo.ico"),
            os.path.join(os.getcwd(), "icon.png"),
            os.path.join(os.getcwd(), "logo.png"),
        ]

        for path in candidates:
            if os.path.exists(path):
                try:
                    if path.lower().endswith(".ico"):
                        self.iconbitmap(path)
                        return
                    elif HAS_PIL:
                        img = Image.open(path)
                        self._icon_image = ImageTk.PhotoImage(img)
                        self.iconphoto(False, self._icon_image)
                        return
                except Exception:
                    continue

    def _setup_style(self):
        """Configure eye-friendly, comfortable colors and high-contrast large readable typography"""
        self.style = ttk.Style(self)
        self.style.theme_use("clam")

        self.configure(bg="#f8fafc")
        self.style.configure(".", font=("Segoe UI", 11), background="#f8fafc", foreground="#0f172a")

        # Header Styles
        self.style.configure("Header.TFrame", background="#1e293b")
        self.style.configure("Clock.TLabel", font=("Segoe UI", 32, "bold"), foreground="#38bdf8", background="#1e293b")
        self.style.configure("Date.TLabel", font=("Segoe UI", 12), foreground="#f1f5f9", background="#1e293b")
        self.style.configure("NextEvent.TLabel", font=("Segoe UI", 12, "bold"), foreground="#fef08a", background="#1e293b")

        # Tab Notebook Styles (Large readable tabs)
        self.style.configure("TNotebook", background="#f8fafc", borderwidth=0)
        self.style.configure("TNotebook.Tab", font=("Segoe UI", 11, "bold"), padding=[22, 10], background="#e2e8f0", foreground="#334155")
        self.style.map("TNotebook.Tab",
            background=[("selected", "#2563eb"), ("active", "#cbd5e1")],
            foreground=[("selected", "#ffffff"), ("active", "#0f172a")]
        )

        # Controls & Table Styles
        self.style.configure("TFrame", background="#f8fafc")
        self.style.configure("TableHeader.TLabel", font=("Segoe UI", 11, "bold"), background="#e2e8f0", foreground="#1e293b", padding=6)
        self.style.configure("TCombobox", font=("Segoe UI", 11), padding=4)

    def _build_native_menu(self):
        """Build native Win32 Menu Bar"""
        menubar = tk.Menu(self)

        # 1. Menu แฟ้ม (File)
        menu_file = tk.Menu(menubar, tearoff=0)
        menu_file.add_command(label="💾 บันทึกตารางเวลานี้ (Ctrl+S)", command=self.save_current_day_schedule, accelerator="Ctrl+S")
        menu_file.add_command(label="📋 นำตารางนี้ไปใช้กับทุกวัน (Ctrl+Shift+A)", command=self.copy_current_to_all_days, accelerator="Ctrl+Shift+A")
        menu_file.add_command(label="🔄 คืนค่าตารางมาตรฐานโรงเรียน (Ctrl+R)", command=self.confirm_reset_default, accelerator="Ctrl+R")
        menu_file.add_separator()
        menu_file.add_command(label="📤 ส่งออกไฟล์สำรอง (JSON)...", command=self.export_backup)
        menu_file.add_command(label="📥 นำเข้าไฟล์สำรอง (JSON)...", command=self.import_backup)
        menu_file.add_separator()
        menu_file.add_command(label="❌ ออกจากโปรแกรม (Alt+F4)", command=self.on_close, accelerator="Alt+F4")
        menubar.add_cascade(label="📁 แฟ้ม (File)", menu=menu_file, underline=0)

        # 2. Menu เลือกวัน (Days)
        menu_days = tk.Menu(menubar, tearoff=0)
        for day_id, label, color, shortcut in DAYS_MAP:
            menu_days.add_command(
                label=f"{label}  ({shortcut})",
                command=lambda d=day_id: self.select_day(d)
            )
        menubar.add_cascade(label="📅 เลือกวัน (Days)", menu=menu_days, underline=0)

        # 3. Menu ประกาศ (Live Broadcast)
        menu_broadcast = tk.Menu(menubar, tearoff=0)
        menu_broadcast.add_command(label="📢 เปิดหน้า QR Code ประกาศทางมือถือ (Ctrl+B)", command=lambda: self.notebook.select(1), accelerator="Ctrl+B")
        menu_broadcast.add_command(label="🌐 เปิดหน้าเว็บพูดประกาศในเบราว์เซอร์", command=self.open_web_broadcast)
        menu_broadcast.add_command(label="📋 คัดลอก URL หน้าพูดประกาศ", command=self.copy_broadcast_url)
        menu_broadcast.add_separator()
        menu_broadcast.add_command(label="⏹️ ตัดเสียงประกาศทันที (Esc)", command=self.stop_audio, accelerator="Esc")
        menubar.add_cascade(label="📢 ประกาศ (Broadcast)", menu=menu_broadcast, underline=0)

        # 4. Menu เสียง (Audio)
        menu_audio = tk.Menu(menubar, tearoff=0)
        menu_audio.add_command(label="▶️ ทดสอบเล่นเสียงคาบที่เลือก (Ctrl+T)", command=lambda: self.test_slot(self.current_focused_slot), accelerator="Ctrl+T")
        menu_audio.add_command(label="🔔 ทดสอบกริ่งเริ่ม (Ctrl+1)", command=lambda: self.player.play_bell(self.bell_pack.get(), "First"), accelerator="Ctrl+1")
        menu_audio.add_command(label="🗣️ ทดสอบขานเวลาปัจจุบัน (Ctrl+2)", command=self.test_current_time_voice, accelerator="Ctrl+2")
        menu_audio.add_command(label="🔕 ทดสอบกริ่งเลิก (Ctrl+3)", command=lambda: self.player.play_bell(self.bell_pack.get(), "Last"), accelerator="Ctrl+3")
        menu_audio.add_separator()
        menu_audio.add_command(label="⏹️ หยุดเล่นเสียงทันที (Esc)", command=self.stop_audio, accelerator="Esc")
        menubar.add_cascade(label="🔊 ระบบเสียง (Audio)", menu=menu_audio, underline=0)

        # 5. Menu ตั้งค่า (Settings)
        menu_settings = tk.Menu(menubar, tearoff=0)
        menu_settings.add_command(label="⚙️ ไปยังหน้าจอตั้งค่าระบบ (Ctrl+,)", command=lambda: self.notebook.select(2), accelerator="Ctrl+,")
        menu_settings.add_separator()
        menu_settings.add_command(label="🔔 โหมดตารางเดียวกันทุกวัน (All Days)", command=lambda: self._set_mode_via_menu("all_day"))
        menu_settings.add_command(label="📅 โหมดแยกตารางตามวัน (Each Day)", command=lambda: self._set_mode_via_menu("each_day"))
        menu_settings.add_command(label='ยกเลิกการปิดเครื่องอัตโนมัติ', command=self.cancel_shutdown)
        menubar.add_cascade(label="⚙️ ตั้งค่า (Settings)", menu=menu_settings, underline=0)

        # 6. Menu ช่วยเหลือ (Help)
        menu_help = tk.Menu(menubar, tearoff=0)
        menu_help.add_command(label="📢 อ่านสรุปเวลาและเสียงถัดไป (F5)", command=self.speak_summary_nvda, accelerator="F5")
        menu_help.add_command(label="⌨️ คู่มือคีย์ลัดการใช้งาน (F1)", command=self.show_nvda_help, accelerator="F1")
        menu_help.add_separator()
        menu_help.add_command(label="🔄 ตรวจสอบการอัปเดต...", command=self.check_updates_interactive)
        menu_help.add_command(label="ℹ️ เกี่ยวกับ Smart School Chime", command=self.show_about_dialog)
        menubar.add_cascade(label="❓ ช่วยเหลือ (Help)", menu=menu_help, underline=0)

        self.config(menu=menubar)

    def _set_mode_via_menu(self, mode):
        self.day_mode.set(mode)
        self.on_mode_change()
        txt = "เปลี่ยนเป็นโหมดตารางเวลาเดียวกันทุกวัน" if mode == "all_day" else "เปลี่ยนเป็นโหมดแยกตารางรายวัน"
        self.announce(txt)

    def _build_header(self):
        """Build top banner with title, next event, and large readable digital clock"""
        header = ttk.Frame(self, style="Header.TFrame", padding="16 12 16 12")
        header.pack(fill=tk.X, side=tk.TOP)

        left_box = ttk.Frame(header, style="Header.TFrame")
        left_box.pack(side=tk.LEFT, fill=tk.Y)

        title_row = ttk.Frame(left_box, style="Header.TFrame")
        title_row.pack(anchor="w")

        # Load header logo image if available
        has_logo_img = False
        logo_path = os.path.join(self.base_dir, "logo.png")
        if not os.path.exists(logo_path):
            logo_path = os.path.join(self.base_dir, "icon.png")

        if HAS_PIL and os.path.exists(logo_path):
            try:
                raw_logo = Image.open(logo_path)
                resized_logo = raw_logo.resize((42, 42), RESAMPLE_FILTER)
                self._header_logo_img = ImageTk.PhotoImage(resized_logo)
                lbl_logo = ttk.Label(title_row, image=self._header_logo_img, background="#1e293b")
                lbl_logo.pack(side=tk.LEFT, padx=(0, 10))
                has_logo_img = True
            except Exception:
                has_logo_img = False

        header_title_text = "Smart School Chime" if has_logo_img else "🔔 Smart School Chime"
        title = ttk.Label(
            title_row,
            text=header_title_text,
            font=("Segoe UI", 20, "bold"),
            foreground="#ffffff",
            background="#1e293b"
        )
        title.pack(side=tk.LEFT, anchor="w")

        # Subtitle without any "Universal Accessibility Edition" text
        subtitle = ttk.Label(
            left_box,
            text="ระบบเสียงสัญญาณเตือนเวลาและประกาศโรงเรียนอัตโนมัติ",
            font=("Segoe UI", 11),
            foreground="#94a3b8",
            background="#1e293b"
        )
        subtitle.pack(anchor="w", pady=(2, 4))

        self.lbl_next_event = ttk.Label(
            left_box,
            text="⏳ เสียงถัดไป: กำลังคำนวณ...",
            style="NextEvent.TLabel"
        )
        self.lbl_next_event.pack(anchor="w", pady=(2, 0))

        right_box = ttk.Frame(header, style="Header.TFrame")
        right_box.pack(side=tk.RIGHT, fill=tk.Y)

        self.lbl_clock = ttk.Label(right_box, text="00:00:00", style="Clock.TLabel")
        self.lbl_clock.pack(anchor="e")

        self.lbl_date = ttk.Label(right_box, text="", style="Date.TLabel")
        self.lbl_date.pack(anchor="e", pady=(3, 0))

    def _build_tabs(self):
        self.notebook = ttk.Notebook(self)
        self.notebook.pack(fill=tk.BOTH, expand=True, padx=12, pady=6)

        # Tab 1: Schedule
        self.tab_schedule = ttk.Frame(self.notebook)
        self.notebook.add(self.tab_schedule, text="  🕒 ตารางเวลาเรียน (Schedule)  ")
        self._build_schedule_tab()

        # Tab 2: Live Mobile Broadcast (QR Code & LAN URL)
        self.tab_broadcast = ttk.Frame(self.notebook)
        self.notebook.add(self.tab_broadcast, text="  📢 ประกาศผ่านมือถือ (Live Broadcast)  ")
        self._build_broadcast_tab()

        # Tab 3: Settings
        self.tab_settings = ttk.Frame(self.notebook)
        self.notebook.add(self.tab_settings, text="  ⚙️ ตั้งค่าระบบ (Settings)  ")
        self._build_settings_tab()

    def _build_schedule_tab(self):
        # 1. Day selector buttons bar
        day_bar = tk.Frame(self.tab_schedule, bg="#e2e8f0", padx=10, pady=8)
        day_bar.pack(fill=tk.X, padx=2, pady=4)

        lbl_day = tk.Label(
            day_bar,
            text="📅 เลือกวัน:",
            font=("Segoe UI", 11, "bold"),
            bg="#e2e8f0",
            fg="#1e293b"
        )
        lbl_day.pack(side=tk.LEFT, padx=(4, 10))

        self.day_buttons = {}
        for day_id, label, color, shortcut in DAYS_MAP:
            btn = tk.Button(
                day_bar,
                text=label,
                font=("Segoe UI", 10, "bold"),
                bg="#ffffff",
                fg="#334155",
                activebackground="#2563eb",
                activeforeground="#ffffff",
                relief="flat",
                bd=1,
                padx=12,
                pady=5,
                cursor="hand2",
                command=lambda d=day_id: self.select_day(d)
            )
            btn.pack(side=tk.LEFT, padx=3)
            btn.bind("<FocusIn>", lambda e, d=label, s=shortcut: self.announce(f"ปุ่มเลือก {d} คีย์ลัด {s}"))
            self.day_buttons[day_id] = btn

        # Quick action button: Reset to Default Thai School Timetable
        btn_default = tk.Button(
            day_bar,
            text="🔄 คืนค่าตารางมาตรฐานโรงเรียน",
            font=("Segoe UI", 10, "bold"),
            bg="#f1f5f9",
            fg="#0f172a",
            relief="solid",
            bd=1,
            padx=12,
            pady=5,
            cursor="hand2",
            command=self.confirm_reset_default
        )
        btn_default.pack(side=tk.RIGHT, padx=4)
        btn_default.bind("<FocusIn>", lambda e: self.announce("ปุ่มคืนค่าตารางเวลามาตรฐานโรงเรียน คีย์ลัด Ctrl+R"))

        # 2. Middle: Scrollable Table that stretches 100% full width
        container = ttk.Frame(self.tab_schedule)
        container.pack(fill=tk.BOTH, expand=True, padx=4, pady=4)

        self.canvas = tk.Canvas(container, borderwidth=0, highlightthickness=0, bg="#ffffff")
        scrollbar = ttk.Scrollbar(container, orient=tk.VERTICAL, command=self.canvas.yview)
        self.scrollable_frame = tk.Frame(self.canvas, bg="#ffffff")

        self.scrollable_frame.bind(
            "<Configure>",
            lambda e: self.canvas.configure(scrollregion=self.canvas.bbox("all"))
        )
        self.canvas_window = self.canvas.create_window((0, 0), window=self.scrollable_frame, anchor="nw")
        self.canvas.configure(yscrollcommand=scrollbar.set)

        # CRITICAL: Dynamically stretch scrollable frame to 100% canvas width!
        # Eliminates the huge empty gap on the right completely!
        def _on_canvas_configure(event):
            self.canvas.itemconfig(self.canvas_window, width=event.width)
        self.canvas.bind('<Configure>', _on_canvas_configure)

        def _on_mousewheel(event):
            self.canvas.yview_scroll(int(-1 * (event.delta / 120)), "units")
        self.canvas.bind_all("<MouseWheel>", _on_mousewheel)

        self.canvas.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        scrollbar.pack(side=tk.RIGHT, fill=tk.Y)

        # 3. Table Column Headers - Full width Grid
        header_frame = tk.Frame(self.scrollable_frame, bg="#e2e8f0", padx=6, pady=6)
        header_frame.pack(fill=tk.X, expand=True, padx=4, pady=(2, 4))

        # Configure columns for 100% responsive expansion
        # Col 5 (Thai file) and Col 6 (Eng file) expand with weight 5 and 4!
        self._apply_column_weights(header_frame)

        cols = [
            (0, "คาบ", "center"),
            (1, "เวลา (ชม:นาที)", "center"),
            (2, "🔔 กริ่งเริ่ม", "w"),
            (3, "🗣️ ขานเวลา", "w"),
            (4, "📢 เปิดกิจกรรม", "w"),
            (5, "ไฟล์เสียงกิจกรรม (ไทย)", "w"),
            (6, "ไฟล์เสียงกิจกรรม (Eng)", "w"),
            (7, "🔕 กริ่งเลิก", "w"),
            (8, "ฟังเสียง", "center")
        ]
        for col_idx, name, anc in cols:
            lbl = tk.Label(
                header_frame,
                text=name,
                font=("Segoe UI", 11, "bold"),
                bg="#e2e8f0",
                fg="#1e293b",
                anchor=anc,
                padx=6,
                pady=4
            )
            lbl.grid(row=0, column=col_idx, sticky="nsew", padx=2, pady=2)

        # 4. Build 24 Slot Rows - Full width Grid with large readable fonts
        self.slot_widgets = []
        for i in range(1, 25):
            row_bg = "#ffffff" if i % 2 == 1 else "#f8fafc"
            row = tk.Frame(self.scrollable_frame, bg=row_bg, padx=6, pady=4, bd=1, relief="solid")
            row.pack(fill=tk.X, expand=True, padx=4, pady=2)
            self._apply_column_weights(row)

            # Col 0: Slot number badge
            lbl_slot = tk.Label(
                row,
                text=f"คาบ {i:02d}",
                font=("Segoe UI", 11, "bold"),
                bg="#e0e7ff" if i <= 14 else "#f1f5f9",
                fg="#1e3a8a" if i <= 14 else "#64748b",
                anchor="center",
                relief="flat",
                padx=4,
                pady=3
            )
            lbl_slot.grid(row=0, column=0, sticky="nsew", padx=3, pady=2)

            # Col 1: Hour & Minute Comboboxes
            time_box = tk.Frame(row, bg=row_bg)
            time_box.grid(row=0, column=1, sticky="nsew", padx=3, pady=2)

            hour_var = tk.StringVar(value="00")
            combo_hour = ttk.Combobox(time_box, textvariable=hour_var, values=[f"{h:02d}" for h in range(24)], width=3, state="readonly", font=("Segoe UI", 11))
            combo_hour.pack(side=tk.LEFT, padx=1)
            self._setup_accessible_widget(combo_hour, row, f"คาบที่ {i:02d} ชั่วโมง", i)

            sep_lbl = tk.Label(time_box, text=":", font=("Segoe UI", 12, "bold"), bg=row_bg, fg="#0f172a")
            sep_lbl.pack(side=tk.LEFT, padx=2)

            min_var = tk.StringVar(value="00")
            combo_min = ttk.Combobox(time_box, textvariable=min_var, values=[f"{m:02d}" for m in range(60)], width=3, state="readonly", font=("Segoe UI", 11))
            combo_min.pack(side=tk.LEFT, padx=1)
            self._setup_accessible_widget(combo_min, row, f"คาบที่ {i:02d} นาที", i)

            # Col 2: Checkbox กริ่งเริ่ม
            chk_first_var = tk.BooleanVar(value=False)
            chk_first = tk.Checkbutton(row, text="กริ่งเริ่ม", variable=chk_first_var, bg=row_bg, activebackground=row_bg, font=("Segoe UI", 11), anchor="w", padx=4)
            chk_first.grid(row=0, column=2, sticky="nsew", padx=3, pady=2)
            self._setup_accessible_widget(chk_first, row, f"คาบที่ {i:02d} กริ่งเริ่ม", i)

            # Col 3: Checkbox ขานเวลา
            chk_time_var = tk.BooleanVar(value=False)
            chk_time = tk.Checkbutton(row, text="ขานเวลา", variable=chk_time_var, bg=row_bg, activebackground=row_bg, font=("Segoe UI", 11), anchor="w", padx=4)
            chk_time.grid(row=0, column=3, sticky="nsew", padx=3, pady=2)
            self._setup_accessible_widget(chk_time, row, f"คาบที่ {i:02d} ขานเวลา", i)

            # Col 4: Checkbox เปิดเสียงกิจกรรม
            chk_con_var = tk.BooleanVar(value=False)
            chk_con = tk.Checkbutton(row, text="เปิดกิจกรรม", variable=chk_con_var, bg=row_bg, activebackground=row_bg, font=("Segoe UI", 11), anchor="w", padx=4)
            chk_con.grid(row=0, column=4, sticky="nsew", padx=3, pady=2)
            self._setup_accessible_widget(chk_con, row, f"คาบที่ {i:02d} เปิดเสียงกิจกรรม", i)

            # Col 5: Thai sound combobox (Stretches across available space!)
            con_thai_var = tk.StringVar(value="(ไม่มีเสียง)")
            combo_con_thai = ttk.Combobox(row, textvariable=con_thai_var, values=self.thai_clips, state="readonly", font=("Segoe UI", 11))
            combo_con_thai.grid(row=0, column=5, sticky="ew", padx=4, pady=2)
            self._setup_accessible_widget(combo_con_thai, row, f"คาบที่ {i:02d} ไฟล์เสียงไทย", i)

            # Col 6: English sound combobox (Stretches across available space!)
            con_eng_var = tk.StringVar(value="(None)")
            combo_con_eng = ttk.Combobox(row, textvariable=con_eng_var, values=self.eng_clips, state="readonly", font=("Segoe UI", 11))
            combo_con_eng.grid(row=0, column=6, sticky="ew", padx=4, pady=2)
            self._setup_accessible_widget(combo_con_eng, row, f"คาบที่ {i:02d} ไฟล์เสียงอังกฤษ", i)

            # Col 7: Checkbox กริ่งเลิก
            chk_last_var = tk.BooleanVar(value=False)
            chk_last = tk.Checkbutton(row, text="กริ่งเลิก", variable=chk_last_var, bg=row_bg, activebackground=row_bg, font=("Segoe UI", 11), anchor="w", padx=4)
            chk_last.grid(row=0, column=7, sticky="nsew", padx=3, pady=2)
            self._setup_accessible_widget(chk_last, row, f"คาบที่ {i:02d} กริ่งเลิก", i)

            # Col 8: Test Play Button
            btn_test = tk.Button(
                row,
                text="▶ ฟัง",
                font=("Segoe UI", 9, "bold"),
                bg="#e0f2fe",
                fg="#0369a1",
                activebackground="#0284c7",
                activeforeground="#ffffff",
                relief="flat",
                bd=1,
                padx=8,
                pady=2,
                cursor="hand2",
                command=lambda s_idx=i: self.test_slot(s_idx)
            )
            btn_test.grid(row=0, column=8, sticky="nsew", padx=3, pady=2)
            self._setup_accessible_widget(btn_test, row, f"คาบที่ {i:02d} ปุ่มทดสอบเล่นเสียง", i)

            self.slot_widgets.append({
                "slot_num": i,
                "row_frame": row,
                "hour": hour_var,
                "minute": min_var,
                "sound_first": chk_first_var,
                "sound_time": chk_time_var,
                "sound_con": chk_con_var,
                "sound_data": con_thai_var,
                "sound_data_eng": con_eng_var,
                "sound_last": chk_last_var,
                "base_bg": row_bg
            })

        # 5. Bottom Action Bar (Large, comfortable, no NVDA badges)
        bottom_bar = tk.Frame(self.tab_schedule, bg="#e2e8f0", padx=16, pady=12)
        bottom_bar.pack(fill=tk.X, side=tk.BOTTOM)

        btn_save = tk.Button(
            bottom_bar,
            text="💾 บันทึกตารางเวลานี้ (Ctrl+S)",
            font=("Segoe UI", 11, "bold"),
            bg="#059669",
            fg="#ffffff",
            activebackground="#047857",
            activeforeground="#ffffff",
            relief="flat",
            bd=0,
            padx=18,
            pady=8,
            cursor="hand2",
            command=self.save_current_day_schedule
        )
        btn_save.pack(side=tk.LEFT, padx=(0, 10))
        btn_save.bind("<FocusIn>", lambda e: self.announce("ปุ่มบันทึกตารางเวลานี้ คีย์ลัด Ctrl+S"))

        btn_copy = tk.Button(
            bottom_bar,
            text="📋 นำตารางนี้ไปใช้กับทุกวัน",
            font=("Segoe UI", 11, "bold"),
            bg="#2563eb",
            fg="#ffffff",
            activebackground="#1d4ed8",
            activeforeground="#ffffff",
            relief="flat",
            bd=0,
            padx=16,
            pady=8,
            cursor="hand2",
            command=self.copy_current_to_all_days
        )
        btn_copy.pack(side=tk.LEFT, padx=6)
        btn_copy.bind("<FocusIn>", lambda e: self.announce("ปุ่มนำตารางนี้ไปใช้กับทุกวัน"))

        btn_goto_bc = tk.Button(
            bottom_bar,
            text="📢 ประกาศผ่านมือถือ / QR Code (Ctrl+B)",
            font=("Segoe UI", 11, "bold"),
            bg="#0284c7",
            fg="#ffffff",
            activebackground="#0369a1",
            activeforeground="#ffffff",
            relief="flat",
            bd=0,
            padx=16,
            pady=8,
            cursor="hand2",
            command=lambda: self.notebook.select(1)
        )
        btn_goto_bc.pack(side=tk.LEFT, padx=6)
        btn_goto_bc.bind("<FocusIn>", lambda e: self.announce("ปุ่มเปิดหน้า QR Code ประกาศทางมือถือ คีย์ลัด Ctrl+B"))

        btn_stop = tk.Button(
            bottom_bar,
            text="⏹️ หยุดเสียงทันที (Esc)",
            font=("Segoe UI", 11, "bold"),
            bg="#dc2626",
            fg="#ffffff",
            activebackground="#b91c1c",
            activeforeground="#ffffff",
            relief="flat",
            bd=0,
            padx=18,
            pady=8,
            cursor="hand2",
            command=self.stop_audio
        )
        btn_stop.pack(side=tk.RIGHT, padx=4)
        btn_stop.bind("<FocusIn>", lambda e: self.announce("ปุ่มหยุดเล่นเสียงทันที คีย์ลัด Escape"))

    def _apply_column_weights(self, frame):
        """Configure grid column weights so table fills 100% of widescreen without blank space on right"""
        frame.columnconfigure(0, weight=0, minsize=80)    # คาบ
        frame.columnconfigure(1, weight=0, minsize=140)   # เวลา
        frame.columnconfigure(2, weight=0, minsize=110)   # กริ่งเริ่ม
        frame.columnconfigure(3, weight=0, minsize=110)   # ขานเวลา
        frame.columnconfigure(4, weight=0, minsize=130)   # เปิดกิจกรรม
        frame.columnconfigure(5, weight=6, minsize=280)   # เสียงไทย (Stretches full width!)
        frame.columnconfigure(6, weight=5, minsize=230)   # เสียง Eng (Stretches full width!)
        frame.columnconfigure(7, weight=0, minsize=110)   # กริ่งเลิก
        frame.columnconfigure(8, weight=0, minsize=90)    # ฟังเสียง

    def _setup_accessible_widget(self, widget, row_frame, desc, slot_num):
        def on_focus(e):
            self.current_focused_slot = slot_num
            self.announce(desc)
            self._ensure_widget_visible(widget)
        widget.bind("<FocusIn>", on_focus)

    def _ensure_widget_visible(self, widget):
        try:
            self.update_idletasks()
            widget_y = widget.winfo_rooty() - self.scrollable_frame.winfo_rooty()
            frame_h = self.scrollable_frame.winfo_height()
            canvas_h = self.canvas.winfo_height()
            if frame_h > canvas_h and canvas_h > 0:
                pos = max(0.0, min(1.0, (widget_y - 40) / float(frame_h)))
                self.canvas.yview_moveto(pos)
        except Exception:
            pass

    def _build_broadcast_tab(self):
        """Build the Mobile QR Code & LAN Live Push-to-Talk Announcement Tab"""
        urls = self.broadcast_server.get_urls()
        https_url = urls["https"]
        http_url = urls["http"]

        main_box = tk.Frame(self.tab_broadcast, bg="#f8fafc", padx=24, pady=20)
        main_box.pack(fill=tk.BOTH, expand=True)

        # Left Column: QR Code Display Card
        left_card = tk.LabelFrame(
            main_box,
            text=" 📱 สแกน QR Code ด้วยมือถือเพื่อพูดประกาศ ",
            font=("Segoe UI", 12, "bold"),
            bg="#ffffff",
            fg="#1e293b",
            padx=20,
            pady=18,
            bd=1,
            relief="solid"
        )
        left_card.pack(side=tk.LEFT, fill=tk.BOTH, padx=(0, 20), pady=4)

        if HAS_QRCODE and HAS_PIL:
            try:
                qr = qrcode.QRCode(box_size=7, border=2)
                qr.add_data(https_url)
                qr.make(fit=True)
                qr_img = qr.make_image(fill_color="#0f172a", back_color="#ffffff").convert('RGB')
                filter_fn = RESAMPLE_FILTER if RESAMPLE_FILTER is not None else 1
                qr_img = qr_img.resize((270, 270), filter_fn)
                self.qr_photo = ImageTk.PhotoImage(qr_img)
                lbl_qr = tk.Label(left_card, image=self.qr_photo, bg="#ffffff")
                lbl_qr.pack(anchor="center", pady=(8, 14))
            except Exception as e:
                lbl_qr = tk.Label(left_card, text=f"QR Code: {e}", bg="#ffffff")
                lbl_qr.pack(pady=20)
        else:
            fallback_box = tk.Frame(left_card, bg="#f1f5f9", padx=20, pady=40, bd=1, relief="solid")
            fallback_box.pack(anchor="center", pady=(8, 14))
            tk.Label(fallback_box, text="📱 เข้าใช้งานผ่าน URL:", font=("Segoe UI", 11, "bold"), bg="#f1f5f9", fg="#1e293b").pack(pady=2)
            tk.Label(fallback_box, text=https_url, font=("Segoe UI", 12, "bold"), bg="#f1f5f9", fg="#2563eb").pack(pady=6)
            tk.Label(fallback_box, text="(คัดลอกหรือเปิดจากแถบด้านขวาได้ทันที)", font=("Segoe UI", 10), bg="#f1f5f9", fg="#64748b").pack(pady=2)

        lbl_scan_hint = tk.Label(
            left_card,
            text="สแกนด้วยกล้องมือถือที่ต่อ Wi-Fi เดียวกัน\nกดค้างเพื่ออัดเสียง ปล่อยเพื่อส่งประกาศ",
            font=("Segoe UI", 11, "bold"),
            bg="#ffffff",
            fg="#2563eb",
            justify="center"
        )
        lbl_scan_hint.pack(anchor="center", pady=(2, 6))

        # Right Column: LAN URLs, Features, and Live Event Log
        right_box = tk.Frame(main_box, bg="#f8fafc")
        right_box.pack(side=tk.LEFT, fill=tk.BOTH, expand=True, pady=4)

        # 1. Connection Card
        conn_card = tk.LabelFrame(
            right_box,
            text=" 🌐 ที่อยู่เว็บไซต์สำหรับเข้าผ่านเบราว์เซอร์ในวง LAN เดียวกัน ",
            font=("Segoe UI", 12, "bold"),
            bg="#ffffff",
            fg="#1e293b",
            padx=18,
            pady=14,
            bd=1,
            relief="solid"
        )
        conn_card.pack(fill=tk.X, pady=(0, 16))

        # Primary HTTPS URL
        row_https = tk.Frame(conn_card, bg="#ffffff")
        row_https.pack(fill=tk.X, pady=6)
        tk.Label(row_https, text="🔒 มือถือ (HTTPS):", font=("Segoe UI", 11, "bold"), bg="#ffffff", fg="#059669", width=18, anchor="w").pack(side=tk.LEFT)
        entry_https = tk.Entry(row_https, font=("Segoe UI", 12, "bold"), bg="#f1f5f9", fg="#1e293b", bd=1, relief="solid")
        entry_https.insert(0, https_url)
        entry_https.configure(state="readonly")
        entry_https.pack(side=tk.LEFT, fill=tk.X, expand=True, padx=8)

        btn_copy_https = tk.Button(row_https, text="📋 คัดลอก", font=("Segoe UI", 10), bg="#e2e8f0", padx=10, command=lambda: self._copy_to_clipboard(https_url))
        btn_copy_https.pack(side=tk.LEFT, padx=3)
        btn_open_https = tk.Button(row_https, text="🌐 เปิดดู", font=("Segoe UI", 10, "bold"), bg="#2563eb", fg="#ffffff", padx=10, command=lambda: webbrowser.open(https_url))
        btn_open_https.pack(side=tk.LEFT, padx=3)

        # Secondary HTTP URL
        row_http = tk.Frame(conn_card, bg="#ffffff")
        row_http.pack(fill=tk.X, pady=6)
        tk.Label(row_http, text="💻 คอมพิวเตอร์ (HTTP):", font=("Segoe UI", 11), bg="#ffffff", fg="#64748b", width=18, anchor="w").pack(side=tk.LEFT)
        entry_http = tk.Entry(row_http, font=("Segoe UI", 11), bg="#f8fafc", fg="#475569", bd=1, relief="solid")
        entry_http.insert(0, http_url)
        entry_http.configure(state="readonly")
        entry_http.pack(side=tk.LEFT, fill=tk.X, expand=True, padx=8)

        btn_copy_http = tk.Button(row_http, text="📋 คัดลอก", font=("Segoe UI", 10), bg="#e2e8f0", padx=10, command=lambda: self._copy_to_clipboard(http_url))
        btn_copy_http.pack(side=tk.LEFT, padx=3)
        btn_open_http = tk.Button(row_http, text="🌐 เปิดดู", font=("Segoe UI", 10), bg="#f1f5f9", padx=10, command=lambda: webbrowser.open(http_url))
        btn_open_http.pack(side=tk.LEFT, padx=3)

        # 2. Audio Processing Info Badges
        feat_card = tk.Frame(conn_card, bg="#ffffff")
        feat_card.pack(fill=tk.X, pady=(12, 4))

        lbl_f1 = tk.Label(feat_card, text="🛡️ ลดเสียงรบกวนตามความสามารถของมือถือ", font=("Segoe UI", 10, "bold"), bg="#ecfdf5", fg="#047857", padx=10, pady=4, relief="solid", bd=1)
        lbl_f1.pack(side=tk.LEFT, padx=(0, 8))

        lbl_f2 = tk.Label(feat_card, text="⏱️ อัดแล้วส่งเมื่อปล่อยปุ่ม (ไม่ใช่ถ่ายทอดสด)", font=("Segoe UI", 10, "bold"), bg="#eff6ff", fg="#1d4ed8", padx=10, pady=4, relief="solid", bd=1)
        lbl_f2.pack(side=tk.LEFT, padx=8)

        lbl_f3 = tk.Label(feat_card, text="🎙️ กดค้างเพื่อพูด (Push-to-Talk): เปิด", font=("Segoe UI", 10, "bold"), bg="#fef3c7", fg="#b45309", padx=10, pady=4, relief="solid", bd=1)
        lbl_f3.pack(side=tk.LEFT, padx=8)

        # 3. Live Broadcast Log and Emergency Controls
        log_card = tk.LabelFrame(
            right_box,
            text=" 📋 ประวัติการพูดประกาศผ่านระบบไมโครโฟนไร้สาย ",
            font=("Segoe UI", 12, "bold"),
            bg="#ffffff",
            fg="#1e293b",
            padx=16,
            pady=12,
            bd=1,
            relief="solid"
        )
        log_card.pack(fill=tk.BOTH, expand=True)

        log_scroll = ttk.Scrollbar(log_card, orient=tk.VERTICAL)
        self.broadcast_listbox = tk.Listbox(
            log_card,
            font=("Segoe UI", 10),
            bg="#f8fafc",
            fg="#0f172a",
            selectbackground="#2563eb",
            selectforeground="#ffffff",
            bd=1,
            relief="solid",
            yscrollcommand=log_scroll.set
        )
        log_scroll.config(command=self.broadcast_listbox.yview)
        self.broadcast_listbox.pack(side=tk.LEFT, fill=tk.BOTH, expand=True)
        log_scroll.pack(side=tk.RIGHT, fill=tk.Y)

        status = 'พร้อมรับเสียงประกาศ (อัดแล้วส่ง)' if self.broadcast_server.httpsd else 'HTTPS เปิดไม่สำเร็จ: ตรวจพอร์ตและบันทึกระบบ'
        self.broadcast_listbox.insert(tk.END, status)

        # Bottom Bar of Broadcast Tab
        bc_bottom = tk.Frame(self.tab_broadcast, bg="#e2e8f0", padx=16, pady=12)
        bc_bottom.pack(fill=tk.X, side=tk.BOTTOM)

        btn_test_sim = tk.Button(
            bc_bottom,
            text="▶️ ทดสอบเปิดหน้าพูดประกาศในคอม",
            font=("Segoe UI", 11),
            bg="#2563eb",
            fg="#ffffff",
            activebackground="#1d4ed8",
            activeforeground="#ffffff",
            relief="flat",
            bd=0,
            padx=16,
            pady=8,
            cursor="hand2",
            command=self.open_web_broadcast
        )
        btn_test_sim.pack(side=tk.LEFT, padx=4)

        btn_stop_bc = tk.Button(
            bc_bottom,
            text="⏹️ ตัดเสียงประกาศทันที (Esc)",
            font=("Segoe UI", 11, "bold"),
            bg="#dc2626",
            fg="#ffffff",
            activebackground="#b91c1c",
            activeforeground="#ffffff",
            relief="flat",
            bd=0,
            padx=18,
            pady=8,
            cursor="hand2",
            command=self.stop_audio
        )
        btn_stop_bc.pack(side=tk.RIGHT, padx=4)
        tk.Button(bc_bottom, text='ออก QR ใหม่ / ยกเลิกสิทธิ์มือถือเดิม',
                  command=self.refresh_broadcast_pairing).pack(side=tk.LEFT, padx=8)

    def refresh_broadcast_pairing(self):
        self.broadcast_server.rotate_token()
        for child in self.tab_broadcast.winfo_children():
            child.destroy()
        self._build_broadcast_tab()
        self.announce('ออก QR ใหม่แล้ว สิทธิ์มือถือเดิมหมดอายุ')

    def report_callback_exception(self, exc_type, exc_value, traceback):
        logging.getLogger(__name__).error('UI callback failed', exc_info=(exc_type, exc_value, traceback))
        messagebox.showerror('ทำรายการไม่สำเร็จ', str(exc_value))

    def _copy_to_clipboard(self, text):
        self.clipboard_clear()
        self.clipboard_append(text)
        self.announce("คัดลอก URL เรียบร้อยแล้ว")
        messagebox.showinfo("คัดลอกแล้ว", f"คัดลอก URL:\n{text}\n\nไปยังคลิปบอร์ดเรียบร้อยแล้ว")

    def copy_broadcast_url(self):
        urls = self.broadcast_server.get_urls()
        self._copy_to_clipboard(urls["https"])

    def open_web_broadcast(self):
        urls = self.broadcast_server.get_urls()
        webbrowser.open(urls["https"])
        self.announce("เปิดหน้าเว็บพูดประกาศในเบราว์เซอร์แล้ว")

    def post_ui(self, callback):
        if not self.is_running:
            return False
        try:
            self._ui_queue.put_nowait(callback)
            return True
        except queue.Full:
            logging.getLogger(__name__).error('UI event queue full')
            return False

    def _drain_ui_queue(self):
        for _ in range(32):
            try:
                callback = self._ui_queue.get_nowait()
            except queue.Empty:
                break
            try:
                callback()
            except Exception:
                logging.getLogger(__name__).exception('UI event failed')
        if self.is_running:
            self._queue_after = self.after(50, self._drain_ui_queue)

    def handle_incoming_broadcast(self, client_ip, wav_path, play_chime):
        generation = self._audio_generation

        def accept():
            if not self.is_running or generation != self._audio_generation:
                self.broadcast_server.release_broadcast(wav_path)
                return
            self.add_broadcast_log(f'รับเสียงประกาศจาก {client_ip} เข้าคิวแล้ว')
            files = []
            if play_chime:
                files.append(self.player.get_sound_path('Bell', self.bell_pack.get(), 'First.wav'))
            files.append(wav_path)
            try:
                self.player.play_sequence_async(
                    files, enqueue=True,
                    on_finish=lambda: self.post_ui(lambda: self.add_broadcast_log(f'เล่นประกาศจาก {client_ip} สำเร็จ')),
                    on_error=lambda error: self.post_ui(lambda e=str(error): self.add_broadcast_log(f'เล่นประกาศไม่สำเร็จ: {e}')),
                    on_cleanup=lambda: self.broadcast_server.release_broadcast(wav_path))
            except Exception:
                self.broadcast_server.release_broadcast(wav_path)
                raise

        if not self.post_ui(accept):
            raise RuntimeError('Application is closing or busy')

    def add_broadcast_log(self, text):
        self.broadcast_listbox.insert(tk.END, text)
        self.broadcast_listbox.see(tk.END)
        if self.broadcast_listbox.size() > 500:
            self.broadcast_listbox.delete(0, self.broadcast_listbox.size() - 501)

    def _build_settings_tab(self):
        frame = tk.Frame(self.tab_settings, bg="#f8fafc", padx=30, pady=20)
        frame.pack(fill=tk.BOTH, expand=True)

        # 1. Operation Mode
        grp_mode = tk.LabelFrame(
            frame,
            text=" ⚙️ โหมดการใช้งานตารางเวลา (Schedule Mode) ",
            font=("Segoe UI", 11, "bold"),
            bg="#ffffff",
            fg="#1e293b",
            padx=18,
            pady=14,
            bd=1,
            relief="solid"
        )
        grp_mode.pack(fill=tk.X, pady=(0, 16))

        rb_all = tk.Radiobutton(
            grp_mode,
            text="🌟 ใช้ตารางเวลาเดียวกันทุกวัน (All Days Mode) — สะดวก และใช้ได้ทันที",
            font=("Segoe UI", 11),
            variable=self.day_mode,
            value="all_day",
            bg="#ffffff",
            activebackground="#ffffff",
            command=self.on_mode_change
        )
        rb_all.pack(anchor="w", pady=4)
        rb_all.bind("<FocusIn>", lambda e: self.announce("ตัวเลือกโหมดตารางเวลาเดียวกันทุกวัน"))

        rb_each = tk.Radiobutton(
            grp_mode,
            text="📅 แยกตารางเวลาตามวัน (Each Day Mode: จันทร์ - อาทิตย์) — เหมาะกับโรงเรียนที่มีกิจกรรมเฉพาะวัน",
            font=("Segoe UI", 11),
            variable=self.day_mode,
            value="each_day",
            bg="#ffffff",
            activebackground="#ffffff",
            command=self.on_mode_change
        )
        rb_each.pack(anchor="w", pady=4)
        rb_each.bind("<FocusIn>", lambda e: self.announce("ตัวเลือกโหมดแยกตารางเวลาตามวัน"))

        # 2. Sound & Voice Settings
        grp_sound = tk.LabelFrame(
            frame,
            text=" 🔊 การตั้งค่าเสียงกริ่งและภาษาบอกเวลา ",
            font=("Segoe UI", 11, "bold"),
            bg="#ffffff",
            fg="#1e293b",
            padx=18,
            pady=14,
            bd=1,
            relief="solid"
        )
        grp_sound.pack(fill=tk.X, pady=(0, 16))

        bell_row = tk.Frame(grp_sound, bg="#ffffff")
        bell_row.pack(fill=tk.X, pady=6)

        tk.Label(bell_row, text="🔔 ชุดเสียงกริ่ง (Bell Sound):", font=("Segoe UI", 11), bg="#ffffff", fg="#0f172a", width=24, anchor="w").pack(side=tk.LEFT)
        combo_bell = ttk.Combobox(bell_row, textvariable=self.bell_pack, values=self.bell_packs, width=14, state="readonly", font=("Segoe UI", 11))
        combo_bell.pack(side=tk.LEFT, padx=5)
        combo_bell.bind("<FocusIn>", lambda e: self.announce("เลือกชุดเสียงกริ่ง"))

        btn_bell1 = tk.Button(bell_row, text="▶ ลองฟังกริ่งเริ่ม", font=("Segoe UI", 10), bg="#f1f5f9", relief="solid", bd=1, padx=10, pady=3, command=lambda: self.player.play_bell(self.bell_pack.get(), "First"))
        btn_bell1.pack(side=tk.LEFT, padx=6)
        btn_bell1.bind("<FocusIn>", lambda e: self.announce("ปุ่มลองฟังเสียงกริ่งเริ่ม"))

        btn_bell2 = tk.Button(bell_row, text="▶ ลองฟังกริ่งเลิก", font=("Segoe UI", 10), bg="#f1f5f9", relief="solid", bd=1, padx=10, pady=3, command=lambda: self.player.play_bell(self.bell_pack.get(), "Last"))
        btn_bell2.pack(side=tk.LEFT, padx=6)
        btn_bell2.bind("<FocusIn>", lambda e: self.announce("ปุ่มลองฟังเสียงกริ่งเลิก"))

        lang_row = tk.Frame(grp_sound, bg="#ffffff")
        lang_row.pack(fill=tk.X, pady=8)
        tk.Label(lang_row, text="🗣️ ภาษาขานเวลา (Voice Language):", font=("Segoe UI", 11), bg="#ffffff", fg="#0f172a", width=24, anchor="w").pack(side=tk.LEFT)

        rb_th = tk.Radiobutton(lang_row, text="ภาษาไทย", font=("Segoe UI", 11), variable=self.voice_lang, value="thai", bg="#ffffff")
        rb_th.pack(side=tk.LEFT, padx=8)
        rb_th.bind("<FocusIn>", lambda e: self.announce("ตัวเลือกภาษาขานเวลา ภาษาไทย"))

        rb_en = tk.Radiobutton(lang_row, text="English", font=("Segoe UI", 11), variable=self.voice_lang, value="eng", bg="#ffffff")
        rb_en.pack(side=tk.LEFT, padx=8)
        rb_en.bind("<FocusIn>", lambda e: self.announce("ตัวเลือกภาษาขานเวลา ภาษาอังกฤษ"))

        rb_both = tk.Radiobutton(lang_row, text="ทั้ง 2 ภาษา (Thai + Eng)", font=("Segoe UI", 11), variable=self.voice_lang, value="both", bg="#ffffff")
        rb_both.pack(side=tk.LEFT, padx=8)
        rb_both.bind("<FocusIn>", lambda e: self.announce("ตัวเลือกภาษาขานเวลา ทั้งสองภาษา"))

        btn_test_voice = tk.Button(lang_row, text="▶ ทดสอบขานเวลาตอนนี้", font=("Segoe UI", 10), bg="#f1f5f9", relief="solid", bd=1, padx=12, pady=3, command=self.test_current_time_voice)
        btn_test_voice.pack(side=tk.LEFT, padx=16)
        btn_test_voice.bind("<FocusIn>", lambda e: self.announce("ปุ่มทดสอบขานเวลาตามเวลาปัจจุบัน"))

        # 3. Auto Shutdown
        grp_power = tk.LabelFrame(
            frame,
            text=" 💻 ระบบตั้งเวลาปิดคอมพิวเตอร์อัตโนมัติ (Auto Shutdown) ",
            font=("Segoe UI", 11, "bold"),
            bg="#ffffff",
            fg="#1e293b",
            padx=18,
            pady=14,
            bd=1,
            relief="solid"
        )
        grp_power.pack(fill=tk.X, pady=(0, 16))

        power_row = tk.Frame(grp_power, bg="#ffffff")
        power_row.pack(fill=tk.X, pady=6)

        chk_shutdown = tk.Checkbutton(
            power_row,
            text="เปิดใช้งานระบบปิดคอมพิวเตอร์อัตโนมัติเมื่อถึงเวลา:",
            font=("Segoe UI", 11),
            variable=self.auto_shutdown,
            bg="#ffffff"
        )
        chk_shutdown.pack(side=tk.LEFT)
        chk_shutdown.bind("<FocusIn>", lambda e: self.announce("ช่องกาเครื่องหมาย เปิดใช้งานระบบปิดคอมพิวเตอร์อัตโนมัติ"))

        combo_sh_h = ttk.Combobox(power_row, textvariable=self.shutdown_hour, values=[f"{h:02d}" for h in range(24)], width=4, state="readonly", font=("Segoe UI", 11))
        combo_sh_h.pack(side=tk.LEFT, padx=(10, 2))
        combo_sh_h.bind("<FocusIn>", lambda e: self.announce("เลือกชั่วโมงปิดเครื่อง"))

        tk.Label(power_row, text=":", font=("Segoe UI", 11, "bold"), bg="#ffffff").pack(side=tk.LEFT)

        combo_sh_m = ttk.Combobox(power_row, textvariable=self.shutdown_min, values=[f"{m:02d}" for m in range(60)], width=4, state="readonly", font=("Segoe UI", 11))
        combo_sh_m.pack(side=tk.LEFT, padx=(2, 10))
        combo_sh_m.bind("<FocusIn>", lambda e: self.announce("เลือกนาทีปิดเครื่อง"))

        tk.Label(power_row, text="น.", font=("Segoe UI", 11), bg="#ffffff").pack(side=tk.LEFT)

        # 4. Backup & Restore
        grp_data = tk.LabelFrame(
            frame,
            text=" 💾 สำรองและนำเข้าข้อมูล (Backup / Restore) ",
            font=("Segoe UI", 11, "bold"),
            bg="#ffffff",
            fg="#1e293b",
            padx=18,
            pady=14,
            bd=1,
            relief="solid"
        )
        grp_data.pack(fill=tk.X, pady=(0, 16))

        data_row = tk.Frame(grp_data, bg="#ffffff")
        data_row.pack(fill=tk.X, pady=6)

        btn_exp = tk.Button(data_row, text="📤 ส่งออกไฟล์สำรอง (Export JSON)", font=("Segoe UI", 10), bg="#f1f5f9", relief="solid", bd=1, padx=14, pady=5, command=self.export_backup)
        btn_exp.pack(side=tk.LEFT, padx=5)
        btn_exp.bind("<FocusIn>", lambda e: self.announce("ปุ่มส่งออกไฟล์สำรองข้อมูล JSON"))

        btn_imp = tk.Button(data_row, text="📥 นำเข้าไฟล์สำรอง (Import JSON)", font=("Segoe UI", 10), bg="#f1f5f9", relief="solid", bd=1, padx=14, pady=5, command=self.import_backup)
        btn_imp.pack(side=tk.LEFT, padx=5)
        btn_imp.bind("<FocusIn>", lambda e: self.announce("ปุ่มนำเข้าไฟล์สำรองข้อมูล JSON"))

        btn_save_settings = tk.Button(
            frame,
            text="💾 บันทึกการตั้งค่าระบบทั้งหมด",
            font=("Segoe UI", 11, "bold"),
            bg="#059669",
            fg="#ffffff",
            activebackground="#047857",
            activeforeground="#ffffff",
            relief="flat",
            bd=0,
            padx=22,
            pady=9,
            cursor="hand2",
            command=self.save_settings
        )
        btn_save_settings.pack(anchor="w", pady=10)
        btn_save_settings.bind("<FocusIn>", lambda e: self.announce("ปุ่มบันทึกการตั้งค่าระบบทั้งหมด"))

    def _build_statusbar(self):
        """Bottom Status Bar without NVDA badges"""
        statusbar = tk.Frame(self, bg="#1e293b", padx=16, pady=7)
        statusbar.pack(fill=tk.X, side=tk.BOTTOM)

        lbl_status = tk.Label(
            statusbar,
            text="🟢 ระบบเฝ้าตรวจเวลาทำงานปกติ",
            font=("Segoe UI", 10, "bold"),
            bg="#1e293b",
            fg="#4ade80"
        )
        lbl_status.pack(side=tk.LEFT, padx=(0, 14))

        # Broadcast Status Badge
        self.lbl_bc_badge = tk.Label(
            statusbar,
            text=f"📡 ประกาศ: {self.broadcast_server.lan_ip}:5443",
            font=("Segoe UI", 10, "bold"),
            bg="#1e293b",
            fg="#facc15"
        )
        self.lbl_bc_badge.pack(side=tk.LEFT, padx=10)

        self.lbl_accessibility = tk.Label(
            statusbar,
            textvariable=self.accessible_status,
            font=("Segoe UI", 10),
            bg="#1e293b",
            fg="#f1f5f9"
        )
        self.lbl_accessibility.pack(side=tk.LEFT, padx=12)

        self.lbl_log = tk.Label(
            statusbar,
            text="พร้อมใช้งาน",
            font=("Segoe UI", 10),
            bg="#1e293b",
            fg="#cbd5e1"
        )
        self.lbl_log.pack(side=tk.RIGHT)

    def _bind_shortcuts(self):
        self.bind("<Control-s>", lambda e: self.save_current_day_schedule())
        self.bind("<Control-S>", lambda e: self.save_current_day_schedule())
        self.bind("<Control-b>", lambda e: self.notebook.select(1))
        self.bind("<Control-B>", lambda e: self.notebook.select(1))
        self.bind("<Control-r>", lambda e: self.confirm_reset_default())
        self.bind("<Control-R>", lambda e: self.confirm_reset_default())
        self.bind("<Control-t>", lambda e: self.test_slot(self.current_focused_slot))
        self.bind("<Control-T>", lambda e: self.test_slot(self.current_focused_slot))
        self.bind("<Control-1>", lambda e: self.player.play_bell(self.bell_pack.get(), "First"))
        self.bind("<Control-2>", lambda e: self.test_current_time_voice())
        self.bind("<Control-3>", lambda e: self.player.play_bell(self.bell_pack.get(), "Last"))
        self.bind("<Escape>", lambda e: self.stop_audio())
        self.bind("<F1>", lambda e: self.show_nvda_help())
        self.bind("<F5>", lambda e: self.speak_summary_nvda())

        for day_id, label, color, shortcut in DAYS_MAP:
            key_num = shortcut.split("+")[1]
            self.bind(f"<Alt-Key-{key_num}>", lambda e, d=day_id: self.select_day(d))

    def announce(self, text):
        self.accessible_status.set(text)
        nvda.speak(text)

    def select_day(self, day_id):
        self.current_day_id = day_id
        day_label = [d[1] for d in DAYS_MAP if d[0] == day_id][0]

        for d_id, btn in self.day_buttons.items():
            if d_id == day_id:
                btn.configure(bg="#2563eb", fg="#ffffff", relief="solid", bd=2)
            else:
                btn.configure(bg="#ffffff", fg="#334155", relief="flat", bd=1)

        self.load_schedule_for_day(day_id, announce=True)

    def load_schedule_for_day(self, day_id, announce=True):
        slots = database.get_schedules_for_day(day_id)
        active_count = 0

        for s_data in slots:
            num = s_data.get("slot_num", 1)
            if 1 <= num <= 24:
                w = self.slot_widgets[num - 1]
                w["hour"].set(str(s_data.get("hour", "00")).zfill(2))
                w["minute"].set(str(s_data.get("minute", "00")).zfill(2))

                sf = bool(s_data.get("sound_first"))
                st = bool(s_data.get("sound_time"))
                sc = bool(s_data.get("sound_con"))
                sl = bool(s_data.get("sound_last"))

                w["sound_first"].set(sf)
                w["sound_time"].set(st)
                w["sound_con"].set(sc)

                sd = s_data.get("sound_data", "")
                w["sound_data"].set(sd if sd in self.thai_clips else "(ไม่มีเสียง)")

                sde = s_data.get("sound_data_eng", "")
                w["sound_data_eng"].set(sde if sde in self.eng_clips else "(None)")

                w["sound_last"].set(sl)

                if sf or st or sc or sl:
                    active_count += 1

        day_name = [d[1] for d in DAYS_MAP if d[0] == day_id][0]
        self.set_log(f"โหลดข้อมูล: {day_name} ({active_count} คาบที่มีเสียง)")
        if announce:
            self.announce(f"เลือกตาราง {day_name} มีเสียงทำงาน {active_count} คาบ")

    def save_current_day_schedule(self):
        day_id = self.current_day_id
        slots_list = []
        for w in self.slot_widgets:
            thai_file = w["sound_data"].get()
            eng_file = w["sound_data_eng"].get()
            slots_list.append({
                "slot_num": w["slot_num"],
                "hour": w["hour"].get(),
                "minute": w["minute"].get(),
                "sound_first": 1 if w["sound_first"].get() else 0,
                "sound_time": 1 if w["sound_time"].get() else 0,
                "sound_con": 1 if w["sound_con"].get() else 0,
                "sound_data": "" if thai_file == "(ไม่มีเสียง)" else thai_file,
                "sound_data_eng": "" if eng_file == "(None)" else eng_file,
                "sound_last": 1 if w["sound_last"].get() else 0
            })
        try:
            database.save_all_day_slots(day_id, slots_list)
        except (ValueError, OSError, database.sqlite3.Error) as error:
            messagebox.showerror('บันทึกไม่สำเร็จ', str(error))
            return
        self._refresh_next_event()
        day_name = [d[1] for d in DAYS_MAP if d[0] == day_id][0]
        self.announce(f"บันทึกตารางเวลา '{day_name}' เรียบร้อยแล้ว")
        messagebox.showinfo("บันทึกสำเร็จ", f"บันทึกตารางเวลา '{day_name}' เรียบร้อยแล้ว")
        self.set_log(f"บันทึกตารางเวลา '{day_name}' สำเร็จ")

    def copy_current_to_all_days(self):
        day_name = [d[1] for d in DAYS_MAP if d[0] == self.current_day_id][0]
        if not messagebox.askyesno("ยืนยัน", f"คุณต้องการนำตารางเวลาจาก '{day_name}' ไปทับทุกวัน (จันทร์-อาทิตย์ และ All Day) หรือไม่?"):
            return
        database.copy_day_to_all_days(self.current_day_id)
        self._refresh_next_event()
        self.announce("นำตารางเวลานี้ไปใช้กับทุกวันเรียบร้อยแล้ว")
        messagebox.showinfo("สำเร็จ", "คัดลอกตารางเวลาไปยังทุกวันเรียบร้อยแล้ว!")
        self.set_log("คัดลอกตารางเวลาไปยังทุกวันสำเร็จ")

    def confirm_reset_default(self):
        if messagebox.askyesno("ยืนยัน", "คุณต้องการรีเซ็ตตารางเวลากลับเป็น 'ตารางมาตรฐานโรงเรียน' (14 คาบเรียนครบชุด) หรือไม่?"):
            database.reset_to_default_schedule()
            self.load_schedule_for_day(self.current_day_id, announce=False)
            self._refresh_next_event()
            self.announce("คืนค่าตารางเวลามาตรฐานโรงเรียน 14 คาบเรียนเรียบร้อยแล้ว")
            messagebox.showinfo("สำเร็จ", "คืนค่าตารางเวลามาตรฐานโรงเรียนเรียบร้อยแล้ว")
            self.set_log("คืนค่าตารางเวลามาตรฐานโรงเรียนสำเร็จ")

    def test_slot(self, slot_idx):
        if not (1 <= slot_idx <= 24):
            slot_idx = 1
        w = self.slot_widgets[slot_idx - 1]
        thai_f = w["sound_data"].get()
        eng_f = w["sound_data_eng"].get()

        slot_data = {
            "slot_num": slot_idx,
            "hour": w["hour"].get(),
            "minute": w["minute"].get(),
            "sound_first": w["sound_first"].get(),
            "sound_time": w["sound_time"].get(),
            "sound_con": w["sound_con"].get(),
            "sound_data": "" if thai_f == "(ไม่มีเสียง)" else thai_f,
            "sound_data_eng": "" if eng_f == "(None)" else eng_f,
            "sound_last": w["sound_last"].get()
        }

        desc = f"คาบที่ {slot_idx:02d} เวลา {slot_data['hour']}:{slot_data['minute']} น."
        self.announce(f"กำลังทดสอบเสียง {desc}")
        self.set_log(f"กำลังทดสอบเสียง: {desc}")

        self.player.play_slot_event(
            slot_data,
            bell_pack=self.bell_pack.get(),
            voice_lang=self.voice_lang.get(),
            on_finish=lambda: self.post_ui(lambda: self.set_log(f"ทดสอบเสียง {desc} เสร็จสิ้น"))
        )

    def test_current_time_voice(self):
        now = datetime.datetime.now()
        slot_data = {
            "hour": f"{now.hour:02d}",
            "minute": f"{now.minute:02d}",
            "sound_first": False,
            "sound_time": True,
            "sound_con": False,
            "sound_last": False
        }
        self.announce(f"ทดสอบขานเวลา {now.hour:02d}:{now.minute:02d} น.")
        self.player.play_slot_event(
            slot_data,
            bell_pack=self.bell_pack.get(),
            voice_lang=self.voice_lang.get(),
            on_finish=lambda: self.post_ui(lambda: self.set_log("ทดสอบขานเวลาเสร็จสิ้น"))
        )

    def stop_audio(self):
        self._audio_generation += 1
        self.player.stop()
        self.announce("หยุดเล่นเสียงทั้งหมดแล้ว")
        self.set_log("หยุดเล่นเสียงทั้งหมดแล้ว")

    def on_mode_change(self):
        database.set_setting("day_mode", self.day_mode.get())
        self.set_log(f"เปลี่ยนโหมดเป็น: {self.day_mode.get()}")
        self._refresh_next_event()

    def save_settings(self):
        try:
            config_manager.save_all_settings({
                'day_mode': self.day_mode.get(), 'bell_pack': self.bell_pack.get(),
                'voice_lang': self.voice_lang.get(),
                'auto_shutdown': '1' if self.auto_shutdown.get() else '0',
                'shutdown_hour': self.shutdown_hour.get(), 'shutdown_minute': self.shutdown_min.get(),
            })
        except (ValueError, OSError) as error:
            messagebox.showerror('บันทึกไม่สำเร็จ', str(error))
            return
        self._refresh_next_event()
        self.announce('บันทึกการตั้งค่าระบบเรียบร้อยแล้ว')
        messagebox.showinfo('บันทึกสำเร็จ', 'บันทึกการตั้งค่าระบบเรียบร้อยแล้ว')

    def export_backup(self):
        file_path = filedialog.asksaveasfilename(
            defaultextension=".json",
            filetypes=[("JSON files", "*.json")],
            initialfile=f"smart_school_chime_backup_{datetime.date.today().strftime('%Y%m%d')}.json"
        )
        if not file_path:
            return
        try:
            database.export_to_json(file_path)
            self.announce("ส่งออกข้อมูลสำรองเสร็จสิ้น")
            messagebox.showinfo("สำเร็จ", f"ส่งออกไฟล์สำรองไปยัง {file_path} เรียบร้อยแล้ว")
        except Exception as e:
            messagebox.showerror("ผิดพลาด", f"ไม่สามารถส่งออกข้อมูลได้: {e}")

    def import_backup(self):
        file_path = filedialog.askopenfilename(filetypes=[("JSON files", "*.json")])
        if not file_path:
            return
        if not messagebox.askyesno("ยืนยัน", "การนำเข้าข้อมูลจะเขียนทับตารางเวลาปัจจุบัน ต้องการดำเนินการต่อหรือไม่?"):
            return
        try:
            database.import_from_json(file_path)
            settings = config_manager.load_all_settings()
            self.day_mode.set(settings['day_mode'])
            self.bell_pack.set(settings['bell_pack'])
            self.voice_lang.set(settings['voice_lang'])
            self.auto_shutdown.set(settings['auto_shutdown'] == '1')
            self.shutdown_hour.set(settings['shutdown_hour'])
            self.shutdown_min.set(settings['shutdown_minute'])
            self._refresh_next_event()
            self.load_schedule_for_day(self.current_day_id, announce=False)
            self.announce("นำเข้าข้อมูลสำรองเรียบร้อยแล้ว")
            messagebox.showinfo("สำเร็จ", "นำเข้าข้อมูลจากไฟล์สำรองเรียบร้อยแล้ว!")
        except Exception as e:
            messagebox.showerror("ผิดพลาด", f"ไม่สามารถนำเข้าข้อมูลได้: {e}")

    def speak_summary_nvda(self):
        now = datetime.datetime.now()
        thai_day = THAI_DAYS[now.weekday()]
        thai_month = THAI_MONTHS[now.month]
        thai_year = now.year + 543
        txt_event = self.lbl_next_event.cget("text")
        urls = self.broadcast_server.get_urls()
        msg = f"ขณะนี้เวลา {now.hour:02d} นาฬิกา {now.minute:02d} นาที {thai_day}ที่ {now.day} {thai_month} พ.ศ. {thai_year} {txt_event} ระบบประกาศทำงานอยู่ที่ {urls['https']}"
        self.announce(msg)

    def test_nvda_connection(self):
        if nvda.is_running():
            nvda.speak("การเชื่อมต่อระหว่าง Smart School Chime และ NVDA ทำงานได้สมบูรณ์แบบ 100%")
            messagebox.showinfo("สถานะ", "โปรแกรมเชื่อมต่อกับ NVDA ได้สำเร็จ")
        else:
            messagebox.showinfo("สถานะ", "ไม่พบว่า NVDA กำลังทำงานอยู่ในขณะนี้")

    def show_nvda_help(self):
        msg = (
            "📌 คู่มือคีย์ลัดการใช้งานสำหรับแป้นพิมพ์:\n\n"
            "• Alt : เปิดแถบเมนูหลัก\n"
            "• Ctrl + B : ไปยังหน้าจอ QR Code ประกาศทางมือถือทันที\n"
            "• Alt + 1 ถึง 8 : สลับตารางวัน (Alt+8 ทุกวัน, Alt+2 วันจันทร์ ถึง Alt+1 วันอาทิตย์)\n"
            "• Tab / Shift+Tab : เลื่อนโฟกัสไปตามช่องควบคุม (ระบบจะเลื่อนหน้าจอตามอัตโนมัติ)\n"
            "• Spacebar : ติ๊กเลือก หรือ สลับสถานะกล่องกาเครื่องหมาย\n"
            "• ลูกศร ขึ้น/ลง : เลือกค่าในกล่องตัวเลือก (ชั่วโมง, นาที, ไฟล์เสียง)\n"
            "• Ctrl + S : บันทึกตารางเวลาปัจจุบันทันที\n"
            "• Ctrl + T : สั่งเล่นทดสอบเสียงในคาบที่กำลังเลือก\n"
            "• Ctrl + R : คืนค่าตารางเวลามาตรฐานโรงเรียน (14 คาบครบชุด)\n"
            "• Escape : สั่งหยุดเสียงทั้งหมดทันที\n"
            "• F5 : อ่านสรุปเวลาและรายการเสียงถัดไป\n"
            "• F1 : เปิดหน้าต่างแนะนำคีย์ลัดนี้"
        )
        self.announce("หน้าต่างคู่มือคีย์ลัดการใช้งาน")
        messagebox.showinfo("คู่มือคีย์ลัดการใช้งาน", msg)

    def show_about_dialog(self):
        urls = self.broadcast_server.get_urls()
        msg = (
            "🔔 Smart School Chime\n"
            "ระบบเสียงสัญญาณและประกาศเวลาโรงเรียนอัจฉริยะ\n"
            f"เวอร์ชัน: v{updater.__version__}\n\n"
            f"• ระบบพูดประกาศผ่าน Wi-Fi: {urls['https']}\n"
            "• ตารางเวลาและเสียงเริ่มต้น 14 คาบเรียนมาตรฐานไทย\n"
            "• ระบบอัปเดตอัตโนมัติผ่าน GitHub Releases\n"
            "• อัดเสียงแล้วส่งผ่าน HTTPS พร้อมสิทธิ์จาก QR Code"
        )
        messagebox.showinfo("เกี่ยวกับ Smart School Chime", msg)

    def _check_update_background(self):
        """Silently query GitHub in background thread after startup."""
        def worker():
            try:
                res = updater.check_for_updates(current_version=updater.__version__)
                if res.get("has_update"):
                    self.after(0, lambda: self._prompt_update_available(res, auto=True))
            except Exception:
                pass
        threading.Thread(target=worker, daemon=True).start()

    def check_updates_interactive(self):
        """User-triggered update check from Help menu."""
        self.set_log("กำลังตรวจสอบการอัปเดตจาก GitHub Releases...")
        self.announce("กำลังตรวจสอบการอัปเดต...")

        def worker():
            res = updater.check_for_updates(current_version=updater.__version__)
            self.after(0, lambda: self._handle_manual_update_result(res))

        threading.Thread(target=worker, daemon=True).start()

    def _handle_manual_update_result(self, res: dict):
        if res.get("status") == "error":
            err = res.get("error_message") or "ไม่ทราบสาเหตุ"
            self.set_log(f"ตรวจสอบการอัปเดตไม่สำเร็จ: {err}")
            self.announce("ตรวจสอบการอัปเดตไม่สำเร็จ")
            messagebox.showwarning(
                "ตรวจสอบการอัปเดต",
                f"ไม่สามารถตรวจสอบการอัปเดตได้ในขณะนี้:\n{err}\n\nโปรดตรวจสอบการเชื่อมต่ออินเทอร์เน็ต",
            )
            return

        if res.get("has_update"):
            self._prompt_update_available(res, auto=False)
        else:
            self.set_log(f"คุณกำลังใช้งานเวอร์ชันล่าสุดแล้ว (v{updater.__version__})")
            self.announce(f"คุณกำลังใช้งานเวอร์ชันล่าสุดแล้ว เวอร์ชัน {updater.__version__}")
            messagebox.showinfo(
                "ตรวจสอบการอัปเดต",
                f"คุณกำลังใช้งาน Smart School Chime เวอร์ชันล่าสุดแล้ว\n\nเวอร์ชันปัจจุบัน: v{updater.__version__}",
            )

    def _prompt_update_available(self, info: dict, auto: bool = False):
        latest_v = info.get("latest_version", "")
        curr_v = info.get("current_version", updater.__version__)
        body = info.get("release_notes", "").strip() or "มีการปรับปรุงประสิทธิภาพและการแก้ไขข้อผิดพลาด"
        asset_name = info.get("asset_name") or "SmartSchoolChime_Setup.exe"
        size_bytes = info.get("asset_size", 0)
        size_mb = size_bytes / (1024 * 1024) if size_bytes > 0 else 0
        size_text = f" ({size_mb:.1f} MB)" if size_mb > 0 else ""

        lines = body.split("\n")
        if len(lines) > 10:
            body_preview = "\n".join(lines[:10]) + "\n..."
        else:
            body_preview = body

        msg = (
            f"🔔 พบ Smart School Chime เวอร์ชันใหม่: v{latest_v}\n"
            f"(เวอร์ชันปัจจุบันของคุณ: v{curr_v})\n\n"
            f"ไฟล์ติดตั้ง: {asset_name}{size_text}\n\n"
            f"รายละเอียดการอัปเดต:\n{body_preview}\n\n"
            f"คุณต้องการดาวน์โหลดและติดตั้งทันทีหรือไม่?"
        )

        self.set_log(f"พบเวอร์ชันใหม่ v{latest_v} พร้อมให้อัปเดต")
        self.announce(f"พบเวอร์ชันใหม่ {latest_v} ต้องการอัปเดตหรือไม่")

        confirm = messagebox.askyesno(
            f"พบการอัปเดตใหม่ v{latest_v}",
            msg,
            icon="info",
        )
        if confirm:
            UpdateProgressDialog(self, info)

    def set_log(self, text):
        now_str = datetime.datetime.now().strftime("%H:%M:%S")
        self.lbl_log.config(text=f"[{now_str}] {text}")

    def _scheduler_loop(self):
        if not self.is_running:
            return
        try:
            now = datetime.datetime.now()
            date_str = f'{THAI_DAYS[now.weekday()]}ที่ {now.day} {THAI_MONTHS[now.month]} {now.year + 543}'
            self._update_clock_ui(now.strftime('%H:%M:%S'), date_str)
            previous_check = self._minute_scheduler.last_check
            try:
                for scheduled in self._minute_scheduler.due(now):
                    self._check_and_trigger(scheduled)
            except Exception:
                # Retry transient database failures within the grace period.
                # Already claimed occurrences remain protected by SQLite.
                self._minute_scheduler.last_check = previous_check
                raise
            minute_key = now.strftime('%Y-%m-%d %H:%M')
            if minute_key != self.last_triggered_minute:
                self.last_triggered_minute = minute_key
                self._refresh_next_event()
        except Exception:
            logging.getLogger(__name__).exception('Scheduler tick failed')
            self.set_log('ระบบเวลาพบข้อผิดพลาด โปรดตรวจบันทึกระบบ')
        finally:
            if self.is_running:
                self._scheduler_after = self.after(250, self._scheduler_loop)

    def _target_day(self, now):
        return 8 if self.day_mode.get() == 'all_day' else (now.weekday() + 1) % 7 + 1

    def _refresh_next_event(self):
        now = datetime.datetime.now()
        self._calculate_next_event(self._target_day(now), now)

    def _update_clock_ui(self, time_str, date_str):
        self.lbl_clock.config(text=time_str)
        self.lbl_date.config(text=date_str)

    def _check_and_trigger(self, now):
        target_day = self._target_day(now)
        cur_h, cur_m = now.strftime('%H'), now.strftime('%M')
        stamp = now.strftime('%Y-%m-%d %H:%M')
        slots = database.get_schedules_for_day(target_day)
        matched = [slot for slot in slots if slot['hour'] == cur_h and slot['minute'] == cur_m
                   and any(slot.get(flag) for flag in database.FLAGS)]
        for slot in matched:
            occurrence = f"{stamp}/slot/{slot['slot_num']}"
            if not database.claim_event(occurrence):
                continue
            desc = f"คาบที่ {slot['slot_num']:02d} ({cur_h}:{cur_m})"
            self.set_log(f'เข้าคิวเสียงตามตาราง: {desc}')
            try:
                self.player.play_slot_event(
                    slot, self.bell_pack.get(), self.voice_lang.get(), enqueue=True,
                    on_finish=lambda key=occurrence, d=desc: self.post_ui(lambda: self._finish_scheduled(key, d, 'completed')),
                    on_error=lambda error, key=occurrence, d=desc: self.post_ui(lambda: self._finish_scheduled(key, d, 'failed')),
                    on_cleanup=lambda key=occurrence: self.post_ui(lambda: database.finish_event_if_pending(key, 'cancelled')))
            except Exception:
                database.finish_event(occurrence, 'failed')
                raise
        if (self.auto_shutdown.get() and cur_h == self.shutdown_hour.get().zfill(2)
                and cur_m == self.shutdown_min.get().zfill(2)):
            key = f'{stamp}/shutdown'
            if database.claim_event(key):
                if self.player.is_playing():
                    database.finish_event(key, 'skipped_busy')
                    self.set_log('ข้ามการปิดเครื่อง เพราะมีเสียงกำลังเล่นหรือรอคิว')
                else:
                    result = subprocess.run(['shutdown', '/s', '/t', '60', '/c', 'Smart School Chime'],
                                            capture_output=True, creationflags=getattr(subprocess, 'CREATE_NO_WINDOW', 0))
                    database.finish_event(key, 'completed' if result.returncode == 0 else 'failed')
                    self.set_log('กำหนดปิดเครื่องใน 60 วินาที กดยกเลิกได้จากเมนูตั้งค่า')

    def _finish_scheduled(self, occurrence, description, status):
        database.finish_event(occurrence, status)
        self.set_log(f'{description}: {status}')

    def cancel_shutdown(self):
        result = subprocess.run(['shutdown', '/a'], capture_output=True,
                                creationflags=getattr(subprocess, 'CREATE_NO_WINDOW', 0))
        self.set_log('ยกเลิกการปิดเครื่องแล้ว' if result.returncode == 0 else 'ไม่มีการปิดเครื่องที่ยกเลิกได้')

    def _calculate_next_event(self, target_day_id, now):
        next_event = None
        for offset in range(8):
            date = now + datetime.timedelta(days=offset)
            day = target_day_id if offset == 0 else self._target_day(date)
            for slot in database.get_schedules_for_day(day):
                if not any(slot.get(flag) for flag in database.FLAGS):
                    continue
                try:
                    when = date.replace(hour=int(slot['hour']), minute=int(slot['minute']), second=0, microsecond=0)
                except (ValueError, TypeError):
                    continue
                if when > now and (next_event is None or when < next_event[0]):
                    next_event = (when, slot['slot_num'])
            if next_event:
                break
        if next_event:
            when, number = next_event
            minutes = max(1, int((when - now).total_seconds() + 59) // 60)
            txt = f"เสียงถัดไป: {when:%d/%m %H:%M} (คาบ {number:02d}) อีก {minutes} นาที"
        else:
            txt = 'ไม่มีรายการเสียงใน 7 วันข้างหน้า'
        self.lbl_next_event.config(text=f'⏳ {txt}')

    def on_close(self):
        self.is_running = False
        self._audio_generation += 1
        for identifier in (
            self._scheduler_after,
            self._queue_after,
            self._initial_after,
            getattr(self, '_update_check_after', None),
        ):
            if identifier:
                try:
                    self.after_cancel(identifier)
                except Exception:
                    pass
        self.player.close()
        self.broadcast_server.stop()
        logging.getLogger().removeHandler(self._log_handler)
        self._log_handler.close()
        self.destroy()


class UpdateProgressDialog(tk.Toplevel):
    """Accessible modal dialog displaying download progress for the new update."""

    def __init__(self, parent, update_info: dict):
        super().__init__(parent)
        self.parent = parent
        self.update_info = update_info
        self.cancel_event = threading.Event()
        self.title("ดาวน์โหลดการอัปเดต - Smart School Chime")
        self.geometry("520x240")
        self.resizable(False, False)
        self.transient(parent)
        self.grab_set()

        self.update_idletasks()
        try:
            px = parent.winfo_rootx() + (parent.winfo_width() - 520) // 2
            py = parent.winfo_rooty() + (parent.winfo_height() - 240) // 2
            self.geometry(f"+{max(20, px)}+{max(20, py)}")
        except Exception:
            pass

        self.protocol("WM_DELETE_WINDOW", self.on_cancel)

        container = ttk.Frame(self, padding="24 20 24 20")
        container.pack(fill=tk.BOTH, expand=True)

        latest_v = update_info.get("latest_version", "")
        lbl_head = ttk.Label(
            container,
            text=f"🚀 กำลังดาวน์โหลด Smart School Chime v{latest_v}...",
            font=("Segoe UI", 12, "bold"),
            foreground="#1e3a8a",
        )
        lbl_head.pack(anchor="w", pady=(0, 6))

        asset_name = update_info.get("asset_name", "Setup.exe")
        lbl_sub = ttk.Label(
            container,
            text=f"ไฟล์: {asset_name}",
            font=("Segoe UI", 9),
            foreground="#64748b",
        )
        lbl_sub.pack(anchor="w", pady=(0, 14))

        self.progress_bar = ttk.Progressbar(container, orient="horizontal", mode="determinate", maximum=100)
        self.progress_bar.pack(fill=tk.X, pady=(0, 10))

        self.lbl_status = ttk.Label(
            container,
            text="กำลังเริ่มการเชื่อมต่อไปยัง GitHub Releases...",
            font=("Segoe UI", 9),
            foreground="#334155",
        )
        self.lbl_status.pack(anchor="w", pady=(0, 16))

        btn_box = ttk.Frame(container)
        btn_box.pack(fill=tk.X)

        self.btn_cancel = ttk.Button(btn_box, text="ยกเลิก (Cancel)", command=self.on_cancel)
        self.btn_cancel.pack(side=tk.RIGHT)

        self._last_nvda_pct = -10
        self._download_thread = threading.Thread(target=self._run_download, daemon=True)
        self._download_thread.start()

    def _run_download(self):
        url = self.update_info.get("download_url")
        asset_name = self.update_info.get("asset_name") or "SmartSchoolChime_Setup.exe"
        dest_dir = updater.get_updates_directory()
        dest_file = dest_dir / asset_name

        def on_progress(downloaded, total, percent, speed):
            self.after(0, lambda: self._update_progress_ui(downloaded, total, percent, speed))

        try:
            saved_path = updater.download_update(
                url,
                dest_file,
                progress_callback=on_progress,
                cancel_event=self.cancel_event,
            )
            self.after(0, lambda: self._on_download_success(saved_path))
        except InterruptedError:
            self.after(0, self._on_download_cancelled)
        except Exception as exc:
            self.after(0, lambda: self._on_download_error(str(exc)))

    def _update_progress_ui(self, downloaded, total, percent, speed):
        self.progress_bar["value"] = percent
        dl_mb = downloaded / (1024 * 1024)
        total_mb = total / (1024 * 1024) if total > 0 else 0
        speed_kb = speed / 1024
        speed_text = f"{speed_kb / 1024:.2f} MB/s" if speed_kb >= 1024 else f"{speed_kb:.0f} KB/s"

        if total > 0:
            status_text = f"{percent:.1f}% ({dl_mb:.1f} MB / {total_mb:.1f} MB) • ความเร็ว {speed_text}"
        else:
            status_text = f"ดาวน์โหลดแล้ว {dl_mb:.1f} MB • ความเร็ว {speed_text}"

        self.lbl_status.config(text=status_text)

        int_pct = int(percent)
        if int_pct >= self._last_nvda_pct + 25:
            self._last_nvda_pct = (int_pct // 25) * 25
            nvda.speak(f"ดาวน์โหลดอัปเดต {self._last_nvda_pct} เปอร์เซ็นต์")

    def _on_download_success(self, installer_path: Path):
        self.progress_bar["value"] = 100
        self.lbl_status.config(
            text="✅ ดาวน์โหลดเสร็จสมบูรณ์! กำลังปิดโปรแกรมและเริ่มการติดตั้ง...",
            foreground="#16a34a",
        )
        self.btn_cancel.config(state="disabled")
        nvda.speak("ดาวน์โหลดเสร็จสมบูรณ์ ระบบกำลังปิดโปรแกรมและเริ่มการติดตั้งเวอร์ชันใหม่")
        self.after(800, lambda: self._launch_installer(installer_path))

    def _launch_installer(self, installer_path: Path):
        try:
            updater.launch_installer_and_exit(installer_path, on_before_exit=self.parent.on_close)
        except Exception as exc:
            messagebox.showerror("เปิดตัวติดตั้งไม่สำเร็จ", f"ไม่สามารถเปิดไฟล์ตัวติดตั้งได้:\n{exc}")
            self.destroy()

    def _on_download_cancelled(self):
        self.lbl_status.config(text="ยกเลิกการดาวน์โหลดแล้ว", foreground="#dc2626")
        self.destroy()

    def _on_download_error(self, err_msg: str):
        nvda.speak(f"ดาวน์โหลดอัปเดตล้มเหลว {err_msg}")
        messagebox.showerror(
            "ดาวน์โหลดไม่สำเร็จ",
            f"เกิดข้อผิดพลาดระหว่างดาวน์โหลดไฟล์อัปเดต:\n{err_msg}\n\nกรุณาตรวจสอบการเชื่อมต่ออินเทอร์เน็ตแล้วลองใหม่อีกครั้ง",
        )
        self.destroy()

    def on_cancel(self):
        self.cancel_event.set()
        self.lbl_status.config(text="กำลังยกเลิก...")
        self.btn_cancel.config(state="disabled")

def write_diagnostics(filename):
    """Offline check for deployment support; no sound, shutdown or listener."""
    app_paths.initialize_storage()
    database.init_db()
    try:
        with open(config_manager.CONFIG_FILE, encoding='utf-8') as stream:
            config_manager.validate_settings(json.load(stream))
        settings_valid = True
    except (OSError, ValueError, TypeError):
        settings_valid = False
    report = {
        'frozen': bool(getattr(sys, 'frozen', False)),
        'state_dir': str(app_paths.STATE_DIR),
        'sound_dir': str(app_paths.SOUND_DIR),
        'wav_files': len(list(app_paths.SOUND_DIR.rglob('*.wav'))),
        'schedule_slots': sum(len(database.get_schedules_for_day(day)) for day in range(1, 9)),
        'settings_valid': settings_valid,
    }
    with open(filename, 'w', encoding='utf-8') as stream:
        json.dump(report, stream, ensure_ascii=False, indent=2)


if __name__ == '__main__':
    if len(sys.argv) == 3 and sys.argv[1] == '--diagnose':
        write_diagnostics(sys.argv[2])
    else:
        from instance_lock import InstanceLock
        lock = InstanceLock(app_paths.STATE_DIR)
        if not lock.acquired:
            import ctypes
            ctypes.windll.user32.MessageBoxW(None, 'โปรแกรมกำลังเปิดใช้งานกับข้อมูลชุดนี้อยู่แล้ว', 'Smart School Chime', 0x40)
            sys.exit(0)
        try:
            app = SmartSchoolChimeApp()
            app.mainloop()
        finally:
            lock.close()
