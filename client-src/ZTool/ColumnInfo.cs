using System.Diagnostics;

namespace ZTool;

public class ColumnInfo
{
	public int index
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int DisplayIndex
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public int Width
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	public bool Visible
	{
		[DebuggerNonUserCode]
		get;
		[DebuggerNonUserCode]
		set;
	}

	[DebuggerNonUserCode]
	public ColumnInfo()
	{
	}
}
