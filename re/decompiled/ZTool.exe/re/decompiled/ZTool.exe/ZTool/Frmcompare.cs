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
public class Frmcompare : Form
{
	[CompilerGenerated]
	internal class _Closure_0024__75
	{
		public int _0024VB_0024Local_rownumber;

		[DebuggerNonUserCode]
		public _Closure_0024__75(_Closure_0024__75 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_rownumber = other._0024VB_0024Local_rownumber;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__75()
		{
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__76
	{
		public int _0024VB_0024Local_rownumber;

		[DebuggerNonUserCode]
		public _Closure_0024__76(_Closure_0024__76 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_rownumber = other._0024VB_0024Local_rownumber;
			}
		}

		[DebuggerNonUserCode]
		public _Closure_0024__76()
		{
		}
	}

	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private IContainer components;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel _TableLayoutPanel1;

	[AccessedThroughProperty("OK_Button")]
	private Button _OK_Button;

	[AccessedThroughProperty("ComboBox1")]
	private ComboBox _ComboBox1;

	[AccessedThroughProperty("ComboBox2")]
	private ComboBox _ComboBox2;

	[AccessedThroughProperty("RadioButton1")]
	private RadioButton _RadioButton1;

	[AccessedThroughProperty("RadioButton2")]
	private RadioButton _RadioButton2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("All_Button")]
	private Button _All_Button;

	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[AccessedThroughProperty("StatusStrip1")]
	private StatusStrip _StatusStrip1;

	[AccessedThroughProperty("count")]
	private ToolStripStatusLabel _count;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("ListView1")]
	private ListViewVR _ListView1;

	private List<int> ColList1;

	private List<int> ColList2;

	private double dpixRatio;

	private Size mediumsize;

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
			EventHandler value2 = ComboBox2_SelectedIndexChanged;
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
			EventHandler value2 = ComboBox2_SelectedIndexChanged;
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

