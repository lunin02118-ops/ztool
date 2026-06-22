using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Reinjector: transplant edited method bodies from ZTool.Core.dll back into the
// real ZTool.exe. References in the edited bodies that point at the compile-time
// publicized shim (ZTool.public) or at our own core assembly (ZTool.Core) are
// remapped to the target exe's own types/members, so the patched exe is fully
// self-contained and references nothing of our build scaffolding.
//
// usage: reinject <target ZTool.exe> <source ZTool.Core.dll> <output exe>
//                 [--types A,B,C]   (default: SR,SecurityCenter,TCPClient,GetRegistrycreatedtime,MySWDM)

internal sealed class RedirectMapper : ImportMapper
{
    private readonly ModuleDef _target;
    private readonly ModuleDef _source;
    private readonly Dictionary<string, TypeDef> _targetTypes;

    public RedirectMapper(ModuleDef target, ModuleDef source)
    {
        _target = target;
        _source = source;
        _targetTypes = new Dictionary<string, TypeDef>(StringComparer.Ordinal);
        foreach (var t in target.GetTypes())
            _targetTypes[t.FullName] = t;
    }

    public bool InRedirectScope(ITypeDefOrRef t)
    {
        // Redirect any reference whose type is actually defined in the target exe.
        // target.GetTypes() only contains ZTool's own types, so mscorlib / System.*
        // refs never match and are imported normally. This covers the publicized
        // shim (assembly name "ZTool", identical to the target) as well as our core
        // dll and the source module.
        return t != null && ResolveTarget(t) != null;
    }

    public TypeDef ResolveTarget(ITypeDefOrRef t)
        => t != null && _targetTypes.TryGetValue(t.FullName, out var td) ? td : null;

    // Resolve a method/field operand that points at a redirect-scope type (the
    // publicized shim or our core dll) directly to the target's own MethodDef /
    // FieldDef. This yields a same-module Def token instead of a MemberRef whose
    // parent is a TypeDef -- the latter makes the CLR JIT throw
    // BadImageFormatException when the referencing method is compiled.
    public IMethod ResolveMethodOperand(IMethod m)
    {
        if (m == null || m is MethodSpec) return null;            // skip generic instantiations
        var dt = m.DeclaringType;
        if (!InRedirectScope(dt)) return null;
        var tt = ResolveTarget(dt);
        return tt != null ? Matcher.FindMethodBySig(tt, m.Name?.String, m.MethodSig) : null;
    }

    public IField ResolveFieldOperand(IField f)
    {
        if (f == null) return null;
        var dt = f.DeclaringType;
        if (!InRedirectScope(dt)) return null;
        var tt = ResolveTarget(dt);
        return tt?.Fields.FirstOrDefault(x => x.Name == f.Name);
    }

    public override ITypeDefOrRef Map(ITypeDefOrRef source)
    {
        if (InRedirectScope(source))
        {
            var td = ResolveTarget(source);
            if (td != null) return td;
        }
        return null; // import normally
    }

    public override IMethod Map(MethodDef source)
    {
        if (source != null && source.Module == _source)
        {
            var td = ResolveTarget(source.DeclaringType);
            var m = td != null ? Matcher.FindMethod(td, source) : null;
            if (m != null) return m;
        }
        return null;
    }

    public override IField Map(FieldDef source)
    {
        if (source != null && source.Module == _source)
        {
            var td = ResolveTarget(source.DeclaringType);
            var f = td?.Fields.FirstOrDefault(x => x.Name == source.Name);
            if (f != null) return f;
        }
        return null;
    }

    public override MemberRef Map(MemberRef source) => null; // handled via class-type mapping
}

internal static class Matcher
{
    public static bool AllowFuzzyMatch { get; set; } = false;

    private static string Key(TypeSig s) => s?.FullName ?? "";

    public static MethodDef FindMethod(TypeDef tt, MethodDef src)
        => FindMethodBySig(tt, src.Name?.String, src.MethodSig);

