using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IPropertyStore
{
	[PreserveSig]
	HRESULT GetCount(out uint cProps);

	[PreserveSig]
	HRESULT GetAt([In] uint iProp, out PropertyKey pkey);

	[PreserveSig]
	HRESULT GetValue([In] ref PropertyKey key, out PropVariant pv);

	[PreserveSig]
	HRESULT SetValue([In] ref PropertyKey key, [In] ref PropVariant pv);

	[PreserveSig]
	HRESULT Commit();
}
