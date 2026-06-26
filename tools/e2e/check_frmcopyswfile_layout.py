#!/usr/bin/env python3
"""Guard the backup-copy dialog against clipped Russian layout."""

from __future__ import annotations

import argparse
import re
from pathlib import Path


GOOD_FIXTURE = r'''
ConfigureResponsiveLayout();
private int Dpi(int value)
{
}
private void ConfigureResponsiveLayout()
{
    ApplyFont(this, new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204));
    FormBorderStyle = FormBorderStyle.SizableToolWindow;
    MaximizeBox = true;
    MinimumSize = new Size(Dpi(760), Dpi(430));
    mediumsize = new Size(Dpi(760), Dpi(620));
    SizeGripStyle = SizeGripStyle.Show;
}
private void ApplyResponsiveLayout()
{
    Panel1.Height = Dpi(292);
    c_folder.SetBounds(num, Dpi(42), Math.Max(Dpi(360), ClientSize.Width - Dpi(64)), Dpi(25));
    c_Browse.SetBounds(c_folder.Right + Dpi(4), Dpi(41), Dpi(32), Dpi(27));
    c_addprefix.AutoSize = false;
    c_addprefix.SetBounds(num, Dpi(78), Dpi(150), Dpi(24));
    c_prefix.SetBounds(Dpi(170), Dpi(77), Dpi(165), Dpi(25));
    c_addsuffix.AutoSize = false;
    c_addsuffix.SetBounds(Dpi(352), Dpi(78), Dpi(150), Dpi(24));
    c_suffix.SetBounds(Dpi(508), Dpi(77), Math.Max(Dpi(170), ClientSize.Width - Dpi(524)), Dpi(25));
    c_Includeother.AutoSize = false;
    c_Includeother.SetBounds(num, Dpi(166), num2, Dpi(24));
    TableLayoutPanel1.SetBounds(ClientSize.Width - Dpi(174), Dpi(246), Dpi(156), Dpi(36));
}
'''

BAD_FIXTURE = "\n".join(
    [
        'Font = new Font("' + "\u5fae\u8f6f\u96c5\u9ed1" + '", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);',
        "MaximizeBox = false;",
        "MinimumSize = (Size = new Size((int)Math.Round(410.0 * dpixRatio), (int)Math.Round(310.0 * dpixRatio)));",
        "c_addsuffix.AutoSize = true;",
        "c_suffix.SetBounds(Dpi(280), Dpi(75), Dpi(100), Dpi(23));",
    ]
)


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "DPI helper": "private int Dpi(int value)",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "responsive apply method": "private void ApplyResponsiveLayout()",
        "Segoe UI font": 'new Font("Segoe UI"',
        "sizable tool window": "FormBorderStyle = FormBorderStyle.SizableToolWindow;",
        "maximize enabled": "MaximizeBox = true;",
        "minimum dialog size": "MinimumSize = new Size(Dpi(760), Dpi(430));",
        "medium error size": "mediumsize = new Size(Dpi(760), Dpi(620));",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "panel stable height": "Panel1.Height = Dpi(292);",
        "folder field stretch": "c_folder.SetBounds(num, Dpi(42), Math.Max(Dpi(360), ClientSize.Width - Dpi(64)), Dpi(25));",
        "browse follows folder": "c_Browse.SetBounds(c_folder.Right + Dpi(4), Dpi(41), Dpi(32), Dpi(27));",
        "prefix fixed label": "c_addprefix.AutoSize = false;",
        "prefix label width": "c_addprefix.SetBounds(num, Dpi(78), Dpi(150), Dpi(24));",
        "prefix input width": "c_prefix.SetBounds(Dpi(170), Dpi(77), Dpi(165), Dpi(25));",
        "suffix fixed label": "c_addsuffix.AutoSize = false;",
        "suffix label width": "c_addsuffix.SetBounds(Dpi(352), Dpi(78), Dpi(150), Dpi(24));",
        "suffix input stretch": "c_suffix.SetBounds(Dpi(508), Dpi(77), Math.Max(Dpi(170), ClientSize.Width - Dpi(524)), Dpi(25));",
        "long extra-files checkbox": "c_Includeother.SetBounds(num, Dpi(166), num2, Dpi(24));",
        "buttons stay right": "TableLayoutPanel1.SetBounds(ClientSize.Width - Dpi(174), Dpi(246), Dpi(156), Dpi(36));",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    forbidden_tokens = (
        '"' + "\u5fae\u8f6f\u96c5\u9ed1" + '"',
        '"' + "\u5b8b\u4f53" + '"',
        "MaximizeBox = false",
        "MinimumSize = (Size = new Size((int)Math.Round(410.0 * dpixRatio), (int)Math.Round(310.0 * dpixRatio)));",
        "c_addsuffix.AutoSize = true;",
        "c_addprefix.AutoSize = true;",
    )
    for token in forbidden_tokens:
        if token in source:
            issues.append(f"forbidden fixed/legacy token: {token}")

    if re.search(r"[\u4e00-\u9fff]", source):
        issues.append("raw Han characters are not allowed in this dialog source")
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "frm_copyswfile.cs"))
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
    print(f"PASS: backup-copy dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
