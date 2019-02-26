// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Text.FontWeight"/>
    /// </summary>
    public class FontWeight
    {
        private windows.UI.Text.FontWeight UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FontWeight"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Text.FontWeight"/>
        /// </summary>
        public FontWeight(windows.UI.Text.FontWeight instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Text.FontWeight"/> to <see cref="FontWeight"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Text.FontWeight"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator FontWeight(
            windows.UI.Text.FontWeight args)
        {
            return FromFontWeight(args);
        }

        /// <summary>
        /// Creates a <see cref="FontWeight"/> from <see cref="windows.UI.Text.FontWeight"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Text.FontWeight"/> instance containing the event data.</param>
        /// <returns><see cref="FontWeight"/></returns>
        public static FontWeight FromFontWeight(windows.UI.Text.FontWeight args)
        {
            return new FontWeight(args);
        }
    }
}