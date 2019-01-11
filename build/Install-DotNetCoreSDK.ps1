$globalJson = Get-Content "..\global.json" | ConvertFrom-Json

Invoke-WebRequest 'https://dot.net/v1/dotnet-install.ps1' -OutFile 'dotnet-install.ps1';

./dotnet-install.ps1 -Version $globalJson.sdk.version;