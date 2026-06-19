using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class SecurityCenter
{
	[DebuggerNonUserCode]
	public SecurityCenter()
	{
	}

	public string EncriptStr(string Source, string Key)
	{
		string result;
		try
		{
			Aes aes = Aes.Create("AES");
			byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(Key));
			aes.BlockSize = checked(array.Length * 8);
			aes.Key = array;
			aes.IV = array;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform cryptoTransform = aes.CreateEncryptor();
			byte[] bytes = Encoding.Unicode.GetBytes(Source);
			result = Convert.ToBase64String(cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string DecriptStr(string EncodedStr, string Key)
	{
		string result;
		try
		{
			Aes aes = Aes.Create("AES");
			byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(Key));
			aes.BlockSize = checked(array.Length * 8);
			aes.Key = array;
			aes.IV = array;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			ICryptoTransform cryptoTransform = aes.CreateDecryptor();
			byte[] array2 = Convert.FromBase64String(EncodedStr);
			result = Encoding.Unicode.GetString(cryptoTransform.TransformFinalBlock(array2, 0, array2.Length));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
