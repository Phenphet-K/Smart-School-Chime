@echo off
chcp 65001 > nul
title Building Smart School Chime EXE
echo ========================================================
echo   กำลังสร้างไฟล์ SmartSchoolChime.exe ด้วย PyInstaller
echo ========================================================
echo.

python -m PyInstaller --noconsole --onefile --name "SmartSchoolChime" --icon="icon.ico" --add-data "nvdaControllerClient64.dll;." --add-data "icon.ico;." --add-data "logo.png;." --add-data "icon.png;." main.py

echo.
echo ========================================================
echo   การสร้าง EXE เสร็จสิ้น! ตรวจสอบไฟล์ได้ที่โฟลเดอร์ dist/
echo ========================================================
pause
