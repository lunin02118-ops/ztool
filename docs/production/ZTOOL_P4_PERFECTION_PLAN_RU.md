# ZTool/SWTools — детальный план доведения репозитория до P4 Production Ready

Дата: 2026-06-22  
Целевой репозиторий: `lunin02118-ops/ztool`  
Локальный путь исполнения: `D:\Development\ztool`  
Статус документа: план для следующего локального агента/Codex. Application source code этим документом не меняется.

## 1. Цель

Довести проект из состояния `P3- / release candidate` до доказуемого `P4 / Production Ready`.

`P4` означает не декларацию, а набор проверяемых evidence-артефактов: логи команд, хэши, отчёты CI, SBOM, license notices, подписи, installer smoke, живой SolidWorks acceptance, localization screenshots, release dossier и финальный go/no-go.

## 2. Текущий диагноз по итогам аудита

Проект уже имеет сильную инженерную базу:

- восстановленный `client-src`;
- `client-src-addin`;
- `client-core` и reinjection pipeline;
- Python `license-server`;
- CI workflows;
- release package verification;
- NSIS installer;
- manual SolidWorks reports;
- localization scan/whitelist process;
- production docs, threat model, risk register.

Но безусловный `P4 Production Ready` пока не доказан из-за следующих классов рисков:

1. необходимость поддерживать redacted Legal/IP attestation без публикации private evidence;
2. split между source, reinjection и runtime binaries;
3. обязательная зависимость от живого SolidWorks acceptance на exact release package;
4. отсутствие полного SBOM/license/SCA gate;
5. неподтверждённая Authenticode/code signing цепочка;
6. manual-heavy localization screenshot gate;
7. legacy crypto residual risk;
8. perimeter-based rate limiting;
9. возможный production backend drift SQLite/MySQL;
10. недостаточно формализованный release dossier.
11. repo hygiene: временные релизы, evidence, секреты и runtime artifacts должны оставаться вне Git;
12. BinaryFormatter legacy surface должен быть containment-ограничен и задокументирован;
13. localization architecture debt: whitelist должен не маскировать user-facing Han и source/runtime/help должны проверяться раздельно.

## 3. Жёсткие правила для агента

### 3.1 Запрещено

- отключать license check;
- убирать hardware binding;
- ослаблять protocol validation;
- коммитить private keys, DB, dumps, production logs, токены, `.env`;
- заменять security checks декоративными заглушками;
- удалять failing checks вместо исправления причины;
- менять application behavior без тестов и описания backward compatibility;
- менять бинарные runtime artifacts без manifest/hash/provenance;
- считать зелёный CI заменой SolidWorks acceptance;
- скрывать residual risks.

### 3.2 Разрешено

- создавать/обновлять документацию;
- добавлять CI workflows;
- добавлять scripts для проверки release readiness;
- добавлять tests;
- добавлять SBOM/license/signing/security gates;
- улучшать packaging verification;
- улучшать operational runbooks;
- менять application source code только если задача прямо требует исправления и сопровождается тестами, manual acceptance notes и rollback plan.

## 4. Финальная Definition of Done для P4

Проект считается доведённым до `P4`, когда выполнены все условия:

```text
[ ] External Legal/IP approval attestation confirmed; source legal evidence remains outside Git.
[ ] Binary provenance matrix создана для всех EXE/DLL/CHM/runtime artifacts.
[ ] From-source path либо полностью заменяет binary/reinject path, либо split явно documented/accepted.
[ ] SQLite/MySQL production backend drift закрыт.
[ ] License-server tests проходят с coverage threshold.
[ ] Client-src и client-src-addin собираются локально и в CI.
[ ] Release package verification проходит на exact package.
[ ] Installer build проходит.
[ ] Authenticode signatures verified для Setup.exe, SWTools.exe, SWTools.dll.
[ ] `-AllowUnsigned` используется только как CI evidence mode; production GO требует Valid signatures или formal release exception.
[ ] SBOM CycloneDX/SPDX generated.
[ ] Third-party license notices generated and packaged.
[ ] Dependency vulnerability scan проходит или имеет accepted exceptions.
[ ] Secret scan проходит.
[ ] Localization scan проходит с fail-on-unclassified.
[ ] Full visual localization screenshot pass выполнен.
[ ] SolidWorks live acceptance выполнен по FULL_TEST_METHODOLOGY_RU.md.
[ ] Installer smoke выполнен на clean VM.
[ ] Release dossier создан и содержит hashes, logs, screenshots, environment, operator sign-off.
[ ] Risk register обновлён: все P0/P1 либо mitigated, либо formally accepted.
```

