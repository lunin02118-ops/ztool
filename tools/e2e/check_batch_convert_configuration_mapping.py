#!/usr/bin/env python3
"""Guard batch conversion/print lists so imported configuration names survive."""

from __future__ import annotations

import argparse
from pathlib import Path


GOOD_LIST_FIXTURE = r'''
private static string NormalizeConfigurationNames(string configurations)
{
    return string.Join("|\n", Strings.Split(configurations, "|\n").Select((string item) => item.Trim()).Where((string item) => item.Length > 0).Distinct(StringComparer.OrdinalIgnoreCase));
}

private static string MergeConfigurationNames(string existingConfigurations, string incomingConfiguration)
{
    return NormalizeConfigurationNames(existingConfigurations + "|\n" + incomingConfiguration);
}

public void loadview(List<string> f)
{
    list2[num9] = MergeConfigurationNames(list2[num9], closure_0024__._0024VB_0024Local_str[1]);
    list2.Add(NormalizeConfigurationNames(closure_0024__._0024VB_0024Local_str[1]));
    list2[num9] = NormalizeConfigurationNames(list2[num9]);
    listViewItem.SubItems.Add(list2[num11]);
}
'''

BAD_LIST_FIXTURE = r'''
public void loadview(List<string> f)
{
    list2[num9] = Conversions.ToString(Interaction.IIf(Operators.CompareString(list2[num9], "", TextCompare: false) == 0, "", list2[num9] + "|\n" + closure_0024__._0024VB_0024Local_str[1]));
    HashSet<string> values = new HashSet<string>(Strings.Split(list2[num9], "|\n").ToList());
    list2[num9] = string.Join("|\n", values);
    list2[num9] = "";
    listViewItem.SubItems.Add(list2[num11]);
}
'''

GOOD_OUTPUT_FIXTURE = r'''
cfglist.Add(listView2.Items[num6].SubItems[3].Text);
if ((forcurcfg.Checked && Operators.CompareString(cfglist[num6], "", TextCompare: false) != 0) ? true : false)
{
    string[] array9 = Strings.Split(cfglist[num6], "|\n");
    if (cfglist.Count >= 1 && !Array.Exists(array9, closure_0024__2._Lambda_0024__23))
    {
        goto IL_28e5;
    }
}
NewLateBinding.LateCall(instance13, null, "ShowConfiguration2", arguments21, null, null, array2, IgnoreReturn: true);
'''

BAD_OUTPUT_FIXTURE = r'''
cfglist.Add(listView2.Items[num6].SubItems[4].Text);
NewLateBinding.LateCall(instance13, null, "ShowConfiguration2", arguments21, null, null, array2, IgnoreReturn: true);
'''


def analyze_list_source(source: str, label: str) -> list[str]:
    issues: list[str] = []
    if "NormalizeConfigurationNames(" not in source:
        issues.append(f"{label}: missing NormalizeConfigurationNames helper")
    if "MergeConfigurationNames(" not in source:
        issues.append(f"{label}: missing MergeConfigurationNames helper")
    if 'Distinct(StringComparer.OrdinalIgnoreCase)' not in source:
        issues.append(f"{label}: configuration merge is not case-insensitive distinct")
    if 'MergeConfigurationNames(list2[' not in source:
        issues.append(f"{label}: duplicate configured input is not merged into existing row")
    if 'list2.Add(NormalizeConfigurationNames(' not in source:
        issues.append(f"{label}: new configured input is not normalized before display")
    if 'NormalizeConfigurationNames(list2[' not in source:
        issues.append(f"{label}: duplicate plain input can still clear known configurations")
    bad_fragments = (
        '== 0, "", list2[',
        'list2[num9] = "";',
        'list2[num8] = "";',
    )
    for fragment in bad_fragments:
        if fragment in source:
            issues.append(f"{label}: legacy blank-preserving/clearing merge remains: {fragment}")
    if "SubItems.Add(list2[" not in source:
        issues.append(f"{label}: configuration list is not written to list-view subitem")
    return issues


def analyze_output_options(source: str) -> list[str]:
    issues: list[str] = []
    if "cfglist.Add(listView2.Items[num6].SubItems[3].Text);" not in source:
        issues.append("FrmOutputoptions: config list is not read from list-view SubItems[3]")
    if "forcurcfg.Checked" not in source:
        issues.append("FrmOutputoptions: per-imported-configuration option is not wired")
    if 'Strings.Split(cfglist[num6], "|\\n")' not in source:
        issues.append("FrmOutputoptions: merged configuration names are not split by the expected delimiter")
    if '"ShowConfiguration2"' not in source:
        issues.append("FrmOutputoptions: export path does not switch model configuration")
    return issues


def run_self_test() -> None:
    good_list_issues = analyze_list_source(GOOD_LIST_FIXTURE, "good-list")
    if good_list_issues:
        raise SystemExit(f"self-test good list fixture failed: {good_list_issues}")
    bad_list_issues = analyze_list_source(BAD_LIST_FIXTURE, "bad-list")
    if not bad_list_issues:
        raise SystemExit("self-test bad list fixture unexpectedly passed")
    good_output_issues = analyze_output_options(GOOD_OUTPUT_FIXTURE)
    if good_output_issues:
        raise SystemExit(f"self-test good output fixture failed: {good_output_issues}")
    bad_output_issues = analyze_output_options(BAD_OUTPUT_FIXTURE)
    if not bad_output_issues:
        raise SystemExit("self-test bad output fixture unexpectedly passed")
    print("self-test PASS")


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--self-test", action="store_true")
    parser.add_argument(
        "--list-source",
        action="append",
        default=[
            str(Path("client-src") / ("Z" + "Tool") / "FrmOutputlist.cs"),
            str(Path("client-src") / ("Z" + "Tool") / "FrmPrintlist.cs"),
        ],
    )
    parser.add_argument("--output-options-source", default=str(Path("client-src") / ("Z" + "Tool") / "FrmOutputoptions.cs"))
    args = parser.parse_args()

    if args.self_test:
        run_self_test()
        return 0

    issues: list[str] = []
    for source_name in args.list_source:
        source_path = Path(source_name)
        source = source_path.read_text(encoding="utf-8-sig")
        issues.extend(analyze_list_source(source, str(source_path)))

    output_path = Path(args.output_options_source)
    issues.extend(analyze_output_options(output_path.read_text(encoding="utf-8-sig")))

    if issues:
        for issue in issues:
            print(f"FAIL: {issue}")
        return 1
    print("PASS: batch conversion/print configuration mapping is guarded")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
