# P4 next executor instructions

Дата: 2026-06-23  
Scope: действия исполнителя после merge Sprint H/L/M/N stack into `main`.

## 0. Контекст

Текущий P4 hardening stack смержен:

```text
#77 — Sprint H localization architecture debt
#75 — Sprint L/M repo hygiene + BinaryFormatter containment
#76 — Sprint N signing/release dossier policy
```

Текущий production decision остаётся:

```text
NO-GO
```

Причина: финальный release package, подпись, live SolidWorks/licensing acceptance и localization screenshots ещё не собраны как release evidence.

## 1. Жёсткие запреты

Не делать без отдельного approval owner:

```text
[ ] не менять application runtime/source behavior;
[ ] не менять license protocol / crypto / keys;
[ ] не менять accepted release hashes без final acceptance;
[ ] не использовать -AllowUnsigned как production approval;
[ ] не коммитить _local_artifacts/;
[ ] не коммитить releases/;
[ ] не коммитить private keys, signing certificates, legal evidence, endpoint secrets;
[ ] не переписывать Git history;
[ ] не мержить старые PR #61/#64/#65 as-is.
```

## 2. Сначала обновить локальный `main`

```powershell
Set-Location 'D:\Development\ztool'

git fetch origin
git switch main
git pull --ff-only

git log --oneline -10
git status --short
```

Ожидаемые merge commits в истории:

```text
d92c7859  #77 Sprint H
b0ca1a1f  #75 Sprint L/M
4978defc  #76 Sprint N
```

Если история отличается — остановиться и сообщить владельцу.

## 3. Закрыть или пересобрать stale PRs

### #61

Decision: close as superseded.

Reason: docs-only audit @1.1.5 is stale after Deep Audit delta and P4 Sprint H/L/M/N stack.

### #64

Decision: do not merge as-is.

Options:

```text
A. Close as stale.
B. Recreate fresh minimal PR only for scripts/solidworks-registry-preflight.ps1 if needed for live SolidWorks acceptance.
```

The show/hide-columns analysis doc is optional and must not block P4 final evidence.

### #65

Decision: do not merge as-is.

Reason: old from-source release-package PR is behind current P4 stack and changes workflows, package scripts, hashes and project files.

If useful logic remains, extract it into a new fresh PR after comparing against current `main`. That new PR must not change accepted production hashes without final release acceptance.

## 4. Run final P4 gates on current `main`

Create local reports under `_local_artifacts\reports\p4-final\`. Do not commit `_local_artifacts/`.

```powershell
New-Item -ItemType Directory -Force _local_artifacts\reports\p4-final | Out-Null

python tools\secret_scan.py
git diff --check

pwsh -NoProfile -File scripts\check_repo_hygiene.ps1 `
  -JsonOut _local_artifacts\reports\p4-final\repo_hygiene.json

pwsh -NoProfile -File scripts\check_binaryformatter_surface.ps1 `
  -JsonOut _local_artifacts\reports\p4-final\binaryformatter_surface.json

pwsh -NoProfile -File scripts\generate_sbom.ps1 `
  -OutputDir _local_artifacts\reports\p4-final\sbom

pwsh -NoProfile -File scripts\check_license_policy.ps1

pwsh -NoProfile -File scripts\generate_binary_provenance.ps1 `
  -OutputPath _local_artifacts\reports\p4-final\binary-provenance.md `
  -JsonOutput _local_artifacts\reports\p4-final\binary-provenance.json

pwsh -NoProfile -File scripts\verify_binary_provenance.ps1 `
  -ProvenancePath _local_artifacts\reports\p4-final\binary-provenance.md
```

Expected minimum:

```text
[ ] secret_scan PASS
[ ] git diff --check PASS
[ ] repo hygiene PASS
[ ] BinaryFormatter surface PASS
[ ] license policy PASS or explicit blocker recorded
[ ] SBOM generated
[ ] binary provenance generated and verified
```

## 5. Build final release package from exact commit

Run from clean `main` with no uncommitted changes.

```powershell
git status --short
```

Then build package according to current release scripts and verify it:

```powershell
pwsh -NoProfile -File scripts\build_release_package.ps1

