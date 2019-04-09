// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace Microsoft.Toolkit.Sample.Wpf.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Windows.UI.Xaml.Controls.ContentDialog _contentDialog;

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
            Windows.UI.Xaml.Controls.StackPanel stackPanel = new Windows.UI.Xaml.Controls.StackPanel()
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

            var button = new Windows.UI.Xaml.Controls.Button()
            {
                Width = 160,
                Height = 60,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                Content = "ContentDialog UWP Button",
            };
            button.Tapped += Button_Tapped;
            stackPanel.Children.Add(button);

            stackPanel.Children.Add(new Windows.UI.Xaml.Shapes.Rectangle()
            {
                Width = 25,
                Height = 100,
                Fill = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Green),
            });

            Windows.UI.Xaml.Controls.Flyout flyout = new Windows.UI.Xaml.Controls.Flyout();
            flyout.Content = new Windows.UI.Xaml.Controls.TextBlock() { Text = "Flyout content", };

            var button2 = new Windows.UI.Xaml.Controls.Button()
            {
                Width = 300,
                Height = 40,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
                Content = "Long UWP Button with Flyout",
                Flyout = flyout,
            };
            stackPanel.Children.Add(button2);

            var comboBox = new Windows.UI.Xaml.Controls.ComboBox()
            {
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center,
            };
            comboBox.Items.Add("One");
            comboBox.Items.Add("Two");
            comboBox.Items.Add("Three");
            comboBox.Items.Add("Four");
            stackPanel.Children.Add(comboBox);

            Windows.UI.Xaml.Controls.Grid grid = new Windows.UI.Xaml.Controls.Grid();
            stackPanel.Children.Add(grid);

            _contentDialog = new Windows.UI.Xaml.Controls.ContentDialog();
            _contentDialog.Content = new Windows.UI.Xaml.Controls.TextBlock() { Text = "ContentDialog content", };
            stackPanel.Children.Add(_contentDialog);

            var popup = new Windows.UI.Xaml.Controls.Primitives.Popup()
            {
                Width = 50,
                Height = 50,
            };
            grid.Children.Add(popup);

            var canvas = new Windows.UI.Xaml.Controls.Canvas()
            {
                Width = 50,
                Height = 50,
                Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Green),
            };
            popup.Child = canvas;

            windowsXamlHost.Child = stackPanel;
            popup.IsOpen = true;
        }

        private async void Button_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            await _contentDialog.ShowAsync(Windows.UI.Xaml.Controls.ContentDialogPlacement.Popup);
        }
    }
}
