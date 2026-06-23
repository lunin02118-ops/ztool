using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class CConfigMng
{
	private static string m_sConfigFileName;

	private static CConfigDO m_Config;

	public static CConfigDO Config
	{
		get
		{
			return m_Config;
		}
		set
		{
			m_Config = value;
		}
	}

	public static string ConfigFileName => m_sConfigFileName;

	[DebuggerNonUserCode]
	public CConfigMng()
	{
	}

	static CConfigMng()
	{
		m_sConfigFileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + Application.ProductName + ".settings";
		m_Config = new CConfigDO();
		LoadConfig();
	}

	public static void LoadConfig()
	{
		try
		{
			if (File.Exists(m_sConfigFileName))
			{
				StreamReader streamReader = File.OpenText(m_sConfigFileName);
				Type type = m_Config.GetType();
				XmlSerializer xmlSerializer = new XmlSerializer(type);
				object objectValue = RuntimeHelpers.GetObjectValue(xmlSerializer.Deserialize(streamReader));
				m_Config = (CConfigDO)objectValue;
				streamReader.Close();
				EnsureRequiredBomMappings();
			}
			else
			{
				m_Config.InitDefaults();
				EnsureRequiredBomMappings();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	private static void EnsureRequiredBomMappings()
	{
		if (m_Config.namemappinglist == null)
		{
			m_Config.namemappinglist = new List<columnnamemapping>();
		}
		EnsureStandardPropertyMappings();
		EnsureBomMapping("Col_Weight", "Масса ед._кг", "МассаЕдКг");
		EnsureBomMapping("Col_bound", "Габаритные размеры", "ГабаритныеРазмеры");
	}

	private static void EnsureStandardPropertyMappings()
	{
		if (m_Config.propname == null)
		{
			return;
		}
		checked
		{
			int num = m_Config.propname.Count - 1;
			int num2 = 0;
			while (true)
			{
				int num3 = num2;
				int num4 = num;
				if (num3 > num4)
				{
					break;
				}
				string text = m_Config.propname[num2] ?? "";
				string defaultPropertyAnchor = GetDefaultPropertyAnchor(text);
				EnsurePropertyMapping(num2, text, defaultPropertyAnchor);
				num2++;
			}
		}
	}

	private static string GetDefaultPropertyAnchor(string text)
	{
		switch (text)
		{
		case "Наименование":
			return "Наименование";
		case "Обозначение":
			return "Обозначение";
		case "Материал":
			return "Материал";
		case "Тип":
			return "Тип";
		case "Версия":
			return "Версия";
		case "Обработка поверхности":
			return "ОбработкаПоверхности";
		default:
			return "";
		}
	}

	private static void EnsurePropertyMapping(int index, string text, string mappingname)
	{
		string name = "PropVal_" + Conversions.ToString(index);
		string name2 = "PropResolvedVal_" + Conversions.ToString(index);
		columnnamemapping columnnamemapping2 = m_Config.namemappinglist.Find((columnnamemapping s) => string.Equals(s.name ?? "", name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.name2 ?? "", name2, StringComparison.OrdinalIgnoreCase));
		if (columnnamemapping2 == null)
		{
			m_Config.namemappinglist.Add(new columnnamemapping
			{
				name = name,
				name2 = name2,
				text = text,
				mappingname = mappingname
			});
			return;
		}
		columnnamemapping2.name = name;
		columnnamemapping2.name2 = name2;
		columnnamemapping2.text = text;
		if (!string.IsNullOrEmpty(mappingname))
		{
			columnnamemapping2.mappingname = mappingname;
		}
	}

	private static void EnsureBomMapping(string name, string text, string mappingname)
	{
		columnnamemapping columnnamemapping2 = m_Config.namemappinglist.Find((columnnamemapping s) => string.Equals(s.name ?? "", name, StringComparison.OrdinalIgnoreCase));
		if (columnnamemapping2 == null)
		{
			m_Config.namemappinglist.Add(new columnnamemapping
			{
				name = name,
				name2 = "",
				text = text,
				mappingname = mappingname
			});
			return;
		}
		columnnamemapping2.name2 = "";
		columnnamemapping2.text = text;
		columnnamemapping2.mappingname = mappingname;
	}

	public static void SaveConfig()
	{
		try
		{
			StreamWriter streamWriter = File.CreateText(m_sConfigFileName);
			Type type = m_Config.GetType();
			if (type.IsSerializable)
			{
				XmlSerializer xmlSerializer = new XmlSerializer(type);
				xmlSerializer.Serialize(streamWriter, m_Config);
				streamWriter.Close();
			}
			LoadConfig();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}

	public static void InitializeConfig()
	{
		try
		{
			if (!File.Exists(m_sConfigFileName))
			{
				StreamWriter streamWriter = File.CreateText(m_sConfigFileName);
				Type type = m_Config.GetType();
				if (type.IsSerializable)
				{
					XmlSerializer xmlSerializer = new XmlSerializer(type);
					xmlSerializer.Serialize(streamWriter, m_Config);
					streamWriter.Close();
				}
				LoadConfig();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			ProjectData.ClearProjectError();
		}
	}
}
