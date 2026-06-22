using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.swdocumentmgr;

namespace ZTool;

public class MySWDM
{
	internal SwDMApplication swDocMgr;

	internal string err;

	internal bool isok;

	private StringBuilder Sb_bomdata;

	private List<string> FilePathNameArr;

	private List<string> CfgNameArr;

	private List<string> CountqutysArr;

	private List<string> NLevelArr;

	private StringBuilder Sb_Feature;

	public string GetSWDMLicenseKey()
	{
		return code.FromHexString("534f4c4944574f524b535f323032323a7377646f636d67725f67656e6572616c2d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d32313432342d32373731322d30323333332d34313234332d31373835382d35363037302d31343436382d36323436372d33353831372d33383136342d34313330342d32383339362d31363131382d33353739352d31313636362d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d342c7377646f636d67725f70726576696577732d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d35353336302d35333036302d32353334332d34323736392d35393036392d35323437332d32323437332d35323232352d31323037342d30343038312d33323930392d33303732382d32383538392d33333232352d31313530372d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d332c7377646f636d67725f67656f6d657472792d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d34373334382d32333737342d34333637332d30333730352d31323136302d30323738302d33323435392d33343831382d36333230352d31373333312d34363238352d36333133352d34393836332d30373839392d31313738372d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d322c7377646f636d67725f64696d78706572742d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d32393939362d30383437322d34373532392d35363539312d36323435362d34363233372d31303834332d33313734372d33323536372d32373035332d35393932372d31373039332d30373136372d30353939362d31313436312d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d372c7377646f636d67725f74657373656c6c6174696f6e2d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d31303433362d35363931302d33323536372d33343937362d32303932382d31313835302d36323934342d32343537372d34303231312d34383733382d32343535352d33373033372d33323537302d33313237362d31313331352d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d392c7377646f636d67725f786d6c2d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d34323031362d30353438392d33353237392d32343831392d35323236342d31343233362d31363430302d34383133312d34333538312d33353935332d31313239302d32383031372d32323635332d32323732382d31313838322d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d38");
	}