---

## 4.1 Legal/IP external approval model

Deep Audit delta: права урегулированы вне репозитория, но исходные evidence не
должны попадать в Git. Поэтому P4 модель фиксируется как
`confirm external approval attestation`.

Repo-safe артефакты:

```text
docs/compliance/LEGAL_APPROVAL_STATUS_RU.md
docs/compliance/LEGAL_APPROVAL_TEMPLATE_RU.md
docs/compliance/THIRD_PARTY_INVENTORY_RU.md
docs/compliance/LICENSE_POLICY_RU.md
docs/compliance/THIRD_PARTY_NOTICES_RU.md
```

Запрещено коммитить:

```text
legal source documents, contracts, scans, emails, commercial terms,
private approvals, license keys, private keys, endpoint secrets.
```

Blocker остаётся только если external approval cannot be confirmed, scope exceeded
или repo accidentally receives non-redacted evidence.

---

# Sprint A — Intake, baseline и freeze состояния

## Цель

Зафиксировать точное состояние репозитория и release target.

## Задачи

```text
[ ] Выполнить harness_status.
[ ] Выполнить latest_handoff.
[ ] Выполнить list_workflow_files.
[ ] Прочитать docs/spec.md, tasks/current.md, AGENTS.md, CLAUDE.md, handoff files, если они доступны локально.
[ ] Зафиксировать branch, commit, dirty state.
[ ] Зафиксировать текущую версию VERSION.
[ ] Зафиксировать expected hashes из scripts/expected_release_hashes.json.
[ ] Зафиксировать наличие releases/1.1.6 package locally.
```

## Команды

```powershell
Set-Location 'D:\Development\ztool'

git status --short
git rev-parse --show-toplevel
git branch --show-current
git log -1 --oneline
Get-Content VERSION
Get-Content scripts\expected_release_hashes.json
```

## Артефакты

Создать:

```text
docs/production/p4-evidence/00-baseline.md
```

## Acceptance criteria

```text
[ ] Baseline документ создан.
[ ] Все дальнейшие проверки ссылаются на этот baseline.
[ ] Если repo dirty, P4 checks помечаются как invalid до clean state.
```

---

# Sprint B — Legal/IP attestation and compliance closure

## Цель

Закрыть repo-safe сторону Legal/IP: не публиковать private evidence, но иметь
проверяемый redacted attestation и compliance inventory.

## Задачи

```text
[ ] Создать redacted Legal/IP attestation template.
[ ] Confirm external approval attestation for ZTool/SWTools runtime.
[ ] Зафиксировать distribution scope: internal / pilot / commercial / public.
[ ] Зафиксировать covered scope: modification, rebrand, rekey, license server migration, packaging, distribution.
[ ] Зафиксировать evidence custody outside Git.
[ ] Добавить explicit prohibition на legal docs/contracts/scans/emails/commercial terms/private approvals in Git.
[ ] Инвентаризировать third-party DLL/assets.
[ ] Сгенерировать SBOM CycloneDX.
[ ] Сгенерировать SBOM SPDX.
[ ] Сгенерировать third-party notices.
[ ] Ввести license allowlist/denylist.
[ ] Добавить CI gate для license/SBOM generation.
```

## Файлы создать/обновить

