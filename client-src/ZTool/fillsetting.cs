using System.Collections.Generic;

namespace ZTool;

public class fillsetting
{
	public string name;

	public bool @checked;

	public List<string> RulesList;

	public int colindex;

	public string fillcontent;

	public fillsetting()
	{
		name = "";
		@checked = true;
		RulesList = new List<string>();
	}
}
