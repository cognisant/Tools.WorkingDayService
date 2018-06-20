@echo off

SET VERSION=0.0.0
IF NOT [%1]==[] (set VERSION=%1)

SET TAG=0.0.0
IF NOT [%2]==[] (set TAG=%2)
SET TAG=%TAG:tags/=%

dotnet test .\src\CR.WorkingDayService.Tests\CR.WorkingDayService.Tests.csproj
if %errorlevel% neq 0 exit /b %errorlevel%

dotnet pack .\src\CR.WorkingDayService\CR.WorkingDayService.csproj -o ..\..\dist -p:Version="%VERSION%" -p:PackageVersion="%VERSION%" -p:Tag="%TAG%" -c Release