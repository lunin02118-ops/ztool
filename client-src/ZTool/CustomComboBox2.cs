using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ZTool;

internal class CustomComboBox2 : ComboBox
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private double dpixRatio;

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

	public CustomComboBox2()
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		Point location = new Point(0, 0);
		Location = location;
		Size size = checked(new Size((int)Math.Round(18.0 * dpixRatio), (int)Math.Round(18.0 * dpixRatio)));
		Size = size;
	}

	protected override void OnDropDown(EventArgs e)
	{
		base.OnDropDown(e);
		AdjustComboBoxDropDownListWidth();
	}

	protected void AdjustComboBoxDropDownListWidth()
	{
		int num = ((Items.Count > MaxDropDownItems) ? SystemInformation.VerticalScrollBarWidth : 0);
		checked
		{
			int num2 = (int)Math.Round(100.0 * dpixRatio);
			foreach (object item in Items)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				int num3 = TextRenderer.MeasureText(objectValue.ToString(), Font).Width;
				if (num2 < num3)
				{
					num2 = num3;
				}
			}
			DropDownWidth = num2 + num;
		}
	}
}
