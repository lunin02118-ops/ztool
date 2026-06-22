#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""IPC handshake parity gate (from-source EXE <-> SolidWorks add-in).

Reading a model ("Подключить SW") makes the from-source EXE send, over
WM_COPYDATA, a line that begins with

    "ZToolRequest@001" + ZTool.code.Getpkt()

and the add-in (PMPHandler.DefWndProc) accepts the request only when that line
equals

    "ZToolRequest@001" + Type_16.m_61(Type_26.p_49)

where p_49 is the embedded resource ``t2PqyrYN``. On any mismatch the add-in
SILENTLY drops the request, so connect completes in ~0.1 s with 0 positions and
the table never fills (this is exactly the live-S7 regression in
docs/audit/phaseD-addin-live-test-2026-06-22_RU.md).

The genuine vendor exe derived Getpkt() from its strong-name public key token.
The from-source build is NOT signed with the vendor key (and the key is not
available), so Getpkt() is pinned to the constant the add-in expects -- exactly
as the IL-reinjection build does (client-core/tools/Localizer.cs PatchHandshakePkt).

This gate makes that cross-component invariant CI-enforced: it derives the
add-in's expected token straight from the add-in resource via the real
m_61/St2 transform (a per-byte nibble swap: swap each adjacent hex-char pair,
drop a trailing unpaired char) and asserts the EXE's pinned Getpkt() constant
matches it. If either side drifts (resource re-baked, or the pin removed/edited)
the gate fails instead of shipping a client whose connect silently returns 0.

Usage:
  python tools/check_ipc_handshake_parity.py
  python tools/check_ipc_handshake_parity.py --self-test
"""
import argparse
import os
import re
import sys
import xml.etree.ElementTree as ET

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")

HERE = os.path.dirname(os.path.abspath(__file__))
REPO = os.path.dirname(HERE)

CODE_CS = os.path.join(REPO, "client-src", "ZTool", "code.cs")
ADDIN_RESX = os.path.join(REPO, "client-src-addin", "ZTool.MyResources.resx")
RESOURCE_KEY = "t2PqyrYN"

# Method body of a pinned Getpkt(): a single string return. Tolerant of
# whitespace/comments between the signature and the return.
_GETPKT = re.compile(
    r'string\s+Getpkt\s*\(\s*\)\s*\{(?P<body>.*?)\}', re.DOTALL)
_RET_LIT = re.compile(r'return\s+"([0-9A-Fa-f]+)"\s*;')


def swap_pairs(s):
    """Reproduce ZTool.code.St2 / Type_16.m_61: swap each adjacent pair of
    hex chars and drop a trailing unpaired char."""
    out = []
    for i in range(0, len(s) - 1, 2):
        out.append(s[i + 1])
        out.append(s[i])
    return "".join(out)


def read_pinned_getpkt(path):
    """Return the string constant Getpkt() is pinned to, or None if Getpkt is
    not a simple pinned-constant return (e.g. reverted to token derivation)."""
    src = open(path, encoding="utf-8").read()
    m = _GETPKT.search(src)
    if not m:
        return None
    lit = _RET_LIT.search(m.group("body"))
    return lit.group(1) if lit else None


def read_addin_resource(path, key):
    """Return the value of the named <data> entry in a .resx file."""
    root = ET.parse(path).getroot()
    for data in root.findall("data"):
        if data.get("name") == key:
            val = data.find("value")
            return val.text if val is not None else None
    return None


def evaluate(pinned, resource):
    """Return list of failure strings (empty == pass)."""
    failures = []
    if pinned is None:
        failures.append(
            "client-src/ZTool/code.cs: Getpkt() is not pinned to a constant "
            "string return. The from-source exe cannot reproduce the vendor "
            "strong-name token, so Getpkt() MUST return the add-in-expected "
            "handshake constant (see Localizer.PatchHandshakePkt). Without it "
            "connect silently returns 0 positions (live-S7 FAIL).")
        return failures
    if resource is None:
        failures.append(
            "client-src-addin/ZTool.MyResources.resx: resource %r not found; "
            "cannot derive the add-in-expected handshake token." % RESOURCE_KEY)
        return failures
    expected = swap_pairs(resource)
    if pinned != expected:
        failures.append(
            "IPC handshake mismatch: EXE Getpkt() is pinned to %r but the "
            "add-in (m_61(%s=%r)) expects %r. Connect would silently return 0 "
            "positions. Re-pin Getpkt() to the expected value, or re-bake the "
            "add-in resource, so the two match." % (
                pinned, RESOURCE_KEY, resource, expected))
    return failures


def run():
    pinned = read_pinned_getpkt(CODE_CS)
    resource = read_addin_resource(ADDIN_RESX, RESOURCE_KEY)
    print("IPC handshake parity (from-source EXE <-> add-in)")
    print("  EXE Getpkt() pinned to       : %r" % pinned)
    print("  add-in resource %-12s : %r" % (RESOURCE_KEY, resource))
    if resource is not None:
        print("  add-in expects (m_61)        : %r" % swap_pairs(resource))
    failures = evaluate(pinned, resource)
    if failures:
        print("FAIL: %d handshake parity violation(s):" % len(failures))
        for f in failures:
            print("  - " + f)
        return 1
    print("PASS: EXE Getpkt() matches the add-in's expected handshake token.")
    return 0


def self_test():
    # Known vendor-baked pair (verified against the shipped DLL and the
    # Localizer's documented obf1()/obf2()):
    #   resource     = E91FBC0FCBAF9D1F81AE0368B381478
    #   m_61(resource)= 9EF1CBF0BCFAD9F118EA30863B1874
    res = "E91FBC0FCBAF9D1F81AE0368B381478"
    exp = "9EF1CBF0BCFAD9F118EA30863B1874"
    assert swap_pairs(res) == exp, "swap_pairs broken: %r" % swap_pairs(res)
    assert evaluate(exp, res) == [], "matching pair should pass"
    assert evaluate("DEADBEEF", res), "mismatch must fail"
    assert evaluate(None, res), "unpinned Getpkt must fail"
    assert evaluate(exp, None), "missing resource must fail"
    # parsing a pinned method body
    sample = ('class code {\n'
              '\tpublic static string Getpkt()\n\t{\n'
              '\t\t// comment\n\t\treturn "9EF1CBF0BCFAD9F118EA30863B1874";\n\t}\n}\n')
    import tempfile
    fd, p = tempfile.mkstemp(suffix=".cs")
    os.close(fd)
    try:
        open(p, "w", encoding="utf-8").write(sample)
        assert read_pinned_getpkt(p) == exp, "should parse pinned constant"
        # token-derived (unpinned) body -> None
        open(p, "w", encoding="utf-8").write(
            'class code { public static string Getpkt() { '
            'return St2(GD52(tok, "x")); } }')
        assert read_pinned_getpkt(p) is None, "token-derived must be unpinned"
    finally:
        os.remove(p)
    print("SELF-TEST PASS")
    return 0


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--self-test", action="store_true")
    args = ap.parse_args()
    sys.exit(self_test() if args.self_test else run())


if __name__ == "__main__":
    main()
