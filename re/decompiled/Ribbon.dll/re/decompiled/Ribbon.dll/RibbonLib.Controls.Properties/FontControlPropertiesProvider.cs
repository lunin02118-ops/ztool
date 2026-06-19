using System;
using System.Drawing;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class FontControlPropertiesProvider : BasePropertiesProvider, IFontControlPropertiesProvider
{
	private string _family;

	private decimal? _size;

	private FontProperties? _bold;

	private FontProperties? _italic;

	private FontUnderline? _underline;

	private FontProperties? _strikethrough;

	private Color? _foregroundColor;

	private SwatchColorType? _foregroundColorType;

	private Color? _backgroundColor;

	private SwatchColorType? _backgroundColorType;

	private FontVerticalPosition? _verticalPositioning;

	private IPropertyStore FontProperties
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.FontProperties, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (IPropertyStore)value.Value;
				}
			}
			return null;
		}
	}

	public string Family
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_Family, out var pv);
				return (string)pv.Value;
			}
			return _family;
		}
		set
		{
			_family = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public decimal Size
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_Size, out var pv);
				return (decimal)pv.Value;
			}
			return _size.GetValueOrDefault();
		}
		set
		{
			_size = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public FontProperties Bold
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_Bold, out var pv);
				return (FontProperties)(uint)pv.Value;
			}
			return _bold ?? RibbonLib.Interop.FontProperties.NotAvailable;
		}
		set
		{
			_bold = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public FontProperties Italic
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_Italic, out var pv);
				return (FontProperties)(uint)pv.Value;
			}
			return _italic ?? RibbonLib.Interop.FontProperties.NotAvailable;
		}
		set
		{
			_italic = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public FontUnderline Underline
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_Underline, out var pv);
				return (FontUnderline)(uint)pv.Value;
			}
			return _underline ?? FontUnderline.NotAvailable;
		}
		set
		{
			_underline = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public FontProperties Strikethrough
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_Strikethrough, out var pv);
				return (FontProperties)(uint)pv.Value;
			}
			return _strikethrough ?? RibbonLib.Interop.FontProperties.NotAvailable;
		}
		set
		{
			_strikethrough = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public Color ForegroundColor
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_ForegroundColorType, out var pv);
				switch ((SwatchColorType)(uint)pv.Value)
				{
				case SwatchColorType.RGB:
				{
					fontProperties.GetValue(ref RibbonProperties.FontProperties_ForegroundColor, out var pv2);
					return ColorTranslator.FromWin32((int)(uint)pv2.Value);
				}
				case SwatchColorType.Automatic:
					return SystemColors.WindowText;
				case SwatchColorType.NoColor:
					throw new NotSupportedException("NoColor is not a valid value for ForegroundColor property in FontControl.");
				default:
					return SystemColors.WindowText;
				}
			}
			return _foregroundColor.GetValueOrDefault(SystemColors.WindowText);
		}
		set
		{
			_foregroundColor = value;
			_foregroundColorType = SwatchColorType.RGB;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public Color BackgroundColor
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_BackgroundColorType, out var pv);
				switch ((SwatchColorType)(uint)pv.Value)
				{
				case SwatchColorType.RGB:
				{
					fontProperties.GetValue(ref RibbonProperties.FontProperties_BackgroundColor, out var pv2);
					return ColorTranslator.FromWin32((int)(uint)pv2.Value);
				}
				case SwatchColorType.Automatic:
					throw new NotSupportedException("Automatic is not a valid value for BackgroundColor property in FontControl.");
				case SwatchColorType.NoColor:
					return SystemColors.Window;
				default:
					return SystemColors.Window;
				}
			}
			return _backgroundColor.GetValueOrDefault(SystemColors.Window);
		}
		set
		{
			_backgroundColor = value;
			_backgroundColorType = SwatchColorType.RGB;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public FontVerticalPosition VerticalPositioning
	{
		get
		{
			if (_ribbon.Initalized)
			{
				IPropertyStore fontProperties = FontProperties;
				fontProperties.GetValue(ref RibbonProperties.FontProperties_VerticalPositioning, out var pv);
				return (FontVerticalPosition)(uint)pv.Value;
			}
			return _verticalPositioning ?? FontVerticalPosition.NotAvailable;
		}
		set
		{
			_verticalPositioning = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.AllProperties);
			}
		}
	}

	public FontControlPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.FontProperties);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.FontProperties && currentValue != null)
		{
			IPropertyStore propertyStore = (IPropertyStore)currentValue.PropVariant.Value;
			if (_family == null || _family.Trim() == string.Empty)
			{
				PropVariant pv = PropVariant.Empty;
				propertyStore.SetValue(ref RibbonProperties.FontProperties_Family, ref pv);
			}
			else
			{
				PropVariant pv2 = PropVariant.FromObject(_family);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_Family, ref pv2);
			}
			if (_size.HasValue)
			{
				PropVariant pv3 = PropVariant.FromObject(_size.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_Size, ref pv3);
			}
			if (_bold.HasValue)
			{
				PropVariant pv4 = PropVariant.FromObject((uint)_bold.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_Bold, ref pv4);
			}
			if (_italic.HasValue)
			{
				PropVariant pv5 = PropVariant.FromObject((uint)_italic.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_Italic, ref pv5);
			}
			if (_underline.HasValue)
			{
				PropVariant pv6 = PropVariant.FromObject((uint)_underline.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_Underline, ref pv6);
			}
			if (_strikethrough.HasValue)
			{
				PropVariant pv7 = PropVariant.FromObject((uint)_strikethrough.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_Strikethrough, ref pv7);
			}
			if (_foregroundColor.HasValue)
			{
				PropVariant pv8 = PropVariant.FromObject((uint)ColorTranslator.ToWin32(_foregroundColor.Value));
				propertyStore.SetValue(ref RibbonProperties.FontProperties_ForegroundColor, ref pv8);
			}
			if (_foregroundColorType.HasValue)
			{
				PropVariant pv9 = PropVariant.FromObject((uint)_foregroundColorType.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_ForegroundColorType, ref pv9);
			}
			if (_backgroundColor.HasValue)
			{
				PropVariant pv10 = PropVariant.FromObject((uint)ColorTranslator.ToWin32(_backgroundColor.Value));
				propertyStore.SetValue(ref RibbonProperties.FontProperties_BackgroundColor, ref pv10);
			}
			if (_backgroundColorType.HasValue)
			{
				PropVariant pv11 = PropVariant.FromObject((uint)_backgroundColorType.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_BackgroundColorType, ref pv11);
			}
			if (_verticalPositioning.HasValue)
			{
				PropVariant pv12 = PropVariant.FromObject((uint)_verticalPositioning.Value);
				propertyStore.SetValue(ref RibbonProperties.FontProperties_VerticalPositioning, ref pv12);
			}
			newValue.SetIUnknown(propertyStore);
		}
		return HRESULT.S_OK;
	}
}
