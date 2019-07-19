using System;
using System.Collections.Generic;
using System.Reflection;
using Windows.UI.Xaml.Markup;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    public abstract class DesktopApp : XamlApplication, global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private readonly ReflectionXamlMetadataProvider reflectionXamlMetadataProvider;

        protected DesktopApp()
        {
            this.reflectionXamlMetadataProvider = new ReflectionXamlMetadataProvider();
        }

        public IXamlType GetXamlType(Type type)
        {
            return reflectionXamlMetadataProvider.GetXamlType(type);
        }

        public IXamlType GetXamlType(string fullName)
        {
            return reflectionXamlMetadataProvider.GetXamlType(fullName);
        }

        public XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return reflectionXamlMetadataProvider.GetXmlnsDefinitions();
        }
    }
}
