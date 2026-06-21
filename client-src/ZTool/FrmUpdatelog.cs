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
public class FrmUpdatelog : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

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

	[DebuggerNonUserCode]
	public FrmUpdatelog()
	{
		base.KeyPress += FrmUpdatelog_KeyPress;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZTool.FrmUpdatelog));
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.SuspendLayout();
		this.TextBox1.BackColor = System.Drawing.Color.White;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.TextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.TextBox1.ForeColor = System.Drawing.Color.DimGray;
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		textBox.Location = location;
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(6);
		textBox2.Margin = margin;
		this.TextBox1.Multiline = true;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		System.Windows.Forms.TextBox textBox3 = this.TextBox1;
		System.Drawing.Size size = new System.Drawing.Size(384, 291);
		textBox3.Size = size;
		this.TextBox1.TabIndex = 0;
		this.TextBox1.TabStop = false;
		this.TextBox1.WordWrap = false;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(384, 291);
		this.ClientSize = size;
		this.Controls.Add(this.TextBox1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.Icon = ZTool.My.Resources.Resources.ztool_11;
		this.KeyPreview = true;
		margin = new System.Windows.Forms.Padding(6);
		this.Margin = margin;
		this.Name = "FrmUpdatelog";
		this.ShowInTaskbar = false;
		this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Журнал обновлений";
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

	private void FrmUpdatelog_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}
}
