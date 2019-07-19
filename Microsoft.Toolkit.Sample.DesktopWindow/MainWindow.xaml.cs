using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace Microsoft.Toolkit.Sample.DesktopWindow
{
    class MainWindow: Microsoft.Toolkit.Win32.UI.XamlHost.DesktopWindow
    {
        public MainWindow()
        {
            global::System.Uri resourceLocator = new global::System.Uri("ms-appx:///MainWindow.xaml");
            global::Windows.UI.Xaml.Application.LoadComponent(this, resourceLocator, global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
        }
    }
}