```text
docs/compliance/LEGAL_APPROVAL_TEMPLATE_RU.md
docs/compliance/LEGAL_APPROVAL_STATUS_RU.md
docs/compliance/THIRD_PARTY_INVENTORY_RU.md
docs/compliance/LICENSE_POLICY_RU.md
docs/compliance/THIRD_PARTY_NOTICES_RU.md
scripts/generate_sbom.ps1
scripts/check_license_policy.ps1
.github/workflows/compliance.yml
```

## Команды

```powershell
syft . -o cyclonedx-json > artifacts\sbom.cyclonedx.json
syft . -o spdx-json > artifacts\sbom.spdx.json
trivy fs --scanners vuln,secret,license .
osv-scanner .
```

Если tool недоступен:

```text
Status: Not run
Reason: tool unavailable
Impact: P4 blocked until run in prepared environment
```

## Acceptance criteria

```text
[ ] Для каждого DLL/EXE/CHM/font/icon указан origin.
[ ] Для каждой third-party dependency указана license.
[ ] Copyleft/notice obligations documented.
[ ] Legal/IP status = `EXTERNALLY_CONFIRMED / NON_PUBLIC_EVIDENCE`.
[ ] Source legal evidence remains outside Git.
[ ] Release package содержит third-party notices.
[ ] CI падает при prohibited license.
```

---

# Sprint C — Binary provenance и source-of-truth

## Цель

Доказать, откуда берётся каждый runtime artifact и какой source/build/patch step его породил.

## Задачи

```text
[ ] Составить binary provenance matrix.
[ ] Для каждого artifact указать: built-from-source / third-party / patched legacy / generated.
[ ] Для built-from-source указать project, command, output path, hash.
[ ] Для patched/reinjected указать input hash, patch tool, output hash, verification command.
[ ] Для third-party указать vendor/license/source URL/package.
[ ] Для CHM указать source HTML/input, build command, output hash.
[ ] Сравнить loose root binaries с accepted release package hashes.
[ ] Обозначить loose binaries как historical/non-authoritative, если они отличаются.
```

## Файлы создать/обновить

```text
docs/audit/BINARY_PROVENANCE_RU.md
docs/audit/FROM_SOURCE_CLOSURE_RU.md
scripts/generate_binary_provenance.ps1
scripts/verify_binary_provenance.ps1
```

## Matrix format

```text
Artifact | Current path | Role | Origin class | Source/input | Build/patch command | Expected SHA256 | Actual SHA256 | Status | Notes
```

## Acceptance criteria

```text
[ ] Нет artifact без origin.
[ ] Нет accepted runtime artifact без expected hash.
[ ] Нет source-built artifact без documented command.
[ ] Нет patched/reinjected artifact без input/output hash.
[ ] README clearly states authoritative release artifacts.
```

---

# Sprint D — Backend drift closure

## Цель

Закрыть риск SQLite/MySQL drift между docs, tests, acceptance tooling и production.

## Задачи

```text
[ ] Определить фактически поддерживаемые backend modes.
[ ] Если production SQLite-only — удалить/закрыть MySQL ambiguity из методологии.
[ ] Если production MySQL реально используется — добавить explicit adapter/config/tests/docs.
[ ] Acceptance tooling должен читать backend из service env.
[ ] Acceptance tooling должен fail-closed, если backend не определён.
[ ] Добавить backend identity check в release acceptance.
[ ] Добавить DB migration smoke для каждого supported backend.
```

## Файлы создать/обновить

```text
docs/operations/PRODUCTION_BACKEND_RU.md
docs/release/FULL_TEST_METHODOLOGY_RU.md
license-server/README.md
scripts/check_license_backend.ps1
scripts/check_license_backend.py
.github/workflows/license-server.yml
```

## Acceptance criteria

```text
[ ] Документация не противоречит runtime.
[ ] Acceptance helper не пишет в неправильную DB.
[ ] DB backend виден в release dossier.
[ ] Migration tests покрывают supported backend.
```

---

# Sprint E — License-server hardening

## Цель

Довести license-server до production-grade operational/security состояния.

## Задачи

