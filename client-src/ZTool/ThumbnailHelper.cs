using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class ThumbnailHelper
{
	private static object ooo = RuntimeHelpers.GetObjectValue(new object());

	private static ThumbnailHelper _ThumbnailHelper;

	private ThumbnailHelper()
	{
	}

	public static ThumbnailHelper GetInstance()
	{
		if (_ThumbnailHelper == null)
		{
			object obj = ooo;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				if (_ThumbnailHelper == null)
				{
					_ThumbnailHelper = new ThumbnailHelper();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		return _ThumbnailHelper;
	}

	public Bitmap GetBitmapThumbnail(string fileName, int width = 256, int height = 129, Win32Helper.ThumbnailOptions options = Win32Helper.ThumbnailOptions.None)
	{
		IntPtr hBitmap = GetHBitmap(Path.GetFullPath(fileName), width, height, options);
		try
		{
			return Image.FromHbitmap(hBitmap);
		}
		finally
		{
			Win32Helper.DeleteObject(hBitmap);
		}
	}

	private Bitmap CreateAlphaBitmap(Bitmap srcBitmap, PixelFormat targetPixelFormat)
	{
		Bitmap bitmap = new Bitmap(srcBitmap.Width, srcBitmap.Height, targetPixelFormat);
		Rectangle rect = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
		BitmapData bitmapData = srcBitmap.LockBits(rect, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
		bool flag = false;
		checked
		{
			try
			{
				for (int i = 0; i <= bitmapData.Height - 1; i++)
				{
					for (int j = 0; j <= bitmapData.Width - 1; j++)
					{
						Color color = Color.FromArgb(Marshal.ReadInt32(bitmapData.Scan0, bitmapData.Stride * i + 4 * j));
						if ((color.A > 0) & (color.A < byte.MaxValue))
						{
							flag = true;
						}
						bitmap.SetPixel(j, i, color);
					}
				}
			}
			finally
			{
				srcBitmap.UnlockBits(bitmapData);
			}
			if (flag)
			{
				return bitmap;
			}
			return srcBitmap;
		}
	}

	private IntPtr GetHBitmap(string fileName, int width, int height, Win32Helper.ThumbnailOptions options)
	{
		Win32Helper.IShellItem shellItem = null;
		Guid riid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
		int num = Win32Helper.SHCreateItemFromParsingName(fileName, IntPtr.Zero, ref riid, ref shellItem);
		if (num != 0)
		{
			throw Marshal.GetExceptionForHR(num);
		}
		Win32Helper.NativeSize size = new Win32Helper.NativeSize
		{
			Width = width,
			Height = height
		};
		IntPtr phbm = default(IntPtr);
		Win32Helper.HResult image = ((Win32Helper.IShellItemImageFactory)shellItem).GetImage(size, options, out phbm);
		Marshal.ReleaseComObject(shellItem);
		if (image == Win32Helper.HResult.Ok)
		{
			return phbm;
		}
		throw Marshal.GetExceptionForHR(checked((int)image));
	}
}
