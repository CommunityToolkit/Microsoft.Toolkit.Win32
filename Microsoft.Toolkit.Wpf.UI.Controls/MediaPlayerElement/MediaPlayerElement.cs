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
    /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.MediaPlayerElement"/>
    /// </summary>
    public class MediaPlayerElement : WindowsXamlHostBase
    {
        internal windows.UI.Xaml.Controls.MediaPlayerElement UwpControl => ChildInternal as windows.UI.Xaml.Controls.MediaPlayerElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaPlayerElement"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.MediaPlayerElement"/>
        /// </summary>
        public MediaPlayerElement()
            : this(typeof(windows.UI.Xaml.Controls.MediaPlayerElement).FullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaPlayerElement"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.MediaPlayerElement"/>.
        /// </summary>
        protected MediaPlayerElement(string typeName)
            : base(typeName)
        {
        }

        /// <inheritdoc />
        protected override void OnInitialized(EventArgs e)
        {
            // Bind dependency properties across controls
            // properties of FrameworkElement
            Bind(nameof(Style), StyleProperty, windows.UI.Xaml.Controls.MediaPlayerElement.StyleProperty);
            Bind(nameof(MaxHeight), MaxHeightProperty, windows.UI.Xaml.Controls.MediaPlayerElement.MaxHeightProperty);
            Bind(nameof(FlowDirection), FlowDirectionProperty, windows.UI.Xaml.Controls.MediaPlayerElement.FlowDirectionProperty);
            Bind(nameof(Margin), MarginProperty, windows.UI.Xaml.Controls.MediaPlayerElement.MarginProperty);
            Bind(nameof(HorizontalAlignment), HorizontalAlignmentProperty, windows.UI.Xaml.Controls.MediaPlayerElement.HorizontalAlignmentProperty);
            Bind(nameof(VerticalAlignment), VerticalAlignmentProperty, windows.UI.Xaml.Controls.MediaPlayerElement.VerticalAlignmentProperty);
            Bind(nameof(MinHeight), MinHeightProperty, windows.UI.Xaml.Controls.MediaPlayerElement.MinHeightProperty);
            Bind(nameof(Height), HeightProperty, windows.UI.Xaml.Controls.MediaPlayerElement.HeightProperty);
            Bind(nameof(MinWidth), MinWidthProperty, windows.UI.Xaml.Controls.MediaPlayerElement.MinWidthProperty);
            Bind(nameof(MaxWidth), MaxWidthProperty, windows.UI.Xaml.Controls.MediaPlayerElement.MaxWidthProperty);
            Bind(nameof(UseLayoutRounding), UseLayoutRoundingProperty, windows.UI.Xaml.Controls.MediaPlayerElement.UseLayoutRoundingProperty);
            Bind(nameof(Name), NameProperty, windows.UI.Xaml.Controls.MediaPlayerElement.NameProperty);
            Bind(nameof(Tag), TagProperty, windows.UI.Xaml.Controls.MediaPlayerElement.TagProperty);
            Bind(nameof(DataContext), DataContextProperty, windows.UI.Xaml.Controls.MediaPlayerElement.DataContextProperty);
            Bind(nameof(Width), WidthProperty, windows.UI.Xaml.Controls.MediaPlayerElement.WidthProperty);

            // MediaPlayerElement specific properties
            Bind(nameof(Stretch), StretchProperty, windows.UI.Xaml.Controls.MediaPlayerElement.StretchProperty);
            Bind(nameof(Source), SourceProperty, windows.UI.Xaml.Controls.MediaPlayerElement.SourceProperty, new MediaSourceConverter());
            Bind(nameof(PosterSource), PosterSourceProperty, windows.UI.Xaml.Controls.MediaPlayerElement.PosterSourceProperty);
            Bind(nameof(IsFullWindow), IsFullWindowProperty, windows.UI.Xaml.Controls.MediaPlayerElement.IsFullWindowProperty);
            Bind(nameof(AutoPlay), AutoPlayProperty, windows.UI.Xaml.Controls.MediaPlayerElement.AutoPlayProperty);
            Bind(nameof(AreTransportControlsEnabled), AreTransportControlsEnabledProperty, windows.UI.Xaml.Controls.MediaPlayerElement.AreTransportControlsEnabledProperty);

            // Full-screen not supported yet.
            UwpControl.TransportControls.IsFullWindowButtonVisible = false;

            base.OnInitialized(e);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.AreTransportControlsEnabledProperty"/>
        /// </summary>
        public static DependencyProperty AreTransportControlsEnabledProperty { get; } = DependencyProperty.Register(nameof(AreTransportControlsEnabled), typeof(bool), typeof(MediaPlayerElement));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.AutoPlayProperty"/>
        /// </summary>
        public static DependencyProperty AutoPlayProperty { get; } = DependencyProperty.Register(nameof(AutoPlay), typeof(bool), typeof(MediaPlayerElement));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.IsFullWindowProperty"/>
        /// </summary>
        public static DependencyProperty IsFullWindowProperty { get; } = DependencyProperty.Register(nameof(IsFullWindow), typeof(bool), typeof(MediaPlayerElement));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.PosterSourceProperty"/>
        /// </summary>
        public static DependencyProperty PosterSourceProperty { get; } = DependencyProperty.Register(nameof(PosterSource), typeof(ImageSource), typeof(MediaPlayerElement));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.SourceProperty"/>
        /// </summary>
        public static DependencyProperty SourceProperty { get; } = DependencyProperty.Register(nameof(Source), typeof(string), typeof(MediaPlayerElement));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.StretchProperty"/>
        /// </summary>
        public static DependencyProperty StretchProperty { get; } = DependencyProperty.Register(nameof(Stretch), typeof(Stretch), typeof(MediaPlayerElement));

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.SetMediaPlayer"/>
        /// </summary>
        public void SetMediaPlayer(MediaPlayer mediaPlayer) => UwpControl.SetMediaPlayer(mediaPlayer.UwpInstance);

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.TransportControls"/>
        /// </summary>
        public MediaTransportControls TransportControls
        {
            get => UwpControl.TransportControls;
            set => UwpControl.TransportControls = value.UwpInstance;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.Stretch"/>
        /// </summary>
        public Stretch Stretch
        {
            get => (Stretch)GetValue(StretchProperty);
            set => SetValue(StretchProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.Source"/>
        /// </summary>
        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.PosterSource"/>
        /// </summary>
        public ImageSource PosterSource
        {
            get => (ImageSource)GetValue(PosterSourceProperty);
            set => SetValue(PosterSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.IsFullWindow"/>
        /// </summary>
        public bool IsFullWindow
        {
            get => (bool)GetValue(IsFullWindowProperty);
            set => SetValue(IsFullWindowProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.AutoPlay"/>
        /// </summary>
        public bool AutoPlay
        {
            get => (bool)GetValue(AutoPlayProperty);
            set => SetValue(AutoPlayProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.AreTransportControlsEnabled"/>
        /// </summary>
        public bool AreTransportControlsEnabled
        {
            get => (bool)GetValue(AreTransportControlsEnabledProperty);
            set => SetValue(AreTransportControlsEnabledProperty, value);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.MediaPlayerElement.MediaPlayer"/>
        /// </summary>
        public MediaPlayer MediaPlayer
        {
            get => UwpControl?.MediaPlayer;
        }
    }
}