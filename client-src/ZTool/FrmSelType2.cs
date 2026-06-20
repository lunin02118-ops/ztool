using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[DesignerGenerated]
public class FrmSelType2 : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("TYPE_SLDASM")]
	private CheckBox _TYPE_SLDASM;

	[AccessedThroughProperty("TYPE_SLDPRT")]
	private CheckBox _TYPE_SLDPRT;

	[AccessedThroughProperty("TYPE_SLDDRW")]
	private CheckBox _TYPE_SLDDRW;

	[AccessedThroughProperty("Includesubfolders")]
	private CheckBox _Includesubfolders;

	[AccessedThroughProperty("Onlyhasdrw")]
	private CheckBox _Onlyhasdrw;

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

	internal virtual CheckBox TYPE_SLDASM
	{
		[DebuggerNonUserCode]
		get
		{
			return _TYPE_SLDASM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = TYPE_SLDPRT_CheckedChanged;
			if (_TYPE_SLDASM != null)
			{
				_TYPE_SLDASM.CheckedChanged -= value2;
			}
			_TYPE_SLDASM = value;
			if (_TYPE_SLDASM != null)
			{
				_TYPE_SLDASM.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox TYPE_SLDPRT
	{
		[DebuggerNonUserCode]
		get
		{
			return _TYPE_SLDPRT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = TYPE_SLDPRT_CheckedChanged;
			if (_TYPE_SLDPRT != null)
			{
				_TYPE_SLDPRT.CheckedChanged -= value2;
			}
			_TYPE_SLDPRT = value;
			if (_TYPE_SLDPRT != null)
			{
				_TYPE_SLDPRT.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox TYPE_SLDDRW
	{
		[DebuggerNonUserCode]
		get
		{
			return _TYPE_SLDDRW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_TYPE_SLDDRW = value;
		}
	}

	internal virtual CheckBox Includesubfolders
	{
		[DebuggerNonUserCode]
		get
		{
			return _Includesubfolders;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Includesubfolders = value;
		}
	}

	internal virtual CheckBox Onlyhasdrw
	{
		[DebuggerNonUserCode]
		get
		{
			return _Onlyhasdrw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Onlyhasdrw = value;
		}
	}

	[DebuggerNonUserCode]
	public FrmSelType2()
	{
		base.Load += FrmSelType2_Load;
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
		this.TYPE_SLDASM = new System.Windows.Forms.CheckBox();
		this.TYPE_SLDPRT = new System.Windows.Forms.CheckBox();
		this.TYPE_SLDDRW = new System.Windows.Forms.CheckBox();
		this.Includesubfolders = new System.Windows.Forms.CheckBox();
		this.Onlyhasdrw = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel1.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(170, 74);
		tableLayoutPanel.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tableLayoutPanel2.Margin = margin;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(170, 35);
		tableLayoutPanel3.Size = size;
		this.TableLayoutPanel1.TabIndex = 2;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(3, 4);
		oK_Button.Location = location;
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		oK_Button2.Margin = margin;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button3 = this.OK_Button;
		size = new System.Drawing.Size(78, 27);
		oK_Button3.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "ОК";
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(88, 4);
		cancel_Button.Location = location;
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		cancel_Button2.Margin = margin;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button3 = this.Cancel_Button;
		size = new System.Drawing.Size(78, 27);
		cancel_Button3.Size = size;
		this.Cancel_Button.TabIndex = 1;
		this.Cancel_Button.Text = "Отмена";
		this.TYPE_SLDASM.AutoSize = true;
		System.Windows.Forms.CheckBox tYPE_SLDASM = this.TYPE_SLDASM;
		location = new System.Drawing.Point(12, 42);
		tYPE_SLDASM.Location = location;
		System.Windows.Forms.CheckBox tYPE_SLDASM2 = this.TYPE_SLDASM;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tYPE_SLDASM2.Margin = margin;
		this.TYPE_SLDASM.Name = "TYPE_SLDASM";
		System.Windows.Forms.CheckBox tYPE_SLDASM3 = this.TYPE_SLDASM;
		size = new System.Drawing.Size(139, 21);
		tYPE_SLDASM3.Size = size;
		this.TYPE_SLDASM.TabIndex = 3;
		this.TYPE_SLDASM.Tag = "*.SLDASM";
		this.TYPE_SLDASM.Text = "Сборка (.SLDASM)";
		this.TYPE_SLDASM.UseVisualStyleBackColor = true;
		this.TYPE_SLDPRT.AutoSize = true;
		System.Windows.Forms.CheckBox tYPE_SLDPRT = this.TYPE_SLDPRT;
		location = new System.Drawing.Point(12, 12);
		tYPE_SLDPRT.Location = location;
		System.Windows.Forms.CheckBox tYPE_SLDPRT2 = this.TYPE_SLDPRT;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tYPE_SLDPRT2.Margin = margin;
		this.TYPE_SLDPRT.Name = "TYPE_SLDPRT";
		System.Windows.Forms.CheckBox tYPE_SLDPRT3 = this.TYPE_SLDPRT;
		size = new System.Drawing.Size(122, 21);
		tYPE_SLDPRT3.Size = size;
		this.TYPE_SLDPRT.TabIndex = 4;
		this.TYPE_SLDPRT.Tag = "*.SLDPRT";
		this.TYPE_SLDPRT.Text = "Деталь (.SLDPRT)";
		this.TYPE_SLDPRT.UseVisualStyleBackColor = true;
		this.TYPE_SLDDRW.AutoSize = true;
		this.TYPE_SLDDRW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.TYPE_SLDDRW.Checked = true;
		this.TYPE_SLDDRW.CheckState = System.Windows.Forms.CheckState.Checked;
		this.TYPE_SLDDRW.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
		System.Windows.Forms.CheckBox tYPE_SLDDRW = this.TYPE_SLDDRW;
		location = new System.Drawing.Point(12, 71);
		tYPE_SLDDRW.Location = location;
		System.Windows.Forms.CheckBox tYPE_SLDDRW2 = this.TYPE_SLDDRW;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tYPE_SLDDRW2.Margin = margin;
		this.TYPE_SLDDRW.Name = "TYPE_SLDDRW";
		System.Windows.Forms.CheckBox tYPE_SLDDRW3 = this.TYPE_SLDDRW;
		size = new System.Drawing.Size(141, 21);
		tYPE_SLDDRW3.Size = size;
		this.TYPE_SLDDRW.TabIndex = 5;
		this.TYPE_SLDDRW.Tag = "*.SLDDRW";
		this.TYPE_SLDDRW.Text = "Чертёж (.SLDDRW)";
		this.TYPE_SLDDRW.UseVisualStyleBackColor = true;
		this.Includesubfolders.AutoSize = true;
		this.Includesubfolders.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.Includesubfolders.Checked = true;
		this.Includesubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
		this.Includesubfolders.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
		System.Windows.Forms.CheckBox includesubfolders = this.Includesubfolders;
		location = new System.Drawing.Point(200, 42);
		includesubfolders.Location = location;
		System.Windows.Forms.CheckBox includesubfolders2 = this.Includesubfolders;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		includesubfolders2.Margin = margin;
		this.Includesubfolders.Name = "Includesubfolders";
		System.Windows.Forms.CheckBox includesubfolders3 = this.Includesubfolders;
		size = new System.Drawing.Size(99, 21);
		includesubfolders3.Size = size;
		this.Includesubfolders.TabIndex = 5;
		this.Includesubfolders.Tag = "";
		this.Includesubfolders.Text = "Включая подпапки";
		this.Includesubfolders.UseVisualStyleBackColor = true;
		this.Onlyhasdrw.AutoSize = true;
		this.Onlyhasdrw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.Onlyhasdrw.Checked = true;
		this.Onlyhasdrw.CheckState = System.Windows.Forms.CheckState.Checked;
		this.Onlyhasdrw.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
		System.Windows.Forms.CheckBox onlyhasdrw = this.Onlyhasdrw;
		location = new System.Drawing.Point(200, 12);
		onlyhasdrw.Location = location;
		System.Windows.Forms.CheckBox onlyhasdrw2 = this.Onlyhasdrw;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		onlyhasdrw2.Margin = margin;
		this.Onlyhasdrw.Name = "Onlyhasdrw";
		System.Windows.Forms.CheckBox onlyhasdrw3 = this.Onlyhasdrw;
		size = new System.Drawing.Size(123, 21);
		onlyhasdrw3.Size = size;
		this.Onlyhasdrw.TabIndex = 5;
		this.Onlyhasdrw.Tag = "";
		this.Onlyhasdrw.Text = "Только элементы, имеющие чертежи";
		this.Onlyhasdrw.UseVisualStyleBackColor = true;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.Cancel_Button;
		size = new System.Drawing.Size(347, 113);
		this.ClientSize = size;
		this.Controls.Add(this.TableLayoutPanel1);
		this.Controls.Add(this.TYPE_SLDASM);
		this.Controls.Add(this.TYPE_SLDPRT);
		this.Controls.Add(this.Onlyhasdrw);
		this.Controls.Add(this.Includesubfolders);
		this.Controls.Add(this.TYPE_SLDDRW);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmSelType2";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Добавить файл";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.OK;
		Close();
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void FrmSelType2_Load(object sender, EventArgs e)
	{
		ControlBox = false;
		if (!TYPE_SLDASM.Checked & !TYPE_SLDPRT.Checked)
		{
			Onlyhasdrw.Enabled = false;
		}
		else
		{
			Onlyhasdrw.Enabled = true;
		}
	}

	private void TYPE_SLDPRT_CheckedChanged(object sender, EventArgs e)
	{
		if (!TYPE_SLDASM.Checked & !TYPE_SLDPRT.Checked)
		{
			Onlyhasdrw.Enabled = false;
		}
		else
		{
			Onlyhasdrw.Enabled = true;
		}
	}
}
