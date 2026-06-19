using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("c205bb48-5b1c-4219-a106-15bd0a5f24e2")]
public interface IUISimplePropertySet
{
	[PreserveSig]
	HRESULT GetValue([In] ref PropertyKey key, out PropVariant value);
}
