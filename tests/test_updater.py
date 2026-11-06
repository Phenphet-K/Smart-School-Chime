"""Unit tests for updater module."""

import io
import json
from pathlib import Path
import threading
import urllib.error
import pytest

import updater


def test_parse_version():
    assert updater.parse_version("1.0.0") == (1, 0, 0)
    assert updater.parse_version("v1.0.1") == (1, 0, 1)
    assert updater.parse_version("V2.1.3") == (2, 1, 3)
    assert updater.parse_version("1.2") == (1, 2, 0)
    assert updater.parse_version("v1.0.0-beta") == (1, 0, 0)
    assert updater.parse_version("") == (0, 0, 0)


def test_is_newer_version():
    assert updater.is_newer_version("1.0.2", "1.0.1") is True
    assert updater.is_newer_version("v1.1.0", "1.0.1") is True
    assert updater.is_newer_version("2.0.0", "1.9.9") is True
    assert updater.is_newer_version("1.0.1", "1.0.1") is False
    assert updater.is_newer_version("1.0.0", "1.0.1") is False
    assert updater.is_newer_version("v0.9.9", "1.0.1") is False


def test_find_installer_asset():
    assets = [
        {"name": "SmartSchoolChime_Portable_v1.0.2.zip", "browser_download_url": "http://zip"},
        {"name": "SmartSchoolChime_Setup_v1.0.2.exe", "browser_download_url": "http://setup"},
        {"name": "readme.txt", "browser_download_url": "http://txt"},
    ]
    installer = updater.find_installer_asset(assets)
    assert installer is not None
    assert installer["name"] == "SmartSchoolChime_Setup_v1.0.2.exe"

    # Fallback to any exe if setup keyword is absent
    assets2 = [
        {"name": "SmartSchoolChime.zip", "browser_download_url": "http://zip"},
        {"name": "SmartSchoolChime.exe", "browser_download_url": "http://exe"},
    ]
    assert updater.find_installer_asset(assets2)["name"] == "SmartSchoolChime.exe"
    assert updater.find_installer_asset([]) is None


def test_check_for_updates_found(monkeypatch):
    mock_payload = {
        "tag_name": "v1.0.2",
        "name": "Version 1.0.2 Release",
        "body": "- Added full auto-updater\n- Improved audio sync",
        "html_url": "https://github.com/Phenphet-K/Smart-School-Chime/releases/tag/v1.0.2",
        "assets": [
            {
                "name": "SmartSchoolChime_Setup_v1.0.2.exe",
                "browser_download_url": "https://example.com/setup.exe",
                "size": 1234567,
            }
        ],
    }

    class MockResponse:
        def __enter__(self):
            return self

        def __exit__(self, *args):
            pass

        def read(self):
            return json.dumps(mock_payload).encode("utf-8")

    monkeypatch.setattr(updater.urllib.request, "urlopen", lambda req, timeout=10: MockResponse())

    info = updater.check_for_updates(current_version="1.0.1")
    assert info["status"] == "success"
    assert info["has_update"] is True
    assert info["is_newer"] is True
    assert info["latest_version"] == "1.0.2"
    assert info["asset_name"] == "SmartSchoolChime_Setup_v1.0.2.exe"
    assert info["download_url"] == "https://example.com/setup.exe"
    assert info["asset_size"] == 1234567


def test_check_for_updates_up_to_date(monkeypatch):
    mock_payload = {
        "tag_name": "v1.0.1",
        "name": "Version 1.0.1",
        "body": "Current release",
        "html_url": "https://github.com/Phenphet-K/Smart-School-Chime/releases/tag/v1.0.1",
        "assets": [
            {
                "name": "SmartSchoolChime_Setup_v1.0.1.exe",
                "browser_download_url": "https://example.com/setup.exe",
                "size": 1234567,
            }
        ],
    }

    class MockResponse:
        def __enter__(self):
            return self

        def __exit__(self, *args):
            pass

        def read(self):
            return json.dumps(mock_payload).encode("utf-8")

    monkeypatch.setattr(updater.urllib.request, "urlopen", lambda req, timeout=10: MockResponse())

    info = updater.check_for_updates(current_version="1.0.1")
    assert info["status"] == "success"
    assert info["has_update"] is False
    assert info["is_newer"] is False


