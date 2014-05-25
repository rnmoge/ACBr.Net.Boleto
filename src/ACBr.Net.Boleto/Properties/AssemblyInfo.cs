using System.Reflection;
using System.Runtime.Versioning;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if COM_INTEROP
[assembly: AssemblyTitle("ACBr.Net Boleto ActiveX")]
[assembly: AssemblyDescription("ACBr.Net Boleto ActiveX")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ACBr.Net")]
[assembly: AssemblyProduct("ACBr.Net Boleto ActiveX")]
[assembly: TypeLibVersion(109, 23)]
#else
[assembly: AssemblyTitle("ACBr.Net Boleto")]
[assembly: AssemblyDescription("ACBr.Net Boleto")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ACBr.Net")]
[assembly: AssemblyProduct("ACBr.Net Boleto")]
#endif

[assembly: AssemblyCopyright("Copyright © ACBr.Net 2014")]
[assembly: AssemblyTrademark("Projeto ACBr.Net https://github.com/ACBrNet")]
[assembly: AssemblyKeyFile(@"../acbr.net.snk")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
#if COM_INTEROP
[assembly: ComVisible(true)]
#else
[assembly: ComVisible(false)]
#endif

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("c479c289-31da-4e61-b80f-e69b03247213")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.9.1.0")]
[assembly: AssemblyFileVersion("0.9.1.5")]
//
//
[assembly: InternalsVisibleTo("ACBr.Net.Boleto.FastReport, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f74260d05a81ed3f35217680435c5b5e65dadf01ca0b54eae8a55ec6e120b40e45bd98f668ec1894f47bd93e7c7bc8dcfbc9c6f443507cce8092d59325ba403961936eb3d0a36d1171f49c605d185a80f4782525a957a3c509bbc369afa230330b74f7858f91dbd84a16389ea7fa602b4245203361e37d0b2e437fa5621762d7")]
