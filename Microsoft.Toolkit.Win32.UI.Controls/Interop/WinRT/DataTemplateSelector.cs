// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Controls.DataTemplateSelector"/>
    /// </summary>
    public class DataTemplateSelector
    {
        private windows.UI.Xaml.Controls.DataTemplateSelector UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTemplateSelector"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.DataTemplateSelector"/>
        /// </summary>
        public DataTemplateSelector(windows.UI.Xaml.Controls.DataTemplateSelector instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.DataTemplateSelector"/> to <see cref="DataTemplateSelector"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.DataTemplateSelector"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DataTemplateSelector(
            windows.UI.Xaml.Controls.DataTemplateSelector args)
        {
            return FromDataTemplateSelector(args);
        }

        /// <summary>
        /// Creates a <see cref="DataTemplateSelector"/> from <see cref="windows.UI.Xaml.Controls.DataTemplateSelector"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.DataTemplateSelector"/> instance containing the event data.</param>
        /// <returns><see cref="DataTemplateSelector"/></returns>
        public static DataTemplateSelector FromDataTemplateSelector(windows.UI.Xaml.Controls.DataTemplateSelector args)
        {
            return new DataTemplateSelector(args);
        }
    }
}