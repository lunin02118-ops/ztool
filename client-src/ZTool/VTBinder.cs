using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZTool;

// Version-tolerant SerializationBinder.
//
// BinaryFormatter embeds the *full* assembly identity (Name, Version,
// Culture, PublicKeyToken) of every serialized type into the stream. Config
// blobs persisted by the original signed ZTool build carry the identity
// "ZTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f08fc7047657204e".
// The from-source build is unsigned (PublicKeyToken=null), so the default
// binder cannot satisfy that identity and deserialization fails (seen as
// "Не удалось загрузить тип System.Object из сборки ZTool ...").
//
// This binder resolves a type by its *short* assembly name against whatever
// is actually loaded in the current AppDomain, ignoring Version / Culture /
// PublicKeyToken. Stored config blobs (Font / Color / DataTable) therefore
// deserialize regardless of which build/runtime produced them. On a miss it
// returns null, so BinaryFormatter falls back to its normal binding.
//
// The assembly identity is also embedded *inside* nested type names - the
// generic arguments / array element of e.g. a DataTable column typed
// System.Object are written as "System.Object, ZTool, Version=...". When the
// named assembly is found but does not actually contain that framework type,
// the default binder throws (observed as "System.Object из ZTool"). To
// survive that, every embedded assembly identity is resolved tolerantly via
// the Type.GetType resolver overload, applied recursively to the generic /
// array parts as well.
internal sealed class VTBinder : SerializationBinder
{
	public override Type BindToType(string assemblyName, string typeName)
	{
		if (!string.IsNullOrEmpty(typeName))
		{
			string aqn = string.IsNullOrEmpty(assemblyName)
				? typeName
				: typeName + ", " + assemblyName;
			try
			{
				Type resolved = Type.GetType(aqn, ResolveAssembly, ResolveType, throwOnError: false);
				if (resolved != null)
				{
					return resolved;
				}
			}
			catch
			{
			}
		}

		string shortAsm = assemblyName ?? string.Empty;
		int comma = shortAsm.IndexOf(',');
		if (comma >= 0)
		{
			shortAsm = shortAsm.Substring(0, comma);
		}
		shortAsm = shortAsm.Trim();

		Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < asms.Length; i++)
		{
			if (string.Equals(asms[i].GetName().Name, shortAsm, StringComparison.OrdinalIgnoreCase))
			{
				Type t = asms[i].GetType(typeName);
				if (t != null)
				{
					return t;
				}
			}
		}

		Type t2 = Type.GetType(typeName + ", " + shortAsm);
		if (t2 != null)
		{
			return t2;
		}
		return Type.GetType(typeName);
	}

	private Assembly ResolveAssembly(AssemblyName name)
	{
		if (name == null || string.IsNullOrEmpty(name.Name))
		{
			return null;
		}

		Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < asms.Length; i++)
		{
			if (string.Equals(asms[i].GetName().Name, name.Name, StringComparison.OrdinalIgnoreCase))
			{
				return asms[i];
			}
		}

		try
		{
			return Assembly.Load(new AssemblyName(name.Name));
		}
		catch
		{
			return null;
		}
	}

	private Type ResolveType(Assembly assembly, string name, bool ignoreCase)
	{
		if (string.IsNullOrEmpty(name))
		{
			return null;
		}

		if (assembly != null)
		{
			try
			{
				Type t = assembly.GetType(name, throwOnError: false, ignoreCase);
				if (t != null)
				{
					return t;
				}
			}
			catch
			{
			}
		}

		Type byName = Type.GetType(name);
		if (byName != null)
		{
			return byName;
		}

		Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < asms.Length; i++)
		{
			try
			{
				Type t = asms[i].GetType(name, throwOnError: false, ignoreCase);
				if (t != null)
				{
					return t;
				}
			}
			catch
			{
			}
		}

		return null;
	}
}
