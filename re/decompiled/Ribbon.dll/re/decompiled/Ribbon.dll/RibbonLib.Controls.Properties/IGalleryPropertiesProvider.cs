using System;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public interface IGalleryPropertiesProvider
{
	IUICollection Categories { get; }

	IUICollection ItemsSource { get; }

	uint SelectedItem { get; set; }

	event EventHandler<EventArgs> CategoriesReady;

	event EventHandler<EventArgs> ItemsSourceReady;
}
