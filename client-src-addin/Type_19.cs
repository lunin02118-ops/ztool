using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;

[StandardModule]
internal static class Type_19
{
	public static byte[] m_74(Image P_0, bool P_1)
	{
		using MemoryStream memoryStream = new MemoryStream();
		if (P_1)
		{
			P_0.Save(memoryStream, ImageFormat.Png);
		}
		else
		{
			P_0.Save(memoryStream, ImageFormat.Jpeg);
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream.GetBuffer();
	}

	public static Image m_75(byte[] P_0)
	{
		MemoryStream stream = new MemoryStream(P_0);
		return Image.FromStream(stream);
	}

	public static Image m_76(Image P_0, int P_1 = 400)
	{
		checked
		{
			if ((P_0.Height > P_1) | (P_0.Width > P_1))
			{
				int thumbWidth;
				int thumbHeight;
				if (P_0.Height > P_0.Width)
				{
					thumbWidth = (int)Math.Round((double)P_0.Width / ((double)P_0.Height / (double)P_1));
					thumbHeight = P_1;
				}
				else
				{
					thumbWidth = P_1;
					thumbHeight = (int)Math.Round((double)P_0.Height / ((double)P_0.Width / (double)P_1));
				}
				return P_0.GetThumbnailImage(thumbWidth, thumbHeight, null, default(IntPtr));
			}
			return P_0;
		}
	}

	public static Bitmap m_77(Bitmap P_0, double P_1)
	{
		Bitmap result = null;
		checked
		{
			try
			{
				int num;
				int num2;
				int x;
				int y;
				if (P_0.Width >= P_0.Height)
				{
					num = (int)Math.Round((double)P_0.Height / P_1);
					num2 = P_0.Height;
					x = (int)Math.Round((double)(P_0.Width - num) / 2.0);
					y = 0;
				}
				else
				{
					num = P_0.Width;
					num2 = (int)Math.Round((double)P_0.Width / P_1);
					x = 0;
					y = (int)Math.Round((double)(P_0.Height - num2) / 2.0);
				}
				Rectangle rect = new Rectangle(x, y, num, num2);
				result = P_0.Clone(rect, P_0.PixelFormat);
				P_0.Dispose();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static int m_78(this CustomPropertyManager P_0, string P_1, string P_2, string P_3)
	{
		int num = 0;
		P_0.Delete(P_1);
		num = P_0.Add2(P_1, Conversions.ToInteger(P_2), P_3);
		if (num == 1)
		{
			return 0;
		}
		return 1;
	}

	public static void m_79(string P_0, string P_1)
	{
		string path = Type_16.m_53(P_1);
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		try
		{
			using StreamWriter streamWriter = File.AppendText(P_1);
			streamWriter.WriteLine(P_0);
			streamWriter.Flush();
		}
		catch (IOException ex)
		{
			ProjectData.SetProjectError(ex);
			IOException ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
