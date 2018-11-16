// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Windows.Forms;

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
            
            var stackPanel = new Windows.UI.Xaml.Controls.StackPanel()
            {
                Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black),
            };

            stackPanel.Children.Add(new Windows.UI.Xaml.Shapes.Rectangle()
            {
                Width = 50,
                Height = 75,
                Fill = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Blue),
            });

            stackPanel.Children.Add(new Windows.UI.Xaml.Shapes.Rectangle()
            {
                Width = 200,
                Height = 30,
                Fill = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Red),
            });

            stackPanel.Children.Add(new Windows.UI.Xaml.Controls.Button()
            {
                Width = 160,
                Height = 60,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                Content = "This is a UWP Button",
            });

            stackPanel.Children.Add(new Windows.UI.Xaml.Shapes.Rectangle()
            {
                Width = 25,
                Height = 100,
                Fill = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Green),
            });

            stackPanel.Children.Add(new Windows.UI.Xaml.Controls.Button()
            {
                Width = 300,
                Height = 40,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                Content = "Another long UWP Button",
            });

            var comboBox = new Windows.UI.Xaml.Controls.ComboBox()
            {
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
            };
            comboBox.Items.Add("One");
            comboBox.Items.Add("Two");
            comboBox.Items.Add("Three");
            comboBox.Items.Add("Four");
            stackPanel.Children.Add(comboBox);

            windowsXamlHost.Child = stackPanel;
        }
    }
}
