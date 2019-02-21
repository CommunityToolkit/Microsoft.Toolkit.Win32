// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Microsoft.Toolkit.Wpf.UI.XamlHost
{
    /// <summary>
    /// Extensions for use with UWP UIElement objects wrapped by the WindowsXamlHostBaseExt
    /// </summary>
    public static class UwpUIElementExtensions
    {
        private static bool IsDesktopWindowsXamlSourcePresent() => Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.UI.Xaml.Hosting.HostingContract", 3);

        private static Windows.UI.Xaml.DependencyProperty WrapperProperty
        {
            get
            {
                if (IsDesktopWindowsXamlSourcePresent())
                {
                    var result = Windows.UI.Xaml.DependencyProperty.RegisterAttached("Wrapper", typeof(System.Windows.UIElement), typeof(UwpUIElementExtensions), new Windows.UI.Xaml.PropertyMetadata(null));
                    return result;
                }

                throw new NotImplementedException();
            }
        }

        public static WindowsXamlHostBase GetWrapper(this Windows.UI.Xaml.UIElement element)
        {
            if (IsDesktopWindowsXamlSourcePresent())
            {
                return (WindowsXamlHostBase)element.GetValue(WrapperProperty);
            }

            return null;
        }

        public static void SetWrapper(this Windows.UI.Xaml.UIElement element, WindowsXamlHostBase wrapper)
        {
            if (IsDesktopWindowsXamlSourcePresent())
            {
                element.SetValue(WrapperProperty, wrapper);
            }
        }
    }
}
