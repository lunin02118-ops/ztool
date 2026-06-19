using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RibbonLib;

public class RibbonShortcutTable
{
	private List<RibbonShortcut> _ribbonShortcuts = new List<RibbonShortcut>();

	public RibbonShortcut[] RibbonShortcutArray
	{
		get
		{
			if (_ribbonShortcuts == null)
			{
				return null;
			}
			return _ribbonShortcuts.ToArray();
		}
		set
		{
			if (value == null)
			{
				_ribbonShortcuts = new List<RibbonShortcut>();
			}
			else
			{
				_ribbonShortcuts = new List<RibbonShortcut>(value);
			}
		}
	}

	[XmlIgnore]
	public List<RibbonShortcut> RibbonShortcuts => _ribbonShortcuts;

	public uint HitTest(Keys shortcutKeys)
	{
		return RibbonShortcuts.FirstOrDefault((RibbonShortcut s) => s.ShortcutKeys == shortcutKeys)?.CommandId ?? 0;
	}
}
