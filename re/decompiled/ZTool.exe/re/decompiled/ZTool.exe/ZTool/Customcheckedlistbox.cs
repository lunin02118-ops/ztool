using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ZTool;

internal class Customcheckedlistbox : CheckedListBox
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private double dpixRatio;

	private bool AuthorizeCheck
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
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

	public Customcheckedlistbox()
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		using Graphics graphics = Graphics.FromHwnd(Handle);
		dpixRatio = graphics.DpiX / 96f;
	}

	protected override void OnItemCheck(ItemCheckEventArgs ice)
	{
		base.OnItemCheck(ice);
		if (!AuthorizeCheck)
		{
			ice.NewValue = ice.CurrentValue;
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		Point pt = PointToClient(Cursor.Position);
		checked
		{
			int num = Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					Rectangle itemRectangle = GetItemRectangle(num2);
					itemRectangle.Width = (int)Math.Round(16.0 * dpixRatio);
					if (itemRectangle.Contains(pt))
					{
						AuthorizeCheck = true;
						bool value = !GetItemChecked(num2);
						SetItemChecked(num2, value);
						AuthorizeCheck = false;
						break;
					}
					num2++;
					continue;
				}
				break;
			}
		}
	}
}