```text
[ ] Добавить/включить coverage threshold.
[ ] Добавить dependency lock/constraints.
[ ] Добавить pip-audit/osv-scanner.
[ ] Добавить in-process rate limiting.
[ ] Добавить metrics/log events для rate limit.
[ ] Добавить tests для rate limiting.
[ ] Добавить deploy-time key permission/fingerprint check.
[ ] Добавить healthcheck без раскрытия секретов.
[ ] Добавить backup/restore drill doc.
[ ] Добавить explicit legacy crypto risk acceptance.
```

## Файлы создать/обновить

```text
license-server/requirements.lock или constraints.txt
license-server/swtools_license_server/rate_limit.py
license-server/tests/test_rate_limit.py
license-server/tests/test_healthcheck.py
docs/security/LEGACY_CRYPTO_RISK_ACCEPTANCE_RU.md
docs/operations/LICENSE_SERVER_DEPLOY_CHECKLIST_RU.md
docs/operations/BACKUP_RESTORE_DRILL_RU.md
```

## Команды

```powershell
cd license-server
python -m pip install -e ".[dev]"
ruff check .
python -m compileall swtools_license_server tests
bandit -q -r swtools_license_server -c pyproject.toml
pytest -q --cov=swtools_license_server --cov-report=term-missing --cov-fail-under=85
pip-audit
osv-scanner .
```

## Acceptance criteria

```text
[ ] Coverage threshold enforced.
[ ] Rate limit tests pass.
[ ] Malformed/oversized protocol frames still fail closed.
[ ] Production DEBUG still fail-closed.
[ ] No plaintext payload logging.
[ ] Key fingerprint visible; key material never logged.
[ ] Public internet deployment requires firewall/fail2ban + in-process limiter.
```

---

# Sprint F — CI/CD gates до production уровня

## Цель

Сделать так, чтобы production release не мог пройти без обязательных проверок.

## Задачи

```text
[ ] Добавить supply-chain workflow.
[ ] Добавить compliance workflow.
[ ] Добавить release-hardening workflow.
[ ] Добавить coverage thresholds.
[ ] Добавить artifact upload для reports.
[ ] Добавить expected-hash verification.
[ ] Добавить installer signature verification.
[ ] Добавить package forbidden-files check.
[ ] Явно задокументировать: `-AllowUnsigned` — только CI evidence mode, не production approval.
[ ] Добавить branch protection recommendation doc.
```

## Файлы создать/обновить

```text
.github/workflows/supply-chain.yml
.github/workflows/compliance.yml
.github/workflows/release-hardening.yml
docs/production/BRANCH_PROTECTION_RU.md
```

## Required gates

```text
license-server lint
license-server tests + coverage threshold
client-src build
client-src-addin build
client-core build/reinject verification
localization scan fail-on-unclassified
secret scan
SCA scan
SBOM generation
license policy check
release package verification
expected hashes verification
installer build
Authenticode verification where signing cert available
```

## Acceptance criteria

```text
[ ] CI fails on unclassified Han.
[ ] CI fails on forbidden secrets.
[ ] CI fails on missing SBOM.
[ ] CI fails on prohibited license.
[ ] CI fails on expected hash mismatch.
[ ] CI stores reports as artifacts.
[ ] Unsigned artifacts are accepted in CI only with `-AllowUnsigned`; production release requires signing or formal exception in Sprint N.
```

---

# Sprint G — Client/source build closure

## Цель

Снизить зависимость от binary patch lineage и сделать source path максимально authoritative.

## Задачи

```text
[ ] Собрать client-src Release.
[ ] Собрать client-src-addin Release.
[ ] Зафиксировать все warnings.
[ ] Классифицировать warnings: benign decompiler artifact / real risk.
[ ] Создать warning baseline.
[ ] Перенести оставшиеся RU localization/rebrand/update-check/window fixes из patch layer в source tree или documented exception.
[ ] Добавить smoke tests для критичных source-level helpers.
[ ] Добавить assembly metadata/version checks.
```

## Файлы создать/обновить

