using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace RibbonLib.Interop;

public struct PropVariant
{
	[StructLayout(LayoutKind.Explicit)]
	private struct PVDecimalOuterUnion
	{
		[FieldOffset(0)]
		public decimal decVal;

		[FieldOffset(0)]
		public PropVariant propVar;
	}

	[StructLayout(LayoutKind.Explicit)]
	private struct PVVectorOuterUnion
	{
		[FieldOffset(0)]
		public PropVariant propVar;

		[FieldOffset(8)]
		public uint cElems;

		[FieldOffset(12)]
		public IntPtr pElems;
	}

	private static class UnsafeNativeMethods
	{
		[DllImport("Ole32.dll", PreserveSig = false)]
		internal static extern void PropVariantClear([In][Out] ref PropVariant pvar);

		[DllImport("Ole32.dll", PreserveSig = false)]
		internal static extern void PropVariantCopy(out PropVariant pDst, [In] ref PropVariant pSrc);

		[DllImport("OleAut32.dll")]
		internal static extern IntPtr SafeArrayCreateVector(ushort vt, int lowerBound, uint cElems);

		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern IntPtr SafeArrayAccessData(IntPtr psa);

		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern void SafeArrayUnaccessData(IntPtr psa);

		[DllImport("OleAut32.dll")]
		internal static extern uint SafeArrayGetDim(IntPtr psa);

		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern int SafeArrayGetLBound(IntPtr psa, uint nDim);

		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern int SafeArrayGetUBound(IntPtr psa, uint nDim);

