using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class MacAddress
{
	[DebuggerNonUserCode]
	public MacAddress()
	{
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern bool DeviceIoControl(IntPtr HDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, IntPtr lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, IntPtr lpOverlapped);

	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle(IntPtr hObject);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

	public static string GetNicAddress(string NicId)
	{
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			try
			{
				IntPtr intPtr = CreateFile("\\\\.\\" + NicId, 3221225472u, 0u, IntPtr.Zero, 3u, 4u, IntPtr.Zero);
				if (intPtr.ToInt32() == -1)
				{
					return string.Empty;
				}
				uint lpBytesReturned = 0u;
				IntPtr intPtr2 = Marshal.AllocHGlobal(256);
				Marshal.WriteInt32(intPtr2, 16843009);
				if (!DeviceIoControl(intPtr, 1507330u, intPtr2, 4u, intPtr2, 256u, ref lpBytesReturned, IntPtr.Zero))
				{
					Marshal.FreeHGlobal(intPtr2);
					CloseHandle(intPtr);
					return string.Empty;
				}
				byte[] array = new byte[6];
				Marshal.Copy(intPtr2, array, 0, 6);
				Marshal.FreeHGlobal(intPtr2);
				CloseHandle(intPtr);
				int num = array.Length - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						stringBuilder.Append(array[num2].ToString("X2"));
						if (num2 != array.Length - 1)
						{
							stringBuilder.Append(":");
						}
						num2++;
						continue;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return stringBuilder.ToString();
		}
	}

	public static string GetNic()
	{
		string text = "";
		string text2 = "";
		try
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in allNetworkInterfaces)
			{
				if (Information.IsNothing(networkInterface) || string.IsNullOrEmpty(networkInterface.Id) || false || ((Strings.InStr(networkInterface.Description, "Bluetooth", CompareMethod.Text) > 0) | (Strings.InStr(networkInterface.Description, "Virtual", CompareMethod.Text) > 0)))
				{
					continue;
				}
				if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
				{
					if (Operators.CompareString(text2, "", TextCompare: false) == 0)
					{
						text2 = GetNicAddress(networkInterface.Id.ToString());
					}
				}
				else if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && Operators.CompareString(text, "", TextCompare: false) == 0)
				{
					text = GetNicAddress(networkInterface.Id.ToString());
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (Operators.CompareString(text2, "", TextCompare: false) != 0)
		{
			return text2;
		}
		if (Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			return text;
		}
		return "";
	}
}
