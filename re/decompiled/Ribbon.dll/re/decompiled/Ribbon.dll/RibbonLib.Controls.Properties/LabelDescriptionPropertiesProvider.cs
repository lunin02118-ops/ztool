using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class LabelDescriptionPropertiesProvider : BasePropertiesProvider, ILabelDescriptionPropertiesProvider
{
	private string _labelDescription;

	public string LabelDescription
	{
		get
		{
			return _labelDescription;
		}
		set
		{
			_labelDescription = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.LabelDescription));
			}
		}
	}

	public LabelDescriptionPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.LabelDescription);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.LabelDescription && _labelDescription != null)
		{
			newValue.SetString(_labelDescription);
		}
		return HRESULT.S_OK;
	}
}
