#!/usr/bin/env python3
"""Guard the document-kind filter against leaking internal Han keys to UI."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
private string DisplayDocumentKindForFilter(string value)
{
    string text = (value ?? string.Empty).Trim();
    return string.Equals(text, "零件", StringComparison.OrdinalIgnoreCase) ? "Деталь" : text;
}

private string FilterDocumentKindFromDisplay(string value)
{
    string text = (value ?? string.Empty).Trim();
    return string.Equals(text, "Деталь", StringComparison.OrdinalIgnoreCase) ? "零件" : text;
}

string item = (columnindex == Col_Extname.Index) ? FilterDocumentKindFromDisplay(Clb.Items[num9].ToString()) : Clb.Items[num9].ToString();
string item = (columnindex == Col_Extname.Index) ? FilterDocumentKindFromDisplay(Clb.Items[num21].ToString()) : Clb.Items[num21].ToString();
if (SelectedCol == Col_Extname.Index)
{
    text = DisplayDocumentKindForFilter(text);
}
Clb.AddItem(text, StringComparison.CurrentCultureIgnoreCase);
'''

BAD_FIXTURE = r'''
private string DisplayDocumentKindForFilter(string value)
{
    return value;
}

private string FilterDocumentKindFromDisplay(string value)
{
    return value;
}

Clb.AddItem(text, StringComparison.CurrentCultureIgnoreCase);
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    if "DisplayDocumentKindForFilter" not in source:
        issues.append("missing DisplayDocumentKindForFilter")
    if "string text = (value ?? string.Empty).Trim();" not in source:
        issues.append("document-kind mapping must trim values before display/raw comparison")
    if 'string.Equals(value, "零件"' not in source or '"Деталь"' not in source:
        if 'string.Equals(text, "零件"' not in source or '"Деталь"' not in source:
            issues.append("missing raw-to-display mapping: 零件 -> Деталь")
    if "FilterDocumentKindFromDisplay" not in source:
        issues.append("missing FilterDocumentKindFromDisplay")
    if 'string.Equals(value, "Деталь"' not in source or '"零件"' not in source:
        if 'string.Equals(text, "Деталь"' not in source or '"零件"' not in source:
            issues.append("missing display-to-raw mapping: Деталь -> 零件")
    if "text = DisplayDocumentKindForFilter(text);" not in source:
        issues.append("filter checklist values are not display-mapped before Clb.AddItem")
    if source.count("FilterDocumentKindFromDisplay(Clb.Items[") < 2:
        issues.append("filter apply paths do not map checklist display values back to raw document-kind keys")
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "Frmmain.cs"))
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
    print(f"PASS: document-kind filter display mapping is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
