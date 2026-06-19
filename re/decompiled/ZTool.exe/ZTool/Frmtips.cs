using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class Frmtips : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__73
	{
		public int _0024VB_0024Local_rownumber;

		[DebuggerNonUserCode]
		public _Closure_0024__73(_Closure_0024__73 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_rownumber = other._0024VB_0024Local_rownumber;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__73()
		{
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__74
	{
		public int _0024VB_0024Local_rownumber;

		[DebuggerNonUserCode]
		public _Closure_0024__74(_Closure_0024__74 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_rownumber = other._0024VB_0024Local_rownumber;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__74()
		{
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("ListView1")]
	private ListViewVR _ListView1;

	[AccessedThroughProperty("ImageList1")]
	private ImageList _ImageList1;

	[AccessedThroughProperty("clearsel")]
	private ToolStripButton _clearsel;

	[AccessedThroughProperty("clearall")]
	private ToolStripButton _clearall;

	[AccessedThroughProperty("csmp2")]
	private ContextMenuStrip _csmp2;

	[AccessedThroughProperty("copydata")]
	private ToolStripMenuItem _copydata;

	private double dpixRatio;

	internal virtual ToolStrip ToolStrip1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStrip1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStrip1 = value;
		}
	}

	internal virtual ListViewVR ListView1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ListView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ListViewItemSelectionChangedEventHandler value2 = ListView1_ItemSelectionChanged;
			ListViewVirtualItemsSelectionRangeChangedEventHandler value3 = ListView1_VirtualItemsSelectionRangeChanged;
			if (_ListView1 != null)
			{
				_ListView1.ItemSelectionChanged -= value2;
				_ListView1.VirtualItemsSelectionRangeChanged -= value3;
			}
			_ListView1 = value;
			if (_ListView1 != null)
			{
				_ListView1.ItemSelectionChanged += value2;
				_ListView1.VirtualItemsSelectionRangeChanged += value3;
			}
		}
	}

	internal virtual ImageList ImageList1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ImageList1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ImageList1 = value;
		}
	}

	internal virtual ToolStripButton clearsel
	{
		[DebuggerNonUserCode]
		get
		{
			return _clearsel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = clearsel_Click;
			if (_clearsel != null)
			{
				_clearsel.Click -= value2;
			}
			_clearsel = value;
			if (_clearsel != null)
			{
				_clearsel.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton clearall
	{
		[DebuggerNonUserCode]
		get
		{
			return _clearall;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = clearall_Click;
			if (_clearall != null)
			{
				_clearall.Click -= value2;
			}
			_clearall = value;
			if (_clearall != null)
			{
				_clearall.Click += value2;
			}
		}
	}

	internal virtual ContextMenuStrip csmp2
	{
		[DebuggerNonUserCode]
		get
		{
			return _csmp2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			CancelEventHandler value2 = csmp2_Opening;
			if (_csmp2 != null)
			{
				_csmp2.Opening -= value2;
			}
			_csmp2 = value;
			if (_csmp2 != null)
			{
				_csmp2.Opening += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem copydata
	{
		[DebuggerNonUserCode]
		get
		{
			return _copydata;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = copydata_Click;
			if (_copydata != null)
			{
				_copydata.Click -= value2;
			}
			_copydata = value;
			if (_copydata != null)
			{
				_copydata.Click += value2;
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

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if ((disposing && components != null) ? true : false)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.Frmtips));
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.clearsel = new System.Windows.Forms.ToolStripButton();
		this.clearall = new System.Windows.Forms.ToolStripButton();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.ListView1 = new ZTool.ListViewVR();
		this.csmp2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.copydata = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStrip1.SuspendLayout();
		this.csmp2.SuspendLayout();
		this.SuspendLayout();
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.clearsel, this.clearall });
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		System.Drawing.Size size = new System.Drawing.Size(784, 25);
		toolStrip2.Size = size;
		this.ToolStrip1.TabIndex = 4;
		this.ToolStrip1.Text = "ToolStrip1";
		this.clearsel.Image = ZTool.My.Resources.Resources.delsel;
		this.clearsel.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton = this.clearsel;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
		toolStripButton.Margin = margin;
		this.clearsel.Name = "clearsel";
		System.Windows.Forms.ToolStripButton toolStripButton2 = this.clearsel;
		size = new System.Drawing.Size(76, 22);
		toolStripButton2.Size = size;
		this.clearsel.Text = "Удалить выбранное";
		this.clearall.Image = ZTool.My.Resources.Resources.del;
		this.clearall.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.clearall.Name = "clearall";
		System.Windows.Forms.ToolStripButton toolStripButton3 = this.clearall;
		size = new System.Drawing.Size(52, 22);
		toolStripButton3.Size = size;
		this.clearall.Text = "Очистить";
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "tip1_16x.png");
		this.ImageList1.Images.SetKeyName(1, "tip2_16x.png");
		this.ListView1.AllowDrop = true;
		this.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		this.ListView1.LargeImageList = this.ImageList1;
		ZTool.ListViewVR listView = this.ListView1;
		location = new System.Drawing.Point(0, 25);
		listView.Location = location;
		this.ListView1.Name = "ListView1";
		ZTool.ListViewVR listView2 = this.ListView1;
		size = new System.Drawing.Size(784, 293);
		listView2.Size = size;
		this.ListView1.SmallImageList = this.ImageList1;
		this.ListView1.TabIndex = 5;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.VirtualMode = true;
		this.csmp2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.copydata });
		this.csmp2.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.csmp2;
		size = new System.Drawing.Size(153, 48);
		contextMenuStrip.Size = size;
		this.copydata.Image = ZTool.My.Resources.Resources.copy_32;
		this.copydata.Name = "copydata";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.copydata;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem.Size = size;
		this.copydata.Text = "Копировать";
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(784, 318);
		this.ClientSize = size;
		this.ContextMenuStrip = this.csmp2;
		this.Controls.Add(this.ListView1);
		this.Controls.Add(this.ToolStrip1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.KeyPreview = true;
		margin = new System.Windows.Forms.Padding(6);
		this.Margin = margin;
		this.Name = "Frmtips";
		this.ShowIcon = false;
		this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Сообщение";
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.csmp2.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public Frmtips()
	{
		base.Load += Frmtips_Load;
		base.KeyPress += FrmUpdatelog_KeyPress;
		base.KeyDown += Frmtips_KeyDown;
		__ENCAddToList(this);
		dpixRatio = 1.0;
		InitializeComponent();
		try
		{
			using Graphics graphics = Graphics.FromHwnd(Handle);
			dpixRatio = graphics.DpiX / 96f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Frmtips_Load(object sender, EventArgs e)
	{
		ListView1.View = View.Details;
		ListView1.AllowDrop = false;
		ListView1.GridLines = true;
		ListView1.MultiSelect = true;
		ListView1.Clear();
		ListView1.Items.Clear();
		checked
		{
			int num = (int)Math.Round(50.0 * dpixRatio);
			int num2 = (int)Math.Round(150.0 * dpixRatio);
			int num3 = (int)Math.Round(50.0 * dpixRatio);
			int num4 = (int)Math.Round(200.0 * dpixRatio);
			int num5 = (int)Math.Round(100.0 * dpixRatio);
			int num6 = (int)Math.Round(400.0 * dpixRatio);
			ListView1.Columns.Add("", num, HorizontalAlignment.Left);
			ListView1.Columns.Add("Время", num2, HorizontalAlignment.Left);
			ListView1.Columns.Add("Строка", num3, HorizontalAlignment.Left);
			ListView1.Columns.Add("Описание", num4, HorizontalAlignment.Left);
			ListView1.Columns.Add("Действие", num5, HorizontalAlignment.Left);
			ListView1.Columns.Add("Название", num6, HorizontalAlignment.Left);
			loadview();
		}
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
		Close();
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void FrmUpdatelog_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void Frmtips_KeyDown(object sender, KeyEventArgs e)
	{
		if ((e.KeyCode == Keys.C && e.Modifiers == Keys.Control) ? true : false)
		{
			copyseldata();
		}
	}

	private void copydata_Click(object sender, EventArgs e)
	{
		copyseldata();
	}

	public void copyseldata()
	{
		StringBuilder stringBuilder = new StringBuilder();
		ListViewVR listView = ListView1;
		checked
		{
			int num = listView.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (listView.Items[num2].Selected)
				{
					stringBuilder.AppendLine(listView.Items[num2].SubItems[1].Text + "\t" + listView.Items[num2].SubItems[2].Text + "\t" + listView.Items[num2].SubItems[3].Text + "\t" + listView.Items[num2].SubItems[4].Text + "\t" + listView.Items[num2].SubItems[5].Text);
				}
				num2++;
			}
			listView = null;
			Clipboard.SetDataObject(stringBuilder.ToString().Trim());
		}
	}

	private void csmp2_Opening(object sender, CancelEventArgs e)
	{
		if ((ListView1.Items.Count > 0 && ListView1.SelectedIndices.Count > 0) ? true : false)
		{
			csmp2.Enabled = true;
		}
		else
		{
			csmp2.Enabled = false;
		}
	}

	private void clearsel_Click(object sender, EventArgs e)
	{
		ListView1.DelSelectItems();
		Refreshmsglist();
		if (ListView1.Items.Count == 0)
		{
			MyProject.Forms.Frmmain.StatusLabel1.Image = null;
		}
	}

	private void clearall_Click(object sender, EventArgs e)
	{
		ListView1.DelAllItems();
		Refreshmsglist();
		MyProject.Forms.Frmmain.StatusLabel1.Image = null;
	}

	private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		checked
		{
			try
			{
				int num = ListView1.Items.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					ListView1.Items[num2].BackColor = SystemColors.Window;
					num2++;
				}
				MyProject.Forms.Frmmain.DGV1.ClearSelection();
				bool flag = false;
				_Closure_0024__73 closure_0024__ = default(_Closure_0024__73);
				foreach (object selectedIndex in ListView1.SelectedIndices)
				{
					int index = Conversions.ToInteger(selectedIndex);
					closure_0024__ = new _Closure_0024__73(closure_0024__);
					ListView1.Items[index].BackColor = SystemColors.MenuHighlight;
					closure_0024__._0024VB_0024Local_rownumber = Conversions.ToInteger(ListView1.Items[index].SubItems[2].Text);
					DataGridViewRow dataGridViewRow = MyProject.Forms.Frmmain.DGV1.Rows.Cast<DataGridViewRow>().Where(closure_0024__._Lambda_0024__130).First();
					if (!Information.IsNothing(dataGridViewRow))
					{
						if (!flag)
						{
							MyProject.Forms.Frmmain.DGV1.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
							flag = true;
						}
						dataGridViewRow.Selected = true;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void ListView1_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
	{
		try
		{
			MyProject.Forms.Frmmain.DGV1.ClearSelection();
			bool flag = false;
			_Closure_0024__74 closure_0024__ = default(_Closure_0024__74);
			foreach (object selectedIndex in ListView1.SelectedIndices)
			{
				int index = Conversions.ToInteger(selectedIndex);
				closure_0024__ = new _Closure_0024__74(closure_0024__);
				ListView1.Items[index].BackColor = SystemColors.MenuHighlight;
				closure_0024__._0024VB_0024Local_rownumber = Conversions.ToInteger(ListView1.Items[index].SubItems[2].Text);
				DataGridViewRow dataGridViewRow = MyProject.Forms.Frmmain.DGV1.Rows.Cast<DataGridViewRow>().Where(closure_0024__._Lambda_0024__131).First();
				if (!Information.IsNothing(dataGridViewRow))
				{
					if (!flag)
					{
						MyProject.Forms.Frmmain.DGV1.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
						flag = true;
					}
					dataGridViewRow.Selected = true;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	internal void additem(int type, string row, string description, string operation, string pathname)
	{
		try
		{
			if (code.msglist.Count > 10000)
			{
				code.msglist.Clear();
			}
			code.msglist.Add(new code.msg
			{
				type = type,
				time = DateAndTime.Now.ToString(),
				row = row,
				description = description,
				operation = operation,
				pathname = pathname
			});
			MyProject.Forms.Frmmain.StatusLabel1.Image = Resources.tip1_32x;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void Refreshmsglist()
	{
		code.msglist.Clear();
		ListViewVR listView = ListView1;
		checked
		{
			int num = listView.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				code.msg item = new code.msg
				{
					type = listView.Items[num2].ImageIndex,
					time = listView.Items[num2].SubItems[1].Text,
					row = listView.Items[num2].SubItems[2].Text,
					description = listView.Items[num2].SubItems[3].Text,
					operation = listView.Items[num2].SubItems[4].Text,
					pathname = listView.Items[num2].SubItems[5].Text
				};
				code.msglist.Add(item);
				num2++;
			}
			listView = null;
		}
	}

	public void loadview()
	{
		List<ListViewItem> list = new List<ListViewItem>();
		checked
		{
			int num = code.msglist.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.ImageIndex = code.msglist[num2].type;
				listViewItem.SubItems[0].Text = Conversions.ToString(num2 + 1);
				listViewItem.SubItems.Add(code.msglist[num2].time);
				listViewItem.SubItems.Add(code.msglist[num2].row);
				listViewItem.SubItems.Add(code.msglist[num2].description);
				listViewItem.SubItems.Add(code.msglist[num2].operation);
				listViewItem.SubItems.Add(code.msglist[num2].pathname);
				list.Add(listViewItem);
				num2++;
			}
			ListView1.DelAllItems();
			ListView1.AddData(list);
			MyProject.Forms.Frmmain.StatusLabel1.Image = null;
			if (ListView1.Items.Count > 0)
			{
				ListView1.Items[ListView1.Items.Count - 1].EnsureVisible();
			}
		}
	}
}
