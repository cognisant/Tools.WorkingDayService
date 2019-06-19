@echo off

SET VERSION=0.0.0
IF NOT [%1]==[] (set VERSION=%1)

SET TAG=0.0.0
IF NOT [%2]==[] (set TAG=%2)
SET TAG=%TAG:tags/=%

dotnet test .\src\Tools.WorkingDayService.Tests\Tools.WorkingDayService.Tests.csproj
if %errorlevel% neq 0 exit /b %errorlevel%

dotnet pack .\src\Tools.WorkingDayService\Tools.WorkingDayService.csproj -o ..\..\dist -p:Version="%VERSION%" -p:PackageVersion="%VERSION%" -p:Tag="%TAG%" -c Release
exit /b %errorlevel%
