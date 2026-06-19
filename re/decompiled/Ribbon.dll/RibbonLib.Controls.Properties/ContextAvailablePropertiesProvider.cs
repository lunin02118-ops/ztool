using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class ContextAvailablePropertiesProvider : BasePropertiesProvider, IContextAvailablePropertiesProvider
{
	private ContextAvailability? _contextAvailable;

	public ContextAvailability ContextAvailable
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.ContextAvailable, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (ContextAvailability)(uint)value.Value;
				}
			}
			return _contextAvailable.GetValueOrDefault();
		}
		set
		{
			_contextAvailable = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject((uint)value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.ContextAvailable, ref value2);
			}
		}
	}

	public ContextAvailablePropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.ContextAvailable);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.ContextAvailable && _contextAvailable.HasValue)
		{
			newValue.SetUInt((uint)_contextAvailable.Value);
		}
		return HRESULT.S_OK;
	}
}
