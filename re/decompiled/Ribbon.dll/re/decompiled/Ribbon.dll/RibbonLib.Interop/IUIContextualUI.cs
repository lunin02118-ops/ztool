using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("EEA11F37-7C46-437c-8E55-B52122B29293")]
public interface IUIContextualUI
{
	[PreserveSig]
	HRESULT ShowAtLocation(int x, int y);
}
