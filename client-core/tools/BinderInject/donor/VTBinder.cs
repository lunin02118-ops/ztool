using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZTool
{
    // Version-tolerant SerializationBinder.
    //
    // BinaryFormatter embeds the *full* assembly identity (Name, Version,
    // Culture, PublicKeyToken) of every serialized type into the stream. A blob
    // written under one runtime (e.g. older .NET) fails to bind under another
    // (SolidWorks 2025 pulls different framework assembly versions): the type's
    // assembly identity no longer matches -> SerializationException.
    //
    // This binder resolves a type by its *short* assembly name against whatever
    // is actually loaded in the current AppDomain, ignoring Version / Culture /
    // PublicKeyToken. Stored config blobs (Font / Color / DataTable) therefore
    // deserialize regardless of which runtime produced them. On a miss it returns
    // null, so BinaryFormatter falls back to its normal binding (no regression).
    //
    // The assembly identity is also embedded *inside* nested type names - the
    // generic arguments / array element of e.g. a DataTable column typed
    // System.Object are written as "System.Object, ZTool, Version=...". When the
    // named assembly is found but does not actually contain that framework type,
    // the default binder throws (observed as "System.Object из ZTool"). To
    // survive that, every embedded assembly identity is resolved tolerantly via
    // the Type.GetType resolver overload, which is applied recursively to the
    // generic / array parts as well.
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
                    Type resolved = Type.GetType(aqn, ResolveAssembly, ResolveType, false);
                    if (resolved != null)
                        return resolved;
                }
                catch
                {
                }
            }

            string shortAsm = assemblyName ?? string.Empty;
            int comma = shortAsm.IndexOf(',');
            if (comma >= 0)
                shortAsm = shortAsm.Substring(0, comma);
            shortAsm = shortAsm.Trim();

            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < asms.Length; i++)
            {
                if (string.Equals(asms[i].GetName().Name, shortAsm, StringComparison.OrdinalIgnoreCase))
                {
                    Type t = asms[i].GetType(typeName);
                    if (t != null)
                        return t;
                }
            }

            Type t2 = Type.GetType(typeName + ", " + shortAsm);
            if (t2 != null)
                return t2;
            return Type.GetType(typeName);
        }

        // Resolve an embedded assembly identity by its short name against the
        // loaded AppDomain (ignoring Version / Culture / PublicKeyToken), falling
        // back to a plain load by simple name. Returning null is allowed: the
        // type resolver below then resolves the type from whatever is loaded.
        //
        // Kept as an instance method on purpose: a method-group conversion of a
        // *static* method makes Roslyn emit a cached-delegate helper type
        // ("<>O"), which the binder transplant does not copy and would leave a
        // dangling donor-assembly reference. An instance method group captures
        // `this`, so no cache type is generated.
        private Assembly ResolveAssembly(AssemblyName name)
        {
            if (name == null || string.IsNullOrEmpty(name.Name))
                return null;

            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < asms.Length; i++)
            {
                if (string.Equals(asms[i].GetName().Name, name.Name, StringComparison.OrdinalIgnoreCase))
                    return asms[i];
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

        // Resolve a type name within the (tolerantly resolved) assembly. If the
        // named assembly does not contain it - the "System.Object, ZTool" case -
        // fall back to the framework / any loaded assembly by name so the bind
        // succeeds instead of throwing. Instance method for the same
        // cache-type reason as ResolveAssembly above.
        private Type ResolveType(Assembly assembly, string name, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            if (assembly != null)
            {
                try
                {
                    Type t = assembly.GetType(name, false, ignoreCase);
                    if (t != null)
                        return t;
                }
                catch
                {
                }
            }

            Type byName = Type.GetType(name);
            if (byName != null)
                return byName;

            Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < asms.Length; i++)
            {
                try
                {
                    Type t = asms[i].GetType(name, false, ignoreCase);
                    if (t != null)
                        return t;
                }
                catch
                {
                }
            }

            return null;
        }
    }
}
