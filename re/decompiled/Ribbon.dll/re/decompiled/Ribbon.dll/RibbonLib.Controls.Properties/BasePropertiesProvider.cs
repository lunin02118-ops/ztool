using System.Collections.Generic;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class BasePropertiesProvider : IPropertiesProvider
{
	protected Ribbon _ribbon;

	protected uint _commandID;

	protected List<PropertyKey> _supportedProperties = new List<PropertyKey>();

	public IList<PropertyKey> SupportedProperties => _supportedProperties;

	protected BasePropertiesProvider(Ribbon ribbon, uint commandID)
	{
		_ribbon = ribbon;
		_commandID = commandID;
	}

	public virtual HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		return HRESULT.S_OK;
	}
}