```text
docs/audit/CLIENT_SRC_WARNING_BASELINE_RU.md
docs/audit/SOURCE_NATIVE_MIGRATION_STATUS_RU.md
scripts/check_client_src_warnings.ps1
```

## Команды

```powershell
dotnet build client-src\ZTool.csproj -c Release -warnaserror:false
dotnet build client-src-addin\ZTool.SwAddin.csproj -c Release -warnaserror:false
```

## Acceptance criteria

```text
[ ] Все warnings classified.
[ ] Новые warnings fail gate или требуют explicit update baseline.
[ ] Source build output hash documented.
[ ] Difference между source build и release runtime explained.
```

---

# Sprint H — Localization perfection

## Цель

Доказать полную русификацию UI/help/installer/SolidWorks add-in без видимых Han-строк, clipping и dirty screenshots.

## Задачи

```text
[ ] Запустить localization scan с fail-on-unclassified.
[ ] Проверить whitelist policy: нет user-facing строк в whitelist.
[ ] Разделить architecture debt: source string literals, binary/runtime scan, help CHM, installer UI, SolidWorks add-in UI.
[ ] Убрать или formally classify remaining `REVIEW` Han entries: fonts, semantic keys, control names, help paths, image names, symbol palette, format fragments, log text.
[ ] Для semantic-key `零` не делать half-rename: producer/consumer меняются только вместе с parity check.
[ ] Зафиксировать, какие entries являются internal architecture debt, а какие user-facing blocker.
[ ] Проверить help_ru.chm.
[ ] Проверить main app UI.
[ ] Проверить registration/license forms.
[ ] Проверить SolidWorks add-in ribbon/forms.
[ ] Проверить BOM/export dialogs.
[ ] Проверить error dialogs.
[ ] Проверить installer UI.
[ ] Сделать clean screenshot pack.
[ ] Создать visual localization report.
```

## Файлы создать/обновить

```text
docs/localization/VISUAL_LOCALIZATION_REPORT_RU.md
docs/localization/HELP_RU_ACCEPTANCE_RU.md
docs/localization/LOCALIZATION_ARCHITECTURE_DEBT_RU.md
manual-test-reports/localization/README.md
```

## Команды

```powershell
python client-core\tools\localization_scan.py --fail-on-unclassified
```

## Acceptance criteria

```text
[ ] unclassified_han = 0.
[ ] Все whitelist entries имеют approved category.
[ ] Все user-facing Han устранены.
[ ] Architecture debt classified; no user-facing Han hidden as whitelist.
[ ] Нет critical clipping.
[ ] help_ru.chm открывается и проходит выборочную проверку.
[ ] Screenshot report имеет FULL PASS.
```

---

# Sprint I — Installer/release hardening

## Цель

Доказать, что installer безопасно ставится, обновляется, удаляется и проходит trust-chain проверки.

## Задачи

```text
[ ] Собрать release package.
[ ] Проверить release package.
[ ] Собрать NSIS installer.
[ ] Подписать Setup.exe.
[ ] Подписать SWTools.exe/SWTools.dll или документировать невозможность.
[ ] Проверить Authenticode signatures.
[ ] Подтвердить, что `-AllowUnsigned` не используется как production approval.
[ ] Проверить SmartScreen/AV/EDR behavior в controlled environment.
[ ] Выполнить clean install.
[ ] Выполнить upgrade from previous build.
[ ] Выполнить uninstall.
[ ] Проверить registry diff.
[ ] Проверить license state preservation.
[ ] Проверить SolidWorks add-in registration.
[ ] Проверить no debug/dev/private artifacts.
```

## Файлы создать/обновить

```text
scripts/verify_authenticode.ps1
scripts/installer_smoke_checklist.ps1
docs/release/INSTALLER_SMOKE_REPORT_TEMPLATE_RU.md
docs/release/SIGNING_POLICY_RU.md
```

## Команды

