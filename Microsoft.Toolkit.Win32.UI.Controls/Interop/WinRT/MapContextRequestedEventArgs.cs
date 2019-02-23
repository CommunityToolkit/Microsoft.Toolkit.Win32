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
    /// <remarks>Copy from <see cref="windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs"/>
    public sealed class MapContextRequestedEventArgs : EventArgs
    {
        private readonly windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs _args;

        internal MapContextRequestedEventArgs(windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs args)
        {
            _args = args;
        }

        public windows.Devices.Geolocation.Geopoint Location
        {
            get => (windows.Devices.Geolocation.Geopoint)_args.Location;
        }

        public System.Collections.Generic.IReadOnlyList<windows.UI.Xaml.Controls.Maps.MapElement> MapElements
        {
            get => (System.Collections.Generic.IReadOnlyList<windows.UI.Xaml.Controls.Maps.MapElement>)_args.MapElements;
        }

        public windows.Foundation.Point Position
        {
            get => (windows.Foundation.Point)_args.Position;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs"/> to <see cref="Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapContextRequestedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MapContextRequestedEventArgs(
            windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs args)
        {
            return FromMapContextRequestedEventArgs(args);
        }

        /// <summary>
        /// Creates a <see cref="MapContextRequestedEventArgs"/> from <see cref="windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="MapContextRequestedEventArgs"/></returns>
        public static MapContextRequestedEventArgs FromMapContextRequestedEventArgs(windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs args)
        {
            return new MapContextRequestedEventArgs(args);
        }
    }
}