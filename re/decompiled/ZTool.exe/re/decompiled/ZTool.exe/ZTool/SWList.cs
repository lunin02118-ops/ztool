using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[DesignerGenerated]
public class SWList : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("IDlist")]
	private ListBox _IDlist;

	[AccessedThroughProperty("Titlelist")]
	private ListBox _Titlelist;

	internal virtual ListBox IDlist
	{
		[DebuggerNonUserCode]
		get
		{
			return _IDlist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_IDlist = value;
		}
	}

	internal virtual ListBox Titlelist
	{
		[DebuggerNonUserCode]
		get
		{
			return _Titlelist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			MouseEventHandler value2 = Titlelist_MouseDoubleClick;
			if (_Titlelist != null)
			{
				_Titlelist.MouseDoubleClick -= value2;
			}
			_Titlelist = value;
			if (_Titlelist != null)
			{
				_Titlelist.MouseDoubleClick += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	public SWList()
	{
		base.FormClosed += SWList_FormClosed;
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
		this.IDlist = new System.Windows.Forms.ListBox();
		this.Titlelist = new System.Windows.Forms.ListBox();
		this.SuspendLayout();
		this.IDlist.FormattingEnabled = true;
		this.IDlist.ItemHeight = 17;
		System.Windows.Forms.ListBox iDlist = this.IDlist;
		System.Drawing.Point location = new System.Drawing.Point(306, 24);
		iDlist.Location = location;
		System.Windows.Forms.ListBox iDlist2 = this.IDlist;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(6);
		iDlist2.Margin = margin;
		this.IDlist.Name = "IDlist";
		System.Windows.Forms.ListBox iDlist3 = this.IDlist;
		System.Drawing.Size size = new System.Drawing.Size(70, 21);
		iDlist3.Size = size;
		this.IDlist.TabIndex = 2;
		this.IDlist.Visible = false;
		this.Titlelist.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.Titlelist.Dock = System.Windows.Forms.DockStyle.Fill;
		this.Titlelist.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f);
		this.Titlelist.FormattingEnabled = true;
		this.Titlelist.ItemHeight = 17;
		System.Windows.Forms.ListBox titlelist = this.Titlelist;
		location = new System.Drawing.Point(0, 0);
		titlelist.Location = location;
		System.Windows.Forms.ListBox titlelist2 = this.Titlelist;
		margin = new System.Windows.Forms.Padding(6);
		titlelist2.Margin = margin;
		this.Titlelist.Name = "Titlelist";
		System.Windows.Forms.ListBox titlelist3 = this.Titlelist;
		size = new System.Drawing.Size(399, 134);
		titlelist3.Size = size;
		this.Titlelist.TabIndex = 3;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.Window;
		size = new System.Drawing.Size(399, 134);
		this.ClientSize = size;
		this.Controls.Add(this.Titlelist);
		this.Controls.Add(this.IDlist);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		margin = new System.Windows.Forms.Padding(6);
		this.Margin = margin;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "SWList";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Двойной щелчок — выбрать процесс SolidWorks для подключения";
		this.ResumeLayout(false);
	}

	private void Titlelist_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		try
		{
			code.CurSWID = Conversions.ToInteger(IDlist.Items[Titlelist.SelectedIndex]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		Close();
	}

	private void SWList_FormClosed(object sender, FormClosedEventArgs e)
	{
		try
		{
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(Titlelist.SelectedItem)))
			{
				code.CurSWID = Conversions.ToInteger(IDlist.Items[0]);
			}
			else
			{
				code.CurSWID = Conversions.ToInteger(IDlist.Items[Titlelist.SelectedIndex]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
