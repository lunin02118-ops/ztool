#!/usr/bin/env python3
"""Verify runtime help entry routes point to existing Russian CHM topics."""

from __future__ import annotations

import argparse
import json
import subprocess
import sys
import tempfile
from pathlib import Path
from typing import Any


ENTRY_POINTS = [
    {
        "id": "H-01",
        "source": Path("client-src/ZTool/Frmexportbom.cs"),
        "expected_route": "/advanced/bom-template.htm",
        "legacy_route": "/进阶操作/BOM表模板制作和导出.htm",
        "topic": Path("advanced/bom-template.htm"),
    },
    {
        "id": "H-02",
        "source": Path("client-src/ZTool/FrmPreview.cs"),
        "expected_route": "/advanced/thumbnails.htm",
        "legacy_route": "/进阶操作/缩略图显示及操作.htm",
        "topic": Path("advanced/thumbnails.htm"),
    },
    {
        "id": "H-03",
        "source": Path("client-src/ZTool/FrmSaveOption.cs"),
        "expected_route": "/basic/save-to-sw.htm",
        "legacy_route": "/基本操作/保存数据到SolidWorks.htm",
        "topic": Path("basic/save-to-sw.htm"),
    },
]


def fail(message: str) -> int:
    print(f"CHM help route check failed: {message}", file=sys.stderr)
    return 1


def decompile_chm(hh_exe: Path, chm_path: Path, extract_dir: Path) -> None:
    extract_dir.mkdir(parents=True, exist_ok=True)
    subprocess.run(
        [str(hh_exe), "-decompile", str(extract_dir), str(chm_path)],
        check=False,
        stdout=subprocess.PIPE,
        stderr=subprocess.PIPE,
        text=True,
        encoding="utf-8",
        errors="replace",
    )


def evaluate(source_root: Path, extract_dir: Path) -> dict[str, Any]:
    entries: list[dict[str, Any]] = []
    errors: list[str] = []

    for entry in ENTRY_POINTS:
        source_path = source_root / entry["source"]
        topic_path = extract_dir / entry["topic"]
        source_text = source_path.read_text(encoding="utf-8", errors="replace") if source_path.is_file() else ""

        has_expected_route = entry["expected_route"] in source_text
        has_legacy_route = entry["legacy_route"] in source_text
        has_topic = topic_path.is_file()

        item = {
            "id": entry["id"],
            "source": str(entry["source"]).replace("\\", "/"),
            "expected_route": entry["expected_route"],
            "legacy_route": entry["legacy_route"],
            "topic": str(entry["topic"]).replace("\\", "/"),
            "has_expected_route": has_expected_route,
            "has_legacy_route": has_legacy_route,
            "topic_exists": has_topic,
        }
        entries.append(item)

        if not source_path.is_file():
            errors.append(f"{entry['id']}: source file not found: {source_path}")
        if not has_expected_route:
            errors.append(f"{entry['id']}: expected route missing in source: {entry['expected_route']}")
        if has_legacy_route:
            errors.append(f"{entry['id']}: legacy Han route still present in source: {entry['legacy_route']}")
        if not has_topic:
            errors.append(f"{entry['id']}: CHM topic not found after decompile: {entry['topic']}")

    return {
        "status": "FAIL" if errors else "PASS",
        "entries": entries,
        "errors": errors,
    }


def run_self_test() -> int:
    with tempfile.TemporaryDirectory(prefix="swtools-help-routes-selftest-") as temp:
        root = Path(temp)
        src = root / "src"
        extract = root / "extract"
        (src / "client-src/ZTool").mkdir(parents=True)
        (extract / "advanced").mkdir(parents=True)
        (extract / "basic").mkdir(parents=True)
        (src / "client-src/ZTool/Frmexportbom.cs").write_text('Help.ShowHelp(this, code.helpfile, "/advanced/bom-template.htm");\n', encoding="utf-8")
        (src / "client-src/ZTool/FrmPreview.cs").write_text('Help.ShowHelp(this, code.helpfile, "/advanced/thumbnails.htm");\n', encoding="utf-8")
        (src / "client-src/ZTool/FrmSaveOption.cs").write_text('Help.ShowHelp(this, code.helpfile, "/basic/save-to-sw.htm");\n', encoding="utf-8")
        (extract / "advanced/bom-template.htm").write_text("ok", encoding="utf-8")
        (extract / "advanced/thumbnails.htm").write_text("ok", encoding="utf-8")
        (extract / "basic/save-to-sw.htm").write_text("ok", encoding="utf-8")

        good = evaluate(src, extract)
        assert good["status"] == "PASS", good

        (src / "client-src/ZTool/FrmPreview.cs").write_text('Help.ShowHelp(this, code.helpfile, "/进阶操作/缩略图显示及操作.htm");\n', encoding="utf-8")
        bad_legacy = evaluate(src, extract)
        assert bad_legacy["status"] == "FAIL", bad_legacy
        assert any("legacy Han route" in error or "expected route missing" in error for error in bad_legacy["errors"]), bad_legacy

        (src / "client-src/ZTool/FrmPreview.cs").write_text('Help.ShowHelp(this, code.helpfile, "/advanced/thumbnails.htm");\n', encoding="utf-8")
        (extract / "advanced/thumbnails.htm").unlink()
        bad_topic = evaluate(src, extract)
        assert bad_topic["status"] == "FAIL", bad_topic
        assert any("CHM topic not found" in error for error in bad_topic["errors"]), bad_topic

    print("CHM help route self-test PASS")
    return 0


def main() -> int:
    if hasattr(sys.stdout, "reconfigure"):
        sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    if hasattr(sys.stderr, "reconfigure"):
        sys.stderr.reconfigure(encoding="utf-8", errors="replace")

    parser = argparse.ArgumentParser()
    parser.add_argument("--source-root", type=Path, default=Path("."))
    parser.add_argument("--chm", type=Path, default=Path("help_ru.chm"))
    parser.add_argument("--hh-exe", type=Path, default=Path(r"C:\Windows\hh.exe"))
    parser.add_argument("--json-out", type=Path)
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        return run_self_test()

    source_root = args.source_root.resolve()
    chm_path = args.chm.resolve()
    hh_exe = args.hh_exe.resolve()
    if not source_root.is_dir():
        return fail(f"source root not found: {source_root}")
    if not chm_path.is_file():
        return fail(f"CHM not found: {chm_path}")
    if not hh_exe.is_file():
        return fail(f"hh.exe not found: {hh_exe}")

    with tempfile.TemporaryDirectory(prefix="swtools-help-routes-") as temp:
        extract_dir = Path(temp) / "extract"
        decompile_chm(hh_exe, chm_path, extract_dir)
        result = evaluate(source_root, extract_dir)
        result.update(
            {
                "source_root": str(source_root),
                "chm": str(chm_path),
                "hh_exe": str(hh_exe),
            }
        )

        if args.json_out:
            args.json_out.parent.mkdir(parents=True, exist_ok=True)
            args.json_out.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")

        if result["errors"]:
            return fail("; ".join(result["errors"]))

    print(f"CHM help route check PASS: chm={chm_path}, entries={len(ENTRY_POINTS)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
