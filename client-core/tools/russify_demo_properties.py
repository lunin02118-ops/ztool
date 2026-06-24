# -*- coding: utf-8 -*-
"""
Russify a demo SolidWorks assembly's custom properties so the RUSSIAN SWTools
config (SWTools.settings) can read it.

ZTool reads custom properties BY EXACT NAME. The demo model 0614-A00 stores its
properties under legacy vendor names. This script walks every component of the
assembly that is OPEN in SolidWorks and, for each legacy property it finds, ADDS
a Russian-named property at document level and at every configuration level. For
legacy type values, the script writes Russian values into `Тип`; production
filter rules must not depend on vendor Han aliases. After running with --apply,
load the Russian config and export: the columns fill with data and the whole BOM
is Russian.

It does NOT delete the legacy properties; it only adds the Russian ones, so it is
safe and reversible (re-running just overwrites the same Russian values).

REQUIREMENTS (run ON the machine where SolidWorks + the assembly are open):
  pip install pywin32

USAGE:
  1. Open 0614-A00.SLDASM in SolidWorks (already open in your session).
  2. Dry-run (prints the plan, changes nothing):
       python russify_demo_properties.py
  3. Apply (writes Russian properties and SAVES each component):
       python russify_demo_properties.py --apply

  Tip: back up the model folder first (copy D:\\...\\0614 to a safe place),
  these are CAD files and --apply saves them in place.
"""
import sys

try:
    import pythoncom
    import win32com.client
    from win32com.client import VARIANT
except ImportError:
    sys.exit("pywin32 is required:  pip install pywin32")

# Legacy vendor property name in the model -> Russian name the config reads.
MAPPING = [
    ("\u8bbe\u8ba1",                 "\u0420\u0430\u0437\u0440\u0430\u0431\u043e\u0442\u0430\u043b"),
    ("\u96f6\u4ef6\u540d\u79f0",     "\u041d\u0430\u0438\u043c\u0435\u043d\u043e\u0432\u0430\u043d\u0438\u0435"),
    ("\u56fe\u53f7",                 "\u041e\u0431\u043e\u0437\u043d\u0430\u0447\u0435\u043d\u0438\u0435"),
    ("\u6750\u6599",                 "\u041c\u0430\u0442\u0435\u0440\u0438\u0430\u043b"),
    ("\u7c7b\u578b",                 "\u0422\u0438\u043f"),
    ("\u7248\u672c",                 "\u0412\u0435\u0440\u0441\u0438\u044f"),
    ("\u8868\u9762\u5904\u7406",     "\u041e\u0431\u0440\u0430\u0431\u043e\u0442\u043a\u0430 \u043f\u043e\u0432\u0435\u0440\u0445\u043d\u043e\u0441\u0442\u0438"),
    ("\u8bbe\u8ba1\u65e5\u671f",     "\u0414\u0430\u0442\u0430 \u0440\u0430\u0437\u0440\u0430\u0431\u043e\u0442\u043a\u0438"),
    ("\u91cd\u91cf",                 "\u041c\u0430\u0441\u0441\u0430"),
]

# Legacy demo value -> Russian production value. This is intentionally a
# fixture migration step, not a runtime alias in the shipped settings.
VALUE_MAPPING = {
    "\u7c7b\u578b": {
        "\u673a\u52a0": "\u041c\u0435\u0445.\u043e\u0431\u0440\u0430\u0431\u043e\u0442\u043a\u0430",
        "\u94a3\u91d1": "\u041b\u0438\u0441\u0442\u043e\u0432\u0430\u044f",
        "\u94f8\u4ef6": "\u041b\u0438\u0442\u044c\u0451",
        "\u710a\u4ef6": "\u0421\u0432\u0430\u0440\u043a\u0430",
        "\u5916\u8d2d": "\u041f\u043e\u043a\u0443\u043f\u043d\u043e\u0435",
        "\u5e02\u8d2d": "\u041f\u043e\u043a\u0443\u043f\u043d\u043e\u0435",
    },
}

