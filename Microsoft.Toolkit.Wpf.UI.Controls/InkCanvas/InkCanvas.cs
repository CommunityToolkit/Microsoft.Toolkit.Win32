// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using windows = Windows;

namespace Microsoft.Toolkit.Wpf.UI.Controls
{
    /// <summary>
    /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.InkCanvas"/>
    /// </summary>
    public class InkCanvas : WindowsXamlHostBase
    {
        internal windows.UI.Xaml.Controls.InkCanvas UwpControl => ChildInternal as windows.UI.Xaml.Controls.InkCanvas;

        /// <summary>
        /// Initializes a new instance of the <see cref="InkCanvas"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.InkCanvas"/>
        /// </summary>
        public InkCanvas()
            : this(typeof(windows.UI.Xaml.Controls.InkCanvas).FullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InkCanvas"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.InkCanvas"/>.
        /// </summary>
        protected InkCanvas(string typeName)
            : base(typeName)
        {
        }

        /// <inheritdoc />
        protected override void OnInitialized(EventArgs e)
        {
            // Bind dependency properties across controls
            // properties of FrameworkElement
            Bind(nameof(Style), StyleProperty, windows.UI.Xaml.Controls.InkCanvas.StyleProperty);
            Bind(nameof(MaxHeight), MaxHeightProperty, windows.UI.Xaml.Controls.InkCanvas.MaxHeightProperty);
            Bind(nameof(FlowDirection), FlowDirectionProperty, windows.UI.Xaml.Controls.InkCanvas.FlowDirectionProperty);
            Bind(nameof(Margin), MarginProperty, windows.UI.Xaml.Controls.InkCanvas.MarginProperty);
            Bind(nameof(HorizontalAlignment), HorizontalAlignmentProperty, windows.UI.Xaml.Controls.InkCanvas.HorizontalAlignmentProperty);
            Bind(nameof(VerticalAlignment), VerticalAlignmentProperty, windows.UI.Xaml.Controls.InkCanvas.VerticalAlignmentProperty);
            Bind(nameof(MinHeight), MinHeightProperty, windows.UI.Xaml.Controls.InkCanvas.MinHeightProperty);
            Bind(nameof(Height), HeightProperty, windows.UI.Xaml.Controls.InkCanvas.HeightProperty);
            Bind(nameof(MinWidth), MinWidthProperty, windows.UI.Xaml.Controls.InkCanvas.MinWidthProperty);
            Bind(nameof(MaxWidth), MaxWidthProperty, windows.UI.Xaml.Controls.InkCanvas.MaxWidthProperty);
            Bind(nameof(UseLayoutRounding), UseLayoutRoundingProperty, windows.UI.Xaml.Controls.InkCanvas.UseLayoutRoundingProperty);
            Bind(nameof(Name), NameProperty, windows.UI.Xaml.Controls.InkCanvas.NameProperty);
            Bind(nameof(Tag), TagProperty, windows.UI.Xaml.Controls.InkCanvas.TagProperty);
            Bind(nameof(DataContext), DataContextProperty, windows.UI.Xaml.Controls.InkCanvas.DataContextProperty);
            Bind(nameof(Width), WidthProperty, windows.UI.Xaml.Controls.InkCanvas.WidthProperty);

            base.OnInitialized(e);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.InkCanvas.InkPresenter"/>
        /// </summary>
        public InkPresenter InkPresenter => UwpControl.InkPresenter;
    }
}