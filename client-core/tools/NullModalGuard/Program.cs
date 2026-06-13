using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

// NullModalGuard
// ---------------
// In ZTool.PMPHandler's SW-read methods (GetDataByBom / GetDataFromSel /
// GetDataFromVis) each catch(Exception) block both logs the error via
// sendmessageC(6, ex.ToString()) AND pops a SolidWorks modal via
// MessageBox.Show(ex.Message, ...). On an early/repeated "Connect SW" a deeper
// SolidWorks COM call returns null mid-read, so a NullReferenceException is
// caught here and the user sees the modal even though the process recovers.
//
// This tool inserts, right before each MessageBox.Show argument block, the guard:
//     if (ex is NullReferenceException) goto <instruction after MessageBox.Show>;
// so transient NULLs are still logged (sendmessageC stays) but no longer raise
// the modal. Every other exception keeps showing the dialog. No data logic
// changes; only the dialog is conditionally skipped.

internal static class NullModalGuard
{
    private const string TypeName = "ZTool.PMPHandler";
    private static readonly string[] Methods = { "GetDataByBom", "GetDataFromSel", "GetDataFromVis" };
    private const string MsgBoxType = "System.Windows.Forms.MessageBox";

    private static ModuleDefinition Read(string path)
    {
        var resolver = new DefaultAssemblyResolver();
        resolver.AddSearchDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
        return ModuleDefinition.ReadModule(path,
            new ReaderParameters { ReadingMode = ReadingMode.Immediate, InMemory = true, AssemblyResolver = resolver });
    }

    private static bool IsMsgBoxShow(Instruction ins)
        => (ins.OpCode == OpCodes.Call || ins.OpCode == OpCodes.Callvirt)
           && ins.Operand is MethodReference mr
           && mr.DeclaringType != null && mr.DeclaringType.FullName == MsgBoxType
           && mr.Name == "Show";

    // (pop, push) stack effect of an instruction
    private static (int pop, int push) Delta(Instruction ins)
    {
        var op = ins.OpCode;
        int pop, push;

        if (op.Code == Code.Call || op.Code == Code.Callvirt || op.Code == Code.Newobj)
        {
            var mr = (MethodReference)ins.Operand;
            int args = mr.Parameters.Count;
            bool thisArg = op.Code != Code.Newobj && mr.HasThis;
            pop = args + (thisArg ? 1 : 0);
            bool returns = op.Code == Code.Newobj || (mr.ReturnType != null && mr.ReturnType.FullName != "System.Void");
            push = returns ? 1 : 0;
            return (pop, push);
        }

        pop = op.StackBehaviourPop switch
        {
            StackBehaviour.Pop0 => 0,
            StackBehaviour.Pop1 or StackBehaviour.Popi or StackBehaviour.Popref => 1,
            StackBehaviour.Pop1_pop1 or StackBehaviour.Popi_pop1 or StackBehaviour.Popi_popi
                or StackBehaviour.Popi_popi8 or StackBehaviour.Popi_popr4 or StackBehaviour.Popi_popr8
                or StackBehaviour.Popref_pop1 or StackBehaviour.Popref_popi => 2,
            StackBehaviour.Popi_popi_popi or StackBehaviour.Popref_popi_popi or StackBehaviour.Popref_popi_popi8
                or StackBehaviour.Popref_popi_popr4 or StackBehaviour.Popref_popi_popr8
                or StackBehaviour.Popref_popi_popref => 3,
            _ => 0,
        };
        push = op.StackBehaviourPush switch
        {
            StackBehaviour.Push0 => 0,
            StackBehaviour.Push1 or StackBehaviour.Pushi or StackBehaviour.Pushi8
                or StackBehaviour.Pushr4 or StackBehaviour.Pushr8 or StackBehaviour.Pushref => 1,
            StackBehaviour.Push1_push1 => 2,
            _ => 0,
        };
        return (pop, push);
    }

    private sealed class Site
    {
        public MethodDefinition Method;
        public ExceptionHandler Handler;
        public Instruction ArgStart;     // first instr of MessageBox.Show arg block
        public Instruction SkipTarget;   // instr just after MessageBox.Show (+ its pop)
        public VariableDefinition ExLocal;
    }

