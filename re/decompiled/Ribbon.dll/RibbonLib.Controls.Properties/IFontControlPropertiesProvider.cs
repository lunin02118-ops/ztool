using System.Drawing;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public interface IFontControlPropertiesProvider
{
	string Family { get; set; }

	decimal Size { get; set; }

	FontProperties Bold { get; set; }

	FontProperties Italic { get; set; }

	FontUnderline Underline { get; set; }

	FontProperties Strikethrough { get; set; }

	Color ForegroundColor { get; set; }

	Color BackgroundColor { get; set; }

	FontVerticalPosition VerticalPositioning { get; set; }
}
