// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Input.ManipulationModes"/>
    /// </summary>
    [Flags]
#pragma warning disable CA1028 // Enum storage should be Int32
    public enum ManipulationModes : uint
#pragma warning restore CA1028 // Enum storage should be Int32
    {
        None = 0,
        TranslateX = 1,
        TranslateY = 2,
        TranslateRailsX = 4,
        TranslateRailsY = 8,
        Rotate = 16,
        Scale = 32,
        TranslateInertia = 64,
        RotateInertia = 128,
        ScaleInertia = 256,
        All = 65535,
        System = 65536,
    }
}