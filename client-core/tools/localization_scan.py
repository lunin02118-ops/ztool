#!/usr/bin/env python3
"""Machine-readable localization gate for ZTool.exe.

The C# Localizer remains the source of truth for binary edits. This wrapper
turns its scan output plus translations.tsv/whitelists into a JSON report that
CI and auditors can consume.
"""

from __future__ import annotations

import argparse
import json
import re
import subprocess
import sys
from pathlib import Path


HAN_RE = re.compile(r"[\u4e00-\u9fff]")
LDSTR_RE = re.compile(r'^\[(?P<context>[^\]]+)\]\s+"(?P<value>.*)"$')
RES_RE = re.compile(r'^\[(?P<resource>[^\]]+)\]\s+(?P<key>.*?)\s+=\s+"(?P<value>.*)"$')


def configure_stdio() -> None:
    """Keep Windows console encodings from crashing JSON output with Han text."""
    for stream in (sys.stdout, sys.stderr):
        reconfigure = getattr(stream, "reconfigure", None)
        if reconfigure is not None:
            reconfigure(encoding="utf-8", errors="replace")


def has_han(value: str) -> bool:
    return bool(HAN_RE.search(value or ""))


def unescape_tsv(value: str) -> str:
    out: list[str] = []
    i = 0
    while i < len(value):
        ch = value[i]
        if ch != "\\" or i + 1 >= len(value):
            out.append(ch)
            i += 1
            continue
        i += 1
        marker = value[i]
        if marker == "t":
            out.append("\t")
        elif marker == "r":
            out.append("\r")
        elif marker == "n":
            out.append("\n")
        elif marker == "u" and i + 4 < len(value):
            out.append(chr(int(value[i + 1:i + 5], 16)))
            i += 4
        else:
            out.append(marker)
        i += 1
    return "".join(out)


def read_lines(path: Path) -> list[str]:
    if not path.exists():
        return []
    result: list[str] = []
    for raw in path.read_text(encoding="utf-8").splitlines():
        line = raw.strip()
        if not line or line.startswith("#"):
            continue
        result.append(line)
    return result


def load_whitelist(path: Path) -> dict[str, set[str]]:
    return {
        "protocol_key": set(read_lines(path / "whitelist_protocol_keys.txt")),
        "font_name": set(read_lines(path / "whitelist_font_names.txt")),
        "technical_log": set(read_lines(path / "whitelist_technical_logs.txt")),
        "known_remaining": set(read_lines(path / "whitelist_known_chinese_remaining.txt")),
    }


def classify(value: str, whitelist: dict[str, set[str]]) -> str | None:
    if value in whitelist["protocol_key"]:
        return "protocol_key"
    if value in whitelist["font_name"]:
        return "font_name"
    if any(token in value for token in whitelist["technical_log"]):
        return "technical_log"
    if value in whitelist["known_remaining"]:
        return "known_remaining"
    return None


def load_translations(path: Path, whitelist: dict[str, set[str]]) -> tuple[dict[str, str], list[dict]]:
    translations: dict[str, str] = {}
    diagnostics: list[dict] = []
    seen: dict[str, int] = {}

    for lineno, raw in enumerate(path.read_text(encoding="utf-8").splitlines(), start=1):
        if not raw or raw.startswith("#"):
            continue
        if "\t" not in raw:
            diagnostics.append({"level": "error", "line": lineno, "message": "missing tab"})
            continue
        zh_raw, ru_raw = raw.split("\t", 1)
        zh = unescape_tsv(zh_raw)
        ru = unescape_tsv(ru_raw)
        if not zh:
            diagnostics.append({"level": "error", "line": lineno, "message": "empty source"})
            continue

        if zh in seen:
            diagnostics.append({
                "level": "error",
                "line": lineno,
                "message": f"duplicate source, first seen at line {seen[zh]}",
                "source": zh,
            })
        seen[zh] = lineno

        category = classify(zh, whitelist)
        if ru and category in {"protocol_key", "font_name"}:
            diagnostics.append({
                "level": "error",
                "line": lineno,
                "message": f"{category} must not be translated",
                "source": zh,
            })

        if has_han(zh) and not ru and category is None:
            diagnostics.append({
                "level": "warning",
                "line": lineno,
                "message": "Han source has empty RU and is not whitelisted",
                "source": zh,
            })

        if ru and zh != ru:
            translations[zh] = ru

    return translations, diagnostics


