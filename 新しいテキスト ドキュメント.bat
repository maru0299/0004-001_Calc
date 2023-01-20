@rem 文字コード Shift-JIS -> UTF-8 変更
chcp 65001

@echo off
set /p comment="commit comment："
echo %comment%
git add .
git commit . -m %comment%
git push origin main
pause
exit /b 0