using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class EnabledPropertiesProvider : BasePropertiesProvider, IEnabledPropertiesProvider
{
	private bool? _enabled;

	public bool Enabled
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.Enabled, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (bool)value.Value;
				}
			}
			return _enabled == true;
		}
		set
		{
			_enabled = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject(value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.Enabled, ref value2);
			}
		}
	}

	public EnabledPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.Enabled);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.Enabled && _enabled.HasValue)
		{
			newValue.SetBool(_enabled.Value);
		}
		return HRESULT.S_OK;
	}
}
