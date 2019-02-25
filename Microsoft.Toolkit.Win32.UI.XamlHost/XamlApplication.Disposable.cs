// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using WUX = Windows.UI.Xaml;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    /// <summary>
    /// XamlApplication is a custom <see cref="WUX.Application" /> that implements <see cref="WUX.Markup.IXamlMetadataProvider" />. The
    /// metadata provider implemented on the application is known as the 'root metadata provider'.  This provider
    /// has the responsibility of loading all other metadata for custom UWP XAML types.  In this implementation,
    /// reflection is used at runtime to probe for metadata providers in the working directory, allowing any
    /// type that includes metadata (compiled in to a .NET framework assembly) to be used without explicit
    /// metadata handling by the developer.
    /// </summary>
    partial class XamlApplication : IDisposable
    {
        private readonly WUX.Hosting.WindowsXamlManager _windowsXamlManager;

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
                this._windowsXamlManager.Dispose();
            }

            this.IsDisposed = true;
        }

        /// <summary>
        /// Gets the instance of the <seealso cref="WUX.Hosting.WindowsXamlManager"/>
        /// </summary>
        public WUX.Hosting.WindowsXamlManager WindowsXamlManager
        {
            get
            {
                return this._windowsXamlManager;
            }
        }
    }
}
