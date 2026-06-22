using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using SolidWorks.Interop.sldworks;
using ZTool;

[StandardModule]
internal static class Type_16
{
	public struct Type_17
	{
		public IntPtr f_65;

		public int f_66;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string f_67;
	}

	public struct Type_18
	{
		public string f_68;

		public object f_69;

		public bool f_70;

		public string f_71;

		public long f_72;

		public Component2 f_73;

		public ModelDoc2 f_74;
	}

	public const int f_46 = 13;

	public const int f_47 = 14;

	public const int f_48 = 786;

	public const int f_49 = 1;

	public const int f_50 = 2;

	public const int f_51 = 4;

	public const int f_52 = -4;

	public const int f_53 = 12;

	public const int f_54 = 258;

	public const int f_55 = 74;

	public static int f_56 = 1;

	public static List<string> f_57 = new List<string>();

	public static string f_58;

	public static ModelDoc2 f_59;

	public static Component2 f_60;

	public static Dictionary<string, string> f_61 = new Dictionary<string, string>();

	public static string f_62 = Path.GetTempPath() + "\\ZTool";

	public static string f_63 = f_62 + "\\ReNameLog.txt";

	public static string f_64 = f_62 + "\\Ferencelog.txt";

	public static string p_5
	{
		get
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			UriBuilder uriBuilder = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uriBuilder.Path);
			return Path.GetDirectoryName(path);
		}
	}

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	public static extern int m_46(int P_0, int P_1, int P_2, string P_3);

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	public static extern int m_47(int P_0, int P_1, int P_2, ref Type_17 P_3);

	[DllImport("User32.dll", EntryPoint = "FindWindow")]
	public static extern int m_48(string P_0, string P_1);

	[DllImport("user32.dll", EntryPoint = "IsWindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool m_49(IntPtr P_0);

	[DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "ShowWindow")]
	public static extern int m_50(IntPtr P_0, short P_1);

	[DllImport("user32.dll", EntryPoint = "MoveWindow")]
	public static extern bool m_51(IntPtr P_0, int P_1, int P_2, int P_3, int P_4, bool P_5);

	[DllImport("user32.dll", EntryPoint = "SetProcessDPIAware")]
	public static extern bool m_52();

	public static string m_53(string P_0, int P_1 = 0)
	{
		string text = "";
		try
		{
			string directoryName = Path.GetDirectoryName(P_0);
			string fileName = Path.GetFileName(P_0);
			string extension = Path.GetExtension(P_0);
			text = checked(P_1 switch
			{
				0 => directoryName + "\\", 
				1 => Strings.Left(fileName, Strings.Len(fileName) - Strings.Len(extension)), 
				2 => Strings.Right(extension, Strings.Len(extension) - 1), 
				3 => Strings.Left(P_0, Strings.Len(P_0) - Strings.Len(extension)), 
				4 => fileName, 
				5 => extension, 
				6 => directoryName, 
				_ => P_0, 
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			text = P_0;
			ProjectData.ClearProjectError();
		}
		return text;
	}

	public static void m_54(List<string> P_0, string P_1, string P_2 = "*.*", bool P_3 = true)
	{
		try
		{
			if (P_1 == null)
			{
				return;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(P_1);
			directoryInfo.GetDirectories();
			try
			{
				object obj = Strings.Split(P_2, "|");
				int num = Information.LBound((Array)obj);
				int num2 = Information.UBound((Array)obj);
				for (int i = num; i <= num2; i = checked(i + 1))
				{
					FileInfo[] files = directoryInfo.GetFiles(Conversions.ToString(NewLateBinding.LateIndexGet(obj, new object[1] { i }, null)), (System.IO.SearchOption)Conversions.ToInteger(Interaction.IIf(P_3, System.IO.SearchOption.AllDirectories, System.IO.SearchOption.TopDirectoryOnly)));
					foreach (FileInfo fileInfo in files)
					{
						if ((fileInfo.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
						{
							P_0.Add(fileInfo.FullName);
						}
					}
				}
			}
			catch (DirectoryNotFoundException ex)
			{
				ProjectData.SetProjectError(ex);
				DirectoryNotFoundException ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK);
			ProjectData.ClearProjectError();
		}
	}

	public static void m_55(string P_0)
	{
		try
		{
			string text = m_53(P_0, 3) + ".SLDDRW";
			if (File.Exists(P_0))
			{
				Type_12.p_0.FileSystem.DeleteFile(P_0, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
			}
			if (File.Exists(text))
			{
				Type_12.p_0.FileSystem.DeleteFile(text, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void m_56(string P_0, string P_1)
	{
		try
		{
			string text = m_53(P_0, 3) + ".SLDDRW";
			if (File.Exists(P_0))
			{
				Type_12.p_0.FileSystem.MoveFile(P_0, Path.Combine(P_1, m_53(P_0, 4)), overwrite: true);
			}
			if (File.Exists(text))
			{
				Type_12.p_0.FileSystem.MoveFile(text, Path.Combine(P_1, m_53(text, 4)), overwrite: true);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static bool m_57(string P_0)
	{
		bool result = false;
		if (string.IsNullOrEmpty(P_0) | string.IsNullOrWhiteSpace(P_0))
		{
			return false;
		}
		try
		{
			P_0 = Path.GetFullPath(P_0);
			P_0 = ((Operators.CompareString(Strings.Right(P_0, 1), "\\", TextCompare: false) == 0) ? P_0 : (P_0 + "\\"));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		if (Directory.Exists(P_0))
		{
			Process.Start("Explorer.exe", P_0);
			result = true;
		}
		return result;
	}

	public static bool m_58(string P_0)
	{
		bool result;
		try
		{
			result = string.Compare(P_0, "true", ignoreCase: true) == 0 || (string.Compare(P_0, "false", ignoreCase: true) != 0 && false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string m_59(int P_0, int P_1)
	{
		string text = "";
		string[] array = null;
		switch (P_1)
		{
		case 2:
			text = "0,1,2,3,4,5,6,7,8,9";
			array = text.Split(',');
			break;
		case 1:
			text = "a,b,c,d,e,f,g,h,i,j,k,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,D,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,X,Y,Z";
			array = text.Split(',');
			break;
		case 5:
			text = "a,b,c,d,e,f,g,h,i,j,k,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
			array = text.Split(',');
			break;
		case 3:
			text = "a,b,c,d,e,f,g,h,i,j,k,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,D,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,X,Y,Z,0,1,2,3,4,5,6,7,8,9";
			array = text.Split(',');
			break;
		case 4:
			text = "A,B,C,E,F,D,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
			array = text.Split(',');
			break;
		}
		StringBuilder stringBuilder = new StringBuilder(P_0);
		Random random = new Random();
		checked
		{
			int num = P_0 - 1;
			int num2 = default(int);
			int num3 = num2 + 1;
			int num4 = num;
			for (num2 = 0; ((num3 >> 31) ^ num2) <= ((num3 >> 31) ^ num4); num2 += num3)
			{
				stringBuilder.Append(array[random.Next(array.Length - 1)]);
			}
			return stringBuilder.ToString();
		}
	}

	public static WindowWrapper m_60(int P_0)
	{
		Process processById = Process.GetProcessById(P_0);
		if (!Information.IsNothing(processById))
		{
			IntPtr mainWindowHandle = processById.MainWindowHandle;
			return new WindowWrapper(mainWindowHandle);
		}
		return null;
	}

	public static string m_61(string P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			foreach (Match item in Regex.Matches(P_0, "([0-9A-Z])([0-9A-Z])", RegexOptions.IgnoreCase))
			{
				stringBuilder.Append($"{item.Groups[2].Value}{item.Groups[1].Value}");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return stringBuilder.ToString().Trim();
	}

	public static void m_62(string P_0, string P_1, string P_2)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software", writable: true).CreateSubKey("ZTool\\AddinMenuOption").CreateSubKey(P_0);
			registryKey.SetValue(P_1, Encoding.UTF8.GetBytes(P_2), RegistryValueKind.Binary);
			registryKey.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static string m_63(string P_0, string P_1)
	{
		string text = "";
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software", writable: true).CreateSubKey("ZTool\\AddinMenuOption").CreateSubKey(P_0);
			byte[] array = (byte[])registryKey.GetValue(P_1);
			registryKey.Close();
			if (!Information.IsNothing(array))
			{
				text = Encoding.UTF8.GetString(array);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return text.Trim();
	}

	public static string m_64(this string P_0)
	{
		string result;
		try
		{
			string text = "";
			byte[] bytes = Encoding.UTF8.GetBytes(P_0);
			foreach (byte b in bytes)
			{
				text += b.ToString("x2");
			}
			result = text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string m_65(this string P_0)
	{
		checked
		{
			string result;
			try
			{
				byte[] array = new byte[unchecked(P_0.Length / 2) - 1 + 1];
				int num = unchecked(P_0.Length / 2) - 1;
				for (int i = 0; i <= num; i++)
				{
					array[i] = Convert.ToByte(P_0.Substring(i * 2, 2), 16);
				}
				result = Encoding.UTF8.GetString(array);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				result = "";
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static string m_66(object P_0)
	{
		string text = "";
		string text2 = "";
		try
		{
			if (P_0 == null)
			{
				return "";
			}
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(P_0, null, "GetCurrentSheet", new object[0], null, null, null));
			if (objectValue == null)
			{
				return "";
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetViews", new object[0], null, null, null));
			if (objectValue2 == null)
			{
				return "";
			}
			for (object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue2, new object[1] { 0 }, null)); objectValue3 != null; objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, null, "GetNextView", new object[0], null, null, null)))
			{
				text = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "ReferencedConfiguration", new object[0], null, null, null));
				text2 = Conversions.ToString(NewLateBinding.LateGet(objectValue3, null, "GetReferencedModelName", new object[0], null, null, null));
				if (Strings.Len(text2) > 0)
				{
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return text2;
	}

	public static bool m_67(SldWorks P_0, ModelDoc2 P_1)
	{
		if (Information.IsNothing(P_1))
		{
			return false;
		}
		if (P_1.GetType() != 3)
		{
			return false;
		}
		DrawingDoc drawingDoc = (DrawingDoc)P_1;
		bool result = default(bool);
		try
		{
			string text = m_66(drawingDoc);
			string pathName;
			string text2;
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				pathName = P_1.GetPathName();
				text2 = m_53(text, 3) + ".SLDDRW";
				if (!pathName.Equals(text2, StringComparison.OrdinalIgnoreCase))
				{
					if (!File.Exists(text2))
					{
						goto IL_00c6;
					}
					if (MessageBox.Show(text2 + "Уже существует! Перезаписать?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						P_0.CloseDoc(text2);
						goto IL_00c6;
					}
					if (MessageBox.Show("Открыть?" + text2 + "？", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						P_0.OpenDoc(text2, 3);
						P_0.ActivateDoc(text2);
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_001c;
			IL_00c6:
			int num = P_1.SaveAs3(text2, 0, 1);
			if (File.Exists(text2) && num == 0)
			{
				try
				{
					if (File.Exists(pathName))
					{
						P_0.CloseDoc(pathName);
						File.Delete(pathName);
					}
					P_0.OpenDoc(text2, 3);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
				result = true;
			}
			end_IL_001c:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			MessageBox.Show(ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string m_68(object P_0)
	{
		IFormatter formatter = new BinaryFormatter();
		string empty = string.Empty;
		using MemoryStream memoryStream = new MemoryStream();
		formatter.Serialize(memoryStream, RuntimeHelpers.GetObjectValue(P_0));
		byte[] array = new byte[checked((int)(memoryStream.Length - 1) + 1)];
		array = memoryStream.ToArray();
		empty = Convert.ToBase64String(array);
		memoryStream.Flush();
		return empty;
	}

	public static object m_69(string P_0)
	{
		IFormatter formatter = new BinaryFormatter();
		byte[] array = Convert.FromBase64String(P_0);
		object obj = null;
		using Stream serializationStream = new MemoryStream(array, 0, array.Length);
		return RuntimeHelpers.GetObjectValue(formatter.Deserialize(serializationStream));
	}

	public static string m_70(object P_0)
	{
		string result = "";
		try
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			result = javaScriptSerializer.Serialize(RuntimeHelpers.GetObjectValue(P_0));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object m_71(string P_0, Type P_1)
	{
		object result = null;
		try
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			result = RuntimeHelpers.GetObjectValue(javaScriptSerializer.Deserialize(P_0, P_1));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool m_72(this string[] P_0, string P_1, StringComparison P_2)
	{
		bool result;
		try
		{
			if (Information.IsNothing(P_0))
			{
				result = false;
			}
			else
			{
				bool flag = false;
				foreach (string text in P_0)
				{
					if (text.Equals(P_1, P_2))
					{
						flag = true;
						break;
					}
				}
				result = flag;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
