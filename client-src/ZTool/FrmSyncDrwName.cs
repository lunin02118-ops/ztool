using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser1;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmSyncDrwName : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__22
	{
		[CompilerGenerated]
		internal class _Closure_0024__23
		{
			public string _0024VB_0024Local_NewDrwName;

			public _Closure_0024__22 _0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12;

			[DebuggerNonUserCode]
			public _Closure_0024__23(_Closure_0024__23 other)
			{
				if (other != null)
				{
					_0024VB_0024Local_NewDrwName = other._0024VB_0024Local_NewDrwName;
				}
			}

			[DebuggerNonUserCode]
			public _Closure_0024__23()
			{
			}

			[SpecialName]
			[CompilerGenerated]
			public void _Lambda_0024__47()
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ListView1.Items[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Local_i].SubItems[3].Text = "Не соответствует условиям синхронизации";
			}

			[SpecialName]
			[CompilerGenerated]
			public void _Lambda_0024__48()
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ListView1.Items[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Local_i].SubItems[1].Text = code.SplitStr(_0024VB_0024Local_NewDrwName, 1);
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ListView1.Items[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Local_i].SubItems[2].Text = _0024VB_0024Local_NewDrwName;
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ListView1.Items[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Local_i].SubItems[3].Text = "Успешно";
			}

			[SpecialName]
			[CompilerGenerated]
			public void _Lambda_0024__49()
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ListView1.Items[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Local_i].SubItems[3].Text = "Чертёж с таким именем уже существует";
			}

			[SpecialName]
			[CompilerGenerated]
			public void _Lambda_0024__50()
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ListView1.Items[_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Local_i].SubItems[3].Text = "Синхронизация не требуется";
			}

			[SpecialName]
			[CompilerGenerated]
			public void _Lambda_0024__51()
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ToolStripProgressBar1.Value = checked(_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Local_i + 1);
				_0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12._0024VB_0024Me.ListView1.Refreshview();
			}
		}

		public int _0024VB_0024Local_i;

		public FrmSyncDrwName _0024VB_0024Me;

		[DebuggerNonUserCode]
		public _Closure_0024__22()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__22(_Closure_0024__22 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_i = other._0024VB_0024Local_i;
				_0024VB_0024Me = other._0024VB_0024Me;
			}
		}
	}

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

	[AccessedThroughProperty("AddFromMain")]
	private ToolStripMenuItem _AddFromMain;

	[AccessedThroughProperty("adddrawformSW")]
	private ToolStripMenuItem _adddrawformSW;

	[AccessedThroughProperty("adddrawformPrt")]
	private ToolStripMenuItem _adddrawformPrt;

	[AccessedThroughProperty("adddrwformsel")]
	private ToolStripMenuItem _adddrwformsel;

	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator _ToolStripSeparator2;

	[AccessedThroughProperty("clearsel")]
	private ToolStripButton _clearsel;

	[AccessedThroughProperty("clearall")]
	private ToolStripButton _clearall;

	[AccessedThroughProperty("ToolStripSeparator1")]
	private ToolStripSeparator _ToolStripSeparator1;

	[AccessedThroughProperty("OK_Button")]
	private ToolStripButton _OK_Button;

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

	[AccessedThroughProperty("copyitem")]
	private ToolStripButton _copyitem;

	[AccessedThroughProperty("pasteitem")]
	private ToolStripButton _pasteitem;

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
			EventHandler value2 = addfiles_Click;
			MouseEventHandler value3 = addfiles_MouseMove;
			if (_addfiles != null)
			{
				_addfiles.ButtonClick -= value2;
				_addfiles.MouseMove -= value3;
			}
			_addfiles = value;
			if (_addfiles != null)
			{
				_addfiles.ButtonClick += value2;
				_addfiles.MouseMove += value3;
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

	internal virtual ToolStripMenuItem AddFromMain
	{
		[DebuggerNonUserCode]
		get
		{
			return _AddFromMain;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AddFromMain_Click;
			if (_AddFromMain != null)
			{
				_AddFromMain.Click -= value2;
			}
			_AddFromMain = value;
			if (_AddFromMain != null)
			{
				_AddFromMain.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem adddrawformSW
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrawformSW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrawformSW_Click;
			if (_adddrawformSW != null)
			{
				_adddrawformSW.Click -= value2;
			}
			_adddrawformSW = value;
			if (_adddrawformSW != null)
			{
				_adddrawformSW.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem adddrawformPrt
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrawformPrt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrawformPrt_Click;
			if (_adddrawformPrt != null)
			{
				_adddrawformPrt.Click -= value2;
			}
			_adddrawformPrt = value;
			if (_adddrawformPrt != null)
			{
				_adddrawformPrt.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem adddrwformsel
	{
		[DebuggerNonUserCode]
		get
		{
			return _adddrwformsel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = adddrwformsel_Click;
			if (_adddrwformsel != null)
			{
				_adddrwformsel.Click -= value2;
			}
			_adddrwformsel = value;
			if (_adddrwformsel != null)
			{
				_adddrwformsel.Click += value2;
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

	internal virtual ToolStripButton OK_Button
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
			EventHandler value2 = OK_Button_Click;
			if (_OK_Button != null)
			{
				_OK_Button.Click -= value2;
			}
			_OK_Button = value;
			if (_OK_Button != null)
			{
				_OK_Button.Click += value2;
			}
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
			DragEventHandler value3 = ListView1_DragEnter;
			ListViewItemSelectionChangedEventHandler value4 = ListView1_ItemSelectionChanged;
			if (_ListView1 != null)
			{
				_ListView1.DragDrop -= value2;
				_ListView1.DragEnter -= value3;
				_ListView1.ItemSelectionChanged -= value4;
			}
			_ListView1 = value;
			if (_ListView1 != null)
			{
				_ListView1.DragDrop += value2;
				_ListView1.DragEnter += value3;
				_ListView1.ItemSelectionChanged += value4;
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

	internal virtual ToolStripButton copyitem
	{
		[DebuggerNonUserCode]
		get
		{
			return _copyitem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = copyitem_Click;
			if (_copyitem != null)
			{
				_copyitem.Click -= value2;
			}
			_copyitem = value;
			if (_copyitem != null)
			{
				_copyitem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton pasteitem
	{
		[DebuggerNonUserCode]
		get
		{
			return _pasteitem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = pasteitem_Click;
			if (_pasteitem != null)
			{
				_pasteitem.Click -= value2;
			}
			_pasteitem = value;
			if (_pasteitem != null)
			{
				_pasteitem.Click += value2;
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
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.addfiles = new System.Windows.Forms.ToolStripSplitButton();
		this.addfilesformfolder1 = new System.Windows.Forms.ToolStripMenuItem();
		this.addfilesformfolder2 = new System.Windows.Forms.ToolStripMenuItem();
		this.AddFromMain = new System.Windows.Forms.ToolStripMenuItem();
		this.adddrawformSW = new System.Windows.Forms.ToolStripMenuItem();
		this.adddrawformPrt = new System.Windows.Forms.ToolStripMenuItem();
		this.adddrwformsel = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.clearsel = new System.Windows.Forms.ToolStripButton();
		this.clearall = new System.Windows.Forms.ToolStripButton();
		this.copyitem = new System.Windows.Forms.ToolStripButton();
		this.pasteitem = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.OK_Button = new System.Windows.Forms.ToolStripButton();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		this.openinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.csmp2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.openinfolder = new System.Windows.Forms.ToolStripMenuItem();
		this.ListView1 = new ZTool.ListViewVR();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ToolStrip1.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.csmp2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		this.ToolStrip1.AutoSize = false;
		this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
		this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.addfiles, this.ToolStripSeparator2, this.clearsel, this.clearall, this.copyitem, this.pasteitem, this.ToolStripSeparator1, this.OK_Button });
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
		this.addfiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.addfilesformfolder1, this.addfilesformfolder2, this.AddFromMain, this.adddrawformSW, this.adddrawformPrt, this.adddrwformsel });
		this.addfiles.Image = ZTool.My.Resources.Resources.slddialogresu_291;
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
		size = new System.Drawing.Size(283, 22);
		toolStripMenuItem.Size = size;
		this.addfilesformfolder1.Tag = "false";
		this.addfilesformfolder1.Text = "Добавить папку";
		this.addfilesformfolder2.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.addfilesformfolder2.Name = "addfilesformfolder2";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.addfilesformfolder2;
		size = new System.Drawing.Size(283, 22);
		toolStripMenuItem2.Size = size;
		this.addfilesformfolder2.Tag = "true";
		this.addfilesformfolder2.Text = "Добавить папку (включая подпапки)";
		this.AddFromMain.Image = ZTool.My.Resources.Resources.arrow_16px;
		this.AddFromMain.Name = "AddFromMain";
		System.Windows.Forms.ToolStripMenuItem addFromMain = this.AddFromMain;
		size = new System.Drawing.Size(283, 22);
		addFromMain.Size = size;
		this.AddFromMain.Text = "Загрузить данные главного окна";
		this.adddrawformSW.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrawformSW.Name = "adddrawformSW";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.adddrawformSW;
		size = new System.Drawing.Size(283, 22);
		toolStripMenuItem3.Size = size;
		this.adddrawformSW.Text = "Загрузить открытые в SolidWorks чертежи";
		this.adddrawformPrt.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrawformPrt.Name = "adddrawformPrt";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4 = this.adddrawformPrt;
		size = new System.Drawing.Size(283, 22);
		toolStripMenuItem4.Size = size;
		this.adddrawformPrt.Text = "Загрузить чертежи открытых в SolidWorks деталей";
		this.adddrwformsel.Image = ZTool.My.Resources.Resources.slddrw;
		this.adddrwformsel.Name = "adddrwformsel";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5 = this.adddrwformsel;
		size = new System.Drawing.Size(283, 22);
		toolStripMenuItem5.Size = size;
		this.adddrwformsel.Text = "Загрузить чертежи выбранных элементов сборки";
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
		this.copyitem.Image = ZTool.My.Resources.Resources.copy_32;
		this.copyitem.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.copyitem.Name = "copyitem";
		System.Windows.Forms.ToolStripButton toolStripButton4 = this.copyitem;
		size = new System.Drawing.Size(76, 30);
		toolStripButton4.Size = size;
		this.copyitem.Text = "Копировать таблицу";
		this.pasteitem.Image = ZTool.My.Resources.Resources.Paste_32;
		this.pasteitem.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.pasteitem.Name = "pasteitem";
		System.Windows.Forms.ToolStripButton toolStripButton5 = this.pasteitem;
		size = new System.Drawing.Size(52, 30);
		toolStripButton5.Size = size;
		this.pasteitem.Text = "Вставить";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator3 = this.ToolStripSeparator1;
		padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
		toolStripSeparator3.Margin = padding;
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = this.ToolStripSeparator1;
		size = new System.Drawing.Size(6, 33);
		toolStripSeparator4.Size = size;
		this.OK_Button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.OK_Button.Image = ZTool.My.Resources.Resources.Start_24x;
		this.OK_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton oK_Button = this.OK_Button;
		padding = new System.Windows.Forms.Padding(0, 1, 20, 2);
		oK_Button.Margin = padding;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.ToolStripButton oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(52, 30);
		oK_Button2.Size = size;
		this.OK_Button.Text = "开始";
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
		this.openinsw.Image = ZTool.My.Resources.Resources.SW_32px;
		this.openinsw.Name = "openinsw";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6 = this.openinsw;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem6.Size = size;
		this.openinsw.Text = "Открыть в SolidWorks";
		this.csmp2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.openinsw, this.openinfolder });
		this.csmp2.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.csmp2;
		size = new System.Drawing.Size(188, 48);
		contextMenuStrip.Size = size;
		this.openinfolder.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.openinfolder.Name = "openinfolder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7 = this.openinfolder;
		size = new System.Drawing.Size(187, 22);
		toolStripMenuItem7.Size = size;
		this.openinfolder.Text = "Открыть в папке";
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
		this.Name = "FrmSyncDrwName";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Tag = "Синхронизировать имена чертежей";
		this.Text = "Синхронизировать имена чертежей";
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.csmp2.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmSyncDrwName()
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
		Icon = Resources.SyncDrwName32;
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

	public void loadview(List<string> f)
	{
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
				f.Add(listView.Items[num2].SubItems[2].Text);
				num2++;
			}
			listView = null;
			HashSet<string> hashSet = new HashSet<string>(f);
			if (hashSet.Count == 0)
			{
				return;
			}
			List<ListViewItem> list = new List<ListViewItem>();
			int num5 = hashSet.Count - 1;
			int num6 = 0;
			int num8 = default(int);
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				num8++;
				if ((code.TMode && num8 > 10) ? true : false)
				{
					MessageBox.Show(this, "Пробная версия поддерживает не более 10 файлов", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					break;
				}
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.SubItems[0].Text = Conversions.ToString(num6 + 1);
				listViewItem.SubItems.Add(code.SplitStr(hashSet.ElementAtOrDefault(num6), 4));
				listViewItem.SubItems.Add(hashSet.ElementAtOrDefault(num6));
				listViewItem.SubItems.Add("");
				list.Add(listViewItem);
				num6++;
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

	private void copyitem_Click(object sender, EventArgs e)
	{
		List<string> list = new List<string>();
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
				list.Add(listView.Items[num2].SubItems[2].Text + "\n");
				num2++;
			}
			listView = null;
			if (list.Count > 0)
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, list);
				Clipboard.SetData(DataFormats.Serializable, memoryStream);
				Clipboard.SetAudio(memoryStream);
				MessageBox.Show("已成功复制 " + Conversions.ToString(list.Count) + " поз.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	private void pasteitem_Click(object sender, EventArgs e)
	{
		if (!Clipboard.ContainsAudio())
		{
			return;
		}
		MemoryStream serializationStream = Clipboard.GetAudioStream() as MemoryStream;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		List<string> list = binaryFormatter.Deserialize(serializationStream) as List<string>;
		if (list.Count <= 0)
		{
			return;
		}
		List<string> list2 = new List<string>();
		checked
		{
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
				string[] array = list[num2].Split('\n');
				string text = "";
				if (array.Count() == 2)
				{
					text = array[1];
				}
				if ((File.Exists(array[0]) && array[0].EndsWith(".slddrw", StringComparison.OrdinalIgnoreCase)) ? true : false)
				{
					list2.Add(array[0]);
				}
				num2++;
			}
			if (list2.Count > 0)
			{
				loadview(list2);
			}
		}
	}

	private void addfiles_Click(object sender, EventArgs e)
	{
		addfiles.HideDropDown();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "工程图(*.SLDDRW)|*.SLDDRW";
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
			string pattern = "*.SLDDRW";
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

	private void adddrawformSW_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		List<string> list = new List<string>();
		object objectValue;
		for (objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetFirstDocument", new object[0], null, null, null)); objectValue != null; objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetNext", new object[0], null, null, null)))
		{
			string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null));
			if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				list.Add(text);
			}
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (list.Count == 0)
		{
			Interaction.MsgBox("Чертёж не открыт", MsgBoxStyle.Information, "Информация");
			return;
		}
		loadview(list);
		objectValue = null;
	}

	private void adddrawformPrt_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		List<string> list = new List<string>();
		object objectValue;
		for (objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetFirstDocument", new object[0], null, null, null)); objectValue != null; objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetNext", new object[0], null, null, null)))
		{
			string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null));
			string text2 = code.SplitStr(text, 3) + ".SLDDRW";
			if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase) && File.Exists(text2))
			{
				list.Add(text2);
			}
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (list.Count == 0)
		{
			Interaction.MsgBox("Чертёж не найден", MsgBoxStyle.Information, "Информация");
			return;
		}
		loadview(list);
		objectValue = null;
	}

	private void adddrwformsel_Click(object sender, EventArgs e)
	{
		if (!code.RunSW())
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "ActiveDoc", new object[0], null, null, null));
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			return;
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
		List<string> list = new List<string>();
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "SelectionManager", new object[0], null, null, null));
		int num = Conversions.ToInteger(NewLateBinding.LateGet(objectValue2, null, "GetSelectedObjectCount2", new object[1] { -1 }, null, null, null));
		int num2 = num;
		int num3 = 1;
		while (true)
		{
			int num4 = num3;
			int num5 = num2;
			if (num4 > num5)
			{
				break;
			}
			object instance = objectValue2;
			object[] array = new object[2] { num3, -1 };
			object[] arguments = array;
			bool[] array2 = new bool[2] { true, false };
			object obj = NewLateBinding.LateGet(instance, null, "GetSelectedObjectsComponent4", arguments, null, null, array2);
			if (array2[0])
			{
				num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
			}
			object objectValue3 = RuntimeHelpers.GetObjectValue(obj);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
			{
				string str = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "GetPathName", new object[0], null, null, null));
				string text = code.SplitStr(str, 3) + ".SLDDRW";
				if (File.Exists(text))
				{
					list.Add(text);
				}
			}
			num3 = checked(num3 + 1);
		}
		NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			loadview(list);
			objectValue = null;
			objectValue2 = null;
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
				if (array[num2].EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
				{
					list.Add(array[num2]);
				}
				else if (Directory.Exists(array[num2]))
				{
					string pattern = "*.SLDDRW";
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

	private void AddFromMain_Click(object sender, EventArgs e)
	{
		if (MyProject.Forms.Frmmain.DGV1.RowCount > 0)
		{
			addformMainform();
		}
	}

	private void addformMainform()
	{
		List<string> list = new List<string>();
		if (MyProject.Forms.FrmSelType.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		checked
		{
			int num = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				string str = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num2].Value);
				if (MyProject.Forms.Frmmain.DGV1.Rows[num2].Visible && (File.Exists(code.SplitStr(str, 3) + ".SLDDRW") & MyProject.Forms.FrmSelType.TYPE_SLDDRW.Checked))
				{
					list.Add(code.SplitStr(str, 3) + ".SLDDRW");
				}
				num2++;
			}
			if (!Information.IsNothing(list) && list.Count != 0)
			{
				loadview(list);
			}
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
			string text = ListView1.Items[selrow].SubItems[2].Text;
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
			string text = ListView1.Items[selrow].SubItems[2].Text;
			if (File.Exists(text))
			{
				Thread thread = new Thread(_Lambda_0024__45);
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

	private void OK_Button_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(OK_Button.Text, "停止", TextCompare: false) == 0)
		{
			Abort = true;
		}
		else if (Operators.CompareString(OK_Button.Text, "开始", TextCompare: false) == 0)
		{
			if (ListView1.Items.Count < 1)
			{
				Interaction.MsgBox("В списке нет файлов", MsgBoxStyle.Information, "Информация");
			}
			else if (code.RunSW())
			{
				Abort = false;
				code.EnablePreview = false;
				OK_Button.Text = "停止";
				mythread = new Thread(SyncName);
				mythread.Name = "SyncName";
				mythread.Start();
				Thread.Sleep(100);
			}
		}
	}

	public void SyncName()
	{
		_Closure_0024__22 closure_0024__ = new _Closure_0024__22();
		closure_0024__._0024VB_0024Me = this;
		checked
		{
			try
			{
				if (!code.RunSW())
				{
					return;
				}
				ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__46);
				int num = ListView1.Items.Count - 1;
				closure_0024__._0024VB_0024Local_i = 0;
				_Closure_0024__22._Closure_0024__23 closure_0024__2 = default(_Closure_0024__22._Closure_0024__23);
				while (true)
				{
					int num2 = closure_0024__._0024VB_0024Local_i;
					int num3 = num;
					if (num2 > num3)
					{
						break;
					}
					closure_0024__2 = new _Closure_0024__22._Closure_0024__23(closure_0024__2);
					closure_0024__2._0024VB_0024NonLocal__0024VB_0024Closure_ClosureVariable_1A9_12 = closure_0024__;
					if (Abort)
					{
						break;
					}
					string text = ListView1.Items[closure_0024__._0024VB_0024Local_i].SubItems[2].Text;
					closure_0024__2._0024VB_0024Local_NewDrwName = "";
					int num4 = 0;
					object swApp = code.swApp;
					object[] array = new object[4] { text, false, true, false };
					object[] arguments = array;
					bool[] array2 = new bool[4] { true, false, false, false };
					object obj = NewLateBinding.LateGet(swApp, null, "GetDocumentDependencies2", arguments, null, null, array2);
					if (array2[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					object objectValue = RuntimeHelpers.GetObjectValue(obj);
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && Information.UBound((Array)objectValue) == 1 && File.Exists(Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { 1 }, null))))
					{
						closure_0024__2._0024VB_0024Local_NewDrwName = code.SplitStr(NewLateBinding.LateIndexGet(objectValue, new object[1] { 1 }, null).ToString(), 3) + ".SLDDRW";
						if (string.Compare(closure_0024__2._0024VB_0024Local_NewDrwName, text) != 0)
						{
							if (!File.Exists(closure_0024__2._0024VB_0024Local_NewDrwName))
							{
								File.Copy(text, closure_0024__2._0024VB_0024Local_NewDrwName);
								if (File.Exists(closure_0024__2._0024VB_0024Local_NewDrwName))
								{
									File.Delete(text);
									num4 = 1;
								}
							}
							else
							{
								num4 = 2;
							}
						}
						else
						{
							num4 = 3;
						}
					}
					switch (num4)
					{
					case 0:
						ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__2._Lambda_0024__47);
						break;
					case 1:
						ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__2._Lambda_0024__48);
						break;
					case 2:
						ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__2._Lambda_0024__49);
						break;
					case 3:
						ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__2._Lambda_0024__50);
						break;
					}
					ControlExtensions.InvokeOnUiThreadIfRequired(this, closure_0024__2._Lambda_0024__51);
					closure_0024__._0024VB_0024Local_i++;
				}
				ControlExtensions.InvokeOnUiThreadIfRequired(this, _Lambda_0024__52);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private static void _Lambda_0024__45(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__46()
	{
		ToolStripStatusLabel1.Text = "Синхронизация имён чертежей...";
		ToolStripProgressBar1.Value = 0;
		ToolStripProgressBar1.Maximum = ListView1.Items.Count;
		ToolStripProgressBar1.Visible = true;
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__52()
	{
		if (Abort)
		{
			ToolStripStatusLabel1.Text = "Задача отменена";
		}
		else
		{
			ToolStripStatusLabel1.Text = "Синхронизация завершена";
		}
		OK_Button.Text = "开始";
		ToolStripProgressBar1.Value = 0;
		ToolStripProgressBar1.Visible = false;
		Abort = true;
		code.EnablePreview = true;
		code.RunSW(HideWindow: false, startnew: false);
	}
}
