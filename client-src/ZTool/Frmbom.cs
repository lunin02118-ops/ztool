using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using AdvancedDataGridView;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class Frmbom : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__26
	{
		public ToolStripItemClickedEventArgs _0024VB_0024Local_e;

		[DebuggerNonUserCode]
		public _Closure_0024__26()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__26(_Closure_0024__26 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_e = other._0024VB_0024Local_e;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__60(bomsetting s)
		{
			return s.name.Equals(_0024VB_0024Local_e.ClickedItem.Text, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__27
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__27()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__27(_Closure_0024__27 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__61(Treenode s)
		{
			return _0024VB_0024Local_str.Equals(s.PathName, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__62(Treenode s)
		{
			return _0024VB_0024Local_str.Equals(s.PathName + "\n" + s.ConfigureName, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TGV1")]
	private TreeGridView _TGV1;

	[AccessedThroughProperty("ImageList1")]
	private ImageList _ImageList1;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton _ToolStripButton1;

	[AccessedThroughProperty("ToolStripTextBox1")]
	private ToolStripTextBox _ToolStripTextBox1;

	[AccessedThroughProperty("ToolStripButton3")]
	private ToolStripButton _ToolStripButton3;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("ToolStripDropDownButton3")]
	private ToolStripDropDownButton _ToolStripDropDownButton3;

	[AccessedThroughProperty("ToolStripMenuItem_toxls")]
	private ToolStripMenuItem _ToolStripMenuItem_toxls;

	[AccessedThroughProperty("ToolStripMenuItem_totxt")]
	private ToolStripMenuItem _ToolStripMenuItem_totxt;

	[AccessedThroughProperty("ToolStripSeparator1")]
	private ToolStripSeparator _ToolStripSeparator1;

	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator _ToolStripSeparator2;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("StatusLabel1")]
	private ToolStripStatusLabel _StatusLabel1;

	[AccessedThroughProperty("ToolStripSeparator4")]
	private ToolStripSeparator _ToolStripSeparator4;

	[AccessedThroughProperty("ToolStripButton5")]
	private ToolStripButton _ToolStripButton5;

	[AccessedThroughProperty("ToolStripDropDownButton1")]
	private ToolStripDropDownButton _ToolStripDropDownButton1;

	[AccessedThroughProperty("ToolStripSeparator3")]
	private ToolStripSeparator _ToolStripSeparator3;

	[AccessedThroughProperty("ToolStripDropDownButton2")]
	private ToolStripDropDownButton _ToolStripDropDownButton2;

	[AccessedThroughProperty("ToolStripMenuItem1")]
	private ToolStripMenuItem _ToolStripMenuItem1;

	[AccessedThroughProperty("ToolStripMenuItem2")]
	private ToolStripMenuItem _ToolStripMenuItem2;

	[AccessedThroughProperty("ToolStripMenuItem3")]
	private ToolStripMenuItem _ToolStripMenuItem3;

	[AccessedThroughProperty("ToolStripProgressBar1")]
	private ToolStripProgressBar _ToolStripProgressBar1;

	[AccessedThroughProperty("ToolStripButton4")]
	private ToolStripButton _ToolStripButton4;

	[AccessedThroughProperty("ToolStripMenuItem4")]
	private ToolStripMenuItem _ToolStripMenuItem4;

	private double dpixRatio;

	private Treenode CurrentNode;

	private int bomtype;

	private DGVPrinter dgvPrinter;

	private List<Treenode> Clist;

	private bool previewing;

	private int sel_row;

	private int sel_col;

	private string filename_inselitem;

	private string cfgname_inselitem;

	private List<int> rlist;

	internal virtual TreeGridView TGV1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TGV1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DataGridViewRowPostPaintEventHandler value2 = TGV1_RowPostPaint;
			MouseEventHandler value3 = TGV1_MouseDown;
			MouseEventHandler value4 = TGV1_MouseUp;
			DataGridViewCellEventHandler value5 = TGV1_CellEnter;
			if (_TGV1 != null)
			{
				_TGV1.RowPostPaint -= value2;
				_TGV1.MouseDown -= value3;
				_TGV1.MouseUp -= value4;
				_TGV1.CellEnter -= value5;
			}
			_TGV1 = value;
			if (_TGV1 != null)
			{
				_TGV1.RowPostPaint += value2;
				_TGV1.MouseDown += value3;
				_TGV1.MouseUp += value4;
				_TGV1.CellEnter += value5;
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

	internal virtual ToolStripTextBox ToolStripTextBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripTextBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripTextBox1 = value;
		}
	}

	internal virtual ToolStripButton ToolStripButton3
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripButton3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripButton3_Click;
			if (_ToolStripButton3 != null)
			{
				_ToolStripButton3.Click -= value2;
			}
			_ToolStripButton3 = value;
			if (_ToolStripButton3 != null)
			{
				_ToolStripButton3.Click += value2;
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
			_ToolStripDropDownButton3 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_toxls
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem_toxls;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripMenuItem_toxls_Click;
			if (_ToolStripMenuItem_toxls != null)
			{
				_ToolStripMenuItem_toxls.Click -= value2;
			}
			_ToolStripMenuItem_toxls = value;
			if (_ToolStripMenuItem_toxls != null)
			{
				_ToolStripMenuItem_toxls.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem_totxt
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem_totxt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripMenuItem_totxt_Click;
			if (_ToolStripMenuItem_totxt != null)
			{
				_ToolStripMenuItem_totxt.Click -= value2;
			}
			_ToolStripMenuItem_totxt = value;
			if (_ToolStripMenuItem_totxt != null)
			{
				_ToolStripMenuItem_totxt.Click += value2;
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

	internal virtual ToolStripStatusLabel StatusLabel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _StatusLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_StatusLabel1 = value;
		}
	}

	internal virtual ToolStripSeparator ToolStripSeparator4
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripSeparator4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripSeparator4 = value;
		}
	}

	internal virtual ToolStripButton ToolStripButton5
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripButton5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripButton5_Click;
			if (_ToolStripButton5 != null)
			{
				_ToolStripButton5.Click -= value2;
			}
			_ToolStripButton5 = value;
			if (_ToolStripButton5 != null)
			{
				_ToolStripButton5.Click += value2;
			}
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
			EventHandler value3 = ToolStripDropDownButton1_DropDownOpening;
			if (_ToolStripDropDownButton1 != null)
			{
				_ToolStripDropDownButton1.DropDownItemClicked -= value2;
				_ToolStripDropDownButton1.DropDownOpening -= value3;
			}
			_ToolStripDropDownButton1 = value;
			if (_ToolStripDropDownButton1 != null)
			{
				_ToolStripDropDownButton1.DropDownItemClicked += value2;
				_ToolStripDropDownButton1.DropDownOpening += value3;
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

	internal virtual ToolStripDropDownButton ToolStripDropDownButton2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripDropDownButton2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ToolStripDropDownButton2 = value;
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripMenuItem1_Click;
			if (_ToolStripMenuItem1 != null)
			{
				_ToolStripMenuItem1.Click -= value2;
			}
			_ToolStripMenuItem1 = value;
			if (_ToolStripMenuItem1 != null)
			{
				_ToolStripMenuItem1.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripMenuItem2_Click;
			if (_ToolStripMenuItem2 != null)
			{
				_ToolStripMenuItem2.Click -= value2;
			}
			_ToolStripMenuItem2 = value;
			if (_ToolStripMenuItem2 != null)
			{
				_ToolStripMenuItem2.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem3
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripMenuItem3_Click;
			if (_ToolStripMenuItem3 != null)
			{
				_ToolStripMenuItem3.Click -= value2;
			}
			_ToolStripMenuItem3 = value;
			if (_ToolStripMenuItem3 != null)
			{
				_ToolStripMenuItem3.Click += value2;
			}
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

	internal virtual ToolStripButton ToolStripButton4
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripButton4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripButton4_Click;
			if (_ToolStripButton4 != null)
			{
				_ToolStripButton4.Click -= value2;
			}
			_ToolStripButton4 = value;
			if (_ToolStripButton4 != null)
			{
				_ToolStripButton4.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem ToolStripMenuItem4
	{
		[DebuggerNonUserCode]
		get
		{
			return _ToolStripMenuItem4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ToolStripMenuItem4_Click;
			if (_ToolStripMenuItem4 != null)
			{
				_ToolStripMenuItem4.Click -= value2;
			}
			_ToolStripMenuItem4 = value;
			if (_ToolStripMenuItem4 != null)
			{
				_ToolStripMenuItem4.Click += value2;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.Frmbom));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.TGV1 = new AdvancedDataGridView.TreeGridView();
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.ToolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
		this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripButton5 = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
		this.ToolStripMenuItem_toxls = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripMenuItem_totxt = new System.Windows.Forms.ToolStripMenuItem();
		this.ToolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
		this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
		this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.ToolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
		this.ToolStripButton3 = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton4 = new System.Windows.Forms.ToolStripButton();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
		this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		((System.ComponentModel.ISupportInitialize)this.TGV1).BeginInit();
		this.ToolStrip1.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.SuspendLayout();
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ImageList1.Images.SetKeyName(0, "sldasm.png");
		this.ImageList1.Images.SetKeyName(1, "sldprt.png");
		this.TGV1.AllowUserToAddRows = false;
		this.TGV1.AllowUserToDeleteRows = false;
		this.TGV1.AllowUserToOrderColumns = true;
		this.TGV1.AllowUserToResizeRows = false;
		this.TGV1.BackgroundColor = System.Drawing.SystemColors.Control;
		this.TGV1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TGV1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.LightGray;
		dataGridViewCellStyle.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.TGV1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.TGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.TGV1.DefaultCellStyle = dataGridViewCellStyle2;
		this.TGV1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TGV1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
		this.TGV1.EnableHeadersVisualStyles = false;
		this.TGV1.ImageList = this.ImageList1;
		AdvancedDataGridView.TreeGridView tGV = this.TGV1;
		System.Drawing.Point location = new System.Drawing.Point(0, 3);
		tGV.Location = location;
		this.TGV1.Name = "TGV1";
		this.TGV1.NodeCount = 0;
		this.TGV1.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		this.TGV1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		AdvancedDataGridView.TreeGridView tGV2 = this.TGV1;
		System.Drawing.Size size = new System.Drawing.Size(784, 511);
		tGV2.Size = size;
		this.TGV1.TabIndex = 4;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
		{
			this.ToolStripDropDownButton2, this.ToolStripSeparator3, this.ToolStripButton5, this.ToolStripSeparator4, this.ToolStripDropDownButton3, this.ToolStripDropDownButton1, this.ToolStripSeparator1, this.ToolStripButton1, this.ToolStripSeparator2, this.ToolStripTextBox1,
			this.ToolStripButton3, this.ToolStripButton4
		});
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		location = new System.Drawing.Point(0, 0);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		size = new System.Drawing.Size(784, 25);
		toolStrip2.Size = size;
		this.ToolStrip1.TabIndex = 5;
		this.ToolStrip1.Text = "ToolStrip1";
		this.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.ToolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.ToolStripMenuItem1, this.ToolStripMenuItem2, this.ToolStripMenuItem3, this.ToolStripMenuItem4 });
		this.ToolStripDropDownButton2.Image = (System.Drawing.Image)resources.GetObject("ToolStripDropDownButton2.Image");
		this.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2";
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton = this.ToolStripDropDownButton2;
		size = new System.Drawing.Size(69, 22);
		toolStripDropDownButton.Size = size;
		this.ToolStripDropDownButton2.Text = "Тип отчёта";
		this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.ToolStripMenuItem1;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem.Size = size;
		this.ToolStripMenuItem1.Text = "Многоуровневая спецификация";
		this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2 = this.ToolStripMenuItem2;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem2.Size = size;
		this.ToolStripMenuItem2.Text = "Одноуровневая спецификация";
		this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3 = this.ToolStripMenuItem3;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem3.Size = size;
		this.ToolStripMenuItem3.Text = "Спецификация верхнего уровня";
		this.ToolStripSeparator3.Name = "ToolStripSeparator3";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator = this.ToolStripSeparator3;
		size = new System.Drawing.Size(6, 25);
		toolStripSeparator.Size = size;
		this.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.ToolStripButton5.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton5.Image");
		this.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton5.Name = "ToolStripButton5";
		System.Windows.Forms.ToolStripButton toolStripButton = this.ToolStripButton5;
		size = new System.Drawing.Size(36, 22);
		toolStripButton.Size = size;
		this.ToolStripButton5.Text = "Печать";
		this.ToolStripSeparator4.Name = "ToolStripSeparator4";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator2 = this.ToolStripSeparator4;
		size = new System.Drawing.Size(6, 25);
		toolStripSeparator2.Size = size;
		this.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.ToolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ToolStripMenuItem_toxls, this.ToolStripMenuItem_totxt });
		this.ToolStripDropDownButton3.Image = (System.Drawing.Image)resources.GetObject("ToolStripDropDownButton3.Image");
		this.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3";
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2 = this.ToolStripDropDownButton3;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
		toolStripDropDownButton2.Padding = padding;
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3 = this.ToolStripDropDownButton3;
		size = new System.Drawing.Size(79, 22);
		toolStripDropDownButton3.Size = size;
		this.ToolStripDropDownButton3.Text = "Прямой экспорт";
		this.ToolStripMenuItem_toxls.Image = ZTool.My.Resources.Resources.xls;
		this.ToolStripMenuItem_toxls.Name = "ToolStripMenuItem_toxls";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_toxls = this.ToolStripMenuItem_toxls;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_toxls.Size = size;
		this.ToolStripMenuItem_toxls.Text = "Экспорт в Excel";
		this.ToolStripMenuItem_totxt.Image = ZTool.My.Resources.Resources.txt;
		this.ToolStripMenuItem_totxt.Name = "ToolStripMenuItem_totxt";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_totxt = this.ToolStripMenuItem_totxt;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem_totxt.Size = size;
		this.ToolStripMenuItem_totxt.Text = "Экспорт в txt";
		this.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.ToolStripDropDownButton1.Image = (System.Drawing.Image)resources.GetObject("ToolStripDropDownButton1.Image");
		this.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1";
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4 = this.ToolStripDropDownButton1;
		padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
		toolStripDropDownButton4.Padding = padding;
		System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5 = this.ToolStripDropDownButton1;
		size = new System.Drawing.Size(91, 22);
		toolStripDropDownButton5.Size = size;
		this.ToolStripDropDownButton1.Text = "Экспорт по шаблону";
		this.ToolStripSeparator1.Name = "ToolStripSeparator1";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator3 = this.ToolStripSeparator1;
		size = new System.Drawing.Size(6, 25);
		toolStripSeparator3.Size = size;
		this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.ToolStripButton1.Image = (System.Drawing.Image)resources.GetObject("ToolStripButton1.Image");
		this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton1.Name = "ToolStripButton1";
		System.Windows.Forms.ToolStripButton toolStripButton2 = this.ToolStripButton1;
		padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
		toolStripButton2.Padding = padding;
		System.Windows.Forms.ToolStripButton toolStripButton3 = this.ToolStripButton1;
		size = new System.Drawing.Size(70, 22);
		toolStripButton3.Size = size;
		this.ToolStripButton1.Text = "Развернуть всё";
		this.ToolStripSeparator2.Name = "ToolStripSeparator2";
		System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = this.ToolStripSeparator2;
		size = new System.Drawing.Size(6, 25);
		toolStripSeparator4.Size = size;
		this.ToolStripTextBox1.AutoSize = false;
		this.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.ToolStripTextBox1.Name = "ToolStripTextBox1";
		System.Windows.Forms.ToolStripTextBox toolStripTextBox = this.ToolStripTextBox1;
		padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
		toolStripTextBox.Padding = padding;
		System.Windows.Forms.ToolStripTextBox toolStripTextBox2 = this.ToolStripTextBox1;
		size = new System.Drawing.Size(170, 23);
		toolStripTextBox2.Size = size;
		this.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.ToolStripButton3.Image = ZTool.My.Resources.Resources.search_12px;
		this.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton3.Name = "ToolStripButton3";
		System.Windows.Forms.ToolStripButton toolStripButton4 = this.ToolStripButton3;
		size = new System.Drawing.Size(23, 22);
		toolStripButton4.Size = size;
		this.ToolStripButton3.Text = "Поиск";
		this.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.ToolStripButton4.Image = ZTool.My.Resources.Resources.del_12px;
		this.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton4.Name = "ToolStripButton4";
		System.Windows.Forms.ToolStripButton toolStripButton5 = this.ToolStripButton4;
		size = new System.Drawing.Size(23, 22);
		toolStripButton5.Size = size;
		this.ToolStripButton4.Text = "ToolStripButton4";
		this.Panel1.Controls.Add(this.TGV1);
		this.Panel1.Controls.Add(this.StatusStrip1);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.Panel panel = this.Panel1;
		location = new System.Drawing.Point(0, 25);
		panel.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel2 = this.Panel1;
		padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
		panel2.Padding = padding;
		System.Windows.Forms.Panel panel3 = this.Panel1;
		size = new System.Drawing.Size(784, 536);
		panel3.Size = size;
		this.Panel1.TabIndex = 6;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.StatusLabel1, this.ToolStripProgressBar1 });
		System.Windows.Forms.StatusStrip statusStrip = this.StatusStrip1;
		location = new System.Drawing.Point(0, 514);
		statusStrip.Location = location;
		this.StatusStrip1.Name = "StatusStrip1";
		System.Windows.Forms.StatusStrip statusStrip2 = this.StatusStrip1;
		size = new System.Drawing.Size(784, 22);
		statusStrip2.Size = size;
		this.StatusStrip1.TabIndex = 5;
		this.StatusStrip1.Text = "StatusStrip1";
		this.StatusLabel1.Name = "StatusLabel1";
		System.Windows.Forms.ToolStripStatusLabel statusLabel = this.StatusLabel1;
		size = new System.Drawing.Size(0, 17);
		statusLabel.Size = size;
		this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
		System.Windows.Forms.ToolStripProgressBar toolStripProgressBar = this.ToolStripProgressBar1;
		size = new System.Drawing.Size(200, 16);
		toolStripProgressBar.Size = size;
		this.ToolStripProgressBar1.Visible = false;
		this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
		System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4 = this.ToolStripMenuItem4;
		size = new System.Drawing.Size(152, 22);
		toolStripMenuItem4.Size = size;
		this.ToolStripMenuItem4.Text = "Только детали";
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(784, 561);
		this.ClientSize = size;
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.ToolStrip1);
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		size = new System.Drawing.Size(800, 600);
		this.MinimumSize = size;
		this.Name = "Frmbom";
		this.ShowIcon = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Отчёт спецификации";
		((System.ComponentModel.ISupportInitialize)this.TGV1).EndInit();
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public Frmbom()
	{
		base.FormClosed += Frmbom_FormClosed;
		base.Load += Frmbom_Load;
		__ENCAddToList(this);
		dpixRatio = 1.0;
		bomtype = 0;
		rlist = new List<int>();
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			try
			{
				ToolStripProgressBar1.Width = (int)Math.Round((double)ToolStripProgressBar1.Width * dpixRatio);
				StatusLabel1.Width = (int)Math.Round((double)StatusLabel1.Width * dpixRatio);
				StatusStrip1.Items.Insert(1, new ToolStripSeparator());
				dgvPrinter = new DGVPrinter();
				dgvPrinter.SourceDGV = TGV1;
				CurrentNode = (Treenode)MyProject.Forms.Frmmain.TV1.SelectedNode;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void Frmbom_FormClosed(object sender, FormClosedEventArgs e)
	{
		previewing = true;
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void Frmbom_Load(object sender, EventArgs e)
	{
		previewing = true;
		if (Information.IsNothing(CurrentNode))
		{
			CurrentNode = (Treenode)MyProject.Forms.Frmmain.TV1.TopNode;
		}
		checked
		{
			try
			{
				addcolumn();
				Clist = new List<Treenode>();
				bomsetting bomsetting2 = new bomsetting();
				bomsetting2.type = 0;
				bomsetting2.includetop = true;
				bomsetting bst = bomsetting2;
				Clist = MyProject.Forms.Frmmain.GetListFromTree(CurrentNode, bst);
				if (bomtype == 0)
				{
					ToTreeGrid(CurrentNode, TGV1.Nodes);
				}
				else if (bomtype == 1)
				{
					ToTreeGrid2(CurrentNode, TGV1.Nodes);
				}
				else if (bomtype == 2)
				{
					ToTreeGrid(CurrentNode, TGV1.Nodes, 0, onlytop: true);
				}
				else if (bomtype == 3)
				{
					ToTreeGrid2(CurrentNode, TGV1.Nodes, 0, OnlyPart: true);
				}
				if (TGV1.NodeCount > 0)
				{
					TGV1.Nodes[0].ExpandAll();
				}
				StatusLabel1.Text = "Всего " + Conversions.ToString(TGV1.RowCount) + " поз.";
				TGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				List<int> list = new List<int>();
				int num = TGV1.ColumnCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					list.Add(TGV1.Columns[num2].Width);
					num2++;
				}
				TGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
				int num5 = TGV1.ColumnCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					TGV1.Columns[num6].Width = list[num6];
					num6++;
				}
				Text = "Спецификация 【" + code.SplitStr(CurrentNode.PathName, 1) + "】";
				if (bomtype != 0)
				{
					if (bomtype == 1)
					{
						TGV1.Columns.Remove(TGV1.Columns["Col_Levelqty"]);
					}
					else if (bomtype == 2)
					{
						TGV1.Columns.Remove(TGV1.Columns["Col_Levelqty"]);
					}
					else if (bomtype == 3)
					{
						TGV1.Columns.Remove(TGV1.Columns["Col_Levelqty"]);
					}
				}
				previewing = true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				ProjectData.ClearProjectError();
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

	private void TGV1_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		rlist.Clear();
		checked
		{
			int num = TGV1.SelectedCells.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				int rowIndex = TGV1.SelectedCells[num2].RowIndex;
				if (!rlist.Contains(rowIndex))
				{
					rlist.Add(rowIndex);
					TGV1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
				}
				num2++;
			}
			sel_row = e.RowIndex;
			sel_col = e.ColumnIndex;
			if (TGV1.RowCount < 1)
			{
				return;
			}
			if (sel_row > -1)
			{
				TreeGridNode currentNode = TGV1.CurrentNode;
				if (!Information.IsNothing(currentNode))
				{
					filename_inselitem = currentNode.pathname;
					cfgname_inselitem = currentNode.cfgname;
				}
			}
			if (!previewing)
			{
				previewing = true;
				if (sel_row > -1 && Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(MyProject.Forms.FrmPreview.Tag, MyProject.Forms.FrmPreview.Text), filename_inselitem + cfgname_inselitem, TextCompare: false))
				{
					code.Preview2(CConfigMng.Config.DefaultDrw, filename_inselitem, cfgname_inselitem, this);
					Focus();
				}
				previewing = false;
			}
		}
	}

	private void TGV1_MouseUp(object sender, MouseEventArgs e)
	{
		previewing = false;
		if (previewing)
		{
			return;
		}
		previewing = true;
		try
		{
			if (sel_row > -1 && Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(MyProject.Forms.FrmPreview.Tag, MyProject.Forms.FrmPreview.Text), filename_inselitem + cfgname_inselitem, TextCompare: false))
			{
				code.Preview2(CConfigMng.Config.DefaultDrw, filename_inselitem, cfgname_inselitem, this);
				Focus();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		previewing = false;
	}

	private void TGV1_MouseDown(object sender, MouseEventArgs e)
	{
		previewing = true;
	}

	private void TGV1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
	{
		ColorRow();
	}

	private void ToolStripButton1_Click(object sender, EventArgs e)
	{
		TGV1.Nodes[0].ExpandAll();
	}

	private void ToolStripDropDownButton1_DropDownOpening(object sender, EventArgs e)
	{
		ToolStripDropDownButton1.DropDownItems.Clear();
		if (CConfigMng.Config.bomsettings.Count < 1)
		{
			ToolStripDropDownButton1.DropDownItems.Add("Нет доступного шаблона");
			return;
		}
		checked
		{
			int num = CConfigMng.Config.bomsettings.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					ToolStripDropDownButton1.DropDownItems.Add(CConfigMng.Config.bomsettings[num2].name);
					num2++;
					continue;
				}
				break;
			}
		}
	}

	private void ToolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
	{
		_Closure_0024__26 closure_0024__ = new _Closure_0024__26();
		closure_0024__._0024VB_0024Local_e = e;
		try
		{
			ToolStripDropDownButton1.DropDown.Close();
			bomsetting bst = CConfigMng.Config.bomsettings.Find(closure_0024__._Lambda_0024__60);
			if (CConfigMng.Config.usenpoi)
			{
				MyProject.Forms.Frmmain.ExportBom_xls4(bst, CurrentNode);
			}
			else
			{
				MyProject.Forms.Frmmain.ExportBom_xls2(bst, CurrentNode);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void ToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		bomtype = 0;
		if (!Information.IsNothing(CurrentNode))
		{
			Frmbom_Load(null, null);
		}
	}

	private void ToolStripMenuItem2_Click(object sender, EventArgs e)
	{
		bomtype = 1;
		if (!Information.IsNothing(CurrentNode))
		{
			Frmbom_Load(null, null);
		}
	}

	private void ToolStripMenuItem3_Click(object sender, EventArgs e)
	{
		bomtype = 2;
		if (!Information.IsNothing(CurrentNode))
		{
			Frmbom_Load(null, null);
		}
	}

	private void ToolStripMenuItem4_Click(object sender, EventArgs e)
	{
		bomtype = 3;
		if (!Information.IsNothing(CurrentNode))
		{
			Frmbom_Load(null, null);
		}
	}

	private void ToolStripButton5_Click(object sender, EventArgs e)
	{
		dgvPrinter.mainTitle = Text;
		dgvPrinter.subTitle = "Дата печати: " + Conversions.ToString(DateTime.Today);
		dgvPrinter.ShowDialog();
	}

	private void ToolStripMenuItem_toxls_Click(object sender, EventArgs e)
	{
		ToolStripDropDownButton3.DropDown.Close();
		ExportBom_xls();
	}

	private void ToolStripMenuItem_totxt_Click(object sender, EventArgs e)
	{
		ToolStripDropDownButton3.DropDown.Close();
		ExportBom_txt();
	}

	private void ToolStripButton3_Click(object sender, EventArgs e)
	{
		string text = ToolStripTextBox1.Text;
		checked
		{
			int num = TGV1.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				int num5 = TGV1.ColumnCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					string @string = Conversions.ToString(TGV1[num6, num2].Value);
					if ((Operators.CompareString(text, "", TextCompare: false) != 0 && Strings.InStr(@string, text, CompareMethod.Text) > 0) ? true : false)
					{
						TGV1[num6, num2].Style.ForeColor = Color.Orange;
					}
					else
					{
						TGV1[num6, num2].Style.ForeColor = TGV1.DefaultCellStyle.ForeColor;
					}
					num6++;
				}
				num2++;
			}
		}
	}

	private void ToolStripButton4_Click(object sender, EventArgs e)
	{
		ToolStripTextBox1.Clear();
		checked
		{
			int num = TGV1.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				int num5 = TGV1.ColumnCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					TGV1[num6, num2].Style.ForeColor = TGV1.DefaultCellStyle.ForeColor;
					num6++;
				}
				num2++;
			}
		}
	}

	public void addcolumn()
	{
		MyProject.Forms.Frmmain.DoubleBuffer(TGV1);
		TGV1.Nodes.Clear();
		TGV1.Columns.Clear();
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn.Name = "Col_Level";
		dataGridViewTextBoxColumn.HeaderText = "Уровень";
		dataGridViewTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		dataGridViewTextBoxColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
		checked
		{
			dataGridViewTextBoxColumn.Width = (int)Math.Round(50.0 * dpixRatio);
			TGV1.Columns.Add(dataGridViewTextBoxColumn);
			TreeGridColumn treeGridColumn = new TreeGridColumn();
			treeGridColumn.Name = MyProject.Forms.Frmmain.Col_FileName.Name;
			treeGridColumn.HeaderText = MyProject.Forms.Frmmain.Col_FileName.HeaderText;
			treeGridColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
			treeGridColumn.Width = (int)Math.Round(250.0 * dpixRatio);
			TGV1.Columns.Add(treeGridColumn);
			DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn2.Name = "Col_Levelqty";
			dataGridViewTextBoxColumn2.HeaderText = "Количество по уровню";
			dataGridViewTextBoxColumn2.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
			dataGridViewTextBoxColumn2.Width = (int)Math.Round(70.0 * dpixRatio);
			TGV1.Columns.Add(dataGridViewTextBoxColumn2);
			DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn3.Name = "Col_TotalQty";
			dataGridViewTextBoxColumn3.HeaderText = "Общее количество";
			dataGridViewTextBoxColumn3.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
			dataGridViewTextBoxColumn3.Width = (int)Math.Round(70.0 * dpixRatio);
			TGV1.Columns.Add(dataGridViewTextBoxColumn3);
			DataGridViewTextBoxColumn dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			dataGridViewTextBoxColumn4.Name = MyProject.Forms.Frmmain.Col_Cfg.Name;
			dataGridViewTextBoxColumn4.HeaderText = MyProject.Forms.Frmmain.Col_Cfg.HeaderText;
			dataGridViewTextBoxColumn4.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
			dataGridViewTextBoxColumn4.Width = (int)Math.Round(70.0 * dpixRatio);
			TGV1.Columns.Add(dataGridViewTextBoxColumn4);
			int num = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (Strings.InStr(1, MyProject.Forms.Frmmain.DGV1.Columns[num2].Name, "PropResolvedVal_") > 0)
				{
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumn5.Name = MyProject.Forms.Frmmain.DGV1.Columns[num2].Name;
					dataGridViewTextBoxColumn5.HeaderText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
					dataGridViewTextBoxColumn5.DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
					dataGridViewTextBoxColumn5.Width = (int)Math.Round(80.0 * dpixRatio);
					TGV1.Columns.Add(dataGridViewTextBoxColumn5);
				}
				num2++;
			}
			TGV1.ColumnHeadersHeight = (int)Math.Round(25.0 * dpixRatio);
			TGV1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			TGV1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
		}
	}

	public TreeGridNode addnodedata(Treenode node, TreeGridNodeCollection gridnodes, int level)
	{
		_Closure_0024__27 closure_0024__ = new _Closure_0024__27();
		TreeGridNode treeGridNode = null;
		int num = MyProject.Forms.Frmmain.getrowindex(node);
		if ((num == -1 && level > 0) ? true : false)
		{
			return null;
		}
		closure_0024__._0024VB_0024Local_str = "";
		if (code.togetherConfig)
		{
			closure_0024__._0024VB_0024Local_str = node.PathName;
		}
		else
		{
			closure_0024__._0024VB_0024Local_str = node.PathName + "\n" + node.ConfigureName;
		}
		foreach (TreeGridNode gridnode in gridnodes)
		{
			if ((Convert.ToString(RuntimeHelpers.GetObjectValue(gridnode.Tag)).Equals(closure_0024__._0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase) && Operators.CompareString(closure_0024__._0024VB_0024Local_str, "", TextCompare: false) != 0) ? true : false)
			{
				gridnode.Cells[2].Value = Operators.AddObject(gridnode.Cells[2].Value, 1);
				return null;
			}
		}
		Treenode treenode = ((!code.togetherConfig) ? Clist.Find(closure_0024__._Lambda_0024__62) : Clist.Find(closure_0024__._Lambda_0024__61));
		checked
		{
			string[] array = new string[TGV1.ColumnCount - 1 + 1];
			try
			{
				int num2 = TGV1.ColumnCount - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					string name = TGV1.Columns[num3].Name;
					if (name.Equals("Col_Level", StringComparison.OrdinalIgnoreCase))
					{
						array[num3] = Conversions.ToString(level);
					}
					else if (name.Equals("Col_Levelqty", StringComparison.OrdinalIgnoreCase))
					{
						array[num3] = Conversions.ToString(1);
					}
					else if (name.Equals("Col_TotalQty", StringComparison.OrdinalIgnoreCase))
					{
						if (!Information.IsNothing(treenode))
						{
							array[num3] = Conversions.ToString(treenode.realcount);
						}
					}
					else if (name.Equals(MyProject.Forms.Frmmain.Col_FileName.Name, StringComparison.OrdinalIgnoreCase))
					{
						array[num3] = code.SplitStr(node.PathName, 1);
					}
					else if (name.Equals(MyProject.Forms.Frmmain.Col_Cfg.Name, StringComparison.OrdinalIgnoreCase))
					{
						array[num3] = node.ConfigureName;
					}
					else if (num == -1)
					{
						array[num3] = "";
					}
					else
					{
						array[num3] = Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[name, num].Value));
					}
					num3++;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message);
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				ProjectData.ClearProjectError();
			}
			treeGridNode = gridnodes.Add(array);
			treeGridNode.ImageIndex = node.ImageIndex;
			treeGridNode.pathname = node.PathName;
			treeGridNode.cfgname = node.ConfigureName;
			treeGridNode.Tag = closure_0024__._0024VB_0024Local_str;
			return treeGridNode;
		}
	}

	public void ToTreeGrid(Treenode node, TreeGridNodeCollection newnodes, int level = 0, bool onlytop = false)
	{
		if ((onlytop && level > 1) || false || Information.IsNothing(node))
		{
			return;
		}
		TreeGridNode treeGridNode = null;
		if (node.DisplayInBOM == 3 && level > 0)
		{
			foreach (Treenode node4 in node.Nodes)
			{
				ToTreeGrid(node4, newnodes, level, onlytop);
			}
			return;
		}
		if (node.DisplayInBOM == 1 && level > 0)
		{
			treeGridNode = addnodedata(node, newnodes, level);
		}
		else
		{
			if (((node.ExcludeFromBOM || node.IsSuppressed) && level > 0) ? true : false)
			{
				return;
			}
			treeGridNode = addnodedata(node, newnodes, level);
			if (Information.IsNothing(treeGridNode))
			{
				return;
			}
			foreach (Treenode node5 in node.Nodes)
			{
				ToTreeGrid(node5, treeGridNode.Nodes, checked(level + 1), onlytop);
			}
		}
	}

	public void ToTreeGrid2(Treenode node, TreeGridNodeCollection newnodes, int level = 0, bool OnlyPart = false)
	{
		if (Information.IsNothing(node))
		{
			return;
		}
		TreeGridNode treeGridNode = null;
		if ((node.DisplayInBOM == 3 && level > 0) ? true : false)
		{
			foreach (Treenode node6 in node.Nodes)
			{
				ToTreeGrid2(node6, newnodes, level, OnlyPart);
			}
			return;
		}
		if ((OnlyPart && node.DisplayInBOM == 2 && level > 0) ? true : false)
		{
			foreach (Treenode node7 in node.Nodes)
			{
				ToTreeGrid2(node7, newnodes, level, OnlyPart);
			}
			return;
		}
		if ((node.DisplayInBOM == 1 && level > 0) ? true : false)
		{
			treeGridNode = addnodedata(node, newnodes, level);
		}
		else
		{
			if (((node.ExcludeFromBOM || node.IsSuppressed) && level > 0) ? true : false)
			{
				return;
			}
			treeGridNode = addnodedata(node, newnodes, level);
			if (Information.IsNothing(treeGridNode))
			{
				return;
			}
			if (level != 0)
			{
				{
					foreach (Treenode node8 in node.Nodes)
					{
						ToTreeGrid2(node8, newnodes, level, OnlyPart);
					}
					return;
				}
			}
			foreach (Treenode node9 in node.Nodes)
			{
				ToTreeGrid2(node9, treeGridNode.Nodes, 1, OnlyPart);
			}
		}
	}

	public void ColorRow()
	{
		if (TGV1.RowCount < 1)
		{
			return;
		}
		int num = 0;
		checked
		{
			int num2 = TGV1.RowCount - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				if (TGV1.Rows[num3].Visible)
				{
					if (!rlist.Contains(num3))
					{
						if (unchecked(num % 2) == 0)
						{
							TGV1.Rows[num3].DefaultCellStyle.BackColor = TGV1.RowsDefaultCellStyle.BackColor;
						}
						else
						{
							TGV1.Rows[num3].DefaultCellStyle.BackColor = Color.FromArgb(210, 225, 243);
						}
					}
					num++;
				}
				num3++;
			}
		}
	}

	public void ExportBom_txt()
	{
		if (TGV1.RowCount < 1 || TGV1.ColumnCount < 1 || false || !code.canrun)
		{
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.DefaultExt = ".txt";
		saveFileDialog.FileName = code.SplitStr(CurrentNode.PathName, 1) + "-" + DateTime.Now.ToString("yyyyMMdd");
		saveFileDialog.Filter = "Текстовый файл (*.txt)|*.txt";
		saveFileDialog.ValidateNames = true;
		if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		string fileName = saveFileDialog.FileName;
		checked
		{
			try
			{
				StatusLabel1.Text = "Экспорт данных....";
				ToolStripProgressBar1.Maximum = TGV1.RowCount - 1;
				ToolStripProgressBar1.Visible = true;
				StringBuilder stringBuilder = new StringBuilder();
				using (StreamWriter streamWriter = new StreamWriter(fileName, append: false, Encoding.UTF8))
				{
					int num = TGV1.ColumnCount - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						if (TGV1.Columns[num2].Visible)
						{
							try
							{
								if (Operators.CompareString(stringBuilder.ToString(), "", TextCompare: false) == 0)
								{
									stringBuilder.Append(TGV1.Columns[num2].HeaderText);
								}
								else
								{
									stringBuilder.Append("\t" + TGV1.Columns[num2].HeaderText);
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								ProjectData.ClearProjectError();
							}
						}
						num2++;
					}
					streamWriter.WriteLine(stringBuilder);
					int num5 = TGV1.RowCount - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num4 = num5;
						if (num7 > num4)
						{
							break;
						}
						StringBuilder stringBuilder2 = new StringBuilder();
						ToolStripProgressBar1.Value = num6;
						int num8 = TGV1.ColumnCount - 1;
						int num9 = 0;
						while (true)
						{
							int num10 = num9;
							num4 = num8;
							if (num10 > num4)
							{
								break;
							}
							if (TGV1.Columns[num9].Visible)
							{
								string text = Conversions.ToString(TGV1[num9, num6].Value);
								if (Operators.CompareString(stringBuilder2.ToString(), "", TextCompare: false) == 0)
								{
									stringBuilder2.Append(text);
								}
								else
								{
									stringBuilder2.Append("\t" + text);
								}
							}
							num9++;
						}
						streamWriter.WriteLine(stringBuilder2);
						num6++;
					}
				}
				StatusLabel1.Text = "Всего " + Conversions.ToString(TGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
				Process.Start(fileName);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public void ExportBom_xls()
	{
		if (TGV1.RowCount < 1 || TGV1.ColumnCount < 1 || false || !code.canrun)
		{
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.DefaultExt = ".xls";
		saveFileDialog.FileName = code.SplitStr(CurrentNode.PathName, 1) + "-" + DateTime.Now.ToString("yyyyMMdd");
		saveFileDialog.SupportMultiDottedExtensions = true;
		saveFileDialog.Filter = "Книга Excel (*.xlsx)|*.xlsx|Книга Excel 97-2003 (*.xls)|*.xls";
		saveFileDialog.ValidateNames = true;
		if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		string fileName = saveFileDialog.FileName;
		if (Operators.CompareString(fileName.Trim(), "", TextCompare: false) == 0)
		{
			return;
		}
		IWorkbook workbook = null;
		ISheet sheet = null;
		bool flag = false;
		int col_exclude = -1;
		if (!code.canrun)
		{
			return;
		}
		checked
		{
			try
			{
				StatusLabel1.Text = "Экспорт данных....";
				ToolStripProgressBar1.Maximum = TGV1.RowCount - 1;
				ToolStripProgressBar1.Visible = true;
				DocumentSummaryInformation documentSummaryInformation = PropertySetFactory.CreateDocumentSummaryInformation();
				documentSummaryInformation.Company = "";
				documentSummaryInformation.Category = "";
				documentSummaryInformation.Manager = "";
				SummaryInformation summaryInformation = PropertySetFactory.CreateSummaryInformation();
				summaryInformation.Subject = "";
				summaryInformation.Title = "";
				summaryInformation.ApplicationName = "";
				summaryInformation.Author = "SWTools";
				summaryInformation.LastAuthor = "";
				summaryInformation.Comments = "";
				summaryInformation.CreateDateTime = DateTime.Now.AddMonths(-2);
				if (fileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
				{
					workbook = new HSSFWorkbook();
					((HSSFWorkbook)workbook).DocumentSummaryInformation = documentSummaryInformation;
					((HSSFWorkbook)workbook).SummaryInformation = summaryInformation;
					flag = true;
				}
				else if (fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
				{
					workbook = new XSSFWorkbook();
					flag = false;
				}
				sheet = workbook.CreateSheet("sheet1");
				if (Information.IsNothing(sheet))
				{
					return;
				}
				ICellStyle cellStyle = workbook.CreateCellStyle();
				cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
				cellStyle.VerticalAlignment = VerticalAlignment.Center;
				IRow row = null;
				ICell cell = null;
				mynpoi.InsertRows(ref sheet, 0, 1, null);
				row = sheet.GetRow(0);
				if (Information.IsNothing(row))
				{
					return;
				}
				int num = TGV1.ColumnCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (TGV1.Columns[num2].Visible)
					{
						try
						{
							cell = row.GetCell(num2);
							if (Information.IsNothing(cell))
							{
								cell = row.CreateCell(num2);
							}
							string headerText = TGV1.Columns[num2].HeaderText;
							cell.SetCellValue(headerText);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ProjectData.ClearProjectError();
						}
					}
					num2++;
				}
				int num5 = TGV1.RowCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					mynpoi.InsertRows(ref sheet, num6 + 1, 1, null);
					row = sheet.GetRow(num6 + 1);
					if (!Information.IsNothing(row))
					{
						ICell cell2 = row.GetCell(0);
						if (!Information.IsNothing(cell2))
						{
							NPOI.SS.UserModel.HorizontalAlignment alignment = row.GetCell(0).CellStyle.Alignment;
						}
						int num8 = TGV1.ColumnCount - 1;
						int num9 = 0;
						while (true)
						{
							int num10 = num9;
							num4 = num8;
							if (num10 > num4)
							{
								break;
							}
							if (TGV1.Columns[num9].Visible)
							{
								cell = row.GetCell(num9);
								if (Information.IsNothing(cell))
								{
									cell = row.CreateCell(num9);
								}
								string text = Conversions.ToString(TGV1[num9, num6].Value);
								if (long.TryParse(text, out var result))
								{
									cell.SetCellValue(result);
								}
								else
								{
									cell.SetCellValue(text);
								}
							}
							num9++;
						}
						ToolStripProgressBar1.Value = num6;
					}
					num6++;
				}
				mynpoi.AutoColumnWidth(sheet, 0, col_exclude);
				using (FileStream stream = new FileStream(fileName, FileMode.Create))
				{
					workbook.Write(stream);
				}
				StatusLabel1.Text = "Экспорт выполнен";
				ToolStripProgressBar1.Visible = false;
				ToolStripProgressBar1.Value = 0;
				if (MessageBox.Show("Экспорт выполнен! Открыть?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Process.Start(fileName);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					StatusLabel1.Text = "Всего " + Conversions.ToString(TGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
					ToolStripProgressBar1.Visible = false;
					ToolStripProgressBar1.Value = 0;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
			}
		}
	}
}
