#!/usr/bin/env python3
"""Guard the file-name rule dialog layout against fixed/clipped Russian UI."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
ConfigureResponsiveLayout();
private void ConfigureResponsiveLayout()
{
    FormBorderStyle = FormBorderStyle.Sizable;
    MaximizeBox = true;
    MinimumSize = new Size(Dpi(720), Dpi(520));
    SizeGripStyle = SizeGripStyle.Show;
    Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
    GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
    TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(156)));
}
'''

BAD_FIXTURE = r'''
this.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 134);
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "sizable border": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "minimum size": "MinimumSize = new Size(Dpi(720), Dpi(520));",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "Segoe UI font": 'Font = new Font("Segoe UI"',
        "rule textbox anchor": "TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;",
        "instruction group anchor": "GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;",
        "rule group anchor": "GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;",
        "bottom buttons layout": "TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")
    for forbidden in ('"宋体"', '"微软雅黑"', "FormBorderStyle.FixedDialog", "MaximizeBox = false"):
        if forbidden in source:
            issues.append(f"forbidden fixed/legacy layout token: {forbidden}")
    if 'this.Button1.Text = "Вставить ссылку....";' in source:
        issues.append("button text still uses four-dot ellipsis")
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "FrmRename.cs"))
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
    print(f"PASS: file-name rule dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
