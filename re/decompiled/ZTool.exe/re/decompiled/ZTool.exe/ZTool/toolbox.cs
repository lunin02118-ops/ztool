using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class toolbox : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__2
	{
		public string _0024VB_0024Local_p;

		[DebuggerNonUserCode]
		public _Closure_0024__2(_Closure_0024__2 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_p = other._0024VB_0024Local_p;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__2()
		{
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__3
	{
		public string _0024VB_0024Local_p;

		[DebuggerNonUserCode]
		public _Closure_0024__3(_Closure_0024__3 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_p = other._0024VB_0024Local_p;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__3()
		{
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__6
	{
		public string _0024VB_0024Local_p;

		[DebuggerNonUserCode]
		public _Closure_0024__6(_Closure_0024__6 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_p = other._0024VB_0024Local_p;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__6()
		{
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("ToolStripStatusLabel1")]
	private ToolStripStatusLabel _ToolStripStatusLabel1;

	[AccessedThroughProperty("csmp2")]
	private ContextMenuStrip _csmp2;

	[AccessedThroughProperty("openinsw")]
	private ToolStripMenuItem _openinsw;

	[AccessedThroughProperty("openinfolder")]
	private ToolStripMenuItem _openinfolder;

	[AccessedThroughProperty("ImageList1")]
	private ImageList _ImageList1;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("csmp1")]
	private ContextMenuStrip _csmp1;

	[AccessedThroughProperty("ToolStripMenuItem9")]
	private ToolStripMenuItem _ToolStripMenuItem9;

	[AccessedThroughProperty("ToolStripMenuItem10")]
	private ToolStripMenuItem _ToolStripMenuItem10;

	[AccessedThroughProperty("ToolStripMenuItem11")]
	private ToolStripMenuItem _ToolStripMenuItem11;

	[AccessedThroughProperty("ToolStripMenuItem12")]
	private ToolStripMenuItem _ToolStripMenuItem12;

	[AccessedThroughProperty("ToolStripMenuItem13")]
	private ToolStripMenuItem _ToolStripMenuItem13;

	[AccessedThroughProperty("ToolStripMenuItem14")]
	private ToolStripMenuItem _ToolStripMenuItem14;

	[AccessedThroughProperty("ToolStripDropDownButton3")]
	private ToolStripDropDownButton _ToolStripDropDownButton3;

	[AccessedThroughProperty("addfiles")]
	private ToolStripButton _addfiles;

	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator _ToolStripSeparator2;

	[AccessedThroughProperty("clearsel")]
	private ToolStripButton _clearsel;

	[AccessedThroughProperty("ToolStripSeparator1")]
	private ToolStripSeparator _ToolStripSeparator1;

	[AccessedThroughProperty("ToolStripDropDownButton1")]
	private ToolStripDropDownButton _ToolStripDropDownButton1;

	[AccessedThroughProperty("平铺ToolStripMenuItem")]
	private ToolStripMenuItem _平铺ToolStripMenuItem;

	[AccessedThroughProperty("小图标ToolStripMenuItem")]
	private ToolStripMenuItem _小图标ToolStripMenuItem;

	[AccessedThroughProperty("列表ToolStripMenuItem")]
	private ToolStripMenuItem _列表ToolStripMenuItem;

	[AccessedThroughProperty("列表ToolStripMenuItem1")]
	private ToolStripMenuItem _列表ToolStripMenuItem1;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("LV1")]
	private ListViewVR _LV1;

	[AccessedThroughProperty("clearall")]
	private ToolStripButton _clearall;

	[AccessedThroughProperty("ToolStripMenuItem15")]
	private ToolStripMenuItem _ToolStripMenuItem15;

	[AccessedThroughProperty("ToolStripMenuItem16")]
	private ToolStripMenuItem _ToolStripMenuItem16;

	[AccessedThroughProperty("ToolStripMenuItem17")]
	private ToolStripMenuItem _ToolStripMenuItem17;

	[AccessedThroughProperty("ToolStripMenuItem18")]
	private ToolStripMenuItem _ToolStripMenuItem18;

	[AccessedThroughProperty("ToolStripMenuItem19")]
	private ToolStripMenuItem _ToolStripMenuItem19;

	[AccessedThroughProperty("ToolStripSeparator3")]
	private ToolStripSeparator _ToolStripSeparator3;

	private double dpixRatio;

	private List<box> itemlist;

	private int currow;

	private box curbox;

	private int filterindex;

	private int viewtype;

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
			_openinfolder = value;
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

	internal virtual ContextMenuStrip csmp1
	{
		[DebuggerNonUserCode]
		get
		{
			return _csmp1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = csmp1_ItemClicked;
			if (_csmp1 != null)
			{
				_csmp1.ItemClicked -= value2;
			}
			_csmp1 = value;
			if (_csmp1 != null)
			{
				_csmp1.ItemClicked += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem9
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem9 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem10
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem10 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem11
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem11 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem12
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem12 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem13
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem13 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem14
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem14 = value;
		}
	}

	internal virtual ToolStripDropDownButton ToolStripDropDownButton3
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripDropDownButton3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = ToolStripDropDownButton3_MouseMove;
			if (_ToolStripDropDownButton3 != null)
			{
				_ToolStripDropDownButton3.MouseMove -= value2;
			}
			_ToolStripDropDownButton3 = value;
			if (_ToolStripDropDownButton3 != null)
			{
				_ToolStripDropDownButton3.MouseMove += value2;
			}
		}
	}

	internal virtual ToolStripButton addfiles
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
			if (_addfiles != null)
			{
				_addfiles.Click -= value2;
			}
			_addfiles = value;
			if (_addfiles != null)
			{
				_addfiles.Click += value2;
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

	internal virtual ToolStripDropDownButton ToolStripDropDownButton1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripDropDownButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ToolStripItemClickedEventHandler value2 = ToolStripDropDownButton1_DropDownItemClicked;
			MouseEventHandler value3 = ToolStripDropDownButton3_MouseMove;
			if (_ToolStripDropDownButton1 != null)
			{
				_ToolStripDropDownButton1.DropDownItemClicked -= value2;
				_ToolStripDropDownButton1.MouseMove -= value3;
			}
			_ToolStripDropDownButton1 = value;
			if (_ToolStripDropDownButton1 != null)
			{
				_ToolStripDropDownButton1.DropDownItemClicked += value2;
				_ToolStripDropDownButton1.MouseMove += value3;
			}
		}
	}

	internal virtual ToolStripMenuItem 平铺ToolStripMenuItem
	{
		[DebuggerNonUserCode]
		get
		{
			return _平铺ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_平铺ToolStripMenuItem = value;
		}
	}

	internal virtual ToolStripMenuItem 小图标ToolStripMenuItem
	{
		[DebuggerNonUserCode]
		get
		{
			return _小图标ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_小图标ToolStripMenuItem = value;
		}
	}

	internal virtual ToolStripMenuItem 列表ToolStripMenuItem
	{
		[DebuggerNonUserCode]
		get
		{
			return _列表ToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_列表ToolStripMenuItem = value;
		}
	}

	internal virtual ToolStripMenuItem 列表ToolStripMenuItem1
	{
		[DebuggerNonUserCode]
		get
		{
			return _列表ToolStripMenuItem1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_列表ToolStripMenuItem1 = value;
		}
	}

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

	internal virtual ListViewVR LV1
	{
		[DebuggerNonUserCode]
		get
		{
			return _LV1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = LV1_MouseDoubleClick;
			ItemDragEventHandler value3 = LV1_ItemDrag;
			DragEventHandler value4 = LV1_DragEnter;
			ListViewItemSelectionChangedEventHandler value5 = ListView1_ItemSelectionChanged;
			DragEventHandler value6 = LV1_DragDrop;
			if (_LV1 != null)
			{
				_LV1.MouseDoubleClick -= value2;
				_LV1.ItemDrag -= value3;
				_LV1.DragEnter -= value4;
				_LV1.ItemSelectionChanged -= value5;
				_LV1.DragDrop -= value6;
			}
			_LV1 = value;
			if (_LV1 != null)
			{
				_LV1.MouseDoubleClick += value2;
				_LV1.ItemDrag += value3;
				_LV1.DragEnter += value4;
				_LV1.ItemSelectionChanged += value5;
				_LV1.DragDrop += value6;
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

	internal virtual ToolStripMenuItem ToolStripMenuItem15
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem15 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem16
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem16 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem17
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem17 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem18
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem18 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem19
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripMenuItem19 = value;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.toolbox));
		this.csmp1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.csmp2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.openinsw = new System.Windows.Forms.ToolStripMenuItem();
		this.openinfolder = new System.Windows.Forms.ToolStripMenuItem();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.Panel1 = new System.Windows.Forms.Panel();
		this.addfiles = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.clearsel = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
		this.平铺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.小图标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.列表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.clearall = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.LV1 = new ZTool.ListViewVR();
		this.csmp1.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.csmp2.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.ToolStrip1.SuspendLayout();
		this.SuspendLayout();
		this.csmp1.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
		{
			this.ToolStripMenuItem9, this.ToolStripMenuItem10, this.ToolStripMenuItem13, this.ToolStripMenuItem14, this.ToolStripMenuItem11, this.ToolStripMenuItem12, this.ToolStripMenuItem15, this.ToolStripMenuItem16, this.ToolStripMenuItem17, this.ToolStripMenuItem18,
			this.ToolStripMenuItem19
		});
		this.csmp1.Name = "csmp1";
		this.csmp1.OwnerItem = this.ToolStripDropDownButton3;
		this.csmp1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.csmp1;
		System.Drawing.Size size = new System.Drawing.Size(125, 246);
		contextMenuStrip.Size = size;
		this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.ToolStripMenuItem9;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem.Size = size;
		this.ToolStripMenuItem9.Text = "Все";
		this.ToolStripMenuItem10.Name = "ToolStripMenuItem10";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.ToolStripMenuItem10;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem2.Size = size;
		this.ToolStripMenuItem10.Text = "Недавние";
		this.ToolStripMenuItem13.Name = "ToolStripMenuItem13";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.ToolStripMenuItem13;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem3.Size = size;
		this.ToolStripMenuItem13.Text = "Файл";
		this.ToolStripMenuItem14.Name = "ToolStripMenuItem14";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4 = this.ToolStripMenuItem14;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem4.Size = size;
		this.ToolStripMenuItem14.Text = "Папка";
		this.ToolStripMenuItem11.Name = "ToolStripMenuItem11";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5 = this.ToolStripMenuItem11;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem5.Size = size;
		this.ToolStripMenuItem11.Text = "Макрос";
		this.ToolStripMenuItem12.Name = "ToolStripMenuItem12";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6 = this.ToolStripMenuItem12;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem6.Size = size;
		this.ToolStripMenuItem12.Text = "Приложение";
		this.ToolStripMenuItem15.Name = "ToolStripMenuItem15";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7 = this.ToolStripMenuItem15;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem7.Size = size;
		this.ToolStripMenuItem15.Text = "Изображение";
		this.ToolStripMenuItem16.Name = "ToolStripMenuItem16";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8 = this.ToolStripMenuItem16;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem8.Size = size;
		this.ToolStripMenuItem16.Text = "PDF";
		this.ToolStripMenuItem17.Name = "ToolStripMenuItem17";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9 = this.ToolStripMenuItem17;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem9.Size = size;
		this.ToolStripMenuItem17.Text = "Деталь";
		this.ToolStripMenuItem18.Name = "ToolStripMenuItem18";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10 = this.ToolStripMenuItem18;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem10.Size = size;
		this.ToolStripMenuItem18.Text = "Сборка";
		this.ToolStripMenuItem19.Name = "ToolStripMenuItem19";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11 = this.ToolStripMenuItem19;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem11.Size = size;
		this.ToolStripMenuItem19.Text = "dwg";
		this.ToolStripDropDownButton3.BackColor = System.Drawing.SystemColors.Control;
		this.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.ToolStripDropDownButton3.DropDown = this.csmp1;
		this.ToolStripDropDownButton3.ForeColor = System.Drawing.Color.ForestGreen;
		this.ToolStripDropDownButton3.Image = (System.Drawing.Image)resources.GetObject("ToolStripDropDownButton3.Image");
		this.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton = this.ToolStripDropDownButton3;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(6, 1, 6, 2);
		toolStripDropDownButton.Margin = margin;
		this.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3";
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2 = this.ToolStripDropDownButton3;
		size = new System.Drawing.Size(45, 21);
		toolStripDropDownButton2.Size = size;
		this.ToolStripDropDownButton3.Text = "Категория";
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.ToolStripStatusLabel1 });
		System.Windows.Forms.StatusStrip statusStrip = this.StatusStrip1;
		System.Drawing.Point location = new System.Drawing.Point(0, 259);
		statusStrip.Location = location;
		this.StatusStrip1.Name = "StatusStrip1";
		System.Windows.Forms.StatusStrip statusStrip2 = this.StatusStrip1;
		size = new System.Drawing.Size(584, 22);
		statusStrip2.Size = size;
		this.StatusStrip1.TabIndex = 14;
		this.StatusStrip1.Text = "StatusStrip1";
		this.ToolStripStatusLabel1.AutoSize = false;
		this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
		System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel = this.ToolStripStatusLabel1;
		size = new System.Drawing.Size(134, 17);
		toolStripStatusLabel.Size = size;
		this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.csmp2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.openinsw, this.openinfolder });
		this.csmp2.Name = "csmp1";
		System.Windows.Forms.ContextMenuStrip contextMenuStrip2 = this.csmp2;
		size = new System.Drawing.Size(161, 48);
		contextMenuStrip2.Size = size;
		this.openinsw.Image = ZTool.My.Resources.Resources.SW_32px;
		this.openinsw.Name = "openinsw";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12 = this.openinsw;
		size = new System.Drawing.Size(160, 22);
		toolStripMenuItem12.Size = size;
		this.openinsw.Text = "Изменить";
		this.openinfolder.Image = ZTool.My.Resources.Resources.folder_vertical_24px;
		this.openinfolder.Name = "openinfolder";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13 = this.openinfolder;
		size = new System.Drawing.Size(160, 22);
		toolStripMenuItem13.Size = size;
		this.openinfolder.Text = "Открыть в папке";
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "工具箱.png");
		this.Panel1.Controls.Add(this.LV1);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.Panel panel = this.Panel1;
		location = new System.Drawing.Point(0, 31);
		panel.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel2 = this.Panel1;
		margin = new System.Windows.Forms.Padding(3);
		panel2.Padding = margin;
		System.Windows.Forms.Panel panel3 = this.Panel1;
		size = new System.Drawing.Size(584, 228);
		panel3.Size = size;
		this.Panel1.TabIndex = 15;
		this.addfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton = this.addfiles;
		margin = new System.Windows.Forms.Padding(10, 1, 2, 2);
		toolStripButton.Margin = margin;
		this.addfiles.Name = "addfiles";
		System.Windows.Forms.ToolStripButton toolStripButton2 = this.addfiles;
		size = new System.Drawing.Size(48, 21);
		toolStripButton2.Size = size;
		this.addfiles.Text = "Добавить элемент";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator = this.ToolStripSeparator2;
		margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
		toolStripSeparator.Margin = margin;
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator2 = this.ToolStripSeparator2;
		size = new System.Drawing.Size(6, 24);
		toolStripSeparator2.Size = size;
		this.clearsel.Image = ZTool.My.Resources.Resources.delsel;
		this.clearsel.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton toolStripButton3 = this.clearsel;
		margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
		toolStripButton3.Margin = margin;
		this.clearsel.Name = "clearsel";
		System.Windows.Forms.ToolStripButton toolStripButton4 = this.clearsel;
		size = new System.Drawing.Size(76, 21);
		toolStripButton4.Size = size;
		this.clearsel.Text = "Удалить выбранное";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator3 = this.ToolStripSeparator1;
		size = new System.Drawing.Size(6, 24);
		toolStripSeparator3.Size = size;
		this.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.ToolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.平铺ToolStripMenuItem, this.小图标ToolStripMenuItem, this.列表ToolStripMenuItem, this.列表ToolStripMenuItem1 });
		this.ToolStripDropDownButton1.ForeColor = System.Drawing.Color.Blue;
		this.ToolStripDropDownButton1.Image = (System.Drawing.Image)resources.GetObject("ToolStripDropDownButton1.Image");
		this.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3 = this.ToolStripDropDownButton1;
		margin = new System.Windows.Forms.Padding(6, 1, 6, 2);
		toolStripDropDownButton3.Margin = margin;
		this.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1";
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4 = this.ToolStripDropDownButton1;
		size = new System.Drawing.Size(45, 21);
		toolStripDropDownButton4.Size = size;
		this.ToolStripDropDownButton1.Text = "Вид";
		this.平铺ToolStripMenuItem.Name = "平铺ToolStripMenuItem";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14 = this.平铺ToolStripMenuItem;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem14.Size = size;
		this.平铺ToolStripMenuItem.Tag = "0";
		this.平铺ToolStripMenuItem.Text = "Крупные значки";
		this.小图标ToolStripMenuItem.Name = "小图标ToolStripMenuItem";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15 = this.小图标ToolStripMenuItem;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem15.Size = size;
		this.小图标ToolStripMenuItem.Tag = "2";
		this.小图标ToolStripMenuItem.Text = "Мелкие значки";
		this.列表ToolStripMenuItem.Name = "列表ToolStripMenuItem";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem16 = this.列表ToolStripMenuItem;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem16.Size = size;
		this.列表ToolStripMenuItem.Tag = "1";
		this.列表ToolStripMenuItem.Text = "Таблица";
		this.列表ToolStripMenuItem1.Name = "列表ToolStripMenuItem1";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem17 = this.列表ToolStripMenuItem1;
		size = new System.Drawing.Size(124, 22);
		toolStripMenuItem17.Size = size;
		this.列表ToolStripMenuItem1.Tag = "3";
		this.列表ToolStripMenuItem1.Text = "Список";
		this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
		this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.addfiles, this.ToolStripSeparator2, this.clearsel, this.clearall, this.ToolStripSeparator1, this.ToolStripDropDownButton1, this.ToolStripSeparator3, this.ToolStripDropDownButton3 });
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		location = new System.Drawing.Point(0, 0);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		margin = new System.Windows.Forms.Padding(2, 2, 2, 5);
		toolStrip2.Padding = margin;
		this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		System.Windows.Forms.ToolStrip toolStrip3 = this.ToolStrip1;
		size = new System.Drawing.Size(584, 31);
		toolStrip3.Size = size;
		this.ToolStrip1.TabIndex = 13;
		this.ToolStrip1.Text = "ToolStrip1";
		this.clearall.Image = ZTool.My.Resources.Resources.del;
		this.clearall.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.clearall.Name = "clearall";
		System.Windows.Forms.ToolStripButton toolStripButton5 = this.clearall;
		size = new System.Drawing.Size(52, 21);
		toolStripButton5.Size = size;
		this.clearall.Text = "Очистить";
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = this.ToolStripSeparator3;
		size = new System.Drawing.Size(6, 24);
		toolStripSeparator4.Size = size;
		this.LV1.AllowDrop = true;
		this.LV1.ContextMenuStrip = this.csmp2;
		this.LV1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.LV1.FullRowSelect = true;
		this.LV1.GridLines = true;
		this.LV1.LargeImageList = this.ImageList1;
		ZTool.ListViewVR lV = this.LV1;
		location = new System.Drawing.Point(3, 3);
		lV.Location = location;
		this.LV1.MultiSelect = false;
		this.LV1.Name = "LV1";
		ZTool.ListViewVR lV2 = this.LV1;
		size = new System.Drawing.Size(578, 222);
		lV2.Size = size;
		this.LV1.SmallImageList = this.ImageList1;
		this.LV1.TabIndex = 0;
		this.LV1.UseCompatibleStateImageBehavior = false;
		this.LV1.View = System.Windows.Forms.View.Details;
		this.LV1.VirtualMode = true;
		this.AllowDrop = true;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(584, 281);
		this.ClientSize = size;
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.ToolStrip1);
		this.Controls.Add(this.StatusStrip1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.Name = "toolbox";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Tag = "";
		this.Text = "Набор инструментов";
		this.csmp1.ResumeLayout(false);
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.csmp2.ResumeLayout(false);
		this.Panel1.ResumeLayout(false);
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public toolbox()
	{
		base.FormClosed += toolbox_FormClosed;
		base.Load += toolbox_Load;
		__ENCAddToList(this);
		dpixRatio = 1.0;
		itemlist = new List<box>();
		curbox = new box();
		InitializeComponent();
		try
		{
			using (Graphics graphics = Graphics.FromHwnd(Handle))
			{
				dpixRatio = graphics.DpiX / 96f;
			}
			ToolStripStatusLabel1.Width = checked((int)Math.Round((double)ToolStripStatusLabel1.Width * dpixRatio));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void toolbox_FormClosed(object sender, FormClosedEventArgs e)
	{
		CConfigMng.Config.itemlist = itemlist;
		CConfigMng.Config.filterindex = filterindex;
		CConfigMng.Config.viewtype = viewtype;
		CConfigMng.SaveConfig();
		Dispose();
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void toolbox_Load(object sender, EventArgs e)
	{
		LV1.VirtualMode = true;
		LV1.MultiSelect = true;
		LV1.ShowItemToolTips = true;
		itemlist = CConfigMng.Config.itemlist;
		filterindex = CConfigMng.Config.filterindex;
		viewtype = CConfigMng.Config.viewtype;
		refreshview();
		refreshitem();
		checked
		{
			int num = (int)Math.Round(300.0 * dpixRatio);
			int num2 = (int)Math.Round(400.0 * dpixRatio);
			int num3 = (int)Math.Round(200.0 * dpixRatio);
			int num4 = (int)Math.Round(200.0 * dpixRatio);
			LV1.Columns.Add("Название", num, HorizontalAlignment.Left);
			LV1.Columns.Add("Путь", num2, HorizontalAlignment.Left);
			LV1.Columns.Add("Сообщение", num3, HorizontalAlignment.Left);
			LV1.Columns.Add("Метка", num4, HorizontalAlignment.Left);
		}
	}

	private void clearall_Click(object sender, EventArgs e)
	{
		if (LV1.Items.Count == 0 || Interaction.MsgBox("Очистить список?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question, "Вопрос") != MsgBoxResult.Ok)
		{
			return;
		}
		checked
		{
			int num = LV1.Items.Count - 1;
			int num2 = 0;
			_Closure_0024__2 closure_0024__ = default(_Closure_0024__2);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				closure_0024__ = new _Closure_0024__2(closure_0024__);
				closure_0024__._0024VB_0024Local_p = LV1.Items[num2].SubItems[1].Text;
				itemlist.RemoveAll(closure_0024__._Lambda_0024__3);
				num2++;
			}
			loadbox(filterindex);
		}
	}

	private void clearsel_Click(object sender, EventArgs e)
	{
		_Closure_0024__3 closure_0024__ = default(_Closure_0024__3);
		foreach (object selectedIndex in LV1.SelectedIndices)
		{
			int index = Conversions.ToInteger(selectedIndex);
			closure_0024__ = new _Closure_0024__3(closure_0024__);
			closure_0024__._0024VB_0024Local_p = LV1.Items[index].SubItems[1].Text;
			itemlist.RemoveAll(closure_0024__._Lambda_0024__4);
		}
		loadbox(filterindex);
	}

	private void ToolStrip1_Paint(object sender, PaintEventArgs e)
	{
		if (ToolStrip1.RenderMode == ToolStripRenderMode.System)
		{
			Rectangle clip = checked(new Rectangle(0, 0, ToolStrip1.Width - 8, ToolStrip1.Height - 8));
			e.Graphics.SetClip(clip);
		}
	}

	private void LV1_DragDrop(object sender, DragEventArgs e)
	{
		ListViewItem listViewItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
		Point p = new Point(e.X, e.Y);
		Point point = LV1.PointToClient(p);
		ListViewItem listViewItem2 = (ListViewItem)LV1.GetItemAt(point.X, point.Y);
		if (!Information.IsNothing(listViewItem) && !Information.IsNothing(listViewItem2) && 0 == 0)
		{
			box item = itemlist.Find([SpecialName] (box s) => s.path.Equals(listViewItem.SubItems[1].Text, StringComparison.OrdinalIgnoreCase));
			itemlist.Remove(item);
			int index = itemlist.FindIndex([SpecialName] (box s) => s.path.Equals(listViewItem2.SubItems[1].Text, StringComparison.OrdinalIgnoreCase));
			itemlist.Insert(index, item);
			loadbox(filterindex);
		}
	}

	private void LV1_DragEnter(object sender, DragEventArgs e)
	{
		e.Effect = DragDropEffects.Move;
	}

	private void LV1_ItemDrag(object sender, ItemDragEventArgs e)
	{
		LV1.DoDragDrop(RuntimeHelpers.GetObjectValue(e.Item), DragDropEffects.Move);
	}

	private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		try
		{
			currow = LV1.SelectedIndices[0];
			string value = LV1.Items[currow].SubItems[1].Text;
			curbox = itemlist.Find([SpecialName] (box s) => s.path.Equals(value, StringComparison.OrdinalIgnoreCase));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void addfiles_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Файлы (*.*)|*.*";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		object fileNames = openFileDialog.FileNames;
		List<box> list = new List<box>();
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
			box box2 = new box();
			box2.path = Conversions.ToString(NewLateBinding.LateIndexGet(fileNames, new object[1] { num3 }, null));
			box2.text = code.SplitStr(Conversions.ToString(NewLateBinding.LateIndexGet(fileNames, new object[1] { num3 }, null)), 1);
			list.Add(box2);
			num3 = checked(num3 + 1);
		}
		if (!Information.IsNothing(list) && list.Count != 0)
		{
			addbox(list);
		}
	}

	private void ToolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		viewtype = Conversions.ToInteger(e.ClickedItem.Tag);
		refreshview();
	}

	private void csmp1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		ContextMenuStrip contextMenuStrip = (ContextMenuStrip)sender;
		filterindex = contextMenuStrip.Items.IndexOf(e.ClickedItem);
		refreshitem();
	}

	private void ToolStripDropDownButton3_MouseMove(object sender, MouseEventArgs e)
	{
		((ToolStripDropDownButton)sender).ShowDropDown();
	}

	private void LV1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		runfrompaths(curbox);
		curbox.useindex = 1;
		checked
		{
			int num = itemlist.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (!itemlist[num2].Equals(curbox))
				{
					int useindex = itemlist[num2].useindex;
					if ((useindex > 0 && useindex < 15) ? true : false)
					{
						itemlist[num2].useindex = useindex + 1;
					}
					else if (useindex >= 15)
					{
						itemlist[num2].useindex = 0;
					}
				}
				num2++;
			}
		}
	}

	public void refreshview()
	{
		foreach (ToolStripMenuItem dropDownItem in ToolStripDropDownButton1.DropDownItems)
		{
			if (Operators.ConditionalCompareObjectEqual(dropDownItem.Tag, viewtype, TextCompare: false))
			{
				dropDownItem.Checked = true;
				ToolStripDropDownButton1.Text = dropDownItem.Text;
				LV1.View = (View)Conversions.ToInteger(dropDownItem.Tag);
			}
			else
			{
				dropDownItem.Checked = false;
			}
		}
	}

	public void refreshitem()
	{
		foreach (ToolStripMenuItem item in csmp1.Items)
		{
			if (csmp1.Items.IndexOf(item) == filterindex)
			{
				item.Checked = true;
				ToolStripDropDownButton3.Text = item.Text;
				loadbox(csmp1.Items.IndexOf(item));
			}
			else
			{
				item.Checked = false;
			}
		}
	}

	public void runfrompaths(box b)
	{
		string path = b.path;
		bool flag = true;
		if (File.Exists(path))
		{
			flag = true;
		}
		else
		{
			if (!Directory.Exists(path))
			{
				MessageBox.Show(path + "не существует!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			flag = false;
		}
		try
		{
			if (flag)
			{
				if (path.EndsWith(".swb", StringComparison.OrdinalIgnoreCase) || (path.EndsWith(".swp", StringComparison.OrdinalIgnoreCase) ? true : false))
				{
					object swApp = code.swApp;
					int num = default(int);
					object[] array = new object[5] { path, "", "main", 0, num };
					bool[] array2 = new bool[5] { true, false, false, false, true };
					NewLateBinding.LateCall(swApp, null, "RunMacro2", array, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						path = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					if (array2[4])
					{
						num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[4]), typeof(int));
					}
				}
				else
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = path;
					processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
					Process process = Process.Start(processStartInfo);
				}
			}
			else if (!code.OpenFolderWithEX(code.SplitStr(path)))
			{
				MessageBox.Show(this, "Папка не существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void addbox(List<box> f)
	{
		checked
		{
			try
			{
				int num = f.Count - 1;
				int num2 = 0;
				_Closure_0024__6 closure_0024__ = default(_Closure_0024__6);
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					closure_0024__ = new _Closure_0024__6(closure_0024__);
					closure_0024__._0024VB_0024Local_p = f[num2].path;
					int num5 = itemlist.FindIndex(closure_0024__._Lambda_0024__8);
					if (num5 < 0)
					{
						itemlist.Add(f[num2]);
					}
					num2++;
				}
				if (itemlist.Count == 0)
				{
					return;
				}
				List<ListViewItem> list = new List<ListViewItem>();
				int num6 = itemlist.Count - 1;
				int num7 = 0;
				while (true)
				{
					int num8 = num7;
					int num4 = num6;
					if (num8 > num4)
					{
						break;
					}
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.ImageIndex = 0;
					try
					{
						itemlist[num7].imagepath = Application.StartupPath + "\\images\\image_" + Conversions.ToString(num7);
						if (!File.Exists(itemlist[num7].imagepath))
						{
							Bitmap bitmapThumbnail = ThumbnailHelper.GetInstance().GetBitmapThumbnail(itemlist[num7].path, 128, 128);
							bitmapThumbnail.Save(itemlist[num7].imagepath);
						}
						ImageList1.Images.Add(itemlist[num7].imagepath, Image.FromFile(itemlist[num7].imagepath));
						listViewItem.ImageKey = itemlist[num7].imagepath;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					listViewItem.Text = itemlist[num7].text;
					listViewItem.SubItems.Add(itemlist[num7].path);
					listViewItem.SubItems.Add(itemlist[num7].tip);
					listViewItem.SubItems.Add(itemlist[num7].mark);
					list.Add(listViewItem);
					num7++;
				}
				LV1.AddData(list);
				if (LV1.Items.Count > 0)
				{
					ToolStripStatusLabel1.Text = "Всего" + Conversions.ToString(LV1.Items.Count) + "поз.";
				}
				else
				{
					ToolStripStatusLabel1.Text = "";
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Interaction.MsgBox(ex4.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void loadbox(int type)
	{
		csmp1.Close();
		LV1.DelAllItems();
		ImageList1.Images.Clear();
		List<ListViewItem> list = new List<ListViewItem>();
		checked
		{
			int num = itemlist.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				string path = itemlist[num2].path;
				int num5 = -1;
				if (File.Exists(path))
				{
					num5 = 0;
				}
				else if (Directory.Exists(path))
				{
					num5 = 1;
				}
				bool flag = false;
				if (type == 0)
				{
					flag = true;
				}
				else if ((type == 1 && itemlist[num2].useindex >= 1 && itemlist[num2].useindex <= 15) ? true : false)
				{
					flag = true;
				}
				else if ((type == 2 && num5 == 0) ? true : false)
				{
					flag = true;
				}
				else if ((type == 3 && num5 == 1) ? true : false)
				{
					flag = true;
				}
				else if ((type == 4 && num5 == 0 && (itemlist[num2].path.EndsWith(".swb", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".swp", StringComparison.OrdinalIgnoreCase))) ? true : false)
				{
					flag = true;
				}
				else if ((type == 5 && num5 == 0 && itemlist[num2].path.EndsWith(".exe", StringComparison.OrdinalIgnoreCase)) ? true : false)
				{
					flag = true;
				}
				else if (type == 6 && num5 == 0 && ((itemlist[num2].path.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".ico", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".jpe", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".jp2", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".j2k", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".jpf", StringComparison.OrdinalIgnoreCase) || itemlist[num2].path.EndsWith(".jpx", StringComparison.OrdinalIgnoreCase)) ? true : false))
				{
					flag = true;
				}
				else if ((type == 7 && num5 == 0 && itemlist[num2].path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)) ? true : false)
				{
					flag = true;
				}
				else if ((type == 8 && num5 == 0 && itemlist[num2].path.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase)) ? true : false)
				{
					flag = true;
				}
				else if ((type == 9 && num5 == 0 && itemlist[num2].path.EndsWith(".sldasm", StringComparison.OrdinalIgnoreCase)) ? true : false)
				{
					flag = true;
				}
				else if ((type == 10 && num5 == 0 && itemlist[num2].path.EndsWith(".dwg", StringComparison.OrdinalIgnoreCase)) ? true : false)
				{
					flag = true;
				}
				if (flag)
				{
					ListViewItem listViewItem = new ListViewItem();
					listViewItem.ImageIndex = 0;
					try
					{
						ImageList1.Images.Add(Image.FromFile(itemlist[num2].imagepath));
						listViewItem.ImageIndex = ImageList1.Images.Count - 1;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					Bitmap bitmap = null;
					try
					{
						if (File.Exists(itemlist[num2].imagepath))
						{
							bitmap = (Bitmap)Image.FromFile(itemlist[num2].imagepath);
						}
						if (Information.IsNothing(bitmap))
						{
							bitmap = ThumbnailHelper.GetInstance().GetBitmapThumbnail(itemlist[num2].path, 64, 64);
						}
						if (!Information.IsNothing(bitmap))
						{
							ImageList1.Images.Add(bitmap);
							listViewItem.ImageIndex = ImageList1.Images.Count - 1;
							itemlist[num2].tip = Conversions.ToString(bitmap.Height);
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						Interaction.MsgBox(ex4.Message);
						ProjectData.ClearProjectError();
					}
					listViewItem.Text = itemlist[num2].text;
					listViewItem.SubItems.Add(itemlist[num2].path);
					listViewItem.SubItems.Add(itemlist[num2].tip);
					listViewItem.SubItems.Add(itemlist[num2].mark);
					listViewItem.useindex = itemlist[num2].useindex;
					list.Add(listViewItem);
				}
				num2++;
			}
			if (type == 1)
			{
				list.Sort(sortRingRecord);
			}
			LV1.AddData(list);
			if (LV1.Items.Count > 0)
			{
				ToolStripStatusLabel1.Text = "Всего" + Conversions.ToString(LV1.Items.Count) + "поз.";
			}
			else
			{
				ToolStripStatusLabel1.Text = "";
			}
		}
	}

	private static int sortRingRecord(ListViewItem xRingRecord, ListViewItem yRingRecord)
	{
		if (xRingRecord.useindex > yRingRecord.useindex)
		{
			return 1;
		}
		if (xRingRecord.useindex == yRingRecord.useindex)
		{
			return 0;
		}
		return -1;
	}

	private void openinsw_Click(object sender, EventArgs e)
	{
		boxset boxset2 = new boxset(curbox);
		boxset2.ShowDialog();
	}
}
