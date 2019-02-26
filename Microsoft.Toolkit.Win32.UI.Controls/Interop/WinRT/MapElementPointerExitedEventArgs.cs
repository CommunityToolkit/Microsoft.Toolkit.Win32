// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// Provides data for events. This class cannot be inherited.
    /// </summary>
    /// <remarks>Copy from <see cref="windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs"/>
    public sealed class MapElementPointerExitedEventArgs : EventArgs
    {
        private readonly windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs _args;

        internal MapElementPointerExitedEventArgs(windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs args)
        {
            _args = args;
        }

        public windows.Devices.Geolocation.Geopoint Location
        {
            get => (windows.Devices.Geolocation.Geopoint)_args.Location;
        }

        public windows.UI.Xaml.Controls.Maps.MapElement MapElement
        {
            get => (windows.UI.Xaml.Controls.Maps.MapElement)_args.MapElement;
        }

        public windows.Foundation.Point Position
        {
            get => (windows.Foundation.Point)_args.Position;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs"/> to <see cref="Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapElementPointerExitedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MapElementPointerExitedEventArgs(
            windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs args)
        {
            return FromMapElementPointerExitedEventArgs(args);
        }

        /// <summary>
        /// Creates a <see cref="MapElementPointerExitedEventArgs"/> from <see cref="windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="MapElementPointerExitedEventArgs"/></returns>
        public static MapElementPointerExitedEventArgs FromMapElementPointerExitedEventArgs(windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs args)
        {
            return new MapElementPointerExitedEventArgs(args);
        }
    }
}