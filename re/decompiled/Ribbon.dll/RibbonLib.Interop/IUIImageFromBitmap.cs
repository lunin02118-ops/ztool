using System;
using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[Guid("18aba7f3-4c1c-4ba2-bf6c-f5c3326fa816")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IUIImageFromBitmap
{
	[PreserveSig]
	HRESULT CreateImage(IntPtr bitmap, Ownership options, [MarshalAs(UnmanagedType.Interface)] out IUIImage image);
}
