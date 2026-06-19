using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class KeytipPropertiesProvider : BasePropertiesProvider, IKeytipPropertiesProvider
{
	private string _keytip;

	public string Keytip
	{
		get
		{
			return _keytip;
		}
		set
		{
			_keytip = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.Keytip));
			}
		}
	}

	public KeytipPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.Keytip);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.Keytip && _keytip != null)
		{
			newValue.SetString(_keytip);
		}
		return HRESULT.S_OK;
	}
}
