using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.CustomFileBorser;

namespace ZTool;

[DesignerGenerated]
public class customsettings : Form
{
	private IContainer f_90;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel f_91;

	[AccessedThroughProperty("OK_Button")]
	private Button f_92;

	[AccessedThroughProperty("Cancel_Button")]
	private Button f_93;

	[AccessedThroughProperty("Button1")]
	private Button f_94;

	[AccessedThroughProperty("Button3")]
	private Button f_95;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox f_96;

	[AccessedThroughProperty("Button4")]
	private Button f_97;

	[AccessedThroughProperty("pathlist")]
	private ListBox f_98;

	[AccessedThroughProperty("Button6")]
	private Button f_99;

	[AccessedThroughProperty("Button5")]
	private Button f_100;

	[AccessedThroughProperty("SplitContainer1")]
	private SplitContainer f_101;

	[AccessedThroughProperty("DGV1")]
	private DataGridView f_102;

	[AccessedThroughProperty("Column4")]
	private DataGridViewCheckBoxColumn f_103;

	[AccessedThroughProperty("Column1")]
	private DataGridViewTextBoxColumn f_104;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox f_105;

	[AccessedThroughProperty("TableLayoutPanel2")]
	private TableLayoutPanel f_106;

	[AccessedThroughProperty("Label1")]
	private Label f_107;

	private List<Type_25> f_108;

	private bool f_109;

	private int f_110;

	private double f_111;

	private bool f_112;

	internal virtual TableLayoutPanel p_6
	{
		get
		{
			return f_91;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_91 = value;
		}
	}

	internal virtual Button p_7
	{
		get
		{
			return f_92;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_87;
			if (f_92 != null)
			{
				f_92.Click -= value2;
			}
			f_92 = value;
			if (f_92 != null)
			{
				f_92.Click += value2;
			}
		}
	}

	internal virtual Button p_8
	{
		get
		{
			return f_93;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_88;
			if (f_93 != null)
			{
				f_93.Click -= value2;
			}
			f_93 = value;
			if (f_93 != null)
			{
				f_93.Click += value2;
			}
		}
	}

	internal virtual Button p_9
	{
		get
		{
			return f_94;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_89;
			if (f_94 != null)
			{
				f_94.Click -= value2;
			}
			f_94 = value;
			if (f_94 != null)
			{
				f_94.Click += value2;
			}
		}
	}

	internal virtual Button p_10
	{
		get
		{
			return f_95;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_91;
			if (f_95 != null)
			{
				f_95.Click -= value2;
			}
			f_95 = value;
			if (f_95 != null)
			{
				f_95.Click += value2;
			}
		}
	}

	internal virtual GroupBox p_11
	{
		get
		{
			return f_96;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_96 = value;
		}
	}

	internal virtual Button p_12
	{
		get
		{
			return f_97;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_90;
			if (f_97 != null)
			{
				f_97.Click -= value2;
			}
			f_97 = value;
			if (f_97 != null)
			{
				f_97.Click += value2;
			}
		}
	}

	internal virtual ListBox p_13
	{
		get
		{
			return f_98;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_98 = value;
		}
	}

	internal virtual Button p_14
	{
		get
		{
			return f_99;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_93;
			if (f_99 != null)
			{
				f_99.Click -= value2;
			}
			f_99 = value;
			if (f_99 != null)
			{
				f_99.Click += value2;
			}
		}
	}

	internal virtual Button p_15
	{
		get
		{
			return f_100;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_92;
			if (f_100 != null)
			{
				f_100.Click -= value2;
			}
			f_100 = value;
			if (f_100 != null)
			{
				f_100.Click += value2;
			}
		}
	}

	internal virtual SplitContainer p_16
	{
		get
		{
			return f_101;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_101 = value;
		}
	}

	internal virtual DataGridView p_17
	{
		get
		{
			return f_102;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			DataGridViewCellEventHandler value2 = m_85;
			DataGridViewCellEventHandler value3 = m_86;
			if (f_102 != null)
			{
				f_102.CellEnter -= value2;
				f_102.CellValueChanged -= value3;
			}
			f_102 = value;
			if (f_102 != null)
			{
				f_102.CellEnter += value2;
				f_102.CellValueChanged += value3;
			}
		}
	}

