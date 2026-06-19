using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class ImagePropertiesProvider : BasePropertiesProvider, IImagePropertiesProvider
{
	private IUIImage _largeImage;

	private IUIImage _smallImage;

	private IUIImage _largeHighContrastImage;

	private IUIImage _smallHighContrastImage;

	public IUIImage LargeImage
	{
		get
		{
			return _largeImage;
		}
		set
		{
			_largeImage = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.LargeImage));
			}
		}
	}

	public IUIImage SmallImage
	{
		get
		{
			return _smallImage;
		}
		set
		{
			_smallImage = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.SmallImage));
			}
		}
	}

	public IUIImage LargeHighContrastImage
	{
		get
		{
			return _largeHighContrastImage;
		}
		set
		{
			_largeHighContrastImage = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.LargeHighContrastImage));
			}
		}
	}

	public IUIImage SmallHighContrastImage
	{
		get
		{
			return _smallHighContrastImage;
		}
		set
		{
			_smallHighContrastImage = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.SmallHighContrastImage));
			}
		}
	}

	public ImagePropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.LargeImage);
		_supportedProperties.Add(RibbonProperties.SmallImage);
		_supportedProperties.Add(RibbonProperties.LargeHighContrastImage);
		_supportedProperties.Add(RibbonProperties.SmallHighContrastImage);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.LargeImage)
		{
			if (_largeImage != null)
			{
				newValue.SetIUnknown(_largeImage);
			}
		}
		else if (key == RibbonProperties.SmallImage)
		{
			if (_smallImage != null)
			{
				newValue.SetIUnknown(_smallImage);
			}
		}
		else if (key == RibbonProperties.LargeHighContrastImage)
		{
			if (_largeHighContrastImage != null)
			{
				newValue.SetIUnknown(_largeHighContrastImage);
			}
		}
		else if (key == RibbonProperties.SmallHighContrastImage && _smallHighContrastImage != null)
		{
			newValue.SetIUnknown(_smallHighContrastImage);
		}
		return HRESULT.S_OK;
	}
}
