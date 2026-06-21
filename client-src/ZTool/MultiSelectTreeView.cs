using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ZTool;

public class MultiSelectTreeView : TreeView
{
	private static List<WeakReference> __ENCList = new List<WeakReference>();

	private List<Treenode> selectedNodelist;

	private Treenode lastSelectedNode;

	private bool isCtrlPressed;

	private bool isShiftPressed;

	private MouseButtons MouseButton;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ExStyle |= 33554432;
			return createParams;
		}
	}

	public List<Treenode> SelectedNodes => selectedNodelist;

	[DebuggerNonUserCode]
	private static void __ENCAddToList(object value)
	{
		checked
		{
			lock (__ENCList)
			{
				if (__ENCList.Count == __ENCList.Capacity)
				{
					int num = 0;
					int num2 = __ENCList.Count - 1;
					int num3 = 0;
					while (true)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						WeakReference weakReference = __ENCList[num3];
						if (weakReference.IsAlive)
						{
							if (num3 != num)
							{
								__ENCList[num] = __ENCList[num3];
							}
							num++;
						}
						num3++;
					}
					__ENCList.RemoveRange(num, __ENCList.Count - num);
					__ENCList.Capacity = __ENCList.Count;
				}
				__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
			}
		}
	}

	public MultiSelectTreeView()
	{
		__ENCAddToList(this);
		selectedNodelist = new List<Treenode>();
		lastSelectedNode = null;
		isCtrlPressed = false;
		isShiftPressed = false;
		MouseButton = MouseButtons.None;
		DrawMode = TreeViewDrawMode.OwnerDrawText;
		HideSelection = false;
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		UpdateStyles();
	}

	protected override void OnInvalidated(InvalidateEventArgs e)
	{
		base.OnInvalidated(e);
		if (e.InvalidRect != ClientRectangle)
		{
			Update();
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		isCtrlPressed = e.Control;
		isShiftPressed = e.Shift;
		if (e.KeyCode == Keys.Escape)
		{
			selectedNodelist.Clear();
			lastSelectedNode = null;
			SelectedNode = null;
			Invalidate();
			e.Handled = true;
		}
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		isCtrlPressed = e.Control;
		isShiftPressed = e.Shift;
	}

	protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
	{
		base.OnNodeMouseClick(e);
		MouseButton = e.Button;
		if (e.Button == MouseButtons.Right)
		{
			TreeNode nodeAt = GetNodeAt(e.X, e.Y);
			if (nodeAt != null)
			{
				SelectedNode = nodeAt;
			}
		}
	}

	private void ToggleNodeSelection(Treenode node)
	{
		if (selectedNodelist.Contains(node))
		{
			selectedNodelist.Remove(node);
		}
		else
		{
			selectedNodelist.Add(node);
		}
	}

	private void SelectSingleNode(Treenode node)
	{
		selectedNodelist.Clear();
		selectedNodelist.Add(node);
		SelectedNode = node;
	}

	private void SelectRange(Treenode startNode, Treenode endNode)
	{
		selectedNodelist.Clear();
		List<Treenode> allVisibleNodes = GetAllVisibleNodes();
		int num = allVisibleNodes.IndexOf(startNode);
		int num2 = allVisibleNodes.IndexOf(endNode);
		if (num == -1 || num2 == -1)
		{
			return;
		}
		if (num > num2)
		{
			int num3 = num;
			num = num2;
			num2 = num3;
		}
		int num4 = num;
		int num5 = num2;
		int num6 = num4;
		while (true)
		{
			int num7 = num6;
			int num8 = num5;
			if (num7 > num8)
			{
				break;
			}
			selectedNodelist.Add(allVisibleNodes[num6]);
			num6 = checked(num6 + 1);
		}
		SelectedNode = endNode;
	}

	private List<Treenode> GetAllVisibleNodes()
	{
		List<Treenode> list = new List<Treenode>();
		AddVisibleNodes(Nodes, list);
		return list;
	}

	private void AddVisibleNodes(TreeNodeCollection collection, List<Treenode> list)
	{
		foreach (Treenode item in collection)
		{
			list.Add(item);
			if (item.IsExpanded)
			{
				AddVisibleNodes(item.Nodes, list);
			}
		}
	}

	protected override void OnDrawNode(DrawTreeNodeEventArgs e)
	{
		base.OnDrawNode(e);
		if ((e.Node == null || e.Bounds.Width <= 0 || e.Bounds.Height <= 0) ? true : false)
		{
			return;
		}
		Color color;
		Color foreColor;
		if (selectedNodelist.Contains((Treenode)e.Node))
		{
			object obj = Interaction.IIf(e.Node == SelectedNode, SystemColors.MenuHighlight, SystemColors.Highlight);
			Color color2 = default(Color);
			color = ((obj != null) ? ((Color)obj) : color2);
			foreColor = SystemColors.HighlightText;
		}
		else
		{
			color = BackColor;
			foreColor = e.Node.ForeColor;
		}
		using (SolidBrush brush = new SolidBrush(color))
		{
			e.Graphics.FillRectangle(brush, e.Bounds);
		}
		TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, e.Bounds, foreColor, TextFormatFlags.Default);
		if ((e.Node == SelectedNode && Focused) ? true : false)
		{
			Color greenYellow = Color.GreenYellow;
			using Pen pen = new Pen(greenYellow, 2f);
			ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, pen.Color, pen.Color);
		}
	}

	protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
	{
		base.OnBeforeSelect(e);
	}

	protected override void OnAfterSelect(TreeViewEventArgs e)
	{
		base.OnAfterSelect(e);
		if ((isCtrlPressed && MouseButton == MouseButtons.Left) ? true : false)
		{
			ToggleNodeSelection((Treenode)e.Node);
			lastSelectedNode = (Treenode)e.Node;
		}
		else if ((isShiftPressed && MouseButton == MouseButtons.Left) ? true : false)
		{
			if (lastSelectedNode != null)
			{
				SelectRange(lastSelectedNode, (Treenode)e.Node);
			}
			else
			{
				SelectSingleNode((Treenode)e.Node);
			}
		}
		else
		{
			if (!selectedNodelist.Contains((Treenode)e.Node))
			{
				SelectSingleNode((Treenode)e.Node);
			}
			lastSelectedNode = (Treenode)e.Node;
		}
		Invalidate();
		isShiftPressed = false;
		isCtrlPressed = false;
		MouseButton = MouseButtons.None;
	}
}
