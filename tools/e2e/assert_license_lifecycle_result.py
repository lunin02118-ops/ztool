#!/usr/bin/env python3
"""Validate SWTools license lifecycle acceptance result JSON.

This gate is intentionally strict about the distinction between an automated
lifecycle proof and production approval: production_go_allowed=true is rejected
unless the caller explicitly overrides it.
"""

from __future__ import annotations

import argparse
import json
import sys
import tempfile
from pathlib import Path


VALID_TOP_STATUSES = {"PASS", "PASS_WITH_WARN", "FAIL"}
VALID_STAGE_STATUSES = {"PASS", "WARN", "FAIL", "SKIP"}


def fail(message: str) -> int:
    print(f"license lifecycle assertion failed: {message}", file=sys.stderr)
    return 1


def load_result(path: Path) -> dict:
    if not path.is_file():
        raise FileNotFoundError(path)
    return json.loads(path.read_text(encoding="utf-8"))


def stage_map(data: dict) -> dict[str, dict]:
    stages = data.get("stages")
    if not isinstance(stages, list):
        raise ValueError("stages must be a list")
    return {stage.get("name"): stage for stage in stages if isinstance(stage, dict)}


def require_pass(stages: dict[str, dict], name: str) -> None:
    stage = stages.get(name)
    if stage is None:
        raise AssertionError(f"missing stage: {name}")
    if stage.get("status") != "PASS":
        raise AssertionError(f"stage {name} must be PASS, got {stage.get('status')!r}")


def assert_common(data: dict, allow_warn: bool, allow_production_go: bool) -> None:
    status = data.get("status")
    if status not in VALID_TOP_STATUSES:
        raise AssertionError(f"invalid top-level status: {status!r}")
    if status == "FAIL":
        raise AssertionError("top-level status is FAIL")
    if status == "PASS_WITH_WARN" and not allow_warn:
        raise AssertionError("top-level status is PASS_WITH_WARN but --allow-warn was not passed")
    if data.get("production_go_allowed") and not allow_production_go:
        raise AssertionError("production_go_allowed=true is not accepted by this gate")

    stages = data.get("stages")
    if not isinstance(stages, list) or not stages:
        raise AssertionError("stages must be a non-empty list")
    for stage in stages:
        if not isinstance(stage, dict):
            raise AssertionError(f"stage must be an object: {stage!r}")
        if stage.get("status") not in VALID_STAGE_STATUSES:
            raise AssertionError(f"invalid stage status: {stage!r}")

    secret = data.get("license_secret") or {}
    if secret:
        if "code" in secret or "password" in secret:
            raise AssertionError("raw license code/password must not be present in result")
        lengths = secret.get("segment_lengths")
        if lengths is not None and lengths != [8, 5, 5, 5, 9]:
            raise AssertionError(f"invalid redacted license segment lengths: {lengths!r}")


def assert_lifecycle(
    data: dict,
    require_no_license: bool,
    require_activation: bool,
    require_transfer: bool,
    require_revoke: bool,
    require_delete: bool,
    require_repeat_check: bool,
) -> None:
    stages = stage_map(data)
    require_pass(stages, "00-contract")
    require_pass(stages, "01-secret-shape")

    if require_no_license:
        require_pass(stages, "02-no-license")
    if require_activation:
        require_pass(stages, "04-activation")
        require_pass(stages, "05-server-active-state")
        activation = stages["04-activation"].get("details") or {}
        if activation.get("restart_confirmed") is not True:
            raise AssertionError("activation stage must prove old PID exit + new PID start")
    if require_transfer:
        require_pass(stages, "05b-transfer-ui")
        details = stages["05b-transfer-ui"].get("details") or {}
        if details.get("success_modal_seen") is not True:
            raise AssertionError(f"transfer stage must prove success modal, got {details!r}")
        if details.get("server_released") is not True:
            raise AssertionError(f"transfer stage must prove server_released=true, got {details!r}")
        if details.get("local_unregistered") is not True:
            raise AssertionError(f"transfer stage must prove local_unregistered=true, got {details!r}")
        if details.get("current_activations") != 0:
            raise AssertionError(f"transfer stage must prove current_activations=0, got {details!r}")
        if details.get("machine_bound") not in (False, 0):
            raise AssertionError(f"transfer stage must prove machine_bound=false, got {details!r}")
    if require_revoke:
        require_pass(stages, "06-revoke")
        details = stages["06-revoke"].get("details") or {}
        if details.get("is_revoked") not in (1, True):
            raise AssertionError(f"revoke stage must prove is_revoked=true, got {details!r}")
    if require_delete:
        require_pass(stages, "07-delete-revoked")
        details = stages["07-delete-revoked"].get("details") or {}
        if details.get("deleted") is not True:
            raise AssertionError(f"delete stage must prove deleted=true, got {details!r}")
    if require_repeat_check:
        require_pass(stages, "08-repeat-check")


