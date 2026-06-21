#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Static localization gate: fail if any tracked file or directory name
contains CJK (Han / fullwidth) characters.

Part of Tier 1 pre-release acceptance (see docs/release/FULL_TEST_METHODOLOGY_RU.md
area M / LOC). After full russification of the runtime tree the released package
must not ship Chinese-named files or folders. This check is intentionally about
*names* only; UI-string localization is covered by localization_scan.py.

Usage:
  python tools/check_no_cjk_filenames.py
Exit code 0 = no CJK in any tracked path, 1 = at least one offending path.
"""
import re
import subprocess
import sys

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")

# CJK Unified Ideographs (+ Ext A), CJK symbols/punctuation, Hiragana/Katakana,
# and Halfwidth/Fullwidth forms. Latin/Cyrillic/digits are allowed.
CJK = re.compile(
    r"[\u3000-\u303f\u3040-\u30ff\u3400-\u4dbf\u4e00-\u9fff\uff00-\uffef]"
)


def tracked_paths():
    out = subprocess.run(
        ["git", "ls-files", "-z"],
        capture_output=True, check=True,
    ).stdout
    for raw in out.split(b"\x00"):
        if raw:
            yield raw.decode("utf-8", "surrogateescape")


def main():
    offenders = []
    for path in tracked_paths():
        # Check every path segment so an offending directory is reported too.
        for segment in path.split("/"):
            if CJK.search(segment):
                offenders.append(path)
                break
    if offenders:
        print("FAIL: %d tracked path(s) contain CJK characters:" % len(offenders))
        for p in sorted(set(offenders)):
            print("  -", p)
        print(
            "\nRename these to Latin/Cyrillic. The release runtime tree must not "
            "ship Chinese-named files or folders."
        )
        return 1
    print("PASS: no CJK characters in any tracked file or directory name.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
