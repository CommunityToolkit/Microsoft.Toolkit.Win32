// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using uwpXaml = Windows.UI.Xaml;

namespace Microsoft.Toolkit.Wpf.UI.XamlHost
{
    /// <summary>
    /// Extensions for use with UWP UIElement objects wrapped by the WindowsXamlHostBaseExt
    /// </summary>
    public static class UwpUIElementExtensions
    {
        private static uwpXaml.DependencyProperty WrapperProperty { get; } =
            uwpXaml.DependencyProperty.RegisterAttached("Wrapper", typeof(System.Windows.UIElement), typeof(UwpUIElementExtensions), new uwpXaml.PropertyMetadata(null));

        public static WindowsXamlHostBase GetWrapper(this uwpXaml.UIElement element)
        {
            return (WindowsXamlHostBase)element.GetValue(WrapperProperty);
        }

        public static void SetWrapper(this uwpXaml.UIElement element, WindowsXamlHostBase wrapper)
        {
            element.SetValue(WrapperProperty, wrapper);
        }
    }
}
