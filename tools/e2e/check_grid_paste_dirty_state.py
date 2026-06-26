#!/usr/bin/env python3
"""Guard grid clipboard paste so pasted cells are saved by SaveToSW."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
public static object PasteExcel(DataGridView DGV)
{
    text = text.TrimEnd('\n');
    string[] array = text.Split('\n');
    int changedCells = 0;
    changedCells += SetPastedCellValue(DGV, columnIndex, rowIndex, array2[0]);
    return changedCells;
}

private static int SetPastedCellValue(DataGridView DGV, int columnIndex, int rowIndex, string rawValue)
{
    string text = NormalizeClipboardCellText(rawValue);
    dataGridViewCell.Value = text;
    MarkPastedCellAsModified(DGV, columnIndex, rowIndex);
    return 1;
}

private static string NormalizeClipboardCellText(string value)
{
    return value.Replace('\u00a0', ' ').Replace("\ufeff", "").Replace("\u200b", "").Replace("\u200c", "").Replace("\u200d", "").Normalize(NormalizationForm.FormKC);
}

private static void MarkPastedCellAsModified(DataGridView DGV, int columnIndex, int rowIndex)
{
    DGV[columnIndex, rowIndex].Style.ForeColor = Color.DarkOrange;
    if (ShouldPasteMarkRowChanged(columnIndex))
    {
        DGV.Rows[rowIndex].Tag = "true";
    }
}
'''

BAD_FIXTURE = r'''
public static object PasteExcel(DataGridView DGV)
{
    text.TrimEnd('\n');
    string[] array = text.Split('\n');
    if (array.Length <= 1)
    {
        return 0;
    }
    DGV[columnIndex, rowIndex].Value = array2[0];
    return 0;
}
'''


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    if "text = text.TrimEnd('\\n');" not in source:
        issues.append("clipboard trailing row separator is not assigned back after TrimEnd")
    if "array.Length <= 1" in source:
        issues.append("single-cell clipboard paste is still rejected")
    for token in (
        "SetPastedCellValue(",
        "NormalizeClipboardCellText(",
        "MarkPastedCellAsModified(",
        "ShouldPasteMarkRowChanged(",
    ):
        if token not in source:
            issues.append(f"missing paste helper: {token}")
    for token in (
        "dataGridViewCell.Value = text;",
        'DGV.Rows[rowIndex].Tag = "true";',
        "DGV[columnIndex, rowIndex].Style.ForeColor = Color.DarkOrange;",
        "NormalizationForm.FormKC",
        "Replace('\\u00a0', ' ')",
        'Replace("\\ufeff", "")',
        'Replace("\\u200b", "")',
    ):
        if token not in source:
            issues.append(f"missing paste dirty/normalization invariant: {token}")
    if "return num2;" not in source and "return changedCells;" not in source:
        issues.append("PasteExcel does not return changed-cell count")
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "code.cs"))
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
    print(f"PASS: grid clipboard paste dirty-state is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
