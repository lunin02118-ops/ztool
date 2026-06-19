using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ZTool;

public class MessageBoxEX
{
	private class MessageForm : Form
	{
		private static List<WeakReference> __ENCList = new List<WeakReference>();

		private IntPtr _handle;

		private MessageBoxButtons _buttons;

		private string[] _buttonTitles;

		private bool _watchForActivate;

		public bool WatchForActivate
		{
			get
			{
				return _watchForActivate;
			}
			set
			{
				_watchForActivate = value;
			}
		}

		[DebuggerNonUserCode]
		private static void __ENCAddToList(object value)
		{
			checked
			{
				lock (__ENCList)
				{
					if (__ENCList.Count == __ENCList.Capacity)
					{
						int num = 0;
						int num2 = __ENCList.Count - 1;
						int num3 = 0;
						while (true)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							WeakReference weakReference = __ENCList[num3];
							if (weakReference.IsAlive)
							{
								if (num3 != num)
								{
									__ENCList[num] = __ENCList[num3];
								}
								num++;
							}
							num3++;
						}
						__ENCList.RemoveRange(num, __ENCList.Count - num);
						__ENCList.Capacity = __ENCList.Count;
					}
					__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
				}
			}
		}

		public MessageForm(MessageBoxButtons buttons, string[] buttonTitles)
		{
			__ENCAddToList(this);
			_buttonTitles = null;
			_watchForActivate = false;
			_buttons = buttons;
			_buttonTitles = buttonTitles;
			ShowIcon = false;
			Text = "";
			StartPosition = FormStartPosition.Manual;
			Point location = new Point(-32000, -32000);
			Location = location;
			ShowInTaskbar = false;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			NativeWin32API.SetWindowPos(Handle, IntPtr.Zero, 0, 0, 0, 0, 659);
		}

		protected override void WndProc(ref Message m)
		{
			if ((_watchForActivate && m.Msg == 6) ? true : false)
			{
				_watchForActivate = false;
				_handle = m.LParam;
				CheckMsgbox();
			}
			base.WndProc(ref m);
		}

		private void CheckMsgbox()
		{
			if (_buttonTitles == null || _buttonTitles.Length == 0)
			{
				return;
			}
			int num = 0;
			IntPtr intPtr = NativeWin32API.GetWindow(_handle, 5);
			while (intPtr != IntPtr.Zero)
			{
				if (NativeWin32API.GetWindowClassName(intPtr).Equals("Button") && _buttonTitles.Length > num)
				{
					NativeWin32API.SetWindowText(intPtr, _buttonTitles[num]);
					num = checked(num + 1);
				}
				intPtr = NativeWin32API.GetWindow(intPtr, 2);
			}
		}
	}

	public class NativeWin32API
	{
		[DebuggerNonUserCode]
		public NativeWin32API()
		{
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, int flags);

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindow(IntPtr hWnd, int wCmd);

		[DllImport("user32.dll")]
		public static extern bool SetWindowText(IntPtr hWnd, string lpString);

		[DllImport("user32.dll")]
		public static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);

		public static string GetWindowClassName(IntPtr handle)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			GetClassNameW(handle, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}
	}

	public const int GW_CHILD = 5;

	public const int GW_HWNDNEXT = 2;

	[DebuggerNonUserCode]
	public MessageBoxEX()
	{
	}

	public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, string[] buttonTitles)
	{
		MessageForm messageForm = new MessageForm(buttons, buttonTitles);
		messageForm.Show();
		messageForm.WatchForActivate = true;
		DialogResult result = MessageBox.Show(messageForm, text, caption, buttons);
		messageForm.Close();
		return result;
	}

	public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, string[] buttonTitles)
	{
		MessageForm messageForm = new MessageForm(buttons, buttonTitles);
		messageForm.Show(owner);
		messageForm.WatchForActivate = true;
		DialogResult result = MessageBox.Show(messageForm, text, caption, buttons, icon, defaultButton);
		messageForm.Close();
		return result;
	}
}
