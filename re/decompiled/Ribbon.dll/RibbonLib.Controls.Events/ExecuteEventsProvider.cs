using System;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Events;

public class ExecuteEventsProvider : BaseEventsProvider, IExecuteEventsProvider
{
	private object _sender;

	public event EventHandler<ExecuteEventArgs> ExecuteEvent;

	public ExecuteEventsProvider(object sender)
	{
		_sender = sender;
		base.SupportedEvents.Add(ExecutionVerb.Execute);
	}

	public override HRESULT Execute(ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
	{
		if (verb == ExecutionVerb.Execute && this.ExecuteEvent != null)
		{
			this.ExecuteEvent(_sender, new ExecuteEventArgs(key, currentValue, commandExecutionProperties));
		}
		return HRESULT.S_OK;
	}
}
