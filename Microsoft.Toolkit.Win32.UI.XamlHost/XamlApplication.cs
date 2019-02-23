// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    /// <summary>
    /// XamlApplication is a custom <see cref="Windows.UI.Xaml.Application" /> that implements <see cref="Windows.UI.Xaml.Markup.IXamlMetadataProvider" />. The
    /// metadata provider implemented on the application is known as the 'root metadata provider'.  This provider
    /// has the responsibility of loading all other metadata for custom UWP XAML types.  In this implementation,
    /// reflection is used at runtime to probe for metadata providers in the working directory, allowing any
    /// type that includes metadata (compiled in to a .NET framework assembly) to be used without explicit
    /// metadata handling by the developer.
    /// </summary>
    partial class XamlApplication : Windows.UI.Xaml.Application, Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XamlApplication"/> class.
        /// </summary>
        public XamlApplication()
        {
            if (_metadataContainer != null)
            {
                throw new InvalidOperationException("Instance already exist");
            }

            _metadataContainer = this;
            this.metadataProviders = new List<Windows.UI.Xaml.Markup.IXamlMetadataProvider>();
            this.windowsXamlManager = Windows.UI.Xaml.Hosting.WindowsXamlManager.InitializeForCurrentThread();
        }

        /// <summary>
        /// Gets XAML <see cref="Windows.UI.Xaml.Markup.IXamlType"/> interface from all cached metadata providers for the <paramref name="type"/>.
        /// </summary>
        /// <param name="type">Type of requested type</param>
        /// <returns>IXamlType interface or null if type is not found</returns>
        public Windows.UI.Xaml.Markup.IXamlType GetXamlType(Type type)
        {
            foreach (var provider in this.MetadataProviders)
            {
                var result = provider.GetXamlType(type);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets XAML IXamlType interface from all cached metadata providers by full type name
        /// </summary>
        /// <param name="fullName">Full name of requested type</param>
        /// <returns><see cref="Windows.UI.Xaml.Markup.IXamlType"/> if found; otherwise, null.</returns>
        public Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            foreach (var provider in this.MetadataProviders)
            {
                var result = provider.GetXamlType(fullName);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets all XAML namespace definitions from metadata providers
        /// </summary>
        /// <returns>Array of namespace definitions</returns>
        public Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            var definitions = new List<Windows.UI.Xaml.Markup.XmlnsDefinition>();
            foreach (var provider in this.MetadataProviders)
            {
                definitions.AddRange(provider.GetXmlnsDefinitions());
            }

            return definitions.ToArray();
        }
    }
}
