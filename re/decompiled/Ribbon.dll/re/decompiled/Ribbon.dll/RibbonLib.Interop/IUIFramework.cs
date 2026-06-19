using System;
using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[Guid("F4F0385D-6872-43a8-AD09-4C339CB3F5C5")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IUIFramework
{
	[PreserveSig]
	HRESULT Initialize(IntPtr frameWnd, IUIApplication application);

	[PreserveSig]
	HRESULT Destroy();

	[PreserveSig]
	HRESULT LoadUI(IntPtr instance, [MarshalAs(UnmanagedType.LPWStr)] string resourceName);

	[PreserveSig]
	HRESULT GetView(uint viewID, [In] ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

	[PreserveSig]
	HRESULT GetUICommandProperty(uint commandID, [In] ref PropertyKey key, out PropVariant value);

	[PreserveSig]
	HRESULT SetUICommandProperty(uint commandID, [In] ref PropertyKey key, [In] ref PropVariant value);

	[PreserveSig]
	HRESULT InvalidateUICommand(uint commandID, Invalidations flags, [Optional][In] PropertyKeyRef key);

	[PreserveSig]
	HRESULT FlushPendingInvalidations();

	[PreserveSig]
	HRESULT SetModes(int iModes);
}
