// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Composition.AnimationPropertyInfo"/>
    /// </summary>
    public class AnimationPropertyInfo
    {
        private windows.UI.Composition.AnimationPropertyInfo uwpInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimationPropertyInfo"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Composition.AnimationPropertyInfo"/>
        /// </summary>
        public AnimationPropertyInfo(windows.UI.Composition.AnimationPropertyInfo instance)
        {
            this.uwpInstance = instance;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Composition.AnimationPropertyInfo.AccessMode"/>
        /// </summary>
        public windows.UI.Composition.AnimationPropertyAccessMode AccessMode
        {
            get => uwpInstance.AccessMode;
            set => uwpInstance.AccessMode = value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Composition.AnimationPropertyInfo"/> to <see cref="AnimationPropertyInfo"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Composition.AnimationPropertyInfo"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator AnimationPropertyInfo(
            windows.UI.Composition.AnimationPropertyInfo args)
        {
            return FromAnimationPropertyInfo(args);
        }

        /// <summary>
        /// Creates a <see cref="AnimationPropertyInfo"/> from <see cref="windows.UI.Composition.AnimationPropertyInfo"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Composition.AnimationPropertyInfo"/> instance containing the event data.</param>
        /// <returns><see cref="AnimationPropertyInfo"/></returns>
        public static AnimationPropertyInfo FromAnimationPropertyInfo(windows.UI.Composition.AnimationPropertyInfo args)
        {
            return new AnimationPropertyInfo(args);
        }
    }
}