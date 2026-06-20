using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ZTool;

public class bomsetting
{
	public string name;

	public string bomname;

	public int type;

	public bool insertimagebool;

	public bool lockratio;

	public int image_width;

	public int image_height;

	public bool Propertyvalue;

	public bool marknodrw;

	public bool autocolumnwidth;

	public bool ByRuler;

	public bool ByFilter;

	public List<string> RulesList;

	public bool includetop;

	public bomsetting()
	{
		name = "Экспорт сводной спецификации по умолчанию";
		bomname = Path.GetDirectoryName(Application.ExecutablePath) + "\\Шаблоны спецификации\\bom_шаблон.xlsx";
		type = 0;
		insertimagebool = false;
		lockratio = true;
		image_width = 64;
		image_height = 48;
		Propertyvalue = true;
		marknodrw = false;
		autocolumnwidth = false;
		ByRuler = false;
		ByFilter = true;
		RulesList = new List<string>();
		includetop = true;
	}
}
