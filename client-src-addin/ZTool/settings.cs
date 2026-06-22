using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[DesignerGenerated]
public class settings : Form
{
	private IContainer f_349;

	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel f_350;

	[AccessedThroughProperty("OK_Button")]
	private Button f_351;

	[AccessedThroughProperty("Cancel_Button")]
	private Button f_352;

	[AccessedThroughProperty("UserControl_SaveDrawing")]
	private CheckBox f_353;

	[AccessedThroughProperty("TextBox1")]
	private TextBox f_354;

	internal virtual TableLayoutPanel p_105
	{
		get
		{
			return f_350;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_350 = value;
		}
	}

	internal virtual Button p_106
	{
		get
		{
			return f_351;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_153;
			if (f_351 != null)
			{
				f_351.Click -= value2;
			}
			f_351 = value;
			if (f_351 != null)
			{
				f_351.Click += value2;
			}
		}
	}

	internal virtual Button p_107
	{
		get
		{
			return f_352;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			EventHandler value2 = m_154;
			if (f_352 != null)
			{
				f_352.Click -= value2;
			}
			f_352 = value;
			if (f_352 != null)
			{
				f_352.Click += value2;
			}
		}
	}

	internal virtual CheckBox p_108
	{
		get
		{
			return f_353;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_353 = value;
		}
	}

	internal virtual TextBox p_109
	{
		get
		{
			return f_354;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_354 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && f_349 != null)
			{
				f_349.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m_152()
	{
		p_105 = new TableLayoutPanel();
		p_106 = new Button();
		p_107 = new Button();
		p_108 = new CheckBox();
		p_109 = new TextBox();
		p_105.SuspendLayout();
		SuspendLayout();
		p_105.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		p_105.AutoSize = true;
		p_105.ColumnCount = 2;
		p_105.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		p_105.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		p_105.Controls.Add(p_106, 0, 0);
		p_105.Controls.Add(p_107, 1, 0);
		TableLayoutPanel tableLayoutPanel = p_105;
		Point location = new Point(283, 248);
		tableLayoutPanel.Location = location;
		TableLayoutPanel tableLayoutPanel2 = p_105;
		Padding margin = new Padding(3, 4, 3, 4);
		tableLayoutPanel2.Margin = margin;
		p_105.Name = "TableLayoutPanel1";
		p_105.RowCount = 1;
		p_105.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel tableLayoutPanel3 = p_105;
		Size size = new Size(144, 35);
		tableLayoutPanel3.Size = size;
		p_105.TabIndex = 0;
		p_106.Anchor = AnchorStyles.None;
		p_106.AutoSize = true;
		Button button = p_106;
		location = new Point(6, 4);
		button.Location = location;
		Button button2 = p_106;
		margin = new Padding(3, 4, 3, 4);
		button2.Margin = margin;
		p_106.Name = "OK_Button";
		Button button3 = p_106;
		size = new Size(60, 27);
		button3.Size = size;
		p_106.TabIndex = 0;
		p_106.Text = "ОК";
		p_107.Anchor = AnchorStyles.None;
		p_107.AutoSize = true;
		p_107.DialogResult = DialogResult.Cancel;
		Button button4 = p_107;
		location = new Point(78, 4);
		button4.Location = location;
		Button button5 = p_107;
		margin = new Padding(3, 4, 3, 4);
		button5.Margin = margin;
		p_107.Name = "Cancel_Button";
		Button button6 = p_107;
		size = new Size(60, 27);
		button6.Size = size;
		p_107.TabIndex = 1;
		p_107.Text = "Отмена";
		p_108.AutoSize = true;
		CheckBox checkBox = p_108;
		location = new Point(16, 8);
		checkBox.Location = location;
		p_108.Name = "UserControl_SaveDrawing";
		CheckBox checkBox2 = p_108;
		size = new Size(219, 21);
		checkBox2.Size = size;
		p_108.TabIndex = 1;
		p_108.Text = "Перехват системного сохранения (только чертежи)";
		p_108.UseVisualStyleBackColor = true;
		p_109.BackColor = SystemColors.Control;
		p_109.BorderStyle = BorderStyle.None;
		p_109.ForeColor = Color.Red;
		TextBox textBox = p_109;
		location = new Point(16, 32);
		textBox.Location = location;
		p_109.Multiline = true;
		p_109.Name = "TextBox1";
		p_109.ReadOnly = true;
		TextBox textBox2 = p_109;
		size = new Size(416, 40);
		textBox2.Size = size;
		p_109.TabIndex = 3;
		p_109.Text = "Описание: после включения этой функции любое сохранение чертежа (вручную, макросом или внешней программой) принудительно переименует его в соответствии с именем связанной детали.";
		AcceptButton = p_106;
		SizeF sizeF = new SizeF(96f, 96f);
		AutoScaleDimensions = sizeF;
		AutoScaleMode = AutoScaleMode.Dpi;
		CancelButton = p_107;
		size = new Size(441, 285);
		ClientSize = size;
		Controls.Add(p_109);
		Controls.Add(p_108);
		Controls.Add(p_105);
		Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		margin = new Padding(3, 4, 3, 4);
		Margin = margin;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "settings";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Доп. функции";
		p_105.ResumeLayout(performLayout: false);
		p_105.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public settings()
	{
		base.Load += m_155;
		Type_16.m_52();
		m_152();
	}

	private void m_153(object P_0, EventArgs P_1)
	{
		Type_16.m_62("", p_108.Name, p_108.Checked.ToString());
		DialogResult = DialogResult.OK;
		Close();
	}

	private void m_154(object P_0, EventArgs P_1)
	{
		DialogResult = DialogResult.Cancel;
		Close();
	}

	private void m_155(object P_0, EventArgs P_1)
	{
		p_108.Checked = Type_16.m_58(Type_16.m_63("", p_108.Name));
	}
}