def run_self_test() -> int:
    good = {
        "status": "PASS",
        "production_go_allowed": False,
        "license_secret": {
            "code_mask": "ABCD...1234",
            "code_sha12": "0123456789ab",
            "segment_lengths": [8, 5, 5, 5, 9],
            "password_length": 10,
            "password_sha12": "abcdef012345",
        },
        "stages": [
            {"name": "00-contract", "status": "PASS"},
            {"name": "01-secret-shape", "status": "PASS"},
            {"name": "02-no-license", "status": "PASS"},
            {"name": "04-activation", "status": "PASS", "details": {"restart_confirmed": True}},
            {"name": "05-server-active-state", "status": "PASS"},
            {
                "name": "05b-transfer-ui",
                "status": "PASS",
                "details": {
                    "success_modal_seen": True,
                    "server_released": True,
                    "local_unregistered": True,
                    "current_activations": 0,
                    "machine_bound": False,
                },
            },
            {"name": "06-revoke", "status": "PASS", "details": {"is_revoked": True}},
            {"name": "07-delete-revoked", "status": "PASS", "details": {"deleted": True}},
            {"name": "08-repeat-check", "status": "PASS"},
        ],
    }
    bad_skip = {
        **good,
        "stages": [
            {"name": "00-contract", "status": "PASS"},
            {"name": "01-secret-shape", "status": "PASS"},
            {"name": "04-activation", "status": "SKIP", "details": {"restart_confirmed": True}},
            {"name": "05-server-active-state", "status": "PASS"},
        ],
    }
    bad_secret = {
        **good,
        "license_secret": {"code": "SHOULD-NOT-BE-HERE", "segment_lengths": [8, 5, 5, 5, 9]},
    }
    bad_production = {**good, "production_go_allowed": True}

    with tempfile.TemporaryDirectory() as td:
        root = Path(td)
        good_path = root / "good.json"
        bad_skip_path = root / "bad-skip.json"
        bad_secret_path = root / "bad-secret.json"
        bad_production_path = root / "bad-production.json"
        for path, payload in (
            (good_path, good),
            (bad_skip_path, bad_skip),
            (bad_secret_path, bad_secret),
            (bad_production_path, bad_production),
        ):
            path.write_text(json.dumps(payload), encoding="utf-8")

        for path in (good_path,):
            data = load_result(path)
            assert_common(data, allow_warn=False, allow_production_go=False)
            assert_lifecycle(
                data,
                require_no_license=True,
                require_activation=True,
                require_transfer=True,
                require_revoke=True,
                require_delete=True,
                require_repeat_check=True,
            )

        expected_failures = (
            (bad_skip_path, "skip activation"),
            (bad_secret_path, "raw secret"),
            (bad_production_path, "production go"),
        )
        for path, label in expected_failures:
            try:
                data = load_result(path)
                assert_common(data, allow_warn=False, allow_production_go=False)
                assert_lifecycle(
                    data,
                    require_no_license=False,
                    require_activation=True,
                    require_transfer=False,
                    require_revoke=False,
                    require_delete=False,
                    require_repeat_check=False,
                )
            except AssertionError:
                continue
            raise AssertionError(f"negative self-test unexpectedly passed: {label}")

    print("license lifecycle assertion self-test PASS")
    return 0


def main() -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("result_json", type=Path, nargs="?")
    parser.add_argument("--self-test", action="store_true")
    parser.add_argument("--allow-warn", action="store_true")
    parser.add_argument("--allow-production-go", action="store_true")
    parser.add_argument("--require-no-license", action="store_true")
    parser.add_argument("--require-activation", action="store_true")
    parser.add_argument("--require-transfer", action="store_true")
    parser.add_argument("--require-revoke", action="store_true")
    parser.add_argument("--require-delete", action="store_true")
    parser.add_argument("--require-repeat-check", action="store_true")
    args = parser.parse_args()

    if args.self_test:
        try:
            return run_self_test()
        except AssertionError as exc:
            return fail(str(exc))

    if args.result_json is None:
        return fail("result_json is required unless --self-test is used")
    try:
        data = load_result(args.result_json)
        assert_common(data, args.allow_warn, args.allow_production_go)
        assert_lifecycle(
            data,
            require_no_license=args.require_no_license,
            require_activation=args.require_activation,
            require_transfer=args.require_transfer,
            require_revoke=args.require_revoke,
            require_delete=args.require_delete,
            require_repeat_check=args.require_repeat_check,
        )
    except (AssertionError, FileNotFoundError, ValueError, json.JSONDecodeError) as exc:
        return fail(str(exc))

    print(
        "license lifecycle assertion PASS: "
        f"status={data.get('status')}, production_go_allowed={data.get('production_go_allowed')}, "
        f"stages={len(data.get('stages') or [])}"
    )
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
