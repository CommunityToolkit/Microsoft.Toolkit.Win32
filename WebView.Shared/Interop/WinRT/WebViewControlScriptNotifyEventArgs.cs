// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Security;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// Provides data for the <see cref="IWebView.ScriptNotify"/> event. This class cannot be inherited.
    /// </summary>
    /// <remarks>Copy from <see cref="windows.Web.UI.WebViewControlScriptNotifyEventArgs"/> to avoid requirement to link Windows.winmd</remarks>
    /// <seealso cref="System.EventArgs" />
    /// <seealso cref="windows.Web.UI.WebViewControlScriptNotifyEventArgs"/>
    public sealed class WebViewControlScriptNotifyEventArgs : EventArgs
    {
        [SecurityCritical]
        private readonly windows.Web.UI.WebViewControlScriptNotifyEventArgs _args;

        internal WebViewControlScriptNotifyEventArgs(windows.Web.UI.WebViewControlScriptNotifyEventArgs args)
        {
            _args = args;
        }

        /// <summary>
        /// Gets the Uniform Resource Identifier (URI) that originated the <see cref="IWebView.ScriptNotify"/> event.
        /// </summary>
        /// <value>The Uniform Resource Identifier (URI).</value>
        public Uri Uri => _args.Uri;

        /// <summary>
        /// Gets the string value passed to the app.
        /// </summary>
        /// <value>The string value passed to the app.</value>
        public string Value => _args.Value;

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.Web.UI.WebViewControlScriptNotifyEventArgs"/> to <see cref="WebViewControlScriptNotifyEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Web.UI.WebViewControlScriptNotifyEventArgs"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator WebViewControlScriptNotifyEventArgs(windows.Web.UI.WebViewControlScriptNotifyEventArgs args) => ToWebViewControlScriptNotifyEventArgs(args);

        /// <summary>
        /// Creates a <see cref="WebViewControlScriptNotifyEventArgs"/> from <see cref="windows.Web.UI.WebViewControlScriptNotifyEventArgs"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.Web.UI.WebViewControlScriptNotifyEventArgs"/> instance containing the event data.</param>
        /// <returns><see cref="WebViewControlScriptNotifyEventArgs"/></returns>
        public static WebViewControlScriptNotifyEventArgs ToWebViewControlScriptNotifyEventArgs(
            windows.Web.UI.WebViewControlScriptNotifyEventArgs args) => new WebViewControlScriptNotifyEventArgs(args);
    }
}