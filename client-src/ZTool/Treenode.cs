using System.Diagnostics;
using System.Windows.Forms;

namespace ZTool;

public class Treenode : TreeNode
{
	private bool _IsSuppressed;

	private bool _ExcludeFromBOM;

	private string _ConfigureName;

	private string _PathName;

	private int _DisplayInBOM;

	private string _level_index;

	private string _idstring;

	private string _FeatureName;

	private int _realcount;

	private int _mylevel;

	private string _realpath;

	public bool IsSuppressed
	{
		get
		{
			return _IsSuppressed;
		}
		set
		{
			_IsSuppressed = value;
		}
	}

	public bool ExcludeFromBOM
	{
		get
		{
			return _ExcludeFromBOM;
		}
		set
		{
			_ExcludeFromBOM = value;
		}
	}

	public string ConfigureName
	{
		get
		{
			return _ConfigureName;
		}
		set
		{
			_ConfigureName = value;
		}
	}

	public string PathName
	{
		get
		{
			return _PathName;
		}
		set
		{
			_PathName = value;
		}
	}

	public int DisplayInBOM
	{
		get
		{
			return _DisplayInBOM;
		}
		set
		{
			_DisplayInBOM = value;
		}
	}

	public string level_index
	{
		get
		{
			return _level_index;
		}
		set
		{
			_level_index = value;
		}
	}

	public int mylevel
	{
		get
		{
			return _mylevel;
		}
		set
		{
			_mylevel = value;
		}
	}

	public string IDString
	{
		get
		{
			return _idstring;
		}
		set
		{
			_idstring = value;
		}
	}

	public string FeatureName
	{
		get
		{
			return _FeatureName;
		}
		set
		{
			_FeatureName = value;
		}
	}

	public int realcount
	{
		get
		{
			return _realcount;
		}
		set
		{
			_realcount = value;
		}
	}

	public string realpath
	{
		get
		{
			return _realpath;
		}
		set
		{
			_realpath = value;
		}
	}

	[DebuggerNonUserCode]
	public Treenode()
	{
	}
}
