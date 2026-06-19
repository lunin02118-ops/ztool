using System.Collections.Generic;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Events;

public class BaseEventsProvider : IEventsProvider
{
	private List<ExecutionVerb> _supportedEvents = new List<ExecutionVerb>();

	public IList<ExecutionVerb> SupportedEvents => _supportedEvents;

	protected BaseEventsProvider()
	{
	}

	public virtual HRESULT Execute(ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
	{
		return HRESULT.S_OK;
	}
}
