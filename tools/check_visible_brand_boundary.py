#!/usr/bin/env python3
"""Gate public SWTools brand boundary against legacy visible ZTool leaks.

The project intentionally keeps some internal `ZTool` identities for binary,
COM, resource and protocol compatibility. This gate makes those exceptions
explicit: every tracked text/path occurrence of `ZTool` must be listed in
`tools/brand_boundary/allowed_internal_ztool.tsv` with a stable count/hash.

Changing an existing occurrence or adding a new one therefore requires a visible
allowlist review instead of silently leaking the old product name back into UI,
docs or release evidence.
"""

from __future__ import annotations

import argparse
import dataclasses
import fnmatch
import hashlib
import subprocess
import sys
from pathlib import Path


TOKEN = "ZTool"
REPO_ROOT = Path(__file__).resolve().parents[1]
DEFAULT_ALLOWLIST = REPO_ROOT / "tools" / "brand_boundary" / "allowed_internal_ztool.tsv"

BINARY_SUFFIXES = {
    ".bmp",
    ".chm",
    ".dll",
    ".dmp",
    ".exe",
    ".ico",
    ".jpg",
    ".jpeg",
    ".pdf",
    ".png",
    ".sldasm",
    ".slddrw",
    ".sldprt",
    ".xlsx",
    ".zip",
}


@dataclasses.dataclass(frozen=True)
class Finding:
    path: str
    surface: str
    count: int
    digest: str


@dataclasses.dataclass(frozen=True)
class Rule:
    path_pattern: str
    surface: str
    expected_count: int
    digest: str
    reason: str


def sha256_text(text: str) -> str:
    return hashlib.sha256(text.encode("utf-8")).hexdigest()


def run_git_ls_files(root: Path) -> list[str]:
    result = subprocess.run(
        ["git", "ls-files", "-z"],
        cwd=root,
        check=True,
        stdout=subprocess.PIPE,
    )
    return [name for name in result.stdout.decode("utf-8").split("\0") if name]


def is_binary_path(path: Path) -> bool:
    suffixes = {suffix.lower() for suffix in path.suffixes}
    return bool(suffixes & BINARY_SUFFIXES)


def content_finding(rel: str, text: str) -> Finding | None:
    count = text.count(TOKEN)
    if count == 0:
        return None
    # Hash only token-bearing lines. This keeps the baseline stable when
    # unrelated text changes, but detects changed or newly added ZTool contexts.
    token_lines = [
        " ".join(line.strip().split())
        for line in text.splitlines()
        if TOKEN in line
    ]
    digest = sha256_text("\n".join(token_lines))
    return Finding(path=rel, surface="content", count=count, digest=digest)


def scan_repo(root: Path) -> list[Finding]:
    findings: list[Finding] = []
    for rel in run_git_ls_files(root):
        if (root / rel).resolve() == DEFAULT_ALLOWLIST.resolve():
            continue
        if TOKEN in rel:
            findings.append(
                Finding(
                    path=rel,
                    surface="path",
                    count=rel.count(TOKEN),
                    digest="-",
                )
            )

        path = root / rel
        if not path.is_file() or is_binary_path(path):
            continue
        try:
            text = path.read_text("utf-8", errors="replace")
        except OSError:
            continue
        finding = content_finding(rel, text)
        if finding:
            findings.append(finding)
    return sorted(findings, key=lambda item: (item.path, item.surface))


def classify_reason(path: str, surface: str) -> str:
    if surface == "path":
        return "internal compatibility path/resource identity; not user-facing by itself"
    if path.startswith(("client-src/", "client-src-addin/", "client-core/")):
        return "source compatibility / recovered legacy identity; visible strings remain separately gated"
    if path.startswith(("scripts/", "tools/", ".github/")):
        return "automation/test code references legacy compatibility name"
    if path.startswith(("docs/audit/", "docs/archive/", "manual-test-reports/", "dumps/")):
        return "historical audit or test evidence; not production-facing release UI"
    if path.startswith("docs/architecture/"):
        return "architecture contract describes legacy compatibility boundary"
    if path.startswith("docs/compliance/"):
        return "compliance/provenance attestation references legacy lineage"
    return "reviewed internal legacy reference; changes require brand-boundary review"


