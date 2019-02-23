// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    /// <summary>
    /// Enables access to active set of <seealso cref="Windows.UI.Xaml.Markup.IXamlMetadataProvider"/>
    /// </summary>
    public partial interface IXamlMetadataContainer
    {
        /// <summary>
        /// Gets the list of active <seealso cref="Windows.UI.Xaml.Markup.IXamlMetadataProvider"/>
        /// </summary>
        List<Windows.UI.Xaml.Markup.IXamlMetadataProvider> MetadataProviders { get; }
    }
}
