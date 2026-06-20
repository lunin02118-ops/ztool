using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ZTool;

public class ShortcutHelper
{
	[DebuggerNonUserCode]
	public ShortcutHelper()
	{
	}

	public void CreateDesktopShortcut1(string targetPath, string shortcutName, string description = "", string arguments = "", string iconPath = "")
	{
		try
		{
			if (!File.Exists(targetPath))
			{
				MessageBox.Show("Целевая программа не существует!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string text = Path.Combine(folderPath, shortcutName + ".lnk");
			object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("WScript.Shell"));
			object[] array = new object[1] { text };
			object[] arguments2 = array;
			bool[] array2 = new bool[1] { true };
			object obj = NewLateBinding.LateGet(objectValue, null, "CreateShortcut", arguments2, null, null, array2);
			if (array2[0])
			{
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			object objectValue2 = RuntimeHelpers.GetObjectValue(obj);
			NewLateBinding.LateSet(objectValue2, null, "TargetPath", new object[1] { targetPath }, null, null);
			NewLateBinding.LateSet(objectValue2, null, "WorkingDirectory", new object[1] { Path.GetDirectoryName(targetPath) }, null, null);
			if (!string.IsNullOrEmpty(arguments))
			{
				NewLateBinding.LateSet(objectValue2, null, "Arguments", new object[1] { arguments }, null, null);
			}
			if ((!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath)) ? true : false)
			{
				NewLateBinding.LateSet(objectValue2, null, "IconLocation", new object[1] { iconPath }, null, null);
			}
			else
			{
				NewLateBinding.LateSet(objectValue2, null, "IconLocation", new object[1] { targetPath }, null, null);
			}
			if (!string.IsNullOrEmpty(description))
			{
				NewLateBinding.LateSet(objectValue2, null, "Description", new object[1] { description }, null, null);
			}
			NewLateBinding.LateCall(objectValue2, null, "Save", new object[0], null, null, null, IgnoreReturn: true);
			MessageBox.Show("Ярлык успешно создан!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("创建快捷方式失败：\r\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void CreateDesktopShortcut2(string targetPath, string shortcutName, string description = "", string arguments = "", string iconPath = "")
	{
		try
		{
			if (!File.Exists(targetPath))
			{
				MessageBox.Show("Не удалось создать ярлык:\r\nцелевая программа не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string text = Path.Combine(folderPath, shortcutName + ".lnk");
			string directoryName = Path.GetDirectoryName(targetPath);
			string text2 = text.Replace("'", "''");
			string text3 = targetPath.Replace("'", "''");
			string text4 = directoryName.Replace("'", "''");
			string text5 = description.Replace("'", "''");
			string text6 = arguments.Replace("'", "''");
			string text7 = "";
			text7 = (((string.IsNullOrEmpty(iconPath) || !File.Exists(iconPath)) && 0 == 0) ? text3 : iconPath.Replace("'", "''"));
			string format = "$WshShell = New-Object -ComObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut('{0}'); $Shortcut.TargetPath = '{1}'; $Shortcut.WorkingDirectory = '{2}'; $Shortcut.IconLocation = '{3}'; $Shortcut.Description = '{4}'; $Shortcut.Arguments = '{5}'; $Shortcut.Save();";
			string text8 = string.Format(format, text2, text3, text4, text7, text5, text6);
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "powershell.exe";
			processStartInfo.Arguments = "-NoProfile -ExecutionPolicy Bypass -Command \"" + text8 + "\"";
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.RedirectStandardError = true;
			processStartInfo.RedirectStandardOutput = true;
			using (Process process = Process.Start(processStartInfo))
			{
				process.WaitForExit();
				if (process.ExitCode != 0)
				{
					string text9 = process.StandardError.ReadToEnd();
					if (string.IsNullOrEmpty(text9))
					{
						text9 = process.StandardOutput.ReadToEnd();
					}
					throw new Exception("PowerShell 执行失败 (ExitCode: " + process.ExitCode + "): " + text9);
				}
			}
			MessageBox.Show("Ярлык успешно создан!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("创建快捷方式失败：\r\n" + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}
}
