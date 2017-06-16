@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

"%programfiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe" AssemblySoft.FileClient.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

::mkdir Build
::mkdir Build\lib
::mkdir Build\lib\net40

%nuget% pack "AssemblySoft.FileClient\AssemblySoft.FileClient.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"
