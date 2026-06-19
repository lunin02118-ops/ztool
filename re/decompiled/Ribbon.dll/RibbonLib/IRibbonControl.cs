using RibbonLib.Interop;

namespace RibbonLib;

internal interface IRibbonControl
{
	uint CommandID { get; }

	HRESULT Execute(ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties);

	HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue);
}
