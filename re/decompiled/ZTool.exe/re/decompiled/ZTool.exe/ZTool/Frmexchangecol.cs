using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class Frmexchangecol : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Undo_Button")]
	private Button _Undo_Button;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("ComboBox2")]
	private ComboBox _ComboBox2;

	private List<int> ColList1;

	private List<int> ColList2;

	private List<DataGridViewCell> CellArr;

	private List<string> CellValArr;

	private List<Color> CellColorArr;

	private List<DataGridViewRow> RowArr;

	private List<bool> Ismodifylist;

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

	internal virtual ComboBox ComboBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox1 = value;
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

	internal virtual Button Undo_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _Undo_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = Undo_Button_Click;
			if (_Undo_Button != null)
			{
				_Undo_Button.Click -= value2;
			}
			_Undo_Button = value;
			if (_Undo_Button != null)
			{
				_Undo_Button.Click += value2;
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

	internal virtual ComboBox ComboBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _ComboBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_ComboBox2 = value;
		}
	}

	public Frmexchangecol()
	{
		base.Activated += FrmCopy_Activated;
		base.KeyPress += FrmCopy_KeyPress;
		__ENCAddToList(this);
		ColList1 = new List<int>();
		ColList2 = new List<int>();
		CellArr = new List<DataGridViewCell>();
		CellValArr = new List<string>();
		CellColorArr = new List<Color>();
		RowArr = new List<DataGridViewRow>();
		Ismodifylist = new List<bool>();
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
		this.Label1 = new System.Windows.Forms.Label();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Undo_Button = new System.Windows.Forms.Button();
		this.Label2 = new System.Windows.Forms.Label();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.TableLayoutPanel2.SuspendLayout();
		this.SuspendLayout();
		this.Label1.AutoSize = true;
		System.Windows.Forms.Label label = this.Label1;
		System.Drawing.Point location = new System.Drawing.Point(8, 16);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		System.Drawing.Size size = new System.Drawing.Size(56, 17);
		label2.Size = size;
		this.Label1.TabIndex = 10;
		this.Label1.Text = "Первый столбец:";
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox1.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox = this.ComboBox1;
		location = new System.Drawing.Point(77, 10);
		comboBox.Location = location;
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		comboBox2.Margin = margin;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox3 = this.ComboBox1;
		size = new System.Drawing.Size(186, 25);
		comboBox3.Size = size;
		this.ComboBox1.TabIndex = 7;
		this.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel2.AutoSize = true;
		this.TableLayoutPanel2.ColumnCount = 2;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99751f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00249f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23f));
		this.TableLayoutPanel2.Controls.Add(this.OK_Button, 1, 0);
		this.TableLayoutPanel2.Controls.Add(this.Undo_Button, 0, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel2;
		location = new System.Drawing.Point(65, 89);
		tableLayoutPanel.Location = location;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		tableLayoutPanel2.Margin = margin;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = this.TableLayoutPanel2;
		size = new System.Drawing.Size(210, 35);
		tableLayoutPanel3.Size = size;
		this.TableLayoutPanel2.TabIndex = 1;
		this.TableLayoutPanel2.TabStop = true;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(118, 4);
		oK_Button.Location = location;
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		oK_Button2.Margin = margin;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button3 = this.OK_Button;
		size = new System.Drawing.Size(78, 27);
		oK_Button3.Size = size;
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "ОК";
		this.Undo_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Undo_Button.AutoSize = true;
		System.Windows.Forms.Button undo_Button = this.Undo_Button;
		location = new System.Drawing.Point(13, 4);
		undo_Button.Location = location;
		System.Windows.Forms.Button undo_Button2 = this.Undo_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		undo_Button2.Margin = margin;
		this.Undo_Button.Name = "Undo_Button";
		System.Windows.Forms.Button undo_Button3 = this.Undo_Button;
		size = new System.Drawing.Size(78, 27);
		undo_Button3.Size = size;
		this.Undo_Button.TabIndex = 3;
		this.Undo_Button.Text = "Отменить";
		this.Label2.AutoSize = true;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(8, 52);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(56, 17);
		label4.Size = size;
		this.Label2.TabIndex = 11;
		this.Label2.Text = "Второй столбец:";
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.ComboBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox2.FormattingEnabled = true;
		this.ComboBox2.ItemHeight = 17;
		System.Windows.Forms.ComboBox comboBox4 = this.ComboBox2;
		location = new System.Drawing.Point(77, 48);
		comboBox4.Location = location;
		System.Windows.Forms.ComboBox comboBox5 = this.ComboBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		comboBox5.Margin = margin;
		this.ComboBox2.MaxDropDownItems = 20;
		this.ComboBox2.Name = "ComboBox2";
		System.Windows.Forms.ComboBox comboBox6 = this.ComboBox2;
		size = new System.Drawing.Size(186, 25);
		comboBox6.Size = size;
		this.ComboBox2.TabIndex = 8;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(278, 126);
		this.ClientSize = size;
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.ComboBox1);
		this.Controls.Add(this.TableLayoutPanel2);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.ComboBox2);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.Margin = margin;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "Frmexchangecol";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Поменять столбцы местами";
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel2.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
		this.AutoScroll = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.MaximizeBox = true;
		this.MinimizeBox = true;
		this.MinimumSize = new System.Drawing.Size(278, 126);
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				int num = 0;
				int num2 = ColList1[ComboBox1.SelectedIndex];
				int num3 = ColList2[ComboBox2.SelectedIndex];
				if (num2 == num3)
				{
					return;
				}
				RowArr.Clear();
				Ismodifylist.Clear();
				int num4 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num5 = 0;
				while (true)
				{
					int num6 = num5;
					int num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					if (MyProject.Forms.Frmmain.DGV1.Rows[num5].Visible)
					{
						RowArr.Add(MyProject.Forms.Frmmain.DGV1.Rows[num5]);
						Ismodifylist.Add(Conversions.ToBoolean(MyProject.Forms.Frmmain.DGV1.Rows[num5].Tag));
						string text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num2, num5].Value);
						string text2 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num3, num5].Value);
						string text3 = "";
						text3 = text;
						if (Operators.CompareString(text, text2, TextCompare: false) != 0)
						{
							if (num == 0)
							{
								CellArr.Clear();
								CellValArr.Clear();
								CellColorArr.Clear();
							}
							num++;
							CellArr.Add(MyProject.Forms.Frmmain.DGV1[num2, num5]);
							CellValArr.Add(text);
							CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[num2, num5].Style.ForeColor);
							CellArr.Add(MyProject.Forms.Frmmain.DGV1[num3, num5]);
							CellValArr.Add(text2);
							CellColorArr.Add(MyProject.Forms.Frmmain.DGV1[num3, num5].Style.ForeColor);
							MyProject.Forms.Frmmain.DGV1[num2, num5].Value = text2;
							MyProject.Forms.Frmmain.DGV1[num3, num5].Value = text;
						}
					}
					num5++;
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

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void FrmCopy_Activated(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				ComboBox1.Items.Clear();
				ComboBox2.Items.Clear();
				ColList1.Clear();
				ColList2.Clear();
				int num = MyProject.Forms.Frmmain.DGV1.ColumnCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
					if (MyProject.Forms.Frmmain.DGV1.Columns[num2].Visible & !MyProject.Forms.Frmmain.DGV1.Columns[num2].ReadOnly & (num2 != MyProject.Forms.Frmmain.Col_FileName.Index))
					{
						ComboBox1.Items.Add(headerText);
						ColList1.Add(num2);
						ComboBox2.Items.Add(headerText);
						ColList2.Add(num2);
					}
					num2++;
				}
				string headerText2 = MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.DGV1.CurrentCell.ColumnIndex].HeaderText;
				ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(headerText2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void Undo_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = CellArr.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				CellArr[num2].Value = CellValArr[num2];
				CellArr[num2].Style.ForeColor = CellColorArr[num2];
				num2++;
			}
			int num5 = RowArr.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 <= num4)
				{
					RowArr[num6].Tag = Ismodifylist[num6].ToString();
					num6++;
					continue;
				}
				break;
			}
		}
	}

	private void FrmCopy_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}
}
