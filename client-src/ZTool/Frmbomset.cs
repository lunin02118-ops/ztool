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
using ZTool.CustomFileBorser1;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class Frmbomset : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("insertimagebool")]
	private CheckBox _insertimagebool;

	[AccessedThroughProperty("image_height")]
	private NumericUpDown _image_height;

	[AccessedThroughProperty("image_width")]
	private NumericUpDown _image_width;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("Label9")]
	private Label _Label9;

	[AccessedThroughProperty("Label8")]
	private Label _Label8;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("bompath")]
	private TextBox _bompath;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("CheckBox4")]
	private CheckBox _CheckBox4;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("lockratio")]
	private CheckBox _lockratio;

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

	internal virtual CheckBox insertimagebool
	{
		[DebuggerNonUserCode]
		get
		{
			return _insertimagebool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_insertimagebool = value;
		}
	}

	internal virtual NumericUpDown image_height
	{
		[DebuggerNonUserCode]
		get
		{
			return _image_height;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = image_height_ValueChanged;
			if (_image_height != null)
			{
				_image_height.ValueChanged -= value2;
			}
			_image_height = value;
			if (_image_height != null)
			{
				_image_height.ValueChanged += value2;
			}
		}
	}

	internal virtual NumericUpDown image_width
	{
		[DebuggerNonUserCode]
		get
		{
			return _image_width;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = image_width_ValueChanged;
			if (_image_width != null)
			{
				_image_width.ValueChanged -= value2;
			}
			_image_width = value;
			if (_image_width != null)
			{
				_image_width.ValueChanged += value2;
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
			_Label8 = value;
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

	internal virtual TextBox bompath
	{
		[DebuggerNonUserCode]
		get
		{
			return _bompath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_bompath = value;
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
			_CheckBox1 = value;
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

	internal virtual CheckBox lockratio
	{
		[DebuggerNonUserCode]
		get
		{
			return _lockratio;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_lockratio = value;
		}
	}

	[DebuggerNonUserCode]
	public Frmbomset()
	{
		base.Load += Frmbomset_Load;
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
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.insertimagebool = new System.Windows.Forms.CheckBox();
		this.image_height = new System.Windows.Forms.NumericUpDown();
		this.image_width = new System.Windows.Forms.NumericUpDown();
		this.Button2 = new System.Windows.Forms.Button();
		this.Label9 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.bompath = new System.Windows.Forms.TextBox();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.CheckBox4 = new System.Windows.Forms.CheckBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.lockratio = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.image_height).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.image_width).BeginInit();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(194, 227);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(163, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 13;
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
		this.insertimagebool.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox = this.insertimagebool;
		location = new System.Drawing.Point(10, 80);
		checkBox.Location = location;
		this.insertimagebool.Name = "insertimagebool";
		System.Windows.Forms.CheckBox checkBox2 = this.insertimagebool;
		size = new System.Drawing.Size(87, 21);
		checkBox2.Size = size;
		this.insertimagebool.TabIndex = 5;
		this.insertimagebool.Text = "Вставить эскиз";
		this.insertimagebool.UseVisualStyleBackColor = true;
		this.image_height.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.NumericUpDown numericUpDown = this.image_height;
		location = new System.Drawing.Point(194, 136);
		numericUpDown.Location = location;
		System.Windows.Forms.NumericUpDown numericUpDown2 = this.image_height;
		decimal maximum = new decimal(new int[4] { 256, 0, 0, 0 });
		numericUpDown2.Maximum = maximum;
		maximum = (this.image_height.Minimum = new decimal(new int[4] { 32, 0, 0, 0 }));
		this.image_height.Name = "image_height";
		System.Windows.Forms.NumericUpDown numericUpDown3 = this.image_height;
		size = new System.Drawing.Size(62, 23);
		numericUpDown3.Size = size;
		this.image_height.TabIndex = 7;
		maximum = (this.image_height.Value = new decimal(new int[4] { 48, 0, 0, 0 }));
		this.image_width.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.NumericUpDown numericUpDown4 = this.image_width;
		location = new System.Drawing.Point(61, 136);
		numericUpDown4.Location = location;
		maximum = (this.image_width.Maximum = new decimal(new int[4] { 256, 0, 0, 0 }));
		maximum = (this.image_width.Minimum = new decimal(new int[4] { 32, 0, 0, 0 }));
		this.image_width.Name = "image_width";
		System.Windows.Forms.NumericUpDown numericUpDown5 = this.image_width;
		size = new System.Drawing.Size(62, 23);
		numericUpDown5.Size = size;
		this.image_width.TabIndex = 6;
		maximum = (this.image_width.Value = new decimal(new int[4] { 64, 0, 0, 0 }));
		this.Button2.AutoSize = true;
		System.Windows.Forms.Button button = this.Button2;
		location = new System.Drawing.Point(312, 35);
		button.Location = location;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button2 = this.Button2;
		size = new System.Drawing.Size(42, 27);
		button2.Size = size;
		this.Button2.TabIndex = 3;
		this.Button2.Text = "Обзор";
		this.Button2.UseVisualStyleBackColor = true;
		this.Label9.AutoSize = true;
		System.Windows.Forms.Label label = this.Label9;
		location = new System.Drawing.Point(147, 138);
		label.Location = location;
		this.Label9.Name = "Label9";
		System.Windows.Forms.Label label2 = this.Label9;
		size = new System.Drawing.Size(44, 17);
		label2.Size = size;
		this.Label9.TabIndex = 7;
		this.Label9.Text = "Высота:";
		this.Label8.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label8;
		location = new System.Drawing.Point(10, 138);
		label3.Location = location;
		this.Label8.Name = "Label8";
		System.Windows.Forms.Label label4 = this.Label8;
		size = new System.Drawing.Size(44, 17);
		label4.Size = size;
		this.Label8.TabIndex = 8;
		this.Label8.Text = "Ширина:";
		this.Label7.AutoSize = true;
		System.Windows.Forms.Label label5 = this.Label7;
		location = new System.Drawing.Point(10, 108);
		label5.Location = location;
		this.Label7.Name = "Label7";
		System.Windows.Forms.Label label6 = this.Label7;
		size = new System.Drawing.Size(80, 17);
		label6.Size = size;
		this.Label7.TabIndex = 9;
		this.Label7.Text = "Размер эскиза:";
		this.Label6.AutoSize = true;
		System.Windows.Forms.Label label7 = this.Label6;
		location = new System.Drawing.Point(10, 13);
		label7.Location = location;
		this.Label6.Name = "Label6";
		System.Windows.Forms.Label label8 = this.Label6;
		size = new System.Drawing.Size(110, 17);
		label8.Size = size;
		this.Label6.TabIndex = 10;
		this.Label6.Text = "Папка шаблонов спецификации:";
		System.Windows.Forms.TextBox textBox = this.bompath;
		location = new System.Drawing.Point(10, 37);
		textBox.Location = location;
		this.bompath.Name = "bompath";
		System.Windows.Forms.TextBox textBox2 = this.bompath;
		size = new System.Drawing.Size(290, 23);
		textBox2.Size = size;
		this.bompath.TabIndex = 2;
		this.CheckBox1.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox3 = this.CheckBox1;
		location = new System.Drawing.Point(262, 12);
		checkBox3.Location = location;
		this.CheckBox1.Name = "CheckBox1";
		System.Windows.Forms.CheckBox checkBox4 = this.CheckBox1;
		size = new System.Drawing.Size(99, 21);
		checkBox4.Size = size;
		this.CheckBox1.TabIndex = 1;
		this.CheckBox1.Text = "Включая подпапки";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton1;
		location = new System.Drawing.Point(10, 174);
		radioButton.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton1;
		size = new System.Drawing.Size(86, 21);
		radioButton2.Size = size;
		this.RadioButton1.TabIndex = 8;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Выводить значения свойств";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.RadioButton2.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton2;
		location = new System.Drawing.Point(120, 174);
		radioButton3.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton2;
		size = new System.Drawing.Size(110, 21);
		radioButton4.Size = size;
		this.RadioButton2.TabIndex = 9;
		this.RadioButton2.Text = "Выводить выражения свойств";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.CheckBox4.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox5 = this.CheckBox4;
		location = new System.Drawing.Point(10, 202);
		checkBox5.Location = location;
		this.CheckBox4.Name = "CheckBox4";
		System.Windows.Forms.CheckBox checkBox6 = this.CheckBox4;
		size = new System.Drawing.Size(171, 21);
		checkBox6.Size = size;
		this.CheckBox4.TabIndex = 12;
		this.CheckBox4.Text = "Отмечать при экспорте элементы без чертежей";
		this.CheckBox4.UseVisualStyleBackColor = true;
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button3 = this.Button1;
		location = new System.Drawing.Point(312, 68);
		button3.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button4 = this.Button1;
		size = new System.Drawing.Size(42, 27);
		button4.Size = size;
		this.Button1.TabIndex = 4;
		this.Button1.Text = "Открыть";
		this.Button1.UseVisualStyleBackColor = true;
		this.lockratio.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox7 = this.lockratio;
		location = new System.Drawing.Point(172, 107);
		checkBox7.Location = location;
		this.lockratio.Name = "lockratio";
		System.Windows.Forms.CheckBox checkBox8 = this.lockratio;
		size = new System.Drawing.Size(185, 21);
		checkBox8.Size = size;
		this.lockratio.TabIndex = 5;
		this.lockratio.Text = "Сохранять пропорции (исходное соотношение 4:3)";
		this.lockratio.UseVisualStyleBackColor = true;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(369, 265);
		this.ClientSize = size;
		this.Controls.Add(this.RadioButton2);
		this.Controls.Add(this.RadioButton1);
		this.Controls.Add(this.CheckBox1);
		this.Controls.Add(this.CheckBox4);
		this.Controls.Add(this.lockratio);
		this.Controls.Add(this.insertimagebool);
		this.Controls.Add(this.image_height);
		this.Controls.Add(this.image_width);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.Button2);
		this.Controls.Add(this.Label9);
		this.Controls.Add(this.Label8);
		this.Controls.Add(this.Label7);
		this.Controls.Add(this.Label6);
		this.Controls.Add(this.bompath);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "Frmbomset";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Параметры спецификации";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.image_height).EndInit();
		((System.ComponentModel.ISupportInitialize)this.image_width).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		CConfigMng.Config.bompath = bompath.Text;
		CConfigDO config = CConfigMng.Config;
		Size image_size = new Size(Convert.ToInt32(image_width.Value), Convert.ToInt32(image_height.Value));
		config.image_size = image_size;
		CConfigMng.Config.image_lockratio = lockratio.Checked;
		CConfigMng.Config.insertimagebool = checked((int)Math.Round(Conversion.Val(insertimagebool.Checked)));
		CConfigMng.Config.bomsubfolder = CheckBox1.Checked;
		CConfigMng.Config.BomByVal = RadioButton1.Checked;
		CConfigMng.Config.Marknodrw = CheckBox4.Checked;
		CConfigMng.SaveConfig();
		try
		{
			if (Conversions.ToDouble(MyProject.Forms.Frmmain._ExportBom.Keytip) == 1.0)
			{
				MyProject.Forms.Frmmain._ExportBom_ItemsSourceReady(null, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		Close();
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void Frmbomset_Load(object sender, EventArgs e)
	{
		if (Directory.Exists(CConfigMng.Config.bompath))
		{
			bompath.Text = CConfigMng.Config.bompath;
		}
		image_width.Value = new decimal(CConfigMng.Config.image_size.Width);
		image_height.Value = new decimal(CConfigMng.Config.image_size.Height);
		insertimagebool.Checked = code.Cbool1(Conversions.ToString(CConfigMng.Config.insertimagebool));
		CheckBox1.Checked = CConfigMng.Config.bomsubfolder;
		RadioButton1.Checked = CConfigMng.Config.BomByVal;
		RadioButton2.Checked = !CConfigMng.Config.BomByVal;
		CheckBox4.Checked = CConfigMng.Config.Marknodrw;
		lockratio.Checked = CConfigMng.Config.image_lockratio;
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			bompath.Text = fileBorser.DirectoryPath;
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		string text = bompath.Text;
		if (!Directory.Exists(text))
		{
			text = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\Шаблоны спецификации";
		}
		code.OpenFolderWithEX(text);
	}

	private void image_width_ValueChanged(object sender, EventArgs e)
	{
		if (lockratio.Checked)
		{
			image_height.Value = decimal.Divide(decimal.Multiply(image_width.Value, 3m), 4m);
		}
	}

	private void image_height_ValueChanged(object sender, EventArgs e)
	{
		if (lockratio.Checked)
		{
			image_width.Value = decimal.Divide(decimal.Multiply(image_height.Value, 4m), 3m);
		}
	}
}
