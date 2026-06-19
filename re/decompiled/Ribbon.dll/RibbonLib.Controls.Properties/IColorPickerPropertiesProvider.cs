using System.Drawing;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public interface IColorPickerPropertiesProvider
{
	string AutomaticColorLabel { get; set; }

	Color Color { get; set; }

	SwatchColorType ColorType { get; set; }

	string MoreColorsLabel { get; set; }

	string NoColorLabel { get; set; }

	string RecentColorsCategoryLabel { get; set; }

	Color[] StandardColors { get; set; }

	string StandardColorsCategoryLabel { get; set; }

	string[] StandardColorsTooltips { get; set; }

	Color[] ThemeColors { get; set; }

	string ThemeColorsCategoryLabel { get; set; }

	string[] ThemeColorsTooltips { get; set; }
}
