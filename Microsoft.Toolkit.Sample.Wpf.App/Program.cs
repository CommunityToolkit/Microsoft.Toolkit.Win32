// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using Microsoft.Toolkit.Xaml.Markup;
using Windows.UI.Xaml.Markup;

namespace Microsoft.Toolkit.Sample.Wpf.App
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (new Microsoft.Toolkit.Sample.UWP.App.App())
            {
                var app = new Microsoft.Toolkit.Sample.Wpf.App.App();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
}
