// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Media.ImageSource"/>
    /// </summary>
    public class ImageSource
    {
        internal windows.UI.Xaml.Media.ImageSource UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSource"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Media.ImageSource"/>
        /// </summary>
        public ImageSource(windows.UI.Xaml.Media.ImageSource instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Media.ImageSource"/> to <see cref="ImageSource"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Media.ImageSource"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ImageSource(
            windows.UI.Xaml.Media.ImageSource args)
        {
            return FromImageSource(args);
        }

        /// <summary>
        /// Creates a <see cref="ImageSource"/> from <see cref="windows.UI.Xaml.Media.ImageSource"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Media.ImageSource"/> instance containing the event data.</param>
        /// <returns><see cref="ImageSource"/></returns>
        public static ImageSource FromImageSource(windows.UI.Xaml.Media.ImageSource args)
        {
            return new ImageSource(args);
        }
    }
}