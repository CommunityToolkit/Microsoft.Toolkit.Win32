// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// Provides data for events. This class cannot be inherited.
    /// </summary>
    /// <remarks>Copy from <see cref="windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs"/>
    public sealed class MapElementClickEventArgs : EventArgs
    {
        private readonly windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs _args;

        internal MapElementClickEventArgs(windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs args)
        {
            _args = args;
        }

        public windows.Devices.Geolocation.Geopoint Location
        {
            get => (windows.Devices.Geolocation.Geopoint)_args.Location;
        }

        public System.Collections.Generic.IList<windows.UI.Xaml.Controls.Maps.MapElement> MapElements
        {
            get => (System.Collections.Generic.IList<windows.UI.Xaml.Controls.Maps.MapElement>)_args.MapElements;
        }

        public windows.Foundation.Point Position
        {
            get => (windows.Foundation.Point)_args.Position;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs"/> to <see cref="Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapElementClickEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MapElementClickEventArgs(
            windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs args)
        {
            return FromMapElementClickEventArgs(args);
        }

        /// <summary>
        /// Creates a <see cref="MapElementClickEventArgs"/> from <see cref="windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="MapElementClickEventArgs"/></returns>
        public static MapElementClickEventArgs FromMapElementClickEventArgs(windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs args)
        {
            return new MapElementClickEventArgs(args);
        }
    }
}