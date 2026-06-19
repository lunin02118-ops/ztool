using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[StandardModule]
public sealed class TextBoxWaterMark
{
	private const int _206D_200B_206A_206E_206E_206E_200B_202D_202E_202E_200C_206F_206B_206B_202E_200E_200C_202D_206C_202A_206C_206C_202D_202A_206E_200C_206D_200E_202E_206C_200D_200C_200F_200B_206C_200B_206A_200F_200F_200E_202E = 5377;

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	private static extern int _200C_200F_200F_202E_206E_206C_206E_202D_202A_202E_200E_206E_200F_200D_206E_202E_202C_202E_206A_202C_200F_206F_202B_206D_200F_200B_200B_202D_202C_200C_206C_200D_206B_202E_200B_202A_206B_202C_200B_202C_202E(IntPtr P_0, int P_1, int P_2, [MarshalAs(UnmanagedType.LPWStr)] string P_3);

	public static void SetWatermark(this TextBox textBox, string watermark)
	{
		_200C_200F_200F_202E_206E_206C_206E_202D_202A_202E_200E_206E_200F_200D_206E_202E_202C_202E_206A_202C_200F_206F_202B_206D_200F_200B_200B_202D_202C_200C_206C_200D_206B_202E_200B_202A_206B_202C_200B_202C_202E((IntPtr)textBox.Handle.ToInt32(), 5377, 0, watermark);
	}

	public static void ClearWatermark(this TextBox textBox)
	{
		_200C_200F_200F_202E_206E_206C_206E_202D_202A_202E_200E_206E_200F_200D_206E_202E_202C_202E_206A_202C_200F_206F_202B_206D_200F_200B_200B_202D_202C_200C_206C_200D_206B_202E_200B_202A_206B_202C_200B_202C_202E((IntPtr)textBox.Handle.ToInt32(), 5377, 0, string.Empty);
	}
}
