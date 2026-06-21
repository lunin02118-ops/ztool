using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using ZTool.My;
using ZTool.My.Resources;

namespace ZTool;

[StandardModule]
public static class code
{
	public struct dgvdata
	{
		public string pathname;

		public string cfgname;

		public int Quantity;

		public int index;

		public int rowindex;

		public string type;
	}

	public struct msg
	{
		public int type;

		public string time;

		public string row;

		public string description;

		public string operation;

		public string pathname;
	}

	public struct myxlsdata
	{
		public object data;

		public int count;

		public string xlspath;
	}

	public struct COPYDATASTRUCT
	{
		public IntPtr dwData;

		public int cbData;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpData;
	}

	[Serializable]
	public struct BOMPartData
	{
		public int BOMPartNoSource;

		public string BOMPartNumber;

		public string AlternateName;

		public string ParentName;
	}

	public struct updateInf
	{
		public string changetime;

		public string latestversion;

		public string md5;

		public string downloadurl;

		public string changelog;
	}

	public static object swApp;

	public static int propsaveplace;

	public static int DelOtherProp_place;

	public static bool DelOtherProp;

	public static bool DelCurProp_OtherPosition;

	public static int DelCurProp_OtherPosition_place;

	public static bool keepnullvalue;

	public static bool SaveAfterModify;

	public static bool InsertPicBool;

	public static bool canrun = false;

	public static readonly string TTime3 = "3C";

	public static int MacroVer;

	public static int CurSWID;

	public static IntPtr Receiver_hWnd;

	public static string Receiver_Title = "Ztool_Receiver";

	public static bool Dostop = false;

	public static bool EnablePreview = true;

	public static bool EnadleCellEvent = false;

	public static bool checkfilename = true;

	public static bool EnadleMarkrepeat = true;

	public static bool overwrite;

	public static int oldfile_moveto;

	public static string targetpath;

	public static int SaveOptions;

	public static bool DataFromAsm;

	public static bool togetherConfig;

	public static bool SkipReadOnly;

	public static bool Updatereferencebool;

	public static bool UpdatereferenceIncludesubfolders;

	public static string Updatereferencefolder;

	public static bool Insertannotation;

	public static int PWidth;

	public static int PHeight;

	public static int previewformhwnd;

	public const string TTime2 = "F";

	public static int UnitsSystem;

	public static bool CanSetUnit;

	public static int Mass_Length;

	public static int Mass_Mass;

	public static int Mass_Volume;

	public static int Mass_Decimals;

	public static int Basic_Length;

	public static int Basic_Length_Decimals;

	public static int Basic_DualDimension;

	public static int Basic_DualDimension_Decimals;

	public static int Basic_Angle;

	public static int Basic_Angle_Decimals;

	public static int Motion_Time;

	public static int Motion_Force;

	public static int Motion_Power;

	public static int Motion_Energy;

	public static int Motion_Time_Decimal;

	public static int Motion_Force_Decimal;

	public static int Motion_Power_Decimal;

	public static int Motion_Energy_Decimal;

	public const string machine_code_PublicKey = "AwEAAawvVK9CCc8nxZ62EqnMNuF0ZM0zT9ImcrEn1hw4/hLLdGzEqJDbJV2gYWLmJjok1VOtwE84ZHp1dq6P+uoHXMQ+GzY4fSz6JmolZnJrs4nDjbXLlsYwvP+Fz9qyShJTMPxiY9HuQEbnvGfTHXWJKAyCmX6z7Nd6sKRQUduTy8An";

	public static bool TMode = false;

	public const string TTime1 = "C";

	public static int UTTime;

	public const string Sptr = "\t|@#$%|";

	public static Array downlist = new string[17]
	{
		"SW-Материал", "SW-Масса", "SW-Плотность", "SW-Объём", "SW-Площадь поверхности", "SW-Дата создания (Created Date)", "SW-Дата последнего сохранения (Last Saved Date)", "SW-Кто сохранил последним (Last Saved By)", "SW-Имя файла (File Name)", "SW-Имя папки (Folder Name)",
		"SW-Имя конфигурации (Configuration Name)", "SW-Автор (Author)", "SW-Примечания (Comments)", "SW-Тема (Subject)", "SW-Заголовок (Title)", "SW-Ключевые слова (Keywords)", "Текущая дата"
	};

	public static Array downlistvalue = new string[17]
	{
		"\"SW-Material\"",
		"\"SW-Mass\"",
		"\"SW-Density\"",
		"\"SW-Volume\"",
		"\"SW-SurfaceArea\"",
		"$PRP:\"SW-Created Date\"",
		"$PRP:\"SW-Last Saved Date\"",
		"$PRP:\"SW-Last Saved By\"",
		"$PRP:\"SW-File Name\"",
		"$PRP:\"SW-Folder Name\"",
		"$PRP:\"SW-Configuration Name\"",
		"$PRP:\"SW-Author\"",
		"$PRP:\"SW-Comments\"",
		"$PRP:\"SW-Subject\"",
		"$PRP:\"SW-Title\"",
		"$PRP:\"SW-Keywords\"",
		DateTime.Now.ToString("yyyy/MM/dd")
	};

	public static Array connstrlist = new string[4] { "-", "_", " ", "" };

	public static int SWhwnd;

	public static bool g_trig;

	public static Stopwatch T = new Stopwatch();

	public const string RemotePath = "nqi0eG7sRrpI5it9+Thw8wMTW2TQ3vGpzWrnXLNu5zGHCE+ZpbKctzm3ae0j1CDtjKztEf3SNOtuB6aMxBo3Hw==";

	public const string RemoteFileName = "AutoUpdate1.xml";

	public const string ky = "5a546f6f6c2d322e38";

	public static string helpfile = Application.StartupPath + "\\help.CHM";

	public static List<dgvdata> dgvdatalist = new List<dgvdata>();

	public static List<msg> msglist = new List<msg>();

	public static myxlsdata xlsdata = default(myxlsdata);

	public const int WM_HOTKEY = 786;

	public const int MOD_ALT = 1;

	public const int MOD_CONTROL = 2;

	public const int MOD_SHIFT = 4;

	public const int GWL_WNDPROC = -4;

	public const int WM_SETTEXT = 12;

	public const int WM_CHAR = 258;

	public const int WM_COPYDATA = 74;

	public const int SW_RESTORE = 9;

	public const byte VK_MENU = 18;

	public const uint KEYEVENTF_KEYUP = 2u;

	public static int rghwnd;

	public static int rghwnd2;

	[DllImport("user32.dll")]
	public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

