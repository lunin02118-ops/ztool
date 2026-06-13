# -*- coding: utf-8 -*-
"""Rewrite the <FilterRulesList> block in ZTool.settings with rule strings in
the EXACT serialization ZTool.exe expects.

Root cause of modes 7-8 "filter not applied" bug:
  ZTool.exe CustomFilter.FilterByRule() splits each rule string on the literal
  separator "\t|@#$%|" (TAB + |@#$%|) and switches the operator (array[1])
  against the localized Russian operator strings ("Содержит", "Равно", ...).

  The previous rules used SPACES instead of the TAB separator, so the split
  produced a single token (length 1 < 3) and every rule string was skipped.
  When no rule string is evaluated, FilterByRule returns TRUE for every row
  (empty result list, `!list.Contains(false)` == true) => the full BOM is
  exported unfiltered. The operators were also Chinese (包含/等于/不等于),
  which the russified binary's switch no longer matches.

This script regenerates the block byte-perfect: real TAB chars, Russian
operators, and filter values that include the demo model's actual "Тип"
tokens (机加 = machined, 外购 = purchased) so the filter is demonstrable on
0614-A00 today, plus Russian placeholders the user can keep for production.

Property identifier syntax (from FilterByRule):
  $Name$  -> matches the PropResolvedVal_ column whose HeaderText == Name
  %Name%  -> matches the PropVal_ column whose HeaderText == Name
  <Name>  -> matches a service column whose HeaderText == Name
"""
import io
import re
import sys

SETTINGS = sys.argv[1] if len(sys.argv) > 1 else \
    r"C:\Users\Administrator\repos\ztool\ZTool.settings"

SEP = "\t|@#$%|"          # the exact field separator ZTool.exe splits on


def rule_string(prop, operator, values=""):
    """Build one <string> body: prop <SEP> operator <SEP> values."""
    return prop + SEP + operator + SEP + values


# Machined / purchased tokens currently stored in the demo model's "Тип"
# property (Chinese), kept alongside Russian production placeholders.
MACHINED = "机加;Мех.обработка;Листовая;Литьё;Сварка"
PURCHASED = "外购;Покупное;Стандартное"

RULES = [
    # (name, type, [ (prop, operator, values), ... ])
    ("Обрабатываемые детали", "false", [
        ("$Тип$", "Содержит", MACHINED),
    ]),
    ("Покупные изделия", "false", [
        ("$Тип$", "Содержит", PURCHASED),
    ]),
    ("С обработкой поверхности", "false", [
        ("$Тип$", "Содержит", MACHINED),
        ("$Обработка поверхности$", "Не равно", ""),
    ]),
    ("Без обработки поверхности", "false", [
        ("$Тип$", "Содержит", MACHINED),
        ("$Обработка поверхности$", "Равно", ""),
    ]),
    ("Недостающие обязательные свойства", "true", [
        ("$Тип$", "Равно", ""),
        ("$Номер чертежа$", "Равно", ""),
        ("$Материал$", "Равно", ""),
        ("$Масса$", "Равно", ""),
        ("$Имя детали$", "Равно", ""),
    ]),
]


def build_block():
    lines = ["  <FilterRulesList>"]
    for name, rtype, conds in RULES:
        lines.append("    <CustomRule>")
        lines.append("      <name>%s</name>" % name)
        lines.append("      <type>%s</type>" % rtype)
        lines.append("      <RuleList>")
        for prop, op, val in conds:
            body = rule_string(prop, op, val)
            lines.append("        <string>%s</string>" % body)
        lines.append("      </RuleList>")
        lines.append("    </CustomRule>")
    lines.append("  </FilterRulesList>")
    return "\n".join(lines)


def main():
    with io.open(SETTINGS, encoding="utf-8") as f:
        xml = f.read()

    new_block = build_block()
    new_xml, n = re.subn(
        r"  <FilterRulesList>.*?</FilterRulesList>",
        lambda m: new_block,
        xml,
        count=1,
        flags=re.S,
    )
    if n != 1:
        sys.exit("ERROR: could not locate <FilterRulesList> block")

    with io.open(SETTINGS, "w", encoding="utf-8", newline="\n") as f:
        f.write(new_xml)

    # Verify the separator is present with a real TAB
    assert "\t|@#$%|" in new_xml, "TAB separator missing!"
    print("OK: FilterRulesList rewritten with %d rules (TAB separator)." %
          len(RULES))


if __name__ == "__main__":
    main()
