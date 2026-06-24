using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using SolidWorksTools;
using SolidWorksTools.File;

namespace ZTool;

[ComVisible(true)]
[SwAddin(Description = "SWTools SolidWorks Add-in", Title = "SWTools", LoadAtStartup = true)]
[Guid("59959DFA-3229-4B86-852E-52ABF2BDB8C0")]
public class SwAddin : SolidWorks.Interop.swpublished.SwAddin
{
	private enum Type_35
	{
		swMenuItem = 1,
		swToolbarItem
	}

	private enum Type_36
	{
		swDocPART = 1,
		swDocASSEMBLY,
		swDocDRAWING
	}

	private enum Type_37
	{
		swCommandTabButton_NoText = 1,
		swCommandTabButton_TextBelow = 2,
		swCommandTabButton_TextHorizontal = 4
	}

	[AccessedThroughProperty("iSwApp")]
	private SldWorks f_370;

	private ICommandManager f_371;

	private SldWorks f_372;

	private int f_373;

	private Hashtable f_374;

	private Page_RepairReference f_375;

	private Page_randomcolor f_376;

	private PMPHandler f_377;

	internal static Frm_SN f_378;

	internal static ReName f_379;

	private ICommandGroup f_380;

	private const int f_381 = 999;

	private const int f_382 = 1000;

	private const int f_383 = 1001;

	private const int f_384 = 1002;

	private const int f_385 = 1003;

	private const int f_386 = 1004;

	private const int f_387 = 1005;

	private const int f_388 = 1006;

	private const int f_389 = 1007;

	private const int f_390 = 1050;

	private const int f_391 = 1051;

	private const int f_392 = 1052;

	private const int f_393 = 1053;

	private const int f_394 = 1054;

	private const int f_395 = 1055;

	private const int f_396 = 1056;

	private const int f_397 = 3001;

	private const int f_398 = 3002;

	private const int f_399 = 3003;

	private const int f_400 = 1090;

	private SldWorks p_119
	{
		get
		{
			return f_370;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_370 = value;
		}
	}

	public SldWorks SwApp => p_119;

	public ICommandManager CmdMgr => f_371;

	public Hashtable OpenDocumentsTable => f_374;

