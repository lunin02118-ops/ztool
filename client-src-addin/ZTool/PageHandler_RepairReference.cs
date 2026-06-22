using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;

namespace ZTool;

public class PageHandler_RepairReference : PropertyManagerPage2Handler9
{
	[CompilerGenerated]
	internal class Type_28
	{
		public string f_198;

		public string f_199;

		[CompilerGenerated]
		public bool m_107(string P_0)
		{
			return P_0.Equals(f_198, StringComparison.OrdinalIgnoreCase);
		}

		[CompilerGenerated]
		public bool m_108(customdoc P_0)
		{
			return P_0.f_81.Equals(f_198, StringComparison.OrdinalIgnoreCase);
		}

		[CompilerGenerated]
		public bool m_109(string P_0)
		{
			return P_0.Equals(f_199, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class Type_29
	{
		public customdoc f_200;

		[CompilerGenerated]
		public bool m_110(string P_0)
		{
			return P_0.Equals(f_200.f_81, StringComparison.OrdinalIgnoreCase);
		}
	}

	private SldWorks f_189;

	private SwAddin f_190;

	private Page_RepairReference f_191;

	private bool f_192;

	private bool f_193;

	private bool f_194;

	private bool f_195;

	private List<customdoc> f_196;

	private List<string> f_197;

	public PageHandler_RepairReference()
	{
		f_192 = false;
		f_196 = new List<customdoc>();
		f_197 = new List<string>();
	}

	public int Init(SldWorks sw, SwAddin addin, Page_RepairReference upg)
	{
		f_189 = sw;
		f_190 = addin;
		f_191 = upg;
		int result = default(int);
		return result;
	}

	public void AfterClose()
	{
		int indentSize = Debug.IndentSize;
		if (f_192)
		{
			Repair2();
		}
	}

	void IPropertyManagerPage2Handler9.AfterClose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in AfterClose
		this.AfterClose();
	}

	public void OnCheckboxCheck(int id, bool status)
	{
	}

	void IPropertyManagerPage2Handler9.OnCheckboxCheck(int id, bool status)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnCheckboxCheck
		this.OnCheckboxCheck(id, status);
	}

	public void OnClose(int reason)
	{
		int indentSize = Debug.IndentSize;
		f_192 = false;
		switch (reason)
		{
		case 2:
			f_192 = false;
			break;
		case 1:
			f_192 = true;
			break;
		}
		try
		{
			f_193 = f_191.f_168.Checked;
			f_194 = f_191.f_169.Checked;
			f_195 = f_191.f_170.Checked;
			Type_16.m_62("Repair Reference", "includelightweight", Conversions.ToString(f_193));
			Type_16.m_62("Repair Reference", "includesuppressed", Conversions.ToString(f_194));
			Type_16.m_62("Repair Reference", "includehidden", Conversions.ToString(f_195));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	void IPropertyManagerPage2Handler9.OnClose(int reason)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnClose
		this.OnClose(reason);
	}

	public void OnComboboxEditChanged(int id, string text)
	{
	}

	void IPropertyManagerPage2Handler9.OnComboboxEditChanged(int id, string text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnComboboxEditChanged
		this.OnComboboxEditChanged(id, text);
	}

	public int OnActiveXControlCreated(int id, bool status)
	{
		return -1;
	}

	int IPropertyManagerPage2Handler9.OnActiveXControlCreated(int id, bool status)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnActiveXControlCreated
		return this.OnActiveXControlCreated(id, status);
	}

	public void OnButtonPress(int id)
	{
	}

	void IPropertyManagerPage2Handler9.OnButtonPress(int id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnButtonPress
		this.OnButtonPress(id);
	}

	public void OnComboboxSelectionChanged(int id, int item)
	{
	}

	void IPropertyManagerPage2Handler9.OnComboboxSelectionChanged(int id, int item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnComboboxSelectionChanged
		this.OnComboboxSelectionChanged(id, item);
	}

