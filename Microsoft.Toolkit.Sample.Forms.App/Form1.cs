// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Windows.Forms;
using xaml = Windows.UI.Xaml;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.Samples.WinForms.App
{
    public partial class Form1 : Form
    {
        private xaml.Controls.ContentDialog _contentDialog;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inkCanvas1.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;

            xaml.Controls.StackPanel stackPanel = new xaml.Controls.StackPanel()
            {
                Background = new xaml.Media.SolidColorBrush(windows.UI.Colors.Black),
            };

            stackPanel.Children.Add(new xaml.Shapes.Rectangle()
            {
                Width = 50,
                Height = 75,
                Fill = new xaml.Media.SolidColorBrush(windows.UI.Colors.Blue),
            });

            stackPanel.Children.Add(new xaml.Shapes.Rectangle()
            {
                Width = 200,
                Height = 30,
                Fill = new xaml.Media.SolidColorBrush(windows.UI.Colors.Red),
            });

            var button = new xaml.Controls.Button()
            {
                Width = 160,
                Height = 60,
                HorizontalAlignment = xaml.HorizontalAlignment.Center,
                Content = "ContentDialog UWP Button",
            };
            button.Tapped += Button_Tapped;
            stackPanel.Children.Add(button);

            stackPanel.Children.Add(new xaml.Shapes.Rectangle()
            {
                Width = 25,
                Height = 100,
                Fill = new xaml.Media.SolidColorBrush(windows.UI.Colors.Green),
            });

            xaml.Controls.Flyout flyout = new xaml.Controls.Flyout();
            flyout.Content = new xaml.Controls.TextBlock() { Text = "Flyout content", };

            var button2 = new xaml.Controls.Button()
            {
                Width = 300,
                Height = 40,
                HorizontalAlignment = xaml.HorizontalAlignment.Center,
                Content = "Long UWP Button with Flyout",
                Flyout = flyout,
            };
            stackPanel.Children.Add(button2);

            var comboBox = new xaml.Controls.ComboBox()
            {
                HorizontalAlignment = xaml.HorizontalAlignment.Center,
            };
            comboBox.Items.Add("One");
            comboBox.Items.Add("Two");
            comboBox.Items.Add("Three");
            comboBox.Items.Add("Four");
            stackPanel.Children.Add(comboBox);

            xaml.Controls.Grid grid = new xaml.Controls.Grid();
            stackPanel.Children.Add(grid);

            _contentDialog = new xaml.Controls.ContentDialog();
            _contentDialog.Content = new xaml.Controls.TextBlock() { Text = "ContentDialog content", };
            stackPanel.Children.Add(_contentDialog);

            var popup = new xaml.Controls.Primitives.Popup()
            {
                Width = 50,
                Height = 50,
                ShouldConstrainToRootBounds = false,
                Child = new xaml.Controls.TextBlock() { Text = "Popup child", },
            };
            grid.Children.Add(popup);

            windowsXamlHost.Child = stackPanel;
            popup.IsOpen = true;
        }
        private async void Button_Tapped(object sender, xaml.Input.TappedRoutedEventArgs e)
        {
            await _contentDialog.ShowAsync(xaml.Controls.ContentDialogPlacement.Popup);
        }
    }
}
