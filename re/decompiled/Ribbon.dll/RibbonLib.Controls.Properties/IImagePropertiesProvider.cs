using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public interface IImagePropertiesProvider
{
	IUIImage LargeImage { get; set; }

	IUIImage SmallImage { get; set; }

	IUIImage LargeHighContrastImage { get; set; }

	IUIImage SmallHighContrastImage { get; set; }
}
