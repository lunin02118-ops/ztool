using System;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Events;

internal class PreviewEventsProvider : BaseEventsProvider, IPreviewEventsProvider
{
	private object _sender;

	public event EventHandler<ExecuteEventArgs> PreviewEvent;

	public event EventHandler<ExecuteEventArgs> CancelPreviewEvent;

	public PreviewEventsProvider(object sender)
	{
		_sender = sender;
		base.SupportedEvents.Add(ExecutionVerb.Preview);
		base.SupportedEvents.Add(ExecutionVerb.CancelPreview);
	}

	public override HRESULT Execute(ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
	{
		switch (verb)
		{
		case ExecutionVerb.Preview:
			if (this.PreviewEvent != null)
			{
				this.PreviewEvent(_sender, new ExecuteEventArgs(key, currentValue, commandExecutionProperties));
			}
			break;
		case ExecutionVerb.CancelPreview:
			if (this.CancelPreviewEvent != null)
			{
				this.CancelPreviewEvent(_sender, new ExecuteEventArgs(key, currentValue, commandExecutionProperties));
			}
			break;
		}
		return HRESULT.S_OK;
	}
}