```powershell
.\scripts\build_release_package.ps1
.\scripts\verify_release_package.ps1 -PackageRoot .\releases\1.1.6\package\SWTools-1.1.6 -RequireSolidWorksTools
.\scripts\build_client_installer.ps1 -PackageRoot .\releases\1.1.6\package\SWTools-1.1.6

Get-AuthenticodeSignature .\releases\1.1.6\SWTools-1.1.6-Setup.exe
Get-FileHash .\releases\1.1.6\SWTools-1.1.6-Setup.exe -Algorithm SHA256
```

## Acceptance criteria

```text
[ ] Setup.exe signature Valid.
[ ] Runtime binaries signature Valid или accepted exception.
[ ] `-AllowUnsigned` evidence report не используется для финального GO без Sprint N exception.
[ ] Clean install PASS.
[ ] Upgrade PASS.
[ ] Uninstall PASS.
[ ] SolidWorks add-in load PASS.
[ ] Registry entries correct.
[ ] Event Viewer clean.
[ ] No forbidden files in package.
```

---

# Sprint J — SolidWorks full acceptance

## Цель

Закрыть главный functional production gate: живой прогон на SolidWorks.

## Задачи

```text
[ ] Подготовить clean Windows VM.
[ ] Установить целевую версию SolidWorks.
[ ] Установить exact release package.
[ ] Проверить process path/hash.
[ ] Запустить SWTools.
[ ] Проверить registration/activation.
[ ] Проверить transfer/remove_confirm.
[ ] Проверить SolidWorks connection.
[ ] Открыть test assembly.
[ ] Прогнать BOM 8/8.
[ ] Проверить export templates.
[ ] Проверить ribbon/buttons.
[ ] Проверить clipboard/binder scenarios.
[ ] Проверить Event Viewer.
[ ] Сделать screenshots.
[ ] Если доступен оригинальный CN build, выполнить A/B parity.
```

## Файлы создать/обновить

```text
manual-test-reports/release-1.1.6/FULL_ACCEPTANCE_RU.md
manual-test-reports/release-1.1.6/SOLIDWORKS_ENVIRONMENT_RU.md
manual-test-reports/release-1.1.6/EVENT_VIEWER_SUMMARY_RU.md
manual-test-reports/release-1.1.6/HASHES_RU.md
```

## Acceptance criteria

```text
[ ] Full methodology executed.
[ ] All critical scenarios PASS.
[ ] Any WARN has explicit risk acceptance.
[ ] Any FAIL blocks P4.
[ ] Screenshots attached or stored in approved artifact storage.
[ ] Operator/date/environment recorded.
```

---

# Sprint K — Release dossier and final GO/NO-GO

## Цель

Создать единый финальный пакет доказательств для production decision.

## Файлы создать

```text
docs/release/RELEASE_DOSSIER_TEMPLATE_RU.md
docs/release/RELEASE_DOSSIER_1.1.6_RU.md
docs/production/P4_GO_NO_GO_RU.md
```

## Dossier must include

```text
Release version
Git commit
Dirty state
Package path
Package SHA256
Installer SHA256
Expected hashes
Actual hashes
Build logs
Test logs
Coverage report
SBOM links
License scan report
Secret scan report
SCA report
Authenticode report
Installer smoke report
SolidWorks acceptance report
Localization visual report
Risk register delta
Known limitations
Rollback plan
Operator sign-off
Final GO/NO-GO
```

## Acceptance criteria

```text
[ ] Dossier complete.
[ ] Все P0/P1 blockers закрыты или formally accepted.
[ ] P4 decision не опирается на undocumented assumptions.
[ ] README/INDEX указывают на final dossier.
```

---

# Sprint L — Repo hygiene and artifact custody

## Цель

Доказать, что репозиторий не содержит мусор, временные релизы, приватные
evidence, секреты или неавторитетные runtime artifacts, а локальные артефакты
живут в предсказуемых директориях.

## Задачи

