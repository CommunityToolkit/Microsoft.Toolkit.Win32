using System;

namespace Microsoft.Toolkit.Win32.UI.XamlHost
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Internal use only")]
#pragma warning disable CA1064 // Exceptions should be public
    internal sealed class ReflectionHelperException : Exception
#pragma warning restore CA1064 // Exceptions should be public
    {
        private static string reflectionExceptionMessage = @"Error in reflection helper.  Please add '<PropertyGroup><EnableTypeInfoReflection>false</EnableTypeInfoReflection></PropertyGroup>' to your project file.";

        public ReflectionHelperException(string message)
            : base($"{reflectionExceptionMessage}.  {message}")
        {
        }
    }
}