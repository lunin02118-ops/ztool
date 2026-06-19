using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class StringValuePropertiesProvider : BasePropertiesProvider, IStringValuePropertiesProvider
{
	private string _stringValue;

	public string StringValue
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.StringValue, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string)value.Value;
				}
			}
			return _stringValue;
		}
		set
		{
			_stringValue = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = ((_stringValue != null && !(_stringValue.Trim() == string.Empty)) ? PropVariant.FromObject(_stringValue) : PropVariant.Empty);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.StringValue, ref value2);
			}
		}
	}

	public StringValuePropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.StringValue);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.StringValue && _stringValue != null)
		{
			newValue.SetString(_stringValue);
		}
		return HRESULT.S_OK;
	}
}
