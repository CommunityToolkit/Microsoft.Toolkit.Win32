using System;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    public static class DesktopWindowExtensions
    {
        public static void InitializeComponent(this DesktopWindow @this)
        {
            var resourceLocator = new global::System.Uri($"ms-appx:///{@this.GetType().Name}.xaml");
            global::Windows.UI.Xaml.Application.LoadComponent(@this, resourceLocator, global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
        }
    }
}
