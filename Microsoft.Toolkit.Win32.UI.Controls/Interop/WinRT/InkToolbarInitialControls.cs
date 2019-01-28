// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Controls.InkToolbarInitialControls"/>
    /// </summary>
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum InkToolbarInitialControls
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        All = 0,
        None = 1,
        PensOnly = 2,
        AllExceptPens = 3,
    }
}