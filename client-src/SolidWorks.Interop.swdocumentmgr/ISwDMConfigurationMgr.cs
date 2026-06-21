using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("6C2E5743-A4D8-49F9-8DBD-86C53B68C01D")]
[CompilerGenerated]
[TypeIdentifier]
public interface ISwDMConfigurationMgr
{
	void _VtblGap1_3();

	[return: MarshalAs(UnmanagedType.Interface)]
	SwDMConfiguration GetConfigurationByName([In][MarshalAs(UnmanagedType.BStr)] string ConfigurationName);

	[return: MarshalAs(UnmanagedType.Struct)]
	object GetConfigurationNames();

	[return: MarshalAs(UnmanagedType.BStr)]
	string GetActiveConfigurationName();
}
