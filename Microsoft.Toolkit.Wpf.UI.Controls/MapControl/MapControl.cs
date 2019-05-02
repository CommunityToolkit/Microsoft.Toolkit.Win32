// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.XamlHost;
using windows = Windows;

namespace Microsoft.Toolkit.Wpf.UI.Controls
{
    /// <summary>
    /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
    /// </summary>
    [ContentProperty(nameof(Children))]
    public class MapControl : WindowsXamlHostBase
    {
        internal windows.UI.Xaml.Controls.Maps.MapControl UwpControl => this.ChildInternal as windows.UI.Xaml.Controls.Maps.MapControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapControl"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        public MapControl()
            : this(typeof(windows.UI.Xaml.Controls.Maps.MapControl).FullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapControl"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>.
        /// Intended for internal framework use only.
        /// </summary>
        internal MapControl(string typeName)
            : base(typeName)
        {
            Children = new List<DependencyObject>();
        }

        protected override void OnInitialized(EventArgs e)
        {
            // Bind dependency properties across controls
            // properties of FrameworkElement
            Bind(nameof(Style), StyleProperty, windows.UI.Xaml.Controls.Maps.MapControl.StyleProperty);
            Bind(nameof(MaxHeight), MaxHeightProperty, windows.UI.Xaml.Controls.Maps.MapControl.MaxHeightProperty);
            Bind(nameof(FlowDirection), FlowDirectionProperty, windows.UI.Xaml.Controls.Maps.MapControl.FlowDirectionProperty);
            Bind(nameof(Margin), MarginProperty, windows.UI.Xaml.Controls.Maps.MapControl.MarginProperty);
            Bind(nameof(HorizontalAlignment), HorizontalAlignmentProperty, windows.UI.Xaml.Controls.Maps.MapControl.HorizontalAlignmentProperty);
            Bind(nameof(VerticalAlignment), VerticalAlignmentProperty, windows.UI.Xaml.Controls.Maps.MapControl.VerticalAlignmentProperty);
            Bind(nameof(MinHeight), MinHeightProperty, windows.UI.Xaml.Controls.Maps.MapControl.MinHeightProperty);
            Bind(nameof(Height), HeightProperty, windows.UI.Xaml.Controls.Maps.MapControl.HeightProperty);
            Bind(nameof(MinWidth), MinWidthProperty, windows.UI.Xaml.Controls.Maps.MapControl.MinWidthProperty);
            Bind(nameof(MaxWidth), MaxWidthProperty, windows.UI.Xaml.Controls.Maps.MapControl.MaxWidthProperty);
            Bind(nameof(UseLayoutRounding), UseLayoutRoundingProperty, windows.UI.Xaml.Controls.Maps.MapControl.UseLayoutRoundingProperty);
            Bind(nameof(Name), NameProperty, windows.UI.Xaml.Controls.Maps.MapControl.NameProperty);
            Bind(nameof(Tag), TagProperty, windows.UI.Xaml.Controls.Maps.MapControl.TagProperty);
            Bind(nameof(DataContext), DataContextProperty, windows.UI.Xaml.Controls.Maps.MapControl.DataContextProperty);
            Bind(nameof(Width), WidthProperty, windows.UI.Xaml.Controls.Maps.MapControl.WidthProperty);

            // MapControl specific properties
            Bind(nameof(WatermarkMode), WatermarkModeProperty, windows.UI.Xaml.Controls.Maps.MapControl.WatermarkModeProperty, new WindowsXamlHostWrapperConverter());
            /* Bind(nameof(Style), StyleProperty, windows.UI.Xaml.Controls.Maps.MapControl.StyleProperty, new WindowsXamlHostWrapperConverter()); */
            Bind(nameof(MapServiceToken), MapServiceTokenProperty, windows.UI.Xaml.Controls.Maps.MapControl.MapServiceTokenProperty);
            /* Bind(nameof(TransformOrigin), TransformOriginProperty, windows.UI.Xaml.Controls.Maps.MapControl.TransformOriginProperty); */
            Bind(nameof(TrafficFlowVisible), TrafficFlowVisibleProperty, windows.UI.Xaml.Controls.Maps.MapControl.TrafficFlowVisibleProperty);
            Bind(nameof(LandmarksVisible), LandmarksVisibleProperty, windows.UI.Xaml.Controls.Maps.MapControl.LandmarksVisibleProperty);
            Bind(nameof(Heading), HeadingProperty, windows.UI.Xaml.Controls.Maps.MapControl.HeadingProperty);
            Bind(nameof(DesiredPitch), DesiredPitchProperty, windows.UI.Xaml.Controls.Maps.MapControl.DesiredPitchProperty);
            Bind(nameof(ColorScheme), ColorSchemeProperty, windows.UI.Xaml.Controls.Maps.MapControl.ColorSchemeProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(PedestrianFeaturesVisible), PedestrianFeaturesVisibleProperty, windows.UI.Xaml.Controls.Maps.MapControl.PedestrianFeaturesVisibleProperty);
            Bind(nameof(ZoomLevel), ZoomLevelProperty, windows.UI.Xaml.Controls.Maps.MapControl.ZoomLevelProperty);
            Bind(nameof(Center), CenterProperty, windows.UI.Xaml.Controls.Maps.MapControl.CenterProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(LoadingStatus), LoadingStatusProperty, windows.UI.Xaml.Controls.Maps.MapControl.LoadingStatusProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(Pitch), PitchProperty, windows.UI.Xaml.Controls.Maps.MapControl.PitchProperty);
            Bind(nameof(ZoomInteractionMode), ZoomInteractionModeProperty, windows.UI.Xaml.Controls.Maps.MapControl.ZoomInteractionModeProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(TransitFeaturesVisible), TransitFeaturesVisibleProperty, windows.UI.Xaml.Controls.Maps.MapControl.TransitFeaturesVisibleProperty);
            Bind(nameof(TiltInteractionMode), TiltInteractionModeProperty, windows.UI.Xaml.Controls.Maps.MapControl.TiltInteractionModeProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(Scene), SceneProperty, windows.UI.Xaml.Controls.Maps.MapControl.SceneProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(RotateInteractionMode), RotateInteractionModeProperty, windows.UI.Xaml.Controls.Maps.MapControl.RotateInteractionModeProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(PanInteractionMode), PanInteractionModeProperty, windows.UI.Xaml.Controls.Maps.MapControl.PanInteractionModeProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(BusinessLandmarksVisible), BusinessLandmarksVisibleProperty, windows.UI.Xaml.Controls.Maps.MapControl.BusinessLandmarksVisibleProperty);
            Bind(nameof(Is3DSupported), Is3DSupportedProperty, windows.UI.Xaml.Controls.Maps.MapControl.Is3DSupportedProperty);
            Bind(nameof(IsStreetsideSupported), IsStreetsideSupportedProperty, windows.UI.Xaml.Controls.Maps.MapControl.IsStreetsideSupportedProperty);
            Bind(nameof(TransitFeaturesEnabled), TransitFeaturesEnabledProperty, windows.UI.Xaml.Controls.Maps.MapControl.TransitFeaturesEnabledProperty);
            Bind(nameof(BusinessLandmarksEnabled), BusinessLandmarksEnabledProperty, windows.UI.Xaml.Controls.Maps.MapControl.BusinessLandmarksEnabledProperty);
            /* Bind(nameof(ViewPadding), ViewPaddingProperty, windows.UI.Xaml.Controls.Maps.MapControl.ViewPaddingProperty);
            Bind(nameof(StyleSheet), StyleSheetProperty, windows.UI.Xaml.Controls.Maps.MapControl.StyleSheetProperty, new WindowsXamlHostWrapperConverter()); */
            Bind(nameof(MapProjection), MapProjectionProperty, windows.UI.Xaml.Controls.Maps.MapControl.MapProjectionProperty, new WindowsXamlHostWrapperConverter());
            Bind(nameof(Region), RegionProperty, windows.UI.Xaml.Controls.Maps.MapControl.RegionProperty);

            Children.OfType<WindowsXamlHostBase>().ToList().ForEach(RelocateChildToUwpControl);
            UwpControl.CenterChanged += OnCenterChanged;
            UwpControl.HeadingChanged += OnHeadingChanged;
            UwpControl.LoadingStatusChanged += OnLoadingStatusChanged;
            UwpControl.MapDoubleTapped += OnMapDoubleTapped;
            UwpControl.MapHolding += OnMapHolding;
            UwpControl.MapTapped += OnMapTapped;
            UwpControl.PitchChanged += OnPitchChanged;
            UwpControl.TransformOriginChanged += OnTransformOriginChanged;
            UwpControl.ZoomLevelChanged += OnZoomLevelChanged;
            UwpControl.ActualCameraChanged += OnActualCameraChanged;
            UwpControl.ActualCameraChanging += OnActualCameraChanging;
            UwpControl.CustomExperienceChanged += OnCustomExperienceChanged;
            UwpControl.MapElementClick += OnMapElementClick;
            UwpControl.MapElementPointerEntered += OnMapElementPointerEntered;
            UwpControl.MapElementPointerExited += OnMapElementPointerExited;
            UwpControl.TargetCameraChanged += OnTargetCameraChanged;
            UwpControl.MapRightTapped += OnMapRightTapped;
            UwpControl.MapContextRequested += OnMapContextRequested;

            base.OnInitialized(e);
        }

        private void RelocateChildToUwpControl(WindowsXamlHostBase obj)
        {
            if (obj.GetUwpInternalObject() is windows.UI.Xaml.DependencyObject child)
            {
                UwpControl.Children.Add(child);
            }
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ColorSchemeProperty"/>
        /// </summary>
        public static DependencyProperty ColorSchemeProperty { get; } = DependencyProperty.Register(nameof(ColorScheme), typeof(MapColorScheme), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.HeadingProperty"/>
        /// </summary>
        public static DependencyProperty HeadingProperty { get; } = DependencyProperty.Register(nameof(Heading), typeof(double), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.LandmarksVisibleProperty"/>
        /// </summary>
        public static DependencyProperty LandmarksVisibleProperty { get; } = DependencyProperty.Register(nameof(LandmarksVisible), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.LoadingStatusProperty"/>
        /// </summary>
        public static DependencyProperty LoadingStatusProperty { get; } = DependencyProperty.Register(nameof(LoadingStatus), typeof(MapLoadingStatus), typeof(MapControl));

        /*
        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.LocationProperty"/>
        /// </summary>
        public static DependencyProperty LocationProperty { get; } = DependencyProperty.Register(nameof(Center), typeof(Geopoint), typeof(MapControl));
        */

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapServiceTokenProperty"/>
        /// </summary>
        public static DependencyProperty MapServiceTokenProperty { get; } = DependencyProperty.Register(nameof(MapServiceToken), typeof(string), typeof(MapControl));

        /*
        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.NormalizedAnchorPointProperty"/>
        /// </summary>
        public static DependencyProperty NormalizedAnchorPointProperty { get; } = DependencyProperty.Register(nameof(Center), typeof(Geopoint), typeof(MapControl));
        */

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.PedestrianFeaturesVisibleProperty"/>
        /// </summary>
        public static DependencyProperty PedestrianFeaturesVisibleProperty { get; } = DependencyProperty.Register(nameof(PedestrianFeaturesVisible), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.PitchProperty"/>
        /// </summary>
        public static DependencyProperty PitchProperty { get; } = DependencyProperty.Register(nameof(Pitch), typeof(double), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StyleProperty"/>
        /// </summary>
        public static new DependencyProperty StyleProperty { get; } = DependencyProperty.Register(nameof(Style), typeof(MapStyle), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TrafficFlowVisibleProperty"/>
        /// </summary>
        public static DependencyProperty TrafficFlowVisibleProperty { get; } = DependencyProperty.Register(nameof(TrafficFlowVisible), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TransformOriginProperty"/>
        /// </summary>
        public static DependencyProperty TransformOriginProperty { get; } = DependencyProperty.Register(nameof(TransformOrigin), typeof(Win32.UI.Controls.Interop.WinRT.Point), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.WatermarkModeProperty"/>
        /// </summary>
        public static DependencyProperty WatermarkModeProperty { get; } = DependencyProperty.Register(nameof(WatermarkMode), typeof(MapWatermarkMode), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.CenterProperty"/>
        /// </summary>
        public static DependencyProperty CenterProperty { get; } = DependencyProperty.Register(nameof(Center), typeof(Geopoint), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ZoomLevelProperty"/>
        /// </summary>
        public static DependencyProperty ZoomLevelProperty { get; } = DependencyProperty.Register(nameof(ZoomLevel), typeof(double), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.DesiredPitchProperty"/>
        /// </summary>
        public static DependencyProperty DesiredPitchProperty { get; } = DependencyProperty.Register(nameof(DesiredPitch), typeof(double), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.BusinessLandmarksVisibleProperty"/>
        /// </summary>
        public static DependencyProperty BusinessLandmarksVisibleProperty { get; } = DependencyProperty.Register(nameof(BusinessLandmarksVisible), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Is3DSupportedProperty"/>
        /// </summary>
        public static DependencyProperty Is3DSupportedProperty { get; } = DependencyProperty.Register(nameof(Is3DSupported), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.IsStreetsideSupportedProperty"/>
        /// </summary>
        public static DependencyProperty IsStreetsideSupportedProperty { get; } = DependencyProperty.Register(nameof(IsStreetsideSupported), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.PanInteractionModeProperty"/>
        /// </summary>
        public static DependencyProperty PanInteractionModeProperty { get; } = DependencyProperty.Register(nameof(PanInteractionMode), typeof(MapPanInteractionMode), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.RotateInteractionModeProperty"/>
        /// </summary>
        public static DependencyProperty RotateInteractionModeProperty { get; } = DependencyProperty.Register(nameof(RotateInteractionMode), typeof(MapInteractionMode), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.SceneProperty"/>
        /// </summary>
        public static DependencyProperty SceneProperty { get; } = DependencyProperty.Register(nameof(Scene), typeof(MapScene), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TiltInteractionModeProperty"/>
        /// </summary>
        public static DependencyProperty TiltInteractionModeProperty { get; } = DependencyProperty.Register(nameof(TiltInteractionMode), typeof(MapInteractionMode), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TransitFeaturesVisibleProperty"/>
        /// </summary>
        public static DependencyProperty TransitFeaturesVisibleProperty { get; } = DependencyProperty.Register(nameof(TransitFeaturesVisible), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ZoomInteractionModeProperty"/>
        /// </summary>
        public static DependencyProperty ZoomInteractionModeProperty { get; } = DependencyProperty.Register(nameof(ZoomInteractionMode), typeof(MapInteractionMode), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.BusinessLandmarksEnabledProperty"/>
        /// </summary>
        public static DependencyProperty BusinessLandmarksEnabledProperty { get; } = DependencyProperty.Register(nameof(BusinessLandmarksEnabled), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TransitFeaturesEnabledProperty"/>
        /// </summary>
        public static DependencyProperty TransitFeaturesEnabledProperty { get; } = DependencyProperty.Register(nameof(TransitFeaturesEnabled), typeof(bool), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapProjectionProperty"/>
        /// </summary>
        public static DependencyProperty MapProjectionProperty { get; } = DependencyProperty.Register(nameof(MapProjection), typeof(MapProjection), typeof(MapControl));

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StyleSheetProperty"/>
        /// </summary>
        public static DependencyProperty StyleSheetProperty { get; } = DependencyProperty.Register(nameof(StyleSheet), typeof(MapStyleSheet), typeof(MapControl));

        /*
        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ViewPaddingProperty"/>
        /// </summary>
        public static DependencyProperty ViewPaddingProperty { get; } = DependencyProperty.Register(nameof(ViewPadding), typeof(windows.UI.Xaml.Thickness), typeof(MapControl));
        */

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.RegionProperty"/>
        /// </summary>
        public static DependencyProperty RegionProperty { get; } = DependencyProperty.Register(nameof(Region), typeof(string), typeof(MapControl));

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryTiltAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryTiltAsync(double degrees) => UwpControl.TryTiltAsync(degrees).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryTiltToAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryTiltToAsync(double angleInDegrees) => UwpControl.TryTiltToAsync(angleInDegrees).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryZoomInAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryZoomInAsync() => UwpControl.TryZoomInAsync().AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryZoomOutAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryZoomOutAsync() => UwpControl.TryZoomOutAsync().AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryZoomToAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryZoomToAsync(double zoomLevel) => UwpControl.TryZoomToAsync(zoomLevel).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TrySetSceneAsync(MapScene scene) => UwpControl.TrySetSceneAsync(scene.UwpInstance).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TrySetSceneAsync(MapScene scene, MapAnimationKind animationKind) => UwpControl.TrySetSceneAsync(scene.UwpInstance, (windows.UI.Xaml.Controls.Maps.MapAnimationKind)animationKind).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.GetVisibleRegion"/>
        /// </summary>
        /// <returns>Geopath</returns>
        public Geopath GetVisibleRegion(MapVisibleRegionKind region) => UwpControl.GetVisibleRegion((windows.UI.Xaml.Controls.Maps.MapVisibleRegionKind)region);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>IReadOnlyList</returns>
        public System.Collections.Generic.IReadOnlyList<MapElement> FindMapElementsAtOffset(Win32.UI.Controls.Interop.WinRT.Point offset, double radius) => (System.Collections.Generic.IReadOnlyList<MapElement>)UwpControl.FindMapElementsAtOffset(offset.UwpInstance, radius);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        public void GetLocationFromOffset(Win32.UI.Controls.Interop.WinRT.Point offset, AltitudeReferenceSystem desiredReferenceSystem, out windows.Devices.Geolocation.Geopoint location) => UwpControl.GetLocationFromOffset(offset.UwpInstance, (windows.Devices.Geolocation.AltitudeReferenceSystem)desiredReferenceSystem, out location);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StartContinuousPan"/>
        /// </summary>
        public void StartContinuousPan(double horizontalPixelsPerSecond, double verticalPixelsPerSecond) => UwpControl.StartContinuousPan(horizontalPixelsPerSecond, verticalPixelsPerSecond);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StopContinuousPan"/>
        /// </summary>
        public void StopContinuousPan() => UwpControl.StopContinuousPan();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryPanAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryPanAsync(double horizontalPixels, double verticalPixels) => UwpControl.TryPanAsync(horizontalPixels, verticalPixels).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryPanToAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryPanToAsync(Geopoint location) => UwpControl.TryPanToAsync(location.UwpInstance).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>bool</returns>
        public bool TryGetLocationFromOffset(Win32.UI.Controls.Interop.WinRT.Point offset, out windows.Devices.Geolocation.Geopoint location) => UwpControl.TryGetLocationFromOffset(offset.UwpInstance, out location);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>bool</returns>
        public bool TryGetLocationFromOffset(Win32.UI.Controls.Interop.WinRT.Point offset, AltitudeReferenceSystem desiredReferenceSystem, out windows.Devices.Geolocation.Geopoint location) => UwpControl.TryGetLocationFromOffset(offset.UwpInstance, (windows.Devices.Geolocation.AltitudeReferenceSystem)(int)desiredReferenceSystem, out location);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>bool</returns>
        public System.Collections.Generic.IReadOnlyList<MapElement> FindMapElementsAtOffset(Win32.UI.Controls.Interop.WinRT.Point offset) => (System.Collections.Generic.IReadOnlyList<MapElement>)UwpControl.FindMapElementsAtOffset(offset.UwpInstance);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        public void GetLocationFromOffset(Win32.UI.Controls.Interop.WinRT.Point offset, out windows.Devices.Geolocation.Geopoint location) => UwpControl.GetLocationFromOffset(offset.UwpInstance, out location);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.GetOffsetFromLocation"/>
        /// </summary>
        public void GetOffsetFromLocation(Geopoint location, out Win32.UI.Controls.Interop.WinRT.Point offset)
        {
            UwpControl.GetOffsetFromLocation(location.UwpInstance, out var uwpOffset);
            offset = (Win32.UI.Controls.Interop.WinRT.Point)uwpOffset;
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.IsLocationInView"/>
        /// </summary>
        public void IsLocationInView(Geopoint location, out bool isInView) => UwpControl.IsLocationInView(location.UwpInstance, out isInView);

        /*
        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TrySetViewBoundsAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TrySetViewBoundsAsync(GeoboundingBox bounds, windows.UI.Xaml.Thickness? margin, MapAnimationKind animation) => UwpControl.TrySetViewBoundsAsync(bounds, margin, animation);
        */

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TrySetViewAsync(Geopoint center) => UwpControl.TrySetViewAsync(center.UwpInstance).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TrySetViewAsync(Geopoint center, double? zoomLevel) => UwpControl.TrySetViewAsync(center.UwpInstance, zoomLevel).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TrySetViewAsync(Geopoint center, double? zoomLevel, double? heading, double? desiredPitch) => UwpControl.TrySetViewAsync(center.UwpInstance, zoomLevel, heading, desiredPitch).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TrySetViewAsync(Geopoint center, double? zoomLevel, double? heading, double? desiredPitch, MapAnimationKind animation) => UwpControl.TrySetViewAsync(center.UwpInstance, zoomLevel, heading, desiredPitch, (windows.UI.Xaml.Controls.Maps.MapAnimationKind)(int)animation).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StartContinuousRotate"/>
        /// </summary>
        public void StartContinuousRotate(double rateInDegreesPerSecond) => UwpControl.StartContinuousRotate(rateInDegreesPerSecond);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StopContinuousRotate"/>
        /// </summary>
        public void StopContinuousRotate() => UwpControl.StopContinuousRotate();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StartContinuousTilt"/>
        /// </summary>
        public void StartContinuousTilt(double rateInDegreesPerSecond) => UwpControl.StartContinuousTilt(rateInDegreesPerSecond);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StopContinuousTilt"/>
        /// </summary>
        public void StopContinuousTilt() => UwpControl.StopContinuousTilt();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StartContinuousZoom"/>
        /// </summary>
        public void StartContinuousZoom(double rateOfChangePerSecond) => UwpControl.StartContinuousZoom(rateOfChangePerSecond);

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StopContinuousZoom"/>
        /// </summary>
        public void StopContinuousZoom() => UwpControl.StopContinuousZoom();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryRotateAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryRotateAsync(double degrees) => UwpControl.TryRotateAsync(degrees).AsTask();

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TryRotateToAsync"/>
        /// </summary>
        /// <returns>IAsyncOperation</returns>
        public Task<bool> TryRotateToAsync(double angleInDegrees) => UwpControl.TryRotateToAsync(angleInDegrees).AsTask();

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.WatermarkMode"/>
        /// </summary>
        public MapWatermarkMode WatermarkMode
        {
            get => (MapWatermarkMode)GetValue(WatermarkModeProperty);
            set => SetValue(WatermarkModeProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Style"/>
        /// </summary>
        public new MapStyle Style
        {
            get => (MapStyle)GetValue(StyleProperty);
            set => SetValue(StyleProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapServiceToken"/>
        /// </summary>
        public string MapServiceToken
        {
            get => (string)GetValue(MapServiceTokenProperty);
            set => SetValue(MapServiceTokenProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TransformOrigin"/>
        /// </summary>
        public Win32.UI.Controls.Interop.WinRT.Point TransformOrigin
        {
            get => (Win32.UI.Controls.Interop.WinRT.Point)GetValue(TransformOriginProperty);
            set => SetValue(TransformOriginProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TrafficFlowVisible"/>
        /// </summary>
        public bool TrafficFlowVisible
        {
            get => (bool)GetValue(TrafficFlowVisibleProperty);
            set => SetValue(TrafficFlowVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.LandmarksVisible"/>
        /// </summary>
        public bool LandmarksVisible
        {
            get => (bool)GetValue(LandmarksVisibleProperty);
            set => SetValue(LandmarksVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Heading"/>
        /// </summary>
        public double Heading
        {
            get => (double)GetValue(HeadingProperty);
            set => SetValue(HeadingProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.DesiredPitch"/>
        /// </summary>
        public double DesiredPitch
        {
            get => (double)GetValue(DesiredPitchProperty);
            set => SetValue(DesiredPitchProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ColorScheme"/>
        /// </summary>
        public MapColorScheme ColorScheme
        {
            get => (MapColorScheme)GetValue(ColorSchemeProperty);
            set => SetValue(ColorSchemeProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.PedestrianFeaturesVisible"/>
        /// </summary>
        public bool PedestrianFeaturesVisible
        {
            get => (bool)GetValue(PedestrianFeaturesVisibleProperty);
            set => SetValue(PedestrianFeaturesVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ZoomLevel"/>
        /// </summary>
        public double ZoomLevel
        {
            get => (double)GetValue(ZoomLevelProperty);
            set => SetValue(ZoomLevelProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Center"/>
        /// </summary>
        public Geopoint Center
        {
            get => (Geopoint)GetValue(CenterProperty);
            set => SetValue(CenterProperty, value);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.LoadingStatus"/>
        /// </summary>
        public MapLoadingStatus LoadingStatus
        {
            get => (MapLoadingStatus)GetValue(LoadingStatusProperty);
        }

        private System.Collections.Generic.IList<MapElement> _mapElements;

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapElements"/>
        /// </summary>
        public System.Collections.Generic.IList<MapElement> MapElements
        {
            get
            {
                if (_mapElements == null)
                {
                    _mapElements = new WindowsRuntimeCollection<MapElement, windows.UI.Xaml.Controls.Maps.MapElement>(
                        this.UwpControl.MapElements,
                        mp => MapElement.FromMapElement(mp),
                        mp => mp.UwpInstance);
                }

                return _mapElements;
            }
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MaxZoomLevel"/>
        /// </summary>
        public double MaxZoomLevel
        {
            get => UwpControl.MaxZoomLevel;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MinZoomLevel"/>
        /// </summary>
        public double MinZoomLevel
        {
            get => UwpControl.MinZoomLevel;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Pitch"/>
        /// </summary>
        public double Pitch
        {
            get => (double)GetValue(PitchProperty);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Routes"/>
        /// </summary>
        public System.Collections.Generic.IList<windows.UI.Xaml.Controls.Maps.MapRouteView> Routes
        {
            get => this.UwpControl.Routes;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TileSources"/>
        /// </summary>
        public System.Collections.Generic.IList<windows.UI.Xaml.Controls.Maps.MapTileSource> TileSources
        {
            get => this.UwpControl.TileSources;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ZoomInteractionMode"/>
        /// </summary>
        public MapInteractionMode ZoomInteractionMode
        {
            get => (MapInteractionMode)GetValue(ZoomInteractionModeProperty);
            set => SetValue(ZoomInteractionModeProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TransitFeaturesVisible"/>
        /// </summary>
        public bool TransitFeaturesVisible
        {
            get => (bool)GetValue(TransitFeaturesVisibleProperty);
            set => SetValue(TransitFeaturesVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TiltInteractionMode"/>
        /// </summary>
        public MapInteractionMode TiltInteractionMode
        {
            get => (MapInteractionMode)GetValue(TiltInteractionModeProperty);
            set => SetValue(TiltInteractionModeProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Scene"/>
        /// </summary>
        public MapScene Scene
        {
            get => (MapScene)GetValue(SceneProperty);
            set => SetValue(SceneProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.RotateInteractionMode"/>
        /// </summary>
        public MapInteractionMode RotateInteractionMode
        {
            get => (MapInteractionMode)GetValue(RotateInteractionModeProperty);
            set => SetValue(RotateInteractionModeProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.PanInteractionMode"/>
        /// </summary>
        public MapPanInteractionMode PanInteractionMode
        {
            get => (MapPanInteractionMode)GetValue(PanInteractionModeProperty);
            set => SetValue(PanInteractionModeProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.CustomExperience"/>
        /// </summary>
        public MapCustomExperience CustomExperience
        {
            get => UwpControl.CustomExperience;
            set => UwpControl.CustomExperience = value.UwpInstance;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.BusinessLandmarksVisible"/>
        /// </summary>
        public bool BusinessLandmarksVisible
        {
            get => (bool)GetValue(BusinessLandmarksVisibleProperty);
            set => SetValue(BusinessLandmarksVisibleProperty, value);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ActualCamera"/>
        /// </summary>
        public MapCamera ActualCamera
        {
            get => UwpControl.ActualCamera;
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Is3DSupported"/>
        /// </summary>
        public bool Is3DSupported
        {
            get => (bool)GetValue(Is3DSupportedProperty);
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.IsStreetsideSupported"/>
        /// </summary>
        public bool IsStreetsideSupported
        {
            get => (bool)GetValue(IsStreetsideSupportedProperty);
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TargetCamera"/>
        /// </summary>
        public MapCamera TargetCamera
        {
            get => UwpControl.TargetCamera;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TransitFeaturesEnabled"/>
        /// </summary>
        public bool TransitFeaturesEnabled
        {
            get => (bool)GetValue(TransitFeaturesEnabledProperty);
            set => SetValue(TransitFeaturesEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Xaml.Controls.Maps.MapControl.BusinessLandmarksEnabled"/>
        /// </summary>
        public bool BusinessLandmarksEnabled
        {
            get => (bool)GetValue(BusinessLandmarksEnabledProperty);
            set => SetValue(BusinessLandmarksEnabledProperty, value);
        }

        /*
        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ViewPadding"/>
        /// </summary>
        public windows.UI.Xaml.Thickness ViewPadding
        {
            get => (windows.UI.Xaml.Thickness)GetValue(ViewPaddingProperty);
            set => SetValue(ViewPaddingProperty, value);
        }
        */

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.StyleSheet"/>
        /// </summary>
        public MapStyleSheet StyleSheet
        {
            get => (MapStyleSheet)GetValue(StyleSheetProperty);
            set => SetValue(StyleSheetProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapProjection"/>
        /// </summary>
        public MapProjection MapProjection
        {
            get => (MapProjection)GetValue(MapProjectionProperty);
            set => SetValue(MapProjectionProperty, value);
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Layers"/>
        /// </summary>
        public System.Collections.Generic.IList<windows.UI.Xaml.Controls.Maps.MapLayer> Layers
        {
            get => this.UwpControl.Layers;
            set => this.UwpControl.Layers = value;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Xaml.Controls.Maps.MapControl.Region"/>
        /// </summary>
        public string Region
        {
            get => (string)GetValue(RegionProperty);
            set => SetValue(RegionProperty, value);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.CenterChanged"/>
        /// </summary>
        public event EventHandler<object> CenterChanged = (sender, args) => { };

        private void OnCenterChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            this.CenterChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.HeadingChanged"/>
        /// </summary>
        public event EventHandler<object> HeadingChanged = (sender, args) => { };

        private void OnHeadingChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            this.HeadingChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.LoadingStatusChanged"/>
        /// </summary>
        public event EventHandler<object> LoadingStatusChanged = (sender, args) => { };

        private void OnLoadingStatusChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            this.LoadingStatusChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapDoubleTapped"/>
        /// </summary>
        public event EventHandler<MapInputEventArgs> MapDoubleTapped = (sender, args) => { };

        private void OnMapDoubleTapped(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            this.MapDoubleTapped?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapHolding"/>
        /// </summary>
        public event EventHandler<MapInputEventArgs> MapHolding = (sender, args) => { };

        private void OnMapHolding(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            this.MapHolding?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapTapped"/>
        /// </summary>
        public event EventHandler<MapInputEventArgs> MapTapped = (sender, args) => { };

        private void OnMapTapped(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            this.MapTapped?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.PitchChanged"/>
        /// </summary>
        public event EventHandler<object> PitchChanged = (sender, args) => { };

        private void OnPitchChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            this.PitchChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TransformOriginChanged"/>
        /// </summary>
        public event EventHandler<object> TransformOriginChanged = (sender, args) => { };

        private void OnTransformOriginChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            this.TransformOriginChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ZoomLevelChanged"/>
        /// </summary>
        public event EventHandler<object> ZoomLevelChanged = (sender, args) => { };

        private void OnZoomLevelChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, object args)
        {
            this.ZoomLevelChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ActualCameraChanged"/>
        /// </summary>
        public event EventHandler<MapActualCameraChangedEventArgs> ActualCameraChanged = (sender, args) => { };

        private void OnActualCameraChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapActualCameraChangedEventArgs args)
        {
            this.ActualCameraChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.ActualCameraChanging"/>
        /// </summary>
        public event EventHandler<MapActualCameraChangingEventArgs> ActualCameraChanging = (sender, args) => { };

        private void OnActualCameraChanging(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapActualCameraChangingEventArgs args)
        {
            this.ActualCameraChanging?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.CustomExperienceChanged"/>
        /// </summary>
        public event EventHandler<MapCustomExperienceChangedEventArgs> CustomExperienceChanged = (sender, args) => { };

        private void OnCustomExperienceChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapCustomExperienceChangedEventArgs args)
        {
            this.CustomExperienceChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapElementClick"/>
        /// </summary>
        public event EventHandler<MapElementClickEventArgs> MapElementClick = (sender, args) => { };

        private void OnMapElementClick(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs args)
        {
            this.MapElementClick?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapElementPointerEntered"/>
        /// </summary>
        public event EventHandler<MapElementPointerEnteredEventArgs> MapElementPointerEntered = (sender, args) => { };

        private void OnMapElementPointerEntered(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapElementPointerEnteredEventArgs args)
        {
            this.MapElementPointerEntered?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapElementPointerExited"/>
        /// </summary>
        public event EventHandler<MapElementPointerExitedEventArgs> MapElementPointerExited = (sender, args) => { };

        private void OnMapElementPointerExited(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapElementPointerExitedEventArgs args)
        {
            this.MapElementPointerExited?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.TargetCameraChanged"/>
        /// </summary>
        public event EventHandler<MapTargetCameraChangedEventArgs> TargetCameraChanged = (sender, args) => { };

        private void OnTargetCameraChanged(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapTargetCameraChangedEventArgs args)
        {
            this.TargetCameraChanged?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapRightTapped"/>
        /// </summary>
        public event EventHandler<MapRightTappedEventArgs> MapRightTapped = (sender, args) => { };

        private void OnMapRightTapped(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapRightTappedEventArgs args)
        {
            this.MapRightTapped?.Invoke(this, args);
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.Maps.MapControl.MapContextRequested"/>
        /// </summary>
        public event EventHandler<MapContextRequestedEventArgs> MapContextRequested = (sender, args) => { };

        private void OnMapContextRequested(windows.UI.Xaml.Controls.Maps.MapControl sender, windows.UI.Xaml.Controls.Maps.MapContextRequestedEventArgs args)
        {
            this.MapContextRequested?.Invoke(this, args);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<DependencyObject> Children { get; }
    }
}