// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.Devices.Geolocation.BasicGeoposition"/>
    /// </summary>
    public struct BasicGeoposition
    {
#pragma warning disable CA1051 // Do not declare visible instance fields
        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude;

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude;

        /// <summary>
        /// Altitude
        /// </summary>
        public double Altitude;
#pragma warning restore CA1051 // Do not declare visible instance fields

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.Devices.Geolocation.BasicGeoposition"/> to <see cref="BasicGeoposition"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Devices.Geolocation.BasicGeoposition"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator BasicGeoposition(
            windows.Devices.Geolocation.BasicGeoposition args)
        {
            return FromBasicGeoposition(args);
        }

        /// <summary>
        /// Creates a <see cref="BasicGeoposition"/> from <see cref="windows.Devices.Geolocation.BasicGeoposition"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Devices.Geolocation.BasicGeoposition"/> instance containing the event data.</param>
        /// <returns><see cref="BasicGeoposition"/></returns>
        public static BasicGeoposition FromBasicGeoposition(windows.Devices.Geolocation.BasicGeoposition args)
        {
            return new BasicGeoposition() { Latitude = args.Latitude, Longitude = args.Longitude, Altitude = args.Altitude };
        }
    }
}