swDocPART = 1
swDocASSEMBLY = 2
swCustomInfoText = 30
swCustomPropertyReplaceValue = 2          # add or replace value, keep existing too
swComponentFullyResolved = 3
swSaveAsOptions_Silent = 1


def get_raw_value(cpm, name):
    """Return the raw (unresolved) value expression of a property, or None."""
    try:
        res = cpm.Get5(name, False)   # (ret, ValOut, ResolvedValOut, WasResolved)
    except pythoncom.com_error:
        return None
    if not isinstance(res, (list, tuple)) or len(res) < 3:
        return None
    val_out, resolved = res[1], res[2]
    raw = val_out if val_out else resolved
    return raw if raw else None


def normalize_value(source_name, raw):
    """Translate legacy fixture values for Russian production properties."""
    value_map = VALUE_MAPPING.get(source_name)
    if not value_map or not raw:
        return raw
    result = raw
    for old, new in value_map.items():
        result = result.replace(old, new)
    return result


def russify_doc(model):
    """Add Russian properties (doc-level + each config). Returns list of changes."""
    changes = []
    scopes = [""]
    try:
        cfgs = model.GetConfigurationNames()
        if cfgs:
            scopes += list(cfgs)
    except pythoncom.com_error:
        pass
    for scope in scopes:
        cpm = model.Extension.CustomPropertyManager(scope)
        for zh, ru in MAPPING:
            raw = get_raw_value(cpm, zh)
            if raw is None:
                continue
            raw = normalize_value(zh, raw)
            cpm.Add3(ru, swCustomInfoText, raw, swCustomPropertyReplaceValue)
            changes.append((scope or "<doc>", ru, raw))
    return changes


def collect_docs(swApp, asm):
    """Map pathname -> loaded ModelDoc2 for the assembly and all its components."""
    docs = {}
    try:
        docs[asm.GetPathName()] = asm
    except pythoncom.com_error:
        pass
    try:
        comps = asm.GetComponents(False)   # False = all levels, not top-only
    except pythoncom.com_error:
        comps = None
    for c in (comps or []):
        try:
            md = c.GetModelDoc2()
            if md is None:
                c.SetSuppression2(swComponentFullyResolved)
                md = c.GetModelDoc2()
            if md is not None:
                docs[md.GetPathName()] = md
        except pythoncom.com_error:
            continue
    return docs


def main():
    apply = "--apply" in sys.argv
    try:
        swApp = win32com.client.GetActiveObject("SldWorks.Application")
    except pythoncom.com_error:
        sys.exit("SolidWorks is not running / not registered for COM on this machine.")

    asm = swApp.ActiveDoc
    if asm is None:
        sys.exit("No active document. Open 0614-A00.SLDASM first.")
    if asm.GetType() != swDocASSEMBLY:
        sys.exit("Active document is not an assembly. Open the assembly 0614-A00.SLDASM.")

    docs = collect_docs(swApp, asm)
    print("=" * 64)
    print("Russify demo properties  (mode: %s)" % ("APPLY+SAVE" if apply else "DRY-RUN"))
    print("components found:", len(docs))
    print("=" * 64)

    total = 0
    saved = 0
    for path, model in docs.items():
        changes = russify_doc(model)
        if not changes:
            print("  [skip] %s  (no Chinese props found)" % path)
            continue
        total += len(changes)
        print("  [ok ] %s  (+%d russian props)" % (path, len(changes)))
        for scope, ru, raw in changes:
            print("         %-22s = %s   (%s)" % (ru, raw, scope))
        if apply:
            try:
                errors = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
                warnings = VARIANT(pythoncom.VT_BYREF | pythoncom.VT_I4, 0)
                model.Save3(swSaveAsOptions_Silent, errors, warnings)
                saved += 1
            except pythoncom.com_error as e:
                print("         !! save failed: %s" % (e,))

    print("-" * 64)
    print("properties added: %d   docs saved: %d" % (total, saved))
    if not apply:
        print("DRY-RUN only - nothing was written. Re-run with --apply to save.")
    else:
        print("Done. Now load the RUSSIAN SWTools.settings and export the BOM.")


if __name__ == "__main__":
    main()
