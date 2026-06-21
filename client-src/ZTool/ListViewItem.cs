using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ZTool;

[Serializable]
public class ListViewItem : System.Windows.Forms.ListViewItem
{
	private int _useindex;

	public int useindex
	{
		get
		{
			return _useindex;
		}
		set
		{
			_useindex = value;
		}
	}

	[DebuggerNonUserCode]
	public ListViewItem()
	{
	}
}
