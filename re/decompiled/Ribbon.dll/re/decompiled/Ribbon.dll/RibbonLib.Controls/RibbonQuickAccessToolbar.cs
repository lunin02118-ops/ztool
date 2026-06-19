using System;
using RibbonLib.Controls.Events;
using RibbonLib.Interop;

namespace RibbonLib.Controls;

public class RibbonQuickAccessToolbar : IRibbonControl, IExecuteEventsProvider
{
	protected Ribbon _ribbon;

	protected uint _commandID;

	protected RibbonButton _customizeButton;

	private IUICollection _itemsSource = new UICollection();

	public uint CommandID => _commandID;

	public IUICollection ItemsSource
	{
		get
		{
			if (_ribbon.Initalized)
			{
				PropVariant value;
				HRESULT uICommandProperty = _ribbon.Framework.GetUICommandProperty(_commandID, ref RibbonProperties.ItemsSource, out value);
				if (NativeMethods.Succeeded(uICommandProperty))
				{
					return (IUICollection)value.Value;
				}
			}
			return _itemsSource;
		}
	}

	public event EventHandler<ExecuteEventArgs> ExecuteEvent
	{
		add
		{
			if (_customizeButton != null)
			{
				_customizeButton.ExecuteEvent += value;
			}
		}
		remove
		{
			if (_customizeButton != null)
			{
				_customizeButton.ExecuteEvent -= value;
			}
		}
	}

	public RibbonQuickAccessToolbar(Ribbon ribbon, uint commandId)
	{
		_ribbon = ribbon;
		_commandID = commandId;
	}

	public RibbonQuickAccessToolbar(Ribbon ribbon, uint commandId, uint customizeCommandId)
		: this(ribbon, commandId)
	{
		_customizeButton = new RibbonButton(_ribbon, customizeCommandId);
	}

	public HRESULT Execute(ExecutionVerb verb, PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
	{
		return HRESULT.S_OK;
	}

	public HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.ItemsSource && _itemsSource != null)
		{
			IUICollection iUICollection = (IUICollection)currentValue.PropVariant.Value;
			iUICollection.Clear();
			_itemsSource.GetCount(out var count);
			for (uint num = 0u; num < count; num++)
			{
				_itemsSource.GetItem(num, out var item);
				iUICollection.Add(item);
			}
		}
		return HRESULT.S_OK;
	}
}
