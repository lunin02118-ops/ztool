using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;

namespace ZTool;

public class DrawingEventHandler : DocumentEventHandler
{
	[AccessedThroughProperty("iDrawing")]
	private DrawingDoc f_123;

	private DrawingDoc p_25
	{
		get
		{
			return f_123;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			f_123 = value;
		}
	}

	public override bool Init(SldWorks sw, SwAddin addin, ModelDoc2 model)
	{
		userAddin = addin;
		p_25 = (DrawingDoc)model;
		iDocument = (ModelDoc2)p_25;
		iSwApp = sw;
		bool result = default(bool);
		return result;
	}

	public override bool AttachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "DestroyNotify").AddEventHandler(p_25, new DDrawingDocEvents_DestroyNotifyEventHandler(DrawingDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "NewSelectionNotify").AddEventHandler(p_25, new DDrawingDocEvents_NewSelectionNotifyEventHandler(DrawingDoc_NewSelectionNotify));
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "FileSaveNotify").AddEventHandler(p_25, new DDrawingDocEvents_FileSaveNotifyEventHandler(DrawingDoc_FileSaveNotify));
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "FileSaveAsNotify2").AddEventHandler(p_25, new DDrawingDocEvents_FileSaveAsNotify2EventHandler(DrawingDoc_FileSaveAsNotify2));
		ConnectModelViews();
		bool result = default(bool);
		return result;
	}

	public override bool DetachEventHandlers()
	{
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "DestroyNotify").RemoveEventHandler(p_25, new DDrawingDocEvents_DestroyNotifyEventHandler(DrawingDoc_DestroyNotify));
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "NewSelectionNotify").RemoveEventHandler(p_25, new DDrawingDocEvents_NewSelectionNotifyEventHandler(DrawingDoc_NewSelectionNotify));
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "FileSaveNotify").RemoveEventHandler(p_25, new DDrawingDocEvents_FileSaveNotifyEventHandler(DrawingDoc_FileSaveNotify));
		new ComAwareEventInfo(typeof(DDrawingDocEvents_Event), "FileSaveAsNotify2").RemoveEventHandler(p_25, new DDrawingDocEvents_FileSaveAsNotify2EventHandler(DrawingDoc_FileSaveAsNotify2));
		DisconnectModelViews();
		userAddin.DetachModelEventHandler(iDocument);
		bool result = default(bool);
		return result;
	}

	public int DrawingDoc_FileSaveAsNotify2(string filename)
	{
		int result = default(int);
		try
		{
			if (Strings.Len(iDocument.GetPathName().Trim()) == 0 && Type_16.m_58(Type_16.m_63("", "UserControl_SaveDrawing")) && Type_16.m_67(iSwApp, iDocument))
			{
				result = 1;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int DrawingDoc_FileSaveNotify(string filename)
	{
		int result = default(int);
		try
		{
			if (Type_16.m_58(Type_16.m_63("", "UserControl_SaveDrawing")) && Type_16.m_67(iSwApp, iDocument))
			{
				result = 1;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int DrawingDoc_DestroyNotify()
	{
		DetachEventHandlers();
		int result = default(int);
		return result;
	}

	public int DrawingDoc_NewSelectionNotify()
	{
		int result = default(int);
		return result;
	}
}
