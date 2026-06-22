using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;

namespace ZTool;

public class DocView
{
	[AccessedThroughProperty("iModelView")]
	private ModelView f_124;

	private SwAddin f_125;

	private DocumentEventHandler f_126;

	private ModelView p_26
	{
		get
		{
			return f_124;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_124 = value;
		}
	}

	public bool Init(SwAddin addin, ModelView mView, DocumentEventHandler parent)
	{
		f_125 = addin;
		p_26 = mView;
		f_126 = parent;
		bool result = default(bool);
		return result;
	}

	public bool AttachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DModelViewEvents_Event), "DestroyNotify2").AddEventHandler(p_26, new DModelViewEvents_DestroyNotify2EventHandler(ModelView_DestroyNotify2));
		new ComAwareEventInfo(typeof(DModelViewEvents_Event), "RepaintNotify").AddEventHandler(p_26, new DModelViewEvents_RepaintNotifyEventHandler(ModelView_RepaintNotify));
		bool result = default(bool);
		return result;
	}

	public bool DetachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DModelViewEvents_Event), "DestroyNotify2").RemoveEventHandler(p_26, new DModelViewEvents_DestroyNotify2EventHandler(ModelView_DestroyNotify2));
		new ComAwareEventInfo(typeof(DModelViewEvents_Event), "RepaintNotify").RemoveEventHandler(p_26, new DModelViewEvents_RepaintNotifyEventHandler(ModelView_RepaintNotify));
		f_126.DetachModelViewEventHandler(p_26);
		bool result = default(bool);
		return result;
	}

	public int ModelView_DestroyNotify2(int destroyTYpe)
	{
		DetachEventHandlers();
		int result = default(int);
		return result;
	}

	public int ModelView_RepaintNotify(int repaintTYpe)
	{
		int result = default(int);
		return result;
	}
}
