// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Controls.InkToolbarCustomPen"/>
    /// </summary>
    public class InkToolbarCustomPen
    {
        internal windows.UI.Xaml.Controls.InkToolbarCustomPen UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InkToolbarCustomPen"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.InkToolbarCustomPen"/>
        /// </summary>
        public InkToolbarCustomPen(windows.UI.Xaml.Controls.InkToolbarCustomPen instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.InkToolbarCustomPen"/> to <see cref="InkToolbarCustomPen"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.InkToolbarCustomPen"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator InkToolbarCustomPen(
            windows.UI.Xaml.Controls.InkToolbarCustomPen args)
        {
            return FromInkToolbarCustomPen(args);
        }

        /// <summary>
        /// Creates a <see cref="InkToolbarCustomPen"/> from <see cref="windows.UI.Xaml.Controls.InkToolbarCustomPen"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.InkToolbarCustomPen"/> instance containing the event data.</param>
        /// <returns><see cref="InkToolbarCustomPen"/></returns>
        public static InkToolbarCustomPen FromInkToolbarCustomPen(windows.UI.Xaml.Controls.InkToolbarCustomPen args)
        {
            return new InkToolbarCustomPen(args);
        }
    }
}