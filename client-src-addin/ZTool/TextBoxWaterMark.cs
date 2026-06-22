using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[StandardModule]
public static class TextBoxWaterMark
{
	private const int f_75 = 5377;

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	private static extern int m_73(IntPtr P_0, int P_1, int P_2, [MarshalAs(UnmanagedType.LPWStr)] string P_3);

	public static void SetWatermark(this TextBox textBox, string watermark)
	{
		m_73((IntPtr)textBox.Handle.ToInt32(), 5377, 0, watermark);
	}

	public static void ClearWatermark(this TextBox textBox)
	{
		m_73((IntPtr)textBox.Handle.ToInt32(), 5377, 0, string.Empty);
	}
}
