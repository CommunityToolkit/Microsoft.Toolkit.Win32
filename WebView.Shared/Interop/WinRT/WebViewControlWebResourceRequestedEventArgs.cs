// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security;
using Windows.Web.Http;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// CProvides data for the <see cref="IWebView.WebResourceRequested" /> event. This class cannot be inherited.
    /// </summary>
    /// <remarks>Copy from <see cref="windows.Web.UI.WebViewControlWebResourceRequestedEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="System.EventArgs" />
    /// <seealso cref="windows.Web.UI.WebViewControlWebResourceRequestedEventArgs"/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "WebResourceRequested", Justification = "Same as WinRT type")]
    public sealed class WebViewControlWebResourceRequestedEventArgs : EventArgs
    {
        [SecurityCritical]
        private readonly windows.Web.UI.WebViewControlWebResourceRequestedEventArgs _args;

        internal WebViewControlWebResourceRequestedEventArgs(windows.Web.UI.WebViewControlWebResourceRequestedEventArgs args)
        {
            _args = args ?? throw new ArgumentNullException(nameof(args));
        }

        /// <summary>
        /// Gets gets or sets the HTTP response that will be sent to the Windows.Web.UI.IWebViewControl
        /// </summary>
        /// <value>The response.</value>
        public HttpResponseMessage Response => _args.Response;

        /// <summary>
        /// Gets a Deferral.
        /// </summary>
        /// <returns><seealso cref="windows.Foundation.Deferral"/></returns>
        public windows.Foundation.Deferral GetDeferral() => _args.GetDeferral();

        /// <summary>
        /// Gets the intercepted HTTP request.
        /// </summary>
        /// <value>The request.</value>
        public HttpRequestMessage Request => _args.Request;

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.Web.UI.WebViewControlWebResourceRequestedEventArgs"/> to <see cref="WebViewControlWebResourceRequestedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Web.UI.WebViewControlWebResourceRequestedEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator WebViewControlWebResourceRequestedEventArgs(windows.Web.UI.WebViewControlWebResourceRequestedEventArgs args) => ToWebViewControlWebResourceRequestedEventArgs(args);

        /// <summary>
        /// Creates a <see cref="WebViewControlWebResourceRequestedEventArgs"/> from <see cref="windows.Web.UI.WebViewControlWebResourceRequestedEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Web.UI.WebViewControlWebResourceRequestedEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="WebViewControlWebResourceRequestedEventArgs"/></returns>
        public static WebViewControlWebResourceRequestedEventArgs
            ToWebViewControlWebResourceRequestedEventArgs(
                windows.Web.UI.WebViewControlWebResourceRequestedEventArgs args) =>
            new WebViewControlWebResourceRequestedEventArgs(args);
    }
}
