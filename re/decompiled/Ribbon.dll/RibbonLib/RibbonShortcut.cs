using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RibbonLib;

public class RibbonShortcut
{
	private string _shortcut;

	private Keys _shortcutKeys;

	[XmlAttribute]
	public uint CommandId { get; set; }

	[XmlAttribute("Shortcut")]
	public string Shortcut
	{
		get
		{
			return _shortcut;
		}
		set
		{
			_shortcut = value;
			_shortcutKeys = ConvertToKeys(value);
		}
	}

	[XmlIgnore]
	public Keys ShortcutKeys => _shortcutKeys;

	public Keys ConvertToKeys(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return Keys.None;
		}
		Keys keys = Keys.None;
		string[] array = value.Split('+');
		string[] array2 = array;
		foreach (string text in array2)
		{
			string value2 = ((!(text == "Ctrl")) ? text : "Control");
			try
			{
				Keys keys2 = (Keys)Enum.Parse(typeof(Keys), value2, ignoreCase: true);
				keys |= keys2;
			}
			catch (Exception innerException)
			{
				throw new ArgumentException($"The ShortcutKey '{value}' is invalid. The token '{text}' is unknown", innerException);
			}
		}
		return keys;
	}
}
