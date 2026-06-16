#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Phase 11 gate: internal-string invariants of the localized client binaries.

Background (docs/audit/refactor-production-readiness-gap-audit-2026-06-16_RU.md):
the material/colour bug happened because vendor strings were classified by
*language*, not by *role*: the Chinese literal `零件` is a semantic key
(`Col_Extname.Tag` compared at runtime in several `Frmmain` methods), yet it was
treated as translatable UI text. `localization_scan.py` checks for unclassified
Han but does not separate "visible text" from "semantic key".

This gate works on the actual shipped binaries and enforces two invariants:

  1. ALLOW-LIST: every Han string still present in a localized binary's #US heap
     must be explicitly classified in tools/string_invariants/allowed_han.tsv
     (role + note). A NEW unclassified Han string fails the gate — that is a new
     untranslated UI string or a corrupted localization.

  2. REQUIRED KEYS: the semantic vendor keys the runtime compares against (e.g.
     `零件`, the `$...$`/`<...>` naming placeholders) MUST still be present
     (byte-level UTF-16LE) in the binary that owns them. Translating or dropping
     one of these is exactly the regression that broke material colours.

Roles in allowed_han.tsv whose note starts with "REVIEW" are allowed (so the
gate is green on the accepted build) but reprinted in a REVIEW section so a human
can confirm they are intentional rather than missed translations.

Usage:
  python tools/check_string_invariants.py [--root .]
