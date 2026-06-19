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
	internal class _202E_200E_202D_200E_206B_202A_206C_206C_206F_202A_200F_200F_202A_206E_200D_206A_200B_200D_206F_200B_202C_206E_206C_206B_206E_206F_200F_206C_200F_206D_206A_200D_200F_206C_200B_206B_200B_202B_200D_202B_202E
	{
		public string _200B_200F_206C_200D_206E_206C_202C_202D_206F_202B_202B_202E_206F_202A_202E_202C_202B_206C_206B_200B_206D_200E_202E_200B_200D_200B_200D_202A_200C_206B_200B_206F_206B_202C_202A_206D_202A_206A_206F_200C_202E;

		public string _206A_206C_202B_206E_202D_200B_206C_206D_202E_206E_200C_202A_206D_200D_206A_206D_206F_202C_206F_200F_200B_200E_206F_206D_206A_206D_206B_200C_206B_200E_200F_200D_200D_200D_200C_206D_206A_202C_200D_202D_202E;

		[SpecialName]
		[CompilerGenerated]
		public bool _200B_202C_200B_206B_200D_202A_200B_200D_206F_200D_200C_206D_202C_202B_206D_200B_206C_200B_206E_202C_200E_202E_206E_200D_202C_206F_202A_200E_202C_206A_200C_200D_206A_202E_202D_202C_200C_200E_202B_206B_202E(string P_0)
		{
			return P_0.Equals(_200B_200F_206C_200D_206E_206C_202C_202D_206F_202B_202B_202E_206F_202A_202E_202C_202B_206C_206B_200B_206D_200E_202E_200B_200D_200B_200D_202A_200C_206B_200B_206F_206B_202C_202A_206D_202A_206A_206F_200C_202E, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _200E_200E_200C_200E_206B_202A_202D_200D_206C_206C_200F_206D_202B_202B_206B_200F_200F_200C_206B_206C_200E_206B_206B_202D_200F_206F_200F_206E_206A_206E_202E_200F_202B_200B_202D_206F_202D_200B_202E_200D_202E(customdoc P_0)
		{
			return P_0._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E.Equals(_200B_200F_206C_200D_206E_206C_202C_202D_206F_202B_202B_202E_206F_202A_202E_202C_202B_206C_206B_200B_206D_200E_202E_200B_200D_200B_200D_202A_200C_206B_200B_206F_206B_202C_202A_206D_202A_206A_206F_200C_202E, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _200C_202D_206E_200E_202D_206F_206F_202C_200D_202B_200D_202A_202C_206F_200B_206A_200E_200B_202A_206A_206E_200B_202C_200B_202C_206A_206C_200B_202E_202B_200F_206F_200F_200C_206C_202E_200D_200E_206C_206B_202E(string P_0)
		{
			return P_0.Equals(_206A_206C_202B_206E_202D_200B_206C_206D_202E_206E_200C_202A_206D_200D_206A_206D_206F_202C_206F_200F_200B_200E_206F_206D_206A_206D_206B_200C_206B_200E_200F_200D_200D_200D_200C_206D_206A_202C_200D_202D_202E, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _202C_206C_202B_200E_206F_202E_200F_202A_200C_202D_202D_206F_206F_206A_206E_200D_206D_200D_200C_206E_202E_200E_202A_202A_206C_200D_206D_206F_206A_202B_200F_206B_200E_206E_200C_206A_202B_200D_200F_206D_202E
	{
		public customdoc _200C_206B_202E_202A_202D_206A_200B_206B_206E_206F_206E_206C_202C_206E_206F_206C_202B_200B_200F_200C_206A_202B_200C_202C_206D_206A_202B_202D_202D_200E_200C_206D_200D_206F_202D_206E_200B_202A_202C_202E_202E;

		[SpecialName]
		[CompilerGenerated]
		public bool _206F_202D_202E_206A_202C_200D_202C_200E_202C_202C_206F_202E_200F_206F_206C_206B_206C_200D_200D_206B_200F_202B_206A_200F_202D_206D_202B_206A_202E_200B_202C_200C_206A_202B_202B_202B_200F_200D_206D_200E_202E(string P_0)
		{
			return P_0.Equals(_200C_206B_202E_202A_202D_206A_200B_206B_206E_206F_206E_206C_202C_206E_206F_206C_202B_200B_200F_200C_206A_202B_200C_202C_206D_206A_202B_202D_202D_200E_200C_206D_200D_206F_202D_206E_200B_202A_202C_202E_202E._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E, StringComparison.OrdinalIgnoreCase);
		}
	}

	private SldWorks _202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E;

	private SwAddin _206A_200E_206A_200D_200B_202B_206D_206B_202C_200D_200B_206D_202B_202B_206B_200F_200D_206A_202C_200E_202E_202B_200D_200F_206D_206A_202E_200D_200B_206A_206D_206D_206D_202D_202D_200F_202D_200E_206C_202B_202E;

	private Page_RepairReference _200B_202B_206F_206C_202B_206D_200D_206E_200F_206D_200C_200B_200E_202B_202B_206C_206C_206A_206F_200E_200F_202A_202E_206A_206F_200C_200B_206E_200B_206C_206F_202A_206B_202B_206B_200F_200D_202E_200C_202C_202E;

	private bool _202A_206E_200D_202C_206E_206D_202C_206D_200F_206F_206A_200E_200F_200C_200B_206E_206F_202D_202A_200F_206C_200E_206D_206D_202C_200E_206D_200E_202E_200C_202C_202D_206B_200F_206B_200B_200B_206C_202E_200C_202E;

	private bool _202D_206C_200C_200D_206D_202D_200F_202A_206E_200E_202D_202D_200B_206E_206D_200D_202E_206C_200D_202C_202D_202C_206F_200B_200C_202C_206E_200B_206D_206A_206E_200D_200C_200B_200C_200D_200D_206E_202C_202E;

	private bool _202C_206E_202D_206B_206D_206E_202E_206B_206A_206C_206C_200B_202E_206D_202A_206E_206A_200E_202B_202B_200C_200C_206C_202E_206B_202C_200C_200D_202A_202C_206A_206B_206A_200F_206B_206C_202D_206A_206F_206A_202E;

	private bool _202B_206E_206B_202C_206C_206E_202D_200C_200D_200D_206B_202E_206D_200D_202B_202B_206B_200D_206F_200E_202E_200D_200C_206B_200F_206E_206A_206F_202B_206D_206F_200D_202E_206A_206F_200D_202E_206B_206D_206D_202E;

	private List<customdoc> _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E;

	private List<string> _200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E;

	public PageHandler_RepairReference()
	{
		_202A_206E_200D_202C_206E_206D_202C_206D_200F_206F_206A_200E_200F_200C_200B_206E_206F_202D_202A_200F_206C_200E_206D_206D_202C_200E_206D_200E_202E_200C_202C_202D_206B_200F_206B_200B_200B_206C_202E_200C_202E = false;
		_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E = new List<customdoc>();
		_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E = new List<string>();
	}

	public int Init(SldWorks sw, SwAddin addin, Page_RepairReference upg)
	{
		_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E = sw;
		_206A_200E_206A_200D_200B_202B_206D_206B_202C_200D_200B_206D_202B_202B_206B_200F_200D_206A_202C_200E_202E_202B_200D_200F_206D_206A_202E_200D_200B_206A_206D_206D_206D_202D_202D_200F_202D_200E_206C_202B_202E = addin;
		_200B_202B_206F_206C_202B_206D_200D_206E_200F_206D_200C_200B_200E_202B_202B_206C_206C_206A_206F_200E_200F_202A_202E_206A_206F_200C_200B_206E_200B_206C_206F_202A_206B_202B_206B_200F_200D_202E_200C_202C_202E = upg;
		int result = default(int);
		return result;
	}

	public void AfterClose()
	{
		int indentSize = Debug.IndentSize;
		if (_202A_206E_200D_202C_206E_206D_202C_206D_200F_206F_206A_200E_200F_200C_200B_206E_206F_202D_202A_200F_206C_200E_206D_206D_202C_200E_206D_200E_202E_200C_202C_202D_206B_200F_206B_200B_200B_206C_202E_200C_202E)
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
		_202A_206E_200D_202C_206E_206D_202C_206D_200F_206F_206A_200E_200F_200C_200B_206E_206F_202D_202A_200F_206C_200E_206D_206D_202C_200E_206D_200E_202E_200C_202C_202D_206B_200F_206B_200B_200B_206C_202E_200C_202E = false;
		switch (reason)
		{
		case 2:
			_202A_206E_200D_202C_206E_206D_202C_206D_200F_206F_206A_200E_200F_200C_200B_206E_206F_202D_202A_200F_206C_200E_206D_206D_202C_200E_206D_200E_202E_200C_202C_202D_206B_200F_206B_200B_200B_206C_202E_200C_202E = false;
			break;
		case 1:
			_202A_206E_200D_202C_206E_206D_202C_206D_200F_206F_206A_200E_200F_200C_200B_206E_206F_202D_202A_200F_206C_200E_206D_206D_202C_200E_206D_200E_202E_200C_202C_202D_206B_200F_206B_200B_200B_206C_202E_200C_202E = true;
			break;
		}
		try
		{
			_202D_206C_200C_200D_206D_202D_200F_202A_206E_200E_202D_202D_200B_206E_206D_200D_202E_206C_200D_202C_202D_202C_206F_200B_200C_202C_206E_200B_206D_206A_206E_200D_200C_200B_200C_200D_200D_206E_202C_202E = _200B_202B_206F_206C_202B_206D_200D_206E_200F_206D_200C_200B_200E_202B_202B_206C_206C_206A_206F_200E_200F_202A_202E_206A_206F_200C_200B_206E_200B_206C_206F_202A_206B_202B_206B_200F_200D_202E_200C_202C_202E._202C_206F_206D_202C_206A_206A_202E_200D_206C_202B_200B_206A_202D_200F_200F_202D_200E_206E_200D_202A_200B_202D_202B_206D_202D_206C_206B_206D_200E_206B_206F_202C_202E_202C_200B_202E_206A_206D_206B_200C_202E.Checked;
			_202C_206E_202D_206B_206D_206E_202E_206B_206A_206C_206C_200B_202E_206D_202A_206E_206A_200E_202B_202B_200C_200C_206C_202E_206B_202C_200C_200D_202A_202C_206A_206B_206A_200F_206B_206C_202D_206A_206F_206A_202E = _200B_202B_206F_206C_202B_206D_200D_206E_200F_206D_200C_200B_200E_202B_202B_206C_206C_206A_206F_200E_200F_202A_202E_206A_206F_200C_200B_206E_200B_206C_206F_202A_206B_202B_206B_200F_200D_202E_200C_202C_202E._202E_200D_200F_206E_202A_202A_200D_206E_200E_200C_200D_206D_206F_206C_202C_202B_206F_200F_200C_200B_206D_202E_202B_200E_200F_206A_202C_200F_202E_206A_202B_202A_206A_206B_206F_202E_206A_206B_202A_206D_202E.Checked;
			_202B_206E_206B_202C_206C_206E_202D_200C_200D_200D_206B_202E_206D_200D_202B_202B_206B_200D_206F_200E_202E_200D_200C_206B_200F_206E_206A_206F_202B_206D_206F_200D_202E_206A_206F_200D_202E_206B_206D_206D_202E = _200B_202B_206F_206C_202B_206D_200D_206E_200F_206D_200C_200B_200E_202B_202B_206C_206C_206A_206F_200E_200F_202A_202E_206A_206F_200C_200B_206E_200B_206C_206F_202A_206B_202B_206B_200F_200D_202E_200C_202C_202E._202E_206F_200E_202D_202D_200E_206F_206C_206B_200D_206F_202A_202D_202C_200F_200B_200B_206A_206C_202B_202A_202D_200F_206C_202D_202C_200E_200E_202A_202B_206F_206B_202D_206F_206E_206C_200E_206F_206E_200E_202E.Checked;
			_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._200D_200B_200E_206D_202B_200D_202E_202B_202C_202C_200E_206A_206B_200C_206B_202A_200E_202C_202A_206B_206C_200E_202D_200D_206D_200B_202D_206E_202C_200C_206B_206E_206E_202C_200B_206D_200B_206D_200D_202E_202E("Repair Reference", "includelightweight", Conversions.ToString(_202D_206C_200C_200D_206D_202D_200F_202A_206E_200E_202D_202D_200B_206E_206D_200D_202E_206C_200D_202C_202D_202C_206F_200B_200C_202C_206E_200B_206D_206A_206E_200D_200C_200B_200C_200D_200D_206E_202C_202E));
			_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._200D_200B_200E_206D_202B_200D_202E_202B_202C_202C_200E_206A_206B_200C_206B_202A_200E_202C_202A_206B_206C_200E_202D_200D_206D_200B_202D_206E_202C_200C_206B_206E_206E_202C_200B_206D_200B_206D_200D_202E_202E("Repair Reference", "includesuppressed", Conversions.ToString(_202C_206E_202D_206B_206D_206E_202E_206B_206A_206C_206C_200B_202E_206D_202A_206E_206A_200E_202B_202B_200C_200C_206C_202E_206B_202C_200C_200D_202A_202C_206A_206B_206A_200F_206B_206C_202D_206A_206F_206A_202E));
			_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._200D_200B_200E_206D_202B_200D_202E_202B_202C_202C_200E_206A_206B_200C_206B_202A_200E_202C_202A_206B_206C_200E_202D_200D_206D_200B_202D_206E_202C_200C_206B_206E_206E_202C_200B_206D_200B_206D_200D_202E_202E("Repair Reference", "includehidden", Conversions.ToString(_202B_206E_206B_202C_206C_206E_202D_200C_200D_200D_206B_202E_206D_200D_202B_202B_206B_200D_206F_200E_202E_200D_200C_206B_200F_206E_206A_206F_202B_206D_206F_200D_202E_206A_206F_200D_202E_206B_206D_206D_202E));
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
		List<_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._206D_202C_206F_200B_202B_206A_200D_202A_200E_206A_206F_200D_202A_200D_206C_206A_206A_202A_206D_200C_200B_206B_202E_202D_206E_202B_202B_206E_200B_202D_202A_200F_206E_200F_206A_202D_202A_200C_202D_200D_202E> list2 = new List<_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._206D_202C_206F_200B_202B_206A_200D_202A_200E_206A_206F_200D_202A_200D_206C_206A_206A_202A_206D_200C_200B_206B_202E_202D_206E_202B_202B_206E_200B_202D_202A_200F_206E_200F_206A_202D_202A_200C_202D_200D_202E>();
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
				ModelDoc2 modelDoc = (ModelDoc2)_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.ActiveDoc;
				object objectValue = RuntimeHelpers.GetObjectValue(_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.GetDocuments());
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
						object objectValue2 = RuntimeHelpers.GetObjectValue(_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.GetDocumentDependencies2(text, Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
						int num2 = Information.UBound((Array)objectValue2);
						for (int j = 0; j <= num2; j += 2)
						{
							string text2 = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue2, new object[1] { j + 1 }, null));
							if (Operators.CompareString(Strings.UCase(Strings.Right(text2, 7)), ".SLDPRT", TextCompare: false) != 0)
							{
								continue;
							}
							bool flag = false;
							ModelDoc2 modelDoc3 = (ModelDoc2)_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.GetOpenDocumentByName(text2);
							if (modelDoc3 == null && File.Exists(text2))
							{
								modelDoc3 = (ModelDoc2)_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.OpenDoc(text2, 1);
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
								_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.CloseDoc(text2);
							}
							if (num3 < 1)
							{
								continue;
							}
							_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._206D_202C_206F_200B_202B_206A_200D_202A_200E_206A_206F_200D_202A_200D_206C_206A_206A_202A_206D_200C_200B_206B_202E_202D_206E_202B_202B_206E_200B_202D_202A_200F_206E_200F_206A_202D_202A_200C_202D_200D_202E item = default(_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._206D_202C_206F_200B_202B_206A_200D_202A_200E_206A_206F_200D_202A_200D_206C_206A_206A_202A_206D_200C_200B_206B_202E_202D_206E_202B_202B_206E_200B_202D_202A_200F_206E_200F_206A_202D_202A_200C_202D_200D_202E);
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
									item._206B_206A_202C_206B_200D_200C_200F_202D_200B_206E_200B_206B_202E_206F_200F_206F_200D_200C_206A_202B_202B_200D_206F_206D_200B_202D_206D_206A_206B_200E_202C_202A_206B_200F_206F_202A_206B_206C_202B_206B_202E = text2;
									item._200F_206C_206B_200B_202B_200C_200F_200F_200D_200B_202C_202A_202D_202E_202A_206E_200F_206C_202B_206B_206E_200B_202C_200C_200E_206D_202D_206A_200C_200C_202E_206A_200E_200B_202E_200E_202D_202C_202B_206A_202E = RuntimeHelpers.GetObjectValue(Status);
									item._206F_206D_202A_202E_206D_202A_206E_206D_202C_200E_206B_202D_206A_202A_200D_202A_202C_202A_202C_202C_200C_202D_202E_202E_206C_200F_200F_206A_202E_202A_202B_202B_206C_206C_202D_200E_206B_200E_202B_200D_202E = true;
									item._206E_206F_206C_202D_206A_206E_200F_200C_202A_200B_202C_202C_202D_202C_202E_206F_202A_206F_200B_202D_202C_200E_206E_206E_206B_206C_200B_202C_200E_200C_202A_200B_206A_200D_200C_206C_202A_202E_206E_202E_202E = Conversions.ToString(NewLateBinding.LateIndexGet(ModelPathName, new object[1] { k }, null));
									item._200F_206C_200D_206E_206D_200C_206A_202E_200F_202A_202B_206D_202B_202C_202A_206E_200E_202A_206D_206A_206E_200E_202D_200D_202C_200C_202D_202B_202D_206E_200B_202C_200E_206F_202E_202D_206D_202A_202A_206B_202E = num3;
									break;
								}
							}
							if (!item._206F_206D_202A_202E_206D_202A_206E_206D_202C_200E_206B_202D_206A_202A_200D_202A_202C_202A_202C_202C_200C_202D_202E_202E_206C_200F_200F_206A_202E_202A_202B_202B_206C_206C_202D_200E_206B_200E_202B_200D_202E)
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
								AssemblyDoc assemblyDoc = (AssemblyDoc)_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.GetOpenDocumentByName(text3);
								if (assemblyDoc == null)
								{
									continue;
								}
								object objectValue3 = RuntimeHelpers.GetObjectValue(assemblyDoc.GetComponents(TopLevelOnly: true));
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
											item._200E_200E_200C_206B_200F_202C_206D_200E_206D_202C_206F_200D_206C_202E_202E_206F_202A_202C_202E_200C_206B_202B_206B_200B_202D_200E_200F_200E_206A_200E_206A_200B_202A_206D_202C_202D_200D_202C_206D_206D_202E = component;
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
						if (!Information.IsNothing(list2[n]._200E_200E_200C_206B_200F_202C_206D_200E_206D_202C_206F_200D_206C_202E_202E_206F_202A_202C_202E_200C_206B_202B_206B_200B_202D_200E_200F_200E_206A_200E_206A_200B_202A_206D_202C_202D_200D_202C_206D_206D_202E))
						{
							list2[n]._200E_200E_200C_206B_200F_202C_206D_200E_206D_202C_206F_200D_206C_202E_202E_206F_202A_202C_202E_200C_206B_202B_206B_200B_202D_200E_200F_200E_206A_200E_206A_200B_202A_206D_202C_202D_200D_202C_206D_206D_202E.SetSuppression2(1);
							flag2 = _202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.ReplaceReferencedDocument(list2[n]._206B_206A_202C_206B_200D_200C_200F_202D_200B_206E_200B_206B_202E_206F_200F_206F_200D_200C_206A_202B_202B_200D_206F_206D_200B_202D_206D_206A_206B_200E_202C_202A_206B_200F_206F_202A_206B_206C_202B_206B_202E, list2[n]._206E_206F_206C_202D_206A_206E_200F_200C_202A_200B_202C_202C_202D_202C_202E_206F_202A_206F_200B_202D_202C_200E_206E_206E_206B_206C_200B_202C_200E_200C_202A_200B_206A_200D_200C_206C_202A_202E_206E_202E_202E, text);
							if (flag2)
							{
								num8++;
							}
							list2[n]._200E_200E_200C_206B_200F_202C_206D_200E_206D_202C_206F_200D_206C_202E_202E_206F_202A_202C_202E_200C_206B_202B_206B_200B_202D_200E_200F_200E_206A_200E_206A_200B_202A_206D_202C_202D_200D_202C_206D_206D_202E.SetSuppression2(3);
						}
						_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E(Conversions.ToString(Operators.ConcatenateObject(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(DateTime.Now.ToString("G") + "\n", "Восстановимые элементы:"), list2[n]._206B_206A_202C_206B_200D_200C_200F_202D_200B_206E_200B_206B_202E_206F_200F_206F_200D_200C_206A_202B_202B_200D_206F_206D_200B_202D_206D_206A_206B_200E_202C_202A_206B_200F_206F_202A_206B_206C_202B_206B_202E), "\n"), "Потерянные внешние ссылки:"), list2[n]._206E_206F_206C_202D_206A_206E_200F_200C_202A_200B_202C_202C_202D_202C_202E_206F_202A_206F_200B_202D_202C_200E_206E_206E_206B_206C_200B_202C_200E_200C_202A_200B_206A_200D_200C_206C_202A_202E_206E_202E_202E), "\n"), "Восстановить как:"), text), "\n"), "Результат:"), Interaction.IIf(flag2, "Успешно!", "Ошибка!"))), _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
						_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E("**************************************************", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
					}
					modelDoc.ForceRebuild3(TopOnly: true);
					_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E("Восстановление успешно" + Conversions.ToString(num8) + " шт., ошибка восстановления" + Conversions.ToString(list2.Count - num8) + "шт.", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
					_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E("**************************************************", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
					Process.Start("NotePad.exe", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
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
				ModelDoc2 modelDoc = (ModelDoc2)_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.ActiveDoc;
				if (Information.IsNothing(modelDoc) || modelDoc.GetType() != 2)
				{
					return;
				}
				if (File.Exists(_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E))
				{
					File.Delete(_202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
				}
				_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.DocumentVisible(Visible: false, 1);
				_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.DocumentVisible(Visible: false, 2);
				_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E.Clear();
				_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E.Clear();
				string pathName = modelDoc.GetPathName();
				object objectValue = RuntimeHelpers.GetObjectValue(((AssemblyDoc)modelDoc).GetComponents(TopLevelOnly: true));
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					int num4 = Information.UBound((Array)objectValue);
					for (int i = 0; i <= num4; i++)
					{
						Component2 component = (Component2)NewLateBinding.LateIndexGet(objectValue, new object[1] { i }, null);
						TraComp(component, component.GetSelectByIDString(), pathName, pathName);
					}
				}
				int num5 = _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E.Count - 1;
				int Errors = default(int);
				int Warnings = default(int);
				for (int j = 0; j <= num5; j++)
				{
					int num6 = _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202B_200C_202B_206C_206B_200D_200C_200F_206F_206C_206F_206D_202A_200E_206C_200D_206A_200D_202E_206D_206F_202E_206F_206B_206C_202C_206D_202B_200E_206D_206A_206E_202D_206E_202E_206B_202E_200E_200B_200D_202E - 1;
					for (int k = 0; k <= num6; k++)
					{
						if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206B_206C_200D_200C_202B_202C_206C_200C_200E_206A_200D_206E_202A_202A_202E_202A_206A_206D_202E_206D_202A_202D_202A_206D_202E_206E_202C_202D_200B_200E_200F_206B_202A_200C_202E_200B_202A_206B_206B_206E_202E, new object[1] { k }, null), 4, TextCompare: false))
						{
							continue;
						}
						try
						{
							for (int l = _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202C_200F_202D_200B_206D_200C_206C_200D_202A_200D_206F_200C_200E_206C_200B_200F_206F_200F_202B_202A_200D_200D_200C_206C_202E_202D_206B_202C_206A_206F_202A_206D_200B_202D_206B_200C_200E_202A_206D_202D_202E.Count - 1; l >= 0; l += -1)
							{
								if (Operators.CompareString(NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202A_206E_202E_200C_206E_202D_200D_200D_200E_202C_200F_200F_202C_206B_200D_202D_206D_206D_206A_206D_206D_206D_200E_200C_200E_202B_206B_206D_200F_200F_202B_206A_200E_206F_206B_206B_200B_200F_206B_202C_202E, new object[1] { k }, null).ToString(), "", TextCompare: false) != 0 && !NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202A_206E_202E_200C_206E_202D_200D_200D_200E_202C_200F_200F_202C_206B_200D_202D_206D_206D_206A_206D_206D_206D_200E_200C_200E_202B_206B_206D_200F_200F_202B_206A_200E_206F_206B_206B_200B_200F_206B_202C_202E, new object[1] { k }, null).ToString().Equals(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202C_200F_202D_200B_206D_200C_206C_200D_202A_200D_206F_200C_200E_206C_200B_200F_206F_200F_202B_202A_200D_200D_200C_206C_202E_202D_206B_202C_206A_206F_202A_206D_200B_202D_206B_200C_200E_202A_206D_202D_202E[l], StringComparison.OrdinalIgnoreCase))
								{
									num3++;
									_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206B_202B_200F_200B_200E_206E_206C_206F_202C_206C_202A_206D_200D_200C_202C_200D_206A_200C_202D_202D_200E_200B_206C_206C_200C_200B_200C_202D_202E_206C_206F_206D_202E_200B_200B_206B_206F_206E_206B_206D_202E = true;
									if (_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206A_206A_206E_200E_206E_202B_206B_206D_206B_200B_202D_202A_200B_206B_200D_206C_206D_206F_206C_200E_202B_200D_200D_206C_206E_206F_206C_202B_206F_202E_200C_206F_202E_206C_202A_202D_202E_202B_202B_200D_202E.GetSaveFlag())
									{
										_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206A_206A_206E_200E_206E_202B_206B_206D_206B_200B_202D_202A_200B_206B_200D_206C_206D_206F_206C_200E_202B_200D_200D_206C_206E_206F_206C_202B_206F_202E_200C_206F_202E_206C_202A_202D_202E_202B_202B_200D_202E.Save3(1, ref Errors, ref Warnings);
									}
									bool flag = false;
									if (_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206A_206A_206E_200E_206E_202B_206B_206D_206B_200B_202D_202A_200B_206B_200D_206C_206D_206F_206C_200E_202B_200D_200D_206C_206E_206F_206C_202B_206F_202E_200C_206F_202E_206C_202A_202D_202E_202B_202B_200D_202E.ForceReleaseLocks() == 1)
									{
										flag = _202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.ReplaceReferencedDocument(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E, NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202A_206E_202E_200C_206E_202D_200D_200D_200E_202C_200F_200F_202C_206B_200D_202D_206D_206D_206A_206D_206D_206D_200E_200C_200E_202B_206B_206D_200F_200F_202B_206A_200E_206F_206B_206B_200B_200F_206B_202C_202E, new object[1] { k }, null).ToString(), _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202C_200F_202D_200B_206D_200C_206C_200D_202A_200D_206F_200C_200E_206C_200B_200F_206F_200F_202B_202A_200D_200D_200C_206C_202E_202D_206B_202C_206A_206F_202A_206D_200B_202D_206B_200C_200E_202A_206D_202D_202E[l]);
										_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206A_206A_206E_200E_206E_202B_206B_206D_206B_200B_202D_202A_200B_206B_200D_206C_206D_206F_206C_200E_202B_200D_200D_206C_206E_206F_206C_202B_206F_202E_200C_206F_202E_206C_202A_202D_202E_202B_202B_200D_202E.ReloadOrReplace(ReadOnly: false, _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E, DiscardChanges: true);
									}
									if (flag && ReferenceInContext(_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E, k, _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]))
									{
										num++;
										_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E(DateTime.Now.ToString("G") + "\nЭлементы для восстановления:" + _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E + "\nПотерянные внешние ссылки:" + NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._200B_202E_202C_200C_200C_200B_200C_202A_202D_202D_202D_202E_206B_206A_200B_206B_202C_206D_200D_202C_200D_206C_206B_200D_202B_200D_202C_206B_202A_202B_202B_206F_200F_202B_206F_206E_200D_206E_206D_206E_202E, new object[1] { k }, null).ToString() + "\nВосстановить как:" + NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202A_206E_202E_200C_206E_202D_200D_200D_200E_202C_200F_200F_202C_206B_200D_202D_206D_206D_206A_206D_206D_206D_200E_200C_200E_202B_206B_206D_200F_200F_202B_206A_200E_206F_206B_206B_200B_200F_206B_202C_202E, new object[1] { k }, null).ToString() + "\nРезультат восстановления: успешно!", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
										_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E("**************************************************", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
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
					if (!_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206B_202B_200F_200B_200E_206E_206C_206F_202C_206C_202A_206D_200D_200C_202C_200D_206A_200C_202D_202D_200E_200B_206C_206C_200C_200B_200C_202D_202E_206C_206F_206D_202E_200B_200B_206B_206F_206E_206B_206D_202E)
					{
						continue;
					}
					int num7 = _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202B_200C_202B_206C_206B_200D_200C_200F_206F_206C_206F_206D_202A_200E_206C_200D_206A_200D_202E_206D_206F_202E_206F_206B_206C_202C_206D_202B_200E_206D_206A_206E_202D_206E_202E_206B_202E_200E_200B_200D_202E - 1;
					for (int m = 0; m <= num7; m++)
					{
						if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206B_206C_200D_200C_202B_202C_206C_200C_200E_206A_200D_206E_202A_202A_202E_202A_206A_206D_202E_206D_202A_202D_202A_206D_202E_206E_202C_202D_200B_200E_200F_206B_202A_200C_202E_200B_202A_206B_206B_206E_202E, new object[1] { m }, null), 4, TextCompare: false) && Operators.CompareString(NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._202A_206E_202E_200C_206E_202D_200D_200D_200E_202C_200F_200F_202C_206B_200D_202D_206D_206D_206A_206D_206D_206D_200E_200C_200E_202B_206B_206D_200F_200F_202B_206A_200E_206F_206B_206B_200B_200F_206B_202C_202E, new object[1] { m }, null).ToString(), "", TextCompare: false) != 0)
						{
							num2++;
							_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E(DateTime.Now.ToString("G") + "\nЭлементы для восстановления:" + _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E + "\nПотерянные внешние ссылки:" + NewLateBinding.LateIndexGet(_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[j]._200B_202E_202C_200C_200C_200B_200C_202A_202D_202D_202D_202E_206B_206A_200B_206B_202C_206D_200D_202C_200D_206C_206B_200D_202B_200D_202C_206B_202A_202B_202B_206F_200F_202B_206F_206E_200D_206E_206D_206E_202E, new object[1] { m }, null).ToString() + "\nРезультат восстановления: ошибка!", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
							_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E("**************************************************", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
						}
					}
				}
				if (num3 > 0)
				{
					modelDoc.ForceRebuild3(TopOnly: true);
					_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E("Восстановление успешно" + Conversions.ToString(num) + " шт., ошибка восстановления" + Conversions.ToString(num2) + "шт.", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
					_202E_200B_206A_206E_206B_206F_202B_200F_206A_206B_206B_206D_200D_200D_202D_206A_206B_202C_200B_206D_202A_200F_206A_200D_202B_202A_202E_200D_202E_202B_206C_202A_202D_200B_202A_200D_200E_202E_200D_200D_202E._202A_202A_206A_206F_206D_202A_206C_206B_206F_200C_206D_200F_202B_206E_200C_206F_202A_206E_206F_206C_206E_206B_206D_202D_206F_200D_202C_202D_200C_202D_200E_200C_206D_200B_206D_202A_206B_200D_206C_202E("**************************************************", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
					Process.Start("NotePad.exe", _202B_202C_206E_206F_206B_202C_200F_202D_202C_206A_202E_200D_206E_200B_200C_202C_206A_206C_206E_202A_206A_206F_206C_202A_200E_206D_202E_200B_206C_202E_200B_206F_202B_202E_200B_206B_200E_206B_200E_206F_202E._202A_200B_202A_206F_202C_200B_200B_202B_202E_206F_206C_200D_206F_200F_200E_202D_200F_200B_202C_202B_200F_202D_200C_206F_206E_200C_202A_206A_206D_206A_202B_202C_206A_206E_200E_200D_200F_200D_202D_206A_202E);
				}
				else
				{
					MessageBox.Show("Нет элементов для восстановления", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				int num8 = _200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E.Count - 1;
				for (int n = 0; n <= num8; n++)
				{
					_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.CloseDoc(_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E[n]);
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
				_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E.Clear();
				_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E.Clear();
				_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.DocumentVisible(Visible: true, 1);
				_202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.DocumentVisible(Visible: true, 2);
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
		if (Information.IsNothing(swcomp) || (swcomp.GetSuppression() == 0 && !_202C_206E_202D_206B_206D_206E_202E_206B_206A_206C_206C_200B_202E_206D_202A_206E_206A_200E_202B_202B_200C_200C_206C_202E_206B_202C_200C_200D_202A_202C_206A_206B_206A_200F_206B_206C_202D_206A_206F_206A_202E) || ((swcomp.GetSuppression() == 1 || swcomp.GetSuppression() == 4) && !_202D_206C_200C_200D_206D_202D_200F_202A_206E_200E_202D_202D_200B_206E_206D_200D_202E_206C_200D_202C_202D_202C_206F_200B_200C_202C_206E_200B_206D_206A_206E_200D_200C_200B_200C_200D_200D_206E_202C_202E) || (swcomp.Visible == 0 && !_202B_206E_206B_202C_206C_206E_202D_200C_200D_200D_206B_202E_206D_200D_202B_202B_206B_200D_206F_200E_202E_200D_200C_206B_200F_206E_206A_206F_202B_206D_206F_200D_202E_206A_206F_200D_202E_206B_206D_206D_202E))
		{
			return;
		}
		string pathName = swcomp.GetPathName();
		string referencedConfiguration = swcomp.ReferencedConfiguration;
		int num;
		if (pathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
		{
			num = 1;
		}
		else if (pathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
		{
			num = 2;
		}
		else
		{
			if (!pathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
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
			modelDoc = _202A_202E_202C_206D_202E_206C_206F_202A_206A_206A_200F_202D_200E_206C_200F_202C_202D_206F_202A_200E_202B_200E_206E_202E_206E_200E_206B_200F_200C_200E_206C_206F_200D_200E_202B_206F_202D_206E_202E.OpenDoc6(pathName, num, 1, referencedConfiguration, ref Errors, ref Warnings);
			if (!_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E.Exists([SpecialName] (string P_0) => P_0.Equals(pathName, StringComparison.OrdinalIgnoreCase)))
			{
				_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E.Add(pathName);
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
			int num4 = _202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E.FindIndex([SpecialName] (customdoc P_0) => P_0._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E.Equals(pathName, StringComparison.OrdinalIgnoreCase));
			if (num4 >= 0)
			{
				if (!_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[num4]._202C_200F_202D_200B_206D_200C_206C_200D_202A_200D_206F_200C_200E_206C_200B_200F_206F_200F_202B_202A_200D_200D_200C_206C_202E_202D_206B_202C_206A_206F_202A_206D_200B_202D_206B_200C_200E_202A_206D_202D_202E.Exists([SpecialName] (string P_0) => P_0.Equals(ParentName, StringComparison.OrdinalIgnoreCase)))
				{
					_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E[num4]._202C_200F_202D_200B_206D_200C_206C_200D_202A_200D_206F_200C_200E_206C_200B_200F_206F_200F_202B_202A_200D_200D_200C_206C_202E_202D_206B_202C_206A_206F_202A_206D_200B_202D_206B_200C_200E_202A_206D_202D_202E.Add(ParentName);
				}
				break;
			}
			int num5 = 0;
			ModelDocExtension extension = modelDoc.Extension;
			if (extension != null)
			{
				num5 = extension.ListExternalFileReferencesCount();
				extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
			}
			if (num5 > 0)
			{
				_202B_206E_206C_202C_202E_200E_206C_200B_200F_200C_202C_200C_206E_202A_202E_200F_202B_206F_202B_206E_200D_200C_206F_202A_200C_202A_206E_202B_200F_202D_206A_206A_200F_206E_206A_206E_206F_206E_202E_202E.Add(new customdoc
				{
					_206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E = pathName,
					_202B_200E_206D_200B_206C_202E_202D_206A_206B_202B_206F_206D_206B_202D_206A_200B_200F_202A_200F_202B_200D_200E_202A_202A_206C_202C_200E_202B_200E_202D_206E_202C_206F_200F_200D_202A_206B_206A_200C_202A_202E = SelectByIDString,
					_206B_206E_202D_206B_206D_206B_200E_200F_202D_200E_200B_206F_206C_200D_200E_206C_202D_202B_202D_202C_206B_200C_206A_206E_200C_206B_202E_202E_206E_206F_202E_200B_202A_200C_200F_206B_206A_206E_206C_202B_202E = swcomp.Name2,
					_206A_206A_206E_200E_206E_202B_206B_206D_206B_200B_202D_202A_200B_206B_200D_206C_206D_206F_206C_200E_202B_200D_200D_206C_206E_206F_206C_202B_206F_202E_200C_206F_202E_206C_202A_202D_202E_202B_202B_200D_202E = modelDoc,
					_202A_200C_200B_200D_206A_202D_202B_200E_206D_200C_202E_200B_206F_206A_206C_206D_202D_206E_206B_206C_206D_200D_202B_200B_202B_200C_206F_206A_200E_200B_206B_202E_202A_206E_202E_202B_202C_206E_200C_202C_202E = swcomp,
					_202C_200F_202D_200B_206D_200C_206C_200D_202A_200D_206F_200C_200E_206C_200B_200F_206F_200F_202B_202A_200D_200D_200C_206C_202E_202D_206B_202C_206A_206F_202A_206D_200B_202D_206B_200C_200E_202A_206D_202D_202E = new List<string>(ParentNames.Split('|')),
					_206B_206C_200D_200C_202B_202C_206C_200C_200E_206A_200D_206E_202A_202A_202E_202A_206A_206D_202E_206D_202A_202D_202A_206D_202E_206E_202C_202D_200B_200E_200F_206B_202A_200C_202E_200B_202A_206B_206B_206E_202E = RuntimeHelpers.GetObjectValue(Status),
					_200B_202E_202C_200C_200C_200B_200C_202A_202D_202D_202D_202E_206B_206A_200B_206B_202C_206D_200D_202C_200D_206C_206B_200D_202B_200D_202C_206B_202A_202B_202B_206F_200F_202B_206F_206E_200D_206E_206D_206E_202E = RuntimeHelpers.GetObjectValue(ModelPathName),
					_202A_206E_202E_200C_206E_202D_200D_200D_200E_202C_200F_200F_202C_206B_200D_202D_206D_206D_206A_206D_206D_206D_200E_200C_200E_202B_206B_206D_200F_200F_202B_206A_200E_206F_206B_206B_200B_200F_206B_202C_202E = RuntimeHelpers.GetObjectValue(ModelPathName),
					_202B_200C_202B_206C_206B_200D_200C_200F_206F_206C_206F_206D_202A_200E_206C_200D_206A_200D_202E_206D_206F_202E_206F_206B_206C_202C_206D_202B_200E_206D_206A_206E_202D_206E_202E_206B_202E_200E_200B_200D_202E = num5
				});
			}
			break;
		}
		case 2:
		{
			object objectValue = RuntimeHelpers.GetObjectValue(((AssemblyDoc)modelDoc).GetComponents(TopLevelOnly: true));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				int num2 = Information.UBound((Array)objectValue);
				for (int num3 = 0; num3 <= num2; num3 = checked(num3 + 1))
				{
					Component2 component = (Component2)NewLateBinding.LateIndexGet(objectValue, new object[1] { num3 }, null);
					TraComp(component, SelectByIDString + "/" + component.GetSelectByIDString(), ParentNames + "|" + pathName, pathName);
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
		ModelDoc2 modelDoc = (ModelDoc2)mdoc._202A_200C_200B_200D_206A_202D_202B_200E_206D_200C_202E_200B_206F_206A_206C_206D_202D_206E_206B_206C_206D_200D_202B_200B_202B_200C_206F_206A_200E_200B_206B_202E_202A_206E_202E_202B_202C_206E_200C_202C_202E.GetModelDoc2();
		if (modelDoc == null)
		{
			int Errors = default(int);
			int Warnings = default(int);
			modelDoc = swapp.OpenDoc6(mdoc._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E, 1, 1, "", ref Errors, ref Warnings);
			if (!_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E.Exists([SpecialName] (string P_0) => P_0.Equals(mdoc._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E, StringComparison.OrdinalIgnoreCase)))
			{
				_200D_206E_206A_200C_200B_206E_202E_206F_200D_202E_200D_202D_202D_206F_202A_202C_206C_202E_206E_202D_202E_202A_206E_206E_206D_200D_202A_206E_206E_206C_206D_200E_206E_206C_202C_200E_206C_206D_202A_202D_202E.Add(mdoc._206F_200E_206E_206D_202D_200E_200C_200E_202E_200D_206A_202D_206F_202D_202B_200F_202D_200D_202B_202A_206F_200D_202E_202E_206F_206E_202A_206B_206C_200B_202B_202A_200D_206B_202A_206A_206B_206B_206B_202C_202E);
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
			mdoc._206B_206C_200D_200C_202B_202C_206C_200C_200E_206A_200D_206E_202A_202A_202E_202A_206A_206D_202E_206D_202A_202D_202A_206D_202E_206E_202C_202D_200B_200E_200F_206B_202A_200C_202E_200B_202A_206B_206B_206E_202E = RuntimeHelpers.GetObjectValue(Status);
			mdoc._202A_206E_202E_200C_206E_202D_200D_200D_200E_202C_200F_200F_202C_206B_200D_202D_206D_206D_206A_206D_206D_206D_200E_200C_200E_202B_206B_206D_200F_200F_202B_206A_200E_206F_206B_206B_200B_200F_206B_202C_202E = RuntimeHelpers.GetObjectValue(ModelPathName);
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(Status, new object[1] { index }, null), 3, TextCompare: false))
			{
				result = true;
			}
		}
		return result;
	}
}
