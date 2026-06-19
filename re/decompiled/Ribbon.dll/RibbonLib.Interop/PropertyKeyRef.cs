using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[StructLayout(LayoutKind.Sequential)]
public class PropertyKeyRef
{
	public PropertyKey PropertyKey;

	public static PropertyKeyRef From(PropertyKey value)
	{
		PropertyKeyRef propertyKeyRef = new PropertyKeyRef();
		propertyKeyRef.PropertyKey = value;
		return propertyKeyRef;
	}
}