	[ComRegisterFunction]
	public static void RegisterFunction(Type t)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		SwAddinAttribute val = null;
		object[] customAttributes = System.Attribute.GetCustomAttributes(typeof(SwAddin), typeof(SwAddinAttribute));
		if (customAttributes.Length > 0)
		{
			val = (SwAddinAttribute)customAttributes[0];
		}
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			RegistryKey currentUser = Registry.CurrentUser;
			string subkey = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
			RegistryKey registryKey = localMachine.CreateSubKey(subkey);
			registryKey.SetValue(null, 1, RegistryValueKind.DWord);
			registryKey.SetValue("", 1, RegistryValueKind.DWord);
			registryKey.SetValue("Description", "SWTools SolidWorks Add-in");
			registryKey.SetValue("Title", "SWTools");
			subkey = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
			registryKey = currentUser.CreateSubKey(subkey);
			registryKey.SetValue(null, val.LoadAtStartup, RegistryValueKind.DWord);
		}
		catch (NullReferenceException ex)
		{
			ProjectData.SetProjectError(ex);
			NullReferenceException ex2 = ex;
			Console.WriteLine("There was a problem registering this dll: SWattr is null.\\n " + ex2.Message);
			MessageBox.Show("There was a problem registering this dll: SWattr is null.\\n" + ex2.Message);
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Console.WriteLine("There was a problem registering this dll: " + ex4.Message);
			MessageBox.Show("There was a problem registering this dll: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}

	[ComUnregisterFunction]
	public static void UnregisterFunction(Type t)
	{
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			RegistryKey currentUser = Registry.CurrentUser;
			string subkey = "SOFTWARE\\SolidWorks\\Addins\\{" + t.GUID.ToString() + "}";
			localMachine.DeleteSubKey(subkey);
			subkey = "Software\\SolidWorks\\AddInsStartup\\{" + t.GUID.ToString() + "}";
			currentUser.DeleteSubKey(subkey);
		}
		catch (NullReferenceException ex)
		{
			ProjectData.SetProjectError(ex);
			NullReferenceException ex2 = ex;
			Console.WriteLine("There was a problem unregistering this dll: SWattr is null.\\n " + ex2.Message);
			MessageBox.Show("There was a problem unregistering this dll: SWattr is null.\\n" + ex2.Message);
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Console.WriteLine("There was a problem unregistering this dll: " + ex4.Message);
			MessageBox.Show("There was a problem unregistering this dll: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}

	public bool ConnectToSW(object ThisSW, int Cookie)
	{
		p_119 = (SldWorks)ThisSW;
		f_373 = Cookie;
		SldWorks instance = p_119;
		object[] array = new object[3] { 0, this, f_373 };
		bool[] array2 = new bool[3] { false, false, true };
		NewLateBinding.LateCall(instance, null, "SetAddinCallbackInfo2", array, null, null, array2, IgnoreReturn: true);
		if (array2[2])
		{
			f_373 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[2]), typeof(int));
		}
		f_371 = p_119.GetCommandManager(Cookie);
		AddCommandMgr();
		f_372 = p_119;
		f_374 = new Hashtable();
		AttachEventHandlers();
		AddPMP();
		return true;
	}

	bool ISwAddin.ConnectToSW(object ThisSW, int Cookie)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ConnectToSW
		return this.ConnectToSW(ThisSW, Cookie);
	}

	public bool DisconnectFromSW()
	{
		RemoveCommandMgr();
		RemovePMP();
		DetachEventHandlers();
		Marshal.ReleaseComObject(f_371);
		f_371 = null;
		Marshal.ReleaseComObject(p_119);
		p_119 = null;
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		return true;
	}

	bool ISwAddin.DisconnectFromSW()
	{
		//ILSpy generated this explicit interface implementation from .override directive in DisconnectFromSW
		return this.DisconnectFromSW();
	}

	public bool AddPMP()
	{
		f_375 = new Page_RepairReference();
		f_376 = new Page_randomcolor();
		f_375.Init(p_119, this);
		f_376.Init(p_119, this);
		f_377 = new PMPHandler();
		f_377.f_206 = SwApp;
		bool result = default(bool);
		return result;
	}

	private bool EnsurePMP()
	{
		if (Information.IsNothing(f_377) || f_377.IsDisposed)
		{
			AddPMP();
		}
		return !Information.IsNothing(f_377) && !f_377.IsDisposed;
	}

	public bool RemovePMP()
	{
		f_375 = null;
		f_376 = null;
		f_377 = null;
		bool result = default(bool);
		return result;
	}

	public void AddCommandMgr()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		BitmapHandler val = new BitmapHandler();
		string text = "ZTool";
		string toolTip = "ZTool — вспомогательные инструменты";
		Assembly assembly = Assembly.GetAssembly(GetType());
		int Errors = 0;
		bool flag = false;
		object UserIDs = null;
		bool groupDataFromRegistry = f_371.GetGroupDataFromRegistry(999, out UserIDs);
		int[] addinIDs = new int[19]
		{
			1000, 1001, 1002, 1003, 1004, 1005, 1006, 1007, 1050, 1051,
			1052, 1053, 1054, 1055, 1056, 3001, 3002, 3003, 1090
		};
		if (groupDataFromRegistry && !CompareIDs((int[])UserIDs, addinIDs))
		{
			flag = true;
		}
		f_380 = f_371.CreateCommandGroup2(999, text, toolTip, "", -1, flag, ref Errors);
		int num;
		using (Graphics graphics = Graphics.FromHwnd(Type_16.m_60(SwApp.GetProcessID()).Handle))
		{
			num = checked((int)Math.Round(graphics.DpiX / 96f));
		}
		if (num >= 2)
		{
			f_380.LargeIconList = val.CreateFileFromResourceBitmap("ZTool.ToolbarLarge_32.bmp", assembly);
			f_380.SmallIconList = val.CreateFileFromResourceBitmap("ZTool.ToolbarLarge_24.bmp", assembly);
			f_380.LargeMainIcon = val.CreateFileFromResourceBitmap("ZTool.MainIconLarge_32.bmp", assembly);
			f_380.SmallMainIcon = val.CreateFileFromResourceBitmap("ZTool.MainIconLarge_24.bmp", assembly);
		}
		else
		{
			f_380.LargeIconList = val.CreateFileFromResourceBitmap("ZTool.ToolbarLarge_24.bmp", assembly);
			f_380.SmallIconList = val.CreateFileFromResourceBitmap("ZTool.ToolbarSmall_16.bmp", assembly);
			f_380.LargeMainIcon = val.CreateFileFromResourceBitmap("ZTool.MainIconLarge_24.bmp", assembly);
			f_380.SmallMainIcon = val.CreateFileFromResourceBitmap("ZTool.MainIconSmall_16.bmp", assembly);
		}
		int menuTBOption = 3;
		int commandIndex = f_380.AddCommandItem2("Переименование деталей", -1, "Переименование деталей", "Переименование деталей", 0, "Menu0_0", "PMPEnable_0", 1000, menuTBOption);
		int commandIndex2 = f_380.AddCommandItem2("Синхронизация в папку детали", -1, "Синхронизация в папку детали", "Синхронизация в папку детали", 9, "Menu0_1", "PMPEnable_1", 1001, menuTBOption);
		int commandIndex3 = f_380.AddCommandItem2("Разделить конфигурации", -1, "Разделить конфигурации", "Разделить конфигурации", 7, "Menu0_2", "PMPEnable_2", 1002, menuTBOption);
		int commandIndex4 = f_380.AddCommandItem2("Временный номер", -1, "Временный номер", "Временный номер", 17, "Menu0_7", "PMPEnable_3", 1007, menuTBOption);
		int commandIndex5 = f_380.AddCommandItem2("Сохранить выбранное", -1, "Сохранить выбранные детали в сборке", "Сохранить выбранное", 8, "Menu0_3", "PMPEnable_3", 1003, menuTBOption);
		int commandIndex6 = f_380.AddCommandItem2("Восстановить внешние ссылки", -1, "Восстановить потерянные внешние ссылки деталей в сборке", "Восстановить внешние ссылки", 11, "Menu0_4", "PMPEnable_3", 1004, menuTBOption);
		int commandIndex7 = f_380.AddCommandItem2("Случайная окраска", -1, "Случайная окраска", "Случайная окраска", 14, "Menu0_6", "PMPEnable_0", 1006, menuTBOption);
		int commandIndex8 = f_380.AddCommandItem2("Доп. функции", -1, "Доп. функции", "Доп. функции", 12, "Menu0_5", "1", 1005, menuTBOption);
		f_380.AddSpacer(-1);
		int commandIndex9 = f_380.AddCommandItem2("Управление файлами", -1, "Пакетная обработка файлов", "Управление файлами", 1, "openZtool(0)", "1", 1050, menuTBOption);
		int commandIndex10 = f_380.AddCommandItem2("Пакетное преобразование форматов", -1, "Пакетное преобразование форматов", "Пакетное преобразование форматов", 2, "openZtool(1)", "1", 1051, menuTBOption);
		int commandIndex11 = f_380.AddCommandItem2("Пакетная печать", -1, "Пакетная печать чертежей", "Пакетная печать", 3, "openZtool(2)", "", 1052, menuTBOption);
		int commandIndex12 = f_380.AddCommandItem2("Замена рамки и стандарта", -1, "Пакетная замена рамки и стандарта", "Замена рамки и стандарта", 4, "openZtool(3)", "1", 1053, menuTBOption);
		int commandIndex13 = f_380.AddCommandItem2("Замена ссылочных файлов", -1, "Поиск и замена одноимённых ссылочных файлов из указанной папки", "Замена ссылочных файлов", 5, "openZtool(4)", "1", 1054, menuTBOption);
		int commandIndex14 = f_380.AddCommandItem2("Синхронизация имён чертежей", -1, "Пакетная синхронизация имён чертежей с именами и путями связанных деталей", "Синхронизация имён чертежей", 6, "openZtool(5)", "1", 1055, menuTBOption);
		int commandIndex15 = f_380.AddCommandItem2("Объединение и разделение PDF", -1, "Объединение и разделение PDF", "Объединение и разделение PDF", 10, "openZtool(6)", "1", 1056, menuTBOption);
		f_380.AddSpacer(-1);
		int commandIndex16 = f_380.AddCommandItem2("Обновление", -1, "Обновление", "Обновление", 15, "openZtool(120)", "1", 3001, menuTBOption);
		int commandIndex17 = f_380.AddCommandItem2("Справка", -1, "Справка", "Справка", 13, "Menu3_1", "1", 3002, menuTBOption);
		int commandIndex18 = f_380.AddCommandItem2("О программе", -1, "О программе", "О программе", 16, "openZtool(130)", "1", 3003, menuTBOption);
		f_380.AddSpacer(-1);
		f_380.HasToolbar = true;
		f_380.HasMenu = true;
		f_380.Activate();
		string largeImageList;
		string smallImageList;
		string largeIcon;
		string smallIcon;
		if (num >= 2)
		{
			largeImageList = val.CreateFileFromResourceBitmap("ZTool.flyGroupiconlist_32.png", assembly);
			smallImageList = val.CreateFileFromResourceBitmap("ZTool.flyGroupiconlist_24.png", assembly);
			largeIcon = val.CreateFileFromResourceBitmap("ZTool.flyGroupicon_32.png", assembly);
			smallIcon = val.CreateFileFromResourceBitmap("ZTool.flyGroupicon_24.png", assembly);
		}
		else
		{
			largeImageList = val.CreateFileFromResourceBitmap("ZTool.flyGroupiconlist_24.png", assembly);
			smallImageList = val.CreateFileFromResourceBitmap("ZTool.flyGroupiconlist_16.png", assembly);
			largeIcon = val.CreateFileFromResourceBitmap("ZTool.flyGroupicon_24.png", assembly);
			smallIcon = val.CreateFileFromResourceBitmap("ZTool.flyGroupicon_16.png", assembly);
		}
		string text2 = Type_16.m_63("", "title1");
		if (Operators.CompareString(text2.Trim(), "", TextCompare: false) == 0)
		{
			text2 = "Настроить";
		}
		string text3 = Type_16.m_63("", "tooltip1");
		if (Operators.CompareString(text3.Trim(), "", TextCompare: false) == 0)
		{
			text3 = "Настроить";
		}
		string text4 = Type_16.m_63("", "hint1");
		if (Operators.CompareString(text4.Trim(), "", TextCompare: false) == 0)
		{
			text4 = "Пользовательское меню";
		}
		FlyoutGroup flyoutGroup = f_371.CreateFlyoutGroup(1090, text2, text3, text4, smallIcon, largeIcon, smallImageList, largeImageList, "FlyoutCallback1", "1");
		if (Operators.CompareString(Type_16.m_63("", "AddContext1"), "1", TextCompare: false) == 0)
		{
			bool flag2 = flyoutGroup.AddContextMenuFlyout(1, 2);
			flag2 = flyoutGroup.AddContextMenuFlyout(2, 20);
			flag2 = flyoutGroup.AddContextMenuFlyout(2, 2);
		}
		int[] array = new int[3] { 2, 3, 1 };
		int[] array2 = array;
		foreach (int documentType in array2)
		{
			ICommandTab commandTab = f_371.GetCommandTab(documentType, text);
			if ((commandTab != null && !groupDataFromRegistry) || flag)
			{
				f_371.RemoveCommandTab((CommandTab)commandTab);
				commandTab = null;
			}
			if (commandTab == null)
			{
				commandTab = f_371.AddCommandTab(documentType, text);
				CommandTabBox commandTabBox = commandTab.AddCommandTabBox();
				int[] array3 = new int[8];
				int[] array4 = new int[8];
				array3[0] = f_380.get_CommandID(commandIndex);
				array4[0] = 2;
				array3[1] = f_380.get_CommandID(commandIndex2);
				array4[1] = 2;
				array3[2] = f_380.get_CommandID(commandIndex3);
				array4[2] = 2;
				array3[3] = f_380.get_CommandID(commandIndex4);
				array4[3] = 2;
				array3[4] = f_380.get_CommandID(commandIndex5);
				array4[4] = 2;
				array3[5] = f_380.get_CommandID(commandIndex6);
				array4[5] = 2;
				array3[6] = f_380.get_CommandID(commandIndex7);
				array4[6] = 2;
				array3[7] = f_380.get_CommandID(commandIndex8);
				array4[7] = 2;
				bool flag2 = commandTabBox.AddCommands(array3, array4);
				CommandTabBox commandTabBox2 = commandTab.AddCommandTabBox();
				array3 = new int[7];
				array4 = new int[7];
				array3[0] = f_380.get_CommandID(commandIndex9);
				array4[0] = 2;
				array3[1] = f_380.get_CommandID(commandIndex10);
				array4[1] = 2;
				array3[2] = f_380.get_CommandID(commandIndex11);
				array4[2] = 2;
				array3[3] = f_380.get_CommandID(commandIndex12);
				array4[3] = 2;
				array3[4] = f_380.get_CommandID(commandIndex13);
				array4[4] = 2;
				array3[5] = f_380.get_CommandID(commandIndex14);
				array4[5] = 2;
				array3[6] = f_380.get_CommandID(commandIndex15);
				array4[6] = 2;
				flag2 = commandTabBox2.AddCommands(array3, array4);
				CommandTabBox commandTabBox3 = commandTab.AddCommandTabBox();
				array3 = new int[2];
				array4 = new int[2];
				array3[0] = flyoutGroup.CmdID;
				array4[0] = 2;
				flag2 = commandTabBox3.AddCommands(array3, array4);
				CommandTabBox commandTabBox4 = commandTab.AddCommandTabBox();
				array3 = new int[4];
				array4 = new int[4];
				array3[0] = f_380.get_CommandID(commandIndex16);
				array4[0] = 2;
				array3[1] = f_380.get_CommandID(commandIndex17);
				array4[1] = 2;
				array3[2] = f_380.get_CommandID(commandIndex18);
				array4[2] = 2;
				flag2 = commandTabBox4.AddCommands(array3, array4);
			}
		}
		int[] array5 = array;
		foreach (int documentType2 in array5)
		{
			ICommandTab commandTab2 = f_371.GetCommandTab(documentType2, text);
			if (!Information.IsNothing(commandTab2))
			{
				commandTab2.Active = false;
			}
		}
		assembly = null;
	}

	public void RemoveCommandMgr()
	{
		try
		{
			f_371.RemoveCommandGroup(999);
			f_371.RemoveFlyoutGroup(1090);
			foreach (Form openForm in Application.OpenForms)
			{
				openForm.Close();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public bool CompareIDs(int[] storedIDs, int[] addinIDs)
	{
		List<int> list = new List<int>(storedIDs);
		List<int> list2 = new List<int>(addinIDs);
		list2.Sort();
		list.Sort();
		if (list2.Count != list.Count)
		{
			return false;
		}
		checked
		{
			int num = list2.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (list2[i] != list[i])
				{
					return false;
				}
			}
			return true;
		}
	}

	public int PMPEnable_0()
	{
		ModelDoc2 modelDoc = (ModelDoc2)SwApp.ActiveDoc;
		if (Information.IsNothing(modelDoc))
		{
			return 0;
		}
		if (modelDoc.GetType() == 3)
		{
			return 0;
		}
		return 1;
	}

	public int PMPEnable_1()
	{
		ModelDoc2 modelDoc = (ModelDoc2)SwApp.ActiveDoc;
		if (Information.IsNothing(modelDoc))
		{
			return 0;
		}
		if (modelDoc.GetType() == 3)
		{
			return 1;
		}
		return 0;
	}

	public int PMPEnable_2()
	{
		ModelDoc2 modelDoc = (ModelDoc2)SwApp.ActiveDoc;
		if (!Information.IsNothing(modelDoc))
		{
			int configurationCount = modelDoc.GetConfigurationCount();
			if (configurationCount <= 1)
			{
				return 0;
			}
			return 1;
		}
		return 0;
	}

	public int PMPEnable_3()
	{
		ModelDoc2 modelDoc = (ModelDoc2)SwApp.ActiveDoc;
		if (Information.IsNothing(modelDoc))
		{
			return 0;
		}
		if (modelDoc.GetType() == 2)
		{
			return 1;
		}
		return 0;
	}

	public void Menu0_0()
	{
		if (Information.IsNothing(f_379))
		{
			f_379 = new ReName();
			f_379.f_318 = SwApp;
			f_379.Show(Type_16.m_60(SwApp.GetProcessID()));
		}
	}

	public void Menu0_1()
	{
		ModelDoc2 modelDoc = (ModelDoc2)SwApp.ActiveDoc;
		if (!Information.IsNothing(modelDoc))
		{
			Type_16.m_67(SwApp, modelDoc);
			modelDoc = null;
		}
	}

	public void Menu0_2()
	{
		SplitConfig splitConfig = new SplitConfig();
		splitConfig.f_365 = SwApp;
		splitConfig.ShowDialog();
	}

	public void Menu0_3()
	{
		try
		{
			string text = "";
			ModelDoc2 modelDoc = (ModelDoc2)SwApp.ActiveDoc;
			SelectionMgr selectionMgr;
			if (modelDoc != null)
			{
				if (modelDoc.GetType() == 2)
				{
					selectionMgr = (SelectionMgr)modelDoc.SelectionManager;
					int selectedObjectCount = selectionMgr.GetSelectedObjectCount2(-1);
					if (selectedObjectCount > 0)
					{
						int num = selectedObjectCount;
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							ModelDoc2 modelDoc2 = null;
							SelectionMgr instance = selectionMgr;
							object[] array = new object[2] { i, -1 };
							bool[] array2 = new bool[2] { true, false };
							object obj = NewLateBinding.LateGet(instance, null, "GetSelectedObjectsComponent4", array, null, null, array2);
							if (array2[0])
							{
								i = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
							}
							Component2 component = (Component2)obj;
							if (!Information.IsNothing(component))
							{
								modelDoc2 = (ModelDoc2)component.GetModelDoc2();
							}
							if (!Information.IsNothing(modelDoc2))
							{
								modelDoc2.Save();
								modelDoc2 = null;
							}
						}
					}
				}
				modelDoc = null;
			}
			selectionMgr = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void Menu0_4()
	{
		f_375.Show();
	}

	public void Menu0_5()
	{
		settings settings2 = new settings();
		settings2.ShowDialog();
	}

	public void Menu0_6()
	{
		f_376.Show();
	}

	public void Menu0_7()
	{
		if (Information.IsNothing(f_378))
		{
			f_378 = new Frm_SN();
			f_378.swapp = SwApp;
			f_378.Show(Type_16.m_60(SwApp.GetProcessID()));
		}
	}

	public void Menu3_0()
	{
	}

	public void Menu3_1()
	{
		try
		{
			string location = Assembly.GetExecutingAssembly().Location;
			location = Path.GetDirectoryName(location);
			string text = Path.Combine(location, "help.CHM");
			if (File.Exists(text))
			{
				Process.Start(text);
			}
			else
			{
				MessageBox.Show("Файл help.chm не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void Menu3_2()
	{
	}

	public void openZtool(int Type)
	{
		if (!EnsurePMP())
		{
			MessageBox.Show("Не удалось подготовить канал связи SWTools с SolidWorks.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		int num = default(int);
		switch (Type)
		{
		case 0:
			num = f_377.sendmessageC(1000, "1000");
			break;
		case 1:
			num = f_377.sendmessageC(1000, "1001");
			break;
		case 2:
			num = f_377.sendmessageC(1000, "1002");
			break;
		case 3:
			num = f_377.sendmessageC(1000, "1003");
			break;
		case 4:
			num = f_377.sendmessageC(1000, "1004");
			break;
		case 5:
			num = f_377.sendmessageC(1000, "1005");
			break;
		case 6:
			num = f_377.sendmessageC(1000, "1006");
			break;
		case 120:
			num = f_377.sendmessageC(1000, "1120");
			break;
		case 130:
			num = f_377.sendmessageC(1000, "1130");
			break;
		}
		if (num != 0)
		{
			return;
		}
		checked
		{
			try
			{
				int processID = SwApp.GetProcessID();
				string expression = SwApp.RevisionNumber();
				expression = Strings.Split(expression, ".")[0];
				if (!Versioned.IsNumeric(expression))
				{
					MessageBox.Show("Ошибка чтения информации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (Conversions.ToInteger(expression) < 20)
				{
					MessageBox.Show("Поддерживается только версия 2012 и выше!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				string location = Assembly.GetExecutingAssembly().Location;
				location = Path.GetDirectoryName(location);
				string[] array = null;
				if (Directory.Exists(location))
				{
					array = Directory.GetFiles(location, "*.exe");
				}
				bool flag = false;
				int i = default(int);
				if (!Information.IsNothing(array))
				{
					int num2 = array.Length - 1;
					for (i = 0; i <= num2; i++)
					{
						string text = Type_15.m_45(array[i]);
						if (text.Equals("ZTool", StringComparison.OrdinalIgnoreCase))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = array[i];
					processStartInfo.Arguments = expression + Strings.Space(1) + Conversions.ToString(processID) + Strings.Space(1) + Conversions.ToString(Type) + Strings.Space(1) + f_377.Handle;
					processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
					using Process process = Process.Start(processStartInfo);
					try
					{
						int num3 = 0;
						while (process.MainWindowHandle == (IntPtr)0 && !process.HasExited)
						{
							Thread.Sleep(500);
							num3 += 500;
							if (num3 > 10000)
							{
								MessageBox.Show("Тайм-аут соединения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								break;
							}
						}
						return;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
						return;
					}
				}
				MessageBox.Show("Основная программа" + Path.Combine(location, "ZTool.exe") + "\nотсутствует, проверьте, не удалён ли антивирусом; добавьте антивирус в белый список и переустановите программу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void FlyoutCallback1()
	{
		FlyoutGroup flyoutGroup = f_371.GetFlyoutGroup(1090);
		flyoutGroup.RemoveAllCommandItems();
		int num = 0;
		checked
		{
			do
			{
				try
				{
					string text = "Customsetting" + Conversions.ToString(num);
					string text2 = Type_16.m_63(text, "title");
					if (Operators.CompareString(text2, "", TextCompare: false) == 0)
					{
						text2 = "Пользовательское меню" + Conversions.ToString(num + 1);
					}
					string text3 = Type_16.m_63(text, "hide");
					if (!Type_16.m_58(text3))
					{
						flyoutGroup.AddCommandItem(text2, "", 0, "runfrompaths(" + Conversions.ToString(num) + ")", "1");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
				num++;
			}
			while (num <= 19);
			flyoutGroup.AddCommandItem("Настройки", "", 1, "Menu2_20", "1");
			flyoutGroup.FlyoutType = 0;
		}
	}

	public void Menu2_20()
	{
		customsettings customsettings2 = new customsettings();
		customsettings2.ShowDialog();
	}

	public void runfrompaths(int index)
	{
		string expression = Type_16.m_63("Customsetting" + Conversions.ToString(index), "pathname");
		if (Strings.Len(expression) == 0)
		{
			MessageBox.Show("Сначала выполните настройку", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		string[] array = Strings.Split(expression, "\r\n");
		checked
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = array[i];
				bool flag = true;
				if (File.Exists(text))
				{
					flag = true;
				}
				else
				{
					if (!Directory.Exists(text))
					{
						MessageBox.Show(text + "не существует!", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						continue;
					}
					flag = false;
				}
				Path.GetFullPath(text);
				try
				{
					if (flag)
					{
						if (text.EndsWith(".swb", StringComparison.OrdinalIgnoreCase) || text.EndsWith(".swp", StringComparison.OrdinalIgnoreCase))
						{
							SwApp.RunMacro2(text, "", "main", 0, out var _);
							continue;
						}
						ProcessStartInfo processStartInfo = new ProcessStartInfo();
						processStartInfo.FileName = text;
						processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
						Process process = Process.Start(processStartInfo);
						try
						{
							int num2 = 0;
							while (process.MainWindowHandle == (IntPtr)0 && !process.HasExited)
							{
								Thread.Sleep(500);
								num2 += 500;
								if (num2 > 10000)
								{
									MessageBox.Show("Тайм-аут соединения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									break;
								}
							}
							process = null;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ProjectData.ClearProjectError();
						}
					}
					else if (!Type_16.m_57(Type_16.m_53(text)))
					{
						MessageBox.Show(Type_16.m_60(SwApp.GetProcessID()), "Папка не существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public void AttachEventHandlers()
	{
		AttachSWEvents();
		AttachEventsToAllDocuments();
	}

	public void DetachEventHandlers()
	{
		DetachSWEvents();
		int count = f_374.Count;
		checked
		{
			if (count > 0)
			{
				object[] array = new object[count - 1 + 1];
				f_374.Keys.CopyTo(array, 0);
				object[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					ModelDoc2 key = (ModelDoc2)array2[i];
					DocumentEventHandler documentEventHandler = (DocumentEventHandler)f_374[key];
					documentEventHandler.DetachEventHandlers();
					documentEventHandler = null;
					key = null;
				}
			}
		}
	}

	public void AttachSWEvents()
	{
		try
		{
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "ActiveDocChangeNotify").AddEventHandler(p_119, new DSldWorksEvents_ActiveDocChangeNotifyEventHandler(SldWorks_ActiveDocChangeNotify));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "DocumentLoadNotify2").AddEventHandler(p_119, new DSldWorksEvents_DocumentLoadNotify2EventHandler(SldWorks_DocumentLoadNotify2));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "FileNewNotify2").AddEventHandler(p_119, new DSldWorksEvents_FileNewNotify2EventHandler(SldWorks_FileNewNotify2));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "ActiveModelDocChangeNotify").AddEventHandler(p_119, new DSldWorksEvents_ActiveModelDocChangeNotifyEventHandler(SldWorks_ActiveModelDocChangeNotify));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "FileOpenPostNotify").AddEventHandler(p_119, new DSldWorksEvents_FileOpenPostNotifyEventHandler(SldWorks_FileOpenPostNotify));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Console.WriteLine(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void DetachSWEvents()
	{
		try
		{
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "ActiveDocChangeNotify").RemoveEventHandler(p_119, new DSldWorksEvents_ActiveDocChangeNotifyEventHandler(SldWorks_ActiveDocChangeNotify));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "DocumentLoadNotify2").RemoveEventHandler(p_119, new DSldWorksEvents_DocumentLoadNotify2EventHandler(SldWorks_DocumentLoadNotify2));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "FileNewNotify2").RemoveEventHandler(p_119, new DSldWorksEvents_FileNewNotify2EventHandler(SldWorks_FileNewNotify2));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "ActiveModelDocChangeNotify").RemoveEventHandler(p_119, new DSldWorksEvents_ActiveModelDocChangeNotifyEventHandler(SldWorks_ActiveModelDocChangeNotify));
			new ComAwareEventInfo(typeof(DSldWorksEvents_Event), "FileOpenPostNotify").RemoveEventHandler(p_119, new DSldWorksEvents_FileOpenPostNotifyEventHandler(SldWorks_FileOpenPostNotify));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Console.WriteLine(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public void AttachEventsToAllDocuments()
	{
		for (ModelDoc2 modelDoc = (ModelDoc2)p_119.GetFirstDocument(); modelDoc != null; modelDoc = (ModelDoc2)modelDoc.GetNext())
		{
			if (!f_374.Contains(modelDoc))
			{
				AttachModelDocEventHandler(modelDoc);
			}
			else
			{
				((DocumentEventHandler)f_374[modelDoc])?.ConnectModelViews();
			}
		}
	}

	public bool AttachModelDocEventHandler(ModelDoc2 modDoc)
	{
		if (modDoc == null)
		{
			return false;
		}
		DocumentEventHandler documentEventHandler = null;
		if (!f_374.Contains(modDoc))
		{
			switch (modDoc.GetType())
			{
			case 1:
				documentEventHandler = new PartEventHandler();
				break;
			case 2:
				documentEventHandler = new AssemblyEventHandler();
				break;
			case 3:
				documentEventHandler = new DrawingEventHandler();
				break;
			}
			documentEventHandler.Init(p_119, this, modDoc);
			documentEventHandler.AttachEventHandlers();
			f_374.Add(modDoc, documentEventHandler);
		}
		bool result = default(bool);
		return result;
	}

	public void DetachModelEventHandler(ModelDoc2 modDoc)
	{
		DocumentEventHandler documentEventHandler = (DocumentEventHandler)f_374[modDoc];
		f_374.Remove(modDoc);
		modDoc = null;
		documentEventHandler = null;
	}

	public int SldWorks_ActiveDocChangeNotify()
	{
		int result = default(int);
		return result;
	}

	public int SldWorks_DocumentLoadNotify2(string docTitle, string docPath)
	{
		int result = default(int);
		return result;
	}

	public int SldWorks_FileNewNotify2(object newDoc, int doctype, string templateName)
	{
		AttachEventsToAllDocuments();
		int result = default(int);
		return result;
	}

	public int SldWorks_ActiveModelDocChangeNotify()
	{
		int result = default(int);
		return result;
	}

	public int SldWorks_FileOpenPostNotify(string FileName)
	{
		AttachEventsToAllDocuments();
		int result = default(int);
		return result;
	}

	public static bool Addin(string key)
	{
		if (string.Compare(key, "t3pcVhk04Ik=") != 0)
		{
			return false;
		}
		Assembly assembly = Assembly.GetAssembly(typeof(SwAddin));
		string fullName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
		string subkey = assembly.GetName().Version.ToString();
		string text = typeof(SwAddin).GUID.ToString();
		bool result = default(bool);
		try
		{
			RegistryKey classesRoot = Registry.ClassesRoot;
			string subkey2 = "CLSID\\{" + text + "}";
			RegistryKey registryKey = classesRoot.CreateSubKey(subkey2);
			registryKey.SetValue("", fullName);
			registryKey.CreateSubKey("Implemented Categories").CreateSubKey("{62C8FE65-4EBB-45E7-B440-6E39B2CDBF29}");
			RegistryKey registryKey2 = registryKey.CreateSubKey("InprocServer32");
			registryKey2.SetValue("", "mscoree.dll");
			registryKey2.SetValue("Assembly", assembly.FullName);
			registryKey2.SetValue("Class", fullName);
			registryKey2.SetValue("CodeBase", assembly.CodeBase.ToString());
			registryKey2.SetValue("RuntimeVersion", assembly.ImageRuntimeVersion);
			registryKey2.SetValue("ThreadingModel", "Both");
			RegistryKey registryKey3 = registryKey2.CreateSubKey(subkey);
			registryKey3.SetValue("", "mscoree.dll");
			registryKey3.SetValue("Assembly", assembly.FullName);
			registryKey3.SetValue("Class", fullName);
			registryKey3.SetValue("CodeBase", assembly.CodeBase.ToString());
			registryKey3.SetValue("RuntimeVersion", assembly.ImageRuntimeVersion);
			registryKey.CreateSubKey("ProgId").SetValue("", fullName);
			RegistryKey localMachine = Registry.LocalMachine;
			registryKey = localMachine.CreateSubKey("Software\\SolidWorks\\AddIns\\{" + text + "}");
			registryKey.SetValue("", "00000001", RegistryValueKind.DWord);
			registryKey.SetValue("Description", "SWTools — вспомогательные инструменты");
			registryKey.SetValue("Title", "SWTools");
			RegistryKey currentUser = Registry.CurrentUser;
			registryKey = currentUser.CreateSubKey("Software\\SolidWorks\\AddInsStartup\\{" + text + "}");
			registryKey.SetValue("", "00000001", RegistryValueKind.DWord);
			registryKey = classesRoot.CreateSubKey(fullName);
			registryKey.SetValue("", fullName);
			registryKey.CreateSubKey("CLSID").SetValue("", "{" + text + "}");
			result = true;
			return result;
		}
		catch (NullReferenceException ex)
		{
			ProjectData.SetProjectError(ex);
			NullReferenceException ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
