using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.Toolkit.Win32.UI.Tools
{
    public class GenerateWinRTManifest : Microsoft.Build.Utilities.AppDomainIsolatedTask
    {
        private bool _success = true;

        public virtual bool Success
        {
            get
            {
                return _success;
            }

            set
            {
                _success = value;
            }
        }

        private string _appxManifest;

        public virtual string AppxManifest
        {
            get
            {
                return _appxManifest;
            }

            set
            {
                _appxManifest = value;
            }
        }

        private string _winMDReferences;

        public virtual string WinMDReferences
        {
            get
            {
                return _winMDReferences;
            }

            set
            {
                _winMDReferences = value;
            }
        }

        private string _targetDir;

        public virtual string TargetDir
        {
            get
            {
                return _targetDir;
            }

            set
            {
                _targetDir = value;
            }
        }

        private string _destinationFolder;

        public virtual string DestinationFolder
        {
            get
            {
                return _destinationFolder;
            }

            set
            {
                _destinationFolder = value;
            }
        }

        public override bool Execute()
        {
            var headerF = @"<?xml version='1.0' encoding='utf-8' standalone='yes'?>
<assembly
  manifestVersion='1.0'
  xmlns:asmv3='urn:schemas-microsoft-com:asm.v3'
  xmlns='urn:schemas-microsoft-com:asm.v1'>
  <trustInfo xmlns='urn:schemas-microsoft-com:asm.v2'>
    <security>
      <requestedPrivileges xmlns='urn:schemas-microsoft-com:asm.v3'>
        <requestedExecutionLevel level='asInvoker' uiAccess='false' />
      </requestedPrivileges>
    </security>
  </trustInfo>
  <compatibility xmlns='urn:schemas-microsoft-com:compatibility.v1'>
    <application>
      <maxversiontested Id='10.0.18362.0'/>
      <supportedOS Id='{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}' />
    </application>
  </compatibility>
  <application xmlns='urn:schemas-microsoft-com:asm.v3'>
    <windowsSettings>
      <dpiAware xmlns='http://schemas.microsoft.com/SMI/2005/WindowsSettings'>true/PM</dpiAware>
      <dpiAwareness xmlns='http://schemas.microsoft.com/SMI/2016/WindowsSettings'>PerMonitorV2, PerMonitor</dpiAwareness>
    </windowsSettings>
  </application>";
            var sb = new StringBuilder();
            sb.Append(headerF);

            bool foundXamlHost = false;

            const string fileStart = @"    <asmv3:file name='{0}'>";
            const string fileEntry = @"
        <activatableClass
            name='{0}'
            threadingModel='both'
            xmlns='urn:schemas-microsoft-com:winrt.v1'/>";
            const string fileEnd = @"
    </asmv3:file>
";

            if (!string.IsNullOrEmpty(AppxManifest))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(AppxManifest);
                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("m", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");
                var xQuery = "./m:Package/m:Extensions/m:Extension/m:InProcessServer";

                foreach (XmlNode winRTFactory in doc.SelectNodes(xQuery, nsmgr))
                {
                    var dllPathNode = winRTFactory.SelectSingleNode("./m:Path", nsmgr);
                    var dllPath = dllPathNode.InnerText;
                    if (!foundXamlHost)
                    {
                        foundXamlHost = string.Compare(dllPath, "Microsoft.Toolkit.Win32.UI.XamlHost.dll", true) == 0;
                    }

                    var typesNames = winRTFactory.SelectNodes("./m:ActivatableClass", nsmgr).OfType<XmlNode>();
                    var xmlHeader = string.Format(fileStart, dllPath);
                    sb.Append(xmlHeader);
                    foreach (var typeNode in typesNames)
                    {
                        var attribs = typeNode.Attributes.OfType<XmlAttribute>().ToArray();
                        var typeName = attribs
                            .OfType<XmlAttribute>()
                            .SingleOrDefault(x => x.Name == "ActivatableClassId")
                            .InnerText;
                        var xmlEntry = string.Format(fileEntry, typeName);
                        sb.Append(xmlEntry);
                    }

                    sb.Append(fileEnd);
                }
            }
            else if (!string.IsNullOrEmpty(WinMDReferences))
            {
                var references = WinMDReferences.Replace("\\\\", "\\").Split(';');

                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += (sender, eventArgs) => Assembly.ReflectionOnlyLoad(eventArgs.Name);
                WindowsRuntimeMetadata.ReflectionOnlyNamespaceResolve += (sender, eventArgs) =>
                {
                    string path =
                        WindowsRuntimeMetadata.ResolveNamespace(eventArgs.NamespaceName, references)
                            .FirstOrDefault();
                    if (path == null)
                    {
                        return;
                    }

                    eventArgs.ResolvedAssemblies.Add(Assembly.ReflectionOnlyLoadFrom(path));
                };

                var referencesInfo = references.Select(f => new FileInfo(f));
                var winMDreferences = referencesInfo
                    .Where(f => string.Equals(f.Extension, ".winmd", StringComparison.OrdinalIgnoreCase))
                    .Where(f => !f.Name.StartsWith("Windows", StringComparison.OrdinalIgnoreCase));
                foreach (var winMDFile in winMDreferences)
                {
                    string fullAssemblyPath = winMDFile.FullName;
                    var exportedTypes = Enumerable.Empty<Type>();
                    try
                    {
                        var loadedAssembly = Assembly.ReflectionOnlyLoadFrom(fullAssemblyPath);
                        exportedTypes = loadedAssembly.GetTypes();
                    }
                    catch (Exception)
                    {
                    }

                    if (winMDFile.Name.StartsWith("Microsoft.Toolkit.Win32.UI.XamlHost", StringComparison.InvariantCultureIgnoreCase))
                    {
                        foundXamlHost = true;
                    }

                    var appendEnd = false;
                    foreach (var type in exportedTypes)
                    {
                        bool isVisible = false;
                        var attributes = CustomAttributeData.GetCustomAttributes(type);
                        foreach (var attrib in attributes)
                        {
                            var attributeString = attrib.ToString();
                            if (attributeString.Contains("Windows.Foundation.Metadata.ComposableAttribute") ||
                                attributeString.Contains("Windows.Foundation.Metadata.ActivatableAttribute") ||
                                attributeString.Contains("Windows.Foundation.Metadata.StaticAttribute"))
                            {
                                isVisible = true;
                            }
                        }

                        if (isVisible)
                        {
                            if (!appendEnd)
                            {
                                appendEnd = true;

                                var implementationDll = winMDFile.Name.Replace(".winmd", ".dll");
                                var xmlHeader = string.Format(fileStart, implementationDll);
                                sb.Append(xmlHeader);
                            }

                            var xmlEntry = string.Format(fileEntry, type.FullName);
                            sb.Append(xmlEntry);
                        }
                    }

                    if (appendEnd)
                    {
                        sb.Append(fileEnd);
                    }
                }
            }

            if (!foundXamlHost)
            {
                sb.Append(@"
    <asmv3:file name='Microsoft.Toolkit.Win32.UI.XamlHost.dll'>
        <activatableClass
            name='Microsoft.Toolkit.Win32.UI.XamlHost.XamlApplication'
            threadingModel='both'
            xmlns='urn:schemas-microsoft-com:winrt.v1'/>
        <activatableClass
            name='Microsoft.Toolkit.Win32.UI.XamlHost.DesktopWindow'
            threadingModel='both'
            xmlns='urn:schemas-microsoft-com:winrt.v1'/>
    </asmv3:file>");
            }

            var xmlFooterF = @"
</assembly>";
            sb.Append(xmlFooterF);
            var manifestContent = sb.ToString();
            var outFileName = Path.Combine(DestinationFolder, "app.manifest");
            File.WriteAllText(outFileName, manifestContent, Encoding.UTF8);

            return _success;
        }
    }
}
