using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My.Resources;

namespace ZTool;

internal class SearchBox : Label
{
	public delegate void srButtonTextButton_Clickhandle(object sender, EventArgs e);

	public delegate void srButtonTextTextbox_txtChangedHandle(object sender, EventArgs e);

	public delegate void srButtonTextTextbox_MouseEnterHandle(object sender, EventArgs e);

	public delegate void srButtonTextTextbox_KeyEventHandler(object sender, KeyEventArgs e);

	public delegate void srButtonTextTextbox_KeypressEventHandler(object sender, KeyPressEventArgs e);

	public delegate void srButtonTextTextbox_GotFocusHandle(object sender, EventArgs e);

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	public TextBox srButtonTextTextbox;

	public Button srButtonTextButton;

	private Label srButtonTextlable;

	private double dpixRatio;

	public int txtMaxLength
	{
		get
		{
			return srButtonTextTextbox.MaxLength;
		}
		set
		{
			srButtonTextTextbox.MaxLength = value;
		}
	}

	public new Font Font
	{
		get
		{
			return srButtonTextTextbox.Font;
		}
		set
		{
			srButtonTextTextbox.Font = value;
			srButtonTextButton.Font = value;
			srButtonTextlable.Font = value;
		}
	}

	public override string Text
	{
		get
		{
			return srButtonTextTextbox.Text;
		}
		set
		{
			srButtonTextTextbox.Text = value;
		}
	}

	public string ToolTip
	{
		set
		{
			ToolTip toolTip = new ToolTip();
			toolTip.SetToolTip(srButtonTextTextbox, value);
		}
	}

	[method: DebuggerNonUserCode]
	public event srButtonTextButton_Clickhandle ButtonClick;

	[method: DebuggerNonUserCode]
	public new event srButtonTextTextbox_txtChangedHandle TextChanged;

	[method: DebuggerNonUserCode]
	public new event srButtonTextTextbox_MouseEnterHandle MouseEnter;

	[method: DebuggerNonUserCode]
	public new event srButtonTextTextbox_KeyEventHandler KeyDown;

	[method: DebuggerNonUserCode]
	public new event srButtonTextTextbox_KeyEventHandler KeyUp;

	[method: DebuggerNonUserCode]
	public new event srButtonTextTextbox_KeypressEventHandler KeyPress;

	[method: DebuggerNonUserCode]
	public new event srButtonTextTextbox_GotFocusHandle GotFocus;

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

	public SearchBox()
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		SuspendLayout();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			Height = (int)Math.Round(20.0 * dpixRatio);
			Name = "SearchBox";
			Size minimumSize = new Size((int)Math.Round(150.0 * dpixRatio), (int)Math.Round(20.0 * dpixRatio));
			MinimumSize = minimumSize;
			AutoSize = true;
			TextBox textBox = new TextBox();
			textBox.Text = "";
			textBox.Font = new Font("微软雅黑", textBox.Font.Size, textBox.Font.Style);
			textBox.BackColor = Color.White;
			textBox.BorderStyle = BorderStyle.None;
			textBox.ImeMode = ImeMode.NoControl;
			minimumSize = new Size(Width, Height);
			textBox.Size = minimumSize;
			srButtonTextTextbox = textBox;
			Button button = new Button
			{
				Image = Resources.del_12px,
				ImageAlign = ContentAlignment.MiddleCenter,
				Text = "",
				FlatStyle = FlatStyle.Flat,
				BackColor = Color.White
			};
			minimumSize = new Size((int)Math.Round((double)Height * 0.9), (int)Math.Round((double)Height * 0.8));
			button.Size = minimumSize;
			button.TabStop = false;
			button.Visible = false;
			srButtonTextButton = button;
			srButtonTextButton.FlatAppearance.BorderColor = Color.White;
			srButtonTextButton.FlatAppearance.MouseDownBackColor = Color.Gray;
			srButtonTextButton.FlatAppearance.MouseOverBackColor = Color.LightGray;
			srButtonTextButton.FlatAppearance.BorderSize = 2;
			Label label = new Label
			{
				Image = Resources.search_12px,
				ImageAlign = ContentAlignment.MiddleCenter,
				Text = "",
				FlatStyle = FlatStyle.Flat
			};
			minimumSize = new Size(Height, Height);
			label.Size = minimumSize;
			label.Visible = true;
			srButtonTextlable = label;
			srButtonTextTextbox.Dock = DockStyle.Left;
			srButtonTextButton.Dock = DockStyle.Right;
			srButtonTextlable.Dock = DockStyle.Right;
			SetButton(srButtonTextButton);
			Controls.Add(srButtonTextTextbox);
			Controls.Add(srButtonTextButton);
			Controls.Add(srButtonTextlable);
			Resize += srButtonText_Resize;
			srButtonTextButton.Click += srButtonTextButton_Click;
			srButtonTextTextbox.TextChanged += srButtonTextTextbox_TextChanged;
			srButtonTextTextbox.MouseEnter += srButtonTextTextbox_MouseEnter;
			srButtonTextTextbox.KeyDown += srButtonTextTextbox_KeyDown;
			srButtonTextTextbox.KeyUp += srButtonTextTextbox_KeyUp;
			srButtonTextTextbox.KeyPress += srButtonTextTextbox_KeyPress;
			srButtonTextTextbox.GotFocus += srButtonTextTextbox_GotFocus;
			BackColor = Color.White;
			BorderStyle = BorderStyle.FixedSingle;
			Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			ResumeLayout(performLayout: false);
		}
	}

	private void srButtonText_Resize(object sender, EventArgs e)
	{
		checked
		{
			Height = (int)Math.Round(20.0 * dpixRatio);
			srButtonTextTextbox.Dock = DockStyle.Left;
			srButtonTextButton.Dock = DockStyle.Right;
			srButtonTextlable.Dock = DockStyle.Right;
			srButtonTextTextbox.Width = Width - srButtonTextButton.Width;
			srButtonTextTextbox.Height = Height;
		}
	}

	private void srButtonTextButton_Click(object sender, EventArgs e)
	{
		ButtonClick?.Invoke(RuntimeHelpers.GetObjectValue(sender), new EventArgs());
		Text = "";
	}

	private void srButtonTextTextbox_MouseEnter(object sender, EventArgs e)
	{
		MouseEnter?.Invoke(RuntimeHelpers.GetObjectValue(sender), new EventArgs());
	}

	private void srButtonTextTextbox_TextChanged(object sender, EventArgs e)
	{
		TextChanged?.Invoke(RuntimeHelpers.GetObjectValue(sender), new EventArgs());
		if (Operators.CompareString(Text, "", TextCompare: false) == 0)
		{
			srButtonTextButton.Visible = false;
			srButtonTextlable.Visible = true;
		}
		else
		{
			srButtonTextButton.Visible = true;
			srButtonTextlable.Visible = false;
		}
	}

	private void srButtonTextTextbox_KeyUp(object sender, KeyEventArgs e)
	{
		KeyUp?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void srButtonTextTextbox_KeyDown(object sender, KeyEventArgs e)
	{
		KeyDown?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void srButtonTextTextbox_KeyPress(object sender, KeyPressEventArgs e)
	{
		KeyPress?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void srButtonTextTextbox_GotFocus(object sender, EventArgs e)
	{
		GotFocus?.Invoke(RuntimeHelpers.GetObjectValue(sender), new EventArgs());
	}

	public void SetButton(Button button)
	{
		MethodInfo method = button.GetType().GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
		method.Invoke(button, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, new object[2]
		{
			ControlStyles.Selectable,
			false
		}, Application.CurrentCulture);
	}
}
