using System.Collections.Generic;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Events;

public interface IEventsProvider
{
	IList<ExecutionVerb> SupportedEvents { get; }

	HRESULT Execute(ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties);
}
