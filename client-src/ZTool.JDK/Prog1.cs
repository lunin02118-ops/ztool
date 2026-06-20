using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My.Resources;

namespace ZTool.JDK;

internal class Prog1
{
	[DebuggerNonUserCode]
	public Prog1()
	{
	}

	[DllImport("SWToolsARM.dll", EntryPoint = "JDKey_Enum")]
	public static extern uint JDK_E(ref DONGLE_INFO pDongleInfo, ref int pCount);

	[DllImport("SWToolsARM.dll", EntryPoint = "JDKey_Open")]
	public static extern uint JDK_O(ref uint phDongle, string pPID, int index);

	[DllImport("SWToolsARM.dll", EntryPoint = "JDKey_Close")]
	public static extern uint JDK_C(uint hDongle);

	[DllImport("SWToolsARM.dll", EntryPoint = "JDKey_VerifyPIN")]
	public static extern uint JDK_VP(uint hDongle, int nFlag, string pInPin, ref int pRemainCount);

	[DllImport("SWToolsARM.dll", EntryPoint = "JDKey_GenRandom")]
	public static extern uint JDK_GRd(uint hDongle, int Len_In, byte[] pOutBuf);

	[DllImport("SWToolsARM.dll", EntryPoint = "JDKey_RunARM")]
	public static extern uint JDK_RAM(uint hDongle, ushort appid, byte[] pInBuf, int Len_In, byte[] pOutBuf, ref int pLen_Out);

	public bool exit_g()
	{
		uint num = 0u;
		int pCount = 0;
		int num2 = 0;
		DONGLE_INFO pDongleInfo = default(DONGLE_INFO);
		uint num3 = 0u;
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		bool flag = false;
		bool result;
		try
		{
			if (JDK_E(ref pDongleInfo, ref pCount) == 0)
			{
				text = pDongleInfo.m_ProductID.ToString("x").ToUpper();
				if (Operators.CompareString(GetMd5(text), Resources.G_SN, TextCompare: false) == 0)
				{
					flag = true;
				}
				goto IL_00a1;
			}
			result = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		goto IL_00a7;
		IL_00a1:
		result = flag;
		goto IL_00a7;
		IL_00a7:
		return result;
	}

	public string GetMd5(object text)
	{
		string result = "";
		try
		{
			string text2 = text.ToString();
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = Encoding.Unicode.GetBytes(text.ToString());
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
			result = BitConverter.ToString(array).Replace("-", "");
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
