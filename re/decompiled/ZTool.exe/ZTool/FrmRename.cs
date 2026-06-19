using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmRename : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__86
	{
		public string _0024VB_0024Local_oldpathname;

		[DebuggerNonUserCode]
		public _Closure_0024__86(_Closure_0024__86 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_oldpathname = other._0024VB_0024Local_oldpathname;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__86()
		{
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__88
	{
		public string _0024VB_0024Local_str;

		[DebuggerNonUserCode]
		public _Closure_0024__88(_Closure_0024__88 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_str = other._0024VB_0024Local_str;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__88()
		{
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Reset_Button")]
	private Button _Reset_Button;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("TextBox2")]
	private TextBox _TextBox2;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Undo_Button")]
	private Button _Undo_Button;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("NumericUpDown1")]
	private NumericUpDown _NumericUpDown1;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("ByFilter")]
	private CheckBox _ByFilter;

	[AccessedThroughProperty("ByRuler")]
	private CheckBox _ByRuler;

	[AccessedThroughProperty("Label8")]
	private Label _Label8;

	[AccessedThroughProperty("RuleNameList")]
	private CheckedListBox _RuleNameList;

	[AccessedThroughProperty("Excludebyruler")]
	private RadioButton _Excludebyruler;

	[AccessedThroughProperty("UnExcludebyruler")]
	private RadioButton _UnExcludebyruler;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Label9")]
	private Label _Label9;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("ByCheck")]
	private CheckBox _ByCheck;

	private List<DataGridViewCell> CellArr;

	private List<string> CellValArr;

	private List<Color> CellColorArr;

	private List<DataGridViewRow> RowArr;

	private List<bool> Ismodifylist;

	private List<string> vallist;

	private ContextMenuStrip menu1;

	private double dpixRatio;

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
			EventHandler value2 = OK_Button_Click_1;
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

	internal virtual Button Reset_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Reset_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Reset_Button_Click;
			if (_Reset_Button != null)
			{
				_Reset_Button.Click -= value2;
			}
			_Reset_Button = value;
			if (_Reset_Button != null)
			{
				_Reset_Button.Click += value2;
			}
		}
	}

	internal virtual TextBox TextBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = TextBox1_TextChanged;
			if (_TextBox1 != null)
			{
				_TextBox1.TextChanged -= value2;
			}
			_TextBox1 = value;
			if (_TextBox1 != null)
			{
				_TextBox1.TextChanged += value2;
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

	internal virtual TextBox TextBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox2 = value;
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

	internal virtual Label Label6
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label6 = value;
		}
	}

	internal virtual NumericUpDown NumericUpDown1
	{
		[DebuggerNonUserCode]
		get
		{
			return _NumericUpDown1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_NumericUpDown1 = value;
		}
	}

	internal virtual Label Label4
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label4 = value;
		}
	}

	internal virtual CheckBox ByFilter
	{
		[DebuggerNonUserCode]
		get
		{
			return _ByFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ByFilter_CheckedChanged;
			if (_ByFilter != null)
			{
				_ByFilter.CheckedChanged -= value2;
			}
			_ByFilter = value;
			if (_ByFilter != null)
			{
				_ByFilter.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox ByRuler
	{
		[DebuggerNonUserCode]
		get
		{
			return _ByRuler;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ByRuler_CheckedChanged;
			if (_ByRuler != null)
			{
				_ByRuler.CheckedChanged -= value2;
			}
			_ByRuler = value;
			if (_ByRuler != null)
			{
				_ByRuler.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label Label8
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Label8_MouseLeave;
			EventHandler value3 = Label8_MouseHover;
			EventHandler value4 = Label8_Click;
			if (_Label8 != null)
			{
				_Label8.MouseLeave -= value2;
				_Label8.MouseHover -= value3;
				_Label8.Click -= value4;
			}
			_Label8 = value;
			if (_Label8 != null)
			{
				_Label8.MouseLeave += value2;
				_Label8.MouseHover += value3;
				_Label8.Click += value4;
			}
		}
	}

	internal virtual CheckedListBox RuleNameList
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

	internal virtual RadioButton Excludebyruler
	{
		[DebuggerNonUserCode]
		get
		{
			return _Excludebyruler;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Excludebyruler = value;
		}
	}

	internal virtual RadioButton UnExcludebyruler
	{
		[DebuggerNonUserCode]
		get
		{
			return _UnExcludebyruler;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_UnExcludebyruler = value;
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

	private virtual Label Label5
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label5 = value;
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

	internal virtual Label Label9
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label9 = value;
		}
	}

	internal virtual Label Label7
	{
		[DebuggerNonUserCode]
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Label7 = value;
		}
	}

	internal virtual CheckBox ByCheck
	{
		[DebuggerNonUserCode]
		get
		{
			return _ByCheck;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ByCheck_CheckedChanged;
			if (_ByCheck != null)
			{
				_ByCheck.CheckedChanged -= value2;
			}
			_ByCheck = value;
			if (_ByCheck != null)
			{
				_ByCheck.CheckedChanged += value2;
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
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.Reset_Button = new System.Windows.Forms.Button();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Undo_Button = new System.Windows.Forms.Button();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.NumericUpDown1 = new System.Windows.Forms.NumericUpDown();
		this.ByFilter = new System.Windows.Forms.CheckBox();
		this.ByRuler = new System.Windows.Forms.CheckBox();
		this.Label8 = new System.Windows.Forms.Label();
		this.RuleNameList = new System.Windows.Forms.CheckedListBox();
		this.Excludebyruler = new System.Windows.Forms.RadioButton();
		this.UnExcludebyruler = new System.Windows.Forms.RadioButton();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.Button1 = new System.Windows.Forms.Button();
		this.ByCheck = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).BeginInit();
		this.GroupBox2.SuspendLayout();
		this.TableLayoutPanel1.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel2.AutoSize = true;
		this.TableLayoutPanel2.ColumnCount = 3;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel2.Controls.Add(this.Reset_Button, 0, 0);
		this.TableLayoutPanel2.Controls.Add(this.OK_Button, 2, 0);
		this.TableLayoutPanel2.Controls.Add(this.Undo_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel2;
		System.Drawing.Point location = new System.Drawing.Point(237, 346);
		tableLayoutPanel.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel2;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tableLayoutPanel2.Margin = margin;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel2;
		System.Drawing.Size size = new System.Drawing.Size(302, 35);
		tableLayoutPanel3.Size = size;
		this.TableLayoutPanel2.TabIndex = 11;
		this.TableLayoutPanel2.TabStop = true;
		this.Reset_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Reset_Button.AutoSize = true;
		System.Windows.Forms.Button reset_Button = this.Reset_Button;
		location = new System.Drawing.Point(6, 4);
		reset_Button.Location = location;
		System.Windows.Forms.Button reset_Button2 = this.Reset_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		reset_Button2.Margin = margin;
		this.Reset_Button.Name = "Reset_Button";
		System.Windows.Forms.Button reset_Button3 = this.Reset_Button;
		size = new System.Drawing.Size(87, 27);
		reset_Button3.Size = size;
		this.Reset_Button.TabIndex = 3;
		this.Reset_Button.Text = "Сбросить имя файла";
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(211, 4);
		oK_Button.Location = location;
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		oK_Button2.Margin = margin;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button3 = this.OK_Button;
		size = new System.Drawing.Size(79, 27);
		oK_Button3.Size = size;
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "Старт";
		this.Undo_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Undo_Button.AutoSize = true;
		System.Windows.Forms.Button undo_Button = this.Undo_Button;
		location = new System.Drawing.Point(110, 4);
		undo_Button.Location = location;
		System.Windows.Forms.Button undo_Button2 = this.Undo_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		undo_Button2.Margin = margin;
		this.Undo_Button.Name = "Undo_Button";
		System.Windows.Forms.Button undo_Button3 = this.Undo_Button;
		size = new System.Drawing.Size(79, 27);
		undo_Button3.Size = size;
		this.Undo_Button.TabIndex = 1;
		this.Undo_Button.Text = "Отменить";
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		location = new System.Drawing.Point(16, 30);
		textBox.Location = location;
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		textBox2.Margin = margin;
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox3 = this.TextBox1;
		size = new System.Drawing.Size(360, 70);
		textBox3.Size = size;
		this.TextBox1.TabIndex = 13;
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(16, 8);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(80, 17);
		label2.Size = size;
		this.Label1.TabIndex = 14;
		this.Label1.Text = "Правило имени файла:";
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(19, 24);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(44, 17);
		label4.Size = size;
		this.Label2.TabIndex = 15;
		this.Label2.Text = "Пример:";
		this.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox4 = this.TextBox2;
		location = new System.Drawing.Point(21, 48);
		textBox4.Location = location;
		System.Windows.Forms.TextBox textBox5 = this.TextBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		textBox5.Margin = margin;
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.TextBox2;
		size = new System.Drawing.Size(196, 23);
		textBox6.Size = size;
		this.TextBox2.TabIndex = 16;
		this.TextBox2.Text = "$Номер$-$ИмяДетали$-{001}";
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label3;
		location = new System.Drawing.Point(20, 80);
		label5.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label6 = this.Label3;
		size = new System.Drawing.Size(44, 17);
		label6.Size = size;
		this.Label3.TabIndex = 15;
		this.Label3.Text = "Результат:";
		this.Label5.AutoSize = true;
		this.Label5.BackColor = System.Drawing.SystemColors.Control;
		this.Label5.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Label5.ForeColor = System.Drawing.Color.DarkOrange;
		System.Windows.Forms.Label label7 = this.Label5;
		location = new System.Drawing.Point(19, 128);
		label7.Location = location;
		this.Label5.Name = "Label5";
		System.Windows.Forms.Label label8 = this.Label5;
		size = new System.Drawing.Size(181, 85);
		label8.Size = size;
		this.Label5.TabIndex = 15;
		this.Label5.Text = "Описание:\r\n{ } — начальное значение порядкового номера;\r\n$ЗаголовокСтолбца$ — вычисленное значение столбца свойства\r\n%ЗаголовокСтолбца% — выражение столбца свойства\r\n<ЗаголовокСтолбца> — значение из другого столбца\r\n";
		this.GroupBox1.BackColor = System.Drawing.SystemColors.Control;
		this.GroupBox1.Controls.Add(this.Label9);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.TextBox2);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(14, 112);
		groupBox.Location = location;
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox2.Margin = margin;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox3.Padding = margin;
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox1;
		size = new System.Drawing.Size(248, 224);
		groupBox4.Size = size;
		this.GroupBox1.TabIndex = 17;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Инструкция";
		this.Label9.AutoSize = true;
		this.Label9.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.Label label9 = this.Label9;
		location = new System.Drawing.Point(70, 96);
		label9.Location = location;
		this.Label9.Name = "Label9";
		System.Windows.Forms.Label label10 = this.Label9;
		size = new System.Drawing.Size(17, 17);
		label10.Size = size;
		this.Label9.TabIndex = 18;
		this.Label9.Text = "...";
		this.Label7.AutoSize = true;
		this.Label7.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.Label label11 = this.Label7;
		location = new System.Drawing.Point(72, 112);
		label11.Location = location;
		this.Label7.Name = "Label7";
		System.Windows.Forms.Label label12 = this.Label7;
		size = new System.Drawing.Size(109, 17);
		label12.Size = size;
		this.Label7.TabIndex = 17;
		this.Label7.Text = "ID010-Корпус подшипника-010";
		this.Label4.AutoSize = true;
		this.Label4.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.Label label13 = this.Label4;
		location = new System.Drawing.Point(72, 80);
		label13.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label14 = this.Label4;
		size = new System.Drawing.Size(109, 17);
		label14.Size = size;
		this.Label4.TabIndex = 15;
		this.Label4.Text = "ID001-Корпус подшипника-001";
		this.Label6.AutoSize = true;
		System.Windows.Forms.Label label15 = this.Label6;
		location = new System.Drawing.Point(391, 8);
		label15.Location = location;
		this.Label6.Name = "Label6";
		System.Windows.Forms.Label label16 = this.Label6;
		size = new System.Drawing.Size(44, 17);
		label16.Size = size;
		this.Label6.TabIndex = 14;
		this.Label6.Text = "Инкремент:";
		System.Windows.Forms.NumericUpDown numericUpDown = this.NumericUpDown1;
		location = new System.Drawing.Point(393, 32);
		numericUpDown.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown2 = this.NumericUpDown1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		numericUpDown2.Margin = margin;
		System.Windows.Forms.NumericUpDown numericUpDown3 = this.NumericUpDown1;
		decimal maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		numericUpDown3.Maximum = maximum;
		maximum = (this.NumericUpDown1.Minimum = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.NumericUpDown1.Name = "NumericUpDown1";
		System.Windows.Forms.NumericUpDown numericUpDown4 = this.NumericUpDown1;
		size = new System.Drawing.Size(65, 23);
		numericUpDown4.Size = size;
		this.NumericUpDown1.TabIndex = 19;
		maximum = (this.NumericUpDown1.Value = new decimal(new int[4] { 1, 0, 0, 0 }));
		this.ByFilter.AutoSize = true;
		this.ByFilter.Checked = true;
		this.ByFilter.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox byFilter = this.ByFilter;
		location = new System.Drawing.Point(82, 352);
		byFilter.Location = location;
		System.Windows.Forms.CheckBox byFilter2 = this.ByFilter;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		byFilter2.Margin = margin;
		this.ByFilter.Name = "ByFilter";
		System.Windows.Forms.CheckBox byFilter3 = this.ByFilter;
		size = new System.Drawing.Size(63, 21);
		byFilter3.Size = size;
		this.ByFilter.TabIndex = 21;
		this.ByFilter.Text = "По фильтру";
		this.ByFilter.UseVisualStyleBackColor = true;
		this.ByRuler.AutoSize = true;
		System.Windows.Forms.CheckBox byRuler = this.ByRuler;
		location = new System.Drawing.Point(13, 352);
		byRuler.Location = location;
		System.Windows.Forms.CheckBox byRuler2 = this.ByRuler;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		byRuler2.Margin = margin;
		this.ByRuler.Name = "ByRuler";
		System.Windows.Forms.CheckBox byRuler3 = this.ByRuler;
		size = new System.Drawing.Size(63, 21);
		byRuler3.Size = size;
		this.ByRuler.TabIndex = 21;
		this.ByRuler.Text = "По правилу";
		this.ByRuler.UseVisualStyleBackColor = true;
		this.Label8.AutoSize = true;
		this.Label8.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 134);
		this.Label8.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.Label label17 = this.Label8;
		location = new System.Drawing.Point(120, 8);
		label17.Location = location;
		this.Label8.Name = "Label8";
		System.Windows.Forms.Label label18 = this.Label8;
		size = new System.Drawing.Size(0, 12);
		label18.Size = size;
		this.Label8.TabIndex = 23;
		this.RuleNameList.CheckOnClick = true;
		this.RuleNameList.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.CheckedListBox ruleNameList = this.RuleNameList;
		location = new System.Drawing.Point(3, 20);
		ruleNameList.Location = location;
		System.Windows.Forms.CheckedListBox ruleNameList2 = this.RuleNameList;
		margin = new System.Windows.Forms.Padding(0);
		ruleNameList2.Margin = margin;
		this.RuleNameList.Name = "RuleNameList";
		this.RuleNameList.ScrollAlwaysVisible = true;
		System.Windows.Forms.CheckedListBox ruleNameList3 = this.RuleNameList;
		size = new System.Drawing.Size(252, 148);
		ruleNameList3.Size = size;
		this.RuleNameList.TabIndex = 17;
		this.Excludebyruler.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Excludebyruler.AutoSize = true;
		this.Excludebyruler.Checked = true;
		System.Windows.Forms.RadioButton excludebyruler = this.Excludebyruler;
		location = new System.Drawing.Point(3, 27);
		excludebyruler.Location = location;
		System.Windows.Forms.RadioButton excludebyruler2 = this.Excludebyruler;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		excludebyruler2.Margin = margin;
		this.Excludebyruler.Name = "Excludebyruler";
		System.Windows.Forms.RadioButton excludebyruler3 = this.Excludebyruler;
		size = new System.Drawing.Size(86, 21);
		excludebyruler3.Size = size;
		this.Excludebyruler.TabIndex = 24;
		this.Excludebyruler.TabStop = true;
		this.Excludebyruler.Text = "Исключить совпадающие";
		this.Excludebyruler.UseVisualStyleBackColor = true;
		this.UnExcludebyruler.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.UnExcludebyruler.AutoSize = true;
		System.Windows.Forms.RadioButton unExcludebyruler = this.UnExcludebyruler;
		location = new System.Drawing.Point(129, 27);
		unExcludebyruler.Location = location;
		System.Windows.Forms.RadioButton unExcludebyruler2 = this.UnExcludebyruler;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		unExcludebyruler2.Margin = margin;
		this.UnExcludebyruler.Name = "UnExcludebyruler";
		System.Windows.Forms.RadioButton unExcludebyruler3 = this.UnExcludebyruler;
		size = new System.Drawing.Size(86, 21);
		unExcludebyruler3.Size = size;
		this.UnExcludebyruler.TabIndex = 24;
		this.UnExcludebyruler.Text = "Включить совпадающие";
		this.UnExcludebyruler.UseVisualStyleBackColor = true;
		this.GroupBox2.Controls.Add(this.RuleNameList);
		this.GroupBox2.Controls.Add(this.TableLayoutPanel1);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox2;
		location = new System.Drawing.Point(275, 112);
		groupBox5.Location = location;
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox6.Margin = margin;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		groupBox7.Padding = margin;
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox2;
		size = new System.Drawing.Size(258, 224);
		groupBox8.Size = size;
		this.GroupBox2.TabIndex = 25;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Пользовательское правило";
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.LinkLabel1, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Excludebyruler, 0, 1);
		this.TableLayoutPanel1.Controls.Add(this.UnExcludebyruler, 1, 1);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel4 = this.TableLayoutPanel1;
		location = new System.Drawing.Point(3, 168);
		tableLayoutPanel4.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 2;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.1953f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.8047f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel5 = this.TableLayoutPanel1;
		size = new System.Drawing.Size(252, 52);
		tableLayoutPanel5.Size = size;
		this.TableLayoutPanel1.TabIndex = 46;
		this.LinkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		System.Windows.Forms.LinkLabel linkLabel = this.LinkLabel1;
		location = new System.Drawing.Point(3, 2);
		linkLabel.Location = location;
		this.LinkLabel1.Name = "LinkLabel1";
		System.Windows.Forms.LinkLabel linkLabel2 = this.LinkLabel1;
		size = new System.Drawing.Size(56, 17);
		linkLabel2.Size = size;
		this.LinkLabel1.TabIndex = 45;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Создать правило";
		this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(392, 72);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(88, 27);
		button2.Size = size;
		this.Button1.TabIndex = 27;
		this.Button1.Text = "Вставить ссылку....";
		this.Button1.UseVisualStyleBackColor = true;
		this.ByCheck.AutoSize = true;
		System.Windows.Forms.CheckBox byCheck = this.ByCheck;
		location = new System.Drawing.Point(151, 352);
		byCheck.Location = location;
		System.Windows.Forms.CheckBox byCheck2 = this.ByCheck;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		byCheck2.Margin = margin;
		this.ByCheck.Name = "ByCheck";
		System.Windows.Forms.CheckBox byCheck3 = this.ByCheck;
		size = new System.Drawing.Size(63, 21);
		byCheck3.Size = size;
		this.ByCheck.TabIndex = 21;
		this.ByCheck.Text = "По отметке";
		this.ByCheck.UseVisualStyleBackColor = true;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(542, 382);
		this.ClientSize = size;
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.Label8);
		this.Controls.Add(this.ByRuler);
		this.Controls.Add(this.ByCheck);
		this.Controls.Add(this.ByFilter);
		this.Controls.Add(this.NumericUpDown1);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.Label6);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.TableLayoutPanel2);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.Margin = margin;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmRename";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Заполнить имя файла";
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel2.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.NumericUpDown1).EndInit();
		this.GroupBox2.ResumeLayout(false);
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
		this.AutoScroll = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.MaximizeBox = true;
		this.MinimizeBox = true;
		this.MinimumSize = new System.Drawing.Size(542, 382);
	}

	public FrmRename()
	{
		base.FormClosed += FrmRename_FormClosed;
		base.KeyPress += FrmRename_KeyPress;
		base.Load += FrmRename_Load;
		base.Activated += FrmRename_Activated;
		__ENCAddToList(this);
		CellArr = new List<DataGridViewCell>();
		CellValArr = new List<string>();
		CellColorArr = new List<Color>();
		RowArr = new List<DataGridViewRow>();
		Ismodifylist = new List<bool>();
		vallist = new List<string>();
		menu1 = new ContextMenuStrip();
		dpixRatio = 1.0;
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		TextBox1.Height = checked((int)Math.Round(66.0 * dpixRatio));
	}

	private void Reset_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				code.checkfilename = false;
				undo();
				RowArr.Clear();
				Ismodifylist.Clear();
				Frmmain frmmain = MyProject.Forms.Frmmain;
				int num = frmmain.DGV1.Rows.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if ((!frmmain.DGV1[frmmain.Col_FileName.Index, num2].ReadOnly && frmmain.DGV1.Rows[num2].Visible) ? true : false)
					{
						RowArr.Add(MyProject.Forms.Frmmain.DGV1.Rows[num2]);
						Ismodifylist.Add(Conversions.ToBoolean(MyProject.Forms.Frmmain.DGV1.Rows[num2].Tag));
						frmmain.DGV1[frmmain.Col_FileName.Index, num2].Value = code.SplitStr(Conversions.ToString(frmmain.DGV1[frmmain.Col_Path.Index, num2].Value), 1);
						frmmain.DGV1[frmmain.Col_FileName.Index, num2].Style.ForeColor = frmmain.DGV1.DefaultCellStyle.ForeColor;
					}
					num2++;
				}
				frmmain.DGV1.RefreshEdit();
				frmmain = null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			finally
			{
				code.checkfilename = true;
			}
		}
	}

	private void OK_Button_Click_1(object sender, EventArgs e)
	{
		string text = TextBox1.Text.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
		CConfigMng.Config.ReNameRule = text;
		CConfigMng.Config.ReNameByCheck = ByCheck.Checked;
		CConfigMng.Config.ReNameByRule = ByRuler.Checked;
		CConfigMng.Config.ReNameByFilter = ByFilter.Checked;
		CConfigMng.Config.Excludebyruler = Excludebyruler.Checked;
		CConfigMng.SaveConfig();
		CustomFilter customFilter = new CustomFilter(CConfigMng.Config.ReNameFilterRule);
		RowArr.Clear();
		Ismodifylist.Clear();
		List<string> list = new List<string>();
		Dictionary<string, code.dgvdata> dictionary = new Dictionary<string, code.dgvdata>(StringComparer.OrdinalIgnoreCase);
		checked
		{
			try
			{
				code.checkfilename = false;
				int num = 0;
				string text2 = "";
				int num2 = MyProject.Forms.Frmmain.DGV1.Rows.Count - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					RowArr.Add(MyProject.Forms.Frmmain.DGV1.Rows[num3]);
					Ismodifylist.Add(Conversions.ToBoolean(MyProject.Forms.Frmmain.DGV1.Rows[num3].Tag));
					code.dgvdata value = default(code.dgvdata);
					value.pathname = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num3].Value);
					value.index = Conversions.ToInteger(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Number.Index, num3].Value);
					value.type = code.SplitStr(value.pathname, 2);
					string key = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_FileName.Index, num3].Value);
					string key2 = code.SplitStr(value.pathname, 1);
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, value);
					}
					if (!dictionary.ContainsKey(key2))
					{
						dictionary.Add(key2, value);
					}
					num3++;
				}
				int num6 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num7 = 0;
				_Closure_0024__86 closure_0024__ = default(_Closure_0024__86);
				while (true)
				{
					int num8 = num7;
					int num5 = num6;
					if (num8 > num5)
					{
						break;
					}
					closure_0024__ = new _Closure_0024__86(closure_0024__);
					string text3 = Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_FileName.Index, num7].Value));
					closure_0024__._0024VB_0024Local_oldpathname = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num7].Value);
					bool flag = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Checkbox.Index, num7].Value));
					code.dgvdata dgvdata = new code.dgvdata
					{
						pathname = closure_0024__._0024VB_0024Local_oldpathname,
						index = Conversions.ToInteger(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Number.Index, num7].Value),
						type = code.SplitStr(closure_0024__._0024VB_0024Local_oldpathname, 2)
					};
					if (!list.Exists(closure_0024__._Lambda_0024__144) && (!ByCheck.Checked || flag) && 0 == 0 && (!ByFilter.Checked || MyProject.Forms.Frmmain.DGV1.Rows[num7].Visible) && 0 == 0 && (!ByRuler.Checked || customFilter.FilterByRule(num7) != Excludebyruler.Checked) && 0 == 0)
					{
						string text4 = text;
						if (Operators.CompareString(text4, "", TextCompare: false) == 0)
						{
							break;
						}
						int num9 = MyProject.Forms.Frmmain.DGV1.Columns.Count - 1;
						int num10 = 0;
						while (true)
						{
							int num11 = num10;
							num5 = num9;
							if (num11 > num5)
							{
								break;
							}
							if (MyProject.Forms.Frmmain.DGV1.Columns[num10].Name.Contains("PropVal_"))
							{
								string oldValue = "%" + MyProject.Forms.Frmmain.DGV1.Columns[num10].HeaderText + "%";
								text4 = text4.Replace(oldValue, Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num10, num7].Value)));
							}
							else if (MyProject.Forms.Frmmain.DGV1.Columns[num10].Name.Contains("PropResolvedVal_"))
							{
								string oldValue2 = "$" + MyProject.Forms.Frmmain.DGV1.Columns[num10].HeaderText + "$";
								text4 = text4.Replace(oldValue2, Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num10, num7].Value)));
							}
							else
							{
								string text5 = "<" + MyProject.Forms.Frmmain.DGV1.Columns[num10].HeaderText + ">";
								if (vallist.Exists([SpecialName] (string s1) => s1.Equals(text5, StringComparison.OrdinalIgnoreCase)))
								{
									text4 = text4.Replace(text5, Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num10, num7].Value)));
								}
							}
							num10++;
						}
						string text6 = code.MidStrEx(text4, "{", "}");
						if (Versioned.IsNumeric(text6))
						{
							text2 = text4.Replace("{" + text6 + "}", "{" + (Conversions.ToDouble(text6) + (double)num).ToString().PadLeft(text6.Length, '0') + "}");
							text4 = text4.Replace("{" + text6 + "}", (Conversions.ToDouble(text6) + (double)num).ToString().PadLeft(text6.Length, '0'));
						}
						StringBuilder stringBuilder = new StringBuilder();
						code.dgvdata dgvdata2 = lookrepeat(dictionary, text4, dgvdata);
						while (true)
						{
							if (dgvdata2.index > 0)
							{
								list.Add(dgvdata2.pathname);
								text6 = code.MidStrEx(text2, "{", "}");
								if (Versioned.IsNumeric(text6))
								{
									num = Convert.ToInt32(decimal.Add(new decimal(num), NumericUpDown1.Value));
									stringBuilder.Append(text4 + ";");
									text2 = text2.Replace("{" + text6 + "}", "{" + (Conversions.ToDouble(text6) + Convert.ToDouble(NumericUpDown1.Value)).ToString().PadLeft(text6.Length, '0') + "}");
									string text7 = code.MidStrEx(text2, "{", "}");
									text4 = text2.Replace("{" + text7 + "}", text7);
									dgvdata2 = lookrepeat(dictionary, text4, dgvdata);
									continue;
								}
								break;
							}
							if (text4.Equals(text3, StringComparison.OrdinalIgnoreCase))
							{
								num = Convert.ToInt32(decimal.Add(new decimal(num), NumericUpDown1.Value));
								break;
							}
							if (Operators.CompareString(stringBuilder.ToString(), "", TextCompare: false) != 0 && MessageBox.Show(stringBuilder.ToString() + " уже существует, увеличить порядковый номер автоматически?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
							{
								return;
							}
							if (Operators.CompareString(text4, "", TextCompare: false) != 0)
							{
								if (num == 0)
								{
									CellArr.Clear();
									CellValArr.Clear();
									CellColorArr.Clear();
								}
								CellArr.Add(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_FileName.Index, num7]);
								CellValArr.Add(text3);
								CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_FileName.Index, num7].Style.ForeColor);
								if (!dictionary.ContainsKey(text4))
								{
									dictionary.Add(text4, dgvdata);
								}
								list.Add(closure_0024__._0024VB_0024Local_oldpathname);
								MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_FileName.Index, num7].Value = text4;
								string text8 = code.MidStrEx(text2, "{", "}");
								string text9 = code.MidStrEx(text, "{", "}");
								Label8.Text = text.Replace("{" + text9 + "}", "{" + text8 + "}");
								num = Convert.ToInt32(decimal.Add(new decimal(num), NumericUpDown1.Value));
							}
							break;
						}
					}
					num7++;
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
			finally
			{
				code.checkfilename = true;
			}
		}
	}

	public code.dgvdata lookrepeat(Dictionary<string, code.dgvdata> filenamelist, string str, code.dgvdata olddoc)
	{
		code.dgvdata value = default(code.dgvdata);
		if (filenamelist.TryGetValue(str, out value) && ((!string.Equals(value.pathname, olddoc.pathname, StringComparison.OrdinalIgnoreCase) && string.Equals(value.type, olddoc.type, StringComparison.OrdinalIgnoreCase)) ? true : false))
		{
			return value;
		}
		code.dgvdata result = default(code.dgvdata);
		return result;
	}

	private void Undo_Button_Click(object sender, EventArgs e)
	{
		undo();
	}

	public void undo()
	{
		if (CellArr.Count < 1)
		{
			return;
		}
		checked
		{
			try
			{
				code.checkfilename = false;
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			finally
			{
				code.checkfilename = true;
			}
		}
	}

	private void FrmRename_FormClosed(object sender, FormClosedEventArgs e)
	{
		CConfigMng.Config.ReNameRule = TextBox1.Text;
		CConfigMng.Config.ReNameByCheck = ByCheck.Checked;
		CConfigMng.Config.ReNameByRule = ByRuler.Checked;
		CConfigMng.Config.ReNameByFilter = ByFilter.Checked;
		CConfigMng.Config.Excludebyruler = Excludebyruler.Checked;
		CConfigMng.SaveConfig();
	}

	private void FrmRename_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void FrmRename_Load(object sender, EventArgs e)
	{
		try
		{
			menu1 = createmenu();
			TextBox1.Text = CConfigMng.Config.ReNameRule.Replace("\n", "\r\n");
			ByCheck.Checked = CConfigMng.Config.ReNameByCheck;
			ByRuler.Checked = CConfigMng.Config.ReNameByRule;
			ByFilter.Checked = CConfigMng.Config.ReNameByFilter;
			Excludebyruler.Checked = CConfigMng.Config.Excludebyruler;
			UnExcludebyruler.Checked = !Excludebyruler.Checked;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void FrmRename_Activated(object sender, EventArgs e)
	{
		RuleNameList.Items.Clear();
		checked
		{
			int num = CConfigMng.Config.FilterRulesList.Count - 1;
			int num2 = 0;
			_Closure_0024__88 closure_0024__ = default(_Closure_0024__88);
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					closure_0024__ = new _Closure_0024__88(closure_0024__);
					closure_0024__._0024VB_0024Local_str = CConfigMng.Config.FilterRulesList[num2].name;
					bool isChecked = CConfigMng.Config.ReNameFilterRule.Exists(closure_0024__._Lambda_0024__146);
					if (!RuleNameList.Items.Contains(closure_0024__._0024VB_0024Local_str))
					{
						RuleNameList.Items.Add(closure_0024__._0024VB_0024Local_str, isChecked);
					}
					num2++;
					continue;
				}
				break;
			}
		}
	}

	private void Label8_MouseHover(object sender, EventArgs e)
	{
		Cursor = Cursors.Hand;
	}

	private void Label8_MouseLeave(object sender, EventArgs e)
	{
		Cursor = Cursors.Default;
	}

	private void Label8_Click(object sender, EventArgs e)
	{
		string text = Label8.Text;
		string text2 = code.MidStrEx(text, "{", "}");
		if (Versioned.IsNumeric(text2))
		{
			text = Strings.Replace(text, text2, (Conversions.ToDouble(text2) + Convert.ToDouble(NumericUpDown1.Value)).ToString().PadLeft(text2.Length, '0'));
		}
		TextBox1.Text = text;
	}

	private void ByRuler_CheckedChanged(object sender, EventArgs e)
	{
		CConfigMng.Config.ReNameByRule = ((CheckBox)sender).Checked;
		CConfigMng.SaveConfig();
	}

	private void ByFilter_CheckedChanged(object sender, EventArgs e)
	{
		CConfigMng.Config.ReNameByFilter = ((CheckBox)sender).Checked;
		CConfigMng.SaveConfig();
	}

	private void ByCheck_CheckedChanged(object sender, EventArgs e)
	{
		CConfigMng.Config.ReNameByCheck = ((CheckBox)sender).Checked;
		CConfigMng.SaveConfig();
	}

	private void TextBox1_TextChanged(object sender, EventArgs e)
	{
		CConfigMng.Config.ReNameRule = TextBox1.Text;
		CConfigMng.SaveConfig();
	}

	private void RuleNameList_SelectedIndexChanged(object sender, EventArgs e)
	{
		CConfigMng.Config.ReNameFilterRule.Clear();
		checked
		{
			int num = RuleNameList.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				if (RuleNameList.GetItemChecked(num2))
				{
					CConfigMng.Config.ReNameFilterRule.Add(RuleNameList.Items[num2].ToString());
				}
				num2++;
			}
			CConfigMng.SaveConfig();
		}
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		if (!MyProject.Forms.FrmFilterrules.Visible)
		{
			MyProject.Forms.FrmFilterrules.Show(this);
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		menu1.Show(button, button.Width, 0);
	}

	public ContextMenuStrip createmenu()
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		contextMenuStrip.ShowImageMargin = false;
		contextMenuStrip.Items.Clear();
		vallist.Clear();
		contextMenuStrip.AutoSize = true;
		checked
		{
			try
			{
				if (MyProject.Forms.Frmmain.DGV1.ColumnCount > 0)
				{
					int num = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							if ((num2 != MyProject.Forms.Frmmain.Col_Preview.Index && num2 != MyProject.Forms.Frmmain.Col_Checkbox.Index && num2 != MyProject.Forms.Frmmain.Col_Extname.Index && num2 != MyProject.Forms.Frmmain.Col_Drw.Index && num2 != MyProject.Forms.Frmmain.Col_CreationTime.Index && num2 != MyProject.Forms.Frmmain.Col_SaveTime.Index && num2 != MyProject.Forms.Frmmain.Col_bound.Index && num2 != MyProject.Forms.Frmmain.Col_Path.Index && num2 != MyProject.Forms.Frmmain.Col_NewFolder.Index) || 1 == 0)
							{
								string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
								headerText = (MyProject.Forms.Frmmain.DGV1.Columns[num2].Name.Contains("PropVal_") ? (headerText + " (выражение свойства)") : ((!MyProject.Forms.Frmmain.DGV1.Columns[num2].Name.Contains("PropResolvedVal_")) ? ("<" + headerText + ">") : (headerText + " (значение свойства)")));
								contextMenuStrip.Items.Add(headerText);
								vallist.Add(headerText);
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
				ProjectData.ClearProjectError();
			}
			int num5 = contextMenuStrip.Items.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				contextMenuStrip.Items[num6].Click += menuItems_click;
				num6++;
			}
			return contextMenuStrip;
		}
	}

	private void menuItems_click(object sender, EventArgs e)
	{
		try
		{
			string text = TextBox1.Text;
			string text2 = ((ToolStripMenuItem)sender).Text;
			if (text2.EndsWith(" (выражение свойства)"))
			{
				text2 = text2.Substring(0, text2.LastIndexOf(" (выражение свойства)"));
				text2 = "%" + text2 + "%";
			}
			else if (text2.EndsWith(" (значение свойства)"))
			{
				text2 = text2.Substring(0, text2.LastIndexOf(" (значение свойства)"));
				text2 = "$" + text2 + "$";
			}
			TextBox1.Focus();
			int selectionStart = TextBox1.SelectionStart;
			if (TextBox1.SelectionLength > 0)
			{
				text = Strings.Replace(text, TextBox1.SelectedText, text2);
			}
			else
			{
				text = text.Insert(selectionStart, text2);
				TextBox1.Text = text;
			}
			TextBox1.SelectionStart = checked(selectionStart + text2.Length);
			TextBox1.SelectionLength = 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
