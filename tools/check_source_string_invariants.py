#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""From-source string-invariants gate (Этап C).

Reorients the legacy #29 binary (#US-heap) string gate onto the from-source tree.
The from-source ZTool.exe carries NO Chinese in its #US heap (the legacy IL path's
Localizer is what injected/translated #US literals); the bearing Chinese now lives
directly in the client-src *source* — so the meaningful invariant for from-source is
checked against the source, not a compiled binary.

Two invariants over client-src C# string LITERALS (string-valued "..."; CJK
*identifiers* such as enum members / WinForms control names and CJK in comments are
intentionally out of scope — they are internal and not user-visible):

  (1) ALLOW-LIST: every distinct literal containing CJK must be registered in
      source_allowed_han.tsv with a role. An unregistered CJK literal fails the gate
      (this is what catches an accidentally re-introduced visible-Chinese string).

  (2) REQUIRED KEYS: each crypto passphrase in source_required_keys.tsv must still be
      present somewhere in the source. Dropping/translating one silently breaks the
      licensing handshake, so its removal fails the gate.

Entries whose note starts with "REVIEW" are surfaced (not failed): they are allowed to
remain for now but are flagged for human confirmation / planned replacement.

Usage:
  python tools/check_source_string_invariants.py [--root client-src]
  python tools/check_source_string_invariants.py --self-test
"""
import argparse
import os
import re
import sys

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")

HERE = os.path.dirname(os.path.abspath(__file__))
TSV_DIR = os.path.join(HERE, "string_invariants")

CJK = re.compile(r"[\u3400-\u4dbf\u4e00-\u9fff\uff00-\uffef]")
STRLIT = re.compile(r'"((?:\\.|[^"\\])*)"')


def esc(s):
    """Stable single-line key for a literal (matches the allow-list storage)."""
    return s.replace("\\", "\\\\").replace("\t", "\\t").replace("\n", "\\n")


def strip_comments(src):
    """Remove C# // and /* */ comments while preserving string/char literals.

    Single pass with explicit state so that // or /* inside a string (or escaped
    quotes such as "a\\"b") never confuse comment detection. Handles regular,
    verbatim (@"") and interpolated ($) strings and char literals.
    """
    out = []
    i, n = 0, len(src)
    while i < n:
        c = src[i]
        # line comment
        if c == "/" and i + 1 < n and src[i + 1] == "/":
            j = src.find("\n", i)
            if j == -1:
                break
            i = j
            continue
        # block comment
        if c == "/" and i + 1 < n and src[i + 1] == "*":
            j = src.find("*/", i + 2)
            i = n if j == -1 else j + 2
            continue
        # string with @ / $ prefixes (verbatim / interpolated)
        if c in "@$":
            k, verbatim = i, False
            while k < n and src[k] in "@$":
                if src[k] == "@":
                    verbatim = True
                k += 1
            if k < n and src[k] == '"':
                out.append(src[i:k + 1])
                i = k + 1
                if verbatim:
                    while i < n:
                        if src[i] == '"' and i + 1 < n and src[i + 1] == '"':
                            out.append('""'); i += 2; continue
                        out.append(src[i])
                        if src[i] == '"':
                            i += 1; break
                        i += 1
                else:
                    while i < n:
                        if src[i] == "\\" and i + 1 < n:
                            out.append(src[i:i + 2]); i += 2; continue
                        out.append(src[i])
                        if src[i] == '"':
                            i += 1; break
                        i += 1
                continue
            out.append(c); i += 1; continue
        # regular string / char literal (backslash escapes)
        if c in "\"'":
            quote = c
            out.append(c); i += 1
            while i < n:
                if src[i] == "\\" and i + 1 < n:
                    out.append(src[i:i + 2]); i += 2; continue
                out.append(src[i])
                if src[i] == quote:
                    i += 1; break
                i += 1
            continue
        out.append(c); i += 1
    return "".join(out)


def extract_cjk_literals(root):
    """Return {escaped_literal: sorted[relpaths]} for CJK-bearing C# string literals."""
    found = {}
    for base, _, files in os.walk(root):
        parts = base.split(os.sep)
        if "bin" in parts or "obj" in parts:
            continue
        for fn in files:
            if not fn.endswith(".cs"):
                continue
            p = os.path.join(base, fn)
            try:
                txt = open(p, encoding="utf-8", errors="replace").read()
            except OSError:
                continue
            rel = os.path.relpath(p, root)
            for lit in STRLIT.findall(strip_comments(txt)):
                if CJK.search(lit):
                    found.setdefault(esc(lit), set()).add(rel)
    return {k: sorted(v) for k, v in found.items()}


def load_allowed(path):
    """Return {escaped_literal: (role, note)}."""
    allowed = {}
    with open(path, encoding="utf-8") as f:
        for line in f:
            line = line.rstrip("\n")
            if not line or line.startswith("#"):
                continue
            cols = line.split("\t")
            lit = cols[0]
            role = cols[1] if len(cols) > 1 else ""
            note = cols[2] if len(cols) > 2 else ""
            allowed[lit] = (role, note)
    return allowed


def load_required(path):
    """Return {escaped_key: note}."""
    required = {}
    with open(path, encoding="utf-8") as f:
        for line in f:
            line = line.rstrip("\n")
            if not line or line.startswith("#"):
                continue
            cols = line.split("\t")
            required[cols[0]] = cols[1] if len(cols) > 1 else ""
    return required


