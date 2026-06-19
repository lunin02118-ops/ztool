using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class Frmsymbol : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[DebuggerNonUserCode]
	public Frmsymbol()
	{
		base.KeyPress += Frmsymbol_KeyPress;
		base.Load += Frmsymbol_Load;
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
		this.SuspendLayout();
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.White;
		System.Drawing.Size clientSize = new System.Drawing.Size(309, 161);
		this.ClientSize = clientSize;
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "Frmsymbol";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Символ";
		this.ResumeLayout(false);
		this.AutoScroll = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.MaximizeBox = true;
		this.MinimizeBox = true;
		this.MinimumSize = new System.Drawing.Size(309, 161);
	}

	private void Frmsymbol_Load(object sender, EventArgs e)
	{
		int num = 5;
		int num2 = 5;
		int num3 = 0;
		Graphics graphics = Graphics.FromHwnd(Handle);
		double num4 = graphics.DpiX / 96f;
		Controls.Clear();
		string expression = "°,℃,℉,%,‰,≤,≥,《,》,≈,≠,±,×,÷,∠,＃,ø,§,@,＆,￡,∮,$,:,Α,Β,Γ,Δ,Ε,Ζ,Η,Θ,Ι,Κ,Λ,Μ,Ν,Ξ,Ο,Π,Ρ,Σ,Τ,Υ,Φ,Χ,Ψ,Ω,α,β,γ,δ,ε,ζ,ν,ξ,ο,π,ρ,σ,η,θ,ι,κ,λ,μ,τ,υ,φ,χ,ψ,ω";
		string[] array = Strings.Split(expression, ",");
		checked
		{
			int num5 = array.Count() - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num8 = num5;
				if (num7 <= num8)
				{
					Label label = new Label();
					label.BackColor = Color.White;
					label.Left = num2;
					label.Top = num;
					label.Name = "btn";
					label.Font = Font;
					Size size = new Size((int)Math.Round(25.0 * num4), (int)Math.Round(25.0 * num4));
					label.Size = size;
					label.TextAlign = ContentAlignment.MiddleCenter;
					label.BorderStyle = BorderStyle.None;
					label.FlatStyle = FlatStyle.Flat;
					label.TabIndex = 1;
					label.Text = array[num6];
					label.MouseDown += btn_MouseDown;
					label.MouseUp += btn_MouseUp;
					label.MouseEnter += btn_MouseEnter;
					label.MouseLeave += btn_MouseLeave;
					num3++;
					if (num3 == 12)
					{
						num += label.Height;
						num2 = 5;
						num3 = 0;
					}
					else
					{
						num2 += label.Width;
					}
					Controls.Add(label);
					num6++;
					continue;
				}
				break;
			}
		}
	}

	private void btn_MouseDown(object sender, EventArgs e)
	{
		try
		{
			((Label)sender).BackColor = Color.FromArgb(135, 206, 255);
			if (!MyProject.Forms.Frmmain.DGV1.CurrentCell.ReadOnly)
			{
				TextBox textBox = (TextBox)MyProject.Forms.Frmmain.DGV1.EditingControl;
				string text = textBox.Text;
				string text2 = ((Label)sender).Text;
				textBox.Focus();
				int selectionStart = textBox.SelectionStart;
				if (textBox.SelectionLength > 0)
				{
					text = Strings.Replace(text, textBox.SelectedText, text2);
					MyProject.Forms.Frmmain.DGV1.CurrentCell.Value = text;
				}
				else
				{
					text = text.Insert(selectionStart, text2);
					textBox.Text = text;
				}
				textBox.SelectionStart = checked(selectionStart + 1);
				textBox.SelectionLength = 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void btn_MouseUp(object sender, EventArgs e)
	{
		((Label)sender).BackColor = Color.FromArgb(202, 225, 255);
	}

	private void btn_MouseEnter(object sender, EventArgs e)
	{
		((Label)sender).BackColor = Color.FromArgb(202, 225, 255);
	}

	private void btn_MouseLeave(object sender, EventArgs e)
	{
		((Label)sender).BackColor = Color.White;
	}

	private void Frmsymbol_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}
}
