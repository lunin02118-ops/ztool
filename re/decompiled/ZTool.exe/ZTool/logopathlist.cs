using System;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

[StandardModule]
internal sealed class logopathlist
{
	public static string rootpath = Path.GetTempPath() + "\\ZTool\\";

	public static string logPath = rootpath + "Logs\\";

	public static string PreviewFolder = rootpath + "Preview\\";

	public static string LastLog = rootpath + "LastSelectIDList";

	public static string SetDrwlog = rootpath + "SetDrwlog.txt";

	public static string ConvertDrwlog = rootpath + "ConvertDrwlog.txt";

	public static string LastRecord1 = rootpath + "LastRecord1.txt";

	public static void WriteLog(string str, string logpathname)
	{
		string path = code.SplitStr(logpathname);
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		try
		{
			using StreamWriter streamWriter = File.AppendText(logpathname);
			streamWriter.WriteLine(str);
			streamWriter.Flush();
		}
		catch (IOException ex)
		{
			ProjectData.SetProjectError(ex);
			IOException ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void WriteLog(string str)
	{
		if (!Directory.Exists(logPath))
		{
			Directory.CreateDirectory(logPath);
		}
		string path = logPath + DateTime.Now.ToString("yyyy-MM-dd-HH") + ".log";
		try
		{
			using StreamWriter streamWriter = File.AppendText(path);
			streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\r\n" + Program.EncryptDES(str, "83t00000"));
			streamWriter.WriteLine("**************************************************");
			streamWriter.Flush();
		}
		catch (IOException ex)
		{
			ProjectData.SetProjectError(ex);
			IOException ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
