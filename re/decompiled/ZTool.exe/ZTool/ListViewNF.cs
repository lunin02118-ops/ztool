using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ZTool;

public class ListViewNF : ListView
{
	public class ColumnSort : IComparer
	{
		public bool bAscending;

		private int col;

		public ColumnSort(int column)
		{
			bAscending = true;
			col = 0;
			col = column;
		}

		private int CompareInt(int x, int y)
		{
			if (x > y)
			{
				return 1;
			}
			if (x < y)
			{
				return -1;
			}
			return 0;
		}

		public int Compare(object a, object b)
		{
			System.Windows.Forms.ListViewItem listViewItem = (System.Windows.Forms.ListViewItem)a;
			System.Windows.Forms.ListViewItem listViewItem2 = (System.Windows.Forms.ListViewItem)b;
			string text = listViewItem.SubItems[col].Text;
			string text2 = listViewItem2.SubItems[col].Text;
			int result;
			int result2;
			if (bAscending)
			{
				if ((int.TryParse(text, out result) && int.TryParse(text2, out result2)) ? true : false)
				{
					return CompareInt(result, result2);
				}
				return string.Compare(text, text2);
			}
			checked
			{
				if ((int.TryParse(text, out result) && int.TryParse(text2, out result2)) ? true : false)
				{
					return -1 * CompareInt(result, result2);
				}
				return -1 * string.Compare(text, text2);
			}
		}

		int IComparer.Compare(object a, object b)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Compare
			return this.Compare(a, b);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

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

	public ListViewNF()
	{
		base.ColumnClick += ListViewNF_ColumnClick;
		__ENCAddToList(this);
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.EnableNotifyMessage, value: true);
	}

	protected override void OnNotifyMessage(Message m)
	{
		if (m.Msg != 20)
		{
			base.OnNotifyMessage(m);
		}
	}

	private void ListViewNF_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		ColumnSort columnSort = new ColumnSort(e.Column);
		columnSort.bAscending = Sorting == SortOrder.Ascending;
		if (columnSort.bAscending)
		{
			Sorting = SortOrder.Descending;
		}
		else
		{
			Sorting = SortOrder.Ascending;
		}
		ListViewItemSorter = columnSort;
		ListViewItemSorter = null;
	}
}