    private static bool SigMatches(MethodDef candidate, MethodSig sig)
    {
        if (candidate == null || sig == null || candidate.MethodSig == null) return false;
        var pc = sig.Params.Count;
        if ((candidate.MethodSig.Params.Count) != pc) return false;
        if (Key(candidate.MethodSig.RetType) != Key(sig.RetType)) return false;
        for (int i = 0; i < pc; i++)
            if (Key(candidate.MethodSig.Params[i]) != Key(sig.Params[i])) return false;
        return true;
    }

    public static MethodDef FindMethodBySig(TypeDef tt, string name, MethodSig sig)
    {
        if (tt == null || name == null) return null;
        var byName = tt.Methods.Where(m => m.Name == name).ToList();
        if (byName.Count == 0) return null;
        if (byName.Count == 1)
        {
            if (sig == null || SigMatches(byName[0], sig)) return byName[0];
            return AllowFuzzyMatch ? byName[0] : null;
        }
        var pc = sig?.Params.Count ?? 0;
        var cand = byName.Where(m => (m.MethodSig?.Params.Count ?? 0) == pc).ToList();
        if (cand.Count == 1) return cand[0];
        foreach (var m in cand)
            if (SigMatches(m, sig)) return m;
        return AllowFuzzyMatch ? (cand.FirstOrDefault() ?? byName.FirstOrDefault()) : null;
    }
}

