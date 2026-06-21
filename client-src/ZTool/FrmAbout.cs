using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmAbout : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("OKButton")]
	private Button _OKButton;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("LableDescription")]
	private Label _LableDescription;

	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[AccessedThroughProperty("LabelQQ")]
	private Label _LabelQQ;

	[AccessedThroughProperty("LabelEmail")]
	private Label _LabelEmail;

	[AccessedThroughProperty("LabelVersion")]
	private Label _LabelVersion;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("LinkLabel1")]
	private LinkLabel _LinkLabel1;

	[AccessedThroughProperty("PictureBox2")]
	private PictureBox _PictureBox2;

	internal virtual Button OKButton
	{
		[DebuggerNonUserCode]
		get
		{
			return _OKButton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OKButton_Click_1;
			if (_OKButton != null)
			{
				_OKButton.Click -= value2;
			}
			_OKButton = value;
			if (_OKButton != null)
			{
				_OKButton.Click += value2;
			}
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

	internal virtual Label LableDescription
	{
		[DebuggerNonUserCode]
		get
		{
			return _LableDescription;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_LableDescription = value;
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

	internal virtual Label LabelQQ
	{
		[DebuggerNonUserCode]
		get
		{
			return _LabelQQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_LabelQQ = value;
		}
	}

	internal virtual Label LabelEmail
	{
		[DebuggerNonUserCode]
		get
		{
			return _LabelEmail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_LabelEmail = value;
		}
	}

	internal virtual Label LabelVersion
	{
		[DebuggerNonUserCode]
		get
		{
			return _LabelVersion;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_LabelVersion = value;
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

	internal virtual PictureBox PictureBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _PictureBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_PictureBox2 = value;
		}
	}

	[DebuggerNonUserCode]
	public FrmAbout()
	{
		base.FormClosed += FrmAbout_FormClosed;
		base.KeyPress += FrmAbout_KeyPress;
		base.Load += AboutBox1_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.FrmAbout));
		this.OKButton = new System.Windows.Forms.Button();
		this.Button1 = new System.Windows.Forms.Button();
		this.LableDescription = new System.Windows.Forms.Label();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.LabelQQ = new System.Windows.Forms.Label();
		this.LabelEmail = new System.Windows.Forms.Label();
		this.LabelVersion = new System.Windows.Forms.Label();
		this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.Label1 = new System.Windows.Forms.Label();
		this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		this.TableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).BeginInit();
		this.SuspendLayout();
		this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button oKButton = this.OKButton;
		System.Drawing.Point location = new System.Drawing.Point(216, 419);
		oKButton.Location = location;
		System.Windows.Forms.Button oKButton2 = this.OKButton;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(5);
		oKButton2.Margin = margin;
		this.OKButton.Name = "OKButton";
		System.Windows.Forms.Button oKButton3 = this.OKButton;
		System.Drawing.Size size = new System.Drawing.Size(75, 27);
		oKButton3.Size = size;
		this.OKButton.TabIndex = 0;
		this.OKButton.Text = "ОК(&O)";
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		System.Windows.Forms.Button button = this.Button1;
		location = new System.Drawing.Point(7, 419);
		button.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button2 = this.Button1;
		size = new System.Drawing.Size(75, 27);
		button2.Size = size;
		this.Button1.TabIndex = 3;
		this.Button1.Text = "Журнал обновлений";
		this.Button1.UseVisualStyleBackColor = true;
		this.LableDescription.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.LableDescription.AutoSize = true;
		this.LableDescription.Font = new System.Drawing.Font("华文行楷", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.LableDescription.ForeColor = System.Drawing.Color.Red;
		System.Windows.Forms.Label lableDescription = this.LableDescription;
		location = new System.Drawing.Point(3, 255);
		lableDescription.Location = location;
		this.LableDescription.Name = "LableDescription";
		System.Windows.Forms.Label lableDescription2 = this.LableDescription;
		size = new System.Drawing.Size(299, 19);
		lableDescription2.Size = size;
		this.LableDescription.TabIndex = 4;
		this.LableDescription.Text = "Label1";
		this.LableDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.PictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("PictureBox1.BackgroundImage");
		this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.PictureBox1.InitialImage = null;
		System.Windows.Forms.PictureBox pictureBox = this.PictureBox1;
		location = new System.Drawing.Point(0, 0);
		pictureBox.Location = location;
		System.Windows.Forms.PictureBox pictureBox2 = this.PictureBox1;
		margin = new System.Windows.Forms.Padding(0);
		pictureBox2.Margin = margin;
		this.PictureBox1.Name = "PictureBox1";
		System.Windows.Forms.PictureBox pictureBox3 = this.PictureBox1;
		size = new System.Drawing.Size(305, 65);
		pictureBox3.Size = size;
		this.PictureBox1.TabIndex = 3;
		this.PictureBox1.TabStop = false;
		this.LabelQQ.Dock = System.Windows.Forms.DockStyle.Top;
		this.LabelQQ.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label labelQQ = this.LabelQQ;
		location = new System.Drawing.Point(6, 135);
		labelQQ.Location = location;
		System.Windows.Forms.Label labelQQ2 = this.LabelQQ;
		margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		labelQQ2.Margin = margin;
		this.LabelQQ.Name = "LabelQQ";
		System.Windows.Forms.Label labelQQ3 = this.LabelQQ;
		size = new System.Drawing.Size(296, 20);
		labelQQ3.Size = size;
		this.LabelQQ.TabIndex = 0;
		this.LabelQQ.Text = "Группа QQ";
		this.LabelQQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.LabelEmail.Dock = System.Windows.Forms.DockStyle.Top;
		this.LabelEmail.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label labelEmail = this.LabelEmail;
		location = new System.Drawing.Point(6, 105);
		labelEmail.Location = location;
		System.Windows.Forms.Label labelEmail2 = this.LabelEmail;
		margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		labelEmail2.Margin = margin;
		this.LabelEmail.Name = "LabelEmail";
		System.Windows.Forms.Label labelEmail3 = this.LabelEmail;
		size = new System.Drawing.Size(296, 20);
		labelEmail3.Size = size;
		this.LabelEmail.TabIndex = 2;
		this.LabelEmail.Text = "Email";
		this.LabelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.LabelVersion.Dock = System.Windows.Forms.DockStyle.Top;
		this.LabelVersion.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label labelVersion = this.LabelVersion;
		location = new System.Drawing.Point(6, 75);
		labelVersion.Location = location;
		System.Windows.Forms.Label labelVersion2 = this.LabelVersion;
		margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		labelVersion2.Margin = margin;
		this.LabelVersion.Name = "LabelVersion";
		System.Windows.Forms.Label labelVersion3 = this.LabelVersion;
		size = new System.Drawing.Size(296, 20);
		labelVersion3.Size = size;
		this.LabelVersion.TabIndex = 0;
		this.LabelVersion.Text = "Версия";
		this.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
		this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 5);
		this.TableLayoutPanel1.Controls.Add(this.LabelVersion, 0, 2);
		this.TableLayoutPanel1.Controls.Add(this.LabelEmail, 0, 3);
		this.TableLayoutPanel1.Controls.Add(this.LableDescription, 0, 7);
		this.TableLayoutPanel1.Controls.Add(this.LabelQQ, 0, 4);
		this.TableLayoutPanel1.Controls.Add(this.PictureBox1, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.LinkLabel1, 0, 6);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		location = new System.Drawing.Point(0, 0);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 8;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39f));
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		size = new System.Drawing.Size(305, 296);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 2;
		this.Label1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(6, 165);
		label.Location = location;
		System.Windows.Forms.Label label2 = this.Label1;
		margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
		label2.Margin = margin;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label3 = this.Label1;
		size = new System.Drawing.Size(296, 30);
		label3.Size = size;
		this.Label1.TabIndex = 4;
		this.Label1.Text = "Поддерживаемые версии ОС";
		this.LinkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.LinkLabel1.AutoSize = true;
		this.LinkLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.LinkLabel linkLabel = this.LinkLabel1;
		location = new System.Drawing.Point(3, 204);
		linkLabel.Location = location;
		this.LinkLabel1.Name = "LinkLabel1";
		System.Windows.Forms.LinkLabel linkLabel2 = this.LinkLabel1;
		size = new System.Drawing.Size(299, 21);
		linkLabel2.Size = size;
		this.LinkLabel1.TabIndex = 5;
		this.LinkLabel1.TabStop = true;
		this.LinkLabel1.Text = "LinkLabel1";
		this.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
		this.PictureBox2.Image = ZTool.My.Resources.Resources.二维码;
		System.Windows.Forms.PictureBox pictureBox4 = this.PictureBox2;
		location = new System.Drawing.Point(8, 296);
		pictureBox4.Location = location;
		this.PictureBox2.Name = "PictureBox2";
		System.Windows.Forms.PictureBox pictureBox5 = this.PictureBox2;
		size = new System.Drawing.Size(288, 112);
		pictureBox5.Size = size;
		this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.PictureBox2.TabIndex = 4;
		this.PictureBox2.TabStop = false;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(305, 450);
		this.ClientSize = size;
		this.Controls.Add(this.PictureBox2);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Controls.Add(this.OKButton);
		this.Controls.Add(this.Button1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = ZTool.My.Resources.Resources.ztool_11;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmAbout";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "О программе";
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox2).EndInit();
		this.ResumeLayout(false);
	}

	private void FrmAbout_FormClosed(object sender, FormClosedEventArgs e)
	{
		Dispose();
		if (Application.OpenForms.Count == 0)
		{
			Application.Exit();
		}
	}

	private void FrmAbout_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void AboutBox1_Load(object sender, EventArgs e)
	{
		Text = string.Format(arg0: (Operators.CompareString(MyProject.Application.Info.Title, "", TextCompare: false) == 0) ? Path.GetFileNameWithoutExtension(MyProject.Application.Info.AssemblyName) : MyProject.Application.Info.Title, format: "О программе " + MyProject.Application.Info.ProductName + " — {0}");
		if (Environment.Is64BitProcess)
		{
			LabelVersion.Text = string.Format("Версия :{0}", Application.ProductVersion.ToString() + "(x64)");
		}
		else
		{
			LabelVersion.Text = string.Format("Версия :{0}", Application.ProductVersion.ToString() + "(x86)");
		}
		LabelEmail.Text = "Email: ";
		LabelQQ.Text = "Группа QQ: ";
		LinkLabel1.Text = Resources.website;
		Label1.Text = "Поддерживаемые версии ОС: Win7 и выше";
		LableDescription.Text = MyProject.Application.Info.Description;
		try
		{
			MyProject.Forms.Frmmain.sendhwndtosw();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		zt_AboutSetup();
	}

	// Phase 3: rebuilds the About box from source (mirrors the IL-Localizer
	// PatchAboutBox transform): SWTools logo banner, website + MAX hyperlinks,
	// e-mail line and the MAX contact QR; the vendor phone/QQ grid, version, OS
	// and description rows plus the update-log button are hidden.
	private void zt_AboutSetup()
	{
		SuspendLayout();
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MaximizeBox = false;
		StartPosition = FormStartPosition.CenterScreen;
		ClientSize = new Size(360, 342);
		TableLayoutPanel1.Visible = false;
		Button1.Visible = false;
		PictureBox pictureBox = new PictureBox();
		System.IO.Stream logoStream = typeof(FrmAbout).Assembly.GetManifestResourceStream("SWToolsLogo.png");
		if (logoStream == null)
		{
			throw new System.InvalidOperationException("Встроенный ресурс \"SWToolsLogo.png\" не найден");
		}
		pictureBox.BackgroundImage = new Bitmap(logoStream);
		pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
		pictureBox.Location = new Point(0, 0);
		pictureBox.Size = new Size(360, 72);
		Controls.Add(pictureBox);
		LinkLabel linkLabel = new LinkLabel();
		linkLabel.AutoSize = false;
		linkLabel.Text = "Перейти на сайт";
		linkLabel.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
		linkLabel.TextAlign = ContentAlignment.MiddleCenter;
		linkLabel.Location = new Point(20, 84);
		linkLabel.Size = new Size(320, 26);
		linkLabel.LinkClicked += zt_AboutWeb_Click;
		Controls.Add(linkLabel);
		Label label = new Label();
		label.AutoSize = false;
		label.Text = "Email: lunin021189@gmail.com";
		label.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);
		label.TextAlign = ContentAlignment.MiddleCenter;
		label.Location = new Point(20, 116);
		label.Size = new Size(320, 24);
		Controls.Add(label);
		LinkLabel linkLabel2 = new LinkLabel();
		linkLabel2.AutoSize = false;
		linkLabel2.Text = "Связаться в MAX";
		linkLabel2.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
		linkLabel2.TextAlign = ContentAlignment.MiddleCenter;
		linkLabel2.Location = new Point(20, 144);
		linkLabel2.Size = new Size(320, 26);
		linkLabel2.LinkClicked += zt_AboutMax_Click;
		Controls.Add(linkLabel2);
		PictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
		PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
		PictureBox2.Location = new Point(30, 172);
		PictureBox2.Size = new Size(300, 118);
		OKButton.Location = new Point(268, 302);
		OKButton.Size = new Size(82, 28);
		ResumeLayout(false);
	}

	private void zt_AboutWeb_Click(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start("explorer.exe", "https://license.vizbuka.ru/swtools/");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void zt_AboutMax_Click(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			Process.Start("explorer.exe", "https://max.ru/u/f9LHodD0cOLc5SX8zsbZvz3TMwMzyunwK6GAYYw79SkF1lZ0YUlZknFImsU");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void OKButton_Click_1(object sender, EventArgs e)
	{
		Close();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		MyProject.Forms.FrmUpdatelog.TextBox1.Text = Resources.Update_log;
		MyProject.Forms.FrmUpdatelog.Hide();
		MyProject.Forms.FrmUpdatelog.Show(this);
	}

	private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start(LinkLabel1.Text);
	}
}
