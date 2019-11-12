// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Toolkit.Win32.UI.XamlHost;
using Windows.Foundation.Metadata;
using WUX = Windows.UI.Xaml;

namespace Microsoft.Toolkit.Forms.UI.XamlHost
{
    /// <summary>
    ///     WindowsXamlHostBase hosts UWP XAML content inside Windows Forms
    /// </summary>
    [System.ComponentModel.DesignerCategory("code")]
    public abstract partial class WindowsXamlHostBase : ContainerControl
    {
        /// <summary>
        /// An instance of <seealso cref="IXamlMetadataContainer"/>. Required to
        /// probe at runtime for custom UWP XAML type information.
        /// This must be implemented by the instance of <seealso cref="WUX.Application"/>
        /// </summary>
        /// <remarks>
        /// <seealso cref="WUX.Application"/> object is required for loading custom control metadata.  If a custom
        /// Application object is not provided by the application, the host control will create an instance of <seealso cref="XamlApplication"/>.
        /// Instantiation of the application object must occur before creating the DesktopWindowXamlSource instance.
        /// If no Application object is created before DesktopWindowXamlSource is created, DestkopWindowXamlSource
        /// will create an instance of <seealso cref="XamlApplication"/> that implements <seealso cref="IXamlMetadataContainer"/>.
        /// </remarks>
        private static readonly IXamlMetadataContainer _metadataContainer;

        static WindowsXamlHostBase()
        {
            _metadataContainer = XamlApplicationExtensions.GetOrCreateXamlMetadataContainer();
        }

        /// <summary>
        /// DesktopWindowXamlSource instance
        /// </summary>
        private readonly WUX.Hosting.DesktopWindowXamlSource _xamlSource;

        /// <summary>
        /// Gets the current instance of <seealso cref="XamlApplication"/>
        /// </summary>
        protected static IXamlMetadataContainer MetadataContainer
        {
            get
            {
                return _metadataContainer;
            }
        }

        /// <summary>
        /// Private field that backs ChildInternal property.
        /// </summary>
        private WUX.UIElement _childInternal;

        /// <summary>
        ///    Last preferredSize returned by UWP XAML during WinForms layout pass
        /// </summary>
        private Size _lastXamlContentPreferredSize;

        /// <summary>
        ///    UWP XAML island window handle associated with this Control instance
        /// </summary>
        private IntPtr _xamlIslandWindowHandle = IntPtr.Zero;

        /// <summary>
        ///    The last dpi value retrieved from the system
        /// </summary>
        private double _lastDpi = 96.0f;

        /// <summary>
        ///     Fired when XAML content has been updated
        /// </summary>
        [Browsable(true)]
        [Category("UWP XAML")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Fired when UWP XAML content has been updated")]
        public event EventHandler ChildChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsXamlHostBase"/> class.
        /// </summary>
        public WindowsXamlHostBase()
        {
            // Return immediately if control is instantiated by the Visual Studio Designer
            // https://stackoverflow.com/questions/1166226/detecting-design-mode-from-a-controls-constructor
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            // Must be a container control with TabStop == false to allow nested UWP XAML Focus
            // BUGBUG: Uncomment when nested Focus is available
            // TabStop = false;

            // Respond to size changes on this Control
            SizeChanged += OnWindowXamlHostSizeChanged;

            // Create DesktopWindowXamlSource, host for UWP XAML content
            _xamlSource = new WUX.Hosting.DesktopWindowXamlSource();

            // Hook up method for DesktopWindowXamlSource Focus handling
            _xamlSource.TakeFocusRequested += this.OnTakeFocusRequested;
        }

        protected WindowsXamlHostBase(string typeName)
            : this()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                ChildInternal = UWPTypeFactory.CreateXamlContentByType(typeName);
                ChildInternal.SetWrapper(this);
            }
        }

        /// <summary>
        /// Exposes ChildInternal without exposing its actual Type.
        /// </summary>
        /// <returns>the underlying UWP child object</returns>
        public object GetUwpInternalObject()
        {
            return ChildInternal;
        }

        /// <summary>
        ///    Gets or sets XAML content for XamlContentHost
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected WUX.UIElement ChildInternal
        {
            get => _childInternal;

            set
            {
                if (!DesignMode)
                {
                    if (value == ChildInternal)
                    {
                        return;
                    }

                    var newFrameworkElement = value as WUX.FrameworkElement;
                    var oldFrameworkElement = ChildInternal as WUX.FrameworkElement;

                    if (oldFrameworkElement != null)
                    {
                        oldFrameworkElement.SizeChanged -= OnChildSizeChanged;
                    }

                    _childInternal = value;
                    SetContent(value);

                    if (newFrameworkElement != null)
                    {
                        // If XAML content has changed, check XAML size and WindowsXamlHost.AutoSize
                        // setting to determine if WindowsXamlHost needs to re-run layout.
                        newFrameworkElement.SizeChanged += OnChildSizeChanged;
                    }

                    PerformLayout();

                    ChildChanged?.Invoke(this, new EventArgs());
                }
                else
                {
                    _childInternal = value;
                }
            }
        }

        /// <summary>
        /// Sets the root UWP XAML element on DesktopWindowXamlSource
        /// </summary>
        /// <param name="newValue">A UWP XAML Framework element</param>
        protected virtual void SetContent(WUX.UIElement newValue)
        {
            if (_xamlSource != null)
            {
                _xamlSource.Content = newValue;
            }
        }

        /// <summary>
        /// Clean up hosted UWP XAML content
        /// </summary>
        /// <param name="disposing">IsDisposing?</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SizeChanged -= OnWindowXamlHostSizeChanged;

                var oldFrameworkElement = ChildInternal as WUX.FrameworkElement;
                if (oldFrameworkElement != null)
                {
                    oldFrameworkElement.SizeChanged -= OnChildSizeChanged;
                }

                ChildInternal?.ClearWrapper();

                this._childInternal = null;

                // Required by CA2213: _xamlSource?.Dispose() is insufficient.
                if (_xamlSource != null)
                {
                    _xamlSource.TakeFocusRequested -= OnTakeFocusRequested;
                    _xamlSource.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Raises the HandleCreated event.  Assign window render target to UWP XAML content.
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!DesignMode)
            {
                // Attach window to DesktopWindowXamSource as a render target
                var desktopWindowXamlSourceNative = _xamlSource.GetInterop<IDesktopWindowXamlSourceNative>();
                desktopWindowXamlSourceNative.AttachToWindow(Handle);
                _xamlIslandWindowHandle = desktopWindowXamlSourceNative.WindowHandle;

                // Set window style required by container control to support Focus
                if (Interop.Win32.UnsafeNativeMethods.SetWindowLong(Handle, Interop.Win32.NativeDefines.GWL_EXSTYLE, Interop.Win32.NativeDefines.WS_EX_CONTROLPARENT) == 0)
                {
                    throw new InvalidOperationException("WindowsXamlHostBase::OnHandleCreated: Failed to set WS_EX_CONTROLPARENT on control window.");
                }

                if (ChildInternal != null)
                {
                    SetContent(ChildInternal);
                    ChildInternal.SetWrapper(this);
                }

                UpdateDpiScalingFactor();
            }
        }

        /// <summary>
        /// Override that disposes the current instance when the parent handle has been destroyed
        /// </summary>
        /// <param name="e">Ignored</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            this.Dispose(true);
            base.OnHandleDestroyed(e);
        }
    }
}