		[DllImport("OleAut32.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		internal static extern object SafeArrayGetElement(IntPtr psa, ref int rgIndices);

		[DllImport("OleAut32.dll", PreserveSig = false)]
		internal static extern void SafeArrayDestroy(IntPtr psa);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int InitPropVariantFromPropVariantVectorElem([In] ref PropVariant propvarIn, uint iElem, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern uint InitPropVariantFromFileTime([In] ref System.Runtime.InteropServices.ComTypes.FILETIME pftIn, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.I4)]
		internal static extern int PropVariantGetElementCount([In] ref PropVariant propVar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetBooleanElem([In] ref PropVariant propVar, [In] uint iElem, [MarshalAs(UnmanagedType.Bool)] out bool pfVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetInt16Elem([In] ref PropVariant propVar, [In] uint iElem, out short pnVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetUInt16Elem([In] ref PropVariant propVar, [In] uint iElem, out ushort pnVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetInt32Elem([In] ref PropVariant propVar, [In] uint iElem, out int pnVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetUInt32Elem([In] ref PropVariant propVar, [In] uint iElem, out uint pnVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetInt64Elem([In] ref PropVariant propVar, [In] uint iElem, out long pnVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetUInt64Elem([In] ref PropVariant propVar, [In] uint iElem, out ulong pnVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetDoubleElem([In] ref PropVariant propVar, [In] uint iElem, out double pnVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetFileTimeElem([In] ref PropVariant propVar, [In] uint iElem, [MarshalAs(UnmanagedType.Struct)] out System.Runtime.InteropServices.ComTypes.FILETIME pftVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void PropVariantGetStringElem([In] ref PropVariant propVar, [In] uint iElem, [MarshalAs(UnmanagedType.LPWStr)] out string ppszVal);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromBooleanVector([In][Out] bool[] prgf, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromInt16Vector([In][Out] short[] prgn, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromUInt16Vector([In][Out] ushort[] prgn, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromInt32Vector([In][Out] int[] prgn, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromUInt32Vector([In][Out] uint[] prgn, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromInt64Vector([In][Out] long[] prgn, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromUInt64Vector([In][Out] ulong[] prgn, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromDoubleVector([In][Out] double[] prgn, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromFileTimeVector([In][Out] System.Runtime.InteropServices.ComTypes.FILETIME[] prgft, uint cElems, out PropVariant ppropvar);

		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern void InitPropVariantFromStringVector([In][Out] string[] prgsz, uint cElems, out PropVariant ppropvar);
	}

	private ushort valueType;

	private ushort wReserved1;

	private ushort wReserved2;

	private ushort wReserved3;

	private IntPtr valueData;

	private int valueDataExt;

	public static PropVariant Empty
	{
		get
		{
			PropVariant result = default(PropVariant);
			result.valueType = 0;
			result.wReserved1 = (result.wReserved2 = (result.wReserved3 = 0));
			result.valueData = IntPtr.Zero;
			result.valueDataExt = 0;
			return result;
		}
	}

	public VarEnum VarType => (VarEnum)valueType;

	public object Value
	{
		get
		{
			switch ((VarEnum)valueType)
			{
			case VarEnum.VT_I1:
				return cVal;
			case VarEnum.VT_UI1:
				return bVal;
			case VarEnum.VT_I2:
				return iVal;
			case VarEnum.VT_UI2:
				return uiVal;
			case VarEnum.VT_I4:
			case VarEnum.VT_INT:
				return lVal;
			case VarEnum.VT_UI4:
			case VarEnum.VT_UINT:
				return ulVal;
			case VarEnum.VT_I8:
				return hVal;
			case VarEnum.VT_UI8:
				return uhVal;
			case VarEnum.VT_R4:
				return fltVal;
			case VarEnum.VT_R8:
				return dblVal;
			case VarEnum.VT_BOOL:
				return boolVal;
			case VarEnum.VT_ERROR:
				return scode;
			case VarEnum.VT_CY:
				return cyVal;
			case VarEnum.VT_DATE:
				return date;
			case VarEnum.VT_FILETIME:
				return DateTime.FromFileTime(hVal);
			case VarEnum.VT_BSTR:
				return Marshal.PtrToStringBSTR(valueData);
			case VarEnum.VT_BLOB:
				return GetBlobData();
			case VarEnum.VT_LPSTR:
				return Marshal.PtrToStringAnsi(valueData);
			case VarEnum.VT_LPWSTR:
				return Marshal.PtrToStringUni(valueData);
			case VarEnum.VT_UNKNOWN:
				return Marshal.GetObjectForIUnknown(valueData);
			case VarEnum.VT_DISPATCH:
				return Marshal.GetObjectForIUnknown(valueData);
			case VarEnum.VT_DECIMAL:
				return CrackDecimal();
			case (VarEnum)8205:
				return CrackSingleDimSafeArray(valueData);
			case (VarEnum)4127:
				return GetStringVector();
			case (VarEnum)4098:
				return GetVector<short>();
			case (VarEnum)4114:
				return GetVector<ushort>();
			case (VarEnum)4099:
				return GetVector<int>();
			case (VarEnum)4115:
				return GetVector<uint>();
			case (VarEnum)4116:
				return GetVector<long>();
			case (VarEnum)4117:
				return GetVector<ulong>();
			case (VarEnum)4101:
				return GetVector<double>();
			case (VarEnum)4107:
				return GetVector<bool>();
			case (VarEnum)4160:
				return GetVector<DateTime>();
			default:
				throw new NotSupportedException("The type of this variable is not support ('" + valueType.ToString(CultureInfo.CurrentCulture.NumberFormat) + "')");
			}
		}
	}

	private sbyte cVal => (sbyte)GetDataBytes()[0];

	private byte bVal => GetDataBytes()[0];

	private short iVal => BitConverter.ToInt16(GetDataBytes(), 0);

	private ushort uiVal => BitConverter.ToUInt16(GetDataBytes(), 0);

	private int lVal => BitConverter.ToInt32(GetDataBytes(), 0);

	private uint ulVal => BitConverter.ToUInt32(GetDataBytes(), 0);

	private long hVal => BitConverter.ToInt64(GetDataBytes(), 0);

	private ulong uhVal => BitConverter.ToUInt64(GetDataBytes(), 0);

	private float fltVal => BitConverter.ToSingle(GetDataBytes(), 0);

	private double dblVal => BitConverter.ToDouble(GetDataBytes(), 0);

	private bool boolVal
	{
		get
		{
			if (iVal != 0)
			{
				return true;
			}
			return false;
		}
	}

	private int scode => lVal;

	private decimal cyVal => decimal.FromOACurrency(hVal);

	private DateTime date => DateTime.FromOADate(dblVal);

	public static PropVariant FromObject(object value)
	{
		PropVariant result = default(PropVariant);
		if (value == null)
		{
			result.Clear();
			return result;
		}
		if (value.GetType() == typeof(string))
		{
			if (string.IsNullOrEmpty(value as string) || string.IsNullOrEmpty((value as string).Trim()))
			{
				throw new ArgumentException("String argument cannot be null or empty.");
			}
			result.SetString(value as string);
		}
		else if (value.GetType() == typeof(bool?))
		{
			result.SetBool((value as bool?).Value);
		}
		else if (value.GetType() == typeof(bool))
		{
			result.SetBool((bool)value);
		}
		else if (value.GetType() == typeof(byte?))
		{
			result.SetByte((value as byte?).Value);
		}
		else if (value.GetType() == typeof(byte))
		{
			result.SetByte((byte)value);
		}
		else if (value.GetType() == typeof(sbyte?))
		{
			result.SetSByte((value as sbyte?).Value);
		}
		else if (value.GetType() == typeof(sbyte))
		{
			result.SetSByte((sbyte)value);
		}
		else if (value.GetType() == typeof(short?))
		{
			result.SetShort((value as short?).Value);
		}
		else if (value.GetType() == typeof(short))
		{
			result.SetShort((short)value);
		}
		else if (value.GetType() == typeof(ushort?))
		{
			result.SetUShort((value as ushort?).Value);
		}
		else if (value.GetType() == typeof(ushort))
		{
			result.SetUShort((ushort)value);
		}
		else if (value.GetType() == typeof(int?))
		{
			result.SetInt((value as int?).Value);
		}
		else if (value.GetType() == typeof(int))
		{
			result.SetInt((int)value);
		}
		else if (value.GetType() == typeof(uint?))
		{
			result.SetUInt((value as uint?).Value);
		}
		else if (value.GetType() == typeof(uint))
		{
			result.SetUInt((uint)value);
		}
		else if (value.GetType() == typeof(long?))
		{
			result.SetLong((value as long?).Value);
		}
		else if (value.GetType() == typeof(long))
		{
			result.SetLong((long)value);
		}
		else if (value.GetType() == typeof(ulong?))
		{
			result.SetULong((value as ulong?).Value);
		}
		else if (value.GetType() == typeof(ulong))
		{
			result.SetULong((ulong)value);
		}
		else if (value.GetType() == typeof(double?))
		{
			result.SetDouble((value as double?).Value);
		}
		else if (value.GetType() == typeof(double))
		{
			result.SetDouble((double)value);
		}
		else if (value.GetType() == typeof(decimal?))
		{
			result.SetDecimal((value as decimal?).Value);
		}
		else if (value.GetType() == typeof(decimal))
		{
			result.SetDecimal((decimal)value);
		}
		else if (value.GetType() == typeof(DateTime?))
		{
			result.SetDateTime((value as DateTime?).Value);
		}
		else if (value.GetType() == typeof(DateTime))
		{
			result.SetDateTime((DateTime)value);
		}
		else if (value.GetType() == typeof(string[]))
		{
			result.SetStringVector(value as string[]);
		}
		else if (value.GetType() == typeof(short[]))
		{
			result.SetShortVector(value as short[]);
		}
		else if (value.GetType() == typeof(ushort[]))
		{
			result.SetUShortVector(value as ushort[]);
		}
		else if (value.GetType() == typeof(int[]))
		{
			result.SetIntVector(value as int[]);
		}
		else if (value.GetType() == typeof(uint[]))
		{
			result.SetUIntVector(value as uint[]);
		}
		else if (value.GetType() == typeof(long[]))
		{
			result.SetLongVector(value as long[]);
		}
		else if (value.GetType() == typeof(ulong[]))
		{
			result.SetULongVector(value as ulong[]);
		}
		else if (value.GetType() == typeof(DateTime[]))
		{
			result.SetDateTimeVector(value as DateTime[]);
		}
		else
		{
			if (!(value.GetType() == typeof(bool[])))
			{
				throw new ArgumentException("This Value type is not supported.");
			}
			result.SetBoolVector(value as bool[]);
		}
		return result;
	}

	public bool IsNull()
	{
		if (valueType != 0)
		{
			return valueType == 1;
		}
		return true;
	}

	public void Clear()
	{
		PropVariant pvar = this;
		UnsafeNativeMethods.PropVariantClear(ref pvar);
		valueType = 0;
		wReserved1 = (wReserved2 = (wReserved3 = 0));
		valueData = IntPtr.Zero;
		valueDataExt = 0;
	}

	public PropVariant Clone()
	{
		PropVariant pSrc = this;
		UnsafeNativeMethods.PropVariantCopy(out var pDst, ref pSrc);
		return pDst;
	}

	public void SetUInt(uint value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 19;
		valueData = (IntPtr)(int)value;
	}

	public void SetBool(bool value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 11;
		valueData = (value ? ((IntPtr)65535) : ((IntPtr)0));
	}

	public void SetDateTime(DateTime value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 64;
		System.Runtime.InteropServices.ComTypes.FILETIME pftIn = DateTimeTotFileTime(value);
		UnsafeNativeMethods.InitPropVariantFromFileTime(ref pftIn, out var ppropvar);
		CopyData(ppropvar);
	}

	public void SetString(string value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 31;
		valueData = Marshal.StringToCoTaskMemUni(value);
	}

	public void SetIUnknown(object value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 13;
		valueData = Marshal.GetIUnknownForObject(value);
	}

	public void SetSafeArray(Array array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array == null)
		{
			return;
		}
		IntPtr psa = UnsafeNativeMethods.SafeArrayCreateVector(13, 0, (uint)array.Length);
		IntPtr ptr = UnsafeNativeMethods.SafeArrayAccessData(psa);
		try
		{
			for (int i = 0; i < array.Length; i++)
			{
				object value = array.GetValue(i);
				IntPtr val = ((value != null) ? Marshal.GetIUnknownForObject(value) : IntPtr.Zero);
				Marshal.WriteIntPtr(ptr, i * IntPtr.Size, val);
			}
		}
		finally
		{
			UnsafeNativeMethods.SafeArrayUnaccessData(psa);
		}
		valueType = 8205;
		valueData = psa;
	}

	public void SetByte(byte value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 17;
		valueData = (IntPtr)value;
	}

	public void SetSByte(sbyte value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 16;
		valueData = (IntPtr)value;
	}

	public void SetShort(short value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 2;
		valueData = (IntPtr)value;
	}

	public void SetUShort(ushort value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 18;
		valueData = (IntPtr)value;
	}

	public void SetInt(int value)
	{
		if (!IsNull())
		{
			Clear();
		}
		valueType = 3;
		valueData = (IntPtr)value;
	}

	public void SetUIntVector(uint[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromUInt32Vector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetStringVector(string[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromStringVector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetBoolVector(bool[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromBooleanVector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetShortVector(short[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromInt16Vector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetUShortVector(ushort[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromUInt16Vector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetIntVector(int[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromInt32Vector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetLongVector(long[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromInt64Vector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetULongVector(ulong[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromUInt64Vector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetDoubleVector(double[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			UnsafeNativeMethods.InitPropVariantFromDoubleVector(array, (uint)array.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetDateTimeVector(DateTime[] array)
	{
		if (!IsNull())
		{
			Clear();
		}
		if (array != null)
		{
			System.Runtime.InteropServices.ComTypes.FILETIME[] array2 = new System.Runtime.InteropServices.ComTypes.FILETIME[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				ref System.Runtime.InteropServices.ComTypes.FILETIME reference = ref array2[i];
				reference = DateTimeTotFileTime(array[i]);
			}
			UnsafeNativeMethods.InitPropVariantFromFileTimeVector(array2, (uint)array2.Length, out var ppropvar);
			CopyData(ppropvar);
		}
	}

	public void SetDecimal(decimal value)
	{
		if (!IsNull())
		{
			Clear();
		}
		this = new PVDecimalOuterUnion
		{
			decVal = value
		}.propVar;
		valueType = 14;
	}

	public void SetLong(long value)
	{
		if (!IsNull())
		{
			Clear();
		}
		long[] prgn = new long[1] { value };
		UnsafeNativeMethods.InitPropVariantFromInt64Vector(prgn, 1u, out var ppropvar);
		CreatePropVariantFromVectorElement(ppropvar);
	}

	public void SetULong(ulong value)
	{
		if (!IsNull())
		{
			Clear();
		}
		ulong[] prgn = new ulong[1] { value };
		UnsafeNativeMethods.InitPropVariantFromUInt64Vector(prgn, 1u, out var ppropvar);
		CreatePropVariantFromVectorElement(ppropvar);
	}

	public void SetDouble(double value)
	{
		if (!IsNull())
		{
			Clear();
		}
		double[] prgn = new double[1] { value };
		UnsafeNativeMethods.InitPropVariantFromDoubleVector(prgn, 1u, out var ppropvar);
		CreatePropVariantFromVectorElement(ppropvar);
	}

	public static bool operator ==(PropVariant left, PropVariant right)
	{
		throw new NotImplementedException();
	}

	public static bool operator !=(PropVariant left, PropVariant right)
	{
		throw new NotImplementedException();
	}

	public override string ToString()
	{
		if (IsNull())
		{
			return "(null)";
		}
		return string.Concat("PropVariant: ", (VarEnum)valueType, ":", Value);
	}

	public override bool Equals(object obj)
	{
		throw new NotImplementedException();
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	private void CopyData(PropVariant propVar)
	{
		valueType = propVar.valueType;
		valueData = propVar.valueData;
		valueDataExt = propVar.valueDataExt;
	}

	private void CreatePropVariantFromVectorElement(PropVariant propVar)
	{
		CopyData(propVar);
		UnsafeNativeMethods.InitPropVariantFromPropVariantVectorElem(ref this, 0u, out propVar);
		CopyData(propVar);
	}

	private static long FileTimeToDateTime(ref System.Runtime.InteropServices.ComTypes.FILETIME val)
	{
		return ((long)val.dwHighDateTime << 32) + val.dwLowDateTime;
	}

	private static System.Runtime.InteropServices.ComTypes.FILETIME DateTimeTotFileTime(DateTime value)
	{
		long num = value.ToFileTime();
		return new System.Runtime.InteropServices.ComTypes.FILETIME
		{
			dwLowDateTime = (int)(num & 0xFFFFFFFFu),
			dwHighDateTime = (int)(num >> 32)
		};
	}

	private object GetBlobData()
	{
		byte[] array = new byte[lVal];
		IntPtr source;
		if (IntPtr.Size == 4)
		{
			source = new IntPtr(valueDataExt);
		}
		else
		{
			if (IntPtr.Size != 8)
			{
				throw new NotSupportedException();
			}
			source = new IntPtr((long)BitConverter.ToInt32(GetDataBytes(), 4) + (long)BitConverter.ToInt32(GetDataBytes(), 8));
		}
		Marshal.Copy(source, array, 0, lVal);
		return array;
	}

	private Array GetVector<T>() where T : struct
	{
		int num = UnsafeNativeMethods.PropVariantGetElementCount(ref this);
		if (num <= 0)
		{
			return null;
		}
		Array array = new T[num];
		for (uint num2 = 0u; num2 < num; num2++)
		{
			if (typeof(T) == typeof(short))
			{
				UnsafeNativeMethods.PropVariantGetInt16Elem(ref this, num2, out var pnVal);
				array.SetValue(pnVal, num2);
			}
			else if (typeof(T) == typeof(ushort))
			{
				UnsafeNativeMethods.PropVariantGetUInt16Elem(ref this, num2, out var pnVal2);
				array.SetValue(pnVal2, num2);
			}
			else if (typeof(T) == typeof(int))
			{
				UnsafeNativeMethods.PropVariantGetInt32Elem(ref this, num2, out var pnVal3);
				array.SetValue(pnVal3, num2);
			}
			else if (typeof(T) == typeof(uint))
			{
				UnsafeNativeMethods.PropVariantGetUInt32Elem(ref this, num2, out var pnVal4);
				array.SetValue(pnVal4, num2);
			}
			else if (typeof(T) == typeof(long))
			{
				UnsafeNativeMethods.PropVariantGetInt64Elem(ref this, num2, out var pnVal5);
				array.SetValue(pnVal5, num2);
			}
			else if (typeof(T) == typeof(ulong))
			{
				UnsafeNativeMethods.PropVariantGetUInt64Elem(ref this, num2, out var pnVal6);
				array.SetValue(pnVal6, num2);
			}
			else if (typeof(T) == typeof(DateTime))
			{
				UnsafeNativeMethods.PropVariantGetFileTimeElem(ref this, num2, out var pftVal);
				long fileTime = FileTimeToDateTime(ref pftVal);
				array.SetValue(DateTime.FromFileTime(fileTime), num2);
			}
			else if (typeof(T) == typeof(bool))
			{
				UnsafeNativeMethods.PropVariantGetBooleanElem(ref this, num2, out var pfVal);
				array.SetValue(pfVal, num2);
			}
			else if (typeof(T) == typeof(double))
			{
				UnsafeNativeMethods.PropVariantGetDoubleElem(ref this, num2, out var pnVal7);
				array.SetValue(pnVal7, num2);
			}
			else if (typeof(T) == typeof(string))
			{
				UnsafeNativeMethods.PropVariantGetStringElem(ref this, num2, out var ppszVal);
				array.SetValue(ppszVal, num2);
			}
		}
		return array;
	}

	private string[] GetStringVector()
	{
		int num = UnsafeNativeMethods.PropVariantGetElementCount(ref this);
		if (num <= 0)
		{
			return null;
		}
		string[] array = new string[num];
		for (uint num2 = 0u; num2 < num; num2++)
		{
			UnsafeNativeMethods.PropVariantGetStringElem(ref this, num2, out array[num2]);
		}
		return array;
	}

	private byte[] GetDataBytes()
	{
		byte[] array = new byte[IntPtr.Size + 4];
		if (IntPtr.Size == 4)
		{
			BitConverter.GetBytes(valueData.ToInt32()).CopyTo(array, 0);
		}
		else if (IntPtr.Size == 8)
		{
			BitConverter.GetBytes(valueData.ToInt64()).CopyTo(array, 0);
		}
		BitConverter.GetBytes(valueDataExt).CopyTo(array, IntPtr.Size);
		return array;
	}

	private static Array CrackSingleDimSafeArray(IntPtr psa)
	{
		uint num = UnsafeNativeMethods.SafeArrayGetDim(psa);
		if (num != 1)
		{
			throw new ArgumentException("Multi-dimensional SafeArrays not supported.");
		}
		int num2 = UnsafeNativeMethods.SafeArrayGetLBound(psa, 1u);
		int num3 = UnsafeNativeMethods.SafeArrayGetUBound(psa, 1u);
		int num4 = num3 - num2 + 1;
		object[] array = new object[num4];
		for (int i = num2; i <= num3; i++)
		{
			array[i] = UnsafeNativeMethods.SafeArrayGetElement(psa, ref i);
		}
		return array;
	}

	private decimal CrackDecimal()
	{
		PVDecimalOuterUnion pVDecimalOuterUnion = new PVDecimalOuterUnion
		{
			propVar = this
		};
		return pVDecimalOuterUnion.decVal;
	}
}