	[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "UnregisterHotKey", SetLastError = true)]
	public static extern bool UnRegisterHotKey(IntPtr hwnd, int id);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int SetForegroundWindow(IntPtr hwnd);

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);

	[DllImport("User32.dll")]
	public static extern int SendMessage(int hWnd, int Msg, int wParam, string lParam);

	[DllImport("User32.dll")]
	public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

	[DllImport("User32.dll")]
	public static extern int GetWindowThreadProcessId(int hWnd, ref int lpdwProcessId);

	[DllImport("user32.dll")]
	public static extern bool SetProcessDPIAware();

	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int IsDebuggerPresent();

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int ShowWindow(int hWnd, int nCmdShow);

	[DllImport("user32.dll")]
	public static extern int MessageBoxTimeoutA(IntPtr hWnd, string msg, string Caps, int type, int Id, int time);

	public static void StartSwitch(bool status)
	{
		Dostop = !status;
		string text = Dostop.ToString();
		byte[] bytes = Encoding.Unicode.GetBytes(text);
		int num = bytes.Length;
		int value = 5;
		COPYDATASTRUCT lParam = default(COPYDATASTRUCT);
		ref IntPtr dwData = ref lParam.dwData;
		dwData = new IntPtr(value);
		lParam.cbData = checked(num + 1);
		lParam.lpData = text;
		SendMessage((int)Receiver_hWnd, 74, 0, ref lParam);
	}

	public static bool OpenTopAsm(bool Resolve = true)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(new object());
		string text = "";
		bool result = false;
		if (!RunSW())
		{
			return false;
		}
		text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1.Tag);
		int num = default(int);
		if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
		{
			num = 1;
		}
		if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
		{
			num = 2;
		}
		if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
		{
			num = 3;
		}
		NewLateBinding.LateCall(swApp, null, "SetCurrentWorkingDirectory", new object[1] { SplitStr(text) }, null, null, null, IgnoreReturn: true);
		object instance = swApp;
		int num2 = default(int);
		int num3 = default(int);
		object[] array = new object[6] { text, num, 1, "", num2, num3 };
		object[] arguments = array;
		bool[] array2 = new bool[6] { true, true, false, false, true, true };
		object obj = NewLateBinding.LateGet(instance, null, "OpenDoc6", arguments, null, null, array2);
		if (array2[0])
		{
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
		}
		if (array2[1])
		{
			num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
		}
		if (array2[4])
		{
			num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[4]), typeof(int));
		}
		if (array2[5])
		{
			num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[5]), typeof(int));
		}
		objectValue = RuntimeHelpers.GetObjectValue(obj);
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			object instance2 = swApp;
			int num4 = default(int);
			object[] array3 = new object[3] { text, true, num4 };
			object[] arguments2 = array3;
			array2 = new bool[3] { true, false, true };
			NewLateBinding.LateCall(instance2, null, "ActivateDoc2", arguments2, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			if (array2[2])
			{
				num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
			if (Resolve)
			{
				ResolveAll(RuntimeHelpers.GetObjectValue(objectValue));
			}
			result = objectValue.Equals(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swApp, null, "activedoc", new object[0], null, null, null)));
		}
		else
		{
			MessageBox.Show("Открыть " + text + " не удалось!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		objectValue = null;
		return result;
	}

	public static void DelToRecycle(string file)
	{
		try
		{
			MyProject.Computer.FileSystem.DeleteFile(file, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
			MyProject.Computer.FileSystem.DeleteFile(SplitStr(file, 3) + ".SLDDRW", UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public static void CommandInProgress(bool @bool)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + Getpkt());
			stringBuilder.AppendLine(Conversions.ToString(@bool));
			stringBuilder.AppendLine(">");
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 50;
			COPYDATASTRUCT lParam = default(COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			SendMessage((int)Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public static bool RunSW(bool HideWindow = false, bool startnew = true)
	{
		string text = "";
		int num = 0;
		string text2 = "Указана неверная версия SolidWorks, задайте её заново";
		bool result;
		checked
		{
			try
			{
				if (TMode & (UTTime > 300))
				{
					result = false;
					goto IL_06c9;
				}
				if (!canrun)
				{
					result = false;
					goto IL_06c9;
				}
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(swApp)))
				{
					swApp = null;
				}
				if (CConfigMng.Config.SWver >= 1)
				{
					num = 19 + CConfigMng.Config.SWver;
				}
				if ((Versioned.IsNumeric(MacroVer) && MacroVer >= 20) ? true : false)
				{
					num = MacroVer;
					text2 = "Не удалось обратиться к текущей версии SolidWorks!";
				}
				text = Conversions.ToString(Interaction.IIf(num == 0, "SldWorks.Application", "SldWorks.Application." + Conversions.ToString(num)));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
				ProjectData.ClearProjectError();
				goto IL_06c9;
			}
			try
			{
				CommandInProgress(@bool: true);
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64);
				if (Information.IsNothing(registryKey))
				{
					result = false;
					goto IL_06c9;
				}
				registryKey.Close();
				RegistryKey registryKey2 = registryKey.OpenSubKey(text + "\\clsid", writable: false);
				if (Information.IsNothing(registryKey2))
				{
					if (num != 0)
					{
						MessageBox.Show(MyProject.Forms.Frmmain, text2, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show(MyProject.Forms.Frmmain, "SolidWorks не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					result = false;
					goto IL_06c9;
				}
				string text3 = Conversions.ToString(registryKey2.GetValue(string.Empty));
				registryKey2.Close();
				SolidWorksMacro solidWorksMacro = new SolidWorksMacro();
				if (!solidWorksMacro.RunSW_ByID(CurSWID))
				{
					SWList sWList = new SWList();
					Process[] processesInfo = solidWorksMacro.GetProcessesInfo("SLDWORKS");
					foreach (Process process in processesInfo)
					{
						if (solidWorksMacro.RunSW_ByID(process.Id))
						{
							sWList.Titlelist.Items.Add(process.MainWindowTitle);
							sWList.IDlist.Items.Add(process.Id);
						}
					}
					if (sWList.Titlelist.Items.Count > 1)
					{
						sWList.ShowDialog();
						solidWorksMacro.RunSW_ByID(CurSWID);
					}
					else if (sWList.Titlelist.Items.Count == 1)
					{
						CurSWID = Conversions.ToInteger(sWList.IDlist.Items[0]);
						solidWorksMacro.RunSW_ByID(CurSWID);
					}
				}
				if ((startnew && Information.IsNothing(RuntimeHelpers.GetObjectValue(swApp))) ? true : false)
				{
					RegistryKey registryKey3 = registryKey.OpenSubKey("CLSID\\" + text3 + "\\LocalServer32", writable: false);
					if (Information.IsNothing(registryKey3))
					{
						MessageBox.Show(MyProject.Forms.Frmmain, "Класс не зарегистрирован, ProgID: «" + text + "\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						result = false;
						goto IL_06c9;
					}
					string fileName = Conversions.ToString(registryKey3.GetValue(string.Empty));
					registryKey3.Close();
					Process process2 = Process.Start(fileName);
					if (Information.IsNothing(process2))
					{
						MessageBox.Show("Не удалось запустить SolidWorks", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						result = false;
						goto IL_06c9;
					}
					CurSWID = process2.Id;
					int num2 = 0;
					solidWorksMacro.RunSW_ByID(CurSWID);
					while (Conversions.ToBoolean((Conversions.ToBoolean((process2.MainWindowHandle == (IntPtr)0 || swApp == null) ? true : false) || (Conversions.ToBoolean(num >= 23) && Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(swApp, null, "StartupProcessCompleted", new object[0], null, null, null))))) ? ((object)true) : ((object)false)) && !process2.HasExited)
					{
						Thread.Sleep(500);
						num2 += 500;
						if (num2 > 50000)
						{
							MessageBox.Show(MyProject.Forms.Frmmain, "Тайм-аут подключения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							break;
						}
						solidWorksMacro.RunSW_ByID(CurSWID);
					}
					process2 = null;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
				ProjectData.ClearProjectError();
				goto IL_06c9;
			}
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(swApp)))
			{
				try
				{
					NewLateBinding.LateSet(swApp, null, "UserControl", new object[1] { false }, null, null);
					NewLateBinding.LateSet(swApp, null, "visible", new object[1] { !HideWindow }, null, null);
					int lpdwProcessId = 0;
					int windowThreadProcessId = GetWindowThreadProcessId(Receiver_hWnd.ToInt32(), ref lpdwProcessId);
					if (lpdwProcessId != CurSWID)
					{
						M_FindWindow m_FindWindow = new M_FindWindow();
						Receiver_hWnd = m_FindWindow.FindChildHwnd(CurSWID, Receiver_Title);
					}
					SWhwnd = (int)Process.GetProcessById(CurSWID).MainWindowHandle;
					if (HideWindow)
					{
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(swApp, null, "FrameState", new object[0], null, null, null), 1, TextCompare: false))
						{
							NewLateBinding.LateSet(swApp, null, "FrameState", new object[1] { 1 }, null, null);
						}
						ShowWindow(SWhwnd, 0);
					}
					else
					{
						ShowWindow(SWhwnd, 5);
					}
					NewLateBinding.LateCall(swApp, null, "SetUserPreferenceToggle", new object[2] { 18, true }, null, null, null, IgnoreReturn: true);
					CommandInProgress(@bool: false);
					result = true;
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					MessageBox.Show(ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					CommandInProgress(@bool: false);
					result = false;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				CommandInProgress(@bool: false);
				result = false;
			}
			goto IL_06c9;
		}
		IL_06c9:
		return result;
	}

	public static void SetForegroundWindow_Custom(object App)
	{
		try
		{
			int processId = Conversions.ToInteger(NewLateBinding.LateGet(App, null, "GetProcessID", new object[0], null, null, null));
			IntPtr mainWindowHandle = Process.GetProcessById(processId).MainWindowHandle;
			SetForegroundWindow(mainWindowHandle);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public static void OpenDoc(string FilePathName, string cfgname = "")
	{
		try
		{
			if (!File.Exists(FilePathName) || !RunSW())
			{
				return;
			}
			SetForegroundWindow_Custom(RuntimeHelpers.GetObjectValue(swApp));
			int num = default(int);
			if (FilePathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				num = 1;
			}
			if (FilePathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				num = 2;
			}
			if (FilePathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				num = 3;
			}
			object instance = swApp;
			int num2 = default(int);
			int num3 = default(int);
			object[] array = new object[6] { FilePathName, num, 1, cfgname, num2, num3 };
			object[] arguments = array;
			bool[] array2 = new bool[6] { true, true, false, true, true, true };
			object obj = NewLateBinding.LateGet(instance, null, "OpenDoc6", arguments, null, null, array2);
			if (array2[0])
			{
				FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			if (array2[1])
			{
				num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
			}
			if (array2[3])
			{
				cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[3]), typeof(string));
			}
			if (array2[4])
			{
				num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[4]), typeof(int));
			}
			if (array2[5])
			{
				num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[5]), typeof(int));
			}
			object objectValue = RuntimeHelpers.GetObjectValue(obj);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				object instance2 = swApp;
				int num4 = default(int);
				object[] array3 = new object[3] { FilePathName, true, num4 };
				object[] arguments2 = array3;
				array2 = new bool[3] { true, false, true };
				NewLateBinding.LateCall(instance2, null, "ActivateDoc2", arguments2, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
				if (array2[2])
				{
					num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
				}
				object instance3 = objectValue;
				array3 = new object[1] { cfgname };
				object[] arguments3 = array3;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(instance3, null, "ShowConfiguration2", arguments3, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
				NewLateBinding.LateSet(objectValue, null, "Visible", new object[1] { true }, null, null);
				objectValue = null;
			}
			swApp = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public static void selectbyinstring(string idstring)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("ZToolRequest@001" + Getpkt());
			stringBuilder.AppendLine(idstring);
			stringBuilder.AppendLine(MyProject.Forms.Frmmain.DGV1.Tag.ToString());
			stringBuilder.AppendLine(MyProject.Forms.Frmmain.DGV1.topcfgName);
			stringBuilder.AppendLine(">");
			string text = stringBuilder.ToString().Trim();
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			int num = bytes.Length;
			int value = 60;
			COPYDATASTRUCT lParam = default(COPYDATASTRUCT);
			ref IntPtr dwData = ref lParam.dwData;
			dwData = new IntPtr(value);
			lParam.cbData = checked(num + 1);
			lParam.lpData = text;
			SendMessage((int)Receiver_hWnd, 74, 0, ref lParam);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public static void SaveDoc(string ModelName)
	{
		if (!RunSW())
		{
			return;
		}
		bool flag = false;
		int num = default(int);
		if (ModelName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
		{
			num = 1;
		}
		if (ModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
		{
			num = 2;
		}
		if (ModelName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
		{
			num = 3;
		}
		bool flag2 = false;
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swApp, null, "ActiveDoc", new object[0], null, null, null));
		string text = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "getpathname", new object[0], null, null, null));
			if (!ModelName.Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				flag2 = true;
			}
			objectValue = null;
		}
		bool flag3 = false;
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swApp, null, "GetOpenDocument", new object[1] { MyProject.Forms.Frmmain.DGV1.Tag.ToString() }, null, null, null));
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
		{
			flag3 = true;
			objectValue2 = null;
		}
		object instance = swApp;
		object[] array = new object[1] { ModelName };
		object[] arguments = array;
		bool[] array2 = new bool[1] { true };
		object obj = NewLateBinding.LateGet(instance, null, "GetOpenDocument", arguments, null, null, array2);
		if (array2[0])
		{
			ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
		}
		object objectValue3 = RuntimeHelpers.GetObjectValue(obj);
		bool flag4 = default(bool);
		object[] array3;
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
		{
			flag4 = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue3, null, "Visible", new object[0], null, null, null));
			flag = true;
		}
		else
		{
			object instance2 = swApp;
			array3 = new object[2] { ModelName, num };
			object[] arguments2 = array3;
			array2 = new bool[2] { true, true };
			object obj2 = NewLateBinding.LateGet(instance2, null, "OpenDoc", arguments2, null, null, array2);
			if (array2[0])
			{
				ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			if (array2[1])
			{
				num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
			}
			objectValue3 = RuntimeHelpers.GetObjectValue(obj2);
			flag = false;
		}
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
		{
			return;
		}
		object instance3 = swApp;
		int num2 = default(int);
		array3 = new object[3] { ModelName, true, num2 };
		object[] arguments3 = array3;
		array2 = new bool[3] { true, false, true };
		NewLateBinding.LateCall(instance3, null, "ActivateDoc2", arguments3, null, null, array2, IgnoreReturn: true);
		if (array2[0])
		{
			ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
		}
		if (array2[2])
		{
			num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
		}
		long num3 = Conversions.ToLong(NewLateBinding.LateGet(objectValue3, null, "GetLightSourceCount", new object[0], null, null, null));
		string text2 = "Light" + Conversions.ToString(checked(num3 + 1));
		object instance4 = objectValue3;
		array3 = new object[3] { text2, 4, text2 };
		object[] arguments4 = array3;
		array2 = new bool[3] { true, false, true };
		object value = NewLateBinding.LateGet(instance4, null, "AddLightSource", arguments4, null, null, array2);
		if (array2[0])
		{
			text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
		}
		if (array2[2])
		{
			text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(string));
		}
		bool[] array5;
		if (Conversions.ToBoolean(value))
		{
			object instance5 = objectValue3;
			object[] array4 = new object[1] { num3 };
			object[] arguments5 = array4;
			array5 = new bool[1] { true };
			NewLateBinding.LateCall(instance5, null, "DeleteLightSource", arguments5, null, null, array5, IgnoreReturn: true);
			if (array5[0])
			{
				num3 = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(long));
			}
		}
		NewLateBinding.LateCall(objectValue3, null, "EditRebuild3", new object[0], null, null, null, IgnoreReturn: true);
		NewLateBinding.LateCall(objectValue3, null, "ShowNamedView2", new object[2] { "", 7 }, null, null, null, IgnoreReturn: true);
		NewLateBinding.LateCall(objectValue3, null, "ViewZoomtofit2", new object[0], null, null, null, IgnoreReturn: true);
		object instance6 = objectValue3;
		int num4 = default(int);
		object[] array6 = new object[3] { 5, num2, num4 };
		object[] arguments6 = array6;
		array5 = new bool[3] { false, true, true };
		NewLateBinding.LateCall(instance6, null, "Save3", arguments6, null, null, array5, IgnoreReturn: true);
		if (array5[1])
		{
			num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[1]), typeof(int));
		}
		if (array5[2])
		{
			num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[2]), typeof(int));
		}
		if (flag2)
		{
			if (!flag4 || !flag)
			{
				object instance7 = swApp;
				array6 = new object[1] { ModelName };
				object[] arguments7 = array6;
				array5 = new bool[1] { true };
				NewLateBinding.LateCall(instance7, null, "closedoc", arguments7, null, null, array5, IgnoreReturn: true);
				if (array5[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[0]), typeof(string));
				}
			}
			if (flag)
			{
				if (!flag4)
				{
					object instance8 = swApp;
					array6 = new object[2] { false, num };
					object[] arguments8 = array6;
					array5 = new bool[2] { false, true };
					NewLateBinding.LateCall(instance8, null, "DocumentVisible", arguments8, null, null, array5, IgnoreReturn: true);
					if (array5[1])
					{
						num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[1]), typeof(int));
					}
				}
				object instance9 = swApp;
				array6 = new object[2] { ModelName, num };
				object[] arguments9 = array6;
				array5 = new bool[2] { true, true };
				NewLateBinding.LateCall(instance9, null, "OpenDoc", arguments9, null, null, array5, IgnoreReturn: true);
				if (array5[0])
				{
					ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[0]), typeof(string));
				}
				if (array5[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[1]), typeof(int));
				}
				object instance10 = swApp;
				array6 = new object[2] { true, num };
				object[] arguments10 = array6;
				array5 = new bool[2] { false, true };
				NewLateBinding.LateCall(instance10, null, "DocumentVisible", arguments10, null, null, array5, IgnoreReturn: true);
				if (array5[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[1]), typeof(int));
				}
			}
			object instance11 = swApp;
			array6 = new object[3] { text, true, num2 };
			object[] arguments11 = array6;
			array5 = new bool[3] { true, false, true };
			NewLateBinding.LateCall(instance11, null, "ActivateDoc2", arguments11, null, null, array5, IgnoreReturn: true);
			if (array5[0])
			{
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[0]), typeof(string));
			}
			if (array5[2])
			{
				num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array6[2]), typeof(int));
			}
		}
		objectValue3 = null;
	}

	public static void executemacro(string macropath, string ModelName)
	{
		if (!RunSW())
		{
			return;
		}
		int num = default(int);
		if (ModelName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
		{
			num = 1;
		}
		if (ModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
		{
			num = 2;
		}
		if (ModelName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
		{
			num = 3;
		}
		bool flag = false;
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swApp, null, "ActiveDoc", new object[0], null, null, null));
		string text = "";
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "getpathname", new object[0], null, null, null));
			if (string.Compare(ModelName, text, ignoreCase: true) != 0)
			{
				flag = true;
			}
			objectValue = null;
		}
		bool flag2 = false;
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swApp, null, "GetOpenDocument", new object[1] { MyProject.Forms.Frmmain.DGV1.Tag.ToString() }, null, null, null));
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
		{
			flag2 = true;
			objectValue2 = null;
		}
		object instance = swApp;
		object[] array = new object[1] { ModelName };
		object[] arguments = array;
		bool[] array2 = new bool[1] { true };
		object obj = NewLateBinding.LateGet(instance, null, "GetOpenDocument", arguments, null, null, array2);
		if (array2[0])
		{
			ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
		}
		object objectValue3 = RuntimeHelpers.GetObjectValue(obj);
		bool flag3;
		object[] array3;
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
		{
			flag3 = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue3, null, "Visible", new object[0], null, null, null));
		}
		else
		{
			object instance2 = swApp;
			array3 = new object[2] { ModelName, num };
			object[] arguments2 = array3;
			array2 = new bool[2] { true, true };
			object obj2 = NewLateBinding.LateGet(instance2, null, "OpenDoc", arguments2, null, null, array2);
			if (array2[0])
			{
				ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			if (array2[1])
			{
				num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
			}
			objectValue3 = RuntimeHelpers.GetObjectValue(obj2);
			flag3 = false;
		}
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
		{
			return;
		}
		object instance3 = swApp;
		int num2 = default(int);
		array3 = new object[3] { ModelName, true, num2 };
		object[] arguments3 = array3;
		array2 = new bool[3] { true, false, true };
		NewLateBinding.LateCall(instance3, null, "ActivateDoc2", arguments3, null, null, array2, IgnoreReturn: true);
		if (array2[0])
		{
			ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
		}
		if (array2[2])
		{
			num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
		}
		object instance4 = swApp;
		int num3 = default(int);
		array3 = new object[5] { macropath, "", "main", 0, num3 };
		object[] arguments4 = array3;
		array2 = new bool[5] { true, false, false, false, true };
		NewLateBinding.LateCall(instance4, null, "RunMacro2", arguments4, null, null, array2, IgnoreReturn: true);
		if (array2[0])
		{
			macropath = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
		}
		if (array2[4])
		{
			num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[4]), typeof(int));
		}
		if ((!flag3 && !(DataFromAsm & MyProject.Forms.Frmmain.DGV1.Tag.ToString().Equals(ModelName, StringComparison.OrdinalIgnoreCase))) ? true : false)
		{
			object instance5 = swApp;
			array3 = new object[1] { ModelName };
			object[] arguments5 = array3;
			array2 = new bool[1] { true };
			NewLateBinding.LateCall(instance5, null, "closedoc", arguments5, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				ModelName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
		}
		if (flag)
		{
			object instance6 = swApp;
			array3 = new object[3] { text, true, num2 };
			object[] arguments6 = array3;
			array2 = new bool[3] { true, false, true };
			NewLateBinding.LateCall(instance6, null, "ActivateDoc2", arguments6, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			if (array2[2])
			{
				num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
			}
		}
		objectValue3 = null;
	}

	public static bool CompConfigProperties4(string topname, string cfgname, string sellist, bool ExcludeFromBOM, int Suppression)
	{
		bool result = false;
		if (!RunSW())
		{
			return false;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swApp, null, "GetOpenDocument", new object[1] { MyProject.Forms.Frmmain.DGV1.Tag.ToString() }, null, null, null));
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			object instance = objectValue;
			object[] array = new object[1] { cfgname };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			NewLateBinding.LateCall(instance, null, "ShowConfiguration2", arguments, null, null, array2, IgnoreReturn: true);
			if (array2[0])
			{
				cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(objectValue);
			selectbyinstring(string.Join("|", sellist));
			object[] array3 = new object[6] { Suppression, 0, true, true, "", ExcludeFromBOM };
			object[] arguments2 = array3;
			array2 = new bool[6] { true, false, false, false, false, true };
			object value = NewLateBinding.LateGet(objectValue2, null, "CompConfigProperties4", arguments2, null, null, array2);
			if (array2[0])
			{
				Suppression = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(int));
			}
			if (array2[5])
			{
				ExcludeFromBOM = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[5]), typeof(bool));
			}
			result = Conversions.ToBoolean(value);
			NewLateBinding.LateCall(objectValue, null, "EditRebuild3", new object[0], null, null, null, IgnoreReturn: true);
			objectValue = null;
		}
		return result;
	}

	public static List<string> GetModelcfgfromdrw(object swSheet, bool @bool = false)
	{
		List<string> list = new List<string>();
		string text = "";
		string text2 = "";
		object obj = null;
		int num = 0;
		checked
		{
			try
			{
				if (swSheet == null)
				{
					return null;
				}
				string left = Conversions.ToString(NewLateBinding.LateGet(swSheet, null, "CustomPropertyView", new object[0], null, null, null));
				object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swSheet, null, "GetProperties2", new object[0], null, null, null));
				double num2 = Conversions.ToDouble(Operators.DivideObject(NewLateBinding.LateIndexGet(objectValue, new object[1] { 2 }, null), NewLateBinding.LateIndexGet(objectValue, new object[1] { 3 }, null)));
				object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swSheet, null, "GetViews", new object[0], null, null, null));
				if (objectValue2 == null)
				{
					return null;
				}
				int num3 = Information.UBound((Array)objectValue2);
				int num4 = 0;
				double num7 = default(double);
				double num8 = default(double);
				while (true)
				{
					int num5 = num4;
					int num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue2, new object[1] { num4 }, null));
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)) && !Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue3, null, "GetVisible", new object[0], null, null, null), false, TextCompare: false) && 0 == 0)
					{
						text = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "ReferencedConfiguration", new object[0], null, null, null));
						text2 = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "GetReferencedModelName", new object[0], null, null, null));
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "ScaleRatio", new object[0], null, null, null));
						if ((Operators.CompareString(left, "", TextCompare: false) == 0 && num == 0) ? true : false)
						{
							list.Add(text);
							num7 = Conversions.ToDouble(NewLateBinding.LateIndexGet(obj, new object[1] { 0 }, null));
							num8 = Conversions.ToDouble(NewLateBinding.LateIndexGet(obj, new object[1] { 1 }, null));
						}
						else if ((Operators.CompareString(left, "", TextCompare: false) != 0 && Operators.ConditionalCompareObjectEqual(left, NewLateBinding.LateGet(objectValue3, null, "GetName2", new object[0], null, null, null), TextCompare: false)) ? true : false)
						{
							list.Add(text);
							num7 = Conversions.ToDouble(NewLateBinding.LateIndexGet(obj, new object[1] { 0 }, null));
							num8 = Conversions.ToDouble(NewLateBinding.LateIndexGet(obj, new object[1] { 1 }, null));
						}
						num++;
						if (!@bool)
						{
							break;
						}
						if (Operators.ConditionalCompareObjectEqual(Operators.DivideObject(NewLateBinding.LateIndexGet(obj, new object[1] { 0 }, null), NewLateBinding.LateIndexGet(obj, new object[1] { 1 }, null)), num2, TextCompare: false))
						{
							@bool = false;
							break;
						}
					}
					num4++;
				}
				if ((@bool && num7 >= 0.0 && num8 >= 0.0) ? true : false)
				{
					object[] array = new object[4] { num7, num8, false, false };
					object[] arguments = array;
					bool[] array2 = new bool[4] { true, true, false, false };
					NewLateBinding.LateCall(swSheet, null, "SetScale", arguments, null, null, array2, IgnoreReturn: true);
					if (array2[0])
					{
						num7 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(double));
					}
					if (array2[1])
					{
						num8 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(double));
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return list;
		}
	}

	public static Dictionary<string, string> Getpropfromsheet(object curswapp, object swSheet)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string text = "";
		string text2 = "";
		object obj = null;
		checked
		{
			try
			{
				if (swSheet == null)
				{
					return null;
				}
				string text3 = Conversions.ToString(NewLateBinding.LateGet(swSheet, null, "CustomPropertyView", new object[0], null, null, null));
				object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(swSheet, null, "GetViews", new object[0], null, null, null));
				if (objectValue == null)
				{
					return null;
				}
				int num = Information.UBound((Array)objectValue);
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { num2 }, null));
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
					{
						if (Conversions.ToBoolean(Operators.NotObject(NewLateBinding.LateGet(objectValue2, null, "IsModelLoaded", new object[0], null, null, null))))
						{
							NewLateBinding.LateCall(objectValue2, null, "LoadModel", new object[0], null, null, null, IgnoreReturn: true);
						}
						text = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "ReferencedConfiguration", new object[0], null, null, null));
						text2 = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "GetReferencedModelName", new object[0], null, null, null));
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "ReferencedDocument", new object[0], null, null, null));
					}
					switch (text3)
					{
					case null:
					case "":
					case "default":
					case "По умолчанию":
						if (true)
						{
							break;
						}
						goto default;
					default:
						if (!Operators.ConditionalCompareObjectEqual(text3, NewLateBinding.LateGet(objectValue2, null, "GetName2", new object[0], null, null, null), TextCompare: false))
						{
							goto IL_01c5;
						}
						break;
					}
					break;
					IL_01c5:
					num2++;
				}
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
				{
					object obj2 = null;
					object obj3 = null;
					object obj4 = null;
					object obj5 = null;
					object obj6 = null;
					object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj, null, "Extension", new object[0], null, null, null));
					object[] array = new object[1] { text };
					object[] arguments = array;
					bool[] array2 = new bool[1] { true };
					object obj7 = NewLateBinding.LateGet(objectValue3, null, "CustomPropertyManager", arguments, null, null, array2);
					if (array2[0])
					{
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					obj2 = RuntimeHelpers.GetObjectValue(obj7);
					int num5 = Conversions.ToInteger(NewLateBinding.LateGet(obj2, null, "Count", new object[0], null, null, null));
					obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj2, null, "GetNames", new object[0], null, null, null));
					int num6 = num5 - 1;
					int num7 = 0;
					while (true)
					{
						int num8 = num7;
						int num4 = num6;
						if (num8 > num4)
						{
							break;
						}
						string text4 = "";
						string text5 = "";
						object instance = obj2;
						object[] array3 = new object[4]
						{
							RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(obj3, new object[1] { num7 }, null)),
							false,
							text4,
							text5
						};
						object[] arguments2 = array3;
						array2 = new bool[4] { true, false, true, true };
						NewLateBinding.LateCall(instance, null, "Get4", arguments2, null, null, array2, IgnoreReturn: true);
						if (array2[0])
						{
							NewLateBinding.LateIndexSetComplex(obj3, new object[2]
							{
								num7,
								RuntimeHelpers.GetObjectValue(array3[0])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (array2[2])
						{
							text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(string));
						}
						if (array2[3])
						{
							text5 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[3]), typeof(string));
						}
						dictionary.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("$", NewLateBinding.LateIndexGet(obj3, new object[1] { num7 }, null)), "$")), text5);
						num7++;
					}
					obj2 = null;
					obj3 = null;
					obj4 = null;
					obj5 = null;
					obj6 = null;
					obj2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "CustomPropertyManager", new object[1] { "" }, null, null, null));
					num5 = Conversions.ToInteger(NewLateBinding.LateGet(obj2, null, "Count", new object[0], null, null, null));
					obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj2, null, "GetNames", new object[0], null, null, null));
					int num9 = num5 - 1;
					num7 = 0;
					while (true)
					{
						int num10 = num7;
						int num4 = num9;
						if (num10 > num4)
						{
							break;
						}
						string text6 = "";
						string text7 = "";
						object instance2 = obj2;
						array = new object[4]
						{
							RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(obj3, new object[1] { num7 }, null)),
							false,
							text6,
							text7
						};
						object[] arguments3 = array;
						array2 = new bool[4] { true, false, true, true };
						NewLateBinding.LateCall(instance2, null, "Get4", arguments3, null, null, array2, IgnoreReturn: true);
						if (array2[0])
						{
							NewLateBinding.LateIndexSetComplex(obj3, new object[2]
							{
								num7,
								RuntimeHelpers.GetObjectValue(array[0])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (array2[2])
						{
							text6 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(string));
						}
						if (array2[3])
						{
							text7 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[3]), typeof(string));
						}
						if (!dictionary.ContainsKey(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("$", NewLateBinding.LateIndexGet(obj3, new object[1] { num7 }, null)), "$"))))
						{
							dictionary.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("$", NewLateBinding.LateIndexGet(obj3, new object[1] { num7 }, null)), "$")), text7);
						}
						num7++;
					}
					dictionary.Add("<Заголовок>", Conversions.ToString(NewLateBinding.LateGet(obj, null, "SummaryInfo", new object[1] { 0 }, null, null, null)));
					dictionary.Add("<Тема>", Conversions.ToString(NewLateBinding.LateGet(obj, null, "SummaryInfo", new object[1] { 1 }, null, null, null)));
					dictionary.Add("<Автор>", Conversions.ToString(NewLateBinding.LateGet(obj, null, "SummaryInfo", new object[1] { 2 }, null, null, null)));
					dictionary.Add("<КлючевыеСлова>", Conversions.ToString(NewLateBinding.LateGet(obj, null, "SummaryInfo", new object[1] { 3 }, null, null, null)));
					dictionary.Add("<Примечание>", Conversions.ToString(NewLateBinding.LateGet(obj, null, "SummaryInfo", new object[1] { 4 }, null, null, null)));
					dictionary.Add("<ИмяФайлаМодели>", SplitStr(text2, 1));
					dictionary.Add("<ИмяПапкиМодели>", SplitStr(text2));
					dictionary.Add("<ИмяКонфигурации>", text);
					dictionary.Add("<ТекущаяДата>", DateTime.Now.ToString("yyyyMMdd"));
					string value = "";
					if (text2.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase))
					{
						string text8 = "";
						object instance3 = obj;
						object[] array3 = new object[2] { text, text8 };
						object[] arguments4 = array3;
						array2 = new bool[2] { true, true };
						object obj8 = NewLateBinding.LateGet(instance3, null, "GetMaterialPropertyName2", arguments4, null, null, array2);
						if (array2[0])
						{
							text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
						}
						if (array2[1])
						{
							text8 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(string));
						}
						value = Conversions.ToString(obj8);
					}
					dictionary.Add("<Материал>", value);
					string text9 = "";
					string text10 = "";
					int num11 = dgvdatalist.Count - 1;
					int num12 = 0;
					while (true)
					{
						int num13 = num12;
						int num4 = num11;
						if (num13 <= num4)
						{
							if (togetherConfig)
							{
								text9 = text2;
								text10 = dgvdatalist[num12].pathname;
							}
							else
							{
								text9 = text2 + text;
								text10 = dgvdatalist[num12].pathname + dgvdatalist[num12].cfgname;
							}
							if (text9.Equals(text10, StringComparison.OrdinalIgnoreCase))
							{
								dictionary.Add("<Количество>", Conversions.ToString(dgvdatalist[num12].Quantity));
								break;
							}
							num12++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				ProjectData.ClearProjectError();
			}
			return dictionary;
		}
	}

	public static Dictionary<string, string> Getpropfrommodel(object curswapp, object modeldoc, string sConfName)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		checked
		{
			try
			{
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(modeldoc)))
				{
					object obj = null;
					object obj2 = null;
					object obj3 = null;
					object obj4 = null;
					object obj5 = null;
					object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(modeldoc, null, "Extension", new object[0], null, null, null));
					object[] array = new object[1] { sConfName };
					object[] arguments = array;
					bool[] array2 = new bool[1] { true };
					object obj6 = NewLateBinding.LateGet(objectValue, null, "CustomPropertyManager", arguments, null, null, array2);
					if (array2[0])
					{
						sConfName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					}
					obj = RuntimeHelpers.GetObjectValue(obj6);
					int num = Conversions.ToInteger(NewLateBinding.LateGet(obj, null, "Count", new object[0], null, null, null));
					obj2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj, null, "GetNames", new object[0], null, null, null));
					int num2 = num - 1;
					int num3 = 0;
					while (true)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						string text = "";
						string text2 = "";
						object instance = obj;
						object[] array3 = new object[4]
						{
							RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(obj2, new object[1] { num3 }, null)),
							false,
							text,
							text2
						};
						object[] arguments2 = array3;
						array2 = new bool[4] { true, false, true, true };
						NewLateBinding.LateCall(instance, null, "Get4", arguments2, null, null, array2, IgnoreReturn: true);
						if (array2[0])
						{
							NewLateBinding.LateIndexSetComplex(obj2, new object[2]
							{
								num3,
								RuntimeHelpers.GetObjectValue(array3[0])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (array2[2])
						{
							text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(string));
						}
						if (array2[3])
						{
							text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[3]), typeof(string));
						}
						dictionary.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("$", NewLateBinding.LateIndexGet(obj2, new object[1] { num3 }, null)), "$")), text2);
						num3++;
					}
					obj = null;
					obj2 = null;
					obj3 = null;
					obj4 = null;
					obj5 = null;
					obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "CustomPropertyManager", new object[1] { "" }, null, null, null));
					num = Conversions.ToInteger(NewLateBinding.LateGet(obj, null, "Count", new object[0], null, null, null));
					obj2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj, null, "GetNames", new object[0], null, null, null));
					int num6 = num - 1;
					num3 = 0;
					while (true)
					{
						int num7 = num3;
						int num5 = num6;
						if (num7 > num5)
						{
							break;
						}
						string text3 = "";
						string text4 = "";
						object instance2 = obj;
						array = new object[4]
						{
							RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(obj2, new object[1] { num3 }, null)),
							false,
							text3,
							text4
						};
						object[] arguments3 = array;
						array2 = new bool[4] { true, false, true, true };
						NewLateBinding.LateCall(instance2, null, "Get4", arguments3, null, null, array2, IgnoreReturn: true);
						if (array2[0])
						{
							NewLateBinding.LateIndexSetComplex(obj2, new object[2]
							{
								num3,
								RuntimeHelpers.GetObjectValue(array[0])
							}, null, OptimisticSet: true, RValueBase: false);
						}
						if (array2[2])
						{
							text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(string));
						}
						if (array2[3])
						{
							text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[3]), typeof(string));
						}
						if (!dictionary.ContainsKey(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("$", NewLateBinding.LateIndexGet(obj2, new object[1] { num3 }, null)), "$"))))
						{
							dictionary.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("$", NewLateBinding.LateIndexGet(obj2, new object[1] { num3 }, null)), "$")), text4);
						}
						num3++;
					}
					string text5 = Conversions.ToString(NewLateBinding.LateGet(modeldoc, null, "getpathname", new object[0], null, null, null));
					dictionary.Add("<Заголовок>", Conversions.ToString(NewLateBinding.LateGet(modeldoc, null, "SummaryInfo", new object[1] { 0 }, null, null, null)));
					dictionary.Add("<Тема>", Conversions.ToString(NewLateBinding.LateGet(modeldoc, null, "SummaryInfo", new object[1] { 1 }, null, null, null)));
					dictionary.Add("<Автор>", Conversions.ToString(NewLateBinding.LateGet(modeldoc, null, "SummaryInfo", new object[1] { 2 }, null, null, null)));
					dictionary.Add("<КлючевыеСлова>", Conversions.ToString(NewLateBinding.LateGet(modeldoc, null, "SummaryInfo", new object[1] { 3 }, null, null, null)));
					dictionary.Add("<Примечание>", Conversions.ToString(NewLateBinding.LateGet(modeldoc, null, "SummaryInfo", new object[1] { 4 }, null, null, null)));
					dictionary.Add("<ИмяФайла>", SplitStr(text5, 1));
					dictionary.Add("<ИмяПапки>", SplitStr(text5));
					dictionary.Add("<ИмяКонфигурации>", sConfName);
					dictionary.Add("<ТекущаяДата>", DateTime.Now.ToString("yyyyMMdd"));
					string value = "";
					if (text5.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase))
					{
						string text6 = "";
						object[] array3 = new object[2] { sConfName, text6 };
						object[] arguments4 = array3;
						array2 = new bool[2] { true, true };
						object obj7 = NewLateBinding.LateGet(modeldoc, null, "GetMaterialPropertyName2", arguments4, null, null, array2);
						if (array2[0])
						{
							sConfName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
						}
						if (array2[1])
						{
							text6 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(string));
						}
						value = Conversions.ToString(obj7);
					}
					dictionary.Add("<Материал>", value);
					string text7 = "";
					string text8 = "";
					int num8 = dgvdatalist.Count - 1;
					int num9 = 0;
					while (true)
					{
						int num10 = num9;
						int num5 = num8;
						if (num10 <= num5)
						{
							if (togetherConfig)
							{
								text7 = text5;
								text8 = dgvdatalist[num9].pathname;
							}
							else
							{
								text7 = text5 + sConfName;
								text8 = dgvdatalist[num9].pathname + dgvdatalist[num9].cfgname;
							}
							if (text7.Equals(text8, StringComparison.OrdinalIgnoreCase))
							{
								dictionary.Add("<Количество>", Conversions.ToString(dgvdatalist[num9].Quantity));
								break;
							}
							num9++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw ex2;
			}
			return dictionary;
		}
	}

	public static string BOMPartNumber(object config, object document)
	{
		string result = "";
		try
		{
			object left = NewLateBinding.LateGet(config, null, "BOMPartNoSource", new object[0], null, null, null);
			if (Operators.ConditionalCompareObjectEqual(left, 2, TextCompare: false))
			{
				result = Conversions.ToString(NewLateBinding.LateGet(config, null, "Name", new object[0], null, null, null));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 1, TextCompare: false))
			{
				string text = Conversions.ToString(NewLateBinding.LateGet(document, null, "GetTitle", new object[0], null, null, null));
				result = ((!text.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase) && (!text.EndsWith(".sldasm", StringComparison.OrdinalIgnoreCase) || 1 == 0)) ? text : text.Substring(0, checked(Strings.Len(text) - 7)));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 8, TextCompare: false))
			{
				result = Conversions.ToString(NewLateBinding.LateGet(config, null, "AlternateName", new object[0], null, null, null));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, 4, TextCompare: false))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(config, null, "GetParent", new object[0], null, null, null));
				result = BOMPartNumber(RuntimeHelpers.GetObjectValue(objectValue), RuntimeHelpers.GetObjectValue(document));
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

	public static BOMPartData GetBOMPartData(string FilePathName, string cfgname)
	{
		BOMPartData result = default(BOMPartData);
		bool flag = false;
		try
		{
			if (!File.Exists(FilePathName))
			{
				return result;
			}
			if (!RunSW())
			{
				return result;
			}
			int num = default(int);
			if (FilePathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				num = 1;
			}
			if (FilePathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				num = 2;
			}
			if (FilePathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				num = 3;
			}
			object instance = swApp;
			object[] array = new object[1] { FilePathName };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(instance, null, "GetOpenDocument", arguments, null, null, array2);
			if (array2[0])
			{
				FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue = RuntimeHelpers.GetObjectValue(obj);
			object[] array3;
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				flag = false;
				object instance2 = swApp;
				int num2 = default(int);
				int num3 = default(int);
				array3 = new object[6] { FilePathName, num, 1, cfgname, num2, num3 };
				object[] arguments2 = array3;
				array2 = new bool[6] { true, true, false, true, true, true };
				object obj2 = NewLateBinding.LateGet(instance2, null, "OpenDoc6", arguments2, null, null, array2);
				if (array2[0])
				{
					FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
				if (array2[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
				}
				if (array2[3])
				{
					cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[3]), typeof(string));
				}
				if (array2[4])
				{
					num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[4]), typeof(int));
				}
				if (array2[5])
				{
					num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[5]), typeof(int));
				}
				objectValue = RuntimeHelpers.GetObjectValue(obj2);
			}
			else
			{
				flag = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, null, "Visible", new object[0], null, null, null));
			}
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				MessageBox.Show("Открыть " + FilePathName + " не удалось!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return result;
			}
			object instance3 = objectValue;
			array3 = new object[1] { cfgname };
			object[] arguments3 = array3;
			array2 = new bool[1] { true };
			object obj3 = NewLateBinding.LateGet(instance3, null, "GetConfigurationByName", arguments3, null, null, array2);
			if (array2[0])
			{
				cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(obj3);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
			{
				result.AlternateName = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "AlternateName", new object[0], null, null, null));
				result.BOMPartNoSource = Conversions.ToInteger(NewLateBinding.LateGet(objectValue2, null, "BOMPartNoSource", new object[0], null, null, null));
				object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, null, "GetParent", new object[0], null, null, null));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
				{
					result.ParentName = BOMPartNumber(RuntimeHelpers.GetObjectValue(objectValue3), RuntimeHelpers.GetObjectValue(objectValue));
				}
				result.BOMPartNumber = BOMPartNumber(RuntimeHelpers.GetObjectValue(objectValue2), RuntimeHelpers.GetObjectValue(objectValue));
			}
			if (!flag)
			{
				object instance4 = swApp;
				array3 = new object[1] { FilePathName };
				object[] arguments4 = array3;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(instance4, null, "closedoc", arguments4, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void SetBOMPartData(string FilePathName, string cfgname, int BOMPartNoSource, string AlternateName = "")
	{
		bool flag = false;
		try
		{
			if (!File.Exists(FilePathName))
			{
				return;
			}
			int num = default(int);
			if (FilePathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				num = 1;
			}
			if (FilePathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				num = 2;
			}
			if (FilePathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				num = 3;
			}
			object instance = swApp;
			object[] array = new object[1] { FilePathName };
			object[] arguments = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(instance, null, "GetOpenDocument", arguments, null, null, array2);
			if (array2[0])
			{
				FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue = RuntimeHelpers.GetObjectValue(obj);
			object[] array3;
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				flag = false;
				object instance2 = swApp;
				int num2 = default(int);
				int num3 = default(int);
				array3 = new object[6] { FilePathName, num, 1, cfgname, num2, num3 };
				object[] arguments2 = array3;
				array2 = new bool[6] { true, true, false, true, true, true };
				object obj2 = NewLateBinding.LateGet(instance2, null, "OpenDoc6", arguments2, null, null, array2);
				if (array2[0])
				{
					FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
				if (array2[1])
				{
					num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
				}
				if (array2[3])
				{
					cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[3]), typeof(string));
				}
				if (array2[4])
				{
					num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[4]), typeof(int));
				}
				if (array2[5])
				{
					num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[5]), typeof(int));
				}
				objectValue = RuntimeHelpers.GetObjectValue(obj2);
			}
			else
			{
				flag = Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, null, "Visible", new object[0], null, null, null));
			}
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				return;
			}
			object instance3 = objectValue;
			array3 = new object[1] { cfgname };
			object[] arguments3 = array3;
			array2 = new bool[1] { true };
			object obj3 = NewLateBinding.LateGet(instance3, null, "GetConfigurationByName", arguments3, null, null, array2);
			if (array2[0])
			{
				cfgname = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(obj3);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
			{
				NewLateBinding.LateSet(objectValue2, null, "BOMPartNoSource", new object[1] { BOMPartNoSource }, null, null);
				if (BOMPartNoSource == 8)
				{
					NewLateBinding.LateSet(objectValue2, null, "AlternateName", new object[1] { AlternateName }, null, null);
					NewLateBinding.LateSet(objectValue2, null, "UseAlternateNameInBOM", new object[1] { true }, null, null);
				}
				else
				{
					NewLateBinding.LateSet(objectValue2, null, "UseAlternateNameInBOM", new object[1] { false }, null, null);
				}
				NewLateBinding.LateCall(objectValue, null, "EditRebuild3", new object[0], null, null, null, IgnoreReturn: true);
				object instance4 = objectValue;
				int num4 = default(int);
				int num5 = default(int);
				array3 = new object[3] { 5, num4, num5 };
				object[] arguments4 = array3;
				array2 = new bool[3] { false, true, true };
				NewLateBinding.LateCall(instance4, null, "Save3", arguments4, null, null, array2, IgnoreReturn: true);
				if (array2[1])
				{
					num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(int));
				}
				if (array2[2])
				{
					num5 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[2]), typeof(int));
				}
			}
			if (!flag)
			{
				object instance5 = swApp;
				array3 = new object[1] { FilePathName };
				object[] arguments5 = array3;
				array2 = new bool[1] { true };
				NewLateBinding.LateCall(instance5, null, "closedoc", arguments5, null, null, array2, IgnoreReturn: true);
				if (array2[0])
				{
					FilePathName = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static string StrToByte(string str)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(str);
		return "(" + string.Join(",", bytes) + ")";
	}

	public static void ResolveAll(object Model)
	{
		try
		{
			string text = "";
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(Model)))
			{
				return;
			}
			text = Conversions.ToString(NewLateBinding.LateGet(Model, null, "GetPathName", new object[0], null, null, null));
			if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Model);
				int num = default(int);
				if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(objectValue, null, "GetLightWeightComponentCount", new object[0], null, null, null), 0, TextCompare: false))
				{
					MyProject.Forms.Frmmain.StatusLabel1.Text = "Разбор компонентов...";
					num = Conversions.ToInteger(NewLateBinding.LateGet(objectValue, null, "ResolveAllLightWeightComponents", new object[1] { true }, null, null, null));
				}
				switch (num)
				{
				case 0:
					break;
				case 1:
					MessageBox.Show(MyProject.Forms.Frmmain, "User aborted resolving the components", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					break;
				case 2:
					MessageBox.Show(MyProject.Forms.Frmmain, "Some of the components did not get resolved despite the user requesting it", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public static string SplitStr(string str, int TypeBool = 0)
	{
		string result;
		try
		{
			if (!IsValidPath(str))
			{
				throw new ArgumentException("Недопустимый формат пути", str);
			}
			string directoryName = Path.GetDirectoryName(str);
			string fileName = Path.GetFileName(str);
			string extension = Path.GetExtension(str);
			result = checked(TypeBool switch
			{
				0 => directoryName + "\\", 
				1 => Strings.Left(fileName, Strings.Len(fileName) - Strings.Len(extension)), 
				2 => Strings.Right(extension, Strings.Len(extension) - 1), 
				3 => Strings.Left(str, Strings.Len(str) - Strings.Len(extension)), 
				4 => fileName, 
				5 => extension, 
				6 => directoryName, 
				_ => str, 
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			result = str;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static bool IsValidPath(string ipath)
	{
		if (string.IsNullOrEmpty(ipath) || ipath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
		{
			return false;
		}
		return Path.IsPathRooted(ipath);
	}

	public static string GetdownlistValue(string str)
	{
		string result = str;
		checked
		{
			try
			{
				int num = downlist.Length - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						if (Operators.ConditionalCompareObjectEqual(str, NewLateBinding.LateIndexGet(downlist, new object[1] { num2 }, null), TextCompare: false))
						{
							result = Conversions.ToString(NewLateBinding.LateIndexGet(downlistvalue, new object[1] { num2 }, null));
							break;
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
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static int GetFieldType(string wName)
	{
		return wName.ToUpper() switch
		{
			"Текст" => 30, 
			"Дата" => 64, 
			"Число" => 3, 
			"Да или нет" => 11, 
			_ => 30, 
		};
	}

	public static int GetLengthunitType(string wName)
	{
		return wName.ToUpper() switch
		{
			"ангстрем" => 6, 
			"нанометр" => 7, 
			"микрометр" => 8, 
			"миллиметр" => 0, 
			"сантиметр" => 1, 
			"метр" => 2, 
			"тысячная дюйма" => 10, 
			"мил" => 9, 
			"дюйм" => 3, 
			"фут" => 4, 
			"футы и дюймы" => 5, 
			_ => 0, 
		};
	}

	public static int GetAngleUnitType(string wName)
	{
		return wName.ToUpper() switch
		{
			"градус" => 0, 
			"градус/минута" => 1, 
			"градус/минута/секунда" => 2, 
			"радиан" => 3, 
			_ => 0, 
		};
	}

	public static int GetMassunitType(string wName)
	{
		return wName.ToUpper() switch
		{
			"миллиграмм" => 1, 
			"грамм" => 2, 
			"килограмм" => 3, 
			"фунт" => 4, 
			_ => 3, 
		};
	}

	public static int GetVolumeunitType(string wName)
	{
		return wName.ToUpper() switch
		{
			"ангстрем³" => 1, 
			"нанометр³" => 2, 
			"микрометр³" => 3, 
			"миллиметр³" => 4, 
			"сантиметр³" => 5, 
			"метр³" => 6, 
			"тысячная дюйма³" => 7, 
			"мил³" => 8, 
			"дюйм³" => 9, 
			"фут³" => 10, 
			"микролитр" => 11, 
			"миллилитр" => 12, 
			"сантилитр" => 13, 
			"децилитр" => 14, 
			"литр" => 15, 
			_ => 4, 
		};
	}

	public static int GetMotion_TimeType(string wName)
	{
		return wName.ToUpper() switch
		{
			"секунда" => 1, 
			"миллисекунда" => 2, 
			"микросекунда" => 5, 
			"наносекунда" => 6, 
			"минута" => 3, 
			"час" => 4, 
			_ => 1, 
		};
	}

	public static int GetMotion_ForceType(string wName)
	{
		return wName.ToUpper() switch
		{
			"дина" => 1, 
			"миллиньютон" => 2, 
			"ньютон" => 3, 
			"килоньютон" => 4, 
			"меганьютон" => 5, 
			"фунт-сила" => 6, 
			"килограмм-сила" => 7, 
			"унция-сила" => 8, 
			_ => 3, 
		};
	}

	public static int GetMotion_PowerType(string wName)
	{
		return wName.ToUpper() switch
		{
			"ватт" => 1, 
			"лошадиная сила" => 2, 
			"киловатт" => 3, 
			_ => 1, 
		};
	}

	public static int GetMotion_EnergyType(string wName)
	{
		return wName.ToUpper() switch
		{
			"джоуль" => 1, 
			"эрг" => 2, 
			"BTU" => 3, 
			"киловатт-час" => 4, 
			_ => 1, 
		};
	}

	public static long GetPaperSize(string wName)
	{
		return wName.ToUpper() switch
		{
			"A4" => 9L, 
			"A3" => 8L, 
			"A2" => 66L, 
			"A1" => 137L, 
			"A0" => 136L, 
			_ => 8L, 
		};
	}

	public static void SetSWUnit()
	{
		try
		{
			MyProject.Forms.FrmSWUnit.FrmSWUnit_Load(MyProject.Forms.FrmSWUnit, null);
			Mass_Length = GetLengthunitType(MyProject.Forms.FrmSWUnit.Mass_Length.Text);
			Mass_Mass = GetMassunitType(MyProject.Forms.FrmSWUnit.Mass_Mass.SelectedText);
			Mass_Volume = GetVolumeunitType(MyProject.Forms.FrmSWUnit.Mass_Volume.Text);
			Mass_Decimals = MyProject.Forms.FrmSWUnit.Mass_Decimals.SelectedIndex;
			Basic_Length = GetLengthunitType(MyProject.Forms.FrmSWUnit.Basic_Length.Text);
			Basic_Length_Decimals = MyProject.Forms.FrmSWUnit.Basic_Length_Decimals.SelectedIndex;
			Basic_DualDimension = GetLengthunitType(MyProject.Forms.FrmSWUnit.Basic_DualDimension.Text);
			Basic_DualDimension_Decimals = MyProject.Forms.FrmSWUnit.Basic_DualDimension_Decimals.SelectedIndex;
			Basic_Angle = GetAngleUnitType(MyProject.Forms.FrmSWUnit.Basic_Angle.Text);
			Basic_Angle_Decimals = MyProject.Forms.FrmSWUnit.Basic_Angle_Decimals.SelectedIndex;
			Motion_Time = GetMotion_TimeType(MyProject.Forms.FrmSWUnit.Motion_Time.Text);
			Motion_Time_Decimal = MyProject.Forms.FrmSWUnit.Motion_Time_Decimal.SelectedIndex;
			Motion_Force = GetMotion_ForceType(MyProject.Forms.FrmSWUnit.Motion_Force.Text);
			Motion_Force_Decimal = MyProject.Forms.FrmSWUnit.Motion_Force_Decimal.SelectedIndex;
			Motion_Power = GetMotion_PowerType(MyProject.Forms.FrmSWUnit.Motion_Power.Text);
			Motion_Power_Decimal = MyProject.Forms.FrmSWUnit.Motion_Power_Decimal.SelectedIndex;
			Motion_Energy = GetMotion_EnergyType(MyProject.Forms.FrmSWUnit.Motion_Energy.Text);
			Motion_Energy_Decimal = MyProject.Forms.FrmSWUnit.Motion_Energy_Decimal.SelectedIndex;
			foreach (Control control in MyProject.Forms.FrmSWUnit.GroupBox1.Controls)
			{
				if (((RadioButton)control).Checked)
				{
					if (Operators.CompareString(control.Name, MyProject.Forms.FrmSWUnit.Unit_CGS.Name, TextCompare: false) == 0)
					{
						UnitsSystem = 1;
					}
					else if (Operators.CompareString(control.Name, MyProject.Forms.FrmSWUnit.Unit_IPS.Name, TextCompare: false) == 0)
					{
						UnitsSystem = 3;
					}
					else if (Operators.CompareString(control.Name, MyProject.Forms.FrmSWUnit.Unit_MKS.Name, TextCompare: false) == 0)
					{
						UnitsSystem = 2;
					}
					else if (Operators.CompareString(control.Name, MyProject.Forms.FrmSWUnit.Unit_MMGS.Name, TextCompare: false) == 0)
					{
						UnitsSystem = 5;
					}
					else
					{
						UnitsSystem = 4;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void Preview2(bool typebool, string ModelName, string CfgName, Form mform = null)
	{
		try
		{
			if (!EnablePreview)
			{
				return;
			}
			if (((IntPtr)previewformhwnd != mform.Handle) & (previewformhwnd != 0))
			{
				MyProject.Forms.FrmPreview.Close();
			}
			if (!File.Exists(ModelName) || !RunSW())
			{
				return;
			}
			if (!Directory.Exists(logopathlist.PreviewFolder))
			{
				Directory.CreateDirectory(logopathlist.PreviewFolder);
			}
			string text = SplitStr(ModelName, 3) + ".SLDDRW";
			string text2 = logopathlist.PreviewFolder + SplitStr(ModelName, 1) + ".png";
			string text3 = (((!typebool || !File.Exists(text)) && 0 == 0) ? ModelName : text);
			MyProject.Forms.Frmmain.Cachedata_pre = "";
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("ZToolRequest@001" + Getpkt());
				stringBuilder.AppendLine(Conversions.ToString(MyProject.Forms.Frmmain.Handle.ToInt32()));
				stringBuilder.AppendLine(text3);
				stringBuilder.AppendLine(CfgName);
				stringBuilder.AppendLine(Conversions.ToString(Value: true));
				string text4 = stringBuilder.ToString().Trim();
				byte[] bytes = Encoding.Unicode.GetBytes(text4);
				int num = bytes.Length;
				int value = 20;
				COPYDATASTRUCT lParam = default(COPYDATASTRUCT);
				ref IntPtr dwData = ref lParam.dwData;
				dwData = new IntPtr(value);
				lParam.cbData = checked(num + 1);
				lParam.lpData = text4;
				SendMessage((int)Receiver_hWnd, 74, 0, ref lParam);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(MyProject.Forms.Frmmain, ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			try
			{
				Image image = ImageHelper.BytesToImage(Convert.FromBase64String(MyProject.Forms.Frmmain.Cachedata_pre));
				image = CutImageWhitePart((Bitmap)image, 5);
				if (!Information.IsNothing(image))
				{
					MyProject.Forms.FrmPreview.PictureBox1.Image = image;
					MyProject.Forms.FrmPreview.Image_W = image.Width;
					MyProject.Forms.FrmPreview.Image_H = image.Height;
				}
				else
				{
					MyProject.Forms.FrmPreview.PictureBox1.Image = Resources.@null;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(MyProject.Forms.Frmmain, ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			if (!MyProject.Forms.FrmPreview.Visible)
			{
				MyProject.Forms.FrmPreview.Show(mform);
			}
			MyProject.Forms.FrmPreview.form = mform;
			MyProject.Forms.FrmPreview.Tag = ModelName;
			MyProject.Forms.FrmPreview.Text = CfgName;
			previewformhwnd = (int)mform.Handle;
			MyProject.Forms.FrmPreview.Title.Text = SplitStr(text3, 4);
			if (ModelName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				MyProject.Forms.FrmPreview.Open3D_InSw.Image = Resources.sldprt;
				MyProject.Forms.FrmPreview.Open3D_InSw.ToolTipText = "Открыть деталь";
			}
			else if (ModelName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				MyProject.Forms.FrmPreview.Open3D_InSw.Image = Resources.sldasm;
				MyProject.Forms.FrmPreview.Open3D_InSw.ToolTipText = "Открыть сборку";
			}
			if (Operators.CompareString(Microsoft.VisualBasic.FileSystem.Dir(SplitStr(ModelName, 3) + ".SLDDRW"), "", TextCompare: false) != 0)
			{
				MyProject.Forms.FrmPreview.Open2D_InSw.Enabled = true;
			}
			else
			{
				MyProject.Forms.FrmPreview.Open2D_InSw.Enabled = false;
			}
			swApp = null;
			GC.Collect();
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			logopathlist.WriteLog($"Тип исключения: {ex6.GetType().Name}\r\nСообщение: {ex6.Message}\r\nИнформация: {ex6.StackTrace}");
			MessageBox.Show(ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public static void InsertPic2()
	{
		if (MyProject.Forms.Frmmain.DGV1.RowCount <= 0)
		{
			return;
		}
		checked
		{
			try
			{
				StartSwitch(status: true);
				MyProject.Forms.Frmmain.DGV1.Enabled = false;
				EnablePreview = false;
				MyProject.Forms.Frmmain.StatusLabel1.Text = "Вставка эскиза";
				MyProject.Forms.Frmmain.IsStop.Visible = true;
				Directory.CreateDirectory(logopathlist.PreviewFolder);
				MyProject.Forms.Frmmain.ToolStripProgressBar1.Maximum = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				MyProject.Forms.Frmmain.ToolStripProgressBar1.Visible = true;
				MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_Preview.Index].DefaultCellStyle.NullValue = Resources.@null;
				int num = MyProject.Forms.Frmmain.DGV1.RowCount - 1;
				int num2 = 0;
				int num6 = default(int);
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					Application.DoEvents();
					if (Dostop)
					{
						break;
					}
					MyProject.Forms.Frmmain.ToolStripProgressBar1.Value = num2;
					string text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, num2].Value);
					string value = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Cfg.Index, num2].Value);
					string filename = ((CConfigMng.Config.Thumbnail_position != 1) ? (logopathlist.PreviewFolder + SplitStr(text, 1) + ".png") : (SplitStr(text, 3) + ".png"));
					Bitmap bitmap = null;
					try
					{
						if (CConfigMng.Config.PreviewMode == 0)
						{
							MyProject.Forms.Frmmain.Cachedata_pre = "";
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder.AppendLine("ZToolRequest@001" + Getpkt());
							stringBuilder.AppendLine(Conversions.ToString(MyProject.Forms.Frmmain.Handle.ToInt32()));
							stringBuilder.AppendLine(text);
							stringBuilder.AppendLine(value);
							stringBuilder.AppendLine(Conversions.ToString(Value: false));
							string text2 = stringBuilder.ToString().Trim();
							byte[] bytes = Encoding.Unicode.GetBytes(text2);
							int num5 = bytes.Length;
							int value2 = 20;
							COPYDATASTRUCT lParam = default(COPYDATASTRUCT);
							ref IntPtr dwData = ref lParam.dwData;
							dwData = new IntPtr(value2);
							lParam.cbData = num5 + 1;
							lParam.lpData = text2;
							SendMessage((int)Receiver_hWnd, 74, 0, ref lParam);
							Bitmap original = (Bitmap)ImageHelper.BytesToImage(Convert.FromBase64String(MyProject.Forms.Frmmain.Cachedata_pre));
							bitmap = new Bitmap(original);
							bitmap = CutImage(bitmap, 0.75);
							if (CConfigMng.Config.Thumbnail_Savetolocal)
							{
								bitmap.Save(filename);
							}
							bitmap = (Bitmap)GetMinPic(bitmap, 381);
						}
						else
						{
							Bitmap bitmapThumbnail = ThumbnailHelper.GetInstance().GetBitmapThumbnail(text, 256, 192);
							bitmap = new Bitmap(bitmapThumbnail);
							if (CConfigMng.Config.Thumbnail_Savetolocal)
							{
								bitmap.Save(filename);
							}
						}
						if (!Information.IsNothing(bitmap))
						{
							MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Preview.Index, num2].Value = bitmap;
							num6 = (int)Math.Round((double)(bitmap.Width * CConfigMng.Config.rowheight) / (double)bitmap.Height);
							bitmap = null;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
						ProjectData.ClearProjectError();
					}
					num2++;
				}
				if (num6 > MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_Preview.Index].MinimumWidth)
				{
					MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_Preview.Index].Width = num6;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				GC.Collect();
				MyProject.Forms.Frmmain.DGV1.Enabled = true;
				MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_Preview.Index].Visible = true;
				MyProject.Forms.Frmmain.ToolStripProgressBar1.Visible = false;
				MyProject.Forms.Frmmain.ToolStripProgressBar1.Value = 0;
				MyProject.Forms.Frmmain.StatusLabel1.Text = "Всего сейчас" + Conversions.ToString(MyProject.Forms.Frmmain.DGV1.Rows.GetRowCount(DataGridViewElementStates.Visible)) + " поз.";
				MyProject.Forms.Frmmain.IsStop.Visible = false;
				EnablePreview = true;
				InsertPicBool = true;
			}
		}
	}

	public static void RefreshPic(int i)
	{
		checked
		{
			if (i < 0 || ((i > MyProject.Forms.Frmmain.DGV1.RowCount - 1) ? true : false))
			{
				return;
			}
			try
			{
				StartSwitch(status: true);
				Directory.CreateDirectory(logopathlist.PreviewFolder);
				string text = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Path.Index, i].Value);
				string value = Conversions.ToString(MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Cfg.Index, i].Value);
				string filename = logopathlist.PreviewFolder + SplitStr(text, 1) + ".png";
				Bitmap bitmap = null;
				if (CConfigMng.Config.PreviewMode == 0)
				{
					MyProject.Forms.Frmmain.Cachedata_pre = "";
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine("ZToolRequest@001" + Getpkt());
					stringBuilder.AppendLine(Conversions.ToString(MyProject.Forms.Frmmain.Handle.ToInt32()));
					stringBuilder.AppendLine(text);
					stringBuilder.AppendLine(value);
					stringBuilder.AppendLine(Conversions.ToString(Value: false));
					string text2 = stringBuilder.ToString().Trim();
					byte[] bytes = Encoding.Unicode.GetBytes(text2);
					int num = bytes.Length;
					int value2 = 20;
					COPYDATASTRUCT lParam = default(COPYDATASTRUCT);
					ref IntPtr dwData = ref lParam.dwData;
					dwData = new IntPtr(value2);
					lParam.cbData = num + 1;
					lParam.lpData = text2;
					SendMessage((int)Receiver_hWnd, 74, 0, ref lParam);
					Bitmap original = (Bitmap)ImageHelper.BytesToImage(Convert.FromBase64String(MyProject.Forms.Frmmain.Cachedata_pre));
					bitmap = new Bitmap(original);
					bitmap = CutImage(bitmap, 0.75);
					if (CConfigMng.Config.Thumbnail_Savetolocal)
					{
						bitmap.Save(filename);
					}
					bitmap = (Bitmap)GetMinPic(bitmap, 381);
				}
				else
				{
					Bitmap bitmapThumbnail = ThumbnailHelper.GetInstance().GetBitmapThumbnail(text, 256, 192);
					bitmap = new Bitmap(bitmapThumbnail);
					if (CConfigMng.Config.Thumbnail_Savetolocal)
					{
						bitmap.Save(filename);
					}
				}
				int num2 = default(int);
				if (!Information.IsNothing(bitmap))
				{
					MyProject.Forms.Frmmain.DGV1[MyProject.Forms.Frmmain.Col_Preview.Index, i].Value = bitmap;
					num2 = (int)Math.Round((double)(bitmap.Width * CConfigMng.Config.rowheight) / (double)bitmap.Height);
					bitmap = null;
				}
				if (num2 > MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_Preview.Index].MinimumWidth)
				{
					MyProject.Forms.Frmmain.DGV1.Columns[MyProject.Forms.Frmmain.Col_Preview.Index].Width = num2;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				GC.Collect();
			}
		}
	}

	public static void SearchFiles(List<string> files, string path, string pattern = "*.*", bool @bool = true)
	{
		try
		{
			if (path == null)
			{
				return;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			directoryInfo.GetDirectories();
			try
			{
				object obj = Strings.Split(pattern, "|");
				int num = Information.LBound((Array)obj);
				int num2 = Information.UBound((Array)obj);
				int num3 = num;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					FileInfo[] files2 = directoryInfo.GetFiles(Conversions.ToString(NewLateBinding.LateIndexGet(obj, new object[1] { num3 }, null)), (System.IO.SearchOption)Conversions.ToInteger(Interaction.IIf(@bool, System.IO.SearchOption.AllDirectories, System.IO.SearchOption.TopDirectoryOnly)));
					foreach (FileInfo fileInfo in files2)
					{
						if ((fileInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
						{
							files.Add(fileInfo.FullName);
						}
					}
					num3 = checked(num3 + 1);
				}
			}
			catch (DirectoryNotFoundException ex)
			{
				ProjectData.SetProjectError(ex);
				DirectoryNotFoundException ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public static void SearchFiles(List<string> files, string path, bool onlyhasdrw, string pattern = "*.*", bool @bool = true)
	{
		try
		{
			if (path == null)
			{
				return;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			directoryInfo.GetDirectories();
			try
			{
				object obj = Strings.Split(pattern, "|");
				int num = Information.LBound((Array)obj);
				int num2 = Information.UBound((Array)obj);
				int num3 = num;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					FileInfo[] files2 = directoryInfo.GetFiles(Conversions.ToString(NewLateBinding.LateIndexGet(obj, new object[1] { num3 }, null)), (System.IO.SearchOption)Conversions.ToInteger(Interaction.IIf(@bool, System.IO.SearchOption.AllDirectories, System.IO.SearchOption.TopDirectoryOnly)));
					foreach (FileInfo fileInfo in files2)
					{
						string fullName = fileInfo.FullName;
						string path2 = SplitStr(fullName, 3) + ".SLDDRW";
						if ((!onlyhasdrw || File.Exists(path2)) && 0 == 0 && (fileInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
						{
							files.Add(fullName);
						}
					}
					num3 = checked(num3 + 1);
				}
			}
			catch (DirectoryNotFoundException ex)
			{
				ProjectData.SetProjectError(ex);
				DirectoryNotFoundException ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public static string KeyCodeToStr(int vbKeycode)
	{
		if (vbKeycode > 47 && vbKeycode < 91)
		{
			return Conversions.ToString(Strings.Chr(vbKeycode));
		}
		if (vbKeycode > 111 && vbKeycode < 124)
		{
			return "F" + Conversions.ToString(checked(vbKeycode - 111));
		}
		if (vbKeycode > 95 && vbKeycode < 106)
		{
			return "Num " + Conversions.ToString(checked(vbKeycode - 96));
		}
		return vbKeycode switch
		{
			8 => "Back", 
			9 => "Tab", 
			12 => "Clear", 
			13 => "Enter", 
			16 => "Shift", 
			17 => "Ctrl", 
			18 => "Alt", 
			19 => "Pause", 
			20 => "Caps Lock", 
			27 => "Esc", 
			32 => "Space", 
			33 => "Page Up", 
			34 => "Page Down", 
			35 => "End", 
			36 => "Home", 
			41 => "Select", 
			42 => "Print Screen", 
			43 => "Execute", 
			44 => "SnapShot", 
			45 => "Insert", 
			46 => "Delete", 
			47 => "Help", 
			106 => "Num *", 
			107 => "Num +", 
			109 => "Num -", 
			110 => "Num Del", 
			111 => "Num /", 
			144 => "Num Lock", 
			189 => "-_", 
			187 => "=+", 
			255 => "Unknown", 
			192 => "`~", 
			37 => "Left Arrow", 
			38 => "Up Arrow", 
			39 => "Right Arrow", 
			40 => "Dowm Arrow", 
			219 => "[{", 
			221 => "]}", 
			186 => ";:", 
			222 => "'\"", 
			220 => "\\|", 
			188 => ",<", 
			190 => ".>", 
			191 => "/?", 
			193 => "\\", 
			_ => "", 
		};
	}

	public static bool IsReadOnly(string str)
	{
		bool result = false;
		try
		{
			if ((File.GetAttributes(str) & FileAttributes.ReadOnly) != 0)
			{
				result = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = true;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool IsVirtual(string str)
	{
		bool result = false;
		try
		{
			if ((SplitStr(str).Contains("VC~~") && SplitStr(str, 1).Contains("^") && SplitStr(str).Contains(Path.GetTempPath())) ? true : false)
			{
				result = true;
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

	public static bool OpenFolderWithEX(string folder)
	{
		bool result = false;
		if (string.IsNullOrEmpty(folder) | string.IsNullOrWhiteSpace(folder))
		{
			return false;
		}
		try
		{
			folder = Path.GetFullPath(folder);
			folder = ((Operators.CompareString(Strings.Right(folder, 1), "\\", TextCompare: false) == 0) ? folder : (folder + "\\"));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		if (Directory.Exists(folder))
		{
			Process.Start("Explorer.exe", folder);
			result = true;
		}
		return result;
	}

	public static string StreamToStr(MemoryStream InputStream)
	{
		string result = "";
		try
		{
			InputStream.Position = 0L;
			StreamReader streamReader = new StreamReader(InputStream);
			result = streamReader.ReadToEnd();
			streamReader.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Stream StrToStream(string str)
	{
		Stream result = null;
		try
		{
			byte[] bytes = Encoding.ASCII.GetBytes(str);
			result = new MemoryStream(bytes);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object PasteExcel(DataGridView DGV)
	{
		DataGridViewCell dataGridViewCell = null;
		bool rowFollowdisplay = CConfigMng.Config.RowFollowdisplay;
		CConfigMng.Config.RowFollowdisplay = false;
		checked
		{
			try
			{
				if (DGV.SelectedCells.Count < 1)
				{
					return 0;
				}
				foreach (DataGridViewCell selectedCell in DGV.SelectedCells)
				{
					if (Information.IsNothing(dataGridViewCell) || ((dataGridViewCell.RowIndex > selectedCell.RowIndex) ? true : false))
					{
						dataGridViewCell = selectedCell;
					}
				}
				if (Information.IsNothing(dataGridViewCell))
				{
					return 0;
				}
				string text = Clipboard.GetText();
				if (string.IsNullOrEmpty(text))
				{
					return 0;
				}
				text = text.Replace("\r\n", "\n");
				text = text.Replace("\r", "\n");
				text.TrimEnd('\n');
				string[] array = text.Split('\n');
				if (array.Length <= 1)
				{
					return 0;
				}
				if (Operators.CompareString(array[array.Length - 1], "", TextCompare: false) == 0)
				{
					array = (string[])Utils.CopyArray(array, new string[array.Length - 2 + 1]);
				}
				int columnIndex = dataGridViewCell.ColumnIndex;
				int rowIndex = dataGridViewCell.RowIndex;
				int num = 0;
				int num2 = array.Length - 1;
				int num3 = 0;
				while (true)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					string[] array2 = array[num3].Split('\t');
					int num6 = rowIndex + num3 + num;
					if (num6 > DGV.Rows.Count - 1)
					{
						break;
					}
					if (DGV[columnIndex, num6].Visible)
					{
						if ((columnIndex != MyProject.Forms.Frmmain.Col_FileName.Index || MyProject.Forms.Frmmain.isrepeat(array2[0], num6) < 0) && 0 == 0)
						{
							DGV[columnIndex, num6].Value = array2[0];
						}
					}
					else
					{
						while (num6 < DGV.Rows.Count - 1)
						{
							num6++;
							num++;
							if (DGV[columnIndex, num6].Visible)
							{
								if ((columnIndex != MyProject.Forms.Frmmain.Col_FileName.Index || MyProject.Forms.Frmmain.isrepeat(array2[0], num6) < 0) && 0 == 0)
								{
									DGV[columnIndex, num6].Value = array2[0];
								}
								break;
							}
						}
					}
					num3++;
				}
				if (DGV[columnIndex, rowIndex].Visible)
				{
					DGV.CurrentCell = DGV[columnIndex, rowIndex];
				}
				if (DGV.CurrentCell.ColumnIndex == 0)
				{
					return 0;
				}
				return 0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				CConfigMng.Config.RowFollowdisplay = rowFollowdisplay;
			}
			return 0;
		}
	}

	public static string St2(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			foreach (Match item in Regex.Matches(str, "([0-9A-Z])([0-9A-Z])", RegexOptions.IgnoreCase))
			{
				stringBuilder.Append($"{item.Groups[2].Value}{item.Groups[1].Value}");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return stringBuilder.ToString().Trim();
	}

	public static string GD52(string txt, string key)
	{
		if (Operators.CompareString(key, "天意。。。", TextCompare: false) != 0)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			try
			{
				using MD5 mD = MD5.Create();
				byte[] bytes = Encoding.UTF8.GetBytes(txt);
				byte[] array = mD.ComputeHash(bytes);
				int num = array.Length - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						stringBuilder.Append(array[num2].ToString("X1"));
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

	public static Image GetMinPic(Image MaxPic, int Int_SmallSize = 400)
	{
		checked
		{
			if ((MaxPic.Height > Int_SmallSize) | (MaxPic.Width > Int_SmallSize))
			{
				int thumbWidth;
				int thumbHeight;
				if (MaxPic.Height > MaxPic.Width)
				{
					thumbWidth = (int)Math.Round((double)MaxPic.Width / ((double)MaxPic.Height / (double)Int_SmallSize));
					thumbHeight = Int_SmallSize;
				}
				else
				{
					thumbWidth = Int_SmallSize;
					thumbHeight = (int)Math.Round((double)MaxPic.Height / ((double)MaxPic.Width / (double)Int_SmallSize));
				}
				return MaxPic.GetThumbnailImage(thumbWidth, thumbHeight, null, default(IntPtr));
			}
			return MaxPic;
		}
	}

	public static Bitmap CutImage(Bitmap bmp, double ratio)
	{
		Bitmap result = null;
		checked
		{
			try
			{
				int num;
				int num2;
				int x;
				int y;
				if (bmp.Width >= bmp.Height)
				{
					num = (int)Math.Round((double)bmp.Height / ratio);
					num2 = bmp.Height;
					x = (int)Math.Round((double)(bmp.Width - num) / 2.0);
					y = 0;
				}
				else
				{
					num = bmp.Width;
					num2 = (int)Math.Round((double)bmp.Width / ratio);
					x = 0;
					y = (int)Math.Round((double)(bmp.Height - num2) / 2.0);
				}
				Rectangle rect = new Rectangle(x, y, num, num2);
				result = bmp.Clone(rect, bmp.PixelFormat);
				bmp.Dispose();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static Bitmap CutImageWhitePart(Bitmap bmp, int t = 10)
	{
		if (Information.IsNothing(bmp))
		{
			return null;
		}
		int num = 0;
		int num2 = 0;
		int num3 = bmp.Width;
		int num4 = bmp.Height;
		checked
		{
			try
			{
				bool flag = false;
				int num5 = bmp.Height - 1;
				int num6 = 0;
				while (true)
				{
					int num7 = (t >> 31) ^ num6;
					int num8 = (t >> 31) ^ num5;
					if (num7 > num8)
					{
						break;
					}
					int num9 = bmp.Width - 1;
					int num10 = 0;
					while (true)
					{
						int num11 = (t >> 31) ^ num10;
						num8 = (t >> 31) ^ num9;
						if (num11 > num8)
						{
							break;
						}
						Color pixel = bmp.GetPixel(num10, num6);
						if (!IsWhite(pixel))
						{
							num = num6;
							flag = true;
							break;
						}
						num10 += t;
					}
					if (flag)
					{
						break;
					}
					num6 += t;
				}
				int num12 = bmp.Width - 1;
				int num13 = 0;
				while (true)
				{
					int num14 = (t >> 31) ^ num13;
					int num8 = (t >> 31) ^ num12;
					if (num14 > num8)
					{
						break;
					}
					flag = false;
					int num15 = num;
					int num16 = bmp.Height - 1;
					int num17 = num15;
					while (true)
					{
						int num18 = (t >> 31) ^ num17;
						num8 = (t >> 31) ^ num16;
						if (num18 > num8)
						{
							break;
						}
						Color pixel2 = bmp.GetPixel(num13, num17);
						if (!IsWhite(pixel2))
						{
							num2 = num13;
							flag = true;
							break;
						}
						num17 += t;
					}
					if (flag)
					{
						break;
					}
					num13 += t;
				}
				flag = false;
				int num19 = bmp.Height - 1;
				int num20 = -t;
				int num21 = num19;
				while (true)
				{
					int num22 = (num20 >> 31) ^ num21;
					int num8 = (num20 >> 31) ^ 0;
					if (num22 > num8)
					{
						break;
					}
					int num23 = num2;
					int num24 = bmp.Width - 1;
					int num25 = num23;
					while (true)
					{
						int num26 = (t >> 31) ^ num25;
						num8 = (t >> 31) ^ num24;
						if (num26 > num8)
						{
							break;
						}
						Color pixel3 = bmp.GetPixel(num25, num21);
						if (!IsWhite(pixel3))
						{
							num4 = num21;
							flag = true;
							break;
						}
						num25 += t;
					}
					if (flag)
					{
						break;
					}
					num21 += num20;
				}
				flag = false;
				int num27 = bmp.Width - 1;
				int num28 = -t;
				int num29 = num27;
				while (true)
				{
					int num30 = (num28 >> 31) ^ num29;
					int num8 = (num28 >> 31) ^ 0;
					if (num30 > num8)
					{
						break;
					}
					int num31 = num;
					int num32 = num4;
					int num33 = num31;
					while (true)
					{
						int num34 = (t >> 31) ^ num33;
						num8 = (t >> 31) ^ num32;
						if (num34 > num8)
						{
							break;
						}
						Color pixel4 = bmp.GetPixel(num29, num33);
						if (!IsWhite(pixel4))
						{
							num3 = num29;
							flag = true;
							break;
						}
						num33 += t;
					}
					if (flag)
					{
						break;
					}
					num29 += num28;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
				ProjectData.ClearProjectError();
			}
			num2 = Conversions.ToInteger(Interaction.IIf(num2 > 20, num2 - 20, num2));
			num = Conversions.ToInteger(Interaction.IIf(num > 20, num - 20, num));
			num3 = Conversions.ToInteger(Interaction.IIf(bmp.Width - num3 > 20, num3 + 20, num3));
			num4 = Conversions.ToInteger(Interaction.IIf(bmp.Height - num4 > 20, num4 + 20, num4));
			Bitmap result = null;
			try
			{
				Rectangle rect = new Rectangle(num2, num, num3 - num2, num4 - num);
				result = bmp.Clone(rect, bmp.PixelFormat);
				bmp.Dispose();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static bool IsWhite(Color c)
	{
		if (c.A < 10 || ((c.R > 245 && c.G > 245 && c.B > 245) ? true : false))
		{
			return true;
		}
		return false;
	}

	public static string St1(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			foreach (Match item in Regex.Matches(str, "([0-9A-Z])([0-9A-Z])", RegexOptions.IgnoreCase))
			{
				stringBuilder.Append($"{item.Groups[2].Value}{item.Groups[1].Value}");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return stringBuilder.ToString().Trim();
	}

	public static string GD51(string txt)
	{
		StringBuilder stringBuilder = new StringBuilder();
		checked
		{
			try
			{
				using MD5 mD = MD5.Create();
				byte[] bytes = Encoding.UTF8.GetBytes(txt);
				byte[] array = mD.ComputeHash(bytes);
				int num = array.Length - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 <= num4)
					{
						stringBuilder.Append(array[num2].ToString("X2"));
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

	public static string getstrbylen(string strs, int len)
	{
		string[] array = Strings.Split(strs, ",");
		int num = checked(array.Count() - 1);
		int num2 = 1;
		while (true)
		{
			int num3 = num2;
			int num4 = num;
			if (num3 > num4)
			{
				break;
			}
			if (num2 % len == 0)
			{
				array[num2] += " _\n";
			}
			num2 = checked(num2 + 1);
		}
		return string.Join(",", array);
	}

	public static string StringToHex(string text)
	{
		string text2 = "";
		ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
		aSCIIEncoding.GetEncoder();
		checked
		{
			int num = text.Length - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				text2 += Strings.Asc(text.Substring(num2, 1)).ToString("X4").ToUpper();
				num2++;
			}
			return text2;
		}
	}

	public static bool Cbool1(string str)
	{
		bool result;
		try
		{
			result = string.Equals(str.Trim(), "yes", StringComparison.OrdinalIgnoreCase) || (string.Equals(str.Trim(), "Да", StringComparison.OrdinalIgnoreCase) ? true : false) || (((!string.Equals(str.Trim(), "no", StringComparison.OrdinalIgnoreCase) && !string.Equals(str.Trim(), "not", StringComparison.OrdinalIgnoreCase) && !string.Equals(str.Trim(), "Нет", StringComparison.OrdinalIgnoreCase)) || 1 == 0) && Conversions.ToBoolean(str));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string YesOrNo(string str)
	{
		string result;
		try
		{
			result = (((string.Equals(str.Trim(), "true", StringComparison.OrdinalIgnoreCase) || string.Equals(str.Trim(), "yes", StringComparison.OrdinalIgnoreCase) || string.Equals(str.Trim(), "Да", StringComparison.OrdinalIgnoreCase)) ? true : false) ? "Yes" : (((!string.Equals(str.Trim(), "false", StringComparison.OrdinalIgnoreCase) && !string.Equals(str.Trim(), "no", StringComparison.OrdinalIgnoreCase) && !string.Equals(str.Trim(), "not", StringComparison.OrdinalIgnoreCase) && !string.Equals(str.Trim(), "Нет", StringComparison.OrdinalIgnoreCase)) || 1 == 0) ? str : "Not"));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = str;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string GetHash()
	{
		string result = "";
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;
			openFileDialog.SupportMultiDottedExtensions = true;
			openFileDialog.Filter = "All Files(*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return result;
			}
			string fileName = openFileDialog.FileName;
			FileInfo fileInfo = new FileInfo(fileName);
			using Stream inputStream = fileInfo.OpenRead();
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] inArray = mD.ComputeHash(inputStream);
			result = GD51(Convert.ToBase64String(inArray));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string Getpkt()
	{
		string result;
		try
		{
			byte[] publicKeyToken = Assembly.GetEntryAssembly().GetName(copiedName: true).GetPublicKeyToken();
			result = St2(GD52(BitConverter.ToString(publicKeyToken).Replace("-", ""), "天意。。。"));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool HasShell(string k)
	{
		return true;
	}

	public static string GenerateRandom(int Length, int s)
	{
		string text = "";
		string[] array = null;
		switch (s)
		{
		case 2:
			text = "0,1,2,3,4,5,6,7,8,9";
			array = text.Split(',');
			break;
		case 1:
			text = "a,b,c,d,e,f,g,h,i,j,k,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,D,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,X,Y,Z";
			array = text.Split(',');
			break;
		case 5:
			text = "a,b,c,d,e,f,g,h,i,j,k,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
			array = text.Split(',');
			break;
		case 3:
			text = "a,b,c,d,e,f,g,h,i,j,k,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,D,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,X,Y,Z,0,1,2,3,4,5,6,7,8,9";
			array = text.Split(',');
			break;
		case 4:
			text = "A,B,C,E,F,D,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
			array = text.Split(',');
			break;
		}
		StringBuilder stringBuilder = new StringBuilder(Length);
		Random random = new Random();
		checked
		{
			int num = Length - 1;
			int num3 = default(int);
			int num2 = num3 + 1;
			int num4 = num;
			num3 = 0;
			while (true)
			{
				int num5 = (num2 >> 31) ^ num3;
				int num6 = (num2 >> 31) ^ num4;
				if (num5 > num6)
				{
					break;
				}
				stringBuilder.Append(array[random.Next(array.Length - 1)]);
				num3 += num2;
			}
			return stringBuilder.ToString();
		}
	}

	public static void DeleteInvalidChars(ref string str)
	{
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		checked
		{
			int num = invalidFileNameChars.Count() - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 <= num4)
				{
					str = str.Replace(Conversions.ToString(invalidFileNameChars[num2]), "");
					num2++;
					continue;
				}
				break;
			}
		}
	}

	public static string ToHexString(this string str)
	{
		string result;
		try
		{
			string text = "";
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			foreach (byte b in bytes)
			{
				text += b.ToString("x2");
			}
			result = text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string FromHexString(this string str)
	{
		checked
		{
			string result;
			try
			{
				byte[] array = new byte[unchecked(str.Length / 2) - 1 + 1];
				int num = unchecked(str.Length / 2) - 1;
				int num2 = 0;
				while (true)
				{
					int num3 = num2;
					int num4 = num;
					if (num3 > num4)
					{
						break;
					}
					array[num2] = Convert.ToByte(str.Substring(num2 * 2, 2), 16);
					num2++;
				}
				result = Encoding.UTF8.GetString(array);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = "";
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static bool Exist(this string[] arr, string str, StringComparison ComparisonType)
	{
		bool result;
		try
		{
			if (Information.IsNothing(arr))
			{
				result = false;
			}
			else
			{
				bool flag = false;
				foreach (string text in arr)
				{
					if (text.Equals(str, ComparisonType))
					{
						flag = true;
						break;
					}
				}
				result = flag;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static string FindIndexedProcessName(int pid)
	{
		string processName = Process.GetProcessById(pid).ProcessName;
		Process[] processesByName = Process.GetProcessesByName(processName);
		string text = null;
		checked
		{
			int num = processesByName.Length - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				text = ((num2 == 0) ? processName : (processName + "#" + Conversions.ToString(num2)));
				PerformanceCounter performanceCounter = new PerformanceCounter("Process", "ID Process", text);
				if ((int)Math.Round(Math.Truncate(performanceCounter.NextValue())) == pid)
				{
					return text;
				}
				num2++;
			}
			return text;
		}
	}

	private static Process FindPidFromIndexedProcessName(string indexedProcessName)
	{
		PerformanceCounter performanceCounter = new PerformanceCounter("Process", "Creating Process ID", indexedProcessName);
		return Process.GetProcessById(checked((int)Math.Round(Math.Truncate(performanceCounter.NextValue()))));
	}

	public static Process Parent(this Process process)
	{
		return FindPidFromIndexedProcessName(FindIndexedProcessName(process.Id));
	}

	public static string getver(string k, bool md5 = false)
	{
		if (Operators.CompareString(k, "今天。。。", TextCompare: false) != 0)
		{
			return "";
		}
		string text = "";
		text = ((!Environment.Is64BitProcess) ? (Application.ProductVersion.ToString() + " (x86)") : (Application.ProductVersion.ToString() + " (x64)"));
		return Conversions.ToString(Interaction.IIf(md5, GD51(text), text));
	}

	public static byte[] int_to_Byte(int iSource, int len)
	{
		checked
		{
			byte[] array = new byte[len - 1 + 1];
			try
			{
				for (int i = 0; i < 4 && i < len; i++)
				{
					if (1 == 0)
					{
						break;
					}
					array[i] = (byte)((iSource >> 8 * i) & 0xFF);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return array;
		}
	}

	public static int byte_to_Int(byte[] b)
	{
		int num = 0;
		checked
		{
			try
			{
				int num2 = 0;
				int num3;
				int num4;
				do
				{
					byte b2 = b[num2];
					num += (b2 & 0xFF) << 8 * num2;
					num2++;
					num3 = num2;
					num4 = 3;
				}
				while (num3 <= num4);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return num;
		}
	}

	public static void CreatelinkbyVBS()
	{
		string text = logopathlist.rootpath + "Shortcut.VBS";
		string text2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SWTools.lnk";
		try
		{
			using (StreamWriter streamWriter = new StreamWriter(text, append: false, Encoding.Unicode))
			{
				streamWriter.WriteLine("set WshShell = WScript.CreateObject(\"WScript.Shell\")");
				streamWriter.WriteLine("set oShellLink = WshShell.CreateShortcut(\"" + text2 + "\")");
				streamWriter.WriteLine("oShellLink.TargetPath =\"" + Application.ExecutablePath + "\"");
				streamWriter.WriteLine("oShellLink.WindowStyle = 1");
				streamWriter.WriteLine("oShellLink.Description =\"Эффективный помощник для SolidWorks\" ");
				streamWriter.WriteLine("oShellLink.WorkingDirectory =\"" + Application.StartupPath + "\"");
				streamWriter.WriteLine("oShellLink.Save");
				streamWriter.WriteLine("createobject(\"scripting.filesystemobject\").deletefile wscript.scriptfullname");
			}
			if (File.Exists(text))
			{
				Process.Start(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Не удалось создать ярлык!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public static void startrg(IWin32Window frm)
	{
		try
		{
			using Process expression = Process.GetProcessById(rghwnd);
			if ((rghwnd > 0 && !Information.IsNothing(expression)) ? true : false)
			{
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		try
		{
			WindowsIdentity current = WindowsIdentity.GetCurrent();
			WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
			if (windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
			{
				MyProject.Forms.FrmRg.Show();
				return;
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = Application.ExecutablePath;
			processStartInfo.Arguments = "0" + Strings.Space(1) + Conversions.ToString(110);
			processStartInfo.Verb = "runas";
			using Process process = Process.Start(processStartInfo);
			rghwnd = process.Id;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
	}

	public static void startaddin()
	{
		try
		{
			using Process expression = Process.GetProcessById(rghwnd2);
			if ((rghwnd2 > 0 && !Information.IsNothing(expression)) ? true : false)
			{
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		checked
		{
			try
			{
				string directoryName = Path.GetDirectoryName(Application.ExecutablePath);
				string[] array = null;
				if (Directory.Exists(directoryName))
				{
					array = Directory.GetFiles(directoryName, "*.exe");
				}
				bool flag = false;
				int num2 = default(int);
				if (!Information.IsNothing(array))
				{
					int num = array.Length - 1;
					num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 > num4)
						{
							break;
						}
						try
						{
							Assembly assembly = Assembly.LoadFrom(array[num2]);
							if ((!Information.IsNothing(assembly) && assembly.GetName().Name.Equals("Инициализация", StringComparison.OrdinalIgnoreCase)) ? true : false)
							{
								flag = true;
								break;
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ProjectData.ClearProjectError();
						}
						num2++;
					}
				}
				if (flag)
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = array[num2];
					processStartInfo.Verb = "runas";
					using Process process = Process.Start(processStartInfo);
					rghwnd2 = process.Id;
					return;
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ProjectData.ClearProjectError();
			}
		}
	}

	public static List<string> getmateriallist()
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				if (RunSW(HideWindow: false, startnew: false))
				{
					List<string> list2 = new List<string>();
					string text = Conversions.ToString(NewLateBinding.LateGet(swApp, null, "GetUserPreferenceStringValue", new object[1] { 28 }, null, null, null));
					list2 = text.Split(';').ToList();
					int num = list2.Count - 1;
					int num2 = 0;
					while (true)
					{
						int num3 = num2;
						int num4 = num;
						if (num3 <= num4)
						{
							if (Directory.Exists(list2[num2]))
							{
								SearchFiles(list, list2[num2], "*.sldmat", @bool: false);
							}
							num2++;
							continue;
						}
						break;
					}
				}
				else
				{
					List<string> list3 = new List<string>();
					RegistryKey registryKey = null;
					int num5 = 2030;
					int num6;
					int num4;
					do
					{
						registryKey = Registry.CurrentUser.OpenSubKey("Software\\SolidWorks\\SOLIDWORKS " + Conversions.ToString(num5) + "\\ExtReferences", writable: false);
						if (!Information.IsNothing(registryKey))
						{
							break;
						}
						num5 += -1;
						num6 = num5;
						num4 = 2012;
					}
					while (num6 >= num4);
					string text2 = Conversions.ToString(registryKey.GetValue("Material Database Folders"));
					registryKey.Close();
					list3 = text2.Split(';').ToList();
					int num7 = list3.Count - 1;
					int num8 = 0;
					while (true)
					{
						int num9 = num8;
						num4 = num7;
						if (num9 <= num4)
						{
							if (Directory.Exists(list3[num8]))
							{
								SearchFiles(list, list3[num8], "*.sldmat", @bool: false);
							}
							num8++;
							continue;
						}
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return list;
		}
	}

	public static int CharWidth(string str, Font font)
	{
		int result = 0;
		using Bitmap image = new Bitmap(10, 10);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			result = checked((int)Math.Round((double)(int)Math.Round(graphics.MeasureString(str, font).Width) / 0.0148 / (double)graphics.DpiX));
		}
		return result;
	}

	public static updateInf GetRemoteinf(string URL)
	{
		updateInf result = default(updateInf);
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
			if (Information.IsNothing(httpWebRequest))
			{
				return result;
			}
			httpWebRequest.KeepAlive = false;
			httpWebRequest.AllowAutoRedirect = false;
			httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
			httpWebRequest.Timeout = 5000;
			httpWebRequest.Proxy = (IWebProxy)GetProxy();
			httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
			using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			if (httpWebResponse.StatusCode == HttpStatusCode.OK || httpWebResponse.StatusCode == HttpStatusCode.PartialContent)
			{
				using Stream inStream = httpWebResponse.GetResponseStream();
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(inStream);
				result.changetime = xmlDocument.SelectSingleNode("/UpDateInfo/changetime").Attributes[0].Value.ToString();
				result.latestversion = xmlDocument.SelectSingleNode("/UpDateInfo/latestversion").Attributes[0].Value.ToString();
				result.md5 = xmlDocument.SelectSingleNode("/UpDateInfo/md5").Attributes[0].Value.ToString();
				result.downloadurl = xmlDocument.SelectSingleNode("/UpDateInfo/downloadurl").Attributes[0].Value.ToString();
				result.changelog = xmlDocument.SelectSingleNode("/UpDateInfo/changelog").Attributes[0].Value.ToString();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw ex2;
		}
		return result;
	}

	public static object GetProxy()
	{
		return null;
	}

	public static bool IsNumber(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return false;
		}
		string pattern = "^[+-]?\\d*[.]?\\d*$";
		return Regex.IsMatch(str, pattern);
	}

	public static bool IsInt(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return false;
		}
		string pattern = "^[+-]?\\d*$";
		return Regex.IsMatch(str, pattern);
	}

	public static string MidStrEx(string source, string startstr, string endstr)
	{
		string result = string.Empty;
		try
		{
			if (Information.IsNothing(source))
			{
				return result;
			}
			int num = source.IndexOf(startstr);
			if (num == -1)
			{
				return result;
			}
			string text = source.Substring(checked(num + startstr.Length));
			int num2 = text.IndexOf(endstr);
			if (num2 == -1)
			{
				return result;
			}
			result = text.Remove(num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void killxlapp(object xlapp)
	{
		try
		{
			int lpdwProcessId = 0;
			GetWindowThreadProcessId(Conversions.ToInteger(NewLateBinding.LateGet(xlapp, null, "hwnd", new object[0], null, null, null)), ref lpdwProcessId);
			Process processById = Process.GetProcessById(lpdwProcessId);
			processById.Kill();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static Color ARGBtoColor(int argb)
	{
		checked
		{
			byte alpha = (byte)((argb >> 24) & 0xFF);
			byte red = (byte)((argb >> 16) & 0xFF);
			byte green = (byte)((argb >> 8) & 0xFF);
			byte blue = (byte)(argb & 0xFF);
			return Color.FromArgb(alpha, red, green, blue);
		}
	}

	public static byte[] SerializeBinary(object request)
	{
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		MemoryStream memoryStream = new MemoryStream();
		binaryFormatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(request));
		return memoryStream.GetBuffer();
	}

	public static object DeserializeBinary(byte[] buf)
	{
		MemoryStream memoryStream = new MemoryStream(buf);
		memoryStream.Position = 0L;
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Binder = new VTBinder();
		object objectValue = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize(memoryStream));
		memoryStream.Close();
		return objectValue;
	}

	public static string SerializeObject(object obj)
	{
		IFormatter formatter = new BinaryFormatter();
		string result = string.Empty;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			formatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(obj));
			byte[] array = new byte[checked((int)(memoryStream.Length - 1) + 1)];
			array = memoryStream.ToArray();
			result = Convert.ToBase64String(array);
			memoryStream.Flush();
		}
		return result;
	}

	public static object DeserializeObject(string str)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		formatter.Binder = new VTBinder();
		byte[] array = Convert.FromBase64String(str);
		object result = null;
		using (Stream stream = new MemoryStream(array, 0, array.Length))
		{
			stream.Position = 0L;
			result = RuntimeHelpers.GetObjectValue(formatter.Deserialize(stream));
		}
		return result;
	}

	public static string SerializeObject_json(object obj)
	{
		string result = "";
		try
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			result = javaScriptSerializer.Serialize(RuntimeHelpers.GetObjectValue(obj));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object DeserializeObject_json(string str, Type type)
	{
		object result = null;
		try
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			result = RuntimeHelpers.GetObjectValue(javaScriptSerializer.Deserialize(str, type));
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
