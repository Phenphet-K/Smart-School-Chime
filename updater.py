"""Full-cycle auto-updater for Smart School Chime via GitHub Releases.

Provides:
- Semantic version comparison
- Background / Manual release checks against GitHub API
- Chunked file download with progress reporting & cancellation
- Graceful shutdown and execution of the new installer
"""

import json
import logging
import os
from pathlib import Path
import subprocess
import sys
import time
import urllib.error
import urllib.request
from typing import Callable, Optional

import app_paths

__version__ = "1.0.1"
GITHUB_REPO = "Phenphet-K/Smart-School-Chime"
RELEASES_API_URL = f"https://api.github.com/repos/{GITHUB_REPO}/releases/latest"

logger = logging.getLogger(__name__)


def parse_version(v: str) -> tuple[int, ...]:
    """Parse a version string into a tuple of integers for reliable comparison.

    Examples:
        'v1.0.1' -> (1, 0, 1)
        '1.2.3'  -> (1, 2, 3)
        '2.0'    -> (2, 0, 0)
    """
    if not v:
        return (0, 0, 0)
    cleaned = v.strip().lstrip("vV")
    parts: list[int] = []
    for section in cleaned.split("."):
        digits = ""
        for ch in section:
            if ch.isdigit():
                digits += ch
            else:
                break
        parts.append(int(digits) if digits else 0)
    while len(parts) < 3:
        parts.append(0)
    return tuple(parts)


def is_newer_version(latest_tag: str, current_version: str = __version__) -> bool:
    """Return True if latest_tag represents a strictly newer version than current_version."""
    return parse_version(latest_tag) > parse_version(current_version)


def find_installer_asset(assets: list[dict]) -> Optional[dict]:
    """Locate the Windows setup/installer executable from GitHub release assets."""
    # Priority 1: Setup or Installer exe
    for asset in assets:
        name = asset.get("name", "").lower()
        if name.endswith(".exe") and ("setup" in name or "installer" in name):
            return asset
    # Priority 2: Any .exe
    for asset in assets:
        name = asset.get("name", "").lower()
        if name.endswith(".exe"):
            return asset
    return None


def get_updates_directory() -> Path:
    """Return directory for temporary update installer downloads."""
    updates_dir = app_paths.STATE_DIR / "Updates"
    updates_dir.mkdir(parents=True, exist_ok=True)
    return updates_dir


def check_for_updates(current_version: str = __version__, timeout: int = 10) -> dict:
    """Check GitHub Releases API for newer version.

    Returns dict with keys:
        status: 'success' | 'error'
        has_update: bool
        is_newer: bool
        current_version: str
        latest_version: str
        tag_name: str
        release_name: str
        release_notes: str
        html_url: str
        asset_name: str
        download_url: str
        asset_size: int
        error_message: Optional[str]
    """
    req = urllib.request.Request(
        RELEASES_API_URL,
        headers={
            "User-Agent": f"SmartSchoolChime-Updater/{current_version}",
            "Accept": "application/vnd.github.v3+json",
        },
    )
    try:
        with urllib.request.urlopen(req, timeout=timeout) as response:
            payload = json.loads(response.read().decode("utf-8"))

        tag_name = payload.get("tag_name", "")
        remote_version = tag_name.lstrip("vV")
        is_newer = is_newer_version(tag_name, current_version)
        installer = find_installer_asset(payload.get("assets", []))

        return {
            "status": "success",
            "has_update": bool(is_newer and installer),
            "is_newer": is_newer,
            "current_version": current_version,
            "latest_version": remote_version,
            "tag_name": tag_name,
            "release_name": payload.get("name") or tag_name,
            "release_notes": payload.get("body") or "",
            "html_url": payload.get("html_url") or f"https://github.com/{GITHUB_REPO}/releases",
            "asset_name": installer.get("name") if installer else None,
            "download_url": installer.get("browser_download_url") if installer else None,
            "asset_size": installer.get("size", 0) if installer else 0,
            "error_message": None,
        }
    except Exception as exc:
        logger.warning("Failed to check for updates: %s", exc)
        return {
            "status": "error",
            "has_update": False,
            "is_newer": False,
            "current_version": current_version,
            "latest_version": None,
            "tag_name": None,
            "release_name": None,
            "release_notes": "",
            "html_url": f"https://github.com/{GITHUB_REPO}/releases",
            "asset_name": None,
            "download_url": None,
            "asset_size": 0,
            "error_message": str(exc),
        }


def download_update(
    download_url: str,
    dest_path: Path,
    progress_callback: Optional[Callable[[int, int, float, float], None]] = None,
    cancel_event: Optional[object] = None,
    chunk_size: int = 65536,
    timeout: int = 30,
) -> Path:
    """Download installer file with chunked streaming and progress callback.

    progress_callback receives (downloaded_bytes, total_bytes, percent, speed_bytes_per_sec)
    """
    dest_path = Path(dest_path)
    dest_path.parent.mkdir(parents=True, exist_ok=True)
    temp_path = dest_path.with_suffix(dest_path.suffix + ".download")

    req = urllib.request.Request(
        download_url,
        headers={"User-Agent": f"SmartSchoolChime-Updater/{__version__}"},
    )

    start_time = time.time()
    try:
        with urllib.request.urlopen(req, timeout=timeout) as response:
            total_size = int(response.headers.get("Content-Length", 0))
            downloaded = 0
            last_time = start_time
            last_bytes = 0
            current_speed = 0.0

            with open(temp_path, "wb") as f_out:
                while True:
                    if cancel_event and getattr(cancel_event, "is_set", lambda: False)():
                        raise InterruptedError("การดาวน์โหลดถูกยกเลิกโดยผู้ใช้")
                    chunk = response.read(chunk_size)
                    if not chunk:
                        break
                    f_out.write(chunk)
                    downloaded += len(chunk)

                    now = time.time()
                    elapsed = now - last_time
                    if elapsed >= 0.2:
                        current_speed = (downloaded - last_bytes) / elapsed
                        last_time = now
                        last_bytes = downloaded
                        percent = (downloaded / total_size * 100.0) if total_size > 0 else 0.0
                        if progress_callback:
                            progress_callback(downloaded, total_size, percent, current_speed)

        # Final progress report (100%)
        if progress_callback:
            progress_callback(downloaded, total_size or downloaded, 100.0, current_speed)

        if temp_path.exists():
            if dest_path.exists():
                try:
                    dest_path.unlink()
                except OSError:
                    pass
            temp_path.rename(dest_path)
        return dest_path
    finally:
        if temp_path.exists():
            try:
                temp_path.unlink()
            except OSError:
                pass


def launch_installer_and_exit(installer_path: Path | str, on_before_exit: Optional[Callable] = None):
    """Launch the installer executable detached and exit the current application."""
    installer_path = Path(installer_path).resolve()
    if not installer_path.is_file():
        raise FileNotFoundError(f"Installer not found: {installer_path}")

    # Launch detached so installer lives after Python process exits
    flags = 0
    if sys.platform == "win32":
        flags = getattr(subprocess, "DETACHED_PROCESS", 0x00000008) | getattr(
            subprocess, "CREATE_NEW_PROCESS_GROUP", 0x00000200
        )

    logger.info("Spawning installer: %s", installer_path)
    subprocess.Popen([str(installer_path)], close_fds=True, creationflags=flags)

    if on_before_exit:
        try:
            on_before_exit()
        except Exception as exc:
            logger.warning("Error running on_before_exit callback: %s", exc)

    # Clean immediate process exit
    os._exit(0)

