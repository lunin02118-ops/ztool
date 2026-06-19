using System;
using System.Drawing;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class ColorPickerPropertiesProvider : BasePropertiesProvider, IColorPickerPropertiesProvider
{
	private string _automaticColorLabel;

	private Color? _color;

	private SwatchColorType? _colorType;

	private string _moreColorsLabel;

	private string _noColorLabel;

	private string _recentColorsCategoryLabel;

	private Color[] _standardColors;

	private string _standardColorsCategoryLabel;

	private string[] _standardColorsTooltips;

	private Color[] _themeColors;

	private string _themeColorsCategoryLabel;

	private string[] _themeColorsTooltips;

	public string AutomaticColorLabel
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.AutomaticColorLabel, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string)value.Value;
				}
			}
			return _automaticColorLabel;
		}
		set
		{
			_automaticColorLabel = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = ((_automaticColorLabel != null && !(_automaticColorLabel.Trim() == string.Empty)) ? PropVariant.FromObject(_automaticColorLabel) : PropVariant.Empty);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.AutomaticColorLabel, ref value2);
			}
		}
	}

	public Color Color
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.Color, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return ColorTranslator.FromWin32((int)(uint)value.Value);
				}
			}
			return _color.GetValueOrDefault();
		}
		set
		{
			_color = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject((uint)ColorTranslator.ToWin32(value));
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.Color, ref value2);
			}
		}
	}

	public SwatchColorType ColorType
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.ColorType, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (SwatchColorType)value.Value;
				}
			}
			return _colorType.GetValueOrDefault();
		}
		set
		{
			_colorType = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject((uint)value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.ColorType, ref value2);
			}
		}
	}

	public string MoreColorsLabel
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.MoreColorsLabel, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string)value.Value;
				}
			}
			return _moreColorsLabel;
		}
		set
		{
			_moreColorsLabel = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = ((_moreColorsLabel != null && !(_moreColorsLabel.Trim() == string.Empty)) ? PropVariant.FromObject(_moreColorsLabel) : PropVariant.Empty);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.MoreColorsLabel, ref value2);
			}
		}
	}

	public string NoColorLabel
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.NoColorLabel, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string)value.Value;
				}
			}
			return _noColorLabel;
		}
		set
		{
			_noColorLabel = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = ((_noColorLabel != null && !(_noColorLabel.Trim() == string.Empty)) ? PropVariant.FromObject(_noColorLabel) : PropVariant.Empty);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.NoColorLabel, ref value2);
			}
		}
	}

	public string RecentColorsCategoryLabel
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.RecentColorsCategoryLabel, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string)value.Value;
				}
			}
			return _recentColorsCategoryLabel;
		}
		set
		{
			_recentColorsCategoryLabel = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = ((_recentColorsCategoryLabel != null && !(_recentColorsCategoryLabel.Trim() == string.Empty)) ? PropVariant.FromObject(_recentColorsCategoryLabel) : PropVariant.Empty);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.RecentColorsCategoryLabel, ref value2);
			}
		}
	}

	public Color[] StandardColors
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.StandardColors, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					uint[] array = (uint[])value.Value;
					int[] array2 = Array.ConvertAll(array, Convert.ToInt32);
					return Array.ConvertAll(array2, ColorTranslator.FromWin32);
				}
			}
			return _standardColors;
		}
		set
		{
			_standardColors = value;
			if (_ribbon.Initalized)
			{
				int[] array = Array.ConvertAll(_standardColors, ColorTranslator.ToWin32);
				uint[] value2 = Array.ConvertAll(array, Convert.ToUInt32);
				PropVariant value3 = PropVariant.FromObject(value2);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.StandardColors, ref value3);
			}
		}
	}

	public string StandardColorsCategoryLabel
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.StandardColorsCategoryLabel, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string)value.Value;
				}
			}
			return _standardColorsCategoryLabel;
		}
		set
		{
			_standardColorsCategoryLabel = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = ((_standardColorsCategoryLabel != null && !(_standardColorsCategoryLabel.Trim() == string.Empty)) ? PropVariant.FromObject(_standardColorsCategoryLabel) : PropVariant.Empty);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.StandardColorsCategoryLabel, ref value2);
			}
		}
	}

	public string[] StandardColorsTooltips
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.StandardColorsTooltips, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string[])value.Value;
				}
			}
			return _standardColorsTooltips;
		}
		set
		{
			_standardColorsTooltips = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject(value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.StandardColorsTooltips, ref value2);
			}
		}
	}

	public Color[] ThemeColors
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.ThemeColors, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					uint[] array = (uint[])value.Value;
					int[] array2 = Array.ConvertAll(array, Convert.ToInt32);
					return Array.ConvertAll(array2, ColorTranslator.FromWin32);
				}
			}
			return _themeColors;
		}
		set
		{
			_themeColors = value;
			if (_ribbon.Initalized)
			{
				int[] array = Array.ConvertAll(_themeColors, ColorTranslator.ToWin32);
				uint[] value2 = Array.ConvertAll(array, Convert.ToUInt32);
				PropVariant value3 = PropVariant.FromObject(value2);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.ThemeColors, ref value3);
			}
		}
	}

	public string ThemeColorsCategoryLabel
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.ThemeColorsCategoryLabel, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string)value.Value;
				}
			}
			return _themeColorsCategoryLabel;
		}
		set
		{
			_themeColorsCategoryLabel = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = ((_themeColorsCategoryLabel != null && !(_themeColorsCategoryLabel.Trim() == string.Empty)) ? PropVariant.FromObject(_themeColorsCategoryLabel) : PropVariant.Empty);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.ThemeColorsCategoryLabel, ref value2);
			}
		}
	}

	public string[] ThemeColorsTooltips
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.ThemeColorsTooltips, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (string[])value.Value;
				}
			}
			return _themeColorsTooltips;
		}
		set
		{
			_themeColorsTooltips = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject(value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.ThemeColorsTooltips, ref value2);
			}
		}
	}

	public ColorPickerPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.AutomaticColorLabel);
		_supportedProperties.Add(RibbonProperties.Color);
		_supportedProperties.Add(RibbonProperties.ColorType);
		_supportedProperties.Add(RibbonProperties.MoreColorsLabel);
		_supportedProperties.Add(RibbonProperties.NoColorLabel);
		_supportedProperties.Add(RibbonProperties.RecentColorsCategoryLabel);
		_supportedProperties.Add(RibbonProperties.StandardColors);
		_supportedProperties.Add(RibbonProperties.StandardColorsCategoryLabel);
		_supportedProperties.Add(RibbonProperties.StandardColorsTooltips);
		_supportedProperties.Add(RibbonProperties.ThemeColors);
		_supportedProperties.Add(RibbonProperties.ThemeColorsCategoryLabel);
		_supportedProperties.Add(RibbonProperties.ThemeColorsTooltips);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.AutomaticColorLabel)
		{
			if (_automaticColorLabel != null)
			{
				newValue.SetString(_automaticColorLabel);
			}
		}
		else if (key == RibbonProperties.Color)
		{
			if (_color.HasValue)
			{
				newValue.SetUInt((uint)ColorTranslator.ToWin32(_color.Value));
			}
		}
		else if (key == RibbonProperties.ColorType)
		{
			if (_colorType.HasValue)
			{
				newValue.SetUInt((uint)_colorType.Value);
			}
		}
		else if (key == RibbonProperties.MoreColorsLabel)
		{
			if (_moreColorsLabel != null)
			{
				newValue.SetString(_moreColorsLabel);
			}
		}
		else if (key == RibbonProperties.NoColorLabel)
		{
			if (_noColorLabel != null)
			{
				newValue.SetString(_noColorLabel);
			}
		}
		else if (key == RibbonProperties.RecentColorsCategoryLabel)
		{
			if (_recentColorsCategoryLabel != null)
			{
				newValue.SetString(_recentColorsCategoryLabel);
			}
		}
		else if (key == RibbonProperties.StandardColors)
		{
			if (_standardColors != null)
			{
				int[] array = Array.ConvertAll(_standardColors, ColorTranslator.ToWin32);
				uint[] uIntVector = Array.ConvertAll(array, Convert.ToUInt32);
				newValue.SetUIntVector(uIntVector);
			}
		}
		else if (key == RibbonProperties.StandardColorsCategoryLabel)
		{
			if (_standardColorsCategoryLabel != null)
			{
				newValue.SetString(_standardColorsCategoryLabel);
			}
		}
		else if (key == RibbonProperties.StandardColorsTooltips)
		{
			if (_standardColorsTooltips != null)
			{
				newValue.SetStringVector(_standardColorsTooltips);
			}
		}
		else if (key == RibbonProperties.ThemeColors)
		{
			if (_themeColors != null)
			{
				int[] array2 = Array.ConvertAll(_themeColors, ColorTranslator.ToWin32);
				uint[] uIntVector2 = Array.ConvertAll(array2, Convert.ToUInt32);
				newValue.SetUIntVector(uIntVector2);
			}
		}
		else if (key == RibbonProperties.ThemeColorsCategoryLabel)
		{
			if (_themeColorsCategoryLabel != null)
			{
				newValue.SetString(_themeColorsCategoryLabel);
			}
		}
		else if (key == RibbonProperties.ThemeColorsTooltips && _themeColorsTooltips != null)
		{
			newValue.SetStringVector(_themeColorsTooltips);
		}
		return HRESULT.S_OK;
	}
}
