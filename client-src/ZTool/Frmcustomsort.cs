using System;
using System.Collections;
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
public class Frmcustomsort : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("Cancel_Button")]
	private Button _Cancel_Button;

	[AccessedThroughProperty("ComboBox2")]
	private ComboBox _ComboBox2;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("RadioButton3")]
	private RadioButton _RadioButton3;

	[AccessedThroughProperty("RadioButton4")]
	private RadioButton _RadioButton4;

	private List<string> ColList1;

	private List<string> ColList2;

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
			EventHandler value2 = ComboBox1_SelectedIndexChanged;
			if (_ComboBox1 != null)
			{
				_ComboBox1.SelectedIndexChanged -= value2;
			}
			_ComboBox1 = value;
			if (_ComboBox1 != null)
			{
				_ComboBox1.SelectedIndexChanged += value2;
			}
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
			EventHandler value2 = ComboBox1_SelectedIndexChanged;
			if (_ComboBox2 != null)
			{
				_ComboBox2.SelectedIndexChanged -= value2;
			}
			_ComboBox2 = value;
			if (_ComboBox2 != null)
			{
				_ComboBox2.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox1 = value;
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

	internal virtual GroupBox GroupBox2
	{
		[DebuggerNonUserCode]
		get
		{
			return _GroupBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_GroupBox2 = value;
		}
	}

	internal virtual RadioButton RadioButton3
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_RadioButton3 = value;
		}
	}

	internal virtual RadioButton RadioButton4
	{
		[DebuggerNonUserCode]
		get
		{
			return _RadioButton4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_RadioButton4 = value;
		}
	}

	public Frmcustomsort()
	{
		base.KeyPress += FrmCopy_KeyPress;
		base.Load += FrmCopy_load;
		base.FormClosed += Frmsort_FormClosed;
		__ENCAddToList(this);
		ColList1 = new List<string>();
		ColList2 = new List<string>();
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
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Cancel_Button = new System.Windows.Forms.Button();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.RadioButton3 = new System.Windows.Forms.RadioButton();
		this.RadioButton4 = new System.Windows.Forms.RadioButton();
		this.TableLayoutPanel2.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.SuspendLayout();
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.ComboBox1.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox = this.ComboBox1;
		System.Drawing.Point location = new System.Drawing.Point(12, 24);
		comboBox.Location = location;
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox1;
		System.Windows.Forms.Padding margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		comboBox2.Margin = margin;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox3 = this.ComboBox1;
		System.Drawing.Size size = new System.Drawing.Size(270, 25);
		comboBox3.Size = size;
		this.ComboBox1.TabIndex = 7;
		this.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel2.AutoSize = true;
		this.TableLayoutPanel2.ColumnCount = 2;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99751f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00249f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23f));
		this.TableLayoutPanel2.Controls.Add(this.OK_Button, 0, 0);
		this.TableLayoutPanel2.Controls.Add(this.Cancel_Button, 1, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel2;
		location = new System.Drawing.Point(284, 161);
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
		location = new System.Drawing.Point(13, 4);
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
		this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Cancel_Button.AutoSize = true;
		System.Windows.Forms.Button cancel_Button = this.Cancel_Button;
		location = new System.Drawing.Point(118, 4);
		cancel_Button.Location = location;
		System.Windows.Forms.Button cancel_Button2 = this.Cancel_Button;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		cancel_Button2.Margin = margin;
		this.Cancel_Button.Name = "Cancel_Button";
		System.Windows.Forms.Button cancel_Button3 = this.Cancel_Button;
		size = new System.Drawing.Size(78, 27);
		cancel_Button3.Size = size;
		this.Cancel_Button.TabIndex = 3;
		this.Cancel_Button.Text = "Отмена";
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.ComboBox2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.ComboBox2.FormattingEnabled = true;
		this.ComboBox2.ItemHeight = 17;
		System.Windows.Forms.ComboBox comboBox4 = this.ComboBox2;
		location = new System.Drawing.Point(12, 24);
		comboBox4.Location = location;
		System.Windows.Forms.ComboBox comboBox5 = this.ComboBox2;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		comboBox5.Margin = margin;
		this.ComboBox2.MaxDropDownItems = 20;
		this.ComboBox2.Name = "ComboBox2";
		System.Windows.Forms.ComboBox comboBox6 = this.ComboBox2;
		size = new System.Drawing.Size(270, 25);
		comboBox6.Size = size;
		this.ComboBox2.TabIndex = 8;
		this.GroupBox1.Controls.Add(this.RadioButton1);
		this.GroupBox1.Controls.Add(this.RadioButton2);
		this.GroupBox1.Controls.Add(this.ComboBox1);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(16, 8);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(478, 72);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 12;
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Text = "Сначала сортировать по";
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		this.RadioButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton1;
		location = new System.Drawing.Point(308, 16);
		radioButton.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton1;
		size = new System.Drawing.Size(145, 21);
		radioButton2.Size = size;
		this.RadioButton1.TabIndex = 4;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "По возрастанию";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.RadioButton2.AutoSize = true;
		this.RadioButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton2;
		location = new System.Drawing.Point(308, 42);
		radioButton3.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton2;
		size = new System.Drawing.Size(145, 21);
		radioButton4.Size = size;
		this.RadioButton2.TabIndex = 4;
		this.RadioButton2.Text = "По убыванию";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.GroupBox2.Controls.Add(this.RadioButton3);
		this.GroupBox2.Controls.Add(this.RadioButton4);
		this.GroupBox2.Controls.Add(this.ComboBox2);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(16, 84);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(478, 72);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 12;
		this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox2.Text = "Затем сортировать по";
		this.RadioButton3.AutoSize = true;
		this.RadioButton3.Checked = true;
		this.RadioButton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.RadioButton radioButton5 = this.RadioButton3;
		location = new System.Drawing.Point(308, 16);
		radioButton5.Location = location;
		this.RadioButton3.Name = "RadioButton3";
		System.Windows.Forms.RadioButton radioButton6 = this.RadioButton3;
		size = new System.Drawing.Size(145, 21);
		radioButton6.Size = size;
		this.RadioButton3.TabIndex = 4;
		this.RadioButton3.TabStop = true;
		this.RadioButton3.Text = "По возрастанию";
		this.RadioButton3.UseVisualStyleBackColor = true;
		this.RadioButton4.AutoSize = true;
		this.RadioButton4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		System.Windows.Forms.RadioButton radioButton7 = this.RadioButton4;
		location = new System.Drawing.Point(308, 42);
		radioButton7.Location = location;
		this.RadioButton4.Name = "RadioButton4";
		System.Windows.Forms.RadioButton radioButton8 = this.RadioButton4;
		size = new System.Drawing.Size(145, 21);
		radioButton8.Size = size;
		this.RadioButton4.TabIndex = 4;
		this.RadioButton4.Text = "По убыванию";
		this.RadioButton4.UseVisualStyleBackColor = true;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(511, 204);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.TableLayoutPanel2);
		this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
		this.KeyPreview = true;
		margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.Margin = margin;
		this.MaximizeBox = true;
		this.MinimumSize = new System.Drawing.Size(535, 250);
		this.Name = "Frmcustomsort";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Пользовательская сортировка";
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel2.PerformLayout();
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox1.PerformLayout();
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox2.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				SortOrder sortOrder = SortOrder.Ascending;
				SortOrder sortOrder2 = SortOrder.Ascending;
				if (RadioButton1.Checked)
				{
					sortOrder = SortOrder.Ascending;
				}
				else if (RadioButton2.Checked)
				{
					sortOrder = SortOrder.Descending;
				}
				if (RadioButton3.Checked)
				{
					sortOrder2 = SortOrder.Ascending;
				}
				else if (RadioButton4.Checked)
				{
					sortOrder2 = SortOrder.Descending;
				}
				string text = "";
				string text2 = "";
				if (ComboBox1.SelectedIndex >= 1)
				{
					text = ColList1[ComboBox1.SelectedIndex - 1];
				}
				if (ComboBox2.SelectedIndex >= 1)
				{
					text2 = ColList2[ComboBox2.SelectedIndex - 1];
				}
				if ((Operators.CompareString(text, "", TextCompare: false) != 0 || Operators.CompareString(text2, "", TextCompare: false) != 0) && 0 == 0)
				{
					MyProject.Forms.Frmmain.DGV1.Focus();
					MyProject.Forms.Frmmain.DGV1.Sort(new DataGridViewRowComparer(text, sortOrder, text2, sortOrder2));
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

	private void FrmCopy_load(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				ComboBox1.Items.Clear();
				ComboBox2.Items.Clear();
				ColList1.Clear();
				ColList2.Clear();
				ComboBox1.Items.Add("");
				ComboBox2.Items.Add("");
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
					string name = MyProject.Forms.Frmmain.DGV1.Columns[num2].Name;
					string text = "";
					if (num2 == MyProject.Forms.Frmmain.Col_Extname.Index)
					{
						text = "Тип файла";
					}
					else if (num2 == MyProject.Forms.Frmmain.Col_Drw.Index)
					{
						text = "Наличие чертежа";
					}
					else
					{
						if (num2 == MyProject.Forms.Frmmain.Col_Preview.Index || ((num2 == MyProject.Forms.Frmmain.Col_Checkbox.Index) ? true : false))
						{
							goto IL_01bf;
						}
						text = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
					}
					if (MyProject.Forms.Frmmain.DGV1.Columns[num2].Visible)
					{
						ComboBox1.Items.Add(text);
						ColList1.Add(name);
						ComboBox2.Items.Add(text);
						ColList2.Add(name);
					}
					goto IL_01bf;
					IL_01bf:
					num2++;
				}
				Loadcfg();
				if (ComboBox1.SelectedIndex == -1)
				{
					string headerText = MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.DGV1.CurrentCell.ColumnIndex].HeaderText;
					ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(headerText);
				}
				if (ComboBox2.SelectedIndex == -1)
				{
					string headerText2 = MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_FileName.Name].HeaderText;
					ComboBox2.SelectedIndex = ComboBox2.Items.IndexOf(headerText2);
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

	private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		ComboBox comboBox = (ComboBox)sender;
		if (comboBox.SelectedIndex == 0)
		{
			comboBox.SelectedIndex = -1;
		}
	}

	private void Cancel_Button_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Frmsort_FormClosed(object sender, FormClosedEventArgs e)
	{
		Savecfg();
	}

	private void FrmCopy_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void Savecfg()
	{
		CConfigMng.Config.frmsortcfg.Clear();
		foreach (Control control in Controls)
		{
			FindctlToSave(control);
		}
		CConfigMng.SaveConfig();
	}

	private void FindctlToSave(Control parent)
	{
		foreach (Control control in parent.Controls)
		{
			if (control is CheckBox)
			{
				CConfigMng.Config.frmsortcfg.Add(control.Name + "\n" + Conversions.ToString(((CheckBox)control).Checked));
			}
			else if (control is TextBox)
			{
				CConfigMng.Config.frmsortcfg.Add(control.Name + "\n" + ((TextBox)control).Text);
			}
			else if (control is ComboBox)
			{
				CConfigMng.Config.frmsortcfg.Add(control.Name + "\n" + Conversions.ToString(((ComboBox)control).SelectedIndex));
			}
			else if (control is RadioButton)
			{
				CConfigMng.Config.frmsortcfg.Add(control.Name + "\n" + Conversions.ToString(((RadioButton)control).Checked));
			}
			if (control.HasChildren)
			{
				FindctlToSave(control);
			}
		}
	}

	private void Loadcfg()
	{
		foreach (Control control in Controls)
		{
			FindctlToLoad(control);
		}
	}

	private void FindctlToLoad(Control parent)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		Control control = default(Control);
		string[] array = default(string[]);
		IEnumerator enumerator = default(IEnumerator);
		int num5 = default(int);
		int num6 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					int num7;
					int num8;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000a;
					case 579:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_000a;
							case 3:
								goto IL_002a;
							case 4:
								goto IL_0047;
							case 5:
								goto IL_0067;
							case 7:
							case 8:
								goto IL_0081;
							case 9:
								goto IL_009f;
							case 10:
								goto IL_00b2;
							case 12:
								goto IL_00cf;
							case 13:
								goto IL_00e2;
							case 15:
								goto IL_00f7;
							case 16:
								goto IL_010a;
							case 18:
								goto IL_012a;
							case 19:
								goto IL_013d;
							case 6:
							case 11:
							case 14:
							case 17:
							case 20:
							case 21:
							case 22:
								goto IL_0157;
							case 23:
								goto IL_016c;
							case 24:
								goto IL_017c;
							case 25:
							case 26:
								goto IL_0189;
							default:
								goto end_IL_0001;
							case 27:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_00e2:
						num2 = 13;
						((TextBox)control).Text = array[1];
						goto IL_0157;
						IL_00f7:
						num2 = 15;
						if (control is ComboBox)
						{
							goto IL_010a;
						}
						goto IL_012a;
						IL_00cf:
						num2 = 12;
						if (control is TextBox)
						{
							goto IL_00e2;
						}
						goto IL_00f7;
						IL_010a:
						num2 = 16;
						((ComboBox)control).SelectedIndex = (int)Math.Round(Conversion.Val(array[1]));
						goto IL_0157;
						IL_000a:
						num2 = 2;
						enumerator = parent.Controls.GetEnumerator();
						goto IL_018e;
						IL_018e:
						if (enumerator.MoveNext())
						{
							control = (Control)enumerator.Current;
							goto IL_002a;
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						goto end_IL_0001_2;
						IL_012a:
						num2 = 18;
						if (control is RadioButton)
						{
							goto IL_013d;
						}
						goto IL_0157;
						IL_0157:
						num2 = 22;
						num5++;
						goto IL_0160;
						IL_013d:
						num2 = 19;
						((RadioButton)control).Checked = code.Cbool1(array[1]);
						goto IL_0157;
						IL_002a:
						num2 = 3;
						num6 = CConfigMng.Config.frmsortcfg.Count - 1;
						num5 = 0;
						goto IL_0160;
						IL_0160:
						num7 = num5;
						num8 = num6;
						if (num7 <= num8)
						{
							goto IL_0047;
						}
						goto IL_016c;
						IL_016c:
						num2 = 23;
						if (control.HasChildren)
						{
							goto IL_017c;
						}
						goto IL_0189;
						IL_017c:
						num2 = 24;
						FindctlToLoad(control);
						goto IL_0189;
						IL_0189:
						num2 = 26;
						goto IL_018e;
						IL_0047:
						num2 = 4;
						array = Strings.Split(CConfigMng.Config.frmsortcfg[num5], "\n");
						goto IL_0067;
						IL_0067:
						num2 = 5;
						if (array.Count() == 2)
						{
							goto IL_0081;
						}
						goto IL_0157;
						IL_0081:
						num2 = 8;
						if (Operators.CompareString(control.Name, array[0], TextCompare: false) == 0)
						{
							goto IL_009f;
						}
						goto IL_0157;
						IL_009f:
						num2 = 9;
						if (control is CheckBox)
						{
							goto IL_00b2;
						}
						goto IL_00cf;
						IL_00b2:
						num2 = 10;
						((CheckBox)control).Checked = code.Cbool1(array[1]);
						goto IL_0157;
						end_IL_0001:
						break;
					}
				}
			}
			catch (Exception obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 579;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_2:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}
}
