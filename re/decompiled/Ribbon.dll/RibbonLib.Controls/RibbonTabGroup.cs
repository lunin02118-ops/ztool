using RibbonLib.Controls.Properties;
using RibbonLib.Interop;

namespace RibbonLib.Controls;

public class RibbonTabGroup : BaseRibbonControl, IContextAvailablePropertiesProvider, IKeytipPropertiesProvider, ILabelPropertiesProvider, ITooltipPropertiesProvider
{
	private ContextAvailablePropertiesProvider _contextAvailablePropertiesProvider;

	private KeytipPropertiesProvider _keytipPropertiesProvider;

	private LabelPropertiesProvider _labelPropertiesProvider;

	private TooltipPropertiesProvider _tooltipPropertiesProvider;

	public ContextAvailability ContextAvailable
	{
		get
		{
			return _contextAvailablePropertiesProvider.ContextAvailable;
		}
		set
		{
			_contextAvailablePropertiesProvider.ContextAvailable = value;
		}
	}

	public string Keytip
	{
		get
		{
			return _keytipPropertiesProvider.Keytip;
		}
		set
		{
			_keytipPropertiesProvider.Keytip = value;
		}
	}

	public string Label
	{
		get
		{
			return _labelPropertiesProvider.Label;
		}
		set
		{
			_labelPropertiesProvider.Label = value;
		}
	}

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

	public RibbonTabGroup(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		AddPropertiesProvider(_contextAvailablePropertiesProvider = new ContextAvailablePropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_keytipPropertiesProvider = new KeytipPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_labelPropertiesProvider = new LabelPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_tooltipPropertiesProvider = new TooltipPropertiesProvider(ribbon, commandId));
	}
}
