using System;
using System.Runtime.InteropServices.ComTypes;
using RibbonLib.Interop;

namespace RibbonLib;

public class UICollectionChangedEvent : IUICollectionChangedEvent
{
	private IUICollection _collection;

	private int _cookie;

	public event EventHandler<UICollectionChangedEventArgs> ChangedEvent;

	public void Attach(IUICollection collection)
	{
		if (_collection != null)
		{
			Detach();
		}
		_collection = collection;
		_cookie = RegisterComEvent(_collection);
	}

	public void Detach()
	{
		if (_collection != null)
		{
			UnregisterComEvent(_collection, _cookie);
			_collection = null;
			_cookie = 0;
		}
	}

	private IConnectionPoint GetConnectionPoint(IUICollection collection)
	{
		IConnectionPointContainer connectionPointContainer = (IConnectionPointContainer)collection;
		Guid riid = new Guid("6502AE91-A14D-44b5-BBD0-62AACC581D52");
		connectionPointContainer.FindConnectionPoint(ref riid, out var ppCP);
		return ppCP;
	}

	private int RegisterComEvent(IUICollection collection)
	{
		IConnectionPoint connectionPoint = GetConnectionPoint(collection);
		connectionPoint.Advise(this, out var pdwCookie);
		return pdwCookie;
	}

	private void UnregisterComEvent(IUICollection collection, int cookie)
	{
		IConnectionPoint connectionPoint = GetConnectionPoint(collection);
		connectionPoint.Unadvise(cookie);
	}

	HRESULT IUICollectionChangedEvent.OnChanged(CollectionChange action, uint oldIndex, object oldItem, uint newIndex, object newItem)
	{
		if (this.ChangedEvent != null)
		{
			this.ChangedEvent(_collection, new UICollectionChangedEventArgs(action, oldIndex, oldItem, newIndex, newItem));
		}
		return HRESULT.S_OK;
	}
}
