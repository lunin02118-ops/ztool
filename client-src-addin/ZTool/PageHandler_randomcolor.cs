using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;

namespace ZTool;

public class PageHandler_randomcolor : PropertyManagerPage2Handler9
{
	[CompilerGenerated]
	internal class Type_27
	{
		public string f_188;

		public Type_27(Type_27 P_0)
		{
			if (P_0 != null)
			{
				f_188 = P_0.f_188;
			}
		}

		[CompilerGenerated]
		public bool m_106(string P_0)
		{
			return P_0.Equals(f_188, StringComparison.OrdinalIgnoreCase);
		}
	}

	private SldWorks f_183;

	private SwAddin f_184;

	private Page_randomcolor f_185;

	private bool f_186;

	private bool f_187;

	public PageHandler_randomcolor()
	{
		f_186 = false;
	}

	public int Init(SldWorks sw, SwAddin addin, Page_randomcolor upg)
	{
		f_183 = sw;
		f_184 = addin;
		f_185 = upg;
		int result = default(int);
		return result;
	}

	public void AfterClose()
	{
		int indentSize = Debug.IndentSize;
		if (f_186)
		{
			randomcolor();
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
		f_186 = false;
		switch (reason)
		{
		case 2:
			f_186 = false;
			break;
		case 1:
			f_186 = true;
			break;
		}
		try
		{
			f_187 = f_185.f_155.Checked;
			Type_16.m_62("randomcolor", "forpart", Conversions.ToString(f_187));
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

	public void randomcolor()
	{
		try
		{
			List<string> list = new List<string>();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			ModelDoc2 modelDoc = (ModelDoc2)f_183.ActiveDoc;
			if (Information.IsNothing(modelDoc))
			{
				return;
			}
			if (modelDoc.GetType() == 2)
			{
				clearcolor(modelDoc);
				object objectValue = RuntimeHelpers.GetObjectValue(((AssemblyDoc)modelDoc).GetComponents(false));
				int num = Information.UBound((Array)objectValue);
				Type_27 type_ = default(Type_27);
				for (int i = 0; i <= num; i = checked(i + 1))
				{
					type_ = new Type_27(type_);
					Component2 component = (Component2)NewLateBinding.LateIndexGet(objectValue, new object[1] { i }, null);
					if (Information.IsNothing(component))
					{
						continue;
					}
					type_.f_188 = component.GetPathName();
					if (f_187)
					{
						if (list.Exists(type_.m_106))
						{
							continue;
						}
						list.Add(type_.f_188);
						ModelDoc2 modelDoc2 = (ModelDoc2)component.GetModelDoc2();
						if (!Information.IsNothing(modelDoc2))
						{
							clearcolor(modelDoc2);
							if (modelDoc2.GetType() == 1)
							{
								setcolor(modelDoc2);
							}
						}
					}
					else if (!f_187 && type_.f_188.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase))
					{
						if (dictionary.ContainsKey(type_.f_188))
						{
							setcolor(component, RuntimeHelpers.GetObjectValue(dictionary[type_.f_188]));
							continue;
						}
						setcolor(component, null);
						dictionary.Add(type_.f_188, RuntimeHelpers.GetObjectValue(component.MaterialPropertyValues));
					}
				}
			}
			else if (modelDoc.GetType() == 1)
			{
				clearcolor(modelDoc);
				setcolor(modelDoc);
			}
			modelDoc.EditRebuild3();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void setcolor(ModelDoc2 ModelDoc)
	{
		if (ModelDoc != null)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(ModelDoc.MaterialPropertyValues);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && Information.UBound((Array)objectValue) == 8)
			{
				VBMath.Randomize();
				NewLateBinding.LateIndexSet(objectValue, new object[2]
				{
					0,
					VBMath.Rnd()
				}, null);
				NewLateBinding.LateIndexSet(objectValue, new object[2]
				{
					1,
					VBMath.Rnd()
				}, null);
				NewLateBinding.LateIndexSet(objectValue, new object[2]
				{
					2,
					VBMath.Rnd()
				}, null);
				ModelDoc.MaterialPropertyValues = RuntimeHelpers.GetObjectValue(objectValue);
			}
		}
	}

	public void setcolor(Component2 comp, object Ret)
	{
		if (comp == null)
		{
			return;
		}
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(Ret)) || Information.UBound((Array)Ret) != 8)
		{
			Ret = RuntimeHelpers.GetObjectValue(comp.MaterialPropertyValues);
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(Ret)) || Information.UBound((Array)Ret) != 8)
			{
				ModelDoc2 modelDoc = (ModelDoc2)comp.GetModelDoc2();
				if (!Information.IsNothing(modelDoc))
				{
					Ret = RuntimeHelpers.GetObjectValue(modelDoc.MaterialPropertyValues);
				}
			}
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(Ret)) || Information.UBound((Array)Ret) != 8)
			{
				return;
			}
			VBMath.Randomize();
			NewLateBinding.LateIndexSet(Ret, new object[2]
			{
				0,
				VBMath.Rnd()
			}, null);
			NewLateBinding.LateIndexSet(Ret, new object[2]
			{
				1,
				VBMath.Rnd()
			}, null);
			NewLateBinding.LateIndexSet(Ret, new object[2]
			{
				2,
				VBMath.Rnd()
			}, null);
		}
		comp.MaterialPropertyValues = RuntimeHelpers.GetObjectValue(Ret);
	}

	public void clearcolor(ModelDoc2 swModel)
	{
		ModelDocExtension extension = swModel.Extension;
		object objectValue = RuntimeHelpers.GetObjectValue(extension.GetRenderMaterials());
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
		{
			int num = Information.UBound((Array)objectValue);
			for (int i = 0; i <= num; i = checked(i + 1))
			{
				RenderMaterial renderMaterial = (RenderMaterial)NewLateBinding.LateIndexGet(objectValue, new object[1] { i }, null);
				renderMaterial.RemoveAllEntities();
			}
		}
	}
}
