@echo off
set /p comment="commit comment："
echo %comment%
git add .
git commit . -m %comment%
git push origin main
pause
exit /b 0