using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[TypeIdentifier]
[CompilerGenerated]
[Guid("9563DEA3-1ABB-4C3E-A5FD-983F8F1A2489")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ISwDMDocument
{
	void _VtblGap1_4();

	[DispId(5)]
	SwDMConfigurationMgr ConfigurationManager
	{
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap2_8();

	[return: MarshalAs(UnmanagedType.Struct)]
	object GetCustomPropertyNames();

	void _VtblGap3_1();

	void CloseDoc();

	void _VtblGap4_17();

	SwDmDocumentSaveError Save();
}
