using System.Collections.Generic;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public interface IPropertiesProvider
{
	IList<PropertyKey> SupportedProperties { get; }

	HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue);
}
