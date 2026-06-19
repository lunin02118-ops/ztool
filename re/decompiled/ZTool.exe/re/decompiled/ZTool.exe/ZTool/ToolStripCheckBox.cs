using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;

namespace ZTool;

[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
public class ToolStripCheckBox : ToolStripItem
{
	private bool IsChecked;

	public bool HasChecked
	{
		get
		{
			return IsChecked;
		}
		set
		{
			IsChecked = value;
			Invalidate();
		}
	}

	public ToolStripCheckBox()
	{
		IsChecked = false;
	}

	public override Size GetPreferredSize(Size constrainingSize)
	{
		base.GetPreferredSize(constrainingSize);
		Size preferredSize = base.GetPreferredSize(constrainingSize);
		checked
		{
			preferredSize.Width += 13;
			return preferredSize;
		}
	}

	protected override void OnClick(EventArgs e)
	{
		IsChecked = !IsChecked;
		base.OnClick(e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		checked
		{
			if (base.Owner != null)
			{
				Point glyphLocation = new Point(e.ClipRectangle.X, unchecked(e.ClipRectangle.Height / 2) - 6);
				Size size = TextRenderer.MeasureText(Text, Font);
				Rectangle textBounds = new Rectangle(glyphLocation.X + 13, glyphLocation.Y, size.Width, size.Height);
				CheckBoxState checkBoxState = ((!IsChecked) ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal);
				CheckBoxRenderer.DrawCheckBox(e.Graphics, glyphLocation, textBounds, Text, Font, focused: false, checkBoxState);
			}
		}
	}
}
