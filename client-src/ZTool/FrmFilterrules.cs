using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmFilterrules : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__36
	{
		public string _0024VB_0024Local_Str;

		[DebuggerNonUserCode]
		public _Closure_0024__36(_Closure_0024__36 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_Str = other._0024VB_0024Local_Str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__36()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__74(CustomRule s)
		{
			return s.name.Equals(_0024VB_0024Local_Str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__37
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__37(_Closure_0024__37 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__37()
		{
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__75(CustomRule s)
		{
			return s.name.Equals(_0024VB_0024Local_str, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__38
	{
		public string _0024VB_0024Local_oldstr;

		[DebuggerNonUserCode]
		public _Closure_0024__38()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__38(_Closure_0024__38 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_oldstr = other._0024VB_0024Local_oldstr;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__77(bomsetting s)
		{
			return Operators.CompareString(s.name, _0024VB_0024Local_oldstr, TextCompare: false) == 0;
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__78(string s)
		{
			return Operators.CompareString(s, _0024VB_0024Local_oldstr, TextCompare: false) == 0;
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("DGV1")]
	private DataGridView _DGV1;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("add")]
	private Button _add;

	[AccessedThroughProperty("edit")]
	private Button _edit;

	[AccessedThroughProperty("del")]
	private Button _del;

	[AccessedThroughProperty("RuleNameList")]
	private ListBox _RuleNameList;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("ruler_or")]
	private RadioButton _ruler_or;

	[AccessedThroughProperty("ruler_and")]
	private RadioButton _ruler_and;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Column1")]
	private DataGridViewTextBoxColumn _Column1;

	[AccessedThroughProperty("Column3")]
	private DataGridViewComboBoxColumn _Column3;

	[AccessedThroughProperty("Column2")]
	private DataGridViewTextBoxColumn _Column2;

	private string RuleName;

	private List<CustomRule> RulesList;

	private bool canchange;

	[AccessedThroughProperty("ComboBox1")]
	private CustomComboBox2 _ComboBox1;

	private double dpixRatio;

	private Color mLinearColor1;

	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TableLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TableLayoutPanel1 = value;
		}
	}

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

	internal virtual Button Cancel_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Cancel_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Cancel_Button_Click;
			if (_Cancel_Button != null)
			{
				_Cancel_Button.Click -= value2;
			}
			_Cancel_Button = value;
			if (_Cancel_Button != null)
			{
				_Cancel_Button.Click += value2;
			}
		}
	}

	internal virtual DataGridView DGV1
	{
		[DebuggerNonUserCode]
		get
		{
			return _DGV1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			DataGridViewCellEventHandler value2 = DGV1_CellEnter;
			DataGridViewCellEventHandler value3 = DGV1_CellValueChanged;
			DataGridViewCellEventHandler value4 = DGV1_CellClick;
			DataGridViewDataErrorEventHandler value5 = DGV1_DataError;
			PaintEventHandler value6 = DGV1_Paint;
			DataGridViewRowsRemovedEventHandler value7 = DGV1_RowsRemoved;
			DataGridViewCellPaintingEventHandler value8 = DGV1_CellPainting;
			if (_DGV1 != null)
			{
				_DGV1.CellEnter -= value2;
				_DGV1.CellValueChanged -= value3;
				_DGV1.CellClick -= value4;
				_DGV1.DataError -= value5;
				_DGV1.Paint -= value6;
				_DGV1.RowsRemoved -= value7;
				_DGV1.CellPainting -= value8;
			}
			_DGV1 = value;
			if (_DGV1 != null)
			{
				_DGV1.CellEnter += value2;
				_DGV1.CellValueChanged += value3;
				_DGV1.CellClick += value4;
				_DGV1.DataError += value5;
				_DGV1.Paint += value6;
				_DGV1.RowsRemoved += value7;
				_DGV1.CellPainting += value8;
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

	internal virtual Button add
	{
		[DebuggerNonUserCode]
		get
		{
			return _add;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = add1_Click;
			if (_add != null)
			{
				_add.Click -= value2;
			}
			_add = value;
			if (_add != null)
			{
				_add.Click += value2;
			}
		}
	}

	internal virtual Button edit
	{
		[DebuggerNonUserCode]
		get
		{
			return _edit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = edit_Click;
			if (_edit != null)
			{
				_edit.Click -= value2;
			}
			_edit = value;
			if (_edit != null)
			{
				_edit.Click += value2;
			}
		}
	}

	internal virtual Button del
	{
		[DebuggerNonUserCode]
		get
		{
			return _del;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = del_Click;
			if (_del != null)
			{
				_del.Click -= value2;
			}
			_del = value;
			if (_del != null)
			{
				_del.Click += value2;
			}
		}
	}

	internal virtual ListBox RuleNameList
	{
		[DebuggerNonUserCode]
		get
		{
			return _RuleNameList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = RuleNameList_SelectedIndexChanged;
			if (_RuleNameList != null)
			{
				_RuleNameList.SelectedIndexChanged -= value2;
			}
			_RuleNameList = value;
			if (_RuleNameList != null)
			{
				_RuleNameList.SelectedIndexChanged += value2;
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

	internal virtual GroupBox GroupBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox2 = value;
		}
	}

	internal virtual RadioButton ruler_or
	{
		[DebuggerNonUserCode]
		get
		{
			return _ruler_or;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ruler_or_CheckedChanged;
			if (_ruler_or != null)
			{
				_ruler_or.CheckedChanged -= value2;
			}
			_ruler_or = value;
			if (_ruler_or != null)
			{
				_ruler_or.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton ruler_and
	{
		[DebuggerNonUserCode]
		get
		{
			return _ruler_and;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ruler_or_CheckedChanged;
			if (_ruler_and != null)
			{
				_ruler_and.CheckedChanged -= value2;
			}
			_ruler_and = value;
			if (_ruler_and != null)
			{
				_ruler_and.CheckedChanged += value2;
			}
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

	internal virtual DataGridViewTextBoxColumn Column1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Column1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Column1 = value;
		}
	}

	internal virtual DataGridViewComboBoxColumn Column3
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

	private CustomComboBox2 ComboBox1
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
			EventHandler value2 = ComboBox1_SelectedIndexChanged;
			if (_ComboBox1 != null)
			{
				_ComboBox1.SelectedIndexChanged -= value2;
			}
			_ComboBox1 = value;
			if (_ComboBox1 != null)
			{
				_ComboBox1.SelectedIndexChanged += value2;
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.DGV1 = new System.Windows.Forms.DataGridView();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.add = new System.Windows.Forms.Button();
		this.edit = new System.Windows.Forms.Button();
		this.del = new System.Windows.Forms.Button();
		this.RuleNameList = new System.Windows.Forms.ListBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.ruler_or = new System.Windows.Forms.RadioButton();
		this.ruler_and = new System.Windows.Forms.RadioButton();
		this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
		this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).BeginInit();
		this.TableLayoutPanel2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(402, 368);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(163, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(7, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(67, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "ОК";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(88, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(67, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.DGV1.AllowUserToResizeRows = false;
		this.DGV1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		this.DGV1.BackgroundColor = System.Drawing.SystemColors.Control;
		this.DGV1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DGV1.Columns.AddRange(this.Column1, this.Column3, this.Column2);
		this.DGV1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.DGV1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
		System.Windows.Forms.DataGridView dGV = this.DGV1;
		location = new System.Drawing.Point(6, 46);
		dGV.Location = location;
		this.DGV1.Name = "DGV1";
		this.DGV1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		this.DGV1.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.DGV1.RowHeadersWidth = 15;
		this.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.DGV1.RowTemplate.Height = 23;
		System.Windows.Forms.DataGridView dGV2 = this.DGV1;
		size = new System.Drawing.Size(368, 255);
		dGV2.Size = size;
		this.DGV1.TabIndex = 28;
		this.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.TableLayoutPanel2.ColumnCount = 3;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.Controls.Add(this.add, 0, 0);
		this.TableLayoutPanel2.Controls.Add(this.edit, 1, 0);
		this.TableLayoutPanel2.Controls.Add(this.del, 2, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel2;
		location = new System.Drawing.Point(6, 305);
		tableLayoutPanel3.Location = location;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel4 = this.TableLayoutPanel2;
		size = new System.Drawing.Size(153, 33);
		tableLayoutPanel4.Size = size;
		this.TableLayoutPanel2.TabIndex = 27;
		System.Windows.Forms.Button button = this.add;
		location = new System.Drawing.Point(3, 3);
		button.Location = location;
		this.add.Name = "add";
		System.Windows.Forms.Button button2 = this.add;
		size = new System.Drawing.Size(45, 27);
		button2.Size = size;
		this.add.TabIndex = 0;
		this.add.Text = "Добавить";
		this.add.UseVisualStyleBackColor = true;
		System.Windows.Forms.Button button3 = this.edit;
		location = new System.Drawing.Point(54, 3);
		button3.Location = location;
		this.edit.Name = "edit";
		System.Windows.Forms.Button button4 = this.edit;
		size = new System.Drawing.Size(45, 27);
		button4.Size = size;
		this.edit.TabIndex = 0;
		this.edit.Text = "Изменить";
		this.edit.UseVisualStyleBackColor = true;
		System.Windows.Forms.Button button5 = this.del;
		location = new System.Drawing.Point(105, 3);
		button5.Location = location;
		this.del.Name = "del";
		System.Windows.Forms.Button button6 = this.del;
		size = new System.Drawing.Size(45, 27);
		button6.Size = size;
		this.del.TabIndex = 0;
		this.del.Text = "Удалить";
		this.del.UseVisualStyleBackColor = true;
		this.RuleNameList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.RuleNameList.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.RuleNameList.FormattingEnabled = true;
		this.RuleNameList.IntegralHeight = false;
		this.RuleNameList.ItemHeight = 17;
		System.Windows.Forms.ListBox ruleNameList = this.RuleNameList;
		location = new System.Drawing.Point(9, 20);
		ruleNameList.Location = location;
		this.RuleNameList.Name = "RuleNameList";
		this.RuleNameList.ScrollAlwaysVisible = true;
		this.RuleNameList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
		System.Windows.Forms.ListBox ruleNameList2 = this.RuleNameList;
		size = new System.Drawing.Size(154, 276);
		ruleNameList2.Size = size;
		this.RuleNameList.TabIndex = 24;
		this.GroupBox1.Controls.Add(this.RuleNameList);
		this.GroupBox1.Controls.Add(this.TableLayoutPanel2);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(12, 12);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(172, 347);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 29;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Список правил";
		this.GroupBox2.Controls.Add(this.DGV1);
		this.GroupBox2.Controls.Add(this.Label1);
		this.GroupBox2.Controls.Add(this.ruler_or);
		this.GroupBox2.Controls.Add(this.ruler_and);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(190, 12);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(6, 30, 6, 6);
		groupBox4.Padding = padding;
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox2;
		size = new System.Drawing.Size(380, 347);
		groupBox5.Size = size;
		this.GroupBox2.TabIndex = 30;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Изменить правило";
		this.Label1.AutoSize = true;
		this.Label1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.Label1.ForeColor = System.Drawing.Color.Green;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(6, 301);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
		label2.Padding = padding;
		System.Windows.Forms.Label label3 = this.Label1;
		size = new System.Drawing.Size(206, 40);
		label3.Size = size;
		this.Label1.TabIndex = 31;
		this.Label1.Text = "Выберите заголовок строки и нажмите Del для удаления всей строки;\r\nнесколько значений можно разделять латинской точкой с запятой;";
		this.ruler_or.AutoSize = true;
		this.ruler_or.Checked = true;
		System.Windows.Forms.RadioButton radioButton = this.ruler_or;
		location = new System.Drawing.Point(16, 24);
		radioButton.Location = location;
		this.ruler_or.Name = "ruler_or";
		System.Windows.Forms.RadioButton radioButton2 = this.ruler_or;
		size = new System.Drawing.Size(38, 21);
		radioButton2.Size = size;
		this.ruler_or.TabIndex = 29;
		this.ruler_or.TabStop = true;
		this.ruler_or.Text = "Или";
		this.ruler_or.UseVisualStyleBackColor = true;
		this.ruler_and.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton3 = this.ruler_and;
		location = new System.Drawing.Point(80, 24);
		radioButton3.Location = location;
		this.ruler_and.Name = "ruler_and";
		System.Windows.Forms.RadioButton radioButton4 = this.ruler_and;
		size = new System.Drawing.Size(38, 21);
		radioButton4.Size = size;
		this.ruler_and.TabIndex = 29;
		this.ruler_and.Text = "И";
		this.ruler_and.UseVisualStyleBackColor = true;
		this.Column1.HeaderText = "名称";
		this.Column1.MinimumWidth = 10;
		this.Column1.Name = "Column1";
		this.Column1.ReadOnly = true;
		this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Column3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
		this.Column3.FillWeight = 50f;
		this.Column3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Column3.HeaderText = "类型";
		this.Column3.Items.AddRange("等于", "不等于", "包含", "不包含", "开头是", "开头不是", "结尾是", "结尾不是");
		this.Column3.MinimumWidth = 90;
		this.Column3.Name = "Column3";
		this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.Column3.Width = 90;
		this.Column2.FillWeight = 50f;
		this.Column2.HeaderText = "Значение";
		this.Column2.MinimumWidth = 10;
		this.Column2.Name = "Column2";
		this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.Column2.Width = 350;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(577, 406);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmFilterrules";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Пользовательское правило";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.DGV1).EndInit();
		this.TableLayoutPanel2.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmFilterrules()
	{
		base.Load += FrmFilterrules_Load;
		__ENCAddToList(this);
		RuleName = "";
		RulesList = new List<CustomRule>();
		canchange = true;
		ComboBox1 = new CustomComboBox2();
		dpixRatio = 1.0;
		mLinearColor1 = Color.FromArgb(240, 240, 240);
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			int num = DGV1.Columns.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				DGV1.Columns[num2].Width = (int)Math.Round((double)DGV1.Columns[num2].Width * dpixRatio);
				num2++;
			}
			DGV1.RowHeadersWidth = (int)Math.Round((double)DGV1.RowHeadersWidth * dpixRatio);
		}
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				CConfigMng.Config.FilterRulesList.Clear();
				if (RulesList.Count >= 1)
				{
					int num = RulesList.Count - 1;
					int num2 = 0;
					_Closure_0024__36 closure_0024__ = default(_Closure_0024__36);
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						closure_0024__ = new _Closure_0024__36(closure_0024__);
						closure_0024__._0024VB_0024Local_Str = RulesList[num2].name;
						if (!string.IsNullOrEmpty(RulesList[num2].name) && !string.IsNullOrWhiteSpace(RulesList[num2].name) && 0 == 0 && !CConfigMng.Config.FilterRulesList.Exists(closure_0024__._Lambda_0024__74))
						{
							CConfigMng.Config.FilterRulesList.Add(RulesList[num2]);
						}
						num2++;
					}
				}
				CConfigMng.SaveConfig();
				MyProject.Forms.Frmmain.ReadonlyRowMark();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (Conversions.ToDouble(MyProject.Forms.Frmmain._SaveToSW.Keytip) == 1.0)
				{
					MyProject.Forms.Frmmain._SaveToSW_ItemsSourceReady(null, null);
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
				if (Conversions.ToDouble(MyProject.Forms.Frmmain._ExportBom.Keytip) == 1.0)
				{
					MyProject.Forms.Frmmain._ExportBom_ItemsSourceReady(null, null);
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
				if (Conversions.ToDouble(MyProject.Forms.Frmmain._fastfilter.Keytip) == 1.0)
				{
					MyProject.Forms.Frmmain._fastfilter_ItemsSourceReady(null, null);
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ProjectData.ClearProjectError();
			}
			DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void FrmFilterrules_Load(object sender, EventArgs e)
	{
		GroupBox2.Enabled = false;
		DGV1.Rows.Clear();
		DGV1.Controls.Clear();
		DGV1.Controls.Add(ComboBox1);
		ComboBox1.Visible = false;
		ComboBox1.Font = new Font("微软雅黑", 9f);
		ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		checked
		{
			try
			{
				RulesList.Clear();
				RuleNameList.Items.Clear();
				if (CConfigMng.Config.FilterRulesList.Count > 0)
				{
					int num = CConfigMng.Config.FilterRulesList.Count - 1;
					int num2 = 0;
					_Closure_0024__37 closure_0024__ = default(_Closure_0024__37);
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							closure_0024__ = new _Closure_0024__37(closure_0024__);
							closure_0024__._0024VB_0024Local_str = CConfigMng.Config.FilterRulesList[num2].name;
							if (!string.IsNullOrEmpty(closure_0024__._0024VB_0024Local_str) && !string.IsNullOrWhiteSpace(closure_0024__._0024VB_0024Local_str) && 0 == 0 && !RulesList.Exists(closure_0024__._Lambda_0024__75))
							{
								RulesList.Add(CConfigMng.Config.FilterRulesList[num2]);
								RuleNameList.Items.Add(closure_0024__._0024VB_0024Local_str);
							}
							num2++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (MyProject.Forms.Frmmain.DGV1.ColumnCount <= 0)
				{
					return;
				}
				ComboBox1.Items.Clear();
				int num5 = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = num6;
					int num4 = num5;
					if (num7 <= num4)
					{
						if (!((num6 == MyProject.Forms.Frmmain.Col_Preview.Index) | (num6 == MyProject.Forms.Frmmain.Col_Number.Index) | (num6 == MyProject.Forms.Frmmain.Col_Checkbox.Index)))
						{
							string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num6].HeaderText;
							headerText = (MyProject.Forms.Frmmain.DGV1.Columns[num6].Name.Contains("PropVal_") ? (headerText + " (属性表达式)") : (MyProject.Forms.Frmmain.DGV1.Columns[num6].Name.Contains("PropResolvedVal_") ? (headerText + " (属性值)") : ((num6 == MyProject.Forms.Frmmain.Col_Extname.Index) ? "<文件类型>" : ((num6 != MyProject.Forms.Frmmain.Col_Drw.Index) ? ("<" + headerText + ">") : "<有无工程图>"))));
							ComboBox1.Items.Add(headerText);
						}
						num6++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ComboBox1.Items.Clear();
				ProjectData.ClearProjectError();
			}
		}
	}

	private void RuleNameList_SelectedIndexChanged(object sender, EventArgs e)
	{
		bool flag = false;
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(RuleNameList.SelectedItem)))
		{
			RuleName = RuleNameList.SelectedItem.ToString();
			GroupBox2.Enabled = true;
		}
		else
		{
			GroupBox2.Enabled = false;
		}
		int num = 0;
		if (RulesList.Count < 1 || !canchange)
		{
			return;
		}
		checked
		{
			int num2 = RulesList.Count - 1;
			int num3 = 0;
			while (true)
			{
				int num4 = num3;
				int num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				CustomRule customRule = RulesList[num3];
				if (customRule.name.Equals(RuleName, StringComparison.OrdinalIgnoreCase))
				{
					ruler_or.Checked = customRule.type;
					ruler_and.Checked = !customRule.type;
					flag = true;
					DGV1.Rows.Clear();
					int num6 = customRule.RuleList.Count - 1;
					int num7 = 0;
					while (true)
					{
						int num8 = num7;
						num5 = num6;
						if (num8 <= num5)
						{
							string[] array = Strings.Split(customRule.RuleList[num7], "\t|@#$%|");
							if (array.Length >= 3 && !string.IsNullOrEmpty(array[0]) && !string.IsNullOrEmpty(array[1]) && 0 == 0)
							{
								DGV1.Rows.Add();
								DGV1[0, num].Value = array[0];
								DGV1[1, num].Value = array[1];
								DGV1[2, num].Value = array[2];
								num++;
							}
							num7++;
							continue;
						}
						break;
					}
					break;
				}
				num3++;
			}
			if (!flag)
			{
				DGV1.Rows.Clear();
			}
		}
	}

	private void DGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		Refreshrulelist();
	}

	private void DGV1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
	{
		Refreshrulelist();
	}

	private void ruler_or_CheckedChanged(object sender, EventArgs e)
	{
		Refreshrulelist();
	}

	public CustomRule CreateCustomRule(string rulename)
	{
		CustomRule customRule = new CustomRule();
		customRule.name = rulename;
		customRule.type = ruler_or.Checked;
		checked
		{
			int num = DGV1.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (!string.IsNullOrEmpty(Conversions.ToString(DGV1[0, num2].Value)) && !string.IsNullOrEmpty(Conversions.ToString(DGV1[1, num2].Value)) && 0 == 0)
				{
					customRule.RuleList.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DGV1[0, num2].Value, "\t|@#$%|"), DGV1[1, num2].Value), "\t|@#$%|"), Convert.ToString(RuntimeHelpers.GetObjectValue(DGV1[2, num2].Value)))));
				}
				num2++;
			}
			return customRule;
		}
	}

	public void Refreshrulelist()
	{
		try
		{
			int num = RulesList.FindIndex(_Lambda_0024__76);
			if (num >= 0)
			{
				RulesList[num] = CreateCustomRule(RuleName);
			}
			else
			{
				RulesList.Add(CreateCustomRule(RuleName));
			}
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

	private void add1_Click(object sender, EventArgs e)
	{
		string text = Interaction.InputBox("输入规则名称");
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return;
		}
		bool flag = false;
		checked
		{
			int num = RuleNameList.Items.Count - 1;
			while (true)
			{
				int num2 = num;
				int num3 = 0;
				if (num2 < num3)
				{
					break;
				}
				if (string.Equals(text, RuleNameList.Items[num].ToString(), StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					break;
				}
				num += -1;
			}
			if (!flag)
			{
				try
				{
					RuleNameList.Items.Add(text);
					RuleNameList.ClearSelected();
					RuleNameList.SetSelected(RuleNameList.Items.Count - 1, value: true);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
				RulesList.Add(CreateCustomRule(text));
			}
			else
			{
				MessageBox.Show(this, "Имя «" + text + "» уже существует, выберите другое имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	private void del_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = RuleNameList.SelectedItems.Count - 1;
			while (true)
			{
				int num2 = num;
				int num3 = 0;
				if (num2 < num3)
				{
					break;
				}
				try
				{
					string value = Conversions.ToString(RuleNameList.SelectedItems[num]);
					RuleNameList.Items.Remove(value);
					int num4 = RulesList.Count - 1;
					int num5 = 0;
					while (true)
					{
						int num6 = num5;
						num3 = num4;
						if (num6 <= num3)
						{
							if (RulesList[num5].name.Equals(value, StringComparison.OrdinalIgnoreCase))
							{
								RulesList.RemoveAt(num5);
								break;
							}
							num5++;
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
				num += -1;
			}
		}
	}

	private void edit_Click(object sender, EventArgs e)
	{
		if (RuleNameList.SelectedItems.Count < 1)
		{
			return;
		}
		if (RuleNameList.SelectedItems.Count > 1)
		{
			MessageBox.Show(this, "Можно выбрать только один элемент", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		string text = Interaction.InputBox("输入规则名称", "", RuleName);
		if ((Operators.CompareString(text, "", TextCompare: false) == 0) | (Operators.CompareString(text, RuleName, TextCompare: false) == 0))
		{
			return;
		}
		bool flag = false;
		checked
		{
			try
			{
				int num = RuleNameList.Items.Count - 1;
				while (true)
				{
					int num2 = num;
					int num3 = 0;
					if (num2 < num3)
					{
						break;
					}
					if (string.Equals(text, RuleNameList.Items[num].ToString(), StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
					num += -1;
				}
				if (!flag)
				{
					_Closure_0024__38 closure_0024__ = new _Closure_0024__38();
					canchange = false;
					closure_0024__._0024VB_0024Local_oldstr = Conversions.ToString(RuleNameList.Items[RuleNameList.SelectedIndex]);
					RuleNameList.Items[RuleNameList.SelectedIndex] = text;
					RuleName = text;
					RulesList[RuleNameList.SelectedIndex] = CreateCustomRule(RuleName);
					int num4 = CConfigMng.Config.bomsettings.FindIndex(closure_0024__._Lambda_0024__77);
					if (num4 >= 0)
					{
						CConfigMng.Config.bomsettings[num4].name = text;
					}
					int num5 = CConfigMng.Config.ReNameFilterRule.FindIndex(closure_0024__._Lambda_0024__78);
					if (num5 >= 0)
					{
						CConfigMng.Config.ReNameFilterRule[num5] = text;
					}
					canchange = true;
				}
				else
				{
					MessageBox.Show(this, "Имя «" + text + "» уже существует, выберите другое имя", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

	private void DGV1_CellEnter(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		if ((dataGridView.Columns[e.ColumnIndex].Index == 1 && dataGridView.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) ? true : false)
		{
			SendKeys.Send("{F4}");
		}
	}

	private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.ColumnIndex == -1)
			{
				DGV1.EditMode = DataGridViewEditMode.EditOnKeystroke;
				DGV1.EndEdit();
				DGV1.Rows[e.RowIndex].Selected = true;
			}
			else
			{
				DGV1.EditMode = DataGridViewEditMode.EditOnEnter;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string text = ComboBox1.Text;
			if (text.EndsWith(" (属性表达式)"))
			{
				text = text.Substring(0, text.LastIndexOf(" (属性表达式)"));
				text = "%" + text + "%";
			}
			else if (text.EndsWith(" (属性值)"))
			{
				text = text.Substring(0, text.LastIndexOf(" (属性值)"));
				text = "$" + text + "$";
			}
			DGV1.CurrentCell.Value = text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void DGV1_Paint(object sender, PaintEventArgs e)
	{
		try
		{
			if (!Information.IsNothing(DGV1.CurrentCell))
			{
				int rowIndex = DGV1.CurrentCell.RowIndex;
				int columnIndex = DGV1.CurrentCell.ColumnIndex;
				Rectangle cellDisplayRectangle = DGV1.GetCellDisplayRectangle(columnIndex, rowIndex, cutOverflow: false);
				if (rowIndex > -1 && columnIndex == 0)
				{
					ComboBox1.FlatStyle = FlatStyle.System;
					CustomComboBox2 comboBox = ComboBox1;
					Point location = checked(new Point(cellDisplayRectangle.Right - ComboBox1.Width, cellDisplayRectangle.Top + cellDisplayRectangle.Height - ComboBox1.Height));
					comboBox.Location = location;
					ComboBox1.Visible = true;
					ComboBox1.Refresh();
				}
				else
				{
					ComboBox1.Visible = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ComboBox1.Visible = false;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private bool _Lambda_0024__76(CustomRule s)
	{
		return s.name.Equals(RuleName, StringComparison.OrdinalIgnoreCase);
	}
}
