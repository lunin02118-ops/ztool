using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmRverify : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("Test")]
	private Button _Test;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("TableLayoutPanel3")]
	private TableLayoutPanel _TableLayoutPanel3;

	[AccessedThroughProperty("TextBox4")]
	private TextBox _TextBox4;

	[AccessedThroughProperty("TextBox3")]
	private TextBox _TextBox3;

	[AccessedThroughProperty("TextBox2")]
	private TextBox _TextBox2;

	[AccessedThroughProperty("TextBox5")]
	private TextBox _TextBox5;

	[AccessedThroughProperty("TextBox6")]
	private TextBox _TextBox6;

	[AccessedThroughProperty("TextBox7")]
	private TextBox _TextBox7;

	[AccessedThroughProperty("TextBox8")]
	private TextBox _TextBox8;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("TextBox9")]
	private TextBox _TextBox9;

	[AccessedThroughProperty("TextBox10")]
	private TextBox _TextBox10;

	[AccessedThroughProperty("TextBox11")]
	private TextBox _TextBox11;

	[AccessedThroughProperty("TextBox12")]
	private TextBox _TextBox12;

	[AccessedThroughProperty("TableLayoutPanel4")]
	private TableLayoutPanel _TableLayoutPanel4;

	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	private string str;

	internal virtual Button Test
	{
		[DebuggerNonUserCode]
		get
		{
			return _Test;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Test_Click;
			if (_Test != null)
			{
				_Test.Click -= value2;
			}
			_Test = value;
			if (_Test != null)
			{
				_Test.Click += value2;
			}
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

	internal virtual TableLayoutPanel TableLayoutPanel3
	{
		[DebuggerNonUserCode]
		get
		{
			return _TableLayoutPanel3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TableLayoutPanel3 = value;
		}
	}

	internal virtual TextBox TextBox4
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox4 = value;
		}
	}

	internal virtual TextBox TextBox3
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox3 = value;
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

	internal virtual TextBox TextBox5
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox5 = value;
		}
	}

	internal virtual TextBox TextBox6
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox6 = value;
		}
	}

	internal virtual TextBox TextBox7
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox7 = value;
		}
	}

	internal virtual TextBox TextBox8
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox8 = value;
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
			_TextBox1 = value;
		}
	}

	internal virtual TextBox TextBox9
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox9 = value;
		}
	}

	internal virtual TextBox TextBox10
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = TextBox10_MouseLeave;
			EventHandler value3 = TextBox10_MouseHover;
			MouseEventHandler value4 = TextBox10_MouseDown;
			if (_TextBox10 != null)
			{
				_TextBox10.MouseLeave -= value2;
				_TextBox10.MouseHover -= value3;
				_TextBox10.MouseDown -= value4;
			}
			_TextBox10 = value;
			if (_TextBox10 != null)
			{
				_TextBox10.MouseLeave += value2;
				_TextBox10.MouseHover += value3;
				_TextBox10.MouseDown += value4;
			}
		}
	}

	internal virtual TextBox TextBox11
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = TextBox10_MouseLeave;
			EventHandler value3 = TextBox10_MouseHover;
			MouseEventHandler value4 = TextBox10_MouseDown;
			if (_TextBox11 != null)
			{
				_TextBox11.MouseLeave -= value2;
				_TextBox11.MouseHover -= value3;
				_TextBox11.MouseDown -= value4;
			}
			_TextBox11 = value;
			if (_TextBox11 != null)
			{
				_TextBox11.MouseLeave += value2;
				_TextBox11.MouseHover += value3;
				_TextBox11.MouseDown += value4;
			}
		}
	}

	internal virtual TextBox TextBox12
	{
		[DebuggerNonUserCode]
		get
		{
			return _TextBox12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TextBox12 = value;
		}
	}

	internal virtual TableLayoutPanel TableLayoutPanel4
	{
		[DebuggerNonUserCode]
		get
		{
			return _TableLayoutPanel4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TableLayoutPanel4 = value;
		}
	}

	internal virtual PictureBox PictureBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_PictureBox1 = value;
		}
	}

	[DebuggerNonUserCode]
	public FrmRverify()
	{
		base.FormClosed += FrmRverify_FormClosed;
		base.Load += FrmRverify_Load;
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
		this.Test = new System.Windows.Forms.Button();
		this.Label2 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Button2 = new System.Windows.Forms.Button();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
		this.TextBox3 = new System.Windows.Forms.TextBox();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.TextBox5 = new System.Windows.Forms.TextBox();
		this.TextBox4 = new System.Windows.Forms.TextBox();
		this.TextBox8 = new System.Windows.Forms.TextBox();
		this.TextBox6 = new System.Windows.Forms.TextBox();
		this.TextBox7 = new System.Windows.Forms.TextBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.TextBox9 = new System.Windows.Forms.TextBox();
		this.TextBox10 = new System.Windows.Forms.TextBox();
		this.TextBox11 = new System.Windows.Forms.TextBox();
		this.TextBox12 = new System.Windows.Forms.TextBox();
		this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.TableLayoutPanel1.SuspendLayout();
		this.TableLayoutPanel2.SuspendLayout();
		this.TableLayoutPanel3.SuspendLayout();
		this.TableLayoutPanel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		this.SuspendLayout();
		this.Test.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Test.Enabled = false;
		System.Windows.Forms.Button test = this.Test;
		System.Drawing.Point location = new System.Drawing.Point(3, 3);
		test.Location = location;
		this.Test.Name = "Test";
		System.Windows.Forms.Button test2 = this.Test;
		System.Drawing.Size size = new System.Drawing.Size(65, 27);
		test2.Size = size;
		this.Test.TabIndex = 3;
		this.Test.Text = "Проба";
		this.Test.UseVisualStyleBackColor = true;
		this.Test.Visible = false;
		this.Label2.BackColor = System.Drawing.SystemColors.Control;
		this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Label2.Font = new System.Drawing.Font("微软雅黑", 18f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 134);
		this.Label2.ForeColor = System.Drawing.Color.Red;
		System.Windows.Forms.Label label = this.Label2;
		location = new System.Drawing.Point(2, 0);
		label.Location = location;
		System.Windows.Forms.Label label2 = this.Label2;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		label2.Margin = margin;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label3 = this.Label2;
		size = new System.Drawing.Size(398, 88);
		label3.Size = size;
		this.Label2.TabIndex = 6;
		this.Label2.Text = "Действующая лицензия не обнаружена!";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(280, 3);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(65, 27);
		button2.Size = size;
		this.Button1.TabIndex = 3;
		this.Button1.Text = "Отмена";
		this.Button1.UseVisualStyleBackColor = true;
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 4;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.Button1, 3, 0);
		this.TableLayoutPanel1.Controls.Add(this.Test, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button2, 2, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		location = new System.Drawing.Point(34, 338);
		tableLayoutPanel.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		margin = new System.Windows.Forms.Padding(2);
		tableLayoutPanel2.Margin = margin;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel1;
		size = new System.Drawing.Size(357, 33);
		tableLayoutPanel3.Size = size;
		this.TableLayoutPanel1.TabIndex = 7;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.None;
		System.Windows.Forms.Button button3 = this.Button2;
		location = new System.Drawing.Point(192, 3);
		button3.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button4 = this.Button2;
		size = new System.Drawing.Size(65, 27);
		button4.Size = size;
		this.Button2.TabIndex = 3;
		this.Button2.Text = "Регистрация";
		this.Button2.UseVisualStyleBackColor = true;
		this.TableLayoutPanel2.ColumnCount = 1;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel2.Controls.Add(this.Label2, 0, 0);
		this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel4 = this.TableLayoutPanel2;
		location = new System.Drawing.Point(0, 0);
		tableLayoutPanel4.Location = location;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel5 = this.TableLayoutPanel2;
		size = new System.Drawing.Size(402, 88);
		tableLayoutPanel5.Size = size;
		this.TableLayoutPanel2.TabIndex = 8;
		this.TableLayoutPanel3.ColumnCount = 4;
		this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.96758f));
		this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.40399f));
		this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.46384f));
		this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.16459f));
		this.TableLayoutPanel3.Controls.Add(this.TextBox3, 3, 0);
		this.TableLayoutPanel3.Controls.Add(this.TextBox2, 1, 0);
		this.TableLayoutPanel3.Controls.Add(this.TextBox5, 0, 0);
		this.TableLayoutPanel3.Controls.Add(this.TextBox4, 3, 1);
		this.TableLayoutPanel3.Controls.Add(this.TextBox8, 2, 0);
		this.TableLayoutPanel3.Controls.Add(this.TextBox6, 0, 1);
		this.TableLayoutPanel3.Controls.Add(this.TextBox7, 2, 1);
		this.TableLayoutPanel3.Controls.Add(this.TextBox1, 1, 1);
		this.TableLayoutPanel3.Controls.Add(this.TextBox9, 0, 2);
		this.TableLayoutPanel3.Controls.Add(this.TextBox10, 1, 2);
		this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel6 = this.TableLayoutPanel3;
		location = new System.Drawing.Point(0, 88);
		tableLayoutPanel6.Location = location;
		this.TableLayoutPanel3.Name = "TableLayoutPanel3";
		this.TableLayoutPanel3.RowCount = 3;
		this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel7 = this.TableLayoutPanel3;
		size = new System.Drawing.Size(402, 72);
		tableLayoutPanel7.Size = size;
		this.TableLayoutPanel3.TabIndex = 9;
		this.TextBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.TextBox3.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox = this.TextBox3;
		location = new System.Drawing.Point(270, 4);
		textBox.Location = location;
		System.Windows.Forms.TextBox textBox2 = this.TextBox3;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox2.Margin = margin;
		this.TextBox3.Name = "TextBox3";
		this.TextBox3.ReadOnly = true;
		System.Windows.Forms.TextBox textBox3 = this.TextBox3;
		size = new System.Drawing.Size(124, 16);
		textBox3.Size = size;
		this.TextBox3.TabIndex = 12;
		this.TextBox3.Text = "823539419";
		this.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.TextBox2.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox4 = this.TextBox2;
		location = new System.Drawing.Point(58, 4);
		textBox4.Location = location;
		System.Windows.Forms.TextBox textBox5 = this.TextBox2;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox5.Margin = margin;
		this.TextBox2.Name = "TextBox2";
		this.TextBox2.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.TextBox2;
		size = new System.Drawing.Size(130, 16);
		textBox6.Size = size;
		this.TextBox2.TabIndex = 11;
		this.TextBox2.Text = "287926418";
		this.TextBox5.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.TextBox5.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox7 = this.TextBox5;
		location = new System.Drawing.Point(6, 4);
		textBox7.Location = location;
		System.Windows.Forms.TextBox textBox8 = this.TextBox5;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox8.Margin = margin;
		this.TextBox5.Name = "TextBox5";
		this.TextBox5.ReadOnly = true;
		System.Windows.Forms.TextBox textBox9 = this.TextBox5;
		size = new System.Drawing.Size(43, 16);
		textBox9.Size = size;
		this.TextBox5.TabIndex = 11;
		this.TextBox5.Text = "QQ:";
		this.TextBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.TextBox4.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox10 = this.TextBox4;
		location = new System.Drawing.Point(270, 28);
		textBox10.Location = location;
		System.Windows.Forms.TextBox textBox11 = this.TextBox4;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox11.Margin = margin;
		this.TextBox4.Name = "TextBox4";
		this.TextBox4.ReadOnly = true;
		System.Windows.Forms.TextBox textBox12 = this.TextBox4;
		size = new System.Drawing.Size(124, 16);
		textBox12.Size = size;
		this.TextBox4.TabIndex = 13;
		this.TextBox4.Text = "О программе";
		this.TextBox8.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.TextBox8.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox13 = this.TextBox8;
		location = new System.Drawing.Point(212, 4);
		textBox13.Location = location;
		System.Windows.Forms.TextBox textBox14 = this.TextBox8;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox14.Margin = margin;
		this.TextBox8.Name = "TextBox8";
		this.TextBox8.ReadOnly = true;
		System.Windows.Forms.TextBox textBox15 = this.TextBox8;
		size = new System.Drawing.Size(49, 16);
		textBox15.Size = size;
		this.TextBox8.TabIndex = 12;
		this.TextBox8.Text = "Группа QQ:";
		this.TextBox6.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.TextBox6.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox16 = this.TextBox6;
		location = new System.Drawing.Point(6, 28);
		textBox16.Location = location;
		System.Windows.Forms.TextBox textBox17 = this.TextBox6;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox17.Margin = margin;
		this.TextBox6.Name = "TextBox6";
		this.TextBox6.ReadOnly = true;
		System.Windows.Forms.TextBox textBox18 = this.TextBox6;
		size = new System.Drawing.Size(43, 16);
		textBox18.Size = size;
		this.TextBox6.TabIndex = 4;
		this.TextBox6.Text = "Email:";
		this.TextBox7.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.TextBox7.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox19 = this.TextBox7;
		location = new System.Drawing.Point(212, 28);
		textBox19.Location = location;
		System.Windows.Forms.TextBox textBox20 = this.TextBox7;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox20.Margin = margin;
		this.TextBox7.Name = "TextBox7";
		this.TextBox7.ReadOnly = true;
		System.Windows.Forms.TextBox textBox21 = this.TextBox7;
		size = new System.Drawing.Size(49, 16);
		textBox21.Size = size;
		this.TextBox7.TabIndex = 13;
		this.TextBox7.Text = "Разработчик:";
		this.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.TextBox1.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox22 = this.TextBox1;
		location = new System.Drawing.Point(58, 28);
		textBox22.Location = location;
		System.Windows.Forms.TextBox textBox23 = this.TextBox1;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox23.Margin = margin;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		System.Windows.Forms.TextBox textBox24 = this.TextBox1;
		size = new System.Drawing.Size(130, 16);
		textBox24.Size = size;
		this.TextBox1.TabIndex = 11;
		this.TextBox1.Text = "mail@z-tool.cn";
		this.TextBox9.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.TextBox9.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox25 = this.TextBox9;
		location = new System.Drawing.Point(6, 52);
		textBox25.Location = location;
		System.Windows.Forms.TextBox textBox26 = this.TextBox9;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox26.Margin = margin;
		this.TextBox9.Name = "TextBox9";
		this.TextBox9.ReadOnly = true;
		System.Windows.Forms.TextBox textBox27 = this.TextBox9;
		size = new System.Drawing.Size(43, 16);
		textBox27.Size = size;
		this.TextBox9.TabIndex = 4;
		this.TextBox9.Text = "Сайт:";
		this.TextBox10.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.TextBox10.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox10.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.TextBox textBox28 = this.TextBox10;
		location = new System.Drawing.Point(58, 52);
		textBox28.Location = location;
		System.Windows.Forms.TextBox textBox29 = this.TextBox10;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox29.Margin = margin;
		this.TextBox10.Name = "TextBox10";
		this.TextBox10.ReadOnly = true;
		System.Windows.Forms.TextBox textBox30 = this.TextBox10;
		size = new System.Drawing.Size(145, 16);
		textBox30.Size = size;
		this.TextBox10.TabIndex = 11;
		this.TextBox10.Text = "www.z-tool.cn";
		this.TextBox11.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox11.ForeColor = System.Drawing.Color.Blue;
		System.Windows.Forms.TextBox textBox31 = this.TextBox11;
		location = new System.Drawing.Point(58, 3);
		textBox31.Location = location;
		System.Windows.Forms.TextBox textBox32 = this.TextBox11;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox32.Margin = margin;
		this.TextBox11.Name = "TextBox11";
		this.TextBox11.ReadOnly = true;
		System.Windows.Forms.TextBox textBox33 = this.TextBox11;
		size = new System.Drawing.Size(334, 16);
		textBox33.Size = size;
		this.TextBox11.TabIndex = 11;
		this.TextBox11.Text = "https://item.taobao.com/item.htm?id=638150915723";
		this.TextBox12.BackColor = System.Drawing.SystemColors.Control;
		this.TextBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
		System.Windows.Forms.TextBox textBox34 = this.TextBox12;
		location = new System.Drawing.Point(6, 3);
		textBox34.Location = location;
		System.Windows.Forms.TextBox textBox35 = this.TextBox12;
		margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
		textBox35.Margin = margin;
		this.TextBox12.Name = "TextBox12";
		this.TextBox12.ReadOnly = true;
		System.Windows.Forms.TextBox textBox36 = this.TextBox12;
		size = new System.Drawing.Size(43, 16);
		textBox36.Size = size;
		this.TextBox12.TabIndex = 4;
		this.TextBox12.Text = "Taobao:";
		this.TableLayoutPanel4.ColumnCount = 2;
		this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.24419f));
		this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350f));
		this.TableLayoutPanel4.Controls.Add(this.TextBox12, 0, 0);
		this.TableLayoutPanel4.Controls.Add(this.TextBox11, 1, 0);
		this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel8 = this.TableLayoutPanel4;
		location = new System.Drawing.Point(0, 160);
		tableLayoutPanel8.Location = location;
		this.TableLayoutPanel4.Name = "TableLayoutPanel4";
		this.TableLayoutPanel4.RowCount = 1;
		this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel9 = this.TableLayoutPanel4;
		size = new System.Drawing.Size(402, 32);
		tableLayoutPanel9.Size = size;
		this.TableLayoutPanel4.TabIndex = 12;
		this.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox1.Image = ZTool.My.Resources.Resources.二维码;
		System.Windows.Forms.PictureBox pictureBox = this.PictureBox1;
		location = new System.Drawing.Point(8, 200);
		pictureBox.Location = location;
		this.PictureBox1.Name = "PictureBox1";
		System.Windows.Forms.PictureBox pictureBox2 = this.PictureBox1;
		size = new System.Drawing.Size(384, 128);
		pictureBox2.Size = size;
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox1.TabIndex = 13;
		this.PictureBox1.TabStop = false;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.Control;
		size = new System.Drawing.Size(402, 374);
		this.ClientSize = size;
		this.Controls.Add(this.PictureBox1);
		this.Controls.Add(this.TableLayoutPanel4);
		this.Controls.Add(this.TableLayoutPanel3);
		this.Controls.Add(this.TableLayoutPanel2);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmRverify";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel3.ResumeLayout(false);
		this.TableLayoutPanel3.PerformLayout();
		this.TableLayoutPanel4.ResumeLayout(false);
		this.TableLayoutPanel4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void FrmRverify_FormClosed(object sender, FormClosedEventArgs e)
	{
		Close();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		code.TMode = false;
		Environment.Exit(0);
	}

	private void FrmRverify_Load(object sender, EventArgs e)
	{
		try
		{
			if (Environment.Is64BitProcess)
			{
				Text = Application.ProductName.Insert(2, "\u001e\u001c") + " " + Application.ProductVersion.ToString() + "（x64）\u001e\u001c";
			}
			else
			{
				Text = Application.ProductName.Insert(2, "\u001e\u001c") + " " + Application.ProductVersion.ToString() + "（x86）\u001e\u001c";
			}
			TextBox10.Text = Resources.website;
			if (code.TMode)
			{
				Test.Enabled = false;
				Test.Visible = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
	}

	private void Test_Click(object sender, EventArgs e)
	{
		try
		{
			SR sR = new SR();
			if (!sR.Isme("冰雨。。。"))
			{
				Environment.Exit(0);
			}
			if (!code.TMode)
			{
				code.TMode = true;
				Close();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		code.startrg(this);
	}

	private void TextBox10_MouseDown(object sender, MouseEventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		textBox.Cursor = Cursors.Default;
		Process.Start(textBox.Text);
	}

	private void TextBox10_MouseHover(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		textBox.Cursor = Cursors.Hand;
	}

	private void TextBox10_MouseLeave(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		textBox.Cursor = Cursors.Default;
	}
}
