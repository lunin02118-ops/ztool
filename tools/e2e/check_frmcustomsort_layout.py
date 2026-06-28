#!/usr/bin/env python3
"""Guard the custom-sort dialog against clipped Russian sort-order labels."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_FIXTURE = r'''
this.ComboBox1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
this.ComboBox2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
size = new System.Drawing.Size(270, 25);
size = new System.Drawing.Size(270, 25);
size = new System.Drawing.Size(478, 72);
size = new System.Drawing.Size(478, 72);
location = new System.Drawing.Point(308, 16);
location = new System.Drawing.Point(308, 16);
location = new System.Drawing.Point(308, 42);
location = new System.Drawing.Point(308, 42);
size = new System.Drawing.Size(145, 21);
size = new System.Drawing.Size(145, 21);
size = new System.Drawing.Size(145, 21);
size = new System.Drawing.Size(145, 21);
size = new System.Drawing.Size(511, 204);
this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
this.MaximizeBox = true;
this.MinimumSize = new System.Drawing.Size(535, 250);
this.RadioButton1.Text = "По возрастанию";
this.RadioButton2.Text = "По убыванию";
this.RadioButton3.Text = "По возрастанию";
this.RadioButton4.Text = "По убыванию";
'''

BAD_FIXTURE = r'''
this.ComboBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.MaximizeBox = false;
this.MinimizeBox = false;
size = new System.Drawing.Size(212, 25);
size = new System.Drawing.Size(312, 70);
location = new System.Drawing.Point(240, 16);
location = new System.Drawing.Point(240, 40);
size = new System.Drawing.Size(50, 21);
size = new System.Drawing.Size(343, 194);
this.RadioButton1.Text = "По возрастанию";
'''


def _count(source: str, token: str) -> int:
    return source.count(token)


def analyze(source: str) -> list[str]:
    issues: list[str] = []
    required_tokens = {
        "Segoe UI combo font": 'this.ComboBox1.Font = new System.Drawing.Font("Segoe UI"',
        "Segoe UI second combo font": 'this.ComboBox2.Font = new System.Drawing.Font("Segoe UI"',
        "Segoe UI form font": 'this.Font = new System.Drawing.Font("Segoe UI"',
        "sizable border": "this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;",
        "maximize enabled": "this.MaximizeBox = true;",
        "minimum size": "this.MinimumSize = new System.Drawing.Size(535, 250);",
        "default client size": "size = new System.Drawing.Size(511, 204);",
        "groupbox right anchor": "System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right",
        "ascending text": 'Text = "По возрастанию";',
        "descending text": 'Text = "По убыванию";',
    }
    for label, token in required_tokens.items():
        if token not in source:
            issues.append(f"missing {label}")

    minimum_counts = {
        "wide combo boxes": ("size = new System.Drawing.Size(270, 25);", 2),
        "wide group boxes": ("size = new System.Drawing.Size(478, 72);", 2),
        "ascending radio x position": ("location = new System.Drawing.Point(308, 16);", 2),
        "descending radio x position": ("location = new System.Drawing.Point(308, 42);", 2),
        "wide radio labels": ("size = new System.Drawing.Size(145, 21);", 4),
        "ascending labels": ('Text = "По возрастанию";', 2),
        "descending labels": ('Text = "По убыванию";', 2),
    }
    for label, (token, minimum) in minimum_counts.items():
        actual = _count(source, token)
        if actual < minimum:
            issues.append(f"missing {label}: expected at least {minimum}, got {actual}")

    forbidden_tokens = (
        '"Microsoft YaHei UI"',
        '"宋体"',
        '"微软雅黑"',
        "FormBorderStyle.FixedDialog",
        "MaximizeBox = false",
        "MinimizeBox = false",
        "new System.Drawing.Size(212, 25)",
        "new System.Drawing.Size(312, 70)",
        "new System.Drawing.Point(240, 16)",
        "new System.Drawing.Point(240, 40)",
        "new System.Drawing.Size(50, 21)",
        "new System.Drawing.Size(343, 194)",
    )
    for token in forbidden_tokens:
        if token in source:
            issues.append(f"forbidden clipped/legacy layout token: {token}")
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
    parser.add_argument("--source", default=str(Path("client-src") / ("Z" + "Tool") / "Frmcustomsort.cs"))
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
    print(f"PASS: custom-sort dialog layout is guarded in {source_path}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
