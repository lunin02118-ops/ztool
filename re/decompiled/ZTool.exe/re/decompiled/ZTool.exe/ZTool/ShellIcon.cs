using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[StandardModule]
public sealed class ShellIcon
{
	public struct SHFILEINFO
	{
		public IntPtr hIcon;

		public IntPtr iIcon;

		public uint dwAttributes;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	}

	private class Win32
	{
		public const uint SHGFI_ICON = 256u;

		public const uint SHGFI_LARGEICON = 0u;

		public const uint SHGFI_SMALLICON = 1u;

		[DebuggerNonUserCode]
		public Win32()
		{
		}

		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

		[DllImport("User32.dll")]
		public static extern int DestroyIcon(IntPtr hIcon);
	}

	static ShellIcon()
	{
	}

	public static Icon GetSmallIcon(string fileName)
	{
		return GetIcon(fileName, 1u);
	}

	public static Icon GetLargeIcon(string fileName)
	{
		return GetIcon(fileName, 0u);
	}

	private static Icon GetIcon(string fileName, uint flags)
	{
		SHFILEINFO psfi = default(SHFILEINFO);
		IntPtr intPtr = Win32.SHGetFileInfo(fileName, 0u, ref psfi, Convert.ToUInt32(Math.Truncate(new decimal(Marshal.SizeOf((object)psfi)))), 0x100 | flags);
		Icon result = (Icon)Icon.FromHandle(psfi.hIcon).Clone();
		Win32.DestroyIcon(psfi.hIcon);
		return result;
	}
}
