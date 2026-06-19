using System.Collections.Generic;
using RibbonLib.Controls.Events;
using RibbonLib.Controls.Properties;
using RibbonLib.Interop;

namespace RibbonLib.Controls;

public class BaseRibbonControl : IRibbonControl
{
	protected Ribbon _ribbon;

	protected uint _commandID;

	protected Dictionary<PropertyKey, IPropertiesProvider> _mapProperties = new Dictionary<PropertyKey, IPropertiesProvider>();

	protected Dictionary<ExecutionVerb, IEventsProvider> _mapEvents = new Dictionary<ExecutionVerb, IEventsProvider>();

	public uint CommandID => _commandID;

	protected BaseRibbonControl(Ribbon ribbon, uint commandID)
	{
		_ribbon = ribbon;
		_commandID = commandID;
		ribbon.AddRibbonControl(this);
	}

	protected void AddPropertiesProvider(IPropertiesProvider propertiesProvider)
	{
		foreach (PropertyKey supportedProperty in propertiesProvider.SupportedProperties)
		{
			_mapProperties[supportedProperty] = propertiesProvider;
		}
	}

	protected void AddEventsProvider(IEventsProvider eventsProvider)
	{
		foreach (ExecutionVerb supportedEvent in eventsProvider.SupportedEvents)
		{
			_mapEvents[supportedEvent] = eventsProvider;
		}
	}

	public virtual HRESULT Execute(ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
	{
		if (_mapEvents.ContainsKey(verb))
		{
			IEventsProvider eventsProvider = _mapEvents[verb];
			return eventsProvider.Execute(verb, key, currentValue, commandExecutionProperties);
		}
		return HRESULT.E_NOTIMPL;
	}

	public virtual HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (_mapProperties.ContainsKey(key))
		{
			IPropertiesProvider propertiesProvider = _mapProperties[key];
			return propertiesProvider.UpdateProperty(ref key, currentValue, ref newValue);
		}
		return HRESULT.S_OK;
	}
}