internal static class Program
{
    private static int Main(string[] args)
    {
        if (args.Length >= 2 && args[0] == "--verify")
        {
            var m = ModuleDefMD.Load(args[1]);
            Console.WriteLine("AssemblyRefs:");
            int badRefs = 0;
            foreach (var ar in m.GetAssemblyRefs()) Console.WriteLine("  " + ar.FullName);
            foreach (var ar in m.GetAssemblyRefs())
            {
                var n = ar.Name?.String;
                if (n == "ZTool.public" || n == "ZTool.Core")
                {
                    Console.WriteLine("  ! dangling assembly ref <- " + n);
                    badRefs++;
                }
            }
            Console.WriteLine("TypeRefs into ZTool.public / ZTool.Core:");
            int bad = 0;
            foreach (var tr in m.GetTypeRefs())
            {
                var n = tr.DefinitionAssembly?.Name?.String;
                if (n == "ZTool.public" || n == "ZTool.Core") { Console.WriteLine("  ! " + tr.FullName + "  <- " + n); bad++; }
            }
            bad += badRefs;
            Console.WriteLine($"dangling typerefs = {bad}");
            return bad > 0 ? 1 : 0;
        }
        if (args.Length >= 4 && args[0] == "--rawhex")
        {
            // --rawhex <asm> <TypeName> <MethodName>
            var m = ModuleDefMD.Load(args[1]);
            var pe = m.Metadata.PEImage;
            var td = m.GetTypes().FirstOrDefault(t => t.Name == args[2]);
            foreach (var md in td.Methods.Where(x => x.Name == args[3] && x.HasBody))
            {
                uint rva = (uint)md.RVA;
                long fo = (long)pe.ToFileOffset((dnlib.PE.RVA)rva);
                var reader = pe.CreateReader();
                reader.Position = (uint)fo;
                byte[] buf = reader.ReadBytes(160);
                Console.WriteLine($"{td.Name}::{md.Name} RVA=0x{rva:X} fileOff=0x{fo:X}");
                for (int i = 0; i < buf.Length; i += 16)
                {
                    var sb2 = new System.Text.StringBuilder($"  {i:X4}: ");
                    for (int j = 0; j < 16 && i + j < buf.Length; j++) sb2.Append(buf[i + j].ToString("X2") + " ");
                    Console.WriteLine(sb2.ToString());
                }
            }
            return 0;
        }
        if (args.Length >= 4 && args[0] == "--dumpil")
        {
            // --dumpil <asm> <TypeName> <MethodName>
            var m = ModuleDefMD.Load(args[1]);
            var td = m.GetTypes().FirstOrDefault(t => t.Name == args[2]);
            if (td == null) { Console.Error.WriteLine("no type " + args[2]); return 2; }
            foreach (var md in td.Methods.Where(x => x.Name == args[3] && x.HasBody))
            {
                var b = md.Body;
                Console.WriteLine($"=== {td.Name}::{md.Name}  maxstack={b.MaxStack} initlocals={b.InitLocals} ===");
                Console.WriteLine("LOCALS:");
                foreach (var l in b.Variables) Console.WriteLine($"  [{l.Index}] {l.Type}");
                Console.WriteLine("EH:");
                foreach (var eh in b.ExceptionHandlers)
                    Console.WriteLine($"  {eh.HandlerType} try[{Off(eh.TryStart)}..{Off(eh.TryEnd)}] handler[{Off(eh.HandlerStart)}..{Off(eh.HandlerEnd)}] filter[{Off(eh.FilterStart)}] catch={eh.CatchType}");
                Console.WriteLine("IL:");
                foreach (var ins in b.Instructions)
                    Console.WriteLine($"  IL_{ins.Offset:X4}: {ins.OpCode} {OperandStr(ins.Operand)}");
            }
            return 0;
        }
        if (args.Length < 3)
        {
            Console.Error.WriteLine("usage: reinject <target.exe> <source.dll> <output.exe> [--types A,B,C]");
            return 2;
        }
        string targetPath = args[0], sourcePath = args[1], outPath = args[2];
        var typeFilter = new HashSet<string>(new[]
            { "SR", "SecurityCenter", "TCPClient", "GetRegistrycreatedtime", "MySWDM" });
        HashSet<string> methodFilter = null;   // null = all methods
        HashSet<string> methodExclude = new HashSet<string>(StringComparer.Ordinal);
        bool listOnly = false;
        bool noOpt = false;
        bool preserve = false;
        bool allowFuzzyMatch = false;
        for (int i = 3; i < args.Length; i++)
        {
            if (args[i] == "--noopt") { noOpt = true; continue; }
            if (args[i] == "--preserve") { preserve = true; continue; }
            if (args[i] == "--allow-fuzzy-match") { allowFuzzyMatch = true; continue; }
            if (args[i] == "--types" && i + 1 < args.Length)
                typeFilter = new HashSet<string>(args[++i].Split(',').Select(s => s.Trim()));
            else if (args[i] == "--methods" && i + 1 < args.Length)
                methodFilter = new HashSet<string>(args[++i].Split(',').Select(s => s.Trim()), StringComparer.Ordinal);
            else if (args[i] == "--exclude" && i + 1 < args.Length)
                methodExclude = new HashSet<string>(args[++i].Split(',').Select(s => s.Trim()), StringComparer.Ordinal);
            else if (args[i] == "--list")
                listOnly = true;
        }

        var target = ModuleDefMD.Load(targetPath);
        var source = ModuleDefMD.Load(sourcePath);
        Matcher.AllowFuzzyMatch = allowFuzzyMatch;
        var mapper = new RedirectMapper(target, source);
        var importer = new Importer(target,
            ImporterOptions.TryToUseTypeDefs | ImporterOptions.TryToUseMethodDefs | ImporterOptions.TryToUseFieldDefs,
            new GenericParamContext(), mapper);

        int replaced = 0, skipped = 0, missingTargets = 0;
        foreach (var st in source.GetTypes())
        {
            if (st.IsGlobalModuleType) continue;
            string simple = st.Name.String;
            if (!typeFilter.Contains(simple)) continue;

            var tt = target.GetTypes().FirstOrDefault(t => t.FullName == st.FullName);
            if (tt == null)
            {
                Console.Error.WriteLine($"  ! no target type {st.FullName}");
                missingTargets++;
                continue;
            }

            foreach (var sm in st.Methods)
            {
                if (sm.Body == null || !sm.HasBody) { skipped++; continue; }   // extern / pinvoke / abstract
                if (simple == "MySWDM" && sm.Name == ".ctor") { skipped++; continue; } // keep Document Manager initialization from the target exe
                if (listOnly) { Console.WriteLine($"  {st.Name}::{sm.Name}"); continue; }
                if (methodFilter != null && !methodFilter.Contains(sm.Name.String)) continue;
                if (methodExclude.Contains(sm.Name.String)) continue;
                var tm = Matcher.FindMethod(tt, sm);
                if (tm == null)
                {
                    Console.Error.WriteLine($"  ! no target method {st.Name}::{sm.Name}");
                    missingTargets++;
                    continue;
                }
                CopyBody(sm, tm, importer, mapper, noOpt);
                replaced++;
            }
        }

        if (listOnly)
        {
            Console.WriteLine($"listed: candidate methods only (no write)");
            return missingTargets > 0 ? 1 : 0;
        }

        if (missingTargets > 0)
        {
            Console.Error.WriteLine($"ERROR: missing target types/methods = {missingTargets}; output not written");
            return 1;
        }

        var opts = new dnlib.DotNet.Writer.ModuleWriterOptions(target);
        if (preserve)
            opts.MetadataOptions.Flags |= dnlib.DotNet.Writer.MetadataFlags.PreserveAll | dnlib.DotNet.Writer.MetadataFlags.KeepOldMaxStack;
        target.Write(outPath, opts);
        Console.WriteLine($"reinjected: methods replaced={replaced} skipped(extern)={skipped} -> {outPath}");
        return 0;
    }

