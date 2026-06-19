using System;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class GalleryPropertiesProvider : BasePropertiesProvider, IGalleryPropertiesProvider
{
	private object _sender;

	private uint? _selectedItem;

	public IUICollection Categories
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.Categories, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (IUICollection)value.Value;
				}
			}
			return null;
		}
	}

	public IUICollection ItemsSource
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.ItemsSource, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (IUICollection)value.Value;
				}
			}
			return null;
		}
	}

	public uint SelectedItem
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.SelectedItem, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (uint)value.Value;
				}
			}
			return (uint)(((int?)_selectedItem) ?? (-1));
		}
		set
		{
			_selectedItem = value;
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject(value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.SelectedItem, ref value2);
			}
		}
	}

	public event EventHandler<EventArgs> CategoriesReady;

	public event EventHandler<EventArgs> ItemsSourceReady;

	public GalleryPropertiesProvider(Ribbon ribbon, uint commandId, object sender)
		: base(ribbon, commandId)
	{
		_sender = sender;
		_supportedProperties.Add(RibbonProperties.Categories);
		_supportedProperties.Add(RibbonProperties.ItemsSource);
		_supportedProperties.Add(RibbonProperties.SelectedItem);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.Categories)
		{
			if (this.CategoriesReady != null)
			{
				this.CategoriesReady(_sender, EventArgs.Empty);
			}
		}
		else if (key == RibbonProperties.ItemsSource)
		{
			if (this.ItemsSourceReady != null)
			{
				this.ItemsSourceReady(_sender, EventArgs.Empty);
			}
		}
		else if (key == RibbonProperties.SelectedItem && _selectedItem.HasValue)
		{
			newValue.SetUInt(_selectedItem.Value);
		}
		return HRESULT.S_OK;
	}
}
