#!/usr/bin/env python3
"""Guard the SolidWorks add-in rename dialog against clipped Russian UI."""

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
    Font font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
    FormBorderStyle = FormBorderStyle.Sizable;
    MaximizeBox = true;
    MaximumSize = Size.Empty;
    MinimumSize = new Size(Dpi(760), Dpi(460));
    SizeGripStyle = SizeGripStyle.Show;
}
private void ApplyResponsiveLayout()
{
    p_103.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(145)));
    p_61.SetBounds(num, num6, num2, Dpi(28));
    p_60.SetBounds(p_64.Right + Dpi(26), num6, Dpi(140), Dpi(28));
    p_59.SetBounds(p_66.Right + Dpi(26), num6, Dpi(130), Dpi(28));
    p_73.SetBounds(Dpi(8), Dpi(8), Dpi(80), Dpi(28));
    p_93.SetBounds(Dpi(8), Dpi(8), Dpi(80), Dpi(28));
    p_76.ScrollBars = ScrollBars.Both;
}
private string NormalizeRenameFieldName(string value, string fallback)
{
    case "$\u56fe\u53f7$":
        return "$Обозначение$";
    case "$\u96f6\u4ef6\u540d\u79f0$":
        return "$Наименование$";
    case "$\u7248\u672c$":
        return "$Версия$";
}
dataGridView.Rows[0].Cells[1].ToolTipText = "$ИмяСвойства$ — свойство файла";
'''

BAD_FIXTURE = "\n".join(
    [
        'Font = new Font("' + "\u5fae\u8f6f\u96c5\u9ed1" + '", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);',
        "MaximizeBox = false;",
        "p_76.ScrollBars = ScrollBars.None;",
        'dataGridView.Rows[0].Cells[1].Value = "$' + "\u56fe\u53f7" + '$";',
        'dataGridView.Rows[0].Cells[1].ToolTipText = "$' + "\u5c5e\u6027\u540d\u79f0" + '$";',
    ]
)


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "responsive layout hook": "ConfigureResponsiveLayout();",
        "DPI helper": "private int Dpi(int value)",
        "responsive method": "private void ConfigureResponsiveLayout()",
        "responsive apply method": "private void ApplyResponsiveLayout()",
        "field-name migration": "private string NormalizeRenameFieldName(string value, string fallback)",
        "sizable border": "FormBorderStyle = FormBorderStyle.Sizable;",
        "maximize enabled": "MaximizeBox = true;",
        "no fixed maximum": "MaximumSize = Size.Empty;",
        "minimum dialog size": "MinimumSize = new Size(Dpi(760), Dpi(460));",
        "size grip": "SizeGripStyle = SizeGripStyle.Show;",
        "Segoe UI font": 'new Font("Segoe UI"',
        "lock-path column width": "p_103.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, Dpi(145)));",
        "assembly-path button width": "p_61.SetBounds(num, num6, num2, Dpi(28));",
        "source-path button width": "p_60.SetBounds(p_64.Right + Dpi(26), num6, Dpi(140), Dpi(28));",
        "browse-path button width": "p_59.SetBounds(p_66.Right + Dpi(26), num6, Dpi(130), Dpi(28));",
        "frequent-path add button width": "p_73.SetBounds(Dpi(8), Dpi(8), Dpi(80), Dpi(28));",
        "reference-folder add button width": "p_93.SetBounds(Dpi(8), Dpi(8), Dpi(80), Dpi(28));",
        "rule grid scrollbars": "p_76.ScrollBars = ScrollBars.Both;",
        "drawing number Russian field": 'return "$Обозначение$";',
        "part name Russian field": 'return "$Наименование$";',
        "version Russian field": 'return "$Версия$";',
        "legacy drawing number migration": r'case "$\u56fe\u53f7$":',
        "legacy part name migration": r'case "$\u96f6\u4ef6\u540d\u79f0$":',
        "legacy version migration": r'case "$\u7248\u672c$":',
        "Russian tooltip": "$ИмяСвойства$ — свойство файла",
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    forbidden_tokens = (
        '"' + "\u5fae\u8f6f\u96c5\u9ed1" + '"',
        '"' + "\u5b8b\u4f53" + '"',
        "$" + "\u56fe\u53f7" + "$",
        "$" + "\u96f6\u4ef6\u540d\u79f0" + "$",
        "$" + "\u7248\u672c" + "$",
        "$" + "\u5c5e\u6027\u540d\u79f0" + "$",
        "MaximizeBox = false",
        "FormBorderStyle.FixedDialog",
        "ScrollBars = ScrollBars.None",
    )
    for token in forbidden_tokens:
        if token in source:
            issues.append(f"forbidden fixed/legacy token: {token}")

    if re.search(r"[\u4e00-\u9fff]", source):
        issues.append("raw Han characters are not allowed in this user-facing dialog source")
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
    parser.add_argument("--source", default=str(Path("client-src-addin") / ("Z" + "Tool") / "ReName.cs"))
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
    print(f"PASS: add-in rename dialog responsive layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
