@echo off
cd Database
set /p id="Enter Migration Name (without spaces) : "
dotnet ef migrations add %id%
pause
