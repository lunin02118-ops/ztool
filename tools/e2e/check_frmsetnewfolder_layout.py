#!/usr/bin/env python3
"""Guard the save-to-new-folder dialog against clipped Russian layout."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
ConfigureResponsiveLayout();
private int Dpi(int value)
{
    return checked((int)Math.Round((double)value * dpixRatio));
}
private void ConfigureResponsiveLayout()
{
    FormBorderStyle = FormBorderStyle.Sizable;
    MaximizeBox = true;
    MaximumSize = Size.Empty;
    MinimumSize = new Size(Dpi(660), Dpi(190));
    SizeGripStyle = SizeGripStyle.Show;
    Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
    Label2.AutoSize = false;
    Label3.AutoSize = false;
    TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(180)));
    TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
}
'''

LEGACY_CJK_FONT = "\u5fae\u8f6f\u96c5\u9ed1"

BAD_FIXTURE = f'''
this.Font = new System.Drawing.Font("{LEGACY_CJK_FONT}", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
this.MaximizeBox = false;
this.MaximumSize = new System.Drawing.Size(1500, 166);
this.MinimumSize = new System.Drawing.Size(491, 166);
this.Label2.AutoSize = true;
this.Label3.AutoSize = true;
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "DPI helper": "private int Dpi(int value)",
        "sizable border": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "no fixed maximum": "MaximumSize = Size.Empty;",
        "minimum size": "MinimumSize = new Size(Dpi(660), Dpi(190));",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "Segoe UI font": 'Font = new Font("Segoe UI"',
        "source label fixed layout": "Label2.AutoSize = false;",
        "target label fixed layout": "Label3.AutoSize = false;",
        "source textbox stretch": "TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;",
        "target textbox stretch": "TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;",
        "browse button right anchor": "Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;",
        "left buttons fixed columns": "TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(180)));",
        "right buttons bottom anchor": "TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")
    forbidden_tokens = (
        f'"{LEGACY_CJK_FONT}"',
        "MaximizeBox = false",
        "MaximumSize = size;",
        "new System.Drawing.Size(1500, 166)",
        "new System.Drawing.Size(491, 166)",
        "Label2.AutoSize = true;",
        "Label3.AutoSize = true;",
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "FrmSetNewFolder.cs"))
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
    print(f"PASS: save-to-new-folder dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
