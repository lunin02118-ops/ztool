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

    // The main splash (FrmRverify) shows a vendor QR panel whose 4 captions
    // (淘宝/公众号/QQ群/抖音) are baked into the embedded bitmap resource "二维码",
    // and the QR codes themselves point at the original vendor's Chinese
    // channels. We remove the whole panel: drop the PictureBox1 control from the
    // form and shrink the window height by the picture's height so the
    // bottom-anchored button row reflows up instead of leaving an empty gap.
    private const int QrPictureHeight = 128; // FrmRverify PictureBox1 height
    private const int OrigClientHeight = 374; // FrmRverify ClientSize height
    private const int NewClientHeight = OrigClientHeight - QrPictureHeight; // 246
    private const int OrigButtonRowY = 338; // FrmRverify TableLayoutPanel1.Location.Y
    private const int NewButtonRowY = OrigButtonRowY - QrPictureHeight; // 210

    private static int RemoveVendorQrPanel(ModuleDefMD mod)
    {
        var form = mod.GetTypes().FirstOrDefault(t => t.Name == "FrmRverify");
        var init = form?.Methods.FirstOrDefault(m => m.Name == "InitializeComponent");
        if (init == null || init.Body == null) return 0;

        var ins = init.Body.Instructions;
        int changes = 0;

        // 1) Drop `Me.Controls.Add(Me.PictureBox1)`. VB WithEvents controls are
        // reached through a property getter, so the statement is:
        //   ldarg.0; callvirt get_Controls; ldarg.0; callvirt get_PictureBox1;
        //   callvirt Control.ControlCollection::Add(Control)
        for (int i = 0; i + 1 < ins.Count; i++)
        {
            if (ins[i].OpCode.Code == Code.Callvirt
                && ins[i].Operand is IMethod getPic && getPic.Name == "get_PictureBox1"
                && ins[i + 1].OpCode.Code == Code.Callvirt
                && ins[i + 1].Operand is IMethod add && add.Name == "Add"
                && add.DeclaringType != null && add.DeclaringType.Name == "ControlCollection")
            {
                int start = i - 3; // ldarg.0; callvirt get_Controls; ldarg.0
                if (start < 0) continue;
                for (int k = start; k <= i + 1; k++)
                {
                    ins[k].OpCode = OpCodes.Nop;
                    ins[k].Operand = null;
                }
                changes++;
                break;
            }
        }

        // 2) Shrink ClientSize height. VB emits `New Size(402, 374)` as a
        // value-type ctor invoked with `call` on a temp address (not `newobj`):
        //   ldc.i4 402; ldc.i4 374; call Size::.ctor(int32,int32)
        for (int i = 0; i + 2 < ins.Count; i++)
        {
            if (ins[i].OpCode.Code == Code.Ldc_I4 && ins[i].GetLdcI4Value() == 402
                && ins[i + 1].OpCode.Code == Code.Ldc_I4 && ins[i + 1].GetLdcI4Value() == OrigClientHeight
                && (ins[i + 2].OpCode.Code == Code.Call || ins[i + 2].OpCode.Code == Code.Newobj)
                && ins[i + 2].Operand is IMethod ctor && ctor.Name == ".ctor"
                && ctor.DeclaringType != null && ctor.DeclaringType.Name == "Size")
            {
                ins[i + 1].OpCode = OpCodes.Ldc_I4;
                ins[i + 1].Operand = NewClientHeight;
                changes++;
                break;
            }
        }

        // 3) Move the bottom button row (TableLayoutPanel1) up by the picture's
        // height so it sits inside the shrunk window. The panel is Bottom-anchored
        // and its Location.Y is set during InitializeComponent (before the layout
        // pass), so relying on the anchor alone leaves it clipped:
        //   ... ldc.i4.s 34 (X); ldc.i4 338 (Y); call Point::.ctor; set_Location
        for (int i = 0; i + 1 < ins.Count; i++)
        {
            if (ins[i].OpCode.Code == Code.Ldc_I4 && ins[i].GetLdcI4Value() == OrigButtonRowY
                && (ins[i + 1].OpCode.Code == Code.Call || ins[i + 1].OpCode.Code == Code.Newobj)
                && ins[i + 1].Operand is IMethod pctor && pctor.Name == ".ctor"
                && pctor.DeclaringType != null && pctor.DeclaringType.Name == "Point")
            {
                ins[i].OpCode = OpCodes.Ldc_I4;
                ins[i].Operand = NewButtonRowY;
                changes++;
                break;
            }
        }

        Console.WriteLine($"  FrmRverify: removed vendor QR panel, ClientSize {OrigClientHeight}->{NewClientHeight}, buttonRowY {OrigButtonRowY}->{NewButtonRowY} (edits={changes})");
        return changes;
    }

    private static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("usage: localize --scan <exe>");
            Console.WriteLine("       localize <inExe> <outExe>   (apply localization map)");
            return 2;
        }

        if (args[0] == "--dumpform" && args.Length >= 2)
        {
            var mod = ModuleDefMD.Load(args[1]);
            var form = mod.GetTypes().FirstOrDefault(t => t.Name == "FrmRverify");
            var init = form?.Methods.FirstOrDefault(m => m.Name == "InitializeComponent");
            if (init == null) { Console.WriteLine("no FrmRverify.InitializeComponent"); return 1; }
            int idx = 0;
            foreach (var ip in init.Body.Instructions)
            {
                string op = ip.Operand is string so ? "\"" + Show(so) + "\"" : (ip.Operand?.ToString() ?? "");
                Console.WriteLine($"{idx++,4}: {ip.OpCode,-12} {op}");
            }
            return 0;
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
            int formChanges = RemoveVendorQrPanel(mod);
            mod.Write(outExe);
            Console.WriteLine($"localized: ldstr replaced={replaced}, form edits={formChanges} -> {outExe}");
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
