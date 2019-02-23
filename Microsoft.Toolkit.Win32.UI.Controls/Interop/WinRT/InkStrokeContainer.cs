// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Input.Inking.InkStrokeContainer"/>
    /// </summary>
    public class InkStrokeContainer
    {
        private windows.UI.Input.Inking.InkStrokeContainer uwpInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="InkStrokeContainer"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Input.Inking.InkStrokeContainer"/>
        /// </summary>
        public InkStrokeContainer(windows.UI.Input.Inking.InkStrokeContainer instance)
        {
            this.uwpInstance = instance;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Input.Inking.InkStrokeContainer.BoundingRect"/>
        /// </summary>
        public windows.Foundation.Rect BoundingRect
        {
            get => uwpInstance.BoundingRect;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Input.Inking.InkStrokeContainer"/> to <see cref="InkStrokeContainer"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Input.Inking.InkStrokeContainer"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator InkStrokeContainer(
            windows.UI.Input.Inking.InkStrokeContainer args)
        {
            return FromInkStrokeContainer(args);
        }

        /// <summary>
        /// Creates a <see cref="InkStrokeContainer"/> from <see cref="windows.UI.Input.Inking.InkStrokeContainer"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Input.Inking.InkStrokeContainer"/> instance containing the event data.</param>
        /// <returns><see cref="InkStrokeContainer"/></returns>
        public static InkStrokeContainer FromInkStrokeContainer(windows.UI.Input.Inking.InkStrokeContainer args)
        {
            return new InkStrokeContainer(args);
        }
    }
}