def test_check_for_updates_network_error(monkeypatch):
    def mock_fail(req, timeout=10):
        raise urllib.error.URLError("Connection refused")

    monkeypatch.setattr(updater.urllib.request, "urlopen", mock_fail)
    info = updater.check_for_updates(current_version="1.0.1")
    assert info["status"] == "error"
    assert info["has_update"] is False
    assert "Connection refused" in info["error_message"]


def test_download_update(tmp_path, monkeypatch):
    data = b"MOCK_EXE_BINARY_CONTENT" * 1024

    class MockDownloadResponse:
        def __init__(self):
            self.stream = io.BytesIO(data)
            self.headers = {"Content-Length": str(len(data))}

        def __enter__(self):
            return self

        def __exit__(self, *args):
            pass

        def read(self, chunk_size=65536):
            return self.stream.read(chunk_size)

    monkeypatch.setattr(updater.urllib.request, "urlopen", lambda req, timeout=30: MockDownloadResponse())

    dest_file = tmp_path / "updates" / "installer.exe"
    progress_records = []

    def on_progress(downloaded, total, pct, speed):
        progress_records.append((downloaded, total, pct))

    result_path = updater.download_update(
        "http://example.com/installer.exe",
        dest_file,
        progress_callback=on_progress,
        chunk_size=1024,
    )

    assert result_path.is_file()
    assert result_path.read_bytes() == data
    assert len(progress_records) > 0
    assert progress_records[-1][2] == 100.0


def test_download_update_cancellation(tmp_path, monkeypatch):
    data = b"MOCK_DATA" * 5000

    class MockDownloadResponse:
        def __init__(self):
            self.stream = io.BytesIO(data)
            self.headers = {"Content-Length": str(len(data))}

        def __enter__(self):
            return self

        def __exit__(self, *args):
            pass

        def read(self, chunk_size=100):
            return self.stream.read(chunk_size)

    monkeypatch.setattr(updater.urllib.request, "urlopen", lambda req, timeout=30: MockDownloadResponse())

    dest_file = tmp_path / "updates" / "installer_cancel.exe"
    cancel_evt = threading.Event()
    cancel_evt.set()  # Cancel immediately

    with pytest.raises(InterruptedError):
        updater.download_update(
            "http://example.com/installer.exe",
            dest_file,
            cancel_event=cancel_evt,
            chunk_size=100,
        )

    # Temporary file should have been cleaned up
    assert not dest_file.exists()
    assert not dest_file.with_suffix(".exe.download").exists()


def test_gui_update_notifications(monkeypatch):
    import main
    boxes = []
    monkeypatch.setattr(main.messagebox, "showinfo", lambda t, m: boxes.append(("info", t, m)))
    monkeypatch.setattr(main.messagebox, "showwarning", lambda t, m: boxes.append(("warning", t, m)))
    monkeypatch.setattr(main.messagebox, "askyesno", lambda t, m, **kwargs: boxes.append(("askyesno", t, m)) or False)
    monkeypatch.setattr(main.nvda, "speak", lambda *a, **k: True)

    class DummyApp:
        def __init__(self):
            self.logs = []
            self.announcements = []
        def set_log(self, text):
            self.logs.append(text)
        def announce(self, text):
            self.announcements.append(text)
        _handle_manual_update_result = main.SmartSchoolChimeApp._handle_manual_update_result
        _prompt_update_available = main.SmartSchoolChimeApp._prompt_update_available

    app = DummyApp()

    # Case 1: Already up to date
    app._handle_manual_update_result({"status": "success", "has_update": False})
    assert any(b[0] == "info" for b in boxes)
    assert "ล่าสุด" in app.logs[-1]

    # Case 2: Update available
    boxes.clear()
    update_info = {
        "status": "success",
        "has_update": True,
        "latest_version": "1.0.5",
        "current_version": "1.0.1",
        "release_notes": "Changelog text",
        "asset_name": "SmartSchoolChime_Setup_v1.0.5.exe",
        "asset_size": 25000000,
        "download_url": "https://example.com/setup.exe",
    }
    app._handle_manual_update_result(update_info)
    assert any(b[0] == "askyesno" for b in boxes)
    assert "1.0.5" in app.logs[-1]

    # Case 3: Error
    boxes.clear()
    app._handle_manual_update_result({"status": "error", "error_message": "Network timeout"})
    assert any(b[0] == "warning" for b in boxes)
    assert "Network timeout" in boxes[0][2]

