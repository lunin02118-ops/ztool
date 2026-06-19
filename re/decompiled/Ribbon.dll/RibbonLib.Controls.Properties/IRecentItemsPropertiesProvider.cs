using System.Collections.Generic;

namespace RibbonLib.Controls.Properties;

public interface IRecentItemsPropertiesProvider
{
	IList<RecentItemsPropertySet> RecentItems { get; set; }
}
