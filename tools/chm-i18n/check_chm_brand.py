#!/usr/bin/env python3
"""Verify visible CHM branding by binary scan and HTML Help decompile."""

from __future__ import annotations

import argparse
import json
import subprocess
import sys
import tempfile
from pathlib import Path
from typing import Iterable


TEXT_SUFFIXES = {".htm", ".html", ".hhc", ".hhk", ".hhp", ".txt"}
DECODINGS = ("utf-8", "cp1251", "gbk", "latin-1")


def fail(message: str) -> int:
    print(f"CHM brand check failed: {message}", file=sys.stderr)
    return 1


def token_bytes(token: str) -> list[bytes]:
    return [
        token.encode("utf-8"),
        token.encode("cp1251", errors="ignore"),
        token.encode("utf-16le"),
        token.encode("utf-16be"),
    ]


def count_binary_token(data: bytes, token: str) -> int:
    seen: set[bytes] = set()
    total = 0
    for encoded in token_bytes(token):
        if not encoded or encoded in seen:
            continue
        seen.add(encoded)
        total += data.count(encoded)
    return total


def read_text(path: Path) -> str:
    raw = path.read_bytes()
    for encoding in DECODINGS:
        try:
            return raw.decode(encoding)
        except UnicodeDecodeError:
            continue
    return raw.decode("latin-1", errors="replace")


def scan_text_files(root: Path, tokens: Iterable[str]) -> tuple[int, dict[str, list[str]]]:
    files = [path for path in root.rglob("*") if path.is_file() and path.suffix.lower() in TEXT_SUFFIXES]
    matches: dict[str, list[str]] = {token: [] for token in tokens}
    for path in files:
        text = read_text(path)
        rel = str(path.relative_to(root))
        for token in tokens:
            if token and token in text:
                matches[token].append(rel)
    return len(files), matches


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


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("chm", type=Path)
    parser.add_argument("--hh-exe", type=Path, default=Path(r"C:\Windows\hh.exe"))
    parser.add_argument("--forbid", action="append", default=[])
    parser.add_argument("--require", action="append", default=[])
    parser.add_argument("--min-text-files", type=int, default=3)
    parser.add_argument("--json-out", type=Path)
    args = parser.parse_args()

    chm_path = args.chm.resolve()
    hh_exe = args.hh_exe.resolve()
    if not chm_path.is_file():
        return fail(f"CHM not found: {chm_path}")
    if not hh_exe.is_file():
        return fail(f"hh.exe not found: {hh_exe}")
    forbid = args.forbid or ["ZTool"]
    require = args.require or ["SWTools"]

    data = chm_path.read_bytes()
    binary_forbidden = {token: count_binary_token(data, token) for token in forbid}
    binary_required = {token: count_binary_token(data, token) for token in require}

    with tempfile.TemporaryDirectory(prefix="swtools-chm-brand-") as temp:
        extract_dir = Path(temp) / "extract"
        decompile_chm(hh_exe, chm_path, extract_dir)
        text_file_count, text_matches = scan_text_files(extract_dir, [*forbid, *require])

        result = {
            "status": "PASS",
            "chm": str(chm_path),
            "hh_exe": str(hh_exe),
            "text_file_count": text_file_count,
            "binary_forbidden": binary_forbidden,
            "binary_required": binary_required,
            "text_matches": text_matches,
        }

        errors: list[str] = []
        if text_file_count < args.min_text_files:
            errors.append(f"decompiled text file count {text_file_count} < {args.min_text_files}")
        for token, count in binary_forbidden.items():
            if count:
                errors.append(f"forbidden token {token!r} found in CHM binary {count} time(s)")
        for token in forbid:
            if text_matches.get(token):
                errors.append(f"forbidden token {token!r} found in decompiled files: {text_matches[token]}")
        for token in require:
            if not binary_required.get(token) and not text_matches.get(token):
                errors.append(f"required token {token!r} was not found in CHM binary or decompiled files")

        if errors:
            result["status"] = "FAIL"
            result["errors"] = errors

        if args.json_out:
            args.json_out.parent.mkdir(parents=True, exist_ok=True)
            args.json_out.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")

        if errors:
            return fail("; ".join(errors))

    print(
        "CHM brand check PASS: "
        f"chm={chm_path}, text_files={text_file_count}, "
        f"forbid={forbid}, require={require}"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
