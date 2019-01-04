// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.ElementHighContrastAdjustment"/>
    /// </summary>
    [Flags]
#pragma warning disable CA1028 // Enum storage should be Int32
#pragma warning disable CA1714 // Flags enums should have plural names
    public enum ElementHighContrastAdjustment : uint
#pragma warning restore CA1714 // Flags enums should have plural names
#pragma warning restore CA1028 // Enum storage should be Int32
    {
        None = 0,
        Application = 2147483648,
        Auto = 4294967295,
    }
}