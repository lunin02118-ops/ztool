using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class BooleanValuePropertyProvider : BasePropertiesProvider, IBooleanValuePropertyProvider
{
	private bool? _booleanValue;

	public bool BooleanValue
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.BooleanValue, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (bool)value.Value;
				}
			}
			return _booleanValue == true;
		}
		set
		{
			_booleanValue = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject(value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.BooleanValue, ref value2);
			}
		}
	}

	public BooleanValuePropertyProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.BooleanValue);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.BooleanValue && _booleanValue.HasValue)
		{
			newValue.SetBool(_booleanValue.Value);
		}
		return HRESULT.S_OK;
	}
}
