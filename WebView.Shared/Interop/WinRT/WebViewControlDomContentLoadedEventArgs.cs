// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// Provides data for the <see cref="IWebView.DOMContentLoaded"/> and <see cref="IWebView.FrameDOMContentLoaded"/> events. This class cannot be inherited.
    /// </summary>
    /// <remarks>Copy from <see cref="windows.Web.UI.WebViewControlDOMContentLoadedEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="windows.Web.UI.WebViewControlDOMContentLoadedEventArgs"/>
    /// <seealso cref="EventArgs"/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Naming",
        "CA1709:IdentifiersShouldBeCasedCorrectly",
        MessageId = "DOM",
        Justification = "Maintain consistency with WinRT type name")]
    public sealed class WebViewControlDOMContentLoadedEventArgs : EventArgs
    {
        [SecurityCritical]
        internal WebViewControlDOMContentLoadedEventArgs(windows.Web.UI.WebViewControlDOMContentLoadedEventArgs args)
        {
            Uri = args.Uri;
        }

        internal WebViewControlDOMContentLoadedEventArgs(Uri uri)
        {
            Uri = uri;
        }

        /// <summary>
        /// Gets the Uniform Resource Identifier (URI) of the content the <see cref="IWebView"/> is loading.
        /// </summary>
        /// <value>The Uniform Resource Identifier (URI) of the content the <see cref="IWebView"/> is loading.</value>
        public Uri Uri { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.Web.UI.WebViewControlDOMContentLoadedEventArgs"/> to <see cref="WebViewControlDOMContentLoadedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Web.UI.WebViewControlDOMContentLoadedEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator WebViewControlDOMContentLoadedEventArgs(windows.Web.UI.WebViewControlDOMContentLoadedEventArgs args) => FromWebViewControlDOMContentLoadedEventArgs(args);

        /// <summary>
        /// Creates a <see cref="WebViewControlDOMContentLoadedEventArgs"/> from <see cref="windows.Web.UI.WebViewControlDOMContentLoadedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Web.UI.WebViewControlDOMContentLoadedEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="WebViewControlDOMContentLoadedEventArgs"/>.</returns>
        public static WebViewControlDOMContentLoadedEventArgs FromWebViewControlDOMContentLoadedEventArgs(
            windows.Web.UI.WebViewControlDOMContentLoadedEventArgs args) =>
            new WebViewControlDOMContentLoadedEventArgs(args);
    }
}