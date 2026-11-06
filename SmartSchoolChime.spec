# -*- mode: python ; coding: utf-8 -*-
import os
import shutil
from pathlib import Path

a = Analysis(
    ['main.py'],
    pathex=[],
    binaries=[('nvdaControllerClient64.dll', '.')],
    datas=[('icon.ico', '.'), ('logo.png', '.'), ('icon.png', '.'), ('Sound', 'Sound')],
    hiddenimports=['qrcode', 'PIL', 'sqlite3', 'winsound', 'cryptography.x509', 'updater'],
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=['numpy', 'matplotlib', 'pygame', 'pandas', 'pytest', 'IPython', 'clr', 'pythonnet'],
    noarchive=False,
    optimize=0,
)
pyz = PYZ(a.pure)

exe = EXE(
    pyz,
    a.scripts,
    a.binaries,
    a.datas,
    [],
    name='SmartSchoolChime',
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=True,
    upx_exclude=[],
    runtime_tmpdir=None,
    console=False,
    disable_windowed_traceback=False,
    argv_emulation=False,
    target_arch=None,
    codesign_identity=None,
    entitlements_file=None,
    icon=['icon.ico'],
)

# Post-build: Create dist/SmartSchoolChime folder with all necessary folders (Config, data, Sound)
dist_dir = os.path.join(DISTPATH, 'SmartSchoolChime')
os.makedirs(dist_dir, exist_ok=True)

# Copy main executable into dist/SmartSchoolChime
exe_src = os.path.join(DISTPATH, 'SmartSchoolChime.exe')
exe_dst = os.path.join(dist_dir, 'SmartSchoolChime.exe')
if os.path.exists(exe_src):
    shutil.copy2(exe_src, exe_dst)

# Sound is embedded. Never package live databases, private keys or user settings.

# Copy necessary support files
for file_name in ['icon.ico', 'README.md', 'LICENSE']:
    src_file = os.path.join(SPECPATH, file_name)
    dst_file = os.path.join(dist_dir, file_name)
    if os.path.exists(src_file):
        shutil.copy2(src_file, dst_file)
