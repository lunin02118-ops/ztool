using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser1;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmSaveOption : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("Save_All")]
	private Button _Save_All;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("CheckBox3")]
	private CheckBox _CheckBox3;

	[AccessedThroughProperty("CheckBox2")]
	private CheckBox _CheckBox2;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[AccessedThroughProperty("ComboBox2")]
	private ComboBox _ComboBox2;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("CheckBox4")]
	private CheckBox _CheckBox4;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("CheckBox8")]
	private CheckBox _CheckBox8;

	[AccessedThroughProperty("CheckBox6")]
	private CheckBox _CheckBox6;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("CheckBox7")]
	private CheckBox _CheckBox7;

	[AccessedThroughProperty("CheckBox9")]
	private CheckBox _CheckBox9;

	[AccessedThroughProperty("ComboBox3")]
	private ComboBox _ComboBox3;

	[AccessedThroughProperty("ComboBox4")]
	private ComboBox _ComboBox4;

	[AccessedThroughProperty("CheckBox10")]
	private CheckBox _CheckBox10;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("RadioButton3")]
	private RadioButton _RadioButton3;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Save_Changed")]
	private Button _Save_Changed;

	[AccessedThroughProperty("Save_Failed")]
	private Button _Save_Failed;

	[AccessedThroughProperty("LinkLabel2")]
	private LinkLabel _LinkLabel2;

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

	internal virtual Button Save_All
	{
		[DebuggerNonUserCode]
		get
		{
			return _Save_All;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Save_Click;
			if (_Save_All != null)
			{
				_Save_All.Click -= value2;
			}
			_Save_All = value;
			if (_Save_All != null)
			{
				_Save_All.Click += value2;
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

	internal virtual CheckBox CheckBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox3 = value;
		}
	}

	internal virtual CheckBox CheckBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox2 = value;
		}
	}

	internal virtual CheckBox CheckBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = CheckBox1_CheckedChanged;
			if (_CheckBox1 != null)
			{
				_CheckBox1.CheckedChanged -= value2;
			}
			_CheckBox1 = value;
			if (_CheckBox1 != null)
			{
				_CheckBox1.CheckedChanged += value2;
			}
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
			EventHandler value2 = ComboBox1_TextChanged;
			if (_ComboBox1 != null)
			{
				_ComboBox1.TextChanged -= value2;
			}
			_ComboBox1 = value;
			if (_ComboBox1 != null)
			{
				_ComboBox1.TextChanged += value2;
			}
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

	internal virtual CheckBox CheckBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox4 = value;
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
			EventHandler value2 = TextBox1_MouseEnter;
			MouseEventHandler value3 = TextBox1_MouseDoubleClick;
			if (_TextBox1 != null)
			{
				_TextBox1.MouseEnter -= value2;
				_TextBox1.MouseDoubleClick -= value3;
			}
			_TextBox1 = value;
			if (_TextBox1 != null)
			{
				_TextBox1.MouseEnter += value2;
				_TextBox1.MouseDoubleClick += value3;
			}
		}
	}

	internal virtual CheckBox CheckBox8
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox8 = value;
		}
	}

	internal virtual CheckBox CheckBox6
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = CheckBox6_CheckedChanged_1;
			if (_CheckBox6 != null)
			{
				_CheckBox6.CheckedChanged -= value2;
			}
			_CheckBox6 = value;
			if (_CheckBox6 != null)
			{
				_CheckBox6.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox3 = value;
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

	internal virtual CheckBox CheckBox7
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox7 = value;
		}
	}

	internal virtual CheckBox CheckBox9
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = ComboBox1_TextChanged;
			if (_CheckBox9 != null)
			{
				_CheckBox9.CheckedChanged -= value2;
			}
			_CheckBox9 = value;
			if (_CheckBox9 != null)
			{
				_CheckBox9.CheckedChanged += value2;
			}
		}
	}

	internal virtual ComboBox ComboBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox3 = value;
		}
	}

	internal virtual ComboBox ComboBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox4 = value;
		}
	}

	internal virtual CheckBox CheckBox10
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox10 = value;
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
			_RadioButton2 = value;
		}
	}

	internal virtual RadioButton RadioButton3
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_RadioButton3 = value;
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
			_RadioButton1 = value;
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
			EventHandler value2 = LinkLabel1_TextChanged;
			LinkLabelLinkClickedEventHandler value3 = LinkLabel1_LinkClicked;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.TextChanged -= value2;
				_LinkLabel1.LinkClicked -= value3;
			}
			_LinkLabel1 = value;
			if (_LinkLabel1 != null)
			{
				_LinkLabel1.TextChanged += value2;
				_LinkLabel1.LinkClicked += value3;
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

	internal virtual Button Save_Changed
	{
		[DebuggerNonUserCode]
		get
		{
			return _Save_Changed;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Save_Click;
			if (_Save_Changed != null)
			{
				_Save_Changed.Click -= value2;
			}
			_Save_Changed = value;
			if (_Save_Changed != null)
			{
				_Save_Changed.Click += value2;
			}
		}
	}

	internal virtual Button Save_Failed
	{
		[DebuggerNonUserCode]
		get
		{
			return _Save_Failed;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Save_Click;
			if (_Save_Failed != null)
			{
				_Save_Failed.Click -= value2;
			}
			_Save_Failed = value;
			if (_Save_Failed != null)
			{
				_Save_Failed.Click += value2;
			}
		}
	}

	internal virtual LinkLabel LinkLabel2
	{
		[DebuggerNonUserCode]
		get
		{
			return _LinkLabel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			LinkLabelLinkClickedEventHandler value2 = LinkLabel2_LinkClicked;
			if (_LinkLabel2 != null)
			{
				_LinkLabel2.LinkClicked -= value2;
			}
			_LinkLabel2 = value;
			if (_LinkLabel2 != null)
			{
				_LinkLabel2.LinkClicked += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	public FrmSaveOption()
	{
		base.Load += FrmSaveOption_Load;
		base.HelpButtonClicked += FrmSaveOption_HelpButtonClicked;
		__ENCAddToList(this);
		InitializeComponent();
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
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.Save_Changed = new System.Windows.Forms.Button();
		this.Save_All = new System.Windows.Forms.Button();
		this.Save_Failed = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ComboBox4 = new System.Windows.Forms.ComboBox();
		this.CheckBox10 = new System.Windows.Forms.CheckBox();
		this.CheckBox3 = new System.Windows.Forms.CheckBox();
		this.CheckBox2 = new System.Windows.Forms.CheckBox();
		this.CheckBox9 = new System.Windows.Forms.CheckBox();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.ComboBox3 = new System.Windows.Forms.ComboBox();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.Label2 = new System.Windows.Forms.Label();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.RadioButton3 = new System.Windows.Forms.RadioButton();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.CheckBox7 = new System.Windows.Forms.CheckBox();
		this.CheckBox4 = new System.Windows.Forms.CheckBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.CheckBox8 = new System.Windows.Forms.CheckBox();
		this.CheckBox6 = new System.Windows.Forms.CheckBox();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.Label3 = new System.Windows.Forms.Label();
		this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
		this.TableLayoutPanel1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 4;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.04762f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.95238f));
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Save_Changed, 3, 0);
		this.TableLayoutPanel1.Controls.Add(this.Save_All, 2, 0);
		this.TableLayoutPanel1.Controls.Add(this.Save_Failed, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(128, 298);
		tableLayoutPanel.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(2);
		tableLayoutPanel2.Margin = margin;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(441, 30);
		tableLayoutPanel3.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.TableLayoutPanel1.TabStop = true;
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.Cancel_Button.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(8, 2);
		cancel_Button.Location = location;
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		margin = new System.Windows.Forms.Padding(2);
		cancel_Button2.Margin = margin;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button3 = this.Cancel_Button;
		size = new System.Drawing.Size(65, 26);
		cancel_Button3.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.Save_Changed.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Save_Changed.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Save_Changed.ForeColor = System.Drawing.Color.DarkOrange;
		this.Save_Changed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		System.Windows.Forms.Button save_Changed = this.Save_Changed;
		location = new System.Drawing.Point(329, 2);
		save_Changed.Location = location;
		System.Windows.Forms.Button save_Changed2 = this.Save_Changed;
		margin = new System.Windows.Forms.Padding(2);
		save_Changed2.Margin = margin;
		this.Save_Changed.Name = "Save_Changed";
		System.Windows.Forms.Button save_Changed3 = this.Save_Changed;
		size = new System.Drawing.Size(100, 26);
		save_Changed3.Size = size;
		this.Save_Changed.TabIndex = 0;
		this.Save_Changed.Text = "Сохранять только изменённые";
		this.Save_All.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Save_All.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Save_All.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		System.Windows.Forms.Button save_All = this.Save_All;
		location = new System.Drawing.Point(209, 2);
		save_All.Location = location;
		System.Windows.Forms.Button save_All2 = this.Save_All;
		margin = new System.Windows.Forms.Padding(2);
		save_All2.Margin = margin;
		this.Save_All.Name = "Save_All";
		System.Windows.Forms.Button save_All3 = this.Save_All;
		size = new System.Drawing.Size(100, 26);
		save_All3.Size = size;
		this.Save_All.TabIndex = 1;
		this.Save_All.Text = "Сохранить всё";
		this.Save_Failed.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Save_Failed.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Save_Failed.ForeColor = System.Drawing.Color.Red;
		this.Save_Failed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		System.Windows.Forms.Button save_Failed = this.Save_Failed;
		location = new System.Drawing.Point(91, 2);
		save_Failed.Location = location;
		System.Windows.Forms.Button save_Failed2 = this.Save_Failed;
		margin = new System.Windows.Forms.Padding(2);
		save_Failed2.Margin = margin;
		this.Save_Failed.Name = "Save_Failed";
		System.Windows.Forms.Button save_Failed3 = this.Save_Failed;
		size = new System.Drawing.Size(100, 26);
		save_Failed3.Size = size;
		this.Save_Failed.TabIndex = 1;
		this.Save_Failed.Text = "Сохранять только несохранённые";
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Button2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		System.Windows.Forms.Button button = this.Button2;
		location = new System.Drawing.Point(8, 300);
		button.Location = location;
		System.Windows.Forms.Button button2 = this.Button2;
		margin = new System.Windows.Forms.Padding(2);
		button2.Margin = margin;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button3 = this.Button2;
		size = new System.Drawing.Size(55, 26);
		button3.Size = size;
		this.Button2.TabIndex = 1;
		this.Button2.Text = "Справка";
		this.GroupBox1.Controls.Add(this.LinkLabel2);
		this.GroupBox1.Controls.Add(this.ComboBox4);
		this.GroupBox1.Controls.Add(this.CheckBox10);
		this.GroupBox1.Controls.Add(this.CheckBox3);
		this.GroupBox1.Controls.Add(this.CheckBox2);
		this.GroupBox1.Controls.Add(this.CheckBox9);
		this.GroupBox1.Controls.Add(this.CheckBox1);
		this.GroupBox1.Controls.Add(this.ComboBox2);
		this.GroupBox1.Controls.Add(this.ComboBox3);
		this.GroupBox1.Controls.Add(this.ComboBox1);
		this.GroupBox1.Controls.Add(this.Label1);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(4, 12);
		groupBox.Location = location;
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(18, 21, 18, 21);
		groupBox2.Margin = margin;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox1;
		margin = new System.Windows.Forms.Padding(2);
		groupBox3.Padding = margin;
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox1;
		size = new System.Drawing.Size(240, 276);
		groupBox4.Size = size;
		this.GroupBox1.TabIndex = 1;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Настройка сохранения свойств";
		this.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox4.Enabled = false;
		this.ComboBox4.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox4.FormattingEnabled = true;
		this.ComboBox4.ItemHeight = 17;
		this.ComboBox4.Items.AddRange(new object[1] { "其它位置" });
		System.Windows.Forms.ComboBox comboBox = this.ComboBox4;
		location = new System.Drawing.Point(13, 98);
		comboBox.Location = location;
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox4;
		margin = new System.Windows.Forms.Padding(2);
		comboBox2.Margin = margin;
		this.ComboBox4.Name = "ComboBox4";
		System.Windows.Forms.ComboBox comboBox3 = this.ComboBox4;
		size = new System.Drawing.Size(218, 25);
		comboBox3.Size = size;
		this.ComboBox4.TabIndex = 4;
		this.ComboBox4.Visible = false;
		System.Windows.Forms.CheckBox checkBox = this.CheckBox10;
		location = new System.Drawing.Point(13, 239);
		checkBox.Location = location;
		System.Windows.Forms.CheckBox checkBox2 = this.CheckBox10;
		margin = new System.Windows.Forms.Padding(2);
		checkBox2.Margin = margin;
		this.CheckBox10.Name = "CheckBox10";
		System.Windows.Forms.CheckBox checkBox3 = this.CheckBox10;
		size = new System.Drawing.Size(135, 21);
		checkBox3.Size = size;
		this.CheckBox10.TabIndex = 7;
		this.CheckBox10.Text = "Автосохранение после изменения свойств";
		this.CheckBox10.UseVisualStyleBackColor = true;
		this.CheckBox3.Checked = true;
		this.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox4 = this.CheckBox3;
		location = new System.Drawing.Point(13, 214);
		checkBox4.Location = location;
		System.Windows.Forms.CheckBox checkBox5 = this.CheckBox3;
		margin = new System.Windows.Forms.Padding(2);
		checkBox5.Margin = margin;
		this.CheckBox3.Name = "CheckBox3";
		System.Windows.Forms.CheckBox checkBox6 = this.CheckBox3;
		size = new System.Drawing.Size(111, 21);
		checkBox6.Size = size;
		this.CheckBox3.TabIndex = 7;
		this.CheckBox3.Text = "Обновлять единицы компонента";
		this.CheckBox3.UseVisualStyleBackColor = true;
		System.Windows.Forms.CheckBox checkBox7 = this.CheckBox2;
		location = new System.Drawing.Point(13, 189);
		checkBox7.Location = location;
		System.Windows.Forms.CheckBox checkBox8 = this.CheckBox2;
		margin = new System.Windows.Forms.Padding(2);
		checkBox8.Margin = margin;
		this.CheckBox2.Name = "CheckBox2";
		System.Windows.Forms.CheckBox checkBox9 = this.CheckBox2;
		size = new System.Drawing.Size(123, 21);
		checkBox9.Size = size;
		this.CheckBox2.TabIndex = 6;
		this.CheckBox2.Text = "Сохранять свойства с пустым значением";
		this.CheckBox2.UseVisualStyleBackColor = true;
		System.Windows.Forms.CheckBox checkBox10 = this.CheckBox9;
		location = new System.Drawing.Point(13, 74);
		checkBox10.Location = location;
		System.Windows.Forms.CheckBox checkBox11 = this.CheckBox9;
		margin = new System.Windows.Forms.Padding(2);
		checkBox11.Margin = margin;
		this.CheckBox9.Name = "CheckBox9";
		System.Windows.Forms.CheckBox checkBox12 = this.CheckBox9;
		size = new System.Drawing.Size(123, 21);
		checkBox12.Size = size;
		this.CheckBox9.TabIndex = 2;
		this.CheckBox9.Text = "и удалить из следующего расположения";
		this.CheckBox9.UseVisualStyleBackColor = true;
		System.Windows.Forms.CheckBox checkBox13 = this.CheckBox1;
		location = new System.Drawing.Point(13, 129);
		checkBox13.Location = location;
		System.Windows.Forms.CheckBox checkBox14 = this.CheckBox1;
		margin = new System.Windows.Forms.Padding(2);
		checkBox14.Margin = margin;
		this.CheckBox1.Name = "CheckBox1";
		System.Windows.Forms.CheckBox checkBox15 = this.CheckBox1;
		size = new System.Drawing.Size(183, 21);
		checkBox15.Size = size;
		this.CheckBox1.TabIndex = 4;
		this.CheckBox1.Text = "и удалить лишние свойства из следующего расположения";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.Enabled = false;
		this.ComboBox2.FormattingEnabled = true;
		this.ComboBox2.Items.AddRange(new object[4] { "自定义和所有配置", "所有配置", "当前配置", "Пользовательское" });
		System.Windows.Forms.ComboBox comboBox4 = this.ComboBox2;
		location = new System.Drawing.Point(13, 153);
		comboBox4.Location = location;
		System.Windows.Forms.ComboBox comboBox5 = this.ComboBox2;
		margin = new System.Windows.Forms.Padding(2);
		comboBox5.Margin = margin;
		this.ComboBox2.Name = "ComboBox2";
		System.Windows.Forms.ComboBox comboBox6 = this.ComboBox2;
		size = new System.Drawing.Size(218, 25);
		comboBox6.Size = size;
		this.ComboBox2.TabIndex = 5;
		this.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox3.Enabled = false;
		this.ComboBox3.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox3.FormattingEnabled = true;
		this.ComboBox3.ItemHeight = 17;
		this.ComboBox3.Items.AddRange(new object[2] { "其它位置", "Пользовательское" });
		System.Windows.Forms.ComboBox comboBox7 = this.ComboBox3;
		location = new System.Drawing.Point(13, 98);
		comboBox7.Location = location;
		System.Windows.Forms.ComboBox comboBox8 = this.ComboBox3;
		margin = new System.Windows.Forms.Padding(2);
		comboBox8.Margin = margin;
		this.ComboBox3.Name = "ComboBox3";
		System.Windows.Forms.ComboBox comboBox9 = this.ComboBox3;
		size = new System.Drawing.Size(218, 25);
		comboBox9.Size = size;
		this.ComboBox3.TabIndex = 3;
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox1.FormattingEnabled = true;
		this.ComboBox1.ItemHeight = 17;
		this.ComboBox1.Items.AddRange(new object[4] { "原位置（新建属性在自定义）", "原位置（新建属性在配置）", "Пользовательское", "当前配置" });
		System.Windows.Forms.ComboBox comboBox10 = this.ComboBox1;
		location = new System.Drawing.Point(13, 43);
		comboBox10.Location = location;
		System.Windows.Forms.ComboBox comboBox11 = this.ComboBox1;
		margin = new System.Windows.Forms.Padding(2);
		comboBox11.Margin = margin;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox12 = this.ComboBox1;
		size = new System.Drawing.Size(218, 25);
		comboBox12.Size = size;
		this.ComboBox1.TabIndex = 1;
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(10, 23);
		label.Location = location;
		System.Windows.Forms.Label label2 = this.Label1;
		margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label2.Margin = margin;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label3 = this.Label1;
		size = new System.Drawing.Size(56, 17);
		label3.Size = size;
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Сохранить в:";
		this.GroupBox2.BackColor = System.Drawing.SystemColors.Control;
		this.GroupBox2.Controls.Add(this.LinkLabel1);
		this.GroupBox2.Controls.Add(this.Label2);
		this.GroupBox2.Controls.Add(this.RadioButton2);
		this.GroupBox2.Controls.Add(this.RadioButton3);
		this.GroupBox2.Controls.Add(this.RadioButton1);
		this.GroupBox2.Controls.Add(this.CheckBox7);
		this.GroupBox2.Controls.Add(this.CheckBox4);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox2;
		location = new System.Drawing.Point(256, 12);
		groupBox5.Location = location;
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox2;
		margin = new System.Windows.Forms.Padding(2);
		groupBox6.Margin = margin;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox7 = this.GroupBox2;
		margin = new System.Windows.Forms.Padding(2);
		groupBox7.Padding = margin;
		System.Windows.Forms.GroupBox groupBox8 = this.GroupBox2;
		size = new System.Drawing.Size(313, 156);
		groupBox8.Size = size;
		this.GroupBox2.TabIndex = 2;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Настройка переименования";
		this.LinkLabel1.AutoSize = true;
		System.Windows.Forms.LinkLabel linkLabel = this.LinkLabel1;
		location = new System.Drawing.Point(24, 124);
		linkLabel.Location = location;
		this.LinkLabel1.Name = "LinkLabel1";
		System.Windows.Forms.LinkLabel linkLabel2 = this.LinkLabel1;
		size = new System.Drawing.Size(80, 17);
		linkLabel2.Size = size;
		this.LinkLabel1.TabIndex = 6;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "Нажмите, чтобы задать путь";
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label4 = this.Label2;
		location = new System.Drawing.Point(10, 78);
		label4.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label5 = this.Label2;
		size = new System.Drawing.Size(128, 17);
		label5.Size = size;
		this.Label2.TabIndex = 5;
		this.Label2.Text = "После переименования старые файлы переместить в";
		this.RadioButton2.AutoSize = true;
		this.RadioButton2.Checked = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton2;
		location = new System.Drawing.Point(136, 98);
		radioButton.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton2;
		size = new System.Drawing.Size(74, 21);
		radioButton2.Size = size;
		this.RadioButton2.TabIndex = 4;
		this.RadioButton2.TabStop = true;
		this.RadioButton2.Text = "Не обрабатывать";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.RadioButton3.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton3;
		location = new System.Drawing.Point(10, 126);
		radioButton3.Location = location;
		this.RadioButton3.Name = "RadioButton3";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton3;
		size = new System.Drawing.Size(14, 13);
		radioButton4.Size = size;
		this.RadioButton3.TabIndex = 4;
		this.RadioButton3.UseVisualStyleBackColor = true;
		this.RadioButton1.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton5 = this.RadioButton1;
		location = new System.Drawing.Point(10, 98);
		radioButton5.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton6 = this.RadioButton1;
		size = new System.Drawing.Size(62, 21);
		radioButton6.Size = size;
		this.RadioButton1.TabIndex = 4;
		this.RadioButton1.Text = "Корзина";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.CheckBox7.Checked = true;
		this.CheckBox7.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox16 = this.CheckBox7;
		location = new System.Drawing.Point(10, 48);
		checkBox16.Location = location;
		System.Windows.Forms.CheckBox checkBox17 = this.CheckBox7;
		margin = new System.Windows.Forms.Padding(2);
		checkBox17.Margin = margin;
		this.CheckBox7.Name = "CheckBox7";
		System.Windows.Forms.CheckBox checkBox18 = this.CheckBox7;
		size = new System.Drawing.Size(99, 21);
		checkBox18.Size = size;
		this.CheckBox7.TabIndex = 3;
		this.CheckBox7.Text = "Пропускать файлы только для чтения";
		this.CheckBox7.UseVisualStyleBackColor = true;
		System.Windows.Forms.CheckBox checkBox19 = this.CheckBox4;
		location = new System.Drawing.Point(10, 25);
		checkBox19.Location = location;
		System.Windows.Forms.CheckBox checkBox20 = this.CheckBox4;
		margin = new System.Windows.Forms.Padding(2);
		checkBox20.Margin = margin;
		this.CheckBox4.Name = "CheckBox4";
		System.Windows.Forms.CheckBox checkBox21 = this.CheckBox4;
		size = new System.Drawing.Size(159, 21);
		checkBox21.Size = size;
		this.CheckBox4.TabIndex = 1;
		this.CheckBox4.Text = "Перезаписывать файлы с тем же именем (осторожно)";
		this.CheckBox4.UseVisualStyleBackColor = true;
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		location = new System.Drawing.Point(10, 78);
		textBox.Location = location;
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		margin = new System.Windows.Forms.Padding(2);
		textBox2.Margin = margin;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox3 = this.TextBox1;
		size = new System.Drawing.Size(270, 23);
		textBox3.Size = size;
		this.TextBox1.TabIndex = 3;
		this.CheckBox8.Checked = true;
		this.CheckBox8.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox22 = this.CheckBox8;
		location = new System.Drawing.Point(175, 53);
		checkBox22.Location = location;
		System.Windows.Forms.CheckBox checkBox23 = this.CheckBox8;
		margin = new System.Windows.Forms.Padding(2);
		checkBox23.Margin = margin;
		this.CheckBox8.Name = "CheckBox8";
		System.Windows.Forms.CheckBox checkBox24 = this.CheckBox8;
		size = new System.Drawing.Size(99, 21);
		checkBox24.Size = size;
		this.CheckBox8.TabIndex = 2;
		this.CheckBox8.Text = "Включая подпапки";
		this.CheckBox8.UseVisualStyleBackColor = true;
		this.CheckBox6.Checked = true;
		this.CheckBox6.CheckState = System.Windows.Forms.CheckState.Checked;
		System.Windows.Forms.CheckBox checkBox25 = this.CheckBox6;
		location = new System.Drawing.Point(10, 25);
		checkBox25.Location = location;
		System.Windows.Forms.CheckBox checkBox26 = this.CheckBox6;
		margin = new System.Windows.Forms.Padding(2);
		checkBox26.Margin = margin;
		this.CheckBox6.Name = "CheckBox6";
		System.Windows.Forms.CheckBox checkBox27 = this.CheckBox6;
		size = new System.Drawing.Size(99, 21);
		checkBox27.Size = size;
		this.CheckBox6.TabIndex = 1;
		this.CheckBox6.Text = "Обновлять ссылки";
		this.CheckBox6.UseVisualStyleBackColor = true;
		this.GroupBox3.BackColor = System.Drawing.SystemColors.Control;
		this.GroupBox3.Controls.Add(this.Button1);
		this.GroupBox3.Controls.Add(this.TextBox1);
		this.GroupBox3.Controls.Add(this.CheckBox8);
		this.GroupBox3.Controls.Add(this.CheckBox6);
		this.GroupBox3.Controls.Add(this.Label3);
		System.Windows.Forms.GroupBox groupBox9 = this.GroupBox3;
		location = new System.Drawing.Point(256, 176);
		groupBox9.Location = location;
		System.Windows.Forms.GroupBox groupBox10 = this.GroupBox3;
		margin = new System.Windows.Forms.Padding(2);
		groupBox10.Margin = margin;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox11 = this.GroupBox3;
		margin = new System.Windows.Forms.Padding(2);
		groupBox11.Padding = margin;
		System.Windows.Forms.GroupBox groupBox12 = this.GroupBox3;
		size = new System.Drawing.Size(313, 111);
		groupBox12.Size = size;
		this.GroupBox3.TabIndex = 3;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Обновлять прочие ссылки";
		this.Button1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Button button4 = this.Button1;
		location = new System.Drawing.Point(281, 77);
		button4.Location = location;
		System.Windows.Forms.Button button5 = this.Button1;
		margin = new System.Windows.Forms.Padding(2);
		button5.Margin = margin;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button6 = this.Button1;
		size = new System.Drawing.Size(27, 25);
		button6.Size = size;
		this.Button1.TabIndex = 4;
		this.Button1.Text = "...";
		this.Button1.UseVisualStyleBackColor = true;
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label6 = this.Label3;
		location = new System.Drawing.Point(7, 54);
		label6.Location = location;
		System.Windows.Forms.Label label7 = this.Label3;
		margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label7.Margin = margin;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label8 = this.Label3;
		size = new System.Drawing.Size(104, 17);
		label8.Size = size;
		this.Label3.TabIndex = 0;
		this.Label3.Text = "Папки для обновления:";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.LinkLabel2.AutoSize = true;
		System.Windows.Forms.LinkLabel linkLabel3 = this.LinkLabel2;
		location = new System.Drawing.Point(120, 216);
		linkLabel3.Location = location;
		this.LinkLabel2.Name = "LinkLabel2";
		System.Windows.Forms.LinkLabel linkLabel4 = this.LinkLabel2;
		size = new System.Drawing.Size(44, 17);
		linkLabel4.Size = size;
		this.LinkLabel2.TabIndex = 7;
		this.LinkLabel2.TabStop = true;
		this.LinkLabel2.Text = "Перейти к настройке";
		this.AcceptButton = this.Save_All;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(575, 333);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox3);
		this.Controls.Add(this.Button2);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Cursor = System.Windows.Forms.Cursors.Default;
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.HelpButton = true;
		margin = new System.Windows.Forms.Padding(2);
		this.Margin = margin;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmSaveOption";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = " Параметры сохранения";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox3.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void Save_Click(object sender, EventArgs e)
	{
		MyProject.Forms.Frmmain.DGV1.EndEdit();
		code.StartSwitch(status: true);
		Savecfg();
		try
		{
			code.propsaveplace = ComboBox1.SelectedIndex;
			code.DelOtherProp_place = ComboBox2.SelectedIndex;
			code.DelOtherProp = CheckBox1.Checked;
			if (ComboBox3.Visible & !ComboBox4.Visible)
			{
				code.DelCurProp_OtherPosition_place = ComboBox3.SelectedIndex;
			}
			else if (!ComboBox3.Visible & ComboBox4.Visible)
			{
				code.DelCurProp_OtherPosition_place = ComboBox4.SelectedIndex;
			}
			code.DelCurProp_OtherPosition = CheckBox9.Checked;
			code.keepnullvalue = CheckBox2.Checked;
			code.CanSetUnit = CheckBox3.Checked;
			code.overwrite = CheckBox4.Checked;
			code.Updatereferencebool = CheckBox6.Checked;
			code.SkipReadOnly = CheckBox7.Checked;
			code.UpdatereferenceIncludesubfolders = CheckBox8.Checked;
			code.SaveAfterModify = CheckBox10.Checked;
			code.targetpath = LinkLabel1.Text;
			if (RadioButton1.Checked)
			{
				code.oldfile_moveto = 1;
			}
			else if (RadioButton2.Checked)
			{
				code.oldfile_moveto = 0;
			}
			else if (RadioButton3.Checked)
			{
				code.oldfile_moveto = 2;
				if (!Directory.Exists(code.targetpath))
				{
					MessageBox.Show(this, "Сначала укажите путь перемещения старых файлов после переименования", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
			code.Updatereferencefolder = TextBox1.Text;
			if (Operators.CompareString(Strings.Right(code.Updatereferencefolder, 1), "\\", TextCompare: false) != 0)
			{
				code.Updatereferencefolder += "\\";
			}
			code.Updatereferencefolder = code.SplitStr(code.Updatereferencefolder);
			if (Operators.CompareString(((Button)sender).Name, Save_Changed.Name, TextCompare: false) == 0)
			{
				code.SaveOptions = 1;
			}
			else if (Operators.CompareString(((Button)sender).Name, Save_Failed.Name, TextCompare: false) == 0)
			{
				code.SaveOptions = 2;
			}
			else
			{
				code.SaveOptions = 0;
			}
			Close();
			if (code.CanSetUnit)
			{
				code.SetSWUnit();
			}
			MyProject.Forms.Frmmain.SaveToSW();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void FrmSaveOption_Load(object sender, EventArgs e)
	{
		if (MyProject.Forms.Frmmain.Rowlist_Savefailed.Count > 0)
		{
			Save_Failed.Visible = true;
		}
		else
		{
			Save_Failed.Visible = false;
		}
		try
		{
			Loadcfg();
			if (ComboBox1.SelectedIndex < 0)
			{
				ComboBox1.SelectedIndex = 0;
			}
			if (ComboBox2.SelectedIndex < 0)
			{
				ComboBox2.SelectedIndex = 0;
			}
			if (ComboBox3.SelectedIndex < 0)
			{
				ComboBox3.SelectedIndex = 0;
			}
			if (ComboBox4.SelectedIndex < 0)
			{
				ComboBox4.SelectedIndex = 0;
			}
			TextBox1.Enabled = CheckBox6.Checked;
			Button1.Enabled = CheckBox6.Checked;
			CheckBox8.Enabled = CheckBox6.Checked;
			TextBox1.Text = Path.GetDirectoryName(Conversions.ToString(MyProject.Forms.Frmmain.DGV1.Tag));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			ComboBox2.Enabled = true;
		}
		else
		{
			ComboBox2.Enabled = false;
		}
	}

	private void TextBox1_MouseDoubleClick(object sender, EventArgs e)
	{
		try
		{
			TextBox1.Text = Path.GetDirectoryName(Conversions.ToString(MyProject.Forms.Frmmain.DGV1.Tag));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			MessageBox.Show(this, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			TextBox1.Text = fileBorser.DirectoryPath;
		}
	}

	private void CheckBox6_CheckedChanged_1(object sender, EventArgs e)
	{
		TextBox1.Enabled = CheckBox6.Checked;
		Button1.Enabled = CheckBox6.Checked;
		CheckBox8.Enabled = CheckBox6.Checked;
	}

	private void TextBox1_MouseEnter(object sender, EventArgs e)
	{
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip(TextBox1, "Двойной щелчок — ввести папку текущей сборки");
	}

	private void ComboBox1_TextChanged(object sender, EventArgs e)
	{
		ComboBox3.Enabled = CheckBox9.Checked;
		ComboBox4.Enabled = CheckBox9.Checked;
		if (ComboBox1.Items.IndexOf(ComboBox1.Text) == 3)
		{
			ComboBox3.Visible = true;
			ComboBox4.Visible = false;
		}
		else
		{
			ComboBox3.Visible = false;
			ComboBox4.Visible = true;
		}
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			LinkLabel1.Text = fileBorser.DirectoryPath;
		}
	}

	private void LinkLabel1_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(LinkLabel1.Text, "", TextCompare: false) == 0 || !Directory.Exists(LinkLabel1.Text))
		{
			LinkLabel1.Text = "Нажмите, чтобы задать путь";
		}
		ToolTip toolTip = new ToolTip();
		toolTip.SetToolTip(LinkLabel1, LinkLabel1.Text);
	}

	private void FrmSaveOption_HelpButtonClicked(object sender, CancelEventArgs e)
	{
		try
		{
			if (File.Exists(code.helpfile))
			{
				Help.ShowHelp(this, code.helpfile, "/基本操作/保存数据到SolidWorks.htm");
			}
			else
			{
				MessageBox.Show("Файл help.chm не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

	private void Button2_Click(object sender, EventArgs e)
	{
		try
		{
			if (File.Exists(code.helpfile))
			{
				Help.ShowHelp(this, code.helpfile, "/基本操作/保存数据到SolidWorks.htm");
			}
			else
			{
				MessageBox.Show("Файл help.chm не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

	private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		MyProject.Forms.FrmSWUnit.ShowDialog();
	}

	private void Savecfg()
	{
		CConfigMng.Config.savetoswcfg.Clear();
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
				CConfigMng.Config.savetoswcfg.Add(control.Name + "\n" + Conversions.ToString(((CheckBox)control).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.savetoswcfg.Add(control.Name + "\n" + ((TextBox)control).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.savetoswcfg.Add(control.Name + "\n" + Conversions.ToString(((ComboBox)control).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.savetoswcfg.Add(control.Name + "\n" + Conversions.ToString(((RadioButton)control).Checked));
			}
			else if (control is LinkLabel && Directory.Exists(LinkLabel1.Text))
			{
				CConfigMng.Config.savetoswcfg.Add(control.Name + "\n" + ((LinkLabel)control).Text);
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
					case 599:
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
							case 6:
								goto IL_0085;
							case 7:
								goto IL_0097;
							case 9:
								goto IL_00b3;
							case 10:
								goto IL_00c6;
							case 12:
								goto IL_00e3;
							case 13:
								goto IL_00f6;
							case 15:
								goto IL_0116;
							case 16:
								goto IL_0129;
							case 18:
								goto IL_0143;
							case 19:
								goto IL_0156;
							case 8:
							case 11:
							case 14:
							case 17:
							case 20:
							case 21:
							case 22:
								goto IL_016b;
							case 23:
								goto IL_0180;
							case 24:
								goto IL_0190;
							case 25:
							case 26:
								goto IL_019d;
							default:
								goto end_IL_0001;
							case 27:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_00f6:
						num2 = 13;
						((ComboBox)control).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						goto IL_016b;
						IL_0116:
						num2 = 15;
						if (control is RadioButton)
						{
							goto IL_0129;
						}
						goto IL_0143;
						IL_00e3:
						num2 = 12;
						if (control is ComboBox)
						{
							goto IL_00f6;
						}
						goto IL_0116;
						IL_0129:
						num2 = 16;
						((RadioButton)control).Checked = code.Cbool1(array[1]);
						goto IL_016b;
						IL_000a:
						num2 = 2;
						enumerator = parent.Controls.GetEnumerator();
						goto IL_01a2;
						IL_01a2:
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
						IL_0143:
						num2 = 18;
						if (control is LinkLabel)
						{
							goto IL_0156;
						}
						goto IL_016b;
						IL_016b:
						num2 = 22;
						num5++;
						goto IL_0174;
						IL_0156:
						num2 = 19;
						((LinkLabel)control).Text = array[1];
						goto IL_016b;
						IL_002a:
						num2 = 3;
						num6 = CConfigMng.Config.savetoswcfg.Count - 1;
						num5 = 0;
						goto IL_0174;
						IL_0174:
						num7 = num5;
						num8 = num6;
						if (num7 <= num8)
						{
							goto IL_0047;
						}
						goto IL_0180;
						IL_0180:
						num2 = 23;
						if (control.HasChildren)
						{
							goto IL_0190;
						}
						goto IL_019d;
						IL_0190:
						num2 = 24;
						FindctlToLoad(control);
						goto IL_019d;
						IL_019d:
						num2 = 26;
						goto IL_01a2;
						IL_0047:
						num2 = 4;
						array = Strings.Split(CConfigMng.Config.savetoswcfg[num5], "\n");
						goto IL_0067;
						IL_0067:
						num2 = 5;
						if (Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
						{
							goto IL_0085;
						}
						goto IL_016b;
						IL_0085:
						num2 = 6;
						if (control is CheckBox)
						{
							goto IL_0097;
						}
						goto IL_00b3;
						IL_0097:
						num2 = 7;
						((CheckBox)control).Checked = code.Cbool1(array[1]);
						goto IL_016b;
						IL_00b3:
						num2 = 9;
						if (control is TextBox)
						{
							goto IL_00c6;
						}
						goto IL_00e3;
						IL_00c6:
						num2 = 10;
						((TextBox)control).Text = array[1].ToString();
						goto IL_016b;
						end_IL_0001:
						break;
					}
				}
			}
			catch (Exception obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 599;
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
}
