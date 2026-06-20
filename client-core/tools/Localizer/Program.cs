using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.W32Resources;
using dnlib.IO;

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

    // Intentionally a no-op: we must KEEP the assembly's public key. The licensing IPC handshake
    // derives a per-request token from GetEntryAssembly().GetName().GetPublicKeyToken() (see
    // code::Getpkt), and the SolidWorks add-in (PMPHandler::DefWndProc) validates each
    // "ZToolRequest@001" request against the original exe's token (f08fc7047657204e). Nulling the
    // public key makes GetPublicKeyToken() empty, Getpkt() yields the wrong token, and the add-in
    // rejects the request -> "read from SW" returns 0 positions. The caller also keeps the COR20
    // StrongNameSigned bit set (the full-trust loader skips signature verification), so the file
    // loads while preserving the public key token. Hence: preserve everything, do nothing here.
    private static int StripStrongName(ModuleDefMD mod)
    {
        var asm = mod.Assembly;
        if (asm == null) return 0;
        // Preserve PublicKey / PublicKey attribute on purpose; no edits here.
        return 0;
    }

    // The material/color context menu uses the component kind stored in
    // Col_Extname.Tag as an internal key. The vendor key is "零件"; it is not a
    // visible label in these methods. Translating it to "Деталь" makes commands
    // like "Случайный цвет" silently skip selected part rows or read material
    // colors without marking rows as parts.
    private static int RestoreMaterialPartKindKeys(ModuleDefMD mod)
    {
        int changes = 0;
        var methodNames = new HashSet<string>(StringComparer.Ordinal)
        {
            "GetMaterialName",
            "Material_list_ItemClicked",
            "mens_click",
            "addctl",
            "readstr",
        };

        var form = mod.GetTypes().FirstOrDefault(t => t.FullName == "ZTool.Frmmain");
        if (form == null) return 0;

        foreach (var method in form.Methods.Where(m => methodNames.Contains(m.Name) && m.Body != null))
        {
            foreach (var ins in method.Body.Instructions)
            {
                if (ins.OpCode.Code == Code.Ldstr && (ins.Operand as string) == "Деталь")
                {
                    ins.Operand = "零件";
                    changes++;
                }
            }
        }

        Console.WriteLine($"  material/color: restored internal part-kind key \"零件\" in Frmmain color handlers (edits={changes})");
        return changes;
    }

    private static bool IsMethodOperand(Instruction ins, string name, string declaringTypeName = null)
    {
        return ins?.Operand is IMethod m
            && m.Name == name
            && (declaringTypeName == null || m.DeclaringType?.Name == declaringTypeName);
    }

    private static Local GetLocalOperand(MethodDef method, Instruction ins)
    {
        if (method?.Body == null || ins == null) return null;
        switch (ins.OpCode.Code)
        {
            case Code.Ldloc_0:
            case Code.Stloc_0:
                return method.Body.Variables.Count > 0 ? method.Body.Variables[0] : null;
            case Code.Ldloc_1:
            case Code.Stloc_1:
                return method.Body.Variables.Count > 1 ? method.Body.Variables[1] : null;
            case Code.Ldloc_2:
            case Code.Stloc_2:
                return method.Body.Variables.Count > 2 ? method.Body.Variables[2] : null;
            case Code.Ldloc_3:
            case Code.Stloc_3:
                return method.Body.Variables.Count > 3 ? method.Body.Variables[3] : null;
            case Code.Ldloc:
            case Code.Ldloc_S:
            case Code.Stloc:
            case Code.Stloc_S:
                return ins.Operand as Local;
            default:
                return null;
        }
    }

    private static bool LoadsLocal(MethodDef method, Instruction ins, Local local)
    {
        return local != null
            && (ins.OpCode.Code == Code.Ldloc
                || ins.OpCode.Code == Code.Ldloc_S
                || ins.OpCode.Code == Code.Ldloc_0
                || ins.OpCode.Code == Code.Ldloc_1
                || ins.OpCode.Code == Code.Ldloc_2
                || ins.OpCode.Code == Code.Ldloc_3)
            && GetLocalOperand(method, ins) == local;
    }

    private static bool StoresLocal(MethodDef method, Instruction ins)
    {
        return GetLocalOperand(method, ins) != null
            && (ins.OpCode.Code == Code.Stloc
                || ins.OpCode.Code == Code.Stloc_S
                || ins.OpCode.Code == Code.Stloc_0
                || ins.OpCode.Code == Code.Stloc_1
                || ins.OpCode.Code == Code.Stloc_2
                || ins.OpCode.Code == Code.Stloc_3);
    }

    private static Instruction CloneInstruction(Instruction ins)
    {
        if (ins.Operand == null) return Instruction.Create(ins.OpCode);
        return new Instruction(ins.OpCode, ins.Operand);
    }

    private static IEnumerable<Instruction> LoadFrmmainColumnName(
        IMethod getForms,
        IMethod getFrmmain,
        IMethod getDgv1,
        IMethod getColumns,
        Local columnIndexLocal,
        IMethod getItem,
        IMethod getName)
    {
        yield return Instruction.Create(OpCodes.Call, getForms);
        yield return Instruction.Create(OpCodes.Callvirt, getFrmmain);
        yield return Instruction.Create(OpCodes.Callvirt, getDgv1);
        yield return Instruction.Create(OpCodes.Callvirt, getColumns);
        yield return Instruction.Create(OpCodes.Ldloc, columnIndexLocal);
        yield return Instruction.Create(OpCodes.Callvirt, getItem);
        yield return Instruction.Create(OpCodes.Callvirt, getName);
    }

    // BOM export originally applies namemappinglist only to PropVal_ /
    // PropResolvedVal_ columns. Computed service columns such as Col_Weight and
    // Col_bound have Excel-invalid headers ("Масса ед._кг",
    // "Габаритные размеры"), so they need the same mapping fallback by
    // DataGridViewColumn.Name. The export fallback below re-runs the
    // namemappinglist lookup (matched by column Name + header text), so it is
    // already generic for any column; Frmmapping is widened to display every
    // calculated/service column (every "Col_" column except the non-data
    // checkbox/new-folder columns) so users can map them by hand.
    private static int PatchBomCalculatedColumnMapping(ModuleDefMD mod)
    {
        int changes = 0;
        var frmmain = mod.Find("ZTool.Frmmain", false);
        if (frmmain != null)
        {
            foreach (var methodName in new[] { "ExportBom_xls1", "ExportBom_xls2", "ExportBom_xls3", "ExportBom_xls4" })
            {
                var method = frmmain.FindMethod(methodName);
                if (method?.Body == null) continue;
                var ins = method.Body.Instructions;

                int lookupStart = -1, lookupEnd = -1;
                Local mappingLocal = null;
                for (int i = 0; i < ins.Count - 1; i++)
                {
                    if (IsMethodOperand(ins[i], "get_Config", "CConfigMng")
                        && IsMethodOperand(ins[i + 1], "get_namemappinglist", "CConfigDO"))
                    {
                        lookupStart = i;
                        for (int j = i + 2; j < Math.Min(i + 12, ins.Count); j++)
                        {
                            if (IsMethodOperand(ins[j], "Find") && j + 1 < ins.Count && StoresLocal(method, ins[j + 1]))
                            {
                                lookupEnd = j + 1;
                                mappingLocal = GetLocalOperand(method, ins[j + 1]);
                                break;
                            }
                        }
                        if (lookupEnd >= 0) break;
                    }
                }
                if (lookupStart < 0 || lookupEnd < 0 || mappingLocal == null) continue;

                int nullCheck = -1;
                IMethod isNothing = null;
                for (int i = lookupEnd + 1; i < ins.Count - 1; i++)
                {
                    if (LoadsLocal(method, ins[i], mappingLocal)
                        && IsMethodOperand(ins[i + 1], "IsNothing", "Information"))
                    {
                        nullCheck = i;
                        isNothing = (IMethod)ins[i + 1].Operand;
                        break;
                    }
                }
                if (nullCheck < 0 || isNothing == null) continue;

                var skipFallback = Instruction.Create(OpCodes.Nop);
                var add = new List<Instruction>
                {
                    Instruction.Create(OpCodes.Ldloc, mappingLocal),
                    Instruction.Create(OpCodes.Call, isNothing),
                    Instruction.Create(OpCodes.Brfalse, skipFallback),
                };
                for (int i = lookupStart; i <= lookupEnd; i++)
                    add.Add(CloneInstruction(ins[i]));
                add.Add(skipFallback);

                for (int i = 0; i < add.Count; i++)
                    ins.Insert(nullCheck + i, add[i]);
                changes++;
            }
        }

        var mappingForm = mod.Find("ZTool.Frmmapping", false);
        var load = mappingForm?.FindMethod("Frmmapping_Load");
        if (load?.Body != null)
        {
            var ins = load.Body.Instructions;
            int stlocBool = -1;
            for (int i = 0; i < ins.Count - 4; i++)
            {
                if (ins[i].OpCode.Code == Code.Ldstr
                    && (ins[i].Operand as string) == "PropVal_"
                    && IsMethodOperand(ins[i + 1], "Contains", "String")
                    && ins[i + 2].OpCode.Code == Code.Ldc_I4_0
                    && ins[i + 3].OpCode.Code == Code.Ceq
                    && StoresLocal(load, ins[i + 4]))
                {
                    stlocBool = i + 4;
                    break;
                }
            }

            if (stlocBool >= 0)
            {
                var skipLocal = GetLocalOperand(load, ins[stlocBool]);
                IMethod getForms = null, getFrmmain = null, getDgv1 = null, getColumns = null, getItem = null, getName = null;
                Local columnIndexLocal = null;
                for (int i = Math.Max(0, stlocBool - 20); i < stlocBool; i++)
                {
                    if (IsMethodOperand(ins[i], "get_Forms")) getForms = (IMethod)ins[i].Operand;
                    else if (IsMethodOperand(ins[i], "get_Frmmain")) getFrmmain = (IMethod)ins[i].Operand;
                    else if (IsMethodOperand(ins[i], "get_DGV1")) getDgv1 = (IMethod)ins[i].Operand;
                    else if (IsMethodOperand(ins[i], "get_Columns")) getColumns = (IMethod)ins[i].Operand;
                    else if (IsMethodOperand(ins[i], "get_Item") && i > 0)
                    {
                        getItem = (IMethod)ins[i].Operand;
                        columnIndexLocal = GetLocalOperand(load, ins[i - 1]);
                    }
                    else if (IsMethodOperand(ins[i], "get_Name")) getName = (IMethod)ins[i].Operand;
                }

                var stringEquals = mod.GetTypes()
                    .SelectMany(t => t.Methods)
                    .Where(m => m.Body != null)
                    .SelectMany(m => m.Body.Instructions)
                    .Select(i => i.Operand as IMethod)
                    .FirstOrDefault(m => m != null
                        && m.Name == "Equals"
                        && m.DeclaringType?.FullName == "System.String"
                        && m.MethodSig?.Params.Count == 2);

                var stringStartsWith = mod.GetTypes()
                    .SelectMany(t => t.Methods)
                    .Where(m => m.Body != null)
                    .SelectMany(m => m.Body.Instructions)
                    .Select(i => i.Operand as IMethod)
                    .FirstOrDefault(m => m != null
                        && m.Name == "StartsWith"
                        && m.DeclaringType?.FullName == "System.String"
                        && m.MethodSig?.Params.Count == 2);

                if (skipLocal != null && getForms != null && getFrmmain != null
                    && getDgv1 != null && getColumns != null && getItem != null
                    && getName != null && columnIndexLocal != null && stringEquals != null
                    && stringStartsWith != null)
                {
                    // Show every calculated/service column (Name starts with
                    // "Col_") in the mapping grid, excluding the two non-data
                    // columns that have no meaningful header to map.
                    var after = Instruction.Create(OpCodes.Nop);
                    var add = new List<Instruction>
                    {
                        Instruction.Create(OpCodes.Ldloc, skipLocal),
                        Instruction.Create(OpCodes.Brfalse, after),
                    };
                    add.AddRange(LoadFrmmainColumnName(getForms, getFrmmain, getDgv1, getColumns, columnIndexLocal, getItem, getName));
                    add.Add(Instruction.Create(OpCodes.Ldstr, "Col_"));
                    add.Add(Instruction.CreateLdcI4(5)); // StringComparison.OrdinalIgnoreCase
                    add.Add(Instruction.Create(OpCodes.Callvirt, stringStartsWith));
                    add.Add(Instruction.Create(OpCodes.Brfalse, after));
                    foreach (var excluded in new[] { "Col_Checkbox", "Col_NewFolder" })
                    {
                        add.AddRange(LoadFrmmainColumnName(getForms, getFrmmain, getDgv1, getColumns, columnIndexLocal, getItem, getName));
                        add.Add(Instruction.Create(OpCodes.Ldstr, excluded));
                        add.Add(Instruction.CreateLdcI4(5));
                        add.Add(Instruction.Create(OpCodes.Callvirt, stringEquals));
                        add.Add(Instruction.Create(OpCodes.Brtrue, after));
                    }
                    add.Add(Instruction.Create(OpCodes.Ldc_I4_0));
                    add.Add(Instruction.Create(OpCodes.Stloc, skipLocal));
                    add.Add(after);

                    for (int i = 0; i < add.Count; i++)
                        ins.Insert(stlocBool + 1 + i, add[i]);
                    changes++;
                }
            }
        }

        Console.WriteLine($"  BOM mapping: enabled all calculated/service (Col_*) columns in mapping/export (edits={changes})");
        return changes;
    }

    // The original split-column dialog lets users add mapping rows, but it has
    // no explicit delete button. WinForms users naturally press Delete on the
    // selected grid row; make that path work for the three rule grids without
    // changing the split/match business logic.
    private static int PatchSplitColumnDeleteRows(ModuleDefMD mod)
    {
        var form = mod.Find("ZTool.FrmSplitcloumn", false);
        var init = form?.FindMethod("InitializeComponent");
        if (form == null || init?.Body == null) return 0;
        if (form.FindMethod("SplitGrid_KeyDown") != null) return 0;

        IMethod FindMethodRef(string name, string declaringTypeName = null, int? paramCount = null) =>
            mod.GetTypes()
                .SelectMany(t => t.Methods)
                .Where(m => m.Body != null)
                .SelectMany(m => m.Body.Instructions)
                .Select(i => i.Operand as IMethod)
                .FirstOrDefault(m => m != null
                    && m.Name == name
                    && (declaringTypeName == null || m.DeclaringType?.Name == declaringTypeName)
                    && (paramCount == null || m.MethodSig?.Params.Count == paramCount.Value));

        var addKeyDown = FindMethodRef("add_KeyDown");
        var keyHandlerCtor = FindMethodRef(".ctor", "KeyEventHandler");
        var getKeyCode = FindMethodRef("get_KeyCode", "KeyEventArgs");
        var setHandled = FindMethodRef("set_Handled", "HandledEventArgs")
            ?? FindMethodRef("set_Handled", "KeyEventArgs");
        var setSuppress = FindMethodRef("set_SuppressKeyPress", "KeyEventArgs");
        var getCurrentCell = FindMethodRef("get_CurrentCell", "DataGridView");
        var getRowIndex = FindMethodRef("get_RowIndex", "DataGridViewCell");
        var getRowCount = FindMethodRef("get_RowCount", "DataGridView");
        var endEdit = FindMethodRef("EndEdit", "DataGridView", paramCount: 0);
        var getRows = FindMethodRef("get_Rows", "DataGridView");
        var removeAt = FindMethodRef("RemoveAt", "DataGridViewRowCollection");

        if (addKeyDown == null || keyHandlerCtor == null || getKeyCode == null
            || setHandled == null || setSuppress == null || getCurrentCell == null
            || getRowIndex == null || getRowCount == null || endEdit == null
            || getRows == null || removeAt == null)
        {
            Console.WriteLine("  FrmSplitcloumn: Delete-row patch skipped (WinForms refs missing)");
            return 0;
        }

        var dataGridViewType = getCurrentCell.DeclaringType;
        var dataGridViewCellType = getRowIndex.DeclaringType;
        var keyEventArgsType = getKeyCode.DeclaringType;
        var exceptionType = mod.CorLibTypes.GetTypeRef("System", "Exception");

        var handler = new MethodDefUser(
            "SplitGrid_KeyDown",
            MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Object, new ClassSig(keyEventArgsType)),
            MethodImplAttributes.IL | MethodImplAttributes.Managed,
            MethodAttributes.Private | MethodAttributes.HideBySig);
        handler.Body = new CilBody { InitLocals = true };
        handler.Body.Variables.Add(new Local(new ClassSig(dataGridViewType))); // V_0: grid
        handler.Body.Variables.Add(new Local(new ClassSig(dataGridViewCellType))); // V_1: current cell
        handler.Body.Variables.Add(new Local(mod.CorLibTypes.Int32)); // V_2: row index

        var ret = Instruction.Create(OpCodes.Ret);
        var afterKeyCheck = Instruction.Create(OpCodes.Nop);
        var afterGridCheck = Instruction.Create(OpCodes.Nop);
        var afterCellCheck = Instruction.Create(OpCodes.Nop);
        var afterNonNegativeCheck = Instruction.Create(OpCodes.Nop);
        var afterBoundsCheck = Instruction.Create(OpCodes.Nop);
        var handlerStart = Instruction.Create(OpCodes.Pop);

        var body = handler.Body.Instructions;
        var tryStart = Instruction.Create(OpCodes.Ldarg_2);
        body.Add(tryStart);
        body.Add(Instruction.Create(OpCodes.Callvirt, getKeyCode));
        body.Add(Instruction.CreateLdcI4(46)); // System.Windows.Forms.Keys.Delete
        body.Add(Instruction.Create(OpCodes.Ceq));
        body.Add(Instruction.Create(OpCodes.Brtrue, afterKeyCheck));
        body.Add(Instruction.Create(OpCodes.Leave, ret));

        body.Add(afterKeyCheck);
        body.Add(Instruction.Create(OpCodes.Ldarg_1));
        body.Add(Instruction.Create(OpCodes.Isinst, dataGridViewType));
        body.Add(Instruction.Create(OpCodes.Stloc_0));
        body.Add(Instruction.Create(OpCodes.Ldloc_0));
        body.Add(Instruction.Create(OpCodes.Brtrue, afterGridCheck));
        body.Add(Instruction.Create(OpCodes.Leave, ret));

        body.Add(afterGridCheck);
        body.Add(Instruction.Create(OpCodes.Ldloc_0));
        body.Add(Instruction.Create(OpCodes.Callvirt, getCurrentCell));
        body.Add(Instruction.Create(OpCodes.Stloc_1));
        body.Add(Instruction.Create(OpCodes.Ldloc_1));
        body.Add(Instruction.Create(OpCodes.Brtrue, afterCellCheck));
        body.Add(Instruction.Create(OpCodes.Leave, ret));

        body.Add(afterCellCheck);
        body.Add(Instruction.Create(OpCodes.Ldloc_1));
        body.Add(Instruction.Create(OpCodes.Callvirt, getRowIndex));
        body.Add(Instruction.Create(OpCodes.Stloc_2));
        body.Add(Instruction.Create(OpCodes.Ldloc_2));
        body.Add(Instruction.CreateLdcI4(0));
        body.Add(Instruction.Create(OpCodes.Bge, afterNonNegativeCheck));
        body.Add(Instruction.Create(OpCodes.Leave, ret));
        body.Add(afterNonNegativeCheck);
        body.Add(Instruction.Create(OpCodes.Ldloc_2));
        body.Add(Instruction.Create(OpCodes.Ldloc_0));
        body.Add(Instruction.Create(OpCodes.Callvirt, getRowCount));
        body.Add(Instruction.Create(OpCodes.Blt, afterBoundsCheck));
        body.Add(Instruction.Create(OpCodes.Leave, ret));

        body.Add(afterBoundsCheck);
        body.Add(Instruction.Create(OpCodes.Ldloc_0));
        body.Add(Instruction.Create(OpCodes.Callvirt, endEdit));
        body.Add(Instruction.Create(OpCodes.Pop));
        body.Add(Instruction.Create(OpCodes.Ldloc_0));
        body.Add(Instruction.Create(OpCodes.Callvirt, getRows));
        body.Add(Instruction.Create(OpCodes.Ldloc_2));
        body.Add(Instruction.Create(OpCodes.Callvirt, removeAt));
        body.Add(Instruction.Create(OpCodes.Ldarg_2));
        body.Add(Instruction.CreateLdcI4(1));
        body.Add(Instruction.Create(OpCodes.Callvirt, setHandled));
        body.Add(Instruction.Create(OpCodes.Ldarg_2));
        body.Add(Instruction.CreateLdcI4(1));
        body.Add(Instruction.Create(OpCodes.Callvirt, setSuppress));
        body.Add(Instruction.Create(OpCodes.Leave, ret));

        body.Add(handlerStart);
        body.Add(Instruction.Create(OpCodes.Leave, ret));
        body.Add(ret);
        handler.Body.ExceptionHandlers.Add(new ExceptionHandler(ExceptionHandlerType.Catch)
        {
            CatchType = exceptionType,
            TryStart = tryStart,
            TryEnd = handlerStart,
            HandlerStart = handlerStart,
            HandlerEnd = ret,
        });
        form.Methods.Add(handler);

        int changes = 1;
        foreach (var getterName in new[] { "get_dgv_match", "get_dgv2", "get_dgv_split" })
        {
            var getter = form.FindMethod(getterName);
            if (getter == null) continue;
            var retIns = init.Body.Instructions.LastOrDefault(i => i.OpCode.Code == Code.Ret);
            if (retIns == null) continue;
            var add = new[]
            {
                Instruction.Create(OpCodes.Ldarg_0),
                Instruction.Create(OpCodes.Callvirt, getter),
                Instruction.Create(OpCodes.Ldarg_0),
                Instruction.Create(OpCodes.Ldftn, handler),
                Instruction.Create(OpCodes.Newobj, keyHandlerCtor),
                Instruction.Create(OpCodes.Callvirt, addKeyDown),
                Instruction.Create(OpCodes.Nop),
            };
            foreach (var ins in add)
                init.Body.Instructions.Insert(init.Body.Instructions.IndexOf(retIns), ins);
            changes++;
        }

        Console.WriteLine($"  FrmSplitcloumn: Delete removes the current split-rule row (edits={changes})");
        return changes;
    }

    private sealed class DialogLayout
    {
        public DialogLayout(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }

    private static readonly Dictionary<string, DialogLayout> DialogLayoutOverrides =
        new Dictionary<string, DialogLayout>(StringComparer.Ordinal)
        {
            ["FrmSaveOption"] = new DialogLayout(820, 460),
            ["Frmexportbom"] = new DialogLayout(1160, 560),
            ["Frmmapping"] = new DialogLayout(780, 520),
            ["FrmFilterrules"] = new DialogLayout(920, 560),
            ["FrmFilling"] = new DialogLayout(760, 540),
            ["FrmSWUnit"] = new DialogLayout(640, 650),
            ["FrmOptions"] = new DialogLayout(760, 560),
        };

    private sealed class ControlPatch
    {
        public ControlPatch(
            string name,
            int? left = null,
            int? top = null,
            int? width = null,
            int? height = null,
            string text = null,
            int? anchor = null,
            int? dock = null)
        {
            Name = name;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            Text = text;
            Anchor = anchor;
            Dock = dock;
        }

        public string Name { get; }
        public int? Left { get; }
        public int? Top { get; }
        public int? Width { get; }
        public int? Height { get; }
        public string Text { get; }
        public int? Anchor { get; }
        public int? Dock { get; }
    }

    private static readonly Dictionary<string, ControlPatch[]> ControlLayoutPatches =
        new Dictionary<string, ControlPatch[]>(StringComparer.Ordinal)
        {
            ["FrmSaveOption"] = new[]
            {
                new ControlPatch("GroupBox1", width: 340),
                new ControlPatch("ComboBox1", width: 318),
                new ControlPatch("ComboBox2", width: 318),
                new ControlPatch("ComboBox3", width: 318),
                new ControlPatch("ComboBox4", width: 318),
                new ControlPatch("CheckBox9", width: 300, text: "и удалить из сл. расположения"),
                new ControlPatch("CheckBox1", width: 300),
                new ControlPatch("CheckBox2", width: 250, text: "Сохранять пустые"),
                new ControlPatch("CheckBox3", width: 145, text: "Обновлять ед."),
                new ControlPatch("CheckBox10", width: 260, text: "Автосохранение"),
                new ControlPatch("LinkLabel2", left: 165, width: 150, text: "Настройки"),
                new ControlPatch("GroupBox2", left: 360, width: 430),
                new ControlPatch("CheckBox7", width: 240, text: "Пропускать read-only"),
                new ControlPatch("CheckBox4", width: 240),
                new ControlPatch("Label2", width: 310),
                new ControlPatch("RadioButton2", width: 170),
                new ControlPatch("GroupBox3", left: 360, width: 430),
                new ControlPatch("TextBox1", width: 385),
                new ControlPatch("Button1", left: 395),
                new ControlPatch("CheckBox8", left: 300, width: 100),
                new ControlPatch("Label3", width: 220),
                new ControlPatch("TableLayoutPanel1", left: 320, width: 490),
                new ControlPatch("Save_Failed", text: "Не сохран."),
                new ControlPatch("Save_Changed", text: "Изменённые"),
            },
            ["Frmexportbom"] = new[]
            {
                new ControlPatch("GroupBox5", width: 410),
                new ControlPatch("bomsettinglist", width: 392),
                new ControlPatch("TableLayoutPanel2", width: 394),
                new ControlPatch("add", width: 100, text: "Добавить"),
                new ControlPatch("edit", width: 130, text: "Переименовать"),
                new ControlPatch("del", width: 100, text: "Удалить"),
                new ControlPatch("Button3", left: 1114),
                new ControlPatch("Label1", left: 430, width: 150),
                new ControlPatch("ComboBox1", left: 585, width: 520),
                new ControlPatch("GroupBox1", left: 430, width: 160),
                new ControlPatch("RadioButton3", width: 140),
                new ControlPatch("RadioButton4", width: 130),
                new ControlPatch("GroupBox4", left: 605, width: 220),
                new ControlPatch("Propertyvalue", width: 180),
                new ControlPatch("Propertylink", width: 180),
                new ControlPatch("includetop", width: 160),
                new ControlPatch("GroupBox2", left: 840, width: 310),
                new ControlPatch("RuleList", width: 324),
                new ControlPatch("GroupBox3", left: 430, width: 390),
                new ControlPatch("lockratio", width: 250),
                new ControlPatch("ByRuler", left: 840, width: 78),
                new ControlPatch("ByFilter", left: 930, width: 78),
                new ControlPatch("TableLayoutPanel1", left: 860, width: 292),
                new ControlPatch("Button1", width: 80),
                new ControlPatch("Apply_Button", width: 95),
                new ControlPatch("OK_Button", width: 80),
            },
            ["Frmmapping"] = new[]
            {
                new ControlPatch("DGV1", width: 760, height: 360),
                new ControlPatch("Label1", top: 380, width: 760, height: 80),
            },
            ["Frmsetpropname"] = new[]
            {
                // The "Импорт..." button ships with AnchorStyles.None, so once
                // the dialog is made resizable it drifts toward the centre as the
                // form grows. Pin it to the bottom-left corner (Bottom|Left = 6).
                new ControlPatch("Button1", anchor: 6),
            },
            ["FrmFilterrules"] = new[]
            {
                new ControlPatch("GroupBox1", width: 220),
                new ControlPatch("RuleNameList", width: 202),
                new ControlPatch("TableLayoutPanel2", width: 204),
                new ControlPatch("add", text: "Доб."),
                new ControlPatch("edit", text: "Изм."),
                new ControlPatch("del", text: "Удал."),
                new ControlPatch("GroupBox2", left: 250, width: 560),
                new ControlPatch("DGV1", width: 540),
                new ControlPatch("Label1", width: 540),
            },
            ["FrmFilling"] = new[]
            {
                new ControlPatch("TabControl1", left: 0, top: 0, width: 760, height: 492, anchor: 15, dock: 0),
                new ControlPatch("TableLayoutPanel2", left: 560, top: 500, width: 190, anchor: 10),

                new ControlPatch("Label1", width: 230),
                new ControlPatch("ComboBox1", width: 630, anchor: 13),
                new ControlPatch("TextBox1", width: 510, height: 76, anchor: 5),
                new ControlPatch("Label3", top: 68, width: 160),
                new ControlPatch("Label6", left: 545, top: 68, width: 90),
                new ControlPatch("NumericUpDown1", left: 635, top: 66),
                new ControlPatch("Button1", left: 545, top: 120, width: 130, text: "Вставить ссылку"),
                new ControlPatch("GroupBox1", top: 180, width: 720, height: 270, anchor: 15),
                new ControlPatch("Label5", left: 280, width: 430, height: 105),
                new ControlPatch("Label7", width: 280),

                new ControlPatch("GroupBox5", left: 8, top: 8, width: 270, height: 420, anchor: 7),
                new ControlPatch("fillsettinglist", width: 250, height: 340, anchor: 15, dock: 0),
                new ControlPatch("TableLayoutPanel1", top: 378, width: 250, anchor: 6),
                new ControlPatch("add", width: 72, text: "Доб."),
                new ControlPatch("edit", width: 86, text: "Переим."),
                new ControlPatch("del", width: 72, text: "Удал."),
                new ControlPatch("GroupBox2", left: 295, top: 8, width: 430, height: 185, anchor: 13),
                new ControlPatch("RuleList", width: 410, height: 138),
                new ControlPatch("GroupBox3", left: 295, top: 210, width: 430, height: 170, anchor: 13),
                new ControlPatch("Label2", width: 220),
                new ControlPatch("ComboBox2", width: 395, anchor: 13),
                new ControlPatch("TextBox3", width: 395, anchor: 13),

                new ControlPatch("GroupBox4", left: 8, top: 8, width: 720, height: 120, anchor: 13),
                new ControlPatch("datasource", width: 610, anchor: 13),
                new ControlPatch("Button3", left: 682, width: 36, anchor: 9),
                new ControlPatch("Label11", width: 120),
                new ControlPatch("srownumer", left: 135),
                new ControlPatch("Label15", left: 250, width: 95),
                new ControlPatch("datacount", left: 350, width: 40),
                new ControlPatch("Button2", left: 430, width: 150, text: "Обновить данные"),
                new ControlPatch("GroupBox6", left: 8, top: 145, width: 720, height: 155, anchor: 13),
                new ControlPatch("Label12", left: 130, width: 95),
                new ControlPatch("ComboBox3", left: 235, width: 460, anchor: 13),
                new ControlPatch("Label13", width: 55),
                new ControlPatch("rcolnumer2", left: 70),
                new ControlPatch("Label14", left: 145, width: 90),
                new ControlPatch("ComboBox4", left: 235, width: 460, anchor: 13),

                new ControlPatch("DGV1", dock: 5),
                new ControlPatch("Panel1", dock: 2),
                new ControlPatch("Label16", text: "Двойной щелчок по строке — записать в главное окно; Del — удалить строку."),
            },
            ["FrmSWUnit"] = new[]
            {
                new ControlPatch("GroupBox1", width: 600),
                new ControlPatch("Unit_MMKS", width: 200, text: "MMKS (мм, кг, с)"),
                new ControlPatch("Unit_MMGS", left: 330, width: 150),
                new ControlPatch("Unit_IPS", left: 330, width: 180),
                new ControlPatch("Unit_Custom", left: 330, width: 180),
                new ControlPatch("GroupBox2", width: 500),
                new ControlPatch("GroupBox3", width: 500),
                new ControlPatch("GroupBox4", width: 500),
                new ControlPatch("Label3", width: 100, text: "Двойной размер"),
                new ControlPatch("Label7", width: 80, text: "Объём"),
            },
            ["FrmOptions"] = new[]
            {
                new ControlPatch("TabControl1", width: 760, height: 500),
                new ControlPatch("Label3", width: 120, text: "Подсветка строк:"),
                new ControlPatch("Label1", width: 100, text: "Версия SW:"),
                new ControlPatch("Label4", width: 145, text: "Пакетные эскизы:"),
                new ControlPatch("PreviewMode", left: 180, width: 240),
                new ControlPatch("Thumbnail_Savetolocal", width: 285),
                new ControlPatch("Thumbnail_position", left: 315, width: 180),
                new ControlPatch("Button3", width: 210),
                new ControlPatch("Button7", left: 250, width: 230),
                new ControlPatch("macrolist", width: 590),
                new ControlPatch("Panel3", left: 600, width: 150),
                new ControlPatch("Button8", width: 130),
                new ControlPatch("Button9", width: 130),
            },
        };

    private static bool IsSizeCtor(Instruction ins) =>
        (ins.OpCode.Code == Code.Call || ins.OpCode.Code == Code.Newobj)
        && ins.Operand is IMethod ctor
        && ctor.Name == ".ctor"
        && ctor.DeclaringType != null
        && ctor.DeclaringType.Name == "Size";

    private static (int width, int height)? TryReadClientSize(MethodDef init)
    {
        if (init?.Body == null) return null;
        var ins = init.Body.Instructions;
        for (int i = 0; i < ins.Count; i++)
        {
            if (!(ins[i].Operand is IMethod m) || m.Name != "set_ClientSize") continue;
            for (int j = i - 1; j >= 2 && j >= i - 20; j--)
            {
                if (IsSizeCtor(ins[j]) && ins[j - 2].IsLdcI4() && ins[j - 1].IsLdcI4())
                    return (ins[j - 2].GetLdcI4Value(), ins[j - 1].GetLdcI4Value());
            }
        }
        return null;
    }

    private static bool HasFixedDialogBorder(MethodDef init)
    {
        if (init?.Body == null) return false;
        var ins = init.Body.Instructions;
        for (int i = 1; i < ins.Count; i++)
        {
            if (!(ins[i].Operand is IMethod m) || m.Name != "set_FormBorderStyle") continue;
            if (ins[i - 1].IsLdcI4())
            {
                int v = ins[i - 1].GetLdcI4Value();
                if (v == 1 || v == 2 || v == 3) return true; // FixedSingle/3D/FixedDialog
            }
        }
        return false;
    }

    private static IMethod FindMethodRef(ModuleDefMD mod, string name, string declaringTypeName, int? paramCount = null)
    {
        return mod.GetTypes()
            .SelectMany(t => t.Methods)
            .Where(m => m.Body != null)
            .SelectMany(m => m.Body.Instructions)
            .Select(i => i.Operand as IMethod)
            .FirstOrDefault(m => m != null
                && m.Name == name
                && (declaringTypeName == null || m.DeclaringType?.Name == declaringTypeName)
                && (paramCount == null || m.MethodSig?.Params.Count == paramCount.Value));
    }

    private static AssemblyRef FindAssemblyRef(ModuleDefMD mod, string name) =>
        mod.GetAssemblyRefs().FirstOrDefault(a => string.Equals(a.Name, name, StringComparison.Ordinal));

    private static MemberRefUser MakeWinFormsSetter(ModuleDefMD mod, string declaringTypeName, string setterName, TypeSig paramType)
    {
        var asm = FindAssemblyRef(mod, "System.Windows.Forms");
        if (asm == null) return null;
        var type = new TypeRefUser(mod, "System.Windows.Forms", declaringTypeName, asm);
        return new MemberRefUser(mod, setterName, MethodSig.CreateInstance(mod.CorLibTypes.Void, paramType), type);
    }

    private static TypeRefUser MakeControlType(ModuleDefMD mod)
    {
        var asm = FindAssemblyRef(mod, "System.Windows.Forms");
        return asm == null ? null : new TypeRefUser(mod, "System.Windows.Forms", "Control", asm);
    }

    private static TypeRefUser MakeControlCollectionType(ModuleDefMD mod, TypeRefUser controlType) =>
        controlType == null ? null : new TypeRefUser(mod, "", "ControlCollection", controlType);

    private static MemberRefUser MakeControlGetter(ModuleDefMD mod, TypeRefUser controlType, TypeRefUser collectionType) =>
        new MemberRefUser(
            mod,
            "get_Controls",
            MethodSig.CreateInstance(new ClassSig(collectionType)),
            controlType);

    private static MemberRefUser MakeControlCollectionFind(ModuleDefMD mod, TypeRefUser controlType, TypeRefUser collectionType) =>
        new MemberRefUser(
            mod,
            "Find",
            MethodSig.CreateInstance(new SZArraySig(new ClassSig(controlType)), mod.CorLibTypes.String, mod.CorLibTypes.Boolean),
            collectionType);

    private static MemberRefUser MakeControlIntSetter(ModuleDefMD mod, TypeRefUser controlType, string setterName) =>
        new MemberRefUser(
            mod,
            setterName,
            MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Int32),
            controlType);

    private static MemberRefUser MakeControlTextSetter(ModuleDefMD mod, TypeRefUser controlType) =>
        new MemberRefUser(
            mod,
            "set_Text",
            MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.String),
            controlType);

    private static void AddFindControl(List<Instruction> add, IMethod getControls, IMethod findControl, string controlName)
    {
        add.Add(Instruction.Create(OpCodes.Ldarg_0));
        add.Add(Instruction.Create(OpCodes.Callvirt, getControls));
        add.Add(Instruction.Create(OpCodes.Ldstr, controlName));
        add.Add(Instruction.CreateLdcI4(1));
        add.Add(Instruction.Create(OpCodes.Callvirt, findControl));
        add.Add(Instruction.CreateLdcI4(0));
        add.Add(Instruction.Create(OpCodes.Ldelem_Ref));
    }

    private static int AddControlLayoutInstructions(
        ModuleDefMD mod,
        string formName,
        List<Instruction> add,
        IMethod getControls,
        IMethod findControl,
        IMethod setLeft,
        IMethod setTop,
        IMethod setWidth,
        IMethod setHeight,
        IMethod setText,
        IMethod setAnchor,
        IMethod setDock)
    {
        if (!ControlLayoutPatches.TryGetValue(formName, out var patches)) return 0;
        int edits = 0;
        foreach (var patch in patches)
        {
            if (patch.Dock.HasValue && setDock != null)
            {
                AddFindControl(add, getControls, findControl, patch.Name);
                add.Add(Instruction.CreateLdcI4(patch.Dock.Value));
                add.Add(Instruction.Create(OpCodes.Callvirt, setDock));
                edits += 8;
            }
            if (patch.Left.HasValue)
            {
                AddFindControl(add, getControls, findControl, patch.Name);
                add.Add(Instruction.CreateLdcI4(patch.Left.Value));
                add.Add(Instruction.Create(OpCodes.Callvirt, setLeft));
                edits += 8;
            }
            if (patch.Top.HasValue)
            {
                AddFindControl(add, getControls, findControl, patch.Name);
                add.Add(Instruction.CreateLdcI4(patch.Top.Value));
                add.Add(Instruction.Create(OpCodes.Callvirt, setTop));
                edits += 8;
            }
            if (patch.Width.HasValue)
            {
                AddFindControl(add, getControls, findControl, patch.Name);
                add.Add(Instruction.CreateLdcI4(patch.Width.Value));
                add.Add(Instruction.Create(OpCodes.Callvirt, setWidth));
                edits += 8;
            }
            if (patch.Height.HasValue)
            {
                AddFindControl(add, getControls, findControl, patch.Name);
                add.Add(Instruction.CreateLdcI4(patch.Height.Value));
                add.Add(Instruction.Create(OpCodes.Callvirt, setHeight));
                edits += 8;
            }
            if (patch.Text != null)
            {
                AddFindControl(add, getControls, findControl, patch.Name);
                add.Add(Instruction.Create(OpCodes.Ldstr, patch.Text));
                add.Add(Instruction.Create(OpCodes.Callvirt, setText));
                edits += 8;
            }
            if (patch.Anchor.HasValue && setAnchor != null)
            {
                AddFindControl(add, getControls, findControl, patch.Name);
                add.Add(Instruction.CreateLdcI4(patch.Anchor.Value));
                add.Add(Instruction.Create(OpCodes.Callvirt, setAnchor));
                edits += 8;
            }
        }
        return edits;
    }

    private static MemberRefUser MakeMinimumSizeSetter(ModuleDefMD mod)
    {
        var formsAsm = FindAssemblyRef(mod, "System.Windows.Forms");
        var drawingAsm = FindAssemblyRef(mod, "System.Drawing");
        if (formsAsm == null || drawingAsm == null) return null;
        var controlType = new TypeRefUser(mod, "System.Windows.Forms", "Control", formsAsm);
        var sizeType = new TypeRefUser(mod, "System.Drawing", "Size", drawingAsm);
        return new MemberRefUser(
            mod,
            "set_MinimumSize",
            MethodSig.CreateInstance(mod.CorLibTypes.Void, new ValueTypeSig(sizeType)),
            controlType);
    }

    private static int InsertBeforeRet(MethodDef method, IEnumerable<Instruction> additions)
    {
        var body = method?.Body;
        if (body == null) return 0;
        var ret = body.Instructions.LastOrDefault(i => i.OpCode.Code == Code.Ret);
        if (ret == null) return 0;
        int index = body.Instructions.IndexOf(ret);
        int count = 0;
        foreach (var ins in additions)
        {
            body.Instructions.Insert(index++, ins);
            count++;
        }
        return count;
    }

    private static int NormalizeLongRussianUiStrings(ModuleDefMD mod)
    {
        var replacements = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["-Если имя сопоставления пустое или совпадает с заголовком столбца, сопоставление для столбца не применяется;\r\n-Имя сопоставления должно совпадать с пользовательским именем в шаблоне Excel;\r\n-Сопоставление заголовков нужно в основном для решения проблем синтаксиса пользовательских имён в шаблоне Excel,\r\nа также путаницы в данных спецификации из-за повторяющихся заголовков столбцов;"] =
                "Пустое имя или имя, совпадающее с заголовком, не применяется.\r\nИмя должно совпадать с пользовательским именем в Excel-шаблоне.\r\nИспользуйте сопоставление для повторяющихся или проблемных заголовков.",
            ["Выберите заголовок строки и нажмите Del для удаления всей строки;\r\nнесколько значений можно разделять латинской точкой с запятой;"] =
                "Del на заголовке строки удаляет всю строку.\r\nНесколько значений разделяйте латинской точкой с запятой.",
            ["Сохранять только изменённые"] = "Только изменённые",
            ["Только изменённые"] = "Изменённые",
            ["Сохранять только несохранённые"] = "Несохранённые",
            ["Только несохранённые"] = "Несохранённые",
            ["Исходное расположение (новое свойство в каждую конфигурацию)"] = "Исходное расположение",
            ["Исходное расположение (новое свойство в «Настраиваемые»)"] = "Исходное (настраиваемые)",
            ["Исходное расположение (новое свойство в «Конфигурация»)"] = "Исходное (конфигурация)",
            ["Автосохранение после изменения свойств"] = "Автосохранение после изменений",
            ["Сохранять свойства с пустым значением"] = "Сохранять пустые свойства",
            ["и удалить лишние свойства из следующего расположения"] = "и удалить лишние свойства",
            ["Перезаписывать файлы с тем же именем (осторожно)"] = "Перезаписывать файлы",
            ["Пропускать файлы только для чтения"] = "Пропускать read-only файлы",
            ["После переименования старые файлы переместить в"] = "После переименования старые файлы:",
            ["Сохранять пропорции (исходное соотношение)"] = "Сохранять пропорции",
            ["Сохранять пропорции (исходное соотношение 4:3)"] = "Сохранять пропорции (4:3)",
            ["Только верхний уровень"] = "Только верхний",
            ["Включая самый верхний уровень"] = "Включая верхний",
            ["Выводить значения свойств"] = "Значения свойств",
            ["Выводить выражения свойств"] = "Выражения свойств",
            ["Отмечать элементы без чертежей"] = "Без чертежей",
            ["Автоширина столбцов"] = "Автоширина",
            ["Включить правило"] = "Правило",
            ["Включить фильтр"] = "Фильтр",
            ["Обрабатываемые детали"] = "Обрабат. детали",
            ["Без обработки поверхности"] = "Без обработки",
            ["Недостающие обязательные свойства"] = "Нет обязат. свойств",
            ["Включая подпапки"] = "Подпапки",
            ["Перейти к настройкам"] = "Настройки",
            ["Перейти к настройке"] = "Настройки",
            ["Заполнять элементы, удовлетворяющие пользовательскому правилу"] = "Заполнять строки по правилу",
            ["Описание:\r\n{ } — начальное значение инкремента;\r\n$ИмяСвойства$ — значение свойства\r\n%ИмяСвойства% — выражение свойства\r\n<ЗаголовокСтолбца> — значение из другого столбца\r\n"] =
                "Описание:\r\n{ } — шаг инкремента\r\n$ИмяСвойства$ — значение свойства\r\n%ИмяСвойства% — выражение\r\n<Заголовок> — значение столбца",
            ["Объём кэшируемых данных:"] = "Кэш данных:",
            ["-го столбца искать"] = "столбца искать",
            ["-й столбец"] = "строка",
            ["записать данные в"] = "записать в",
            ["Длина (двойной размер)"] = "Двойной размер",
            ["Единица объёма"] = "Объём",
            ["MKS (метр, килограмм, секунда)"] = "MKS (м, кг, с)",
            ["MMGS (миллиметр, грамм, секунда)"] = "MMGS (мм, г, с)",
            ["MMKS (миллиметр, килограмм, секунда)"] = "MMKS (мм, кг, с)",
            ["CGS (сантиметр, грамм, секунда)"] = "CGS (см, г, с)",
            ["IPS (дюйм, фунт, секунда)"] = "IPS (дюйм, фунт, с)",
            ["Читать свойства каждой конфигурации (только для деталей)"] = "Читать свойства всех конфигураций (детали)",
            ["Двойной щелчок по значку — открыть компонент или чертёж в SOLIDWORKS"] = "Двойной щелчок по значку открывает файл в SOLIDWORKS",
            ["Скрывать интерфейс SolidWorks при работе пакетных инструментов"] = "Скрывать SolidWorks при пакетной обработке",
            ["Включать предпросмотр файлов в пакетных инструментах"] = "Предпросмотр файлов в пакетных инструментах",
        };

        int ldstr = 0;
        foreach (var t in mod.GetTypes())
            foreach (var m in t.Methods)
            {
                if (m.Body == null) continue;
                foreach (var ins in m.Body.Instructions)
                {
                    if (ins.OpCode.Code == Code.Ldstr
                        && ins.Operand is string s
                        && replacements.TryGetValue(s, out var shorter)
                        && s != shorter)
                    {
                        ins.Operand = shorter;
                        ldstr++;
                    }
                }
            }

        int res = RewriteResources(mod, replacements);
        Console.WriteLine($"  UI text: shortened long Russian captions (ldstr={ldstr}, resources={res})");
        return ldstr + res;
    }

    private static int PatchDialogReadabilityLayout(ModuleDefMD mod)
    {
        var setFormBorderStyle = FindMethodRef(mod, "set_FormBorderStyle", "Form", 1);
        var setMaximizeBox = FindMethodRef(mod, "set_MaximizeBox", "Form", 1);
        var setMinimizeBox = FindMethodRef(mod, "set_MinimizeBox", "Form", 1);
        var setClientSize = FindMethodRef(mod, "set_ClientSize", "Form", 1);
        var sizeCtor = FindMethodRef(mod, ".ctor", "Size", 2);
        var setMinimumSize = MakeMinimumSizeSetter(mod);
        var setAutoScroll = MakeWinFormsSetter(mod, "ScrollableControl", "set_AutoScroll", mod.CorLibTypes.Boolean);
        var controlType = MakeControlType(mod);
        var controlCollectionType = MakeControlCollectionType(mod, controlType);
        var getControls = controlType != null && controlCollectionType != null ? MakeControlGetter(mod, controlType, controlCollectionType) : null;
        var findControl = controlType != null && controlCollectionType != null ? MakeControlCollectionFind(mod, controlType, controlCollectionType) : null;
        var setLeft = controlType != null ? MakeControlIntSetter(mod, controlType, "set_Left") : null;
        var setTop = controlType != null ? MakeControlIntSetter(mod, controlType, "set_Top") : null;
        var setWidth = controlType != null ? MakeControlIntSetter(mod, controlType, "set_Width") : null;
        var setHeight = controlType != null ? MakeControlIntSetter(mod, controlType, "set_Height") : null;
        var setText = controlType != null ? MakeControlTextSetter(mod, controlType) : null;
        var setAnchor = FindMethodRef(mod, "set_Anchor", "Control", 1);
        var setDock = FindMethodRef(mod, "set_Dock", "Control", 1);

        if (setFormBorderStyle == null || setClientSize == null || sizeCtor == null || setMinimumSize == null)
        {
            Console.WriteLine("  dialog layout: skipped (WinForms layout refs missing)");
            return 0;
        }

        int forms = 0, edits = 0;
        foreach (var form in mod.GetTypes().Where(t => t.BaseType?.FullName == "System.Windows.Forms.Form"))
        {
            var init = form.FindMethod("InitializeComponent");
            if (init?.Body == null) continue;

            var size = TryReadClientSize(init);
            bool hasOverride = DialogLayoutOverrides.TryGetValue(form.Name, out var layout);
            if (!hasOverride && !HasFixedDialogBorder(init)) continue;

            int targetW = hasOverride ? layout.Width : (size?.width ?? 0);
            int targetH = hasOverride ? layout.Height : (size?.height ?? 0);
            if (targetW <= 0 || targetH <= 0) continue;

            var add = new List<Instruction>();
            if (setAutoScroll != null)
            {
                add.Add(Instruction.Create(OpCodes.Ldarg_0));
                add.Add(Instruction.CreateLdcI4(1));
                add.Add(Instruction.Create(OpCodes.Callvirt, setAutoScroll));
            }

            add.Add(Instruction.Create(OpCodes.Ldarg_0));
            add.Add(Instruction.CreateLdcI4(4)); // FormBorderStyle.Sizable
            add.Add(Instruction.Create(OpCodes.Callvirt, setFormBorderStyle));
            if (setMaximizeBox != null)
            {
                add.Add(Instruction.Create(OpCodes.Ldarg_0));
                add.Add(Instruction.CreateLdcI4(1));
                add.Add(Instruction.Create(OpCodes.Callvirt, setMaximizeBox));
            }
            if (setMinimizeBox != null)
            {
                add.Add(Instruction.Create(OpCodes.Ldarg_0));
                add.Add(Instruction.CreateLdcI4(1));
                add.Add(Instruction.Create(OpCodes.Callvirt, setMinimizeBox));
            }

            if (hasOverride)
            {
                add.Add(Instruction.Create(OpCodes.Ldarg_0));
                add.Add(Instruction.CreateLdcI4(layout.Width));
                add.Add(Instruction.CreateLdcI4(layout.Height));
                add.Add(Instruction.Create(OpCodes.Newobj, sizeCtor));
                add.Add(Instruction.Create(OpCodes.Callvirt, setClientSize));
            }

            add.Add(Instruction.Create(OpCodes.Ldarg_0));
            add.Add(Instruction.CreateLdcI4(targetW));
            add.Add(Instruction.CreateLdcI4(targetH));
            add.Add(Instruction.Create(OpCodes.Newobj, sizeCtor));
            add.Add(Instruction.Create(OpCodes.Callvirt, setMinimumSize));

            int controlEdits = 0;
            if (getControls != null && findControl != null && setLeft != null && setTop != null && setWidth != null && setHeight != null && setText != null)
            {
                controlEdits = AddControlLayoutInstructions(
                    mod,
                    form.Name,
                    add,
                    getControls,
                    findControl,
                    setLeft,
                    setTop,
                    setWidth,
                    setHeight,
                    setText,
                    setAnchor,
                    setDock);
            }

            int inserted = InsertBeforeRet(init, add);
            if (inserted > 0)
            {
                forms++;
                edits += inserted;
                string old = size.HasValue ? $"{size.Value.width}x{size.Value.height}" : "resource";
                string reason = hasOverride ? $"default {old}->{targetW}x{targetH}" : $"minimum {targetW}x{targetH}";
                string detail = controlEdits > 0 ? $", control-edits={controlEdits}" : "";
                Console.WriteLine($"  dialog layout: {form.Name} resizable, {reason}, inserted={inserted}{detail}");
            }
        }

        Console.WriteLine($"  dialog layout: patched forms={forms}, il edits={edits}");
        return edits;
    }

    private static (ushort major, ushort minor, ushort build, ushort revision, string display) ParseFileVersion(string version)
    {
        var parts = (version ?? "")
            .Split(new[] { '.', '-', '+', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(p => p.All(char.IsDigit))
            .Select(p => int.TryParse(p, out var n) ? Math.Max(0, Math.Min(65535, n)) : 0)
            .ToList();
        while (parts.Count < 4) parts.Add(0);
        string display = $"{parts[0]}.{parts[1]}.{parts[2]}";
        return ((ushort)parts[0], (ushort)parts[1], (ushort)parts[2], (ushort)parts[3], display);
    }

    // In-place patch of the Win32 VS_VERSIONINFO so FileVersion/ProductVersion report
    // the release train instead of the vendor's leftover 3.8.4.0. This does not touch
    // the managed assembly identity/Application.ProductVersion used by licensing.
    private static int NormalizeWin32Version(string exePath, string releaseVersion)
    {
        var parsed = ParseFileVersion(releaseVersion);
        byte[] b = System.IO.File.ReadAllBytes(exePath);
        int edits = 0;

        // 1) VS_FIXEDFILEINFO (signature 0xFEEF04BD): patch only the block whose file+product
        //    version is exactly 3.8.4.0 (MS=0x00030008, LS=0x00040000).
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
                    uint ms = (uint)((parsed.major << 16) | parsed.minor);
                    uint ls = (uint)((parsed.build << 16) | parsed.revision);
                    BitConverter.GetBytes(ms).CopyTo(b, i + 8);
                    BitConverter.GetBytes(ls).CopyTo(b, i + 12);
                    BitConverter.GetBytes(ms).CopyTo(b, i + 16);
                    BitConverter.GetBytes(ls).CopyTo(b, i + 20);
                    edits++;
                }
            }
        }

        // 2) StringFileInfo "FileVersion"/"ProductVersion" values. Keep the PE resource
        // length stable; for the 1.x.x train this remains the same five UTF-16 chars as "3.8.4".
        byte[] from = Encoding.Unicode.GetBytes("3.8.4");
        byte[] to = Encoding.Unicode.GetBytes(parsed.display);
        if (to.Length == from.Length)
        {
            for (int i = 0; i <= b.Length - from.Length; i++)
            {
                bool m = true;
                for (int j = 0; j < from.Length; j++) if (b[i + j] != from[j]) { m = false; break; }
                if (m) { Array.Copy(to, 0, b, i, to.Length); edits++; i += from.Length - 1; }
            }
        }

        if (edits > 0) System.IO.File.WriteAllBytes(exePath, b);
        return edits;
    }

    // ---- Win32 VS_VERSIONINFO brand rewrite (ProductName/CompanyName/Internal/Original ----
    // The managed ModuleWriter copies the vendor's Win32 RT_VERSION resource verbatim, so its
    // StringFileInfo still reports "ZTool" in Explorer -> Properties -> Details. Because the
    // brand strings change length ("ZTool" -> "SWTools"), we cannot byte-patch in place; we
    // parse the VS_VERSIONINFO tree, rewrite the target String values, and re-serialize with
    // correct wLength/wValueLength. This runs on mod.Win32Resources BEFORE mod.Write so dnlib
    // re-lays-out the .rsrc section. Only the genuine RT_VERSION blob is touched (embedded
    // component version strings live in managed resources, not here).
    private sealed class VNode
    {
        public ushort Type;
        public string Key = "";
        public byte[] Value = Array.Empty<byte>();
        public ushort ValueLen;
        public List<VNode> Children = new List<VNode>();
    }

    private static readonly HashSet<string> _verBrandKeys = new HashSet<string>(StringComparer.Ordinal)
    {
        "ProductName", "CompanyName", "InternalName", "OriginalFilename", "LegalTrademarks"
    };

    private static int Align4(int x) => (x + 3) & ~3;

    private static VNode ParseVNode(byte[] b, int pos, out int end)
    {
        ushort wLength = BitConverter.ToUInt16(b, pos);
        ushort wValueLength = BitConverter.ToUInt16(b, pos + 2);
        ushort wType = BitConverter.ToUInt16(b, pos + 4);
        int p = pos + 6;
        int ks = p;
        while (BitConverter.ToUInt16(b, p) != 0) p += 2;
        string key = Encoding.Unicode.GetString(b, ks, p - ks);
        p += 2;
        p = Align4(p);
        int valBytes = (wType == 1) ? wValueLength * 2 : wValueLength;
        byte[] val = new byte[valBytes];
        Array.Copy(b, p, val, 0, valBytes);
        p += valBytes;
        var node = new VNode { Type = wType, Key = key, Value = val, ValueLen = wValueLength };
        int nodeEnd = pos + wLength;
        p = Align4(p);
        while (p < nodeEnd)
        {
            var child = ParseVNode(b, p, out int cEnd);
            node.Children.Add(child);
            p = Align4(cEnd);
        }
        end = nodeEnd;
        return node;
    }

    private static byte[] SerializeVNode(VNode n)
    {
        var ms = new System.IO.MemoryStream();
        void w16(ushort v) { ms.WriteByte((byte)(v & 0xff)); ms.WriteByte((byte)((v >> 8) & 0xff)); }
        void pad() { while ((ms.Length & 3) != 0) ms.WriteByte(0); }
        w16(0); // wLength placeholder
        w16(n.ValueLen);
        w16(n.Type);
        byte[] kb = Encoding.Unicode.GetBytes(n.Key);
        ms.Write(kb, 0, kb.Length);
        w16(0); // key terminator
        pad();
        if (n.Value != null && n.Value.Length > 0) ms.Write(n.Value, 0, n.Value.Length);
        long leafLen = ms.Length;
        long wLength;
        if (n.Children.Count > 0)
        {
            pad();
            for (int i = 0; i < n.Children.Count; i++)
            {
                byte[] cb = SerializeVNode(n.Children[i]);
                ms.Write(cb, 0, cb.Length);
                if (i < n.Children.Count - 1) pad();
            }
            wLength = ms.Length;
        }
        else wLength = leafLen;
        byte[] arr = ms.ToArray();
        arr[0] = (byte)(wLength & 0xff);
        arr[1] = (byte)((wLength >> 8) & 0xff);
        return arr;
    }

    private static int RebrandVTree(VNode n)
    {
        int c = 0;
        if (n.Type == 1 && n.Children.Count == 0 &&
            (_verBrandKeys.Contains(n.Key) || n.Key == "FileDescription" || n.Key == "LegalCopyright"))
        {
            string val = Encoding.Unicode.GetString(n.Value);
            int z = val.IndexOf('\0');
            if (z >= 0) val = val.Substring(0, z);
            string nv;
            if (n.Key == "FileDescription") nv = "SWTools — надстройка SolidWorks";
            else if (n.Key == "LegalCopyright") nv = "© SWTools";
            else nv = val.Replace("ZTool", "SWTools");
            if (nv != val)
            {
                n.Value = Encoding.Unicode.GetBytes(nv + "\0");
                n.ValueLen = (ushort)(nv.Length + 1);
                c++;
            }
        }
        foreach (var ch in n.Children) c += RebrandVTree(ch);
        return c;
    }

    private static byte[] RebuildVersionBlob(byte[] b, out int count)
    {
        count = 0;
        try
        {
            var root = ParseVNode(b, 0, out _);
            count = RebrandVTree(root);
            return count == 0 ? b : SerializeVNode(root);
        }
        catch { count = 0; return b; }
    }

    private static int RebrandWin32VersionStrings(ModuleDefMD mod)
    {
        var res = mod.Win32Resources;
        if (res == null || res.Root == null) return 0;
        int total = 0;
        foreach (var typeDir in res.Root.Directories)
        {
            if (!typeDir.Name.HasId || typeDir.Name.Id != 16) continue; // RT_VERSION
            foreach (var nameDir in typeDir.Directories)
            {
                for (int i = 0; i < nameDir.Data.Count; i++)
                {
                    var data = nameDir.Data[i];
                    byte[] blob = data.CreateReader().ToArray();
                    byte[] nb = RebuildVersionBlob(blob, out int cnt);
                    if (cnt > 0)
                    {
                        var factory = ByteArrayDataReaderFactory.Create(nb, null);
                        nameDir.Data[i] = new ResourceData(data.Name, factory, 0, (uint)nb.Length);
                        total += cnt;
                    }
                }
            }
        }
        return total;
    }

    private static int Main(string[] args)
    {
        try { Console.OutputEncoding = new UTF8Encoding(false); } catch { /* redirected console may reject */ }
        if (args.Length < 1)
        {
            Console.WriteLine("usage: localize --scan <exe>");
            Console.WriteLine("       localize <inExe> <outExe> [translations.tsv] [release-version]");
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
            string releaseVersion = args.Length >= 4 ? args[3] : "1.0.0";
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
            string assetDir = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(tablePath));
            string qrPng = System.IO.Path.Combine(assetDir, "max_qr.png");
            int maxQrChanges = InjectMaxQr(mod, qrPng);
            int frmRgChanges = TuneFrmRg(mod);
            int verifyChanges = PatchVerifyContacts(mod);
            int aboutTitleChanges = FixAboutTitle(mod);
            int updateChanges = DisableUpdateCheck(mod);
            int pktChanges = PatchHandshakePkt(mod);
            int nameForced = ForceAssemblyName(mod, "ZTool");
            int brandAttrChanges = SetBrandAttributes(mod);
            int brandStrChanges = RebrandClientStrings(mod);
            int attrChanges = LocalizeAssemblyAttributes(mod, map);
            int materialKeyChanges = RestoreMaterialPartKindKeys(mod);
            int splitDeleteChanges = PatchSplitColumnDeleteRows(mod);
            int bomMappingChanges = PatchBomCalculatedColumnMapping(mod);
            int uiTextChanges = NormalizeLongRussianUiStrings(mod);
            int dialogLayoutChanges = PatchDialogReadabilityLayout(mod);
            int aboutBoxChanges = PatchAboutBox(mod,
                System.IO.Path.Combine(assetDir, "swtools_logo.png"));
            // Strong-name handling: KEEP both the public key AND the COR20 "StrongNameSigned"
            // header bit. The licensing IPC handshake derives a token from
            // GetEntryAssembly().GetName().GetPublicKeyToken() (code::Getpkt) which the add-in
            // validates; nulling the key broke that (0-positions read). The original signature can
            // never be valid again (no vendor private key), but a locally launched, full-trust exe
            // skips strong-name *signature verification* (the .NET full-trust bypass, on by default),
            // so the file still loads as long as the StrongNameSigned bit stays set and the public
            // key is present. CLEARING the bit (delay-signed presentation) makes the loader reject
            // the assembly with a strong-name failure (verified: Assembly.LoadFrom -> 0x8013141A,
            // and the add-in launcher then opens no window). This mirrors the working vendor base.exe
            // (StrongNameSigned set + public key f08fc7047657204e).
            int snStripped = StripStrongName(mod);
            int win32Brand = RebrandWin32VersionStrings(mod);
            var wopts = new dnlib.DotNet.Writer.ModuleWriterOptions(mod);
            var curFlags = mod.Metadata.ImageCor20Header.Flags;
            wopts.Cor20HeaderOptions.Flags = curFlags | dnlib.DotNet.MD.ComImageFlags.StrongNameSigned;
            mod.Write(outExe, wopts);
            // dnlib preserves the vendor's Win32 VS_VERSIONINFO (FileVersion/ProductVersion = 3.8.4.0,
            // shown by Explorer / FileVersionInfo). The activation key is derived from the *managed*
            // Application.ProductVersion (="1.0"), not this resource, so 3.8.4 is cosmetic only.
            int win32Ver = NormalizeWin32Version(outExe, releaseVersion);
            Console.WriteLine($"localized: ldstr replaced={replaced}, vendor ldstr blanked={blanked}, resource strings replaced={resReplaced}, max-qr edits={maxQrChanges}, frmrg edits={frmRgChanges}, about-title edits={aboutTitleChanges}, update edits={updateChanges}, handshake-pkt edits={pktChanges}, asm-name-forced={nameForced}, brand-attrs={brandAttrChanges}, brand-strings={brandStrChanges}, attr strings={attrChanges}, material-key edits={materialKeyChanges}, split-delete edits={splitDeleteChanges}, bom-mapping edits={bomMappingChanges}, ui-text edits={uiTextChanges}, dialog-layout edits={dialogLayoutChanges}, about-box edits={aboutBoxChanges}, verify edits={verifyChanges}, win32-ver edits={win32Ver}, win32-brand edits={win32Brand}, strongname-stripped={snStripped} -> {outExe}");
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

    private const string BrandOld = "ZTool", BrandNew = "SWTools";

    // Product rebrand ZTool -> SWTools. The window captions (Frmmain/FrmRg/FrmRverify),
    // the About-box caption and the settings file name (CConfigMng builds it as
    // Application.ProductName + ".settings") are ALL derived from
    // Application.ProductName == AssemblyProductAttribute. Rewriting that attribute (and
    // AssemblyTitle, which the About caption uses as its "{0}") rebrands every caption and
    // the settings file in one shot.
    //
    // The INTERNAL assembly Name is deliberately left as "ZTool" (see ForceAssemblyName):
    // the SolidWorks add-in launcher SwAddin.openZtool matches the exe by
    // AssemblyName.GetAssemblyName(path).Name == "ZTool", and the IPC handshake prefix
    // "ZToolRequest@001" is assembled inside the obfuscated add-in DLL (it is NOT a plain
    // string there, so it cannot be rewritten without breaking the protected methods).
    // Renaming either would break the SolidWorks integration with no user-visible effect,
    // so both stay as inert internal plumbing.
    private static int SetBrandAttributes(ModuleDefMD mod)
    {
        int n = 0;
        var sets = new List<IList<CustomAttribute>>();
        if (mod.Assembly != null) sets.Add(mod.Assembly.CustomAttributes);
        sets.Add(mod.CustomAttributes);
        foreach (var attrs in sets)
            foreach (var ca in attrs)
            {
                var tn = ca.AttributeType?.Name ?? "";
                if (tn != "AssemblyProductAttribute" && tn != "AssemblyTitleAttribute") continue;
                for (int i = 0; i < ca.ConstructorArguments.Count; i++)
                {
                    var arg = ca.ConstructorArguments[i];
                    if (arg.Value?.ToString() == BrandOld)
                    {
                        ca.ConstructorArguments[i] = new CAArgument(arg.Type, new UTF8String(BrandNew));
                        n++;
                    }
                }
            }
        Console.WriteLine($"  rebrand: product/title attributes \"{BrandOld}\"->\"{BrandNew}\" (edits={n})");
        return n;
    }

    // Rewrite the handful of plain "ZTool" string literals that are user-visible or
    // brand-bearing: the HKCU\SOFTWARE\ZTool licensing key (3 sites), the desktop-shortcut
    // display name + file, and the BOM document Author tag. Also retargets the native
    // dongle P/Invoke module name. Exact whole-operand matches only, so the embedded
    // resource namespace ("ZTool.Resources", "ZTool.*.bmp") and the handshake prefix
    // ("ZToolRequest@001") are intentionally untouched.
    private static int RebrandClientStrings(ModuleDefMD mod)
    {
        var exact = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "ZTool", "SWTools" },
            { "ZTool.lnk", "SWTools.lnk" },
            { "ZToolARM.dll", "SWToolsARM.dll" },
            { "«ZToolARM.dll» отсутствует", "«SWToolsARM.dll» отсутствует" },
            { "ZTool: проверка обновлений", "SWTools: проверка обновлений" },
            { "ZTool Updater", "SWTools Updater" },
            { "ZTool Updater\\.exe$", "SWTools Updater\\.exe$" },
            { "«ZTool Updater.exe» отсутствует! Не удаётся запустить программу обновления!",
              "«SWTools Updater.exe» отсутствует! Не удаётся запустить программу обновления!" },
        };
        int n = 0;
        foreach (var t in mod.GetTypes())
            foreach (var m in t.Methods)
            {
                if (m.Body == null) continue;
                foreach (var ins in m.Body.Instructions)
                    if (ins.OpCode.Code == Code.Ldstr && ins.Operand is string s && exact.TryGetValue(s, out var repl))
                    { ins.Operand = repl; n++; }
            }
        int pinv = 0;
        foreach (var mr in mod.GetModuleRefs())
            if (mr.Name == "ZToolARM.dll") { mr.Name = "SWToolsARM.dll"; pinv++; }
        Console.WriteLine($"  rebrand: ldstr literals (edits={n}), dongle p/invoke module (edits={pinv})");
        return n + pinv;
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

    // The user's public website (clickable hyperlink in the About box).
    private const string SiteUrl = "https://license.vizbuka.ru/swtools/";

    // Rebuilds the About box (FrmAbout) into a clean, professional layout per the
    // user's request: vendor logo banner on top, a clickable website hyperlink,
    // two phone numbers each preceded by its country flag (KZ / RU), the e-mail,
    // and the existing clickable "MAX" link + QR code. Everything else (QQ group,
    // version line, "supported OS" line, the red description label and the
    // "update log" button) is removed. The flags are embedded as plain manifest
    // resources (decoded at runtime with new Bitmap(stream), as InjectMaxQr does).
    //
    // The work is done by an injected instance helper `zt_AboutSetup` which we
    // call at the very end of AboutBox1_Load (after the original code, so our
    // texts/positions win). The original TableLayoutPanel content is simply hidden
    // (Visible=false) and fresh, absolutely-positioned controls are added to the
    // form, which is switched to a fixed-size, centered dialog.
    private static int PatchAboutBox(ModuleDefMD mod, string logoPath)
    {
        var about = mod.Find("ZTool.FrmAbout", false);
        var load = about?.FindMethod("AboutBox1_Load");
        if (about == null || load?.Body == null)
        {
            Console.WriteLine("  FrmAbout: layout patch skipped (form/Load not found)");
            return 0;
        }
        if (about.FindMethod("zt_AboutSetup") != null) return 0; // idempotent

        var wf = FindAssemblyRef(mod, "System.Windows.Forms");
        var dr = FindAssemblyRef(mod, "System.Drawing");
        if (wf == null || dr == null)
        {
            Console.WriteLine("  FrmAbout: layout patch skipped (WinForms/Drawing refs missing)");
            return 0;
        }

        var corlib = mod.CorLibTypes.AssemblyRef;
        TypeRefUser WF(string n) => new TypeRefUser(mod, "System.Windows.Forms", n, wf);
        TypeRefUser DR(string n) => new TypeRefUser(mod, "System.Drawing", n, dr);
        TypeRefUser CL(string ns, string n) => new TypeRefUser(mod, ns, n, corlib);

        // --- framework type refs ---
        var trControl = WF("Control");
        var trCtrlColl = new TypeRefUser(mod, "", "ControlCollection", trControl); // nested Control.ControlCollection
        var trLabel = WF("Label");
        var trLinkLabel = WF("LinkLabel");
        var trPictureBox = WF("PictureBox");
        var trForm = WF("Form");
        var trLinkHandler = WF("LinkLabelLinkClickedEventHandler");
        var trPoint = DR("Point");
        var trSize = DR("Size");
        var trFont = DR("Font");
        var trImage = DR("Image");
        var trBitmap = DR("Bitmap");

        // SWTools logo banner: replaces the vendor "ZTOOL" bitmap. The PNG is embedded
        // (alongside the QR/asset embedding below) and decoded at runtime via the same
        // new Bitmap(GetManifestResourceStream(...)) refs used for the other resources.
        const string logoRes = "SWToolsLogo.png";
        bool haveLogo = !string.IsNullOrEmpty(logoPath) && System.IO.File.Exists(logoPath);

        var sigControl = new ClassSig(trControl);
        var sigCtrlColl = new ClassSig(trCtrlColl);
        var sigImage = new ClassSig(trImage);
        var sigPoint = new ValueTypeSig(trPoint);
        var sigSize = new ValueTypeSig(trSize);
        var sigFont = new ClassSig(trFont);
        var sigContentAlign = new ValueTypeSig(DR("ContentAlignment"));
        var sigFontStyle = new ValueTypeSig(DR("FontStyle"));
        var sigSizeMode = new ValueTypeSig(WF("PictureBoxSizeMode"));
        var sigImageLayout = new ValueTypeSig(WF("ImageLayout"));
        var sigFormBorder = new ValueTypeSig(WF("FormBorderStyle"));
        var sigStartPos = new ValueTypeSig(WF("FormStartPosition"));
        var sigLinkHandler = new ClassSig(trLinkHandler);

        // --- member refs ---
        var getControls = new MemberRefUser(mod, "get_Controls", MethodSig.CreateInstance(sigCtrlColl), trControl);
        var ccAdd = new MemberRefUser(mod, "Add", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigControl), trCtrlColl);
        var setText = new MemberRefUser(mod, "set_Text", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.String), trControl);
        var setFont = new MemberRefUser(mod, "set_Font", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigFont), trControl);
        var setLocation = new MemberRefUser(mod, "set_Location", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigPoint), trControl);
        var setCtrlSize = new MemberRefUser(mod, "set_Size", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigSize), trControl);
        var setVisible = new MemberRefUser(mod, "set_Visible", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trControl);
        var setBackImage = new MemberRefUser(mod, "set_BackgroundImage", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigImage), trControl);
        var getBackImage = new MemberRefUser(mod, "get_BackgroundImage", MethodSig.CreateInstance(sigImage), trControl);
        var setBackLayout = new MemberRefUser(mod, "set_BackgroundImageLayout", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigImageLayout), trControl);
        var setAnchor = new MemberRefUser(mod, "set_Anchor", MethodSig.CreateInstance(mod.CorLibTypes.Void, new ValueTypeSig(WF("AnchorStyles"))), trControl);
        var suspendLayout = new MemberRefUser(mod, "SuspendLayout", MethodSig.CreateInstance(mod.CorLibTypes.Void), trControl);
        var resumeLayout = new MemberRefUser(mod, "ResumeLayout", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trControl);

        var labCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void), trLabel);
        var labAutoSize = new MemberRefUser(mod, "set_AutoSize", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trLabel);
        var labTextAlign = new MemberRefUser(mod, "set_TextAlign", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigContentAlign), trLabel);

        var linkCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void), trLinkLabel);
        var linkAutoSize = new MemberRefUser(mod, "set_AutoSize", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trLinkLabel);
        var linkTextAlign = new MemberRefUser(mod, "set_TextAlign", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigContentAlign), trLinkLabel);
        var addLinkClicked = new MemberRefUser(mod, "add_LinkClicked", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigLinkHandler), trLinkLabel);

        var picCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void), trPictureBox);
        var setImage = new MemberRefUser(mod, "set_Image", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigImage), trPictureBox);
        var setSizeMode = new MemberRefUser(mod, "set_SizeMode", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigSizeMode), trPictureBox);

        var setFormBorder = new MemberRefUser(mod, "set_FormBorderStyle", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigFormBorder), trForm);
        var setMaxBox = new MemberRefUser(mod, "set_MaximizeBox", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trForm);
        var setClientSize = new MemberRefUser(mod, "set_ClientSize", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigSize), trForm);
        var setStartPos = new MemberRefUser(mod, "set_StartPosition", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigStartPos), trForm);

        var pointCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Int32, mod.CorLibTypes.Int32), trPoint);
        var sizeCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Int32, mod.CorLibTypes.Int32), trSize);
        var fontCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.String, mod.CorLibTypes.Single, sigFontStyle), trFont);
        var linkHandlerCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Object, mod.CorLibTypes.IntPtr), trLinkHandler);

        // FrmAbout property getters (MethodDefs already on the form).
        var getPic1 = about.FindMethod("get_PictureBox1");
        var getPic2 = about.FindMethod("get_PictureBox2");
        var getTlp = about.FindMethod("get_TableLayoutPanel1");
        var getBtn1 = about.FindMethod("get_Button1");
        var getOk = about.FindMethod("get_OKButton");
        if (getPic1 == null || getPic2 == null || getTlp == null || getBtn1 == null || getOk == null)
        {
            Console.WriteLine("  FrmAbout: layout patch skipped (control accessors missing)");
            return 0;
        }

        // Process.Start(string) — reuse the existing ref from the MAX link handler.
        var procStart = mod.GetTypes().SelectMany(t => t.Methods).Where(m => m.Body != null)
            .SelectMany(m => m.Body.Instructions).Select(i => i.Operand as IMethod)
            .FirstOrDefault(m => m != null && m.Name == "Start" && m.DeclaringType?.Name == "Process"
                && m.MethodSig?.Params.Count == 1);
        if (procStart == null)
        {
            Console.WriteLine("  FrmAbout: layout patch skipped (Process.Start ref missing)");
            return 0;
        }

        // Process.Start(string, string): launch URLs out-of-process via explorer.exe so a
        // broken or missing default-browser association can never fault the host process.
        var procParent = (procStart as MemberRef)?.Class;
        var procStart2 = procParent == null ? null : new MemberRefUser(mod, "Start",
            MethodSig.CreateStatic(procStart.MethodSig.RetType, mod.CorLibTypes.String, mod.CorLibTypes.String),
            procParent);

        // refs for the runtime flag-image loader (mirrors InjectMaxQr).
        var typeRef = CL("System", "Type");
        var rthRef = CL("System", "RuntimeTypeHandle");
        var asmRef = CL("System.Reflection", "Assembly");
        var streamRef = CL("System.IO", "Stream");
        var streamSig = new ClassSig(streamRef);
        var mGetTypeFromHandle = new MemberRefUser(mod, "GetTypeFromHandle",
            MethodSig.CreateStatic(new ClassSig(typeRef), new ValueTypeSig(rthRef)), typeRef);
        var mGetAssembly = new MemberRefUser(mod, "get_Assembly",
            MethodSig.CreateInstance(new ClassSig(asmRef)), typeRef);
        var mGetStream = new MemberRefUser(mod, "GetManifestResourceStream",
            MethodSig.CreateInstance(streamSig, mod.CorLibTypes.String), asmRef);
        var mBitmapCtor = new MemberRefUser(mod, ".ctor",
            MethodSig.CreateInstance(mod.CorLibTypes.Void, streamSig), trBitmap);

        // embed the SWTools logo PNG as a plain manifest resource.
        void Embed(string resName, string path)
        {
            if (System.IO.File.Exists(path) && !mod.Resources.Any(r => r.Name == resName))
                mod.Resources.Add(new EmbeddedResource(resName, System.IO.File.ReadAllBytes(path), ManifestResourceAttributes.Public));
        }
        if (haveLogo) Embed(logoRes, logoPath);

        // --- inject static helper:  Image zt_AboutImg(string name) ---
        var imgHelper = new MethodDefUser("zt_AboutImg",
            MethodSig.CreateStatic(sigImage, mod.CorLibTypes.String),
            MethodImplAttributes.IL | MethodImplAttributes.Managed,
            MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig);
        imgHelper.Body = new CilBody();
        var ih = imgHelper.Body.Instructions;
        ih.Add(Instruction.Create(OpCodes.Ldtoken, about));
        ih.Add(Instruction.Create(OpCodes.Call, mGetTypeFromHandle));
        ih.Add(Instruction.Create(OpCodes.Callvirt, mGetAssembly));
        ih.Add(Instruction.Create(OpCodes.Ldarg_0));
        ih.Add(Instruction.Create(OpCodes.Callvirt, mGetStream));
        ih.Add(Instruction.Create(OpCodes.Newobj, mBitmapCtor));
        ih.Add(Instruction.Create(OpCodes.Ret));
        about.Methods.Add(imgHelper);

        // --- inject the two link-click handlers (object, LinkLabelLinkClickedEventArgs) ---
        var linkArgs = new ClassSig(WF("LinkLabelLinkClickedEventArgs"));
        var exceptionRef = new TypeRefUser(mod, "System", "Exception", mod.CorLibTypes.AssemblyRef);
        MethodDefUser MakeLinkHandler(string name, string url)
        {
            var h = new MethodDefUser(name,
                MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Object, linkArgs),
                MethodImplAttributes.IL | MethodImplAttributes.Managed,
                MethodAttributes.Private | MethodAttributes.HideBySig);
            h.Body = new CilBody();
            var ins = h.Body.Instructions;
            // try { Process.Start("explorer.exe", url); } catch { }
            // Open the URL through explorer.exe (a child process) rather than an in-process
            // ShellExecute. A misconfigured / missing default-browser association must never
            // crash the host app: an in-process Process.Start(url) can raise an
            // AccessViolationException from the Windows shell — a corrupted-state exception a
            // managed catch cannot trap — whereas delegating to a child process keeps any such
            // fault out of ZTool. The catch still swallows ordinary launch failures.
            var ret = Instruction.Create(OpCodes.Ret);
            var tryStart = (procStart2 != null)
                ? Instruction.Create(OpCodes.Ldstr, "explorer.exe")
                : Instruction.Create(OpCodes.Ldstr, url);
            ins.Add(tryStart);
            if (procStart2 != null)
            {
                ins.Add(Instruction.Create(OpCodes.Ldstr, url));
                ins.Add(Instruction.Create(OpCodes.Call, procStart2));
            }
            else
            {
                ins.Add(Instruction.Create(OpCodes.Call, procStart));
            }
            ins.Add(Instruction.Create(OpCodes.Pop));
            ins.Add(Instruction.Create(OpCodes.Leave_S, ret));
            var handlerStart = Instruction.Create(OpCodes.Pop); // discard the caught exception
            ins.Add(handlerStart);
            ins.Add(Instruction.Create(OpCodes.Leave_S, ret));
            ins.Add(ret);
            h.Body.ExceptionHandlers.Add(new ExceptionHandler(ExceptionHandlerType.Catch)
            {
                TryStart = tryStart,
                TryEnd = handlerStart,
                HandlerStart = handlerStart,
                HandlerEnd = ret,
                CatchType = exceptionRef,
            });
            about.Methods.Add(h);
            return h;
        }
        var webClick = MakeLinkHandler("zt_AboutWeb_Click", SiteUrl);
        var maxClick = MakeLinkHandler("zt_AboutMax_Click", MaxUrl);

        // --- inject the layout builder:  void zt_AboutSetup() ---
        var setup = new MethodDefUser("zt_AboutSetup",
            MethodSig.CreateInstance(mod.CorLibTypes.Void),
            MethodImplAttributes.IL | MethodImplAttributes.Managed,
            MethodAttributes.Private | MethodAttributes.HideBySig);
        setup.Body = new CilBody { InitLocals = true };
        var locLink = new Local(new ClassSig(trLinkLabel));
        var locLabel = new Local(new ClassSig(trLabel));
        var locPic = new Local(new ClassSig(trPictureBox));
        setup.Body.Variables.Add(locLink);
        setup.Body.Variables.Add(locLabel);
        setup.Body.Variables.Add(locPic);
        var S = setup.Body.Instructions;

        Instruction Ld0() => Instruction.Create(OpCodes.Ldarg_0);
        Instruction LdL(Local l) => Instruction.Create(OpCodes.Ldloc, l);
        Instruction I4(int n) => Instruction.CreateLdcI4(n);
        void E(params Instruction[] xs) { foreach (var x in xs) S.Add(x); }

        // common control configuration helpers (operate on a stored local)
        void CSetLoc(Local l, int x, int y) => E(LdL(l), I4(x), I4(y), Instruction.Create(OpCodes.Newobj, pointCtor), Instruction.Create(OpCodes.Callvirt, setLocation));
        void CSetSize(Local l, int w, int h) => E(LdL(l), I4(w), I4(h), Instruction.Create(OpCodes.Newobj, sizeCtor), Instruction.Create(OpCodes.Callvirt, setCtrlSize));
        void CSetText(Local l, string s) => E(LdL(l), Instruction.Create(OpCodes.Ldstr, s), Instruction.Create(OpCodes.Callvirt, setText));
        void CSetFont(Local l, float sz, int style) => E(LdL(l), Instruction.Create(OpCodes.Ldstr, "Segoe UI"), Instruction.Create(OpCodes.Ldc_R4, sz), I4(style), Instruction.Create(OpCodes.Newobj, fontCtor), Instruction.Create(OpCodes.Callvirt, setFont));
        void CAdd(Local l) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, getControls), LdL(l), Instruction.Create(OpCodes.Callvirt, ccAdd));
        // getter-based existing controls
        void GLoc(MethodDef g, int x, int y) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), I4(x), I4(y), Instruction.Create(OpCodes.Newobj, pointCtor), Instruction.Create(OpCodes.Callvirt, setLocation));
        void GSize(MethodDef g, int w, int h) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), I4(w), I4(h), Instruction.Create(OpCodes.Newobj, sizeCtor), Instruction.Create(OpCodes.Callvirt, setCtrlSize));
        void GVisible(MethodDef g, bool v) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), I4(v ? 1 : 0), Instruction.Create(OpCodes.Callvirt, setVisible));

        const int CW = 360, CH = 342;
        const int MidC = 32; // ContentAlignment.MiddleCenter

        E(Ld0(), Instruction.Create(OpCodes.Callvirt, suspendLayout));

        // form -> fixed, centered dialog
        E(Ld0(), I4(3), Instruction.Create(OpCodes.Callvirt, setFormBorder)); // FixedDialog
        E(Ld0(), I4(0), Instruction.Create(OpCodes.Callvirt, setMaxBox));
        E(Ld0(), I4(1), Instruction.Create(OpCodes.Callvirt, setStartPos)); // CenterScreen
        E(Ld0(), I4(CW), I4(CH), Instruction.Create(OpCodes.Newobj, sizeCtor), Instruction.Create(OpCodes.Callvirt, setClientSize));

        // hide the original grid layout + the update-log button
        GVisible(getTlp, false);
        GVisible(getBtn1, false);

        // logo banner: load the embedded SWTools logo (falls back to the vendor
        // PictureBox1 image if the PNG asset is unavailable at build time).
        E(Instruction.Create(OpCodes.Newobj, picCtor), Instruction.Create(OpCodes.Stloc, locPic));
        if (haveLogo)
            E(LdL(locPic),
              Instruction.Create(OpCodes.Ldtoken, (ITypeDefOrRef)about),
              Instruction.Create(OpCodes.Call, mGetTypeFromHandle),
              Instruction.Create(OpCodes.Callvirt, mGetAssembly),
              Instruction.Create(OpCodes.Ldstr, logoRes),
              Instruction.Create(OpCodes.Callvirt, mGetStream),
              Instruction.Create(OpCodes.Newobj, mBitmapCtor),
              Instruction.Create(OpCodes.Callvirt, setBackImage));
        else
            E(LdL(locPic), Ld0(), Instruction.Create(OpCodes.Callvirt, getPic1), Instruction.Create(OpCodes.Callvirt, getBackImage), Instruction.Create(OpCodes.Callvirt, setBackImage));
        E(LdL(locPic), I4(3), Instruction.Create(OpCodes.Callvirt, setBackLayout)); // ImageLayout.Stretch
        CSetLoc(locPic, 0, 0);
        CSetSize(locPic, CW, 72);
        CAdd(locPic);

        // website hyperlink
        E(Instruction.Create(OpCodes.Newobj, linkCtor), Instruction.Create(OpCodes.Stloc, locLink));
        E(LdL(locLink), I4(0), Instruction.Create(OpCodes.Callvirt, linkAutoSize));
        CSetText(locLink, "Перейти на сайт");
        CSetFont(locLink, 9.75f, 1); // Bold
        E(LdL(locLink), I4(MidC), Instruction.Create(OpCodes.Callvirt, linkTextAlign));
        CSetLoc(locLink, 20, 84);
        CSetSize(locLink, 320, 26);
        E(LdL(locLink), Ld0(), Instruction.Create(OpCodes.Ldftn, webClick), Instruction.Create(OpCodes.Newobj, linkHandlerCtor), Instruction.Create(OpCodes.Callvirt, addLinkClicked));
        CAdd(locLink);

        // e-mail
        E(Instruction.Create(OpCodes.Newobj, labCtor), Instruction.Create(OpCodes.Stloc, locLabel));
        E(LdL(locLabel), I4(0), Instruction.Create(OpCodes.Callvirt, labAutoSize));
        CSetText(locLabel, "Email: lunin021189@gmail.com");
        CSetFont(locLabel, 9.75f, 0);
        E(LdL(locLabel), I4(MidC), Instruction.Create(OpCodes.Callvirt, labTextAlign));
        CSetLoc(locLabel, 20, 116);
        CSetSize(locLabel, 320, 24);
        CAdd(locLabel);

        // MAX link
        E(Instruction.Create(OpCodes.Newobj, linkCtor), Instruction.Create(OpCodes.Stloc, locLink));
        E(LdL(locLink), I4(0), Instruction.Create(OpCodes.Callvirt, linkAutoSize));
        CSetText(locLink, "Связаться в MAX");
        CSetFont(locLink, 9.75f, 1);
        E(LdL(locLink), I4(MidC), Instruction.Create(OpCodes.Callvirt, linkTextAlign));
        CSetLoc(locLink, 20, 144);
        CSetSize(locLink, 320, 26);
        E(LdL(locLink), Ld0(), Instruction.Create(OpCodes.Ldftn, maxClick), Instruction.Create(OpCodes.Newobj, linkHandlerCtor), Instruction.Create(OpCodes.Callvirt, addLinkClicked));
        CAdd(locLink);

        // QR code (existing PictureBox2): center it below. Clear its Top|Left|Right
        // anchor first, otherwise the layout pass stretches it to the form width.
        E(Ld0(), Instruction.Create(OpCodes.Callvirt, getPic2), I4(5), Instruction.Create(OpCodes.Callvirt, setAnchor)); // AnchorStyles.Top|Left
        E(Ld0(), Instruction.Create(OpCodes.Callvirt, getPic2), I4(4), Instruction.Create(OpCodes.Callvirt, setSizeMode)); // PictureBoxSizeMode.Zoom
        GLoc(getPic2, 30, 172);
        GSize(getPic2, 300, 118);

        // OK button reposition (keep): directly below the QR card
        GLoc(getOk, 268, 302);
        GSize(getOk, 82, 28);

        E(Ld0(), I4(0), Instruction.Create(OpCodes.Callvirt, resumeLayout));
        S.Add(Instruction.Create(OpCodes.Ret));
        about.Methods.Add(setup);

        // call zt_AboutSetup() at the very end of AboutBox1_Load (after original body).
        var retIns = load.Body.Instructions.LastOrDefault(i => i.OpCode.Code == Code.Ret);
        int insertAt = retIns != null ? load.Body.Instructions.IndexOf(retIns) : load.Body.Instructions.Count;
        load.Body.Instructions.Insert(insertAt, Instruction.Create(OpCodes.Ldarg_0));
        load.Body.Instructions.Insert(insertAt + 1, Instruction.Create(OpCodes.Call, setup));

        Console.WriteLine("  FrmAbout: rebuilt About box (site link, email, MAX QR; removed phones/QQ/version/OS/desc/log)");
        return 1;
    }

    // Redesigns the trial / "license not found" window (FrmRverify) to match the
    // rebuilt About box: the vendor contact grids — TableLayoutPanel3 (QQ /
    // Группа QQ / Email rows) and TableLayoutPanel4 (the Сайт: row) — are hidden,
    // and a clean centered e-mail line plus a clickable "Перейти на сайт"
    // hyperlink are dropped into the freed space above the MAX QR card. The red
    // "license not found" banner (TableLayoutPanel2), the phone-free MAX QR
    // (PictureBox1) and the Проба / Регистр / Отмена buttons (TableLayoutPanel1)
    // are left untouched. Same pattern as PatchAboutBox: an injected instance
    // helper zt_VerifySetup() is called at the end of InitializeComponent so the
    // controls always exist, and the website link opens via explorer.exe (a child
    // process) so a broken default-browser association can never fault the host.
    private static int PatchVerifyContacts(ModuleDefMD mod)
    {
        var frm = mod.Find("ZTool.FrmRverify", false);
        var init = frm?.FindMethod("InitializeComponent");
        if (frm == null || init?.Body == null)
        {
            Console.WriteLine("  FrmRverify: contact patch skipped (form/InitializeComponent not found)");
            return 0;
        }
        if (frm.FindMethod("zt_VerifySetup") != null) return 0; // idempotent

        var wf = FindAssemblyRef(mod, "System.Windows.Forms");
        var dr = FindAssemblyRef(mod, "System.Drawing");
        if (wf == null || dr == null)
        {
            Console.WriteLine("  FrmRverify: contact patch skipped (WinForms/Drawing refs missing)");
            return 0;
        }
        TypeRefUser WF(string n) => new TypeRefUser(mod, "System.Windows.Forms", n, wf);
        TypeRefUser DR(string n) => new TypeRefUser(mod, "System.Drawing", n, dr);

        var trControl = WF("Control");
        var trCtrlColl = new TypeRefUser(mod, "", "ControlCollection", trControl);
        var trLabel = WF("Label");
        var trLinkLabel = WF("LinkLabel");
        var trLinkHandler = WF("LinkLabelLinkClickedEventHandler");
        var trPoint = DR("Point");
        var trSize = DR("Size");
        var trFont = DR("Font");

        var sigControl = new ClassSig(trControl);
        var sigCtrlColl = new ClassSig(trCtrlColl);
        var sigPoint = new ValueTypeSig(trPoint);
        var sigSize = new ValueTypeSig(trSize);
        var sigFont = new ClassSig(trFont);
        var sigContentAlign = new ValueTypeSig(DR("ContentAlignment"));
        var sigFontStyle = new ValueTypeSig(DR("FontStyle"));
        var sigLinkHandler = new ClassSig(trLinkHandler);

        var getControls = new MemberRefUser(mod, "get_Controls", MethodSig.CreateInstance(sigCtrlColl), trControl);
        var ccAdd = new MemberRefUser(mod, "Add", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigControl), trCtrlColl);
        var setText = new MemberRefUser(mod, "set_Text", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.String), trControl);
        var setFont = new MemberRefUser(mod, "set_Font", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigFont), trControl);
        var setLocation = new MemberRefUser(mod, "set_Location", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigPoint), trControl);
        var setCtrlSize = new MemberRefUser(mod, "set_Size", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigSize), trControl);
        var setVisible = new MemberRefUser(mod, "set_Visible", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trControl);
        var setClientSize = new MemberRefUser(mod, "set_ClientSize", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigSize), trControl);

        var labCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void), trLabel);
        var labAutoSize = new MemberRefUser(mod, "set_AutoSize", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trLabel);
        var labTextAlign = new MemberRefUser(mod, "set_TextAlign", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigContentAlign), trLabel);

        var linkCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void), trLinkLabel);
        var linkAutoSize = new MemberRefUser(mod, "set_AutoSize", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Boolean), trLinkLabel);
        var linkTextAlign = new MemberRefUser(mod, "set_TextAlign", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigContentAlign), trLinkLabel);
        var addLinkClicked = new MemberRefUser(mod, "add_LinkClicked", MethodSig.CreateInstance(mod.CorLibTypes.Void, sigLinkHandler), trLinkLabel);

        var pointCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Int32, mod.CorLibTypes.Int32), trPoint);
        var sizeCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Int32, mod.CorLibTypes.Int32), trSize);
        var fontCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.String, mod.CorLibTypes.Single, sigFontStyle), trFont);
        var linkHandlerCtor = new MemberRefUser(mod, ".ctor", MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Object, mod.CorLibTypes.IntPtr), trLinkHandler);

        var getTlp2 = frm.FindMethod("get_TableLayoutPanel2");
        var getTlp3 = frm.FindMethod("get_TableLayoutPanel3");
        var getTlp4 = frm.FindMethod("get_TableLayoutPanel4");
        var getLabel2 = frm.FindMethod("get_Label2");
        var getPic = frm.FindMethod("get_PictureBox1");
        var getTest = frm.FindMethod("get_Test");
        var getBtn1 = frm.FindMethod("get_Button1");
        var getBtn2 = frm.FindMethod("get_Button2");
        if (getTlp2 == null || getTlp3 == null || getTlp4 == null || getLabel2 == null || getPic == null || getTest == null || getBtn1 == null || getBtn2 == null)
        {
            Console.WriteLine("  FrmRverify: contact patch skipped (TLP accessors missing)");
            return 0;
        }

        // Process.Start(string,string): open the URL via explorer.exe so a broken
        // default-browser association can never raise an uncatchable fault in-process.
        var procStart = mod.GetTypes().SelectMany(t => t.Methods).Where(m => m.Body != null)
            .SelectMany(m => m.Body.Instructions).Select(i => i.Operand as IMethod)
            .FirstOrDefault(m => m != null && m.Name == "Start" && m.DeclaringType?.Name == "Process"
                && m.MethodSig?.Params.Count == 1);
        if (procStart == null)
        {
            Console.WriteLine("  FrmRverify: contact patch skipped (Process.Start ref missing)");
            return 0;
        }
        var procParent = (procStart as MemberRef)?.Class;
        var procStart2 = procParent == null ? null : new MemberRefUser(mod, "Start",
            MethodSig.CreateStatic(procStart.MethodSig.RetType, mod.CorLibTypes.String, mod.CorLibTypes.String), procParent);

        // --- inject the website link-click handler ---
        var linkArgs = new ClassSig(WF("LinkLabelLinkClickedEventArgs"));
        var exceptionRef = new TypeRefUser(mod, "System", "Exception", mod.CorLibTypes.AssemblyRef);
        var webClick = new MethodDefUser("zt_VerifyWeb_Click",
            MethodSig.CreateInstance(mod.CorLibTypes.Void, mod.CorLibTypes.Object, linkArgs),
            MethodImplAttributes.IL | MethodImplAttributes.Managed,
            MethodAttributes.Private | MethodAttributes.HideBySig);
        webClick.Body = new CilBody();
        {
            var ins = webClick.Body.Instructions;
            var ret = Instruction.Create(OpCodes.Ret);
            var tryStart = (procStart2 != null)
                ? Instruction.Create(OpCodes.Ldstr, "explorer.exe")
                : Instruction.Create(OpCodes.Ldstr, SiteUrl);
            ins.Add(tryStart);
            if (procStart2 != null)
            {
                ins.Add(Instruction.Create(OpCodes.Ldstr, SiteUrl));
                ins.Add(Instruction.Create(OpCodes.Call, procStart2));
            }
            else
            {
                ins.Add(Instruction.Create(OpCodes.Call, procStart));
            }
            ins.Add(Instruction.Create(OpCodes.Pop));
            ins.Add(Instruction.Create(OpCodes.Leave_S, ret));
            var handlerStart = Instruction.Create(OpCodes.Pop);
            ins.Add(handlerStart);
            ins.Add(Instruction.Create(OpCodes.Leave_S, ret));
            ins.Add(ret);
            webClick.Body.ExceptionHandlers.Add(new ExceptionHandler(ExceptionHandlerType.Catch)
            {
                TryStart = tryStart,
                TryEnd = handlerStart,
                HandlerStart = handlerStart,
                HandlerEnd = ret,
                CatchType = exceptionRef,
            });
        }
        frm.Methods.Add(webClick);

        // --- inject the layout builder zt_VerifySetup() ---
        var setup = new MethodDefUser("zt_VerifySetup",
            MethodSig.CreateInstance(mod.CorLibTypes.Void),
            MethodImplAttributes.IL | MethodImplAttributes.Managed,
            MethodAttributes.Private | MethodAttributes.HideBySig);
        setup.Body = new CilBody { InitLocals = true };
        var locLink = new Local(new ClassSig(trLinkLabel));
        var locLabel = new Local(new ClassSig(trLabel));
        setup.Body.Variables.Add(locLink);
        setup.Body.Variables.Add(locLabel);
        var S = setup.Body.Instructions;

        Instruction Ld0() => Instruction.Create(OpCodes.Ldarg_0);
        Instruction LdL(Local l) => Instruction.Create(OpCodes.Ldloc, l);
        Instruction I4(int n) => Instruction.CreateLdcI4(n);
        void E(params Instruction[] xs) { foreach (var x in xs) S.Add(x); }
        void CSetLoc(Local l, int x, int y) => E(LdL(l), I4(x), I4(y), Instruction.Create(OpCodes.Newobj, pointCtor), Instruction.Create(OpCodes.Callvirt, setLocation));
        void CSetSize(Local l, int w, int h) => E(LdL(l), I4(w), I4(h), Instruction.Create(OpCodes.Newobj, sizeCtor), Instruction.Create(OpCodes.Callvirt, setCtrlSize));
        void CSetText(Local l, string s) => E(LdL(l), Instruction.Create(OpCodes.Ldstr, s), Instruction.Create(OpCodes.Callvirt, setText));
        void CSetFont(Local l, float sz, int style) => E(LdL(l), Instruction.Create(OpCodes.Ldstr, "Segoe UI"), Instruction.Create(OpCodes.Ldc_R4, sz), I4(style), Instruction.Create(OpCodes.Newobj, fontCtor), Instruction.Create(OpCodes.Callvirt, setFont));
        void CAdd(Local l) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, getControls), LdL(l), Instruction.Create(OpCodes.Callvirt, ccAdd));
        void GVisible(MethodDef g, bool v) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), I4(v ? 1 : 0), Instruction.Create(OpCodes.Callvirt, setVisible));
        void GText(MethodDef g, string s) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), Instruction.Create(OpCodes.Ldstr, s), Instruction.Create(OpCodes.Callvirt, setText));
        void GFont(MethodDef g, float sz, int style) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), Instruction.Create(OpCodes.Ldstr, "Segoe UI"), Instruction.Create(OpCodes.Ldc_R4, sz), I4(style), Instruction.Create(OpCodes.Newobj, fontCtor), Instruction.Create(OpCodes.Callvirt, setFont));
        void GSize(MethodDef g, int w, int h) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), I4(w), I4(h), Instruction.Create(OpCodes.Newobj, sizeCtor), Instruction.Create(OpCodes.Callvirt, setCtrlSize));
        void GLoc(MethodDef g, int x, int y) => E(Ld0(), Instruction.Create(OpCodes.Callvirt, g), I4(x), I4(y), Instruction.Create(OpCodes.Newobj, pointCtor), Instruction.Create(OpCodes.Callvirt, setLocation));

        const int MidC = 32; // ContentAlignment.MiddleCenter

        // hide both vendor contact grids (QQ / Группа QQ / Email + Сайт rows).
        GVisible(getTlp3, false);
        GVisible(getTlp4, false);

        // compact, professional red banner: shorter text, smaller clean font,
        // half the original height (was 18pt italic wrapping in an 88px cell).
        GSize(getTlp2, 402, 52);
        GText(getLabel2, "Лицензия не обнаружена");
        GFont(getLabel2, 15.75f, 1); // Segoe UI Bold (red colour kept from designer)

        // e-mail line, centered just below the banner.
        E(Instruction.Create(OpCodes.Newobj, labCtor), Instruction.Create(OpCodes.Stloc, locLabel));
        E(LdL(locLabel), I4(0), Instruction.Create(OpCodes.Callvirt, labAutoSize));
        CSetText(locLabel, "Email: lunin021189@gmail.com");
        CSetFont(locLabel, 9.75f, 0);
        E(LdL(locLabel), I4(MidC), Instruction.Create(OpCodes.Callvirt, labTextAlign));
        CSetLoc(locLabel, 11, 66);
        CSetSize(locLabel, 380, 22);
        CAdd(locLabel);

        // website hyperlink "Перейти на сайт".
        E(Instruction.Create(OpCodes.Newobj, linkCtor), Instruction.Create(OpCodes.Stloc, locLink));
        E(LdL(locLink), I4(0), Instruction.Create(OpCodes.Callvirt, linkAutoSize));
        CSetText(locLink, "Перейти на сайт");
        CSetFont(locLink, 9.75f, 1); // Bold
        E(LdL(locLink), I4(MidC), Instruction.Create(OpCodes.Callvirt, linkTextAlign));
        CSetLoc(locLink, 11, 94);
        CSetSize(locLink, 380, 24);
        E(LdL(locLink), Ld0(), Instruction.Create(OpCodes.Ldftn, webClick), Instruction.Create(OpCodes.Newobj, linkHandlerCtor), Instruction.Create(OpCodes.Callvirt, addLinkClicked));
        CAdd(locLink);

        // friendlier button labels: "Проба" -> "Демо" (demo/trial period); the
        // "Регистрация" caption already exists but was clipped by the narrow 65px
        // button drawn in the wide vendor font. Switch all three buttons to the
        // tidy Segoe UI 9pt used elsewhere and widen "Регистрация" so it fits.
        GText(getTest, "Демо");
        GFont(getTest, 9f, 0);
        GFont(getBtn1, 9f, 0);
        GFont(getBtn2, 9f, 0);
        GSize(getBtn2, 86, 27);

        // pull the MAX QR card up into the freed space and tighten the form so the
        // bottom-anchored buttons sit just under it (removes the big empty gaps).
        GLoc(getPic, 8, 130);
        E(Ld0(), I4(402), I4(300), Instruction.Create(OpCodes.Newobj, sizeCtor), Instruction.Create(OpCodes.Callvirt, setClientSize));

        S.Add(Instruction.Create(OpCodes.Ret));
        frm.Methods.Add(setup);

        // call zt_VerifySetup() at the very end of InitializeComponent (after the
        // controls are created, so they always exist when we hide/add them).
        var retIns = init.Body.Instructions.LastOrDefault(i => i.OpCode.Code == Code.Ret);
        int insertAt = retIns != null ? init.Body.Instructions.IndexOf(retIns) : init.Body.Instructions.Count;
        init.Body.Instructions.Insert(insertAt, Instruction.Create(OpCodes.Ldarg_0));
        init.Body.Instructions.Insert(insertAt + 1, Instruction.Create(OpCodes.Call, setup));

        Console.WriteLine("  FrmRverify: redesigned (compact 'Лицензия не обнаружена' banner; hid QQ/Сайт grids; email + 'Перейти на сайт' link; MAX QR pulled up; 'Демо'/'Регистрация' buttons; form tightened)");
        return 1;
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

    // The IPC handshake token expected by the SolidWorks add-in. Reading the model
    // ("Подключить SW") sends, over WM_COPYDATA, the line
    //     "ZToolRequest@001" + code::Getpkt()
    // where Getpkt() == St2(MD5(uppercaseHex(GetEntryAssembly().GetPublicKeyToken()))).
    // The add-in (PMPHandler::DefWndProc) compares that line against
    //     "ZToolRequest@001" + obf2(obf1())
    // and silently drops the request on mismatch -> read returns 0 positions with
    // "затрачено 0,0 сек." (rejected BEFORE any BOM traversal).
    //
    // The expected value is a fixed, vendor-baked constant. It was recovered by
    // executing the add-in's own (protector-decrypted) helpers obf1()=0x06000134
    // and obf2()=0x0600005B straight out of the shipped DLL (verified byte-identical
    // between the raw SLDWORKS memory dump and the russified candidate2 build):
    //     obf1()            = "E91FBC0FCBAF9D1F81AE0368B381478"
    //     obf2(obf1())      = "9EF1CBF0BCFAD9F118EA30863B1874"   <- this is it
    // The original vendor exe was strong-named with the key that produces this value;
    // the build-input base.exe was re-keyed (token f08fc7047657204e) and so produces a
    // DIFFERENT value -> rejected. We do not have the vendor private key, so instead of
    // re-signing we hard-set Getpkt() to return the value the add-in expects. This makes
    // the handshake (and every IPC command that prefixes it) authenticate exactly as the
    // genuine exe did. To re-derive for a different DLL build, run obf2(obf1()) on it.
    private const string HandshakePkt = "9EF1CBF0BCFAD9F118EA30863B1874";

    private static int PatchHandshakePkt(ModuleDefMD mod)
    {
        var code = mod.Find("ZTool.code", false);
        var getpkt = code?.FindMethod("Getpkt");
        if (getpkt?.Body == null)
        {
            Console.WriteLine("  handshake: ZTool.code::Getpkt NOT found - SKIPPED");
            return 0;
        }
        var b = getpkt.Body;
        b.Instructions.Clear();
        b.ExceptionHandlers.Clear();
        b.Variables.Clear();
        b.Instructions.Add(Instruction.Create(OpCodes.Ldstr, HandshakePkt));
        b.Instructions.Add(Instruction.Create(OpCodes.Ret));
        Console.WriteLine($"  handshake: Getpkt() pinned to add-in-expected token \"{HandshakePkt}\"");
        return 1;
    }

    // The add-in launcher (SwAddin::openZtool) does NOT pick the exe by file name.
    // It enumerates every *.exe next to the loaded ZTool.dll, reads each file's
    // INTERNAL assembly identity via AssemblyName.GetAssemblyName(path).Name, and
    // launches the one whose Name equals "ZTool" (OrdinalIgnoreCase). The vendor
    // build-input (ZTool-base.exe) carries the same internal Name="ZTool", so a
    // mere file rename never stopped it from being matched (and, sorting first, it
    // won). We solve this from both sides: the build-input's internal name is set
    // to "ZToolBuildInput" (see scripts/rename-base-assembly), and here we force the
    // SHIPPED output back to exactly "ZTool" so the launcher matches our build and
    // nothing else. Returns 1 if the name had to be changed.
    private static int ForceAssemblyName(ModuleDefMD mod, string name)
    {
        if (mod.Assembly == null) return 0;
        if (string.Equals(mod.Assembly.Name, name, StringComparison.Ordinal)) return 0;
        Console.WriteLine($"  launcher: assembly internal Name \"{mod.Assembly.Name}\" -> \"{name}\"");
        mod.Assembly.Name = name;
        return 1;
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
