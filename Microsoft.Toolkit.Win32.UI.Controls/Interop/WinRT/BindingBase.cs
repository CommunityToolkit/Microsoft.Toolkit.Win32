// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Data.BindingBase"/>
    /// </summary>
    public class BindingBase
    {
        private windows.UI.Xaml.Data.BindingBase UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingBase"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Data.BindingBase"/>
        /// </summary>
        public BindingBase(windows.UI.Xaml.Data.BindingBase instance)
        {
            UwpInstance = instance;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Data.BindingBase"/> to <see cref="BindingBase"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Data.BindingBase"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator BindingBase(
            windows.UI.Xaml.Data.BindingBase args)
        {
            return FromBindingBase(args);
        }

        /// <summary>
        /// Creates a <see cref="BindingBase"/> from <see cref="windows.UI.Xaml.Data.BindingBase"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Data.BindingBase"/> instance containing the event data.</param>
        /// <returns><see cref="BindingBase"/></returns>
        public static BindingBase FromBindingBase(windows.UI.Xaml.Data.BindingBase args)
        {
            return new BindingBase(args);
        }
    }
}