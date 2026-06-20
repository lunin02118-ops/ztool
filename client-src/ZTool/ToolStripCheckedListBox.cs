using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ZTool;

public class ToolStripCheckedListBox : ToolStripControlHost
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private double dpixRatio;

	private bool ing;

	public CheckedListBox CheckedListBoxControl => Control as CheckedListBox;

	public CheckedListBox.ObjectCollection Items => CheckedListBoxControl.Items;

	public bool CheckedOnClick
	{
		get
		{
			return CheckedListBoxControl.CheckOnClick;
		}
		set
		{
			CheckedListBoxControl.CheckOnClick = value;
		}
	}

	public CheckedListBox.CheckedItemCollection CheckedItems => CheckedListBoxControl.CheckedItems;

	[method: DebuggerNonUserCode]
	public event ItemCheckEventHandler ItemCheck;

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

	public ToolStripCheckedListBox()
		: base(new CheckedListBox())
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		ing = false;
		using (Graphics graphics = Graphics.FromHwnd(CheckedListBoxControl.Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		CheckedListBox checkedListBoxControl = CheckedListBoxControl;
		checked
		{
			Size maximumSize = new Size((int)Math.Round(400.0 * dpixRatio), (int)Math.Round(400.0 * dpixRatio));
			checkedListBoxControl.MaximumSize = maximumSize;
			CheckedListBox checkedListBoxControl2 = CheckedListBoxControl;
			maximumSize = new Size((int)Math.Round(150.0 * dpixRatio), (int)Math.Round(100.0 * dpixRatio));
			checkedListBoxControl2.MinimumSize = maximumSize;
			CheckedListBoxControl.ThreeDCheckBoxes = true;
			CheckedListBoxControl.CheckOnClick = true;
			CheckedListBoxControl.SelectionMode = SelectionMode.One;
			CheckedListBoxControl.Items.Add("(全选)", isChecked: true);
			CheckedListBoxControl.HorizontalScrollbar = true;
		}
	}

	public ToolStripCheckedListBox(Control c)
		: base(c)
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		ing = false;
	}

	public void AddItem(object item, bool isChecked)
	{
		Items.Add(RuntimeHelpers.GetObjectValue(item));
		if (isChecked)
		{
			CheckedListBoxControl.SetItemChecked(checked(Items.Count - 1), value: true);
		}
	}

	public void AddItem(object item, CheckState state)
	{
		Items.Add(RuntimeHelpers.GetObjectValue(item));
		CheckedListBoxControl.SetItemCheckState(checked(Items.Count - 1), state);
	}

	public bool AddItem(string str, StringComparison Comparison, bool isChecked = true)
	{
		bool flag = false;
		checked
		{
			int num = Items.Count - 1;
			int num2 = 1;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (string.Equals(Items[num2].ToString(), str, Comparison))
				{
					flag = true;
					break;
				}
				num2++;
			}
			if (!flag)
			{
				AddItem(str, isChecked: true);
			}
			return flag;
		}
	}

	public CheckState GetItemCheckState(int i)
	{
		return CheckedListBoxControl.GetItemCheckState(i);
	}

	public void SetItemState(int i, CheckState checkState)
	{
		if ((i >= 0 && i < Items.Count) ? true : false)
		{
			CheckedListBoxControl.SetItemCheckState(i, checkState);
		}
	}

	public void CheckAll()
	{
		checked
		{
			int num = Items.Count - 1;
			int num2 = 1;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					CheckedListBoxControl.SetItemChecked(num2, value: true);
					num2++;
					continue;
				}
				break;
			}
		}
	}

	public void UncheckAll()
	{
		checked
		{
			int num = Items.Count - 1;
			int num2 = 1;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					CheckedListBoxControl.SetItemChecked(num2, value: false);
					num2++;
					continue;
				}
				break;
			}
		}
	}

	public int GetUnCheckedCount()
	{
		int num = 0;
		checked
		{
			int num2 = Items.Count - 1;
			int num3 = 1;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (CheckedListBoxControl.GetItemCheckState(num3) == CheckState.Unchecked)
				{
					num++;
				}
				num3++;
			}
			return num;
		}
	}

	public bool Contains(string str, StringComparison Comparison)
	{
		bool result = false;
		checked
		{
			int num = Items.Count - 1;
			int num2 = 1;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (string.Equals(Items[num2].ToString(), str, Comparison))
				{
					result = true;
					break;
				}
				num2++;
			}
			return result;
		}
	}

	protected override void OnSubscribeControlEvents(Control c)
	{
		base.OnSubscribeControlEvents(c);
		CheckedListBox checkedListBox = (CheckedListBox)c;
		checkedListBox.ItemCheck += OnItemCheck;
	}

	protected override void OnUnsubscribeControlEvents(Control c)
	{
		base.OnUnsubscribeControlEvents(c);
		CheckedListBox checkedListBox = (CheckedListBox)c;
		checkedListBox.ItemCheck -= OnItemCheck;
	}

	private void OnItemCheck(object sender, ItemCheckEventArgs e)
	{
		ItemCheck?.Invoke(this, e);
		if (e.Index == 0)
		{
			if (!ing)
			{
				if (e.NewValue == CheckState.Checked)
				{
					CheckAll();
				}
				else if (e.NewValue == CheckState.Unchecked)
				{
					UncheckAll();
				}
			}
		}
		else
		{
			ing = true;
			if ((GetUnCheckedCount() == 1) & (e.NewValue == CheckState.Checked))
			{
				SetItemState(0, CheckState.Checked);
			}
			else if ((GetUnCheckedCount() == checked(Items.Count - 2)) & (e.NewValue == CheckState.Unchecked))
			{
				SetItemState(0, CheckState.Unchecked);
			}
			else
			{
				SetItemState(0, CheckState.Indeterminate);
			}
			ing = false;
		}
	}
}
