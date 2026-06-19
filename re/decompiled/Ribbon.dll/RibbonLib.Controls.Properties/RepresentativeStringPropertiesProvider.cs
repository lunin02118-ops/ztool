using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class RepresentativeStringPropertiesProvider : BasePropertiesProvider, IRepresentativeStringPropertiesProvider
{
	private string _representativeString;

	public string RepresentativeString
	{
		get
		{
			return _representativeString;
		}
		set
		{
			_representativeString = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.RepresentativeString));
			}
		}
	}

	public RepresentativeStringPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.RepresentativeString);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.RepresentativeString && _representativeString != null)
		{
			newValue.SetString(_representativeString);
		}
		return HRESULT.S_OK;
	}
}
