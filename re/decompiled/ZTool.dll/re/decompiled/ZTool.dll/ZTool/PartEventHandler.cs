using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;

namespace ZTool;

public class PartEventHandler : DocumentEventHandler
{
	[AccessedThroughProperty("iPart")]
	private PartDoc _200B_202D_206D_200C_202A_202D_200D_200E_206C_206C_202A_202C_206E_206C_206F_200C_202A_202C_200B_200D_202C_202A_200E_202A_202D_200B_202D_206D_206C_206C_206F_206E_202A_206F_200F_202B_200D_200C_206F_200F_202E;

	private virtual PartDoc _200E_202A_206B_202B_202D_202B_206B_206C_202A_200E_206E_202A_202D_200B_200B_200D_200F_202D_202A_202B_202C_200F_200C_202C_206F_206A_206D_200D_206A_206A_200B_206F_202A_206B_200B_200C_202B_202C_202E_202C_202E
	{
		get
		{
			return _200B_202D_206D_200C_202A_202D_200D_200E_206C_206C_202A_202C_206E_206C_206F_200C_202A_202C_200B_200D_202C_202A_200E_202A_202D_200B_202D_206D_206C_206C_206F_206E_202A_206F_200F_202B_200D_200C_206F_200F_202E;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_200B_202D_206D_200C_202A_202D_200D_200E_206C_206C_202A_202C_206E_206C_206F_200C_202A_202C_200B_200D_202C_202A_200E_202A_202D_200B_202D_206D_206C_206C_206F_206E_202A_206F_200F_202B_200D_200C_206F_200F_202E = partDoc;
		}
	}

	public override bool Init(SldWorks sw, SwAddin addin, ModelDoc2 model)
	{
		userAddin = addin;
		_200E_202A_206B_202B_202D_202B_206B_206C_202A_200E_206E_202A_202D_200B_200B_200D_200F_202D_202A_202B_202C_200F_200C_202C_206F_206A_206D_200D_206A_206A_200B_206F_202A_206B_200B_200C_202B_202C_202E_202C_202E = (PartDoc)model;
		iDocument = (ModelDoc2)_200E_202A_206B_202B_202D_202B_206B_206C_202A_200E_206E_202A_202D_200B_200B_200D_200F_202D_202A_202B_202C_200F_200C_202C_206F_206A_206D_200D_206A_206A_200B_206F_202A_206B_200B_200C_202B_202C_202E_202C_202E;
		iSwApp = sw;
		bool result = default(bool);
		return result;
	}

	public override bool AttachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "DestroyNotify").AddEventHandler(_200E_202A_206B_202B_202D_202B_206B_206C_202A_200E_206E_202A_202D_200B_200B_200D_200F_202D_202A_202B_202C_200F_200C_202C_206F_206A_206D_200D_206A_206A_200B_206F_202A_206B_200B_200C_202B_202C_202E_202C_202E, new DPartDocEvents_DestroyNotifyEventHandler(PartDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "NewSelectionNotify").AddEventHandler(_200E_202A_206B_202B_202D_202B_206B_206C_202A_200E_206E_202A_202D_200B_200B_200D_200F_202D_202A_202B_202C_200F_200C_202C_206F_206A_206D_200D_206A_206A_200B_206F_202A_206B_200B_200C_202B_202C_202E_202C_202E, new DPartDocEvents_NewSelectionNotifyEventHandler(PartDoc_NewSelectionNotify));
		ConnectModelViews();
		bool result = default(bool);
		return result;
	}

	public override bool DetachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "DestroyNotify").RemoveEventHandler(_200E_202A_206B_202B_202D_202B_206B_206C_202A_200E_206E_202A_202D_200B_200B_200D_200F_202D_202A_202B_202C_200F_200C_202C_206F_206A_206D_200D_206A_206A_200B_206F_202A_206B_200B_200C_202B_202C_202E_202C_202E, new DPartDocEvents_DestroyNotifyEventHandler(PartDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DPartDocEvents_Event), "NewSelectionNotify").RemoveEventHandler(_200E_202A_206B_202B_202D_202B_206B_206C_202A_200E_206E_202A_202D_200B_200B_200D_200F_202D_202A_202B_202C_200F_200C_202C_206F_206A_206D_200D_206A_206A_200B_206F_202A_206B_200B_200C_202B_202C_202E_202C_202E, new DPartDocEvents_NewSelectionNotifyEventHandler(PartDoc_NewSelectionNotify));
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
