using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class LabelPropertiesProvider : BasePropertiesProvider, ILabelPropertiesProvider
{
	private string _label;

	public string Label
	{
		get
		{
			return _label;
		}
		set
		{
			_label = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.Label));
			}
		}
	}

	public LabelPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.Label);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.Label && _label != null)
		{
			newValue.SetString(_label);
		}
		return HRESULT.S_OK;
	}
}
