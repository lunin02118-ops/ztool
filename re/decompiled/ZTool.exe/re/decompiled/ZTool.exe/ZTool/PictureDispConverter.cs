using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ZTool;

public class PictureDispConverter : AxHost
{
	public PictureDispConverter()
		: base("56174C86-1546-4778-8EE6-B6AC606875E7")
	{
	}

	public static Image Convert(object objIDispImage)
	{
		return AxHost.GetPictureFromIPicture(RuntimeHelpers.GetObjectValue(objIDispImage));
	}
}
