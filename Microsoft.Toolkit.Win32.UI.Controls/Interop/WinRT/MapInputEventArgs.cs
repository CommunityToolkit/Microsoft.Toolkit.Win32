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
    /// <remarks>Copy from <see cref="windows.UI.Xaml.Controls.Maps.MapInputEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="windows.UI.Xaml.Controls.Maps.MapInputEventArgs"/>
    public sealed class MapInputEventArgs : EventArgs
    {
        private readonly windows.UI.Xaml.Controls.Maps.MapInputEventArgs _args;

        internal MapInputEventArgs(windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            _args = args;
        }

        public windows.Devices.Geolocation.Geopoint Location
        {
            get => (windows.Devices.Geolocation.Geopoint)_args.Location;
        }

        public windows.Foundation.Point Position
        {
            get => (windows.Foundation.Point)_args.Position;
        }

        public windows.UI.Core.CoreDispatcher Dispatcher
        {
            get => (windows.UI.Core.CoreDispatcher)_args.Dispatcher;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.Maps.MapInputEventArgs"/> to <see cref="Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapInputEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapInputEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MapInputEventArgs(
            windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            return FromMapInputEventArgs(args);
        }

        /// <summary>
        /// Creates a <see cref="MapInputEventArgs"/> from <see cref="windows.UI.Xaml.Controls.Maps.MapInputEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapInputEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="MapInputEventArgs"/></returns>
        public static MapInputEventArgs FromMapInputEventArgs(windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            return new MapInputEventArgs(args);
        }
    }
}