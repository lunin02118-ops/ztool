using System;
using RibbonLib.Controls.Events;
using RibbonLib.Controls.Properties;
using RibbonLib.Interop;

namespace RibbonLib.Controls;

public class RibbonSpinner : BaseRibbonControl, ISpinnerPropertiesProvider, IRepresentativeStringPropertiesProvider, IEnabledPropertiesProvider, IKeytipPropertiesProvider, ILabelPropertiesProvider, IImagePropertiesProvider, ITooltipPropertiesProvider, IExecuteEventsProvider
{
	private SpinnerPropertiesProvider _spinnerPropertiesProvider;

	private RepresentativeStringPropertiesProvider _representativeStringPropertiesProvider;

	private EnabledPropertiesProvider _enabledPropertiesProvider;

	private KeytipPropertiesProvider _keytipPropertiesProvider;

	private LabelPropertiesProvider _labelPropertiesProvider;

	private ImagePropertiesProvider _imagePropertiesProvider;

	private TooltipPropertiesProvider _tooltipPropertiesProvider;

	private ExecuteEventsProvider _executeEventsProvider;

	public decimal DecimalValue
	{
		get
		{
			return _spinnerPropertiesProvider.DecimalValue;
		}
		set
		{
			_spinnerPropertiesProvider.DecimalValue = value;
		}
	}

	public decimal Increment
	{
		get
		{
			return _spinnerPropertiesProvider.Increment;
		}
		set
		{
			_spinnerPropertiesProvider.Increment = value;
		}
	}

	public decimal MaxValue
	{
		get
		{
			return _spinnerPropertiesProvider.MaxValue;
		}
		set
		{
			_spinnerPropertiesProvider.MaxValue = value;
		}
	}

	public decimal MinValue
	{
		get
		{
			return _spinnerPropertiesProvider.MinValue;
		}
		set
		{
			_spinnerPropertiesProvider.MinValue = value;
		}
	}

	public uint DecimalPlaces
	{
		get
		{
			return _spinnerPropertiesProvider.DecimalPlaces;
		}
		set
		{
			_spinnerPropertiesProvider.DecimalPlaces = value;
		}
	}

	public string FormatString
	{
		get
		{
			return _spinnerPropertiesProvider.FormatString;
		}
		set
		{
			_spinnerPropertiesProvider.FormatString = value;
		}
	}

	public string RepresentativeString
	{
		get
		{
			return _representativeStringPropertiesProvider.RepresentativeString;
		}
		set
		{
			_representativeStringPropertiesProvider.RepresentativeString = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return _enabledPropertiesProvider.Enabled;
		}
		set
		{
			_enabledPropertiesProvider.Enabled = value;
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

	public IUIImage LargeImage
	{
		get
		{
			return _imagePropertiesProvider.LargeImage;
		}
		set
		{
			_imagePropertiesProvider.LargeImage = value;
		}
	}

	public IUIImage SmallImage
	{
		get
		{
			return _imagePropertiesProvider.SmallImage;
		}
		set
		{
			_imagePropertiesProvider.SmallImage = value;
		}
	}

	public IUIImage LargeHighContrastImage
	{
		get
		{
			return _imagePropertiesProvider.LargeHighContrastImage;
		}
		set
		{
			_imagePropertiesProvider.LargeHighContrastImage = value;
		}
	}

	public IUIImage SmallHighContrastImage
	{
		get
		{
			return _imagePropertiesProvider.SmallHighContrastImage;
		}
		set
		{
			_imagePropertiesProvider.SmallHighContrastImage = value;
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

	public event EventHandler<ExecuteEventArgs> ExecuteEvent
	{
		add
		{
			_executeEventsProvider.ExecuteEvent += value;
		}
		remove
		{
			_executeEventsProvider.ExecuteEvent -= value;
		}
	}

	public RibbonSpinner(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		AddPropertiesProvider(_spinnerPropertiesProvider = new SpinnerPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_representativeStringPropertiesProvider = new RepresentativeStringPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_enabledPropertiesProvider = new EnabledPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_keytipPropertiesProvider = new KeytipPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_labelPropertiesProvider = new LabelPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_imagePropertiesProvider = new ImagePropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_tooltipPropertiesProvider = new TooltipPropertiesProvider(ribbon, commandId));
		AddEventsProvider(_executeEventsProvider = new ExecuteEventsProvider(this));
	}
}
