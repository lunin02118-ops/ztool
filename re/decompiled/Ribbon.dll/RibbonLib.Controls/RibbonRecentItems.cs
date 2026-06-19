using System;
using System.Collections.Generic;
using RibbonLib.Controls.Events;
using RibbonLib.Controls.Properties;

namespace RibbonLib.Controls;

public class RibbonRecentItems : BaseRibbonControl, IRecentItemsPropertiesProvider, IKeytipPropertiesProvider, IExecuteEventsProvider
{
	private KeytipPropertiesProvider _keytipPropertiesProvider;

	private RecentItemsPropertiesProvider _recentItemsPropertiesProvider;

	private ExecuteEventsProvider _executeEventsProvider;

	public IList<RecentItemsPropertySet> RecentItems
	{
		get
		{
			return _recentItemsPropertiesProvider.RecentItems;
		}
		set
		{
			_recentItemsPropertiesProvider.RecentItems = value;
		}
	}

	public string Keytip
	{
		get
		{
			return _keytipPropertiesProvider.Keytip;
		}
		set
		{
			_keytipPropertiesProvider.Keytip = value;
		}
	}

	public event EventHandler<ExecuteEventArgs> ExecuteEvent
	{
		add
		{
			_executeEventsProvider.ExecuteEvent += value;
		}
		remove
		{
			_executeEventsProvider.ExecuteEvent -= value;
		}
	}

	public RibbonRecentItems(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		AddPropertiesProvider(_recentItemsPropertiesProvider = new RecentItemsPropertiesProvider(ribbon, commandId));
		AddPropertiesProvider(_keytipPropertiesProvider = new KeytipPropertiesProvider(ribbon, commandId));
		AddEventsProvider(_executeEventsProvider = new ExecuteEventsProvider(this));
	}
}
