using System;
using RibbonLib.Interop;

namespace RibbonLib;

public class UICollectionChangedEventArgs : EventArgs
{
	private CollectionChange _action;

	private uint _oldIndex;

	private object _oldItem;

	private uint _newIndex;

	private object _newItem;

	public CollectionChange Action => _action;

	public uint OldIndex => _oldIndex;

	public object OldItem => _oldItem;

	public uint NewIndex => _newIndex;

	public object NewItem => _newItem;

	public UICollectionChangedEventArgs(CollectionChange action, uint oldIndex, object oldItem, uint newIndex, object newItem)
	{
		_action = action;
		_oldIndex = oldIndex;
		_oldItem = oldItem;
		_newIndex = newIndex;
		_newItem = newItem;
	}
}
