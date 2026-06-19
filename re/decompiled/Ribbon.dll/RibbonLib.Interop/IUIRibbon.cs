using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace RibbonLib.Interop;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("803982ab-370a-4f7e-a9e7-8784036a6e26")]
public interface IUIRibbon
{
	[PreserveSig]
	HRESULT GetHeight(out uint cy);

	[PreserveSig]
	HRESULT LoadSettingsFromStream([In][MarshalAs(UnmanagedType.Interface)] IStream pStream);

	[PreserveSig]
	HRESULT SaveSettingsToStream([In][MarshalAs(UnmanagedType.Interface)] IStream pStream);
}
