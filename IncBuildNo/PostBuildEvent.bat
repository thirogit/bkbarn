@echo off
"C:\WINNT40\Profiles\ah.HISCIA\Eigene Dateien\Visual Studio 2005\Projects\incBuildNo\IncBuildNo" "C:\WINNT40\Profiles\ah.HISCIA\Eigene Dateien\Visual Studio 2005\Projects\incBuildNo\AssemblyInfo.cs"  Release
if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd