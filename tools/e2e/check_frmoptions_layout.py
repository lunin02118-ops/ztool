#!/usr/bin/env python3
"""Guard the main Options dialog against clipped Russian tab layouts."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
ConfigureResponsiveLayout();
private int Dpi(int value)
{
}
private void ConfigureResponsiveLayout()
{
    ApplyFont(this, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204));
    FormBorderStyle = FormBorderStyle.Sizable;
    MaximizeBox = true;
    MinimizeBox = true;
    MinimumSize = new Size(Dpi(900), Dpi(560));
    if (ClientSize.Width < Dpi(880) || ClientSize.Height < Dpi(520))
    {
        ClientSize = new Size(Math.Max(ClientSize.Width, Dpi(880)), Math.Max(ClientSize.Height, Dpi(520)));
    }
    SizeGripStyle = SizeGripStyle.Show;
    TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    ListBox1.Dock = DockStyle.Fill;
    TextBox1.Dock = DockStyle.Fill;
    private sealed class ColorListItem
    internal string GetSelectedRowColorName()
    private static string TranslateColorName(string name)
    return "Светло-голубой";
    e.DrawBackground();
    string text = GetColorDisplayName(item);
    string colorName = GetColorName(item);
    TextRenderer.DrawText(e.Graphics, text, rowcolor.Font, bounds, foreColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
}
private void ApplyResponsiveLayout()
{
    LayoutGeneralTab();
    LayoutSketchTab();
    LayoutMaterialTab();
    LayoutUserListTab();
    LayoutMacroTab();
}
private void LayoutSketchTab()
{
    Thumbnail_Savetolocal.AutoSize = false;
    SetBoundsDpi(Button3, 20, 160, 240, 32);
    SetBoundsDpi(Button7, 280, 160, 260, 32);
}
private void LayoutGeneralTab()
{
    SetBoundsDpi(Label3, 20, 24, 230, 24);
    SetBoundsDpi(rowcolor, 260, 22, num2, 26);
    SetBoundsDpi(Label1, 20, 64, 230, 24);
    SetBoundsDpi(SwVer, 260, 62, num2, 26);
}
private void LayoutUserListTab()
{
    Label13.AutoSize = false;
    Label15.AutoSize = false;
    SetBoundsDpi(Label13, 20, 20, num - 40, 42);
    SetBoundsDpi(Panel1, 20, 102, num3, Math.Max(190, num2 - 134));
    SetBoundsDpi(Panel2, 40 + num3, 102, num4, Math.Max(190, num2 - 134));
}
private void LayoutMacroTab()
{
    SetBoundsDpi(Panel3, Math.Max(460, num - 170), 20, 150, 180);
    Panel3.AutoScroll = false;
    SetBoundsDpi(Button8, 0, 0, 150, 36);
    SetBoundsDpi(Button9, 0, 52, 150, 36);
    SetBoundsDpi(Button10, 0, 104, 90, 36);
    SetBoundsDpi(Button11, 0, 156, 90, 36);
}
'''

BAD_FIXTURE = r'''
InitializeComponent();
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
this.MinimizeBox = false;
MinimumSize = new Size(Dpi(760), Dpi(540));
SetBoundsDpi(Label3, 20, 24, 130, 24);
SetBoundsDpi(rowcolor, 160, 22, 280, 26);
SetBoundsDpi(Panel3, Math.Max(400, num - 130), 20, 110, 180);
resources.ApplyResources(this.TabControl1, "TabControl1");
resources.ApplyResources(this.Button3, "Button3");
resources.ApplyResources(this.Button7, "Button7");
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "DPI helper": "private int Dpi(int value)",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "responsive apply method": "private void ApplyResponsiveLayout()",
        "Segoe UI font": 'new Font("Segoe UI"',
        "sizable border": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "minimize enabled": "MinimizeBox = true;",
        "minimum size": "MinimumSize = new Size(Dpi(900), Dpi(560));",
        "default client width guard": "ClientSize.Width < Dpi(880)",
        "default client height guard": "ClientSize.Height < Dpi(520)",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "tab control stretch": "TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;",
        "bottom buttons anchor": "TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;",
        "options page layout": "LayoutGeneralTab();",
        "sketch page layout": "LayoutSketchTab();",
        "material page layout": "LayoutMaterialTab();",
        "user list page layout": "LayoutUserListTab();",
        "macro page layout": "LayoutMacroTab();",
        "general tab row color label width": "SetBoundsDpi(Label3, 20, 24, 230, 24);",
        "general tab row color combo width": "SetBoundsDpi(rowcolor, 260, 22, num2, 26);",
        "general tab SolidWorks label width": "SetBoundsDpi(Label1, 20, 64, 230, 24);",
        "general tab SolidWorks combo width": "SetBoundsDpi(SwVer, 260, 62, num2, 26);",
        "sketch save checkbox fixed width": "Thumbnail_Savetolocal.AutoSize = false;",
        "reset sketch button width": "SetBoundsDpi(Button3, 20, 160, 240, 32);",
        "open sketch folder button width": "SetBoundsDpi(Button7, 280, 160, 260, 32);",
        "user list instruction fixed width": "Label13.AutoSize = false;",
        "user list instruction full width": "SetBoundsDpi(Label13, 20, 20, num - 40, 42);",
        "user list title fixed width": "Label15.AutoSize = false;",
        "user list left panel stretch": "SetBoundsDpi(Panel1, 20, 102, num3, Math.Max(190, num2 - 134));",
        "user list right panel stretch": "SetBoundsDpi(Panel2, 40 + num3, 102, num4, Math.Max(190, num2 - 134));",
        "macro button panel width": "SetBoundsDpi(Panel3, Math.Max(460, num - 170), 20, 150, 180);",
        "macro button panel no internal scroll": "Panel3.AutoScroll = false;",
        "add macro file button width": "SetBoundsDpi(Button8, 0, 0, 150, 36);",
        "delete selected macro button width": "SetBoundsDpi(Button9, 0, 52, 150, 36);",
        "move macro up button width": "SetBoundsDpi(Button10, 0, 104, 90, 36);",
        "move macro down button width": "SetBoundsDpi(Button11, 0, 156, 90, 36);",
        "list box fills panel": "ListBox1.Dock = DockStyle.Fill;",
        "dropdown text fills panel": "TextBox1.Dock = DockStyle.Fill;",
        "color combo keeps internal color identity": "private sealed class ColorListItem",
        "color combo exposes stable color name": "internal string GetSelectedRowColorName()",
        "color combo translates visible names": "private static string TranslateColorName(string name)",
        "LightCyan localized": 'return "Светло-голубой";',
        "color combo clears full owner-draw bounds": "e.DrawBackground();",
        "color combo draws display name": "string text = GetColorDisplayName(item);",
        "color combo uses internal color name": "string colorName = GetColorName(item);",
        "color combo centered text": "TextRenderer.DrawText(e.Graphics, text, rowcolor.Font, bounds, foreColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    forbidden_tokens = (
        '"宋体"',
        '"微软雅黑"',
        "FormBorderStyle.FixedDialog",
        "MaximizeBox = false",
        "MinimizeBox = false",
        "e.Graphics.FillRectangle(SystemBrushes.Highlight, rect)",
        "e.Graphics.FillRectangle(SystemBrushes.Window, rect)",
        "Color.FromName(MyProject.Forms.FrmOptions.rowcolor.Text)",
        "MinimumSize = new Size(Dpi(760), Dpi(540));",
        "SetBoundsDpi(Label3, 20, 24, 130, 24);",
        "SetBoundsDpi(rowcolor, 160, 22, 280, 26);",
        "SetBoundsDpi(Panel3, Math.Max(400, num - 130), 20, 110, 180);",
    )
    for token in forbidden_tokens:
        if token in source:
            issues.append(f"forbidden fixed/legacy layout token: {token}")
    return issues


def run_self_test() -> None:
    good_issues = analyze(GOOD_FIXTURE)
    if good_issues:
        raise SystemExit(f"self-test good fixture failed: {good_issues}")
    bad_issues = analyze(BAD_FIXTURE)
    if not bad_issues:
        raise SystemExit("self-test bad fixture unexpectedly passed")
    print("self-test PASS")


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "FrmOptions.cs"))
    parser.add_argument("--main-source", default=str(Path("client-src") / ("Z" + "Tool") / "Frmmain.cs"))
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        run_self_test()
        return 0

    source_path = Path(args.source)
    source = source_path.read_text(encoding="utf-8-sig")
    main_source_path = Path(args.main_source)
    issues = analyze(source)
    if main_source_path.exists():
        main_source = main_source_path.read_text(encoding="utf-8-sig")
        if "Color.FromName(MyProject.Forms.FrmOptions.rowcolor.Text)" in main_source:
            issues.append("forbidden color application token in Frmmain.cs: Color.FromName(MyProject.Forms.FrmOptions.rowcolor.Text)")
    if issues:
        for issue in issues:
            safe_issue = issue.encode("ascii", "backslashreplace").decode("ascii")
            print(f"FAIL: {safe_issue}")
        return 1
    print(f"PASS: options dialog responsive tab layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
