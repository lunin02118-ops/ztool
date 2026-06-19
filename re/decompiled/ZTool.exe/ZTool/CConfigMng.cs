using System;
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
			}
			else
			{
				m_Config.CConfigDO();
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