def evaluate(found, allowed, required):
    """Return (failures, review_items). found/allowed/required keyed by escaped literal."""
    failures = []
    review = []
    for lit in sorted(found):
        if lit not in allowed:
            failures.append(
                "unregistered CJK literal %r in %s" % (lit, ", ".join(found[lit]))
            )
        else:
            role, note = allowed[lit]
            if note.startswith("REVIEW"):
                review.append((lit, role, note, found[lit]))
    present = set(found)
    for key, note in sorted(required.items()):
        if key not in present:
            failures.append(
                "required crypto passphrase %r is MISSING from source (%s)" % (key, note)
            )
    return failures, review


def run(root):
    allowed = load_allowed(os.path.join(TSV_DIR, "source_allowed_han.tsv"))
    required = load_required(os.path.join(TSV_DIR, "source_required_keys.tsv"))
    found = extract_cjk_literals(root)
    failures, review = evaluate(found, allowed, required)

    print("from-source string invariants (root=%s)" % root)
    print("  distinct CJK literals found : %d" % len(found))
    print("  allow-list entries          : %d" % len(allowed))
    print("  required crypto keys        : %d" % len(required))
    roles = {}
    for lit in found:
        if lit in allowed:
            roles[allowed[lit][0]] = roles.get(allowed[lit][0], 0) + 1
    for role in sorted(roles):
        print("    role %-16s : %d" % (role, roles[role]))
    if review:
        print("  REVIEW (allowed, planned/confirm) : %d" % len(review))
        for lit, role, _note, files in review:
            print("    [%s] %r  (%s)" % (role, lit, files[0]))
    if failures:
        print("FAIL: %d invariant violation(s):" % len(failures))
        for f in failures:
            print("  - " + f)
        return 1
    print("PASS: all CJK literals registered; all required crypto passphrases present.")
    return 0


def self_test():
    import shutil
    import tempfile

    tmp = tempfile.mkdtemp(prefix="srcinv_")
    try:
        good = os.path.join(tmp, "good")
        os.makedirs(good)
        # good tree: only registered crypto passphrase + a font literal, both allow-listed
        with open(os.path.join(good, "A.cs"), "w", encoding="utf-8") as f:
            f.write('class A { void m(){ sR.IsReg2("\u6765\u751f\u7f18\u3002\u3002\u3002"); '
                    'var x = new Font("\u5fae\u8f6f\u96c5\u9ed1"); } }\n')
        allowed = {esc("\u6765\u751f\u7f18\u3002\u3002\u3002"): ("crypto-passphrase", "ok"),
                   esc("\u5fae\u8f6f\u96c5\u9ed1"): ("font", "REVIEW: font")}
        required = {esc("\u6765\u751f\u7f18\u3002\u3002\u3002"): "must stay"}
        f1, r1 = evaluate(extract_cjk_literals(good), allowed, required)
        assert f1 == [], "good tree should pass, got %r" % f1
        assert len(r1) == 1 and r1[0][1] == "font", "font should be a REVIEW item"

        # bad tree #1: a NEW unregistered Chinese literal
        bad = os.path.join(tmp, "bad")
        os.makedirs(bad)
        with open(os.path.join(bad, "B.cs"), "w", encoding="utf-8") as f:
            f.write('class B { string s = "\u4f60\u597d"; }\n')  # 你好 not allow-listed
        f2, _ = evaluate(extract_cjk_literals(bad), allowed, required)
        assert any("unregistered" in x for x in f2), "should flag unregistered literal: %r" % f2

        # bad tree #2: crypto passphrase dropped
        empty = os.path.join(tmp, "empty")
        os.makedirs(empty)
        with open(os.path.join(empty, "C.cs"), "w", encoding="utf-8") as f:
            f.write('class C {}\n')
        f3, _ = evaluate(extract_cjk_literals(empty), allowed, required)
        assert any("MISSING" in x for x in f3), "should flag missing crypto key: %r" % f3

        # comments / CJK identifiers must be ignored (not flagged)
        ign = os.path.join(tmp, "ign")
        os.makedirs(ign)
        with open(os.path.join(ign, "D.cs"), "w", encoding="utf-8") as f:
            f.write('// \u6ce8\u6210 comment\nenum E { \u65e0\u6ce8\u7801 = 1 }\n')
        f4, _ = evaluate(extract_cjk_literals(ign), allowed, {})
        assert not any("unregistered" in x for x in f4), \
            "CJK in comments/identifiers must be ignored, got %r" % f4

        # escaped-quote regression: a string with \" must not make a trailing
        # // comment (containing CJK) survive comment stripping.
        esc_dir = os.path.join(tmp, "esc")
        os.makedirs(esc_dir)
        with open(os.path.join(esc_dir, "E.cs"), "w", encoding="utf-8") as f:
            f.write('class E { string s = "a\\"b"; } // comment \u4f60\u597d\n')
        f5, _ = evaluate(extract_cjk_literals(esc_dir), allowed, {})
        assert not any("unregistered" in x for x in f5), \
            "CJK in a // comment after an escaped-quote string must be ignored, got %r" % f5

        print("SELF-TEST PASS")
        return 0
    finally:
        shutil.rmtree(tmp, ignore_errors=True)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--root", default="client-src")
    ap.add_argument("--self-test", action="store_true")
    args = ap.parse_args()
    if args.self_test:
        sys.exit(self_test())
    sys.exit(run(args.root))


if __name__ == "__main__":
    main()
