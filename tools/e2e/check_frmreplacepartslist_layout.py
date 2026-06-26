#!/usr/bin/env python3
"""Guard the replace-links dialog against clipped Russian layout."""

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
    MinimumSize = new Size(Dpi(1320), Dpi(640));
    SizeGripStyle = SizeGripStyle.Show;
    Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
    SplitContainer1.Panel1MinSize = Dpi(380);
    SplitContainer1.Panel2MinSize = Dpi(900);
    ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    ListView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
    GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    clearsel.MinimumSize = new Size(Dpi(110), Dpi(27));
    clearall.MinimumSize = new Size(Dpi(84), Dpi(27));
}
private void ApplyResponsiveLayout()
{
    ApplyFileListPanelLayout();
    ApplyReplacementPanelLayout();
}
private void ApplyFileListPanelLayout()
{
}
private void ApplyReplacementPanelLayout()
{
}
'''

BAD_FIXTURE = r'''
this.SplitContainer1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
this.MinimumSize = new System.Drawing.Size(800, 600);
this.MaximizeBox = false;
this.GroupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
this.GroupBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "DPI helper": "private int Dpi(int value)",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "responsive apply method": "private void ApplyResponsiveLayout()",
        "left-panel layout method": "private void ApplyFileListPanelLayout()",
        "right-panel layout method": "private void ApplyReplacementPanelLayout()",
        "sizable border": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "no fixed maximum": "MaximumSize = Size.Empty;",
        "minimum dialog size": "MinimumSize = new Size(Dpi(1320), Dpi(640));",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "Segoe UI font": 'Font = new Font("Segoe UI"',
        "splitter left min": "SplitContainer1.Panel1MinSize = Dpi(380);",
        "splitter right min": "SplitContainer1.Panel2MinSize = Dpi(900);",
        "left list stretch": "ListView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;",
        "right list stretch": "ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;",
        "file type group anchor": "GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;",
        "read rule group anchor": "GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;",
        "new reference path group anchor": "GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;",
        "moved components group anchor": "GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;",
        "new path browse right anchor": "Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;",
        "specific folder browse right anchor": "Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;",
        "delete button min width": "clearsel.MinimumSize = new Size(Dpi(110), Dpi(27));",
        "clear button min width": "clearall.MinimumSize = new Size(Dpi(84), Dpi(27));",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    forbidden_tokens = (
        '"Microsoft YaHei UI"',
        '"微软雅黑"',
        '"宋体"',
        "MaximizeBox = false",
        "FormBorderStyle.FixedDialog",
    )
    for token in forbidden_tokens:
        if token in source:
            issues.append(f"forbidden fixed/legacy layout token: {token}")

    if "MinimumSize = new Size(Dpi(1320), Dpi(640));" not in source and "this.MinimumSize = size;" in source:
        issues.append("designer-only minimum size is not overridden by responsive minimum")
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "FrmReplacePartslist.cs"))
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
    print(f"PASS: replace-links dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
