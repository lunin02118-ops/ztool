using RibbonLib.Interop;

namespace RibbonLib;

public class GalleryCommandPropertySet : IUISimplePropertySet
{
	private uint? _commandID;

	private CommandType? _commandType;

	private uint? _categoryID;

	public uint CommandID
	{
		get
		{
			return _commandID.GetValueOrDefault();
		}
		set
		{
			_commandID = value;
		}
	}

	public CommandType CommandType
	{
		get
		{
			return _commandType.GetValueOrDefault();
		}
		set
		{
			_commandType = value;
		}
	}

	public uint CategoryID
	{
		get
		{
			return (uint)(((int?)_categoryID) ?? (-1));
		}
		set
		{
			_categoryID = value;
		}
	}

	public HRESULT GetValue(ref PropertyKey key, out PropVariant value)
	{
		if (key == RibbonProperties.CommandID)
		{
			if (_commandID.HasValue)
			{
				value = PropVariant.FromObject(_commandID.Value);
			}
			else
			{
				value = PropVariant.Empty;
			}
			return HRESULT.S_OK;
		}
		if (key == RibbonProperties.CommandType)
		{
			if (_commandType.HasValue)
			{
				value = PropVariant.FromObject((uint)_commandType.Value);
			}
			else
			{
				value = PropVariant.Empty;
			}
			return HRESULT.S_OK;
		}
		if (key == RibbonProperties.CategoryID)
		{
			if (_categoryID.HasValue)
			{
				value = PropVariant.FromObject(_categoryID.Value);
			}
			else
			{
				value = PropVariant.Empty;
			}
			return HRESULT.S_OK;
		}
		value = PropVariant.Empty;
		return HRESULT.E_NOTIMPL;
	}
}
