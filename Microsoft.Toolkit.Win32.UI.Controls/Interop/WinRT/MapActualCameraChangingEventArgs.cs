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
    /// <remarks>Copy from <see cref="windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs"/>
    public sealed class MapActualCameraChangingEventArgs : EventArgs
    {
        private readonly windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs _args;

        internal MapActualCameraChangingEventArgs(windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs args)
        {
            _args = args;
        }

        public windows.UI.Xaml.Controls.Maps.MapCamera Camera
        {
            get => (windows.UI.Xaml.Controls.Maps.MapCamera)_args.Camera;
        }

        public windows.UI.Xaml.Controls.Maps.MapCameraChangeReason ChangeReason
        {
            get => (windows.UI.Xaml.Controls.Maps.MapCameraChangeReason)_args.ChangeReason;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs"/> to <see cref="Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapActualCameraChangingEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MapActualCameraChangingEventArgs(
            windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs args)
        {
            return FromMapActualCameraChangingEventArgs(args);
        }

        /// <summary>
        /// Creates a <see cref="MapActualCameraChangingEventArgs"/> from <see cref="windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="MapActualCameraChangingEventArgs"/></returns>
        public static MapActualCameraChangingEventArgs FromMapActualCameraChangingEventArgs(windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs args)
        {
            return new MapActualCameraChangingEventArgs(args);
        }
    }
}