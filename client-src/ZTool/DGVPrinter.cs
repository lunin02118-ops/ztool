using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class DGVPrinter : PrintPreviewDialog
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private double dpixRatio;

	private PrintDocument printDoc;

	private PageSetupDialog pageSetupDlg;

	private PrintDialog printDlg;

	private ToolStripComboBox StripComboBox;

	private DataGridView sourceDGV_Conflict;

	private int printedRowsCount;

	public Font printFont;

	public string mainTitle;

	public string subTitle;

	public DataGridView SourceDGV
	{
		get
		{
			return sourceDGV_Conflict;
		}
		set
		{
			sourceDGV_Conflict = value;
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

	public DGVPrinter()
	{
		__ENCAddToList(this);
		dpixRatio = 1.0;
		printedRowsCount = 0;
		mainTitle = "";
		subTitle = "";
		using (Graphics graphics = Graphics.FromHwnd(Handle))
		{
			dpixRatio = graphics.DpiX / 96f;
		}
		printFont = SystemFonts.DefaultFont;
		printDoc = new PrintDocument();
		printDoc.PrintPage += printDoc_PrintPage;
		AutoScaleMode = AutoScaleMode.Dpi;
		checked
		{
			Width = (int)Math.Round(600.0 * dpixRatio);
			Height = (int)Math.Round(450.0 * dpixRatio);
			PrintPreviewControl.Zoom = 1.0;
			StartPosition = FormStartPosition.CenterParent;
			foreach (Control control in base.Controls)
			{
				if ((object)control.GetType() != typeof(ToolStrip))
				{
					continue;
				}
				control.Height = (int)Math.Round(40.0 * dpixRatio);
				ToolStrip toolStrip = control as ToolStrip;
				int num = toolStrip.Items.Count - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					toolStrip.Items[num2].DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					num2++;
				}
				toolStrip.Items.Insert(1, new ToolStripSeparator());
				toolStrip.Items.Insert(1, CreatePageSetupButton());
				toolStrip.Items.Insert(1, CreatePrintsetButton());
				toolStrip.Items.Insert(1, CreatePrinterlist());
			}
			pageSetupDlg = new PageSetupDialog();
			pageSetupDlg.MinMargins = new Margins(10, 10, 10, 10);
			pageSetupDlg.Document = printDoc;
			printDlg = new PrintDialog();
			printDlg.Document = printDoc;
			Document = printDoc;
		}
	}

	private ToolStripButton CreatePrintsetButton()
	{
		ToolStripButton toolStripButton = new ToolStripButton();
		toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton.ImageTransparentColor = Color.Magenta;
		toolStripButton.Name = "printsetStripButton";
		Size size = checked(new Size((int)Math.Round(23.0 * dpixRatio), (int)Math.Round(22.0 * dpixRatio)));
		toolStripButton.Size = size;
		toolStripButton.Text = "Настройки печати";
		toolStripButton.Click += Stripbutton1_Click;
		return toolStripButton;
	}

	private ToolStripButton CreatePageSetupButton()
	{
		ToolStripButton toolStripButton = new ToolStripButton();
		toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
		toolStripButton.ImageTransparentColor = Color.Magenta;
		toolStripButton.Name = "PageSetupStripButton";
		Size size = checked(new Size((int)Math.Round(23.0 * dpixRatio), (int)Math.Round(22.0 * dpixRatio)));
		toolStripButton.Size = size;
		toolStripButton.Text = "Параметры страницы";
		toolStripButton.Click += Stripbutton2_Click;
		return toolStripButton;
	}

	private ToolStripComboBox CreatePrinterlist()
	{
		StripComboBox = new ToolStripComboBox();
		StripComboBox.DisplayStyle = ToolStripItemDisplayStyle.Text;
		StripComboBox.FlatStyle = FlatStyle.Standard;
		StripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		checked
		{
			int num5 = default(int);
			using (PrintDocument printDocument = new PrintDocument())
			{
				string printerName = printDocument.PrinterSettings.PrinterName;
				StripComboBox.Items.Clear();
				int num = PrinterSettings.InstalledPrinters.Count - 1;
				while (true)
				{
					int num2 = num;
					int num3 = 0;
					if (num2 >= num3)
					{
						string text = PrinterSettings.InstalledPrinters[num];
						StripComboBox.Items.Add(text);
						int num4 = TextRenderer.MeasureText(text, StripComboBox.Font).Width;
						if (num4 > num5)
						{
							num5 = num4;
						}
						if (Operators.CompareString(printerName, text, TextCompare: false) == 0)
						{
							StripComboBox.SelectedIndex = StripComboBox.Items.IndexOf(printerName);
						}
						num += -1;
						continue;
					}
					break;
				}
			}
			StripComboBox.Name = "Printerlist";
			ToolStripComboBox stripComboBox = StripComboBox;
			Size size = new Size(num5, (int)Math.Round(22.0 * dpixRatio));
			stripComboBox.Size = size;
			StripComboBox.AutoSize = true;
			StripComboBox.Text = "Принтер";
			StripComboBox.SelectedIndexChanged += StripComboBox_SelectedIndexChanged;
			return StripComboBox;
		}
	}

	private void Stripbutton1_Click(object sender, EventArgs e)
	{
		if (printDlg.ShowDialog() == DialogResult.OK)
		{
			StripComboBox.Text = printDoc.PrinterSettings.PrinterName;
			PrintPreviewControl.InvalidatePreview();
		}
	}

	private void Stripbutton2_Click(object sender, EventArgs e)
	{
		if ((pageSetupDlg.ShowDialog() == DialogResult.OK && RegionInfo.CurrentRegion.IsMetric && Environment.OSVersion.Platform != PlatformID.Unix) ? true : false)
		{
			pageSetupDlg.PageSettings.Margins = PrinterUnitConvert.Convert(pageSetupDlg.PageSettings.Margins, PrinterUnit.Display, PrinterUnit.TenthsOfAMillimeter);
			PrintPreviewControl.InvalidatePreview();
		}
	}

	private void StripComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (Operators.CompareString(StripComboBox.Text, "", TextCompare: false) != 0)
			{
				printDoc.PrinterSettings.PrinterName = StripComboBox.Text;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
	{
		int num = e.MarginBounds.Left;
		int num2 = e.MarginBounds.Top;
		Pen pen = new Pen(Color.Gray);
		Brush lightGray = Brushes.LightGray;
		checked
		{
			if (printedRowsCount == 0)
			{
				if (Operators.CompareString(mainTitle, "", TextCompare: false) != 0)
				{
					Font font = new Font(new FontFamily("宋体"), 20f, FontStyle.Bold);
					SizeF sizeF = e.Graphics.MeasureString(mainTitle, font, int.MaxValue);
					unchecked
					{
						if ((float)e.PageBounds.Width > sizeF.Width)
						{
							num = checked(e.PageBounds.Width - Convert.ToInt32(sizeF.Width)) / 2;
						}
						e.Graphics.DrawString(mainTitle, font, Brushes.Black, num, num2);
					}
					num2 += Convert.ToInt32(sizeF.Height) + 5;
					num = e.MarginBounds.Left;
				}
				if (Operators.CompareString(subTitle, "", TextCompare: false) != 0)
				{
					Font font2 = new Font(new FontFamily("宋体"), 10f, FontStyle.Bold);
					SizeF sizeF2 = e.Graphics.MeasureString(subTitle, font2, int.MaxValue);
					if ((float)e.PageBounds.Width > sizeF2.Width + 80f)
					{
						num = e.PageBounds.Width - Convert.ToInt32(sizeF2.Width) - 10;
					}
					e.Graphics.DrawString(subTitle, font2, Brushes.Black, num, num2);
					num2 += Convert.ToInt32(sizeF2.Height) + 5;
					num = e.MarginBounds.Left;
				}
			}
			int num3 = sourceDGV_Conflict.Columns.Count - 1;
			int num4 = 0;
			while (true)
			{
				int num5 = num4;
				int num6 = num3;
				if (num5 > num6)
				{
					break;
				}
				int num7 = (int)Math.Round((double)sourceDGV_Conflict.Columns[num4].Width / dpixRatio);
				int num8 = (int)Math.Round((double)sourceDGV_Conflict.ColumnHeadersHeight / dpixRatio);
				Rectangle rect = new Rectangle(num, num2, num7, num8);
				e.Graphics.FillRectangle(lightGray, rect);
				e.Graphics.DrawRectangle(pen, rect);
				DrawStringCenter(e.Graphics, sourceDGV_Conflict.Columns[num4].HeaderText, rect);
				num += rect.Width;
				num4++;
			}
			num = e.MarginBounds.Left;
			num2 = (int)Math.Round((double)num2 + (double)sourceDGV_Conflict.ColumnHeadersHeight / dpixRatio);
			int num9 = printedRowsCount;
			int num10 = sourceDGV_Conflict.Rows.Count - 1;
			int num11 = num9;
			while (true)
			{
				int num12 = num11;
				int num6 = num10;
				if (num12 > num6)
				{
					break;
				}
				int num13 = (int)Math.Round((double)sourceDGV_Conflict.Rows[num11].Height / dpixRatio);
				int num14 = sourceDGV_Conflict.Columns.Count - 1;
				int num15 = 0;
				while (true)
				{
					int num16 = num15;
					num6 = num14;
					if (num16 > num6)
					{
						break;
					}
					int num17 = (int)Math.Round((double)sourceDGV_Conflict.Columns[num15].Width / dpixRatio);
					Rectangle rect2 = new Rectangle(num, num2, num17, num13);
					e.Graphics.DrawRectangle(pen, rect2);
					if (sourceDGV_Conflict.Rows[num11].Cells[num15].Value != null)
					{
						DrawStringCenter(e.Graphics, sourceDGV_Conflict.Rows[num11].Cells[num15].Value.ToString(), rect2);
					}
					num += num17;
					num15++;
				}
				printedRowsCount++;
				num = e.MarginBounds.Left;
				num2 += num13;
				if ((num2 > e.PageBounds.Height - 80 && printedRowsCount < sourceDGV_Conflict.Rows.Count) ? true : false)
				{
					e.HasMorePages = true;
					return;
				}
				num11++;
			}
			printedRowsCount = 0;
		}
	}

	private void DrawStringCenter(Graphics g, string str, Rectangle rect)
	{
		PointF pointF = new PointF(rect.X, rect.Y);
		SizeF sizeF = g.MeasureString(str, printFont, int.MaxValue);
		checked
		{
			if ((float)rect.Width > sizeF.Width)
			{
				pointF.X = rect.X + unchecked(checked(rect.Width - Convert.ToInt32(sizeF.Width)) / 2);
			}
			if ((float)rect.Height > sizeF.Height)
			{
				pointF.Y = rect.Y + unchecked(checked(rect.Height - Convert.ToInt32(sizeF.Height)) / 2);
			}
			g.DrawString(layoutRectangle: new Rectangle(Convert.ToInt32(pointF.X), Convert.ToInt32(pointF.Y), rect.Width, rect.Height), s: str, font: printFont, brush: Brushes.Black, format: StringFormat.GenericTypographic);
		}
	}

	private void InitializeComponent()
	{
		this.SuspendLayout();
		System.Drawing.Size clientSize = new System.Drawing.Size(478, 300);
		this.ClientSize = clientSize;
		this.Name = "DGVPrinter";
		this.ResumeLayout(false);
	}
}