def run_localizer(localizer_project: Path, dotnet: str, exe: Path, mode: str) -> list[str]:
    command = [
        dotnet,
        "run",
        "-c",
        "Release",
        "--project",
        str(localizer_project),
        "--",
        mode,
        str(exe),
    ]
    try:
        result = subprocess.run(
            command,
            check=True,
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
            text=True,
            encoding="utf-8",
            errors="replace",
        )
    except FileNotFoundError as exc:
        raise RuntimeError(f"dotnet executable not found: {dotnet}") from exc
    except subprocess.CalledProcessError as exc:
        details = "\n".join(
            part for part in [exc.stdout.strip(), exc.stderr.strip()] if part
        )
        suffix = f"\n{details}" if details else ""
        raise RuntimeError(
            f"Localizer scan command failed with exit code {exc.returncode}: {' '.join(command)}"
            f"{suffix}"
        ) from exc
    return result.stdout.splitlines()


def scan_exe(localizer_project: Path, dotnet: str, exe: Path) -> list[dict]:
    entries: list[dict] = []
    for line in run_localizer(localizer_project, dotnet, exe, "--scan"):
        match = LDSTR_RE.match(line)
        if not match:
            continue
        value = match.group("value")
        if has_han(value):
            entries.append({
                "kind": "ldstr",
                "context": match.group("context"),
                "value": value,
            })

    for line in run_localizer(localizer_project, dotnet, exe, "--scanres"):
        match = RES_RE.match(line)
        if not match:
            continue
        value = match.group("value")
        if has_han(value):
            entries.append({
                "kind": "resource",
                "context": f"{match.group('resource')}::{match.group('key')}",
                "value": value,
            })

    return entries


def build_report(args) -> dict:
    whitelist = load_whitelist(args.whitelist_dir)
    translations, diagnostics = load_translations(args.translations, whitelist)

    report = {
        "translations": {
            "path": str(args.translations),
            "translated_count": len(translations),
            "diagnostics": diagnostics,
        },
        "whitelist": {key: sorted(values) for key, values in whitelist.items()},
        "scan": None,
        "summary": {
            "errors": sum(1 for item in diagnostics if item["level"] == "error"),
            "warnings": sum(1 for item in diagnostics if item["level"] == "warning"),
            "unclassified_han": 0,
        },
    }

    if args.exe:
        entries = scan_exe(args.localizer_project, args.dotnet, args.exe)
        classified: list[dict] = []
        unclassified: list[dict] = []
        for entry in entries:
            value = entry["value"]
            category = classify(value, whitelist)
            translated = value in translations
            item = {
                **entry,
                "translated": translated,
                "category": category,
            }
            if not translated and category is None:
                unclassified.append(item)
            else:
                classified.append(item)
        report["scan"] = {
            "exe": str(args.exe),
            "han_entries": len(entries),
            "classified_or_translated": classified,
            "unclassified_han": unclassified,
        }
        report["summary"]["unclassified_han"] = len(unclassified)

    return report


def main() -> int:
    configure_stdio()
    parser = argparse.ArgumentParser(description="Validate ZTool localization state")
    parser.add_argument("--exe", type=Path, default=None, help="Localized ZTool.exe to scan")
    parser.add_argument("--translations", type=Path, required=True, help="translations.tsv")
    parser.add_argument("--whitelist-dir", type=Path, default=Path("localization"))
    parser.add_argument(
        "--localizer-project",
        type=Path,
        default=Path("client-core/tools/Localizer"),
        help="Path to C# Localizer project",
    )
    parser.add_argument("--dotnet", default="dotnet", help="dotnet executable")
    parser.add_argument("--report", type=Path, default=None, help="Write JSON report")
    parser.add_argument("--fail-on-unclassified", action="store_true")
    args = parser.parse_args()

    try:
        report = build_report(args)
    except RuntimeError as exc:
        print(f"localization_scan error: {exc}", file=sys.stderr)
        return 2
    payload = json.dumps(report, ensure_ascii=False, indent=2)
    if args.report:
        args.report.parent.mkdir(parents=True, exist_ok=True)
        args.report.write_text(payload + "\n", encoding="utf-8")
        print(f"localization report written to: {args.report}")
    else:
        print(payload)

    if report["summary"]["errors"]:
        return 1
    if args.fail_on_unclassified and report["summary"]["unclassified_han"]:
        return 1
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
