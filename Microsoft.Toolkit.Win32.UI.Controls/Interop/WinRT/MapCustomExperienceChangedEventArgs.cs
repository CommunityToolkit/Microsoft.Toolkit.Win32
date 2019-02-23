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
    /// <remarks>Copy from <see cref="windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs"/>
    public sealed class MapCustomExperienceChangedEventArgs : EventArgs
    {
        private readonly windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs _args;

        internal MapCustomExperienceChangedEventArgs(windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs args)
        {
            _args = args;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs"/> to <see cref="Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.MapCustomExperienceChangedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator MapCustomExperienceChangedEventArgs(
            windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs args)
        {
            return FromMapCustomExperienceChangedEventArgs(args);
        }

        /// <summary>
        /// Creates a <see cref="MapCustomExperienceChangedEventArgs"/> from <see cref="windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="MapCustomExperienceChangedEventArgs"/></returns>
        public static MapCustomExperienceChangedEventArgs FromMapCustomExperienceChangedEventArgs(windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs args)
        {
            return new MapCustomExperienceChangedEventArgs(args);
        }
    }
}