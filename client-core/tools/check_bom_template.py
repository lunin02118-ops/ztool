#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Offline pre-flight check for ZTool BOM export configuration.

Validates, WITHOUT SolidWorks, that ZTool.settings and the BOM template are
mutually consistent so that a real export inside SolidWorks can succeed:

  1. Every BOM preset points at an ABSOLUTE template path (relative paths are
     resolved against the process CWD = ...\\Documents under SolidWorks and fail).
  2. Every non-empty <mappingname> in <namemappinglist> exists as a defined name
     (named range) in the template workbook - otherwise that column is silently
     left unfilled on export. The shipped runtime also requires explicit
     mappings for calculated columns whose UI headers are not valid Excel names.
  3. Reports the column -> header(propname) -> template-anchor wiring and the
     preset table (name / type / thumbnails / filters) for a human cross-check.
  4. Checks that the default material library referenced by <materialpath> is
     available locally and reports whether material colors are enabled.

This does NOT verify data population - that requires SolidWorks + a model whose
custom-property names match the <text> (propname) values. See the methodology.

Usage:
  python check_bom_template.py [path\\to\\ZTool.settings]
Exit code 0 = all checks passed, 1 = at least one problem found.
"""
import os
import re
import sys

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
if hasattr(sys.stderr, "reconfigure"):
    sys.stderr.reconfigure(encoding="utf-8", errors="replace")

try:
    import openpyxl
except ImportError:
    sys.exit("openpyxl is required: pip install openpyxl")


def parse_settings(path):
    xml = open(path, encoding="utf-8").read()

    def tag(block, t):
        m = re.search(r"<%s>(.*?)</%s>" % (t, t), block, re.S)
        if m:
            return m.group(1).strip()
        # self-closing / empty element
        if re.search(r"<%s\s*/>" % t, block):
            return ""
        return None

    def tag_list(block, t):
        """Extract list of <string>...</string> values from a parent tag."""
        m = re.search(r"<%s>(.*?)</%s>" % (t, t), block, re.S)
        if not m:
            return []
        return re.findall(r"<string>(.*?)</string>", m.group(1), re.S)

    presets = []
    for m in re.finditer(r"<bomsetting>(.*?)</bomsetting>", xml, re.S):
        b = m.group(1)
        presets.append({
            "name": tag(b, "name"),
            "type": tag(b, "type"),
            "img": tag(b, "insertimagebool"),
            "byruler": tag(b, "ByRuler"),
            "byfilter": tag(b, "ByFilter"),
            "bomname": tag(b, "bomname"),
            "ruleslist": tag_list(b, "RulesList"),
        })

    mappings = []
    mm = re.search(r"<namemappinglist>(.*?)</namemappinglist>", xml, re.S)
    if mm:
        for c in re.finditer(r"<columnnamemapping>(.*?)</columnnamemapping>",
                             mm.group(1), re.S):
            cb = c.group(1)
            mappings.append({
                "col": tag(cb, "name"),
                "header": tag(cb, "text"),
                "anchor": tag(cb, "mappingname") or "",
            })

    # Parse FilterRulesList (name -> list of rule-string bodies)
    filter_rules = {}
    frm = re.search(r"<FilterRulesList>(.*?)</FilterRulesList>", xml, re.S)
    if frm:
        for cr in re.finditer(r"<CustomRule>(.*?)</CustomRule>",
                              frm.group(1), re.S):
            rule_name = tag(cr.group(1), "name")
            if rule_name:
                bodies = []
                rl = re.search(r"<RuleList>(.*?)</RuleList>", cr.group(1), re.S)
                if rl:
                    bodies = re.findall(r"<string>(.*?)</string>",
                                        rl.group(1), re.S)
                filter_rules[rule_name] = bodies

    material = {
        "materialpath": tag(xml, "materialpath") or "",
        "usematerialcolor": tag(xml, "usematerialcolor") or "",
    }

    return presets, mappings, filter_rules, material


# Field separator ZTool.exe (CustomFilter.FilterByRule) splits rule strings on.
RULE_SEP = "\t|@#$%|"

# Localized operator strings the russified ZTool.exe switch accepts (array[1]).
VALID_OPERATORS = {
    "Равно", "Не равно", "Содержит", "Не содержит",
    "Начинается с", "Не начинается с", "Заканчивается на", "Не заканчивается на",
}


def template_defined_names(path):
    wb = openpyxl.load_workbook(path, data_only=False)
    names = set()
    name_dests = {}
    dn = wb.defined_names

    # openpyxl 3.1: defined_names is a dict-like of DefinedName.
    # openpyxl 3.0: it exposes a definedName list.
    items = []
    try:
        items = list(dn.items())
    except AttributeError:
        items = [(d.name, d) for d in dn.definedName]

    for name, defined_name in items:
        names.add(name)
        destinations = set()
        try:
            for sheet, coord in defined_name.destinations:
                destinations.add((sheet.strip("'"), coord.replace("$", "").upper()))
        except Exception:
            destinations = set()
        if destinations:
            name_dests[name] = destinations
    return names, wb.sheetnames, name_dests


def main():
    settings = sys.argv[1] if len(sys.argv) > 1 else "ZTool.settings"
    presets, mappings, filter_rules, material = parse_settings(settings)

    problems = 0
    print("=" * 70)
    print("BOM export pre-flight check")
    print("settings:", os.path.abspath(settings))
    print("=" * 70)

    # --- 1. presets + absolute path ---
    print("\n[1] Presets (report types): %d mode(s)" % len(presets))
    tmpl_path = None
    for p in presets:
        abs_ok = bool(p["bomname"]) and (
            re.match(r"^[A-Za-z]:[\\/]", p["bomname"]) or
            p["bomname"].startswith("\\\\"))
        flag = "OK " if abs_ok else "REL!"
        if not abs_ok:
            problems += 1
        ruler_info = ""
        if p["byruler"] and p["byruler"].lower() == "true" and p["ruleslist"]:
            ruler_info = " rules=%s" % p["ruleslist"]
        print("  - type=%s img=%-5s ByRuler=%-5s ByFilter=%-5s [%s] %s%s"
              % (p["type"], p["img"], p["byruler"], p["byfilter"], flag,
                 p["name"], ruler_info))
        tmpl_path = p["bomname"] or tmpl_path
    print("  template path:", tmpl_path)

    # --- 1b. validate FilterRulesList references ---
    if filter_rules:
        print("\n[1b] FilterRulesList: %d rule(s) defined" % len(filter_rules))
        for name in sorted(filter_rules):
            print("    - %s" % name)
    for p in presets:
        if p["byruler"] and p["byruler"].lower() == "true":
            for rule_ref in p["ruleslist"]:
                if rule_ref not in filter_rules:
                    print("  ** ERROR: preset '%s' references rule '%s' "
                          "not found in FilterRulesList!" % (p["name"], rule_ref))
                    problems += 1

    # --- 1c. validate rule-string FORMAT (TAB separator + operator) ---
    # ZTool.exe splits each rule string on RULE_SEP ("\t|@#$%|") and switches
    # the operator (field 1) against VALID_OPERATORS. A rule string that uses
    # spaces instead of the TAB separator, or a non-localized operator, is
    # silently skipped -> FilterByRule returns true for every row -> the BOM
    # exports UNFILTERED. This check catches that class of bug pre-export.
    if filter_rules:
        print("\n[1c] Rule-string format (separator + operator):")
        for name in sorted(filter_rules):
            for body in filter_rules[name]:
                parts = body.split(RULE_SEP)
                if len(parts) < 3:
                    print("  ** ERROR: rule '%s': string does not use the TAB "
                          "separator '\\t|@#$%%|' (got %d field(s)); filter "
                          "would be ignored and BOM exported unfiltered."
                          % (name, len(parts)))
                    problems += 1
                    continue
                op = parts[1]
                if op not in VALID_OPERATORS:
                    print("  ** ERROR: rule '%s': operator %r not recognized by "
                          "ZTool.exe (expected one of: %s)."
                          % (name, op, ", ".join(sorted(VALID_OPERATORS))))
                    problems += 1
                else:
                    print("    - %s: prop=%s op=%s OK"
                          % (name, parts[0], op))

    # --- 2. resolve template for anchor check ---
    local_tmpl = None
    if tmpl_path:
        base = os.path.basename(tmpl_path.replace("\\", "/"))
        for cand in [
            os.path.join("Шаблоны спецификации", base),
            os.path.join(os.path.dirname(os.path.abspath(settings)),
                         "Шаблоны спецификации", base),
        ]:
            if os.path.exists(cand):
                local_tmpl = cand
                break
    if not local_tmpl:
        print("\n[!] Template workbook not found locally for anchor check "
              "(looked for basename of bomname under 'Шаблоны спецификации').")
        problems += 1
        return finish(problems)

    names, sheets, name_dests = template_defined_names(local_tmpl)
    print("\n[2] Template:", local_tmpl)
    print("    sheets:", sheets)
    print("    defined names (%d): %s" % (len(names), sorted(names)))

    # --- 3. mapping wiring + anchor existence ---
    print("\n[3] Column -> header(propname) -> template anchor:")
    for mp in mappings:
        anc = mp["anchor"]
        if anc == "":
            status = "(no anchor - column header only)"
        elif anc in names:
            status = "anchor OK"
        else:
            status = "ANCHOR MISSING IN TEMPLATE!"
            problems += 1
        print("  %-14s | %-22s | anchor=%-6s %s"
              % (mp["col"], mp["header"] or "", anc, status))
    problems += check_calculated_mappings(mappings, names, name_dests)

    # --- 4. service columns (header-bound, NOT in namemappinglist) ---
    # ZTool's export (ExportBom_xls4/_xls2) resolves SERVICE columns (the auto
    # number, the computed quantity, path, sketch, disk file name) by the
    # column's runtime HeaderText: it calls workbook.GetName(HeaderText) and
    # writes that column ONLY IF a defined name with exactly that name exists.
    # These headers come from the localized ZTool.exe resources (Frmmain.resx),
    # NOT from ZTool.settings, so they cannot be remapped via the config.
    # An Excel defined name cannot contain spaces (or '-', '/', a leading digit,
    # '#'/'№' ...), so a header like "Подсчитанное количество" can never be
    # bound by ANY template anchor - the column stays empty by construction.
    problems += check_service_columns(names)

    # --- 5. material library / color defaults ---
    print("\n[5] Material library / material color defaults:")
    mat_path = material.get("materialpath") or ""
    use_mat_color = material.get("usematerialcolor") or ""
    if use_mat_color.lower() == "true":
        print("    usematerialcolor: true")
    else:
        print("    usematerialcolor: %s (material colors disabled)" %
              (use_mat_color or "<missing>"))

    if mat_path:
        candidates = [mat_path]
        if not os.path.isabs(mat_path):
            candidates.append(os.path.join(os.path.dirname(os.path.abspath(settings)),
                                           mat_path))
        for base_dir in [
            os.path.dirname(os.path.abspath(settings)),
            os.getcwd(),
        ]:
            candidates.append(os.path.join(base_dir, "SolidWorksTemplates",
                                           os.path.basename(mat_path)))
        local_mat = next((p for p in candidates if os.path.exists(p)), None)
        if local_mat:
            print("    materialpath: %s [OK: %s]" % (mat_path, local_mat))
        else:
            print("  ** ERROR: materialpath points to a missing library: %s" %
                  mat_path)
            problems += 1
    elif use_mat_color.lower() == "true":
        print("  ** ERROR: usematerialcolor=true but materialpath is empty")
        problems += 1
    else:
        print("    materialpath: <empty>")

    return finish(problems)


# DataGridView service columns and their localized HeaderText in the shipped
# Russian ZTool.exe (read from ZTool.Frmmain.resources). The export binds each
# to a defined name == this exact string.
SERVICE_HEADERS = [
    ("Col_Number",   "Номер",                "auto row number"),
    ("Col_Quantity", "Количество",            "computed quantity"),
    ("Col_Path",     "Путь",                 "document path"),
    ("Col_Preview",  "Эскиз",                "thumbnail image"),
    ("Col_FileName", "Имя файла на диске",   "disk file name"),
]

# Service columns whose binary header rename is intentionally deferred. An
# unbindable header here is reported as a non-blocking DEFERRED warning instead
# of a hard failure (the column simply stays empty until its header is renamed).
DEFERRED_SERVICE = {"Col_FileName"}

# Calculated service columns with user-visible headers that cannot be used as
# Excel names directly. The localized exporter patches these through
# namemappinglist by DataGridViewColumn.Name, so the release profile and template
# must keep this contract in sync.
REQUIRED_CALCULATED_MAPPINGS = {
    "Col_Weight": ("Масса ед._кг", "МассаЕдКг"),
    "Col_bound": ("Габаритные размеры", "ГабаритныеРазмеры"),
}


def valid_excel_name(s):
    """True if s can be an Excel/OOXML defined name (so an anchor CAN exist)."""
    if not s or any(ch.isspace() for ch in s):
        return False
    # first char: letter (incl. Cyrillic) or underscore/backslash; rest: word
    # chars or '.'; reject anything else (-, /, №, etc.)
    return re.match(r"^[^\W\d][\w.]*$", s, re.UNICODE) is not None


def check_service_columns(names):
    print("\n[4] Service columns (auto, bound by HeaderText -> defined name):")
    problems = 0
    for col, header, desc in SERVICE_HEADERS:
        if not valid_excel_name(header):
            if col in DEFERRED_SERVICE:
                status = ("DEFERRED - unbindable header (space); rename deferred "
                          "by request, column stays empty until renamed")
            else:
                status = ("UNBINDABLE - header is not a valid Excel name; rename "
                          "the column header in ZTool.exe to one word (binary fix)")
                problems += 1
        elif header in names:
            status = "anchor OK"
        else:
            status = "ANCHOR MISSING - add a defined name '%s' to the template" % header
            problems += 1
        print("  %-14s | header=%-24r %-18s | %s"
              % (col, header, "(%s)" % desc, status))
    return problems


def check_calculated_mappings(mappings, names, name_dests):
    print("\n[3b] Calculated columns (mapped by column name):")
    problems = 0
    by_col = {mp["col"]: mp for mp in mappings}
    for col, (header, anchor) in REQUIRED_CALCULATED_MAPPINGS.items():
        mp = by_col.get(col)
        if not mp:
            print("  ** ERROR: missing mapping for %s (%s -> %s)" %
                  (col, header, anchor))
            problems += 1
            continue
        actual_header = mp.get("header") or ""
        actual_anchor = mp.get("anchor") or ""
        ok = True
        if actual_header != header:
            print("  ** ERROR: %s header mismatch: expected %r, got %r" %
                  (col, header, actual_header))
            ok = False
        if actual_anchor != anchor:
            print("  ** ERROR: %s anchor mismatch: expected %r, got %r" %
                  (col, anchor, actual_anchor))
            ok = False
        if actual_anchor not in names:
            print("  ** ERROR: %s anchor %r missing in template" %
                  (col, actual_anchor))
            ok = False
        if ok:
            print("    - %-12s | %-20s -> %-20s OK" %
                  (col, actual_header, actual_anchor))
        else:
            problems += 1

        calc_dests = name_dests.get(anchor, set())
        for other in mappings:
            other_col = other.get("col") or ""
            other_anchor = other.get("anchor") or ""
            if other_col == col or not other_anchor or other_anchor == anchor:
                continue
            overlap = calc_dests & name_dests.get(other_anchor, set())
            if overlap:
                cells = ", ".join("%s!%s" % dest for dest in sorted(overlap))
                print("  ** ERROR: %s anchor %r shares template cell(s) %s "
                      "with calculated %s anchor %r; empty custom properties "
                      "can overwrite computed export values." %
                      (other_col, other_anchor, cells, col, anchor))
                problems += 1
    return problems


def finish(problems):
    print("\n" + "=" * 70)
    if problems == 0:
        print("RESULT: PASS - settings/template are consistent for export.")
        print("Note: data population still must be verified in SolidWorks on a")
        print("model whose custom-property names match the headers above.")
        return 0
    print("RESULT: FAIL - %d problem(s) found (see above)." % problems)
    return 1


if __name__ == "__main__":
    sys.exit(main())