	public void OnGroupCheck(int id, bool status)
	{
	}

	void IPropertyManagerPage2Handler9.OnGroupCheck(int id, bool status)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnGroupCheck
		this.OnGroupCheck(id, status);
	}

	public void OnGroupExpand(int id, bool status)
	{
	}

	void IPropertyManagerPage2Handler9.OnGroupExpand(int id, bool status)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnGroupExpand
		this.OnGroupExpand(id, status);
	}

	public bool OnHelp()
	{
		return true;
	}

	bool IPropertyManagerPage2Handler9.OnHelp()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnHelp
		return this.OnHelp();
	}

	public void OnListboxSelectionChanged(int id, int item)
	{
	}

	void IPropertyManagerPage2Handler9.OnListboxSelectionChanged(int id, int item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnListboxSelectionChanged
		this.OnListboxSelectionChanged(id, item);
	}

	public bool OnNextPage()
	{
		return true;
	}

	bool IPropertyManagerPage2Handler9.OnNextPage()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnNextPage
		return this.OnNextPage();
	}

	public void OnNumberboxChanged(int id, double val)
	{
	}

	void IPropertyManagerPage2Handler9.OnNumberboxChanged(int id, double val)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnNumberboxChanged
		this.OnNumberboxChanged(id, val);
	}

	public void OnOptionCheck(int id)
	{
	}

	void IPropertyManagerPage2Handler9.OnOptionCheck(int id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnOptionCheck
		this.OnOptionCheck(id);
	}

	public bool OnPreviousPage()
	{
		return true;
	}

	bool IPropertyManagerPage2Handler9.OnPreviousPage()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnPreviousPage
		return this.OnPreviousPage();
	}

	public void OnSelectionboxCalloutCreated(int id)
	{
	}

	void IPropertyManagerPage2Handler9.OnSelectionboxCalloutCreated(int id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnSelectionboxCalloutCreated
		this.OnSelectionboxCalloutCreated(id);
	}

	public void OnSelectionboxCalloutDestroyed(int id)
	{
	}

	void IPropertyManagerPage2Handler9.OnSelectionboxCalloutDestroyed(int id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnSelectionboxCalloutDestroyed
		this.OnSelectionboxCalloutDestroyed(id);
	}

	public void OnSelectionboxFocusChanged(int Id)
	{
	}

	void IPropertyManagerPage2Handler9.OnSelectionboxFocusChanged(int Id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnSelectionboxFocusChanged
		this.OnSelectionboxFocusChanged(Id);
	}

	public void OnSelectionboxListChanged(int id, int item)
	{
	}

	void IPropertyManagerPage2Handler9.OnSelectionboxListChanged(int id, int item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnSelectionboxListChanged
		this.OnSelectionboxListChanged(id, item);
	}

	public void OnTextboxChanged(int id, string text)
	{
	}

	void IPropertyManagerPage2Handler9.OnTextboxChanged(int id, string text)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnTextboxChanged
		this.OnTextboxChanged(id, text);
	}

	public void AfterActivation()
	{
	}

	void IPropertyManagerPage2Handler9.AfterActivation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in AfterActivation
		this.AfterActivation();
	}

	public bool OnKeystroke(int Wparam, int Message, int Lparam, int Id)
	{
		bool result = default(bool);
		return result;
	}

	bool IPropertyManagerPage2Handler9.OnKeystroke(int Wparam, int Message, int Lparam, int Id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnKeystroke
		return this.OnKeystroke(Wparam, Message, Lparam, Id);
	}

	public void OnPopupMenuItem(int Id)
	{
	}

	void IPropertyManagerPage2Handler9.OnPopupMenuItem(int Id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnPopupMenuItem
		this.OnPopupMenuItem(Id);
	}

	public void OnPopupMenuItemUpdate(int Id, ref int retval)
	{
	}

	void IPropertyManagerPage2Handler9.OnPopupMenuItemUpdate(int Id, ref int retval)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnPopupMenuItemUpdate
		this.OnPopupMenuItemUpdate(Id, ref retval);
	}

	public bool OnPreview()
	{
		return true;
	}

	bool IPropertyManagerPage2Handler9.OnPreview()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnPreview
		return this.OnPreview();
	}

	public void OnSliderPositionChanged(int Id, double Value)
	{
	}

	void IPropertyManagerPage2Handler9.OnSliderPositionChanged(int Id, double Value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnSliderPositionChanged
		this.OnSliderPositionChanged(Id, Value);
	}

	public void OnSliderTrackingCompleted(int Id, double Value)
	{
	}

	void IPropertyManagerPage2Handler9.OnSliderTrackingCompleted(int Id, double Value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnSliderTrackingCompleted
		this.OnSliderTrackingCompleted(Id, Value);
	}

	public bool OnSubmitSelection(int Id, object Selection, int SelType, ref string ItemText)
	{
		return true;
	}

	bool IPropertyManagerPage2Handler9.OnSubmitSelection(int Id, object Selection, int SelType, ref string ItemText)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnSubmitSelection
		return this.OnSubmitSelection(Id, Selection, SelType, ref ItemText);
	}

	public bool OnTabClicked(int Id)
	{
		return true;
	}

	bool IPropertyManagerPage2Handler9.OnTabClicked(int Id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnTabClicked
		return this.OnTabClicked(Id);
	}

	public void OnUndo()
	{
	}

	void IPropertyManagerPage2Handler9.OnUndo()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnUndo
		this.OnUndo();
	}

	public void OnWhatsNew()
	{
	}

	void IPropertyManagerPage2Handler9.OnWhatsNew()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnWhatsNew
		this.OnWhatsNew();
	}

	public int OnWindowFromHandleControlCreated(int Id, bool Status)
	{
		int result = default(int);
		return result;
	}

	int IPropertyManagerPage2Handler9.OnWindowFromHandleControlCreated(int Id, bool Status)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnWindowFromHandleControlCreated
		return this.OnWindowFromHandleControlCreated(Id, Status);
	}

	public void OnGainedFocus(int Id)
	{
	}

	void IPropertyManagerPage2Handler9.OnGainedFocus(int Id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnGainedFocus
		this.OnGainedFocus(Id);
	}

	public void OnListboxRMBUp(int Id, int PosX, int PosY)
	{
	}

	void IPropertyManagerPage2Handler9.OnListboxRMBUp(int Id, int PosX, int PosY)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnListboxRMBUp
		this.OnListboxRMBUp(Id, PosX, PosY);
	}

	public void OnLostFocus(int Id)
	{
	}

	void IPropertyManagerPage2Handler9.OnLostFocus(int Id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnLostFocus
		this.OnLostFocus(Id);
	}

	public void OnRedo()
	{
	}

	void IPropertyManagerPage2Handler9.OnRedo()
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnRedo
		this.OnRedo();
	}

	public void OnNumberBoxTrackingCompleted(int id, double val)
	{
	}

	void IPropertyManagerPage2Handler9.OnNumberBoxTrackingCompleted(int id, double val)
	{
		//ILSpy generated this explicit interface implementation from .override directive in OnNumberBoxTrackingCompleted
		this.OnNumberBoxTrackingCompleted(id, val);
	}

	public void Repair()
	{
		List<string> list = new List<string>();
		List<Type_16.Type_18> list2 = new List<Type_16.Type_18>();
		object ModelPathName = null;
		object ComponentPathName = null;
		object Feature = null;
		object DataType = null;
		object Status = null;
		object RefEntity = null;
		object FeatCom = null;
		string ConfigName = null;
		string text = "";
		checked
		{
			try
			{
				ModelDoc2 modelDoc = (ModelDoc2)f_189.ActiveDoc;
				object objectValue = RuntimeHelpers.GetObjectValue(f_189.GetDocuments());
				int num = Information.UBound((Array)objectValue);
				for (int i = 0; i <= num; i++)
				{
					ModelDoc2 modelDoc2 = (ModelDoc2)NewLateBinding.LateIndexGet(objectValue, new object[1] { i }, null);
					if (modelDoc2 != null)
					{
						string pathName = modelDoc2.GetPathName();
						list.Add(pathName);
					}
				}
				if (modelDoc != null)
				{
					text = modelDoc.GetPathName();
					if (modelDoc.GetType() == 2)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(f_189.GetDocumentDependencies2(text, Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
						int num2 = Information.UBound((Array)objectValue2);
						for (int j = 0; j <= num2; j += 2)
						{
							string text2 = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue2, new object[1] { j + 1 }, null));
							if (Operators.CompareString(Strings.UCase(Strings.Right(text2, 7)), ".SLDPRT", TextCompare: false) != 0)
							{
								continue;
							}
							bool flag = false;
							ModelDoc2 modelDoc3 = (ModelDoc2)f_189.GetOpenDocumentByName(text2);
							if (modelDoc3 == null && File.Exists(text2))
							{
								modelDoc3 = (ModelDoc2)f_189.OpenDoc(text2, 1);
								flag = true;
							}
							if (modelDoc3 == null)
							{
								continue;
							}
							int num3 = 0;
							ModelDocExtension extension = modelDoc3.Extension;
							if (extension != null)
							{
								num3 = extension.ListExternalFileReferencesCount();
								extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
							}
							if (flag)
							{
								f_189.CloseDoc(text2);
							}
							if (num3 < 1)
							{
								continue;
							}
							Type_16.Type_18 item = default(Type_16.Type_18);
							int num4 = num3 - 1;
							for (int k = 0; k <= num4; k++)
							{
								object left = Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Status, new object[1] { k }, null), 4, TextCompare: false);
								Type typeFromHandle = typeof(Strings);
								object[] array = new object[1] { RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(ModelPathName, new object[1] { k }, null)) };
								bool[] array2 = new bool[1] { true };
								object left2 = NewLateBinding.LateGet(null, typeFromHandle, "UCase", array, null, null, array2);
								if (array2[0])
								{
									NewLateBinding.LateIndexSetComplex(ModelPathName, new object[2]
									{
										k,
										RuntimeHelpers.GetObjectValue(array[0])
									}, null, OptimisticSet: true, RValueBase: false);
								}
								if (Conversions.ToBoolean(Operators.AndObject(left, Operators.CompareObjectNotEqual(left2, Strings.UCase(text), TextCompare: false))))
								{
									item.f_68 = text2;
									item.f_69 = RuntimeHelpers.GetObjectValue(Status);
									item.f_70 = true;
									item.f_71 = Conversions.ToString(NewLateBinding.LateIndexGet(ModelPathName, new object[1] { k }, null));
									item.f_72 = num3;
									break;
								}
							}
							if (!item.f_70)
							{
								continue;
							}
							int num5 = list.Count - 1;
							for (int l = 0; l <= num5; l++)
							{
								string text3 = list[l];
								if (Operators.CompareString(Strings.UCase(Strings.Right(text3, 7)), ".SLDASM", TextCompare: false) != 0)
								{
									continue;
								}
								AssemblyDoc assemblyDoc = (AssemblyDoc)f_189.GetOpenDocumentByName(text3);
								if (assemblyDoc == null)
								{
									continue;
								}
								object objectValue3 = RuntimeHelpers.GetObjectValue(assemblyDoc.GetComponents(true));
								if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
								{
									continue;
								}
								int num6 = Information.UBound((Array)objectValue3);
								for (int m = 0; m <= num6; m++)
								{
									Component2 component = (Component2)NewLateBinding.LateIndexGet(objectValue3, new object[1] { m }, null);
									if (component != null)
									{
										string pathName2 = component.GetPathName();
										if (Operators.CompareString(Strings.UCase(pathName2), Strings.UCase(text2), TextCompare: false) == 0)
										{
											item.f_73 = component;
											break;
										}
									}
								}
							}
							list2.Add(item);
						}
					}
				}
				if (list2.Count > 0)
				{
					int num7 = list2.Count - 1;
					int num8 = default(int);
					for (int n = 0; n <= num7; n++)
					{
						bool flag2 = false;
						if (!Information.IsNothing(list2[n].f_73))
						{
							list2[n].f_73.SetSuppression2(1);
							flag2 = f_189.ReplaceReferencedDocument(list2[n].f_68, list2[n].f_71, text);
							if (flag2)
							{
								num8++;
							}
							list2[n].f_73.SetSuppression2(3);
						}
						Type_19.m_79(Conversions.ToString(Operators.ConcatenateObject(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(DateTime.Now.ToString("G") + "\n", "Восстановимые элементы:"), list2[n].f_68), "\n"), "Потерянные внешние ссылки:"), list2[n].f_71), "\n"), "Восстановить как:"), text), "\n"), "Результат:"), Interaction.IIf(flag2, "Успешно!", "Ошибка!"))), Type_16.f_64);
						Type_19.m_79("**************************************************", Type_16.f_64);
					}
					modelDoc.ForceRebuild3(TopOnly: true);
					Type_19.m_79("Восстановление успешно" + Conversions.ToString(num8) + " шт., ошибка восстановления" + Conversions.ToString(list2.Count - num8) + "шт.", Type_16.f_64);
					Type_19.m_79("**************************************************", Type_16.f_64);
					Process.Start("NotePad.exe", Type_16.f_64);
				}
				else
				{
					MessageBox.Show("Нет элементов для восстановления", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				modelDoc = null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Repair2()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		checked
		{
			try
			{
				ModelDoc2 modelDoc = (ModelDoc2)f_189.ActiveDoc;
				if (Information.IsNothing(modelDoc) || modelDoc.GetType() != 2)
				{
					return;
				}
				if (File.Exists(Type_16.f_64))
				{
					File.Delete(Type_16.f_64);
				}
				f_189.DocumentVisible(Visible: false, 1);
				f_189.DocumentVisible(Visible: false, 2);
				f_196.Clear();
				f_197.Clear();
				string pathName = modelDoc.GetPathName();
				object objectValue = RuntimeHelpers.GetObjectValue(((AssemblyDoc)modelDoc).GetComponents(true));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					int num4 = Information.UBound((Array)objectValue);
					for (int i = 0; i <= num4; i++)
					{
						Component2 component = (Component2)NewLateBinding.LateIndexGet(objectValue, new object[1] { i }, null);
						TraComp(component, component.GetSelectByIDString(), pathName, pathName);
					}
				}
				int num5 = f_196.Count - 1;
				int Errors = default(int);
				int Warnings = default(int);
				for (int j = 0; j <= num5; j++)
				{
					int num6 = f_196[j].f_86 - 1;
					for (int k = 0; k <= num6; k++)
					{
						if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(f_196[j].f_83, new object[1] { k }, null), 4, TextCompare: false))
						{
							continue;
						}
						try
						{
							for (int l = f_196[j].f_80.Count - 1; l >= 0; l += -1)
							{
								if (Operators.CompareString(NewLateBinding.LateIndexGet(f_196[j].f_85, new object[1] { k }, null).ToString(), "", TextCompare: false) != 0 && !NewLateBinding.LateIndexGet(f_196[j].f_85, new object[1] { k }, null).ToString().Equals(f_196[j].f_80[l], StringComparison.OrdinalIgnoreCase))
								{
									num3++;
									f_196[j].f_87 = true;
									if (f_196[j].f_77.GetSaveFlag())
									{
										f_196[j].f_77.Save3(1, ref Errors, ref Warnings);
									}
									bool flag = false;
									if (f_196[j].f_77.ForceReleaseLocks() == 1)
									{
										flag = f_189.ReplaceReferencedDocument(f_196[j].f_81, NewLateBinding.LateIndexGet(f_196[j].f_85, new object[1] { k }, null).ToString(), f_196[j].f_80[l]);
										f_196[j].f_77.ReloadOrReplace(ReadOnly: false, f_196[j].f_81, DiscardChanges: true);
									}
									if (flag && ReferenceInContext(f_189, k, f_196[j]))
									{
										num++;
										Type_19.m_79(DateTime.Now.ToString("G") + "\nЭлементы для восстановления:" + f_196[j].f_81 + "\nПотерянные внешние ссылки:" + NewLateBinding.LateIndexGet(f_196[j].f_84, new object[1] { k }, null).ToString() + "\nВосстановить как:" + NewLateBinding.LateIndexGet(f_196[j].f_85, new object[1] { k }, null).ToString() + "\nРезультат восстановления: успешно!", Type_16.f_64);
										Type_19.m_79("**************************************************", Type_16.f_64);
										break;
									}
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
					if (!f_196[j].f_87)
					{
						continue;
					}
					int num7 = f_196[j].f_86 - 1;
					for (int m = 0; m <= num7; m++)
					{
						if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(f_196[j].f_83, new object[1] { m }, null), 4, TextCompare: false) && Operators.CompareString(NewLateBinding.LateIndexGet(f_196[j].f_85, new object[1] { m }, null).ToString(), "", TextCompare: false) != 0)
						{
							num2++;
							Type_19.m_79(DateTime.Now.ToString("G") + "\nЭлементы для восстановления:" + f_196[j].f_81 + "\nПотерянные внешние ссылки:" + NewLateBinding.LateIndexGet(f_196[j].f_84, new object[1] { m }, null).ToString() + "\nРезультат восстановления: ошибка!", Type_16.f_64);
							Type_19.m_79("**************************************************", Type_16.f_64);
						}
					}
				}
				if (num3 > 0)
				{
					modelDoc.ForceRebuild3(TopOnly: true);
					Type_19.m_79("Восстановление успешно" + Conversions.ToString(num) + " шт., ошибка восстановления" + Conversions.ToString(num2) + "шт.", Type_16.f_64);
					Type_19.m_79("**************************************************", Type_16.f_64);
					Process.Start("NotePad.exe", Type_16.f_64);
				}
				else
				{
					MessageBox.Show("Нет элементов для восстановления", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				int num8 = f_197.Count - 1;
				for (int n = 0; n <= num8; n++)
				{
					f_189.CloseDoc(f_197[n]);
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				f_196.Clear();
				f_197.Clear();
				f_189.DocumentVisible(Visible: true, 1);
				f_189.DocumentVisible(Visible: true, 2);
			}
		}
	}

	public void TraComp(Component2 swcomp, string SelectByIDString, string ParentNames, string ParentName)
	{
		object ModelPathName = null;
		object ComponentPathName = null;
		object Feature = null;
		object DataType = null;
		object Status = null;
		object RefEntity = null;
		object FeatCom = null;
		string ConfigName = "";
		if (Information.IsNothing(swcomp) || (swcomp.GetSuppression() == 0 && !f_194) || ((swcomp.GetSuppression() == 1 || swcomp.GetSuppression() == 4) && !f_193) || (swcomp.Visible == 0 && !f_195))
		{
			return;
		}
		string f_198 = swcomp.GetPathName();
		string referencedConfiguration = swcomp.ReferencedConfiguration;
		int num;
		if (f_198.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
		{
			num = 1;
		}
		else if (f_198.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
		{
			num = 2;
		}
		else
		{
			if (!f_198.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				swcomp = null;
				return;
			}
			num = 3;
		}
		ModelDoc2 modelDoc = (ModelDoc2)swcomp.GetModelDoc2();
		if (Information.IsNothing(modelDoc))
		{
			int Errors = default(int);
			int Warnings = default(int);
			modelDoc = f_189.OpenDoc6(f_198, num, 1, referencedConfiguration, ref Errors, ref Warnings);
			if (!f_197.Exists((string P_0) => P_0.Equals(f_198, StringComparison.OrdinalIgnoreCase)))
			{
				f_197.Add(f_198);
			}
		}
		if (modelDoc == null)
		{
			return;
		}
		switch (num)
		{
		case 1:
		{
			int num3 = f_196.FindIndex((customdoc P_0) => P_0.f_81.Equals(f_198, StringComparison.OrdinalIgnoreCase));
			if (num3 >= 0)
			{
				if (!f_196[num3].f_80.Exists((string P_0) => P_0.Equals(ParentName, StringComparison.OrdinalIgnoreCase)))
				{
					f_196[num3].f_80.Add(ParentName);
				}
				break;
			}
			int num4 = 0;
			ModelDocExtension extension = modelDoc.Extension;
			if (extension != null)
			{
				num4 = extension.ListExternalFileReferencesCount();
				extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
			}
			if (num4 > 0)
			{
				f_196.Add(new customdoc
				{
					f_81 = f_198,
					f_79 = SelectByIDString,
					f_82 = swcomp.Name2,
					f_77 = modelDoc,
					f_78 = swcomp,
					f_80 = new List<string>(ParentNames.Split('|')),
					f_83 = RuntimeHelpers.GetObjectValue(Status),
					f_84 = RuntimeHelpers.GetObjectValue(ModelPathName),
					f_85 = RuntimeHelpers.GetObjectValue(ModelPathName),
					f_86 = num4
				});
			}
			break;
		}
		case 2:
		{
			object objectValue = RuntimeHelpers.GetObjectValue(((AssemblyDoc)modelDoc).GetComponents(true));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				int num2 = Information.UBound((Array)objectValue);
				for (int i = 0; i <= num2; i = checked(i + 1))
				{
					Component2 component = (Component2)NewLateBinding.LateIndexGet(objectValue, new object[1] { i }, null);
					TraComp(component, SelectByIDString + "/" + component.GetSelectByIDString(), ParentNames + "|" + f_198, f_198);
				}
			}
			break;
		}
		}
	}

	public bool ReferenceInContext(SldWorks swapp, long index, customdoc mdoc)
	{
		bool result = false;
		object ModelPathName = null;
		object ComponentPathName = null;
		object Feature = null;
		object DataType = null;
		object Status = null;
		object RefEntity = null;
		object FeatCom = null;
		string ConfigName = null;
		ModelDoc2 modelDoc = (ModelDoc2)mdoc.f_78.GetModelDoc2();
		if (modelDoc == null)
		{
			int Errors = default(int);
			int Warnings = default(int);
			modelDoc = swapp.OpenDoc6(mdoc.f_81, 1, 1, "", ref Errors, ref Warnings);
			if (!f_197.Exists((string P_0) => P_0.Equals(mdoc.f_81, StringComparison.OrdinalIgnoreCase)))
			{
				f_197.Add(mdoc.f_81);
			}
		}
		if (modelDoc == null)
		{
			return false;
		}
		ModelDocExtension extension = modelDoc.Extension;
		int num = default(int);
		if (extension != null)
		{
			num = extension.ListExternalFileReferencesCount();
			extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
		}
		if (num > index)
		{
			mdoc.f_83 = RuntimeHelpers.GetObjectValue(Status);
			mdoc.f_85 = RuntimeHelpers.GetObjectValue(ModelPathName);
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(Status, new object[1] { index }, null), 3, TextCompare: false))
			{
				result = true;
			}
		}
		return result;
	}
}
