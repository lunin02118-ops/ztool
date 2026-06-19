using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ZTool;

public class Win32Helper
{
	[ComImport]
	[Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IShellItem
	{
		void BindToHandler(IntPtr pbc, [MarshalAs(UnmanagedType.LPStruct)] Guid bhid, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, ref IntPtr ppv);

		void GetParent(ref IShellItem ppsi);

		void GetDisplayName(SIGDN sigdnName, ref IntPtr ppszName);

		void GetAttributes(uint sfgaoMask, ref uint psfgaoAttribs);

		void Compare(IShellItem psi, uint hint, ref int piOrder);
	}

	public enum ThumbnailOptions : uint
	{
		None = 0u,
		ReturnOnlyIfCached = 1u,
		ResizeThumbnail = 2u,
		UseCurrentScale = 4u
	}

	internal enum SIGDN : uint
	{
		NORMALDISPLAY = 0u,
		PARENTRELATIVEPARSING = 2147581953u,
		PARENTRELATIVEFORADDRESSBAR = 2147598337u,
		DESKTOPABSOLUTEPARSING = 2147647488u,
		PARENTRELATIVEEDITING = 2147684353u,
		DESKTOPABSOLUTEEDITING = 2147794944u,
		FILESYSPATH = 2147844096u,
		URL = 2147909632u
	}

	internal enum HResult : uint
	{
		Ok = 0u,
		False = 1u,
		InvalidArguments = 2147942487u,
		OutOfMemory = 2147942414u,
		NoInterface = 2147500034u,
		Fail = 2147500037u,
		ElementNotFound = 2147943568u,
		TypeElementNotFound = 2147647531u,
		NoObject = 2147746277u,
		Win32ErrorCanceled = 1223u,
		Canceled = 2147943623u,
		ResourceInUse = 2147942570u,
		AccessDenied = 2147680261u
	}

	[ComImport]
	[Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IShellItemImageFactory
	{
		[PreserveSig]
		HResult GetImage([In][MarshalAs(UnmanagedType.Struct)] NativeSize size, [In] ThumbnailOptions flags, out IntPtr phbm);
	}

	internal struct NativeSize
	{
		private int width_Conflict;

		private int height_Conflict;

		public int Width
		{
			set
			{
				width_Conflict = value;
			}
		}

		public int Height
		{
			set
			{
				height_Conflict = value;
			}
		}
	}

	public struct RGBQUAD
	{
		public byte rgbBlue;

		public byte rgbGreen;

		public byte rgbRed;

		public byte rgbReserved;
	}

	internal const string IShellItem2Guid = "7E9FB0D3-919F-4307-AB2E-9B1860310C93";

	[DebuggerNonUserCode]
	public Win32Helper()
	{
	}

	[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern int SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string path, IntPtr pbc, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] ref IShellItem shellItem);

	[DllImport("gdi32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool DeleteObject(IntPtr hObject);
}
