using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZTool.JDK;

namespace ZTool;

[StandardModule]
internal sealed class Program
{
	[CompilerGenerated]
	internal class _Closure_0024__1
	{
		public string _0024VB_0024Local_resourceName;

		[DebuggerNonUserCode]
		public _Closure_0024__1()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__1(_Closure_0024__1 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_resourceName = other._0024VB_0024Local_resourceName;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__2(string element)
		{
			return element.EndsWith(_0024VB_0024Local_resourceName);
		}
	}

	public static string StartType;

	private static byte[] Keys = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };

	[STAThread]
	public static void Main(string[] args)
	{
		if (!code.HasShell("笨小孩。。。"))
		{
			return;
		}
		checkdebug checkdebug2 = new checkdebug();
		if (Environment.OSVersion.Version.Major >= 6)
		{
			code.SetProcessDPIAware();
		}
		Application.ThreadException += Application_ThreadException;
		AppDomain.CurrentDomain.AssemblyResolve += _Lambda_0024__1;
		AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		try
		{
			if (args.Length == 0)
			{
				StartType = Conversions.ToString(0);
			}
			else if (args.Length == 2)
			{
				StartType = args[1];
			}
			else if (args.Length == 3)
			{
				if (int.Parse(args[0]) >= 22)
				{
					code.MacroVer = int.Parse(args[0]);
					code.CurSWID = Conversions.ToInteger(args[1]);
					StartType = args[2];
				}
			}
			else if (args.Length == 4 && int.Parse(args[0]) >= 22)
			{
				code.MacroVer = int.Parse(args[0]);
				code.CurSWID = Conversions.ToInteger(args[1]);
				StartType = args[2];
				code.Receiver_hWnd = (IntPtr)Conversions.ToLong(args[3]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			string str = $"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}\r\n";
			logopathlist.WriteLog(str);
			ProjectData.ClearProjectError();
		}
		try
		{
			SR sR = new SR();
			if (sR.Isme("冰雨。。。"))
			{
				sR.writeini();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(defaultValue: false);
				Application.Run(new MyapplicationContext());
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			string str2 = $"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}\r\n";
			logopathlist.WriteLog(str2);
			Environment.Exit(0);
			ProjectData.ClearProjectError();
		}
	}

	public static object CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
	{
		_Closure_0024__1 closure_0024__ = new _Closure_0024__1();
		closure_0024__._0024VB_0024Local_resourceName = new AssemblyName(args.Name).Name + ".dll";
		string name = Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), closure_0024__._Lambda_0024__2);
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
		byte[] array = new byte[checked((int)(stream.Length - 1) + 1)];
		stream.Read(array, 0, array.Length);
		return Assembly.Load(array);
	}

	public static void CurrentDomain_ProcessExit(object sender, EventArgs args)
	{
		try
		{
			code.StartSwitch(status: false);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(code.swApp)))
			{
				NewLateBinding.LateSet(code.swApp, null, "visible", new object[1] { true }, null, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
	{
		try
		{
			code.StartSwitch(status: false);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(code.swApp)))
			{
				NewLateBinding.LateSet(code.swApp, null, "visible", new object[1] { true }, null, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		string text = "";
		Exception ex3 = args.ExceptionObject as Exception;
		text = ((ex3 == null) ? $"Application UnhandledError:{args}" : $"Application UnhandledException:{ex3.Message};\n\r堆栈信息:{ex3.StackTrace}");
		logopathlist.WriteLog(text);
		MessageBox.Show(ex3.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
	{
		string text = "";
		Exception exception = e.Exception;
		text = ((exception == null) ? $"Ошибка потока приложения:{e}" : $"Тип исключения: {exception.GetType().Name}\r\nСообщение: {exception.Message}\r\nИнформация: {exception.StackTrace}");
		logopathlist.WriteLog(text);
		MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public static string EncryptDES(string encryptString, string encryptKey)
	{
		string result;
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
			byte[] keys = Keys;
			byte[] bytes2 = Encoding.UTF8.GetBytes(encryptString);
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, keys), CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			result = Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = encryptString;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[SpecialName]
	[DebuggerStepThrough]
	[CompilerGenerated]
	private static Assembly _Lambda_0024__1(object a0, ResolveEventArgs a1)
	{
		return (Assembly)CurrentDomain_AssemblyResolve(RuntimeHelpers.GetObjectValue(a0), a1);
	}
}
