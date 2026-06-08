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

    // Font names and protocol keys MUST NOT be translated (they drive font
    // selection and crypto key derivation). Diagnostic/log templates are not
    // user-facing UI, so we also leave them. Everything else with Han that is
    // user-visible (labels, buttons, menus, messages, file-dialog filters) is
    // translatable.
    private static readonly HashSet<string> FontNames = new HashSet<string>
    { "微软雅黑", "宋体", "黑体", "仿宋", "楷体", "楷体_GB2312", "新宋体", "华文中宋", "华文行楷", "Microsoft YaHei" };

    private static bool IsProtocolKey(string s) => s.EndsWith("。。。");
    private static bool IsFontName(string s) => FontNames.Contains(s);
    private static bool IsLogTemplate(string s) =>
        s.Contains("异常") || s.Contains("堆栈") || s.StartsWith("Application");

    // True for strings we are willing to translate (must contain Han and not be
    // a protocol key / font name / diagnostic log template).
    private static bool IsTranslatable(string s) =>
        HasHan(s) && !IsProtocolKey(s) && !IsFontName(s) && !IsLogTemplate(s);

    // Decodes the raw data of a ResourceTypeCode.String entry (as returned by
    // ResourceReader.GetResourceData): a 7-bit-encoded length prefix followed by
    // UTF-8 bytes (the BinaryWriter.Write(string) format).
    private static string DecodeStringResource(byte[] data)
    {
        int pos = 0, len = 0, shift = 0;
        while (pos < data.Length)
        {
            byte b = data[pos++];
            len |= (b & 0x7F) << shift;
            if ((b & 0x80) == 0) break;
            shift += 7;
        }
        if (pos + len > data.Length) len = data.Length - pos;
        return Encoding.UTF8.GetString(data, pos, len);
    }

    // Reversible single-line escaping for the TSV translation table. Backslash,
    // tab and CR/LF use short escapes; all other control chars (e.g. the \u001E
    // \u001C separators in the window-title strings) use \uXXXX so the table
    // stays a clean, line-oriented text file.
    private static string Esc(string s)
    {
        var sb = new StringBuilder();
        foreach (var ch in s)
        {
            if (ch == '\\') sb.Append("\\\\");
            else if (ch == '\t') sb.Append("\\t");
            else if (ch == '\r') sb.Append("\\r");
            else if (ch == '\n') sb.Append("\\n");
            else if (ch < 0x20) sb.Append("\\u").Append(((int)ch).ToString("X4"));
            else sb.Append(ch);
        }
        return sb.ToString();
    }

    private static string Unesc(string s)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '\\' && i + 1 < s.Length)
            {
                char n = s[++i];
                if (n == 't') sb.Append('\t');
                else if (n == 'r') sb.Append('\r');
                else if (n == 'n') sb.Append('\n');
                else if (n == 'u' && i + 4 < s.Length)
                {
                    sb.Append((char)Convert.ToInt32(s.Substring(i + 1, 4), 16));
                    i += 4;
                }
                else sb.Append(n);
            }
            else sb.Append(s[i]);
        }
        return sb.ToString();
    }

    // Loads the committed zh->ru translation table. Lines: escZh \t escRu.
    // Blank lines, '#' comments and rows with an empty RU column are ignored.
    private static Dictionary<string, string> LoadTable(string path)
    {
        var map = new Dictionary<string, string>();
        foreach (var raw in System.IO.File.ReadAllLines(path, Encoding.UTF8))
        {
            if (raw.Length == 0 || raw[0] == '#') continue;
            int tab = raw.IndexOf('\t');
            if (tab < 0) continue;
            string zh = Unesc(raw.Substring(0, tab));
            string ru = Unesc(raw.Substring(tab + 1));
            if (zh.Length == 0 || ru.Length == 0 || zh == ru) continue;
            map[zh] = ru;
        }
        return map;
    }

    // Enumerates string resource values in every embedded *.resources, skipping
    // entries whose value cannot be read without BinaryFormatter (bitmaps etc.).
    private static IEnumerable<(EmbeddedResource res, string key, string val)> EnumResourceStrings(ModuleDefMD mod)
    {
        foreach (var r in mod.Resources)
        {
            if (!(r is EmbeddedResource er) || !er.Name.String.EndsWith(".resources")) continue;
            byte[] bytes;
            using (var rd = er.CreateReader().AsStream())
            using (var ms = new System.IO.MemoryStream())
            { rd.CopyTo(ms); bytes = ms.ToArray(); }
            var results = new List<(EmbeddedResource, string, string)>();
            using (var ms = new System.IO.MemoryStream(bytes))
            using (var rr = new System.Resources.ResourceReader(ms))
            {
                var en = rr.GetEnumerator();
                while (true)
                {
                    try { if (!en.MoveNext()) break; } catch { break; }
                    object val;
                    try { val = en.Value; } catch { continue; }
                    if (val is string sv) results.Add((er, (string)en.Key, sv));
                }
            }
            foreach (var t in results) yield return t;
        }
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

    // Remove the assembly's strong name. After reinjection the original signature is invalid
    // (we changed IL without the vendor's private key), so machines that enforce strong-name
    // verification refuse to load it. Clearing the public key makes the writer emit an
    // unsigned assembly that loads everywhere. Nothing references this exe by strong name.
    private static int StripStrongName(ModuleDefMD mod)
    {
        var asm = mod.Assembly;
        if (asm == null) return 0;
        bool had = asm.PublicKey != null && !asm.PublicKey.IsNullOrEmpty;
        asm.PublicKey = null;                                          // flips HasPublicKey off
        asm.Attributes &= ~dnlib.DotNet.AssemblyAttributes.PublicKey;  // belt-and-suspenders
        return had ? 1 : 0;
    }

    // In-place patch of the Win32 VS_VERSIONINFO so FileVersion/ProductVersion report 1.0.0
    // instead of the vendor's leftover 3.8.4.0. Both edits are length-preserving (the numeric
    // DWORDs are fixed size; UTF-16 "3.8.4" and "1.0.0" are both 5 chars), so the PE section
    // layout is untouched and no length fields need recomputing.
    private static int NormalizeWin32Version(string exePath)
    {
        byte[] b = System.IO.File.ReadAllBytes(exePath);
        int edits = 0;

        // 1) VS_FIXEDFILEINFO (signature 0xFEEF04BD): patch only the block whose file+product
        //    version is exactly 3.8.4.0 (MS=0x00030008, LS=0x00040000) -> 1.0.0.0.
        for (int i = 0; i <= b.Length - 24; i++)
        {
            if (b[i] == 0xBD && b[i + 1] == 0x04 && b[i + 2] == 0xEF && b[i + 3] == 0xFE)
            {
                uint fileMS = BitConverter.ToUInt32(b, i + 8);
                uint fileLS = BitConverter.ToUInt32(b, i + 12);
                uint prodMS = BitConverter.ToUInt32(b, i + 16);
                uint prodLS = BitConverter.ToUInt32(b, i + 20);
                if (fileMS == 0x00030008 && fileLS == 0x00040000 && prodMS == 0x00030008 && prodLS == 0x00040000)
                {
                    BitConverter.GetBytes((uint)0x00010000).CopyTo(b, i + 8);   // fileMS = 1.0
                    BitConverter.GetBytes((uint)0x00000000).CopyTo(b, i + 12);  // fileLS = 0.0
                    BitConverter.GetBytes((uint)0x00010000).CopyTo(b, i + 16);  // prodMS = 1.0
                    BitConverter.GetBytes((uint)0x00000000).CopyTo(b, i + 20);  // prodLS = 0.0
                    edits++;
                }
            }
        }

        // 2) StringFileInfo "FileVersion"/"ProductVersion" values: "3.8.4" -> "1.0.0" (same length).
        byte[] from = Encoding.Unicode.GetBytes("3.8.4");
        byte[] to = Encoding.Unicode.GetBytes("1.0.0");
        for (int i = 0; i <= b.Length - from.Length; i++)
        {
            bool m = true;
            for (int j = 0; j < from.Length; j++) if (b[i + j] != from[j]) { m = false; break; }
            if (m) { Array.Copy(to, 0, b, i, to.Length); edits++; i += from.Length - 1; }
        }

        if (edits > 0) System.IO.File.WriteAllBytes(exePath, b);
        return edits;
    }

    private static int Main(string[] args)
    {
        try { Console.OutputEncoding = new UTF8Encoding(false); } catch { /* redirected console may reject */ }
        if (args.Length < 1)
        {
            Console.WriteLine("usage: localize --scan <exe>");
            Console.WriteLine("       localize <inExe> <outExe>   (apply localization map)");
            return 2;
        }

        if (args[0] == "--asmver" && args.Length >= 2)
        {
            var mod = ModuleDefMD.Load(args[1]);
            Console.WriteLine($"AssemblyName.Version = {mod.Assembly.Version}");
            var pk = mod.Assembly.PublicKey;
            Console.WriteLine($"StrongNamed = {(pk != null && !pk.IsNullOrEmpty)}; PublicKeyToken = {(pk != null ? pk.Token?.ToString() : "<none>")}");
            foreach (var ca in mod.Assembly.CustomAttributes)
            {
                var n = ca.AttributeType?.Name ?? "";
                if (n == "AssemblyFileVersionAttribute" || n == "AssemblyInformationalVersionAttribute"
                    || n == "AssemblyVersionAttribute" || n == "AssemblyProductAttribute")
                {
                    var val = ca.ConstructorArguments.Count > 0 ? ca.ConstructorArguments[0].Value?.ToString() : "";
                    Console.WriteLine($"{n} = \"{val}\"");
                }
            }
            return 0;
        }

        if (args[0] == "--dumpform" && args.Length >= 2)
        {
            var mod = ModuleDefMD.Load(args[1]);
            string typeName = args.Length >= 3 ? args[2] : "FrmRverify";
            string methodName = args.Length >= 4 ? args[3] : "InitializeComponent";
            var form = mod.GetTypes().FirstOrDefault(t => t.Name == typeName);
            var init = form?.Methods.FirstOrDefault(m => m.Name == methodName);
            if (init == null) { Console.WriteLine($"no {typeName}.{methodName}"); return 1; }
            int idx = 0;
            foreach (var ip in init.Body.Instructions)
            {
                string op = ip.Operand is string so ? "\"" + Show(so) + "\"" : (ip.Operand?.ToString() ?? "");
                Console.WriteLine($"{idx++,4}: {ip.OpCode,-12} {op}");
            }
            return 0;
        }

        if (args[0] == "--scanres" && args.Length >= 2)
        {
            var mod = ModuleDefMD.Load(args[1]);
            string filter = args.Length >= 3 ? args[2] : null; // resource-name substring -> dump ALL strings
            int total = 0, withHan = 0;
            foreach (var res in mod.Resources)
            {
                if (!(res is EmbeddedResource er)) { Console.WriteLine($"[non-embedded] {res.Name}"); continue; }
                if (!er.Name.String.EndsWith(".resources")) continue;
                bool dumpAll = filter != null && er.Name.String.Contains(filter);
                byte[] bytes;
                using (var rd = er.CreateReader().AsStream())
                using (var ms = new System.IO.MemoryStream())
                { rd.CopyTo(ms); bytes = ms.ToArray(); }
                // Robust enumeration: collect keys first (Key never deserializes),
                // then read each value via GetResourceData so one bad/object entry
                // cannot abort the whole resource.
                var keys = new List<string>();
                using (var ms = new System.IO.MemoryStream(bytes))
                using (var rr = new System.Resources.ResourceReader(ms))
                {
                    var en = rr.GetEnumerator();
                    while (true)
                    {
                        try { if (!en.MoveNext()) break; } catch { break; }
                        try { keys.Add((string)en.Key); } catch { }
                    }
                }
                using (var ms = new System.IO.MemoryStream(bytes))
                using (var rr = new System.Resources.ResourceReader(ms))
                {
                    foreach (var key in keys)
                    {
                        string type; byte[] data;
                        try { rr.GetResourceData(key, out type, out data); } catch { continue; }
                        if (dumpAll) Console.WriteLine($"[{er.Name}] {key} :: {type}");
                        if (type != "ResourceTypeCode.String") continue;
                        string sv;
                        try { sv = DecodeStringResource(data); } catch { continue; }
                        if (sv == null) continue;
                        total++;
                        if (HasHan(sv) || dumpAll) { if (HasHan(sv)) withHan++; Console.WriteLine($"[{er.Name}] {key} = \"{Show(sv)}\""); }
                    }
                }
            }
            Console.WriteLine($"resource string values: total={total}, with-han={withHan}");
            return 0;
        }

        if (args[0] == "--findstr" && args.Length >= 3)
        {
            var mod = ModuleDefMD.Load(args[1]);
            string needle = args[2];
            byte[] needleU8 = Encoding.UTF8.GetBytes(needle);
            foreach (var t in mod.GetTypes())
                foreach (var m in t.Methods)
                {
                    if (m.Body == null) continue;
                    foreach (var ins in m.Body.Instructions)
                        if (ins.OpCode.Code == Code.Ldstr && ins.Operand is string s && s.Contains(needle))
                            Console.WriteLine($"LDSTR [{t.FullName}::{m.Name}] \"{Show(s)}\"");
                }
            foreach (var res in mod.Resources)
            {
                if (!(res is EmbeddedResource er) || !er.Name.String.EndsWith(".resources")) continue;
                byte[] bytes;
                using (var rd = er.CreateReader().AsStream())
                using (var ms = new System.IO.MemoryStream())
                { rd.CopyTo(ms); bytes = ms.ToArray(); }
                // raw UTF-8 substring search within the resource blob
                for (int i = 0; i + needleU8.Length <= bytes.Length; i++)
                {
                    bool hit = true;
                    for (int j = 0; j < needleU8.Length; j++) if (bytes[i + j] != needleU8[j]) { hit = false; break; }
                    if (hit) { Console.WriteLine($"RESBLOB [{er.Name}] raw-utf8 @ {i}"); break; }
                }
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

        // Generate / refresh the translation table template from the exe: every
        // distinct translatable Han string (ldstr + resource string values),
        // sorted, with an empty RU column for rows not already translated. Rows
        // already present (with a RU value) in the existing table are preserved.
        if (args[0] == "--gentable" && args.Length >= 3)
        {
            var mod = ModuleDefMD.Load(args[1]);
            string outTsv = args[2];
            var existing = System.IO.File.Exists(outTsv) ? LoadTable(outTsv) : new Dictionary<string, string>();
            var keys = new SortedSet<string>(StringComparer.Ordinal);
            foreach (var t in mod.GetTypes())
                foreach (var m in t.Methods)
                {
                    if (m.Body == null) continue;
                    foreach (var ins in m.Body.Instructions)
                        if (ins.OpCode.Code == Code.Ldstr && ins.Operand is string s && IsTranslatable(s))
                            keys.Add(s);
                }
            foreach (var (_, _, val) in EnumResourceStrings(mod))
                if (IsTranslatable(val)) keys.Add(val);

            var sb = new StringBuilder();
            sb.Append("# ZTool localization table: <escaped zh>\\t<escaped ru>\n");
            sb.Append("# Rows with an empty RU column are left untouched. Edit RU values only.\n");
            int done = 0;
            foreach (var k in keys)
            {
                existing.TryGetValue(k, out var ru);
                if (!string.IsNullOrEmpty(ru)) done++;
                sb.Append(Esc(k)).Append('\t').Append(ru == null ? "" : Esc(ru)).Append('\n');
            }
            System.IO.File.WriteAllText(outTsv, sb.ToString(), new UTF8Encoding(false));
            Console.WriteLine($"gentable: {keys.Count} translatable strings ({done} already translated) -> {outTsv}");
            return 0;
        }

        if (args.Length >= 2)
        {
            string inExe = args[0], outExe = args[1];
            string tablePath = args.Length >= 3 ? args[2] : System.IO.Path.Combine(AppContext.BaseDirectory, "translations.tsv");
            if (!System.IO.File.Exists(tablePath))
            {
                Console.WriteLine($"ERROR: translation table not found: {tablePath}");
                return 1;
            }
            var map = LoadTable(tablePath);
            Console.WriteLine($"loaded {map.Count} translations from {tablePath}");
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
                            if (map.TryGetValue(s, out var ru) && s != ru)
                            {
                                ins.Operand = ru;
                                replaced++;
                            }
                            else if (IsTranslatable(s) && !map.ContainsKey(s))
                            {
                                unmatched.Add(s);
                            }
                        }
                }

            int blanked = BlankVendorContacts(mod);
            var blankKeys = new HashSet<string>(StringComparer.Ordinal) { "qq", "email", "website", "DOGURL" };
            int resReplaced = RewriteResources(mod, map, blankKeys);
            // The vendor QR panels are no longer hidden; instead InjectMaxQr swaps
            // the QR bitmap for the user's MAX contact code and shows them again.
            string qrPng = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(tablePath)), "max_qr.png");
            int maxQrChanges = InjectMaxQr(mod, qrPng);
            int frmRgChanges = TuneFrmRg(mod);
            int aboutTitleChanges = FixAboutTitle(mod);
            int updateChanges = DisableUpdateCheck(mod);
            int attrChanges = LocalizeAssemblyAttributes(mod, map);
            // Strip the (now-invalid) strong name so the reinjected exe loads even on machines
            // where strong-name verification bypass is disabled. We modify IL without the vendor's
            // private key, so the original signature can never be valid again; removing the strong
            // name entirely is the only way to make it load everywhere.
            int snStripped = StripStrongName(mod);
            // Clearing the public key is not enough: dnlib's writer otherwise preserves the COR20
            // "StrongNameSigned" header bit, so a verifying loader still tries (and fails) to check
            // a signature that no longer exists. Explicitly drop that bit while keeping the rest of
            // the original COR20 flags (e.g. ILOnly / bitness) intact.
            var wopts = new dnlib.DotNet.Writer.ModuleWriterOptions(mod);
            var curFlags = mod.Metadata.ImageCor20Header.Flags;
            wopts.Cor20HeaderOptions.Flags = curFlags & ~dnlib.DotNet.MD.ComImageFlags.StrongNameSigned;
            mod.Write(outExe, wopts);
            // dnlib preserves the vendor's Win32 VS_VERSIONINFO (FileVersion/ProductVersion = 3.8.4.0,
            // shown by Explorer / FileVersionInfo). The activation key is derived from the *managed*
            // Application.ProductVersion (="1.0"), not this resource, so 3.8.4 is cosmetic only - but we
            // normalize it to 1.0.0 so the file's reported version matches.
            int win32Ver = NormalizeWin32Version(outExe);
            Console.WriteLine($"localized: ldstr replaced={replaced}, vendor ldstr blanked={blanked}, resource strings replaced={resReplaced}, max-qr edits={maxQrChanges}, frmrg edits={frmRgChanges}, about-title edits={aboutTitleChanges}, update edits={updateChanges}, attr strings={attrChanges}, win32-ver edits={win32Ver}, strongname-stripped={snStripped} -> {outExe}");
            if (unmatched.Count > 0)
            {
                Console.WriteLine($"WARNING: {unmatched.Count} translatable Chinese ldstr have NO RU entry (still visible!):");
                foreach (var u in unmatched.Take(60)) Console.WriteLine("  ~ \"" + Show(u) + "\"");
            }
            return 0;
        }

        Console.WriteLine("bad args");
        return 2;
    }

    // Rebuilds every embedded *.resources that contains a translated string,
    // replacing string values found in the map. Non-string entries (bitmaps,
    // icons, primitives) are copied verbatim via raw resource data so no
    // BinaryFormatter round-trip is needed. Returns count of strings replaced.
    // Blanks the original vendor's contact details that are baked into form
    // designer code as ldstr operands (license window FrmRverify, the About
    // box). Generic labels (Email:, Сайт:, QQ:, Группа QQ:) are kept so the
    // user can fill in their own data later; only the VALUES are emptied. The
    // China-only Taobao field (label + link) is removed entirely per request.
    private static int BlankVendorContacts(ModuleDefMD mod)
    {
        // (typeName, methodName) -> { exact ldstr -> replacement }
        var scoped = new (string type, string method, Dictionary<string, string> repl)[]
        {
            ("FrmRverify", "InitializeComponent", new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["823539419"] = "",
                ["287926418"] = "",
                ["mail@z-tool.cn"] = "",
                ["www.z-tool.cn"] = "",
                ["https://item.taobao.com/item.htm?id=638150915723"] = "",
                // user asked to drop the China-only Taobao marketplace link
                // entirely (not keep it as a placeholder), so blank the label too.
                ["Taobao:"] = "",
                ["淘宝:"] = "",
            }),
            ("FrmAbout", "AboutBox1_Load", new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["Email: mail@z-tool.cn"] = "Email: ",
                ["Группа QQ: 823539419"] = "Группа QQ: ",
            }),
            ("CheckUpdate", "InitializeComponent", new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["www.z-tool.cn"] = "",
                ["Сайт загрузки: www.z-tool.cn"] = "Сайт загрузки: ",
            }),
        };
        int n = 0;
        foreach (var (typeName, methodName, repl) in scoped)
        {
            var t = mod.GetTypes().FirstOrDefault(x => x.Name == typeName);
            var m = t?.Methods.FirstOrDefault(x => x.Name == methodName);
            if (m?.Body == null) { Console.WriteLine($"  blank: {typeName}::{methodName} not found"); continue; }
            foreach (var ins in m.Body.Instructions)
                if (ins.OpCode.Code == Code.Ldstr && ins.Operand is string s && repl.TryGetValue(s, out var rep) && s != rep)
                { ins.Operand = rep; n++; }
        }
        return n;
    }

    // The About box (FrmAbout) shows the same vendor QR bitmap (PictureBox2,
    // image "二维码" with 淘宝/公众号/QQ群/抖音 captions) as the splash. Remove it the
    // same way: drop the Controls.Add(PictureBox2) statement, shrink the dialog
    // height by the picture's height (450 -> 338) and lift the bottom-anchored
    // OK / log buttons (Location.Y 419 -> 307) so they reflow without a gap.
    private static int RemoveAboutQrPanel(ModuleDefMD mod)
    {
        var form = mod.GetTypes().FirstOrDefault(t => t.Name == "FrmAbout");
        var init = form?.Methods.FirstOrDefault(m => m.Name == "InitializeComponent");
        if (init == null || init.Body == null) return 0;
        var ins = init.Body.Instructions;
        int changes = 0;

        // 1) drop `Me.Controls.Add(Me.PictureBox2)`
        for (int i = 0; i + 1 < ins.Count; i++)
        {
            if (ins[i].OpCode.Code == Code.Callvirt
                && ins[i].Operand is IMethod getPic && getPic.Name == "get_PictureBox2"
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

        // 2) shrink ClientSize `New Size(305, 450)` -> 338. Key off the height
        // (450, unique) immediately followed by the Size ctor so the match does
        // not depend on how the width was emitted (ldc.i4 vs short forms).
        for (int i = 0; i + 1 < ins.Count; i++)
        {
            if (ins[i].IsLdcI4() && ins[i].GetLdcI4Value() == 450
                && (ins[i + 1].OpCode.Code == Code.Call || ins[i + 1].OpCode.Code == Code.Newobj)
                && ins[i + 1].Operand is IMethod ctor && ctor.Name == ".ctor"
                && ctor.DeclaringType != null && ctor.DeclaringType.Name == "Size")
            {
                ins[i].OpCode = OpCodes.Ldc_I4;
                ins[i].Operand = 338;
                changes++;
                break;
            }
        }

        // 3) lift both bottom buttons: `New Point(x, 419)` -> 307. Y=419 is used
        // only by OKButton (x=216) and Button1 (x=7), so update every match. We
        // key off the Y load directly before the Point ctor: Button1's x=7 is
        // emitted as ldc.i4.7 (a short form), so testing the X opcode would miss
        // it and leave that button clipped below the shrunk window.
        for (int i = 0; i + 1 < ins.Count; i++)
        {
            if (ins[i].IsLdcI4() && ins[i].GetLdcI4Value() == 419
                && (ins[i + 1].OpCode.Code == Code.Call || ins[i + 1].OpCode.Code == Code.Newobj)
                && ins[i + 1].Operand is IMethod pc && pc.Name == ".ctor"
                && pc.DeclaringType != null && pc.DeclaringType.Name == "Point")
            {
                ins[i].OpCode = OpCodes.Ldc_I4;
                ins[i].Operand = 307;
                changes++;
            }
        }

        // 4) widen the "update log" button. Its 75px width fit the short Chinese
        // caption (更新日志) but truncates the Russian "Журнал обновлений".
        // Anchor on `Button1.Name = "Button1"` then rewrite the following
        // `New Size(75, 27)` width 75 -> 160 (OKButton starts at x=216, no overlap).
        for (int i = 0; i < ins.Count; i++)
        {
            if (ins[i].OpCode.Code != Code.Ldstr || (ins[i].Operand as string) != "Button1") continue;
            for (int j = i + 1; j < ins.Count && j < i + 20; j++)
            {
                if (ins[j].OpCode.Code == Code.Call || ins[j].OpCode.Code == Code.Newobj)
                {
                    if (ins[j].Operand is IMethod sc && sc.Name == ".ctor"
                        && sc.DeclaringType != null && sc.DeclaringType.Name == "Size"
                        && j >= 2 && ins[j - 1].IsLdcI4() && ins[j - 1].GetLdcI4Value() == 27
                        && ins[j - 2].IsLdcI4() && ins[j - 2].GetLdcI4Value() == 75)
                    {
                        ins[j - 2].OpCode = OpCodes.Ldc_I4;
                        ins[j - 2].Operand = 160;
                        changes++;
                    }
                    break;
                }
            }
            break;
        }
        return changes;
    }

    // FrmRg (the activation window) lays its three bottom buttons out in a 4-column
    // TableLayoutPanel whose percentages were tuned for short Chinese captions
    // ("\u5728\u7ebf\u6fc0\u6d3b" etc). The Russian captions ("Активация онлайн",
    // "Перенести лицензию") are far wider, and since the buttons are AutoSize they
    // truncate when their cell is too narrow. The middle (index 1) column is an
    // empty spacer that hogged ~35% of the width. Re-balance the 4 percentages so
    // the button columns get enough room; the AutoSize buttons then fill them.
    // Separately, one info label ("Пароль защиты лицензии (...)") is a single long
    // AutoSize line that runs off the 477px-wide window, so collapse it to a
    // concise caption that fits.
    private static int TuneFrmRg(ModuleDefMD mod)
    {
        var frm = mod.Find("ZTool.FrmRg", false);
        var init = frm?.FindMethod("InitializeComponent");
        if (init?.Body == null) return 0;
        int changes = 0;
        var ins = init.Body.Instructions;

        // 1) re-balance the 4 ColumnStyle percentages: [Перенести | spacer | Активация | Отмена]
        float[] target = { 34f, 6f, 38f, 22f };
        int seen = 0;
        for (int i = 0; i < ins.Count && seen < target.Length; i++)
        {
            if (ins[i].OpCode.Code != Code.Ldc_R4) continue;
            if (i + 1 >= ins.Count || ins[i + 1].OpCode.Code != Code.Newobj) continue;
            if (!(ins[i + 1].Operand is IMethod ctor) || ctor.DeclaringType == null
                || ctor.DeclaringType.Name != "ColumnStyle") continue;
            ins[i].Operand = target[seen];
            seen++;
            changes++;
        }

        // 2) shorten the over-long single-line password info label.
        const string longPwd = "Пароль защиты лицензии (можно задать при активации; после переноса лицензии очищается автоматически):";
        const string shortPwd = "Пароль защиты лицензии (необязательно, задаётся при активации):";
        foreach (var i2 in ins)
        {
            if (i2.OpCode.Code == Code.Ldstr && (i2.Operand as string) == longPwd)
            {
                i2.Operand = shortPwd;
                changes++;
            }
        }
        Console.WriteLine($"  FrmRg: retuned {seen} button columns, shortened password label (edits={changes})");
        return changes;
    }

    // The About-box window caption is assembled at runtime in FrmAbout.AboutBox1_Load
    // as: "О программе" + ProductName + "--{0}", where {0} is the AssemblyTitle.
    // That glues the words together ("О программеZTool--...") and uses an ASCII
    // double-hyphen. Fix the separators *only inside that method* (the same
    // "О программе" literal is also a button caption elsewhere and must stay).
    private static int FixAboutTitle(ModuleDefMD mod)
    {
        var m = mod.Find("ZTool.FrmAbout", false)?.FindMethod("AboutBox1_Load");
        if (m?.Body == null) return 0;
        int changes = 0;
        foreach (var i in m.Body.Instructions)
        {
            if (i.OpCode.Code != Code.Ldstr) continue;
            string s = i.Operand as string;
            if (s == "О программе") { i.Operand = "О программе "; changes++; }
            else if (s == "--{0}") { i.Operand = " — {0}"; changes++; }
        }
        Console.WriteLine($"  FrmAbout: polished window-caption separators (edits={changes})");
        return changes;
    }

    // The user's own MAX-messenger contact link, encoded in tools/Localizer/max_qr.png
    // and opened by the clickable "Max" hyperlink in the About box.
    private const string MaxUrl =
        "https://max.ru/u/f9LHodD0cOLc5SX8zsbZvz3TMwMzyunwK6GAYYw79SkF1lZ0YUlZknFImsU";
    // The QR bitmap's resource key / accessor in ZTool.My.Resources (二维码).
    private const string QrResKey = "\u4E8C\u7EF4\u7801";

    // Replaces the original vendor QR (PictureBox image "二维码", which had baked-in
    // 淘宝/公众号/QQ群/抖音 captions pointing at the vendor's Chinese channels) with the
    // user's own MAX contact QR, and turns the About-box hyperlink into a clickable
    // "Max" that opens the user's MAX profile.
    //
    // The image swap is done WITHOUT touching the serialized .resources bitmap (which
    // would need BinaryFormatter, unavailable on net10): the PNG is embedded as a
    // plain manifest resource and the existing static accessor `get_二维码()` is
    // rewritten to decode it. Both PictureBoxes (FrmRverify.PictureBox1 and
    // FrmAbout.PictureBox2) call that one accessor, so both windows update at once.
    // Because the new image is Russian-only, the QR panels no longer need hiding —
    // RemoveVendorQrPanel / RemoveAboutQrPanel are dropped from the pipeline so the
    // PictureBoxes show again at their original (SizeMode=Zoom) layout.
    private static int InjectMaxQr(ModuleDefMD mod, string pngPath)
    {
        if (!System.IO.File.Exists(pngPath))
        {
            Console.WriteLine($"  MaxQr: PNG not found: {pngPath}");
            return 0;
        }
        int changes = 0;

        // locate the static QR accessor by the literal it loads from the resource set.
        MethodDef qrGetter = null;
        foreach (var t in mod.GetTypes())
        {
            foreach (var m in t.Methods)
            {
                if (m.Body == null) continue;
                foreach (var ins in m.Body.Instructions)
                    if (ins.OpCode.Code == Code.Ldstr && (ins.Operand as string) == QrResKey)
                    { qrGetter = m; break; }
                if (qrGetter != null) break;
            }
            if (qrGetter != null) break;
        }
        if (qrGetter == null) { Console.WriteLine("  MaxQr: get_二维码 accessor not found"); return 0; }

        // embed the PNG bytes as a plain manifest resource.
        const string resName = "MaxQr.png";
        if (!mod.Resources.Any(r => r.Name == resName))
            mod.Resources.Add(new EmbeddedResource(resName,
                System.IO.File.ReadAllBytes(pngPath), ManifestResourceAttributes.Public));

        // build the framework method/type refs needed by the new accessor body.
        var corlib = mod.CorLibTypes.AssemblyRef;
        var drawingAsm = mod.GetAssemblyRefs().FirstOrDefault(a => a.Name == "System.Drawing");
        ITypeDefOrRef bitmapType =
            mod.GetTypeRefs().FirstOrDefault(tr => tr.Namespace == "System.Drawing" && tr.Name == "Bitmap")
            ?? (ITypeDefOrRef)new TypeRefUser(mod, "System.Drawing", "Bitmap", drawingAsm);

        var typeRef = new TypeRefUser(mod, "System", "Type", corlib);
        var rthRef = new TypeRefUser(mod, "System", "RuntimeTypeHandle", corlib);
        var asmRef = new TypeRefUser(mod, "System.Reflection", "Assembly", corlib);
        var streamRef = new TypeRefUser(mod, "System.IO", "Stream", corlib);

        var typeSig = new ClassSig(typeRef);
        var streamSig = new ClassSig(streamRef);

        var mGetTypeFromHandle = new MemberRefUser(mod, "GetTypeFromHandle",
            MethodSig.CreateStatic(typeSig, new ValueTypeSig(rthRef)), typeRef);
        var mGetAssembly = new MemberRefUser(mod, "get_Assembly",
            MethodSig.CreateInstance(new ClassSig(asmRef)), typeRef);
        var mGetStream = new MemberRefUser(mod, "GetManifestResourceStream",
            MethodSig.CreateInstance(streamSig, mod.CorLibTypes.String), asmRef);
        var mBitmapCtor = new MemberRefUser(mod, ".ctor",
            MethodSig.CreateInstance(mod.CorLibTypes.Void, streamSig), bitmapType);

        // get_二维码() => new Bitmap(typeof(<declaring>).Assembly.GetManifestResourceStream("MaxQr.png"))
        var b = qrGetter.Body;
        b.Instructions.Clear();
        b.ExceptionHandlers.Clear();
        b.Variables.Clear();
        b.Instructions.Add(Instruction.Create(OpCodes.Ldtoken, qrGetter.DeclaringType));
        b.Instructions.Add(Instruction.Create(OpCodes.Call, mGetTypeFromHandle));
        b.Instructions.Add(Instruction.Create(OpCodes.Callvirt, mGetAssembly));
        b.Instructions.Add(Instruction.Create(OpCodes.Ldstr, resName));
        b.Instructions.Add(Instruction.Create(OpCodes.Callvirt, mGetStream));
        b.Instructions.Add(Instruction.Create(OpCodes.Newobj, mBitmapCtor));
        b.Instructions.Add(Instruction.Create(OpCodes.Ret));
        changes++;

        // About box: make LinkLabel1 a clickable "Max" that opens the MAX profile.
        var about = mod.Find("ZTool.FrmAbout", false);
        var load = about?.FindMethod("AboutBox1_Load");
        if (load?.Body != null)
        {
            // the link text comes from `call get_website()` feeding LinkLabel1.set_Text;
            // show literal "Max" instead.
            foreach (var ins in load.Body.Instructions)
                if ((ins.OpCode.Code == Code.Call || ins.OpCode.Code == Code.Callvirt)
                    && ins.Operand is IMethod gw && gw.Name == "get_website")
                {
                    ins.OpCode = OpCodes.Ldstr;
                    ins.Operand = "Max";
                    changes++;
                    break;
                }
        }
        var click = about?.FindMethod("LinkLabel1_LinkClicked");
        if (click?.Body != null)
        {
            // reuse the existing Process.Start(string) ref from the original body.
            IMethod procStart = click.Body.Instructions
                .Select(x => x.Operand as IMethod)
                .FirstOrDefault(x => x != null && x.Name == "Start"
                    && x.DeclaringType != null && x.DeclaringType.Name == "Process");
            if (procStart != null)
            {
                var cb = click.Body;
                cb.Instructions.Clear();
                cb.ExceptionHandlers.Clear();
                cb.Variables.Clear();
                cb.Instructions.Add(Instruction.Create(OpCodes.Ldstr, MaxUrl));
                cb.Instructions.Add(Instruction.Create(OpCodes.Call, procStart));
                cb.Instructions.Add(Instruction.Create(OpCodes.Pop));
                cb.Instructions.Add(Instruction.Create(OpCodes.Ret));
                changes++;
            }
        }

        Console.WriteLine($"  MaxQr: embedded contact QR + clickable 'Max' link (edits={changes})");
        return changes;
    }

    // Fully disables the vendor's online update mechanism (user request). The
    // update window (CheckUpdate) is itself Russian, but its changelog body is
    // fetched at runtime from the vendor site (z-tool.cn, in Chinese) and its
    // "download" button pulls the ORIGINAL vendor exe, which would overwrite our
    // re-keyed/localized client. There are two network entry points that hit
    // <decrypted base>/AutoUpdate1.xml: CheckUpdate.getinfo (the window) and
    // Frmmain.haveupdate (the startup "update available" probe). We:
    //   * gut CheckUpdate.getinfo  -> body becomes `ret` (no fetch, no changelog;
    //     `findnew` stays false so Button2_Click can never download/install),
    //   * gut Frmmain.haveupdate   -> body becomes `return false` (no startup
    //     probe, no "new version" notification lambda),
    //   * neutralize LinkLabel1_LinkClicked -> `ret` (the download-site link can
    //     no longer launch a browser to the vendor URL), and
    //   * relabel the window's status line and blank the vendor site link text
    //     + its Tag (the URL) so no z-tool.cn reference remains on screen.
    // The window, if still opened from the ribbon, is now an inert Russian
    // dialog reading "\u041f\u0440\u043e\u0432\u0435\u0440\u043a\u0430 \u043e\u0431\u043d\u043e\u0432\u043b\u0435\u043d\u0438\u0439 \u043e\u0442\u043a\u043b\u044e\u0447\u0435\u043d\u0430.".
    private static int DisableUpdateCheck(ModuleDefMD mod)
    {
        var t = mod.Find("ZTool.CheckUpdate", false);
        var frmmain = mod.Find("ZTool.Frmmain", false);
        int changes = 0;

        // helper: replace a method body with a minimal stub.
        static int Stub(MethodDef m, params Instruction[] body)
        {
            if (m?.Body == null) return 0;
            var b = m.Body;
            b.Instructions.Clear();
            b.ExceptionHandlers.Clear();
            b.Variables.Clear();
            foreach (var ins in body) b.Instructions.Add(ins);
            b.Instructions.Add(Instruction.Create(OpCodes.Ret));
            return 1;
        }

        if (t != null)
        {
            changes += Stub(t.FindMethod("getinfo"));               // -> ret
            changes += Stub(t.FindMethod("LinkLabel1_LinkClicked")); // -> ret

            // relabel the window status line (the vendor site link is already
            // blanked by BlankVendorContacts, scoped to CheckUpdate above).
            var ul = t.FindMethod("Updata_Load");
            if (ul?.Body != null)
                foreach (var ins in ul.Body.Instructions)
                    if (ins.OpCode.Code == Code.Ldstr && ins.Operand is string s
                        && s == "Подключение к серверу...")
                    {
                        ins.Operand = "Обновления отключены";
                        changes++;
                    }
        }

        // startup "update available" probe in Frmmain -> always report "no update"
        if (frmmain != null)
            changes += Stub(frmmain.FindMethod("haveupdate"), Instruction.Create(OpCodes.Ldc_I4_0));

        // The window must never appear at all. It is opened everywhere with the
        // VB pattern `MyForms.get_CheckUpdate().Show()`. Neutralize every such
        // launch by replacing the `Show()` call with `pop` (the form instance
        // returned by get_CheckUpdate is discarded, stack stays balanced, and no
        // window is created/shown). This covers the Frmmain ribbon menu item(s)
        // and the StartType==120 branch in MyapplicationContext.
        //
        // MyapplicationContext is special: StartType==120 is a dedicated process
        // whose ONLY job is the update window. With the window suppressed,
        // Application.Run(context) would spin a message loop with no form and
        // hang invisibly. So for that one site we also terminate the process via
        // Environment.Exit(0) (reusing the ref already present in Program.Main).
        IMethod envExit = mod.GetTypes()
            .SelectMany(x => x.Methods).Where(x => x.HasBody)
            .SelectMany(x => x.Body.Instructions)
            .Select(x => x.Operand as IMethod)
            .FirstOrDefault(x => x != null && x.Name == "Exit"
                && x.DeclaringType != null && x.DeclaringType.Name == "Environment");

        int shows = 0;
        foreach (var type in mod.GetTypes())
        foreach (var m in type.Methods)
        {
            if (m.Body == null) continue;
            bool isCtx = type.Name == "MyapplicationContext";
            var ins = m.Body.Instructions;
            for (int i = 0; i < ins.Count; i++)
            {
                if (!(ins[i].Operand is IMethod gm) || gm.Name != "get_CheckUpdate") continue;
                // find the Show() call that consumes this instance (next few ins).
                for (int j = i + 1; j < ins.Count && j <= i + 4; j++)
                {
                    if ((ins[j].OpCode.Code == Code.Callvirt || ins[j].OpCode.Code == Code.Call)
                        && ins[j].Operand is IMethod sm && sm.Name == "Show")
                    {
                        ins[j].OpCode = OpCodes.Pop;       // discard the form instance
                        ins[j].Operand = null;
                        shows++;
                        if (isCtx && envExit != null)
                        {
                            // ...; pop; ldc.i4.0; call Environment.Exit(int32)
                            ins.Insert(j + 1, Instruction.Create(OpCodes.Ldc_I4_0));
                            ins.Insert(j + 2, Instruction.Create(OpCodes.Call, envExit));
                            changes++;
                        }
                        break;
                    }
                }
            }
        }
        changes += shows;

        Console.WriteLine($"  CheckUpdate/Frmmain: disabled vendor online update (edits={changes}, Show() sites neutralized={shows})");
        return changes;
    }

    // Some user-visible strings (the About box title and description) come from
    // assembly custom attributes (AssemblyTitle / AssemblyDescription), not from
    // ldstr or form resources. Translate any attribute string-argument that
    // contains Han via the same TSV map. Unmatched Han is logged so the exact
    // value can be added to the table.
    private static int LocalizeAssemblyAttributes(ModuleDefMD mod, Dictionary<string, string> map)
    {
        int n = 0;
        var sets = new List<IList<CustomAttribute>>();
        if (mod.Assembly != null) sets.Add(mod.Assembly.CustomAttributes);
        sets.Add(mod.CustomAttributes);
        foreach (var attrs in sets)
            foreach (var ca in attrs)
                for (int i = 0; i < ca.ConstructorArguments.Count; i++)
                {
                    var arg = ca.ConstructorArguments[i];
                    string sv = arg.Value?.ToString();
                    if (sv == null || !HasHan(sv)) continue;
                    if (map.TryGetValue(sv, out var ru) && ru != sv)
                    {
                        ca.ConstructorArguments[i] = new CAArgument(arg.Type, new UTF8String(ru));
                        n++;
                    }
                    else
                    {
                        Console.WriteLine($"  WARN attr Han no-RU [{ca.TypeFullName}]: \"{Show(sv)}\"");
                    }
                }
        return n;
    }

    private static int RewriteResources(ModuleDefMD mod, Dictionary<string, string> map, HashSet<string> blankKeys = null)
    {
        blankKeys = blankKeys ?? new HashSet<string>(StringComparer.Ordinal);
        int replaced = 0;
        for (int ri = 0; ri < mod.Resources.Count; ri++)
        {
            if (!(mod.Resources[ri] is EmbeddedResource er) || !er.Name.String.EndsWith(".resources")) continue;
            byte[] bytes;
            using (var rd = er.CreateReader().AsStream())
            using (var ms = new System.IO.MemoryStream())
            { rd.CopyTo(ms); bytes = ms.ToArray(); }

            // First pass: collect ordered entries and detect whether any string
            // value in this resource is translated (otherwise skip the rewrite).
            var entries = new List<(string key, bool isStr, string val)>();
            bool needs = false;
            using (var ms = new System.IO.MemoryStream(bytes))
            using (var rr = new System.Resources.ResourceReader(ms))
            {
                var en = rr.GetEnumerator();
                while (true)
                {
                    try { if (!en.MoveNext()) break; } catch { break; }
                    string key = (string)en.Key;
                    object val;
                    try { val = en.Value; } catch { entries.Add((key, false, null)); continue; }
                    if (val is string sv)
                    {
                        entries.Add((key, true, sv));
                        if (map.ContainsKey(sv) || blankKeys.Contains(key)) needs = true;
                    }
                    else entries.Add((key, false, null));
                }
            }
            if (!needs) continue;

            byte[] outBytes;
            using (var rms = new System.IO.MemoryStream(bytes))
            using (var rr = new System.Resources.ResourceReader(rms))
            using (var oms = new System.IO.MemoryStream())
            {
                using (var rw = new System.Resources.ResourceWriter(oms))
                {
                    foreach (var e in entries)
                    {
                        if (e.isStr)
                        {
                            string v = e.val;
                            if (blankKeys.Contains(e.key)) { if (v != "") replaced++; v = ""; }
                            else if (map.TryGetValue(v, out var ru) && v != ru) { v = ru; replaced++; }
                            rw.AddResource(e.key, v);
                        }
                        else
                        {
                            rr.GetResourceData(e.key, out string type, out byte[] data);
                            rw.AddResourceData(e.key, type, data);
                        }
                    }
                    rw.Generate();
                }
                outBytes = oms.ToArray();
            }
            mod.Resources[ri] = new EmbeddedResource(er.Name, outBytes, er.Attributes);
            Console.WriteLine($"  rewrote resource {er.Name} ({entries.Count} entries)");
        }
        return replaced;
    }
}