	public MySWDM()
	{
		Sb_bomdata = new StringBuilder();
		FilePathNameArr = new List<string>();
		CfgNameArr = new List<string>();
		CountqutysArr = new List<string>();
		NLevelArr = new List<string>();
		Sb_Feature = new StringBuilder();
		isok = true;
		try
		{
			object classFactory = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("SwDocumentMgr.SwDMClassFactory"));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(classFactory)))
			{
				try
				{
					object app = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(classFactory, null, "GetApplication", new object[1] { GetSWDMLicenseKey() }, null, null, null));
					swDocMgr = app as SwDMApplication;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
					err = ex2.Message;
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			logopathlist.WriteLog($"Тип исключения: {ex4.GetType().Name}\r\nСообщение: {ex4.Message}\r\nИнформация: {ex4.StackTrace}");
			err = ex4.Message;
			ProjectData.ClearProjectError();
		}
	}

	internal List<string> GetPropertyNames1()
	{
		string pname = "";
		List<string> list = new List<string>();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Файлы SOLIDWORKS (*.SLDPRT;*.SLDASM)|*.SLDPRT;*.SLDASM|Деталь SOLIDWORKS (*.SLDPRT)|*.SLDPRT|Сборка SOLIDWORKS (*.SLDASM)|*.SLDASM";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return list;
		}
		string[] fileNames = openFileDialog.FileNames;
		int num2 = default(int);
		foreach (string text in fileNames)
		{
			int num;
			if (Strings.InStr(Strings.LCase(text), "sldprt") > 0)
			{
				num = 1;
			}
			else
			{
				if (Strings.InStr(Strings.LCase(text), "sldasm") <= 0)
				{
					if (Strings.InStr(Strings.LCase(text), "slddrw") > 0)
					{
						num = 3;
					}
					else
					{
						num = 0;
					}
					continue;
				}
				num = 2;
			}
			bool gotFromOriginalSwDmPath = false;
			try
			{
				SwDMApplication swDMApplication = swDocMgr;
				int docType = num;
				SwDmDocumentOpenError result = (SwDmDocumentOpenError)num2;
				SwDMDocument document = swDMApplication.GetDocument(text, (SwDmDocumentType)docType, allowReadOnly: true, out result);
				num2 = (int)result;
				SwDMDocument swDMDocument = document;
				if (!Information.IsNothing(swDMDocument))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(swDMDocument.GetCustomPropertyNames());
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
					{
						foreach (object item in (IEnumerable)objectValue)
						{
							object objectValue2 = RuntimeHelpers.GetObjectValue(item);
							pname = Conversions.ToString(objectValue2);
							bool exists = false;
							foreach (string item2 in list)
							{
								if (item2.Equals(pname, StringComparison.OrdinalIgnoreCase))
								{
									exists = true;
									break;
								}
							}
							if (!exists)
							{
								list.Add(pname);
								gotFromOriginalSwDmPath = true;
							}
						}
						SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
						object objectValue3 = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
						foreach (object item3 in (IEnumerable)objectValue3)
						{
							object objectValue4 = RuntimeHelpers.GetObjectValue(item3);
							SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)configurationManager.GetConfigurationByName(Conversions.ToString(objectValue4));
							if (Information.IsNothing(swDMConfiguration))
							{
								continue;
							}
							objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetCustomPropertyNames());
							if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
							{
								continue;
							}
							foreach (object item4 in (IEnumerable)objectValue)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(item4);
								pname = Conversions.ToString(objectValue2);
								bool exists = false;
								foreach (string item5 in list)
								{
									if (item5.Equals(pname, StringComparison.OrdinalIgnoreCase))
									{
										exists = true;
										break;
									}
								}
								if (!exists)
								{
									list.Add(pname);
									gotFromOriginalSwDmPath = true;
								}
							}
						}
					}
					swDMDocument.CloseDoc();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if (gotFromOriginalSwDmPath)
			{
				continue;
			}
			try
			{
				if (!code.RunSW(HideWindow: false, startnew: false))
				{
					continue;
				}
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
				object objectValue5 = null;
				try
				{
					objectValue5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetOpenDocumentByName", new object[1] { text }, null, null, null));
				}
				catch
				{
					objectValue5 = null;
				}
				if (objectValue5 == null)
				{
					try
					{
						objectValue5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetOpenDocument", new object[1] { text }, null, null, null));
					}
					catch
					{
						objectValue5 = null;
					}
				}
				bool openedByFallback = false;
				if (objectValue5 == null)
				{
					NewLateBinding.LateCall(code.swApp, null, "SetCurrentWorkingDirectory", new object[1] { Path.GetDirectoryName(text) }, null, null, null, IgnoreReturn: true);
					int num3 = 0;
					int num4 = 0;
					object[] array = new object[6];
					array[0] = text;
					array[1] = num;
					array[2] = 1;
					array[3] = "";
					array[4] = num3;
					array[5] = num4;
					bool[] array2 = new bool[6];
					array2[0] = false;
					array2[1] = false;
					array2[2] = false;
					array2[3] = false;
					array2[4] = true;
					array2[5] = true;
					objectValue5 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "OpenDoc6", array, null, null, array2));
					openedByFallback = objectValue5 != null;
				}
				if (objectValue5 == null)
				{
					continue;
				}
				object objectValue6 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue5, null, "Extension", new object[0], null, null, null));
				ArrayList arrayList = new ArrayList();
				arrayList.Add("");
				object objectValue7 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue5, null, "GetConfigurationNames", new object[0], null, null, null));
				IEnumerable enumerable = objectValue7 as IEnumerable;
				if (enumerable != null)
				{
					foreach (object item6 in enumerable)
					{
						string text2 = Conversions.ToString(item6);
						if (Operators.CompareString(text2, "", TextCompare: false) != 0)
						{
							arrayList.Add(text2);
						}
					}
				}
				foreach (object item7 in arrayList)
				{
					string text3 = Conversions.ToString(item7);
					object objectValue8 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue6, null, "CustomPropertyManager", new object[1] { text3 }, null, null, null));
					if (objectValue8 == null)
					{
						continue;
					}
					object objectValue9 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue8, null, "GetNames", new object[0], null, null, null));
					IEnumerable enumerable2 = objectValue9 as IEnumerable;
					if (enumerable2 == null)
					{
						continue;
					}
					foreach (object item8 in enumerable2)
					{
						pname = Conversions.ToString(item8);
						bool exists = false;
						foreach (string item9 in list)
						{
							if (item9.Equals(pname, StringComparison.OrdinalIgnoreCase))
							{
								exists = true;
								break;
							}
						}
						if (!exists && Operators.CompareString(pname, "", TextCompare: false) != 0)
						{
							list.Add(pname);
						}
					}
				}
				if (openedByFallback)
				{
					string text4 = Conversions.ToString(NewLateBinding.LateGet(objectValue5, null, "GetTitle", new object[0], null, null, null));
					NewLateBinding.LateCall(code.swApp, null, "CloseDoc", new object[1] { text4 }, null, null, null, IgnoreReturn: true);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show(ex4.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				ProjectData.ClearProjectError();
			}
			finally
			{
				try
				{
					NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
				}
				catch
				{
				}
			}
		}
		return list;
	}
}
