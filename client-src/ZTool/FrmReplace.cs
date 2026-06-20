using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My;

namespace ZTool;

[DesignerGenerated]
public class FrmReplace : Form
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel _TableLayoutPanel2;

	[AccessedThroughProperty("OKAll_Button")]
	private Button _OKAll_Button;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("TextBox2")]
	private TextBox _TextBox2;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[AccessedThroughProperty("Undo_Button")]
	private Button _Undo_Button;

	[AccessedThroughProperty("LookUp_Next")]
	private Button _LookUp_Next;

	private List<int> ColList;

	private List<DataGridViewCell> CellArr;

	private List<string> CellValArr;

	private List<Color> CellColorArr;

	private List<DataGridViewRow> RowArr;

	private List<bool> Ismodifylist;

	private List<string> finshlist;

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

	internal virtual Button OKAll_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _OKAll_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OKAll_Button_Click;
			if (_OKAll_Button != null)
			{
				_OKAll_Button.Click -= value2;
			}
			_OKAll_Button = value;
			if (_OKAll_Button != null)
			{
				_OKAll_Button.Click += value2;
			}
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
			EventHandler value2 = LookUp_Next_Click;
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

	internal virtual CheckBox CheckBox1
	{
		[DebuggerNonUserCode]
		get
		{
			return _CheckBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_CheckBox1 = value;
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

	internal virtual Button LookUp_Next
	{
		[DebuggerNonUserCode]
		get
		{
			return _LookUp_Next;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = LookUp_Next_Click;
			if (_LookUp_Next != null)
			{
				_LookUp_Next.Click -= value2;
			}
			_LookUp_Next = value;
			if (_LookUp_Next != null)
			{
				_LookUp_Next.Click += value2;
			}
		}
	}

	public FrmReplace()
	{
		base.KeyPress += FrmReplace_KeyPress;
		base.Activated += FrmReplace_Activated;
		__ENCAddToList(this);
		ColList = new List<int>();
		CellArr = new List<DataGridViewCell>();
		CellValArr = new List<string>();
		CellColorArr = new List<Color>();
		RowArr = new List<DataGridViewRow>();
		Ismodifylist = new List<bool>();
		finshlist = new List<string>();
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
		this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.LookUp_Next = new System.Windows.Forms.Button();
		this.OK_Button = new System.Windows.Forms.Button();
		this.Undo_Button = new System.Windows.Forms.Button();
		this.OKAll_Button = new System.Windows.Forms.Button();
		this.TextBox2 = new System.Windows.Forms.TextBox();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.TableLayoutPanel2.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel2.AutoSize = true;
		this.TableLayoutPanel2.ColumnCount = 4;
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
		this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
		this.TableLayoutPanel2.Controls.Add(this.LookUp_Next, 3, 0);
		this.TableLayoutPanel2.Controls.Add(this.OK_Button, 2, 0);
		this.TableLayoutPanel2.Controls.Add(this.Undo_Button, 0, 0);
		this.TableLayoutPanel2.Controls.Add(this.OKAll_Button, 1, 0);
		this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel2;
		System.Drawing.Point location = new System.Drawing.Point(0, 139);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel2.Name = "TableLayoutPanel2";
		this.TableLayoutPanel2.RowCount = 1;
		this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel2;
		System.Drawing.Size size = new System.Drawing.Size(356, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel2.TabIndex = 0;
		this.TableLayoutPanel2.TabStop = true;
		this.LookUp_Next.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.LookUp_Next.AutoSize = true;
		this.LookUp_Next.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		System.Windows.Forms.Button lookUp_Next = this.LookUp_Next;
		location = new System.Drawing.Point(270, 3);
		lookUp_Next.Location = location;
		this.LookUp_Next.Name = "LookUp_Next";
		System.Windows.Forms.Button lookUp_Next2 = this.LookUp_Next;
		size = new System.Drawing.Size(83, 27);
		lookUp_Next2.Size = size;
		this.LookUp_Next.TabIndex = 0;
		this.LookUp_Next.Text = "Найти далее";
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(185, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(75, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 1;
		this.OK_Button.Text = "Заменить";
		this.Undo_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.Undo_Button.AutoSize = true;
		System.Windows.Forms.Button undo_Button = this.Undo_Button;
		location = new System.Drawing.Point(7, 3);
		undo_Button.Location = location;
		this.Undo_Button.Name = "Undo_Button";
		System.Windows.Forms.Button undo_Button2 = this.Undo_Button;
		size = new System.Drawing.Size(75, 27);
		undo_Button2.Size = size;
		this.Undo_Button.TabIndex = 3;
		this.Undo_Button.Text = "Отменить";
		this.OKAll_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OKAll_Button.AutoSize = true;
		System.Windows.Forms.Button oKAll_Button = this.OKAll_Button;
		location = new System.Drawing.Point(92, 3);
		oKAll_Button.Location = location;
		this.OKAll_Button.Name = "OKAll_Button";
		System.Windows.Forms.Button oKAll_Button2 = this.OKAll_Button;
		size = new System.Drawing.Size(83, 27);
		oKAll_Button2.Size = size;
		this.OKAll_Button.TabIndex = 2;
		this.OKAll_Button.Text = "Заменить всё";
		this.TextBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.TextBox textBox = this.TextBox2;
		location = new System.Drawing.Point(83, 80);
		textBox.Location = location;
		this.TextBox2.Name = "TextBox2";
		System.Windows.Forms.TextBox textBox2 = this.TextBox2;
		size = new System.Drawing.Size(261, 23);
		textBox2.Size = size;
		this.TextBox2.TabIndex = 3;
		this.TextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.TextBox textBox3 = this.TextBox1;
		location = new System.Drawing.Point(83, 48);
		textBox3.Location = location;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox4 = this.TextBox1;
		size = new System.Drawing.Size(261, 23);
		textBox4.Size = size;
		this.TextBox1.TabIndex = 2;
		this.Label3.AutoSize = true;
		this.Label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label = this.Label3;
		location = new System.Drawing.Point(21, 84);
		label.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label2 = this.Label3;
		size = new System.Drawing.Size(56, 17);
		label2.Size = size;
		this.Label3.TabIndex = 8;
		this.Label3.Text = "Заменить на:";
		this.Label2.AutoSize = true;
		this.Label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(9, 52);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(68, 17);
		label4.Size = size;
		this.Label2.TabIndex = 9;
		this.Label2.Text = "Найти:";
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label5 = this.Label1;
		location = new System.Drawing.Point(9, 20);
		label5.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label6 = this.Label1;
		size = new System.Drawing.Size(68, 17);
		label6.Size = size;
		this.Label1.TabIndex = 10;
		this.Label1.Text = "Диапазон поиска:";
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox1.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox = this.ComboBox1;
		location = new System.Drawing.Point(83, 16);
		comboBox.Location = location;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox1;
		size = new System.Drawing.Size(261, 25);
		comboBox2.Size = size;
		this.ComboBox1.TabIndex = 1;
		this.CheckBox1.AutoSize = true;
		this.CheckBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.CheckBox checkBox = this.CheckBox1;
		location = new System.Drawing.Point(83, 112);
		checkBox.Location = location;
		this.CheckBox1.Name = "CheckBox1";
		System.Windows.Forms.CheckBox checkBox2 = this.CheckBox1;
		size = new System.Drawing.Size(87, 21);
		checkBox2.Size = size;
		this.CheckBox1.TabIndex = 4;
		this.CheckBox1.Text = "Учитывать регистр";
		this.CheckBox1.UseVisualStyleBackColor = true;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(356, 172);
		this.ClientSize = size;
		this.Controls.Add(this.CheckBox1);
		this.Controls.Add(this.TableLayoutPanel2);
		this.Controls.Add(this.TextBox2);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.ComboBox1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmReplace";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Поиск и замена";
		this.TableLayoutPanel2.ResumeLayout(false);
		this.TableLayoutPanel2.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	private void FrmReplace_Activated(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				ComboBox1.Items.Clear();
				ColList.Clear();
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
					if (MyProject.Forms.Frmmain.DGV1.Columns[num2].Visible)
					{
						string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
						if (!MyProject.Forms.Frmmain.DGV1.Columns[num2].ReadOnly)
						{
							ComboBox1.Items.Add(headerText);
							ColList.Add(num2);
						}
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

	private void OKAll_Button_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				if (Operators.CompareString(TextBox1.Text, "", TextCompare: false) == 0)
				{
					return;
				}
				int num = 0;
				int num2 = ColList[ComboBox1.SelectedIndex];
				RowArr.Clear();
				Ismodifylist.Clear();
				finshlist.Clear();
				code.EnablePreview = false;
				code.EnadleMarkrepeat = false;
				code.checkfilename = false;
				Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
				int num3 = 0;
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
					string text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num2, num5].Value);
					string text2 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num5].Value);
					Color foreColor = MyProject.Forms.Frmmain.DGV1[num2, num5].Style.ForeColor;
					string key = text + code.SplitStr(text2, 5);
					string key2 = code.SplitStr(text2, 4);
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, text2);
					}
					if (!dictionary.ContainsKey(key2))
					{
						dictionary.Add(key2, text2);
					}
					if (MyProject.Forms.Frmmain.DGV1.Rows[num5].Visible && Strings.InStr(text, TextBox1.Text, unchecked((CompareMethod)Conversions.ToInteger(Conversion.Int(!CheckBox1.Checked)))) > 0)
					{
						RowArr.Add(MyProject.Forms.Frmmain.DGV1.Rows[num5]);
						Ismodifylist.Add(Conversions.ToBoolean(MyProject.Forms.Frmmain.DGV1.Rows[num5].Tag));
						if (num == 0)
						{
							CellArr.Clear();
							CellValArr.Clear();
							CellColorArr.Clear();
						}
						num++;
						CellArr.Add(MyProject.Forms.Frmmain.DGV1[num2, num5]);
						CellValArr.Add(text);
						CellColorArr.Add(foreColor);
					}
					num5++;
				}
				int num8 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num9 = 0;
				while (true)
				{
					int num10 = num9;
					int num7 = num8;
					if (num10 > num7)
					{
						break;
					}
					bool flag = false;
					string text3 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[num2, num9].Value);
					string text4 = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num9].Value);
					int num11 = Conversions.ToInteger(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Number.Index, num9].Value);
					Color foreColor2 = MyProject.Forms.Frmmain.DGV1[num2, num9].Style.ForeColor;
					if (MyProject.Forms.Frmmain.DGV1.Rows[num9].Visible && Strings.InStr(text3, TextBox1.Text, unchecked((CompareMethod)Conversions.ToInteger(Conversion.Int(!CheckBox1.Checked)))) > 0)
					{
						bool flag2 = false;
						int num12 = finshlist.Count - 1;
						int num13 = 0;
						while (true)
						{
							int num14 = num13;
							num7 = num12;
							if (num14 > num7)
							{
								break;
							}
							if (finshlist.Contains(text4))
							{
								flag2 = true;
								break;
							}
							num13++;
						}
						if (!flag2)
						{
							string text5 = Strings.Replace(text3, _TextBox1.Text, TextBox2.Text, 1, -1, unchecked((CompareMethod)Conversions.ToInteger(Conversion.Int(!CheckBox1.Checked))));
							if (num2 == MyProject.Forms.Frmmain.Col_FileName.Index)
							{
								string value = "";
								string key3 = text5 + code.SplitStr(text4, 5);
								if ((dictionary.TryGetValue(key3, out value) && !string.Equals(value, text4, StringComparison.OrdinalIgnoreCase)) ? true : false)
								{
									num3++;
									MyProject.Forms.Frmtips.additem(0, Conversions.ToString(num11), "文件名重复", "Поиск и замена", text4);
									goto IL_0550;
								}
								if (!dictionary.ContainsKey(key3))
								{
									dictionary.Add(key3, text4);
								}
							}
							MyProject.Forms.Frmmain.DGV1[num2, num9].Value = text5;
							finshlist.Add(text4);
						}
					}
					goto IL_0550;
					IL_0550:
					num9++;
				}
				if (num == 0)
				{
					MessageBox.Show(MyProject.Forms.Frmmain, "未找到字符\"" + TextBox1.Text + "\"", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show(MyProject.Forms.Frmmain, "Замена завершена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				if (num3 > 0)
				{
					MessageBox.Show(this, "有 " + Conversions.ToString(num3) + " элементов не заменено из-за повторяющихся имён файлов", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(MyProject.Forms.Frmmain, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				code.EnablePreview = true;
				code.EnadleMarkrepeat = false;
				code.checkfilename = false;
			}
		}
	}

	private void LookUp_Next_Click(object sender, EventArgs e)
	{
		try
		{
			if (Operators.CompareString(((Button)sender).Name, OK_Button.Name, TextCompare: false) == 0)
			{
				bool flag = false;
				string text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1.CurrentCell.Value);
				Color foreColor = MyProject.Forms.Frmmain.DGV1.CurrentCell.Style.ForeColor;
				if (!MyProject.Forms.Frmmain.DGV1.CurrentCell.ReadOnly)
				{
					if (Strings.InStr(text, TextBox1.Text, (CompareMethod)Conversions.ToInteger(Conversion.Int(!CheckBox1.Checked))) > 0)
					{
						MyProject.Forms.Frmmain.DGV1.CurrentCell.Value = Strings.Replace(text, TextBox1.Text, TextBox2.Text, 1, -1, (CompareMethod)Conversions.ToInteger(Conversion.Int(!CheckBox1.Checked)));
						CellArr.Clear();
						CellValArr.Clear();
						CellColorArr.Clear();
						CellArr.Add(MyProject.Forms.Frmmain.DGV1.CurrentCell);
						CellValArr.Add(text);
						CellColorArr.Add(foreColor);
						LookUp(ReplaceOK: true);
					}
					else
					{
						LookUp();
					}
				}
			}
			else if (Operators.CompareString(((Button)sender).Name, LookUp_Next.Name, TextCompare: false) == 0)
			{
				LookUp();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void LookUp(bool ReplaceOK = false)
	{
		checked
		{
			try
			{
				if (MyProject.Forms.Frmmain.DGV1.RowCount == 0)
				{
					return;
				}
				List<int> list = new List<int>();
				int columnIndex = ColList[ComboBox1.SelectedIndex];
				int num = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if (MyProject.Forms.Frmmain.DGV1.Rows[num2].Visible && Strings.InStr(MyProject.Forms.Frmmain.DGV1[columnIndex, num2].Value.ToString(), TextBox1.Text, unchecked((CompareMethod)Conversions.ToInteger(Conversion.Int(!CheckBox1.Checked)))) > 0)
					{
						list.Add(num2);
					}
					num2++;
				}
				if (list.Count == 0)
				{
					if (!ReplaceOK)
					{
						MessageBox.Show(MyProject.Forms.Frmmain, "未找到字符\"" + TextBox1.Text + "\"", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (list[list.Count - 1] > MyProject.Forms.Frmmain.DGV1.CurrentRow.Index)
				{
					int num5 = list.Count - 1;
					int num6 = 0;
					while (true)
					{
						int num7 = num6;
						int num4 = num5;
						if (num7 <= num4)
						{
							if (list[num6] > MyProject.Forms.Frmmain.DGV1.CurrentRow.Index)
							{
								MyProject.Forms.Frmmain.DGV1.CurrentCell = null;
								MyProject.Forms.Frmmain.DGV1.CurrentCell = MyProject.Forms.Frmmain.DGV1[columnIndex, list[num6]];
								MyProject.Forms.Frmmain.DGV1.BeginEdit(selectAll: true);
								break;
							}
							num6++;
							continue;
						}
						break;
					}
				}
				else
				{
					MyProject.Forms.Frmmain.DGV1.CurrentCell = null;
					MyProject.Forms.Frmmain.DGV1.CurrentCell = MyProject.Forms.Frmmain.DGV1[columnIndex, list[0]];
					MyProject.Forms.Frmmain.DGV1.BeginEdit(selectAll: true);
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

	private void Undo_Button_Click(object sender, EventArgs e)
	{
		if (CellValArr.Count == 0)
		{
			return;
		}
		code.EnablePreview = false;
		code.EnadleCellEvent = false;
		MyProject.Forms.Frmmain.Focus();
		checked
		{
			try
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
					if (CellArr.Count == 1)
					{
						MyProject.Forms.Frmmain.DGV1.CurrentCell = CellArr[num2];
					}
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			code.EnablePreview = true;
			code.EnadleCellEvent = true;
		}
	}

	private void FrmReplace_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}
}
