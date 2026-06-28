using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SolidWorks.Interop.swdocumentmgr;
using ZTool.CustomFileBorser1;
using ZTool.My;

namespace ZTool;

public class MySWDM
{
	[CompilerGenerated]
	internal class _Closure_0024__92
	{
		public string _0024VB_0024Local_pname;

		[DebuggerNonUserCode]
		public _Closure_0024__92()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__92(_Closure_0024__92 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_pname = other._0024VB_0024Local_pname;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__150(string s)
		{
			return s.Equals(_0024VB_0024Local_pname, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__151(string s)
		{
			return s.Equals(_0024VB_0024Local_pname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__93
	{
		public string _0024VB_0024Local_pname;

		[DebuggerNonUserCode]
		public _Closure_0024__93()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__93(_Closure_0024__93 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_pname = other._0024VB_0024Local_pname;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__152(string s)
		{
			return s.Equals(_0024VB_0024Local_pname, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__153(string s)
		{
			return s.Equals(_0024VB_0024Local_pname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__94
	{
		public string _0024VB_0024Local_vCustPropName;

		[DebuggerNonUserCode]
		public _Closure_0024__94()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__94(_Closure_0024__94 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_vCustPropName = other._0024VB_0024Local_vCustPropName;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__154(string s)
		{
			return s.Equals(_0024VB_0024Local_vCustPropName, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__95
	{
		public string _0024VB_0024Local_cfgname;

		[DebuggerNonUserCode]
		public _Closure_0024__95()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__95(_Closure_0024__95 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_cfgname = other._0024VB_0024Local_cfgname;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__155(string s)
		{
			return s.Equals(_0024VB_0024Local_cfgname, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	internal class _Closure_0024__96
	{
		public string _0024VB_0024Local_cfgname;

		[DebuggerNonUserCode]
		public _Closure_0024__96()
		{
		}

		[DebuggerNonUserCode]
		public _Closure_0024__96(_Closure_0024__96 other)
		{
			if (other != null)
			{
				_0024VB_0024Local_cfgname = other._0024VB_0024Local_cfgname;
			}
		}

		[SpecialName]
		[CompilerGenerated]
		public bool _Lambda_0024__156(string s)
		{
			return s.Equals(_0024VB_0024Local_cfgname, StringComparison.OrdinalIgnoreCase);
		}
	}

	private SwDMClassFactory swClassFact;

	internal SwDMApplication swDocMgr;

	internal string err;

	internal bool isok;

	protected string key2022;

	protected string key2021;

	protected string key2019;

	protected string key2016;

	private StreamWriter sw;

	private StringBuilder Sb_bomdata;

	private string Sb_savedata;

	private string Sb_GetFilelist;

	private List<string> FilePathNameArr;

	private List<string> CfgNameArr;

	private List<string> CountqutysArr;

	private List<string> NLevelArr;

	private StringBuilder Sb_Feature;

	private string[] NewConfigNames;

	public string GetSWDMLicenseKey()
	{
		string text = "";
		return code.FromHexString(key2022);
	}

	public MySWDM()
	{
		key2022 = "534f4c4944574f524b535f323032323a7377646f636d67725f67656e6572616c2d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d32313432342d32373731322d30323333332d34313234332d31373835382d35363037302d31343436382d36323436372d33353831372d33383136342d34313330342d32383339362d31363131382d33353739352d31313636362d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d342c7377646f636d67725f70726576696577732d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d35353336302d35333036302d32353334332d34323736392d35393036392d35323437332d32323437332d35323232352d31323037342d30343038312d33323930392d33303732382d32383538392d33333232352d31313530372d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d332c7377646f636d67725f67656f6d657472792d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d34373334382d32333737342d34333637332d30333730352d31323136302d30323738302d33323435392d33343831382d36333230352d31373333312d34363238352d36333133352d34393836332d30373839392d31313738372d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d322c7377646f636d67725f64696d78706572742d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d32393939362d30383437322d34373532392d35363539312d36323435362d34363233372d31303834332d33313734372d33323536372d32373035332d35393932372d31373039332d30373136372d30353939362d31313436312d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d372c7377646f636d67725f74657373656c6c6174696f6e2d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d31303433362d35363931302d33323536372d33343937362d32303932382d31313835302d36323934342d32343537372d34303231312d34383733382d32343535352d33373033372d33323537302d33313237362d31313331352d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d392c7377646f636d67725f786d6c2d31313738352d30323035312d30303036342d35303137372d30363631322d33363836342d34393932312d30303030332d34323031362d30353438392d33353237392d32343831392d35323236342d31343233362d31363430302d34383133312d34333538312d33353935332d31313239302d32383031372d32323635332d32323732382d31313838322d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353639362d30303130302d31323537322d31313537372d33303034392d31313632332d31323333382d31323333382d38";
		key2021 = "4265696a696e6759696461536966616e67496e666f546563683a7377646f636d67725f67656e6572616c2d31313738352d30323035312d30303036342d33333739332d30383632392d33343330372d30303030372d32303339322d36323739392d30343331352d35353635372d31373133322d31363937352d33393139352d35333235352d34383631352d34323439332d34323232302d32373738352d30353931342d33323235302d32333638372d33383135322d34333432392d34373532352d32363031332d33373238352d31393834352d33393333332d34373439332d30393632392d33393335332d32303932352d33363234352d30303431372d32353134342d32333135322d35313931322d32333233382d32343637362d32343637362d352c7377646f636d67725f70726576696577732d31313738352d30323035312d30303036342d33333739332d30383632392d33343330372d30303030372d32303632342d32373932392d32343830352d35313933362d35383638392d35363632382d31373137322d35393339372d35373034362d34323530352d32383037322d30353036392d35373637312d33303236352d32323536372d33383135322d34333432392d34373532352d32363031332d33373238352d31393834352d33393333332d34373439332d30393632392d33393335332d32303932352d33363234352d30303431372d32353134342d32333135322d35313931322d32333233382d32343637362d32343637362d352c7377646f636d67725f64696d78706572742d31313738352d30323035312d30303036342d33333739332d30383632392d33343330372d30303030372d35333337362d30323534322d33333331382d36303833342d36323939382d31383939342d34383238382d30323035352d35323633372d34353936362d34333533332d30323632302d35313739342d33343939362d32323639372d33383135322d34333432392d34373532352d32363031332d33373238352d31393834352d33393333332d34373439332d30393632392d33393335332d32303932352d33363234352d30303431372d32353134342d32333135322d35313931322d32333233382d32343637362d32343637362d312c7377646f636d67725f67656f6d657472792d31313738352d30323035312d30303036342d33333739332d30383632392d33343330372d30303030372d35303932302d31373136382d31313031332d36333336372d35353235372d30303633352d36343332352d33323737332d30353331302d30343035332d35333939342d33353734362d36313934312d34383833322d32343230382d33383135322d34333432392d34373532352d32363031332d33373238352d31393834352d33393333332d34373439332d30393632392d33393335332d32303932352d33363234352d30303431372d32353134342d32333135322d35313931322d32333233382d32343637362d32343637362d322c7377646f636d67725f786d6c2d31313738352d30323035312d30303036342d33333739332d30383632392d33343330372d30303030372d33313239362d30393835352d30383536362d30373732322d34323534322d35333531382d34353532302d32363632352d31333534372d36333336372d36313332302d34323336362d32333933352d32393934332d32333832382d33383135322d34333432392d34373532352d32363031332d33373238352d31393834352d33393333332d34373439332d30393632392d33393335332d32303932352d33363234352d30303431372d32353134342d32333135322d35313931322d32333233382d32343637362d32343637362d312c7377646f636d67725f74657373656c6c6174696f6e2d31313738352d30323035312d30303036342d33333739332d30383632392d33343330372d30303030372d32353331322d35353036302d30353138312d31303930392d30303939352d31343632342d34383137352d34333031302d31353033312d32343039322d36323831372d35333835342d34353039342d35343632342d32333534322d33383135322d34333432392d34373532352d32363031332d33373238352d3139";
		key2019 = "534f4c4944574f524b535f323031393a7377646f636d67725f67656e6572616c2d31313738352d30323035312d30303036342d30313032352d30363531392d33363836342d34393932312d30303030332d32313230302d35373931302d31383938372d32363536382d31303833392d30313538342d30303631382d36303431372d30393830332d30313337322d34353539392d32373535352d36303339362d36343037382d31313938302d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353138342d30303131342d31333038342d31313536382d33303034392d31313632332d31323333382d31343132392d362c7377646f636d67725f70726576696577732d31313738352d30323035312d30303036342d30313032352d30363531392d33363836342d34393932312d30303030332d33343230342d31333236372d31373030362d35353036392d34333738352d36333732322d35363538332d35393339332d32363639342d31363233332d30383037332d34313434322d31353739372d31313437362d31313731302d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353138342d30303131342d31333038342d31313536382d33303034392d31313632332d31323333382d31343132392d372c7377646f636d67725f67656f6d657472792d31313738352d30323035312d30303036342d30313032352d30363531392d33363836342d34393932312d30303030332d31323138342d30333734392d36343231322d33363931352d33353736342d32323033302d33383536392d31363338372d35363038312d34393539372d31313530322d33363739302d32313930392d30383339342d31313738352d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353138342d30303131342d31333038342d31313536382d33303034392d31313632332d31323333382d31343132392d312c7377646f636d67725f64696d78706572742d31313738352d30323035312d30303036342d30313032352d30363531392d33363836342d34393932312d30303030332d32323736342d33353634372d31393934322d33353637382d31343234332d30343837392d35303331332d35303137372d30353531352d31333037382d33343938372d30373035372d32313937302d32383637372d31313534342d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353138342d30303131342d31333038342d31313536382d33303034392d31313632332d31323333382d31343132392d332c7377646f636d67725f74657373656c6c6174696f6e2d31313738352d30323035312d30303036342d30313032352d30363531392d33363836342d34393932312d30303030332d32313335322d35373534332d31323631352d31383732302d32343632322d35373231362d31323335372d32363632342d31373335312d35323236352d35363537302d33383233362d33353838382d31303336392d31313532362d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353138342d30303131342d31333038342d31313536382d33303034392d31313632332d31323333382d31343132392d332c7377646f636d67725f786d6c2d31313738352d30323035312d30303036342d30313032352d30363531392d33363836342d34393932312d30303030332d35393334302d30303139302d32353634312d33393239352d34373231362d34383031312d33363630342d36343531352d30343738342d32313130352d33323335352d33313439372d30323931352d32353239332d31313933322d34303631342d33373532382d34343638302d34323134322d34323634362d32353739302d32353138342d30303131342d31333038342d31313536382d33303034392d31313632332d31323333382d31343132392d39";
		key2016 = "536f6c6964576f726b733a7377646f636d67725f67656e6572616c2d31313738352d30323035312d30303036342d31373430392d30383437332d33343330372d30303030372d33303933362d32373233382d35303433382d36333037342d32353433342d33323535302d35343434352d32383637392d34373631352d33373831322d35303034352d31343539372d32333035302d32363137322d32343533312d34383436302d34323431372d32333935332d35313634352d35323635332d31343333372d32353639362d35383937302d35373534362d32353639302d32353138342d313034372c7377646f636d67725f70726576696577732d31313738352d30323035312d30303036342d31373430392d30383437332d33343330372d30303030372d31353632342d30393235322d35383032312d35313733372d35343436342d36313037332d30333231312d32323533322d36313939352d35383838342d32373332302d33353931332d32303934322d30363033332d32333430302d34383436302d34323431372d32333935332d35313634352d35323635332d31343333372d32353639362d35383937302d35373534362d32353639302d32353138342d313034322c7377646f636d67725f64696d78706572742d31313738352d30323035312d30303036342d31373430392d30383437332d33343330372d30303030372d30323931322d31363035352d34363839372d32353438352d34363635372d36323832332d36303630322d30343039382d33333234352d33323537302d31383635392d36323632342d31373734312d31363332322d32323831342d34383436302d34323431372d32333935332d35313634352d35323635332d31343333372d32353639362d35383937302d35373534362d32353639302d32353138342d313034372c7377646f636d67725f67656f6d657472792d31313738352d30323035312d30303036342d31373430392d30383437332d33343330372d30303030372d34363530342d32333832362d33323435382d31303938312d30313238362d36303131362d36343134362d35333235342d36323039382d30333039312d31313537352d36323833302d30373032302d33313130302d32333330362d34383436302d34323431372d32333935332d35313634352d35323635332d31343333372d32353639362d35383937302d35373534362d32353639302d32353138342d313034362c7377646f636d67725f74657373656c6c6174696f6e2d31313738352d30323035312d30303036342d31373430392d30383437332d33343330372d30303030372d35393830382d34363837312d35383239392d32343833332d35383138342d32303930392d33343236332d32383637362d32313036362d31353430302d36303836312d33373436322d30373937392d33373336392d32343339312d34383436302d34323431372d32333935332d35313634352d35323635332d31343333372d32353639362d35383937302d35373534362d32353639302d32353138342d313034392c7377646f636d67725f786d6c2d31313738352d30323035312d30303036342d31373430392d30383437332d33343330372d30303030372d32303630302d36343834362d30393334322d33393138382d31333733312d30313636312d32393731342d34353035362d31333638342d33343836342d32353534342d36333836342d31313835342d31323538392d32343437372d34383436302d34323431372d32333935332d35313634352d35323635332d31343333372d32353639362d35383937302d35373534362d32353639302d32353138342d31303437";
		Sb_bomdata = new StringBuilder();
		FilePathNameArr = new List<string>();
		CfgNameArr = new List<string>();
		CountqutysArr = new List<string>();
		NLevelArr = new List<string>();
		Sb_Feature = new StringBuilder();
		try
		{
			swClassFact = (SwDMClassFactory)Interaction.CreateObject("SwDocumentMgr.SwDMClassFactory");
			if (!Information.IsNothing(swClassFact))
			{
				swDocMgr = swClassFact.GetApplication(GetSWDMLicenseKey());
			}
			if (!Information.IsNothing(swDocMgr))
			{
				isok = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			logopathlist.WriteLog($"Тип исключения: {ex2.GetType().Name}\r\nСообщение: {ex2.Message}\r\nИнформация: {ex2.StackTrace}");
			err = ex2.Message;
			ProjectData.ClearProjectError();
		}
	}

	private static void AddPropertyName(List<string> list, string propertyName)
	{
		string text = Strings.Trim(propertyName);
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return;
		}
		if (!list.Exists((string existing) => existing.Equals(text, StringComparison.OrdinalIgnoreCase)))
		{
			list.Add(text);
		}
	}

	private static void AddPropertyNamesFromEnumerable(List<string> list, object names)
	{
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(names)))
		{
			return;
		}
		foreach (object item in (IEnumerable)names)
		{
			AddPropertyName(list, Conversions.ToString(RuntimeHelpers.GetObjectValue(item)));
		}
	}

	private void RecordDocumentManagerOpenError(string context, string fileName, SwDmDocumentOpenError result)
	{
		if (result == SwDmDocumentOpenError.swDmDocumentOpenErrorNone)
		{
			err = $"{context}\r\nФайл: {fileName}\r\nDocument Manager не вернул объект документа без явного кода ошибки.\r\nПроверьте установленный SOLIDWORKS Document Manager и лицензионный ключ SWDM.";
		}
		else
		{
			err = $"{context}\r\nФайл: {fileName}\r\nDocument Manager не открыл документ: {result} ({(int)result}).\r\nПроверьте установленный SOLIDWORKS Document Manager и лицензионный ключ SWDM.";
		}
		logopathlist.WriteLog(err);
	}

	internal List<string> GetPropertyNames1()
	{
		_Closure_0024__92 closure_0024__ = new _Closure_0024__92();
		closure_0024__._0024VB_0024Local_pname = "";
		err = "";
		List<string> list = new List<string>();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = true;
		openFileDialog.SupportMultiDottedExtensions = true;
		openFileDialog.Filter = "Файлы SOLIDWORKS (*.SLDPRT;*.SLDASM)|*.SLDPRT;*.SLDASM|Деталь SOLIDWORKS (*.SLDPRT)|*.SLDPRT|Сборка SOLIDWORKS (*.SLDASM)|*.SLDASM";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.Cancel)
		{
			return list;
		}
		string[] fileNames = openFileDialog.FileNames;
		string[] array = fileNames;
		int num2 = default(int);
		foreach (string text in array)
		{
			int num;
			if (Strings.InStr(Strings.LCase(text), "sldprt") > 0)
			{
				num = 1;
			}
			else
			{
				if (Strings.InStr(Strings.LCase(text), "sldasm") <= 0)
				{
					if (Strings.InStr(Strings.LCase(text), "slddrw") > 0)
					{
						num = 3;
					}
					else
					{
						num = 0;
					}
					continue;
				}
				num = 2;
			}
			try
			{
				SwDMApplication swDMApplication = swDocMgr;
				int docType = num;
				SwDmDocumentOpenError result = (SwDmDocumentOpenError)num2;
				SwDMDocument document = swDMApplication.GetDocument(text, (SwDmDocumentType)docType, allowReadOnly: true, out result);
				num2 = (int)result;
				SwDMDocument swDMDocument = document;
				if (Information.IsNothing(swDMDocument))
				{
					RecordDocumentManagerOpenError("Импорт свойств из файла", text, result);
					continue;
				}
				object objectValue = RuntimeHelpers.GetObjectValue(swDMDocument.GetCustomPropertyNames());
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
				{
					AddPropertyNamesFromEnumerable(list, objectValue);
				}
				SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
				object objectValue3 = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
				{
					swDMDocument.CloseDoc();
					continue;
				}
				foreach (object item2 in (IEnumerable)objectValue3)
				{
					object objectValue4 = RuntimeHelpers.GetObjectValue(item2);
					SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)configurationManager.GetConfigurationByName(Conversions.ToString(objectValue4));
					if (Information.IsNothing(swDMConfiguration))
					{
						continue;
					}
					objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetCustomPropertyNames());
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
					{
						continue;
					}
					AddPropertyNamesFromEnumerable(list, objectValue);
				}
				swDMDocument.CloseDoc();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				err = $"Document Manager не смог импортировать свойства из файла: {text}\r\n{ex2.Message}";
				logopathlist.WriteLog(err);
				ProjectData.ClearProjectError();
			}
		}
		return list;
	}

	internal List<string> GetPropertyNames2()
	{
		_Closure_0024__93 closure_0024__ = new _Closure_0024__93();
		closure_0024__._0024VB_0024Local_pname = "";
		err = "";
		List<string> list = new List<string>();
		string text = "";
		FileBorser fileBorser = new FileBorser();
		if (fileBorser.ShowDialog(null) == DialogResult.OK)
		{
			text = fileBorser.DirectoryPath;
		}
		if (Operators.CompareString(text, "", TextCompare: false) == 0)
		{
			return list;
		}
		MyProject.Forms.FrmSelType2.TYPE_SLDDRW.Visible = false;
		MyProject.Forms.FrmSelType2.Includesubfolders.Visible = true;
		if (MyProject.Forms.FrmSelType2.ShowDialog() == DialogResult.Cancel)
		{
			return list;
		}
		string text2 = "";
		bool flag = false;
		bool flag2 = false;
		if (MyProject.Forms.FrmSelType2.TYPE_SLDPRT.Checked)
		{
			text2 += "|*.SLDPRT";
		}
		if (MyProject.Forms.FrmSelType2.TYPE_SLDASM.Checked)
		{
			text2 += "|*.SLDASM";
		}
		flag = MyProject.Forms.FrmSelType2.Includesubfolders.Checked;
		flag2 = MyProject.Forms.FrmSelType2.Onlyhasdrw.Checked;
		List<string> list2 = new List<string>();
		code.SearchFiles(list2, text, flag2, text2, flag);
		if (Information.IsNothing(list2) || list2.Count == 0)
		{
			return list;
		}
		int num = checked(list2.Count - 1);
		int num2 = 0;
		int num6 = default(int);
		while (true)
		{
			int num3 = num2;
			int num4 = num;
			if (num3 > num4)
			{
				break;
			}
			int num5;
			if (Strings.InStr(Strings.LCase(list2[num2]), "sldprt") > 0)
			{
				num5 = 1;
			}
			else
			{
				if (Strings.InStr(Strings.LCase(list2[num2]), "sldasm") <= 0)
				{
					if (Strings.InStr(Strings.LCase(list2[num2]), "slddrw") > 0)
					{
						num5 = 3;
					}
					else
					{
						num5 = 0;
					}
					goto IL_0445;
				}
				num5 = 2;
			}
			try
			{
				SwDMApplication swDMApplication = swDocMgr;
				string fullPathName = list2[num2];
				int docType = num5;
				SwDmDocumentOpenError result = (SwDmDocumentOpenError)num6;
				SwDMDocument document = swDMApplication.GetDocument(fullPathName, (SwDmDocumentType)docType, allowReadOnly: true, out result);
				num6 = (int)result;
				SwDMDocument swDMDocument = document;
				if (Information.IsNothing(swDMDocument))
				{
					RecordDocumentManagerOpenError("Импорт свойств из папки", list2[num2], result);
				}
				else
				{
					object objectValue = RuntimeHelpers.GetObjectValue(swDMDocument.GetCustomPropertyNames());
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
					{
						AddPropertyNamesFromEnumerable(list, objectValue);
					}
					SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
					object objectValue3 = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
					{
						foreach (object item2 in (IEnumerable)objectValue3)
						{
							object objectValue4 = RuntimeHelpers.GetObjectValue(item2);
							SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)configurationManager.GetConfigurationByName(Conversions.ToString(objectValue4));
							if (Information.IsNothing(swDMConfiguration))
							{
								continue;
							}
							objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetCustomPropertyNames());
							if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
							{
								continue;
							}
							AddPropertyNamesFromEnumerable(list, objectValue);
						}
					}
					swDMDocument.CloseDoc();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				err = $"Document Manager не смог импортировать свойства из папки: {list2[num2]}\r\n{ex2.Message}";
				logopathlist.WriteLog(err);
				ProjectData.ClearProjectError();
			}
			goto IL_0445;
			IL_0445:
			num2 = checked(num2 + 1);
		}
		return list;
	}

	internal List<string> GetPropertyNames3()
	{
		_Closure_0024__94 closure_0024__ = new _Closure_0024__94();
		List<string> list = new List<string>();
		if (!code.RunSW(HideWindow: false, startnew: false))
		{
			MessageBox.Show("Сначала откройте SolidWorks", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return list;
		}
		checked
		{
			try
			{
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { true }, null, null);
				object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(code.swApp, null, "GetFirstDocument", new object[0], null, null, null));
				while (objectValue != null)
				{
					string text = Conversions.ToString(NewLateBinding.LateGet(objectValue, null, "GetPathName", new object[0], null, null, null));
					if (!text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase) && !text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					string[] array = (string[])NewLateBinding.LateGet(objectValue, null, "GetConfigurationNames", new object[0], null, null, null);
					array = (string[])Utils.CopyArray(array, new string[Information.UBound(array) + 1 + 1]);
					array[Information.UBound(array)] = "";
					object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Extension", new object[0], null, null, null));
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text2 = array2[i];
						object[] array3 = new object[1] { text2 };
						object[] arguments = array3;
						bool[] array4 = new bool[1] { true };
						object obj = NewLateBinding.LateGet(objectValue2, null, "CustomPropertyManager", arguments, null, null, array4);
						if (array4[0])
						{
							text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
						}
						object objectValue3 = RuntimeHelpers.GetObjectValue(obj);
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue3)))
						{
							continue;
						}
						string[] array5 = (string[])NewLateBinding.LateGet(objectValue3, null, "GetNames", new object[0], null, null, null);
						if (Information.IsNothing(array5))
						{
							continue;
						}
						string[] array6 = array5;
						for (int j = 0; j < array6.Length; j++)
						{
							closure_0024__._0024VB_0024Local_vCustPropName = array6[j];
							if (!list.Exists(closure_0024__._Lambda_0024__154))
							{
								list.Add(closure_0024__._0024VB_0024Local_vCustPropName);
							}
						}
					}
					objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "GetNext", new object[0], null, null, null));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				ProjectData.ClearProjectError();
			}
			finally
			{
				NewLateBinding.LateSet(code.swApp, null, "CommandInProgress", new object[1] { false }, null, null);
			}
			return list;
		}
	}

	internal void getasmfrompath(string sDocFileName)
	{
		int num;
		if (Strings.InStr(Strings.LCase(sDocFileName), "sldprt") > 0)
		{
			num = 1;
		}
		else if (Strings.InStr(Strings.LCase(sDocFileName), "sldasm") > 0)
		{
			num = 2;
		}
		else
		{
			if (Strings.InStr(Strings.LCase(sDocFileName), "slddrw") <= 0)
			{
				num = 0;
				return;
			}
			num = 3;
		}
		string text = code.SplitStr(sDocFileName, 3) + ".txt";
		SwDMApplication swDMApplication = swDocMgr;
		int docType = num;
		int num2 = default(int);
		SwDmDocumentOpenError result = (SwDmDocumentOpenError)num2;
		SwDMDocument document = swDMApplication.GetDocument(sDocFileName, (SwDmDocumentType)docType, allowReadOnly: true, out result);
		num2 = (int)result;
		SwDMDocument14 swDMDocument = (SwDMDocument14)document;
		if (!Information.IsNothing(swDMDocument))
		{
			string activeConfigurationName = swDMDocument.ConfigurationManager.GetActiveConfigurationName();
			sw = new StreamWriter(text, append: false, Encoding.UTF8);
			SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
			SwDMConfiguration7 swDMConfiguration = (SwDMConfiguration7)configurationManager.GetConfigurationByName(activeConfigurationName);
			object objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetComponents());
			using (sw)
			{
				sw.WriteLine("Уровень\tpathname\tcfgname\tExcludeFromBOM\tIsEnvelope\tIsVirtual\tSelectName");
				sw.WriteLine(Conversions.ToString(0) + "\t" + sDocFileName + "\t" + activeConfigurationName + "\t\t\t\t");
				int num3 = Information.UBound((Array)objectValue);
				int num4 = 0;
				while (true)
				{
					int num5 = num4;
					int num6 = num3;
					if (num5 <= num6)
					{
						SwDMComponent9 vComponents = (SwDMComponent9)NewLateBinding.LateIndexGet(objectValue, new object[1] { num4 }, null);
						TraverseAsm_BySWDM(vComponents, 1);
						num4 = checked(num4 + 1);
						continue;
					}
					break;
				}
			}
		}
		Process.Start(text);
	}

	public void GetDataByBom(string sDocFileName)
	{
		try
		{
			FilePathNameArr.Clear();
			CfgNameArr.Clear();
			CountqutysArr.Clear();
			NLevelArr.Clear();
			Sb_bomdata.Clear();
			Sb_Feature.Clear();
			int num = 0;
			SwDMConfigurationMgr swDMConfigurationMgr = null;
			object references = null;
			object configurations = null;
			object sstates = null;
			object IsVirtual = null;
			int num2;
			if (Strings.InStr(Strings.LCase(sDocFileName), "sldprt") > 0)
			{
				num2 = 1;
			}
			else if (Strings.InStr(Strings.LCase(sDocFileName), "sldasm") > 0)
			{
				num2 = 2;
			}
			else
			{
				if (Strings.InStr(Strings.LCase(sDocFileName), "slddrw") <= 0)
				{
					num2 = 0;
					return;
				}
				num2 = 3;
			}
			SwDMApplication swDMApplication = swDocMgr;
			int docType = num2;
			int num3 = default(int);
			SwDmDocumentOpenError result = (SwDmDocumentOpenError)num3;
			SwDMDocument document = swDMApplication.GetDocument(sDocFileName, (SwDmDocumentType)docType, allowReadOnly: true, out result);
			num3 = (int)result;
			SwDMDocument14 swDMDocument = (SwDMDocument14)document;
			if (Information.IsNothing(swDMDocument))
			{
				return;
			}
			string activeConfigurationName = swDMDocument.ConfigurationManager.GetActiveConfigurationName();
			if (num2 == 2)
			{
				SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)swDMConfigurationMgr.GetConfigurationByName(activeConfigurationName);
				swDMConfiguration.GetReferencesInformation2(out references, out configurations, out sstates, out IsVirtual);
			}
			int num4 = 2;
			swDMConfigurationMgr = swDMDocument.ConfigurationManager;
			string[] array = (string[])swDMConfigurationMgr.GetConfigurationNames();
			checked
			{
				switch (num2)
				{
				case 1:
				{
					if (true)
					{
						NewConfigNames = new string[1];
						NewConfigNames[0] = "";
						string[] array2 = array;
						foreach (string text in array2)
						{
							NewConfigNames = (string[])Utils.CopyArray(NewConfigNames, new string[Information.UBound(NewConfigNames) + 1 + 1]);
							NewConfigNames[Information.UBound(NewConfigNames)] = text;
						}
					}
					else
					{
						NewConfigNames = new string[1];
						NewConfigNames[0] = activeConfigurationName;
					}
					int num5 = Information.UBound(NewConfigNames) + 1;
					break;
				}
				case 2:
				{
					NewConfigNames = new string[1];
					NewConfigNames[0] = activeConfigurationName;
					SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)swDMConfigurationMgr.GetConfigurationByName(activeConfigurationName);
					swDMConfiguration.GetReferencesInformation2(out references, out configurations, out sstates, out IsVirtual);
					int num5 = Information.UBound((Array)references);
					break;
				}
				case 3:
					NewConfigNames = new string[1];
					NewConfigNames[0] = "";
					break;
				default:
					return;
				}
				Sb_Feature.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
				Sb_Feature.AppendLine("<Tree>");
				Sb_Feature.AppendLine("<Node PathName=\"" + code.ToHexString(sDocFileName) + "\" ConfigureName=\"" + code.ToHexString(NewConfigNames[0]) + "\" IsSuppressed=\"" + Conversions.ToString(Value: false) + "\" ExcludeFromBOM=\"" + Conversions.ToString(Value: false) + "\" DisplayInBOM=\"" + Conversions.ToString(num4) + "\" FeatureName=\"" + code.ToHexString(code.SplitStr(sDocFileName, 1)) + "\" >");
				string[] newConfigNames = NewConfigNames;
				foreach (string text2 in newConfigNames)
				{
					if (num2 == 1)
					{
						num++;
					}
					Sb_bomdata.AppendLine("PathFileName\u001e\u001c" + sDocFileName);
					Sb_bomdata.AppendLine("ConfigureName\u001e\u001c" + text2);
					Sb_bomdata.AppendLine("NLevel\u001e\u001c0");
					if (num2 == 2)
					{
						Sb_bomdata.AppendLine("DataFromAsm\u001e\u001c" + true);
					}
					Sb_bomdata.AppendLine("Quantity\u001e\u001c1");
					Sb_bomdata.AppendLine(">");
				}
				if (num2 == 2)
				{
					num = 0;
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(references)))
					{
						int num6 = Information.UBound((Array)references);
						int num7 = 0;
						while (true)
						{
							int num8 = num7;
							int num9 = num6;
							if (num8 > num9)
							{
								break;
							}
							num++;
							TraFeature(NewLateBinding.LateIndexGet(references, new object[1] { num7 }, null).ToString(), NewLateBinding.LateIndexGet(configurations, new object[1] { num7 }, null).ToString(), NewLateBinding.LateIndexGet(sstates, new object[1] { num7 }, null).ToString(), NewLateBinding.LateIndexGet(IsVirtual, new object[1] { num7 }, null).ToString());
							num7++;
						}
					}
				}
				Sb_Feature.AppendLine("</Node>");
				Sb_Feature.AppendLine("</Tree>");
				if (CountqutysArr.Count > 0)
				{
					int num10 = CountqutysArr.Count - 1;
					int num11 = 0;
					while (true)
					{
						int num12 = num11;
						int num9 = num10;
						if (num12 > num9)
						{
							break;
						}
						Sb_bomdata.Replace("\r\nQuantity#\u001e\u001c" + Conversions.ToString(num11) + "\r\n", "\r\nQuantity\u001e\u001c" + CountqutysArr[num11] + "\r\n");
						num11++;
					}
				}
				object swApp = code.swApp;
				object[] array3 = new object[1];
				object[] array4 = array3;
				object instance = swDMDocument;
				array4[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(instance, null, "GetPathName", new object[0], null, null, null));
				object[] array5 = array3;
				object[] arguments = array5;
				bool[] array6 = new bool[1] { true };
				NewLateBinding.LateCall(swApp, null, "ActivateDoc", arguments, null, null, array6, IgnoreReturn: true);
				if (array6[0])
				{
					NewLateBinding.LateSetComplex(instance, null, "GetPathName", new object[1] { RuntimeHelpers.GetObjectValue(array5[0]) }, null, null, OptimisticSet: true, RValueBase: false);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	public void TraFeature(string sDocFileName, string cfgname, string sstate = "", string IsVirtual = "", int level = 0)
	{
		_Closure_0024__95 closure_0024__ = new _Closure_0024__95();
		closure_0024__._0024VB_0024Local_cfgname = cfgname;
		object references = null;
		object configurations = null;
		object sstates = null;
		object IsVirtual2 = null;
		try
		{
			int num;
			if (Strings.InStr(Strings.LCase(sDocFileName), "sldprt") > 0)
			{
				num = 1;
			}
			else if (Strings.InStr(Strings.LCase(sDocFileName), "sldasm") > 0)
			{
				num = 2;
			}
			else
			{
				if (Strings.InStr(Strings.LCase(sDocFileName), "slddrw") <= 0)
				{
					num = 0;
					return;
				}
				num = 3;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			int num2 = 0;
			bool flag4 = false;
			Sb_Feature.AppendLine("<Node PathName=\"" + code.ToHexString(sDocFileName) + "\" ConfigureName=\"" + code.ToHexString(closure_0024__._0024VB_0024Local_cfgname) + "\" IsSuppressed=\"" + sstate + "\" ExcludeFromBOM=\"\" DisplayInBOM=\"" + Conversions.ToString(num2) + "\" FeatureName=\"\" >");
			SwDMApplication swDMApplication = swDocMgr;
			int docType = num;
			int num3 = default(int);
			SwDmDocumentOpenError result = (SwDmDocumentOpenError)num3;
			SwDMDocument document = swDMApplication.GetDocument(sDocFileName, (SwDmDocumentType)docType, allowReadOnly: true, out result);
			num3 = (int)result;
			SwDMDocument14 swDMDocument = (SwDMDocument14)document;
			checked
			{
				if (!Information.IsNothing(swDMDocument))
				{
					SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
					string[] source = (string[])configurationManager.GetConfigurationNames();
					if (!source.ToList().Exists(closure_0024__._Lambda_0024__155))
					{
						closure_0024__._0024VB_0024Local_cfgname = configurationManager.GetActiveConfigurationName();
					}
					if (FilePathNameArr.Count > 0)
					{
						int num4 = FilePathNameArr.Count - 1;
						int num5 = 0;
						while (true)
						{
							int num6 = num5;
							int num7 = num4;
							if (num6 > num7)
							{
								break;
							}
							if (((true && FilePathNameArr[num5].Equals(sDocFileName, StringComparison.OrdinalIgnoreCase) && CfgNameArr[num5].Equals(closure_0024__._0024VB_0024Local_cfgname, StringComparison.OrdinalIgnoreCase)) || (false && FilePathNameArr[num5].Equals(sDocFileName, StringComparison.OrdinalIgnoreCase))) ? true : false)
							{
								flag = true;
								CountqutysArr[num5] = Conversions.ToString(Conversions.ToDouble(CountqutysArr[num5]) + 1.0);
								break;
							}
							num5++;
						}
					}
					if (!flag)
					{
						FilePathNameArr.Add(sDocFileName);
						NLevelArr.Add(Conversions.ToString(level));
						CfgNameArr.Add(closure_0024__._0024VB_0024Local_cfgname);
						CountqutysArr.Add(Conversions.ToString(1));
						Sb_bomdata.AppendLine("PathFileName\u001e\u001c" + sDocFileName);
						Sb_bomdata.AppendLine("ConfigureName\u001e\u001c" + closure_0024__._0024VB_0024Local_cfgname);
						Sb_bomdata.AppendLine("NLevel\u001e\u001c" + Conversions.ToString(level));
						Sb_bomdata.AppendLine("Quantity#\u001e\u001c" + Conversions.ToString(FilePathNameArr.Count - 1));
						Sb_bomdata.AppendLine(">");
					}
					if ((num == 2 && !flag2) ? true : false)
					{
						SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)configurationManager.GetConfigurationByName(closure_0024__._0024VB_0024Local_cfgname);
						swDMConfiguration.GetReferencesInformation2(out references, out configurations, out sstates, out IsVirtual2);
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(references)))
						{
							int num8 = Information.UBound((Array)references);
							int num9 = 0;
							while (true)
							{
								int num10 = num9;
								int num7 = num8;
								if (num10 > num7)
								{
									break;
								}
								TraFeature(NewLateBinding.LateIndexGet(references, new object[1] { num9 }, null).ToString(), NewLateBinding.LateIndexGet(configurations, new object[1] { num9 }, null).ToString(), NewLateBinding.LateIndexGet(sstates, new object[1] { num9 }, null).ToString(), NewLateBinding.LateIndexGet(IsVirtual2, new object[1] { num9 }, null).ToString(), level + 1);
								num9++;
							}
						}
					}
				}
				Sb_Feature.AppendLine("</Node>");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void TraverseAsm_BySWDM(SwDMComponent9 vComponents, int level)
	{
		object obj = null;
		object obj2 = null;
		object obj3 = null;
		object obj4 = null;
		try
		{
			_Closure_0024__96 closure_0024__ = new _Closure_0024__96();
			if (Information.IsNothing(vComponents))
			{
				return;
			}
			string pathName = vComponents.PathName;
			closure_0024__._0024VB_0024Local_cfgname = vComponents.ConfigurationName;
			int num;
			if (Strings.InStr(Strings.LCase(pathName), "sldprt") > 0)
			{
				num = 1;
			}
			else if (Strings.InStr(Strings.LCase(pathName), "sldasm") > 0)
			{
				num = 2;
			}
			else
			{
				if (Strings.InStr(Strings.LCase(pathName), "slddrw") <= 0)
				{
					num = 0;
					return;
				}
				num = 3;
			}
			sw.WriteLine(Strings.Space(checked(4 * level)) + Conversions.ToString(level) + "\t" + pathName + "\t" + closure_0024__._0024VB_0024Local_cfgname + "\t" + Conversions.ToString(vComponents.ExcludeFromBOM) + "\t" + Conversions.ToString(vComponents.IsEnvelope()) + "\t" + Conversions.ToString(vComponents.IsVirtual) + "\t" + vComponents.SelectName);
			SwDMApplication swDMApplication = swDocMgr;
			int docType = num;
			int num2 = default(int);
			SwDmDocumentOpenError result = (SwDmDocumentOpenError)num2;
			SwDMDocument document = swDMApplication.GetDocument(pathName, (SwDmDocumentType)docType, allowReadOnly: true, out result);
			num2 = (int)result;
			SwDMDocument14 swDMDocument = (SwDMDocument14)document;
			if (Information.IsNothing(swDMDocument))
			{
				return;
			}
			SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
			string[] source = (string[])configurationManager.GetConfigurationNames();
			if (!source.ToList().Exists(closure_0024__._Lambda_0024__156))
			{
				closure_0024__._0024VB_0024Local_cfgname = configurationManager.GetActiveConfigurationName();
			}
			if (num != 2)
			{
				return;
			}
			SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)configurationManager.GetConfigurationByName(closure_0024__._0024VB_0024Local_cfgname);
			object objectValue = RuntimeHelpers.GetObjectValue(swDMConfiguration.GetComponents());
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				return;
			}
			int num3 = Information.UBound((Array)objectValue);
			int num4 = 0;
			checked
			{
				while (true)
				{
					int num5 = num4;
					int num6 = num3;
					if (num5 <= num6)
					{
						SwDMComponent9 vComponents2 = (SwDMComponent9)NewLateBinding.LateIndexGet(objectValue, new object[1] { num4 }, null);
						TraverseAsm_BySWDM(vComponents2, level + 1);
						num4++;
						continue;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	internal void exportimg(string sDocFileName)
	{
		int num;
		if (Strings.InStr(Strings.LCase(sDocFileName), "sldprt") > 0)
		{
			num = 1;
		}
		else if (Strings.InStr(Strings.LCase(sDocFileName), "sldasm") > 0)
		{
			num = 2;
		}
		else
		{
			if (Strings.InStr(Strings.LCase(sDocFileName), "slddrw") <= 0)
			{
				num = 0;
				return;
			}
			num = 3;
		}
		if (num == 3)
		{
			return;
		}
		SwDMApplication swDMApplication = swDocMgr;
		int docType = num;
		int num2 = default(int);
		SwDmDocumentOpenError result = (SwDmDocumentOpenError)num2;
		SwDMDocument document = swDMApplication.GetDocument(sDocFileName, (SwDmDocumentType)docType, allowReadOnly: true, out result);
		num2 = (int)result;
		SwDMDocument swDMDocument = document;
		SwDMConfigurationMgr configurationManager = swDMDocument.ConfigurationManager;
		object objectValue = RuntimeHelpers.GetObjectValue(configurationManager.GetConfigurationNames());
		foreach (object item in (IEnumerable)objectValue)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(item);
			SwDMConfiguration8 swDMConfiguration = (SwDMConfiguration8)configurationManager.GetConfigurationByName(Conversions.ToString(objectValue2));
			SwDmPreviewError result2 = (SwDmPreviewError)num2;
			object previewBitmap = swDMConfiguration.GetPreviewBitmap(out result2);
			num2 = (int)result2;
			object objectValue3 = RuntimeHelpers.GetObjectValue(previewBitmap);
			Image image = PictureDispConverter.Convert(RuntimeHelpers.GetObjectValue(objectValue3));
			NewLateBinding.LateCall(image, null, "Save", new object[2]
			{
				Operators.AddObject(Operators.AddObject(Operators.AddObject(code.SplitStr(sDocFileName, 3) + "(", objectValue2), ")"), ".PNG"),
				ImageFormat.Bmp
			}, null, null, null, IgnoreReturn: true);
			image.Dispose();
		}
		swDMDocument.Save();
		swDMDocument.CloseDoc();
	}
}
