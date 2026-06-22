using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace ZTool;

public class AssemblyEventHandler : DocumentEventHandler
{
	private SelectionMgr f_119;

	[AccessedThroughProperty("iAssembly")]
	private AssemblyDoc f_120;

	private SwAddin f_121;

	private bool f_122;

	private AssemblyDoc p_24
	{
		get
		{
			return f_120;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_120 = value;
		}
	}

	public AssemblyEventHandler()
	{
		f_122 = false;
	}

	public override bool Init(SldWorks sw, SwAddin addin, ModelDoc2 model)
	{
		userAddin = addin;
		p_24 = (AssemblyDoc)model;
		iDocument = (ModelDoc2)p_24;
		iSwApp = sw;
		f_121 = addin;
		bool result = default(bool);
		return result;
	}

	public override bool AttachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "DestroyNotify").AddEventHandler(p_24, new DAssemblyDocEvents_DestroyNotifyEventHandler(AssemblyDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "NewSelectionNotify").AddEventHandler(p_24, new DAssemblyDocEvents_NewSelectionNotifyEventHandler(AssemblyDoc_NewSelectionNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentStateChangeNotify").AddEventHandler(p_24, new DAssemblyDocEvents_ComponentStateChangeNotifyEventHandler(AssemblyDoc_ComponentStateChangeNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentStateChangeNotify2").AddEventHandler(p_24, new DAssemblyDocEvents_ComponentStateChangeNotify2EventHandler(AssemblyDoc_ComponentStateChangeNotify2));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentVisualPropertiesChangeNotify").AddEventHandler(p_24, new DAssemblyDocEvents_ComponentVisualPropertiesChangeNotifyEventHandler(AssemblyDoc_ComponentVisiblePropertiesChangeNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentDisplayStateChangeNotify").AddEventHandler(p_24, new DAssemblyDocEvents_ComponentDisplayStateChangeNotifyEventHandler(AssemblyDoc_ComponentDisplayStateChangeNotify));
		ConnectModelViews();
		bool result = default(bool);
		return result;
	}

	public override bool DetachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "DestroyNotify").RemoveEventHandler(p_24, new DAssemblyDocEvents_DestroyNotifyEventHandler(AssemblyDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "NewSelectionNotify").RemoveEventHandler(p_24, new DAssemblyDocEvents_NewSelectionNotifyEventHandler(AssemblyDoc_NewSelectionNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentStateChangeNotify").RemoveEventHandler(p_24, new DAssemblyDocEvents_ComponentStateChangeNotifyEventHandler(AssemblyDoc_ComponentStateChangeNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentStateChangeNotify2").RemoveEventHandler(p_24, new DAssemblyDocEvents_ComponentStateChangeNotify2EventHandler(AssemblyDoc_ComponentStateChangeNotify2));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentVisualPropertiesChangeNotify").RemoveEventHandler(p_24, new DAssemblyDocEvents_ComponentVisualPropertiesChangeNotifyEventHandler(AssemblyDoc_ComponentVisiblePropertiesChangeNotify));
		new ComAwareEventInfo(typeof(DAssemblyDocEvents_Event), "ComponentDisplayStateChangeNotify").RemoveEventHandler(p_24, new DAssemblyDocEvents_ComponentDisplayStateChangeNotifyEventHandler(AssemblyDoc_ComponentDisplayStateChangeNotify));
		DisconnectModelViews();
		userAddin.DetachModelEventHandler(iDocument);
		bool result = default(bool);
		return result;
	}

	public int AssemblyDoc_DestroyNotify()
	{
		DetachEventHandlers();
		int result = default(int);
		return result;
	}

	public int AssemblyDoc_NewSelectionNotify()
	{
		if (f_122)
		{
			return 0;
		}
		f_122 = true;
		if (!Information.IsNothing(SwAddin.f_378))
		{
			f_119 = (SelectionMgr)NewLateBinding.LateGet(p_24, null, "SelectionManager", new object[0], null, null, null);
			Type_16.f_59 = (ModelDoc2)p_24;
			Type_16.f_60 = (Component2)NewLateBinding.LateGet(f_119, null, "GetSelectedObjectsComponent4", new object[2] { 1, -1 }, null, null, null);
			SwAddin.f_378.RefreshUI();
		}
		f_122 = false;
		int result = default(int);
		return result;
	}

	protected int ComponentStateChange(object componentModel, short newCompState = 3)
	{
		ModelDoc2 modelDoc = (ModelDoc2)componentModel;
		switch ((swComponentSuppressionState_e)newCompState)
		{
		case swComponentSuppressionState_e.swComponentFullyResolved:
		case swComponentSuppressionState_e.swComponentResolved:
			if (modelDoc != null && !f_121.OpenDocumentsTable.Contains(modelDoc))
			{
				f_121.AttachModelDocEventHandler(modelDoc);
			}
			break;
		}
		int result = default(int);
		return result;
	}

	public int AssemblyDoc_ComponentStateChangeNotify(object componentModel, short oldCompState, short newCompState)
	{
		return ComponentStateChange(RuntimeHelpers.GetObjectValue(componentModel), newCompState);
	}

	public int AssemblyDoc_ComponentStateChangeNotify2(object componentModel, string CompName, short oldCompState, short newCompState)
	{
		return ComponentStateChange(RuntimeHelpers.GetObjectValue(componentModel), newCompState);
	}

	public int AssemblyDoc_ComponentVisiblePropertiesChangeNotify(object swObject)
	{
		Component2 component = (Component2)swObject;
		ModelDoc2 componentModel = (ModelDoc2)component.GetModelDoc();
		return ComponentStateChange(componentModel, 3);
	}

	public int AssemblyDoc_ComponentDisplayStateChangeNotify(object swObject)
	{
		Component2 component = (Component2)swObject;
		ModelDoc2 componentModel = (ModelDoc2)component.GetModelDoc();
		return ComponentStateChange(componentModel, 3);
	}
}
