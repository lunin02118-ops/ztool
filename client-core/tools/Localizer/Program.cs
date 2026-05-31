using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// ZTool.exe localizer: surgically replaces user-visible Chinese ldstr operands
// with Russian via an explicit whitelist map. Protocol keys / log strings are
// NOT in the map, so they are left untouched. dnlib rewrites the #US heap, so
// strings of any length are handled correctly (unlike byte patching).
internal static class Program
{
    private static bool HasHan(string s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        foreach (var ch in s)
            if (ch >= 0x4E00 && ch <= 0x9FFF) return true;
        return false;
    }

    private static string Show(string s)
    {
        var sb = new StringBuilder();
        foreach (var ch in s)
        {
            if (ch < 0x20) sb.Append("\\u").Append(((int)ch).ToString("X4"));
            else sb.Append(ch);
        }
        return sb.ToString();
    }

    private static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("usage: localize --scan <exe>");
            Console.WriteLine("       localize <inExe> <outExe>   (apply localization map)");
            return 2;
        }

        if (args[0] == "--scan" && args.Length >= 2)
        {
            var mod = ModuleDefMD.Load(args[1]);
            var seen = new HashSet<string>();
            foreach (var t in mod.GetTypes())
                foreach (var m in t.Methods)
                {
                    if (m.Body == null) continue;
                    foreach (var ins in m.Body.Instructions)
                        if (ins.OpCode.Code == Code.Ldstr && ins.Operand is string s && HasHan(s))
                        {
                            var key = t.FullName + "::" + m.Name + " | " + s;
                            if (seen.Add(key))
                                Console.WriteLine($"[{t.Name}::{m.Name}] \"{Show(s)}\"");
                        }
                }
            return 0;
        }

        if (args.Length >= 2)
        {
            string inExe = args[0], outExe = args[1];
            var map = LocalizationMap.Map;
            var mod = ModuleDefMD.Load(inExe);
            int replaced = 0;
            var unmatched = new HashSet<string>();
            foreach (var t in mod.GetTypes())
                foreach (var m in t.Methods)
                {
                    if (m.Body == null) continue;
                    foreach (var ins in m.Body.Instructions)
                        if (ins.OpCode.Code == Code.Ldstr && ins.Operand is string s)
                        {
                            if (map.TryGetValue(s, out var ru))
                            {
                                if (!ReferenceEquals(s, ru) && s != ru)
                                {
                                    ins.Operand = ru;
                                    replaced++;
                                }
                            }
                            else if (HasHan(s))
                            {
                                unmatched.Add(s);
                            }
                        }
                }
            mod.Write(outExe);
            Console.WriteLine($"localized: ldstr replaced={replaced} -> {outExe}");
            if (unmatched.Count > 0)
            {
                Console.WriteLine($"NOTE: {unmatched.Count} Chinese ldstr left untouched (not in map: keys/logs/etc):");
                foreach (var u in unmatched.Take(40)) Console.WriteLine("  ~ \"" + Show(u) + "\"");
            }
            return 0;
        }

        Console.WriteLine("bad args");
        return 2;
    }
}
