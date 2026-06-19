using System;
using System.Diagnostics;

namespace ZTool;

[Serializable]
public class box
{
	private string _text;

	private string _path;

	private string _tip;

	private string _mark;

	private string _imagepath;

	private int _useindex;

	public string text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
		}
	}

	public string path
	{
		get
		{
			return _path;
		}
		set
		{
			_path = value;
		}
	}

	public string tip
	{
		get
		{
			return _tip;
		}
		set
		{
			_tip = value;
		}
	}

	public string mark
	{
		get
		{
			return _mark;
		}
		set
		{
			_mark = value;
		}
	}

	public string imagepath
	{
		get
		{
			return _imagepath;
		}
		set
		{
			_imagepath = value;
		}
	}

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
	public box()
	{
	}
}
