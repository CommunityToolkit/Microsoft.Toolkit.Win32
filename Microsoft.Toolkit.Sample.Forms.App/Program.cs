// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Forms;
using WUX = Windows.UI.Xaml;

namespace Microsoft.Toolkit.Win32.Samples.WinForms.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(Microsoft.Toolkit.Forms.UI.XamlHost.WindowsXamlHostBase).TypeHandle);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Form1());
        }
    }
}
