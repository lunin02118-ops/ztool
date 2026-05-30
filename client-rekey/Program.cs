using System;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

class Program
{
    static string R(string dir, string name) => File.ReadAllText(Path.Combine(dir, name)).Trim();

    static int Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.Error.WriteLine("usage: patcher <in.exe> <out.exe> <valuesDir>");
            return 2;
        }
        string inPath = args[0], outPath = args[1], dir = args[2];

        string origKey = R(dir, "orig_key.txt"), newKey = R(dir, "new_key.txt");
        string origIp = R(dir, "orig_ip.txt"), newIp = R(dir, "new_ip.txt");
        string origPort = R(dir, "orig_port.txt"), newPort = R(dir, "new_port.txt");

        var module = ModuleDefMD.Load(inPath);

        int keyHits = 0, ipHits = 0, portHits = 0;

        foreach (var type in module.GetTypes())
        {
            foreach (var m in type.Methods)
            {
                if (m.Body == null || !m.HasBody) continue;
                foreach (var instr in m.Body.Instructions)
                {
                    if (instr.OpCode != OpCodes.Ldstr) continue;
                    var s = instr.Operand as string;
                    if (s == null) continue;
                    if (s == origKey) { instr.Operand = newKey; keyHits++; }
                    else if (s == origIp) { instr.Operand = newIp; ipHits++; }
                    else if (s == origPort) { instr.Operand = newPort; portHits++; }
                }
            }
            // const string fields
            foreach (var f in type.Fields)
            {
                if (f.Constant == null) continue;
                if (f.Constant.Value is string cs)
                {
                    if (cs == origKey) { f.Constant.Value = newKey; keyHits++; }
                    else if (cs == origIp) { f.Constant.Value = newIp; ipHits++; }
                    else if (cs == origPort) { f.Constant.Value = newPort; portHits++; }
                }
            }
        }

        // Version -> 1.0
        var asm = module.Assembly;
        bool fileVerUpdated = false, infoVerUpdated = false;
        var strType = module.CorLibTypes.String;
        foreach (var ca in asm.CustomAttributes)
        {
            var tn = ca.TypeFullName;
            if (tn.Contains("AssemblyFileVersionAttribute") && ca.ConstructorArguments.Count == 1)
            {
                ca.ConstructorArguments[0] = new CAArgument(strType, "1.0");
                fileVerUpdated = true;
            }
            else if (tn.Contains("AssemblyInformationalVersionAttribute") && ca.ConstructorArguments.Count == 1)
            {
                ca.ConstructorArguments[0] = new CAArgument(strType, "1.0");
                infoVerUpdated = true;
            }
        }
        if (!infoVerUpdated)
        {
            var attrTypeRef = new TypeRefUser(module, "System.Reflection",
                "AssemblyInformationalVersionAttribute", module.CorLibTypes.AssemblyRef);
            var ctorSig = MethodSig.CreateInstance(module.CorLibTypes.Void, strType);
            var ctor = new MemberRefUser(module, ".ctor", ctorSig, attrTypeRef);
            var ca = new CustomAttribute(ctor);
            ca.ConstructorArguments.Add(new CAArgument(strType, "1.0"));
            asm.CustomAttributes.Add(ca);
            infoVerUpdated = true;
        }

        Console.WriteLine($"keyHits={keyHits} ipHits={ipHits} portHits={portHits} fileVerUpdated={fileVerUpdated} infoVerAdded={infoVerUpdated}");

        if (keyHits == 0 || ipHits == 0 || portHits == 0)
        {
            Console.Error.WriteLine("ERROR: one or more targets not found; aborting without writing.");
            return 1;
        }

        var opts = new ModuleWriterOptions(module);
        opts.MetadataOptions.Flags |= MetadataFlags.PreserveAll | MetadataFlags.KeepOldMaxStack;
        // drop strong-name signing (de-obfuscated assembly is not re-signable without the key)
        module.Write(outPath, opts);
        Console.WriteLine("written: " + outPath);
        return 0;
    }
}
