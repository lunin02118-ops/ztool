using RibbonLib.Controls.Properties;

namespace RibbonLib.Controls;

public class RibbonApplicationMenu : BaseRibbonControl, ITooltipPropertiesProvider
{
	private TooltipPropertiesProvider _tooltipPropertiesProvider;

	public string TooltipTitle
	{
		get
		{
			return _tooltipPropertiesProvider.TooltipTitle;
		}
		set
		{
			_tooltipPropertiesProvider.TooltipTitle = value;
		}
	}

	public string TooltipDescription
	{
		get
		{
			return _tooltipPropertiesProvider.TooltipDescription;
		}
		set
		{
			_tooltipPropertiesProvider.TooltipDescription = value;
		}
	}

	public RibbonApplicationMenu(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		AddPropertiesProvider(_tooltipPropertiesProvider = new TooltipPropertiesProvider(ribbon, commandId));
	}
}