Exit 0 = invariants hold, 1 = violation.
"""
import argparse
import os
import re
import sys

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
from dotnet_strings import extract_us_strings  # noqa: E402

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")

HAN = re.compile(r"[\u3400-\u4dbf\u4e00-\u9fff]")
DATA_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                        "string_invariants")


def load_allowed():
    """Return {string: (role, note)} from allowed_han.tsv. '\\n' is unescaped."""
    allowed = {}
    path = os.path.join(DATA_DIR, "allowed_han.tsv")
    with open(path, encoding="utf-8") as f:
        for line in f:
            line = line.rstrip("\n")
            if not line or line.startswith("#"):
                continue
            parts = line.split("\t")
            text = parts[0].replace("\\n", "\n")
            role = parts[1] if len(parts) > 1 else ""
            note = parts[2] if len(parts) > 2 else ""
            allowed[text] = (role, note)
    return allowed


def load_required():
    """Return list of (binary, key, note) from required_keys.tsv."""
    req = []
    path = os.path.join(DATA_DIR, "required_keys.tsv")
    with open(path, encoding="utf-8") as f:
        for line in f:
            line = line.rstrip("\n")
            if not line or line.startswith("#"):
                continue
            parts = line.split("\t")
            req.append((parts[0], parts[1], parts[2] if len(parts) > 2 else ""))
    return req


def han_us_strings(path):
    return sorted({s for s in extract_us_strings(path) if HAN.search(s)})


def evaluate(han_by_binary, key_counts, allowed, required, emit=lambda *_: None):
    """Pure core. Inputs:
      han_by_binary: {binary: [han #US strings]}
      key_counts:    {(binary, key): occurrence count}
      allowed:       {string: (role, note)}
      required:      [(binary, key, note)]
    Returns (failures, review).
    """
    failures, review = [], []
    for rel, strings in han_by_binary.items():
        emit("\n[#US Han] %s" % rel)
        for s in strings:
            if s not in allowed:
                failures.append("%s: unclassified Han #US string: %r" % (rel, s))
                emit("  UNCLASSIFIED  %r" % s)
                continue
            role, note = allowed[s]
            tag = "REVIEW" if note.startswith("REVIEW") else "ok"
            emit("  %-6s %-14s %r" % (tag, role, s))
            if note.startswith("REVIEW"):
                review.append((rel, role, note, s))

    emit("\n[required vendor keys] (byte-level UTF-16LE presence)")
    for rel, key, note in required:
        n = key_counts.get((rel, key), 0)
        status = "OK" if n > 0 else "MISSING"
        emit("  %-7s %-10s x%-3d %s  (%s)" % (status, rel, n, key, note))
        if n == 0:
            failures.append("%s: required vendor key absent: %r (%s)"
                            % (rel, key, note))
    return failures, review


def self_test():
    allowed = {"零件": ("semantic-key", "internal part-kind key"),
               "修改ToolStripMenuItem": ("control-name", "internal"),
               "宋体": ("font", "font")}
    required = [("ZTool.exe", "零件", "Frmmain material/color key"),
                ("ZTool.dll", "零件", "add-in part-kind key")]
    # good: all Han classified, required key present
    good_f, _ = evaluate({"ZTool.exe": ["零件"],
                          "ZTool.dll": ["零件", "修改ToolStripMenuItem", "宋体"]},
                         {("ZTool.exe", "零件"): 1,
                          ("ZTool.dll", "零件"): 2}, allowed, required)
    # bad #1: the exact production regression - ZTool.exe loses the Frmmain key
    missing_exe_f, _ = evaluate({"ZTool.exe": ["零件"],
                                 "ZTool.dll": ["零件", "宋体"]},
                                {("ZTool.exe", "零件"): 0,
                                 ("ZTool.dll", "零件"): 2}, allowed, required)
    # bad #2: a new unclassified Han string must still fail the allow-list gate
    unclassified_f, _ = evaluate({"ZTool.exe": ["随机颜色"],
                                  "ZTool.dll": ["零件", "宋体"]},
                                 {("ZTool.exe", "零件"): 1,
                                  ("ZTool.dll", "零件"): 2}, allowed, required)
    print("self-test: good_failures=%d (want 0), "
          "missing_exe_key_failures=%d (want 1), "
          "unclassified_failures=%d (want 1)"
          % (len(good_f), len(missing_exe_f), len(unclassified_f)))
    ok = (
        len(good_f) == 0 and
        len(missing_exe_f) == 1 and
        "ZTool.exe" in missing_exe_f[0] and
        len(unclassified_f) == 1 and
        "unclassified Han" in unclassified_f[0]
    )
    if ok:
        print("SELF-TEST PASS")
    else:
        print("SELF-TEST FAIL: missing_exe=%r unclassified=%r"
              % (missing_exe_f, unclassified_f))
    return 0 if ok else 1


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--root", default=".")
    ap.add_argument("--self-test", action="store_true")
    args = ap.parse_args()
    if args.self_test:
        return self_test()
    root = args.root

    allowed = load_allowed()
    required = load_required()

    han_by_binary = {}
    key_counts = {}
    for rel in ["ZTool.exe", "ZTool.dll"]:
        path = os.path.join(root, rel)
        if not os.path.exists(path):
            print("FAIL: missing binary: %s" % rel)
            return 1
        han_by_binary[rel] = han_us_strings(path)
    for rel, key, _ in required:
        path = os.path.join(root, rel)
        if os.path.exists(path):
            key_counts[(rel, key)] = \
                open(path, "rb").read().count(key.encode("utf-16-le"))

    failures, review = evaluate(han_by_binary, key_counts, allowed, required,
                                emit=print)

    if review:
        print("\n[REVIEW] Han strings allowed but flagged for human confirmation")
        print("These remain Chinese in the shipped binary. Confirm each is an")
        print("internal key/font/path and not a missed visible-text translation:")
        for rel, role, note, s in review:
            print("  - %-10s [%s] %r  -- %s" % (rel, role, s, note))

    print("\n" + "=" * 70)
    if failures:
        print("RESULT: FAIL - %d invariant violation(s):" % len(failures))
        for f in failures:
            print("  * " + f)
        return 1
    print("RESULT: PASS - internal-string invariants hold "
          "(%d review item(s) to confirm)." % len(review))
    return 0


if __name__ == "__main__":
    sys.exit(main())
