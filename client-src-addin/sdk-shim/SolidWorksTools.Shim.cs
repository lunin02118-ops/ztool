// COMPILE-TIME SHIM — NOT a runtime artifact.
//
// The recovered SolidWorks add-in references the SolidWorks SDK helper assembly
// `SolidWorksTools.dll` (it ships with SolidWorks under api\redist and is loaded
// at runtime by SolidWorks itself). That assembly is not redistributable here and
// is absent on machines without SolidWorks (e.g. CI runners), so this shim
// reproduces the *minimal public surface* the add-in actually consumes, purely so
// the recovered C# can be compiled as a regression/smoke gate.
//
// On a real SolidWorks machine the add-in is built against the genuine
// SolidWorksTools.dll (set $(SolidWorksToolsPath) or $(SolidWorksDir)); this shim
// is only used when that assembly cannot be found. The shim is compiled into its
// own assembly named `SolidWorksTools` and is referenced with Private=false, so it
// is never copied next to the produced add-in.
using System;
using System.Reflection;

namespace SolidWorksTools
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SwAddinAttribute : Attribute
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public bool LoadAtStartup { get; set; }
    }

    public class BitmapHandler : IDisposable
    {
        public string CreateFileFromResourceBitmap(string resourceName, Assembly assembly) => null;
        public void Dispose() { }
    }
}

namespace SolidWorksTools.File
{
    // Marker type so the `SolidWorksTools.File` namespace exists in this reference
    // assembly's metadata (the add-in has a `using SolidWorksTools.File;`).
    public sealed class _NamespaceMarker { }
}
