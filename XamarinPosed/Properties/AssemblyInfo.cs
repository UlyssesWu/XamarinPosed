using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;
using Android.Runtime;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: MetaData("xposedmodule", Value = "true")]
[assembly: MetaData("xposeddescription", Value = "Xposed for Xamarin")]
[assembly: MetaData("xposedminversion", Value = "82")]
[assembly: NamespaceMapping(Java = "xamarin.posed", Managed = "Xamarin.Posed")]

[assembly: AssemblyTitle("XamarinPosed")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Xamarin.Posed")]
[assembly: AssemblyCopyright("Copyright © Ulysses 2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
