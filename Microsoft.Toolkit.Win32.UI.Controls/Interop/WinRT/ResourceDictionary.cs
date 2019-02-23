// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.ResourceDictionary"/>
    /// </summary>
    public class ResourceDictionary
    {
        private windows.UI.Xaml.ResourceDictionary UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDictionary"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.ResourceDictionary"/>
        /// </summary>
        public ResourceDictionary(windows.UI.Xaml.ResourceDictionary instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.ResourceDictionary.Source"/>
        /// </summary>
        public System.Uri Source
        {
            get => UwpInstance.Source;
            set => UwpInstance.Source = value;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.ResourceDictionary.MergedDictionaries"/>
        /// </summary>
        public System.Collections.Generic.IList<ResourceDictionary> MergedDictionaries
        {
            get => UwpInstance.MergedDictionaries.Cast<ResourceDictionary>().ToList();
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.ResourceDictionary.ThemeDictionaries"/>
        /// </summary>
        public System.Collections.Generic.IDictionary<object, object> ThemeDictionaries
        {
            get => UwpInstance.ThemeDictionaries;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.ResourceDictionary"/> to <see cref="ResourceDictionary"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.ResourceDictionary"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ResourceDictionary(
            windows.UI.Xaml.ResourceDictionary args)
        {
            return FromResourceDictionary(args);
        }

        /// <summary>
        /// Creates a <see cref="ResourceDictionary"/> from <see cref="windows.UI.Xaml.ResourceDictionary"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.ResourceDictionary"/> instance containing the event data.</param>
        /// <returns><see cref="ResourceDictionary"/></returns>
        public static ResourceDictionary FromResourceDictionary(windows.UI.Xaml.ResourceDictionary args)
        {
            return new ResourceDictionary(args);
        }
    }
}