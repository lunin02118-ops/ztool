using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;

[StandardModule]
internal sealed class Type_15
{
	public static string m_45(string P_0)
	{
		if (!File.Exists(P_0))
		{
			return "";
		}
		string result;
		try
		{
			AssemblyName assemblyName = AssemblyName.GetAssemblyName(P_0);
			result = assemblyName.Name;
		}
		catch (BadImageFormatException ex)
		{
			ProjectData.SetProjectError(ex);
			BadImageFormatException ex2 = ex;
			Console.WriteLine("Ошибка: файл не является допустимой сборкой .NET." + ex2.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		catch (FileNotFoundException ex3)
		{
			ProjectData.SetProjectError(ex3);
			FileNotFoundException ex4 = ex3;
			Console.WriteLine("Ошибка: файл не найден." + ex4.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			Console.WriteLine("Ошибка получения имени: " + ex6.Message);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
