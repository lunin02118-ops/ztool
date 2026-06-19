using System;
using System.Drawing;
using RibbonLib.Interop;

namespace RibbonLib;

public class FontPropertyStore
{
	private IPropertyStore _propertyStore;

	public string Family
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_Family, out var pv);
			return (string)pv.Value;
		}
	}

	public decimal Size
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_Size, out var pv);
			return (decimal)pv.Value;
		}
	}

	public FontProperties Bold
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_Bold, out var pv);
			return (FontProperties)(uint)pv.Value;
		}
	}

	public FontProperties Italic
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_Italic, out var pv);
			return (FontProperties)(uint)pv.Value;
		}
	}

	public FontUnderline Underline
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_Underline, out var pv);
			return (FontUnderline)(uint)pv.Value;
		}
	}

	public FontProperties Strikethrough
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_Strikethrough, out var pv);
			return (FontProperties)(uint)pv.Value;
		}
	}

	public Color ForegroundColor
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_ForegroundColor, out var pv);
			return ColorTranslator.FromWin32((int)(uint)pv.Value);
		}
	}

	public SwatchColorType ForegroundColorType
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_ForegroundColorType, out var pv);
			return (SwatchColorType)(uint)pv.Value;
		}
	}

	public FontDeltaSize DeltaSize
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_DeltaSize, out var pv);
			return (FontDeltaSize)(uint)pv.Value;
		}
	}

	public Color BackgroundColor
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_BackgroundColor, out var pv);
			return ColorTranslator.FromWin32((int)(uint)pv.Value);
		}
	}

	public SwatchColorType BackgroundColorType
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_BackgroundColorType, out var pv);
			return (SwatchColorType)(uint)pv.Value;
		}
	}

	public FontVerticalPosition VerticalPositioning
	{
		get
		{
			_propertyStore.GetValue(ref RibbonProperties.FontProperties_VerticalPositioning, out var pv);
			return (FontVerticalPosition)(uint)pv.Value;
		}
	}

	public FontPropertyStore(IPropertyStore propertyStore)
	{
		if (propertyStore == null)
		{
			throw new ArgumentException("Parameter propertyStore cannot be null.", "propertyStore");
		}
		_propertyStore = propertyStore;
	}
}
