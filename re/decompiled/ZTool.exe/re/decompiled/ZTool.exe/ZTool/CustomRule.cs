using System.Collections.Generic;

namespace ZTool;

public class CustomRule
{
	public string name;

	public bool type;

	public List<string> RuleList;

	public CustomRule()
	{
		name = "";
		type = true;
		RuleList = new List<string>();
	}
}
