using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("DF4F45BF-6F9D-4dd7-9D68-D8F9CD18C4DB")]
public interface IUICollection
{
	[PreserveSig]
	HRESULT GetCount(out uint count);

	[PreserveSig]
	HRESULT GetItem(uint index, [MarshalAs(UnmanagedType.IUnknown)] out object item);

	[PreserveSig]
	HRESULT Add([In][MarshalAs(UnmanagedType.IUnknown)] object item);

	[PreserveSig]
	HRESULT Insert(uint index, [In][MarshalAs(UnmanagedType.IUnknown)] object item);

	[PreserveSig]
	HRESULT RemoveAt(uint index);

	[PreserveSig]
	HRESULT Replace(uint indexReplaced, [In][MarshalAs(UnmanagedType.IUnknown)] object itemReplaceWith);

	[PreserveSig]
	HRESULT Clear();
}
