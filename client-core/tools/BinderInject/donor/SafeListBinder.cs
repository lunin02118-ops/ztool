using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZTool
{
    // Allow-list SerializationBinder for the clipboard copy/paste path.
    //
    // pasteitem_Click deserializes a BinaryFormatter blob straight off the
    // clipboard (the private "audio stream" channel) and casts it to
    // List<string>. The clipboard is a shared surface any process can write, so
    // a poisoned payload could otherwise make BinaryFormatter instantiate
    // arbitrary gadget types (deserialization RCE).
    //
    // This binder permits ONLY the types that make up a List<string> graph and
    // throws on anything else, so a poisoned clipboard can never materialise an
    // unexpected type.
    //
    // It must THROW on a disallowed type rather than return null: a null return
    // makes BinaryFormatter fall back to its default assembly-qualified binding,
    // which would resolve the very type we mean to block. For allowed types it
    // binds version-tolerantly (by short assembly name), so blobs still survive a
    // runtime/version change.
    internal sealed class SafeListBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            string tn = typeName ?? string.Empty;
            if (!IsAllowed(tn))
                throw new SerializationException(
                    "SafeListBinder: disallowed type in serialized clipboard data: " + tn);

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
            Type t3 = Type.GetType(typeName);
            if (t3 != null)
                return t3;

            throw new SerializationException(
                "SafeListBinder: could not resolve allowed type: " + typeName);
        }

        private static bool IsAllowed(string typeName)
        {
            if (typeName == "System.String")
                return true;
            if (typeName == "System.String[]")
                return true;
            // List<string>: BinaryFormatter writes the full generic-arg identity,
            // e.g. System.Collections.Generic.List`1[[System.String, mscorlib, ...]].
            if (typeName.StartsWith("System.Collections.Generic.List`1[[System.String,", StringComparison.Ordinal))
                return true;
            if (typeName == "System.Collections.Generic.List`1[[System.String]]")
                return true;
            return false;
        }
    }
}
