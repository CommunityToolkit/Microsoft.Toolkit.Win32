// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Media.RectangleGeometry"/>
    /// </summary>
    public class RectangleGeometry
    {
        private windows.UI.Xaml.Media.RectangleGeometry UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleGeometry"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Media.RectangleGeometry"/>
        /// </summary>
        public RectangleGeometry(windows.UI.Xaml.Media.RectangleGeometry instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Media.RectangleGeometry.Rect"/>
        /// </summary>
        public windows.Foundation.Rect Rect
        {
            get => UwpInstance.Rect;
            set => UwpInstance.Rect = value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Media.RectangleGeometry"/> to <see cref="RectangleGeometry"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Media.RectangleGeometry"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator RectangleGeometry(
            windows.UI.Xaml.Media.RectangleGeometry args)
        {
            return FromRectangleGeometry(args);
        }

        /// <summary>
        /// Creates a <see cref="RectangleGeometry"/> from <see cref="windows.UI.Xaml.Media.RectangleGeometry"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Media.RectangleGeometry"/> instance containing the event data.</param>
        /// <returns><see cref="RectangleGeometry"/></returns>
        public static RectangleGeometry FromRectangleGeometry(windows.UI.Xaml.Media.RectangleGeometry args)
        {
            return new RectangleGeometry(args);
        }
    }
}