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
    internal sealed class VTBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
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
    }
}
