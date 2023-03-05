@rem 文字コード Shift-JIS to UTF-8 変更
chcp 65001

@echo off

set /p comment="comment："
git add .
git commit . -m %comment%
git commit . -m "batch commit push"
git push -u origin main
pause
