using System;
using System.Drawing;
using RibbonLib.Controls.Events;
using RibbonLib.Controls.Properties;
using RibbonLib.Interop;

namespace RibbonLib.Controls;

public class RibbonDropDownColorPicker : BaseRibbonControl, IColorPickerPropertiesProvider, IEnabledPropertiesProvider, IKeytipPropertiesProvider, ILabelPropertiesProvider, IImagePropertiesProvider, ITooltipPropertiesProvider, IExecuteEventsProvider, IPreviewEventsProvider
{
	private ColorPickerPropertiesProvider _colorPickerPropertiesProvider;

	private EnabledPropertiesProvider _enabledPropertiesProvider;

	private KeytipPropertiesProvider _keytipPropertiesProvider;

	private LabelPropertiesProvider _labelPropertiesProvider;

	private ImagePropertiesProvider _imagePropertiesProvider;

	private TooltipPropertiesProvider _tooltipPropertiesProvider;

	private ExecuteEventsProvider _executeEventsProvider;

	private PreviewEventsProvider _previewEventsProvider;

	public string AutomaticColorLabel
	{
		get
		{
			return _colorPickerPropertiesProvider.AutomaticColorLabel;
		}
		set
		{
			_colorPickerPropertiesProvider.AutomaticColorLabel = value;
		}
	}

	public Color Color
	{
		get
		{
			return _colorPickerPropertiesProvider.Color;
		}
		set
		{
			_colorPickerPropertiesProvider.Color = value;
		}
	}

	public SwatchColorType ColorType
	{
		get
		{
			return _colorPickerPropertiesProvider.ColorType;
		}
		set
		{
			_colorPickerPropertiesProvider.ColorType = value;
		}
	}

	public string MoreColorsLabel
	{
		get
		{
			return _colorPickerPropertiesProvider.MoreColorsLabel;
		}
		set
		{
			_colorPickerPropertiesProvider.MoreColorsLabel = value;
		}
	}

	public string NoColorLabel
	{
		get
		{
			return _colorPickerPropertiesProvider.NoColorLabel;
		}
		set
		{
			_colorPickerPropertiesProvider.NoColorLabel = value;
		}
	}

	public string RecentColorsCategoryLabel
	{
		get
		{
			return _colorPickerPropertiesProvider.RecentColorsCategoryLabel;
		}
		set
		{
			_colorPickerPropertiesProvider.RecentColorsCategoryLabel = value;
		}
	}

	public Color[] StandardColors
	{
		get
		{
			return _colorPickerPropertiesProvider.StandardColors;
		}
		set
		{
			_colorPickerPropertiesProvider.StandardColors = value;
		}
	}

	public string StandardColorsCategoryLabel
	{
		get
		{
			return _colorPickerPropertiesProvider.StandardColorsCategoryLabel;
		}
		set
		{
			_colorPickerPropertiesProvider.StandardColorsCategoryLabel = value;
		}
	}

	public string[] StandardColorsTooltips
	{
		get
		{
			return _colorPickerPropertiesProvider.StandardColorsTooltips;
		}
		set
		{
			_colorPickerPropertiesProvider.StandardColorsTooltips = value;
		}
	}

	public Color[] ThemeColors
	{
		get
		{
			return _colorPickerPropertiesProvider.ThemeColors;
		}
		set
		{
			_colorPickerPropertiesProvider.ThemeColors = value;
		}
	}

	public string ThemeColorsCategoryLabel
	{
		get
		{
			return _colorPickerPropertiesProvider.ThemeColorsCategoryLabel;
		}
		set
		{
			_colorPickerPropertiesProvider.ThemeColorsCategoryLabel = value;
		}
	}

	public string[] ThemeColorsTooltips
	{
		get
		{
			return _colorPickerPropertiesProvider.ThemeColorsTooltips;
		}
		set
		{
			_colorPickerPropertiesProvider.ThemeColorsTooltips = value;
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

	public event EventHandler<ExecuteEventArgs> PreviewEvent
	{
		add
		{
			_previewEventsProvider.PreviewEvent += value;
		}
		remove
		{
			_previewEventsProvider.PreviewEvent -= value;
		}
	}

	public event EventHandler<ExecuteEventArgs> CancelPreviewEvent
	{
		add
		{
			_previewEventsProvider.CancelPreviewEvent += value;
		}
		remove
		{
			_previewEventsProvider.CancelPreviewEvent -= value;
		}
	}

	public RibbonDropDownColorPicker(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		AddPropertiesProvider(_colorPickerPropertiesProvider = new ColorPickerPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_enabledPropertiesProvider = new EnabledPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_keytipPropertiesProvider = new KeytipPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_labelPropertiesProvider = new LabelPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_imagePropertiesProvider = new ImagePropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_tooltipPropertiesProvider = new TooltipPropertiesProvider(ribbon, commandId));
		AddEventsProvider(_executeEventsProvider = new ExecuteEventsProvider(this));
		AddEventsProvider(_previewEventsProvider = new PreviewEventsProvider(this));
	}
}
