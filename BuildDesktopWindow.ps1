msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Restore /p:Configuration=Release /p:Platform=x64
msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:ReBuild /p:Configuration=Release /p:Platform=x64

msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Restore /p:Configuration=Release /p:Platform=x86
msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:ReBuild /p:Configuration=Release /p:Platform=x86

msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Restore /p:Configuration=Release /p:Platform=ARM64
msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:ReBuild /p:Configuration=Release /p:Platform=ARM64

msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Pack /p:Configuration=Release /p:Platform="Any CPU"

