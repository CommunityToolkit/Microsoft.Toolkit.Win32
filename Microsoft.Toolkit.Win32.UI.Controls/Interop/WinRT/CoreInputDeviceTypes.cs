// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Core.CoreInputDeviceTypes"/>
    /// </summary>
    [Flags]
#pragma warning disable CA1028 // Enum storage should be Int32
    public enum CoreInputDeviceTypes : uint
#pragma warning restore CA1028 // Enum storage should be Int32
    {
        None = 0,
        Touch = 1,
        Pen = 2,
        Mouse = 4,
    }
}