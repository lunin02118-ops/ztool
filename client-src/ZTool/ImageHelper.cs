using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[StandardModule]
internal sealed class ImageHelper
{
	public static byte[] ImageToBytes(Image image)
	{
		using MemoryStream memoryStream = new MemoryStream();
		image.Save(memoryStream, ImageFormat.Png);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		return memoryStream.GetBuffer();
	}

	public static Image BytesToImage(byte[] buffer)
	{
		Image result = null;
		try
		{
			using MemoryStream memoryStream = new MemoryStream(buffer);
			result = Image.FromStream(memoryStream);
			memoryStream.Close();
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
