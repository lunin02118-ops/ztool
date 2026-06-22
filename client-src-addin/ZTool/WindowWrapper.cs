using System;
using System.Windows.Forms;

namespace ZTool;

public class WindowWrapper : IWin32Window
{
	private IntPtr f_76;

	public IntPtr Handle => f_76;

	public WindowWrapper(IntPtr P_0)
	{
		f_76 = P_0;
	}
}
