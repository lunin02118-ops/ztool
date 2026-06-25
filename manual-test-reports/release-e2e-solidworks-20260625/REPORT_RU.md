# R3 Self-hosted SolidWorks Release E2E Report

Date: 2026-06-25

Status: WORKFLOW/GATE READY

Production GO: NO-GO

## Scope

Этот PR добавляет release-grade workflow для живого SolidWorks E2E на
self-hosted runner.

Runtime/application behavior не менялся.

## Что закрыто

- Добавлен `.github/workflows/release-e2e-solidworks.yml`.
- Workflow запускается только вручную через `workflow_dispatch`.
- Workflow требует runner labels `self-hosted, windows, solidworks, swtools-release`.
- Добавлен wrapper `scripts/e2e/Invoke-SWToolsReleaseE2E.ps1`.
- Wrapper запускает source build/package/S7/S8 strict/branding assertions.
- Wrapper не выставляет `production_go_allowed=true`.
- Visual full profile подключён как строгий gate через cumulative manifest L-01..L-15.
- Добавлен workflow contract validator.

## Машинные gates

- `tools/e2e/check_release_e2e_workflow.py --self-test`
- `tools/e2e/check_release_e2e_workflow.py .github/workflows/release-e2e-solidworks.yml`
- PowerShell parser gate для `Invoke-SWToolsReleaseE2E.ps1`
- Existing release-acceptance gates

## Что остаётся

- Сам live workflow ещё должен быть запущен на self-hosted SolidWorks runner.
- Full visual manifest L-01..L-15 должен быть подготовлен и передан в workflow.
- Signing, release dossier и accepted hash decision остаются следующими слоями.