def parse_allowlist(path: Path) -> list[Rule]:
    rules: list[Rule] = []
    try:
        lines = path.read_text("utf-8").splitlines()
    except FileNotFoundError:
        raise SystemExit(f"allowlist not found: {path}") from None

    for line_no, line in enumerate(lines, 1):
        raw = line.strip()
        if not raw or raw.startswith("#"):
            continue
        parts = line.split("\t")
        if len(parts) != 5:
            raise SystemExit(f"{path}:{line_no}: expected 5 TSV columns")
        path_pattern, surface, count_text, digest, reason = parts
        if surface not in {"path", "content"}:
            raise SystemExit(f"{path}:{line_no}: invalid surface {surface!r}")
        try:
            expected_count = int(count_text)
        except ValueError:
            raise SystemExit(f"{path}:{line_no}: invalid expected_count {count_text!r}") from None
        if not reason.strip():
            raise SystemExit(f"{path}:{line_no}: empty reason")
        rules.append(Rule(path_pattern, surface, expected_count, digest, reason))
    return rules


def matching_rules(finding: Finding, rules: list[Rule]) -> list[Rule]:
    return [
        rule
        for rule in rules
        if rule.surface == finding.surface and fnmatch.fnmatchcase(finding.path, rule.path_pattern)
    ]


def evaluate(findings: list[Finding], rules: list[Rule]) -> list[str]:
    errors: list[str] = []
    seen_rules: set[tuple[str, str]] = set()

    for finding in findings:
        matches = matching_rules(finding, rules)
        if not matches:
            errors.append(
                f"{finding.path}: unallowlisted {finding.surface} occurrence of {TOKEN} "
                f"(count={finding.count})"
            )
            continue
        exact = [rule for rule in matches if rule.path_pattern == finding.path]
        rule = exact[0] if exact else matches[0]
        seen_rules.add((rule.path_pattern, rule.surface))
        if finding.count != rule.expected_count:
            errors.append(
                f"{finding.path}: {finding.surface} {TOKEN} count drift: "
                f"expected {rule.expected_count}, got {finding.count}"
            )
        if rule.digest != "-" and finding.digest != rule.digest:
            errors.append(
                f"{finding.path}: {finding.surface} {TOKEN} context hash drift: "
                f"expected {rule.digest}, got {finding.digest}"
            )

    finding_keys = {(item.path, item.surface) for item in findings}
    for rule in rules:
        if "*" in rule.path_pattern or "?" in rule.path_pattern or "[" in rule.path_pattern:
            continue
        if (rule.path_pattern, rule.surface) not in finding_keys:
            errors.append(
                f"{rule.path_pattern}: allowlist entry no longer has {rule.surface} {TOKEN} occurrence"
            )
    return errors


def write_allowlist(path: Path, findings: list[Finding]) -> None:
    lines = [
        "# path_pattern\tsurface\texpected_count\tztool_context_sha256\treason",
        "# Generated by tools/check_visible_brand_boundary.py --write-allowlist.",
        "# Every entry is a reviewed internal/historical compatibility exception, not a public brand approval.",
    ]
    for finding in findings:
        lines.append(
            "\t".join(
                [
                    finding.path,
                    finding.surface,
                    str(finding.count),
                    finding.digest,
                    classify_reason(finding.path, finding.surface),
                ]
            )
        )
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text("\n".join(lines) + "\n", encoding="utf-8")


def run_self_test() -> int:
    findings = [
        Finding("client-src/ZTool.csproj", "path", 1, "-"),
        Finding("client-src/ZTool.csproj", "content", 2, "abc"),
    ]
    rules = [
        Rule("client-src/ZTool.csproj", "path", 1, "-", "internal project identity"),
        Rule("client-src/ZTool.csproj", "content", 2, "abc", "internal assembly identity"),
    ]
    assert evaluate(findings, rules) == []
    assert evaluate([Finding("docs/public.md", "content", 1, "x")], rules)
    assert evaluate([Finding("client-src/ZTool.csproj", "content", 3, "abc")], rules)
    assert evaluate([Finding("client-src/ZTool.csproj", "content", 2, "changed")], rules)
    assert evaluate([], rules)
    print("visible brand boundary self-test OK")
    return 0


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--allowlist", default=str(DEFAULT_ALLOWLIST))
    parser.add_argument("--write-allowlist", action="store_true")
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args(argv)

    if args.self_test:
        return run_self_test()

    allowlist_path = Path(args.allowlist)
    findings = scan_repo(REPO_ROOT)
    if args.write_allowlist:
        write_allowlist(allowlist_path, findings)
        print(f"wrote {len(findings)} brand-boundary allowlist entries: {allowlist_path}")
        return 0

    rules = parse_allowlist(allowlist_path)
    errors = evaluate(findings, rules)
    if errors:
        print("Visible brand boundary check failed:")
        for error in errors[:200]:
            print(f"  - {error}")
        if len(errors) > 200:
            print(f"  ... {len(errors) - 200} more")
        return 1

    print(f"Visible brand boundary OK: {len(findings)} reviewed {TOKEN} compatibility surfaces")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
