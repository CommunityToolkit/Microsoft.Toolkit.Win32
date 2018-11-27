// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Media.GeneralTransform"/>
    /// </summary>
    public class GeneralTransform
    {
        private windows.UI.Xaml.Media.GeneralTransform UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralTransform"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Media.GeneralTransform"/>
        /// </summary>
        public GeneralTransform(windows.UI.Xaml.Media.GeneralTransform instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Media.GeneralTransform.Inverse"/>
        /// </summary>
        public GeneralTransform Inverse
        {
            get => UwpInstance.Inverse;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Media.GeneralTransform"/> to <see cref="GeneralTransform"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Media.GeneralTransform"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator GeneralTransform(
            windows.UI.Xaml.Media.GeneralTransform args)
        {
            return FromGeneralTransform(args);
        }

        /// <summary>
        /// Creates a <see cref="GeneralTransform"/> from <see cref="windows.UI.Xaml.Media.GeneralTransform"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Media.GeneralTransform"/> instance containing the event data.</param>
        /// <returns><see cref="GeneralTransform"/></returns>
        public static GeneralTransform FromGeneralTransform(windows.UI.Xaml.Media.GeneralTransform args)
        {
            return new GeneralTransform(args);
        }
    }
}