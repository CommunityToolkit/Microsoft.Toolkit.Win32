---
topic: sample
languages:
- csharp
products:
- windows
---

# Windows Community Toolkit - WPF and Windows Forms 
This repository contains all controls for WPF and WinForms to simplify and demonstate usage of UWP controls.

For everything else in the Windows Community Toolkit (UWP controls, .NET Standard web services, helpers and more), [start here](https://github.com/windows-toolkit/WindowsCommunityToolkit)

## XAML Islands Notice
The set of WPF and WinForms controls found here are only designed to work with .NET Core 3.1, nor NET 5 and above. These controls are using the XAML Islands Windows 10 APIs included within the Windows 10 OS, and those APIS won't be improved anymore. 

WinUI 3's XAML Islands is the path forward to these .NET apps that want to use .NET 5 and WinUI. WinUI 3's XAML Islands are still in development, and we recommend reviewing the [WinUI 3 roadmap](https://github.com/Microsoft/microsoft-ui-xaml/blob/master/docs/roadmap.md) to get the latest updates. This repository will be deprecated once WinUI 3'XAML Islands is released.



## Build Status
| Target | Branch | Status | Recommended NuGet packages version |
| ------ | ------ | ------ | ------ |
| Pre-release beta testing | master | [![Build Status](https://dev.azure.com/dotnet/WindowsCommunityToolkit/_apis/build/status/nmetulev.Win32Test)](https://dev.azure.com/dotnet/WindowsCommunityToolkit/_build/latest?definitionId=59) | [![MyGet](https://img.shields.io/dotnet.myget/uwpcommunitytoolkit/vpre/Microsoft.Toolkit.Forms.UI.XamlHost.svg)](https://dotnet.myget.org/gallery/uwpcommunitytoolkit) |

## Getting Started
Please read the [getting Started with the Windows Community Toolkit](https://docs.microsoft.com/windows/communitytoolkit/getting-started) page for more detailed information about using the toolkit.

## Documentation
All documentation for the toolkit is hosted on [Microsoft Docs](https://docs.microsoft.com/windows/communitytoolkit/). All API documentation can be found at the [.NET API Browser](https://docs.microsoft.com/en-us/dotnet/api/?term=microsoft.toolkit).

## Windows Community Toolkit Sample App
Want to see the toolkit in action before jumping into the code? Download and play with the [Windows Community Toolkit Sample App](https://www.microsoft.com/store/apps/9nblggh4tlcq) from the Store.

## Controls

| Control | Minimum supported OS | Description |
|-----------------|-------------------------------|-------------|
| [WindowsXamlHost](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/windowsxamlhost) | Windows 10, version 1809 | Adds built-in or custom UWP controls to the User Interface (UI) of WPF or Windows Forms desktop application. |
| [WebView](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webview) | Windows 10, version 1803 | Uses the Microsoft Edge rendering engine to show web content. |
| [WebViewCompatible](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/webviewcompatible) | Windows 7 | Provides a version of **WebView** that is compatible with more OS versions. This control uses the Microsoft Edge rendering engine to show web content on Windows 10 version 1803 and later, and the Internet Explorer rendering engine to show web content on earlier versions of Windows 10, Windows 8.x, and Windows 7. |
| [InkCanvas](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inkcanvas)<br>[InkToolbar](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/inktoolbar) | Windows 10, version 1809 | Provide a surface and related toolbars for Windows Ink-based user interaction in your Windows Forms or WPF desktop application. |
| [MediaPlayerElement](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/mediaplayerelement) | Windows 10, version 1809 | Embeds a view that streams and renders media content such as video in your Windows Forms or WPF desktop application. |
| [MapControls](https://docs.microsoft.com/windows/communitytoolkit/controls/wpf-winforms/mapcontrol) | Windows 10, version 1809 | Enables a symbolic or photorealistic map in your Windows Forms or WPF desktop application. |

## WebView Notice
**New:** _Try out the pre-release preview of WebView2 for .NET [here](https://docs.microsoft.com/en-us/microsoft-edge/webview2/releasenotes#09515-prerelease)._ 🎉🎉🎉

WebView2 will replace the WebView control in the toolkit, as laid out in the introduction to [WebView2 here](https://aka.ms/WebView2). This means that we've deprecated the WebView control within the Toolkit and are working with the Edge team to convey all the requirements from the open issues here.

Over the next few months, they'll be processing the open requests to ensure the scenarios folks are using WebView for will be supported with its replacement in the future. You can provide feedback directly to the Edge team [here](https://github.com/MicrosoftEdge/WebViewFeedback). Thank you for using WebView!

## Feedback and Requests
Please use [GitHub Issues](https://github.com/windows-toolkit/WindowsCommunityToolkit/issues) for bug reports and feature requests.
For feature requests, please also create an entry in our [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/193402-uwp-community-toolkit).
For general questions and support, please use [Stack Overflow](https://stackoverflow.com/questions/tagged/windows-community-toolkit) where questions should be tagged with the tag `windows-community-toolkit`.

## Contributing
Do you want to contribute? Here are our [contribution guidelines](https://github.com/windows-toolkit/WindowsCommunityToolkit/blob/master/contributing.md).

## Principles
* Principle **#1**: The toolkit will be kept simple.
* Principle **#2**: As soon as a comparable feature is available in the Windows SDK for Windows 10, it will be marked as deprecated.
* Principle **#3**: All features will be supported for two Windows SDK for Windows 10 release cycles or until another principle supersedes it.

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behavior in our community.
For more information see the [.NET Foundation Code of Conduct](http://dotnetfoundation.org/code-of-conduct).

## Roadmap
Read what we [plan for next iterations](https://github.com/windows-toolkit/WindowsCommunityToolkit/milestones), and feel free to ask questions.

By adding this ([NuGet repo](https://dotnet.myget.org/F/uwpcommunitytoolkit/api/v3/index.json) | [Gallery](https://dotnet.myget.org/gallery/uwpcommunitytoolkit)) to your NuGet sources in Visual Studio, you can also get pre-release packages of upcoming versions.

## .NET Foundation
This project is supported by the [.NET Foundation](http://dotnetfoundation.org).
