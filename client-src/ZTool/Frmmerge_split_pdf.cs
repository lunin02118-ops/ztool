using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
public class Frmmerge_split_pdf : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("addfiles")]
	private ToolStripSplitButton _addfiles;

	[AccessedThroughProperty("addfilesformfolder1")]
	private ToolStripMenuItem _addfilesformfolder1;

	[AccessedThroughProperty("addfilesformfolder2")]
	private ToolStripMenuItem _addfilesformfolder2;

	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator _ToolStripSeparator2;

	[AccessedThroughProperty("clearsel")]
	private ToolStripButton _clearsel;

	[AccessedThroughProperty("clearall")]
	private ToolStripButton _clearall;

	[AccessedThroughProperty("ToolStripSeparator1")]
	private ToolStripSeparator _ToolStripSeparator1;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("ToolStripStatusLabel1")]
	private ToolStripStatusLabel _ToolStripStatusLabel1;

	[AccessedThroughProperty("ToolStripProgressBar1")]
	private ToolStripProgressBar _ToolStripProgressBar1;

	[AccessedThroughProperty("openinsw")]
	private ToolStripMenuItem _openinsw;

	[AccessedThroughProperty("csmp2")]
	private ContextMenuStrip _csmp2;

	[AccessedThroughProperty("openinfolder")]
	private ToolStripMenuItem _openinfolder;

	[AccessedThroughProperty("ListView1")]
	private ListViewVR _ListView1;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("OK_Button")]
	private ToolStripDropDownButton _OK_Button;

	[AccessedThroughProperty("merge_pdf")]
	private ToolStripMenuItem _merge_pdf;

	[AccessedThroughProperty("split_pdf")]
	private ToolStripMenuItem _split_pdf;

	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton _ToolStripButton1;

	[AccessedThroughProperty("ToolStripButton2")]
	private ToolStripButton _ToolStripButton2;

	[AccessedThroughProperty("ToolStripSeparator3")]
	private ToolStripSeparator _ToolStripSeparator3;

	internal bool Abort;

	private Thread mythread;

	private double dpixRatio;

	private int selrow;

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
			PaintEventHandler value2 = ToolStrip1_Paint;
			if (_ToolStrip1 != null)
			{
				_ToolStrip1.Paint -= value2;
			}
			_ToolStrip1 = value;
			if (_ToolStrip1 != null)
			{
				_ToolStrip1.Paint += value2;
			}
		}
	}

	internal virtual ToolStripSplitButton addfiles
	{
		[DebuggerNonUserCode]
		get
		{
			return _addfiles;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = addfiles_MouseMove;
			EventHandler value3 = addfiles_Click;
			if (_addfiles != null)
			{
				_addfiles.MouseMove -= value2;
				_addfiles.ButtonClick -= value3;
			}
			_addfiles = value;
			if (_addfiles != null)
			{
				_addfiles.MouseMove += value2;
				_addfiles.ButtonClick += value3;
			}
		}
	}

	internal virtual ToolStripMenuItem addfilesformfolder1
	{
		[DebuggerNonUserCode]
		get
		{
			return _addfilesformfolder1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addfilesformfolder_Click;
			if (_addfilesformfolder1 != null)
			{
				_addfilesformfolder1.Click -= value2;
			}
			_addfilesformfolder1 = value;
			if (_addfilesformfolder1 != null)
			{
				_addfilesformfolder1.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem addfilesformfolder2
	{
		[DebuggerNonUserCode]
		get
		{
			return _addfilesformfolder2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = addfilesformfolder_Click;
			if (_addfilesformfolder2 != null)
			{
				_addfilesformfolder2.Click -= value2;
			}
			_addfilesformfolder2 = value;
			if (_addfilesformfolder2 != null)
			{
				_addfilesformfolder2.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator2 = value;
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

	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator1 = value;
		}
	}

	internal virtual StatusStrip StatusStrip1
	{
		[DebuggerNonUserCode]
		get
		{
			return _StatusStrip1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_StatusStrip1 = value;
		}
	}

	internal virtual ToolStripStatusLabel ToolStripStatusLabel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripStatusLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripStatusLabel1 = value;
		}
	}

	internal virtual ToolStripProgressBar ToolStripProgressBar1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripProgressBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripProgressBar1 = value;
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

	internal virtual ToolStripDropDownButton OK_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _OK_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = OK_Button_MouseMove;
			if (_OK_Button != null)
			{
				_OK_Button.MouseMove -= value2;
			}
			_OK_Button = value;
			if (_OK_Button != null)
			{
				_OK_Button.MouseMove += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem merge_pdf
	{
		[DebuggerNonUserCode]
		get
		{
			return _merge_pdf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = merge_pdf_Click;
			if (_merge_pdf != null)
			{
				_merge_pdf.Click -= value2;
			}
			_merge_pdf = value;
			if (_merge_pdf != null)
			{
				_merge_pdf.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem split_pdf
	{
		[DebuggerNonUserCode]
		get
		{
			return _split_pdf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = split_pdf_Click;
			if (_split_pdf != null)
			{
				_split_pdf.Click -= value2;
			}
			_split_pdf = value;
			if (_split_pdf != null)
			{
				_split_pdf.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripButton1_Click;
			if (_ToolStripButton1 != null)
			{
				_ToolStripButton1.Click -= value2;
			}
			_ToolStripButton1 = value;
			if (_ToolStripButton1 != null)
			{
				_ToolStripButton1.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripButton2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripButton2_Click;
			if (_ToolStripButton2 != null)
			{
				_ToolStripButton2.Click -= value2;
			}
			_ToolStripButton2 = value;
			if (_ToolStripButton2 != null)
			{
				_ToolStripButton2.Click += value2;
			}
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator3
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator3 = value;
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
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.addfiles = new System.Windows.Forms.ToolStripSplitButton();
		this.addfilesformfolder1 = new System.Windows.Forms.ToolStripMenuItem();
		this.addfilesformfolder2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.clearsel = new System.Windows.Forms.ToolStripButton();
		this.clearall = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.OK_Button = new System.Windows.Forms.ToolStripDropDownButton();
		this.merge_pdf = new System.Windows.Forms.ToolStripMenuItem();
		this.split_pdf = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		this.openinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.csmp2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.openinfolder = new System.Windows.Forms.ToolStripMenuItem();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ListView1 = new ZTool.ListViewVR();
		this.ToolStrip1.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.csmp2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		this.ToolStrip1.AutoSize = false;
		this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
		this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.addfiles, this.ToolStripSeparator2, this.clearsel, this.clearall, this.ToolStripSeparator1, this.OK_Button, this.ToolStripButton1, this.ToolStripButton2, this.ToolStripSeparator3 });
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(2, 2, 2, 5);
		toolStrip2.Padding = padding;
		this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		System.Windows.Forms.ToolStrip toolStrip3 = this.ToolStrip1;
		System.Drawing.Size size = new System.Drawing.Size(684, 40);
		toolStrip3.Size = size;
		this.ToolStrip1.TabIndex = 16;
		this.ToolStrip1.Text = "ToolStrip1";
		this.addfiles.DropDownButtonWidth = 20;
		this.addfiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.addfilesformfolder1, this.addfilesformfolder2 });
		this.addfiles.Image = ZTool.My.Resources.Resources.pdf_32;
		this.addfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripSplitButton toolStripSplitButton = this.addfiles;
		padding = new System.Windows.Forms.Padding(10, 1, 2, 2);
		toolStripSplitButton.Margin = padding;
		this.addfiles.Name = "addfiles";
		System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2 = this.addfiles;
		size = new System.Drawing.Size(97, 30);
		toolStripSplitButton2.Size = size;
		this.addfiles.Text = "Добавить файл";
		this.addfilesformfolder1.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.addfilesformfolder1.Name = "addfilesformfolder1";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.addfilesformfolder1;
		size = new System.Drawing.Size(232, 22);
		toolStripMenuItem.Size = size;
		this.addfilesformfolder1.Tag = "false";
		this.addfilesformfolder1.Text = "Добавить папку";
		this.addfilesformfolder2.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.addfilesformfolder2.Name = "addfilesformfolder2";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.addfilesformfolder2;
		size = new System.Drawing.Size(232, 22);
		toolStripMenuItem2.Size = size;
		this.addfilesformfolder2.Tag = "true";
		this.addfilesformfolder2.Text = "Добавить папку (включая подпапки)";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator = this.ToolStripSeparator2;
		padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
		toolStripSeparator.Margin = padding;
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator2 = this.ToolStripSeparator2;
		size = new System.Drawing.Size(6, 33);
		toolStripSeparator2.Size = size;
		this.clearsel.Image = ZTool.My.Resources.Resources.delsel;
		this.clearsel.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton = this.clearsel;
		padding = new System.Windows.Forms.Padding(5, 1, 0, 2);
		toolStripButton.Margin = padding;
		this.clearsel.Name = "clearsel";
		System.Windows.Forms.ToolStripButton toolStripButton2 = this.clearsel;
		size = new System.Drawing.Size(76, 30);
		toolStripButton2.Size = size;
		this.clearsel.Text = "Удалить выбранное";
		this.clearall.Image = ZTool.My.Resources.Resources.del;
		this.clearall.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.clearall.Name = "clearall";
		System.Windows.Forms.ToolStripButton toolStripButton3 = this.clearall;
		size = new System.Drawing.Size(52, 30);
		toolStripButton3.Size = size;
		this.clearall.Text = "Очистить";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator3 = this.ToolStripSeparator1;
		padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
		toolStripSeparator3.Margin = padding;
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = this.ToolStripSeparator1;
		size = new System.Drawing.Size(6, 33);
		toolStripSeparator4.Size = size;
		this.OK_Button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.OK_Button.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.merge_pdf, this.split_pdf });
		this.OK_Button.Image = ZTool.My.Resources.Resources.Start_24x;
		this.OK_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripDropDownButton oK_Button = this.OK_Button;
		padding = new System.Windows.Forms.Padding(0, 1, 20, 2);
		oK_Button.Margin = padding;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.ToolStripDropDownButton oK_Button2 = this.OK_Button;
		padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
		oK_Button2.Padding = padding;
		System.Windows.Forms.ToolStripDropDownButton oK_Button3 = this.OK_Button;
		size = new System.Drawing.Size(101, 30);
		oK_Button3.Size = size;
		this.OK_Button.Text = "开始";
		this.merge_pdf.Name = "merge_pdf";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.merge_pdf;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem3.Size = size;
		this.merge_pdf.Text = "Объединить PDF";
		this.split_pdf.Name = "split_pdf";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4 = this.split_pdf;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem4.Size = size;
		this.split_pdf.Text = "Разделить PDF";
		this.ToolStripButton1.Image = ZTool.My.Resources.Resources.moveup_32;
		this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton1.Name = "ToolStripButton1";
		System.Windows.Forms.ToolStripButton toolStripButton4 = this.ToolStripButton1;
		size = new System.Drawing.Size(52, 30);
		toolStripButton4.Size = size;
		this.ToolStripButton1.Text = "Вверх";
		this.ToolStripButton2.Image = ZTool.My.Resources.Resources.movedown_32;
		this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton2.Name = "ToolStripButton2";
		System.Windows.Forms.ToolStripButton toolStripButton5 = this.ToolStripButton2;
		size = new System.Drawing.Size(52, 30);
		toolStripButton5.Size = size;
		this.ToolStripButton2.Text = "Вниз";
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator5 = this.ToolStripSeparator3;
		size = new System.Drawing.Size(6, 33);
		toolStripSeparator5.Size = size;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ToolStripStatusLabel1, this.ToolStripProgressBar1 });
		System.Windows.Forms.StatusStrip statusStrip = this.StatusStrip1;
		location = new System.Drawing.Point(0, 429);
		statusStrip.Location = location;
		this.StatusStrip1.Name = "StatusStrip1";
		System.Windows.Forms.StatusStrip statusStrip2 = this.StatusStrip1;
		size = new System.Drawing.Size(684, 22);
		statusStrip2.Size = size;
		this.StatusStrip1.TabIndex = 17;
		this.StatusStrip1.Text = "StatusStrip1";
		this.ToolStripStatusLabel1.AutoSize = false;
		this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
		System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel = this.ToolStripStatusLabel1;
		size = new System.Drawing.Size(134, 17);
		toolStripStatusLabel.Size = size;
		this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
		System.Windows.Forms.ToolStripProgressBar toolStripProgressBar = this.ToolStripProgressBar1;
		size = new System.Drawing.Size(300, 16);
		toolStripProgressBar.Size = size;
		this.openinsw.Image = ZTool.My.Resources.Resources.pdf_32;
		this.openinsw.Name = "openinsw";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5 = this.openinsw;
		size = new System.Drawing.Size(160, 22);
		toolStripMenuItem5.Size = size;
		this.openinsw.Text = "Открыть PDF";
		this.csmp2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.openinsw, this.openinfolder });
		this.csmp2.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.csmp2;
		size = new System.Drawing.Size(161, 70);
		contextMenuStrip.Size = size;
		this.openinfolder.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.openinfolder.Name = "openinfolder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6 = this.openinfolder;
		size = new System.Drawing.Size(160, 22);
		toolStripMenuItem6.Size = size;
		this.openinfolder.Text = "Открыть в папке";
		this.GroupBox1.Controls.Add(this.ListView1);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(0, 40);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		padding = new System.Windows.Forms.Padding(12, 6, 12, 12);
		groupBox2.Padding = padding;
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox1;
		size = new System.Drawing.Size(684, 389);
		groupBox3.Size = size;
		this.GroupBox1.TabIndex = 18;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Список файлов (можно перетаскивать файлы или папки прямо в список)";
		this.ListView1.AllowDrop = true;
		this.ListView1.ContextMenuStrip = this.csmp2;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		ZTool.ListViewVR listView = this.ListView1;
		location = new System.Drawing.Point(12, 22);
		listView.Location = location;
		this.ListView1.Name = "ListView1";
		ZTool.ListViewVR listView2 = this.ListView1;
		size = new System.Drawing.Size(660, 355);
		listView2.Size = size;
		this.ListView1.TabIndex = 0;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.VirtualMode = true;
		this.AllowDrop = true;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(684, 451);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.ToolStrip1);
		this.Controls.Add(this.StatusStrip1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		size = new System.Drawing.Size(700, 490);
		this.MinimumSize = size;
		this.Name = "Frmmerge_split_pdf";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Tag = "Объединение и разделение PDF";
		this.Text = "Объединение и разделение PDF";
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.csmp2.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public Frmmerge_split_pdf()
	{
		base.FormClosed += FrmSyncDrwName_FormClosed;
		base.Load += FrmSyncDrwName_Load;
		__ENCAddToList(this);
		Abort = true;
		dpixRatio = 1.0;
		InitializeComponent();
		if (!code.HasShell("笨小孩。。。"))
		{
			Environment.Exit(0);
		}
		checked
		{
			try
			{
				using (Graphics graphics = Graphics.FromHwnd(Handle))
				{
					dpixRatio = graphics.DpiX / 96f;
				}
				ToolStripStatusLabel1.Width = (int)Math.Round((double)ToolStripStatusLabel1.Width * dpixRatio);
				int num = addfiles.DropDownItems.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						if (addfiles.DropDownItems[num2] is ToolStripMenuItem)
						{
							addfiles.DropDownItems[num2].AutoSize = false;
							addfiles.DropDownItems[num2].Height = (int)Math.Round(22.0 * dpixRatio);
							ToolStripItem toolStripItem = addfiles.DropDownItems[num2];
							Padding padding = new Padding((int)Math.Round(10.0 * dpixRatio), 0, 0, 0);
							toolStripItem.Padding = padding;
						}
						num2++;
						continue;
					}
					break;
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

	private void FrmSyncDrwName_FormClosed(object sender, FormClosedEventArgs e)
	{
		Abort = true;
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void FrmSyncDrwName_Load(object sender, EventArgs e)
	{
		try
		{
			SR sR = new SR();
			if (!sR.Isme("冰雨。。。"))
			{
				Environment.Exit(0);
			}
			MyProject.Forms.Frmmain.g_monitor();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
		try
		{
			MyProject.Forms.Frmmain.sendhwndtosw();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
		Icon = Resources.mergepdf_64;
		ListView1.View = View.Details;
		ListView1.AllowDrop = true;
		ListView1.GridLines = true;
		ListView1.MultiSelect = true;
		ListView1.Clear();
		ListView1.Items.Clear();
		checked
		{
			int num = (int)Math.Round(50.0 * dpixRatio);
			int num2 = (int)Math.Round(250.0 * dpixRatio);
			int num3 = (int)Math.Round(200.0 * dpixRatio);
			int num4 = (int)Math.Round(200.0 * dpixRatio);
			ListView1.Columns.Add("Номер", num, HorizontalAlignment.Left);
			ListView1.Columns.Add("文件名", num2, HorizontalAlignment.Left);
			ListView1.Columns.Add("Путь", num3, HorizontalAlignment.Left);
			ListView1.Columns.Add("状态", num4, HorizontalAlignment.Left);
			ToolStripProgressBar1.Visible = false;
		}
	}

	private void addfiles_MouseMove(object sender, MouseEventArgs e)
	{
		addfiles.ShowDropDown();
	}

	private void OK_Button_MouseMove(object sender, MouseEventArgs e)
	{
		OK_Button.ShowDropDown();
	}

	public void loadview(List<string> f)
	{
		int num = 0;
		ListViewVR listView = ListView1;
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
				f.Add(listView.Items[num3].SubItems[2].Text);
				num3++;
			}
			listView = null;
			HashSet<string> hashSet = new HashSet<string>(f);
			if (hashSet.Count == 0)
			{
				return;
			}
			List<ListViewItem> list = new List<ListViewItem>();
			int num6 = hashSet.Count - 1;
			int num7 = 0;
			while (true)
			{
				int num8 = num7;
				int num5 = num6;
				if (num8 > num5)
				{
					break;
				}
				num++;
				if ((code.TMode && num > 10) ? true : false)
				{
					MessageBox.Show(this, "Пробная версия поддерживает не более 10 файлов", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.SubItems[0].Text = Conversions.ToString(num7 + 1);
				listViewItem.SubItems.Add(code.SplitStr(hashSet.ElementAtOrDefault(num7), 4));
				listViewItem.SubItems.Add(hashSet.ElementAtOrDefault(num7));
				listViewItem.SubItems.Add("");
				list.Add(listViewItem);
				num7++;
			}
			ListView1.AddData(list);
			if (ListView1.Items.Count > 0)
			{
				ToolStripStatusLabel1.Text = "共" + Conversions.ToString(ListView1.Items.Count) + "файлов";
			}
			else
			{
				ToolStripStatusLabel1.Text = "";
			}
		}
	}

	private void addfiles_Click(object sender, EventArgs e)
	{
		addfiles.HideDropDown();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "PDF文件(*.pdf)|*.pdf";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		object fileNames = openFileDialog.FileNames;
		List<string> list = new List<string>();
		int num = Information.LBound((Array)fileNames);
		int num2 = Information.UBound((Array)fileNames);
		int num3 = num;
		while (true)
		{
			int num4 = num3;
			int num5 = num2;
			if (num4 > num5)
			{
				break;
			}
			list.Add(Conversions.ToString(NewLateBinding.LateIndexGet(fileNames, new object[1] { num3 }, null)));
			num3 = checked(num3 + 1);
		}
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			loadview(list);
		}
	}

	private void addfilesformfolder_Click(object sender, EventArgs e)
	{
		string text = "";
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			text = fileBorser.DirectoryPath;
		}
		if (Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			string pattern = "*.pdf";
			List<string> list = new List<string>();
			if (Operators.ConditionalCompareObjectEqual(((ToolStripMenuItem)sender).Tag, "true", TextCompare: false))
			{
				code.SearchFiles(list, text, pattern);
			}
			else
			{
				code.SearchFiles(list, text, pattern, @bool: false);
			}
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
			}
		}
	}

	private void ListView1_DragDrop(object sender, DragEventArgs e)
	{
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
				if (array[num2].EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
				{
					list.Add(array[num2]);
				}
				else if (Directory.Exists(array[num2]))
				{
					string pattern = "*.pdf";
					code.SearchFiles(list, array[num2], pattern);
				}
				num2++;
			}
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
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

	private void clearall_Click(object sender, EventArgs e)
	{
		if (ListView1.Items.Count != 0 && Interaction.MsgBox("Точно очистить список?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question, "Вопрос") == MsgBoxResult.Ok)
		{
			ListView1.DelAllItems();
			ToolStripStatusLabel1.Text = "";
		}
	}

	private void clearsel_Click(object sender, EventArgs e)
	{
		ListView1.DelSelectItems();
		int num = 0;
		checked
		{
			int num2 = ListView1.Items.Count - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (ListView1.Items[num3].Checked)
				{
					num++;
				}
				num3++;
			}
			if (ListView1.Items.Count > 0)
			{
				ToolStripStatusLabel1.Text = "共" + Conversions.ToString(ListView1.Items.Count) + "个文件，勾选了" + Conversions.ToString(num) + "поз.";
			}
			else
			{
				ToolStripStatusLabel1.Text = "";
			}
		}
	}

	private void ToolStrip1_Paint(object sender, PaintEventArgs e)
	{
		if (ToolStrip1.RenderMode == ToolStripRenderMode.System)
		{
			Rectangle clip = checked(new Rectangle(0, 0, ToolStrip1.Width - 8, ToolStrip1.Height - 8));
			e.Graphics.SetClip(clip);
		}
	}

	private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		try
		{
			selrow = ListView1.SelectedIndices[0];
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
			string text = ListView1.Items[selrow].SubItems[2].Text;
			if (File.Exists(text))
			{
				Process.Start(text);
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
			string text = ListView1.Items[selrow].SubItems[2].Text;
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

	private void merge_pdf_Click(object sender, EventArgs e)
	{
		OK_Button.HideDropDown();
		List<string> list = new List<string>();
		ListViewVR listView = ListView1;
		if (listView.Items.Count <= 0)
		{
			return;
		}
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
				list.Add(listView.Items[num2].SubItems[2].Text);
				num2++;
			}
			listView = null;
			MyiTextSharp myiTextSharp = new MyiTextSharp();
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".pdf";
			saveFileDialog.Title = "Сохранить объединённый PDF-файл";
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.Filter = "pdf文件（*.pdf）|*.pdf";
			saveFileDialog.FileName = "合并PDF-" + DateTime.Now.ToString("yyyymmddhhmmss");
			if (saveFileDialog.ShowDialog(this) != DialogResult.Cancel)
			{
				string fileName = saveFileDialog.FileName;
				if (MyiTextSharp.CombinePDF(list.ToArray(), fileName, ListView1))
				{
					ToolStripStatusLabel1.Text = "Объединение завершено";
					Process.Start(fileName);
				}
			}
		}
	}

	private void split_pdf_Click(object sender, EventArgs e)
	{
		OK_Button.HideDropDown();
		ListViewVR listView = ListView1;
		if (listView.Items.Count <= 0)
		{
			return;
		}
		string text = "";
		FileBorser fileBorser = new FileBorser();
		fileBorser.Title = "Сохранить результат разделения в папку";
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			text = fileBorser.DirectoryPath;
		}
		if (!Directory.Exists(text))
		{
			return;
		}
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
				listView.Items[num2].SubItems[3].Text = "";
				num2++;
			}
			int num5 = listView.Items.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				string inputPath = listView.Items[num6].SubItems[2].Text;
				int num8 = MyiTextSharp.SplitAndSave(inputPath, text);
				if (num8 > 0)
				{
					listView.Items[num6].SubItems[3].Text = "拆分 " + Conversions.ToString(num8) + " стр.";
					listView.Items[num6].SubItems[3].ForeColor = Color.Blue;
				}
				num6++;
			}
			ToolStripStatusLabel1.Text = "Разделение завершено";
			listView = null;
		}
	}

	private void ToolStripButton1_Click(object sender, EventArgs e)
	{
		ListView1.ItemsMoveUp();
	}

	private void ToolStripButton2_Click(object sender, EventArgs e)
	{
		ListView1.ItemsMoveDown();
	}
}
