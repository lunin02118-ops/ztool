using System;
using dnlib.DotNet;

// Compile-time "publicizer": opens a .NET assembly and promotes every type and
// member to public so an external project can reference its (originally internal/
// private) members. The output is used ONLY as a compile reference; the real,
// unmodified assembly is what ships and what we reinject into at runtime.
//
// Usage: publicizer <input-assembly> <output-assembly>
internal static class Program
{
    private static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.Error.WriteLine("usage: publicizer <input> <output>");
            return 2;
        }

        string input = args[0];
        string output = args[1];

        var mod = ModuleDefMD.Load(input);
        int types = 0, methods = 0, fields = 0;

        foreach (var type in mod.GetTypes())
        {
            if (type.IsNested)
            {
                if (type.Visibility != TypeAttributes.NestedPublic)
                {
                    type.Visibility = TypeAttributes.NestedPublic;
                    types++;
                }
            }
            else if (type.Visibility != TypeAttributes.Public)
            {
                type.Visibility = TypeAttributes.Public;
                types++;
            }

            foreach (var m in type.Methods)
            {
                if (m.Access != MethodAttributes.Public)
                {
                    m.Access = MethodAttributes.Public;
                    methods++;
                }
            }

            foreach (var f in type.Fields)
            {
                if (f.Access != FieldAttributes.Public)
                {
                    f.Access = FieldAttributes.Public;
                    fields++;
                }
            }
        }

        mod.Write(output);
        Console.WriteLine($"publicized: types={types} methods={methods} fields={fields} -> {output}");
        return 0;
    }
}
