using System.Collections;
using SolidWorks.Interop.sldworks;

namespace ZTool;

public class DocumentEventHandler
{
	protected Hashtable openModelViews;

	protected SwAddin userAddin;

	protected ModelDoc2 iDocument;

	protected SldWorks iSwApp;

	public DocumentEventHandler()
	{
		openModelViews = new Hashtable();
	}

	public virtual bool Init(SldWorks sw, SwAddin addin, ModelDoc2 model)
	{
		bool result = default(bool);
		return result;
	}

	public virtual bool AttachEventHandlers()
	{
		bool result = default(bool);
		return result;
	}

	public virtual bool DetachEventHandlers()
	{
		bool result = default(bool);
		return result;
	}

	public bool ConnectModelViews()
	{
		for (ModelView modelView = (ModelView)iDocument.GetFirstModelView(); modelView != null; modelView = (ModelView)modelView.GetNext())
		{
			if (!openModelViews.Contains(modelView))
			{
				DocView docView = new DocView();
				docView.Init(userAddin, modelView, this);
				docView.AttachEventHandlers();
				openModelViews.Add(modelView, docView);
			}
		}
		bool result = default(bool);
		return result;
	}

	public bool DisconnectModelViews()
	{
		int count = openModelViews.Count;
		checked
		{
			object[] array = new object[count - 1 + 1];
			openModelViews.Keys.CopyTo(array, 0);
			object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				ModelView key = (ModelView)array2[i];
				DocView docView = (DocView)openModelViews[key];
				docView.DetachEventHandlers();
				openModelViews.Remove(key);
				docView = null;
				key = null;
			}
			bool result = default(bool);
			return result;
		}
	}

	public void DetachModelViewEventHandler(ModelView mView)
	{
		if (openModelViews.Contains(mView))
		{
			DocView docView = (DocView)openModelViews[mView];
			openModelViews.Remove(mView);
			mView = null;
			docView = null;
		}
	}
}
