@echo off

@rem 文字コード Shift-JIS to UTF-8 変更
chcp 65001

set /p comment="comment："
git add .
git commit . -m %comment%
git push -u origin main
pause