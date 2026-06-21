using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SolidWorks.Interop.swdocumentmgr;

[ComImport]
[TypeIdentifier]
[Guid("F5EE7D1E-C1D2-4BCE-8ABE-5B5E9E6358CA")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[CompilerGenerated]
public interface ISwDMConfiguration8 : ISwDMConfiguration7
{
	void _VtblGap1_11();

	[return: MarshalAs(UnmanagedType.Struct)]
	object GetCustomPropertyNames();

	[return: MarshalAs(UnmanagedType.IDispatch)]
	object GetPreviewBitmap(out SwDmPreviewError result);

	void _VtblGap2_8();

	[return: MarshalAs(UnmanagedType.Struct)]
	new object GetComponents();

	void _VtblGap3_17();

	void GetReferencesInformation2([MarshalAs(UnmanagedType.Struct)] out object references, [MarshalAs(UnmanagedType.Struct)] out object configurations, [MarshalAs(UnmanagedType.Struct)] out object sstates, [MarshalAs(UnmanagedType.Struct)] out object IsVirtual);
}
