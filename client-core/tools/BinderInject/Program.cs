using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// BinderInject: make ZTool.exe's BinaryFormatter deserialization version-tolerant.
//
// BinaryFormatter blobs embed the full assembly identity (Name, Version, Culture,
// PublicKeyToken) of every type. Config blobs (Font/Color via code.DeserializeBinary,
// DataTable via code.DeserializeObject) written under one runtime fail to bind under
// another (e.g. SolidWorks 2025's framework versions) -> SerializationException.
//
// This tool:
//   1. copies a compiled ZTool.VTBinder : SerializationBinder out of a donor DLL
//      into ZTool.exe (no hand-written IL),
//   2. inserts `formatter.Binder = new VTBinder();` right after the BinaryFormatter
//      is constructed inside code.DeserializeBinary and code.DeserializeObject.
//
// VTBinder binds types by short assembly name against what is actually loaded,
// ignoring Version/Culture/PublicKeyToken. On a miss it returns null and the
// formatter falls back to its default binding (no behaviour change otherwise).
//
// usage:
//   binderinject patch  <target ZTool.exe> <donor ZBinderDonor.dll> <out ZTool.exe>
//   binderinject verify <ZTool.exe>

internal static class Program
{
    private const string CodeType = "ZTool.code";
    private const string BinderType = "ZTool.VTBinder";
    private const string BinaryFormatterFull =
        "System.Runtime.Serialization.Formatters.Binary.BinaryFormatter";

    private static readonly string[] TargetMethods = { "DeserializeBinary", "DeserializeObject" };

    private static int Main(string[] args)
    {
        if (args.Length >= 2 && args[0] == "verify")
            return Verify(args[1]);
        if (args.Length >= 4 && args[0] == "patch")
            return Patch(args[1], args[2], args[3]);
        Console.Error.WriteLine("usage:\n  binderinject patch <target.exe> <donor.dll> <out.exe>\n  binderinject verify <exe>");
        return 2;
    }

    private static int Patch(string targetPath, string donorPath, string outPath)
    {
        var target = ModuleDefMD.Load(targetPath);
        var donor = ModuleDefMD.Load(donorPath);
        var importer = new Importer(target,
            ImporterOptions.TryToUseTypeDefs | ImporterOptions.TryToUseMethodDefs | ImporterOptions.TryToUseFieldDefs,
            new GenericParamContext());

        if (target.Find(BinderType, false) != null)
        {
            Console.Error.WriteLine($"! {BinderType} already present in target; aborting (already patched?)");
            return 1;
        }

        // 1) transplant ZTool.VTBinder from the donor into the target exe.
        var donorBinder = donor.Find(BinderType, false);
        if (donorBinder == null) { Console.Error.WriteLine($"! donor has no {BinderType}"); return 1; }
        var binderCtor = CopyType(donorBinder, target, importer);
        Console.WriteLine($"injected type {BinderType}  (methods: {string.Join(", ", donorBinder.Methods.Select(m => m.Name.String))})");

        // set_Binder member refs (mscorlib).
        var corlib = target.CorLibTypes.AssemblyRef;
        var trBinder = new TypeRefUser(target, "System.Runtime.Serialization", "SerializationBinder", corlib);
        var trIFormatter = new TypeRefUser(target, "System.Runtime.Serialization", "IFormatter", corlib);
        var trBinaryFormatter = new TypeRefUser(target, "System.Runtime.Serialization.Formatters.Binary", "BinaryFormatter", corlib);
        var setBinderSig = MethodSig.CreateInstance(target.CorLibTypes.Void, trBinder.ToTypeSig());
        var setBinderIFormatter = new MemberRefUser(target, "set_Binder", setBinderSig, trIFormatter);
        var setBinderBinaryFormatter = new MemberRefUser(target, "set_Binder", setBinderSig, trBinaryFormatter);

        // 2) wire the binder into the two deserialization helpers.
        var codeType = target.Find(CodeType, false);
        if (codeType == null) { Console.Error.WriteLine($"! target has no {CodeType}"); return 1; }
        int wired = 0;
        foreach (var name in TargetMethods)
        {
            var m = codeType.Methods.FirstOrDefault(x => x.Name == name && x.HasBody);
            if (m == null) { Console.Error.WriteLine($"! no {CodeType}::{name}"); return 1; }
            if (!WireBinder(m, binderCtor, setBinderIFormatter, setBinderBinaryFormatter))
            {
                Console.Error.WriteLine($"! could not find BinaryFormatter construction in {name}");
                return 1;
            }
            wired++;
            Console.WriteLine($"wired binder into {CodeType}::{name}");
        }

        target.Write(outPath);
        Console.WriteLine($"OK: injected 1 type, wired {wired} methods -> {outPath}");
        return 0;
    }

