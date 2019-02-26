// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration"/>
    /// </summary>
    public class InkInputProcessingConfiguration
    {
        private windows.UI.Input.Inking.InkInputProcessingConfiguration uwpInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="InkInputProcessingConfiguration"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration"/>
        /// </summary>
        public InkInputProcessingConfiguration(windows.UI.Input.Inking.InkInputProcessingConfiguration instance)
        {
            this.uwpInstance = instance;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration.RightDragAction"/>
        /// </summary>
        public windows.UI.Input.Inking.InkInputRightDragAction RightDragAction
        {
            get => uwpInstance.RightDragAction;
            set => uwpInstance.RightDragAction = value;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration.Mode"/>
        /// </summary>
        public windows.UI.Input.Inking.InkInputProcessingMode Mode
        {
            get => uwpInstance.Mode;
            set => uwpInstance.Mode = value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration"/> to <see cref="InkInputProcessingConfiguration"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator InkInputProcessingConfiguration(
            windows.UI.Input.Inking.InkInputProcessingConfiguration args)
        {
            return FromInkInputProcessingConfiguration(args);
        }

        /// <summary>
        /// Creates a <see cref="InkInputProcessingConfiguration"/> from <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Input.Inking.InkInputProcessingConfiguration"/> instance containing the event data.</param>
        /// <returns><see cref="InkInputProcessingConfiguration"/></returns>
        public static InkInputProcessingConfiguration FromInkInputProcessingConfiguration(windows.UI.Input.Inking.InkInputProcessingConfiguration args)
        {
            return new InkInputProcessingConfiguration(args);
        }
    }
}