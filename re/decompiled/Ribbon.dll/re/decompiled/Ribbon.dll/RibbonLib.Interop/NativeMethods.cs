using System;
using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

public static class NativeMethods
{
	public const uint DONT_RESOLVE_DLL_REFERENCES = 1u;

	public const uint LOAD_LIBRARY_AS_DATAFILE = 2u;

	public const uint LOAD_WITH_ALTERED_SEARCH_PATH = 8u;

	public const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL = 16u;

	public const uint LOAD_LIBRARY_AS_IMAGE_RESOURCE = 32u;

	public const uint LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 64u;

	public const uint LOAD_LIBRARY_REQUIRE_SIGNED_TARGET = 128u;

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool FreeLibrary([In] IntPtr hModule);

	public static bool Succeeded(HRESULT hr)
	{
		return (int)hr >= 0;
	}

	public static bool Failed(HRESULT hr)
	{
		return (int)hr < 0;
	}
}
