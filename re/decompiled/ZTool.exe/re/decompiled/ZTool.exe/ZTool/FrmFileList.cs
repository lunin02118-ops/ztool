using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser1;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmFileList : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__35
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__35(_Closure_0024__35 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__35()
		{
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("ListView1")]
	private ListViewVR _ListView1;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("Button4")]
	private Button _Button4;

	[AccessedThroughProperty("Panel2")]
	private Panel _Panel2;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("csmp2")]
	private ContextMenuStrip _csmp2;

	[AccessedThroughProperty("openinsw")]
	private ToolStripMenuItem _openinsw;

	[AccessedThroughProperty("openinfolder")]
	private ToolStripMenuItem _openinfolder;

	[AccessedThroughProperty("OnlyHasDrw")]
	private CheckBox _OnlyHasDrw;

	[AccessedThroughProperty("Menu1")]
	private ContextMenuStrip _Menu1;

	[AccessedThroughProperty("AddFromfile")]
	private ToolStripMenuItem _AddFromfile;

	[AccessedThroughProperty("AddFromFolder")]
	private ToolStripMenuItem _AddFromFolder;

	[AccessedThroughProperty("AddFromsw")]
	private ToolStripMenuItem _AddFromsw;

	private double dpixRatio;

	private int selrow;

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
			DragEventHandler value2 = ListView1_DragDrop;
			ListViewItemSelectionChangedEventHandler value3 = ListView1_ItemSelectionChanged;
			DragEventHandler value4 = ListView1_DragEnter;
			if (_ListView1 != null)
			{
				_ListView1.DragDrop -= value2;
				_ListView1.ItemSelectionChanged -= value3;
				_ListView1.DragEnter -= value4;
			}
			_ListView1 = value;
			if (_ListView1 != null)
			{
				_ListView1.DragDrop += value2;
				_ListView1.ItemSelectionChanged += value3;
				_ListView1.DragEnter += value4;
			}
		}
	}

	internal virtual Panel Panel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Panel1 = value;
		}
	}

	internal virtual Button Button1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button1_Click;
			if (_Button1 != null)
			{
				_Button1.Click -= value2;
			}
			_Button1 = value;
			if (_Button1 != null)
			{
				_Button1.Click += value2;
			}
		}
	}

	internal virtual Button Button2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button2_Click;
			if (_Button2 != null)
			{
				_Button2.Click -= value2;
			}
			_Button2 = value;
			if (_Button2 != null)
			{
				_Button2.Click += value2;
			}
		}
	}

	internal virtual Button Button3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button3_Click;
			if (_Button3 != null)
			{
				_Button3.Click -= value2;
			}
			_Button3 = value;
			if (_Button3 != null)
			{
				_Button3.Click += value2;
			}
		}
	}

	internal virtual Button Button4
	{
		[DebuggerNonUserCode]
		get
		{
			return _Button4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Button4_Click;
			if (_Button4 != null)
			{
				_Button4.Click -= value2;
			}
			_Button4 = value;
			if (_Button4 != null)
			{
				_Button4.Click += value2;
			}
		}
	}

	internal virtual Panel Panel2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Panel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Panel2 = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox1 = value;
		}
	}

	internal virtual Label Label1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label1 = value;
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
			_csmp2 = value;
		}
	}

	internal virtual ToolStripMenuItem openinsw
	{
		[DebuggerNonUserCode]
		get
		{
			return _openinsw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = openinsw_Click;
			if (_openinsw != null)
			{
				_openinsw.Click -= value2;
			}
			_openinsw = value;
			if (_openinsw != null)
			{
				_openinsw.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem openinfolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _openinfolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = openinfolder_Click;
			if (_openinfolder != null)
			{
				_openinfolder.Click -= value2;
			}
			_openinfolder = value;
			if (_openinfolder != null)
			{
				_openinfolder.Click += value2;
			}
		}
	}

	internal virtual CheckBox OnlyHasDrw
	{
		[DebuggerNonUserCode]
		get
		{
			return _OnlyHasDrw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_OnlyHasDrw = value;
		}
	}

	internal virtual ContextMenuStrip Menu1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Menu1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			CancelEventHandler value2 = Menu1_Opening;
			if (_Menu1 != null)
			{
				_Menu1.Opening -= value2;
			}
			_Menu1 = value;
			if (_Menu1 != null)
			{
				_Menu1.Opening += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AddFromfile
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddFromfile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddFromfile_Click;
			if (_AddFromfile != null)
			{
				_AddFromfile.Click -= value2;
			}
			_AddFromfile = value;
			if (_AddFromfile != null)
			{
				_AddFromfile.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AddFromFolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddFromFolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddFromFolder_Click;
			if (_AddFromFolder != null)
			{
				_AddFromFolder.Click -= value2;
			}
			_AddFromFolder = value;
			if (_AddFromFolder != null)
			{
				_AddFromFolder.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem AddFromsw
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddFromsw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddFromsw_Click;
			if (_AddFromsw != null)
			{
				_AddFromsw.Click -= value2;
			}
			_AddFromsw = value;
			if (_AddFromsw != null)
			{
				_AddFromsw.Click += value2;
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
		this.csmp2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.openinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.openinfolder = new System.Windows.Forms.ToolStripMenuItem();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.OnlyHasDrw = new System.Windows.Forms.CheckBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ListView1 = new ZTool.ListViewVR();
		this.Button1 = new System.Windows.Forms.Button();
		this.Menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.AddFromfile = new System.Windows.Forms.ToolStripMenuItem();
		this.AddFromFolder = new System.Windows.Forms.ToolStripMenuItem();
		this.AddFromsw = new System.Windows.Forms.ToolStripMenuItem();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.Button4 = new System.Windows.Forms.Button();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.csmp2.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.Menu1.SuspendLayout();
		this.Panel2.SuspendLayout();
		this.SuspendLayout();
		this.csmp2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.openinsw, this.openinfolder });
		this.csmp2.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.csmp2;
		System.Drawing.Size size = new System.Drawing.Size(188, 48);
		contextMenuStrip.Size = size;
		this.openinsw.Image = ZTool.My.Resources.Resources.SW_32px;
		this.openinsw.Name = "openinsw";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.openinsw;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem.Size = size;
		this.openinsw.Text = "Открыть в SolidWorks";
		this.openinfolder.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.openinfolder.Name = "openinfolder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.openinfolder;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem2.Size = size;
		this.openinfolder.Text = "Открыть в папке";
		this.Panel1.Controls.Add(this.OnlyHasDrw);
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.GroupBox1);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.Panel panel = this.Panel1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		panel.Location = location;
		System.Windows.Forms.Panel panel2 = this.Panel1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel2.Margin = margin;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel3 = this.Panel1;
		margin = new System.Windows.Forms.Padding(6, 6, 6, 30);
		panel3.Padding = margin;
		System.Windows.Forms.Panel panel4 = this.Panel1;
		size = new System.Drawing.Size(494, 291);
		panel4.Size = size;
		this.Panel1.TabIndex = 2;
		this.OnlyHasDrw.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.OnlyHasDrw.AutoSize = true;
		System.Windows.Forms.CheckBox onlyHasDrw = this.OnlyHasDrw;
		location = new System.Drawing.Point(359, 265);
		onlyHasDrw.Location = location;
		this.OnlyHasDrw.Name = "OnlyHasDrw";
		System.Windows.Forms.CheckBox onlyHasDrw2 = this.OnlyHasDrw;
		size = new System.Drawing.Size(123, 21);
		onlyHasDrw2.Size = size;
		this.OnlyHasDrw.TabIndex = 4;
		this.OnlyHasDrw.Text = "Только элементы, имеющие чертежи";
		this.OnlyHasDrw.UseVisualStyleBackColor = true;
		this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(16, 267);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(0, 17);
		label2.Size = size;
		this.Label1.TabIndex = 4;
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.GroupBox1.Controls.Add(this.ListView1);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(6, 6);
		groupBox.Location = location;
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox2.Margin = margin;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
		groupBox3.Padding = margin;
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox1;
		size = new System.Drawing.Size(482, 255);
		groupBox4.Size = size;
		this.GroupBox1.TabIndex = 2;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Список файлов (можно перетаскивать файлы или папки прямо в список)";
		this.ListView1.AllowDrop = true;
		this.ListView1.ContextMenuStrip = this.csmp2;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		ZTool.ListViewVR listView = this.ListView1;
		location = new System.Drawing.Point(6, 24);
		listView.Location = location;
		ZTool.ListViewVR listView2 = this.ListView1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		listView2.Margin = margin;
		this.ListView1.Name = "ListView1";
		ZTool.ListViewVR listView3 = this.ListView1;
		size = new System.Drawing.Size(470, 223);
		listView3.Size = size;
		this.ListView1.TabIndex = 1;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.VirtualMode = true;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.ContextMenuStrip = this.Menu1;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(10, 15);
		button.Location = location;
		System.Windows.Forms.Button button2 = this.Button1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		button2.Margin = margin;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button3 = this.Button1;
		size = new System.Drawing.Size(70, 30);
		button3.Size = size;
		this.Button1.TabIndex = 3;
		this.Button1.Text = "Добавить...";
		this.Button1.UseVisualStyleBackColor = true;
		this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.AddFromfile, this.AddFromFolder, this.AddFromsw });
		this.Menu1.Name = "Menu1";
		this.Menu1.ShowImageMargin = false;
		System.Windows.Forms.ContextMenuStrip menu = this.Menu1;
		size = new System.Drawing.Size(235, 70);
		menu.Size = size;
		this.AddFromfile.Name = "AddFromfile";
		System.Windows.Forms.ToolStripMenuItem addFromfile = this.AddFromfile;
		size = new System.Drawing.Size(234, 22);
		addFromfile.Size = size;
		this.AddFromfile.Text = "Добавить файл";
		this.AddFromFolder.Name = "AddFromFolder";
		System.Windows.Forms.ToolStripMenuItem addFromFolder = this.AddFromFolder;
		size = new System.Drawing.Size(234, 22);
		addFromFolder.Size = size;
		this.AddFromFolder.Text = "Добавить папку";
		this.AddFromsw.Name = "AddFromsw";
		System.Windows.Forms.ToolStripMenuItem addFromsw = this.AddFromsw;
		size = new System.Drawing.Size(234, 22);
		addFromsw.Size = size;
		this.AddFromsw.Text = "Добавить открытые в SolidWorks компоненты";
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.Button button4 = this.Button2;
		location = new System.Drawing.Point(10, 61);
		button4.Location = location;
		System.Windows.Forms.Button button5 = this.Button2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		button5.Margin = margin;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button6 = this.Button2;
		size = new System.Drawing.Size(70, 30);
		button6.Size = size;
		this.Button2.TabIndex = 3;
		this.Button2.Text = "Удалить выбранное";
		this.Button2.UseVisualStyleBackColor = true;
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.Button button7 = this.Button3;
		location = new System.Drawing.Point(10, 107);
		button7.Location = location;
		System.Windows.Forms.Button button8 = this.Button3;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		button8.Margin = margin;
		this.Button3.Name = "Button3";
		System.Windows.Forms.Button button9 = this.Button3;
		size = new System.Drawing.Size(70, 30);
		button9.Size = size;
		this.Button3.TabIndex = 3;
		this.Button3.Text = "Очистить";
		this.Button3.UseVisualStyleBackColor = true;
		this.Button4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.Button button10 = this.Button4;
		location = new System.Drawing.Point(10, 245);
		button10.Location = location;
		System.Windows.Forms.Button button11 = this.Button4;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		button11.Margin = margin;
		this.Button4.Name = "Button4";
		System.Windows.Forms.Button button12 = this.Button4;
		size = new System.Drawing.Size(70, 30);
		button12.Size = size;
		this.Button4.TabIndex = 3;
		this.Button4.Text = "Подтвердить";
		this.Button4.UseVisualStyleBackColor = true;
		this.Panel2.Controls.Add(this.Button1);
		this.Panel2.Controls.Add(this.Button4);
		this.Panel2.Controls.Add(this.Button2);
		this.Panel2.Controls.Add(this.Button3);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Right;
		System.Windows.Forms.Panel panel5 = this.Panel2;
		location = new System.Drawing.Point(494, 0);
		panel5.Location = location;
		System.Windows.Forms.Panel panel6 = this.Panel2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		panel6.Margin = margin;
		this.Panel2.Name = "Panel2";
		System.Windows.Forms.Panel panel7 = this.Panel2;
		size = new System.Drawing.Size(90, 291);
		panel7.Size = size;
		this.Panel2.TabIndex = 4;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(584, 291);
		this.ClientSize = size;
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.Panel2);
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.Margin = margin;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		size = new System.Drawing.Size(600, 330);
		this.MinimumSize = size;
		this.Name = "FrmFileList";
		this.ShowIcon = false;
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Список файлов для чтения";
		this.csmp2.ResumeLayout(false);
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.Menu1.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	public FrmFileList()
	{
		base.Load += FrmFileList_Load;
		__ENCAddToList(this);
		dpixRatio = 1.0;
		InitializeComponent();
		using Graphics graphics = Graphics.FromHwnd(Handle);
		dpixRatio = graphics.DpiX / 96f;
	}

	private void FrmFileList_Load(object sender, EventArgs e)
	{
		ListView1.View = View.Details;
		ListView1.AllowDrop = true;
		ListView1.GridLines = true;
		ListView1.MultiSelect = true;
		ListView1.Clear();
		ListView1.Items.Clear();
		checked
		{
			int num = (int)Math.Round(50.0 * dpixRatio);
			int num2 = (int)Math.Round(600.0 * dpixRatio);
			ListView1.Columns.Add("Номер", num, HorizontalAlignment.Left);
			ListView1.Columns.Add("Путь", num2, HorizontalAlignment.Left);
		}
	}

	public void loadview(List<string> f)
	{
		List<string> list = new List<string>();
		int num = 0;
		ListViewVR listView = ListView1;
		num = listView.Items.Count;
		checked
		{
			int num2 = listView.Items.Count - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				list.Add(listView.Items[num3].SubItems[1].Text);
				num++;
				num3++;
			}
			listView = null;
			int num6 = f.Count - 1;
			int num7 = 0;
			_Closure_0024__35 closure_0024__ = default(_Closure_0024__35);
			while (true)
			{
				int num8 = num7;
				int num5 = num6;
				if (num8 > num5)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__35(closure_0024__);
				closure_0024__._0024VB_0024Local_str = "\\" + code.SplitStr(f[num7], 4);
				if (!list.Exists(closure_0024__._Lambda_0024__72))
				{
					list.Add(f[num7]);
				}
				num7++;
			}
			if (list.Count == 0)
			{
				return;
			}
			List<ListViewItem> list2 = new List<ListViewItem>();
			int num9 = list.Count - 1;
			int num10 = 0;
			while (true)
			{
				int num11 = num10;
				int num5 = num9;
				if (num11 > num5)
				{
					break;
				}
				if (OnlyHasDrw.Checked)
				{
					string path = code.SplitStr(list[num10], 3) + ".SLDDRW";
					if (!File.Exists(path))
					{
						goto IL_01be;
					}
				}
				num++;
				if ((code.TMode && num > 10) ? true : false)
				{
					MessageBox.Show(this, "Пробная версия поддерживает не более 10 файлов", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.SubItems[0].Text = Conversions.ToString(num10 + 1);
				listViewItem.SubItems.Add(list[num10]);
				list2.Add(listViewItem);
				goto IL_01be;
				IL_01be:
				num10++;
			}
			ListView1.AddData(list2);
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Menu1.Show(Button1, 0, Button1.Height);
	}

	private void ListView1_DragDrop(object sender, DragEventArgs e)
	{
		bool flag = false;
		string text = "";
		bool flag2 = false;
		bool onlyhasdrw = false;
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			return;
		}
		List<string> list = new List<string>();
		string[] array = null;
		array = (string[])e.Data.GetData(DataFormats.FileDrop);
		checked
		{
			int num = array.Length - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (array[num2].EndsWith("sldasm", StringComparison.OrdinalIgnoreCase) || (array[num2].EndsWith("sldprt", StringComparison.OrdinalIgnoreCase) ? true : false))
				{
					list.Add(array[num2]);
				}
				else if (Directory.Exists(array[num2]))
				{
					if (!flag)
					{
						MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Visible = false;
						MyProject.Forms.FrmSelType2.Includesubfolders.Visible = true;
						if (MyProject.Forms.FrmSelType2.ShowDialog() == DialogResult.Cancel)
						{
							goto IL_018a;
						}
						if (MyProject.Forms.FrmSelType2.TYPE_SLDPRT.Checked)
						{
							text += "|*.SLDPRT";
						}
						if (MyProject.Forms.FrmSelType2.TYPE_SLDASM.Checked)
						{
							text += "|*.SLDASM";
						}
						flag2 = MyProject.Forms.FrmSelType2.Includesubfolders.Checked;
						onlyhasdrw = MyProject.Forms.FrmSelType2.Onlyhasdrw.Checked;
					}
					code.SearchFiles(list, array[num2], onlyhasdrw, text, flag2);
					flag = true;
				}
				goto IL_018a;
				IL_018a:
				num2++;
			}
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
				if (ListView1.Items.Count > 0)
				{
					Label1.Text = "Всего" + Conversions.ToString(ListView1.Items.Count) + "файлов";
				}
				else
				{
					Label1.Text = "";
				}
			}
		}
	}

	private void ListView1_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.All;
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		if (ListView1.Items.Count != 0 && Interaction.MsgBox("Точно очистить список?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question, "Вопрос") == MsgBoxResult.Ok)
		{
			ListView1.DelAllItems();
			Label1.Text = "";
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		ListView1.DelSelectItems();
		if (ListView1.Items.Count > 0)
		{
			Label1.Text = "Всего" + Conversions.ToString(ListView1.Items.Count) + "файлов";
		}
		else
		{
			Label1.Text = "";
		}
	}

	private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		try
		{
			selrow = ListView1.SelectedIndices[0];
			string text = ListView1.Items[selrow].SubItems[1].Text;
			if (CConfigMng.Config.Previewfortool)
			{
				MyProject.Forms.FrmPreview.ChangePre = false;
				code.Preview2(Conversions.ToBoolean(Interaction.IIf(string.Equals(code.SplitStr(text, 5), ".slddrw", StringComparison.CurrentCultureIgnoreCase), true, false)), text, "", this);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void openinsw_Click(object sender, EventArgs e)
	{
		try
		{
			string text = ListView1.Items[selrow].SubItems[1].Text;
			if (File.Exists(text))
			{
				Thread thread = new Thread([SpecialName] [DebuggerStepThrough] (object a0) =>
				{
					code.OpenDoc(Conversions.ToString(a0));
				});
				thread.Start(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void openinfolder_Click(object sender, EventArgs e)
	{
		try
		{
			string text = ListView1.Items[selrow].SubItems[1].Text;
			if (File.Exists(text))
			{
				Interaction.Shell("explorer.exe /select," + text, AppWinStyle.NormalFocus);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
		Close();
	}

	private void Menu1_Opening(object sender, CancelEventArgs e)
	{
	}

	private void AddFromsw_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Visible = false;
		MyProject.Forms.FrmSelType2.Includesubfolders.Visible = false;
		if (MyProject.Forms.FrmSelType2.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		List<string> list = new List<string>();
		bool flag = false;
		if (MyProject.Forms.FrmSelType2.TYPE_SLDPRT.Checked)
		{
			list.Add(".SLDPRT");
		}
		if (MyProject.Forms.FrmSelType2.TYPE_SLDASM.Checked)
		{
			list.Add(".SLDASM");
		}
		flag = MyProject.Forms.FrmSelType2.Onlyhasdrw.Checked;
		List<string> list2 = new List<string>();
		object objectValue = RuntimeHelpers.GetObjectValue(new object());
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		checked
		{
			for (objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetFirstDocument", new object[0], null, null, null)); objectValue != null; objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetNext", new object[0], null, null, null)))
			{
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null));
				int num = list.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (text.EndsWith(list[num2], StringComparison.OrdinalIgnoreCase) && (((flag && File.Exists(code.SplitStr(text, 3) + ".slddrw")) || !flag) ? true : false))
					{
						list2.Add(text);
					}
					num2++;
				}
			}
			NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
			if (list2.Count != 0)
			{
				loadview(list2);
				objectValue = null;
			}
		}
	}

	private void AddFromfile_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			openFileDialog.SupportMultiDottedExtensions = true;
			openFileDialog.Filter = "Деталь (*.SLDPRT)|*.SLDPRT|Сборка (*.SLDASM)|*.SLDASM|Файлы SOLIDWORKS (*.SLDPRT;*.SLDASM)|*.SLDPRT;*.SLDASM";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			string[] fileNames = openFileDialog.FileNames;
			List<string> list = new List<string>();
			int num = Information.LBound(fileNames);
			int num2 = Information.UBound(fileNames);
			int num3 = num;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				list.Add(fileNames[num3]);
				num3 = checked(num3 + 1);
			}
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
				if (ListView1.Items.Count > 0)
				{
					Label1.Text = "Всего" + Conversions.ToString(ListView1.Items.Count) + "файлов";
				}
				else
				{
					Label1.Text = "";
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void AddFromFolder_Click(object sender, EventArgs e)
	{
		string text = "";
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			text = fileBorser.DirectoryPath;
		}
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return;
		}
		MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Visible = false;
		MyProject.Forms.FrmSelType2.Includesubfolders.Visible = true;
		if (MyProject.Forms.FrmSelType2.ShowDialog() != DialogResult.Cancel)
		{
			string text2 = "";
			bool flag = false;
			bool flag2 = false;
			if (MyProject.Forms.FrmSelType2.TYPE_SLDPRT.Checked)
			{
				text2 += "|*.SLDPRT";
			}
			if (MyProject.Forms.FrmSelType2.TYPE_SLDASM.Checked)
			{
				text2 += "|*.SLDASM";
			}
			flag = MyProject.Forms.FrmSelType2.Includesubfolders.Checked;
			flag2 = MyProject.Forms.FrmSelType2.Onlyhasdrw.Checked;
			List<string> list = new List<string>();
			code.SearchFiles(list, text, flag2, text2, flag);
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
			}
		}
	}
}
