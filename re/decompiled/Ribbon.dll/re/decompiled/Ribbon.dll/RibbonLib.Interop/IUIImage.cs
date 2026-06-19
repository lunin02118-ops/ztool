using System;
using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[Guid("23c8c838-4de6-436b-ab01-5554bb7c30dd")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IUIImage
{
	[PreserveSig]
	HRESULT GetBitmap(out IntPtr bitmap);
}
