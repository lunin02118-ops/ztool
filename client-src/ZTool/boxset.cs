using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser1;

namespace ZTool;

[DesignerGenerated]
public class boxset : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("pathname")]
	private TextBox _pathname;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("tooltip")]
	private TextBox _tooltip;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("title")]
	private TextBox _title;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	private box m_section;

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

	internal virtual TextBox pathname
	{
		[DebuggerNonUserCode]
		get
		{
			return _pathname;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_pathname = value;
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

	internal virtual TextBox tooltip
	{
		[DebuggerNonUserCode]
		get
		{
			return _tooltip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_tooltip = value;
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

	internal virtual TextBox title
	{
		[DebuggerNonUserCode]
		get
		{
			return _title;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_title = value;
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
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.pathname = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.tooltip = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.Label4 = new System.Windows.Forms.Label();
		this.title = new System.Windows.Forms.TextBox();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.TableLayoutPanel1.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.91304f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.08696f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 0, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(123, 172);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(184, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(103, 3);
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
		location = new System.Drawing.Point(11, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(67, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(8, 72);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(44, 17);
		label2.Size = size;
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Путь:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.pathname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.TextBox textBox = this.pathname;
		location = new System.Drawing.Point(56, 69);
		textBox.Location = location;
		this.pathname.Name = "pathname";
		System.Windows.Forms.TextBox textBox2 = this.pathname;
		size = new System.Drawing.Size(243, 23);
		textBox2.Size = size;
		this.pathname.TabIndex = 2;
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(8, 103);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(44, 17);
		label4.Size = size;
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Подсказка:";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.tooltip.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.TextBox textBox3 = this.tooltip;
		location = new System.Drawing.Point(56, 100);
		textBox3.Location = location;
		this.tooltip.Name = "tooltip";
		System.Windows.Forms.TextBox textBox4 = this.tooltip;
		size = new System.Drawing.Size(243, 23);
		textBox4.Size = size;
		this.tooltip.TabIndex = 2;
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label3;
		location = new System.Drawing.Point(8, 136);
		label5.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label6 = this.Label3;
		size = new System.Drawing.Size(44, 17);
		label6.Size = size;
		this.Label3.TabIndex = 1;
		this.Label3.Text = "Метка:";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(16, 8);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(42, 27);
		button2.Size = size;
		this.Button1.TabIndex = 3;
		this.Button1.Text = "Добавить";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button3.AutoSize = true;
		System.Windows.Forms.Button button3 = this.Button3;
		location = new System.Drawing.Point(120, 5);
		button3.Location = location;
		this.Button3.Name = "Button3";
		System.Windows.Forms.Button button4 = this.Button3;
		size = new System.Drawing.Size(66, 27);
		button4.Size = size;
		this.Button3.TabIndex = 3;
		this.Button3.Text = "Добавить папку";
		this.Button3.UseVisualStyleBackColor = true;
		this.Label4.AutoSize = true;
		System.Windows.Forms.Label label7 = this.Label4;
		location = new System.Drawing.Point(8, 43);
		label7.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label8 = this.Label4;
		size = new System.Drawing.Size(44, 17);
		label8.Size = size;
		this.Label4.TabIndex = 1;
		this.Label4.Text = "Название:";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.title.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.TextBox textBox5 = this.title;
		location = new System.Drawing.Point(56, 40);
		textBox5.Location = location;
		this.title.Name = "title";
		System.Windows.Forms.TextBox textBox6 = this.title;
		size = new System.Drawing.Size(243, 23);
		textBox6.Size = size;
		this.title.TabIndex = 2;
		this.ComboBox1.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox = this.ComboBox1;
		location = new System.Drawing.Point(56, 132);
		comboBox.Location = location;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox1;
		size = new System.Drawing.Size(243, 25);
		comboBox2.Size = size;
		this.ComboBox1.TabIndex = 4;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(311, 209);
		this.ClientSize = size;
		this.Controls.Add(this.ComboBox1);
		this.Controls.Add(this.Button3);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.tooltip);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.title);
		this.Controls.Add(this.Label4);
		this.Controls.Add(this.pathname);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "boxset";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Изменённые элементы";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public boxset(box section)
	{
		base.Load += customsettings_Load;
		__ENCAddToList(this);
		m_section = new box();
		m_section = section;
		InitializeComponent();
		code.SetProcessDPIAware();
	}

	private void customsettings_Load(object sender, EventArgs e)
	{
		pathname.Text = "";
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "所有文件（*.*）|*.*";
		if (openFileDialog.ShowDialog() != DialogResult.Cancel)
		{
			string fileName = openFileDialog.FileName;
			if (File.Exists(fileName))
			{
				pathname.Text = fileName;
			}
		}
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			FileBorser fileBorser = new FileBorser();
			if (fileBorser.ShowDialog(this) == DialogResult.OK)
			{
				text = fileBorser.DirectoryPath;
				if (!text.EndsWith("\\"))
				{
					text += "\\";
				}
				if (Directory.Exists(text))
				{
					title.Text = text;
				}
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
}
