@echo off
rd  .\publish\   /s /q
dotnet restore
dotnet build
dotnet publish -c Release -o ./publish
echo "Release Success"
pause