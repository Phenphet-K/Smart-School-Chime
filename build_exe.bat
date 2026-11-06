@echo off
cd /d "%~dp0"
chcp 65001 > nul
python -m PyInstaller --noconfirm SmartSchoolChime.spec
if errorlevel 1 (
    echo Build failed. Check the output above.
    pause
    exit /b 1
)
echo Build complete: dist\SmartSchoolChime.exe
pause
