// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Markup;

namespace Microsoft.Toolkit.Sample.Wpf.App
{
    public class MyControl : Toolkit.Wpf.UI.XamlHost.WindowsXamlHostBase
    {
        static MyControl()
        {
            if (MetadataContainer != null)
            {
                MetadataContainer.MetadataProviders.Add(new MyMetadataProvider());
            }
            else
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                throw new InvalidOperationException($"{typeof(MyControl).Name} only supported for {typeof(global::Windows.UI.Xaml.Application).FullName} instances that implements {typeof(Win32.UI.XamlHost.IXamlMetadataContainer).FullName}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
            }
        }

        public MyControl()
        {
        }
    }

    public sealed class MyMetadataProvider : IXamlMetadataProvider
    {
        public IXamlType GetXamlType(Type type)
        {
            return null;
        }

        public IXamlType GetXamlType(string fullName)
        {
            return null;
        }

        public XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return System.Linq.Enumerable.Empty<XmlnsDefinition>().ToArray();
        }
    }

    public static class Program
    {
        enum StartupKind
        {
            Explict,
            CustomAppSettings,
            Normal,
        };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var startupKind = StartupKind.Normal;

            if (startupKind == StartupKind.CustomAppSettings)
            {
                using (var xamlApp = new Win32.UI.XamlHost.XamlApplication(new List<IXamlMetadataProvider>()
                {
                    new MyMetadataProvider(),
                })
                {
                    Resources = new global::Windows.UI.Xaml.ResourceDictionary()
                        {
                            { "MyResourceKey", "MyValue" },
                        },
                })
                {
                    var app = new Microsoft.Toolkit.Sample.Wpf.App.App();
                    app.InitializeComponent();
                    app.Run();
                }
            }
#if !NET462
            else if (startupKind == StartupKind.Explict)
            {
                using (var xamlApp = new Microsoft.Toolkit.Sample.UWP.App.App())
                {
                    var appOwnedWindowsXamlManager = xamlApp.WindowsXamlManager;
                    var app = new Microsoft.Toolkit.Sample.Wpf.App.App();
                    app.InitializeComponent();
                    app.Run();
                }
            }
#endif
            else
            {
                var app = new Microsoft.Toolkit.Sample.Wpf.App.App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
}