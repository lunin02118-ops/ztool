using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[StructLayout(LayoutKind.Sequential)]
public class PropVariantRef
{
	public PropVariant PropVariant;

	public static PropVariantRef From(PropVariant value)
	{
		PropVariantRef propVariantRef = new PropVariantRef();
		propVariantRef.PropVariant = value;
		return propVariantRef;
	}
}
