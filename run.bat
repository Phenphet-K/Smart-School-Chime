@echo off
cd /d "%~dp0"
chcp 65001 > nul
title Smart School Chime - ระบบเสียงสัญญาณและประกาศเวลาโรงเรียนอัจฉริยะ
echo ========================================================
echo   🔔 Smart School Chime
echo   ระบบเสียงสัญญาณและประกาศเวลาโรงเรียนอัจฉริยะ (Universal Accessibility)
echo ========================================================
echo.
echo กำลังเริ่มต้นโปรแกรม...
python main.py
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo เกิดข้อผิดพลาดในการรันโปรแกรม กรุณาตรวจสอบว่าได้ติดตั้ง Python เรียบร้อยแล้ว
    pause
)
