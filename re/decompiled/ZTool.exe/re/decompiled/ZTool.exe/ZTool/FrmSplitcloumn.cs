using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmSplitcloumn : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("Undo_Button")]
	private Button _Undo_Button;

	[AccessedThroughProperty("TabPage2")]
	private TabPage _TabPage2;

	[AccessedThroughProperty("dgv_match")]
	private DataGridView _dgv_match;

	[AccessedThroughProperty("Column3")]
	private DataGridViewTextBoxColumn _Column3;

	[AccessedThroughProperty("Column2")]
	private DataGridViewTextBoxColumn _Column2;

	[AccessedThroughProperty("TabPage1")]
	private TabPage _TabPage1;

	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("dgv2")]
	private DataGridView _dgv2;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("tabcontrol1")]
	private TabControl _tabcontrol1;

	[AccessedThroughProperty("ComboBox2")]
	private ComboBox _ComboBox2;

	[AccessedThroughProperty("error_box")]
	private TextBox _error_box;

	[AccessedThroughProperty("TabPage3")]
	private TabPage _TabPage3;

	[AccessedThroughProperty("dgv_split")]
	private DataGridView _dgv_split;

	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn1;

	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	private DataGridViewTextBoxColumn _DataGridViewTextBoxColumn2;

	private DataGridViewComboBoxColumn dgvc1;

	private DataGridViewComboBoxColumn dgvc2;

	private List<int> ColList1;

	private List<int> ColList2;

	private List<DataGridViewCell> CellArr;

	private List<string> CellValArr;

	private List<Color> CellColorArr;

	private List<DataGridViewRow> RowArr;

	private List<bool> Ismodifylist;

	private Dictionary<string, string> default_regexlist_match;

	private Dictionary<string, string> default_regexlist_split;

	private double dpixRatio;

	private Size mediumsize;

	private string oldval;

	private Color mLinearColor1;

	internal virtual Button OK_Button
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

	internal virtual TableLayoutPanel TableLayoutPanel2
	{
		[DebuggerNonUserCode]
		get
		{
			return _TableLayoutPanel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TableLayoutPanel2 = value;
		}
	}

	internal virtual Button Undo_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Undo_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Undo_Button_Click;
			if (_Undo_Button != null)
			{
				_Undo_Button.Click -= value2;
			}
			_Undo_Button = value;
			if (_Undo_Button != null)
			{
				_Undo_Button.Click += value2;
			}
		}
	}

	internal virtual TabPage TabPage2
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage2 = value;
		}
	}

	internal virtual DataGridView dgv_match
	{
		[DebuggerNonUserCode]
		get
		{
			return _dgv_match;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DataGridViewCellEventHandler value2 = dgv1_CellValueChanged;
			DataGridViewCellCancelEventHandler value3 = DGV1_CellBeginEdit;
			DataGridViewDataErrorEventHandler value4 = DGV1_DataError;
			DataGridViewCellPaintingEventHandler value5 = DGV1_CellPainting;
			DataGridViewCellEventHandler value6 = dgv2_CellClick;
			DataGridViewRowsRemovedEventHandler value7 = dgv_match_RowsRemoved;
			if (_dgv_match != null)
			{
				_dgv_match.CellValueChanged -= value2;
				_dgv_match.CellBeginEdit -= value3;
				_dgv_match.DataError -= value4;
				_dgv_match.CellPainting -= value5;
				_dgv_match.CellClick -= value6;
				_dgv_match.RowsRemoved -= value7;
			}
			_dgv_match = value;
			if (_dgv_match != null)
			{
				_dgv_match.CellValueChanged += value2;
				_dgv_match.CellBeginEdit += value3;
				_dgv_match.DataError += value4;
				_dgv_match.CellPainting += value5;
				_dgv_match.CellClick += value6;
				_dgv_match.RowsRemoved += value7;
			}
		}
	}

	internal virtual DataGridViewTextBoxColumn Column3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Column3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Column3 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn Column2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Column2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Column2 = value;
		}
	}

	internal virtual TabPage TabPage1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage1 = value;
		}
	}

	internal virtual LinkLabel LinkLabel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _LinkLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = LinkLabel1_LinkClicked;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.LinkClicked -= value2;
			}
			_LinkLabel1 = value;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.LinkClicked += value2;
			}
		}
	}

	internal virtual Label Label3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label3 = value;
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

	internal virtual RadioButton RadioButton1
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RadioButton1_CheckedChanged;
			if (_RadioButton1 != null)
			{
				_RadioButton1.CheckedChanged -= value2;
			}
			_RadioButton1 = value;
			if (_RadioButton1 != null)
			{
				_RadioButton1.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RadioButton2
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RadioButton1_CheckedChanged;
			if (_RadioButton2 != null)
			{
				_RadioButton2.CheckedChanged -= value2;
			}
			_RadioButton2 = value;
			if (_RadioButton2 != null)
			{
				_RadioButton2.CheckedChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgv2
	{
		[DebuggerNonUserCode]
		get
		{
			return _dgv2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DataGridViewCellEventHandler value2 = dgv1_CellValueChanged;
			DataGridViewCellCancelEventHandler value3 = DGV1_CellBeginEdit;
			DataGridViewDataErrorEventHandler value4 = DGV1_DataError;
			DataGridViewCellPaintingEventHandler value5 = DGV1_CellPainting;
			DataGridViewCellEventHandler value6 = dgv2_CellClick;
			if (_dgv2 != null)
			{
				_dgv2.CellValueChanged -= value2;
				_dgv2.CellBeginEdit -= value3;
				_dgv2.DataError -= value4;
				_dgv2.CellPainting -= value5;
				_dgv2.CellClick -= value6;
			}
			_dgv2 = value;
			if (_dgv2 != null)
			{
				_dgv2.CellValueChanged += value2;
				_dgv2.CellBeginEdit += value3;
				_dgv2.DataError += value4;
				_dgv2.CellPainting += value5;
				_dgv2.CellClick += value6;
			}
		}
	}

	internal virtual ComboBox ComboBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox1 = value;
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

	internal virtual Label Label2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label2 = value;
		}
	}

	internal virtual TabControl tabcontrol1
	{
		[DebuggerNonUserCode]
		get
		{
			return _tabcontrol1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_tabcontrol1 = value;
		}
	}

	internal virtual ComboBox ComboBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox2 = value;
		}
	}

	internal virtual TextBox error_box
	{
		[DebuggerNonUserCode]
		get
		{
			return _error_box;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_error_box = value;
		}
	}

	internal virtual TabPage TabPage3
	{
		[DebuggerNonUserCode]
		get
		{
			return _TabPage3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TabPage3 = value;
		}
	}

	internal virtual DataGridView dgv_split
	{
		[DebuggerNonUserCode]
		get
		{
			return _dgv_split;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DataGridViewCellEventHandler value2 = dgv1_CellValueChanged;
			DataGridViewCellCancelEventHandler value3 = DGV1_CellBeginEdit;
			DataGridViewDataErrorEventHandler value4 = DGV1_DataError;
			DataGridViewCellPaintingEventHandler value5 = DGV1_CellPainting;
			DataGridViewCellEventHandler value6 = dgv2_CellClick;
			DataGridViewRowsRemovedEventHandler value7 = dgv_split_RowsRemoved;
			if (_dgv_split != null)
			{
				_dgv_split.CellValueChanged -= value2;
				_dgv_split.CellBeginEdit -= value3;
				_dgv_split.DataError -= value4;
				_dgv_split.CellPainting -= value5;
				_dgv_split.CellClick -= value6;
				_dgv_split.RowsRemoved -= value7;
			}
			_dgv_split = value;
			if (_dgv_split != null)
			{
				_dgv_split.CellValueChanged += value2;
				_dgv_split.CellBeginEdit += value3;
				_dgv_split.DataError += value4;
				_dgv_split.CellPainting += value5;
				_dgv_split.CellClick += value6;
				_dgv_split.RowsRemoved += value7;
			}
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn1 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[DebuggerNonUserCode]
		get
		{
			return _DataGridViewTextBoxColumn2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_DataGridViewTextBoxColumn2 = value;
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
		this.OK_Button = new System.Windows.Forms.Button();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.Undo_Button = new System.Windows.Forms.Button();
		this.TabPage2 = new System.Windows.Forms.TabPage();
		this.dgv_match = new System.Windows.Forms.DataGridView();
		this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.TabPage1 = new System.Windows.Forms.TabPage();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.Label3 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.dgv2 = new System.Windows.Forms.DataGridView();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.tabcontrol1 = new System.Windows.Forms.TabControl();
		this.TabPage3 = new System.Windows.Forms.TabPage();
		this.dgv_split = new System.Windows.Forms.DataGridView();
		this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.error_box = new System.Windows.Forms.TextBox();
		this.TableLayoutPanel2.SuspendLayout();
		this.TabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv_match).BeginInit();
		this.TabPage1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv2).BeginInit();
		this.tabcontrol1.SuspendLayout();
		this.TabPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv_split).BeginInit();
		this.SuspendLayout();
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		System.Drawing.Point location = new System.Drawing.Point(101, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		System.Drawing.Size size = new System.Drawing.Size(67, 26);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "ОК";
		this.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel2.ColumnCount = 2;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99751f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00249f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel2.Controls.Add(this.OK_Button, 1, 0);
		this.TableLayoutPanel2.Controls.Add(this.Undo_Button, 0, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel2;
		location = new System.Drawing.Point(280, 344);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel2;
		size = new System.Drawing.Size(180, 32);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel2.TabIndex = 13;
		this.TableLayoutPanel2.TabStop = true;
		this.Undo_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Undo_Button.AutoSize = true;
		System.Windows.Forms.Button undo_Button = this.Undo_Button;
		location = new System.Drawing.Point(11, 3);
		undo_Button.Location = location;
		this.Undo_Button.Name = "Undo_Button";
		System.Windows.Forms.Button undo_Button2 = this.Undo_Button;
		size = new System.Drawing.Size(67, 26);
		undo_Button2.Size = size;
		this.Undo_Button.TabIndex = 3;
		this.Undo_Button.Text = "Отменить";
		this.TabPage2.Controls.Add(this.dgv_match);
		System.Windows.Forms.TabPage tabPage = this.TabPage2;
		location = new System.Drawing.Point(4, 26);
		tabPage.Location = location;
		this.TabPage2.Name = "TabPage2";
		System.Windows.Forms.TabPage tabPage2 = this.TabPage2;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(3);
		tabPage2.Padding = padding;
		System.Windows.Forms.TabPage tabPage3 = this.TabPage2;
		size = new System.Drawing.Size(476, 381);
		tabPage3.Size = size;
		this.TabPage2.TabIndex = 1;
		this.TabPage2.Text = "Правило сопоставления";
		this.TabPage2.UseVisualStyleBackColor = true;
		this.dgv_match.AllowUserToResizeRows = false;
		this.dgv_match.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.dgv_match.BackgroundColor = System.Drawing.SystemColors.Control;
		this.dgv_match.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.dgv_match.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_match.Columns.AddRange(this.Column3, this.Column2);
		this.dgv_match.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.DataGridView dataGridView = this.dgv_match;
		location = new System.Drawing.Point(3, 3);
		dataGridView.Location = location;
		this.dgv_match.MultiSelect = false;
		this.dgv_match.Name = "dgv_match";
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.dgv_match.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dgv_match.RowHeadersWidth = 20;
		this.dgv_match.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.dgv_match.RowsDefaultCellStyle = dataGridViewCellStyle2;
		this.dgv_match.RowTemplate.Height = 23;
		this.dgv_match.ShowEditingIcon = false;
		System.Windows.Forms.DataGridView dataGridView2 = this.dgv_match;
		size = new System.Drawing.Size(470, 375);
		dataGridView2.Size = size;
		this.dgv_match.TabIndex = 19;
		this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
		this.Column3.FillWeight = 50f;
		this.Column3.HeaderText = "Имя правила";
		this.Column3.Name = "Column3";
		this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Column3.Width = 150;
		this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
		this.Column2.FillWeight = 50f;
		this.Column2.HeaderText = "Регулярное выражение";
		this.Column2.Name = "Column2";
		this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.TabPage1.Controls.Add(this.LinkLabel1);
		this.TabPage1.Controls.Add(this.TableLayoutPanel2);
		this.TabPage1.Controls.Add(this.Label3);
		this.TabPage1.Controls.Add(this.GroupBox1);
		this.TabPage1.Controls.Add(this.dgv2);
		this.TabPage1.Controls.Add(this.ComboBox2);
		this.TabPage1.Controls.Add(this.ComboBox1);
		this.TabPage1.Controls.Add(this.Label1);
		this.TabPage1.Controls.Add(this.Label2);
		System.Windows.Forms.TabPage tabPage4 = this.TabPage1;
		location = new System.Drawing.Point(4, 26);
		tabPage4.Location = location;
		this.TabPage1.Name = "TabPage1";
		System.Windows.Forms.TabPage tabPage5 = this.TabPage1;
		padding = new System.Windows.Forms.Padding(3);
		tabPage5.Padding = padding;
		System.Windows.Forms.TabPage tabPage6 = this.TabPage1;
		size = new System.Drawing.Size(476, 381);
		tabPage6.Size = size;
		this.TabPage1.TabIndex = 0;
		this.TabPage1.Text = "Операция разделения";
		this.TabPage1.UseVisualStyleBackColor = true;
		this.LinkLabel1.AutoSize = true;
		System.Windows.Forms.LinkLabel linkLabel = this.LinkLabel1;
		location = new System.Drawing.Point(248, 69);
		linkLabel.Location = location;
		this.LinkLabel1.Name = "LinkLabel1";
		System.Windows.Forms.LinkLabel linkLabel2 = this.LinkLabel1;
		size = new System.Drawing.Size(92, 17);
		linkLabel2.Size = size;
		this.LinkLabel1.TabIndex = 23;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Синтаксис регулярных выражений";
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label = this.Label3;
		location = new System.Drawing.Point(194, 8);
		label.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label2 = this.Label3;
		size = new System.Drawing.Size(68, 17);
		label2.Size = size;
		this.Label3.TabIndex = 16;
		this.Label3.Text = "Правило разбиения:";
		this.GroupBox1.Controls.Add(this.RadioButton1);
		this.GroupBox1.Controls.Add(this.RadioButton2);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(380, 8);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(81, 83);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 22;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Способ разделения";
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton1;
		location = new System.Drawing.Point(13, 23);
		radioButton.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton1;
		size = new System.Drawing.Size(50, 21);
		radioButton2.Size = size;
		this.RadioButton1.TabIndex = 21;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Разбить";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.RadioButton2.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton2;
		location = new System.Drawing.Point(13, 50);
		radioButton3.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton2;
		size = new System.Drawing.Size(50, 21);
		radioButton4.Size = size;
		this.RadioButton2.TabIndex = 21;
		this.RadioButton2.Text = "Сопоставить";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.dgv2.AllowUserToResizeRows = false;
		this.dgv2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dgv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.dgv2.BackgroundColor = System.Drawing.SystemColors.Control;
		this.dgv2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
		System.Windows.Forms.DataGridView dataGridView3 = this.dgv2;
		location = new System.Drawing.Point(12, 97);
		dataGridView3.Location = location;
		this.dgv2.Name = "dgv2";
		dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
		dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.dgv2.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
		this.dgv2.RowHeadersWidth = 20;
		this.dgv2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.dgv2.RowTemplate.Height = 23;
		this.dgv2.ShowEditingIcon = false;
		System.Windows.Forms.DataGridView dataGridView4 = this.dgv2;
		size = new System.Drawing.Size(450, 231);
		dataGridView4.Size = size;
		this.dgv2.TabIndex = 18;
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox2.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox = this.ComboBox2;
		location = new System.Drawing.Point(194, 27);
		comboBox.Location = location;
		this.ComboBox2.Name = "ComboBox2";
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox2;
		size = new System.Drawing.Size(155, 25);
		comboBox2.Size = size;
		this.ComboBox2.TabIndex = 14;
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox1.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox3 = this.ComboBox1;
		location = new System.Drawing.Point(12, 27);
		comboBox3.Location = location;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox4 = this.ComboBox1;
		size = new System.Drawing.Size(160, 25);
		comboBox4.Size = size;
		this.ComboBox1.TabIndex = 14;
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label1;
		location = new System.Drawing.Point(12, 8);
		label3.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label4 = this.Label1;
		size = new System.Drawing.Size(80, 17);
		label4.Size = size;
		this.Label1.TabIndex = 16;
		this.Label1.Text = "Столбец для разделения:";
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label2;
		location = new System.Drawing.Point(12, 77);
		label5.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label6 = this.Label2;
		size = new System.Drawing.Size(92, 17);
		label6.Size = size;
		this.Label2.TabIndex = 17;
		this.Label2.Text = "Результат разделения записать в:";
		this.tabcontrol1.Controls.Add(this.TabPage1);
		this.tabcontrol1.Controls.Add(this.TabPage3);
		this.tabcontrol1.Controls.Add(this.TabPage2);
		this.tabcontrol1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.TabControl tabControl = this.tabcontrol1;
		location = new System.Drawing.Point(0, 0);
		tabControl.Location = location;
		this.tabcontrol1.Name = "tabcontrol1";
		this.tabcontrol1.SelectedIndex = 0;
		System.Windows.Forms.TabControl tabControl2 = this.tabcontrol1;
		size = new System.Drawing.Size(484, 411);
		tabControl2.Size = size;
		this.tabcontrol1.TabIndex = 20;
		this.TabPage3.Controls.Add(this.dgv_split);
		System.Windows.Forms.TabPage tabPage7 = this.TabPage3;
		location = new System.Drawing.Point(4, 26);
		tabPage7.Location = location;
		this.TabPage3.Name = "TabPage3";
		System.Windows.Forms.TabPage tabPage8 = this.TabPage3;
		size = new System.Drawing.Size(476, 381);
		tabPage8.Size = size;
		this.TabPage3.TabIndex = 2;
		this.TabPage3.Text = "Правило разбиения";
		this.TabPage3.UseVisualStyleBackColor = true;
		this.dgv_split.AllowUserToResizeRows = false;
		this.dgv_split.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.dgv_split.BackgroundColor = System.Drawing.SystemColors.Control;
		this.dgv_split.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.dgv_split.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dgv_split.Columns.AddRange(this.DataGridViewTextBoxColumn1, this.DataGridViewTextBoxColumn2);
		this.dgv_split.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.DataGridView dataGridView5 = this.dgv_split;
		location = new System.Drawing.Point(0, 0);
		dataGridView5.Location = location;
		this.dgv_split.MultiSelect = false;
		this.dgv_split.Name = "dgv_split";
		dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
		dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.dgv_split.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
		this.dgv_split.RowHeadersWidth = 20;
		this.dgv_split.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.dgv_split.RowsDefaultCellStyle = dataGridViewCellStyle7;
		this.dgv_split.RowTemplate.Height = 23;
		this.dgv_split.ShowEditingIcon = false;
		System.Windows.Forms.DataGridView dataGridView6 = this.dgv_split;
		size = new System.Drawing.Size(476, 381);
		dataGridView6.Size = size;
		this.dgv_split.TabIndex = 20;
		this.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
		dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.DataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
		this.DataGridViewTextBoxColumn1.FillWeight = 50f;
		this.DataGridViewTextBoxColumn1.HeaderText = "Имя правила";
		this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		this.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.DataGridViewTextBoxColumn1.Width = 150;
		this.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.DataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle9;
		this.DataGridViewTextBoxColumn2.FillWeight = 50f;
		this.DataGridViewTextBoxColumn2.HeaderText = "Регулярное выражение";
		this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		this.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.error_box.Dock = System.Windows.Forms.DockStyle.Fill;
		this.error_box.ForeColor = System.Drawing.Color.Red;
		System.Windows.Forms.TextBox textBox = this.error_box;
		location = new System.Drawing.Point(0, 411);
		textBox.Location = location;
		this.error_box.Multiline = true;
		this.error_box.Name = "error_box";
		this.error_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		System.Windows.Forms.TextBox textBox2 = this.error_box;
		size = new System.Drawing.Size(484, 0);
		textBox2.Size = size;
		this.error_box.TabIndex = 21;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(484, 406);
		this.ClientSize = size;
		this.Controls.Add(this.error_box);
		this.Controls.Add(this.tabcontrol1);
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		size = new System.Drawing.Size(500, 445);
		this.MinimumSize = size;
		this.Name = "FrmSplitcloumn";
		this.ShowIcon = false;
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Разделить столбец";
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel2.PerformLayout();
		this.TabPage2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgv_match).EndInit();
		this.TabPage1.ResumeLayout(false);
		this.TabPage1.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv2).EndInit();
		this.tabcontrol1.ResumeLayout(false);
		this.TabPage3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgv_split).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
		this.dgv_match.KeyDown += new System.Windows.Forms.KeyEventHandler(SplitGrid_KeyDown);
		this.dgv2.KeyDown += new System.Windows.Forms.KeyEventHandler(SplitGrid_KeyDown);
		this.dgv_split.KeyDown += new System.Windows.Forms.KeyEventHandler(SplitGrid_KeyDown);
	}

	public FrmSplitcloumn()
	{
		base.FormClosed += FrmSplitcloumn_FormClosed;
		base.Load += FrmSplitcloumn_Load;
		base.KeyPress += FrmSplitcloumn_KeyPress;
		__ENCAddToList(this);
		dgvc1 = new DataGridViewComboBoxColumn();
		dgvc2 = new DataGridViewComboBoxColumn();
		ColList1 = new List<int>();
		ColList2 = new List<int>();
		CellArr = new List<DataGridViewCell>();
		CellValArr = new List<string>();
		CellColorArr = new List<Color>();
		RowArr = new List<DataGridViewRow>();
		Ismodifylist = new List<bool>();
		default_regexlist_match = new Dictionary<string, string>
		{
			{ "Первые 10 символов", "\\A.{10}" },
			{ "Последние 10 символов", ".{10}\\z" },
			{ "С 10-й позиции взять 10 символов", "(?<=^.{9}).{10}" },
			{ "С 10-й позиции взять минимум 10, максимум 20 символов", "(?<=^.{9}).{10,20}" },
			{ "С 10-й позиции взять до конца", "(?<=^.{9}).*\\z" },
			{ "От начала до _ | ( （ [ 【, пробела или конца", "\\A.*?(?=_|\\(|\\（|\\[|\\【|\\s|\\z)" },
			{ "От _ или пробела до конца", "(?<=_|\\s).*\\z" },
			{ "Извлечь символы в ()", "(?<=\\().*?(?=\\))" },
			{ "Извлечь подстроку вида V1.1", "[A-HJ-NP-Z][0-9][.][0-9]" },
			{ "Извлечь в конце подстроку вида V1.1", "[A-HJ-NP-Z][0-9][.][0-9](?=\\z)" },
			{ "Извлечь китайские символы", "[\\u4e00-\\u9fa5]+" }
		};
		default_regexlist_split = new Dictionary<string, string>
		{
			{ "Пробел", "\\s+" },
			{ "Подчёркивание \"_\"", "_" },
			{ "Дефис \"-\"", "\\-" },
			{ "Тильда \"~\"", "\\~" },
			{ "Косая черта \"\\\"", "\\\\" },
			{ "Точка \".\"", "\\." },
			{ "Точка с запятой \";\"", "\\;" },
			{ "Перенос строки", "\\n" },
			{ "Пробел или подчёркивание", "\\s+|_" },
			{ "Китайские символы", "[\\u4e00-\\u9fa5]+" }
		};
		dpixRatio = 1.0;
		ref Size reference = ref mediumsize;
		reference = new Size(500, 550);
		mLinearColor1 = Color.FromArgb(240, 240, 240);
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			MinimumSize = (Size = new Size((int)Math.Round(500.0 * dpixRatio), (int)Math.Round(445.0 * dpixRatio)));
			ref Size reference2 = ref mediumsize;
			reference2 = new Size((int)Math.Round(500.0 * dpixRatio), (int)Math.Round(550.0 * dpixRatio));
		}
	}

	private void FrmSplitcloumn_FormClosed(object sender, FormClosedEventArgs e)
	{
		checked
		{
			try
			{
				CConfigMng.Config.regexlist.Clear();
				if (dgv_match.RowCount >= 1)
				{
					int num = dgv_match.RowCount - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						if (!dgv_match.Rows[num2].ReadOnly)
						{
							string text = Conversions.ToString(dgv_match[0, num2].Value);
							string text2 = Conversions.ToString(dgv_match[1, num2].Value);
							if ((Operators.CompareString(text, "", TextCompare: false) != 0 && Operators.CompareString(text2, "", TextCompare: false) != 0 && !CConfigMng.Config.regexlist.Contains(text)) ? true : false)
							{
								CConfigMng.Config.regexlist.Add(text + "\n" + text2);
							}
						}
						num2++;
					}
				}
				CConfigMng.Config.regexlist_split.Clear();
				if (dgv_split.RowCount >= 1)
				{
					int num5 = dgv_split.RowCount - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num4 = num5;
						if (num7 > num4)
						{
							break;
						}
						if (!dgv_split.Rows[num6].ReadOnly)
						{
							string text3 = Conversions.ToString(dgv_split[0, num6].Value);
							string text4 = Conversions.ToString(dgv_split[1, num6].Value);
							if ((Operators.CompareString(text3, "", TextCompare: false) != 0 && Operators.CompareString(text4, "", TextCompare: false) != 0 && !CConfigMng.Config.regexlist_split.Contains(text3)) ? true : false)
							{
								CConfigMng.Config.regexlist_split.Add(text3 + "\n" + text4);
							}
						}
						num6++;
					}
				}
				CConfigMng.Config.needfillcolumns.Clear();
				if (dgv2.RowCount >= 1)
				{
					int num8 = dgv2.RowCount - 1;
					int num9 = 0;
					while (true)
					{
						int num10 = num9;
						int num4 = num8;
						if (num10 > num4)
						{
							break;
						}
						string text5 = Conversions.ToString(dgv2[0, num9].Value);
						string value = Convert.ToString(RuntimeHelpers.GetObjectValue(dgv2[1, num9].Value));
						if (Operators.CompareString(text5, "", TextCompare: false) != 0)
						{
							CConfigMng.Config.needfillcolumns.Add(text5 + "\n" + Conversions.ToString(dgvc2.Items.IndexOf(value)));
						}
						num9++;
					}
				}
				CConfigMng.SaveConfig();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			Savecfg();
		}
	}

	private void FrmSplitcloumn_Load(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				ComboBox1.Items.Clear();
				ColList1.Clear();
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
					string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
					if (MyProject.Forms.Frmmain.DGV1.Columns[num2].Visible & (num2 != MyProject.Forms.Frmmain.Col_Drw.Index) & (num2 != MyProject.Forms.Frmmain.Col_Extname.Index) & (num2 != MyProject.Forms.Frmmain.Col_Number.Index) & (num2 != MyProject.Forms.Frmmain.Col_Checkbox.Index) & (num2 != MyProject.Forms.Frmmain.Col_Preview.Index))
					{
						ComboBox1.Items.Add(headerText);
						ColList1.Add(num2);
					}
					num2++;
				}
				string headerText2 = MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_FileName.Index].HeaderText;
				ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(headerText2);
				if (ComboBox1.SelectedIndex < 0)
				{
					ComboBox1.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			try
			{
				dgv_match.Rows.Clear();
				int num5 = 0;
				foreach (KeyValuePair<string, string> item in default_regexlist_match)
				{
					dgv_match.Rows.Add();
					dgv_match.Rows[num5].ReadOnly = true;
					dgv_match.Rows[num5].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
					dgv_match[0, num5].Value = item.Key;
					dgv_match[1, num5].Value = item.Value;
					num5++;
				}
				foreach (string item2 in CConfigMng.Config.regexlist)
				{
					string[] array = Strings.Split(item2, "\n");
					if ((array.Count() == 2 && !string.IsNullOrEmpty(array[0]) && !default_regexlist_match.ContainsKey(array[0])) ? true : false)
					{
						dgv_match.Rows.Add();
						dgv_match.Rows[num5].ReadOnly = false;
						dgv_match[0, num5].Value = array[0];
						dgv_match[1, num5].Value = array[1];
						num5++;
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
			try
			{
				dgv_split.Rows.Clear();
				int num6 = 0;
				foreach (KeyValuePair<string, string> item3 in default_regexlist_split)
				{
					dgv_split.Rows.Add();
					dgv_split.Rows[num6].ReadOnly = true;
					dgv_split.Rows[num6].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
					dgv_split[0, num6].Value = item3.Key;
					dgv_split[1, num6].Value = item3.Value;
					num6++;
				}
				foreach (string item4 in CConfigMng.Config.regexlist_split)
				{
					string[] array2 = Strings.Split(item4, "\n");
					if ((array2.Count() == 2 && !string.IsNullOrEmpty(array2[0]) && !default_regexlist_split.ContainsKey(array2[0])) ? true : false)
					{
						dgv_split.Rows.Add();
						dgv_split.Rows[num6].ReadOnly = false;
						dgv_split[0, num6].Value = array2[0];
						dgv_split[1, num6].Value = array2[1];
						num6++;
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ProjectData.ClearProjectError();
			}
			try
			{
				int num7 = 0;
				ColList2.Clear();
				dgvc1.Items.Clear();
				dgvc1.Width = (int)Math.Round((double)dgv2.Width * 0.35);
				dgvc1.FlatStyle = FlatStyle.Popup;
				dgvc1.HeaderText = "Имя столбца";
				dgvc1.DefaultCellStyle.NullValue = "";
				int num8 = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num4 = num8;
					if (num10 > num4)
					{
						break;
					}
					string headerText3 = MyProject.Forms.Frmmain.DGV1.Columns[num9].HeaderText;
					if (!MyProject.Forms.Frmmain.DGV1.Columns[num9].ReadOnly)
					{
						dgvc1.Items.Add(headerText3);
						ColList2.Add(num9);
					}
					num9++;
				}
				ComboBox2.Items.Clear();
				dgvc2.Items.Clear();
				dgvc2.Width = (int)Math.Round((double)dgv2.Width * 0.6);
				dgvc2.FlatStyle = FlatStyle.Popup;
				dgvc2.HeaderText = "Правило сопоставления";
				dgvc2.DefaultCellStyle.NullValue = "";
				dgvc2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgvc2.Items.Add("");
				int num11 = dgv_match.RowCount - 1;
				int num12 = 0;
				while (true)
				{
					int num13 = num12;
					int num4 = num11;
					if (num13 > num4)
					{
						break;
					}
					string text = Conversions.ToString(dgv_match[0, num12].Value);
					if (Strings.Len(text) != 0)
					{
						dgvc2.Items.Add(text);
					}
					num12++;
				}
				int num14 = dgv_split.RowCount - 1;
				int num15 = 0;
				while (true)
				{
					int num16 = num15;
					int num4 = num14;
					if (num16 > num4)
					{
						break;
					}
					string text2 = Conversions.ToString(dgv_split[0, num15].Value);
					if (Strings.Len(text2) != 0)
					{
						ComboBox2.Items.Add(text2);
					}
					num15++;
				}
				dgv2.Columns.Add(dgvc1);
				dgv2.Columns.Add(dgvc2);
				dgv2.Rows.Clear();
				num7 = 0;
				if (CConfigMng.Config.needfillcolumns.Count >= 1)
				{
					int num17 = CConfigMng.Config.needfillcolumns.Count - 1;
					int num18 = 0;
					while (true)
					{
						int num19 = num18;
						int num4 = num17;
						if (num19 <= num4)
						{
							string[] array3 = Strings.Split(CConfigMng.Config.needfillcolumns[num18], "\n");
							if (array3.Count() == 2 && !string.IsNullOrEmpty(array3[0]))
							{
								dgv2.Rows.Add();
								dgv2[0, num7].Value = array3[0];
								dgv2[1, num7].Value = RuntimeHelpers.GetObjectValue(dgvc2.Items[Conversions.ToInteger(array3[1])]);
								num7++;
							}
							num18++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ProjectData.ClearProjectError();
			}
			Loadcfg();
			try
			{
				dgv2.Columns[1].Visible = !RadioButton1.Checked;
				ComboBox2.Enabled = RadioButton1.Checked;
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				ProjectData.ClearProjectError();
			}
			dgv_match.Columns[0].Width = (int)Math.Round((double)dgv_match.Width * 0.35);
			dgv_split.Columns[0].Width = (int)Math.Round((double)dgv_split.Width * 0.35);
			if (ComboBox2.SelectedIndex == -1)
			{
				ComboBox2.SelectedIndex = 0;
			}
		}
	}

	private void FrmSplitcloumn_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void DGV1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		oldval = Conversions.ToString(dataGridView[e.ColumnIndex, e.RowIndex].Value);
	}

	private void dgv1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		checked
		{
			try
			{
				if ((e.RowIndex < 0) | (e.ColumnIndex < 0))
				{
					return;
				}
				if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dataGridView[0, e.RowIndex].Value, "", TextCompare: false), Operators.CompareObjectEqual(dataGridView[1, e.RowIndex].Value, "", TextCompare: false)), e.RowIndex < dataGridView.RowCount - 1)))
				{
					dataGridView.Rows.RemoveAt(e.RowIndex);
				}
				string left = Conversions.ToString(dataGridView[e.ColumnIndex, e.RowIndex].Value);
				if (Operators.CompareString(left, "", TextCompare: false) == 0)
				{
					return;
				}
				if (e.ColumnIndex == 0)
				{
					int num = dataGridView.RowCount - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						if (num2 != e.RowIndex)
						{
							string text = Conversions.ToString(dataGridView[0, num2].Value);
							if (Operators.ConditionalCompareObjectEqual(dataGridView[e.ColumnIndex, num2].Value, dataGridView[e.ColumnIndex, e.RowIndex].Value, TextCompare: false))
							{
								MessageBox.Show(this, "Повторяющееся имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								dataGridView[e.ColumnIndex, e.RowIndex].Value = oldval;
								dataGridView.CancelEdit();
								break;
							}
						}
						num2++;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if ((Operators.CompareString(dataGridView.Name, dgv_match.Name, TextCompare: false) != 0 && Operators.CompareString(dataGridView.Name, dgv_split.Name, TextCompare: false) != 0) ? true : false)
			{
				return;
			}
			try
			{
				int selectedIndex = ComboBox2.SelectedIndex;
				ComboBox2.Items.Clear();
				int num5 = dgv_split.RowCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 > num4)
					{
						break;
					}
					string text2 = Conversions.ToString(dgv_split[0, num6].Value);
					if (Strings.Len(text2) != 0)
					{
						ComboBox2.Items.Add(text2);
					}
					num6++;
				}
				ComboBox2.SelectedIndex = selectedIndex;
				dgvc2.Items.Clear();
				dgvc2.Items.Add("");
				int num8 = dgv_match.RowCount - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num4 = num8;
					if (num10 <= num4)
					{
						string text3 = Conversions.ToString(dgv_match[0, num9].Value);
						if (Strings.Len(text3) != 0)
						{
							dgvc2.Items.Add(text3);
						}
						num9++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void dgv_match_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		checked
		{
			try
			{
				dgvc2.Items.Clear();
				dgvc2.Items.Add("");
				int num = dgv_match.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						string text = Conversions.ToString(dgv_match[0, num2].Value);
						if (Strings.Len(text) != 0)
						{
							dgvc2.Items.Add(text);
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

	private void dgv_split_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		checked
		{
			try
			{
				int selectedIndex = ComboBox2.SelectedIndex;
				ComboBox2.Items.Clear();
				int num = dgv_split.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string text = Conversions.ToString(dgv_split[0, num2].Value);
					if (Strings.Len(text) != 0)
					{
						ComboBox2.Items.Add(text);
					}
					num2++;
				}
				ComboBox2.SelectedIndex = selectedIndex;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			DataGridView dataGridView = (DataGridView)sender;
			if (e.ColumnIndex == -1)
			{
				dataGridView.EditMode = DataGridViewEditMode.EditOnKeystroke;
				dataGridView.EndEdit();
				dataGridView.Rows[e.RowIndex].Selected = true;
			}
			else
			{
				dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void DGV1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
	{
		Rectangle rect = checked(new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1));
		SolidBrush solidBrush = new SolidBrush(mLinearColor1);
		try
		{
			if ((e.RowIndex == -1) | (e.ColumnIndex == -1))
			{
				e.Graphics.FillRectangle(solidBrush, rect);
				e.PaintContent(e.CellBounds);
				ControlPaint.DrawBorder3D(e.Graphics, e.CellBounds, Border3DStyle.RaisedOuter);
				e.Handled = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		finally
		{
			rect = default(Rectangle);
			solidBrush?.Dispose();
		}
	}

	private void DGV1_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		e.Cancel = false;
	}

	public string Getpatternbyname(string name, DataGridView dgv)
	{
		string result = "";
		try
		{
			DataGridViewRow dataGridViewRow = (from DataGridViewRow r in dgv.Rows
				where r.Cells[0].Value.ToString().Equals(name, StringComparison.Ordinal)
				select r).First();
			result = Conversions.ToString(dgv[1, dataGridViewRow.Index].Value);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			try
			{
				code.checkfilename = false;
				MyProject.Forms.Frmmain.DGV1.EndEdit();
				int columnIndex = ColList1[ComboBox1.SelectedIndex];
				int num = 0;
				RowArr.Clear();
				Ismodifylist.Clear();
				int num2 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					if (MyProject.Forms.Frmmain.DGV1.Rows[num3].Visible)
					{
						RowArr.Add(MyProject.Forms.Frmmain.DGV1.Rows[num3]);
						Ismodifylist.Add(Conversions.ToBoolean(MyProject.Forms.Frmmain.DGV1.Rows[num3].Tag));
						string input = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[columnIndex, num3].Value);
						int num6 = dgv2.RowCount - 1;
						int num7 = 0;
						while (true)
						{
							int num8 = num7;
							num5 = num6;
							if (num8 > num5)
							{
								break;
							}
							string text = Conversions.ToString(dgv2[0, num7].Value);
							string name = Conversions.ToString(dgv2[1, num7].Value);
							if (Operators.CompareString(text, "", TextCompare: false) != 0)
							{
								int num9 = ColList2[dgvc1.Items.IndexOf(text)];
								if (RadioButton1.Checked)
								{
									string pattern = Getpatternbyname(ComboBox2.Text, dgv_split);
									try
									{
										if (Regex.IsMatch(input, pattern))
										{
											string text2 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num9, num3].Value);
											string[] array = Regex.Split(input, pattern);
											if (array.Count() >= num7 + 1 && Operators.CompareString(text2, array[num7], TextCompare: false) != 0)
											{
												int num10 = 0;
												if (num9 == MyProject.Forms.Frmmain.Col_FileName.Index)
												{
													num10 = MyProject.Forms.Frmmain.isrepeat(array[num7], num3);
												}
												if (num10 > 0)
												{
													int num11 = Conversions.ToInteger(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Number.Index, num3].Value);
													stringBuilder.AppendLine("Номер " + Conversions.ToString(num11) + " и " + Conversions.ToString(num10) + " строк имеют повторяющиеся имена файлов на диске, заполнение не выполнено!");
												}
												else
												{
													if (num == 0)
													{
														CellArr.Clear();
														CellValArr.Clear();
														CellColorArr.Clear();
													}
													num++;
													CellArr.Add(MyProject.Forms.Frmmain.DGV1[num9, num3]);
													CellValArr.Add(text2);
													CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[num9, num3].Style.ForeColor);
													MyProject.Forms.Frmmain.DGV1[num9, num3].Value = array[num7];
												}
											}
										}
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception ex2 = ex;
										stringBuilder.AppendLine(ex2.Message);
										ProjectData.ClearProjectError();
									}
								}
								else
								{
									string text3 = Getpatternbyname(name, dgv_match);
									if (Operators.CompareString(text3, "", TextCompare: false) != 0)
									{
										try
										{
											if (Regex.IsMatch(input, text3))
											{
												string text4 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num9, num3].Value);
												string text5 = Regex.Match(input, text3).ToString();
												if (Operators.CompareString(text4, text5, TextCompare: false) != 0)
												{
													int num12 = 0;
													if (num9 == MyProject.Forms.Frmmain.Col_FileName.Index)
													{
														num12 = MyProject.Forms.Frmmain.isrepeat(text5, num3);
													}
													if (num12 > 0)
													{
														int num13 = Conversions.ToInteger(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Number.Index, num3].Value);
														stringBuilder.AppendLine("Номер " + Conversions.ToString(num13) + " и " + Conversions.ToString(num12) + " строк имеют повторяющиеся имена файлов на диске, заполнение не выполнено!");
													}
													else
													{
														if (num == 0)
														{
															CellArr.Clear();
															CellValArr.Clear();
															CellColorArr.Clear();
														}
														num++;
														CellArr.Add(MyProject.Forms.Frmmain.DGV1[num9, num3]);
														CellValArr.Add(text4);
														CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[num9, num3].Style.ForeColor);
														MyProject.Forms.Frmmain.DGV1[num9, num3].Value = text5;
													}
												}
											}
										}
										catch (Exception ex3)
										{
											ProjectData.SetProjectError(ex3);
											Exception ex4 = ex3;
											stringBuilder.AppendLine(ex4.Message);
											ProjectData.ClearProjectError();
										}
									}
								}
							}
							num7++;
						}
					}
					num3++;
				}
				error_box.Clear();
				if (Operators.CompareString(stringBuilder.ToString().Trim(), "", TextCompare: false) != 0)
				{
					error_box.Text = stringBuilder.ToString();
					if (Height < mediumsize.Height)
					{
						Size = mediumsize;
					}
				}
				else
				{
					Size = MinimumSize;
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				logopathlist.WriteLog($"Тип исключения: {ex6.GetType().Name}\r\nСообщение: {ex6.Message}\r\nИнформация: {ex6.StackTrace}");
				MessageBox.Show(ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				code.checkfilename = true;
			}
		}
	}

	private void Undo_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = CellArr.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				CellArr[num2].Value = CellValArr[num2];
				CellArr[num2].Style.ForeColor = CellColorArr[num2];
				num2++;
			}
			int num5 = RowArr.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 <= num4)
				{
					RowArr[num6].Tag = Ismodifylist[num6].ToString();
					num6++;
					continue;
				}
				break;
			}
		}
	}

	private void RadioButton1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			dgv2.Columns[1].Visible = !RadioButton1.Checked;
			ComboBox2.Enabled = RadioButton1.Checked;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		FrmUpdatelog frmUpdatelog = new FrmUpdatelog();
		frmUpdatelog.TextBox1.Text = Resources.regexhelp;
		frmUpdatelog.Text = "Синтаксис регулярных выражений";
		frmUpdatelog.WindowState = FormWindowState.Maximized;
		frmUpdatelog.ShowInTaskbar = true;
		frmUpdatelog.Show();
	}

	private void Savecfg()
	{
		CConfigMng.Config.SplitColumncfg.Clear();
		foreach (Control control in Controls)
		{
			FindctlToSave(control);
		}
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.SplitColumncfg.Add(control.Name + "\n" + Conversions.ToString(((CheckBox)control).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.SplitColumncfg.Add(control.Name + "\n" + ((TextBox)control).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.SplitColumncfg.Add(control.Name + "\n" + Conversions.ToString(((ComboBox)control).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.SplitColumncfg.Add(control.Name + "\n" + Conversions.ToString(((RadioButton)control).Checked));
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
	}

	private void Loadcfg()
	{
		foreach (Control control in Controls)
		{
			FindctlToLoad(control);
		}
	}

	private void FindctlToLoad(Control parent)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		Control control = default(Control);
		string[] array = default(string[]);
		IEnumerator enumerator = default(IEnumerator);
		int num5 = default(int);
		int num6 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					int num7;
					int num8;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000a;
					case 579:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_000a;
							case 3:
								goto IL_002a;
							case 4:
								goto IL_0047;
							case 5:
								goto IL_0067;
							case 7:
							case 8:
								goto IL_0081;
							case 9:
								goto IL_009f;
							case 10:
								goto IL_00b2;
							case 12:
								goto IL_00cf;
							case 13:
								goto IL_00e2;
							case 15:
								goto IL_00f7;
							case 16:
								goto IL_010a;
							case 18:
								goto IL_012a;
							case 19:
								goto IL_013d;
							case 6:
							case 11:
							case 14:
							case 17:
							case 20:
							case 21:
							case 22:
								goto IL_0157;
							case 23:
								goto IL_016c;
							case 24:
								goto IL_017c;
							case 25:
							case 26:
								goto IL_0189;
							default:
								goto end_IL_0001;
							case 27:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_00e2:
						num2 = 13;
						((TextBox)control).Text = array[1];
						goto IL_0157;
						IL_00f7:
						num2 = 15;
						if (control is ComboBox)
						{
							goto IL_010a;
						}
						goto IL_012a;
						IL_00cf:
						num2 = 12;
						if (control is TextBox)
						{
							goto IL_00e2;
						}
						goto IL_00f7;
						IL_010a:
						num2 = 16;
						((ComboBox)control).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						goto IL_0157;
						IL_000a:
						num2 = 2;
						enumerator = parent.Controls.GetEnumerator();
						goto IL_018e;
						IL_018e:
						if (enumerator.MoveNext())
						{
							control = (Control)enumerator.Current;
							goto IL_002a;
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						goto end_IL_0001_2;
						IL_012a:
						num2 = 18;
						if (control is RadioButton)
						{
							goto IL_013d;
						}
						goto IL_0157;
						IL_0157:
						num2 = 22;
						num5++;
						goto IL_0160;
						IL_013d:
						num2 = 19;
						((RadioButton)control).Checked = code.Cbool1(array[1]);
						goto IL_0157;
						IL_002a:
						num2 = 3;
						num6 = CConfigMng.Config.SplitColumncfg.Count - 1;
						num5 = 0;
						goto IL_0160;
						IL_0160:
						num7 = num5;
						num8 = num6;
						if (num7 <= num8)
						{
							goto IL_0047;
						}
						goto IL_016c;
						IL_016c:
						num2 = 23;
						if (control.HasChildren)
						{
							goto IL_017c;
						}
						goto IL_0189;
						IL_017c:
						num2 = 24;
						FindctlToLoad(control);
						goto IL_0189;
						IL_0189:
						num2 = 26;
						goto IL_018e;
						IL_0047:
						num2 = 4;
						array = Strings.Split(CConfigMng.Config.SplitColumncfg[num5], "\n");
						goto IL_0067;
						IL_0067:
						num2 = 5;
						if (array.Count() == 2)
						{
							goto IL_0081;
						}
						goto IL_0157;
						IL_0081:
						num2 = 8;
						if (Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
						{
							goto IL_009f;
						}
						goto IL_0157;
						IL_009f:
						num2 = 9;
						if (control is CheckBox)
						{
							goto IL_00b2;
						}
						goto IL_00cf;
						IL_00b2:
						num2 = 10;
						((CheckBox)control).Checked = code.Cbool1(array[1]);
						goto IL_0157;
						end_IL_0001:
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 579;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_2:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void SplitGrid_KeyDown(object P_0, KeyEventArgs P_1)
	{
		try
		{
			if (P_1.KeyCode == Keys.Delete && P_0 is DataGridView { CurrentCell: { RowIndex: var rowIndex } } dataGridView && rowIndex >= 0 && rowIndex < dataGridView.RowCount)
			{
				dataGridView.EndEdit();
				dataGridView.Rows.RemoveAt(rowIndex);
				((HandledEventArgs)(object)P_1).Handled = true;
				P_1.SuppressKeyPress = true;
			}
		}
		catch (Exception)
		{
		}
	}
}
