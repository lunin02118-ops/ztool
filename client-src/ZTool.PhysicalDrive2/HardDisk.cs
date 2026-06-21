using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ZTool.PhysicalDrive2;

internal class HardDisk
{
	private const uint FILE_SHARE_READ = 1u;

	private const uint FILE_SHARE_WRITE = 2u;

	private const uint OPEN_EXISTING = 3u;

	private const uint FILE_DEVICE_MASS_STORAGE = 45u;

	private const uint IOCTL_STORAGE_BASE = 45u;

	private const uint FILE_DEVICE_CONTROLLER = 4u;

	private const uint IOCTL_SCSI_BASE = 4u;

	private const uint METHOD_BUFFERED = 0u;

	private const uint FILE_ANY_ACCESS = 0u;

	private static uint IOCTL_STORAGE_QUERY_PROPERTY = CTL_CODE(45u, 1280u, 0u, 0u);

	[DebuggerNonUserCode]
	public HardDisk()
	{
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern int CloseHandle(IntPtr hObject);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

	[DllImport("Kernel32.dll")]
	public static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref STORAGE_PROPERTY_QUERY lpInBuffer, uint nInBufferSize, ref STORAGE_DEVICE_DESCRIPTOR lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, [Out] IntPtr lpOverlapped);

	private static uint CTL_CODE(uint DeviceType, uint Function, uint Method, uint Access)
	{
		return (DeviceType << 16) | (Access << 14) | (Function << 2) | Method;
	}

	public static string GetSerialNo(byte driveIndex)
	{
		return (int)Environment.OSVersion.Platform switch
		{
			1 => throw new NotSupportedException("Win9x не поддерживается."), 
			2 => GetHddInfoNT(driveIndex), 
			0 => throw new NotSupportedException("Win32s не поддерживается."), 
			3 => throw new NotSupportedException("WinCE не поддерживается."), 
			_ => throw new NotSupportedException("Неизвестная операционная система."), 
		};
	}

	private static string GetHddInfoNT(byte driveIndex)
	{
		uint lpBytesReturned = 0u;
		IntPtr intPtr = CreateFile($"\\\\.\\PhysicalDrive{driveIndex}", 0u, 3u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
		if (intPtr == IntPtr.Zero)
		{
			throw new Exception("CreateFile faild.");
		}
		STORAGE_PROPERTY_QUERY lpInBuffer = new STORAGE_PROPERTY_QUERY
		{
			PropertyId = 0u,
			QueryType = 0u
		};
		STORAGE_DEVICE_DESCRIPTOR lpOutBuffer = default(STORAGE_DEVICE_DESCRIPTOR);
		if (0 == DeviceIoControl(intPtr, IOCTL_STORAGE_QUERY_PROPERTY, ref lpInBuffer, Convert.ToUInt32(Math.Truncate(new decimal(Marshal.SizeOf((object)lpInBuffer)))), ref lpOutBuffer, Convert.ToUInt32(Math.Truncate(new decimal(Marshal.SizeOf((object)lpOutBuffer)))), ref lpBytesReturned, IntPtr.Zero))
		{
			CloseHandle(intPtr);
			throw new Exception($"Drive {driveIndex} error.");
		}
		CloseHandle(intPtr);
		string result = null;
		if ((long)lpOutBuffer.SerialNumberOffset > 0L)
		{
			checked
			{
				int i;
				for (i = 0; lpOutBuffer.RawDeviceProperties[(int)(unchecked((long)lpOutBuffer.SerialNumberOffset) - 35L + i)] != 0; i++)
				{
				}
				i++;
				byte[] array = new byte[i - 1 + 1];
				Array.Copy(lpOutBuffer.RawDeviceProperties, unchecked((long)lpOutBuffer.SerialNumberOffset) - 36L, array, 0L, i);
				result = Encoding.ASCII.GetString(array).Trim();
			}
		}
		return result;
	}
}
