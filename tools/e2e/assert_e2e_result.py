#!/usr/bin/env python3
"""Validate SWTools E2E result JSON."""

from __future__ import annotations

import argparse
import json
import sys
from pathlib import Path


VALID_STATUSES = {"PASS", "PASS_WITH_WARN", "FAIL"}


def fail(message: str) -> int:
    print(f"E2E assertion failed: {message}", file=sys.stderr)
    return 1


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("result_json", type=Path)
    parser.add_argument("--allow-warn", action="store_true")
    parser.add_argument("--allow-production-go", action="store_true")
    parser.add_argument("--require-stage", action="append", default=[])
    parser.add_argument("--expect-status", choices=sorted(VALID_STATUSES))
    args = parser.parse_args()

    if not args.result_json.is_file():
        return fail(f"missing result JSON: {args.result_json}")

    data = json.loads(args.result_json.read_text(encoding="utf-8"))
    status = data.get("status")
    if status not in VALID_STATUSES:
        return fail(f"invalid status: {status!r}")
    if args.expect_status and status != args.expect_status:
        return fail(f"expected status {args.expect_status}, got {status}")
    if status == "FAIL":
        return fail("status is FAIL")
    if status == "PASS_WITH_WARN" and not args.allow_warn:
        return fail("status is PASS_WITH_WARN but --allow-warn was not passed")

    if data.get("production_go_allowed") and not args.allow_production_go:
        return fail("production_go_allowed=true is not accepted by this assertion")

    stages = data.get("stages")
    if not isinstance(stages, list):
        return fail("stages must be a list")
    stage_names = {stage.get("name") for stage in stages if isinstance(stage, dict)}
    for required in args.require_stage:
        if required not in stage_names:
            return fail(f"required stage missing: {required}")

    print(
        "E2E assertion PASS: "
        f"status={status}, production_go_allowed={data.get('production_go_allowed')}, "
        f"stages={len(stages)}"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
