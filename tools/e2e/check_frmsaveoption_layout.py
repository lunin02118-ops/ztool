#!/usr/bin/env python3
"""Guard the save-options dialog against clipped Russian layout."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
ConfigureResponsiveLayout();
private int Dpi(int value)
{
    return (int)Math.Round((double)value * _dpixRatio);
}
private void ConfigureResponsiveLayout()
{
    ApplyFont(this, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204));
    FormBorderStyle = FormBorderStyle.Sizable;
    MaximizeBox = true;
    MaximumSize = Size.Empty;
    MinimumSize = new Size(Dpi(760), Dpi(430));
    SizeGripStyle = SizeGripStyle.Show;
    Save_Changed.Size = new Size(Dpi(220), Dpi(28));
    Save_Failed.Size = new Size(Dpi(200), Dpi(28));
    base.Resize += FrmSaveOption_ResponsiveResize;
    ApplyResponsiveLayout();
}
private void ApplyResponsiveLayout()
{
    GroupBox1.SetBounds(margin, margin, leftWidth, contentHeight);
    GroupBox2.SetBounds(rightX, margin, rightWidth, Dpi(166));
    GroupBox3.SetBounds(rightX, GroupBox2.Bottom + gap, rightWidth, Math.Max(Dpi(122), bottomTop - GroupBox2.Bottom - gap - margin));
    SetCheckBoxBounds(CheckBox4, Dpi(10), Dpi(25), rightInnerWidth);
    Label2.AutoSize = false;
    Label2.SetBounds(Dpi(10), Dpi(80), rightInnerWidth, Dpi(22));
    Label3.AutoSize = false;
    Label3.SetBounds(Dpi(10), Dpi(58), group3InnerWidth, Dpi(22));
    TextBox1.SetBounds(Dpi(10), Dpi(83), Button1.Left - Dpi(16), Dpi(25));
    TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(224)));
    TableLayoutPanel1.SetBounds(ClientSize.Width - Dpi(668), bottomTop, Dpi(656), Dpi(34));
    Button2.SetBounds(margin, bottomTop + Dpi(2), Dpi(96), Dpi(28));
}
private void SetCheckBoxBounds(CheckBox checkBox, int x, int y, int width)
{
    checkBox.AutoSize = false;
}
'''

BAD_FIXTURE = r'''
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
size = new System.Drawing.Size(575, 333);
this.ClientSize = size;
size = new System.Drawing.Size(100, 26);
save_Changed3.Size = size;
size = new System.Drawing.Size(55, 26);
button3.Size = size;
this.CheckBox4.Text = "Перезаписывать файлы с тем же именем (осторожно)";
this.CheckBox4.Size = new System.Drawing.Size(159, 21);
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "DPI helper": "private int Dpi(int value)",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "responsive apply method": "private void ApplyResponsiveLayout()",
        "Segoe UI font": 'new Font("Segoe UI"',
        "sizable form": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "no fixed maximum": "MaximumSize = Size.Empty;",
        "minimum size": "MinimumSize = new Size(Dpi(760), Dpi(430));",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "changed button width": "Save_Changed.Size = new Size(Dpi(220), Dpi(28));",
        "failed button width": "Save_Failed.Size = new Size(Dpi(200), Dpi(28));",
        "resize hook": "base.Resize += FrmSaveOption_ResponsiveResize;",
        "left group layout": "GroupBox1.SetBounds(margin, margin, leftWidth, contentHeight);",
        "rename group layout": "GroupBox2.SetBounds(rightX, margin, rightWidth, Dpi(166));",
        "link group layout": "GroupBox3.SetBounds(rightX, GroupBox2.Bottom + gap, rightWidth, Math.Max(Dpi(122), bottomTop - GroupBox2.Bottom - gap - margin));",
        "long checkbox stretch": "SetCheckBoxBounds(CheckBox4, Dpi(10), Dpi(25), rightInnerWidth);",
        "rename label fixed layout": "Label2.AutoSize = false;",
        "rename label width": "Label2.SetBounds(Dpi(10), Dpi(80), rightInnerWidth, Dpi(22));",
        "folder label fixed layout": "Label3.AutoSize = false;",
        "folder label width": "Label3.SetBounds(Dpi(10), Dpi(58), group3InnerWidth, Dpi(22));",
        "folder path stretch": "TextBox1.SetBounds(Dpi(10), Dpi(83), Button1.Left - Dpi(16), Dpi(25));",
        "wide final button column": "TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(224)));",
        "bottom buttons area": "TableLayoutPanel1.SetBounds(ClientSize.Width - Dpi(668), bottomTop, Dpi(656), Dpi(34));",
        "help button width": "Button2.SetBounds(margin, bottomTop + Dpi(2), Dpi(96), Dpi(28));",
        "checkbox autosize disabled": "checkBox.AutoSize = false;",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    forbidden_tokens = (
        "FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;",
        "MaximizeBox = false",
        "new System.Drawing.Size(575, 333)",
        "Save_Changed.Size = new System.Drawing.Size(100, 26)",
        "Button2.Size = new System.Drawing.Size(55, 26)",
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
            print(f"FAIL: {issue}")
        return 1
    print(f"PASS: save-options dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
