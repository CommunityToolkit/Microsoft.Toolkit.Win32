// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Xaml.Input.Pointer"/>
    /// </summary>
    public class Pointer
    {
        private windows.UI.Xaml.Input.Pointer UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pointer"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Xaml.Input.Pointer"/>
        /// </summary>
        public Pointer(windows.UI.Xaml.Input.Pointer instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="windows.UI.Xaml.Input.Pointer.IsInContact"/>
        /// </summary>
        public bool IsInContact
        {
            get => UwpInstance.IsInContact;
        }

        /// <summary>
        /// Gets a value indicating whether <see cref="windows.UI.Xaml.Input.Pointer.IsInRange"/>
        /// </summary>
        public bool IsInRange
        {
            get => UwpInstance.IsInRange;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Input.Pointer.PointerDeviceType"/>
        /// </summary>
        public windows.Devices.Input.PointerDeviceType PointerDeviceType
        {
            get => UwpInstance.PointerDeviceType;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Input.Pointer.PointerId"/>
        /// </summary>
        public uint PointerId
        {
            get => UwpInstance.PointerId;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Xaml.Input.Pointer"/> to <see cref="Pointer"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Input.Pointer"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Pointer(
            windows.UI.Xaml.Input.Pointer args)
        {
            return FromPointer(args);
        }

        /// <summary>
        /// Creates a <see cref="Pointer"/> from <see cref="windows.UI.Xaml.Input.Pointer"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Xaml.Input.Pointer"/> instance containing the event data.</param>
        /// <returns><see cref="Pointer"/></returns>
        public static Pointer FromPointer(windows.UI.Xaml.Input.Pointer args)
        {
            return new Pointer(args);
        }
    }
}