using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZTool;

internal sealed class VTBinder : SerializationBinder
{
	public override Type BindToType(string P_0, string P_1)
	{
		string text = P_0 ?? string.Empty;
		int num = text.IndexOf(',');
		if (num >= 0)
		{
			text = text.Substring(0, num);
		}
		text = text.Trim();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			if (string.Equals(assemblies[i].GetName().Name, text, StringComparison.OrdinalIgnoreCase))
			{
				Type type = assemblies[i].GetType(P_1);
				if (type != null)
				{
					return type;
				}
			}
		}
		Type type2 = Type.GetType(P_1 + ", " + text);
		if (type2 != null)
		{
			return type2;
		}
		return Type.GetType(P_1);
	}
}
