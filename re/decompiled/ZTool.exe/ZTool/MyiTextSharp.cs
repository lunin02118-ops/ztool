using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ZTool;

public class MyiTextSharp
{
	[DebuggerNonUserCode]
	public MyiTextSharp()
	{
	}

	public static bool PDFWatermarkimage(string inputfilepath, string ModelPicName, int postion, float top, float left, float GrayFill, float Degrees, int n = 0)
	{
		bool result;
		if (!File.Exists(inputfilepath) || !File.Exists(ModelPicName))
		{
			result = false;
		}
		else
		{
			PdfReader pdfReader = null;
			PdfStamper pdfStamper = null;
			string tempFileName = Path.GetTempFileName();
			try
			{
				pdfReader = new PdfReader(inputfilepath);
				int numberOfPages = pdfReader.NumberOfPages;
				pdfStamper = new PdfStamper(pdfReader, new FileStream(tempFileName, FileMode.Create));
				iTextSharp.text.Image instance = iTextSharp.text.Image.GetInstance(ModelPicName);
				instance.GrayFill = GrayFill;
				instance.RotationDegrees = Degrees;
				top = (float)((double)top / 0.3527);
				left = (float)((double)left / 0.3527);
				int num = numberOfPages;
				int num2 = 1;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					if ((n <= 0 || num2 == n) && 0 == 0)
					{
						iTextSharp.text.Rectangle pageSize = pdfReader.GetPageSize(num2);
						float width = pageSize.Width;
						float height = pageSize.Height;
						switch (postion)
						{
						case 0:
							top = top;
							left = left;
							break;
						case 1:
							top = height - top - instance.Height;
							left = left;
							break;
						case 2:
							top = height - top - instance.Height;
							left = width - left - instance.Width;
							break;
						case 3:
							top = top;
							left = width - left - instance.Width;
							break;
						}
						instance.SetAbsolutePosition(left, top);
						PdfContentByte underContent = pdfStamper.GetUnderContent(num2);
						underContent.AddImage(instance);
					}
					num2 = checked(num2 + 1);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_01c7;
			}
			finally
			{
				pdfStamper?.Close();
				pdfReader?.Close();
			}
			File.Copy(tempFileName, inputfilepath, overwrite: true);
			File.Delete(tempFileName);
			result = true;
		}
		goto IL_01c7;
		IL_01c7:
		return result;
	}

	public static bool PDFWatermarkText(string inputfilepath, string WatermarkText, int postion, float top, float left, System.Drawing.Font dfont, Color dcolor, int n = 0)
	{
		bool result;
		checked
		{
			if (!File.Exists(inputfilepath) || Strings.Len(WatermarkText) == 0)
			{
				result = false;
			}
			else
			{
				PdfReader pdfReader = null;
				PdfStamper pdfStamper = null;
				string tempFileName = Path.GetTempFileName();
				try
				{
					pdfReader = new PdfReader(inputfilepath);
					int numberOfPages = pdfReader.NumberOfPages;
					pdfStamper = new PdfStamper(pdfReader, new FileStream(tempFileName, FileMode.Create));
					iTextSharp.text.Font textFont = GetTextFont(dfont, dcolor);
					string[] array = WatermarkText.Split('\n');
					int num = code.CharWidth(WatermarkText, dfont);
					top = (float)((double)top / 0.3527);
					left = (float)((double)left / 0.3527);
					int num2 = numberOfPages;
					int num3 = 1;
					while (true)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						if ((n <= 0 || num3 == n) && 0 == 0)
						{
							iTextSharp.text.Rectangle pageSize = pdfReader.GetPageSize(num3);
							int num6 = (int)Math.Round(top);
							int num7 = (int)Math.Round(left);
							switch (postion)
							{
							case 0:
								num6 = (int)Math.Round(top);
								num7 = (int)Math.Round(left);
								break;
							case 1:
								num6 = (int)Math.Round(pageSize.Height - top - dfont.Size * (float)array.Length);
								num7 = (int)Math.Round(left);
								break;
							case 2:
								num6 = (int)Math.Round(pageSize.Height - top - dfont.Size * (float)array.Length);
								num7 = (int)Math.Round(pageSize.Width - left - (float)num);
								break;
							case 3:
								num6 = (int)Math.Round(top);
								num7 = (int)Math.Round(pageSize.Width - left - (float)num);
								break;
							default:
								num6 = (int)Math.Round(top);
								num7 = (int)Math.Round(left);
								break;
							}
							PdfContentByte overContent = pdfStamper.GetOverContent(num3);
							int num8 = array.Length - 1;
							int num9 = 0;
							while (true)
							{
								int num10 = num9;
								num5 = num8;
								if (num10 > num5)
								{
									break;
								}
								Chunk chunk = new Chunk(array[num9], textFont);
								ColumnText.ShowTextAligned(overContent, 0, new Phrase(chunk), num7, (float)num6 + dfont.Size * (float)(array.Length - 1 - num9), 0f);
								num9++;
							}
						}
						num3++;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					result = false;
					ProjectData.ClearProjectError();
					goto IL_0293;
				}
				finally
				{
					pdfStamper?.Close();
					pdfReader?.Close();
				}
				File.Copy(tempFileName, inputfilepath, overwrite: true);
				File.Delete(tempFileName);
				result = true;
			}
			goto IL_0293;
		}
		IL_0293:
		return result;
	}

