using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.sldworks;
using stdole;

namespace ZTool;

[DesignerGenerated]
public class PMPHandler : Form
{
	public enum swDocumentTypes_e
	{
		swDocPART = 1,
		swDocASSEMBLY,
		swDocDRAWING
	}

	[Serializable]
	public struct BOMPartData
	{
		public int BOMPartNoSource;

		public string BOMPartNumber;

		public string AlternateName;

		public string ParentName;
	}

	[CompilerGenerated]
	internal class Type_30
	{
		public string f_262;

		public Type_30(Type_30 P_0)
		{
			if (P_0 != null)
			{
				f_262 = P_0.f_262;
			}
		}

		[CompilerGenerated]
		public bool m_114(string P_0)
		{
			return P_0.Equals(f_262, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class Type_31
	{
		public string f_263;

		[CompilerGenerated]
		public bool m_115(string P_0)
		{
			return P_0.Equals(f_263, StringComparison.OrdinalIgnoreCase);
		}
	}

	private IContainer f_205;

	internal SldWorks f_206;

	private IntPtr f_207;

	private int f_208;

	private bool f_209;

	private bool f_210;

	private bool f_211;

	private bool f_212;

	private StringBuilder f_213;

	private StringBuilder f_214;

	private string f_215;

	private string f_216;

	private List<string> f_217;

	private List<string> f_218;

	private List<string> f_219;

	private List<string> f_220;

	private List<string> f_221;

	private string[] f_222;

	private string[] f_223;

	private string f_224;

	private int f_225;

	private bool f_226;

	private bool f_227;

	private int f_228;

	private bool f_229;

	private int f_230;

	private bool f_231;

	private bool f_232;

	private bool f_233;

	private int f_234;

	private string f_235;

	private bool f_236;

	private bool f_237;

	private string f_238;

	private string f_239;

	private int f_240;

	private int f_241;

	private int f_242;

	private int f_243;

	private int f_244;

	private int f_245;

	private int f_246;

	private int f_247;

	private int f_248;

	private int f_249;

	private int f_250;

	private int f_251;

	private int f_252;

	private int f_253;

	private int f_254;

	private int f_255;

	private int f_256;

	private int f_257;

	private int f_258;

	private bool f_259;

	private StringBuilder f_260;

	private List<string> f_261;

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && f_205 != null)
			{
				f_205.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void m_113()
	{
		SuspendLayout();
		SizeF sizeF = new SizeF(6f, 12f);
		AutoScaleDimensions = sizeF;
		AutoScaleMode = AutoScaleMode.Font;
		Size clientSize = new Size(284, 261);
		ClientSize = clientSize;
		Name = "Ztool_Receiver";
		Text = "Ztool_Receiver";
		ResumeLayout(performLayout: false);
	}

	public PMPHandler()
	{
		f_213 = new StringBuilder();
		f_214 = new StringBuilder();
		f_217 = new List<string>();
		f_218 = new List<string>();
		f_219 = new List<string>();
		f_220 = new List<string>();
		f_221 = new List<string>();
		f_259 = false;
		f_260 = new StringBuilder();
		f_261 = new List<string>();
		m_113();
		CreateHandle();
	}

	protected override void DefWndProc(ref Message m)
	{
		try
		{
			if (m.Msg == 74)
			{
				Type type = default(Type_16.Type_17).GetType();
				object lParam = m.GetLParam(type);
				Type_16.Type_17 type_ = default(Type_16.Type_17);
				Type_16.Type_17 type_2 = ((lParam != null) ? ((Type_16.Type_17)lParam) : type_);
				IntPtr f_ = type_2.f_65;
				if (f_ == (IntPtr)5)
				{
					f_259 = Type_16.m_58(type_2.f_67);
				}
				else if (f_ == (IntPtr)10)
				{
					string[] array = Strings.Split(type_2.f_67, "\r\n");
					if (array.Length >= 9 && Operators.CompareString(array[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						f_207 = (IntPtr)Conversions.ToLong(array[1]);
						f_208 = checked((int)Math.Round(Conversion.Val(array[2])));
						f_209 = Type_16.m_58(array[3]);
						f_210 = Type_16.m_58(array[4]);
						f_211 = Type_16.m_58(array[5]);
						f_212 = Type_16.m_58(array[6]);
						f_250 = Conversions.ToInteger(array[7]);
						if (array.Length >= 10)
						{
							f_221 = new List<string>(Type_16.m_65(array[8]).Split('\n'));
						}
						if ((f_208 == 0) | (f_208 == 1))
						{
							GetDataByBom();
						}
						else if (f_208 == 2)
						{
							GetDataFromSel();
						}
						else if (f_208 == 3)
						{
							GetDataFromVis();
						}
						else if (f_208 == 4)
						{
							GetFromFile(f_216);
						}
					}
				}
				else if (f_ == (IntPtr)15)
				{
					f_216 = type_2.f_67;
				}
				else if (f_ == (IntPtr)20)
				{
					string[] array2 = Strings.Split(type_2.f_67, "\r\n");
					if (array2.Length == 5 && Operators.CompareString(array2[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						f_207 = (IntPtr)Conversions.ToLong(array2[1]);
						GetPreview(array2[2], array2[3], Type_16.m_58(array2[4]));
					}
				}
				else if (f_ == (IntPtr)31)
				{
					string[] array3 = Strings.Split(type_2.f_67, "\r\n");
					if (array3.Length == 18 && Operators.CompareString(array3[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						f_207 = (IntPtr)Conversions.ToLong(array3[1]);
						f_225 = Conversions.ToInteger(array3[2]);
						f_226 = Type_16.m_58(array3[3]);
						f_227 = Type_16.m_58(array3[4]);
						f_228 = Conversions.ToInteger(array3[5]);
						f_229 = Type_16.m_58(array3[6]);
						f_230 = Conversions.ToInteger(array3[7]);
						f_231 = Type_16.m_58(array3[8]);
						f_232 = Type_16.m_58(array3[9]);
						f_233 = Type_16.m_58(array3[10]);
						f_234 = Conversions.ToInteger(array3[11]);
						f_236 = Type_16.m_58(array3[12]);
						f_237 = Type_16.m_58(array3[13]);
						f_238 = array3[14];
						f_239 = array3[15];
						f_235 = array3[16];
					}
				}
				else if (f_ == (IntPtr)32)
				{
					string[] array4 = Strings.Split(type_2.f_67, "\r\n");
					if (array4.Length == 22 && Operators.CompareString(array4[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						f_207 = (IntPtr)Conversions.ToLong(array4[1]);
						f_240 = Conversions.ToInteger(array4[2]);
						f_241 = Conversions.ToInteger(array4[3]);
						f_242 = Conversions.ToInteger(array4[4]);
						f_243 = Conversions.ToInteger(array4[5]);
						f_244 = Conversions.ToInteger(array4[6]);
						f_245 = Conversions.ToInteger(array4[7]);
						f_246 = Conversions.ToInteger(array4[8]);
						f_247 = Conversions.ToInteger(array4[9]);
						f_248 = Conversions.ToInteger(array4[10]);
						f_249 = Conversions.ToInteger(array4[11]);
						f_250 = Conversions.ToInteger(array4[12]);
						f_251 = Conversions.ToInteger(array4[13]);
						f_252 = Conversions.ToInteger(array4[14]);
						f_253 = Conversions.ToInteger(array4[15]);
						f_254 = Conversions.ToInteger(array4[16]);
						f_255 = Conversions.ToInteger(array4[17]);
						f_256 = Conversions.ToInteger(array4[18]);
						f_257 = Conversions.ToInteger(array4[19]);
						f_258 = Conversions.ToInteger(array4[20]);
					}
				}
				else if (f_ == (IntPtr)33)
				{
					f_215 = type_2.f_67;
				}
				else if (f_ == (IntPtr)34)
				{
					string[] array5 = Strings.Split(type_2.f_67, "\r\n");
					if (array5.Length == 1 && Operators.CompareString(array5[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0 && !Information.IsNothing(f_206))
					{
						if (Conversions.ToDouble(f_206.RevisionNumber().Substring(0, 2)) >= 22.0)
						{
							SaveData2(f_215);
						}
						else
						{
							SaveData(f_215);
						}
					}
				}
				else if (f_ == (IntPtr)40)
				{
					string[] array6 = Strings.Split(type_2.f_67, "\r\n");
					if (array6.Length == 8 && Operators.CompareString(array6[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						f_207 = (IntPtr)Conversions.ToLong(array6[1]);
						f_209 = Type_16.m_58(array6[2]);
						Setcomponentstate(array6[3], array6[4], array6[5], Conversions.ToInteger(array6[6]));
					}
				}
				else if (f_ == (IntPtr)50)
				{
					string[] array7 = Strings.Split(type_2.f_67, "\r\n");
					if (array7.Length == 3 && Operators.CompareString(array7[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						f_206.CommandInProgress = Type_16.m_58(array7[1]);
					}
				}
				else if (f_ == (IntPtr)60)
				{
					string[] array8 = Strings.Split(type_2.f_67, "\r\n");
					if (array8.Length == 5 && Operators.CompareString(array8[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						selectinsw(array8[1], array8[2], array8[3]);
					}
				}
				else if (f_ == (IntPtr)70)
				{
					string[] array9 = Strings.Split(type_2.f_67, "\r\n");
					if (array9.Length == 4 && Operators.CompareString(array9[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						readmaterialfile(array9[2]);
					}
				}
				else if (f_ == (IntPtr)80)
				{
					string[] array10 = Strings.Split(type_2.f_67, "\r\n");
					if (array10.Length == 5 && Operators.CompareString(array10[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						GetBOMPartData(array10[2], array10[3]);
					}
				}
				else if (f_ == (IntPtr)81)
				{
					string[] array11 = Strings.Split(type_2.f_67, "\r\n");
					if (array11.Length == 7 && Operators.CompareString(array11[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						SetBOMPartData(array11[2], array11[3], Conversions.ToInteger(array11[4]), array11[5]);
					}
				}
				else if (f_ == (IntPtr)90)
				{
					string[] array12 = Strings.Split(type_2.f_67, "\r\n");
					if (array12.Length == 3 && Operators.CompareString(array12[0], "ZToolRequest@001" + Type_16.m_61(Type_26.p_49), TextCompare: false) == 0)
					{
						f_207 = (IntPtr)Conversions.ToLong(array12[1]);
					}
				}
				else if (!(f_ == (IntPtr)100))
				{
				}
			}
			else
			{
				base.DefWndProc(ref m);
			}
		}
		catch (Exception)
		{
		}
	}

	public bool Dostop()
	{
		if (!Type_16.m_49(f_207) | f_259)
		{
			return true;
		}
		return false;
	}

	public int sendmessageC(int @int, string s)
	{
		s = s.Trim();
		Type_16.Type_17 type_ = default(Type_16.Type_17);
		ref IntPtr f_ = ref type_.f_65;
		f_ = new IntPtr(@int);
		type_.f_66 = checked(Encoding.Unicode.GetBytes(s).Length + 1);
		type_.f_67 = s;
		return Type_16.m_47((int)f_207, 74, 0, ref type_);
	}

	public void GetDataByBom()
	{
		checked
		{
			try
			{
				f_217.Clear();
				f_218.Clear();
				f_219.Clear();
				f_220.Clear();
				f_214.Clear();
				f_260.Clear();
				f_261.Clear();
				int num = 0;
				f_206.DocumentVisible(Visible: false, 1);
				f_206.DocumentVisible(Visible: false, 2);
				ModelDoc2 modelDoc = (ModelDoc2)f_206.ActiveDoc;
				if (Information.IsNothing(modelDoc))
				{
					return;
				}
				Configuration configuration = null;
				int num2 = 2;
				string pathName = modelDoc.GetPathName();
				f_222 = (string[])modelDoc.GetConfigurationNames();
				if (modelDoc.GetType() == 1)
				{
					if (f_212)
					{
						f_223 = new string[1];
						f_223[0] = "";
						string[] array = f_222;
						foreach (string text in array)
						{
							f_223 = (string[])Utils.CopyArray(f_223, new string[Information.UBound(f_223) + 1 + 1]);
							f_223[Information.UBound(f_223)] = text;
						}
					}
					else
					{
						f_223 = new string[1];
						f_223[0] = Conversions.ToString(NewLateBinding.LateGet(modelDoc.GetActiveConfiguration(), null, "Name", new object[0], null, null, null));
					}
					sendmessageC(0, (Information.UBound(f_223) + 1).ToString());
				}
				else if (modelDoc.GetType() == 2)
				{
					f_223 = new string[1];
					f_223[0] = Conversions.ToString(NewLateBinding.LateGet(modelDoc.GetActiveConfiguration(), null, "Name", new object[0], null, null, null));
					sendmessageC(0, modelDoc.GetFeatureCount().ToString());
					configuration = (Configuration)modelDoc.GetConfigurationByName(f_223[0]);
					if (!Information.IsNothing(configuration))
					{
						num2 = Conversions.ToInteger(NewLateBinding.LateGet(configuration, null, "ChildComponentDisplayInBOM", new object[0], null, null, null));
					}
				}
				else
				{
					if (modelDoc.GetType() != 3)
					{
						return;
					}
					f_223 = new string[1];
					f_223[0] = "";
				}
				sendmessageC(1, "Получение данных");
				f_260.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
				f_260.AppendLine("<Tree>");
				f_260.AppendLine("<Node PathName=\"" + Type_16.m_64(pathName) + "\" ConfigureName=\"" + Type_16.m_64(f_223[0]) + "\" IsSuppressed=\"" + Conversions.ToString(Value: false) + "\" ExcludeFromBOM=\"" + Conversions.ToString(Value: false) + "\" DisplayInBOM=\"" + Conversions.ToString(num2) + "\" FeatureName=\"" + Type_16.m_64(Type_16.m_53(pathName, 1)) + "\" >");
				string[] array2 = f_223;
				foreach (string text2 in array2)
				{
					if (modelDoc.GetType() == 1)
					{
						if (Dostop())
						{
							break;
						}
						num++;
						sendmessageC(2, num.ToString());
					}
					f_214.AppendLine("PathFileName\u001e\u001c" + pathName);
					f_214.AppendLine("ConfigureName\u001e\u001c" + text2);
					f_214.AppendLine("NLevel\u001e\u001c0");
					if (modelDoc.GetType() == 2)
					{
						f_214.AppendLine("DataFromAsm\u001e\u001c" + true);
					}
					f_214.AppendLine("Quantity\u001e\u001c1");
					Getprp(modelDoc, text2);
					f_214.AppendLine(">");
				}
				if (modelDoc.GetType() == 2)
				{
					num = 0;
					object objectValue = RuntimeHelpers.GetObjectValue(((AssemblyDoc)modelDoc).GetComponents(true));
					Feature feature = (Feature)modelDoc.FirstFeature();
					while (feature != null && !Dostop())
					{
						num++;
						sendmessageC(2, num.ToString());
						string typeName = feature.GetTypeName2();
						if (typeName.Equals("Reference", StringComparison.OrdinalIgnoreCase) || typeName.Equals("ReferencePattern", StringComparison.OrdinalIgnoreCase) || typeName.Equals("SplitReference", StringComparison.OrdinalIgnoreCase))
						{
							string name = feature.Name;
							TraFeature(RuntimeHelpers.GetObjectValue(objectValue), name, 1);
						}
						feature = (Feature)feature.GetNextFeature();
					}
				}
				f_260.AppendLine("</Node>");
				f_260.AppendLine("</Tree>");
				sendmessageC(7, f_260.ToString());
				if (f_219.Count > 0)
				{
					int num3 = f_219.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						f_214.Replace("\r\nQuantity#\u001e\u001c" + Conversions.ToString(k) + "\r\n", "\r\nQuantity\u001e\u001c" + f_219[k] + "\r\n");
					}
				}
				sendmessageC(3, f_214.ToString());
				f_206.ActivateDoc(modelDoc.GetPathName());
				int num4 = f_261.Count - 1;
				for (int l = 0; l <= num4; l++)
				{
					f_206.CloseDoc(f_261[l]);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				if (!(ex2 is NullReferenceException))
				{
					MessageBox.Show(new WindowWrapper(f_207), ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				ProjectData.ClearProjectError();
			}
			finally
			{
				f_206.DocumentVisible(Visible: true, 1);
				f_206.DocumentVisible(Visible: true, 2);
			}
		}
	}

	public void TraFeature(object vComponents, string FeatureName, int nLevel)
	{
		checked
		{
			try
			{
				if (Dostop() || Information.IsNothing(RuntimeHelpers.GetObjectValue(vComponents)))
				{
					return;
				}
				Component2 component = null;
				int num = Information.UBound((Array)vComponents);
				for (int i = 0; i <= num; i++)
				{
					Component2 component2 = (Component2)NewLateBinding.LateIndexGet(vComponents, new object[1] { i }, null);
					if (FeatureName.Equals(component2.Name, StringComparison.OrdinalIgnoreCase))
					{
						component = (Component2)NewLateBinding.LateIndexGet(vComponents, new object[1] { i }, null);
						break;
					}
				}
				if (Information.IsNothing(component))
				{
					return;
				}
				string pathName = component.GetPathName();
				string referencedConfiguration = component.ReferencedConfiguration;
				int num2;
				if (pathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
				{
					num2 = 1;
				}
				else if (pathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
				{
					num2 = 2;
				}
				else
				{
					if (!pathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
					{
						component = null;
						return;
					}
					num2 = 3;
				}
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				int num3 = 0;
				bool flag4 = false;
				ModelDoc2 modelDoc = null;
				Configuration configuration = null;
				int Errors = default(int);
				int Warnings = default(int);
				if (f_208 == 0)
				{
					if (!component.ExcludeFromBOM && !component.IsSuppressed())
					{
						modelDoc = (ModelDoc2)component.GetModelDoc2();
						if (Information.IsNothing(modelDoc))
						{
							modelDoc = f_206.OpenDoc6(pathName, num2, 1, referencedConfiguration, ref Errors, ref Warnings);
							f_261.Add(pathName);
						}
					}
				}
				else
				{
					modelDoc = (ModelDoc2)component.GetModelDoc2();
					if (Information.IsNothing(modelDoc))
					{
						modelDoc = f_206.OpenDoc6(pathName, num2, 1, referencedConfiguration, ref Errors, ref Warnings);
						f_261.Add(pathName);
					}
				}
				if (num2 == 2 && !Information.IsNothing(modelDoc))
				{
					configuration = (Configuration)modelDoc.GetConfigurationByName(referencedConfiguration);
					if (!Information.IsNothing(configuration))
					{
						num3 = Conversions.ToInteger(NewLateBinding.LateGet(configuration, null, "ChildComponentDisplayInBOM", new object[0], null, null, null));
					}
					if (f_208 == 0)
					{
						switch (num3)
						{
						case 3:
							flag3 = true;
							break;
						case 1:
							flag2 = true;
							break;
						}
					}
				}
				f_260.AppendLine("<Node PathName=\"" + Type_16.m_64(pathName) + "\" ConfigureName=\"" + Type_16.m_64(referencedConfiguration) + "\" IsSuppressed=\"" + Conversions.ToString(component.IsSuppressed()) + "\" ExcludeFromBOM=\"" + Conversions.ToString(component.ExcludeFromBOM) + "\" DisplayInBOM=\"" + Conversions.ToString(num3) + "\" FeatureName=\"" + Type_16.m_64(FeatureName) + "\" >");
				if (!Information.IsNothing(modelDoc))
				{
					if (f_217.Count > 0)
					{
						int num4 = f_217.Count - 1;
						for (int j = 0; j <= num4; j++)
						{
							if ((!f_209 && f_217[j].Equals(pathName, StringComparison.OrdinalIgnoreCase) && f_218[j].Equals(referencedConfiguration, StringComparison.OrdinalIgnoreCase)) || (f_209 && f_217[j].Equals(pathName, StringComparison.OrdinalIgnoreCase)))
							{
								flag = true;
								f_219[j] = Conversions.ToString(Conversions.ToDouble(f_219[j]) + 1.0);
								break;
							}
						}
					}
					if ((!flag && !flag3 && !f_210 && f_208 == 0) || (!flag && !flag3 && !component.IsVirtual && f_210 && f_208 == 0) || (!flag && !flag3 && f_208 == 1))
					{
						f_217.Add(pathName);
						f_220.Add(Conversions.ToString(nLevel));
						f_218.Add(referencedConfiguration);
						f_219.Add(Conversions.ToString(1));
						f_214.AppendLine("PathFileName\u001e\u001c" + pathName);
						f_214.AppendLine("ConfigureName\u001e\u001c" + referencedConfiguration);
						f_214.AppendLine("NLevel\u001e\u001c" + Conversions.ToString(nLevel));
						f_214.AppendLine("Quantity#\u001e\u001c" + Conversions.ToString(f_217.Count - 1));
						Getprp(modelDoc, referencedConfiguration);
						f_214.AppendLine(">");
					}
					if (num2 == 2 && !flag2)
					{
						object obj = null;
						if (!Information.IsNothing(configuration))
						{
							obj = RuntimeHelpers.GetObjectValue(configuration.GetRootComponent3(Resolve: true).GetChildren());
							configuration = null;
						}
						Feature feature = (Feature)modelDoc.FirstFeature();
						while (!Information.IsNothing(feature))
						{
							string typeName = feature.GetTypeName2();
							if (typeName.Equals("Reference", StringComparison.OrdinalIgnoreCase) || typeName.Equals("ReferencePattern", StringComparison.OrdinalIgnoreCase) || typeName.Equals("SplitReference", StringComparison.OrdinalIgnoreCase))
							{
								string name = feature.Name;
								TraFeature(RuntimeHelpers.GetObjectValue(obj), name, nLevel + 1);
							}
							feature = (Feature)feature.GetNextFeature();
						}
					}
				}
				f_260.AppendLine("</Node>");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				ProjectData.ClearProjectError();
			}
		}
	}

	public void GetDataFromSel()
	{
		List<Component2> list = new List<Component2>();
		checked
		{
			try
			{
				ModelDoc2 modelDoc = (ModelDoc2)f_206.ActiveDoc;
				if (Information.IsNothing(modelDoc) || modelDoc.GetType() != 2)
				{
					return;
				}
				AssemblyDoc assemblyDoc = (AssemblyDoc)modelDoc;
				if (Information.IsNothing(assemblyDoc))
				{
					return;
				}
				SelectionMgr selectionMgr = (SelectionMgr)modelDoc.SelectionManager;
				if (Information.IsNothing(selectionMgr))
				{
					return;
				}
				int selectedObjectCount = selectionMgr.GetSelectedObjectCount2(-1);
				HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
				int num = selectedObjectCount;
				for (int i = 1; i <= num; i++)
				{
					if (Dostop())
					{
						return;
					}
					object[] array = new object[2] { i, -1 };
					object[] arguments = array;
					bool[] array2 = new bool[2] { true, false };
					object obj = NewLateBinding.LateGet(selectionMgr, null, "GetSelectedObjectsComponent4", arguments, null, null, array2);
					if (array2[0])
					{
						i = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
					}
					object objectValue = RuntimeHelpers.GetObjectValue(obj);
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(modelDoc.Extension.GetPersistReference3(RuntimeHelpers.GetObjectValue(objectValue)));
						string stringFromID = GetStringFromID(f_206, modelDoc, RuntimeHelpers.GetObjectValue(objectValue2));
						hashSet.Add(stringFromID);
					}
				}
				if (hashSet.Count > 0)
				{
					f_213.Clear();
					f_213.AppendLine(string.Join("\n", hashSet));
				}
				if (f_213.Length == 0)
				{
					return;
				}
				StringReader stringReader = new StringReader(f_213.ToString());
				while (stringReader.Peek() > -1)
				{
					if (Dostop())
					{
						stringReader.Close();
						return;
					}
					string stringFromID = stringReader.ReadLine();
					Component2 component = (Component2)GetObjectFromString(f_206, modelDoc, stringFromID);
					if (!Information.IsNothing(component))
					{
						list.Add(component);
					}
				}
				stringReader.Close();
				if (list.Count < 1)
				{
					assemblyDoc = null;
					return;
				}
				sendmessageC(1, "Восстановление деталей");
				sendmessageC(0, (list.Count - 1).ToString());
				int num2 = list.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (Dostop())
					{
						return;
					}
					sendmessageC(2, j.ToString());
					if (list[j].GetSuppression() == 1)
					{
						list[j].SetSuppression2(3);
					}
				}
				modelDoc.ClearSelection2(All: true);
				sendmessageC(1, "Получение данных");
				f_214.Clear();
				f_214.AppendLine("PathFileName\u001e\u001c" + modelDoc.GetPathName());
				f_214.AppendLine("ConfigureName\u001e\u001c" + NewLateBinding.LateGet(modelDoc.GetActiveConfiguration(), null, "Name", new object[0], null, null, null).ToString());
				f_214.AppendLine("NLevel\u001e\u001c0");
				f_214.AppendLine("DataFromAsm\u001e\u001c" + true);
				f_214.AppendLine("Quantity\u001e\u001c1");
				Getprp(modelDoc, NewLateBinding.LateGet(modelDoc.GetActiveConfiguration(), null, "Name", new object[0], null, null, null).ToString());
				f_214.AppendLine(">");
				object objectValue3 = RuntimeHelpers.GetObjectValue(assemblyDoc.GetComponents(false));
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				int num3 = list.Count - 1;
				int type = default(int);
				int Errors = default(int);
				int Warnings = default(int);
				for (int k = 0; k <= num3 && !Dostop(); k++)
				{
					sendmessageC(2, k.ToString());
					list2.Add(list[k].GetSelectByIDString());
					string pathName = list[k].GetPathName();
					string referencedConfiguration = list[k].ReferencedConfiguration;
					string name = list[k].Name2;
					int num4 = Strings.Split(name, "/").Length;
					if (list3.Count > 0)
					{
						int num5 = list3.Count - 1;
						for (int num6 = 0; num6 <= num5; num6++)
						{
							if ((!f_209 && string.Equals(list3[num6], pathName, StringComparison.OrdinalIgnoreCase) && string.Equals(list4[num6], referencedConfiguration, StringComparison.OrdinalIgnoreCase)) || (f_209 && string.Equals(list3[num6], pathName, StringComparison.OrdinalIgnoreCase)))
							{
								goto IL_0680;
							}
						}
					}
					list3.Add(pathName);
					list4.Add(referencedConfiguration);
					int num7 = 0;
					int num8 = Information.UBound((Array)objectValue3);
					for (int l = 0; l <= num8; l++)
					{
						Component2 component2 = (Component2)NewLateBinding.LateIndexGet(objectValue3, new object[1] { l }, null);
						if ((!component2.ExcludeFromBOM & (component2.GetSuppression() != 0)) && ((!f_209 && string.Equals(component2.GetPathName(), pathName, StringComparison.OrdinalIgnoreCase) && string.Equals(component2.ReferencedConfiguration, referencedConfiguration, StringComparison.OrdinalIgnoreCase)) || (f_209 && string.Equals(component2.GetPathName(), pathName, StringComparison.OrdinalIgnoreCase))))
						{
							num7++;
						}
					}
					if (pathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
					{
						type = 1;
					}
					else if (pathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						type = 2;
					}
					else if (pathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
					{
						type = 3;
					}
					f_214.AppendLine("PathFileName\u001e\u001c" + pathName);
					f_214.AppendLine("ConfigureName\u001e\u001c" + referencedConfiguration);
					f_214.AppendLine("NLevel\u001e\u001c" + Conversions.ToString(num4));
					f_214.AppendLine("Quantity\u001e\u001c" + Conversions.ToString(num7));
					bool flag = false;
					ModelDoc2 modelDoc2 = (ModelDoc2)f_206.GetOpenDocumentByName(pathName);
					if (Information.IsNothing(modelDoc2))
					{
						flag = true;
						modelDoc2 = f_206.OpenDoc6(pathName, type, 1, referencedConfiguration, ref Errors, ref Warnings);
					}
					Getprp(modelDoc2, referencedConfiguration);
					f_214.AppendLine(">");
					if (!Information.IsNothing(modelDoc2))
					{
						modelDoc2 = null;
						if (flag)
						{
							f_206.CloseDoc(pathName);
						}
					}
					IL_0680:;
				}
				sendmessageC(3, f_214.ToString());
				int num9 = list2.Count - 1;
				for (int m = 0; m <= num9; m++)
				{
					modelDoc.Extension.SelectByID2(list2[m], "COMPONENT", 0.0, 0.0, 0.0, Append: true, 0, null, 0);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				if (!(ex2 is NullReferenceException))
				{
					MessageBox.Show(new WindowWrapper(f_207), ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public void GetDataFromVis()
	{
		ModelDoc2 modelDoc = null;
		AssemblyDoc assemblyDoc = null;
		Component2 component = null;
		SelectionMgr selectionMgr = null;
		Component2[] array = null;
		ModelDoc2 modelDoc2 = null;
		object obj = null;
		Component2 component2 = null;
		modelDoc = (ModelDoc2)f_206.ActiveDoc;
		if (!Information.IsNothing(modelDoc) && modelDoc.GetType() == 2)
		{
			assemblyDoc = (AssemblyDoc)modelDoc;
			modelDoc = null;
		}
		if (Information.IsNothing(assemblyDoc))
		{
			return;
		}
		obj = RuntimeHelpers.GetObjectValue(assemblyDoc.GetComponents(false));
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
		{
			return;
		}
		array = new Component2[1];
		int num = 0;
		checked
		{
			try
			{
				int num2 = Information.UBound((Array)obj);
				int num3 = default(int);
				for (int i = 0; i <= num2; i++)
				{
					Application.DoEvents();
					if (Dostop())
					{
						assemblyDoc = null;
						return;
					}
					component = (Component2)NewLateBinding.LateIndexGet(obj, new object[1] { i }, null);
					if (Information.IsNothing(component))
					{
						continue;
					}
					string referencedConfiguration = component.ReferencedConfiguration;
					bool flag = false;
					modelDoc = (ModelDoc2)component.GetModelDoc2();
					if (!Information.IsNothing(modelDoc))
					{
						if (modelDoc.GetType() == 2)
						{
							Configuration configuration = (Configuration)modelDoc.GetConfigurationByName(referencedConfiguration);
							if (!Information.IsNothing(configuration))
							{
								num3 = Conversions.ToInteger(NewLateBinding.LateGet(configuration, null, "ChildComponentDisplayInBOM", new object[0], null, null, null));
							}
							if (num3 == 3)
							{
								flag = true;
								configuration = null;
								goto IL_0218;
							}
						}
						modelDoc = null;
					}
					string text = component.Name;
					component2 = component.GetParent();
					while (Strings.InStrRev(text, "/") > 1)
					{
						text = Strings.Left(text, Strings.InStrRev(text, "/") - Strings.Len("/"));
						if (Information.IsNothing(component2))
						{
							continue;
						}
						referencedConfiguration = component2.ReferencedConfiguration;
						modelDoc = (ModelDoc2)component2.GetModelDoc2();
						if (!Information.IsNothing(modelDoc))
						{
							if (modelDoc.GetType() == 2)
							{
								Configuration configuration = (Configuration)modelDoc.GetConfigurationByName(referencedConfiguration);
								num3 = Conversions.ToInteger(NewLateBinding.LateGet(configuration, null, "ChildComponentDisplayInBOM", new object[0], null, null, null));
								if (num3 == 1)
								{
									flag = true;
									break;
								}
							}
							modelDoc = null;
						}
						if (component2.Visible == 0)
						{
							flag = true;
							break;
						}
						component2 = component2.GetParent();
					}
					goto IL_0218;
					IL_0218:
					if ((f_210 && f_211 && component.Visible == 1 && !flag && !component.ExcludeFromBOM && component.GetSuppression() != 0 && component.GetSuppression() != 1 && !component.IsVirtual) || (f_210 && !f_211 && component.Visible == 1 && !flag && !component.ExcludeFromBOM && component.GetSuppression() != 0 && !component.IsVirtual) || (!f_210 && f_211 && component.Visible == 1 && !flag && !component.ExcludeFromBOM && component.GetSuppression() != 1 && component.GetSuppression() != 0) || (!f_210 && !f_211 && component.Visible == 1 && !flag && !component.ExcludeFromBOM && component.GetSuppression() != 0))
					{
						array = (Component2[])Utils.CopyArray(array, new Component2[num + 1]);
						array[num] = component;
						num++;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				if (!(ex2 is NullReferenceException))
				{
					MessageBox.Show(new WindowWrapper(f_207), ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				ProjectData.ClearProjectError();
			}
			if (num < 1)
			{
				return;
			}
			sendmessageC(1, "Восстановление деталей");
			sendmessageC(0, num.ToString());
			try
			{
				int num4 = num - 1;
				for (int j = 0; j <= num4; j++)
				{
					Application.DoEvents();
					if (!Dostop())
					{
						sendmessageC(2, (j + 1).ToString());
						if (array[j].GetSuppression() == 1)
						{
							array[j].SetSuppression2(3);
						}
					}
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				sendmessageC(6, ex4.ToString());
				if (!(ex4 is NullReferenceException))
				{
					MessageBox.Show(new WindowWrapper(f_207), ex4.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				ProjectData.ClearProjectError();
			}
			sendmessageC(1, "Получение данных");
			sendmessageC(0, num.ToString());
			try
			{
				f_214.Clear();
				f_214.AppendLine(Conversions.ToString(Operators.ConcatenateObject("PathFileName\u001e\u001c", NewLateBinding.LateGet(assemblyDoc, null, "GetPathName", new object[0], null, null, null))));
				f_214.AppendLine("ConfigureName\u001e\u001c" + NewLateBinding.LateGet(NewLateBinding.LateGet(assemblyDoc, null, "GetActiveConfiguration", new object[0], null, null, null), null, "Name", new object[0], null, null, null).ToString());
				f_214.AppendLine("NLevel\u001e\u001c0");
				f_214.AppendLine("DataFromAsm\u001e\u001c" + true);
				f_214.AppendLine("Quantity\u001e\u001c1");
				Getprp((ModelDoc2)assemblyDoc, NewLateBinding.LateGet(NewLateBinding.LateGet(assemblyDoc, null, "GetActiveConfiguration", new object[0], null, null, null), null, "Name", new object[0], null, null, null).ToString());
				f_214.AppendLine(">");
				string[] array2 = new string[num - 1 + 1];
				string[] array3 = new string[1];
				string[] array4 = new string[1];
				int num5 = num - 1;
				int num7 = default(int);
				int type = default(int);
				int Errors = default(int);
				int Warnings = default(int);
				for (int k = 0; k <= num5; k++)
				{
					Application.DoEvents();
					if (Dostop())
					{
						continue;
					}
					sendmessageC(2, (k + 1).ToString());
					array2[k] = array[k].GetSelectByIDString();
					string pathName = array[k].GetPathName();
					string referencedConfiguration = array[k].ReferencedConfiguration;
					string name = array[k].Name2;
					int num6 = Information.UBound(Strings.Split(name, "/")) + 1;
					int num8 = num7 - 1;
					int num9 = 0;
					while (true)
					{
						if (num9 <= num8)
						{
							if ((!f_209 && string.Equals(array3[num9], pathName, StringComparison.OrdinalIgnoreCase) && string.Equals(array4[num9], referencedConfiguration)) || (f_209 && string.Equals(array3[num9], pathName, StringComparison.OrdinalIgnoreCase)))
							{
								break;
							}
							num9++;
							continue;
						}
						array3 = (string[])Utils.CopyArray(array3, new string[num7 + 1]);
						array4 = (string[])Utils.CopyArray(array4, new string[num7 + 1]);
						array3[num7] = pathName;
						array4[num7] = referencedConfiguration;
						num7++;
						int num10 = 0;
						int num11 = num - 1;
						for (int l = 0; l <= num11; l++)
						{
							if ((!f_209 && string.Equals(array[l].GetPathName(), pathName, StringComparison.OrdinalIgnoreCase) && string.Equals(array[l].ReferencedConfiguration, referencedConfiguration)) || (f_209 && string.Equals(array[l].GetPathName(), pathName, StringComparison.OrdinalIgnoreCase)))
							{
								num10++;
							}
						}
						if (pathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
						{
							type = 1;
						}
						else if (pathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
						{
							type = 2;
						}
						else if (pathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
						{
							type = 3;
						}
						f_214.AppendLine("PathFileName\u001e\u001c" + pathName);
						f_214.AppendLine("ConfigureName\u001e\u001c" + referencedConfiguration);
						f_214.AppendLine("NLevel\u001e\u001c" + Conversions.ToString(num6));
						f_214.AppendLine("Quantity\u001e\u001c" + Conversions.ToString(num10));
						bool flag2 = false;
						modelDoc2 = (ModelDoc2)f_206.GetOpenDocumentByName(pathName);
						if (Information.IsNothing(modelDoc2))
						{
							flag2 = true;
							modelDoc2 = f_206.OpenDoc6(pathName, type, 1, referencedConfiguration, ref Errors, ref Warnings);
						}
						Getprp(modelDoc2, referencedConfiguration);
						f_214.AppendLine(">");
						if (!Information.IsNothing(modelDoc2))
						{
							modelDoc2 = null;
							if (flag2)
							{
								f_206.CloseDoc(pathName);
							}
						}
						break;
					}
				}
				sendmessageC(3, f_214.ToString());
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				sendmessageC(6, ex6.ToString());
				if (!(ex6 is NullReferenceException))
				{
					MessageBox.Show(new WindowWrapper(f_207), ex6.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				ProjectData.ClearProjectError();
			}
			selectionMgr = null;
			assemblyDoc = null;
		}
	}

	public void GetFromFile(string str)
	{
		if (Strings.Len(str) <= 0)
		{
			return;
		}
		ModelDoc2 modelDoc = null;
		f_217.Clear();
		f_218.Clear();
		f_219.Clear();
		f_220.Clear();
		f_214.Clear();
		int num = 0;
		StringReader stringReader = new StringReader(str);
		f_206.DocumentVisible(Visible: false, 1);
		f_206.DocumentVisible(Visible: false, 2);
		int Errors = default(int);
		int Warnings = default(int);
		while (stringReader.Peek() > -1)
		{
			Application.DoEvents();
			if (Dostop())
			{
				break;
			}
			num = checked(num + 1);
			try
			{
				sendmessageC(2, num.ToString());
				string text = stringReader.ReadLine().Trim();
				int type;
				if (File.Exists(text))
				{
					if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
					{
						type = 1;
						goto IL_00d9;
					}
					if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						type = 2;
						goto IL_00d9;
					}
				}
				goto end_IL_0082;
				IL_00d9:
				modelDoc = (ModelDoc2)f_206.GetOpenDocumentByName(text);
				if (Information.IsNothing(modelDoc))
				{
					modelDoc = f_206.OpenDoc6(text, type, 1, "", ref Errors, ref Warnings);
				}
				if (!Information.IsNothing(modelDoc))
				{
					string text2 = NewLateBinding.LateGet(modelDoc.GetActiveConfiguration(), null, "Name", new object[0], null, null, null).ToString();
					f_214.AppendLine("PathFileName\u001e\u001c" + text);
					f_214.AppendLine("ConfigureName\u001e\u001c" + text2);
					f_214.AppendLine("NLevel\u001e\u001c0");
					f_214.AppendLine("Quantity\u001e\u001c1");
					Getprp(modelDoc, text2);
					f_214.AppendLine(">");
					modelDoc = null;
				}
				end_IL_0082:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
		f_206.DocumentVisible(Visible: true, 1);
		f_206.DocumentVisible(Visible: true, 2);
		sendmessageC(3, f_214.ToString());
	}

	public void Getprp(ModelDoc2 swModel, string CfgName)
	{
		string text = "";
		bool flag = false;
		string text2 = "";
		string text3 = "";
		string Database = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		string text7 = "";
		string text8 = "";
		string text9 = "";
		string text10 = "";
		checked
		{
			try
			{
				if (Information.IsNothing(swModel))
				{
					return;
				}
				swModel.ShowConfiguration2(CfgName);
				ModelDocExtension extension = swModel.Extension;
				try
				{
					double[] array = (double[])swModel.GetMassProperties();
					if (!Information.IsNothing(array))
					{
						text2 = Strings.FormatNumber(array[5], f_250, TriState.True);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
				f_214.AppendLine("weight\u001e\u001c" + text2);
				int bendState = default(int);
				int num = default(int);
				try
				{
					double[] array2 = null;
					if (swModel.GetType() == 1)
					{
						bendState = swModel.GetBendState();
						PartDoc partDoc = (PartDoc)swModel;
						if (!Information.IsNothing(partDoc))
						{
							flag = partDoc.IsWeldment();
							array2 = (double[])partDoc.GetPartBox(NoConversion: true);
							text3 = partDoc.GetMaterialPropertyName2(CfgName, out Database);
							object objectValue = RuntimeHelpers.GetObjectValue(swModel.MaterialPropertyValues);
							if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && Information.UBound((Array)objectValue) == 8)
							{
								num = Information.RGB(Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateIndexGet(objectValue, new object[1] { 0 }, null), 255)), Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateIndexGet(objectValue, new object[1] { 1 }, null), 255)), Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateIndexGet(objectValue, new object[1] { 2 }, null), 255)));
							}
							object objectValue2 = RuntimeHelpers.GetObjectValue(extension.GetRenderMaterials());
							if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue2)))
							{
								int num2 = Information.UBound((Array)objectValue2);
								for (int i = 0; i <= num2; i++)
								{
									RenderMaterial renderMaterial = (RenderMaterial)NewLateBinding.LateIndexGet(objectValue2, new object[1] { i }, null);
									if (renderMaterial.ColorForm == 2)
									{
										num = renderMaterial.PrimaryColor;
										break;
									}
								}
							}
						}
					}
					else if (swModel.GetType() == 2)
					{
						AssemblyDoc assemblyDoc = (AssemblyDoc)swModel;
						if (!Information.IsNothing(assemblyDoc))
						{
							array2 = (double[])assemblyDoc.GetBox(1);
						}
					}
					if (!Information.IsNothing(array2))
					{
						object str = Math.Abs(array2[3] - array2[0]) * 1000.0;
						string text11 = formatstr(ref str);
						str = Math.Abs(array2[4] - array2[1]) * 1000.0;
						string text12 = formatstr(ref str);
						str = Math.Abs(array2[5] - array2[2]) * 1000.0;
						string text13 = formatstr(ref str);
						if ((Operators.CompareString(text11, "", TextCompare: false) != 0) & (Operators.CompareString(text12, "", TextCompare: false) != 0) & (Operators.CompareString(text13, "", TextCompare: false) != 0))
						{
							text = text11 + "×" + text12 + "×" + text13;
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ProjectData.ClearProjectError();
				}
				f_214.AppendLine("isbendstate\u001e\u001c" + Conversions.ToString(bendState));
				f_214.AppendLine("isweldment\u001e\u001c" + Conversions.ToString(flag));
				f_214.AppendLine("Boundarysize\u001e\u001c" + text);
				f_214.AppendLine("material\u001e\u001c" + text3 + "\u001e\u001c" + Conversions.ToString(num));
				Configuration config = (Configuration)swModel.GetConfigurationByName(CfgName);
				f_214.AppendLine("BOMPartNumber\u001e\u001c" + BOMPartNumber(config, swModel));
				try
				{
					text4 = ((IModelDoc2)swModel).get_SummaryInfo(6);
					text5 = ((IModelDoc2)swModel).get_SummaryInfo(7);
					text6 = ((IModelDoc2)swModel).get_SummaryInfo(2);
					text7 = Type_16.m_64(((IModelDoc2)swModel).get_SummaryInfo(4));
					text8 = ((IModelDoc2)swModel).get_SummaryInfo(3);
					text9 = ((IModelDoc2)swModel).get_SummaryInfo(1);
					text10 = ((IModelDoc2)swModel).get_SummaryInfo(0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ProjectData.ClearProjectError();
				}
				f_214.AppendLine("CreationTime\u001e\u001c" + text4);
				f_214.AppendLine("SaveTime\u001e\u001c" + text5);
				f_214.AppendLine("Author\u001e\u001c" + text6);
				f_214.AppendLine("Comment\u001e\u001c" + text7);
				f_214.AppendLine("Keywords\u001e\u001c" + text8);
				f_214.AppendLine("Subject\u001e\u001c" + text9);
				f_214.AppendLine("Title\u001e\u001c" + text10);
				try
				{
					if (f_221.Count <= 0)
					{
						return;
					}
					CustomPropertyManager customPropertyManager = ((IModelDocExtension)extension).get_CustomPropertyManager(CfgName);
					string[] array3 = (string[])customPropertyManager.GetNames();
					int num3 = f_221.Count - 1;
					for (int i = 0; i <= num3; i++)
					{
						if (Strings.Len(f_221[i]) != 0)
						{
							string text14 = Conversions.ToString(Interaction.IIf(Type_16.m_72(array3, f_221[i], StringComparison.OrdinalIgnoreCase), CfgName, ""));
							customPropertyManager = ((IModelDocExtension)extension).get_CustomPropertyManager(text14);
							string ValOut = "";
							string ResolvedValOut = "";
							bool flag2 = customPropertyManager.Get4(f_221[i], UseCached: false, out ValOut, out ResolvedValOut);
							ValOut = Type_16.m_64(ValOut);
							ResolvedValOut = Type_16.m_64(ResolvedValOut);
							f_214.AppendLine(Conversions.ToString(Operators.ConcatenateObject(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat("PropName\u001e\u001c" + f_221[i], "\u001e"), "\u001c"), ValOut), "\u001e"), "\u001c"), ResolvedValOut), "\u001e"), "\u001c"), Interaction.IIf(Operators.CompareString(text14, "", TextCompare: false) == 0, 0, 1))));
						}
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				ProjectData.ClearProjectError();
			}
		}
	}

	public List<string> Getnode(string filepath, string title)
	{
		List<string> list = new List<string>();
		try
		{
			object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("MSXML2.DOMDocument"));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				object[] array = new object[1] { filepath };
				object[] arguments = array;
				bool[] array2 = new bool[1] { true };
				object value = NewLateBinding.LateGet(objectValue, null, "Load", arguments, null, null, array2);
				if (array2[0])
				{
					filepath = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				if (Conversions.ToBoolean(value))
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "DocumentElement", new object[0], null, null, null));
					object CounterResult = default(object);
					object LoopForResult = default(object);
					foreach (object item in (IEnumerable)NewLateBinding.LateGet(objectValue2, null, "ChildNodes", new object[0], null, null, null))
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(item);
						if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue3, null, "BaseName", new object[0], null, null, null), title, TextCompare: false))
						{
							continue;
						}
						if (!ObjectFlowControl.ForLoopControl.ForLoopInitObj(CounterResult, 0, Operators.SubtractObject(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, null, "ChildNodes", new object[0], null, null, null), null, "length", new object[0], null, null, null), 1), 1, ref LoopForResult, ref CounterResult))
						{
							break;
						}
						do
						{
							object[] array3 = new object[1] { RuntimeHelpers.GetObjectValue(CounterResult) };
							object[] arguments2 = array3;
							array2 = new bool[1] { true };
							object instance = NewLateBinding.LateGet(objectValue3, null, "ChildNodes", arguments2, null, null, array2);
							if (array2[0])
							{
								CounterResult = RuntimeHelpers.GetObjectValue(array3[0]);
							}
							list.Add(Conversions.ToString(NewLateBinding.LateGet(instance, null, "Text", new object[0], null, null, null)));
						}
						while (ObjectFlowControl.ForLoopControl.ForNextCheckObj(CounterResult, LoopForResult, ref CounterResult));
						break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return list;
	}

	public string formatstr(ref object str)
	{
		string result;
		try
		{
			str = Strings.Format(RuntimeHelpers.GetObjectValue(str), "0.#");
			if (Operators.CompareString(Strings.Right(Conversions.ToString(str), 1), ".", TextCompare: false) == 0)
			{
				str = Strings.Left(Conversions.ToString(str), checked(Strings.Len(RuntimeHelpers.GetObjectValue(str)) - 1));
			}
			result = Conversions.ToString(str);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = Conversions.ToString(str);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string GetStringFromID(SldWorks swApp, ModelDoc2 swModel, object vPIDarr)
	{
		string text = "";
		foreach (object item in (IEnumerable)vPIDarr)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			text += Strings.Format(RuntimeHelpers.GetObjectValue(objectValue), "###000");
		}
		return text;
	}

	public object GetObjectFromString(object swApp, ModelDoc2 swModel, string IDstring)
	{
		checked
		{
			byte[] array = new byte[(int)Math.Round((double)Strings.Len(IDstring) / 3.0 - 1.0) + 1];
			object obj = null;
			int ErrorCode = 0;
			int num = 0;
			ModelDocExtension extension = swModel.Extension;
			int num2 = Strings.Len(IDstring) - 3;
			for (num = 0; num <= num2; num += 3)
			{
				array[(int)Math.Round((double)num / 3.0)] = Conversions.ToByte(Strings.Mid(IDstring, num + 1, 3));
			}
			obj = array;
			return RuntimeHelpers.GetObjectValue(extension.GetObjectByPersistReference3(RuntimeHelpers.GetObjectValue(obj), out ErrorCode));
		}
	}

	public object getvisiblelist(ModelDoc2 swModel)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(((AssemblyDoc)swModel).GetVisibleComponentsInView());
		object objectValue2 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Scripting.Dictionary"));
		NewLateBinding.LateSet(objectValue2, null, "CompareMode", new object[1] { CompareMethod.Text }, null, null);
		foreach (object item in (IEnumerable)objectValue)
		{
			object objectValue3 = RuntimeHelpers.GetObjectValue(item);
			Component2 component = (Component2)objectValue3;
			object objectValue4 = RuntimeHelpers.GetObjectValue(swModel.Extension.GetPersistReference3(component));
			string stringFromID = GetStringFromID(f_206, swModel, RuntimeHelpers.GetObjectValue(objectValue4));
			NewLateBinding.LateIndexSet(objectValue2, new object[2] { stringFromID, "" }, null);
			for (component = component.GetParent(); component != null; component = component.GetParent())
			{
				objectValue4 = RuntimeHelpers.GetObjectValue(swModel.Extension.GetPersistReference3(component));
				stringFromID = GetStringFromID(f_206, swModel, RuntimeHelpers.GetObjectValue(objectValue4));
				NewLateBinding.LateIndexSet(objectValue2, new object[2] { stringFromID, "" }, null);
			}
		}
		return RuntimeHelpers.GetObjectValue(objectValue2);
	}

	public void SaveData(string str)
	{
		if (Strings.Len(str) <= 0)
		{
			return;
		}
		string text = "";
		string text2 = "";
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		string retval = "";
		string retval2 = "";
		string retval3 = "";
		string retval4 = "";
		string retval5 = "";
		string text3 = "";
		string text4 = "";
		string s = "";
		string text5 = "";
		object obj = null;
		object obj2 = null;
		object obj3 = null;
		object obj4 = null;
		object obj5 = null;
		string text6 = "";
		string text7 = "";
		ModelDoc2 modelDoc = null;
		ModelDocExtension modelDocExtension = null;
		CustomPropertyManager customPropertyManager = null;
		int num = 0;
		List<string> list5 = new List<string>();
		List<string> list6 = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		addmaterialtosw();
		f_206.DocumentVisible(Visible: false, 1);
		f_206.DocumentVisible(Visible: false, 2);
		StringReader stringReader = new StringReader(str);
		checked
		{
			int num2 = default(int);
			bool flag = default(bool);
			bool flag2 = default(bool);
			bool flag4 = default(bool);
			int num4 = default(int);
			int Errors = default(int);
			int Warnings = default(int);
			int Errors2 = default(int);
			int Warnings2 = default(int);
			while (stringReader.Peek() > -1)
			{
				Application.DoEvents();
				if (Dostop())
				{
					break;
				}
				try
				{
					string text8 = stringReader.ReadLine();
					if (Strings.Len(text8.Trim()) <= 0)
					{
						continue;
					}
					string[] array = Strings.Split(text8, "\u001e\u001c");
					if (Operators.CompareString(array[0], "PropName", TextCompare: false) == 0)
					{
						list.Add(array[1]);
						list2.Add(array[2]);
						list3.Add(Type_16.m_65(array[3]));
						list4.Add(array[4]);
					}
					else if (Operators.CompareString(array[0], "Author", TextCompare: false) == 0)
					{
						retval = array[1];
					}
					else if (Operators.CompareString(array[0], "Comment", TextCompare: false) == 0)
					{
						retval2 = Type_16.m_65(array[1]);
					}
					else if (Operators.CompareString(array[0], "Keywords", TextCompare: false) == 0)
					{
						retval3 = array[1];
					}
					else if (Operators.CompareString(array[0], "Subject", TextCompare: false) == 0)
					{
						retval4 = array[1];
					}
					else if (Operators.CompareString(array[0], "Title", TextCompare: false) == 0)
					{
						retval5 = array[1];
					}
					else if (Operators.CompareString(array[0], "CfgName", TextCompare: false) == 0)
					{
						text3 = array[1];
					}
					else if (Operators.CompareString(array[0], "NewMaterial", TextCompare: false) == 0)
					{
						text4 = array[1];
					}
					else if (Operators.CompareString(array[0], "ModelColor", TextCompare: false) == 0)
					{
						s = array[1];
					}
					else if (Operators.CompareString(array[0], "RowNumber", TextCompare: false) == 0)
					{
						num2 = Conversions.ToInteger(array[1]);
					}
					else if (Operators.CompareString(array[0], "End", TextCompare: false) == 0)
					{
						flag = Type_16.m_58(array[1]);
					}
					else if (Operators.CompareString(array[0], "IsChanged", TextCompare: false) == 0)
					{
						flag2 = Type_16.m_58(array[1]);
					}
					else if (Operators.CompareString(array[0], "NewPathName", TextCompare: false) == 0)
					{
						text2 = array[1];
					}
					else
					{
						if (Operators.CompareString(array[0], "OldPathName", TextCompare: false) != 0 || (!flag2 && flag && !f_232))
						{
							continue;
						}
						try
						{
							bool flag3 = false;
							stringBuilder.Clear();
							flag4 = false;
							text = array[1];
							if (list5.Count >= 1)
							{
								int num3 = list5.Count - 1;
								for (int i = 0; i <= num3; i++)
								{
									if (string.Equals(list5[i], text, StringComparison.OrdinalIgnoreCase) & string.Equals(list6[i], text2, StringComparison.OrdinalIgnoreCase))
									{
										text = text2;
										break;
									}
								}
							}
							if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
							{
								num4 = 1;
							}
							else if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
							{
								num4 = 2;
							}
							else if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
							{
								num4 = 3;
							}
							if (File.Exists(text))
							{
								modelDoc = (ModelDoc2)f_206.GetOpenDocumentByName(text);
								if (Information.IsNothing(modelDoc))
								{
									flag3 = true;
									modelDoc = f_206.OpenDoc6(text, num4, 1, text3, ref Errors, ref Warnings);
								}
							}
							if (!Information.IsNothing(modelDoc))
							{
								modelDocExtension = modelDoc.Extension;
								unchecked
								{
									if (num4 == 1 && Operators.CompareString(text3, "", TextCompare: false) != 0)
									{
										ModelDoc2 instance = modelDoc;
										object[] array2 = new object[2] { text3, text7 };
										object[] arguments = array2;
										bool[] array3 = new bool[2] { true, true };
										object obj6 = NewLateBinding.LateGet(instance, null, "GetMaterialPropertyName2", arguments, null, null, array3);
										if (array3[0])
										{
											text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
										}
										if (array3[1])
										{
											text7 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										}
										string a = Conversions.ToString(obj6);
										if (!string.Equals(a, text4, StringComparison.OrdinalIgnoreCase))
										{
											((PartDoc)modelDoc).SetMaterialPropertyName2(text3, f_239, text4);
										}
										modelDoc.ShowConfiguration2(text3);
										object objectValue = RuntimeHelpers.GetObjectValue(modelDoc.MaterialPropertyValues);
										int result = 0;
										if (int.TryParse(s, out result))
										{
											NewLateBinding.LateIndexSet(objectValue, new object[2]
											{
												0,
												(double)(int)ColorTranslator.FromWin32(result).R / 255.0
											}, null);
											NewLateBinding.LateIndexSet(objectValue, new object[2]
											{
												1,
												(double)(int)ColorTranslator.FromWin32(result).G / 255.0
											}, null);
											NewLateBinding.LateIndexSet(objectValue, new object[2]
											{
												2,
												(double)(int)ColorTranslator.FromWin32(result).B / 255.0
											}, null);
											modelDoc.MaterialPropertyValues = RuntimeHelpers.GetObjectValue(objectValue);
										}
									}
									((IModelDoc2)modelDoc).set_SummaryInfo(2, retval);
									((IModelDoc2)modelDoc).set_SummaryInfo(4, retval2);
									((IModelDoc2)modelDoc).set_SummaryInfo(3, retval3);
									((IModelDoc2)modelDoc).set_SummaryInfo(1, retval4);
									((IModelDoc2)modelDoc).set_SummaryInfo(0, retval5);
									if (f_231)
									{
										Modifyunit(modelDocExtension);
									}
								}
								if (f_227)
								{
									if (f_228 == 0)
									{
										obj5 = RuntimeHelpers.GetObjectValue(modelDoc.GetConfigurationNames());
										obj5 = (object[])Utils.CopyArray((Array)obj5, new object[Information.UBound((Array)obj5) + 1 + 1]);
										NewLateBinding.LateIndexSet(obj5, new object[2]
										{
											Information.UBound((Array)obj5),
											""
										}, null);
									}
									else if (f_228 == 1)
									{
										obj5 = new object[1];
										NewLateBinding.LateIndexSet(obj5, new object[2] { 0, "" }, null);
									}
								}
								int num5 = list.Count - 1;
								for (int j = 0; j <= num5; j++)
								{
									if (Strings.Len(list[j].Trim()) == 0)
									{
										continue;
									}
									if (f_225 == 0)
									{
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(text3);
										obj2 = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										text5 = "";
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj2)))
										{
											foreach (object item in (IEnumerable)obj2)
											{
												obj3 = RuntimeHelpers.GetObjectValue(item);
												if (string.Equals(list[j], obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													text5 = text3;
													break;
												}
											}
										}
									}
									else if (f_225 == 1)
									{
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager("");
										obj = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(text3);
										obj2 = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										bool flag5 = false;
										bool flag6 = false;
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
										{
											foreach (object item2 in (IEnumerable)obj)
											{
												obj3 = RuntimeHelpers.GetObjectValue(item2);
												if (string.Equals(list[j], obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													flag5 = true;
													break;
												}
											}
										}
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj2)))
										{
											foreach (object item3 in (IEnumerable)obj2)
											{
												obj3 = RuntimeHelpers.GetObjectValue(item3);
												if (string.Equals(list[j], obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													flag6 = true;
													break;
												}
											}
										}
										text5 = ((!unchecked(flag5 && !flag6)) ? text3 : "");
									}
									else if (f_225 == 2)
									{
										text5 = "";
									}
									else if (f_225 == 3)
									{
										text5 = text3;
									}
									customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(text5);
									if (!f_226)
									{
										if (Strings.Len(list3[j]) == 0)
										{
											customPropertyManager.Delete(list[j]);
										}
										else if (Type_19.m_78(customPropertyManager, list[j], list2[j], list3[j]) != 0)
										{
											stringBuilder.AppendLine("\"" + list[j] + "\" Ошибка изменения");
										}
									}
									else if (((Strings.Len(list3[j]) != 0) ? Type_19.m_78(customPropertyManager, list[j], list2[j], list3[j]) : Type_19.m_78(customPropertyManager, list[j], Conversions.ToString(30), list3[j])) != 0)
									{
										stringBuilder.AppendLine("\"" + list[j] + "\" Ошибка изменения");
									}
									if (!f_227)
									{
										continue;
									}
									foreach (object item4 in (IEnumerable)obj5)
									{
										object objectValue2 = RuntimeHelpers.GetObjectValue(item4);
										if (!string.Equals(text5, objectValue2.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(objectValue2.ToString());
											int num6 = customPropertyManager.Delete(list[j]);
										}
									}
								}
								if (f_229)
								{
									obj5 = RuntimeHelpers.GetObjectValue(modelDoc.GetConfigurationNames());
									if (f_230 == 0)
									{
										obj5 = (object[])Utils.CopyArray((Array)obj5, new object[Information.UBound((Array)obj5) + 1 + 1]);
										NewLateBinding.LateIndexSet(obj5, new object[2]
										{
											Information.UBound((Array)obj5),
											""
										}, null);
									}
									else if (f_230 != 1)
									{
										if (f_230 == 2)
										{
											obj5 = new object[1];
											NewLateBinding.LateIndexSet(obj5, new object[2] { 0, text3 }, null);
										}
										else if (f_230 == 3)
										{
											obj5 = new object[1];
											NewLateBinding.LateIndexSet(obj5, new object[2] { 0, "" }, null);
										}
									}
									foreach (object item5 in (IEnumerable)obj5)
									{
										object objectValue3 = RuntimeHelpers.GetObjectValue(item5);
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(objectValue3.ToString());
										obj4 = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj4)))
										{
											continue;
										}
										foreach (object item6 in (IEnumerable)obj4)
										{
											obj3 = RuntimeHelpers.GetObjectValue(item6);
											bool flag7 = false;
											int num7 = list.Count - 1;
											for (int k = 0; k <= num7; k++)
											{
												if (list[k].Equals(obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													flag7 = true;
													break;
												}
											}
											if (!flag7)
											{
												int num6 = customPropertyManager.Delete(obj3.ToString());
											}
										}
									}
								}
								if (!string.Equals(text2, text, StringComparison.OrdinalIgnoreCase))
								{
									string lErrors = "";
									flag4 = ReName(modelDoc, text2, text, ref lErrors);
									if (!flag4)
									{
										stringBuilder.AppendLine(lErrors);
									}
								}
								if (!flag4)
								{
									modelDoc.SetSaveFlag();
									if (f_232)
									{
										string text9 = "";
										if (Conversions.ToDouble(f_206.RevisionNumber().Substring(0, 2)) >= 23.0)
										{
											Configuration instance2 = (Configuration)modelDoc.GetActiveConfiguration();
											object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance2, null, "GetScene", new object[0], null, null, null));
											if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
											{
												object[] array4 = new object[1] { text9 };
												object[] arguments2 = array4;
												bool[] array3 = new bool[1] { true };
												NewLateBinding.LateCall(objectValue4, null, "GetP2SFileName", arguments2, null, null, array3, IgnoreReturn: true);
												if (array3[0])
												{
													text9 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
												}
											}
										}
										modelDocExtension.InsertScene("\\scenes\\01 basic scenes\\11 white kitchen.p2s");
										modelDocExtension.InsertScene("\\scenes\\01 basic scenes\\00 3 point faded.p2s");
										modelDocExtension.InsertScene(text9);
										if (!modelDoc.Save3(5, ref Errors2, ref Warnings2))
										{
											stringBuilder.AppendLine("Ошибка сохранения:0x" + Errors2.ToString("x2"));
										}
									}
								}
								if (flag)
								{
									if (!flag4)
									{
										f_206.ActivateDoc(text);
										text6 = text;
									}
									else
									{
										f_206.ActivateDoc(text2);
										text6 = text2;
									}
								}
								if (flag3 && f_208 != 4)
								{
									if (modelDoc.GetSaveFlag())
									{
										modelDoc.Save3(5, ref Errors2, ref Warnings2);
									}
									f_206.CloseDoc(text2);
								}
								if (flag4)
								{
									list6.Add(text2);
									list5.Add(text);
								}
								list.Clear();
								list2.Clear();
								list3.Clear();
								list4.Clear();
								customPropertyManager = null;
								modelDocExtension = null;
								modelDoc = null;
							}
							else
							{
								stringBuilder.AppendLine("Недопустимый документ или ошибка открытия:0x" + Errors.ToString("x2"));
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							stringBuilder.AppendLine(ex2.Message);
							ProjectData.ClearProjectError();
						}
						num++;
						sendmessageC(2, num.ToString());
						string value = stringBuilder.ToString();
						stringBuilder.Clear();
						stringBuilder.AppendLine(flag4.ToString());
						stringBuilder.AppendLine(text);
						stringBuilder.AppendLine(text2);
						stringBuilder.AppendLine(Conversions.ToString(num2));
						stringBuilder.AppendLine(value);
						sendmessageC(5, stringBuilder.ToString());
						continue;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					sendmessageC(6, ex4.ToString());
					ProjectData.ClearProjectError();
				}
			}
			f_206.DocumentVisible(Visible: true, 1);
			f_206.DocumentVisible(Visible: true, 2);
			Updatereference3(text6, list6, list5);
			object objectValue5 = RuntimeHelpers.GetObjectValue(f_206.GetOpenDocumentByName(text6));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue5)) && list6.Count > 0)
			{
				NewLateBinding.LateCall(objectValue5, null, "ForceRebuild3", new object[1] { true }, null, null, null, IgnoreReturn: true);
			}
		}
	}

	public void SaveData2(string str)
	{
		if (Strings.Len(str) <= 0)
		{
			return;
		}
		string text = "";
		string text2 = "";
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		string retval = "";
		string retval2 = "";
		string retval3 = "";
		string retval4 = "";
		string retval5 = "";
		string text3 = "";
		string text4 = "";
		string s = "";
		string text5 = "";
		object obj = null;
		object obj2 = null;
		object obj3 = null;
		object obj4 = null;
		object obj5 = null;
		string text6 = "";
		string text7 = "";
		ModelDoc2 modelDoc = null;
		ModelDocExtension modelDocExtension = null;
		CustomPropertyManager customPropertyManager = null;
		int num = 0;
		List<string> list5 = new List<string>();
		List<string> list6 = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		addmaterialtosw();
		f_206.DocumentVisible(Visible: false, 1);
		f_206.DocumentVisible(Visible: false, 2);
		StringReader stringReader = new StringReader(str);
		checked
		{
			int num2 = default(int);
			bool flag = default(bool);
			bool flag2 = default(bool);
			bool flag4 = default(bool);
			int num4 = default(int);
			int Errors = default(int);
			int Warnings = default(int);
			int Errors2 = default(int);
			int Warnings2 = default(int);
			while (stringReader.Peek() > -1)
			{
				Application.DoEvents();
				if (Dostop())
				{
					break;
				}
				try
				{
					string text8 = stringReader.ReadLine();
					if (Strings.Len(text8.Trim()) <= 0)
					{
						continue;
					}
					string[] array = Strings.Split(text8, "\u001e\u001c");
					if (Operators.CompareString(array[0], "PropName", TextCompare: false) == 0)
					{
						list.Add(array[1]);
						list2.Add(array[2]);
						list3.Add(Type_16.m_65(array[3]));
						list4.Add(array[4]);
					}
					else if (Operators.CompareString(array[0], "Author", TextCompare: false) == 0)
					{
						retval = array[1];
					}
					else if (Operators.CompareString(array[0], "Comment", TextCompare: false) == 0)
					{
						retval2 = Type_16.m_65(array[1]);
					}
					else if (Operators.CompareString(array[0], "Keywords", TextCompare: false) == 0)
					{
						retval3 = array[1];
					}
					else if (Operators.CompareString(array[0], "Subject", TextCompare: false) == 0)
					{
						retval4 = array[1];
					}
					else if (Operators.CompareString(array[0], "Title", TextCompare: false) == 0)
					{
						retval5 = array[1];
					}
					else if (Operators.CompareString(array[0], "CfgName", TextCompare: false) == 0)
					{
						text3 = array[1];
					}
					else if (Operators.CompareString(array[0], "NewMaterial", TextCompare: false) == 0)
					{
						text4 = array[1];
					}
					else if (Operators.CompareString(array[0], "ModelColor", TextCompare: false) == 0)
					{
						s = array[1];
					}
					else if (Operators.CompareString(array[0], "RowNumber", TextCompare: false) == 0)
					{
						num2 = Conversions.ToInteger(array[1]);
					}
					else if (Operators.CompareString(array[0], "End", TextCompare: false) == 0)
					{
						flag = Type_16.m_58(array[1]);
					}
					else if (Operators.CompareString(array[0], "IsChanged", TextCompare: false) == 0)
					{
						flag2 = Type_16.m_58(array[1]);
					}
					else if (Operators.CompareString(array[0], "NewPathName", TextCompare: false) == 0)
					{
						text2 = array[1];
					}
					else
					{
						if (Operators.CompareString(array[0], "OldPathName", TextCompare: false) != 0 || (!flag2 && flag && !f_232))
						{
							continue;
						}
						try
						{
							bool flag3 = false;
							stringBuilder.Clear();
							flag4 = false;
							text = array[1];
							if (list5.Count >= 1)
							{
								int num3 = list5.Count - 1;
								for (int i = 0; i <= num3; i++)
								{
									if (string.Equals(list5[i], text, StringComparison.OrdinalIgnoreCase) & string.Equals(list6[i], text2, StringComparison.OrdinalIgnoreCase))
									{
										text = text2;
										break;
									}
								}
							}
							if (text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
							{
								num4 = 1;
							}
							else if (text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
							{
								num4 = 2;
							}
							else if (text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
							{
								num4 = 3;
							}
							if (File.Exists(text))
							{
								modelDoc = (ModelDoc2)f_206.GetOpenDocumentByName(text);
								if (Information.IsNothing(modelDoc))
								{
									flag3 = true;
									modelDoc = f_206.OpenDoc6(text, num4, 1, text3, ref Errors, ref Warnings);
								}
							}
							if (!Information.IsNothing(modelDoc))
							{
								modelDocExtension = modelDoc.Extension;
								unchecked
								{
									if (num4 == 1 && Operators.CompareString(text3, "", TextCompare: false) != 0)
									{
										ModelDoc2 instance = modelDoc;
										object[] array2 = new object[2] { text3, text7 };
										object[] arguments = array2;
										bool[] array3 = new bool[2] { true, true };
										object obj6 = NewLateBinding.LateGet(instance, null, "GetMaterialPropertyName2", arguments, null, null, array3);
										if (array3[0])
										{
											text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
										}
										if (array3[1])
										{
											text7 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										}
										string a = Conversions.ToString(obj6);
										if (!string.Equals(a, text4, StringComparison.OrdinalIgnoreCase))
										{
											((PartDoc)modelDoc).SetMaterialPropertyName2(text3, f_239, text4);
										}
										modelDoc.ShowConfiguration2(text3);
										object objectValue = RuntimeHelpers.GetObjectValue(modelDoc.MaterialPropertyValues);
										int result = 0;
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)) && int.TryParse(s, out result))
										{
											NewLateBinding.LateIndexSet(objectValue, new object[2]
											{
												0,
												(double)(int)ColorTranslator.FromWin32(result).R / 255.0
											}, null);
											NewLateBinding.LateIndexSet(objectValue, new object[2]
											{
												1,
												(double)(int)ColorTranslator.FromWin32(result).G / 255.0
											}, null);
											NewLateBinding.LateIndexSet(objectValue, new object[2]
											{
												2,
												(double)(int)ColorTranslator.FromWin32(result).B / 255.0
											}, null);
											modelDoc.MaterialPropertyValues = RuntimeHelpers.GetObjectValue(objectValue);
										}
									}
									((IModelDoc2)modelDoc).set_SummaryInfo(2, retval);
									((IModelDoc2)modelDoc).set_SummaryInfo(4, retval2);
									((IModelDoc2)modelDoc).set_SummaryInfo(3, retval3);
									((IModelDoc2)modelDoc).set_SummaryInfo(1, retval4);
									((IModelDoc2)modelDoc).set_SummaryInfo(0, retval5);
									if (f_231)
									{
										Modifyunit(modelDocExtension);
									}
								}
								if (f_227)
								{
									if (f_228 == 0)
									{
										obj5 = RuntimeHelpers.GetObjectValue(modelDoc.GetConfigurationNames());
										obj5 = (object[])Utils.CopyArray((Array)obj5, new object[Information.UBound((Array)obj5) + 1 + 1]);
										NewLateBinding.LateIndexSet(obj5, new object[2]
										{
											Information.UBound((Array)obj5),
											""
										}, null);
									}
									else if (f_228 == 1)
									{
										obj5 = new object[1];
										NewLateBinding.LateIndexSet(obj5, new object[2] { 0, "" }, null);
									}
								}
								int num5 = list.Count - 1;
								for (int j = 0; j <= num5; j++)
								{
									if (Strings.Len(list[j].Trim()) == 0)
									{
										continue;
									}
									if (f_225 == 0)
									{
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(text3);
										obj2 = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										text5 = "";
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj2)))
										{
											foreach (object item in (IEnumerable)obj2)
											{
												obj3 = RuntimeHelpers.GetObjectValue(item);
												if (string.Equals(list[j], obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													text5 = text3;
													break;
												}
											}
										}
									}
									else if (f_225 == 1)
									{
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager("");
										obj = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(text3);
										obj2 = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										bool flag5 = false;
										bool flag6 = false;
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
										{
											foreach (object item2 in (IEnumerable)obj)
											{
												obj3 = RuntimeHelpers.GetObjectValue(item2);
												if (string.Equals(list[j], obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													flag5 = true;
													break;
												}
											}
										}
										if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj2)))
										{
											foreach (object item3 in (IEnumerable)obj2)
											{
												obj3 = RuntimeHelpers.GetObjectValue(item3);
												if (string.Equals(list[j], obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													flag6 = true;
													break;
												}
											}
										}
										text5 = ((!unchecked(flag5 && !flag6)) ? text3 : "");
									}
									else if (f_225 == 2)
									{
										text5 = "";
									}
									else if (f_225 == 3)
									{
										text5 = text3;
									}
									customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(text5);
									if (!f_226)
									{
										if (Strings.Len(list3[j]) == 0)
										{
											customPropertyManager.Delete(list[j]);
										}
										else
										{
											CustomPropertyManager instance2 = customPropertyManager;
											object[] array2 = new object[4];
											object[] array4 = array2;
											List<string> list7 = list;
											List<string> list8 = list7;
											int index = j;
											array4[0] = list8[index];
											object[] array5 = array2;
											List<string> list9 = list2;
											List<string> list10 = list9;
											int index2 = j;
											array5[1] = list10[index2];
											object[] array6 = array2;
											List<string> list11 = list3;
											List<string> list12 = list11;
											int index3 = j;
											array6[2] = list12[index3];
											array2[3] = 1;
											object[] array7 = array2;
											object[] arguments2 = array7;
											bool[] array3 = new bool[4] { true, true, true, false };
											object value = NewLateBinding.LateGet(instance2, null, "Add3", arguments2, null, null, array3);
											if (array3[0])
											{
												list7[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
											}
											if (array3[1])
											{
												list9[index2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
											}
											if (array3[2])
											{
												list11[index3] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
											}
											if (Conversions.ToInteger(value) != 0)
											{
												stringBuilder.AppendLine("\"" + list[j] + "\" Ошибка изменения");
											}
										}
									}
									else
									{
										int num6;
										if (Strings.Len(list3[j]) == 0)
										{
											CustomPropertyManager instance3 = customPropertyManager;
											object[] array2 = new object[4];
											object[] array8 = array2;
											List<string> list11 = list;
											List<string> list13 = list11;
											int index3 = j;
											array8[0] = list13[index3];
											array2[1] = 30;
											object[] array9 = array2;
											List<string> list9 = list3;
											List<string> list14 = list9;
											int index2 = j;
											array9[2] = list14[index2];
											array2[3] = 1;
											object[] array7 = array2;
											object[] arguments3 = array7;
											bool[] array3 = new bool[4] { true, false, true, false };
											object value2 = NewLateBinding.LateGet(instance3, null, "Add3", arguments3, null, null, array3);
											if (array3[0])
											{
												list11[index3] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
											}
											if (array3[2])
											{
												list9[index2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
											}
											num6 = Conversions.ToInteger(value2);
										}
										else
										{
											CustomPropertyManager instance4 = customPropertyManager;
											object[] array2 = new object[4];
											object[] array10 = array2;
											List<string> list11 = list;
											List<string> list15 = list11;
											int index3 = j;
											array10[0] = list15[index3];
											object[] array11 = array2;
											List<string> list9 = list2;
											List<string> list16 = list9;
											int index2 = j;
											array11[1] = list16[index2];
											object[] array12 = array2;
											List<string> list7 = list3;
											List<string> list17 = list7;
											int index = j;
											array12[2] = list17[index];
											array2[3] = 1;
											object[] array7 = array2;
											object[] arguments4 = array7;
											bool[] array3 = new bool[4] { true, true, true, false };
											object value3 = NewLateBinding.LateGet(instance4, null, "Add3", arguments4, null, null, array3);
											if (array3[0])
											{
												list11[index3] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
											}
											if (array3[1])
											{
												list9[index2] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[1]), typeof(string));
											}
											if (array3[2])
											{
												list7[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[2]), typeof(string));
											}
											num6 = Conversions.ToInteger(value3);
										}
										if (num6 != 0)
										{
											stringBuilder.AppendLine("\"" + list[j] + "\" Ошибка изменения");
										}
									}
									if (!f_227)
									{
										continue;
									}
									foreach (object item4 in (IEnumerable)obj5)
									{
										object objectValue2 = RuntimeHelpers.GetObjectValue(item4);
										if (!string.Equals(text5, objectValue2.ToString(), StringComparison.OrdinalIgnoreCase))
										{
											customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(objectValue2.ToString());
											int num6 = customPropertyManager.Delete(list[j]);
										}
									}
								}
								if (f_229)
								{
									obj5 = RuntimeHelpers.GetObjectValue(modelDoc.GetConfigurationNames());
									if (f_230 == 0)
									{
										obj5 = (object[])Utils.CopyArray((Array)obj5, new object[Information.UBound((Array)obj5) + 1 + 1]);
										NewLateBinding.LateIndexSet(obj5, new object[2]
										{
											Information.UBound((Array)obj5),
											""
										}, null);
									}
									else if (f_230 != 1)
									{
										if (f_230 == 2)
										{
											obj5 = new object[1];
											NewLateBinding.LateIndexSet(obj5, new object[2] { 0, text3 }, null);
										}
										else if (f_230 == 3)
										{
											obj5 = new object[1];
											NewLateBinding.LateIndexSet(obj5, new object[2] { 0, "" }, null);
										}
									}
									foreach (object item5 in (IEnumerable)obj5)
									{
										object objectValue3 = RuntimeHelpers.GetObjectValue(item5);
										customPropertyManager = ((IModelDocExtension)modelDocExtension).get_CustomPropertyManager(objectValue3.ToString());
										obj4 = RuntimeHelpers.GetObjectValue(customPropertyManager.GetNames());
										if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj4)))
										{
											continue;
										}
										foreach (object item6 in (IEnumerable)obj4)
										{
											obj3 = RuntimeHelpers.GetObjectValue(item6);
											bool flag7 = false;
											int num7 = list.Count - 1;
											for (int k = 0; k <= num7; k++)
											{
												if (list[k].Equals(obj3.ToString(), StringComparison.OrdinalIgnoreCase))
												{
													flag7 = true;
													break;
												}
											}
											if (!flag7)
											{
												int num6 = customPropertyManager.Delete(obj3.ToString());
											}
										}
									}
								}
								if (!string.Equals(text2, text, StringComparison.OrdinalIgnoreCase))
								{
									string lErrors = "";
									flag4 = ReName(modelDoc, text2, text, ref lErrors);
									if (!flag4)
									{
										stringBuilder.AppendLine(lErrors);
									}
								}
								if (!flag4)
								{
									modelDoc.SetSaveFlag();
									if (f_232)
									{
										string text9 = "";
										if (Conversions.ToDouble(f_206.RevisionNumber().Substring(0, 2)) >= 23.0)
										{
											Configuration instance5 = (Configuration)modelDoc.GetActiveConfiguration();
											object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance5, null, "GetScene", new object[0], null, null, null));
											if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue4)))
											{
												object[] array7 = new object[1] { text9 };
												object[] arguments5 = array7;
												bool[] array3 = new bool[1] { true };
												NewLateBinding.LateCall(objectValue4, null, "GetP2SFileName", arguments5, null, null, array3, IgnoreReturn: true);
												if (array3[0])
												{
													text9 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array7[0]), typeof(string));
												}
											}
										}
										modelDocExtension.InsertScene("\\scenes\\01 basic scenes\\11 white kitchen.p2s");
										modelDocExtension.InsertScene("\\scenes\\01 basic scenes\\00 3 point faded.p2s");
										modelDocExtension.InsertScene(text9);
										if (!modelDoc.Save3(1, ref Errors2, ref Warnings2))
										{
											stringBuilder.AppendLine("Ошибка сохранения:0x" + Errors2.ToString("x2"));
										}
									}
								}
								if (flag4)
								{
									list6.Add(text2);
									list5.Add(text);
								}
								if (flag)
								{
									if (!flag4)
									{
										f_206.ActivateDoc(text);
										text6 = text;
									}
									else
									{
										f_206.ActivateDoc(text2);
										text6 = text2;
									}
								}
								if (flag3 && f_208 != 4)
								{
									if (modelDoc.GetSaveFlag())
									{
										modelDoc.Save3(1, ref Errors2, ref Warnings2);
									}
									f_206.CloseDoc(text2);
								}
								list.Clear();
								list2.Clear();
								list3.Clear();
								list4.Clear();
								customPropertyManager = null;
								modelDocExtension = null;
								modelDoc = null;
							}
							else
							{
								stringBuilder.AppendLine("Недопустимый документ или ошибка открытия:0x" + Errors.ToString("x2"));
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							stringBuilder.AppendLine(ex2.Message);
							ProjectData.ClearProjectError();
						}
						num++;
						sendmessageC(2, num.ToString());
						string value4 = stringBuilder.ToString();
						stringBuilder.Clear();
						stringBuilder.AppendLine(flag4.ToString());
						stringBuilder.AppendLine(text);
						stringBuilder.AppendLine(text2);
						stringBuilder.AppendLine(Conversions.ToString(num2));
						stringBuilder.AppendLine(value4);
						sendmessageC(5, stringBuilder.ToString());
						continue;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					sendmessageC(6, ex4.ToString());
					ProjectData.ClearProjectError();
				}
			}
			f_206.DocumentVisible(Visible: true, 1);
			f_206.DocumentVisible(Visible: true, 2);
			Updatereference3(text6, list6, list5);
			object objectValue5 = RuntimeHelpers.GetObjectValue(f_206.GetOpenDocumentByName(text6));
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue5)) && list6.Count > 0)
			{
				NewLateBinding.LateCall(objectValue5, null, "ForceRebuild3", new object[1] { true }, null, null, null, IgnoreReturn: true);
			}
		}
	}

	public bool ReName(ModelDoc2 htPart, string NewPathName, string OldPathName, ref string lErrors)
	{
		int num = -1;
		string text = "";
		string text2 = "";
		if (Information.IsNothing(htPart))
		{
			lErrors = "Недопустимый документ";
			return false;
		}
		if (string.Equals(NewPathName, OldPathName, StringComparison.OrdinalIgnoreCase))
		{
			lErrors = "Новое и старое имя совпадают";
			return false;
		}
		if (File.Exists(NewPathName) & !f_233)
		{
			lErrors = "В текущей папке есть файл с тем же именем" + Type_16.m_53(NewPathName, 4) + ", отметьте опцию «Перезаписать одноимённые файлы»";
			return false;
		}
		ModelDoc2 openDocument = f_206.GetOpenDocument(Type_16.m_53(NewPathName, 4));
		if (!Information.IsNothing(openDocument) && !string.Equals(openDocument.GetPathName(), OldPathName, StringComparison.OrdinalIgnoreCase))
		{
			lErrors = "Имя" + Type_16.m_53(NewPathName, 4) + "файл уже открыт, измените имя на другое";
			return false;
		}
		try
		{
			NewPathName = Type_16.m_53(NewPathName, 3) + Type_16.m_53(NewPathName, 5).ToUpper();
			num = htPart.SaveAs3(NewPathName, 0, 1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (num != 0)
		{
			lErrors = "Ошибка переименования";
			return false;
		}
		try
		{
			text = Type_16.m_53(OldPathName, 3) + ".SLDDRW";
			if (File.Exists(text))
			{
				text2 = Type_16.m_53(NewPathName, 3) + ".SLDDRW";
				File.Copy(text, text2, overwrite: true);
				if (File.Exists(text2))
				{
					File.SetAttributes(text2, FileAttributes.Normal);
				}
				f_206.ReplaceReferencedDocument(text2, OldPathName, NewPathName);
			}
			f_206.CloseDoc(OldPathName);
			f_206.CloseDoc(text);
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
		if (f_234 != 0)
		{
			if (f_234 == 1)
			{
				Type_16.m_55(OldPathName);
			}
			else if (f_234 == 2)
			{
				Type_16.m_56(OldPathName, f_235);
			}
		}
		return true;
	}

	public void Updatereference(string TopDocPathName, List<string> NewNameArr, List<string> OldNameArr)
	{
		int num = 0;
		sendmessageC(0, NewNameArr.Count.ToString());
		sendmessageC(1, "Обновление ссылок");
		sendmessageC(2, num.ToString());
		if (NewNameArr.Count < 1)
		{
			return;
		}
		Component2 component = null;
		object obj = null;
		object obj2 = null;
		List<string> list = new List<string>();
		AssemblyDoc assemblyDoc = null;
		List<string> list2 = new List<string>();
		object ModelPathName = null;
		object ComponentPathName = null;
		object Feature = null;
		object DataType = null;
		object Status = null;
		object RefEntity = null;
		object FeatCom = null;
		string ConfigName = "";
		checked
		{
			try
			{
				obj2 = RuntimeHelpers.GetObjectValue(f_206.GetDocuments());
				int num2 = Information.UBound((Array)obj2);
				for (int i = 0; i <= num2; i++)
				{
					ModelDoc2 modelDoc = (ModelDoc2)NewLateBinding.LateIndexGet(obj2, new object[1] { i }, null);
					if (!Information.IsNothing(modelDoc))
					{
						string pathName = modelDoc.GetPathName();
						list2.Add(pathName);
					}
				}
				int num3 = list2.Count - 1;
				Type_30 type_ = default(Type_30);
				int Errors = default(int);
				int Warnings = default(int);
				for (int j = 0; j <= num3; j++)
				{
					string text = list2[j];
					if (!text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					ModelDoc2 modelDoc2 = (ModelDoc2)f_206.GetOpenDocumentByName(text);
					if (Information.IsNothing(modelDoc2))
					{
						continue;
					}
					int num4 = 0;
					ModelDocExtension extension = modelDoc2.Extension;
					if (!Information.IsNothing(extension))
					{
						num4 = extension.ListExternalFileReferencesCount();
						extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
					}
					if (num4 < 1)
					{
						continue;
					}
					bool flag = false;
					int num5 = num4 - 1;
					for (int k = 0; k <= num5; k++)
					{
						type_ = new Type_30(type_);
						type_.f_262 = Conversions.ToString(NewLateBinding.LateIndexGet(ModelPathName, new object[1] { k }, null));
						if (OldNameArr.Exists(type_.m_114))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
					if (modelDoc2.GetSaveFlag())
					{
						modelDoc2.Save3(1, ref Errors, ref Warnings);
					}
					f_206.CloseDoc(text);
					int num6 = list2.Count - 1;
					for (int l = 0; l <= num6; l++)
					{
						string text2 = list2[l];
						if (!text2.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
						{
							continue;
						}
						assemblyDoc = (AssemblyDoc)f_206.GetOpenDocumentByName(text2);
						if (Information.IsNothing(assemblyDoc))
						{
							continue;
						}
						obj = RuntimeHelpers.GetObjectValue(assemblyDoc.GetComponents(true));
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
						{
							continue;
						}
						int num7 = Information.UBound((Array)obj);
						for (int m = 0; m <= num7; m++)
						{
							component = (Component2)NewLateBinding.LateIndexGet(obj, new object[1] { m }, null);
							if (!Information.IsNothing(component) && component.GetPathName().Equals(text, StringComparison.OrdinalIgnoreCase))
							{
								component.SetSuppression2(1);
							}
						}
						ModelDoc2 expression = (ModelDoc2)f_206.GetOpenDocumentByName(text);
						if (Information.IsNothing(expression))
						{
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				ProjectData.ClearProjectError();
			}
			bool flag2 = false;
			try
			{
				int num8 = NewNameArr.Count - 1;
				for (int n = 0; n <= num8; n++)
				{
					Application.DoEvents();
					if (Dostop())
					{
						break;
					}
					if (NewNameArr[n].EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(f_206.GetDocumentDependencies2(NewNameArr[n], Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
						{
							int num9 = Information.UBound((Array)objectValue);
							for (int num10 = 0; num10 <= num9; num10 += 2)
							{
								if (Dostop())
								{
									return;
								}
								string text3 = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { num10 + 1 }, null));
								if (text3.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
								{
									f_206.ReplaceReferencedDocument(text3, OldNameArr[n], NewNameArr[n]);
								}
							}
						}
					}
					if (f_236 && !flag2)
					{
						Type_16.m_54(list, f_238, "*.SLDASM", f_237);
						flag2 = true;
					}
					int num11 = list.Count - 1;
					for (int num12 = 0; num12 <= num11; num12++)
					{
						f_206.ReplaceReferencedDocument(list[num12], OldNameArr[n], NewNameArr[n]);
					}
					sendmessageC(2, (n + 1).ToString());
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				sendmessageC(6, ex4.ToString());
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Updatereference2(string TopDocPathName, List<string> NewNameArr, List<string> OldNameArr)
	{
		if (NewNameArr.Count < 1)
		{
			return;
		}
		int num = 0;
		sendmessageC(0, NewNameArr.Count.ToString());
		sendmessageC(1, "Обновление ссылок");
		sendmessageC(2, num.ToString());
		List<string> list = new List<string>();
		bool flag = false;
		checked
		{
			try
			{
				int num2 = NewNameArr.Count - 1;
				int Errors = default(int);
				int Warnings = default(int);
				for (int i = 0; i <= num2; i++)
				{
					Application.DoEvents();
					if (Dostop())
					{
						break;
					}
					if (NewNameArr[i].EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(f_206.GetDocumentDependencies2(NewNameArr[i], Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
						{
							int num3 = Information.UBound((Array)objectValue);
							for (int j = 0; j <= num3; j += 2)
							{
								if (Dostop())
								{
									return;
								}
								string text = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { j + 1 }, null));
								if (!text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
								{
									continue;
								}
								ModelDoc2 modelDoc = (ModelDoc2)f_206.GetOpenDocumentByName(text);
								if (!Information.IsNothing(modelDoc))
								{
									if (modelDoc.GetSaveFlag())
									{
										modelDoc.Save3(1, ref Errors, ref Warnings);
									}
									if (modelDoc.ForceReleaseLocks() == 1)
									{
										f_206.ReplaceReferencedDocument(text, OldNameArr[i], NewNameArr[i]);
										modelDoc.ReloadOrReplace(ReadOnly: false, text, DiscardChanges: true);
									}
								}
								else
								{
									f_206.ReplaceReferencedDocument(text, OldNameArr[i], NewNameArr[i]);
								}
							}
						}
					}
					if (f_236 && !flag)
					{
						Type_16.m_54(list, f_238, "*.SLDASM", f_237);
						flag = true;
					}
					int num4 = list.Count - 1;
					for (int k = 0; k <= num4; k++)
					{
						f_206.ReplaceReferencedDocument(list[k], OldNameArr[i], NewNameArr[i]);
					}
					sendmessageC(2, (i + 1).ToString());
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Updatereference3(string TopDocPathName, List<string> NewNameArr, List<string> OldNameArr)
	{
		if (NewNameArr.Count < 1)
		{
			return;
		}
		int num = 0;
		sendmessageC(0, NewNameArr.Count.ToString());
		sendmessageC(1, "Обновление ссылок");
		sendmessageC(2, num.ToString());
		List<string> list = new List<string>();
		object ModelPathName = null;
		object ComponentPathName = null;
		object Feature = null;
		object DataType = null;
		object Status = null;
		object RefEntity = null;
		object FeatCom = null;
		string ConfigName = "";
		bool flag = false;
		checked
		{
			try
			{
				int num2 = NewNameArr.Count - 1;
				int Errors = default(int);
				int Warnings = default(int);
				for (int i = 0; i <= num2; i++)
				{
					Application.DoEvents();
					if (Dostop())
					{
						break;
					}
					if (!flag && f_236)
					{
						Type_16.m_54(list, f_238, "*.SLDASM", f_237);
						flag = true;
					}
					if (NewNameArr[i].EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						object objectValue = RuntimeHelpers.GetObjectValue(f_206.GetDocumentDependencies2(NewNameArr[i], Traverseflag: true, Searchflag: true, AddReadOnlyInfo: false));
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
						{
							int num3 = Information.UBound((Array)objectValue);
							for (int j = 0; j <= num3; j += 2)
							{
								if (Dostop())
								{
									return;
								}
								string text = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { j + 1 }, null));
								list.Remove(text);
								if (!text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
								{
									continue;
								}
								ModelDoc2 modelDoc = (ModelDoc2)f_206.GetOpenDocumentByName(text);
								if (!Information.IsNothing(modelDoc))
								{
									int num4 = 0;
									ModelDocExtension extension = modelDoc.Extension;
									if (!Information.IsNothing(extension))
									{
										num4 = extension.ListExternalFileReferencesCount();
										extension.ListExternalFileReferences(out ModelPathName, out ComponentPathName, out Feature, out DataType, out Status, out RefEntity, out FeatCom, out var _, out ConfigName);
									}
									if (num4 < 1)
									{
										continue;
									}
									bool flag2 = false;
									int num5 = num4 - 1;
									for (int k = 0; k <= num5; k++)
									{
										string value = Conversions.ToString(NewLateBinding.LateIndexGet(ModelPathName, new object[1] { k }, null));
										if (OldNameArr[i].Equals(value, StringComparison.OrdinalIgnoreCase))
										{
											flag2 = true;
											break;
										}
									}
									if (flag2)
									{
										if (modelDoc.GetSaveFlag())
										{
											modelDoc.Save3(1, ref Errors, ref Warnings);
										}
										if (modelDoc.ForceReleaseLocks() == 1)
										{
											f_206.ReplaceReferencedDocument(text, OldNameArr[i], NewNameArr[i]);
											modelDoc.ReloadOrReplace(ReadOnly: false, text, DiscardChanges: true);
										}
									}
								}
								else
								{
									f_206.ReplaceReferencedDocument(text, OldNameArr[i], NewNameArr[i]);
								}
							}
						}
					}
					int num6 = list.Count - 1;
					for (int l = 0; l <= num6; l++)
					{
						f_206.ReplaceReferencedDocument(list[l], OldNameArr[i], NewNameArr[i]);
					}
					sendmessageC(2, (i + 1).ToString());
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Modifyunit(ModelDocExtension swModelDocExt)
	{
		try
		{
			swModelDocExt.SetUserPreferenceInteger(263, 0, 5);
			swModelDocExt.SetUserPreferenceInteger(263, 0, 4);
			swModelDocExt.SetUserPreferenceInteger(47, 0, f_241);
			swModelDocExt.SetUserPreferenceInteger(49, 0, f_242);
			swModelDocExt.SetUserPreferenceInteger(254, 0, f_243);
			swModelDocExt.SetUserPreferenceInteger(256, 0, f_244);
			swModelDocExt.SetUserPreferenceInteger(51, 0, f_245);
			swModelDocExt.SetUserPreferenceInteger(52, 0, f_246);
			swModelDocExt.SetUserPreferenceInteger(258, 0, f_247);
			swModelDocExt.SetUserPreferenceInteger(259, 0, f_248);
			swModelDocExt.SetUserPreferenceInteger(260, 0, f_249);
			swModelDocExt.SetUserPreferenceInteger(261, 0, f_250);
			swModelDocExt.SetUserPreferenceInteger(337, 0, f_251);
			swModelDocExt.SetUserPreferenceInteger(262, 0, f_252);
			swModelDocExt.SetUserPreferenceInteger(335, 0, f_253);
			swModelDocExt.SetUserPreferenceInteger(333, 0, f_254);
			swModelDocExt.SetUserPreferenceInteger(338, 0, f_255);
			swModelDocExt.SetUserPreferenceInteger(332, 0, f_256);
			swModelDocExt.SetUserPreferenceInteger(336, 0, f_257);
			swModelDocExt.SetUserPreferenceInteger(334, 0, f_258);
			swModelDocExt.SetUserPreferenceInteger(263, 0, f_240);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void addmaterialtosw()
	{
		if (File.Exists(f_239))
		{
			string f_263 = Type_16.m_53(f_239).TrimEnd('\\', '/');
			string userPreferenceStringValue = f_206.GetUserPreferenceStringValue(28);
			List<string> list = userPreferenceStringValue.Split(';').ToList();
			if (!list.Exists((string P_0) => P_0.Equals(f_263, StringComparison.OrdinalIgnoreCase)))
			{
				userPreferenceStringValue = userPreferenceStringValue + ";" + f_263;
				bool flag = f_206.SetUserPreferenceStringValue(28, userPreferenceStringValue);
			}
		}
	}

	public void Setcomponentstate(string topname, string Cname, string CfgName, int n)
	{
		AssemblyDoc assemblyDoc = null;
		ModelDoc2 modelDoc = null;
		object obj = null;
		Component2 component = null;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		checked
		{
			try
			{
				if (!topname.EndsWith("SLDASM", StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
				modelDoc = f_206.GetOpenDocument(topname);
				if (Information.IsNothing(modelDoc))
				{
					return;
				}
				assemblyDoc = (AssemblyDoc)modelDoc;
				if (Information.IsNothing(assemblyDoc))
				{
					return;
				}
				obj = RuntimeHelpers.GetObjectValue(assemblyDoc.GetComponents(false));
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
				{
					return;
				}
				int num4 = Information.UBound((Array)obj);
				for (num = 0; num <= num4; num++)
				{
					component = (Component2)NewLateBinding.LateIndexGet(obj, new object[1] { num }, null);
					if (Information.IsNothing(component))
					{
						continue;
					}
					if ((!f_209 && string.Equals(Cname, component.GetPathName(), StringComparison.OrdinalIgnoreCase) && string.Equals(CfgName, component.ReferencedConfiguration, StringComparison.OrdinalIgnoreCase)) || (f_209 && string.Equals(Cname, component.GetPathName(), StringComparison.OrdinalIgnoreCase)))
					{
						component.Select(AppendFlag: true);
						switch (n)
						{
						case 1:
							num3 = component.SetSuppression2(0);
							if (component.GetSuppression() == 0)
							{
								num2++;
							}
							break;
						case 2:
							num3 = component.SetSuppression2(3);
							if (component.GetSuppression() != 0)
							{
								num2++;
							}
							break;
						case 3:
							component.ExcludeFromBOM = true;
							if (component.ExcludeFromBOM)
							{
								num2++;
							}
							break;
						case 4:
							component.ExcludeFromBOM = false;
							if (!component.ExcludeFromBOM)
							{
								num2++;
							}
							break;
						}
					}
					component = null;
				}
				modelDoc.SetSaveFlag();
				modelDoc.EditRebuild3();
				assemblyDoc = null;
				modelDoc = null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				sendmessageC(6, ex2.ToString());
				MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void GetPreview(string filename, string cfgname, bool ispng)
	{
		try
		{
			if (Operators.CompareString(cfgname, string.Empty, TextCompare: false) == 0)
			{
				cfgname = f_206.GetActiveConfigurationName(filename);
			}
			ModelDoc2 openDocument = f_206.GetOpenDocument(filename);
			if (!Information.IsNothing(openDocument))
			{
				openDocument.ShowConfiguration2(cfgname);
				openDocument = null;
			}
			IPictureDisp pictureDisp = (IPictureDisp)f_206.GetPreviewBitmap(filename, cfgname);
			if (!Information.IsNothing(pictureDisp))
			{
				IntPtr hbitmap = new IntPtr(pictureDisp.Handle);
				Image image = Image.FromHbitmap(hbitmap);
				sendmessageC(4, Convert.ToBase64String(Type_19.m_74(image, ispng)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			sendmessageC(6, ex2.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public void selectinsw(string idstring, string asmname, string cfgname)
	{
		try
		{
			ModelDoc2 openDocument = f_206.GetOpenDocument(asmname);
			if (Information.IsNothing(openDocument))
			{
				return;
			}
			openDocument.ShowConfiguration2(cfgname);
			openDocument.ClearSelection();
			List<string> list = idstring.Split('|').ToList();
			foreach (string item in list)
			{
				openDocument.Extension.SelectByID2(item, "COMPONENT", 0.0, 0.0, 0.0, Append: true, 0, null, 0);
			}
			openDocument.ViewZoomToSelection();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			sendmessageC(6, ex2.ToString());
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void readmaterialfile(string Materialpath)
	{
		try
		{
			XDocument xDocument = null;
			if (File.Exists(Materialpath))
			{
				xDocument = XDocument.Load(Materialpath);
			}
			if (!Information.IsNothing(xDocument))
			{
				sendmessageC(8, xDocument.ToString());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			sendmessageC(6, ex2.ToString());
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public string BOMPartNumber(Configuration config, ModelDoc2 document)
	{
		string result = "";
		try
		{
			switch (config.BOMPartNoSource)
			{
			case 2:
				result = config.Name;
				break;
			case 1:
			{
				string title = document.GetTitle();
				result = ((!title.EndsWith(".sldprt", StringComparison.OrdinalIgnoreCase) && !title.EndsWith(".sldasm", StringComparison.OrdinalIgnoreCase)) ? title : title.Substring(0, checked(Strings.Len(title) - 7)));
				break;
			}
			case 8:
				result = config.AlternateName;
				break;
			case 4:
			{
				Configuration config2 = config.GetParent();
				result = BOMPartNumber(config2, document);
				break;
			}
			case 3:
			case 5:
			case 6:
			case 7:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw ex2;
		}
		return result;
	}

	public BOMPartData GetBOMPartData(string FilePathName, string cfgname)
	{
		BOMPartData bOMPartData = default(BOMPartData);
		bool flag = false;
		try
		{
			if (!File.Exists(FilePathName))
			{
				return bOMPartData;
			}
			int type = default(int);
			if (FilePathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				type = 1;
			}
			if (FilePathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				type = 2;
			}
			if (FilePathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				type = 3;
			}
			ModelDoc2 modelDoc = f_206.GetOpenDocument(FilePathName);
			if (Information.IsNothing(modelDoc))
			{
				flag = false;
				int Errors = default(int);
				int Warnings = default(int);
				modelDoc = f_206.OpenDoc6(FilePathName, type, 1, cfgname, ref Errors, ref Warnings);
			}
			else
			{
				flag = modelDoc.Visible;
			}
			if (Information.IsNothing(modelDoc))
			{
				sendmessageC(6, "Открыть " + FilePathName + " Ошибка!");
				MessageBox.Show("Открыть " + FilePathName + " Ошибка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return bOMPartData;
			}
			Configuration configuration = (Configuration)modelDoc.GetConfigurationByName(cfgname);
			if (!Information.IsNothing(configuration))
			{
				bOMPartData.AlternateName = configuration.AlternateName;
				bOMPartData.BOMPartNoSource = configuration.BOMPartNoSource;
				Configuration configuration2 = configuration.GetParent();
				if (!Information.IsNothing(configuration2))
				{
					bOMPartData.ParentName = BOMPartNumber(configuration2, modelDoc);
				}
				bOMPartData.BOMPartNumber = BOMPartNumber(configuration, modelDoc);
			}
			sendmessageC(9, Type_16.m_70(bOMPartData));
			if (!flag)
			{
				f_206.CloseDoc(FilePathName);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			sendmessageC(6, ex2.ToString());
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return bOMPartData;
	}

	public void SetBOMPartData(string FilePathName, string cfgname, int BOMPartNoSource, string AlternateName = "")
	{
		bool flag = false;
		try
		{
			if (!File.Exists(FilePathName))
			{
				return;
			}
			int type = default(int);
			if (FilePathName.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase))
			{
				type = 1;
			}
			if (FilePathName.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
			{
				type = 2;
			}
			if (FilePathName.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase))
			{
				type = 3;
			}
			ModelDoc2 modelDoc = f_206.GetOpenDocument(FilePathName);
			if (Information.IsNothing(modelDoc))
			{
				flag = true;
				int Errors = default(int);
				int Warnings = default(int);
				modelDoc = f_206.OpenDoc6(FilePathName, type, 1, cfgname, ref Errors, ref Warnings);
			}
			if (Information.IsNothing(modelDoc))
			{
				return;
			}
			Configuration configuration = (Configuration)modelDoc.GetConfigurationByName(cfgname);
			if (!Information.IsNothing(configuration))
			{
				int bOMPartNoSource = configuration.BOMPartNoSource;
				string text = BOMPartNumber(configuration, modelDoc);
				configuration.BOMPartNoSource = BOMPartNoSource;
				if (BOMPartNoSource == 8)
				{
					configuration.AlternateName = AlternateName;
					configuration.UseAlternateNameInBOM = true;
				}
				else
				{
					configuration.UseAlternateNameInBOM = false;
				}
				BOMPartData bOMPartData = default(BOMPartData);
				bOMPartData.AlternateName = configuration.AlternateName;
				bOMPartData.BOMPartNoSource = configuration.BOMPartNoSource;
				Configuration configuration2 = configuration.GetParent();
				if (!Information.IsNothing(configuration2))
				{
					bOMPartData.ParentName = BOMPartNumber(configuration2, modelDoc);
				}
				bOMPartData.BOMPartNumber = BOMPartNumber(configuration, modelDoc);
				if (bOMPartNoSource != bOMPartData.BOMPartNoSource || !text.Equals(bOMPartData.BOMPartNumber, StringComparison.OrdinalIgnoreCase))
				{
					modelDoc.SetSaveFlag();
				}
				sendmessageC(9, Type_16.m_70(bOMPartData));
			}
			if (flag)
			{
				if (modelDoc.GetSaveFlag())
				{
					int Errors2 = default(int);
					int Warnings2 = default(int);
					modelDoc.Save3(5, ref Errors2, ref Warnings2);
				}
				f_206.CloseDoc(FilePathName);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			sendmessageC(6, ex2.ToString());
			ProjectData.ClearProjectError();
		}
	}
}
