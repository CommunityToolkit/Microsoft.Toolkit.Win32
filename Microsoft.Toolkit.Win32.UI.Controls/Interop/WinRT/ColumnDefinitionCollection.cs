// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Controls.ColumnDefinitionCollection"/>
    /// </summary>
    public class ColumnDefinitionCollection
    {
        private windows.UI.Xaml.Controls.ColumnDefinitionCollection UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnDefinitionCollection"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.ColumnDefinitionCollection"/>
        /// </summary>
        public ColumnDefinitionCollection(windows.UI.Xaml.Controls.ColumnDefinitionCollection instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.ColumnDefinitionCollection"/> to <see cref="ColumnDefinitionCollection"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.ColumnDefinitionCollection"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ColumnDefinitionCollection(
            windows.UI.Xaml.Controls.ColumnDefinitionCollection args)
        {
            return FromColumnDefinitionCollection(args);
        }

        /// <summary>
        /// Creates a <see cref="ColumnDefinitionCollection"/> from <see cref="windows.UI.Xaml.Controls.ColumnDefinitionCollection"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.ColumnDefinitionCollection"/> instance containing the event data.</param>
        /// <returns><see cref="ColumnDefinitionCollection"/></returns>
        public static ColumnDefinitionCollection FromColumnDefinitionCollection(windows.UI.Xaml.Controls.ColumnDefinitionCollection args)
        {
            return new ColumnDefinitionCollection(args);
        }
    }
}