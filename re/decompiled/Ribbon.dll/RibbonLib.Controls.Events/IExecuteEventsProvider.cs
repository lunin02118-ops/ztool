using System;

namespace RibbonLib.Controls.Events;

public interface IExecuteEventsProvider
{
	event EventHandler<ExecuteEventArgs> ExecuteEvent;
}
