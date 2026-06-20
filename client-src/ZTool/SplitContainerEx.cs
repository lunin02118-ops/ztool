using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ZTool;

[ToolboxBitmap(typeof(SplitContainer))]
public class SplitContainerEx : SplitContainer
{
	private enum MouseState
	{
		Normal,
		Hover
	}

	public enum SplitterPanelEnum
	{
		Panel1,
		Panel2
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private double dpixRatio;

	private SplitterPanelEnum mCollpasePanel;

	private bool mCollpased;

	private Rectangle mRect;

	private MouseState mMouseState;

	private bool mIsSplitterFixed;

	private int _HeightOrWidth;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new int SplitterWidth
	{
		get
		{
			return base.SplitterWidth;
		}
		set
		{
			base.SplitterWidth = 9;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new int Panel1MinSize
	{
		get
		{
			return base.Panel1MinSize;
		}
		set
		{
			base.Panel1MinSize = 0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new int Panel2MinSize
	{
		get
		{
			return base.Panel2MinSize;
		}
		set
		{
			base.Panel2MinSize = 0;
		}
	}

	[DefaultValue(0)]
	public SplitterPanelEnum CollpasePanel
	{
		get
		{
			return mCollpasePanel;
		}
		set
		{
			if (value != mCollpasePanel)
			{
				mCollpasePanel = value;
				Invalidate(ControlRect);
			}
		}
	}

	public bool IsCollpased => mCollpased;

	private Rectangle ControlRect
	{
		get
		{
			checked
			{
				if (Orientation == Orientation.Horizontal)
				{
					mRect.X = (int)Math.Round(((double)Width <= 80.0 * dpixRatio) ? 0.0 : ((double)unchecked(Width / 2) - 40.0 * dpixRatio));
					mRect.Y = SplitterDistance;
					mRect.Width = (int)Math.Round(80.0 * dpixRatio);
					mRect.Height = (int)Math.Round(9.0 * dpixRatio);
				}
				else
				{
					mRect.X = SplitterDistance;
					mRect.Y = (int)Math.Round(((double)Height <= 80.0 * dpixRatio) ? 0.0 : ((double)unchecked(Height / 2) - 40.0 * dpixRatio));
					mRect.Width = (int)Math.Round(9.0 * dpixRatio);
					mRect.Height = (int)Math.Round(80.0 * dpixRatio);
				}
				return mRect;
			}
		}
	}

	public new bool IsSplitterFixed
	{
		get
		{
			return base.IsSplitterFixed;
		}
		set
		{
			base.IsSplitterFixed = value;
			if ((value && !mIsSplitterFixed) ? true : false)
			{
				mIsSplitterFixed = true;
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

	public SplitContainerEx()
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		mCollpasePanel = SplitterPanelEnum.Panel1;
		mCollpased = false;
		mRect = default(Rectangle);
		mMouseState = MouseState.Normal;
		mIsSplitterFixed = true;
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		SplitterWidth = 9;
		Panel1MinSize = 0;
		Panel2MinSize = 0;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		bool collapse = false;
		if (((CollpasePanel == SplitterPanelEnum.Panel1 && !mCollpased) || (CollpasePanel == SplitterPanelEnum.Panel2 && mCollpased)) ? true : false)
		{
			collapse = true;
		}
		Color color = ((mMouseState == MouseState.Normal) ? SystemColors.ButtonShadow : SystemColors.ControlDarkDark);
		Bitmap bitmap = CreateControlImage(collapse, color);
		if (Orientation == Orientation.Vertical)
		{
			bitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
		}
		e.Graphics.SetClip(SplitterRectangle);
		e.Graphics.Clear(BackColor);
		e.Graphics.DrawImage(bitmap, ControlRect);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (SplitterRectangle.Contains(e.Location))
		{
			if (ControlRect.Contains(e.Location))
			{
				if (!IsSplitterFixed)
				{
					IsSplitterFixed = true;
					mIsSplitterFixed = false;
				}
				Cursor = Cursors.Hand;
				mMouseState = MouseState.Hover;
				Invalidate(ControlRect);
			}
			else
			{
				if (!mIsSplitterFixed)
				{
					IsSplitterFixed = false;
					if (Orientation == Orientation.Horizontal)
					{
						Cursor = Cursors.HSplit;
					}
					else
					{
						Cursor = Cursors.VSplit;
					}
				}
				else
				{
					Cursor = Cursors.Default;
				}
				mMouseState = MouseState.Normal;
				Invalidate(ControlRect);
			}
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		Cursor = Cursors.Default;
		mMouseState = MouseState.Normal;
		Invalidate(ControlRect);
		base.OnMouseLeave(e);
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		if (ControlRect.Contains(e.Location))
		{
			CollpaseOrExpand();
		}
		base.OnMouseClick(e);
	}

	public void CollpaseOrExpand()
	{
		checked
		{
			if (mCollpased || SplitterDistance == 0)
			{
				mCollpased = false;
				SplitterDistance = _HeightOrWidth;
			}
			else
			{
				mCollpased = true;
				_HeightOrWidth = SplitterDistance;
				if (CollpasePanel == SplitterPanelEnum.Panel1)
				{
					SplitterDistance = 0;
				}
				else if (Orientation == Orientation.Horizontal)
				{
					SplitterDistance = Height - 9;
				}
				else
				{
					SplitterDistance = Width - 9;
				}
			}
			Invalidate(ControlRect);
		}
	}

	private Bitmap CreateControlImage(bool collapse, Color color)
	{
		Bitmap bitmap = new Bitmap(80, 9);
		int num = 5;
		checked
		{
			int num5;
			int num4;
			do
			{
				int num2 = 1;
				int num3;
				do
				{
					bitmap.SetPixel(num, num2, color);
					num2 += 3;
					num3 = num2;
					num4 = 7;
				}
				while (num3 <= num4);
				num += 5;
				num5 = num;
				num4 = 30;
			}
			while (num5 <= num4);
			int num6 = 50;
			int num9;
			do
			{
				int num7 = 1;
				int num8;
				do
				{
					bitmap.SetPixel(num6, num7, color);
					num7 += 3;
					num8 = num7;
					num4 = 7;
				}
				while (num8 <= num4);
				num6 += 5;
				num9 = num6;
				num4 = 75;
			}
			while (num9 <= num4);
			if (collapse)
			{
				int num10 = 0;
				int num11 = 7;
				int num12;
				do
				{
					for (int i = 35 + num10; i <= 45 - num10; i++)
					{
						bitmap.SetPixel(i, num11, color);
					}
					num10++;
					num11 += -1;
					num12 = num11;
					num4 = 1;
				}
				while (num12 >= num4);
			}
			else
			{
				int num13 = 0;
				int num14 = 1;
				int num15;
				do
				{
					for (int j = 35 + num13; j <= 45 - num13; j++)
					{
						bitmap.SetPixel(j, num14, color);
					}
					num13++;
					num14++;
					num15 = num14;
					num4 = 7;
				}
				while (num15 <= num4);
			}
			return bitmap;
		}
	}
}
