// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Windows.Forms;
using WUX = Windows.UI.Xaml;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.Samples.WinForms.App
{
    public partial class Form1 : Form
    {
        private WUX.Controls.ContentDialog _contentDialog;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inkCanvas1.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;

            WUX.Controls.StackPanel stackPanel = new WUX.Controls.StackPanel()
            {
                Background = new WUX.Media.SolidColorBrush(windows.UI.Colors.Black),
            };

            stackPanel.Children.Add(new WUX.Shapes.Rectangle()
            {
                Width = 50,
                Height = 75,
                Fill = new WUX.Media.SolidColorBrush(global::Windows.UI.Colors.Blue),
            });

            stackPanel.Children.Add(new WUX.Shapes.Rectangle()
            {
                Width = 200,
                Height = 30,
                Fill = new WUX.Media.SolidColorBrush(global::Windows.UI.Colors.Red),
            });

            var button = new WUX.Controls.Button
            {
                Width = 160,
                Height = 60,
                HorizontalAlignment = WUX.HorizontalAlignment.Center,
                Content = "ContentDialog UWP Button",
            };
            button.Tapped += Button_Tapped;
            stackPanel.Children.Add(button);

            stackPanel.Children.Add(new WUX.Shapes.Rectangle()
            {
                Width = 25,
                Height = 100,
                Fill = new WUX.Media.SolidColorBrush(global::Windows.UI.Colors.Green),
            });

            WUX.Controls.Flyout flyout = new WUX.Controls.Flyout();
            flyout.Content = new WUX.Controls.TextBlock() { Text = "Flyout content", };

            var button2 = new WUX.Controls.Button()
            {
                Width = 300,
                Height = 40,
                HorizontalAlignment = WUX.HorizontalAlignment.Center,
                Content = "Long UWP Button with Flyout",
                Flyout = flyout,
            };
            stackPanel.Children.Add(button2);

            var comboBox = new WUX.Controls.ComboBox()
            {
                HorizontalAlignment = WUX.HorizontalAlignment.Center,
            };
            comboBox.Items.Add("One");
            comboBox.Items.Add("Two");
            comboBox.Items.Add("Three");
            comboBox.Items.Add("Four");
            stackPanel.Children.Add(comboBox);

            WUX.Controls.Grid grid = new WUX.Controls.Grid();
            stackPanel.Children.Add(grid);

            _contentDialog = new WUX.Controls.ContentDialog();
            _contentDialog.Content = new WUX.Controls.TextBlock() { Text = "ContentDialog content", };
            stackPanel.Children.Add(_contentDialog);

            var popup = new WUX.Controls.Primitives.Popup()
            {
                Width = 50,
                Height = 50,
                ShouldConstrainToRootBounds = false,
                Child = new WUX.Controls.TextBlock() { Text = "Popup child", },
            };
            grid.Children.Add(popup);

            windowsXamlHost.Child = stackPanel;
            popup.IsOpen = true;
        }
        private async void Button_Tapped(object sender, WUX.Input.TappedRoutedEventArgs e)
        {
            await _contentDialog.ShowAsync(WUX.Controls.ContentDialogPlacement.Popup);
        }
    }
}
