using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

[HideModuleName]
[StandardModule]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[CompilerGenerated]
[DebuggerNonUserCode]
internal sealed class Type_26
{
	private static ResourceManager f_145;

	private static CultureInfo f_146;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager p_44
	{
		get
		{
			if (object.ReferenceEquals(f_145, null))
			{
				ResourceManager resourceManager = new ResourceManager("ZTool.MyResources", typeof(Type_26).Assembly);
				f_145 = resourceManager;
			}
			return f_145;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo p_45
	{
		get
		{
			return f_146;
		}
		set
		{
			f_146 = value;
		}
	}

	internal static Bitmap p_46
	{
		get
		{
			object objectValue = RuntimeHelpers.GetObjectValue(p_44.GetObject("lock_32", f_146));
			return (Bitmap)objectValue;
		}
	}

	internal static Bitmap p_47
	{
		get
		{
			object objectValue = RuntimeHelpers.GetObjectValue(p_44.GetObject("opened_folder_24", f_146));
			return (Bitmap)objectValue;
		}
	}

	internal static Bitmap p_48
	{
		get
		{
			object objectValue = RuntimeHelpers.GetObjectValue(p_44.GetObject("slddrw", f_146));
			return (Bitmap)objectValue;
		}
	}

	internal static string p_49 => p_44.GetString("t2PqyrYN", f_146);
}
