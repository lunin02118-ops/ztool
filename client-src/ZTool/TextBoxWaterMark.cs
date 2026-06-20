using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[StandardModule]
public static class TextBoxWaterMark
{
	private const int EM_SETCUEBANNER = 5377;

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

	public static void SetWatermark(this TextBox textBox, string watermark)
	{
		SendMessage((IntPtr)textBox.Handle.ToInt32(), 5377, 0, watermark);
	}

	public static void ClearWatermark(this TextBox textBox)
	{
		SendMessage((IntPtr)textBox.Handle.ToInt32(), 5377, 0, string.Empty);
	}
}
