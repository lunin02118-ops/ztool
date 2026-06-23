# Local Artifacts Policy

## Назначение

Все локальные временные артефакты разработки ZTool должны храниться только в:

`D:\Development\ztool\_local_artifacts`

Готовые release packages и установщики для ручного теста/выдачи хранятся в
корневой папке:

`D:\Development\ztool\releases\<version>`

Нельзя создавать рабочие ZTool-папки в:

- `D:\`
- `D:\tmp`
- `C:\Temp`
- `D:\Development` рядом с `ztool`
- корне `D:\Development\ztool`, если это не исходники/скрипты/документация

## Структура

- `releases\<version>\`
  - готовый versioned release: installer, package, package manifest, SHA256SUMS.
- `releases\<version>\package\ZTool-<version>\`
  - распакованный package input для installer.
- `_local_artifacts\secrets\licenses\`
  - локальные копии activation keys и другие секреты. Не печатать значения в чат, отчеты или git diff.
- `_local_artifacts\secrets\client-rekey\`
  - локальные `orig_*.txt` / `new_*.txt` inputs для `client-rekey`. Эти файлы
    не должны быть tracked в Git.
- `_local_artifacts\evidence\`
  - screenshots, UI evidence, appdata snapshots, ручные test artifacts.
- `_local_artifacts\worktrees\`
  - git worktrees. Перемещать только через `git worktree move`.
- `_local_artifacts\archive\`
  - старые рабочие директории, архивные копии, исторические release folders.
- `_local_artifacts\scratch\`
  - probes, временные scripts, logs, registry exports, network diagnostics.

## Git policy

`_local_artifacts/` и `releases/` должны быть исключены из git.

Перед staging/push обязательно проверить:

```powershell
git status --short --ignored -- _local_artifacts releases
```

Нормальный результат:

```text
!! _local_artifacts/
!! releases/
```

В git можно пушить только исходники, build scripts и документацию, например:

- `installer/windows-client/ZToolClient.nsi.in`
- `scripts/build_client_installer.ps1`
- `docs/production/*.md`
- релевантные sanitised reports в `manual-test-reports/`

В git нельзя пушить:

- `_local_artifacts/`
- `releases/`
- `.exe/.msi` installers
- activation keys
- `client-rekey/*.txt` rekey input material
- server secrets
- raw logs, screenshots, registry exports и временные diagnostics

## Current release layout

- version source of truth: `D:\Development\ztool\VERSION`
- package:
  `D:\Development\ztool\releases\<version>\package\ZTool-<version>`
- installer:
  `D:\Development\ztool\releases\<version>\ZTool-<version>-Setup.exe`
- activation keys and secrets:
  `D:\Development\ztool\_local_artifacts\secrets\licenses\`
