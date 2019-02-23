// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.DependencyPropertyChangedCallback"/>
    /// </summary>
    public class DependencyPropertyChangedCallback
    {
        private windows.UI.Xaml.DependencyPropertyChangedCallback UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyPropertyChangedCallback"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.DependencyPropertyChangedCallback"/>
        /// </summary>
        public DependencyPropertyChangedCallback(windows.UI.Xaml.DependencyPropertyChangedCallback instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.DependencyPropertyChangedCallback"/> to <see cref="DependencyPropertyChangedCallback"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.DependencyPropertyChangedCallback"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator DependencyPropertyChangedCallback(
            windows.UI.Xaml.DependencyPropertyChangedCallback args)
        {
            return FromDependencyPropertyChangedCallback(args);
        }

        /// <summary>
        /// Creates a <see cref="DependencyPropertyChangedCallback"/> from <see cref="windows.UI.Xaml.DependencyPropertyChangedCallback"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.DependencyPropertyChangedCallback"/> instance containing the event data.</param>
        /// <returns><see cref="DependencyPropertyChangedCallback"/></returns>
        public static DependencyPropertyChangedCallback FromDependencyPropertyChangedCallback(windows.UI.Xaml.DependencyPropertyChangedCallback args)
        {
            return new DependencyPropertyChangedCallback(args);
        }
    }
}