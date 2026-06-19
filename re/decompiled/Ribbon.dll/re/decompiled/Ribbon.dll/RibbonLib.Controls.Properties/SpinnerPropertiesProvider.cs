using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class SpinnerPropertiesProvider : BasePropertiesProvider, ISpinnerPropertiesProvider
{
	private decimal? _increment;

	private decimal? _maxValue;

	private decimal? _minValue;

	private uint? _decimalPlaces;

	private string _formatString;

	public decimal DecimalValue
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.DecimalValue, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (decimal)value.Value;
				}
			}
			return 0m;
		}
		set
		{
			if (_ribbon.Initalized)
			{
				PropVariant value2 = PropVariant.FromObject(value);
				_ribbon.Framework.SetUICommandProperty(_commandID, ref RibbonProperties.DecimalValue, ref value2);
			}
		}
	}

	public decimal Increment
	{
		get
		{
			return _increment.GetValueOrDefault();
		}
		set
		{
			_increment = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.Increment));
			}
		}
	}

	public decimal MaxValue
	{
		get
		{
			return _maxValue.GetValueOrDefault();
		}
		set
		{
			_maxValue = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.MaxValue));
			}
		}
	}

	public decimal MinValue
	{
		get
		{
			return _minValue.GetValueOrDefault();
		}
		set
		{
			_minValue = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.MinValue));
			}
		}
	}

	public uint DecimalPlaces
	{
		get
		{
			return _decimalPlaces.GetValueOrDefault();
		}
		set
		{
			_decimalPlaces = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.DecimalPlaces));
			}
		}
	}

	public string FormatString
	{
		get
		{
			return _formatString;
		}
		set
		{
			_formatString = value;
			if (_ribbon.Initalized)
			{
				_ribbon.Framework.InvalidateUICommand(_commandID, Invalidations.Property, PropertyKeyRef.From(RibbonProperties.FormatString));
			}
		}
	}

	public SpinnerPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.DecimalValue);
		_supportedProperties.Add(RibbonProperties.Increment);
		_supportedProperties.Add(RibbonProperties.MaxValue);
		_supportedProperties.Add(RibbonProperties.MinValue);
		_supportedProperties.Add(RibbonProperties.DecimalPlaces);
		_supportedProperties.Add(RibbonProperties.FormatString);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (!(key == RibbonProperties.DecimalValue))
		{
			if (key == RibbonProperties.Increment)
			{
				if (_increment.HasValue)
				{
					newValue.SetDecimal(_increment.Value);
				}
			}
			else if (key == RibbonProperties.MaxValue)
			{
				if (_maxValue.HasValue)
				{
					newValue.SetDecimal(_maxValue.Value);
				}
			}
			else if (key == RibbonProperties.MinValue)
			{
				if (_minValue.HasValue)
				{
					newValue.SetDecimal(_minValue.Value);
				}
			}
			else if (key == RibbonProperties.DecimalPlaces)
			{
				if (_decimalPlaces.HasValue)
				{
					newValue.SetUInt(_decimalPlaces.Value);
				}
			}
			else if (key == RibbonProperties.FormatString && _formatString != null)
			{
				newValue.SetString(_formatString);
			}
		}
		return HRESULT.S_OK;
	}
}
