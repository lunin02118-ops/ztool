using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace ZTool;

internal class GetRegistrycreatedtime
{
	[Flags]
	public enum RegOption
	{
		NonVolatile = 0,
		Volatile = 1,
		CreateLink = 2,
		BackupRestore = 4,
		OpenLink = 8
	}

	[Flags]
	public enum RegSAM
	{
		QueryValue = 1,
		SetValue = 2,
		CreateSubKey = 4,
		EnumerateSubKeys = 8,
		Notify = 0x10,
		CreateLink = 0x20,
		WOW64_32Key = 0x200,
		WOW64_64Key = 0x100,
		WOW64_Res = 0x300,
		Read = 0x20019,
		Write = 0x20006,
		Execute = 0x20019,
		AllAccess = 0xF003F
	}

	public enum RegResult
	{
		CreatedNewKey = 1,
		OpenedExistingKey
	}

	public enum RootName : uint
	{
		HKEY_CLASSES_ROOT = 2147483648u,
		HKEY_CURRENT_USER = 2147483649u,
		HKEY_LOCAL_MACHINE = 2147483650u,
		HKEY_USERS = 2147483651u,
		HKEY_CURRENT_CONFIG = 2147483653u
	}

	[DebuggerNonUserCode]
	public GetRegistrycreatedtime()
	{
	}

	[DllImport("advapi32.dll")]
	private static extern int RegEnumKeyEx(UIntPtr hkey, uint index, StringBuilder lpName, ref uint lpcbName, IntPtr reserved, IntPtr lpClass, IntPtr lpcbClass, ref long lpftLastWriteTime);

	[DllImport("advapi32.dll")]
	private static extern int RegCreateKeyEx(UIntPtr hKey, string lpSubKey, IntPtr Reserved, string lpClass, RegOption dwOptions, RegSAM samDesired, ref IntPtr lpSecurityAttributes, ref UIntPtr phkResult, ref RegResult lpdwDisposition);

	[DllImport("advapi32.dll")]
	private static extern int RegCloseKey(UIntPtr hKey);

	private static long GetRegistryKeyValue(RootName rootKeyName, string subKeyName, int index)
	{
		UIntPtr hKey = new UIntPtr((uint)rootKeyName);
		UIntPtr phkResult = UIntPtr.Zero;
		IntPtr lpSecurityAttributes = IntPtr.Zero;
		RegResult lpdwDisposition = (RegResult)0;
		int num = RegCreateKeyEx(hKey, subKeyName, IntPtr.Zero, null, RegOption.NonVolatile, RegSAM.EnumerateSubKeys | RegSAM.WOW64_64Key, ref lpSecurityAttributes, ref phkResult, ref lpdwDisposition);
		uint lpcbName = 100u;
		StringBuilder lpName = new StringBuilder();
		long lpftLastWriteTime = 0L;
		uint index2 = checked((uint)index);
		int num2 = RegEnumKeyEx(phkResult, index2, lpName, ref lpcbName, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref lpftLastWriteTime);
		if (phkResult != UIntPtr.Zero)
		{
			RegCloseKey(phkResult);
		}
		return lpftLastWriteTime;
	}

	public static string getregistryKeytime(RootName rootKeyName, string KeyName)
	{
		string result = "";
		checked
		{
			try
			{
				RegistryKey registryKey = null;
				string text = Strings.Right(KeyName, Strings.Len(KeyName) - Strings.InStrRev(KeyName, "\\"));
				KeyName = Strings.Left(KeyName, Strings.InStrRev(KeyName, "\\") - 1);
				RegistryKeyPermissionCheck permissionCheck = RegistryKeyPermissionCheck.Default;
				RegistryRights rights = RegistryRights.ExecuteKey;
				RegistryKey registryKey2 = null;
				switch (unchecked((uint)rootKeyName))
				{
				case 2147483648u:
					registryKey2 = Registry.ClassesRoot;
					break;
				case 2147483653u:
					registryKey2 = Registry.CurrentConfig;
					break;
				case 2147483649u:
					registryKey2 = Registry.CurrentUser;
					break;
				case 2147483650u:
					registryKey2 = Registry.LocalMachine;
					break;
				case 2147483651u:
					registryKey2 = Registry.Users;
					break;
				}
				if (!Information.IsNothing(registryKey2))
				{
					registryKey = registryKey2.OpenSubKey(KeyName, permissionCheck, rights);
				}
				if (!Information.IsNothing(registryKey))
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					if (subKeyNames.Length > 0)
					{
						int num = subKeyNames.Length - 1;
						int num2 = 0;
						while (true)
						{
							int num3 = num2;
							int num4 = num;
							if (num3 <= num4)
							{
								if (text.Equals(subKeyNames[num2], StringComparison.OrdinalIgnoreCase))
								{
									long registryKeyValue = GetRegistryKeyValue(rootKeyName, KeyName, num2);
									result = DateTime.FromFileTime(registryKeyValue).ToString("yyyy/M/d HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
								}
								num2++;
								continue;
							}
							break;
						}
					}
				}
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
}
