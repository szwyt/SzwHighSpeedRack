@echo off
dotnet restore
dotnet build
dotnet publish -c Release -o ./publish
echo "Release Success"
pause