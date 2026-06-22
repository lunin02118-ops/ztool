using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;

namespace ZTool;

public class PartEventHandler : DocumentEventHandler
{
	[AccessedThroughProperty("iPart")]
	private PartDoc f_118;

	private PartDoc p_23
	{
		get
		{
			return f_118;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_118 = value;
		}
	}

	public override bool Init(SldWorks sw, SwAddin addin, ModelDoc2 model)
	{
		userAddin = addin;
		p_23 = (PartDoc)model;
		iDocument = (ModelDoc2)p_23;
		iSwApp = sw;
		bool result = default(bool);
		return result;
	}

	public override bool AttachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "DestroyNotify").AddEventHandler(p_23, new DPartDocEvents_DestroyNotifyEventHandler(PartDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "NewSelectionNotify").AddEventHandler(p_23, new DPartDocEvents_NewSelectionNotifyEventHandler(PartDoc_NewSelectionNotify));
		ConnectModelViews();
		bool result = default(bool);
		return result;
	}

	public override bool DetachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "DestroyNotify").RemoveEventHandler(p_23, new DPartDocEvents_DestroyNotifyEventHandler(PartDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "NewSelectionNotify").RemoveEventHandler(p_23, new DPartDocEvents_NewSelectionNotifyEventHandler(PartDoc_NewSelectionNotify));
		DisconnectModelViews();
		userAddin.DetachModelEventHandler(iDocument);
		bool result = default(bool);
		return result;
	}

	public int PartDoc_DestroyNotify()
	{
		DetachEventHandlers();
		int result = default(int);
		return result;
	}

	public int PartDoc_NewSelectionNotify()
	{
		int result = default(int);
		return result;
	}
}
