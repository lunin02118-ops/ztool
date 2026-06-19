using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

[ComImport]
[Guid("75ae0a2d-dc03-4c9f-8883-069660d0beb6")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IUICommandHandler
{
	[PreserveSig]
	HRESULT Execute(uint commandID, ExecutionVerb verb, [Optional][In] PropertyKeyRef key, [Optional][In] PropVariantRef currentValue, [Optional][In] IUISimplePropertySet commandExecutionProperties);

	[PreserveSig]
	HRESULT UpdateProperty(uint commandID, [In] ref PropertyKey key, [Optional][In] PropVariantRef currentValue, [In][Out] ref PropVariant newValue);
}
