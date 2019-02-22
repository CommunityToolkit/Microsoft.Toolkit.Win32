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
    partial class XamlApplication : IXamlMetadataContainer
    {
        private static IXamlMetadataContainer _metadataContainer;

        // Metadata provider identified by the root metadata provider
        private readonly List<Windows.UI.Xaml.Markup.IXamlMetadataProvider> metadataProviders;

        /// <summary>
        /// Gets the registered set of <seealso cref="Windows.UI.Xaml.Markup.IXamlMetadataProvider"/>
        /// </summary>
        public List<Windows.UI.Xaml.Markup.IXamlMetadataProvider> MetadataProviders
        {
            get
            {
                return this.metadataProviders;
            }
        }

        /// <summary>
        /// Gets and returns the current UWP XAML Application instance in a reference parameter.
        /// If the current XAML Application instance has not been created for the process (is null),
        /// a new <see cref="Microsoft.Toolkit.Win32.UI.XamlHost.XamlApplication" /> instance is created and returned.
        /// </summary>
        /// <returns>The instance of <seealso cref="XamlApplication"/></returns>
        public static IXamlMetadataContainer GetOrCreateXamlMetadataContainer()
        {
            // Instantiation of the application object must occur before creating the DesktopWindowXamlSource instance.
            // DesktopWindowXamlSource will create a generic Application object unable to load custom UWP XAML metadata.
            if (_metadataContainer == null)
            {
                // Create a custom UWP XAML Application object that implements reflection-based XAML metadata probing.
                try
                {
                    var app = new XamlApplication();
                    app.MetadataProviders.AddRange(MetadataProviderDiscovery.DiscoverMetadataProviders());
                    return app;
                }
                catch
                {
                    _metadataContainer = Windows.UI.Xaml.Application.Current as IXamlMetadataContainer;
                }
            }

            var xamlApplication = _metadataContainer as XamlApplication;
            if (xamlApplication != null && xamlApplication.IsDisposed)
            {
                throw new ObjectDisposedException(typeof(XamlApplication).FullName);
            }

            return _metadataContainer;
        }
    }
}
