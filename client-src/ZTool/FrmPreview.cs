using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My.Resources;

namespace ZTool;

[DesignerGenerated]
public class FrmPreview : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[AccessedThroughProperty("ToolStrip1")]
	private ToolStrip _ToolStrip1;

	[AccessedThroughProperty("Open3D_InSw")]
	private ToolStripButton _Open3D_InSw;

	[AccessedThroughProperty("Open2D_InSw")]
	private ToolStripButton _Open2D_InSw;

	[AccessedThroughProperty("OpenFolder")]
	private ToolStripButton _OpenFolder;

	[AccessedThroughProperty("AlwaysShow")]
	private CheckBox _AlwaysShow;

	[AccessedThroughProperty("Title")]
	private Label _Title;

	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton _ToolStripButton1;

	internal Form form;

	internal bool ChangeFrm;

	internal bool FullFrm;

	internal bool ChangePre;

	internal int Image_H;

	internal int Image_W;

	private Size MinSize_H;

	private Size MinSize_V;

	private Point mPoint;

	private bool ismoving;

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
			PaintEventHandler value2 = PictureBox1_Paint;
			MouseEventHandler value3 = PictureBox1_MouseMove;
			MouseEventHandler value4 = PictureBox1_MouseDown;
			MouseEventHandler value5 = PictureBox1_MouseUp;
			if (_PictureBox1 != null)
			{
				_PictureBox1.Paint -= value2;
				_PictureBox1.MouseMove -= value3;
				_PictureBox1.MouseDown -= value4;
				_PictureBox1.MouseUp -= value5;
			}
			_PictureBox1 = value;
			if (_PictureBox1 != null)
			{
				_PictureBox1.Paint += value2;
				_PictureBox1.MouseMove += value3;
				_PictureBox1.MouseDown += value4;
				_PictureBox1.MouseUp += value5;
			}
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
			EventHandler value2 = ToolStrip1_MouseLeave;
			EventHandler value3 = ToolStrip1_MouseEnter;
			PaintEventHandler value4 = ToolStrip1_Paint;
			if (_ToolStrip1 != null)
			{
				_ToolStrip1.MouseLeave -= value2;
				_ToolStrip1.MouseEnter -= value3;
				_ToolStrip1.Paint -= value4;
			}
			_ToolStrip1 = value;
			if (_ToolStrip1 != null)
			{
				_ToolStrip1.MouseLeave += value2;
				_ToolStrip1.MouseEnter += value3;
				_ToolStrip1.Paint += value4;
			}
		}
	}

	internal virtual ToolStripButton Open3D_InSw
	{
		[DebuggerNonUserCode]
		get
		{
			return _Open3D_InSw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OpenModle_InSw_Click;
			if (_Open3D_InSw != null)
			{
				_Open3D_InSw.Click -= value2;
			}
			_Open3D_InSw = value;
			if (_Open3D_InSw != null)
			{
				_Open3D_InSw.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton Open2D_InSw
	{
		[DebuggerNonUserCode]
		get
		{
			return _Open2D_InSw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OpenDraw_InSw_Click;
			if (_Open2D_InSw != null)
			{
				_Open2D_InSw.Click -= value2;
			}
			_Open2D_InSw = value;
			if (_Open2D_InSw != null)
			{
				_Open2D_InSw.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton OpenFolder
	{
		[DebuggerNonUserCode]
		get
		{
			return _OpenFolder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OpenFolder_Click;
			if (_OpenFolder != null)
			{
				_OpenFolder.Click -= value2;
			}
			_OpenFolder = value;
			if (_OpenFolder != null)
			{
				_OpenFolder.Click += value2;
			}
		}
	}

	internal virtual CheckBox AlwaysShow
	{
		[DebuggerNonUserCode]
		get
		{
			return _AlwaysShow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = AlwaysShow_CheckedChanged;
			if (_AlwaysShow != null)
			{
				_AlwaysShow.CheckedChanged -= value2;
			}
			_AlwaysShow = value;
			if (_AlwaysShow != null)
			{
				_AlwaysShow.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label Title
	{
		[DebuggerNonUserCode]
		get
		{
			return _Title;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Title = value;
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

	public FrmPreview()
	{
		base.Load += FrmPreview_Load;
		base.FormClosed += FrmPreview_FormClosed;
		base.KeyDown += FrmPreview_KeyDown;
		__ENCAddToList(this);
		form = new Form();
		ref Size minSize_H = ref MinSize_H;
		minSize_H = new Size(240, 180);
		ref Size minSize_V = ref MinSize_V;
		minSize_V = new Size(180, 240);
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
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
		this.Open3D_InSw = new System.Windows.Forms.ToolStripButton();
		this.Open2D_InSw = new System.Windows.Forms.ToolStripButton();
		this.OpenFolder = new System.Windows.Forms.ToolStripButton();
		this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
		this.AlwaysShow = new System.Windows.Forms.CheckBox();
		this.Title = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		this.ToolStrip1.SuspendLayout();
		this.SuspendLayout();
		this.PictureBox1.BackColor = System.Drawing.Color.White;
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.PictureBox pictureBox = this.PictureBox1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		pictureBox.Location = location;
		this.PictureBox1.Name = "PictureBox1";
		System.Windows.Forms.PictureBox pictureBox2 = this.PictureBox1;
		System.Drawing.Size size = new System.Drawing.Size(240, 180);
		pictureBox2.Size = size;
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox1.TabIndex = 3;
		this.PictureBox1.TabStop = false;
		this.ToolStrip1.BackColor = System.Drawing.Color.Transparent;
		this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.Open3D_InSw, this.Open2D_InSw, this.OpenFolder, this.ToolStripButton1 });
		this.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
		System.Windows.Forms.ToolStrip toolStrip = this.ToolStrip1;
		location = new System.Drawing.Point(3, 32);
		toolStrip.Location = location;
		this.ToolStrip1.Name = "ToolStrip1";
		this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
		System.Windows.Forms.ToolStrip toolStrip2 = this.ToolStrip1;
		size = new System.Drawing.Size(24, 85);
		toolStrip2.Size = size;
		this.ToolStrip1.TabIndex = 2;
		this.ToolStrip1.Text = "Открыть в SolidWorks";
		this.Open3D_InSw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.Open3D_InSw.Image = ZTool.My.Resources.Resources.@null;
		this.Open3D_InSw.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton open3D_InSw = this.Open3D_InSw;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(0);
		open3D_InSw.Margin = margin;
		this.Open3D_InSw.Name = "Open3D_InSw";
		System.Windows.Forms.ToolStripButton open3D_InSw2 = this.Open3D_InSw;
		size = new System.Drawing.Size(22, 20);
		open3D_InSw2.Size = size;
		this.Open3D_InSw.ToolTipText = "Открыть компонент";
		this.Open2D_InSw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.Open2D_InSw.Image = ZTool.My.Resources.Resources.slddrw;
		this.Open2D_InSw.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton open2D_InSw = this.Open2D_InSw;
		margin = new System.Windows.Forms.Padding(0);
		open2D_InSw.Margin = margin;
		this.Open2D_InSw.Name = "Open2D_InSw";
		System.Windows.Forms.ToolStripButton open2D_InSw2 = this.Open2D_InSw;
		size = new System.Drawing.Size(22, 20);
		open2D_InSw2.Size = size;
		this.Open2D_InSw.ToolTipText = "Открыть чертёж";
		this.OpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.OpenFolder.Image = ZTool.My.Resources.Resources.Folder_24px;
		this.OpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
		System.Windows.Forms.ToolStripButton openFolder = this.OpenFolder;
		margin = new System.Windows.Forms.Padding(0);
		openFolder.Margin = margin;
		this.OpenFolder.Name = "OpenFolder";
		System.Windows.Forms.ToolStripButton openFolder2 = this.OpenFolder;
		size = new System.Drawing.Size(22, 20);
		openFolder2.Size = size;
		this.OpenFolder.ToolTipText = "Показать в папке";
		this.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.ToolStripButton1.Image = ZTool.My.Resources.Resources.help_32;
		this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.ToolStripButton1.Name = "ToolStripButton1";
		System.Windows.Forms.ToolStripButton toolStripButton = this.ToolStripButton1;
		size = new System.Drawing.Size(22, 20);
		toolStripButton.Size = size;
		this.ToolStripButton1.Text = "Открыть файл справки";
		this.AlwaysShow.AutoSize = true;
		this.AlwaysShow.BackColor = System.Drawing.Color.Transparent;
		this.AlwaysShow.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.AlwaysShow.ForeColor = System.Drawing.SystemColors.ControlText;
		System.Windows.Forms.CheckBox alwaysShow = this.AlwaysShow;
		location = new System.Drawing.Point(6, 5);
		alwaysShow.Location = location;
		this.AlwaysShow.Name = "AlwaysShow";
		System.Windows.Forms.CheckBox alwaysShow2 = this.AlwaysShow;
		size = new System.Drawing.Size(75, 21);
		alwaysShow2.Size = size;
		this.AlwaysShow.TabIndex = 5;
		this.AlwaysShow.Text = "Показывать рядом";
		this.AlwaysShow.UseVisualStyleBackColor = false;
		this.Title.AutoSize = true;
		this.Title.BackColor = System.Drawing.Color.Transparent;
		this.Title.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.Title.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.Title.ForeColor = System.Drawing.Color.Red;
		System.Windows.Forms.Label title = this.Title;
		location = new System.Drawing.Point(0, 161);
		title.Location = location;
		System.Windows.Forms.Label title2 = this.Title;
		size = new System.Drawing.Size(240, 0);
		title2.MaximumSize = size;
		this.Title.Name = "Title";
		System.Windows.Forms.Label title3 = this.Title;
		size = new System.Drawing.Size(0, 19);
		title3.Size = size;
		this.Title.TabIndex = 6;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(240, 180);
		this.ClientSize = size;
		this.Controls.Add(this.AlwaysShow);
		this.Controls.Add(this.ToolStrip1);
		this.Controls.Add(this.Title);
		this.Controls.Add(this.PictureBox1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		size = new System.Drawing.Size(240, 180);
		this.MinimumSize = size;
		this.Name = "FrmPreview";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		this.ToolStrip1.ResumeLayout(false);
		this.ToolStrip1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public void OpenModle_InSw_Click(object sender, EventArgs e)
	{
		string parameter = Conversions.ToString(Tag);
		Thread thread = new Thread(_Lambda_0024__123);
		thread.Start(parameter);
	}

	public void OpenDraw_InSw_Click(object sender, EventArgs e)
	{
		string str = Conversions.ToString(Tag);
		str = code.SplitStr(str, 3) + ".SLDDRW";
		Thread thread = new Thread(_Lambda_0024__124);
		thread.Start(str);
	}

	private void OpenFolder_Click(object sender, EventArgs e)
	{
		Interaction.Shell(Conversions.ToString(Operators.ConcatenateObject("explorer.exe /select,", Tag)), AppWinStyle.NormalFocus);
	}

	private void PictureBox1_MouseUp(object sender, EventArgs e)
	{
		Cursor = Cursors.Default;
		ismoving = false;
		if (!form.Focused)
		{
			form.Focus();
		}
	}

	private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			ref Point reference = ref mPoint;
			reference = new Point(e.X, e.Y);
			if (Control.MouseButtons == MouseButtons.Left)
			{
				ChangeFrm = !ChangeFrm;
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					FullFrm = true;
				}
				else
				{
					FullFrm = false;
				}
				Refresh();
			}
			if (Control.MouseButtons == MouseButtons.Right)
			{
				ChangePre = !ChangePre;
				CConfigMng.Config.DefaultDrw = ChangePre;
				CConfigMng.SaveConfig();
				code.Preview2(ChangePre, Conversions.ToString(Tag), Text, form);
			}
			if (Control.MouseButtons == MouseButtons.Middle)
			{
				ismoving = true;
				Cursor = Cursors.SizeAll;
			}
			if (!form.Focused)
			{
				form.Focus();
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

	private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
	{
		Rectangle workingArea = Screen.GetWorkingArea(this);
		checked
		{
			if ((e.Button == MouseButtons.Middle && Cursor == Cursors.SizeAll) ? true : false)
			{
				Point frmPreviewLocation = (Location = new Point(Location.X + e.X - mPoint.X, Location.Y + e.Y - mPoint.Y));
				if ((frmPreviewLocation.X + Width <= workingArea.Width && frmPreviewLocation.Y + Height <= workingArea.Height && frmPreviewLocation.X >= 0 && frmPreviewLocation.Y >= 0) ? true : false)
				{
					CConfigMng.Config.FrmPreviewLocation = frmPreviewLocation;
				}
			}
		}
	}

	private void PictureBox1_Paint(object sender, PaintEventArgs e)
	{
		if (ismoving)
		{
			return;
		}
		Rectangle workingArea = Screen.GetWorkingArea(this);
		try
		{
			AutoSize = false;
			if (Image_W <= 0 || Image_H <= 0)
			{
				return;
			}
			Size size;
			if ((!ChangeFrm && !FullFrm) ? true : false)
			{
				if ((Image_W < Image_H) & Title.Text.EndsWith(".slddrw", StringComparison.CurrentCultureIgnoreCase))
				{
					Size = MinSize_V;
				}
				else
				{
					Size = MinSize_H;
				}
				Location = CConfigMng.Config.FrmPreviewLocation;
				PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			}
			else if ((ChangeFrm && !FullFrm) ? true : false)
			{
				size = new Size(Image_W, Image_H);
				Size = size;
				Location = CConfigMng.Config.FrmPreviewLocation;
				PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			}
			else if (FullFrm)
			{
				size = new Size(workingArea.Width, workingArea.Height);
				Size = size;
				Point location = new Point(0, 0);
				Location = location;
				PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			}
			Label title = Title;
			size = new Size(Width, 0);
			title.MaximumSize = size;
			Title.AutoSize = true;
			Title.Dock = DockStyle.Bottom;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void FrmPreview_Load(object sender, EventArgs e)
	{
		if (!Information.IsNothing(CConfigMng.Config.FrmPreviewLocation))
		{
			Location = CConfigMng.Config.FrmPreviewLocation;
		}
		Rectangle workingArea = Screen.GetWorkingArea(this);
		if ((checked(Left + Width > workingArea.Width || Top + Height > workingArea.Height) || Left < 0 || Top < 0) ? true : false)
		{
			Left = 0;
			Top = 0;
		}
		try
		{
			Title.Parent = PictureBox1;
			ToolStrip1.Parent = PictureBox1;
			AlwaysShow.Parent = PictureBox1;
			AlwaysShow.Checked = CConfigMng.Config.RowFollowdisplay;
			AutoSize = false;
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

	private void AlwaysShow_CheckedChanged(object sender, EventArgs e)
	{
		CConfigMng.Config.RowFollowdisplay = AlwaysShow.Checked;
		CConfigMng.SaveConfig();
	}

	private void FrmPreview_FormClosed(object sender, FormClosedEventArgs e)
	{
		Rectangle workingArea = Screen.GetWorkingArea(this);
		if ((checked(Left + Width < workingArea.Width && Top + Height < workingArea.Height) && Left > 0 && Top > 0) ? true : false)
		{
			CConfigMng.Config.FrmPreviewLocation = Location;
			CConfigMng.SaveConfig();
		}
	}

	private void FrmPreview_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
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

	protected override void WndProc(ref Message m)
	{
		if (m.Msg != 20)
		{
			base.WndProc(ref m);
		}
	}

	private void ToolStripButton1_Click(object sender, EventArgs e)
	{
		try
		{
			if (File.Exists(code.helpfile))
			{
				Help.ShowHelp(this, code.helpfile, "/进阶操作/缩略图显示及操作.htm");
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
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void ToolStrip1_MouseEnter(object sender, EventArgs e)
	{
		ToolStrip1.Focus();
	}

	private void ToolStrip1_MouseLeave(object sender, EventArgs e)
	{
		if (!form.Focused)
		{
			form.Focus();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	[DebuggerStepThrough]
	private static void _Lambda_0024__123(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private static void _Lambda_0024__124(object a0)
	{
		code.OpenDoc(Conversions.ToString(a0));
	}
}
