// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Data.BindingExpression"/>
    /// </summary>
    public class BindingExpression
    {
        private windows.UI.Xaml.Data.BindingExpression UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingExpression"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Data.BindingExpression"/>
        /// </summary>
        public BindingExpression(windows.UI.Xaml.Data.BindingExpression instance)
        {
            UwpInstance = instance;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Data.BindingExpression.DataItem"/>
        /// </summary>
        public object DataItem
        {
            get => UwpInstance.DataItem;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Data.BindingExpression.ParentBinding"/>
        /// </summary>
        public windows.UI.Xaml.Data.Binding ParentBinding
        {
            get => UwpInstance.ParentBinding;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Data.BindingExpression"/> to <see cref="BindingExpression"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Data.BindingExpression"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator BindingExpression(
            windows.UI.Xaml.Data.BindingExpression args)
        {
            return FromBindingExpression(args);
        }

        /// <summary>
        /// Creates a <see cref="BindingExpression"/> from <see cref="windows.UI.Xaml.Data.BindingExpression"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Data.BindingExpression"/> instance containing the event data.</param>
        /// <returns><see cref="BindingExpression"/></returns>
        public static BindingExpression FromBindingExpression(windows.UI.Xaml.Data.BindingExpression args)
        {
            return new BindingExpression(args);
        }
    }
}