@rem 文字コード Shift-JIS to UTF-8 変更
chcp 65001

@echo off
set /p comment="Commit Comment："

@echo on
git add .
git commit . -m "%comment%"

@echo off
pause
exit /b 0
