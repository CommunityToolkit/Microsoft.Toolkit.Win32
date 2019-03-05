// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using WUX = Windows.UI.Xaml;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    /// <summary>
    /// Enables access to active set of <seealso cref="WUX.Markup.IXamlMetadataProvider"/>
    /// </summary>
    public partial interface IXamlMetadataContainer
    {
        /// <summary>
        /// Gets the list of active <seealso cref="WUX.Markup.IXamlMetadataProvider"/>
        /// </summary>
        List<WUX.Markup.IXamlMetadataProvider> MetadataProviders { get; }
    }
}
