using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class TooltipPropertiesProvider : BasePropertiesProvider, ITooltipPropertiesProvider
{
	private string _tooltipTitle;

	private string _tooltipDescription;

	public string TooltipTitle
	{
		get
		{
			return _tooltipTitle;
		}
		set
		{
			_tooltipTitle = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.TooltipTitle));
			}
		}
	}

	public string TooltipDescription
	{
		get
		{
			return _tooltipDescription;
		}
		set
		{
			_tooltipDescription = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.TooltipDescription));
			}
		}
	}

	public TooltipPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.TooltipTitle);
		_supportedProperties.Add(RibbonProperties.TooltipDescription);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.TooltipTitle)
		{
			if (_tooltipTitle != null)
			{
				newValue.SetString(_tooltipTitle);
			}
		}
		else if (key == RibbonProperties.TooltipDescription && _tooltipDescription != null)
		{
			newValue.SetString(_tooltipDescription);
		}
		return HRESULT.S_OK;
	}
}
