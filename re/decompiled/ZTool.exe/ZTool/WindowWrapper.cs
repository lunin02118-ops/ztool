using System;
using System.Windows.Forms;

namespace ZTool;

public class WindowWrapper : IWin32Window
{
	private IntPtr _hwnd;

	public IntPtr Handle => _hwnd;

	public WindowWrapper(IntPtr handle_Conflict)
	{
		_hwnd = handle_Conflict;
	}
}
