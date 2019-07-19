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

    partial class MainWindow : global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        public void Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 2: // MainPage.xaml line 12
                    {
                        var element = (global::Windows.UI.Xaml.Controls.Button)(target);
                        element.Click += this.OnButtonClick;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            return null;
        }
    }

}
