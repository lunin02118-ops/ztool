using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ZTool.CustomFileBorser1;

public class FolderNameEditor : UITypeEditor
{
	[DebuggerNonUserCode]
	public FolderNameEditor()
	{
	}

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		FileBorser fileBorser = new FileBorser();
		if (value != null)
		{
			fileBorser.DirectoryPath = $"{RuntimeHelpers.GetObjectValue(value)}";
		}
		if (fileBorser.ShowDialog(null) == DialogResult.OK)
		{
			return fileBorser.DirectoryPath;
		}
		return value;
	}
}
