using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

internal static class AddinBrandPatch
{
    private const string TypeName = "ZTool.SwAddin";
    private const string OldBrand = "ZTool";
    private const string NewBrand = "SWTools";
    private const string OldDescription = "ZTool — вспомогательные инструменты";
    private const string NewDescription = "SWTools — вспомогательные инструменты";
    private const string LegacyAttributeDescription = "ZTool高效辅助工具";
    private const string NewAttributeDescription = "SWTools SolidWorks Add-in";

    private static ModuleDefinition Read(string path)
    {
        var resolver = new DefaultAssemblyResolver();
        resolver.AddSearchDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
        foreach (var dir in new[]
        {
            @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319",
            @"C:\Windows\Microsoft.NET\Framework\v4.0.30319"
        })
        {
            if (Directory.Exists(dir)) resolver.AddSearchDirectory(dir);
        }

        return ModuleDefinition.ReadModule(path, new ReaderParameters
        {
            ReadingMode = ReadingMode.Immediate,
            InMemory = true,
            AssemblyResolver = resolver,
        });
    }

    private static TypeDefinition FindSwAddin(ModuleDefinition mod)
    {
        var type = mod.GetTypes().FirstOrDefault(t => t.FullName == TypeName);
        if (type == null) throw new Exception($"type {TypeName} not found");
        return type;
    }

    private static MethodDefinition FindMethod(TypeDefinition type, string name)
    {
        var method = type.Methods.FirstOrDefault(m => m.Name == name && m.HasBody);
        if (method == null) throw new Exception($"method {TypeName}.{name} not found");
        return method;
    }

    private static int PatchSwAddinAttribute(TypeDefinition type)
    {
        int changed = 0;
        foreach (var attr in type.CustomAttributes.Where(a => a.AttributeType.Name == "SwAddinAttribute"))
        {
            changed += PatchNamedArguments(attr.Properties);
            changed += PatchNamedArguments(attr.Fields);
        }

        return changed;
    }

    private static int PatchNamedArguments(Collection<CustomAttributeNamedArgument> args)
    {
        int changed = 0;
        for (int i = 0; i < args.Count; i++)
        {
            var arg = args[i];
            var value = arg.Argument.Value as string;
            string next = null;
            if (arg.Name == "Title" && value == OldBrand) next = NewBrand;
            if (arg.Name == "Description" && (value == LegacyAttributeDescription || value == OldDescription)) next = NewAttributeDescription;
            if (next == null) continue;

            args[i] = new CustomAttributeNamedArgument(
                arg.Name,
                new CustomAttributeArgument(arg.Argument.Type, next));
            changed++;
        }
        return changed;
    }

    private static int PatchMethodStrings(TypeDefinition type)
    {
        int changed = 0;
        foreach (var methodName in new[] { "AddCommandMgr", "Addin" })
        {
            var method = FindMethod(type, methodName);
            foreach (var ins in method.Body.Instructions.Where(i => i.OpCode == OpCodes.Ldstr))
            {
                var value = ins.Operand as string;
                if (value == OldBrand)
                {
                    ins.Operand = NewBrand;
                    changed++;
                }
                else if (value == OldDescription)
                {
                    ins.Operand = NewDescription;
                    changed++;
                }
            }
        }

        return changed;
    }

    private static int CountLdstr(MethodDefinition method, string value)
    {
        return method.Body.Instructions.Count(i => i.OpCode == OpCodes.Ldstr && string.Equals(i.Operand as string, value, StringComparison.Ordinal));
    }

    private static string GetSwAddinAttributeValue(TypeDefinition type, string propertyName)
    {
        return type.CustomAttributes
            .Where(a => a.AttributeType.Name == "SwAddinAttribute")
            .SelectMany(a => a.Properties.Concat(a.Fields))
            .Where(p => p.Name == propertyName)
            .Select(p => p.Argument.Value as string)
            .FirstOrDefault();
    }

    private static int InspectOrVerify(ModuleDefinition mod, bool verify)
    {
        var type = FindSwAddin(mod);
        var addCommandMgr = FindMethod(type, "AddCommandMgr");
        var addin = FindMethod(type, "Addin");
        var openZtool = FindMethod(type, "openZtool");

        var attrTitle = GetSwAddinAttributeValue(type, "Title");
        var attrDescription = GetSwAddinAttributeValue(type, "Description");

        int addCommandOld = CountLdstr(addCommandMgr, OldBrand);
        int addCommandNew = CountLdstr(addCommandMgr, NewBrand);
        int addCommandOldDescription = CountLdstr(addCommandMgr, OldDescription);
        int addinOld = CountLdstr(addin, OldBrand);
        int addinNew = CountLdstr(addin, NewBrand);
        int openZtoolInternalLookup = CountLdstr(openZtool, OldBrand);

        Console.WriteLine($"SwAddinAttribute.Title={attrTitle}");
        Console.WriteLine($"SwAddinAttribute.Description={attrDescription}");
        Console.WriteLine($"AddCommandMgr ldstr {OldBrand}={addCommandOld}, {NewBrand}={addCommandNew}, oldDescription={addCommandOldDescription}");
        Console.WriteLine($"Addin ldstr {OldBrand}={addinOld}, {NewBrand}={addinNew}");
        Console.WriteLine($"openZtool internal assembly lookup {OldBrand}={openZtoolInternalLookup}");

        if (!verify) return 0;

        int problems = 0;
        void Check(bool ok, string label)
        {
            Console.WriteLine($"  [{(ok ? "OK" : "FAIL")}] {label}");
            if (!ok) problems++;
        }

        Check(attrTitle == NewBrand, "SwAddinAttribute.Title is SWTools");
        Check(!string.IsNullOrWhiteSpace(attrDescription) && attrDescription.Contains(NewBrand) && !attrDescription.Contains(OldBrand),
            "SwAddinAttribute.Description is rebranded");
        Check(addCommandOld == 0, "AddCommandMgr does not create a ZTool tab");
        Check(addCommandNew >= 1, "AddCommandMgr creates an SWTools tab");
        Check(addCommandOldDescription == 0, "AddCommandMgr tooltip is not legacy branded");
        Check(addinOld == 0, "manual Addin registration Title is not ZTool");
        Check(addinNew >= 1, "manual Addin registration Title is SWTools");
        Check(openZtoolInternalLookup >= 1, "openZtool still searches executable by internal assembly name ZTool");

        Console.WriteLine(problems == 0 ? "VERIFY: PASS" : $"VERIFY: FAIL ({problems})");
        return problems == 0 ? 0 : 1;
    }

    public static int Main(string[] args)
    {
        Console.OutputEncoding = new System.Text.UTF8Encoding(false);
        if (args.Length < 2)
        {
            Console.WriteLine("usage:\n  AddinBrandPatch <in.dll> inspect\n  AddinBrandPatch <in.dll> verify\n  AddinBrandPatch <in.dll> patch <out.dll>");
            return 2;
        }

        string input = args[0];
        string mode = args[1];
        var mod = Read(input);

        if (mode == "inspect") return InspectOrVerify(mod, verify: false);
        if (mode == "verify") return InspectOrVerify(mod, verify: true);

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

        var type = FindSwAddin(mod);
        int changed = PatchSwAddinAttribute(type) + PatchMethodStrings(type);
        if (changed == 0)
        {
            Console.WriteLine("nothing changed; input may already be patched");
        }

        mod.Write(args[2], new WriterParameters());
        Console.WriteLine($"WROTE {args[2]} (changed={changed})");
        return 0;
    }
}
