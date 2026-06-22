using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[DesignerGenerated]
public class preview : Form
{
	private IContainer f_201;

	[AccessedThroughProperty("Label1")]
	private Label f_202;

	[AccessedThroughProperty("PictureBox1")]
	private PictureBox f_203;

	[AccessedThroughProperty("hasdrw")]
	private PictureBox f_204;

	internal virtual Label p_50
	{
		get
		{
			return f_202;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_202 = value;
		}
	}

	internal virtual PictureBox p_51
	{
		get
		{
			return f_203;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_203 = value;
		}
	}

	internal virtual PictureBox p_52
	{
		get
		{
			return f_204;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_204 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && f_201 != null)
			{
				f_201.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m_111()
	{
		p_50 = new Label();
		p_51 = new PictureBox();
		p_52 = new PictureBox();
		((ISupportInitialize)p_51).BeginInit();
		((ISupportInitialize)p_52).BeginInit();
		SuspendLayout();
		p_50.AutoSize = true;
		p_50.BackColor = Color.Transparent;
		p_50.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		Label label = p_50;
		Point location = new Point(12, 174);
		label.Location = location;
		p_50.Name = "Label1";
		Label label2 = p_50;
		Size size = new Size(0, 17);
		label2.Size = size;
		p_50.TabIndex = 0;
		p_51.BackColor = Color.White;
		p_51.BorderStyle = BorderStyle.FixedSingle;
		p_51.Dock = DockStyle.Fill;
		PictureBox pictureBox = p_51;
		location = new Point(0, 0);
		pictureBox.Location = location;
		PictureBox pictureBox2 = p_51;
		Padding margin = new Padding(3, 4, 3, 4);
		pictureBox2.Margin = margin;
		p_51.Name = "PictureBox1";
		PictureBox pictureBox3 = p_51;
		size = new Size(200, 150);
		pictureBox3.Size = size;
		p_51.SizeMode = PictureBoxSizeMode.Zoom;
		p_51.TabIndex = 1;
		p_51.TabStop = false;
		p_52.BackColor = Color.White;
		p_52.BackgroundImage = Type_26.p_48;
		p_52.BackgroundImageLayout = ImageLayout.None;
		PictureBox pictureBox4 = p_52;
		location = new Point(3, 3);
		pictureBox4.Location = location;
		p_52.Name = "hasdrw";
		PictureBox pictureBox5 = p_52;
		size = new Size(16, 16);
		pictureBox5.Size = size;
		p_52.TabIndex = 2;
		p_52.TabStop = false;
		p_52.Visible = false;
		SizeF sizeF = new SizeF(96f, 96f);
		AutoScaleDimensions = sizeF;
		AutoScaleMode = AutoScaleMode.Dpi;
		size = new Size(200, 150);
		ClientSize = size;
		Controls.Add(p_52);
		Controls.Add(p_50);
		Controls.Add(p_51);
		Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		FormBorderStyle = FormBorderStyle.None;
		margin = new Padding(3, 4, 3, 4);
		Margin = margin;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "preview";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		((ISupportInitialize)p_51).EndInit();
		((ISupportInitialize)p_52).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public preview()
	{
		m_111();
		Type_16.m_52();
		m_112();
	}

	private void m_112()
	{
		Label label = p_50;
		Size maximumSize = new Size(Width, 0);
		label.MaximumSize = maximumSize;
		p_50.Parent = p_51;
		p_50.AutoSize = true;
		p_50.Dock = DockStyle.Bottom;
	}
}
