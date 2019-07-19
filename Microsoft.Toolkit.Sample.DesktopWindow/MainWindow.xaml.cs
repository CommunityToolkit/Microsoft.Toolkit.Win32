using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Windows.UI.Xaml;
using Microsoft.Toolkit.Win32.UI.XamlHost;

namespace Microsoft.Toolkit.Sample.DesktopWindow
{
    internal partial class MainWindow: Microsoft.Toolkit.Win32.UI.XamlHost.DesktopWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Hello from Xaml!");
        }
    }
}