    private static string Off(Instruction i) => i == null ? "end" : $"IL_{i.Offset:X4}";
    private static string OperandStr(object o)
    {
        switch (o)
        {
            case null: return "";
            case Instruction t: return Off(t);
            case Instruction[] ts: return "[" + string.Join(",", ts.Select(Off)) + "]";
            case Local lv: return $"local[{lv.Index}]";
            case Parameter p: return $"arg[{p.Index}]({(p.IsHiddenThisParameter ? "this" : p.Name)})";
            case string s: return "\"" + s + "\"";
            default: return o.ToString();
        }
    }

    private static void CopyBody(MethodDef src, MethodDef dst, Importer importer, RedirectMapper mapper, bool noOpt = false)
    {
        var sb = src.Body;
        var nb = new CilBody { InitLocals = sb.InitLocals, MaxStack = sb.MaxStack };

        // locals
        var localMap = new Dictionary<Local, Local>();
        foreach (var l in sb.Variables)
        {
            var nl = new Local(importer.Import(l.Type), l.Name);
            nb.Variables.Add(nl);
            localMap[l] = nl;
        }

        // instructions: clone first (no operands), then fix up
        var map = new Dictionary<Instruction, Instruction>();
        foreach (var ins in sb.Instructions)
        {
            var ni = new Instruction(ins.OpCode) { SequencePoint = null };
            nb.Instructions.Add(ni);
            map[ins] = ni;
        }

        var dstParams = dst.Parameters;
        for (int i = 0; i < sb.Instructions.Count; i++)
        {
            var o = sb.Instructions[i].Operand;
            var ni = nb.Instructions[i];
            switch (o)
            {
                case null: ni.Operand = null; break;
                case Instruction t: ni.Operand = map[t]; break;
                case Instruction[] ts: ni.Operand = ts.Select(x => map[x]).ToArray(); break;
                case Local lv: ni.Operand = localMap[lv]; break;
                case Parameter p: ni.Operand = dstParams[p.Index]; break;
                case IMethod m: ni.Operand = mapper.ResolveMethodOperand(m) ?? importer.Import(m); break;
                case IField f: ni.Operand = mapper.ResolveFieldOperand(f) ?? importer.Import(f); break;
                case ITypeDefOrRef ty: ni.Operand = importer.Import(ty); break;
                case TypeSig ts: ni.Operand = importer.Import(ts); break;
                default: ni.Operand = o; break; // string / numeric literals
            }
        }

        // exception handlers
        foreach (var eh in sb.ExceptionHandlers)
        {
            nb.ExceptionHandlers.Add(new ExceptionHandler(eh.HandlerType)
            {
                TryStart = eh.TryStart != null ? map[eh.TryStart] : null,
                TryEnd = eh.TryEnd != null ? map[eh.TryEnd] : null,
                HandlerStart = eh.HandlerStart != null ? map[eh.HandlerStart] : null,
                HandlerEnd = eh.HandlerEnd != null ? map[eh.HandlerEnd] : null,
                FilterStart = eh.FilterStart != null ? map[eh.FilterStart] : null,
                CatchType = eh.CatchType != null ? importer.Import(eh.CatchType) : null,
            });
        }

        dst.Body = nb;
        if (!noOpt)
        {
            nb.OptimizeBranches();
            nb.OptimizeMacros();
        }
    }
}
