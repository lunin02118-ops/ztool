using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZTool_rsa;

namespace ZTool;

[DesignerGenerated]
public class FrmRg : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("Licence1")]
	private TextBox _Licence1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Licence2")]
	private TextBox _Licence2;

	[AccessedThroughProperty("Licence3")]
	private TextBox _Licence3;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("Licence4")]
	private TextBox _Licence4;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("Licence5")]
	private TextBox _Licence5;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("Introduction")]
	private TextBox _Introduction;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("barCodeImg")]
	private PictureBox _barCodeImg;

	[AccessedThroughProperty("BackgroundWorker1")]
	private BackgroundWorker _BackgroundWorker1;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("password")]
	private TextBox _password;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	private TCPClient TCPClient;

	private double dpixRatio;

	private byte[] desKey;

	private byte[] desSIV;

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

	internal virtual TextBox Licence1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Licence1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			KeyEventHandler value2 = Licence1_KeyDown;
			if (_Licence1 != null)
			{
				_Licence1.KeyDown -= value2;
			}
			_Licence1 = value;
			if (_Licence1 != null)
			{
				_Licence1.KeyDown += value2;
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

	internal virtual TextBox Licence2
	{
		[DebuggerNonUserCode]
		get
		{
			return _Licence2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			KeyEventHandler value2 = Licence1_KeyDown;
			if (_Licence2 != null)
			{
				_Licence2.KeyDown -= value2;
			}
			_Licence2 = value;
			if (_Licence2 != null)
			{
				_Licence2.KeyDown += value2;
			}
		}
	}

	internal virtual TextBox Licence3
	{
		[DebuggerNonUserCode]
		get
		{
			return _Licence3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			KeyEventHandler value2 = Licence1_KeyDown;
			if (_Licence3 != null)
			{
				_Licence3.KeyDown -= value2;
			}
			_Licence3 = value;
			if (_Licence3 != null)
			{
				_Licence3.KeyDown += value2;
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

	internal virtual TextBox Licence4
	{
		[DebuggerNonUserCode]
		get
		{
			return _Licence4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			KeyEventHandler value2 = Licence1_KeyDown;
			if (_Licence4 != null)
			{
				_Licence4.KeyDown -= value2;
			}
			_Licence4 = value;
			if (_Licence4 != null)
			{
				_Licence4.KeyDown += value2;
			}
		}
	}

	internal virtual Label Label5
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

	internal virtual TextBox Licence5
	{
		[DebuggerNonUserCode]
		get
		{
			return _Licence5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			KeyEventHandler value2 = Licence1_KeyDown;
			if (_Licence5 != null)
			{
				_Licence5.KeyDown -= value2;
			}
			_Licence5 = value;
			if (_Licence5 != null)
			{
				_Licence5.KeyDown += value2;
			}
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

	private TextBox Introduction
	{
		[DebuggerNonUserCode]
		get
		{
			return _Introduction;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Introduction = value;
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

	internal virtual PictureBox barCodeImg
	{
		[DebuggerNonUserCode]
		get
		{
			return _barCodeImg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_barCodeImg = value;
		}
	}

	internal virtual BackgroundWorker BackgroundWorker1
	{
		[DebuggerNonUserCode]
		get
		{
			return _BackgroundWorker1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			RunWorkerCompletedEventHandler value2 = BackgroundWorker1_RunWorkerCompleted;
			DoWorkEventHandler value3 = BackgroundWorker1_DoWork;
			if (_BackgroundWorker1 != null)
			{
				_BackgroundWorker1.RunWorkerCompleted -= value2;
				_BackgroundWorker1.DoWork -= value3;
			}
			_BackgroundWorker1 = value;
			if (_BackgroundWorker1 != null)
			{
				_BackgroundWorker1.RunWorkerCompleted += value2;
				_BackgroundWorker1.DoWork += value3;
			}
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

	internal virtual TextBox password
	{
		[DebuggerNonUserCode]
		get
		{
			return _password;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = password_LostFocus;
			EventHandler value3 = password_Enter;
			if (_password != null)
			{
				_password.LostFocus -= value2;
				_password.Enter -= value3;
			}
			_password = value;
			if (_password != null)
			{
				_password.LostFocus += value2;
				_password.Enter += value3;
			}
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
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.Licence1 = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Licence2 = new System.Windows.Forms.TextBox();
		this.Licence3 = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.Licence4 = new System.Windows.Forms.TextBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.Licence5 = new System.Windows.Forms.TextBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.Introduction = new System.Windows.Forms.TextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.barCodeImg = new System.Windows.Forms.PictureBox();
		this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.Label7 = new System.Windows.Forms.Label();
		this.password = new System.Windows.Forms.TextBox();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel1.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.barCodeImg).BeginInit();
		this.SuspendLayout();
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 4;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.39474f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.86842f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.34211f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20f));
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 3, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button1, 2, 0);
		this.TableLayoutPanel1.Controls.Add(this.Button2, 0, 0);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(0, 323);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(477, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 9;
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(388, 3);
		cancel_Button.Location = location;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		size = new System.Drawing.Size(80, 27);
		cancel_Button2.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(281, 3);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(80, 27);
		button2.Size = size;
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Активация онлайн";
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button2.AutoSize = true;
		System.Windows.Forms.Button button3 = this.Button2;
		location = new System.Drawing.Point(8, 3);
		button3.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button4 = this.Button2;
		size = new System.Drawing.Size(80, 27);
		button4.Size = size;
		this.Button2.TabIndex = 0;
		this.Button2.TabStop = false;
		this.Button2.Text = "Перенести лицензию";
		System.Windows.Forms.TextBox licence = this.Licence1;
		location = new System.Drawing.Point(9, 234);
		licence.Location = location;
		this.Licence1.MaxLength = 8;
		this.Licence1.Name = "Licence1";
		System.Windows.Forms.TextBox licence2 = this.Licence1;
		size = new System.Drawing.Size(80, 23);
		licence2.Size = size;
		this.Licence1.TabIndex = 2;
		this.Licence1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label = this.Label2;
		location = new System.Drawing.Point(6, 214);
		label.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label2 = this.Label2;
		size = new System.Drawing.Size(56, 17);
		label2.Size = size;
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Регистрационный код:";
		this.Label3.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label3;
		location = new System.Drawing.Point(90, 237);
		label3.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label4 = this.Label3;
		size = new System.Drawing.Size(13, 17);
		label4.Size = size;
		this.Label3.TabIndex = 2;
		this.Label3.Text = "-";
		System.Windows.Forms.TextBox licence3 = this.Licence2;
		location = new System.Drawing.Point(104, 234);
		licence3.Location = location;
		this.Licence2.MaxLength = 5;
		this.Licence2.Name = "Licence2";
		System.Windows.Forms.TextBox licence4 = this.Licence2;
		size = new System.Drawing.Size(80, 23);
		licence4.Size = size;
		this.Licence2.TabIndex = 3;
		this.Licence2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		System.Windows.Forms.TextBox licence5 = this.Licence3;
		location = new System.Drawing.Point(199, 234);
		licence5.Location = location;
		this.Licence3.MaxLength = 5;
		this.Licence3.Name = "Licence3";
		System.Windows.Forms.TextBox licence6 = this.Licence3;
		size = new System.Drawing.Size(80, 23);
		licence6.Size = size;
		this.Licence3.TabIndex = 4;
		this.Licence3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.Label4.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label4;
		location = new System.Drawing.Point(185, 237);
		label5.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label6 = this.Label4;
		size = new System.Drawing.Size(13, 17);
		label6.Size = size;
		this.Label4.TabIndex = 2;
		this.Label4.Text = "-";
		System.Windows.Forms.TextBox licence7 = this.Licence4;
		location = new System.Drawing.Point(294, 234);
		licence7.Location = location;
		this.Licence4.MaxLength = 5;
		this.Licence4.Name = "Licence4";
		System.Windows.Forms.TextBox licence8 = this.Licence4;
		size = new System.Drawing.Size(80, 23);
		licence8.Size = size;
		this.Licence4.TabIndex = 5;
		this.Licence4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.Label5.AutoSize = true;
		System.Windows.Forms.Label label7 = this.Label5;
		location = new System.Drawing.Point(280, 237);
		label7.Location = location;
		this.Label5.Name = "Label5";
		System.Windows.Forms.Label label8 = this.Label5;
		size = new System.Drawing.Size(13, 17);
		label8.Size = size;
		this.Label5.TabIndex = 2;
		this.Label5.Text = "-";
		System.Windows.Forms.TextBox licence9 = this.Licence5;
		location = new System.Drawing.Point(389, 234);
		licence9.Location = location;
		this.Licence5.MaxLength = 9;
		this.Licence5.Name = "Licence5";
		System.Windows.Forms.TextBox licence10 = this.Licence5;
		size = new System.Drawing.Size(80, 23);
		licence10.Size = size;
		this.Licence5.TabIndex = 6;
		this.Licence5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.Label6.AutoSize = true;
		System.Windows.Forms.Label label9 = this.Label6;
		location = new System.Drawing.Point(375, 237);
		label9.Location = location;
		this.Label6.Name = "Label6";
		System.Windows.Forms.Label label10 = this.Label6;
		size = new System.Drawing.Size(13, 17);
		label10.Size = size;
		this.Label6.TabIndex = 2;
		this.Label6.Text = "-";
		this.Introduction.AutoCompleteCustomSource.AddRange(new string[2] { "dwa ", "daw d" });
		this.Introduction.BackColor = System.Drawing.SystemColors.Control;
		this.Introduction.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Introduction.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.TextBox introduction = this.Introduction;
		location = new System.Drawing.Point(12, 22);
		introduction.Location = location;
		this.Introduction.Multiline = true;
		this.Introduction.Name = "Introduction";
		this.Introduction.ReadOnly = true;
		this.Introduction.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		System.Windows.Forms.TextBox introduction2 = this.Introduction;
		size = new System.Drawing.Size(453, 177);
		introduction2.Size = size;
		this.Introduction.TabIndex = 0;
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.barCodeImg);
		this.GroupBox1.Controls.Add(this.Introduction);
		this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(0, 0);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		System.Windows.Forms.Padding padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
		groupBox2.Padding = padding;
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox1;
		size = new System.Drawing.Size(477, 205);
		groupBox3.Size = size;
		this.GroupBox1.TabIndex = 10;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Сведения о регистрации";
		System.Windows.Forms.Label label11 = this.Label1;
		location = new System.Drawing.Point(199, 35);
		label11.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label12 = this.Label1;
		size = new System.Drawing.Size(249, 55);
		label12.Size = size;
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Если компьютер без доступа в интернет, отсканируйте QR-код слева телефоном\r\nи отправьте данные автору для получения файла офлайн-лицензии.";
		this.Label1.Visible = false;
		this.barCodeImg.Dock = System.Windows.Forms.DockStyle.Left;
		System.Windows.Forms.PictureBox pictureBox = this.barCodeImg;
		location = new System.Drawing.Point(12, 22);
		pictureBox.Location = location;
		this.barCodeImg.Name = "barCodeImg";
		System.Windows.Forms.PictureBox pictureBox2 = this.barCodeImg;
		padding = new System.Windows.Forms.Padding(3);
		pictureBox2.Padding = padding;
		System.Windows.Forms.PictureBox pictureBox3 = this.barCodeImg;
		size = new System.Drawing.Size(177, 177);
		pictureBox3.Size = size;
		this.barCodeImg.TabIndex = 1;
		this.barCodeImg.TabStop = false;
		this.barCodeImg.Visible = false;
		this.Label7.AutoSize = true;
		System.Windows.Forms.Label label13 = this.Label7;
		location = new System.Drawing.Point(6, 268);
		label13.Location = location;
		this.Label7.Name = "Label7";
		System.Windows.Forms.Label label14 = this.Label7;
		size = new System.Drawing.Size(343, 17);
		label14.Size = size;
		this.Label7.TabIndex = 2;
		this.Label7.Text = "Пароль защиты лицензии (можно задать при активации; после переноса лицензии очищается автоматически):";
		this.password.ImeMode = System.Windows.Forms.ImeMode.Disable;
		System.Windows.Forms.TextBox textBox = this.password;
		location = new System.Drawing.Point(8, 288);
		textBox.Location = location;
		this.password.MaxLength = 20;
		this.password.Name = "password";
		System.Windows.Forms.TextBox textBox2 = this.password;
		size = new System.Drawing.Size(272, 23);
		textBox2.Size = size;
		this.password.TabIndex = 7;
		this.password.UseSystemPasswordChar = true;
		this.CheckBox1.AutoSize = true;
		this.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
		System.Windows.Forms.CheckBox checkBox = this.CheckBox1;
		location = new System.Drawing.Point(288, 289);
		checkBox.Location = location;
		this.CheckBox1.Name = "CheckBox1";
		System.Windows.Forms.CheckBox checkBox2 = this.CheckBox1;
		size = new System.Drawing.Size(57, 22);
		checkBox2.Size = size;
		this.CheckBox1.TabIndex = 8;
		this.CheckBox1.Text = "Показать";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.AcceptButton = this.Button1;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(477, 356);
		this.ClientSize = size;
		this.Controls.Add(this.CheckBox1);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.Label6);
		this.Controls.Add(this.Label5);
		this.Controls.Add(this.Label4);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.Label7);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Licence5);
		this.Controls.Add(this.Licence4);
		this.Controls.Add(this.Licence3);
		this.Controls.Add(this.Licence2);
		this.Controls.Add(this.password);
		this.Controls.Add(this.Licence1);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmRg";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.barCodeImg).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmRg()
	{
		base.FormClosed += FrmRg_FormClosed;
		base.Load += Reg_Load;
		__ENCAddToList(this);
		TCPClient = new TCPClient();
		dpixRatio = 1.0;
		desKey = new byte[8] { 55, 23, 13, 49, 72, 57, 52, 8 };
		desSIV = new byte[8] { 39, 34, 28, 33, 75, 77, 82, 2 };
		InitializeComponent();
		using Graphics graphics = Graphics.FromHwnd(Handle);
		dpixRatio = graphics.DpiX / 96f;
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		if (BackgroundWorker1.IsBusy)
		{
			return;
		}
		string text = "";
		text = createinfo(withusername: true);
		TCPClient.Sendtype sendtype = TCPClient.Sendtype.Apply_register;
		if ((Operators.CompareString(text, "", TextCompare: false) != 0 && sendtype != 0) ? true : false)
		{
			BackgroundWorker1.RunWorkerAsync();
			if (TCPClient.Connect())
			{
				TCPClient.sendstring(sendtype, text);
			}
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		if (BackgroundWorker1.IsBusy)
		{
			return;
		}
		string text = "";
		SR sR = new SR();
		string text2 = "";
		string use_date = "";
		if (!sR.IsReg1("来生缘。。。", ref text2, ref use_date))
		{
			string text3 = "";
			string use_date2 = "";
			if (sR.IsReg2("来生缘。。。", ref text3, ref use_date2))
			{
				goto IL_006b;
			}
		}
		if (0 == 0)
		{
			return;
		}
		goto IL_006b;
		IL_006b:
		TCPClient.Sendtype sendtype = TCPClient.Sendtype.Apply_Remove;
		text = createinfo(withusername: false, withrgtime: true);
		if ((Operators.CompareString(text, "", TextCompare: false) != 0 && sendtype != 0) ? true : false)
		{
			BackgroundWorker1.RunWorkerAsync();
			if (TCPClient.Connect())
			{
				TCPClient.sendstring(sendtype, text);
			}
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void FrmRg_FormClosed(object sender, FormClosedEventArgs e)
	{
		TCPClient.CloseClientSocket();
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void Reg_Load(object sender, EventArgs e)
	{
		try
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			if (Environment.Is64BitProcess)
			{
				Text = Application.ProductName + " " + Application.ProductVersion.ToString() + "（x64） 注册\u001e\u001c";
			}
			else
			{
				Text = Application.ProductName + " " + Application.ProductVersion.ToString() + "（x86） 注册\u001e\u001c";
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
		TextBoxWaterMark.SetWatermark(password, "请输入8-20位包含大小写字母和数字的密码");
		Introduction.Clear();
		try
		{
			SR sR = new SR();
			string text = "";
			string text2 = "";
			string use_date = "";
			text2 = sR.GetMNum("忘情水。。。");
			if (Operators.CompareString(text2, "", TextCompare: false) != 0)
			{
				if (sR.IsReg2("来生缘。。。", ref text, ref use_date))
				{
					Introduction.AppendText("Регистрационный код:" + text + "\r\n");
					Introduction.AppendText("Действует до: бессрочно\r\n");
				}
				else
				{
					RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", writable: true).CreateSubKey("ZTool");
					text = Conversions.ToString(registryKey.GetValue("sn"));
					registryKey.Close();
				}
				string[] array = Strings.Split(text, "-");
				if ((array.Length == 5 && array[0].Length == 8 && array[1].Length == 5 && array[2].Length == 5 && array[3].Length == 5 && array[4].Length == 9) ? true : false)
				{
					Licence1.Clear();
					Licence2.Clear();
					Licence3.Clear();
					Licence4.Clear();
					Licence5.Clear();
					Licence1.Text = array[0];
					Licence2.Text = array[1];
					Licence3.Text = array[2];
					Licence4.Text = array[3];
					Licence5.Text = array[4];
				}
				Introduction.AppendText("Код устройства:\r\n");
				Introduction.AppendText(text2);
			}
			else
			{
				Introduction.AppendText("Это устройство не соответствует условиям регистрации!");
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			logopathlist.WriteLog($"异常类型：{ex4.GetType().Name}\r\n异常消息：{ex4.Message}\r\n异常信息：{ex4.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	private void Licence1_KeyDown(object sender, KeyEventArgs e)
	{
		try
		{
			if ((e.KeyCode == Keys.V) & e.Control)
			{
				e.SuppressKeyPress = true;
				string expression = Clipboard.GetText();
				string[] array = Strings.Split(expression, "-");
				if ((array.Length == 5 && array[0].Length == 8 && array[1].Length == 5 && array[2].Length == 5 && array[3].Length == 5 && array[4].Length == 9) ? true : false)
				{
					Licence1.Clear();
					Licence2.Clear();
					Licence3.Clear();
					Licence4.Clear();
					Licence5.Clear();
					Licence1.Text = array[0];
					Licence2.Text = array[1];
					Licence3.Text = array[2];
					Licence4.Text = array[3];
					Licence5.Text = array[4];
				}
			}
			else
			{
				e.SuppressKeyPress = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public string createinfo(bool withusername = false, bool withrgtime = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string result;
		try
		{
			string text = Licence1.Text.Trim() + "-" + Licence2.Text.Trim() + "-" + Licence3.Text.Trim() + "-" + Licence4.Text.Trim() + "-" + Licence5.Text.Trim();
			if (Strings.Len(text) <= 4)
			{
				MessageBox.Show("Введите регистрационный код", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				result = "";
				goto IL_0279;
			}
			if ((Strings.Len(text) > 4) & (Strings.Len(text) != 36))
			{
				MessageBox.Show("Недопустимый код, обратитесь к автору для покупки кода", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				result = "";
				goto IL_0279;
			}
			string text2 = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(password.Tag, true, TextCompare: false), "", password.Text));
			if (text2.Length > 0 && !checkpassword(text2))
			{
				MessageBox.Show("Неверный формат пароля, введите 8-20 символов с заглавными и строчными буквами и цифрами", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				result = "";
				goto IL_0279;
			}
			string text3 = "";
			string text4 = "";
			SR sR = new SR();
			text = RSAHelper.EncryptString(text, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An");
			text2 = RSAHelper.EncryptString(text2, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An");
			stringBuilder.AppendLine(text);
			stringBuilder.AppendLine(sR.GetMNum("忘情水。。。"));
			stringBuilder.AppendLine(text2);
			if (withusername)
			{
				string value = RSAHelper.EncryptString(Environment.MachineName + "\\" + Environment.UserName, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An");
				stringBuilder.AppendLine(value);
			}
			if (withrgtime)
			{
				stringBuilder.AppendLine(sR.get_rgtime());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			result = "";
			ProjectData.ClearProjectError();
			goto IL_0279;
		}
		result = stringBuilder.ToString().Trim();
		goto IL_0279;
		IL_0279:
		return result;
	}

	public string Decryptstr(string inXMLFilePath)
	{
		string result = "";
		DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		using (FileStream stream = new FileStream(inXMLFilePath, FileMode.Open, FileAccess.Read))
		{
			using CryptoStream stream2 = new CryptoStream(stream, dESCryptoServiceProvider.CreateDecryptor(desKey, desSIV), CryptoStreamMode.Read);
			using TextReader textReader = new StreamReader(stream2);
			result = textReader.ReadToEnd();
		}
		return result;
	}

	private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		while (TCPClient.isok)
		{
			Button1.Enabled = false;
			Button2.Enabled = false;
			Cursor = Cursors.WaitCursor;
		}
	}

	private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		Button1.Enabled = true;
		Button2.Enabled = true;
		Cursor = Cursors.Default;
	}

	public bool checkpassword(string password)
	{
		if (password.Length > 0)
		{
			Regex regex = new Regex("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,20}$");
			if (regex.IsMatch(password))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			password.UseSystemPasswordChar = false;
		}
		else
		{
			password.UseSystemPasswordChar = true;
		}
		TextBoxWaterMark.SetWatermark(password, "请输入8-20位包含大小写字母和数字的密码");
	}

	private void password_Enter(object sender, EventArgs e)
	{
		TextBoxWaterMark.ClearWatermark(password);
	}

	private void password_LostFocus(object sender, EventArgs e)
	{
		TextBoxWaterMark.SetWatermark(password, "请输入8-20位包含大小写字母和数字的密码");
	}
}
