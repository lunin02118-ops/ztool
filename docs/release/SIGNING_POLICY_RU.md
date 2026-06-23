# Signing policy

Дата: 2026-06-23
Scope: Sprint N / final release trust chain.

## Правило

`-AllowUnsigned` is CI evidence only. Он допустим только для фиксации текущего
unsigned состояния в audit artifacts. Он не является production approval.

Production verification command must run without `-AllowUnsigned`, unless a
formal release exception is explicitly recorded in the release dossier and
GO/NO-GO decision.

## Required artifacts

Перед P4 GO должны быть проверены:

- `SWTools-<version>-Setup.exe`;
- `SWTools.exe`;
- `SWTools.dll`;
- `SWTools-base.exe`, если входит в package/runtime;
- bundled runtime DLLs when distributed with the package.

## Commands

CI evidence mode only:

```powershell
pwsh -NoProfile -File scripts\verify_authenticode.ps1 `
  -Path <artifacts> `
  -ReportPath artifacts\authenticode-ci-evidence.json `
  -AllowUnsigned
```

Production mode:

```powershell
pwsh -NoProfile -File scripts\verify_authenticode.ps1 `
  -Path <artifacts> `
  -ReportPath artifacts\authenticode-production.json
```

## Acceptance

```text
[ ] Setup.exe signature = Valid.
[ ] Runtime signatures = Valid, or formal release exception exists.
[ ] Timestamp certificate present where applicable.
[ ] Report references exact artifact paths and hashes.
[ ] Production GO does not rely on `-AllowUnsigned`.
```

## Exception policy

Unsigned release artifacts are P1/P0 release blockers unless all are true:

1. exception is explicitly listed in `RELEASE_DOSSIER_<version>_RU.md`;
2. risk owner approves the exception outside the code diff;
3. hashes/provenance are immutable and published in the dossier;
4. user acceptance confirms SmartScreen/AV/installer behavior.
