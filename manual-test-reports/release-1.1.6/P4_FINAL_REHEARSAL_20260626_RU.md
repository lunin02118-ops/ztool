# P4 final rehearsal 2026-06-26

Статус: **NO-GO**.

Этот отчет фиксирует финальный rehearsal по текущему стеку PR #104 на ветке
`codex/p4-next-production-gates`. Production GO не заявляется: остались внешние
и технические блокеры, перечисленные ниже.

## Контекст

- Ветка: `codex/p4-next-production-gates`.
- Последний commit: `60deb99828415dae9cc29dca3a589cf1ecfc73f0`.
- Runtime package: `_local_artifacts/reports/p4-final-20260626-1540/release-package/SWTools-1.1.6`.
- Installer: `_local_artifacts/reports/p4-final-20260626-1540/installer/SWTools-1.1.6-Setup.exe`.

## Code/test gates

Пройдено:

- `python -m py_compile scripts\swtools_s7_live_smoke.py scripts\swtools_s8_bom_live.py`
- `python tools\secret_scan.py`
- `git diff --check`
- `pwsh -NoProfile -File scripts\check_client_src_warnings.ps1`
- `python tools\check_source_string_invariants.py --root client-src --root client-src-addin`
- `python tools\check_visible_brand_boundary.py`
- `dotnet build client-src-addin\<add-in project>.csproj -c Release -p:SolidWorksDir="C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS"`

Warning baseline: PASS, counts unchanged (`client-src=123`, `client-src-addin=6`).

## P4 final evidence gates

Output root: `_local_artifacts/reports/p4-final-20260626-1540`.

Пройдено:

- `scripts\check_repo_hygiene.ps1`
- `scripts\check_binaryformatter_surface.ps1`
- `scripts\generate_sbom.ps1`
- `scripts\check_license_policy.ps1`
- `scripts\generate_binary_provenance.ps1`
- `scripts\verify_binary_provenance.ps1`

## Release package

Package build: PASS.

Package verify: PASS.

Runtime hashes:

- `SWTools.exe`: `d2074a81bf1b2addf072c590dcde01d9114e77f7ee5b368d9a2fa67a9e94945c`
- `SWTools.dll`: `da36685aa69c3a115b8c4151848d1592d8151810ed37ca513b3f9da285e2c5ef`
- `Ribbon.dll`: `57e026815738a47e988048b95b354ab107cd80e559d0775d0897d68950e24e8e`
- `ExpandableGridView.dll`: `89ec31d68a132c02f725903d52d5c5c7c422a2aa997a8a8444685a4374cefcc0`
- RSA helper DLL: `274a33f35b98437d57f7eadce21cfe855d5285e9012c1c33733a3ab1f0ec2a90`

Installer build: PASS.

- `SWTools-1.1.6-Setup.exe` SHA256:
  `ac0ac2130256391d8850e06d0a91b4effd62ea2c384bcf1e2ab41f3754530b7d`

## Authenticode

Production Authenticode: **FAIL / BLOCKER**.

Проверка выполнена без `-AllowUnsigned`.

Неподписаны:

- `runtime/SWTools.exe`
- `runtime/SWTools.dll`
- `SWTools-1.1.6-Setup.exe`

Evidence:

- `_local_artifacts/reports/p4-final-20260626-1540/authenticode-production.json`

`-AllowUnsigned` не использовался как production approval.

## Live SolidWorks evidence

Clean source-build live E2E на `c3cdf7b`:

- Evidence: `_local_artifacts/reports/final-release-e2e-20260626-153805`
- S7: PASS, `29` строк, `40` колонок.
- S8: PASS, `8/8` workbook exports.
- Strict filters: PASS (`mode 7 = 18`, `mode 8 = 6`).
- Branding/version/icon: PASS.
- `production_go_allowed=false`.

Final package `60deb99` live evidence:

- S7 на финальном runtime: PASS, `29` строк, `40` колонок.
- Package/runtime identity: PASS.
- Non-strict S8 на обычном TestModel экспортировал `8/8`, но strict filters ожидаемо FAIL для mode 7/8 на неподготовленной модели (`0` строк).
- Попытка strict fixture на финальном runtime подготовила fixture и прошла S7, но S8 automation не завершил проход из-за нестабильного UI/ribbon state после trial countdown. Это остается **release blocker**, пока не будет получен чистый финальный package-run evidence с `S7 PASS + S8 strict 8/8 PASS + branding PASS`.

## Visual localization L-01..L-15

Visual FULL PASS: **NO-GO / BLOCKER**.

Текущий полный профиль есть в репозитории:

- `docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json`
- `docs/localization/VISUAL_LOCALIZATION_OPENERS_L01_L15.json`

Подтверждено:

- strict validator блокирует неполный manifest;
- L-01 capture на финальном runtime выполняется;
- сохраненный historical evidence содержит прогресс по L-03..L-06.

Не закрыто:

- нет cumulative manifest `15/15` со strict PASS;
- L-02 license dialog opener не нашел object-доступную registration/license/demo surface в текущем main window;
- owner/auditor visual review не выполнен.

## Accepted hashes

Accepted hash promotion: **PENDING OWNER DECISION**.

Candidate hashes указаны выше, но `expected_release_hashes.json` не обновлялся этим отчетом.
Продвижение hash в accepted release set нельзя делать без owner release decision.

## Owner/auditor review

Owner/auditor GO: **PENDING**.

Я не ставлю owner GO за пользователя и не подменяю внешний аудит. Для production release
нужны:

1. Подписанные production artifacts.
2. Чистый финальный package-run `S7/S8 strict/branding` PASS.
3. Full visual localization manifest L-01..L-15 strict PASS.
4. Owner/auditor visual review.
5. Accepted hash promotion decision.
6. Явный owner Production GO.

## Вывод

Стек PR #104 существенно улучшил стабильность S7 receiver/IPC, S8 modal handling,
layout fixes и release evidence, но production release на текущем состоянии
нельзя выпускать. Главные блокеры теперь конкретные и воспроизводимые:

- unsigned Authenticode artifacts;
- нет полного visual L-01..L-15 strict PASS;
- нет owner/auditor review;
- нет accepted hash decision;
- финальный package-run strict S8/branding нужно повторить в чистой лицензированной
  сессии без trial countdown interference.
