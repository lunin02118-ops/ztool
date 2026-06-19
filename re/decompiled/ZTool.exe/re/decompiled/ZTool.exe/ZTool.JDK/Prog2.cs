using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.My.Resources;

namespace ZTool.JDK;

internal class Prog2
{
	[DebuggerNonUserCode]
	public Prog2()
	{
	}

	[DllImport("ZToolARM.dll", EntryPoint = "JDKey_Enum")]
	public static extern uint JDK_E(ref DONGLE_INFO pDongleInfo, ref int pCount);

	[DllImport("ZToolARM.dll", EntryPoint = "JDKey_Open")]
	public static extern uint JDK_O(ref uint phDongle, string pPID, int index);

	[DllImport("ZToolARM.dll", EntryPoint = "JDKey_Close")]
	public static extern uint JDK_C(uint hDongle);

	[DllImport("ZToolARM.dll", EntryPoint = "JDKey_VerifyPIN")]
	public static extern uint JDK_VP(uint hDongle, int nFlag, string pInPin, ref int pRemainCount);

	[DllImport("ZToolARM.dll", EntryPoint = "JDKey_GenRandom")]
	public static extern uint JDK_GRd(uint hDongle, int Len_In, byte[] pOutBuf);

	[DllImport("ZToolARM.dll", EntryPoint = "JDKey_RunARM")]
	public static extern uint JDK_RAM(uint hDongle, ushort appid, byte[] pInBuf, int Len_In, byte[] pOutBuf, ref int pLen_Out);

	public string ToHexString(byte[] bytes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			int num = bytes.Length - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				stringBuilder.Append(bytes[num2].ToString("X2"));
				num2++;
			}
			return stringBuilder.ToString();
		}
	}

	public bool exit_g()
	{
		uint num = 0u;
		int pCount = 0;
		int pRemainCount = 0;
		DONGLE_INFO pDongleInfo = default(DONGLE_INFO);
		uint phDongle = 0u;
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
				if (JDK_O(ref phDongle, text, 0) != 0)
				{
					result = false;
				}
				else if (JDK_VP(phDongle, 0, code.St1(Resources.G_PIN), ref pRemainCount) != 0)
				{
					result = false;
				}
				else
				{
					byte[] array = new byte[32];
					byte[] array2 = new byte[2048];
					int pLen_Out = array2.Length;
					int len_In = array.Length;
					ushort appid = 3;
					array[0] = 86;
					array[1] = 23;
					array[2] = 32;
					if (JDK_RAM(phDongle, appid, array, len_In, array2, ref pLen_Out) == 0)
					{
						text2 = ToHexString(array2);
						array = new byte[32];
						array2 = new byte[2048];
						pLen_Out = array2.Length;
						len_In = array.Length;
						array[0] = 87;
						array[1] = 23;
						array[2] = 32;
						if (JDK_RAM(phDongle, appid, array, len_In, array2, ref pLen_Out) == 0)
						{
							text3 = ToHexString(array2);
							array = new byte[32];
							array2 = new byte[2048];
							pLen_Out = array2.Length;
							len_In = array.Length;
							array[0] = 86;
							array[1] = 23;
							array[2] = 32;
							if (JDK_RAM(phDongle, appid, array, len_In, array2, ref pLen_Out) == 0)
							{
								text4 = ToHexString(array2);
								array = new byte[32];
								array2 = new byte[2048];
								pLen_Out = array2.Length;
								len_In = array.Length;
								array[0] = 87;
								array[1] = 23;
								array[2] = 32;
								if (JDK_RAM(phDongle, appid, array, len_In, array2, ref pLen_Out) == 0)
								{
									flag = Conversions.ToBoolean(Interaction.IIf((Operators.CompareString(text2, text3, TextCompare: false) != 0) & (Operators.CompareString(text3, text4, TextCompare: false) == 0), true, false));
									goto IL_02a2;
								}
								result = false;
							}
							else
							{
								result = false;
							}
						}
						else
						{
							result = false;
						}
					}
					else
					{
						result = false;
					}
				}
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
			result = false;
			ProjectData.ClearProjectError();
		}
		finally
		{
			try
			{
				num = JDK_C(phDongle);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
		goto IL_02a8;
		IL_02a2:
		result = flag;
		goto IL_02a8;
		IL_02a8:
		return result;
	}
}
