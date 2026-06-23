# Branch protection для production release

Дата: 2026-06-23

## Цель

`main` не должен принимать release/runtime изменения без обязательных
автоматических gates и явного review.

## Рекомендуемые правила для `main`

| Правило | Значение |
|---|---|
| Require pull request before merging | Да |
| Required approving reviews | Минимум 1 |
| Dismiss stale approvals | Да |
| Require status checks to pass | Да |
| Require branches to be up to date | Да |
| Restrict direct pushes | Да |
| Require conversation resolution | Да |
| Allow force pushes | Нет |
| Allow deletions | Нет |

## Required status checks

Обязательные checks для production-sensitive PR:

| Check | Что закрывает |
|---|---|
| `secret-scan` | Запрещает случайную публикацию секретов |
| `compliance` | SBOM, license policy, binary provenance, backend identity |
| `license-server / test` | Lint, compile, Bandit, pytest+coverage, pip-audit, OSV |
| `client-src / build` | From-source client build |
| `client-src-addin / build` | From-source SolidWorks add-in build surface |
| `client-core-windows / build` | Legacy client-core/reinject/localization gate |
| `release-acceptance / acceptance` | Deterministic release acceptance without SolidWorks |
| `release-hardening / release-hardening` | Package verification, installer smoke, signature report |
| `supply-chain / supply-chain` | Standalone SBOM/license evidence |

## Merge order for stacked PRs

1. Merge documentation/compliance baseline first.
2. Merge executable CI gates after baseline is in `main`.
3. Rebase or retarget stacked PRs before merging into `main`.
4. Do not merge release/runtime binary changes if expected hashes, provenance
   and package verification are not updated in the same stack.

## Exceptions

Unsigned CI dry-run artifacts may pass only when the corresponding workflow
records an explicit unsigned Authenticode report. Production release artifacts
must either have `Valid` Authenticode signatures or a signed release-owner risk
acceptance in the release dossier.

SolidWorks live acceptance cannot run on GitHub-hosted runners. It remains a
manual required release gate and must be attached to the release dossier before
GO decision.
