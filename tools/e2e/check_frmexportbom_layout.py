#!/usr/bin/env python3
"""Guard the BOM scheme dialog layout against fixed/clipped Russian UI."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
ConfigureResponsiveLayout();
private int Dpi(int value)
private void ConfigureResponsiveLayout()
{
    ApplyFont(this, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204));
    FormBorderStyle = FormBorderStyle.Sizable;
    MaximizeBox = true;
    MinimizeBox = true;
    MinimumSize = new Size(Dpi(1220), Dpi(620));
    SizeGripStyle = SizeGripStyle.Show;
    TableLayoutPanel1.ColumnStyles.Clear();
    Button1.Dock = DockStyle.Fill;
    edit.Dock = DockStyle.Fill;
    Label1.AutoSize = false;
    RadioButton3.AutoSize = false;
    includetop.AutoSize = false;
    lockratio.AutoSize = false;
}
private void ApplyResponsiveLayout()
private void LayoutMainShell()
private void LayoutSpecTypeGroup()
private void LayoutPropertyGroup()
private void LayoutSketchGroup()
private void LayoutRuleGroup()
'''

BAD_FIXTURE = r'''
InitializeComponent();
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.GroupBox1.Size = new System.Drawing.Size(112, 152);
this.edit.Size = new System.Drawing.Size(53, 27);
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "DPI helper": "private int Dpi(int value)",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "responsive apply method": "private void ApplyResponsiveLayout()",
        "Segoe UI font": 'new Font("Segoe UI", 9f',
        "sizable border": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "minimize enabled": "MinimizeBox = true;",
        "minimum size": "MinimumSize = new Size(Dpi(1220), Dpi(620));",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "bottom buttons relayout": "TableLayoutPanel1.ColumnStyles.Clear();",
        "bottom buttons fill": "Button1.Dock = DockStyle.Fill;",
        "scheme buttons fill": "edit.Dock = DockStyle.Fill;",
        "long spec type label fixed width": "RadioButton3.AutoSize = false;",
        "long option label fixed width": "includetop.AutoSize = false;",
        "long sketch label fixed width": "lockratio.AutoSize = false;",
        "main shell layout": "private void LayoutMainShell()",
        "spec type layout": "private void LayoutSpecTypeGroup()",
        "property group layout": "private void LayoutPropertyGroup()",
        "sketch group layout": "private void LayoutSketchGroup()",
        "rule group layout": "private void LayoutRuleGroup()",
        "template label fixed width": "Label1.AutoSize = false;",
        "browse button fixed width": "Button3.AutoSize = false;",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    forbidden_tokens = (
        "FormBorderStyle.FixedDialog",
        "MaximizeBox = false",
        "MinimizeBox = false",
        "size = new System.Drawing.Size(112, 152)",
        "size = new System.Drawing.Size(172, 152)",
        "size = new System.Drawing.Size(192, 360)",
        "size = new System.Drawing.Size(45, 27)",
        "size = new System.Drawing.Size(53, 27)",
    )
    for token in forbidden_tokens:
        if token in source:
            issues.append(f"forbidden fixed/clipped layout token: {token}")
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "Frmexportbom.cs"))
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
    print(f"PASS: BOM scheme dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
