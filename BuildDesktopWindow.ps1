msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Restore /p:Configuration=Release /p:Platform=x64
msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Build /p:Configuration=Release /p:Platform=x64

msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Restore /p:Configuration=Release
msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Build /p:Configuration=Release

msbuild .\Microsoft.Toolkit.DesktopWindow.sln /nologo /v:m /t:Pack /p:Configuration=Release

