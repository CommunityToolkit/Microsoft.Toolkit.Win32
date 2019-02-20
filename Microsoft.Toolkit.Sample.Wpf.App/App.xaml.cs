// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Microsoft.Toolkit.Sample.Wpf.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
#pragma warning disable CA1724 // Type names should not match namespaces
    public partial class App : Application
#pragma warning restore CA1724 // Type names should not match namespaces
    {
        public App()
        {
            WindowsXamlHostBase.ApplicationCreated += (sender, args) =>
            {
                if (sender is global::Windows.UI.Xaml.Application xamlApplication)
                {
                    // Setting dark theme for the XAML island even when windows is set to light theme.
                    xamlApplication.RequestedTheme = global::Windows.UI.Xaml.ApplicationTheme.Dark;

                    // You can include .xbf files (XAML Binary Format) from an UWP app as described in 
                    // https://blogs.windows.com/buildingapps/2018/11/08/xaml-islands-a-deep-dive-part-2/
                    // The .xbf can define any XAML like pages and styles. Here you can create the 
                    // ResourceDictionary that will be used by the XAML in the island.

                    // var stylesUri = new Uri("ms-appx:///App/Styles/AppStyles.xaml");
                    // xamlApplication.Resources = new global::Windows.UI.Xaml.ResourceDictionary { Source = stylesUri };
                }
            };
        }
    }
}
