using System;

namespace RibbonLib.Interop;

[Flags]
public enum Invalidations
{
	State = 1,
	Value = 2,
	Property = 4,
	AllProperties = 8
}
