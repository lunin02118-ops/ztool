using System;

namespace RibbonLib.Controls.Events;

public interface IPreviewEventsProvider
{
	event EventHandler<ExecuteEventArgs> PreviewEvent;

	event EventHandler<ExecuteEventArgs> CancelPreviewEvent;
}
