using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.swdocumentmgr;

namespace ZTool;

public class MySWDM
{
	private SwDMClassFactory swClassFact;

	internal SwDMApplication swDocMgr;

	internal string err;

	internal bool isok;

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
