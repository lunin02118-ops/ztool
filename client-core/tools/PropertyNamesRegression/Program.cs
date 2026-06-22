using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

internal static class Program
{
    [STAThread]
    private static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.Error.WriteLine("Usage: PropertyNamesRegression <SWTools.exe> <fixture.SLDPRT/SLDASM>");
            return 2;
        }

        string exePath = Path.GetFullPath(args[0]);
        string fixturePath = Path.GetFullPath(args[1]);
        if (!File.Exists(exePath))
        {
            Console.Error.WriteLine("SWTools.exe not found: " + exePath);
            return 2;
        }
        if (!File.Exists(fixturePath))
        {
            Console.Error.WriteLine("fixture not found: " + fixturePath);
            return 2;
        }

        string runtimeDir = Path.GetDirectoryName(exePath);
        string oldCwd = Environment.CurrentDirectory;
        string evidenceDir = Path.Combine(
            FindRepoRoot(Directory.GetCurrentDirectory()),
            "_local_artifacts",
            "evidence",
            "property-names-regression-" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        Directory.CreateDirectory(evidenceDir);

        try
        {
            Environment.CurrentDirectory = runtimeDir;
            var asm = Assembly.LoadFrom(exePath);

            var cconfig = asm.GetType("ZTool.CConfigMng", throwOnError: true);
            RuntimeHelpers.RunClassConstructor(cconfig.TypeHandle);
            object config = GetStaticProperty(cconfig, "Config");
            if (config == null)
            {
                config = Activator.CreateInstance(asm.GetType("ZTool.CConfigDO", throwOnError: true));
            }
            EnsureListProperty(config, "propname");
            EnsureListProperty(config, "proptype");
            EnsureListProperty(config, "columnInfolist");
            SetStaticField(cconfig, "m_sConfigFileName", Path.Combine(evidenceDir, "SWTools.settings"));
            SetStaticProperty(cconfig, "Config", config);

            var main = CreateFrmmainHarness(asm);
            WriteLine("EXE=" + exePath);
            WriteLine("FIXTURE=" + fixturePath);
            WriteLine("EVIDENCE=" + evidenceDir);
            WriteLine("TITLE_SOURCE=" + asm.GetName().FullName);

            PhaseClear(main, cconfig);
            PhaseManual(main, cconfig, new[] { "ManualRegression_A", "ManualRegression_B" });
            PhaseImport(asm, cconfig, fixturePath);

            WriteLine("RESULT=PASS");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return 1;
        }
        finally
        {
            Environment.CurrentDirectory = oldCwd;
        }
    }

    private static void PhaseClear(object main, Type cconfig)
    {
        WriteLine("== CLEAR ==");
        SetProps(cconfig, Enumerable.Range(1, 8).Select(i => "OldProp_" + i), Enumerable.Repeat("Текст", 8));
        Invoke(main, "insetpropcol");
        AssertContainsColumns(main, "OldProp_1", "OldProp_8");

        // Mirrors Frmsetpropname.OK_Button_Click after a user deletes every row:
        // SavePropName() has already cleared Config.propname/proptype, then the
        // main form persists column state and rebuilds property columns.
        Invoke(main, "SaveColumnInfo");
        SetProps(cconfig, Array.Empty<string>(), Array.Empty<string>());
        Invoke(main, "insetpropcol");
        Invoke(main, "LoadColumnInfo");

        var props = GetPropertyColumns(main).ToList();
        WriteLine("CLEAR_PROP_COLUMNS=" + props.Count);
        if (props.Count != 0)
        {
            throw new InvalidOperationException("Property columns remained after clear: " + string.Join(", ", props));
        }
    }

    private static void PhaseManual(object main, Type cconfig, string[] names)
    {
        WriteLine("== MANUAL ==");
        SetProps(cconfig, names, Enumerable.Repeat("Текст", names.Length));
        Invoke(main, "insetpropcol");
        AssertContainsColumns(main, names);
        WriteLine("MANUAL_PROP_COLUMNS=" + string.Join("|", GetPropertyColumns(main)));
    }

    private static object CreateFrmmainHarness(Assembly asm)
    {
        var mainType = asm.GetType("ZTool.Frmmain", throwOnError: true);
        object main = FormatterServices.GetUninitializedObject(mainType);

        var dgv = (DataGridView)Activator.CreateInstance(asm.GetType("ZTool.DataGridViewEX", throwOnError: true));
        dgv.AllowUserToAddRows = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;

        var colPreview = new DataGridViewImageColumn { Name = "Col_Preview", HeaderText = "Preview" };
        var colCheckbox = new DataGridViewCheckBoxColumn { Name = "Col_Checkbox", HeaderText = "" };
        var colMaterial = new DataGridViewTextBoxColumn { Name = "Col_Material", HeaderText = "Материал" };
        dgv.Columns.Add(colPreview);
        dgv.Columns.Add(colCheckbox);
        dgv.Columns.Add(colMaterial);

        SetField(main, "_DGV1", dgv);
        SetField(main, "_TV1", Activator.CreateInstance(asm.GetType("ZTool.MultiSelectTreeView", throwOnError: true)));
        SetField(main, "_ComboBox1", Activator.CreateInstance(asm.GetType("ZTool.CustomComboBox1", throwOnError: true)));
        SetField(main, "_StatusLabel1", new ToolStripStatusLabel());
        SetField(main, "_PropSwitch", new ToolStripButton { Checked = false });
        SetField(main, "_Col_Preview", colPreview);
        SetField(main, "_Col_Checkbox", colCheckbox);
        SetField(main, "_Col_Material", colMaterial);
        SetField(main, "dpixRatio", 1.0);
        SetField(main, "FilterCollist", new List<string>[1]);
        SetField(main, "HideCollist", new List<int>());
        SetField(main, "FilterColReverse", new List<bool>());

        return main;
    }

    private static void PhaseImport(Assembly asm, Type cconfig, string fixturePath)
    {
        WriteLine("== IMPORT_FROM_FILE ==");
        SetProps(cconfig, Array.Empty<string>(), Array.Empty<string>());
        var names = ReadModelPropertyNamesViaSolidWorks(asm, fixturePath).ToList();
        WriteLine("IMPORT_BACKEND_COUNT=" + names.Count);
        WriteLine("IMPORT_BACKEND_NAMES=" + string.Join("|", names));

        string[] required = { "Разработал", "Наименование", "Обозначение", "Масса", "Проект_ФБ", "Материал_ФБ" };
        foreach (string name in required)
        {
            if (!names.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Imported property is missing: " + name);
            }
        }
        if (names.Count < 40)
        {
            throw new InvalidOperationException("Too few imported properties: " + names.Count);
        }

        var grid = new DataGridView { AllowUserToAddRows = true };
        grid.Columns.Add("col_propname", "Имя свойства");
        grid.Columns.Add("col_proptype", "Тип");
        AddImportedNamesToGrid(grid, names);
        var gridNames = ReadGridNames(grid).ToList();
        WriteLine("IMPORT_GRID_COUNT=" + gridNames.Count);
        foreach (string name in required)
        {
            if (!gridNames.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Imported grid row is missing: " + name);
            }
        }
    }

    private static IEnumerable<string> ReadModelPropertyNamesViaSolidWorks(Assembly asm, string filePath)
    {
        var names = new List<string>();
        Type codeType = asm.GetType("ZTool.code", throwOnError: true);
        var canRun = codeType.GetField("canrun", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        canRun?.SetValue(null, true);
        var runSw = codeType.GetMethod("RunSW", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        object runResult = runSw.Invoke(null, new object[] { false, false });
        WriteLine("IMPORT_RUNSW=" + runResult);
        if (!(runResult is bool ok) || !ok)
        {
            throw new InvalidOperationException("SolidWorks COM is not available for property import regression.");
        }

        object swApp = codeType.GetField("swApp", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null);
        if (swApp == null) throw new InvalidOperationException("ZTool.code.swApp is null.");

        int docType = filePath.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase) ? 2 :
            filePath.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase) ? 3 : 1;
        object doc = null;
        bool opened = false;
        try
        {
            TryLateSet(swApp, "CommandInProgress", true);
            doc = TryLateGet(swApp, "GetOpenDocumentByName", filePath) ?? TryLateGet(swApp, "GetOpenDocument", filePath);
            if (doc == null)
            {
                TryLateCall(swApp, "SetCurrentWorkingDirectory", Path.GetDirectoryName(filePath));
                int errors = 0;
                int warnings = 0;
                object[] args = { filePath, docType, 1, "", errors, warnings };
                bool[] copyBack = { false, false, false, false, true, true };
                doc = NewLateBinding.LateGet(swApp, null, "OpenDoc6", args, null, null, copyBack);
                opened = doc != null;
                WriteLine("IMPORT_OPENDOC_OPENED=" + opened + "; ERRORS=" + args[4] + "; WARNINGS=" + args[5]);
            }
            if (doc == null) throw new InvalidOperationException("SolidWorks returned null document.");

            object ext = NewLateBinding.LateGet(doc, null, "Extension", Array.Empty<object>(), null, null, null);
            AddNames(names, NewLateBinding.LateGet(
                NewLateBinding.LateGet(ext, null, "CustomPropertyManager", new object[] { "" }, null, null, null),
                null,
                "GetNames",
                Array.Empty<object>(),
                null,
                null,
                null));

            object cfgNames = TryLateGet(doc, "GetConfigurationNames");
            if (cfgNames is IEnumerable enumerable)
            {
                foreach (object cfgObj in enumerable)
                {
                    string cfg = Convert.ToString(cfgObj) ?? "";
                    if (cfg.Length == 0) continue;
                    object mgr = NewLateBinding.LateGet(ext, null, "CustomPropertyManager", new object[] { cfg }, null, null, null);
                    AddNames(names, NewLateBinding.LateGet(mgr, null, "GetNames", Array.Empty<object>(), null, null, null));
                }
            }
        }
        finally
        {
            if (opened && doc != null)
            {
                try
                {
                    object title = NewLateBinding.LateGet(doc, null, "GetTitle", Array.Empty<object>(), null, null, null);
                    NewLateBinding.LateCall(swApp, null, "CloseDoc", new[] { title }, null, null, null, true);
                }
                catch { }
            }
            TryLateSet(swApp, "CommandInProgress", false);
        }
        return names;
    }

    private static void AddImportedNamesToGrid(DataGridView grid, IEnumerable<string> names)
    {
        foreach (string name in names)
        {
            if (name.Length == 0 || ReadGridNames(grid).Contains(name, StringComparer.OrdinalIgnoreCase)) continue;
            int row = grid.Rows.Add();
            grid[0, row].Value = name;
            grid[1, row].Value = "Текст";
        }
    }

    private static IEnumerable<string> ReadGridNames(DataGridView grid)
    {
        foreach (DataGridViewRow row in grid.Rows)
        {
            if (row.IsNewRow) continue;
            string value = Convert.ToString(row.Cells[0].Value) ?? "";
            if (value.Length > 0) yield return value;
        }
    }

    private static void AddNames(List<string> names, object values)
    {
        if (!(values is IEnumerable enumerable)) return;
        foreach (object value in enumerable)
        {
            string name = Convert.ToString(value) ?? "";
            if (name.Length > 0 && !names.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                names.Add(name);
            }
        }
    }

    private static object TryLateGet(object instance, string member, params object[] args)
    {
        try { return NewLateBinding.LateGet(instance, null, member, args, null, null, null); }
        catch { return null; }
    }

    private static void TryLateSet(object instance, string member, object value)
    {
        try { NewLateBinding.LateSet(instance, null, member, new[] { value }, null, null); }
        catch { }
    }

    private static void TryLateCall(object instance, string member, params object[] args)
    {
        try { NewLateBinding.LateCall(instance, null, member, args, null, null, null, true); }
        catch { }
    }

    private static void SetProps(Type cconfig, IEnumerable<string> names, IEnumerable<string> types)
    {
        object config = GetStaticProperty(cconfig, "Config");
        EnsureListProperty(config, "propname");
        EnsureListProperty(config, "proptype");
        var propname = (IList)GetProperty(config, "propname");
        var proptype = (IList)GetProperty(config, "proptype");
        propname.Clear();
        proptype.Clear();
        foreach (string name in names) propname.Add(name);
        foreach (string type in types) proptype.Add(type);
        while (proptype.Count < propname.Count) proptype.Add("Текст");
    }

    private static IEnumerable<string> GetPropertyColumns(object main)
    {
        var dgv = (DataGridView)GetProperty(main, "DGV1");
        foreach (DataGridViewColumn col in dgv.Columns)
        {
            if (col.Name.StartsWith("PropVal_", StringComparison.Ordinal) ||
                col.Name.StartsWith("PropResolvedVal_", StringComparison.Ordinal))
            {
                yield return col.Name + ":" + col.HeaderText;
            }
        }
    }

    private static void AssertContainsColumns(object main, params string[] expectedHeaders)
    {
        var headers = GetPropertyColumns(main)
            .Select(s => s.Substring(s.IndexOf(':') + 1))
            .ToList();
        foreach (string expected in expectedHeaders)
        {
            if (!headers.Contains(expected, StringComparer.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Expected property column not found: " + expected);
            }
        }
    }

    private static IEnumerable<string> ReadPropertyGridNames(object form)
    {
        var dgv = (DataGridView)GetProperty(form, "DGV1");
        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (row.IsNewRow) continue;
            string value = Convert.ToString(row.Cells[0].Value) ?? "";
            if (value.Length > 0) yield return value;
        }
    }

    private static object GetStaticProperty(Type type, string name) =>
        type.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(null, null);

    private static void SetStaticProperty(Type type, string name, object value) =>
        type.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value, null);

    private static void SetStaticField(Type type, string name, object value) =>
        type.GetField(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).SetValue(null, value);

    private static void SetField(object instance, string name, object value)
    {
        var field = instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (field == null) throw new MissingFieldException(instance.GetType().FullName, name);
        field.SetValue(instance, value);
    }

    private static object GetProperty(object instance, string name) =>
        instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(instance, null);

    private static void EnsureListProperty(object instance, string name)
    {
        var prop = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (prop == null) throw new MissingMemberException(instance.GetType().FullName, name);
        if (prop.GetValue(instance, null) != null) return;
        prop.SetValue(instance, Activator.CreateInstance(prop.PropertyType), null);
    }

    private static object Invoke(object instance, string name, params object[] args) =>
        instance.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(instance, args);

    private static void WriteLine(string text) => Console.WriteLine(text);

    private static string FindRepoRoot(string start)
    {
        var dir = new DirectoryInfo(Path.GetFullPath(start));
        while (dir != null)
        {
            if (File.Exists(Path.Combine(dir.FullName, "VERSION")) &&
                Directory.Exists(Path.Combine(dir.FullName, ".git")))
            {
                return dir.FullName;
            }
            dir = dir.Parent;
        }
        return Path.GetFullPath(start);
    }
}
