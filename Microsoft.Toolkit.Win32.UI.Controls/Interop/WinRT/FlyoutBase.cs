// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase"/>
    /// </summary>
    public class FlyoutBase
    {
        private windows.UI.Xaml.Controls.Primitives.FlyoutBase UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlyoutBase"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase"/>
        /// </summary>
        public FlyoutBase(windows.UI.Xaml.Controls.Primitives.FlyoutBase instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.Placement"/>
        /// </summary>
        public windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode Placement
        {
            get => UwpInstance.Placement;
            set => UwpInstance.Placement = value;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.LightDismissOverlayMode"/>
        /// </summary>
        public windows.UI.Xaml.Controls.LightDismissOverlayMode LightDismissOverlayMode
        {
            get => UwpInstance.LightDismissOverlayMode;
            set => UwpInstance.LightDismissOverlayMode = value;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.ElementSoundMode"/>
        /// </summary>
        public ElementSoundMode ElementSoundMode
        {
            get => (ElementSoundMode)(int)UwpInstance.ElementSoundMode;
            set => UwpInstance.ElementSoundMode = (windows.UI.Xaml.ElementSoundMode)(int)value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.AllowFocusWhenDisabled"/>
        /// </summary>
        public bool AllowFocusWhenDisabled
        {
            get => UwpInstance.AllowFocusWhenDisabled;
            set => UwpInstance.AllowFocusWhenDisabled = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.AllowFocusOnInteraction"/>
        /// </summary>
        public bool AllowFocusOnInteraction
        {
            get => UwpInstance.AllowFocusOnInteraction;
            set => UwpInstance.AllowFocusOnInteraction = value;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.Target"/>
        /// </summary>
        public windows.UI.Xaml.FrameworkElement Target
        {
            get => UwpInstance.Target;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.OverlayInputPassThroughElement"/>
        /// </summary>
        public windows.UI.Xaml.DependencyObject OverlayInputPassThroughElement
        {
            get => UwpInstance.OverlayInputPassThroughElement;
            set => UwpInstance.OverlayInputPassThroughElement = value;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.ShowMode"/>
        /// </summary>
        public windows.UI.Xaml.Controls.Primitives.FlyoutShowMode ShowMode
        {
            get => UwpInstance.ShowMode;
            set => UwpInstance.ShowMode = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.AreOpenCloseAnimationsEnabled"/>
        /// </summary>
        public bool AreOpenCloseAnimationsEnabled
        {
            get => UwpInstance.AreOpenCloseAnimationsEnabled;
            set => UwpInstance.AreOpenCloseAnimationsEnabled = value;
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.InputDevicePrefersPrimaryCommands"/>
        /// </summary>
        public bool InputDevicePrefersPrimaryCommands
        {
            get => UwpInstance.InputDevicePrefersPrimaryCommands;
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase.IsOpen"/>
        /// </summary>
        public bool IsOpen
        {
            get => UwpInstance.IsOpen;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase"/> to <see cref="FlyoutBase"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator FlyoutBase(
            windows.UI.Xaml.Controls.Primitives.FlyoutBase args)
        {
            return FromFlyoutBase(args);
        }

        /// <summary>
        /// Creates a <see cref="FlyoutBase"/> from <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Controls.Primitives.FlyoutBase"/> instance containing the event data.</param>
        /// <returns><see cref="FlyoutBase"/></returns>
        public static FlyoutBase FromFlyoutBase(windows.UI.Xaml.Controls.Primitives.FlyoutBase args)
        {
            return new FlyoutBase(args);
        }
    }
}