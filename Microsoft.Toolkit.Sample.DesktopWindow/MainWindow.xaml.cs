using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Toolkit.Sample.DesktopWindow
{
    class MainWindow: Microsoft.Toolkit.Win32.UI.XamlHost.DesktopWindow
    {
        public MainWindow()
        {
            Content = new global::Windows.UI.Xaml.Controls.Button()
            {
                Content = "Hello from Xaml",
            };
        }
    }
}
