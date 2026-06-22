# P4 evidence baseline

Дата: 2026-06-22
Локальный worktree: `_local_artifacts\worktrees\p4-production-hardening`
Цель baseline: зафиксировать исходное состояние для выполнения `docs/production/ZTOOL_P4_PERFECTION_PLAN_RU.md`.

## Git

| Поле | Значение |
|---|---|
| Branch | `codex/p4-production-hardening-baseline` |
| Base branch | `origin/advisor/20260622-p4-production-plan` |
| HEAD | `8663140 docs: add P4 production hardening plan` |
| Repo root | `D:/Development/ztool/_local_artifacts/worktrees/p4-production-hardening` |
| Dirty state при снятии baseline | clean |
| Связанный plan PR | `#66 docs: add P4 production hardening plan` |
| Зависимый source-of-truth PR | `#65 Phase E: build release package from source`, CI green, mergeState `CLEAN`, open |

## Version and Accepted Hashes

`VERSION`: `1.1.6`

Из `scripts/expected_release_hashes.json` на baseline HEAD:

| Artifact | Expected SHA256 |
|---|---|
| Setup.exe | `26aabcfbb6dec8538e96076df79d235a2b729bb73f2519d8b0513a03f155ab13` |
| Client EXE | `f418c7d81a735c309b4fb0709c8bd81333d95cfab9c7468aa2329add0a364e09` |
| Add-in DLL | `5dbf9986a4fbce5e6ab8fa4269705732c6ba891d1b27988e60e10c191ae290c1` |
| Ribbon.dll | `57e026815738a47e988048b95b354ab107cd80e559d0775d0897d68950e24e8e` |
| ExpandableGridView.dll | `89ec31d68a132c02f725903d52d5c5c7c422a2aa997a8a8444685a4374cefcc0` |
| ZTool_rsa.dll | `274a33f35b98437d57f7eadce21cfe855d5285e9012c1c33733a3ab1f0ec2a90` |

## Local Release Package Presence

| Path | Status |
|---|---|
| `releases/` | missing in this clean worktree |
| `releases/1.1.6` | missing in this clean worktree |

P4 checks that require the exact installer/package are therefore `BLOCKED` until a package is rebuilt or copied into the approved release location.

## Loose Root Runtime Files

| Path | SHA256 | Baseline status |
|---|---|---|
| `SWTools.exe` | `a57441105c5d02f8c01f920ac23e56a94ca027615520e7c29c5fb1c57fd73ec5` | historical loose binary, does not match accepted client hash |
| `SWTools.dll` | `d053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9` | historical loose binary, does not match accepted add-in hash |
| `SWTools-base.exe` | `c10ce334fdbbbc05b8186a6e657a22c1ed4add8bd638c59d65e5b6798cb4b18d` | historical base input |
| `Ribbon.dll` | `57e026815738a47e988048b95b354ab107cd80e559d0775d0897d68950e24e8e` | matches expected |
| `ExpandableGridView.dll` | `89ec31d68a132c02f725903d52d5c5c7c422a2aa997a8a8444685a4374cefcc0` | matches expected |
| `client-core/ref/ZTool_rsa.dll` | `274a33f35b98437d57f7eadce21cfe855d5285e9012c1c33733a3ab1f0ec2a90` | matches expected |
| `help_ru.chm` | `9a8a7da1ea91ca6e51ae745ba5a4f7caa8314f8ecfc32e1e827aeac42a2a8646` | present, provenance still needs CHM source/build evidence |
| `SWTools.settings` | `f969e4475f5b0a256171fbbdd6d93c2f0ca4a0771f49829efaa1b3d644a7500a` | present |

## Required Local Context Files

| File | Status |
|---|---|
| `docs/spec.md` | missing in clean worktree |
| `tasks/current.md` | missing in clean worktree |
| `AGENTS.md` | missing in clean worktree |
| `CLAUDE.md` | missing in clean worktree |
| `.codegraph/` | missing |

## Baseline Findings

1. `#66` is documentation-only and clean, but it is based on `main` before `#65`.
2. `#65` is the active source-of-truth closure PR for Phase E; P4 binary provenance must be refreshed after `#65` is merged.
3. Root `SWTools.exe` and `SWTools.dll` are not authoritative release artifacts at this baseline because their hashes do not match `scripts/expected_release_hashes.json`.
4. Exact `releases/1.1.6` package is absent from the clean worktree, so installer/package smoke gates are blocked at baseline.
5. Repository code for `license-server` is SQLite-only, while `docs/release/FULL_TEST_METHODOLOGY_RU.md` documents a production MySQL incident. This is a P4 backend drift blocker until the production backend is declared and checked fail-closed.
