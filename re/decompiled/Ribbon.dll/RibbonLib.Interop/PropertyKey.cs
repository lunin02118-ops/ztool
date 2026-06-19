using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace RibbonLib.Interop;

public struct PropertyKey(Guid fmtid, uint pid)
{
	private static Dictionary<PropertyKey, GCHandle> s_pinnedCache = new Dictionary<PropertyKey, GCHandle>(16);

	public Guid FormatId = fmtid;

	public uint PropertyId = pid;

	public static bool operator ==(PropertyKey left, PropertyKey right)
	{
		if (left.FormatId == right.FormatId)
		{
			return left.PropertyId == right.PropertyId;
		}
		return false;
	}

	public static bool operator !=(PropertyKey left, PropertyKey right)
	{
		return !(left == right);
	}

	public override string ToString()
	{
		return "PKey: " + FormatId.ToString() + ":" + PropertyId.ToString(CultureInfo.InvariantCulture.NumberFormat);
	}

	public IntPtr ToPointer()
	{
		if (!s_pinnedCache.ContainsKey(this))
		{
			s_pinnedCache.Add(this, GCHandle.Alloc(this, GCHandleType.Pinned));
		}
		return s_pinnedCache[this].AddrOfPinnedObject();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is PropertyKey))
		{
			return false;
		}
		return this == (PropertyKey)obj;
	}

	public override int GetHashCode()
	{
		return FormatId.GetHashCode() ^ PropertyId.GetHashCode();
	}
}
