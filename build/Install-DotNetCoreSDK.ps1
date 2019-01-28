$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
$globalJsonPath = Join-Path -Path $PSScriptRoot -ChildPath ..\global.json
$globalJson = Get-Content $globalJsonPath | ConvertFrom-Json
$dotnetinstall = Join-Path -Path $PSScriptRoot dotnet-install.ps1

Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile $dotnetinstall;

& $dotnetinstall -Version $globalJson.sdk.version;