	public static bool CombinePDF(string[] fileList, string outFile, ListView ListView1)
	{
		Document document = new Document();
		PdfCopy pdfCopy = null;
		checked
		{
			try
			{
				int num = fileList.Length - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					PdfReader pdfReader = new PdfReader(fileList[num2]);
					try
					{
						int numberOfPages = pdfReader.NumberOfPages;
						if (numberOfPages >= 1)
						{
							if (Information.IsNothing(pdfCopy))
							{
								pdfCopy = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
								document.Open();
							}
							int num5 = numberOfPages;
							int num6 = 1;
							while (true)
							{
								int num7 = num6;
								num4 = num5;
								if (num7 > num4)
								{
									break;
								}
								PdfImportedPage importedPage = pdfCopy.GetImportedPage(pdfReader, num6);
								pdfCopy.AddPage(importedPage);
								num6++;
							}
							ListView1.Items[num2].SubItems[3].Text = Conversions.ToString(numberOfPages) + " страниц объединено";
							ListView1.Items[num2].SubItems[3].ForeColor = Color.Blue;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					finally
					{
						pdfReader?.Close();
					}
					num2++;
				}
				return true;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				throw ex4;
			}
			finally
			{
				if (document.IsOpen())
				{
					document.Close();
				}
				pdfCopy?.Close();
			}
		}
	}

	public static int SplitAndSave(string inputPath, string outputPath)
	{
		FileInfo fileInfo = new FileInfo(inputPath);
		string text = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf("."));
		using PdfReader pdfReader = new PdfReader(inputPath);
		int numberOfPages = pdfReader.NumberOfPages;
		int num = 1;
		while (true)
		{
			int num2 = num;
			int num3 = numberOfPages;
			if (num2 > num3)
			{
				break;
			}
			string path = code.SplitStr(inputPath, 1) + "-" + num + ".pdf";
			string path2 = Path.Combine(outputPath, path);
			Document document = new Document();
			PdfCopy pdfCopy = new PdfCopy(document, new FileStream(path2, FileMode.Create));
			document.Open();
			pdfCopy.AddPage(pdfCopy.GetImportedPage(pdfReader, num));
			document.Close();
			num = checked(num + 1);
		}
		return pdfReader.NumberOfPages;
	}

	public static iTextSharp.text.Font GetTextFont(System.Drawing.Font dfont, Color dcolor)
	{
		iTextSharp.text.Font font = null;
		try
		{
			string name = dfont.Name;
			if (!FontFactory.IsRegistered(name))
			{
				FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
			}
			return FontFactory.GetFont(name, "Identity-H", dfont.Size, ConvertFontStyle(dfont.Style), new BaseColor(dcolor));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw ex2;
		}
	}

	public static int ConvertFontStyle(FontStyle _fontStyle)
	{
		List<int> list = new List<int>();
		if ((_fontStyle & FontStyle.Regular) != FontStyle.Regular)
		{
			list.Add(0);
		}
		if ((_fontStyle & FontStyle.Bold) != FontStyle.Regular)
		{
			list.Add(1);
		}
		if ((_fontStyle & FontStyle.Italic) != FontStyle.Regular)
		{
			list.Add(2);
		}
		if ((_fontStyle & FontStyle.Underline) != FontStyle.Regular)
		{
			list.Add(4);
		}
		if ((_fontStyle & FontStyle.Strikeout) != FontStyle.Regular)
		{
			list.Add(8);
		}
		return list.Count switch
		{
			0 => -1, 
			1 => list[0], 
			2 => list[0] | list[1], 
			3 => list[0] | list[1] | list[2], 
			4 => list[0] | list[1] | list[2] | list[3], 
			5 => list[0] | list[1] | list[2] | list[3] | list[4], 
			_ => -1, 
		};
	}
}