	internal virtual DataGridViewCheckBoxColumn p_18
	{
		get
		{
			return f_103;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_103 = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn p_19
	{
		get
		{
			return f_104;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_104 = value;
		}
	}

	internal virtual GroupBox p_20
	{
		get
		{
			return f_105;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_105 = value;
		}
	}

	internal virtual TableLayoutPanel p_21
	{
		get
		{
			return f_106;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_106 = value;
		}
	}

	internal virtual Label p_22
	{
		get
		{
			return f_107;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_107 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && f_90 != null)
			{
				f_90.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m_83()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		p_6 = new TableLayoutPanel();
		p_7 = new Button();
		p_8 = new Button();
		p_9 = new Button();
		p_10 = new Button();
		p_11 = new GroupBox();
		p_21 = new TableLayoutPanel();
		p_12 = new Button();
		p_14 = new Button();
		p_15 = new Button();
		p_13 = new ListBox();
		p_22 = new Label();
		p_16 = new SplitContainer();
		p_20 = new GroupBox();
		p_17 = new DataGridView();
		p_18 = new DataGridViewCheckBoxColumn();
		p_19 = new DataGridViewTextBoxColumn();
		p_6.SuspendLayout();
		p_11.SuspendLayout();
		p_21.SuspendLayout();
		((ISupportInitialize)p_16).BeginInit();
		p_16.Panel1.SuspendLayout();
		p_16.Panel2.SuspendLayout();
		p_16.SuspendLayout();
		p_20.SuspendLayout();
		((ISupportInitialize)p_17).BeginInit();
		SuspendLayout();
		p_6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		p_6.AutoSize = true;
		p_6.ColumnCount = 2;
		p_6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.40884f));
		p_6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.59116f));
		p_6.Controls.Add(p_7, 1, 0);
		p_6.Controls.Add(p_8, 0, 0);
		TableLayoutPanel tableLayoutPanel = p_6;
		Point location = new Point(399, 301);
		tableLayoutPanel.Location = location;
		p_6.Name = "TableLayoutPanel1";
		p_6.RowCount = 1;
		p_6.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel tableLayoutPanel2 = p_6;
		Size size = new Size(181, 33);
		tableLayoutPanel2.Size = size;
		p_6.TabIndex = 0;
		p_7.Anchor = AnchorStyles.None;
		p_7.AutoSize = true;
		Button button = p_7;
		location = new Point(99, 3);
		button.Location = location;
		p_7.Name = "OK_Button";
		Button button2 = p_7;
		size = new Size(67, 27);
		button2.Size = size;
		p_7.TabIndex = 0;
		p_7.Text = "ОК";
		p_8.Anchor = AnchorStyles.None;
		p_8.AutoSize = true;
		p_8.DialogResult = DialogResult.Cancel;
		Button button3 = p_8;
		location = new Point(8, 3);
		button3.Location = location;
		p_8.Name = "Cancel_Button";
		Button button4 = p_8;
		size = new Size(67, 27);
		button4.Size = size;
		p_8.TabIndex = 1;
		p_8.Text = "Отмена";
		p_9.Anchor = AnchorStyles.None;
		p_9.AutoSize = true;
		Button button5 = p_9;
		location = new Point(8, 3);
		button5.Location = location;
		p_9.Name = "Button1";
		Button button6 = p_9;
		size = new Size(66, 27);
		button6.Size = size;
		p_9.TabIndex = 3;
		p_9.Text = "Добавить файл";
		p_9.UseVisualStyleBackColor = true;
		p_10.Anchor = AnchorStyles.None;
		p_10.AutoSize = true;
		Button button7 = p_10;
		location = new Point(90, 3);
		button7.Location = location;
		p_10.Name = "Button3";
		Button button8 = p_10;
		size = new Size(66, 27);
		button8.Size = size;
		p_10.TabIndex = 3;
		p_10.Text = "Добавить папку";
		p_10.UseVisualStyleBackColor = true;
		p_11.Controls.Add(p_13);
		p_11.Controls.Add(p_21);
		p_11.Controls.Add(p_22);
		p_11.Dock = DockStyle.Fill;
		GroupBox groupBox = p_11;
		location = new Point(3, 3);
		groupBox.Location = location;
		p_11.Name = "GroupBox1";
		GroupBox groupBox2 = p_11;
		Padding padding = new Padding(6);
		groupBox2.Padding = padding;
		GroupBox groupBox3 = p_11;
		size = new Size(388, 290);
		groupBox3.Size = size;
		p_11.TabIndex = 4;
		p_11.TabStop = false;
		p_11.Text = "Запуск меню";
		p_21.AutoSize = true;
		p_21.ColumnCount = 5;
		p_21.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22f));
		p_21.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22f));
		p_21.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22f));
		p_21.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17f));
		p_21.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17f));
		p_21.Controls.Add(p_9, 0, 0);
		p_21.Controls.Add(p_10, 1, 0);
		p_21.Controls.Add(p_12, 2, 0);
		p_21.Controls.Add(p_14, 4, 0);
		p_21.Controls.Add(p_15, 3, 0);
		p_21.Dock = DockStyle.Bottom;
		TableLayoutPanel tableLayoutPanel3 = p_21;
		location = new Point(6, 215);
		tableLayoutPanel3.Location = location;
		p_21.Name = "TableLayoutPanel2";
		p_21.RowCount = 1;
		p_21.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel tableLayoutPanel4 = p_21;
		size = new Size(376, 33);
		tableLayoutPanel4.Size = size;
		p_21.TabIndex = 7;
		p_12.Anchor = AnchorStyles.None;
		p_12.AutoSize = true;
		Button button9 = p_12;
		location = new Point(172, 3);
		button9.Location = location;
		p_12.Name = "Button4";
		Button button10 = p_12;
		size = new Size(66, 27);
		button10.Size = size;
		p_12.TabIndex = 3;
		p_12.Text = "Удалить выбранное";
		p_12.UseVisualStyleBackColor = true;
		p_14.Anchor = AnchorStyles.None;
		p_14.AutoSize = true;
		Button button11 = p_14;
		location = new Point(318, 3);
		button11.Location = location;
		p_14.Name = "Button6";
		Button button12 = p_14;
		size = new Size(48, 27);
		button12.Size = size;
		p_14.TabIndex = 3;
		p_14.Text = "Вниз";
		p_14.UseVisualStyleBackColor = true;
		p_15.Anchor = AnchorStyles.None;
		p_15.AutoSize = true;
		Button button13 = p_15;
		location = new Point(253, 3);
		button13.Location = location;
		p_15.Name = "Button5";
		Button button14 = p_15;
		size = new Size(48, 27);
		button14.Size = size;
		p_15.TabIndex = 3;
		p_15.Text = "Вверх";
		p_15.UseVisualStyleBackColor = true;
		p_13.Dock = DockStyle.Fill;
		p_13.HorizontalScrollbar = true;
		p_13.ItemHeight = 17;
		ListBox listBox = p_13;
		location = new Point(6, 22);
		listBox.Location = location;
		p_13.Name = "pathlist";
		p_13.ScrollAlwaysVisible = true;
		ListBox listBox2 = p_13;
		size = new Size(376, 193);
		listBox2.Size = size;
		p_13.TabIndex = 4;
		p_22.Dock = DockStyle.Bottom;
		p_22.ForeColor = Color.Green;
		Label label = p_22;
		location = new Point(6, 248);
		label.Location = location;
		p_22.Name = "Label1";
		Label label2 = p_22;
		size = new Size(376, 36);
		label2.Size = size;
		p_22.TabIndex = 6;
		p_22.Text = "Описание: поддерживает запуск макросов, открытие exe, excel, URL, ярлыков, папок и т.д.; можно добавить несколько пунктов для последовательного выполнения.";
		p_16.Dock = DockStyle.Top;
		SplitContainer splitContainer = p_16;
		location = new Point(0, 0);
		splitContainer.Location = location;
		p_16.Name = "SplitContainer1";
		p_16.Panel1.Controls.Add(p_20);
		SplitterPanel panel = p_16.Panel1;
		padding = new Padding(3);
		panel.Padding = padding;
		p_16.Panel2.Controls.Add(p_11);
		SplitterPanel panel2 = p_16.Panel2;
		padding = new Padding(3);
		panel2.Padding = padding;
		SplitContainer splitContainer2 = p_16;
		size = new Size(584, 296);
		splitContainer2.Size = size;
		p_16.SplitterDistance = 186;
		p_16.TabIndex = 5;
		p_20.Controls.Add(p_17);
		p_20.Dock = DockStyle.Fill;
		GroupBox groupBox4 = p_20;
		location = new Point(3, 3);
		groupBox4.Location = location;
		p_20.Name = "GroupBox2";
		GroupBox groupBox5 = p_20;
		padding = new Padding(6);
		groupBox5.Padding = padding;
		GroupBox groupBox6 = p_20;
		size = new Size(180, 290);
		groupBox6.Size = size;
		p_20.TabIndex = 6;
		p_20.TabStop = false;
		p_20.Text = "Список меню";
		p_17.AllowUserToAddRows = false;
		p_17.AllowUserToDeleteRows = false;
		p_17.AllowUserToResizeRows = false;
		dataGridViewCellStyle.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		p_17.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		p_17.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
		p_17.BackgroundColor = Color.White;
		p_17.CellBorderStyle = DataGridViewCellBorderStyle.None;
		p_17.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		p_17.ColumnHeadersVisible = false;
		p_17.Columns.AddRange(p_18, p_19);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.NullValue = "\"\"";
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		p_17.DefaultCellStyle = dataGridViewCellStyle2;
		p_17.Dock = DockStyle.Fill;
		DataGridView dataGridView = p_17;
		location = new Point(6, 22);
		dataGridView.Location = location;
		p_17.MultiSelect = false;
		p_17.Name = "DGV1";
		p_17.RowHeadersVisible = false;
		p_17.RowTemplate.Height = 23;
		p_17.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView dataGridView2 = p_17;
		size = new Size(168, 262);
		dataGridView2.Size = size;
		p_17.TabIndex = 7;
		p_18.HeaderText = "";
		p_18.Name = "Column4";
		p_18.Resizable = DataGridViewTriState.False;
		p_18.Width = 25;
		p_19.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle3.NullValue = "\"\"";
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		p_19.DefaultCellStyle = dataGridViewCellStyle3;
		p_19.HeaderText = "";
		p_19.MinimumWidth = 70;
		p_19.Name = "Column1";
		p_19.SortMode = DataGridViewColumnSortMode.NotSortable;
		AcceptButton = p_7;
		SizeF sizeF = new SizeF(96f, 96f);
		AutoScaleDimensions = sizeF;
		AutoScaleMode = AutoScaleMode.Dpi;
		CancelButton = p_8;
		size = new Size(584, 338);
		ClientSize = size;
		Controls.Add(p_16);
		Controls.Add(p_6);
		Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "customsettings";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Настройка меню";
		p_6.ResumeLayout(performLayout: false);
		p_6.PerformLayout();
		p_11.ResumeLayout(performLayout: false);
		p_11.PerformLayout();
		p_21.ResumeLayout(performLayout: false);
		p_21.PerformLayout();
		p_16.Panel1.ResumeLayout(performLayout: false);
		p_16.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)p_16).EndInit();
		p_16.ResumeLayout(performLayout: false);
		p_20.ResumeLayout(performLayout: false);
		((ISupportInitialize)p_17).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public customsettings()
	{
		base.Load += m_84;
		f_108 = new List<Type_25>();
		Type_16.m_52();
		m_83();
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			f_111 = graphics.DpiX / 96f;
		}
		checked
		{
			int num = p_17.ColumnCount - 1;
			for (int i = 0; i <= num; i++)
			{
				p_17.Columns[i].MinimumWidth = (int)Math.Round((double)p_17.Columns[i].MinimumWidth * f_111);
				p_17.Columns[i].Width = (int)Math.Round((double)p_17.Columns[i].Width * f_111);
			}
			p_22.Height = (int)Math.Round(36.0 * f_111);
		}
	}

	private void m_84(object P_0, EventArgs P_1)
	{
		f_109 = false;
		f_108.Clear();
		p_17.Rows.Clear();
		int num = 0;
		checked
		{
			do
			{
				try
				{
					string text = "Customsetting" + Conversions.ToString(num);
					string text2 = Type_16.m_63(text, "title");
					string text3 = Type_16.m_63(text, "hide");
					string text4 = Type_16.m_63(text, "pathname");
					Type_25 type_ = new Type_25();
					type_.f_113 = text;
					type_.f_117 = num;
					type_.f_114 = text4.Trim();
					type_.f_115 = Conversions.ToString(Interaction.IIf(Operators.CompareString(text2, "", TextCompare: false) == 0, "Пользовательское меню" + Conversions.ToString(num + 1), text2));
					type_.f_116 = Type_16.m_58(text3);
					f_108.Add(type_);
					p_17.Rows.Add();
					p_17.Rows[num].SetValues(!type_.f_116, type_.f_115);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
				num++;
			}
			while (num <= 19);
			p_17.ClearSelection();
			p_13.Items.Clear();
			f_109 = true;
		}
	}

	private void m_85(object P_0, DataGridViewCellEventArgs P_1)
	{
		f_112 = false;
		f_110 = P_1.RowIndex;
		p_13.Items.Clear();
		string f_ = f_108[f_110].f_114;
		if (Operators.CompareString(f_, "", TextCompare: false) != 0)
		{
			p_13.Items.AddRange(Strings.Split(f_.Trim(), "\r\n"));
		}
		f_112 = true;
	}

	private void m_86(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (f_109)
		{
			if (P_1.ColumnIndex == 0)
			{
				f_108[f_110].f_116 = Conversions.ToBoolean(Operators.NotObject(p_17[P_1.ColumnIndex, P_1.RowIndex].Value));
			}
			else if (P_1.ColumnIndex == 1)
			{
				f_108[f_110].f_115 = Conversions.ToString(p_17[P_1.ColumnIndex, P_1.RowIndex].Value);
			}
		}
	}

	private void m_87(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = f_108.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Type_16.m_62(f_108[i].f_113, "pathname", f_108[i].f_114);
				Type_16.m_62(f_108[i].f_113, "title", f_108[i].f_115);
				Type_16.m_62(f_108[i].f_113, "hide", Conversions.ToString(f_108[i].f_116));
			}
			Close();
		}
	}

	private void m_88(object P_0, EventArgs P_1)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void m_89(object P_0, EventArgs P_1)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Все файлы (*.*)|*.*";
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return;
		}
		string fileName = openFileDialog.FileName;
		bool flag = false;
		checked
		{
			int num = p_13.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (string.Compare(p_13.Items[i].ToString(), fileName, ignoreCase: true) == 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag && File.Exists(fileName))
			{
				p_13.Items.Add(fileName);
			}
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = p_13.Items.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					stringBuilder.AppendLine(p_13.Items[j].ToString());
				}
				f_108[f_110].f_114 = stringBuilder.ToString().Trim();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_90(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				int num = p_13.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i < p_13.Items.Count && p_13.GetSelected(i))
					{
						p_13.Items.RemoveAt(i);
						i--;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = p_13.Items.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					stringBuilder.AppendLine(p_13.Items[j].ToString());
				}
				f_108[f_110].f_114 = stringBuilder.ToString().Trim();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_91(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				string text = "";
				FileBorser fileBorser = new FileBorser();
				if (fileBorser.ShowDialog(this) != DialogResult.OK)
				{
					return;
				}
				text = fileBorser.DirectoryPath;
				if (!text.EndsWith("\\"))
				{
					text += "\\";
				}
				bool flag = false;
				int num = p_13.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (string.Compare(Conversions.ToString(p_13.Items[i]), text, ignoreCase: true) == 0)
					{
						flag = true;
						break;
					}
				}
				if (!flag & Directory.Exists(text))
				{
					p_13.Items.Add(text);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = p_13.Items.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					stringBuilder.AppendLine(p_13.Items[j].ToString());
				}
				f_108[f_110].f_114 = stringBuilder.ToString().Trim();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_92(object P_0, EventArgs P_1)
	{
		int selectedIndex = p_13.SelectedIndex;
		checked
		{
			if (selectedIndex > 0)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(p_13.SelectedItem);
				p_13.Items.RemoveAt(selectedIndex);
				p_13.Items.Insert(selectedIndex, RuntimeHelpers.GetObjectValue(p_13.Items[selectedIndex - 1]));
				p_13.Items.RemoveAt(selectedIndex - 1);
				p_13.Items.Insert(selectedIndex - 1, RuntimeHelpers.GetObjectValue(objectValue));
				p_13.SelectedIndex = selectedIndex - 1;
			}
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = p_13.Items.Count - 1;
				for (selectedIndex = 0; selectedIndex <= num; selectedIndex++)
				{
					stringBuilder.AppendLine(p_13.Items[selectedIndex].ToString());
				}
				f_108[f_110].f_114 = stringBuilder.ToString().Trim();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void m_93(object P_0, EventArgs P_1)
	{
		int selectedIndex = p_13.SelectedIndex;
		checked
		{
			if (selectedIndex < p_13.Items.Count - 1 && selectedIndex >= 0)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(p_13.SelectedItem);
				p_13.Items.RemoveAt(selectedIndex);
				p_13.Items.Insert(selectedIndex + 1, RuntimeHelpers.GetObjectValue(objectValue));
				p_13.SelectedIndex = selectedIndex + 1;
			}
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num = p_13.Items.Count - 1;
				for (selectedIndex = 0; selectedIndex <= num; selectedIndex++)
				{
					stringBuilder.AppendLine(p_13.Items[selectedIndex].ToString());
				}
				f_108[f_110].f_114 = stringBuilder.ToString().Trim();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}
}
