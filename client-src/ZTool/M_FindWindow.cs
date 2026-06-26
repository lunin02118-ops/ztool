using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ZTool;

public class M_FindWindow
{
	public delegate bool EnumChild(int hwnd, int lParam);

	private string C_title;

	private IntPtr c_hwnd;

	public M_FindWindow()
	{
		C_title = "";
		c_hwnd = IntPtr.Zero;
	}

	[DllImport("user32.dll", SetLastError = true)]
	private static extern int GetDesktopWindow();

	[DllImport("user32.dll")]
	private static extern bool EnumChildWindows(int hWndParent, EnumChild lpEnumFunc, int lParam);

	[DllImport("user32.dll")]
	private static extern bool EnumWindows(EnumChild lpEnumFunc, int lParam);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern int GetClassName(int hwnd, StringBuilder lpClassName, int nMaxCount);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern int GetWindowText(int hwnd, StringBuilder lpString, int cch);

	[DllImport("User32.dll")]
	private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwprocessid);

	public IntPtr FindChildHwnd(int ProcessId, string title)
	{
		c_hwnd = (IntPtr)0;
		C_title = title;
		EnumChild lpEnumFunc = EnumChildProc;
		EnumWindows(lpEnumFunc, ProcessId);
		if (c_hwnd != IntPtr.Zero)
		{
			return c_hwnd;
		}
		EnumChildWindows(GetDesktopWindow(), lpEnumFunc, ProcessId);
		return c_hwnd;
	}

	public bool EnumChildProc(int hwnd, int lParam)
	{
		StringBuilder stringBuilder = new StringBuilder(260);
		GetWindowText(hwnd, stringBuilder, stringBuilder.Capacity);
		if (string.Equals(stringBuilder.ToString(), C_title, StringComparison.Ordinal))
		{
			int lpdwprocessid = 0;
			int windowThreadProcessId = GetWindowThreadProcessId((IntPtr)hwnd, ref lpdwprocessid);
			if (lpdwprocessid == lParam)
			{
				c_hwnd = (IntPtr)hwnd;
				return false;
			}
		}
		stringBuilder = null;
		return true;
	}
}