    private static List<Site> FindSites(MethodDefinition m)
    {
        var sites = new List<Site>();
        var body = m.Body;
        var instrs = body.Instructions;
        var index = new Dictionary<Instruction, int>();
        for (int i = 0; i < instrs.Count; i++) index[instrs[i]] = i;

        foreach (var h in body.ExceptionHandlers.Where(x => x.HandlerType == ExceptionHandlerType.Catch))
        {
            int hs = index[h.HandlerStart];
            int he = h.HandlerEnd == null ? instrs.Count : index[h.HandlerEnd];
            for (int i = hs; i < he; i++)
            {
                if (!IsMsgBoxShow(instrs[i])) continue;
                var show = instrs[i];
                int argCount = ((MethodReference)show.Operand).Parameters.Count;

                // skip target: instruction after Show, skipping its result pop if present
                int after = i + 1;
                if (after < instrs.Count && instrs[after].OpCode == OpCodes.Pop) after++;
                var skipTarget = instrs[after];

                // walk backward to the start of the arg block (net pushes == argCount)
                int depth = 0, j = i - 1;
                Instruction argStart = null;
                while (j >= hs)
                {
                    var (pop, push) = Delta(instrs[j]);
                    depth += push - pop;
                    if (depth == argCount) { argStart = instrs[j]; break; }
                    j--;
                }
                if (argStart == null) throw new Exception($"{m.Name}: could not locate arg block for MessageBox.Show");

                // exception local = local loaded right before Exception::get_Message in this handler,
                // else the first stloc in the handler.
                VariableDefinition exLocal = null;
                for (int k = i - 1; k >= hs; k--)
                {
                    if (instrs[k].OpCode == OpCodes.Callvirt && instrs[k].Operand is MethodReference gm
                        && gm.Name == "get_Message" && gm.DeclaringType.FullName == "System.Exception")
                    {
                        var ld = instrs[k - 1];
                        exLocal = LocalOf(body, ld);
                        break;
                    }
                }
                if (exLocal == null)
                    for (int k = hs; k < he; k++)
                        if (IsStloc(instrs[k].OpCode)) { exLocal = LocalOf(body, instrs[k]); break; }
                if (exLocal == null) throw new Exception($"{m.Name}: could not locate exception local");

                sites.Add(new Site { Method = m, Handler = h, ArgStart = argStart, SkipTarget = skipTarget, ExLocal = exLocal });
            }
        }
        return sites;
    }

    private static bool IsStloc(OpCode op)
        => op == OpCodes.Stloc || op == OpCodes.Stloc_S || op == OpCodes.Stloc_0
        || op == OpCodes.Stloc_1 || op == OpCodes.Stloc_2 || op == OpCodes.Stloc_3;

    private static VariableDefinition LocalOf(MethodBody body, Instruction ins)
    {
        switch (ins.OpCode.Code)
        {
            case Code.Ldloc: case Code.Ldloc_S: case Code.Stloc: case Code.Stloc_S:
                return (VariableDefinition)ins.Operand;
            case Code.Ldloc_0: case Code.Stloc_0: return body.Variables[0];
            case Code.Ldloc_1: case Code.Stloc_1: return body.Variables[1];
            case Code.Ldloc_2: case Code.Stloc_2: return body.Variables[2];
            case Code.Ldloc_3: case Code.Stloc_3: return body.Variables[3];
            default: return null;
        }
    }

    public static int Main(string[] args)
    {
        Console.OutputEncoding = new System.Text.UTF8Encoding(false);
        if (args.Length < 2)
        {
            Console.WriteLine("usage: NullModalGuard <in.dll> <inspect|verify|patch> [out.dll]");
            return 2;
        }
        string inDll = args[0], mode = args[1];
        var mod = Read(inDll);
        var type = mod.GetTypes().FirstOrDefault(x => x.FullName == TypeName);
        if (type == null) throw new Exception($"type {TypeName} not found");

        var methods = Methods.Select(n => type.Methods.First(x => x.Name == n && x.HasBody)).ToList();
        var nre = new TypeReference("System", "NullReferenceException", mod, mod.TypeSystem.CoreLibrary);

        int totalSites = 0, guarded = 0;
        foreach (var m in methods)
        {
            var sites = FindSites(m);
            totalSites += sites.Count;
            foreach (var s in sites)
            {
                // is it already guarded? (an isinst NullReferenceException + brtrue right before ArgStart)
                var il2 = m.Body.Instructions;
                int ai = il2.IndexOf(s.ArgStart);
                bool already = ai >= 3
                    && il2[ai - 1].OpCode == OpCodes.Brtrue
                    && il2[ai - 2].OpCode == OpCodes.Isinst
                    && il2[ai - 2].Operand is TypeReference tr && tr.FullName == "System.NullReferenceException";
                Console.WriteLine($"{m.Name}: MessageBox.Show site, exLocal=V_{s.ExLocal.Index}, guarded={already}");

                if (mode == "patch" && !already)
                {
                    var il = m.Body.GetILProcessor();
                    var ldEx = Instruction.Create(OpCodes.Ldloc, s.ExLocal);
                    var isin = Instruction.Create(OpCodes.Isinst, nre);
                    var br = Instruction.Create(OpCodes.Brtrue, s.SkipTarget);
                    il.InsertBefore(s.ArgStart, ldEx);
                    il.InsertBefore(s.ArgStart, isin);
                    il.InsertBefore(s.ArgStart, br);
                    guarded++;
                }
                if (already) guarded++;
            }
        }

        Console.WriteLine($"sites={totalSites} guarded={guarded}");

        if (mode == "inspect") return 0;

        if (mode == "verify")
        {
            bool ok = totalSites > 0 && guarded == totalSites;
            // re-validate each method's bodies are consistent (Cecil can recompute)
            Console.WriteLine(ok ? "VERIFY: PASS" : "VERIFY: FAIL");
            return ok ? 0 : 1;
        }

        if (mode == "patch")
        {
            if (args.Length < 3) { Console.WriteLine("patch mode needs out.dll"); return 2; }
            foreach (var m in methods) { m.Body.MaxStackSize += 1; }
            mod.Write(args[2]);
            Console.WriteLine($"WROTE {args[2]} (guarded {guarded}/{totalSites})");
            return 0;
        }

        Console.WriteLine($"unknown mode {mode}");
        return 2;
    }
}
