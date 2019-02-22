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
    partial class XamlApplication : IDisposable
    {
        private static Windows.UI.Xaml.Application _application;
        private readonly Windows.UI.Xaml.Hosting.WindowsXamlManager windowsXamlManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="XamlApplication"/> class.
        /// </summary>
        public XamlApplication()
        {
            if (_application != null)
            {
                throw new InvalidOperationException("Instance already exist");
            }

            _application = this;
            this.windowsXamlManager = Windows.UI.Xaml.Hosting.WindowsXamlManager.InitializeForCurrentThread();
        }

        /// <summary>
        /// Gets a value indicating whether the instance has already been disposed
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Disposes the instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Called when the instance is getting finalized or disposed.
        /// </summary>
        /// <param name="disposing">True when disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                this.windowsXamlManager.Dispose();
            }

            this.IsDisposed = true;
        }

        /// <summary>
        /// Gets the instance of the <seealso cref="Windows.UI.Xaml.Hosting.WindowsXamlManager"/>
        /// </summary>
        public Windows.UI.Xaml.Hosting.WindowsXamlManager WindowsXamlManager
        {
            get
            {
                return this.windowsXamlManager;
            }
        }

        /// <summary>
        /// Gets and returns the current UWP XAML Application instance in a reference parameter.
        /// If the current XAML Application instance has not been created for the process (is null),
        /// a new <see cref="Microsoft.Toolkit.Win32.UI.XamlHost.XamlApplication" /> instance is created and returned.
        /// </summary>
        /// <returns>The instance of <seealso cref="XamlApplication"/></returns>
        public static Windows.UI.Xaml.Application GetOrCreateXamlApplicationInstance()
        {
            // Instantiation of the application object must occur before creating the DesktopWindowXamlSource instance.
            // DesktopWindowXamlSource will create a generic Application object unable to load custom UWP XAML metadata.
            if (_application == null)
            {
                // Create a custom UWP XAML Application object that implements reflection-based XAML metadata probing.
                try
                {
                    return new XamlApplication();
                }
                catch
                {
                    _application = Windows.UI.Xaml.Application.Current;
                }
            }

            var xamlApplication = _application as XamlApplication;
            if (xamlApplication != null && xamlApplication.IsDisposed)
            {
                throw new ObjectDisposedException(typeof(XamlApplication).FullName);
            }

            return _application;
        }
    }
}
