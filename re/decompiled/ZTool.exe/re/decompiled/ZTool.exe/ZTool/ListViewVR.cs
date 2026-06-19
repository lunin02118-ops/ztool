using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class ListViewVR : ListView
{
	internal class MMySorter : IComparer<ListViewItem>
	{
		private CaseInsensitiveComparer cic;

		public int columnToSort
		{
			[DebuggerNonUserCode]
			get;
			[DebuggerNonUserCode]
			set;
		}

		public SortOrder so
		{
			[DebuggerNonUserCode]
			get;
			[DebuggerNonUserCode]
			set;
		}

		public MMySorter()
		{
			columnToSort = 0;
			so = SortOrder.None;
			cic = new CaseInsensitiveComparer();
		}

		private int IComparerGeneric_Compare(ListViewItem x, ListViewItem y)
		{
			int num = 0;
			string text = x.SubItems[columnToSort].Text;
			string text2 = y.SubItems[columnToSort].Text;
			int result = 0;
			int result2 = 0;
			num = (((!int.TryParse(text, out result) || !int.TryParse(text2, out result2)) && 0 == 0) ? text.CompareTo(text2) : result.CompareTo(result2));
			if (so == SortOrder.Ascending)
			{
				return num;
			}
			if (so == SortOrder.Descending)
			{
				return checked(-num);
			}
			return num;
		}

		int IComparer<ListViewItem>.Compare(ListViewItem x, ListViewItem y)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IComparerGeneric_Compare
			return this.IComparerGeneric_Compare(x, y);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private List<ListViewItem> CacheItemsSource;

	private MMySorter mySort;

	private const int WM_HSCROLL = 276;

	private const int WM_VSCROLL = 277;

	private double dpixRatio;

	[method: DebuggerNonUserCode]
	public event EventHandler HScroll;

	[method: DebuggerNonUserCode]
	public event EventHandler VScroll;

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

	public ListViewVR()
	{
		__ENCAddToList(this);
		mySort = new MMySorter();
		dpixRatio = 1.0;
		CacheItemsSource = new List<ListViewItem>();
		loadview();
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.EnableNotifyMessage, value: true);
		using Graphics graphics = Graphics.FromHwnd(Handle);
		dpixRatio = graphics.DpiX / 96f;
	}

	protected override void OnNotifyMessage(Message m)
	{
		if (m.Msg != 20)
		{
			base.OnNotifyMessage(m);
		}
	}

	public void loadview()
	{
		Items.Clear();
		if (!Information.IsNothing(CacheItemsSource))
		{
			AllowDrop = true;
			GridLines = true;
			Scrollable = true;
			MultiSelect = true;
			FullRowSelect = true;
			View = View.Details;
			HeaderStyle = ColumnHeaderStyle.Clickable;
			Visible = true;
			VirtualMode = false;
			CheckBoxes = false;
			VirtualListSize = CacheItemsSource.Count;
			VirtualMode = true;
			RetrieveVirtualItem += ListViewVR_RetrieveVirtualItem;
			Invalidate();
			DrawItem += ListViewVR_DrawItem;
			MouseClick += ListViewVR_MouseClick;
			MouseDoubleClick += ListViewVR_MouseDoubleClick;
			ColumnClick += ListViewVR_ColumnClick;
			SelectedIndexChanged += ListViewVR_SelectedIndexChanged;
		}
	}

	public int GetCheckedItemsCount()
	{
		int num = 0;
		checked
		{
			int num2 = Items.Count - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (Items[num3].Checked)
				{
					num++;
				}
				num3++;
			}
			return num;
		}
	}

	public void Refreshview()
	{
		if (!Information.IsNothing(CacheItemsSource))
		{
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
		}
	}

	public void AddData(IList<ListViewItem> l)
	{
		if (l.Count < 1 || Information.IsNothing(CacheItemsSource))
		{
			return;
		}
		CacheItemsSource.Clear();
		CacheItemsSource = new List<ListViewItem>();
		foreach (ListViewItem item in l)
		{
			CacheItemsSource.Add(item);
		}
		VirtualListSize = CacheItemsSource.Count;
		Invalidate();
	}

	public void DelAllItems()
	{
		if (!Information.IsNothing(CacheItemsSource))
		{
			CacheItemsSource.Clear();
			CacheItemsSource = new List<ListViewItem>();
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
		}
	}

	public void DelSelectItems(bool resettext = true)
	{
		if (Information.IsNothing(CacheItemsSource))
		{
			return;
		}
		int num = 0;
		checked
		{
			foreach (object selectedIndex in SelectedIndices)
			{
				int num2 = Conversions.ToInteger(selectedIndex);
				CacheItemsSource.RemoveAt(num2 - num);
				num++;
			}
			if (resettext)
			{
				int num3 = CacheItemsSource.Count - 1;
				int num4 = 0;
				while (true)
				{
					int num5 = num4;
					int num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					CacheItemsSource[num4].Text = Conversions.ToString(num4 + 1);
					num4++;
				}
			}
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
			Select();
		}
	}

	public void DelSpecificItems(int i)
	{
		if (!Information.IsNothing(CacheItemsSource))
		{
			try
			{
				CacheItemsSource.RemoveAt(i);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
			Select();
		}
	}

	public void ItemsMoveUp()
	{
		if (Information.IsNothing(CacheItemsSource))
		{
			return;
		}
		checked
		{
			try
			{
				int num = SelectedIndices[0];
				if (num > 0)
				{
					if (CacheItemsSource.Count > 1)
					{
						int num2 = CacheItemsSource.Count - 1;
						int num3 = 0;
						while (true)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							CacheItemsSource[num3].Selected = false;
							num3++;
						}
					}
					object obj = CacheItemsSource[num];
					CacheItemsSource.RemoveAt(num);
					CacheItemsSource.Insert(num, CacheItemsSource[num - 1]);
					CacheItemsSource.RemoveAt(num - 1);
					CacheItemsSource.Insert(num - 1, (ListViewItem)obj);
					CacheItemsSource[num].Selected = true;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
			Select();
		}
	}

	public void ItemsMoveDown()
	{
		if (Information.IsNothing(CacheItemsSource))
		{
			return;
		}
		checked
		{
			try
			{
				int num = SelectedIndices[0];
				if ((num < CacheItemsSource.Count - 1 && num >= 0) ? true : false)
				{
					if (CacheItemsSource.Count > 1)
					{
						int num2 = CacheItemsSource.Count - 1;
						int num3 = 0;
						while (true)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							CacheItemsSource[num3].Selected = false;
							num3++;
						}
					}
					object obj = CacheItemsSource[num];
					CacheItemsSource.RemoveAt(num);
					CacheItemsSource.Insert(num + 1, (ListViewItem)obj);
					CacheItemsSource[num].Selected = true;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
			Select();
		}
	}

	public void CheckItems(int n)
	{
		if (Information.IsNothing(CacheItemsSource))
		{
			return;
		}
		checked
		{
			int num = CacheItemsSource.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				switch (n)
				{
				case 1:
					CacheItemsSource[num2].Checked = true;
					break;
				case 2:
					CacheItemsSource[num2].Checked = false;
					break;
				case 3:
					CacheItemsSource[num2].Checked = !CacheItemsSource[num2].Checked;
					break;
				}
				num2++;
			}
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
		}
	}

	private void ListViewVR_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
	{
		if (CacheItemsSource != null && CacheItemsSource.Count != 0 && 0 == 0)
		{
			e.Item = CacheItemsSource[e.ItemIndex];
			if (e.ItemIndex == CacheItemsSource.Count)
			{
				CacheItemsSource = null;
			}
		}
	}

	private void ListViewVR_DrawItem(object sender, DrawListViewItemEventArgs e)
	{
		e.DrawDefault = true;
		if (!e.Item.Checked)
		{
			e.Item.Checked = true;
			e.Item.Checked = false;
		}
	}

	protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
	{
		base.OnDrawColumnHeader(e);
		Graphics graphics = e.Graphics;
		Rectangle bounds = e.Bounds;
		checked
		{
			if (e.ColumnIndex != 0)
			{
				bounds.X--;
				bounds.Width++;
			}
			TextFormatFlags formatFlags = GetFormatFlags(e.Header.TextAlign);
			TextRenderer.DrawText(bounds: new Rectangle(bounds.X + 3, bounds.Y, bounds.Width - 6, bounds.Height), dc: graphics, text: e.Header.Text, font: e.Font, foreColor: e.ForeColor, flags: formatFlags);
		}
	}

	protected TextFormatFlags GetFormatFlags(HorizontalAlignment align)
	{
		TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
		switch ((int)align)
		{
		case 2:
			textFormatFlags |= TextFormatFlags.HorizontalCenter;
			break;
		case 1:
			textFormatFlags |= TextFormatFlags.Right;
			break;
		case 0:
			textFormatFlags |= TextFormatFlags.Default;
			break;
		}
		return textFormatFlags;
	}

	private void ListViewVR_MouseClick(object sender, MouseEventArgs e)
	{
		ListView listView = (ListView)sender;
		listView.SuspendLayout();
		listView.Update();
		ListViewItem listViewItem = (ListViewItem)listView.GetItemAt(e.X, e.Y);
		if (listViewItem != null && (double)e.X < (double)listViewItem.Bounds.Left + 16.0 * dpixRatio)
		{
			listViewItem.Checked = !listViewItem.Checked;
			listView.Invalidate(listViewItem.Bounds);
		}
	}

	private void ListViewVR_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		ListView listView = (ListView)sender;
		ListViewItem listViewItem = (ListViewItem)listView.GetItemAt(e.X, e.Y);
		if (listViewItem != null)
		{
			listView.Invalidate(listViewItem.Bounds);
		}
	}

	private void ListViewVR_ColumnClick(object sender, ColumnClickEventArgs e)
	{
		mySort.columnToSort = e.Column;
		if (mySort.so == SortOrder.None)
		{
			mySort.so = SortOrder.Ascending;
		}
		mySort.so = ((mySort.so != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
		if (!Information.IsNothing(CacheItemsSource))
		{
			CacheItemsSource.Sort(mySort);
			VirtualListSize = CacheItemsSource.Count;
			Invalidate();
		}
	}

	protected virtual void OnHScroll(object sender, EventArgs e)
	{
		HScroll?.Invoke(this, e);
	}

	protected virtual void OnVScroll(object sender, EventArgs e)
	{
		VScroll?.Invoke(this, e);
	}

	private void ListViewVR_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 276)
		{
			OnHScroll(this, new EventArgs());
		}
		else if (m.Msg == 277)
		{
			OnVScroll(this, new EventArgs());
		}
		base.WndProc(ref m);
	}
}
