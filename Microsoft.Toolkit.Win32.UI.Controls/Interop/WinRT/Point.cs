// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="Point"/>
    /// </summary>
    public struct Point : IFormattable, IEquatable<Point>
    {
        internal windows.Foundation.Point UwpInstance { get; set; }

        public Point(double x, double y)
        {
            UwpInstance = new windows.Foundation.Point(x, y);
        }

        internal Point(windows.Foundation.Point instance)
        {
            UwpInstance = instance;
        }

        /// <summary>
        /// Gets or sets X
        /// </summary>
        public double X
        {
            get => UwpInstance.X;
            set => UwpInstance = new windows.Foundation.Point(value, Y);
        }

        /// <summary>
        /// Gets or sets Y
        /// </summary>
        public double Y
        {
            get => UwpInstance.Y;
            set => UwpInstance = new windows.Foundation.Point(X, value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.Devices.Geolocation.BasicGeoposition"/> to <see cref="BasicGeoposition"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Devices.Geolocation.BasicGeoposition"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Point(windows.Foundation.Point args)
        {
            return FromPoint(args);
        }

        /// <summary>
        /// Creates a <see cref="BasicGeoposition"/> from <see cref="windows.Devices.Geolocation.BasicGeoposition"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Devices.Geolocation.BasicGeoposition"/> instance containing the event data.</param>
        /// <returns><see cref="BasicGeoposition"/></returns>
        public static Point FromPoint(windows.Foundation.Point args)
        {
            return new Point(args);
        }

        public bool Equals(Point point) => UwpInstance.Equals(point.UwpInstance);

        public override int GetHashCode()
        {
            return UwpInstance.GetHashCode();
        }

        public override string ToString()
        {
#pragma warning disable CA1305 // Specify IFormatProvider
            return UwpInstance.ToString();
#pragma warning restore CA1305 // Specify IFormatProvider
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return UwpInstance.ToString(formatProvider);
        }

        public override bool Equals(object obj)
        {
            return UwpInstance.Equals(obj);
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.UwpInstance == point2.UwpInstance;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return point1.UwpInstance != point2.UwpInstance;
        }
    }
}