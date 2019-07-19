using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml.Markup;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    internal sealed class XamlReflectionType : IXamlType, IXamlType2
    {
        private const string NullableTypeName = "System.Nullable`1";
        private const string ReferenceTypeName = "Windows.Foundation.IReference`1";

        private enum EnumType
        {
            SByte,
            Byte,
            Int16,
            UInt16,
            Int32,
            UInt32,
            Int64,
            UInt64,
        }

        private static TypeInfo iListTypeInfo = typeof(System.Collections.IList).GetTypeInfo();
        private static TypeInfo iDictionaryTypeInfo = typeof(System.Collections.IDictionary).GetTypeInfo();
        private static TypeInfo markupExtTypeInfo = typeof(global::Windows.UI.Xaml.Markup.MarkupExtension).GetTypeInfo();
        private static TypeInfo iEnumerableTypeInfo = typeof(System.Collections.IEnumerable).GetTypeInfo();

        private Type _underlyingType;
        private TypeInfo _info;
        private Dictionary<string, IXamlMember> _members = null;
        private string _fullName = null;
        private MethodInfo _adderInfo = null;

        private MethodInfo _createFromStringMethod = null;
        private bool _gotCreateFromStringMethod = false;

        private IXamlMember _contentProperty;
        private bool _gotContentProperty = false;

        private IXamlType _baseType;
        private bool _gotBaseType = false;

        private IXamlType _boxedType;
        private bool _gotBoxedType = false;

        private EnumType? _enumType = null;

        private XamlReflectionType(System.Type underlyingType)
        {
            _underlyingType = underlyingType;
            _info = _underlyingType.GetTypeInfo();

            _fullName = TypeExtensions.GetFullGenericNestedName(_underlyingType);

            IsMarkupExtension = markupExtTypeInfo.IsAssignableFrom(_info);
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(_underlyingType.TypeHandle);

            var types = _underlyingType.GetTypeInfo().ImplementedInterfaces;
            Type genCollectionType = null, genDictionaryType = null, genListType = null;

            foreach (var t in types)
            {
                string typeName = t.FullName;
                if (genCollectionType == null && typeName.StartsWith("System.Collections.Generic.ICollection`1", StringComparison.InvariantCulture))
                {
                    genCollectionType = t;
                }
                else if (genDictionaryType == null && typeName.StartsWith("System.Collections.Generic.IDictionary`2", StringComparison.InvariantCulture))
                {
                    genDictionaryType = t;
                }
                else if (genListType == null && typeName.StartsWith("System.Collections.Generic.IList`1", StringComparison.InvariantCulture))
                {
                    genListType = t;
                }
            }

            bool isIList = false, isDictionary = false, isEnumerable = false;
            isIList = iListTypeInfo.IsAssignableFrom(_info);
            isDictionary = iDictionaryTypeInfo.IsAssignableFrom(_info);
            isEnumerable = iEnumerableTypeInfo.IsAssignableFrom(_info);

            // First, check if the type really is a dictionary/collection/list
            IsCollection = genCollectionType != null || genListType != null || isIList;
            IsDictionary = isDictionary || genDictionaryType != null;

            if (IsDictionary)
            {
                if (genDictionaryType != null)
                {
                    ItemType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(genDictionaryType.GetTypeInfo().GenericTypeArguments[0]);
                    KeyType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(genDictionaryType.GetTypeInfo().GenericTypeArguments[1]);
                }
                else
                {
                    ItemType = KeyType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(typeof(object));
                }
            }
            else if (IsCollection)
            {
                if (genListType != null)
                {
                    ItemType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(genListType.GetTypeInfo().GenericTypeArguments[0]);
                }
                else if (genCollectionType != null)
                {
                    ItemType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(genCollectionType.GetTypeInfo().GenericTypeArguments[0]);
                }
                else
                {
                    ItemType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(typeof(object));
                }
            }

            // We need to check and store the Add method for two reasons:
            // 1. If the type doesn't implement a collection/dictionary interface, we also consider IEnumerables
            //    with an Add method to be a dictionary/collection, so check that as well
            // 2. For types that are collections/dictionaries, we need to store their add method to invoke it later in our collection/dictionary adders
            if (IsCollection || IsDictionary || isEnumerable)
            {
                // Somewhat hacky - in most cases, GetRuntimeMethods will correctly find the Add method on the object's type.
                // However, Windows.UI.Xaml.DependencyObjectCollection doesn't report an Add method from GetRuntimeMethods,
                // even though it implements ICollection<>.  What *does* work is getting the method from the ICollection<> interface instead.
                // We concat the methods of the actual type and its relevant collection/dictionary interface so that ideally
                // we get the Add method directly from the object, but otherwise use the one from the interface.
                // In case this can happen with other types, we do the same thing for dictionaries.  We don't need to
                // check for IList<>/GenListType since IList<> inherits from ICollection<>, and ICollection<>
                // is the interface with Add on it.
                IEnumerable<MethodInfo> typeMethods = _underlyingType.GetRuntimeMethods();
                IEnumerable<MethodInfo> interfaceMethods = null;

                if (genCollectionType != null)
                {
                    interfaceMethods = genCollectionType.GetRuntimeMethods();
                }
                else if (genDictionaryType != null)
                {
                    interfaceMethods = genListType.GetRuntimeMethods();
                }

                List<MethodInfo> concatList;
                if (interfaceMethods == null)
                {
                    concatList = typeMethods.ToList();
                }
                else
                {
                    concatList = typeMethods.Concat(interfaceMethods).ToList();
                }

                foreach (MethodInfo mi in concatList)
                {
                    if (mi.IsPublic && mi.Name.Equals("Add", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ParameterInfo[] paramInfo = mi.GetParameters();

                        // First handle the IEnumerable case where we need to determine whether the Add method
                        // indicates a collection or dictionary
                        if (isEnumerable && !IsCollection && !IsDictionary)
                        {
                            if (paramInfo.Length == 1)
                            {
                                IsCollection = true;
                                ItemType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(paramInfo[0].ParameterType);
                            }
                            else if (paramInfo.Length == 2)
                            {
                                IsDictionary = true;
                                KeyType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(paramInfo[0].ParameterType);
                                ItemType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(paramInfo[1].ParameterType);
                            }
                        }

                        // Next, store the add method
                        _adderInfo = mi;
                        break;
                    }
                }
            }

            IsConstructible = HasActivatableAttribute();
            IsBindable = HasBindableAttribute();
        }

        public static XamlReflectionType Create(System.Type typeID)
        {
            if (typeID == null)
            {
                return null;
            }

            return new XamlReflectionType(typeID);
        }

        public string FullName
        {
            get
            {
                return _fullName;
            }
        }

        public System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        public IXamlType BaseType
        {
            get
            {
                if (!_gotBaseType)
                {
                    _gotBaseType = true;
                    if (_info.BaseType == null || _info.BaseType.FullName == "System.Runtime.InteropServices.WindowsRuntime.RuntimeClass")
                    {
                        _baseType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(typeof(object));
                    }
                    else
                    {
                        _baseType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(_info.BaseType);
                    }
                }

                return _baseType;
            }
        }

        public IXamlType BoxedType
        {
            get
            {
                if (!_gotBoxedType)
                {
                    _gotBoxedType = true;
                    if (FullName.StartsWith(NullableTypeName, StringComparison.InvariantCulture) || FullName.StartsWith(ReferenceTypeName, StringComparison.InvariantCulture))
                    {
                        Type innerType = _info.GenericTypeArguments[0];
                        _boxedType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(innerType);
                    }
                    else
                    {
                        _boxedType = null;
                    }
                }

                return _boxedType;
            }
        }

        public IXamlMember ContentProperty
        {
            get
            {
                if (!_gotContentProperty)
                {
                    _gotContentProperty = true;
                    string memberName = GetStringNamedArgumentFromAttribute("Windows.UI.Xaml.Markup.ContentPropertyAttribute", "Name");
                    if (memberName != null)
                    {
                        _contentProperty = GetMember(GetStringNamedArgumentFromAttribute("Windows.UI.Xaml.Markup.ContentPropertyAttribute", "Name"));
                    }
                }

                return _contentProperty;
            }
        }

        public IXamlMember GetMember(string name)
        {
            IXamlMember member = null;
            if (_members == null)
            {
                _members = new Dictionary<string, IXamlMember>();
            }
            else
            {
                if (_members.TryGetValue(name, out member))
                {
                    return member;
                }
            }

            member = XamlReflectionMember.Create(name, _underlyingType);
            _members.Add(name, member);
            return member;
        }

        public bool IsArray
        {
            get
            {
                return _underlyingType.IsArray;
            }
        }

        public bool IsCollection { get; }

        public bool IsConstructible { get; }

        public bool IsDictionary { get; }

        public bool IsMarkupExtension { get; }

        public bool IsBindable { get; }

        public IXamlType ItemType { get; }

        public IXamlType KeyType { get; }

        public object ActivateInstance()
        {
            return System.Activator.CreateInstance(_underlyingType);
        }

        public void AddToMap(object instance, object key, object value)
        {
            _adderInfo.Invoke(instance, new object[] { key, value });
        }

        public void AddToVector(object instance, object value)
        {
            _adderInfo.Invoke(instance, new object[] { value });
        }

        public void RunInitializer()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(_underlyingType.TypeHandle);
        }

        public object CreateFromString(string value)
        {
            if (!_gotCreateFromStringMethod)
            {
                _gotCreateFromStringMethod = true;
                string createFromStringMethodName = GetStringNamedArgumentFromAttribute("Windows.Foundation.Metadata.CreateFromStringAttribute", "MethodName");
                Type finalMethodOwnerType = null;
                string finalMethodName = null;
                if (createFromStringMethodName != null)
                {
                    // Case 1 - a method name with no dots, so the method is implicitly declared on the type
                    int lastDotIndex = createFromStringMethodName.LastIndexOf('.');
                    if (lastDotIndex == -1)
                    {
                        finalMethodOwnerType = _underlyingType;
                        finalMethodName = createFromStringMethodName;
                    }
                    else
                    {
                        int firstPlusIndex = createFromStringMethodName.IndexOf("+", StringComparison.InvariantCulture);
                        if (firstPlusIndex == -1)
                        {
                            // Case 2 - a fully qualified method name without a nested class. Grab the method name from the end and lookup the type from the rest
                            string typeName = createFromStringMethodName.Substring(0, lastDotIndex);
                            string methodName = createFromStringMethodName.Substring(lastDotIndex + 1);
                            finalMethodOwnerType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(typeName).UnderlyingType;
                            finalMethodName = methodName;
                        }
                        else
                        {
                            // Case 3 - the method is on a nested class, split it up into the base class, nested classes, and the last nested class + method name
                            // E.g. a createFromStringMethodName could look like "FooNamespace.FooClass+NestedFooClass+NestedBarClass.CreateFromStringMethod"
                            string[] plusSplit = createFromStringMethodName.Split('+');
                            string baseClassName = plusSplit[0];

                            Type currentMethodOwnerType = ReflectionXamlMetadataProvider.GetXamlTypeInternal(baseClassName).UnderlyingType;

                            // Now, traverse the rest of the nested classes except for the last one, which we need to parse specially since it also includes the method name
                            for (int i = 1; i < plusSplit.Length - 1; i++)
                            {
                                currentMethodOwnerType = currentMethodOwnerType.GetTypeInfo().GetDeclaredNestedType(plusSplit[i]).AsType();
                            }

                            // At this point we're at the last element, which looks like "NestedBarClass.CreateFromStringMethod"
                            // Split the string into two parts based on the middle '.', get the nested class, then get the method on the final nested class
                            string nestedLeafString = plusSplit[plusSplit.Length - 1];
                            int lastDotIndexNestedLeaf = nestedLeafString.LastIndexOf('.');

                            string leafTypeName = nestedLeafString.Substring(0, lastDotIndexNestedLeaf);
                            string leafMethodName = nestedLeafString.Substring(lastDotIndexNestedLeaf + 1);

                            finalMethodOwnerType = currentMethodOwnerType.GetTypeInfo().GetDeclaredNestedType(leafTypeName).AsType();
                            finalMethodName = leafMethodName;
                        }
                    }

                    _createFromStringMethod = finalMethodOwnerType.GetRuntimeMethod(finalMethodName, new Type[1] { typeof(string) });
                }
            }

            if (BoxedType == null)
            {
                if (_createFromStringMethod != null)
                {
                    return _createFromStringMethod.Invoke(null, new object[1] { value });
                }
                else
                {
                    return ParseEnumValue(value);
                }
            }
            else
            {
                // For boxed types, call the CreateFromString method on the inner type instead, and box the result of that by
                // invoking the boxed type's constructor.
                object innerCreateFromString = BoxedType.CreateFromString(value);
                foreach (ConstructorInfo ci in _info.DeclaredConstructors)
                {
                    ParameterInfo[] piArr = ci.GetParameters();
                    if (piArr.Length == 1 && piArr[0].ParameterType.Equals(_info.GenericTypeArguments[0]))
                    {
                        return ci.Invoke(new object[1] { innerCreateFromString });
                    }
                }

                throw new ReflectionHelperException($"Couldn't locate appropriate boxing constructor for boxed type '{FullName}'");
            }
        }

        // Given a string value of an enum, parses it and returns an object corresponding to its value.
        private object ParseEnumValue(string value)
        {
            // Enum property values may be either a single enum value, or a comma separated list of values if the enum type represents
            // a list of bit flags.  If it represents bitwise flags, break up the full string into a list of enum values to apply.
            const char enumDelimiter = ',';
            string[] valueParts = value.Split(enumDelimiter);

            if (_enumType == null)
            {
                var actualEnumType = Enum.GetUnderlyingType(_underlyingType);

                if (actualEnumType.Equals(typeof(sbyte)))
                {
                    _enumType = EnumType.SByte;
                }
                else if (actualEnumType.Equals(typeof(byte)))
                {
                    _enumType = EnumType.Byte;
                }
                else if (actualEnumType.Equals(typeof(short)))
                {
                    _enumType = EnumType.Int16;
                }
                else if (actualEnumType.Equals(typeof(ushort)))
                {
                    _enumType = EnumType.UInt16;
                }
                else if (actualEnumType.Equals(typeof(int)))
                {
                    _enumType = EnumType.Int32;
                }
                else if (actualEnumType.Equals(typeof(uint)))
                {
                    _enumType = EnumType.UInt32;
                }
                else if (actualEnumType.Equals(typeof(long)))
                {
                    _enumType = EnumType.Int64;
                }
                else if (actualEnumType.Equals(typeof(ulong)))
                {
                    _enumType = EnumType.UInt64;
                }
                else
                {
                    // We should never get here, as it means we were unable to resolve the enum type.  Our best guess
                    // is that it's a signed int, which is the most common enum.
                    _enumType = EnumType.Int32;
                }
            }

            switch (_enumType)
            {
                case EnumType.SByte:
                    {
                        return (sbyte)ProcessEnumStringSigned(valueParts, _underlyingType);
                    }

                case EnumType.Byte:
                    {
                        return (byte)ProcessEnumStringUnsigned(valueParts, _underlyingType);
                    }

                case EnumType.Int16:
                    {
                        return (short)ProcessEnumStringSigned(valueParts, _underlyingType);
                    }

                case EnumType.UInt16:
                    {
                        return (ushort)ProcessEnumStringUnsigned(valueParts, _underlyingType);
                    }

                case EnumType.Int32:
                    {
                        return (int)ProcessEnumStringSigned(valueParts, _underlyingType);
                    }

                case EnumType.UInt32:
                    {
                        return (uint)ProcessEnumStringUnsigned(valueParts, _underlyingType);
                    }

                case EnumType.Int64:
                    {
                        return ProcessEnumStringSigned(valueParts, _underlyingType);
                    }

                case EnumType.UInt64:
                    {
                        return ProcessEnumStringUnsigned(valueParts, _underlyingType);
                    }

                default:
                    throw new ReflectionHelperException($"Couldn't resolve underlying enum type for type '{_underlyingType.FullName}'");
            }
        }

        private ulong ProcessEnumStringUnsigned(IEnumerable<string> parts, Type underlyingType)
        {
            var finalValue = default(ulong);
            foreach (string valuePart in parts)
            {
                object enumValue = Enum.Parse(underlyingType, valuePart.Trim());
                var fieldVal = System.Convert.ToUInt64(enumValue, CultureInfo.InvariantCulture);
                finalValue |= fieldVal;
            }

            return finalValue;
        }

        private long ProcessEnumStringSigned(IEnumerable<string> parts, Type underlyingType)
        {
            var finalValue = default(long);
            foreach (string valuePart in parts)
            {
                object enumValue = Enum.Parse(underlyingType, valuePart.Trim());
                var fieldVal = System.Convert.ToInt64(enumValue, CultureInfo.InvariantCulture);
                finalValue |= fieldVal;
            }

            return finalValue;
        }

        private bool HasActivatableAttribute()
        {
            return HasAttribute("Windows.Foundation.Metadata.ActivatableAttribute");
        }

        private bool HasBindableAttribute()
        {
            return HasAttribute("Windows.UI.Xaml.Data.BindableAttribute");
        }

        private string GetStringNamedArgumentFromAttribute(string attributeTypeName, string attributeTypedArgName)
        {
            foreach (CustomAttributeData custData in _info.CustomAttributes)
            {
                if (custData.AttributeType.FullName == attributeTypeName)
                {
                    foreach (CustomAttributeNamedArgument namedArg in custData.NamedArguments)
                    {
                        if (namedArg.MemberName.Equals(attributeTypedArgName, StringComparison.InvariantCulture))
                        {
                            string argVal = namedArg.TypedValue.Value as string;
                            return argVal;
                        }
                    }
                }
            }

            return null;
        }

        private bool HasAttribute(string attrName)
        {
            foreach (CustomAttributeData custData in _info.CustomAttributes)
            {
                if (custData.AttributeType.FullName == attrName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}