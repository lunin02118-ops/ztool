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
public class FrmAsk : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("YES_Button")]
	private Button _YES_Button;

	[AccessedThroughProperty("NO_Button")]
	private Button _NO_Button;

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

	internal virtual Button YES_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _YES_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = YES_Button_Click;
			if (_YES_Button != null)
			{
				_YES_Button.Click -= value2;
			}
			_YES_Button = value;
			if (_YES_Button != null)
			{
				_YES_Button.Click += value2;
			}
		}
	}

	internal virtual Button NO_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _NO_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = NO_Button_Click;
			if (_NO_Button != null)
			{
				_NO_Button.Click -= value2;
			}
			_NO_Button = value;
			if (_NO_Button != null)
			{
				_NO_Button.Click += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	public FrmAsk()
	{
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
		this.YES_Button = new System.Windows.Forms.Button();
		this.NO_Button = new System.Windows.Forms.Button();
		this.TableLayoutPanel1.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.YES_Button, 0, 0);
		this.TableLayoutPanel1.Controls.Add(this.NO_Button, 1, 0);
		this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		tableLayoutPanel.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
		tableLayoutPanel2.Margin = margin;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(354, 146);
		tableLayoutPanel3.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.YES_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.YES_Button.DialogResult = System.Windows.Forms.DialogResult.Yes;
		System.Windows.Forms.Button yES_Button = this.YES_Button;
		location = new System.Drawing.Point(21, 41);
		yES_Button.Location = location;
		System.Windows.Forms.Button yES_Button2 = this.YES_Button;
		margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
		yES_Button2.Margin = margin;
		this.YES_Button.Name = "YES_Button";
		System.Windows.Forms.Button yES_Button3 = this.YES_Button;
		size = new System.Drawing.Size(134, 64);
		yES_Button3.Size = size;
		this.YES_Button.TabIndex = 0;
		this.YES_Button.Text = "Продолжить задачу";
		this.NO_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.NO_Button.DialogResult = System.Windows.Forms.DialogResult.No;
		System.Windows.Forms.Button nO_Button = this.NO_Button;
		location = new System.Drawing.Point(198, 41);
		nO_Button.Location = location;
		System.Windows.Forms.Button nO_Button2 = this.NO_Button;
		margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
		nO_Button2.Margin = margin;
		this.NO_Button.Name = "NO_Button";
		System.Windows.Forms.Button nO_Button3 = this.NO_Button;
		size = new System.Drawing.Size(134, 64);
		nO_Button3.Size = size;
		this.NO_Button.TabIndex = 1;
		this.NO_Button.Text = "Начать заново";
		this.AcceptButton = this.YES_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(192f, 192f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.CancelButton = this.NO_Button;
		size = new System.Drawing.Size(354, 146);
		this.ClientSize = size;
		this.ControlBox = false;
		this.Controls.Add(this.TableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
		this.Margin = margin;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmAsk";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Выберите";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.ResumeLayout(false);
		this.AutoScroll = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.MaximizeBox = true;
		this.MinimizeBox = true;
		this.MinimumSize = new System.Drawing.Size(354, 146);
	}

	private void YES_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Yes;
		Close();
	}

	private void NO_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.No;
		Close();
	}
}
