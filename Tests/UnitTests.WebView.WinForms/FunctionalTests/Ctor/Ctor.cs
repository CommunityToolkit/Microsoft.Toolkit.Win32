// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using Microsoft.Toolkit.Win32.UI.Controls.Test.WebView.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Threading;

namespace Microsoft.Toolkit.Win32.UI.Controls.Test.WinForms.WebView.FunctionalTests.Ctor
{
    [TestClass]
    public class CreationTests
    {
#if NETCOREAPP
        TestFx.STAExtensions.STAThreadManager _threadManager = new TestFx.STAExtensions.STAThreadManager();
#endif

        [TestMethod]
        [TestCategory(TestConstants.Categories.Init)]
        public void CanInitializeCtorBeginEndInit()
        {
            void Action()
            {
                var wv = new Forms.UI.Controls.WebView();
                ((ISupportInitialize)wv).BeginInit();
                ((ISupportInitialize)wv).EndInit();
            }

#if NETCOREAPP
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                Action();
            }
            else
            {
                _threadManager.Execute(Action);
            }
#else
            Action();
#endif
        }

        [TestMethod]
        [TestCategory(TestConstants.Categories.Init)]
        public void CanInitializeCtorOnly()
        {
            var wv = new Forms.UI.Controls.WebView();
            wv.Process.ShouldBeNull();
        }

        [TestMethod]
        [TestCategory(TestConstants.Categories.Init)]
        public void DesignerPropertyEqualsSettingsProperty()
        {
            void Action()
            {
                var wv = new Forms.UI.Controls.WebView();
                ((ISupportInitialize)wv).BeginInit();
                wv.IsScriptNotifyAllowed = !wv.IsScriptNotifyAllowed;
                ((ISupportInitialize)wv).EndInit();

                wv.IsScriptNotifyAllowed.ShouldEqual(wv.Settings.IsScriptNotifyAllowed);
            }

#if NETCOREAPP
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                Action();
            }
            else
            {
                _threadManager.Execute(Action);
            }
#else
            Action();
#endif
        }
    }
}
