@rem 文字コード Shift-JIS -> UTF-8 変更
@echo off
chcp 65001

set /p comment="comment："
echo %comment%
git add .
git commit . -m %comment%