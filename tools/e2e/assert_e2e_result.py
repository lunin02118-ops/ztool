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
    parser.add_argument("--require-stage-pass", action="append", default=[])
    parser.add_argument("--require-stage-status", action="append", default=[], metavar="NAME=STATUS")
    parser.add_argument("--require-s7-min-rows", type=int)
    parser.add_argument("--require-s7-min-columns", type=int)
    parser.add_argument("--require-s8-mode-count", type=int)
    parser.add_argument("--require-s8-all-pass", action="store_true")
    parser.add_argument("--require-s8-strict-filters", action="store_true")
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
    stage_by_name = {stage.get("name"): stage for stage in stages if isinstance(stage, dict)}
    for required in [*args.require_stage, *args.require_stage_pass]:
        stage = stage_by_name.get(required)
        if stage is None:
            return fail(f"required stage missing: {required}")
        if stage.get("status") != "PASS":
            return fail(
                f"required stage must be PASS: {required} "
                f"(actual {stage.get('status')!r})"
            )
    for spec in args.require_stage_status:
        if "=" not in spec:
            return fail(f"--require-stage-status must be NAME=STATUS, got {spec!r}")
        name, expected = spec.split("=", 1)
        if expected not in {"PASS", "WARN", "FAIL", "SKIP"}:
            return fail(f"invalid expected stage status for {name}: {expected!r}")
        stage = stage_by_name.get(name)
        if stage is None:
            return fail(f"required stage missing: {name}")
        actual = stage.get("status")
        if actual != expected:
            return fail(f"stage {name} expected {expected}, got {actual!r}")

    if args.require_s7_min_rows is not None or args.require_s7_min_columns is not None:
        stage = stage_by_name.get("07-s7-connect")
        if stage is None:
            return fail("S7 stage missing")
        if stage.get("status") != "PASS":
            return fail(f"S7 stage must be PASS, got {stage.get('status')!r}")
        details = stage.get("details") or {}
        row_count = details.get("row_count")
        column_count = details.get("column_count")
        if args.require_s7_min_rows is not None:
            if not isinstance(row_count, int) or row_count < args.require_s7_min_rows:
                return fail(f"S7 row_count must be >= {args.require_s7_min_rows}, got {row_count!r}")
        if args.require_s7_min_columns is not None:
            if not isinstance(column_count, int) or column_count < args.require_s7_min_columns:
                return fail(
                    f"S7 column_count must be >= {args.require_s7_min_columns}, "
                    f"got {column_count!r}"
                )

    if args.require_s8_mode_count is not None or args.require_s8_all_pass or args.require_s8_strict_filters:
        export_stage = stage_by_name.get("08-s8-bom-export")
        validation_stage = stage_by_name.get("09-excel-validation")
        if export_stage is None:
            return fail("S8 export stage missing")
        if validation_stage is None:
            return fail("S8 Excel validation stage missing")
        if export_stage.get("status") != "PASS":
            return fail(f"S8 export stage must be PASS, got {export_stage.get('status')!r}")
        if validation_stage.get("status") != "PASS":
            return fail(f"S8 validation stage must be PASS, got {validation_stage.get('status')!r}")
        export_details = export_stage.get("details") or {}
        validation_details = validation_stage.get("details") or {}
        mode_count = export_details.get("mode_count")
        if args.require_s8_mode_count is not None:
            if not isinstance(mode_count, int) or mode_count != args.require_s8_mode_count:
                return fail(f"S8 mode_count must be {args.require_s8_mode_count}, got {mode_count!r}")
        issues = validation_details.get("issues") or []
        if args.require_s8_all_pass and issues:
            return fail(f"S8 validation issues must be empty, got {issues!r}")
        if args.require_s8_strict_filters and not validation_details.get("strict_filters"):
            return fail("S8 strict filter validation was required but not recorded")

    print(
        "E2E assertion PASS: "
        f"status={status}, production_go_allowed={data.get('production_go_allowed')}, "
        f"stages={len(stages)}"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
