using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZTool;

internal sealed class SafeListBinder : SerializationBinder
{
	public override Type BindToType(string P_0, string P_1)
	{
		string text = P_1 ?? string.Empty;
		if (!IsAllowed(text))
		{
			throw new SerializationException("SafeListBinder: disallowed type in serialized clipboard data: " + text);
		}
		string text2 = P_0 ?? string.Empty;
		int num = text2.IndexOf(',');
		if (num >= 0)
		{
			text2 = text2.Substring(0, num);
		}
		text2 = text2.Trim();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			if (string.Equals(assemblies[i].GetName().Name, text2, StringComparison.OrdinalIgnoreCase))
			{
				Type type = assemblies[i].GetType(P_1);
				if (type != null)
				{
					return type;
				}
			}
		}
		Type type2 = Type.GetType(P_1 + ", " + text2);
		if (type2 != null)
		{
			return type2;
		}
		Type type3 = Type.GetType(P_1);
		if (type3 != null)
		{
			return type3;
		}
		throw new SerializationException("SafeListBinder: could not resolve allowed type: " + P_1);
	}

	private static bool IsAllowed(string P_0)
	{
		if (P_0 == "System.String")
		{
			return true;
		}
		if (P_0 == "System.String[]")
		{
			return true;
		}
		if (P_0.StartsWith("System.Collections.Generic.List`1[[System.String,", StringComparison.Ordinal))
		{
			return true;
		}
		if (P_0 == "System.Collections.Generic.List`1[[System.String]]")
		{
			return true;
		}
		return false;
	}
}
