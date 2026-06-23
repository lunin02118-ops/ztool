# Repo hygiene report

Дата: 2026-06-23
Scope: Sprint L / repo hygiene and artifact custody.

## Verdict

`PARTIAL PASS / LEGACY EVIDENCE CLEANUP REMAINS`

Что закрыто этим PR:

- `client-rekey/*.txt` удалены из Git tracking;
- `client-rekey/.gitignore` теперь запрещает новые local `.txt` inputs;
- `client-rekey/README.md` переносит rekey input material в
  `_local_artifacts\secrets\client-rekey\`;
- добавлен `scripts/check_repo_hygiene.ps1`, который падает на prohibited
  tracked artifacts.

## Gate result

Command:

```powershell
pwsh -NoProfile -File scripts\check_repo_hygiene.ps1 `
  -JsonOut _local_artifacts\reports\p4-lm\repo_hygiene_after_stage.json
```

Result after staging this PR:

```text
Repo hygiene PASS
prohibited_tracked_count = 0
legacy_tracked_evidence_count = 126
```

## Prohibited tracked patterns

`check_repo_hygiene.ps1` fails on:

- `_local_artifacts/`;
- `releases/`;
- `client-rekey/*.txt`;
- private/signing/key material: `.pfx`, `.pem`, `.key`,
  `license-server/keys/private_key.txt`, `keypair_info.json`;
- registry exports: `.reg`;
- raw dumps: `.dmp`, `.dump`;
- license-server runtime DB files.

## Legacy tracked evidence

The gate reports but does not fail on existing historical evidence:

- `dumps/**` recovery/binary artifacts referenced by older baseline docs;
- curated screenshots/logs under `manual-test-reports/**`.

These are not cleaned in this PR because some baseline/audit documents still
refer to them. Removing them safely requires a separate audited cleanup:

```text
[ ] replace dump binary references with hashes/provenance cards;
[ ] move large/raw screenshots to artifact storage;
[ ] keep only curated report summaries in Git;
[ ] update README/baseline docs after moving evidence.
```

## Current policy

New local releases, screenshots, logs, DB snapshots, registry exports, keys and
activation material belong under `_local_artifacts/` until curated.

No private legal/IP evidence, endpoint secrets, license keys or private approvals
may be committed.