    // Find `newobj BinaryFormatter::.ctor()` then the store that follows, and insert
    //   ldloc <fmt>; newobj VTBinder::.ctor(); callvirt set_Binder
    // right after the store.
    private static bool WireBinder(MethodDef m, MethodDef binderCtor,
        MemberRef setBinderIFormatter, MemberRef setBinderBinaryFormatter)
    {
        var instrs = m.Body.Instructions;
        for (int i = 0; i < instrs.Count - 1; i++)
        {
            var ins = instrs[i];
            if (ins.OpCode.Code != Code.Newobj) continue;
            if (!(ins.Operand is IMethod ctor) || ctor.Name != ".ctor") continue;
            if (ctor.DeclaringType?.FullName != BinaryFormatterFull) continue;

            var store = instrs[i + 1];
            var local = StLocLocal(store, m.Body);
            if (local == null) continue;

            var setter = local.Type != null && local.Type.FullName == BinaryFormatterFull
                ? setBinderBinaryFormatter
                : setBinderIFormatter;

            int at = i + 2;
            instrs.Insert(at + 0, Instruction.Create(OpCodes.Ldloc, local));
            instrs.Insert(at + 1, Instruction.Create(OpCodes.Newobj, binderCtor));
            instrs.Insert(at + 2, Instruction.Create(OpCodes.Callvirt, setter));

            if (m.Body.MaxStack < 3) m.Body.MaxStack = 3;
            m.Body.OptimizeBranches();
            m.Body.OptimizeMacros();
            return true;
        }
        return false;
    }

    private static Local StLocLocal(Instruction ins, CilBody body)
    {
        switch (ins.OpCode.Code)
        {
            case Code.Stloc_0: return body.Variables[0];
            case Code.Stloc_1: return body.Variables[1];
            case Code.Stloc_2: return body.Variables[2];
            case Code.Stloc_3: return body.Variables[3];
            case Code.Stloc:
            case Code.Stloc_S: return ins.Operand as Local;
            default: return null;
        }
    }

    // Recreate a (simple, non-generic) TypeDef from the donor inside the target and
    // return the injected instance .ctor. Method bodies are cloned via CopyBody;
    // all operands resolve to framework refs imported into the target.
    private static MethodDef CopyType(TypeDef src, ModuleDef target, Importer importer)
    {
        var baseType = importer.Import(src.BaseType);
        var nt = new TypeDefUser(src.Namespace, src.Name, baseType) { Attributes = src.Attributes };
        target.Types.Add(nt);

        MethodDef ctor = null;
        foreach (var sm in src.Methods)
        {
            var ret = importer.Import(sm.MethodSig.RetType);
            var pars = sm.MethodSig.Params.Select(p => importer.Import(p)).ToArray();
            var sig = sm.MethodSig.HasThis
                ? MethodSig.CreateInstance(ret, pars)
                : MethodSig.CreateStatic(ret, pars);
            var nm = new MethodDefUser(sm.Name, sig, sm.ImplAttributes, sm.Attributes);
            nm.Parameters.UpdateParameterTypes();
            nt.Methods.Add(nm);
            CopyBody(sm, nm, importer);
            if (sm.Name == ".ctor") ctor = nm;
        }
        if (ctor == null) throw new Exception($"donor type {src.FullName} has no .ctor");
        return ctor;
    }

    private static void CopyBody(MethodDef src, MethodDef dst, Importer importer)
    {
        var sb = src.Body;
        var nb = new CilBody { InitLocals = sb.InitLocals, MaxStack = sb.MaxStack };

        var localMap = new Dictionary<Local, Local>();
        foreach (var l in sb.Variables)
        {
            var nl = new Local(importer.Import(l.Type), l.Name);
            nb.Variables.Add(nl);
            localMap[l] = nl;
        }

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
                case IMethod im: ni.Operand = importer.Import(im); break;
                case IField f: ni.Operand = importer.Import(f); break;
                case ITypeDefOrRef ty: ni.Operand = importer.Import(ty); break;
                case TypeSig tsig: ni.Operand = importer.Import(tsig); break;
                default: ni.Operand = o; break; // string / numeric literals
            }
        }

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
        nb.OptimizeBranches();
        nb.OptimizeMacros();
    }

    private static int Verify(string path)
    {
        var m = ModuleDefMD.Load(path);
        int rc = 0;

        var binder = m.Find(BinderType, false);
        if (binder == null) { Console.WriteLine($"! missing type {BinderType}"); rc = 1; }
        else
        {
            bool overrides = binder.Methods.Any(x => x.Name == "BindToType" && x.IsVirtual && x.HasBody);
            Console.WriteLine($"type {BinderType}: present, BindToType override={(overrides ? "yes" : "NO")}");
            if (!overrides) rc = 1;
        }

        var codeType = m.Find(CodeType, false);
        if (codeType == null) { Console.WriteLine($"! missing type {CodeType}"); return 1; }
        foreach (var name in TargetMethods)
        {
            var md = codeType.Methods.FirstOrDefault(x => x.Name == name && x.HasBody);
            if (md == null) { Console.WriteLine($"! missing {CodeType}::{name}"); rc = 1; continue; }
            int sites = 0;
            var ins = md.Body.Instructions;
            for (int i = 0; i < ins.Count; i++)
            {
                if (ins[i].OpCode.Code == Code.Newobj && ins[i].Operand is IMethod c
                    && c.Name == ".ctor" && c.DeclaringType?.FullName == BinderType)
                {
                    // followed (after the newobj) by callvirt set_Binder
                    if (i + 1 < ins.Count && ins[i + 1].Operand is IMethod sb2 && sb2.Name == "set_Binder")
                        sites++;
                }
            }
            Console.WriteLine($"{CodeType}::{name}: binder-wire sites={sites}");
            if (sites < 1) rc = 1;
        }
        Console.WriteLine(rc == 0 ? "VERIFY: PASS" : "VERIFY: FAIL");
        return rc;
    }
}
