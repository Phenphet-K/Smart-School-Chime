"""
Smart School Chime (ระบบเสียงสัญญาณและประกาศเวลาโรงเรียนอัจฉริยะ)
Automated School Bell, Chime Announcement, and Wireless Live LAN Broadcast System
Features:
- Full widescreen layout (100% width, no wasted blank space on right)
- High readability, large eye-friendly fonts (11-12pt) and comfortable padding
- Mobile Push-to-Talk Announcement via QR Code / LAN URL
- Noise Suppression & 0.1s Pre-roll Delay Buffer
- Silent background NVDA screen reader compatibility
"""

import os
import sys
import time
import datetime
import threading
import subprocess
import json
import webbrowser
import winsound
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

        # Initialize Database & Audio Player
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

        # Start Scheduler Background Thread
        self.scheduler_thread = threading.Thread(target=self._scheduler_loop, daemon=True)
        self.scheduler_thread.start()

        self.protocol("WM_DELETE_WINDOW", self.on_close)

        # Background speech announcement for screen reader users
        self.after(600, self._initial_announce)

    def _initial_announce(self):
        urls = self.broadcast_server.get_urls()
        msg = f"ยินดีต้อนรับสู่ {APP_TITLE} ระบบประกาศสดทางมือถือพร้อมใช้งานที่ {urls['https']} กด F1 เพื่อฟังคู่มือคีย์ลัด"
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

        # 3. Menu ประกาศสด (Live Broadcast)
        menu_broadcast = tk.Menu(menubar, tearoff=0)
        menu_broadcast.add_command(label="📢 เปิดหน้า QR Code ประกาศสดทางมือถือ (Ctrl+B)", command=lambda: self.notebook.select(1), accelerator="Ctrl+B")
        menu_broadcast.add_command(label="🌐 เปิดหน้าเว็บพูดประกาศในเบราว์เซอร์", command=self.open_web_broadcast)
        menu_broadcast.add_command(label="📋 คัดลอก URL หน้าพูดประกาศ", command=self.copy_broadcast_url)
        menu_broadcast.add_separator()
        menu_broadcast.add_command(label="⏹️ ตัดเสียงประกาศทันที (Esc)", command=self.stop_audio, accelerator="Esc")
        menubar.add_cascade(label="📢 ประกาศสด (Broadcast)", menu=menu_broadcast, underline=0)

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
        menubar.add_cascade(label="⚙️ ตั้งค่า (Settings)", menu=menu_settings, underline=0)

        # 6. Menu ช่วยเหลือ (Help)
        menu_help = tk.Menu(menubar, tearoff=0)
        menu_help.add_command(label="📢 อ่านสรุปเวลาและเสียงถัดไป (F5)", command=self.speak_summary_nvda, accelerator="F5")
        menu_help.add_command(label="⌨️ คู่มือคีย์ลัดการใช้งาน (F1)", command=self.show_nvda_help, accelerator="F1")
        menu_help.add_separator()
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
        self.notebook.add(self.tab_broadcast, text="  📢 ประกาศสดผ่านมือถือ (Live Broadcast)  ")
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
            text="📢 ประกาศสดผ่านมือถือ / QR Code (Ctrl+B)",
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
        btn_goto_bc.bind("<FocusIn>", lambda e: self.announce("ปุ่มเปิดหน้า QR Code ประกาศสดทางมือถือ คีย์ลัด Ctrl+B"))

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
            text="สแกนด้วยกล้องมือถือที่ต่อ Wi-Fi เดียวกัน\nกดปุ่มค้างเพื่อพูดกระจายเสียงสดได้ทันที", 
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

        lbl_f1 = tk.Label(feat_card, text="🛡️ ตัดเสียงรบกวน (Noise Suppression): เปิด", font=("Segoe UI", 10, "bold"), bg="#ecfdf5", fg="#047857", padx=10, pady=4, relief="solid", bd=1)
        lbl_f1.pack(side=tk.LEFT, padx=(0, 8))

        lbl_f2 = tk.Label(feat_card, text="⏱️ หน่วงเวลาเริ่มพูด 0.1 วินาที (Pre-roll Buffer): เปิด", font=("Segoe UI", 10, "bold"), bg="#eff6ff", fg="#1d4ed8", padx=10, pady=4, relief="solid", bd=1)
        lbl_f2.pack(side=tk.LEFT, padx=8)

        lbl_f3 = tk.Label(feat_card, text="🎙️ กดค้างเพื่อพูด (Push-to-Talk): เปิด", font=("Segoe UI", 10, "bold"), bg="#fef3c7", fg="#b45309", padx=10, pady=4, relief="solid", bd=1)
        lbl_f3.pack(side=tk.LEFT, padx=8)

        # 3. Live Broadcast Log and Emergency Controls
        log_card = tk.LabelFrame(
            right_box, 
            text=" 📋 ประวัติการพูดประกาศสดผ่านระบบไมโครโฟนไร้สาย ", 
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

        self.broadcast_listbox.insert(tk.END, "🟢 ระบบประกาศสดออนไลน์ พร้อมรับสัญญาณเสียงจากสมาร์ตโฟนในวง Wi-Fi")

        # Bottom Bar of Broadcast Tab
        bc_bottom = tk.Frame(self.tab_broadcast, bg="#e2e8f0", padx=16, pady=12)
        bc_bottom.pack(fill=tk.X, side=tk.BOTTOM)

        btn_test_sim = tk.Button(
            bc_bottom,
            text="▶️ ทดสอบเปิดหน้าพูดประกาศสดในคอม",
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

    def handle_incoming_broadcast(self, client_ip, wav_path, play_chime):
        now_str = datetime.datetime.now().strftime("%H:%M:%S")
        log_msg = f"[{now_str}] 🎙️ ได้รับการพูดประกาศสดจากมือถือ (IP: {client_ip})"
        self.after(0, lambda: self.add_broadcast_log(log_msg))
        self.after(0, lambda: self.announce(f"มีการพูดประกาศสดผ่านระบบไมโครโฟนไร้สาย จากไอพี {client_ip}"))

        def _play_worker():
            # 1. 0.1s Pre-roll buffer per user requirement
            time.sleep(0.1)

            # 2. Optional Pre-announcement Chime
            if play_chime:
                self.after(0, lambda: self.set_log(f"🔔 กำลังเล่นเสียงกริ่งเตือนก่อนเริ่มประกาศสด ({client_ip})"))
                self.player.play_bell(self.bell_pack.get(), "First")
                time.sleep(1.2)

            # 3. Play the live voice announcement
            self.after(0, lambda: self.set_log(f"📢 กำลังถ่ายทอดเสียงประกาศสดจาก {client_ip}..."))
            try:
                winsound.PlaySound(wav_path, winsound.SND_FILENAME)
            except Exception as e:
                print("Error playing broadcast audio:", e)

            self.after(0, lambda: self.set_log(f"✅ สิ้นสุดการถ่ายทอดเสียงประกาศสดจาก {client_ip}"))
            self.after(0, lambda: self.add_broadcast_log(f"[{datetime.datetime.now().strftime('%H:%M:%S')}] ✅ ออกอากาศเสียงประกาศสดสำเร็จ"))

        t = threading.Thread(target=_play_worker, daemon=True)
        t.start()

    def add_broadcast_log(self, text):
        self.broadcast_listbox.insert(tk.END, text)
        self.broadcast_listbox.see(tk.END)

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
            text=f"📡 ประกาศสด: {self.broadcast_server.lan_ip}:5443",
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
        database.save_all_day_slots(day_id, slots_list)
        day_name = [d[1] for d in DAYS_MAP if d[0] == day_id][0]
        self.announce(f"บันทึกตารางเวลา '{day_name}' เรียบร้อยแล้ว")
        messagebox.showinfo("บันทึกสำเร็จ", f"บันทึกตารางเวลา '{day_name}' เรียบร้อยแล้ว")
        self.set_log(f"บันทึกตารางเวลา '{day_name}' สำเร็จ")

    def copy_current_to_all_days(self):
        day_name = [d[1] for d in DAYS_MAP if d[0] == self.current_day_id][0]
        if not messagebox.askyesno("ยืนยัน", f"คุณต้องการนำตารางเวลาจาก '{day_name}' ไปทับทุกวัน (จันทร์-อาทิตย์ และ All Day) หรือไม่?"):
            return
        database.copy_day_to_all_days(self.current_day_id)
        self.announce("นำตารางเวลานี้ไปใช้กับทุกวันเรียบร้อยแล้ว")
        messagebox.showinfo("สำเร็จ", "คัดลอกตารางเวลาไปยังทุกวันเรียบร้อยแล้ว!")
        self.set_log("คัดลอกตารางเวลาไปยังทุกวันสำเร็จ")

    def confirm_reset_default(self):
        if messagebox.askyesno("ยืนยัน", "คุณต้องการรีเซ็ตตารางเวลากลับเป็น 'ตารางมาตรฐานโรงเรียน' (14 คาบเรียนครบชุด) หรือไม่?"):
            database.reset_to_default_schedule()
            self.load_schedule_for_day(self.current_day_id, announce=False)
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
            on_finish=lambda: self.set_log(f"ทดสอบเสียง {desc} เสร็จสิ้น")
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
            on_finish=lambda: self.set_log("ทดสอบขานเวลาเสร็จสิ้น")
        )

    def stop_audio(self):
        self.player.stop()
        self.announce("หยุดเล่นเสียงทั้งหมดแล้ว")
        self.set_log("หยุดเล่นเสียงทั้งหมดแล้ว")

    def on_mode_change(self):
        database.set_setting("day_mode", self.day_mode.get())
        self.set_log(f"เปลี่ยนโหมดเป็น: {self.day_mode.get()}")

    def save_settings(self):
        database.set_setting("day_mode", self.day_mode.get())
        database.set_setting("bell_pack", self.bell_pack.get())
        database.set_setting("voice_lang", self.voice_lang.get())
        database.set_setting("auto_shutdown", "1" if self.auto_shutdown.get() else "0")
        database.set_setting("shutdown_hour", self.shutdown_hour.get())
        database.set_setting("shutdown_minute", self.shutdown_min.get())
        self.announce("บันทึกการตั้งค่าระบบเรียบร้อยแล้ว")
        messagebox.showinfo("บันทึกสำเร็จ", "บันทึกการตั้งค่าระบบเรียบร้อยแล้ว")
        self.set_log("บันทึกการตั้งค่าระบบสำเร็จ")

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
        msg = f"ขณะนี้เวลา {now.hour:02d} นาฬิกา {now.minute:02d} นาที {thai_day}ที่ {now.day} {thai_month} พ.ศ. {thai_year} {txt_event} ระบบประกาศสดทำงานอยู่ที่ {urls['https']}"
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
            "• Ctrl + B : ไปยังหน้าจอ QR Code ประกาศสดทางมือถือทันที\n"
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
            "ระบบเสียงสัญญาณและประกาศเวลาโรงเรียนอัจฉริยะ\n\n"
            f"• ระบบพูดประกาศสดผ่าน Wi-Fi: {urls['https']}\n"
            "• ตารางเวลาและเสียงเริ่มต้น 14 คาบเรียนมาตรฐานไทย\n"
            "• ระบบตัดเสียงรบกวนและหน่วงเวลา 0.1 วินาทีอัตโนมัติ"
        )
        messagebox.showinfo("เกี่ยวกับ Smart School Chime", msg)

    def set_log(self, text):
        now_str = datetime.datetime.now().strftime("%H:%M:%S")
        self.lbl_log.config(text=f"[{now_str}] {text}")

    def _scheduler_loop(self):
        while self.is_running:
            now = datetime.datetime.now()
            time_str = now.strftime("%H:%M:%S")
            thai_year = now.year + 543
            thai_day = THAI_DAYS[now.weekday()]
            thai_month = THAI_MONTHS[now.month]
            date_str = f"{thai_day}ที่ {now.day} {thai_month} {thai_year}"

            try:
                if not self.is_running:
                    break
                self.after(0, lambda t=time_str, d=date_str: self._update_clock_ui(t, d))
            except Exception:
                break

            minute_key = now.strftime("%Y-%m-%d %H:%M")
            if now.second == 0 and minute_key != self.last_triggered_minute:
                self.last_triggered_minute = minute_key
                self._check_and_trigger(now)

            time.sleep(1)

    def _update_clock_ui(self, time_str, date_str):
        self.lbl_clock.config(text=time_str)
        self.lbl_date.config(text=date_str)

    def _check_and_trigger(self, now):
        cur_h = f"{now.hour:02d}"
        cur_m = f"{now.minute:02d}"

        # 1. Check Auto Shutdown
        if self.auto_shutdown.get():
            sh_h = str(self.shutdown_hour.get()).zfill(2)
            sh_m = str(self.shutdown_min.get()).zfill(2)
            if cur_h == sh_h and cur_m == sh_m:
                self.after(0, lambda: self.announce("ระบบกำลังสั่งปิดคอมพิวเตอร์ตามเวลาที่กำหนด"))
                try:
                    subprocess.run(["shutdown", "/s", "/t", "60", "/c", "Smart School Chime: ได้เวลาปิดเครื่องอัตโนมัติ"])
                except Exception as e:
                    print("Shutdown error:", e)
                return

        # 2. Determine Day ID for schedule
        if self.day_mode.get() == "all_day":
            target_day_id = 8
        else:
            if now.weekday() == 6:  # Sunday
                target_day_id = 1
            else:
                target_day_id = now.weekday() + 2

        slots = database.get_schedules_for_day(target_day_id)
        for s in slots:
            slot_h = str(s.get("hour", "00")).zfill(2)
            slot_m = str(s.get("minute", "00")).zfill(2)

            if slot_h == cur_h and slot_m == cur_m:
                has_any_sound = s.get("sound_first") or s.get("sound_time") or s.get("sound_con") or s.get("sound_last")
                if has_any_sound:
                    slot_num = s.get("slot_num", 1)
                    desc = f"คาบที่ {slot_num:02d} ({slot_h}:{slot_m} น.)"
                    self.after(0, lambda d=desc: self.set_log(f"🔔 ถึงเวลาเล่นเสียงตามตาราง: {d}"))
                    self.player.play_slot_event(
                        s, 
                        bell_pack=self.bell_pack.get(), 
                        voice_lang=self.voice_lang.get(),
                        on_finish=lambda d=desc: self.after(0, lambda: self.set_log(f"เล่นเสียง {d} เสร็จสิ้น"))
                    )
                    break

        self._calculate_next_event(target_day_id, now)

    def _calculate_next_event(self, target_day_id, now):
        slots = database.get_schedules_for_day(target_day_id)
        active_slots = []
        for s in slots:
            if s.get("sound_first") or s.get("sound_time") or s.get("sound_con") or s.get("sound_last"):
                try:
                    h = int(s.get("hour", 0))
                    m = int(s.get("minute", 0))
                    active_slots.append((h, m, s.get("slot_num")))
                except Exception:
                    pass

        active_slots.sort()
        cur_total_min = now.hour * 60 + now.minute
        next_event = None
        for h, m, slot_num in active_slots:
            slot_total_min = h * 60 + m
            if slot_total_min > cur_total_min:
                diff = slot_total_min - cur_total_min
                next_event = (h, m, slot_num, diff)
                break

        if next_event:
            h, m, slot_num, diff = next_event
            txt = f"เสียงถัดไป: {h:02d}:{m:02d} น. (คาบ {slot_num:02d}) อีก {diff} นาที"
        else:
            txt = "ไม่มีรายการเสียงที่เหลือในวันนี้แล้ว"
        self.after(0, lambda: self.lbl_next_event.config(text=f"⏳ {txt}"))

    def on_close(self):
        self.is_running = False
        self.broadcast_server.stop()
        self.player.stop()
        self.destroy()

if __name__ == "__main__":
    app = SmartSchoolChimeApp()
    app.mainloop()