	internal virtual Button All_Button
	{
		[DebuggerNonUserCode]
		get
		{
			return _All_Button;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			EventHandler value2 = OK_Button_Click;
			if (_All_Button != null)
			{
				_All_Button.Click -= value2;
			}
			_All_Button = value;
			if (_All_Button != null)
			{
				_All_Button.Click += value2;
			}
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

	internal virtual StatusStrip StatusStrip1
	{
		[DebuggerNonUserCode]
		get
		{
			return _StatusStrip1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_StatusStrip1 = value;
		}
	}

	internal virtual ToolStripStatusLabel count
	{
		[DebuggerNonUserCode]
		get
		{
			return _count;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_count = value;
		}
	}

	internal virtual Panel Panel1
	{
		[DebuggerNonUserCode]
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			_Panel1 = value;
		}
	}

	internal virtual ListViewVR ListView1
	{
		[DebuggerNonUserCode]
		get
		{
			return _ListView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[DebuggerNonUserCode]
		set
		{
			ListViewVirtualItemsSelectionRangeChangedEventHandler value2 = ListView1_VirtualItemsSelectionRangeChanged;
			ListViewItemSelectionChangedEventHandler value3 = ListView1_ItemSelectionChanged;
			if (_ListView1 != null)
			{
				_ListView1.VirtualItemsSelectionRangeChanged -= value2;
				_ListView1.ItemSelectionChanged -= value3;
			}
			_ListView1 = value;
			if (_ListView1 != null)
			{
				_ListView1.VirtualItemsSelectionRangeChanged += value2;
				_ListView1.ItemSelectionChanged += value3;
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
		this.All_Button = new System.Windows.Forms.Button();
		this.ComboBox1 = new System.Windows.Forms.ComboBox();
		this.ComboBox2 = new System.Windows.Forms.ComboBox();
		this.RadioButton1 = new System.Windows.Forms.RadioButton();
		this.RadioButton2 = new System.Windows.Forms.RadioButton();
		this.Label1 = new System.Windows.Forms.Label();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.count = new System.Windows.Forms.ToolStripStatusLabel();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.ListView1 = new ZTool.ListViewVR();
		this.TableLayoutPanel1.SuspendLayout();
		this.StatusStrip1.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.SuspendLayout();
		this.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.TableLayoutPanel1.AutoSize = true;
		this.TableLayoutPanel1.ColumnCount = 2;
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.TableLayoutPanel1.Controls.Add(this.OK_Button, 1, 0);
		this.TableLayoutPanel1.Controls.Add(this.All_Button, 0, 0);
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel = this.TableLayoutPanel1;
		System.Drawing.Point location = new System.Drawing.Point(160, 104);
		tableLayoutPanel.Location = location;
		this.TableLayoutPanel1.Name = "TableLayoutPanel1";
		this.TableLayoutPanel1.RowCount = 1;
		this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = this.TableLayoutPanel1;
		System.Drawing.Size size = new System.Drawing.Size(214, 33);
		tableLayoutPanel2.Size = size;
		this.TableLayoutPanel1.TabIndex = 0;
		this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.OK_Button.AutoSize = true;
		System.Windows.Forms.Button oK_Button = this.OK_Button;
		location = new System.Drawing.Point(116, 3);
		oK_Button.Location = location;
		this.OK_Button.Name = "OK_Button";
		System.Windows.Forms.Button oK_Button2 = this.OK_Button;
		size = new System.Drawing.Size(89, 27);
		oK_Button2.Size = size;
		this.OK_Button.TabIndex = 0;
		this.OK_Button.Text = "Найти далее";
		this.All_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.All_Button.AutoSize = true;
		System.Windows.Forms.Button all_Button = this.All_Button;
		location = new System.Drawing.Point(9, 3);
		all_Button.Location = location;
		this.All_Button.Name = "All_Button";
		System.Windows.Forms.Button all_Button2 = this.All_Button;
		size = new System.Drawing.Size(89, 27);
		all_Button2.Size = size;
		this.All_Button.TabIndex = 0;
		this.All_Button.Text = "Найти все";
		this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.ComboBox1.FormattingEnabled = true;
		System.Windows.Forms.ComboBox comboBox = this.ComboBox1;
		location = new System.Drawing.Point(16, 16);
		comboBox.Location = location;
		this.ComboBox1.Name = "ComboBox1";
		System.Windows.Forms.ComboBox comboBox2 = this.ComboBox1;
		size = new System.Drawing.Size(160, 25);
		comboBox2.Size = size;
		this.ComboBox1.TabIndex = 13;
		this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.ComboBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.ComboBox2.FormattingEnabled = true;
		this.ComboBox2.ItemHeight = 17;
		System.Windows.Forms.ComboBox comboBox3 = this.ComboBox2;
		location = new System.Drawing.Point(220, 16);
		comboBox3.Location = location;
		this.ComboBox2.MaxDropDownItems = 20;
		this.ComboBox2.Name = "ComboBox2";
		System.Windows.Forms.ComboBox comboBox4 = this.ComboBox2;
		size = new System.Drawing.Size(160, 25);
		comboBox4.Size = size;
		this.ComboBox2.TabIndex = 14;
		this.RadioButton1.AutoSize = true;
		this.RadioButton1.Checked = true;
		System.Windows.Forms.RadioButton radioButton = this.RadioButton1;
		location = new System.Drawing.Point(16, 56);
		radioButton.Location = location;
		this.RadioButton1.Name = "RadioButton1";
		System.Windows.Forms.RadioButton radioButton2 = this.RadioButton1;
		size = new System.Drawing.Size(62, 21);
		radioButton2.Size = size;
		this.RadioButton1.TabIndex = 15;
		this.RadioButton1.TabStop = true;
		this.RadioButton1.Text = "Найти отличия";
		this.RadioButton1.UseVisualStyleBackColor = true;
		this.RadioButton2.AutoSize = true;
		System.Windows.Forms.RadioButton radioButton3 = this.RadioButton2;
		location = new System.Drawing.Point(16, 80);
		radioButton3.Location = location;
		this.RadioButton2.Name = "RadioButton2";
		System.Windows.Forms.RadioButton radioButton4 = this.RadioButton2;
		size = new System.Drawing.Size(62, 21);
		radioButton4.Size = size;
		this.RadioButton2.TabIndex = 15;
		this.RadioButton2.Text = "Найти совпадения";
		this.RadioButton2.UseVisualStyleBackColor = true;
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(185, 18);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(26, 20);
		label2.Size = size;
		this.Label1.TabIndex = 16;
		this.Label1.Text = "VS";
		this.CheckBox1.AutoSize = true;
		System.Windows.Forms.CheckBox checkBox = this.CheckBox1;
		location = new System.Drawing.Point(120, 56);
		checkBox.Location = location;
		this.CheckBox1.Name = "CheckBox1";
		System.Windows.Forms.CheckBox checkBox2 = this.CheckBox1;
		size = new System.Drawing.Size(87, 21);
		checkBox2.Size = size;
		this.CheckBox1.TabIndex = 17;
		this.CheckBox1.Text = "Учитывать регистр";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.StatusStrip1.AutoSize = false;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.count });
		System.Windows.Forms.StatusStrip statusStrip = this.StatusStrip1;
		location = new System.Drawing.Point(0, 119);
		statusStrip.Location = location;
		this.StatusStrip1.Name = "StatusStrip1";
		System.Windows.Forms.StatusStrip statusStrip2 = this.StatusStrip1;
		size = new System.Drawing.Size(388, 22);
		statusStrip2.Size = size;
		this.StatusStrip1.TabIndex = 19;
		this.StatusStrip1.Text = "StatusStrip1";
		this.count.Name = "count";
		System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel = this.count;
		size = new System.Drawing.Size(0, 17);
		toolStripStatusLabel.Size = size;
		this.Panel1.Controls.Add(this.TableLayoutPanel1);
		this.Panel1.Controls.Add(this.ComboBox2);
		this.Panel1.Controls.Add(this.ComboBox1);
		this.Panel1.Controls.Add(this.CheckBox1);
		this.Panel1.Controls.Add(this.RadioButton1);
		this.Panel1.Controls.Add(this.Label1);
		this.Panel1.Controls.Add(this.RadioButton2);
		this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
		System.Windows.Forms.Panel panel = this.Panel1;
		location = new System.Drawing.Point(0, 0);
		panel.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel2 = this.Panel1;
		size = new System.Drawing.Size(388, 144);
		panel2.Size = size;
		this.Panel1.TabIndex = 20;
		this.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
		this.ListView1.AllowDrop = true;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		ZTool.ListViewVR listView = this.ListView1;
		location = new System.Drawing.Point(0, 144);
		listView.Location = location;
		this.ListView1.Name = "ListView1";
		ZTool.ListViewVR listView2 = this.ListView1;
		size = new System.Drawing.Size(388, 0);
		listView2.Size = size;
		this.ListView1.TabIndex = 21;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.VirtualMode = true;
		this.AcceptButton = this.OK_Button;
		System.Drawing.SizeF sizeF = new System.Drawing.SizeF(96f, 96f);
		this.AutoScaleDimensions = sizeF;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		size = new System.Drawing.Size(388, 141);
		this.ClientSize = size;
		this.Controls.Add(this.ListView1);
		this.Controls.Add(this.Panel1);
		this.Controls.Add(this.StatusStrip1);
		this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		this.KeyPreview = true;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		size = new System.Drawing.Size(404, 180);
		this.MinimumSize = size;
		this.Name = "Frmcompare";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Сравнение данных столбцов";
		this.TableLayoutPanel1.ResumeLayout(false);
		this.TableLayoutPanel1.PerformLayout();
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.ResumeLayout(false);
	}

	private void OK_Button_Click(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		checked
		{
			try
			{
				MyProject.Forms.Frmmain.Focus();
				if (MyProject.Forms.Frmmain.DGV1.RowCount == 0 || ComboBox1.SelectedIndex < 0 || ComboBox2.SelectedIndex < 0)
				{
					return;
				}
				int num = ColList1[ComboBox1.SelectedIndex];
				int num2 = ColList2[ComboBox2.SelectedIndex];
				List<int> list = new List<int>();
				StringComparison stringComparison = default(StringComparison);
				stringComparison = ((!CheckBox1.Checked) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
				int num3 = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num4 = 0;
				while (true)
				{
					int num5 = num4;
					int num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					if (MyProject.Forms.Frmmain.DGV1.Rows[num4].Visible)
					{
						string text = Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num, num4].Value));
						string value = Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num2, num4].Value));
						if (((RadioButton1.Checked && !text.Equals(value, stringComparison)) || (!RadioButton1.Checked && text.Equals(value, stringComparison))) ? true : false)
						{
							list.Add(num4);
						}
					}
					num4++;
				}
				if (button.Equals(All_Button))
				{
					ListView1.Clear();
					ListView1.DelAllItems();
					string headerText = MyProject.Forms.Frmmain.DGV1.Columns[num].HeaderText;
					string headerText2 = MyProject.Forms.Frmmain.DGV1.Columns[num2].HeaderText;
					int num7 = (int)Math.Round(50.0 * dpixRatio);
					int num8 = (int)Math.Round(250.0 * dpixRatio);
					int num9 = (int)Math.Round(200.0 * dpixRatio);
					ListView1.Columns.Add("Номер", num7, HorizontalAlignment.Left);
					ListView1.Columns.Add(headerText, num8, HorizontalAlignment.Left);
					ListView1.Columns.Add(headerText2, num9, HorizontalAlignment.Left);
				}
				if (list.Count == 0)
				{
					MessageBox.Show(MyProject.Forms.Frmmain, "Совпадающих элементов не найдено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					if (button.Equals(All_Button))
					{
						count.Text = Conversions.ToString(list.Count) + " элементов найдено";
					}
					return;
				}
				if (button.Equals(All_Button))
				{
					List<ListViewItem> list2 = new List<ListViewItem>();
					int num10 = list.Count - 1;
					int num11 = 0;
					while (true)
					{
						int num12 = num11;
						int num6 = num10;
						if (num12 > num6)
						{
							break;
						}
						string text2 = Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num, list[num11]].Value));
						string text3 = Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[num2, list[num11]].Value));
						ListViewItem listViewItem = new ListViewItem();
						listViewItem.SubItems[0].Text = Convert.ToString(RuntimeHelpers.GetObjectValue(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Number.Index, list[num11]].Value));
						listViewItem.SubItems.Add(text2);
						listViewItem.SubItems.Add(text3);
						list2.Add(listViewItem);
						num11++;
					}
					ListView1.AddData(list2);
					if (Height < mediumsize.Height)
					{
						Size = mediumsize;
					}
					count.Text = Conversions.ToString(list.Count) + " элементов найдено";
					if ((!Information.IsNothing(MyProject.Forms.Frmmain.DGV1[num, list[0]]) && MyProject.Forms.Frmmain.DGV1[num, list[0]].Visible) ? true : false)
					{
						MyProject.Forms.Frmmain.DGV1.CurrentCell = MyProject.Forms.Frmmain.DGV1[num, list[0]];
					}
					return;
				}
				int num13 = 0;
				if (!Information.IsNothing(MyProject.Forms.Frmmain.DGV1.CurrentRow))
				{
					num13 = MyProject.Forms.Frmmain.DGV1.CurrentRow.Index;
				}
				if (list[list.Count - 1] > num13)
				{
					int num14 = list.Count - 1;
					int num15 = 0;
					while (true)
					{
						int num16 = num15;
						int num6 = num14;
						if (num16 <= num6)
						{
							if ((list[num15] > num13 && !Information.IsNothing(MyProject.Forms.Frmmain.DGV1[num, list[num15]]) && MyProject.Forms.Frmmain.DGV1[num, list[num15]].Visible) ? true : false)
							{
								MyProject.Forms.Frmmain.DGV1.CurrentCell = MyProject.Forms.Frmmain.DGV1[num, list[num15]];
								break;
							}
							num15++;
							continue;
						}
						break;
					}
				}
				else if ((!Information.IsNothing(MyProject.Forms.Frmmain.DGV1[num, list[0]]) && MyProject.Forms.Frmmain.DGV1[num, list[0]].Visible) ? true : false)
				{
					MyProject.Forms.Frmmain.DGV1.CurrentCell = MyProject.Forms.Frmmain.DGV1[num, list[0]];
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void loadview(List<string> f)
	{
		List<string> list = new List<string>();
		ListViewVR listView = ListView1;
		checked
		{
			int num = listView.Items.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				list.Add(listView.Items[num2].SubItems[2].Text);
				num2++;
			}
			listView = null;
			int num5 = f.Count - 1;
			int num6 = 0;
			while (true)
			{
				int num7 = num6;
				int num4 = num5;
				if (num7 > num4)
				{
					break;
				}
				if (!list.Contains(f[num6]))
				{
					list.Add(f[num6]);
				}
				num6++;
			}
			if (list.Count == 0)
			{
				return;
			}
			List<ListViewItem> list2 = new List<ListViewItem>();
			int num8 = list.Count - 1;
			int num9 = 0;
			while (true)
			{
				int num10 = num9;
				int num4 = num8;
				if (num10 > num4)
				{
					break;
				}
				ListViewItem listViewItem = new ListViewItem();
				listViewItem.SubItems[0].Text = Conversions.ToString(num9 + 1);
				listViewItem.SubItems.Add(code.SplitStr(list[num9], 4));
				listViewItem.SubItems.Add(list[num9]);
				listViewItem.SubItems.Add("");
				list2.Add(listViewItem);
				num9++;
			}
			ListView1.AddData(list2);
		}
	}

	public Frmcompare()
	{
		base.Load += Frmcompare_Load;
		base.KeyPress += Frmcompare_KeyPress;
		__ENCAddToList(this);
		ColList1 = new List<int>();
		ColList2 = new List<int>();
		dpixRatio = 1.0;
		ref Size reference = ref mediumsize;
		reference = new Size(410, 360);
		InitializeComponent();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		checked
		{
			MinimumSize = (Size = new Size((int)Math.Round(410.0 * dpixRatio), (int)Math.Round(180.0 * dpixRatio)));
			ref Size reference2 = ref mediumsize;
			reference2 = new Size((int)Math.Round(410.0 * dpixRatio), (int)Math.Round(360.0 * dpixRatio));
		}
	}

	private void Frmcompare_Load(object sender, EventArgs e)
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
					if (MyProject.Forms.Frmmain.DGV1.Columns[num2].Visible & (num2 != MyProject.Forms.Frmmain.Col_Drw.Index) & (num2 != MyProject.Forms.Frmmain.Col_Extname.Index) & (num2 != MyProject.Forms.Frmmain.Col_Number.Index) & (num2 != MyProject.Forms.Frmmain.Col_Checkbox.Index) & (num2 != MyProject.Forms.Frmmain.Col_Preview.Index))
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

	private void Frmcompare_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\u001b')
		{
			Close();
		}
	}

	private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (ColList1[ComboBox1.SelectedIndex] == ColList2[ComboBox2.SelectedIndex])
			{
				MessageBox.Show(MyProject.Forms.Frmmain, "Выберите два разных столбца", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
	{
		checked
		{
			try
			{
				int num = ListView1.Items.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					ListView1.Items[num2].BackColor = SystemColors.Window;
					num2++;
				}
				MyProject.Forms.Frmmain.DGV1.ClearSelection();
				bool flag = false;
				_Closure_0024__75 closure_0024__ = default(_Closure_0024__75);
				foreach (object selectedIndex in ListView1.SelectedIndices)
				{
					int index = Conversions.ToInteger(selectedIndex);
					closure_0024__ = new _Closure_0024__75(closure_0024__);
					ListView1.Items[index].BackColor = SystemColors.MenuHighlight;
					closure_0024__._0024VB_0024Local_rownumber = Conversions.ToInteger(ListView1.Items[index].SubItems[0].Text);
					int columnIndex = ColList1[ComboBox1.SelectedIndex];
					DataGridViewRow dataGridViewRow = MyProject.Forms.Frmmain.DGV1.Rows.Cast<DataGridViewRow>().Where(closure_0024__._Lambda_0024__132).First();
					if ((!flag && MyProject.Forms.Frmmain.DGV1[columnIndex, dataGridViewRow.Index].Visible) ? true : false)
					{
						MyProject.Forms.Frmmain.DGV1.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
						flag = true;
					}
					dataGridViewRow.Selected = true;
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

	private void ListView1_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
	{
		try
		{
			MyProject.Forms.Frmmain.DGV1.ClearSelection();
			bool flag = false;
			_Closure_0024__76 closure_0024__ = default(_Closure_0024__76);
			foreach (object selectedIndex in ListView1.SelectedIndices)
			{
				int index = Conversions.ToInteger(selectedIndex);
				closure_0024__ = new _Closure_0024__76(closure_0024__);
				ListView1.Items[index].BackColor = SystemColors.MenuHighlight;
				closure_0024__._0024VB_0024Local_rownumber = Conversions.ToInteger(ListView1.Items[index].SubItems[0].Text);
				int columnIndex = ColList1[ComboBox1.SelectedIndex];
				DataGridViewRow dataGridViewRow = MyProject.Forms.Frmmain.DGV1.Rows.Cast<DataGridViewRow>().Where(closure_0024__._Lambda_0024__133).First();
				if ((!flag && !Information.IsNothing(dataGridViewRow) && MyProject.Forms.Frmmain.DGV1[columnIndex, dataGridViewRow.Index].Visible) ? true : false)
				{
					MyProject.Forms.Frmmain.DGV1.FirstDisplayedScrollingRowIndex = dataGridViewRow.Index;
					flag = true;
				}
				dataGridViewRow.Selected = true;
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
