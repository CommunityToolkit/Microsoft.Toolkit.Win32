// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using windows = Windows;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    /// <summary>
    /// <see cref="windows.UI.Input.Inking.InkDrawingAttributes"/>
    /// </summary>
    public class InkDrawingAttributes
    {
        private windows.UI.Input.Inking.InkDrawingAttributes UwpInstance { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InkDrawingAttributes"/> class, a
        /// Wpf-enabled wrapper for <see cref="windows.UI.Input.Inking.InkDrawingAttributes"/>
        /// </summary>
        public InkDrawingAttributes(windows.UI.Input.Inking.InkDrawingAttributes instance)
        {
            this.UwpInstance = instance;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Input.Inking.InkDrawingAttributes.Size"/>
        /// </summary>
        public windows.Foundation.Size Size
        {
            get => UwpInstance.Size;
            set => UwpInstance.Size = value;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Input.Inking.InkDrawingAttributes.PenTip"/>
        /// </summary>
        public windows.UI.Input.Inking.PenTipShape PenTip
        {
            get => UwpInstance.PenTip;
            set => UwpInstance.PenTip = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Input.Inking.InkDrawingAttributes.IgnorePressure"/>
        /// </summary>
        public bool IgnorePressure
        {
            get => UwpInstance.IgnorePressure;
            set => UwpInstance.IgnorePressure = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Input.Inking.InkDrawingAttributes.FitToCurve"/>
        /// </summary>
        public bool FitToCurve
        {
            get => UwpInstance.FitToCurve;
            set => UwpInstance.FitToCurve = value;
        }

        /// <summary>
        /// Gets or sets <see cref="windows.UI.Input.Inking.InkDrawingAttributes.Color"/>
        /// </summary>
        public windows.UI.Color Color
        {
            get => UwpInstance.Color;
            set => UwpInstance.Color = value;
        }

        /*
        /// <summary>
        /// Gets or sets <see cref="windows.UI.Input.Inking.InkDrawingAttributes.PenTipTransform"/>
        /// </summary>
        public System.Numerics.Matrix3x2 PenTipTransform
        {
            get => UwpInstance.PenTipTransform;
            set => UwpInstance.PenTipTransform = value;
        }
        */

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Input.Inking.InkDrawingAttributes.DrawAsHighlighter"/>
        /// </summary>
        public bool DrawAsHighlighter
        {
            get => UwpInstance.DrawAsHighlighter;
            set => UwpInstance.DrawAsHighlighter = value;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Input.Inking.InkDrawingAttributes.Kind"/>
        /// </summary>
        public windows.UI.Input.Inking.InkDrawingAttributesKind Kind
        {
            get => UwpInstance.Kind;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Input.Inking.InkDrawingAttributes.PencilProperties"/>
        /// </summary>
        public windows.UI.Input.Inking.InkDrawingAttributesPencilProperties PencilProperties
        {
            get => UwpInstance.PencilProperties;
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="windows.UI.Input.Inking.InkDrawingAttributes.IgnoreTilt"/>
        /// </summary>
        public bool IgnoreTilt
        {
            get => UwpInstance.IgnoreTilt;
            set => UwpInstance.IgnoreTilt = value;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Input.Inking.InkDrawingAttributes.ModelerAttributes"/>
        /// </summary>
        public windows.UI.Input.Inking.InkModelerAttributes ModelerAttributes
        {
            get => UwpInstance.ModelerAttributes;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="windows.UI.Input.Inking.InkDrawingAttributes"/> to <see cref="InkDrawingAttributes"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Input.Inking.InkDrawingAttributes"/> instance containing the event data.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator InkDrawingAttributes(
            windows.UI.Input.Inking.InkDrawingAttributes args)
        {
            return FromInkDrawingAttributes(args);
        }

        /// <summary>
        /// Creates a <see cref="InkDrawingAttributes"/> from <see cref="windows.UI.Input.Inking.InkDrawingAttributes"/>.
        /// </summary>
        /// <param name="args">The <see cref="windows.UI.Input.Inking.InkDrawingAttributes"/> instance containing the event data.</param>
        /// <returns><see cref="InkDrawingAttributes"/></returns>
        public static InkDrawingAttributes FromInkDrawingAttributes(windows.UI.Input.Inking.InkDrawingAttributes args)
        {
            return new InkDrawingAttributes(args);
        }
    }
}