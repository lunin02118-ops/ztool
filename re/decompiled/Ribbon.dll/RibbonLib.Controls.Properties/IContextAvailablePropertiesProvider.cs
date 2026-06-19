using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public interface IContextAvailablePropertiesProvider
{
	ContextAvailability ContextAvailable { get; set; }
}
