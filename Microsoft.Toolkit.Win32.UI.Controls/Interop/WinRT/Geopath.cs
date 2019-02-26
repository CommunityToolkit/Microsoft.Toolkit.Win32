// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.Devices.Geolocation.Geopath"/>
    /// </summary>
    public class Geopath
    {
        private windows.Devices.Geolocation.Geopath UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Geopath"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.Devices.Geolocation.Geopath"/>
        /// </summary>
        public Geopath(windows.Devices.Geolocation.Geopath instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Gets <see cref="windows.Devices.Geolocation.Geopath.Positions"/>
        /// </summary>
        public System.Collections.Generic.IReadOnlyList<windows.Devices.Geolocation.BasicGeoposition> Positions
        {
            get => UwpInstance.Positions;
        }

        /// <summary>
        /// Gets <see cref="windows.Devices.Geolocation.Geopath.AltitudeReferenceSystem"/>
        /// </summary>
        public Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.AltitudeReferenceSystem AltitudeReferenceSystem
        {
            get => (Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.AltitudeReferenceSystem)(int)UwpInstance.AltitudeReferenceSystem;
        }

        /// <summary>
        /// Gets <see cref="windows.Devices.Geolocation.Geopath.GeoshapeType"/>
        /// </summary>
        public windows.Devices.Geolocation.GeoshapeType GeoshapeType
        {
            get => UwpInstance.GeoshapeType;
        }

        /// <summary>
        /// Gets <see cref="windows.Devices.Geolocation.Geopath.SpatialReferenceId"/>
        /// </summary>
        public uint SpatialReferenceId
        {
            get => UwpInstance.SpatialReferenceId;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.Devices.Geolocation.Geopath"/> to <see cref="Geopath"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Devices.Geolocation.Geopath"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Geopath(
            windows.Devices.Geolocation.Geopath args)
        {
            return FromGeopath(args);
        }

        /// <summary>
        /// Creates a <see cref="Geopath"/> from <see cref="windows.Devices.Geolocation.Geopath"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Devices.Geolocation.Geopath"/> instance containing the event data.</param>
        /// <returns><see cref="Geopath"/></returns>
        public static Geopath FromGeopath(windows.Devices.Geolocation.Geopath args)
        {
            return new Geopath(args);
        }
    }
}