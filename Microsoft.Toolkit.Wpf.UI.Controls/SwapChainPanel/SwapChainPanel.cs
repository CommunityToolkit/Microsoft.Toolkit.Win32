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
    /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.SwapChainPanel"/>
    /// </summary>
    internal class SwapChainPanel : WindowsXamlHostBase
    {
        internal windows.UI.Xaml.Controls.SwapChainPanel UwpControl => ChildInternal as windows.UI.Xaml.Controls.SwapChainPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwapChainPanel"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.SwapChainPanel"/>
        /// </summary>
        public SwapChainPanel()
            : this(typeof(windows.UI.Xaml.Controls.SwapChainPanel).FullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwapChainPanel"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.SwapChainPanel"/>.
        /// Intended for internal framework use only.
        /// </summary>
        public SwapChainPanel(string typeName)
            : base(typeName)
        {
        }

        protected override void OnInitialized(EventArgs e)
        {
            // Bind dependency properties across controls
            // properties of FrameworkElement
            Bind(nameof(Style), StyleProperty, windows.UI.Xaml.Controls.SwapChainPanel.StyleProperty);
            Bind(nameof(MaxHeight), MaxHeightProperty, windows.UI.Xaml.Controls.SwapChainPanel.MaxHeightProperty);
            Bind(nameof(FlowDirection), FlowDirectionProperty, windows.UI.Xaml.Controls.SwapChainPanel.FlowDirectionProperty);
            Bind(nameof(Margin), MarginProperty, windows.UI.Xaml.Controls.SwapChainPanel.MarginProperty);
            Bind(nameof(HorizontalAlignment), HorizontalAlignmentProperty, windows.UI.Xaml.Controls.SwapChainPanel.HorizontalAlignmentProperty);
            Bind(nameof(VerticalAlignment), VerticalAlignmentProperty, windows.UI.Xaml.Controls.SwapChainPanel.VerticalAlignmentProperty);
            Bind(nameof(MinHeight), MinHeightProperty, windows.UI.Xaml.Controls.SwapChainPanel.MinHeightProperty);
            Bind(nameof(Height), HeightProperty, windows.UI.Xaml.Controls.SwapChainPanel.HeightProperty);
            Bind(nameof(MinWidth), MinWidthProperty, windows.UI.Xaml.Controls.SwapChainPanel.MinWidthProperty);
            Bind(nameof(MaxWidth), MaxWidthProperty, windows.UI.Xaml.Controls.SwapChainPanel.MaxWidthProperty);
            Bind(nameof(UseLayoutRounding), UseLayoutRoundingProperty, windows.UI.Xaml.Controls.SwapChainPanel.UseLayoutRoundingProperty);
            Bind(nameof(Name), NameProperty, windows.UI.Xaml.Controls.SwapChainPanel.NameProperty);
            Bind(nameof(Tag), TagProperty, windows.UI.Xaml.Controls.SwapChainPanel.TagProperty);
            Bind(nameof(DataContext), DataContextProperty, windows.UI.Xaml.Controls.SwapChainPanel.DataContextProperty);
            Bind(nameof(Width), WidthProperty, windows.UI.Xaml.Controls.SwapChainPanel.WidthProperty);

            // SwapChainPanel specific properties
            Bind(nameof(CompositionScaleX), CompositionScaleXProperty, windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleXProperty);
            Bind(nameof(CompositionScaleY), CompositionScaleYProperty, windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleYProperty);
            UwpControl.CompositionScaleChanged += OnCompositionScaleChanged;

            base.OnInitialized(e);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleXProperty"/>
        /// </summary>
        public static DependencyProperty CompositionScaleXProperty { get; } = DependencyProperty.Register(nameof(CompositionScaleX), typeof(float), typeof(SwapChainPanel));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleYProperty"/>
        /// </summary>
        public static DependencyProperty CompositionScaleYProperty { get; } = DependencyProperty.Register(nameof(CompositionScaleY), typeof(float), typeof(SwapChainPanel));

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CreateCoreIndependentInputSource"/>
        /// </summary>
        /// <returns>CoreIndependentInputSource</returns>
        public CoreIndependentInputSource CreateCoreIndependentInputSource(CoreInputDeviceTypes deviceTypes) => UwpControl.CreateCoreIndependentInputSource((windows.UI.Core.CoreInputDeviceTypes)deviceTypes);

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleX"/>
        /// </summary>
        public float CompositionScaleX
        {
            get => (float)GetValue(CompositionScaleXProperty);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleY"/>
        /// </summary>
        public float CompositionScaleY
        {
            get => (float)GetValue(CompositionScaleYProperty);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleChanged"/>
        /// </summary>
        public event EventHandler<object> CompositionScaleChanged = (sender, args) => { };

        private void OnCompositionScaleChanged(windows.UI.Xaml.Controls.SwapChainPanel sender, object args)
        {
            this.CompositionScaleChanged?.Invoke(this, args);
        }
    }
}