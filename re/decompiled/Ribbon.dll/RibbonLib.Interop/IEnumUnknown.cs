using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("00000100-0000-0000-C000-000000000046")]
public interface IEnumUnknown
{
	[PreserveSig]
	HRESULT Next([In][MarshalAs(UnmanagedType.U4)] uint celt, [Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] object[] rgelt, [MarshalAs(UnmanagedType.U4)] out uint pceltFetched);

	[PreserveSig]
	HRESULT Skip([In][MarshalAs(UnmanagedType.U4)] uint celt);

	[PreserveSig]
	HRESULT Reset();

	[PreserveSig]
	HRESULT Clone(out IEnumUnknown ppenum);
}
