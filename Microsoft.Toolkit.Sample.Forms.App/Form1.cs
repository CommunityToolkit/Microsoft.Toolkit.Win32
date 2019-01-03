// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Windows.Forms;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.Samples.WinForms.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inkCanvas1.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;
            
            var stackPanel = new windows.UI.Xaml.Controls.StackPanel()
            {
                Background = new windows.UI.Xaml.Media.SolidColorBrush(windows.UI.Colors.Black),
            };

            stackPanel.Children.Add(new windows.UI.Xaml.Shapes.Rectangle()
            {
                Width = 50,
                Height = 75,
                Fill = new windows.UI.Xaml.Media.SolidColorBrush(windows.UI.Colors.Blue),
            });

            stackPanel.Children.Add(new windows.UI.Xaml.Shapes.Rectangle()
            {
                Width = 200,
                Height = 30,
                Fill = new windows.UI.Xaml.Media.SolidColorBrush(windows.UI.Colors.Red),
            });

            stackPanel.Children.Add(new windows.UI.Xaml.Controls.Button()
            {
                Width = 160,
                Height = 60,
                HorizontalAlignment = windows.UI.Xaml.HorizontalAlignment.Center,
                Content = "This is a UWP Button",
            });

            stackPanel.Children.Add(new windows.UI.Xaml.Shapes.Rectangle()
            {
                Width = 25,
                Height = 100,
                Fill = new windows.UI.Xaml.Media.SolidColorBrush(windows.UI.Colors.Green),
            });

            stackPanel.Children.Add(new windows.UI.Xaml.Controls.Button()
            {
                Width = 300,
                Height = 40,
                HorizontalAlignment = windows.UI.Xaml.HorizontalAlignment.Center,
                Content = "Another long UWP Button",
            });

            windowsXamlHost.Child = stackPanel;
        }
    }
}
