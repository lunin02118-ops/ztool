using System.Collections.Generic;
using System.Linq;
using RibbonLib.Interop;

namespace RibbonLib.Controls.Properties;

public class RecentItemsPropertiesProvider : BasePropertiesProvider, IRecentItemsPropertiesProvider
{
	private IList<RecentItemsPropertySet> _recentItems;

	public IList<RecentItemsPropertySet> RecentItems
	{
		get
		{
			return _recentItems;
		}
		set
		{
			_recentItems = value;
		}
	}

	public RecentItemsPropertiesProvider(Ribbon ribbon, uint commandId)
		: base(ribbon, commandId)
	{
		_supportedProperties.Add(RibbonProperties.RecentItems);
	}

	public override HRESULT UpdateProperty(ref PropertyKey key, PropVariantRef currentValue, ref PropVariant newValue)
	{
		if (key == RibbonProperties.RecentItems && _recentItems != null)
		{
			newValue.SetSafeArray(_recentItems.ToArray());
		}
		return HRESULT.S_OK;
	}
}
