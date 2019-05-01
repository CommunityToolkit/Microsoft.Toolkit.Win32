// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    public class MapIcon : MapElement
    {
        public MapIcon(global::Windows.UI.Xaml.Controls.Maps.MapIcon icon)
            : base(icon)
        {
        }

        public MapIcon()
            : base(new global::Windows.UI.Xaml.Controls.Maps.MapIcon())
        {
        }

        public Geopoint Location
        {
            get => ((global::Windows.UI.Xaml.Controls.Maps.MapIcon)this.UwpInstance).Location;
            set => ((global::Windows.UI.Xaml.Controls.Maps.MapIcon)this.UwpInstance).Location = value.UwpInstance;
        }
    }
}