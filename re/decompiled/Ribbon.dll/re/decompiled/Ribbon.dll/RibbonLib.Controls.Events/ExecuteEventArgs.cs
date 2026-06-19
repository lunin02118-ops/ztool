using System;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Events;

public class ExecuteEventArgs : EventArgs
{
	private PropertyKeyRef _key;

	private PropVariantRef _currentValue;

	private IUISimplePropertySet _commandExecutionProperties;

	public PropertyKeyRef Key => _key;

	public PropVariantRef CurrentValue => _currentValue;

	public IUISimplePropertySet CommandExecutionProperties => _commandExecutionProperties;

	public ExecuteEventArgs(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
	{
		_key = key;
		_currentValue = currentValue;
		_commandExecutionProperties = commandExecutionProperties;
	}
}
