using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

// deobfuscate <in.dll> [out.dll]
//
// Renames the invisible-Unicode / symbol-garbage identifiers produced by the
// add-in obfuscator into stable, valid, editable C# identifiers, so the
// decompiled SWTools.dll add-in becomes human-editable source (Этап D).
//
// Behaviour-preserving rules:
//   * Only identifiers that are NOT valid simple names are renamed. A name is
//     "clean" iff every char is a letter (incl. CJK), digit or '_', and the
//     first char is a letter or '_'. SolidWorks COM callbacks (Menu0_0,
//     openZtool, PMPEnable_3, ...) are clean and therefore never touched.
//   * Methods that override / implement something (virtual + reuse-slot, or
//     declared overrides) keep their name so the v-table / interface link is
//     preserved.
//   * Fields of [Serializable] / ISerializable types are left alone so any
//     persisted-by-name state still round-trips.
//   * Renames operate on dnlib *Def* objects, so every in-module IL reference
//     to a renamed member is updated automatically; external MemberRefs (the
//     SolidWorks interop, RibbonLib, mscorlib, ...) are untouched.
internal static class Program
{
    private static ModuleDefMD _mod;
    private static int _typeN, _methodN, _fieldN, _propN, _eventN, _paramN, _gpN;
    private static int _renamed, _refsFixed;

    // (declaring type) -> (old member name -> new member name). Used to repair
    // MemberRefs to members of *generic* types: a call/field access through a
    // generic instantiation (e.g. Foo<Bar>.member) is emitted as a MemberRef
    // whose Name is an independent string copy, so renaming the MethodDef /
    // FieldDef does not update it. We patch those references in a second pass.
    private static readonly Dictionary<TypeDef, Dictionary<string, string>> _memberRenames = new();
    // Global old-name -> new-name fallback. Obfuscated names are globally unique
    // in practice; if the same old name ever maps to two different new names we
    // mark it ambiguous and refuse to use the global fallback for it.
    private static readonly Dictionary<string, string> _globalRename = new();
    private static readonly HashSet<string> _ambiguous = new();

