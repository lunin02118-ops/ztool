using System;
using dnlib.DotNet;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;

// rename-assembly <inExe> <newName> [outExe]
//
// Sets the INTERNAL assembly identity (AssemblyDef.Name) of a .NET exe.
//
// Why this exists: the SolidWorks add-in launcher (SwAddin::openZtool) picks the
// exe to start NOT by file name but by reading every *.exe next to ZTool.dll with
// AssemblyName.GetAssemblyName(path).Name and launching the one whose Name == "ZTool".
// The build-input ZTool-base.exe ships with internal Name="ZTool", so even after a
// file rename it was still matched (and, sorting before ZTool.exe, it won). Renaming
// its INTERNAL name to e.g. "ZToolBuildInput" makes the launcher ignore it.
//
// Strong-name presentation is preserved exactly as the input (StrongNameSigned bit +
// public key kept) so the file still loads / reports identity the same way.
class Program
{
    static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.Error.WriteLine("usage: rename-assembly <inExe> <newName> [outExe]");
            return 2;
        }
        string inExe = args[0];
        string newName = args[1];
        string outExe = args.Length >= 3 ? args[2] : inExe;

        var mod = ModuleDefMD.Load(inExe);
        if (mod.Assembly == null) { Console.Error.WriteLine("no assembly def"); return 3; }
        string old = mod.Assembly.Name;
        mod.Assembly.Name = newName;

        var curFlags = mod.Metadata.ImageCor20Header.Flags;
        var wopts = new ModuleWriterOptions(mod);
        wopts.Cor20HeaderOptions.Flags = curFlags;
        if ((curFlags & ComImageFlags.StrongNameSigned) != 0)
            wopts.Cor20HeaderOptions.Flags = curFlags | ComImageFlags.StrongNameSigned;
        mod.Write(outExe, wopts);

        Console.WriteLine($"assembly internal Name \"{old}\" -> \"{newName}\" -> {outExe}");
        return 0;
    }
}
