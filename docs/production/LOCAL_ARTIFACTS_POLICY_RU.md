# Local Artifacts Policy

## Назначение

Все локальные артефакты разработки релизов ZTool должны храниться только в:

`D:\Development\ztool\_local_artifacts`

Нельзя создавать рабочие ZTool-папки в:

- `D:\`
- `D:\tmp`
- `C:\Temp`
- `D:\Development` рядом с `ztool`
- корне `D:\Development\ztool`, если это не исходники/скрипты/документация

## Структура

- `_local_artifacts\releases\`
  - текущие и исторические release packages, client installers, package manifests.
- `_local_artifacts\secrets\licenses\`
  - локальные копии activation keys и другие секреты. Не печатать значения в чат, отчеты или git diff.
- `_local_artifacts\evidence\`
  - screenshots, UI evidence, appdata snapshots, ручные test artifacts.
- `_local_artifacts\worktrees\`
  - git worktrees. Перемещать только через `git worktree move`.
- `_local_artifacts\archive\`
  - старые рабочие директории, архивные копии, исторические release folders.
- `_local_artifacts\scratch\`
  - probes, временные scripts, logs, registry exports, network diagnostics.

## Git policy

`_local_artifacts/` должен быть в `.gitignore`.

Перед staging/push обязательно проверить:

```powershell
git status --short --ignored -- _local_artifacts
```

Нормальный результат:

```text
!! _local_artifacts/
```

В git можно пушить только исходники, build scripts и документацию, например:

- `installer/windows-client/ZToolClient.nsi.in`
- `scripts/build_client_installer.ps1`
- `docs/production/*.md`
- релевантные sanitised reports в `manual-test-reports/`

В git нельзя пушить:

- `_local_artifacts/`
- `.exe/.msi` installers
- activation keys
- server secrets
- raw logs, screenshots, registry exports и временные diagnostics

## Current manual activation artifact

- installer:
  `D:\Development\ztool\_local_artifacts\releases\2026-06-17-prod-clean\release\client-installer\ZTool-1.0.0-20260617-135653-Setup.exe`
- activation key:
  `D:\Development\ztool\_local_artifacts\secrets\licenses\ztool-manual-activation-key-id-41.txt`
