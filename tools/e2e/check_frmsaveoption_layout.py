#!/usr/bin/env python3
"""Guard the save-options dialog against clipped Russian controls."""

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
    MinimumSize = new Size(Dpi(900), Dpi(520));
    ClientSize.Width < Dpi(860)
    SizeGripStyle = SizeGripStyle.Show;
    CheckBox1.AutoSize = false;
    CheckBox9.AutoSize = false;
    Label2.AutoSize = false;
    LinkLabel1.AutoSize = false;
    TableLayoutPanel1.AutoSize = false;
    TableLayoutPanel1.ColumnStyles.Clear();
    TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(210)));
    TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(230)));
    FitButton(Save_Failed);
    FitButton(Save_Changed);
}
private void ApplyResponsiveLayout()
private void LayoutSavePropertiesGroup()
private void LayoutRenameGroup()
private void LayoutReferencesGroup()
CheckBox1.SetBounds(Dpi(14), Dpi(134), num, Dpi(26));
ComboBox2.SetBounds(Dpi(14), Dpi(162), num, Dpi(27));
CheckBox4.SetBounds(Dpi(12), Dpi(24), num, Dpi(24));
TextBox1.SetBounds(Dpi(12), Dpi(84), Math.Max(Dpi(280), GroupBox3.ClientSize.Width - Dpi(56)), Dpi(27));
'''

BAD_FIXTURE = r'''
InitializeComponent();
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
this.MinimizeBox = false;
size = new System.Drawing.Size(575, 333);
size = new System.Drawing.Size(100, 26);
this.CheckBox1.Text = "и удалить лишние свойства из следующего расположения";
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
        "minimum size": "MinimumSize = new Size(Dpi(900), Dpi(520));",
        "default width guard": "ClientSize.Width < Dpi(860)",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "delete-extra checkbox fixed width": "CheckBox1.AutoSize = false;",
        "delete-current-place checkbox fixed width": "CheckBox9.AutoSize = false;",
        "rename label fixed width": "Label2.AutoSize = false;",
        "target path link fixed width": "LinkLabel1.AutoSize = false;",
        "button panel fixed layout": "TableLayoutPanel1.AutoSize = false;",
        "button columns reset": "TableLayoutPanel1.ColumnStyles.Clear();",
        "save failed button width": "TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(210)));",
        "save changed button width": "TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(230)));",
        "save failed button fill": "FitButton(Save_Failed);",
        "save changed button fill": "FitButton(Save_Changed);",
        "save properties group layout": "private void LayoutSavePropertiesGroup()",
        "rename group layout": "private void LayoutRenameGroup()",
        "references group layout": "private void LayoutReferencesGroup()",
        "delete-extra checkbox full width": "CheckBox1.SetBounds(Dpi(14), Dpi(134), num, Dpi(26));",
        "delete-extra scope combo full width": "ComboBox2.SetBounds(Dpi(14), Dpi(162), num, Dpi(27));",
        "overwrite checkbox full width": "CheckBox4.SetBounds(Dpi(12), Dpi(24), num, Dpi(24));",
        "reference path field stretch": "TextBox1.SetBounds(Dpi(12), Dpi(84), Math.Max(Dpi(280), GroupBox3.ClientSize.Width - Dpi(56)), Dpi(27));",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    forbidden_tokens = (
        "FormBorderStyle.FixedDialog",
        "MaximizeBox = false",
        "MinimizeBox = false",
        "size = new System.Drawing.Size(575, 333)",
        "size = new System.Drawing.Size(100, 26)",
        '"微软雅黑"',
        '"宋体"',
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "FrmSaveOption.cs"))
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
            safe_issue = issue.encode("ascii", "backslashreplace").decode("ascii")
            print(f"FAIL: {safe_issue}")
        return 1
    print(f"PASS: save-options dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
