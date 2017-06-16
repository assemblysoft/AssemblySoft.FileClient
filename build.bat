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

mkdir Build
::call %nuget% pack "AssemblySoft.FileClient\AssemblySoft.FileClient.csproj" -IncludeReferencedProjects -verbosity detailed -o Build -p Configuration=%config% %version%
call %nuget% pack "AssemblySoft.FileClient\AssemblySoft.FileClient.nuspec" -IncludeReferencedProjects -verbosity detailed -o Build -p Configuration="%config%"
