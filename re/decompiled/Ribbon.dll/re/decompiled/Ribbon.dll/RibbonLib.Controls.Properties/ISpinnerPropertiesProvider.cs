namespace RibbonLib.Controls.Properties;

public interface ISpinnerPropertiesProvider
{
	decimal DecimalValue { get; set; }

	decimal Increment { get; set; }

	decimal MaxValue { get; set; }

	decimal MinValue { get; set; }

	uint DecimalPlaces { get; set; }

	string FormatString { get; set; }
}