```text
[ ] Проверить git status на clean state.
[ ] Проверить tracked large/runtime artifacts и сравнить с provenance policy.
[ ] Проверить, что releases/evidence/secrets остаются в approved paths.
[ ] Проверить `_local_artifacts/` и локальные worktrees не попадают в Git.
[ ] Проверить отсутствие legal/private evidence in Git.
[ ] Проверить `.gitignore` для build outputs, dumps, screenshots, logs, DB, keys.
[ ] Создать repo hygiene report.
```

## Файлы создать/обновить

```text
docs/production/REPO_HYGIENE_REPORT_RU.md
docs/production/LOCAL_ARTIFACTS_POLICY_RU.md
.gitignore
```

## Acceptance criteria

```text
[ ] No secrets/legal evidence/private approvals tracked.
[ ] No accidental local release/evidence folders tracked.
[ ] Authoritative release artifacts documented.
[ ] Non-authoritative loose binaries remain documented or removed by release decision.
```

---

# Sprint M — BinaryFormatter containment

## Цель

Сдержать legacy `BinaryFormatter` risk без поспешной смены поведения, которое
может сломать совместимость настроек/форматов.

## Задачи

```text
[ ] Инвентаризировать все `BinaryFormatter` call sites.
[ ] Для каждого call site указать data source: trusted local config / user file / network / embedded resource.
[ ] Запретить network/untrusted BinaryFormatter paths или добавить fail-closed guard.
[ ] Зафиксировать binder/allowed-types policy.
[ ] Добавить regression tests для known config blobs.
[ ] Создать migration plan на safer serializer там, где это возможно без runtime parity break.
```

## Файлы создать/обновить

```text
docs/security/BINARYFORMATTER_CONTAINMENT_RU.md
scripts/check_binaryformatter_surface.ps1
```

## Acceptance criteria

```text
[ ] No network-facing BinaryFormatter usage.
[ ] Every call site has owner, data source and allowed-type policy.
[ ] Existing configs still load.
[ ] Migration is planned but not mixed into unrelated release changes.
```

---

# Sprint N — Final signing and release dossier

## Цель

Закрыть финальную production цепочку доверия: подпись, immutable hashes,
release evidence и GO/NO-GO.

## Задачи

```text
[ ] Подписать Setup.exe.
[ ] Подписать SWTools.exe/SWTools.dll или оформить formal release exception.
[ ] Проверить Authenticode signatures без `-AllowUnsigned`.
[ ] Сформировать final release hashes.
[ ] Сформировать final SBOM/license notices/SCA reports.
[ ] Приложить SolidWorks acceptance + installer smoke + localization evidence.
[ ] Зафиксировать redacted Legal/IP attestation reference.
[ ] Создать final release dossier.
[ ] Принять GO/NO-GO.
```

## Файлы создать/обновить

```text
docs/release/RELEASE_DOSSIER_1.1.6_RU.md
docs/production/P4_GO_NO_GO_RU.md
docs/release/SIGNING_POLICY_RU.md
```

## Acceptance criteria

```text
[ ] `Get-AuthenticodeSignature` returns `Valid` for required artifacts or formal exception is documented.
[ ] `-AllowUnsigned` is absent from production verification command.
[ ] Dossier references exact commit/package/hash.
[ ] All P0/P1 blockers are mitigated or formally accepted.
```

---

# 5. Рекомендуемая очередность PR

```text
#71: Warning identity baseline follow-up — merged
#72: Deep Audit delta and P4 plan correction
#73: Sprint H localization architecture debt + visual localization report
#74: Sprint L repo hygiene + Sprint M BinaryFormatter containment
#75: Sprint N signing/release dossier and final GO/NO-GO
```

## PR report format

Каждый PR должен завершаться отчётом:

```text
Sprint:
Files changed:
Checks run:
Results:
Findings closed:
New findings:
Residual risks:
Rollback:
Next sprint:
```

---

# 6. Минимальный первый шаг агента

Первый агентский commit после добавления этого плана должен создать baseline:

```text
docs/production/p4-evidence/00-baseline.md
```

Затем агент должен переходить к compliance/SBOM и binary provenance. Нельзя начинать application-code changes до закрытия baseline и compliance direction.
