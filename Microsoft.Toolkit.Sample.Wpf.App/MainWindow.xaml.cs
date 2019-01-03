// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using xaml = Windows.UI.Xaml;
using windows = Windows;


namespace Microsoft.Toolkit.Sample.Wpf.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private xaml.Controls.ContentDialog _contentDialog;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void inkCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
        }

        private void inkToolbar_Initialized(object sender, EventArgs e)
        {
            // Handle ink toolbar initialization events here
        }

        private void inkToolbar_ActiveToolChanged(object sender, object e)
        {
            // Handle ink toolbar active tool changed events here.
        }

        private async void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
            var cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            await myMap.TrySetViewAsync(cityCenter, 12);
        }

        private void WindowsXamlHost_Loaded(object sender, RoutedEventArgs e)
        {
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
