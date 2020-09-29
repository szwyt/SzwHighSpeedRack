rd  .\publish\   /s /q
dotnet restore

dotnet build

cd C:\Users\szw\source\repos\SzwHighSpeedRack
dotnet publish -c Release -o ./publish
xcopy .\publish\*.* C:\inetpub\wwwroot\publish\    /e /y

echo "Successfully!!!! ^ please see the file .publish"
cmd