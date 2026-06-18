# Release Versioning

## Source of truth

Текущая версия релиза хранится в корневом файле:

```text
VERSION
```

Для текущей ветки стартовая версия:

```text
1.1.0-alfa
```

Дата сборки не является версией продукта. Дату можно смотреть в manifest/log,
но имя package и installer строятся от `VERSION`.

## Layout

Готовые релизы лежат в корне проекта:

```text
releases\<version>\
```

Структура одного релиза:

```text
releases\<version>\
  ZTool-<version>-Setup.exe
  ZTool-<version>-Setup.manifest.json
  ZTool-<version>-Setup.build.log
  package\
    ZTool-<version>\
      manifest.json
      SHA256SUMS.txt
      runtime\
      license-server\
      docs\
      deploy\
```

`releases/` не пушится в git. Это локальный build output, как `bin/obj/out`.

## Commands

Обычная сборка клиента берёт версию из `VERSION` и записывает её в
`client-core/out/ZTool.manifest.json`:

```powershell
.\client-core\build.ps1
```

Release package по умолчанию пишет в `releases\<version>\package`:

```powershell
.\scripts\build_release_package.ps1 -SolidWorksToolsDll "C:\path\to\SolidWorksTools.dll"
```

Installer из package по умолчанию пишет setup прямо в `releases\<version>`:

```powershell
.\scripts\build_client_installer.ps1 `
  -PackageRoot .\releases\1.1.0-alfa\package\ZTool-1.1.0-alfa
```

## Rules

- Не добавлять timestamp в `Version`.
- Для нового публичного build менять `VERSION`.
- Для scratch/evidence/secrets использовать только `_local_artifacts/`.
- Перед `git push` проверять, что `releases/` и `_local_artifacts/` не staged.
