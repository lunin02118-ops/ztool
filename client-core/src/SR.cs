using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZTool.My.Resources;
using ZTool.PhysicalDrive2;
using ZTool_rsa;

namespace ZTool;

internal class SR
{
	protected const string FmaA9ODlwi = "F827CF462F62848DF37C5E1E94A4DA74";

	protected const string CI4odxcMT6 = "F8320B26D30AB433C5A54546D21F414C";

	[DebuggerNonUserCode]
	public SR()
	{
	}

	public bool Isme(string k)
	{
		bool result = false;
		try
		{
			if (Operators.CompareString(k, "冰雨。。。", TextCompare: false) != 0)
			{
				return false;
			}
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			baseDirectory = Path.GetDirectoryName(baseDirectory);
			baseDirectory = Path.Combine(baseDirectory, "ZToolARM.dll");
			if (File.Exists(baseDirectory))
			{
				FileInfo fileInfo = new FileInfo(baseDirectory);
				using Stream inputStream = fileInfo.OpenRead();
				using MD5 mD = new MD5CryptoServiceProvider();
				byte[] inArray = mD.ComputeHash(inputStream);
				if (Operators.CompareString(code.GD51(Convert.ToBase64String(inArray)), Resources.G_D5V, TextCompare: false) == 0)
				{
					result = true;
				}
			}
			else
			{
				MessageBox.Show("«ZToolARM.dll» отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string GetDiskSN1()
	{
		string text = "";
		return text.Trim();
	}

	public string GetDiskSN1_1()
	{
		string text = "";
		try
		{
			text = HardDisk.GetSerialNo(0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return text.Trim();
	}

	public string GetDiskSN2()
	{
		string text = "";
		return text.Trim();
	}

	public string GetDiskSN2_1()
	{
		string text = "";
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_PhysicalMedia");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				text = managementObject["SerialNumber"].ToString().Trim();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return text.Trim();
	}

	public string GetMac()
	{
		string text = "";
		try
		{
			text = MacAddress.GetNic();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return text.Trim();
	}

	public string GetBoardId()
	{
		string text = "";
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				text = managementObject["SerialNumber"].ToString().Trim();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return text.Trim();
	}

	public string GetUUID()
	{
		string text = "";
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_ComputerSystemProduct");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator())
			{
				if (managementObjectEnumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
					text = Conversions.ToString(NewLateBinding.LateGet(managementObject["UUID"], null, "Trim", new object[0], null, null, null));
				}
			}
			Regex regex = new Regex("^[A-F0-9]{8}(-[A-F0-9]{4}){3}-[A-F0-9]{12}$", RegexOptions.IgnoreCase);
			if (regex.IsMatch(text))
			{
				string pattern = text.Substring(0, 1);
				if (Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count == 32)
				{
					text = "";
				}
			}
			else
			{
				text = "";
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			text = "";
			ProjectData.ClearProjectError();
		}
		return text;
	}

	public string GetMNum(string key, bool Encrypt = true, bool withversion = true)
	{
		string result;
		if (Operators.CompareString(key, "忘情水。。。", TextCompare: false) != 0)
		{
			result = "";
		}
		else
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			try
			{
				text4 = GetUUID();
				text3 = GetDiskSN1_1();
				if (Operators.CompareString(text3, "", TextCompare: false) == 0)
				{
					text3 = GetDiskSN2_1();
				}
				text2 = GetBoardId();
				if (Operators.CompareString(text4, "", TextCompare: false) == 0 || ((Operators.CompareString(text3, "", TextCompare: false) == 0 && Operators.CompareString(text2, "", TextCompare: false) == 0) ? true : false))
				{
					result = "";
					goto IL_01a1;
				}
				text = text4 + "|" + text3 + "|" + text2;
				text = text.Trim('|');
				if (withversion)
				{
					text = text + "\r\n" + code.getver("今天。。。");
				}
				text = Strings.Mid(text, 1, 117);
				text = ((!Encrypt) ? code.GD51(text) : RSAHelper.EncryptString(text, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string str = $"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}\r\n";
				logopathlist.WriteLog(str);
				result = "";
				ProjectData.ClearProjectError();
				goto IL_01a1;
			}
			result = text.Trim();
		}
		goto IL_01a1;
		IL_01a1:
		return result;
	}

	public bool IsReg1(string key, [Optional][DefaultParameterValue("")] ref string code, [Optional][DefaultParameterValue("")] ref string use_date)
	{
		checked
		{
			bool result;
			if (Operators.CompareString(key, "来生缘。。。", TextCompare: false) != 0)
			{
				result = false;
			}
			else
			{
				try
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\SolURxxCfNU\\C4eHN4fjikBan", writable: false);
					byte[] array = (byte[])registryKey.GetValue("information");
					registryKey.Close();
					registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\Jlj4aG8uZBvW", writable: false);
					byte[] array2 = (byte[])registryKey.GetValue("F2S6qCdziIAm");
					registryKey.Close();
					registryKey = Registry.LocalMachine.OpenSubKey("Software\\SolURxxCfNU\\HTwk2RCBDL", writable: false);
					byte[] array3 = (byte[])registryKey.GetValue("information");
					registryKey.Close();
					registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\98CqyvBZcg", writable: false);
					byte[] array4 = (byte[])registryKey.GetValue("information");
					registryKey.Close();
					if ((Information.IsNothing(array) || Information.IsNothing(array2) || Information.IsNothing(array3) || Information.IsNothing(array4)) ? true : false)
					{
						result = false;
					}
					else
					{
						string text = ZTool.code.FromHexString(Encoding.UTF8.GetString(array)).Trim();
						string text2 = ZTool.code.FromHexString(Encoding.UTF8.GetString(array2)).Trim();
						string text3 = ZTool.code.FromHexString(Encoding.UTF8.GetString(array3)).Trim();
						string text4 = ZTool.code.FromHexString(Encoding.UTF8.GetString(array4)).Trim();
						text = text.Replace("\0", string.Empty);
						text2 = text2.Replace("\0", string.Empty);
						text3 = text3.Replace("\0", string.Empty);
						text4 = text4.Replace("\0", string.Empty);
						SecurityCenter securityCenter = new SecurityCenter();
						string text5 = "";
						string text6 = "";
						text5 = Strings.Right(text3, 10) + Strings.Left(text3, 9);
						text6 = text3.Substring(9, Strings.Len(text3) - 19);
						text3 = securityCenter.DecriptStr(text6, text5);
						text3 = RSAHelper.DecryptString(text3, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An").Trim();
						text5 = Strings.Right(text4, 10) + Strings.Left(text4, 9);
						text6 = text4.Substring(9, Strings.Len(text4) - 19);
						text4 = securityCenter.DecriptStr(text6, text5);
						text4 = RSAHelper.DecryptString(text4, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An").Trim();
						text5 = Strings.Right(text2, 10) + Strings.Left(text2, 7);
						text6 = text2.Substring(7, Strings.Len(text2) - Strings.Len(text5));
						text2 = securityCenter.DecriptStr(text6, text5).Trim();
						string[] array5 = Strings.Split(text2.Trim(), "\n");
						string key2 = "";
						string text7 = "";
						string text8 = "";
						if (array5.Count() == 2)
						{
							key2 = RSAHelper.DecryptString(array5[0], "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An").Trim();
							text7 = securityCenter.DecriptStr(array5[1], key2).Trim();
							text = securityCenter.DecriptStr(text, key2);
						}
						string[] array6 = Strings.Split(text.Trim(), "\n");
						if (array6.Count() == 3)
						{
							code = RSAHelper.DecryptString(array6[0], text7).Trim();
							use_date = RSAHelper.DecryptString(array6[2], text7).Trim();
							text8 = RSAHelper.DecryptString(array6[1], text7).Trim();
							text8 = securityCenter.DecriptStr(text8, key2);
						}
						result = ((Strings.Len(code) == 36 && Operators.CompareString(text8, "", TextCompare: false) != 0 && Operators.CompareString(text3, "", TextCompare: false) != 0 && Operators.CompareString(text4, "", TextCompare: false) != 0) || 1 == 0) && (((Operators.CompareString(text8, GetMNum("忘情水。。。", Encrypt: false, withversion: false), TextCompare: false) == 0 && Operators.CompareString(text3 + text4, text8, TextCompare: false) == 0 && Conversions.ToDouble(use_date) == 0.0) ? true : false) ? true : false);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
					result = false;
					ProjectData.ClearProjectError();
				}
			}
			return result;
		}
	}

	public bool IsReg2(string key, [Optional][DefaultParameterValue("")] ref string code, [Optional][DefaultParameterValue("")] ref string use_date)
	{
		checked
		{
			bool result;
			if (Operators.CompareString(key, "来生缘。。。", TextCompare: false) != 0)
			{
				result = false;
			}
			else
			{
				try
				{
					SecurityCenter securityCenter = new SecurityCenter();
					string txt = GetRegistrycreatedtime.getregistryKeytime(GetRegistrycreatedtime.RootName.HKEY_LOCAL_MACHINE, "Software\\SolURxxCfNU\\HTwk2RCBDL");
					string txt2 = GetRegistrycreatedtime.getregistryKeytime(GetRegistrycreatedtime.RootName.HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\98CqyvBZcg");
					txt = ZTool.code.GD51(txt);
					txt2 = ZTool.code.GD51(txt2);
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\SolURxxCfNU\\C4eHN4fjikBan", writable: false);
					byte[] array = (byte[])registryKey.GetValue("information");
					registryKey.Close();
					registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\Jlj4aG8uZBvW", writable: false);
					byte[] array2 = (byte[])registryKey.GetValue("F2S6qCdziIAm");
					registryKey.Close();
					registryKey = Registry.LocalMachine.OpenSubKey("Software\\SolURxxCfNU\\HTwk2RCBDL", writable: false);
					byte[] array3 = (byte[])registryKey.GetValue("information");
					registryKey.Close();
					registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\98CqyvBZcg", writable: false);
					byte[] array4 = (byte[])registryKey.GetValue("information");
					registryKey.Close();
					if ((Information.IsNothing(array) || Information.IsNothing(array2) || Information.IsNothing(array3) || Information.IsNothing(array4)) ? true : false)
					{
						result = false;
					}
					else
					{
						string text = ZTool.code.FromHexString(Encoding.UTF8.GetString(array));
						string text2 = ZTool.code.FromHexString(Encoding.UTF8.GetString(array2));
						string text3 = ZTool.code.FromHexString(Encoding.UTF8.GetString(array3));
						string text4 = ZTool.code.FromHexString(Encoding.UTF8.GetString(array4));
						text = text.Replace("\0", string.Empty);
						text2 = text2.Replace("\0", string.Empty);
						text3 = text3.Replace("\0", string.Empty);
						text4 = text4.Replace("\0", string.Empty);
						string text5 = "";
						string text6 = "";
						text5 = Strings.Right(text3, 10) + Strings.Left(text3, 9);
						text6 = text3.Substring(9, Strings.Len(text3) - Strings.Len(text5));
						text3 = securityCenter.DecriptStr(text6, text5);
						text3 = RSAHelper.DecryptString(text3, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An").Trim();
						text5 = Strings.Right(text4, 10) + Strings.Left(text4, 9);
						text6 = text4.Substring(9, Strings.Len(text4) - Strings.Len(text5));
						text4 = securityCenter.DecriptStr(text6, text5);
						text4 = RSAHelper.DecryptString(text4, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An").Trim();
						text = securityCenter.DecriptStr(text, txt);
						text2 = securityCenter.DecriptStr(text2, txt2);
						string[] array5 = Strings.Split(text2.Trim(), "\n");
						string key2 = "";
						string text7 = "";
						string left = "";
						if (array5.Count() == 2)
						{
							key2 = RSAHelper.DecryptString(array5[0], "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An").Trim();
							text7 = securityCenter.DecriptStr(array5[1], key2);
						}
						string[] array6 = Strings.Split(text.Trim(), "\n");
						if (array6.Count() == 3)
						{
							code = RSAHelper.DecryptString(array6[0], text7).Trim();
							use_date = RSAHelper.DecryptString(array6[2], text7).Trim();
							left = RSAHelper.DecryptString(array6[1], text7).Trim();
							left = securityCenter.DecriptStr(left, key2).Trim();
						}
						if ((Strings.Len(code) != 36 || Operators.CompareString(left, "", TextCompare: false) == 0 || Operators.CompareString(text3, "", TextCompare: false) == 0 || Operators.CompareString(text4, "", TextCompare: false) == 0) ? true : false)
						{
							result = false;
						}
						else if ((Operators.CompareString(left, GetMNum("忘情水。。。", Encrypt: false, withversion: false), TextCompare: false) == 0 && Operators.CompareString(left, text3 + text4, TextCompare: false) == 0 && Conversions.ToDouble(use_date) == 0.0) ? true : false)
						{
							registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", writable: true).CreateSubKey("ZTool");
							registryKey.SetValue("sn", code, RegistryValueKind.String);
							registryKey.Close();
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
					result = false;
					ProjectData.ClearProjectError();
				}
			}
			return result;
		}
	}

	public void writeini()
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", writable: true).CreateSubKey("ZTool");
			registryKey.SetValue("AppDataPath", Application.ExecutablePath, RegistryValueKind.String);
			registryKey.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public bool rg(string Receive)
	{
		bool result;
		try
		{
			SecurityCenter securityCenter = new SecurityCenter();
			string[] array = Strings.Split(securityCenter.DecriptStr(Receive.Trim(), code.getver("今天。。。", md5: true)), "\t");
			if (array.Count() == 4)
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software", writable: true).CreateSubKey("SolURxxCfNU").CreateSubKey("C4eHN4fjikBan");
				registryKey.SetValue("information", Encoding.UTF8.GetBytes(code.ToHexString(array[0])), RegistryValueKind.Binary);
				registryKey.Close();
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true).CreateSubKey("MzORu8qE4HhZ").CreateSubKey("Jlj4aG8uZBvW");
				registryKey.SetValue("F2S6qCdziIAm", Encoding.UTF8.GetBytes(code.ToHexString(array[1])), RegistryValueKind.Binary);
				registryKey.Close();
				registryKey = Registry.LocalMachine.OpenSubKey("Software", writable: true).CreateSubKey("SolURxxCfNU").CreateSubKey("HTwk2RCBDL");
				registryKey.SetValue("information", Encoding.UTF8.GetBytes(code.ToHexString(array[2])), RegistryValueKind.Binary);
				registryKey.Close();
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true).CreateSubKey("MzORu8qE4HhZ").CreateSubKey("98CqyvBZcg");
				registryKey.SetValue("information", Encoding.UTF8.GetBytes(code.ToHexString(array[3])), RegistryValueKind.Binary);
				registryKey.Close();
				result = true;
			}
			else if (array.Count() == 2)
			{
				RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("Software", writable: true).CreateSubKey("SolURxxCfNU").CreateSubKey("C4eHN4fjikBan");
				registryKey2.SetValue("information", Encoding.UTF8.GetBytes(code.ToHexString(array[0])), RegistryValueKind.Binary);
				registryKey2.Close();
				registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true).CreateSubKey("MzORu8qE4HhZ").CreateSubKey("Jlj4aG8uZBvW");
				registryKey2.SetValue("F2S6qCdziIAm", Encoding.UTF8.GetBytes(code.ToHexString(array[1])), RegistryValueKind.Binary);
				registryKey2.Close();
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool outrg(string Receive)
	{
		bool result;
		try
		{
			SecurityCenter securityCenter = new SecurityCenter();
			string[] array = Strings.Split(securityCenter.DecriptStr(Receive.Trim(), code.getver("今天。。。", md5: true)), "\t");
			if (array.Count() == 4)
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software", writable: true).CreateSubKey("SolURxxCfNU").CreateSubKey("C4eHN4fjikBan");
				registryKey.SetValue("information", Encoding.UTF8.GetBytes(code.ToHexString(array[0])), RegistryValueKind.Binary);
				registryKey.Close();
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true).CreateSubKey("MzORu8qE4HhZ").CreateSubKey("Jlj4aG8uZBvW");
				registryKey.SetValue("F2S6qCdziIAm", Encoding.UTF8.GetBytes(code.ToHexString(array[1])), RegistryValueKind.Binary);
				registryKey.Close();
				registryKey = Registry.LocalMachine.OpenSubKey("Software", writable: true).CreateSubKey("SolURxxCfNU").CreateSubKey("HTwk2RCBDL");
				registryKey.SetValue("information", Encoding.UTF8.GetBytes(code.ToHexString(array[2])), RegistryValueKind.Binary);
				registryKey.Close();
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true).CreateSubKey("MzORu8qE4HhZ").CreateSubKey("98CqyvBZcg");
				registryKey.SetValue("information", Encoding.UTF8.GetBytes(code.ToHexString(array[3])), RegistryValueKind.Binary);
				registryKey.Close();
				result = true;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string get_rgtime()
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			string text = GetRegistrycreatedtime.getregistryKeytime(GetRegistrycreatedtime.RootName.HKEY_LOCAL_MACHINE, "SOFTWARE\\SolURxxCfNU\\HTwk2RCBDL");
			string text2 = GetRegistrycreatedtime.getregistryKeytime(GetRegistrycreatedtime.RootName.HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\98CqyvBZcg");
			stringBuilder.AppendLine(RSAHelper.EncryptString(text, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
			stringBuilder.AppendLine(RSAHelper.EncryptString(text2, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		return stringBuilder.ToString().Trim();
	}

	public string get_rginfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", writable: true).CreateSubKey("SolURxxCfNU").CreateSubKey("C4eHN4fjikBan");
			byte[] array = (byte[])registryKey.GetValue("information");
			registryKey.Close();
			registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true).CreateSubKey("MzORu8qE4HhZ").CreateSubKey("Jlj4aG8uZBvW");
			byte[] array2 = (byte[])registryKey.GetValue("F2S6qCdziIAm");
			registryKey.Close();
			registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", writable: true).CreateSubKey("SolURxxCfNU").CreateSubKey("HTwk2RCBDL");
			byte[] array3 = (byte[])registryKey.GetValue("information");
			registryKey.Close();
			registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", writable: true).CreateSubKey("MzORu8qE4HhZ").CreateSubKey("98CqyvBZcg");
			byte[] array4 = (byte[])registryKey.GetValue("information");
			registryKey.Close();
			if ((!Information.IsNothing(array) && !Information.IsNothing(array2) && !Information.IsNothing(array3) && !Information.IsNothing(array4)) ? true : false)
			{
				string text = GetRegistrycreatedtime.getregistryKeytime(GetRegistrycreatedtime.RootName.HKEY_LOCAL_MACHINE, "SOFTWARE\\SolURxxCfNU\\HTwk2RCBDL");
				string text2 = GetRegistrycreatedtime.getregistryKeytime(GetRegistrycreatedtime.RootName.HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\98CqyvBZcg");
				stringBuilder.AppendLine(code.FromHexString(Encoding.UTF8.GetString(array)));
				stringBuilder.AppendLine(code.FromHexString(Encoding.UTF8.GetString(array2)));
				stringBuilder.AppendLine(code.FromHexString(Encoding.UTF8.GetString(array3)));
				stringBuilder.AppendLine(code.FromHexString(Encoding.UTF8.GetString(array4)));
				stringBuilder.AppendLine(RSAHelper.EncryptString(text, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
				stringBuilder.AppendLine(RSAHelper.EncryptString(text2, "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
				stringBuilder.AppendLine(RSAHelper.EncryptString(DateTime.Now.ToString(), "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An"));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"异常类型：{ex2.GetType().Name}\r\n异常消息：{ex2.Message}\r\n异常信息：{ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		return stringBuilder.ToString().Trim();
	}
}
