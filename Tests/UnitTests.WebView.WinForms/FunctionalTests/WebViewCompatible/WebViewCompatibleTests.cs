// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Toolkit.Win32.UI.Controls.Test.WebView.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Security.Principal;

namespace Microsoft.Toolkit.Win32.UI.Controls.Test.WinForms.WebView.FunctionalTests.WebViewCompatible
{
    [TestClass]
    public class WebViewCompatibleTests: ContextSpecification
    {
        Forms.UI.Controls.WebViewCompatible WebView;

        protected override void Given()
        {
            WebView = new Forms.UI.Controls.WebViewCompatible();
        }

        [TestMethod]
        public void WebViewCompatibleShouldBeLegacyIfRunningAsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if(principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                WebView.IsLegacy.ShouldBeTrue();
            }
            else
            {
                Assert.Inconclusive("This test needs to be run as administrator");
            }
        }
    }
}
