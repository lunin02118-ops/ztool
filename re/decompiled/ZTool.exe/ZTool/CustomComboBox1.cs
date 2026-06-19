using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

internal class CustomComboBox1 : Control
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private bool @bool;

	private Rectangle arrowRectangle;

	private ComboBoxState arrowState;

	private Rectangle m_buttonRect;

	private double dpixRatio;

	public bool HotState
	{
		get
		{
			return @bool;
		}
		set
		{
			@bool = value;
			if (value)
			{
				arrowState = ComboBoxState.Pressed;
				Invalidate();
			}
			else
			{
				arrowState = ComboBoxState.Normal;
				Invalidate();
			}
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

	public CustomComboBox1()
	{
		__ENCAddToList(this);
		arrowState = ComboBoxState.Normal;
		dpixRatio = 1.0;
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		Point location = new Point(0, 0);
		Location = location;
		Size size = checked(new Size((int)Math.Round(18.0 * dpixRatio), (int)Math.Round(18.0 * dpixRatio)));
		Size = size;
		ref Rectangle reference = ref arrowRectangle;
		reference = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		checked
		{
			try
			{
				if (ComboBoxRenderer.IsSupported)
				{
					ComboBoxRenderer.DrawDropDownButton(e.Graphics, arrowRectangle, arrowState);
					return;
				}
				Color buttonHoverTop = CT.ButtonHoverTop;
				Color buttonHoverBottom = CT.ButtonHoverBottom;
				Color buttonHoverBorder = CT.ButtonHoverBorder;
				LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, buttonHoverTop, buttonHoverBottom, 90f);
				e.Graphics.FillRectangle(brush, ClientRectangle);
				Rectangle clientRectangle = ClientRectangle;
				clientRectangle.Width = (int)Math.Round((double)clientRectangle.Width - 1.0 * dpixRatio);
				clientRectangle.Height = (int)Math.Round((double)clientRectangle.Height - 1.0 * dpixRatio);
				e.Graphics.DrawRectangle(new Pen(buttonHoverBorder, 1f), clientRectangle);
				Graphics graphics = e.Graphics;
				Pen pen = new Pen(buttonHoverBorder, (float)(dpixRatio * 1.0));
				Point[] array = new Point[3];
				ref Point reference = ref array[0];
				Point point = new Point((int)Math.Round((double)clientRectangle.Left + 5.0 * dpixRatio), (int)Math.Round((double)clientRectangle.Top + 8.0 * dpixRatio));
				reference = point;
				ref Point reference2 = ref array[1];
				Point point2 = new Point(clientRectangle.Left + unchecked(clientRectangle.Width / 2), (int)Math.Round((double)clientRectangle.Bottom - 6.0 * dpixRatio));
				reference2 = point2;
				ref Point reference3 = ref array[2];
				Point point3 = new Point((int)Math.Round((double)clientRectangle.Right - 5.0 * dpixRatio), (int)Math.Round((double)clientRectangle.Top + 8.0 * dpixRatio));
				reference3 = point3;
				graphics.DrawLines(pen, array);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (!HotState)
		{
			arrowState = ComboBoxState.Pressed;
			Invalidate();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		if (!HotState)
		{
			arrowState = ComboBoxState.Hot;
			Invalidate();
		}
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		if (!HotState)
		{
			arrowState = ComboBoxState.Normal;
			Invalidate();
		}
	}
}
