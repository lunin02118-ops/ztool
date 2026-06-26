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
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmSetNewFolder : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[AccessedThroughProperty("TextBox2")]
	private TextBox _TextBox2;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	private double dpixRatio;

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
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.Button3 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.TableLayoutPanel1.SuspendLayout();
		this.TableLayoutPanel2.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(286, 85);
		tableLayoutPanel.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tableLayoutPanel2.Margin = margin;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(175, 35);
		tableLayoutPanel3.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(9, 4);
		oK_Button.Location = location;
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		oK_Button2.Margin = margin;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button3 = this.OK_Button;
		size = new System.Drawing.Size(68, 27);
		oK_Button3.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "ОК";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(99, 4);
		cancel_Button.Location = location;
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		cancel_Button2.Margin = margin;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button3 = this.Cancel_Button;
		size = new System.Drawing.Size(64, 27);
		cancel_Button3.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		location = new System.Drawing.Point(118, 13);
		textBox.Location = location;
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		textBox2.Margin = margin;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		System.Windows.Forms.TextBox textBox3 = this.TextBox1;
		size = new System.Drawing.Size(341, 23);
		textBox3.Size = size;
		this.TextBox1.TabIndex = 4;
		this.Label3.AutoSize = false;
		System.Windows.Forms.Label label = this.Label3;
		location = new System.Drawing.Point(17, 53);
		label.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label2 = this.Label3;
		size = new System.Drawing.Size(92, 17);
		label2.Size = size;
		this.Label3.TabIndex = 6;
		this.Label3.Text = "Имя новой папки:";
		this.Label2.AutoSize = false;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(17, 15);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(92, 17);
		label4.Size = size;
		this.Label2.TabIndex = 7;
		this.Label2.Text = "Имя исходной папки:";
		this.TableLayoutPanel2.AutoSize = true;
		this.TableLayoutPanel2.ColumnCount = 2;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel2.Controls.Add(this.Button3, 0, 0);
		this.TableLayoutPanel2.Controls.Add(this.Button2, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel4 = this.TableLayoutPanel2;
		location = new System.Drawing.Point(12, 85);
		tableLayoutPanel4.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel5 = this.TableLayoutPanel2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tableLayoutPanel5.Margin = margin;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel6 = this.TableLayoutPanel2;
		size = new System.Drawing.Size(218, 35);
		tableLayoutPanel6.Size = size;
		this.TableLayoutPanel2.TabIndex = 0;
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button3.AutoSize = true;
		System.Windows.Forms.Button button = this.Button3;
		location = new System.Drawing.Point(3, 4);
		button.Location = location;
		System.Windows.Forms.Button button2 = this.Button3;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		button2.Margin = margin;
		this.Button3.Name = "Button3";
		System.Windows.Forms.Button button3 = this.Button3;
		size = new System.Drawing.Size(103, 27);
		button3.Size = size;
		this.Button3.TabIndex = 0;
		this.Button3.Text = "Совпадает со сборкой";
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Button2.AutoSize = true;
		this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button button4 = this.Button2;
		location = new System.Drawing.Point(112, 4);
		button4.Location = location;
		System.Windows.Forms.Button button5 = this.Button2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		button5.Margin = margin;
		this.Button2.Name = "Button2";
		System.Windows.Forms.Button button6 = this.Button2;
		size = new System.Drawing.Size(103, 27);
		button6.Size = size;
		this.Button2.TabIndex = 1;
		this.Button2.Text = "Сбросить папку";
		this.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		System.Windows.Forms.TextBox textBox4 = this.TextBox2;
		location = new System.Drawing.Point(118, 50);
		textBox4.Location = location;
		System.Windows.Forms.TextBox textBox5 = this.TextBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		textBox5.Margin = margin;
		this.TextBox2.Name = "TextBox2";
		System.Windows.Forms.TextBox textBox6 = this.TextBox2;
		size = new System.Drawing.Size(308, 23);
		textBox6.Size = size;
		this.TextBox2.TabIndex = 4;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.AutoSize = true;
		System.Windows.Forms.Button button7 = this.Button1;
		location = new System.Drawing.Point(431, 48);
		button7.Location = location;
		this.Button1.Name = "Button1";
		System.Windows.Forms.Button button8 = this.Button1;
		size = new System.Drawing.Size(28, 27);
		button8.Size = size;
		this.Button1.TabIndex = 10;
		this.Button1.Text = "...";
		this.Button1.UseVisualStyleBackColor = true;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(475, 127);
		this.ClientSize = size;
		this.ControlBox = false;
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.TextBox2);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.TableLayoutPanel2);
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.Margin = margin;
		this.MaximizeBox = true;
		this.MaximumSize = System.Drawing.Size.Empty;
		this.MinimizeBox = false;
		size = new System.Drawing.Size(660, 190);
		this.MinimumSize = size;
		this.Name = "FrmSetNewFolder";
		this.ShowIcon = false;
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Сохранить в новую папку";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel2.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	public FrmSetNewFolder()
	{
		base.KeyPress += FrmSetNewFolder_KeyPress;
		base.Load += FrmSetNewFolder_Load;
		__ENCAddToList(this);
		dpixRatio = 1.0;
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		Size minimumSize = checked(new Size((int)Math.Round(491.0 * dpixRatio), (int)Math.Round(166.0 * dpixRatio)));
		MinimumSize = minimumSize;
		ConfigureResponsiveLayout();
	}

	private int Dpi(int value)
	{
		return checked((int)Math.Round((double)value * dpixRatio));
	}

	private void ConfigureResponsiveLayout()
	{
		SuspendLayout();
		try
		{
			FormBorderStyle = FormBorderStyle.Sizable;
			MaximizeBox = true;
			MaximumSize = Size.Empty;
			MinimumSize = new Size(Dpi(660), Dpi(190));
			SizeGripStyle = SizeGripStyle.Show;
			ClientSize = new Size(Math.Max(ClientSize.Width, Dpi(640)), Math.Max(ClientSize.Height, Dpi(160)));
			Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);

			int margin = Dpi(16);
			int labelWidth = Dpi(150);
			int inputLeft = margin + labelWidth + Dpi(10);
			int browseWidth = Dpi(34);
			int inputHeight = Dpi(24);
			int rowGap = Dpi(14);
			int firstRowTop = Dpi(18);
			int secondRowTop = firstRowTop + inputHeight + rowGap;

			Label2.AutoSize = false;
			Label2.Location = new Point(margin, firstRowTop + Dpi(3));
			Label2.Size = new Size(labelWidth, inputHeight);
			Label2.TextAlign = ContentAlignment.MiddleLeft;
			Label2.Anchor = AnchorStyles.Top | AnchorStyles.Left;

			TextBox1.Location = new Point(inputLeft, firstRowTop);
			TextBox1.Size = new Size(ClientSize.Width - inputLeft - margin, inputHeight);
			TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

			Label3.AutoSize = false;
			Label3.Location = new Point(margin, secondRowTop + Dpi(3));
			Label3.Size = new Size(labelWidth, inputHeight);
			Label3.TextAlign = ContentAlignment.MiddleLeft;
			Label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;

			Button1.AutoSize = false;
			Button1.Size = new Size(browseWidth, inputHeight + Dpi(2));
			Button1.Location = new Point(ClientSize.Width - margin - browseWidth, secondRowTop - Dpi(1));
			Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;

			TextBox2.Location = new Point(inputLeft, secondRowTop);
			TextBox2.Size = new Size(Button1.Left - inputLeft - Dpi(8), inputHeight);
			TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

			Button3.AutoSize = false;
			Button2.AutoSize = false;
			Button3.Dock = DockStyle.Fill;
			Button2.Dock = DockStyle.Fill;
			TableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			TableLayoutPanel2.AutoSize = false;
			TableLayoutPanel2.ColumnStyles.Clear();
			TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(180)));
			TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(150)));
			TableLayoutPanel2.Location = new Point(margin, ClientSize.Height - Dpi(44));
			TableLayoutPanel2.Size = new Size(Dpi(338), Dpi(32));

			OK_Button.AutoSize = false;
			Cancel_Button.AutoSize = false;
			OK_Button.Dock = DockStyle.Fill;
			Cancel_Button.Dock = DockStyle.Fill;
			TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			TableLayoutPanel1.AutoSize = false;
			TableLayoutPanel1.ColumnStyles.Clear();
			TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(92)));
			TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(108)));
			TableLayoutPanel1.Location = new Point(ClientSize.Width - margin - Dpi(208), ClientSize.Height - Dpi(44));
			TableLayoutPanel1.Size = new Size(Dpi(208), Dpi(32));
		}
		finally
		{
			ResumeLayout(performLayout: true);
		}
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		try
		{
			string path = TextBox2.Text;
			if (!Directory.Exists(path) && MessageBox.Show(this, "Путь не существует, создать?", "Вопрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
			{
				return;
			}
			path = Directory.CreateDirectory(path).FullName;
			if (!MyProject.Forms.Frmmain.HighLightRow.Checked)
			{
				foreach (DataGridViewCell selectedCell in MyProject.Forms.Frmmain.DGV1.SelectedCells)
				{
					if (MyProject.Forms.Frmmain.DGV1.Rows[selectedCell.RowIndex].Visible)
					{
						MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, selectedCell.RowIndex].Value = path;
					}
				}
			}
			else
			{
				foreach (DataGridViewRow selectedRow in MyProject.Forms.Frmmain.DGV1.SelectedRows)
				{
					if (selectedRow.Visible)
					{
						MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, selectedRow.Index].Value = path;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(this, ex2.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			ProjectData.ClearProjectError();
			return;
		}
		DialogResult = DialogResult.OK;
		Close();
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void FrmSetNewFolder_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void FrmSetNewFolder_Load(object sender, EventArgs e)
	{
		TextBox1.Text = code.SplitStr(Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, MyProject.Forms.Frmmain.sel_row].Value), 6);
		TextBox2.Text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, MyProject.Forms.Frmmain.sel_row].Value);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(this) == DialogResult.OK)
		{
			TextBox2.Text = fileBorser.DirectoryPath;
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		if (!MyProject.Forms.Frmmain.HighLightRow.Checked)
		{
			foreach (DataGridViewCell selectedCell in MyProject.Forms.Frmmain.DGV1.SelectedCells)
			{
				if (MyProject.Forms.Frmmain.DGV1.Rows[selectedCell.RowIndex].Visible)
				{
					MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, selectedCell.RowIndex].Value = code.SplitStr(Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, selectedCell.RowIndex].Value), 6);
				}
			}
		}
		else
		{
			foreach (DataGridViewRow selectedRow in MyProject.Forms.Frmmain.DGV1.SelectedRows)
			{
				if (selectedRow.Visible)
				{
					MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, selectedRow.Index].Value = code.SplitStr(Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, selectedRow.Index].Value), 6);
				}
			}
		}
		Close();
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		if (!MyProject.Forms.Frmmain.HighLightRow.Checked)
		{
			foreach (DataGridViewCell selectedCell in MyProject.Forms.Frmmain.DGV1.SelectedCells)
			{
				if (MyProject.Forms.Frmmain.DGV1.Rows[selectedCell.RowIndex].Visible)
				{
					MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, selectedCell.RowIndex].Value = code.SplitStr(Conversions.ToString(MyProject.Forms.Frmmain.DGV1.Tag), 6);
				}
			}
		}
		else
		{
			foreach (DataGridViewRow selectedRow in MyProject.Forms.Frmmain.DGV1.SelectedRows)
			{
				if (selectedRow.Visible)
				{
					MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_NewFolder.Index, selectedRow.Index].Value = code.SplitStr(Conversions.ToString(MyProject.Forms.Frmmain.DGV1.Tag), 6);
				}
			}
		}
		Close();
	}
}