    private static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("usage: deobfuscate <in.dll> [out.dll]");
            return 2;
        }
        string inPath = args[0];
        string outPath = args.Length >= 2 ? args[1] : inPath;

        _mod = ModuleDefMD.Load(inPath);

        foreach (var type in _mod.GetTypes())
            RenameType(type);

        FixupMemberRefs();

        var opts = new ModuleWriterOptions(_mod);
        _mod.Write(outPath, opts);
        Console.WriteLine($"deobfuscate: renamed {_renamed} identifiers ({_refsFixed} generic memberrefs repaired) -> {outPath}");
        Console.WriteLine($"  types={_typeN} methods={_methodN} fields={_fieldN} props={_propN} events={_eventN} params={_paramN} generics={_gpN}");
        return 0;
    }

    private static void RenameType(TypeDef type)
    {
        if (type.IsGlobalModuleType) return; // <Module>

        // Embedded NoPIA interop types ([TypeIdentifier]) are matched at runtime
        // by GUID and must keep their original identity/namespace -- never touch
        // them (they are dropped from source and replaced by interop references).
        if (IsEmbeddedInterop(type)) return;

        // Namespaces are intentionally left untouched: renaming them merged the
        // embedded interop types into ZTool and collided with the real addin
        // types (e.g. SolidWorks.Interop.swpublished.SwAddin vs ZTool.SwAddin).
        if (IsObfuscated(type.Name))
        {
            string oldFullName = string.IsNullOrEmpty(type.Namespace)
                ? type.Name
                : type.Namespace + "." + type.Name;
            type.Name = $"Type_{_typeN++}";
            _renamed++;
            // WinForms types resolve their designer resources via
            // ComponentResourceManager(typeof(T)) -> "T.FullName.resources".
            // Keep the embedded manifest resource name in sync with the type.
            string newFullName = string.IsNullOrEmpty(type.Namespace)
                ? (string)type.Name
                : type.Namespace + "." + type.Name;
            RenameAssociatedResource(oldFullName, newFullName);
        }

        bool serializable = IsSerializable(type);

        foreach (var gp in type.GenericParameters)
            if (IsObfuscated(gp.Name)) { gp.Name = $"T{_gpN++}"; _renamed++; }

        foreach (var f in type.Fields)
        {
            if (serializable) continue;            // protect persisted-by-name state
            if (IsObfuscated(f.Name)) { string old = f.Name; f.Name = $"f_{_fieldN++}"; _renamed++; RecordRename(type, old, f.Name); }
        }

        // Methods that back a property/event are renamed together with the
        // member below, so skip those here.
        var accessorMethods = new HashSet<MethodDef>();
        foreach (var p in type.Properties)
        {
            if (p.GetMethod != null) accessorMethods.Add(p.GetMethod);
            if (p.SetMethod != null) accessorMethods.Add(p.SetMethod);
            foreach (var m in p.OtherMethods) accessorMethods.Add(m);
        }
        foreach (var e in type.Events)
        {
            if (e.AddMethod != null) accessorMethods.Add(e.AddMethod);
            if (e.RemoveMethod != null) accessorMethods.Add(e.RemoveMethod);
            if (e.InvokeMethod != null) accessorMethods.Add(e.InvokeMethod);
            foreach (var m in e.OtherMethods) accessorMethods.Add(m);
        }

        foreach (var m in type.Methods)
        {
            foreach (var pd in m.ParamDefs)
                if (IsObfuscated(pd.Name)) { pd.Name = $"arg_{_paramN++}"; _renamed++; }
            foreach (var gp in m.GenericParameters)
                if (IsObfuscated(gp.Name)) { gp.Name = $"T{_gpN++}"; _renamed++; }

            if (accessorMethods.Contains(m)) continue;
            if (!IsObfuscated(m.Name)) continue;
            if (m.IsRuntimeSpecialName) continue;  // .ctor / .cctor

            string oldName = m.Name;
            string newName;
            if (m.HasOverrides)
            {
                // Explicit override (MethodImpl) -- e.g. the obfuscator renamed an
                // object.Equals/GetHashCode/ToString override. The C# name must match
                // the overridden member; if that target is itself obfuscated (an
                // internal interface) leave the pair untouched so they stay in sync.
                var tgt = m.Overrides[0].MethodDeclaration;
                string tname = tgt?.Name;
                if (string.IsNullOrEmpty(tname) || IsObfuscated(tname)) continue;
                newName = tname;
            }
            else if (m.IsVirtual && !m.IsNewSlot)
            {
                continue; // implicit slot override of a base we don't control
            }
            else
            {
                newName = $"m_{_methodN++}";
            }
            // Obfuscators set a bogus SpecialName flag on ordinary methods; clear it
            // so the recompiled method is emitted as a normal member.
            m.IsSpecialName = false;
            m.Name = newName; _renamed++;
            RecordRename(type, oldName, newName);
        }

        foreach (var p in type.Properties)
        {
            if (!IsObfuscated(p.Name)) continue;
            string baseName = $"p_{_propN++}";
            RenameAccessor(p.GetMethod, "get_" + baseName);
            RenameAccessor(p.SetMethod, "set_" + baseName);
            p.Name = baseName; _renamed++;
        }
        foreach (var e in type.Events)
        {
            if (!IsObfuscated(e.Name)) continue;
            string baseName = $"e_{_eventN++}";
            RenameAccessor(e.AddMethod, "add_" + baseName);
            RenameAccessor(e.RemoveMethod, "remove_" + baseName);
            e.Name = baseName; _renamed++;
        }
    }

    private static void RenameAccessor(MethodDef m, string name)
    {
        if (m == null) return;
        if (KeepsVtableName(m)) return;
        string old = m.Name;
        m.Name = name; _renamed++;
        RecordRename(m.DeclaringType, old, name);
    }

    private static void RecordRename(TypeDef type, string oldName, string newName)
    {
        if (string.IsNullOrEmpty(oldName)) return;
        if (!_memberRenames.TryGetValue(type, out var map))
            _memberRenames[type] = map = new Dictionary<string, string>();
        map[oldName] = newName;

        if (_globalRename.TryGetValue(oldName, out var existing))
        {
            if (existing != newName) _ambiguous.Add(oldName);
        }
        else _globalRename[oldName] = newName;
    }

    // Second pass: rewrite MemberRefs that target renamed members of generic
    // types so that call sites / field accesses through generic instantiations
    // match the renamed definitions.
    private static void FixupMemberRefs()
    {
        // Walk IL operands directly: the MemberRef instances referenced by
        // instructions are the ones emitted into the new IL, so editing them
        // (rather than the rows from GetMemberRefs) guarantees the change sticks.
        var seen = new HashSet<MemberRef>();
        foreach (var t in _mod.GetTypes())
            foreach (var m in t.Methods)
            {
                if (m.Body == null) continue;
                foreach (var instr in m.Body.Instructions)
                {
                    MemberRef mr = instr.Operand as MemberRef
                        ?? (instr.Operand as MethodSpec)?.Method as MemberRef;
                    if (mr != null && seen.Add(mr))
                        FixupMemberRef(mr);
                }
            }
    }

    private static void FixupMemberRef(MemberRef mr)
    {
        var td = (mr.Class as ITypeDefOrRef)?.ScopeType?.ResolveTypeDef();
        string oldName = mr.Name;
        if (td != null && _memberRenames.TryGetValue(td, out var map)
            && map.TryGetValue(oldName, out var nn))
        {
            mr.Name = nn;
            _refsFixed++;
            return;
        }
        // Fallback: match by globally-unique obfuscated name when the
        // declaring-type lookup misses (e.g. self-referential generic
        // instantiations whose TypeSpec does not resolve to the same TypeDef).
        if (IsObfuscated(oldName) && !_ambiguous.Contains(oldName)
            && _globalRename.TryGetValue(oldName, out var gnn))
        {
            mr.Name = gnn;
            _refsFixed++;
        }
    }

    private static void RenameAssociatedResource(string oldFullName, string newFullName)
    {
        string oldRes = oldFullName + ".resources";
        string newRes = newFullName + ".resources";
        foreach (var res in _mod.Resources)
        {
            if (res.Name == oldRes)
            {
                res.Name = newRes;
                _renamed++;
                Console.WriteLine($"  resource: {oldRes} -> {newRes}");
            }
        }
    }

    private static bool IsEmbeddedInterop(TypeDef type)
    {
        foreach (var ca in type.CustomAttributes)
            if (ca.TypeFullName == "System.Runtime.CompilerServices.TypeIdentifierAttribute")
                return true;
        return false;
    }

    // A method whose name is dictated by something outside this type: it
    // overrides a base method (virtual + reuse slot) or explicitly implements
    // an interface member. Renaming such a method would break the link.
    private static bool KeepsVtableName(MethodDef m)
    {
        if (m.HasOverrides) return true;
        if (m.IsVirtual && !m.IsNewSlot) return true;
        return false;
    }

    private static bool IsSerializable(TypeDef type)
    {
        if (type.IsSerializable) return true;
        var bt = type.BaseType;
        return bt != null && bt.FullName == "System.Runtime.Serialization.ISerializable";
    }

    // "Clean" == a name a human could have written and the obfuscator would not
    // have produced: non-empty, starts with a letter or '_', and every char is
    // a letter (any script, incl. CJK), a digit or '_'. Anything containing a
    // format/control/zero-width char or ASCII punctuation is considered
    // obfuscated.
    private static bool IsObfuscated(string name)
    {
        if (string.IsNullOrEmpty(name)) return false; // nothing to rename
        // A '.' marks an explicit interface implementation (e.g.
        // 'ZTool.ISwAddin.ConnectToSW'); its name is dictated by the interface,
        // so leave it alone.
        if (name.IndexOf('.') >= 0) return false;
        char first = name[0];
        if (!(IsIdentLetter(first) || first == '_')) return true;
        foreach (char c in name)
            if (!(IsIdentLetter(c) || char.IsDigit(c) || c == '_'))
                return true;
        return false;
    }

    private static bool IsIdentLetter(char c)
    {
        var cat = CharUnicodeInfo.GetUnicodeCategory(c);
        switch (cat)
        {
            case UnicodeCategory.UppercaseLetter:
            case UnicodeCategory.LowercaseLetter:
            case UnicodeCategory.TitlecaseLetter:
            case UnicodeCategory.ModifierLetter:
            case UnicodeCategory.OtherLetter:       // CJK ideographs
                return true;
            default:
                return false;
        }
    }
}
