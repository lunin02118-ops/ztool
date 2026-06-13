using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

internal static class DefPatch
{
    private const string TypeName = "ZTool.PMPHandler";
    private const string MethodName = "DefWndProc";

    private static MethodDefinition FindMethod(ModuleDefinition mod)
    {
        var t = mod.GetTypes().FirstOrDefault(x => x.FullName == TypeName);
        if (t == null) throw new Exception($"type {TypeName} not found");
        var m = t.Methods.FirstOrDefault(x => x.Name == MethodName && x.HasBody);
        if (m == null) throw new Exception($"method {MethodName} not found");
        return m;
    }

    private static ModuleDefinition Read(string path)
    {
        var resolver = new DefaultAssemblyResolver();
        resolver.AddSearchDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
        foreach (var d in new[] {
            @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319",
            @"C:\Windows\Microsoft.NET\Framework\v4.0.30319" })
            if (Directory.Exists(d)) resolver.AddSearchDirectory(d);
        var rp = new ReaderParameters
        {
            ReadingMode = ReadingMode.Immediate,
            InMemory = true,
            AssemblyResolver = resolver,
        };
        return ModuleDefinition.ReadModule(path, rp);
    }

    public static int Main(string[] args)
    {
        Console.OutputEncoding = new System.Text.UTF8Encoding(false);
        if (args.Length < 2)
        {
            Console.WriteLine("usage: defpatch <in.dll> <inspect|patch> [out.dll]");
            return 2;
        }
        string inDll = args[0], mode = args[1];
        var mod = Read(inDll);
        var m = FindMethod(mod);
        var body = m.Body;

        var an = mod.Assembly.Name;
        string tok = an.HasPublicKey && an.PublicKeyToken != null && an.PublicKeyToken.Length > 0
            ? string.Concat(an.PublicKeyToken.Select(b => b.ToString("x2"))) : "(none)";
        int retCount = body.Instructions.Count(i => i.OpCode == OpCodes.Ret);
        Console.WriteLine($"asm={an.Name} ver={an.Version} pkt={tok} hasStrongName={an.HasPublicKey}");
        Console.WriteLine($"{TypeName}.{MethodName}: instrs={body.Instructions.Count} rets={retCount} " +
                          $"maxstack={body.MaxStackSize} handlers={body.ExceptionHandlers.Count} initLocals={body.InitLocals}");

        if (mode == "inspect")
            return 0;

        if (mode == "verify")
        {
            int problems = 0;
            void Check(bool ok, string label)
            {
                Console.WriteLine($"  [{(ok ? "OK" : "FAIL")}] {label}");
                if (!ok) problems++;
            }
            var instrs = body.Instructions;
            var last = instrs[instrs.Count - 1];
            Check(body.ExceptionHandlers.Count == 1, "exactly 1 exception handler");
            var h = body.ExceptionHandlers.Count == 1 ? body.ExceptionHandlers[0] : null;
            Check(h != null && h.HandlerType == ExceptionHandlerType.Catch, "handler is a catch");
            Check(h != null && h.CatchType != null && h.CatchType.FullName == "System.Exception",
                  "catch type == System.Exception");
            Check(h != null && h.TryStart == instrs[0], "try starts at first instruction");
            Check(h != null && h.HandlerStart == h.TryEnd, "try-end meets handler-start");
            Check(h != null && h.HandlerStart.OpCode == OpCodes.Pop, "handler begins with pop");
            Check(last.OpCode == OpCodes.Ret, "method ends with ret");
            Check(h != null && h.HandlerEnd == last, "handler-end == final ret");
            Check(instrs.Count(i => i.OpCode == OpCodes.Ret) == 1, "exactly one ret total");
            bool leavesOk = instrs.Where(i => i.OpCode == OpCodes.Leave || i.OpCode == OpCodes.Leave_S)
                                  .All(i => i.Operand == last);
            Check(leavesOk, "every leave targets the final ret");
            Console.WriteLine(problems == 0 ? "VERIFY: PASS" : $"VERIFY: FAIL ({problems})");
            return problems == 0 ? 0 : 1;
        }

        if (mode != "patch")
        {
            Console.WriteLine($"unknown mode {mode}");
            return 2;
        }
        if (args.Length < 3)
        {
            Console.WriteLine("patch mode needs out.dll");
            return 2;
        }
        string outDll = args[2];

        // Build a TypeReference to System.Exception bound to the TARGET's corlib
        // (do NOT import typeof(Exception) -> that would drag in the patcher's
        // .NET 8 System.Private.CoreLib instead of the target's mscorlib).
        var exType = new TypeReference("System", "Exception", mod, mod.TypeSystem.CoreLibrary);

        var il = body.GetILProcessor();
        var first = body.Instructions[0];

        var finalRet = Instruction.Create(OpCodes.Ret);
        var popInstr = Instruction.Create(OpCodes.Pop);          // discard caught exception
        var leaveFromCatch = Instruction.Create(OpCodes.Leave, finalRet);

        // A `ret` is illegal inside a protected region; convert every existing
        // ret to `leave finalRet` so control exits the try cleanly.
        foreach (var ins in body.Instructions.ToList())
        {
            if (ins.OpCode == OpCodes.Ret)
            {
                ins.OpCode = OpCodes.Leave;
                ins.Operand = finalRet;
            }
        }

        il.Append(popInstr);
        il.Append(leaveFromCatch);
        il.Append(finalRet);

        var handler = new ExceptionHandler(ExceptionHandlerType.Catch)
        {
            CatchType = exType,
            TryStart = first,
            TryEnd = popInstr,       // exclusive end of try == first handler instr
            HandlerStart = popInstr,
            HandlerEnd = finalRet,   // exclusive end of handler
        };
        // Outer handler must come AFTER any inner (smaller) handlers in the table.
        body.ExceptionHandlers.Add(handler);

        body.MaxStackSize = Math.Max(body.MaxStackSize, 8);

        var wp = new WriterParameters();
        mod.Write(outDll, wp);
        Console.WriteLine($"wrote {outDll}: wrapped {TypeName}.{MethodName} in try/catch(System.Exception)");
        return 0;
    }
}
