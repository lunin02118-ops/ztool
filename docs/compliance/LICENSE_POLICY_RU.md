# License policy

## Allowed without additional approval

- `MIT`
- `BSD-2-Clause`
- `BSD-3-Clause`
- `Apache-2.0`
- dev-only mixed OSS tooling, если оно не попадает в shipped client/runtime package.

## Review required

- `UNKNOWN`
- `LEGAL-APPROVAL-PENDING`
- `AGPL-3.0-only`
- any copyleft/commercial/unclear license.

Review-required component must have `exception_id` in `docs/compliance/third_party_inventory.json`.

## Prohibited without explicit exception

- GPL/AGPL/LGPL/SSPL/BUSL/copyleft/commercially ambiguous dependencies in shipped runtime.
- Any dependency with missing origin/license.
- Any private/proprietary binary without documented distribution approval.

## Gate behavior

`scripts/check_license_policy.ps1` fails on:

- missing inventory;
- malformed inventory item;
- prohibited status;
- denylisted license without `exception_id`;
- missing license/status/origin/path.

Review-required components with explicit `exception_id` are allowed only as temporary P4 blockers, not as final GO approval.
