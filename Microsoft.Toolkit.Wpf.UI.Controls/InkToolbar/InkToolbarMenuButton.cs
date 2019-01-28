// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using windows = Windows;

namespace Microsoft.Toolkit.Wpf.UI.Controls
{
    /// <summary>
    /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.InkToolbarMenuButton"/>
    /// </summary>
    public class InkToolbarMenuButton : WindowsXamlHostBase
    {
        internal windows.UI.Xaml.Controls.InkToolbarMenuButton UwpControl => ChildInternal as windows.UI.Xaml.Controls.InkToolbarMenuButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="InkToolbarMenuButton"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.InkToolbarMenuButton"/>
        /// </summary>
        public InkToolbarMenuButton()
            : this(typeof(windows.UI.Xaml.Controls.InkToolbarMenuButton).FullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InkToolbarMenuButton"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.InkToolbarMenuButton"/>.
        /// </summary>
        protected InkToolbarMenuButton(string typeName)
            : base(typeName)
        {
        }

        /// <inheritdoc />
        protected override void SetContent()
        {
            // intentionally empty
        }

        /// <inheritdoc />
        protected override void OnInitialized(EventArgs e)
        {
            // Bind dependency properties across controls
            // properties of FrameworkElement
            Bind(nameof(Style), StyleProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.StyleProperty);
            Bind(nameof(MaxHeight), MaxHeightProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.MaxHeightProperty);
            Bind(nameof(FlowDirection), FlowDirectionProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.FlowDirectionProperty);
            Bind(nameof(Margin), MarginProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.MarginProperty);
            Bind(nameof(HorizontalAlignment), HorizontalAlignmentProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.HorizontalAlignmentProperty);
            Bind(nameof(VerticalAlignment), VerticalAlignmentProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.VerticalAlignmentProperty);
            Bind(nameof(MinHeight), MinHeightProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.MinHeightProperty);
            Bind(nameof(Height), HeightProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.HeightProperty);
            Bind(nameof(MinWidth), MinWidthProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.MinWidthProperty);
            Bind(nameof(MaxWidth), MaxWidthProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.MaxWidthProperty);
            Bind(nameof(UseLayoutRounding), UseLayoutRoundingProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.UseLayoutRoundingProperty);
            Bind(nameof(Name), NameProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.NameProperty);
            Bind(nameof(Tag), TagProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.TagProperty);
            Bind(nameof(DataContext), DataContextProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.DataContextProperty);
            Bind(nameof(Width), WidthProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.WidthProperty);

            // InkToolbarMenuButton specific properties
            Bind(nameof(IsExtensionGlyphShown), IsExtensionGlyphShownProperty, windows.UI.Xaml.Controls.InkToolbarMenuButton.IsExtensionGlyphShownProperty);

            base.OnInitialized(e);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.InkToolbarMenuButton.IsExtensionGlyphShownProperty"/>
        /// </summary>
        public static DependencyProperty IsExtensionGlyphShownProperty { get; } = DependencyProperty.Register(nameof(IsExtensionGlyphShown), typeof(bool), typeof(InkToolbarMenuButton));

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.InkToolbarMenuButton.IsExtensionGlyphShown"/>
        /// </summary>
        public bool IsExtensionGlyphShown
        {
            get => (bool)GetValue(IsExtensionGlyphShownProperty);
            set => SetValue(IsExtensionGlyphShownProperty, value);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.InkToolbarMenuButton.MenuKind"/>
        /// </summary>
        public InkToolbarMenuKind MenuKind => (InkToolbarMenuKind)UwpControl.MenuKind;
    }
}