pwsh -NoProfile -File scripts\verify_release_package.ps1 `
  -RequireSolidWorksTools
```

Required evidence:

```text
[ ] exact commit SHA
[ ] package path
[ ] manifest.json
[ ] SHA256SUMS.txt
[ ] no private keys
[ ] no DB/sqlite runtime state
[ ] no dumps/logs/_local_artifacts
[ ] SolidWorksTools.dll present if required by package policy
```

## 6. Build installer and verify signing

Build installer:

```powershell
pwh -NoProfile -File scripts\build_client_installer.ps1
```

If the command is `pwsh` in the environment, use:

```powershell
pwsh -NoProfile -File scripts\build_client_installer.ps1
```

Verify Authenticode in production mode — without `-AllowUnsigned`:

```powershell
pwsh -NoProfile -File scripts\verify_authenticode.ps1 `
  -Path <final artifacts> `
  -ReportPath _local_artifacts\reports\p4-final\authenticode-production.json
```

Rules:

```text
[ ] Valid signatures -> continue.
[ ] unsigned artifacts -> remain NO-GO unless formal release exception is recorded.
[ ] never treat -AllowUnsigned evidence as production approval.
```

## 7. SolidWorks and licensing live acceptance

Run on the real Windows/SolidWorks machine according to `docs/release/FULL_TEST_METHODOLOGY_RU.md`.

Minimum required scenarios:

```text
[ ] clean install smoke;
[ ] process path/hash verification;
[ ] SolidWorks add-in load;
[ ] SolidWorks S7/S8;
[ ] licensing L3-L5;
[ ] apply_register/register_confirm;
[ ] transfer/remove_confirm;
[ ] BOM 8/8 modes;
[ ] mapping/options/save/filling/unit forms;
[ ] material/color flows;
[ ] help_ru.chm open from UI;
[ ] Event Viewer/logs summary;
[ ] uninstall/reinstall sanity if required.
```

## 8. Localization visual audit

Use `docs/localization/VISUAL_LOCALIZATION_REPORT_RU.md` as checklist.

Required screenshots L-01..L-15:

```text
[ ] main window/ribbon/table;
[ ] license/registration dialogs;
[ ] BOM export menu and 8 modes;
[ ] Frmexportbom;
[ ] Frmmapping;
[ ] FrmFilterrules;
[ ] FrmOptions;
[ ] FrmSaveOption;
[ ] FrmFilling;
[ ] FrmSWUnit;
[ ] context menus;
[ ] help buttons -> help_ru.chm Russian content;
[ ] SolidWorks add-in tab/buttons;
[ ] installer/uninstaller UI;
[ ] material/color actions depending on mixed literal 零件.
```

Do not claim visual FULL PASS until screenshots are reviewed by the owner.

## 9. Commit curated evidence only

Open a new PR after the final rehearsal.

Suggested title:

```text
release(p4): add final release rehearsal evidence
```

Suggested files:

```text
docs/production/p4-evidence/06-final-release-rehearsal-report.md
docs/release/RELEASE_DOSSIER_1.1.6_RU.md
docs/production/P4_GO_NO_GO_RU.md
manual-test-reports/release-1.1.6/SOLIDWORKS_ENVIRONMENT_RU.md
manual-test-reports/release-1.1.6/FULL_ACCEPTANCE_RU.md
manual-test-reports/release-1.1.6/EVENT_VIEWER_SUMMARY_RU.md
manual-test-reports/release-1.1.6/HASHES_RU.md
```

Do not commit raw local evidence unless it is curated and allowed by repo hygiene policy.

## 10. Final acceptance rule

`GO` is allowed only when all are true:

```text
[ ] final package built from exact merged commit;
[ ] SHA256SUMS/manifest generated;
[ ] SBOM/license notices generated and accepted;
[ ] binary provenance verified;
[ ] production Authenticode valid or formal exception recorded;
[ ] no production reliance on -AllowUnsigned;
[ ] clean install smoke PASS;
[ ] SolidWorks S7/S8 PASS;
[ ] licensing L3-L5 PASS;
[ ] localization visual audit PASS;
[ ] no open P0/P1 without mitigation/exception;
[ ] owner explicitly approves GO.
```
