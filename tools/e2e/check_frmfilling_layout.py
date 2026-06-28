#!/usr/bin/env python3
"""Guard the fill-column dialog search tab against clipped Russian UI."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
ConfigureResponsiveLayout();
base.Resize += FrmFilling_ResponsiveResize;
private int Dpi(int value)
private void ConfigureResponsiveLayout()
{
    ApplyFont(this, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204));
    FormBorderStyle = FormBorderStyle.Sizable;
    MaximizeBox = true;
    MinimizeBox = true;
    MinimumSize = new Size(Dpi(700), Dpi(500));
    if (ClientSize.Width < Dpi(680) || ClientSize.Height < Dpi(460))
    SizeGripStyle = SizeGripStyle.Show;
    TabControl1.SizeMode = TabSizeMode.Normal;
    TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    TabPage3.AutoScroll = true;
    ConfigureSearchTabLayout();
    ConfigureFooterLayout();
    ApplyResponsiveLayout();
}
private void ConfigureSearchTabLayout()
{
    Button2.AutoSize = false;
    Label15.AutoSize = false;
}
private void ConfigureFooterLayout()
{
    TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(96)));
}
private void LayoutSearchTab()
{
    SetBoundsDpi(GroupBox4, 12, 10, (int)Math.Round((double)num / dpixRatio), 132);
    SetBoundsDpi(GroupBox6, 12, 156, (int)Math.Round((double)num / dpixRatio), 128);
    SetBoundsDpi(Button2, 224, 63, 152, 30);
    SetBoundsDpi(Label15, 12, 100, 220, 24);
    SetBoundsDpi(ComboBox3, 278, 30, (int)Math.Round((double)num3 / dpixRatio), 26);
    SetBoundsDpi(ComboBox4, 328, 72, (int)Math.Round((double)Math.Max(Dpi(220), GroupBox6.ClientSize.Width - Dpi(340)) / dpixRatio), 26);
}
private void TabControl1_Selected(object sender, TabControlEventArgs e)
{
    TableLayoutPanel2.Visible = true;
    ConfigureResponsiveLayout();
}
'''

BAD_FIXTURE = r'''
InitializeComponent();
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
this.TabControl1.ItemSize = new System.Drawing.Size(72, 22);
this.Button2.AutoSize = true;
this.Label15.AutoSize = true;
this.Label15.Location = new System.Drawing.Point(240, 67);
this.Button2.Size = new System.Drawing.Size(66, 27);
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive hook": "ConfigureResponsiveLayout();",
        "resize hook": "base.Resize += FrmFilling_ResponsiveResize;",
        "DPI helper": "private int Dpi(int value)",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "Segoe UI font": 'new Font("Segoe UI", 9f',
        "sizable border": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "minimize enabled": "MinimizeBox = true;",
        "minimum size": "MinimumSize = new Size(Dpi(700), Dpi(500));",
        "default width guard": "ClientSize.Width < Dpi(680)",
        "default height guard": "ClientSize.Height < Dpi(460)",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "normal tab sizing": "TabControl1.SizeMode = TabSizeMode.Normal;",
        "tab control stretch": "TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;",
        "search page scroll": "TabPage3.AutoScroll = true;",
        "search tab static layout": "private void ConfigureSearchTabLayout()",
        "search tab dynamic layout": "private void LayoutSearchTab()",
        "source group height": "SetBoundsDpi(GroupBox4, 12, 10",
        "search group moved below source": "SetBoundsDpi(GroupBox6, 12, 156",
        "update data button width": "SetBoundsDpi(Button2, 224, 63, 152, 30);",
        "cache label own row": "SetBoundsDpi(Label15, 12, 100, 220, 24);",
        "first search combo stretch": "SetBoundsDpi(ComboBox3, 278, 30",
        "second search combo stretch": "SetBoundsDpi(ComboBox4, 328, 72",
        "update data no autosize": "Button2.AutoSize = false;",
        "cache label no autosize": "Label15.AutoSize = false;",
        "footer relayout": "private void ConfigureFooterLayout()",
        "bottom buttons absolute columns": "TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(96)));",
        "tab selection keeps footer visible": "TableLayoutPanel2.Visible = true;",
        "tab selection keeps responsive layout": "ConfigureResponsiveLayout();",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    selected_method = ""
    marker = "private void TabControl1_Selected"
    start = source.find(marker)
    if start >= 0:
        end = source.find("\n\tprivate void", start + len(marker))
        selected_method = source[start : end if end >= 0 else len(source)]
    if "FormBorderStyle.FixedDialog" in selected_method:
        issues.append("tab selection still forces FixedDialog")
    if "TabControl1.Dock = DockStyle.Top;" in selected_method:
        issues.append("tab selection still forces fixed top docking")

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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "FrmFilling.cs"))
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        run_self_test()
        return 0

    source_path = Path(args.source)
    source = source_path.read_text(encoding="utf-8-sig")
    issues = analyze(source)
    if issues:
        for issue in issues:
            print(f"FAIL: {issue}")
        return 1
    print(f"PASS: fill-column search tab responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
