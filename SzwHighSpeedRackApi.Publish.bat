@echo off
rd  .\publish\   /s /q
dotnet restore
dotnet build
cd C:\Users\szw\source\repos\SzwHighSpeedRack
dotnet publish -c Release -o ./publish
xcopy .\publish\*.* C:\inetpub\wwwroot\publish\    /e /y
echo "Release Success"
pause