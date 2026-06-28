# SWTools 1.1.11: audit handoff по ручной сборке

Дата: 2026-06-28  
PR: `#105`  
Branch: `codex/p4-production-blockers-20260626`  
Commit: `9588cd3 chore: bump manual test build to 1.1.11`  
Статус: **готово к аудиту как manual-test build**  
Production GO: **NO-GO**  

## Краткий итог

Подготовлена новая ручная сборка `SWTools 1.1.11` вместо устаревших `1.1.8` / `1.1.10`.

Главная цель этого прохода: убрать риск, что собирается одно, а устанавливается старый setup из другой папки. Для этого версия поднята до `1.1.11`, установщик пересобран, runtime установлен в `C:\Program Files\SWTools`, а `build_client_installer.ps1` теперь блокирует сборку setup из пакета не текущей версии.

Это не production approval. Полный live-прогон SolidWorks и owner/auditor acceptance остаются отдельными gate.

## Что сделано

### Версия и защита от старых сборок

- `VERSION` поднят до `1.1.11`.
- Собран новый installer: `SWTools-1.1.11-Setup.exe`.
- Добавлена защита в `scripts/build_client_installer.ps1`:
  - если `PackageRoot` содержит версию, отличную от текущего `VERSION`, сборка installer останавливается;
  - обход разрешён только явно через `-AllowNonCurrentVersion` для намеренной архивной пересборки.

Цель защиты: не допустить повторения ситуации, когда ветка уже на новой версии, но запускается stale installer вроде `SWTools-1.1.8-Setup.exe`.

### Сборка, установка и runtime identity

Установлено:

- Runtime dir: `C:\Program Files\SWTools`
- Installer: `[worktree]\releases\1.1.11\SWTools-1.1.11-Setup.exe`

Installed runtime:

| Artifact | ProductVersion | FileVersion | SHA256 |
|---|---|---|---|
| `SWTools.exe` | `1.1.11+9588cd3.clean` | `1.1.11.453` | `f8cbcb1b359be63ecca93b7f59b72b5cdbae3cc06db01f8faf88cb14c4169f4c` |
| `SWTools.dll` | `1.1.11+9588cd3.clean` | `1.1.11.453` | `317dfe1ce462757ed93d546f31c5df3b771d476dde3bcba50de91b1285f91b6a` |
| `SWTools-1.1.11-Setup.exe` | n/a | n/a | `c5c1500f0c30a96cef9a211ace4e82320b79782f3d68ac66892cc91f37947ada` |

### Preflight и регистрация add-in

Выполнено на установленном runtime:

```powershell
pwsh -NoProfile -File scripts\check_swtools_runtime_identity.ps1 -RuntimeDir "C:\Program Files\SWTools"

pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\sw_test_preflight.ps1 `
  -RuntimeDir "C:\Program Files\SWTools" `
  -Register `
  -ExpectedExeSha256 f8cbcb1b359be63ecca93b7f59b72b5cdbae3cc06db01f8faf88cb14c4169f4c `
  -ExpectedDllSha256 317dfe1ce462757ed93d546f31c5df3b771d476dde3bcba50de91b1285f91b6a `
  -ReportDir _local_artifacts\reports\preflight-installed-1.1.11
```

Результат:

- runtime identity: **PASS**
- `RegAsm /codebase`: **PASS**
- `SWTools.dll` add-in brand metadata: **PASS**
- CommandManager cleanup: **CLEAN**
- stale `CodeBase` check: **PASS**
- preflight status: **PASS**

Evidence:

- `_local_artifacts\reports\preflight-installed-1.1.11\preflight-report.json`
- `_local_artifacts\reports\preflight-installed-1.1.11\commandmanager-cleanup\cmgr-cleanup-report.json`
- registry backup: `_local_artifacts\reports\preflight-installed-1.1.11\commandmanager-cleanup\HKCU_SolidWorks.reg`

### Local regression gates

Пройдено:

```powershell
python tools\e2e\check_property_import_contract.py --self-test
python tools\e2e\check_property_import_contract.py
python tools\e2e\swtools_property_import_live_probe.py `
  --runtime client-src\bin\Release\net48\SWTools.exe `
  --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT" `
  --open-components `
  --json-out _local_artifacts\reports\property-import-live-20260628\property-import-file-open.json
python tools\e2e\swtools_property_import_live_probe.py `
  --runtime client-src\bin\Release\net48\SWTools.exe `
  --folder "D:\1602.00.000 Шнек" `
  --folder-max-files 3 `
  --json-out _local_artifacts\reports\property-import-live-20260628\property-import-folder.json
python tools\check_visible_brand_boundary.py
python tools\secret_scan.py
git diff --check
```

Результат:

- property import parity contract: **PASS**
- property import live file probe on SW2025 file: **PASS / 46 names**
- property import live open-components probe: **PASS / 46 names**
- property import live folder probe: **PASS / 78 names from first 3 SW files**
- visible brand boundary: **PASS**
- secret scan: **PASS**
- whitespace diff check: **PASS**

### GitHub CI

Для PR `#105` после push `9588cd3` GitHub checks зелёные:

- `acceptance`: PASS
- `build`: PASS
- `compliance`: PASS
- `release-hardening`: PASS
- `secret-scan`: PASS

Комментарий с evidence добавлен в PR:

- PR `#105`, comment `4822962552`

## Что НЕ проверено в этом проходе

Ниже перечислено именно то, что не надо считать закрытым этим audit handoff.

### Live SolidWorks после bump до 1.1.11

После установки `1.1.11` был выполнен preflight и registration, но полный live-прогон SolidWorks на установленном runtime этим проходом не закрыт:

- открыть `0614-A00.SLDASM` через association;
- запустить SWTools из вкладки SolidWorks;
- `Подключить SW`;
- подтвердить S7 `29` строк / ожидаемые колонки;
- проверить, что running process path именно `C:\Program Files\SWTools\SWTools.exe`;
- подтвердить, что add-in загружен из `C:\Program Files\SWTools\SWTools.dll`.

### BOM / спецификация

Не закрыто на `1.1.11` после установки:

- экспорт BOM `8/8` режимов;
- strict filters для mode `7/8`;
- semantic Excel validation;
- проверка сопоставления заголовков столбцов;
- проверка отсутствия видимого legacy brand token / Han в BOM UI;
- проверка корректности `Тип`, `Материал`, `Масса`, `Габаритные размеры`, `Конфигурация`.

### Импорт и свойства

Native-only решение отменено как регресс. В истории найден ранее принятый фикс `4cf4897` / `84902b6` / `de7bd3c`: файл/папка сначала пробуют `SolidWorks Document Manager`, а если SWDM не отдаёт свойства в текущей SW2025-среде, используется тот же SolidWorks `ModelDoc`/`CustomPropertyManager` путь, который уже работает для открытых компонентов.

Новый machine/live evidence:

- `Получить из файла` core path на `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`: **PASS / 46 names**;
- `Получить из открытых в SolidWorks компонентов` core path: **PASS / 46 names**;
- `Получить из папки` core path на первых 3 SW-файлах `D:\1602.00.000 Шнек`: **PASS / 78 names**.

Evidence:

- `manual-test-reports\release-1.1.11\PROPERTY_IMPORT_PARITY_FIX_20260628_RU.md`;
- `_local_artifacts\reports\property-import-live-20260628\property-import-file-open.json`;
- `_local_artifacts\reports\property-import-live-20260628\property-import-folder.json`.

Live UI scenario не закрыт:

- кнопка `Задать имя свойства` -> `Импорт...`;
- UI-импорт свойств из реальной детали после пересборки/установки текущего head;
- UI-импорт свойств из файла `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT`;
- ручное удаление свойств;
- ручное добавление свойств;
- сохранение свойств обратно в модель;
- проверка, что legacy/Han-свойства не появляются без явной настройки пользователя.

### Лицензирование

Не закрыто в этом проходе:

- clean no-license state;
- онлайн-активация через production license server;
- проверка отзыва/удаления лицензии на сервере;
- проверка поведения без лицензии;
- проверка авто-закрытия/перезапуска после успешной активации.

### Visual/layout acceptance

Не закрыто полностью:

- cumulative visual manifest `L-01..L-15` strict PASS;
- ручной owner/auditor visual review;
- проверка всех окон после последних layout fixes;
- проверка, что текст полностью помещается при минимальном размере окон;
- проверка всех проблемных окон:
  - `Параметры`;
  - `Настроить схему спецификации`;
  - `Заполнить имя файла`;
  - `Параметры сохранения`;
  - `Сохранить в новую папку`;
  - `Заменить ссылочные файлы`;
  - `Копировать резервную копию`;
  - `Пакетное преобразование формата`.

### Production release gates

Остаются блокерами production release:

- Authenticode signing production artifacts;
- accepted hash promotion decision;
- final release dossier;
- owner/auditor visual acceptance;
- explicit owner Production GO.

## Рекомендация аудитору

Этот PR можно аудировать как:

1. **version/build hygiene fix**: новая версия `1.1.11`, защита от stale installer;
2. **manual-test build preparation**: установленный runtime соответствует текущему commit;
3. **preflight-ready state**: add-in зарегистрирован, runtime identity подтверждён.

Этот PR нельзя считать:

- production release approval;
- full SolidWorks functional PASS;
- full visual localization PASS;
- licensing PASS.

Для следующего шага пользователь/исполнитель должен выполнить live manual/E2E на установленной `1.1.11` и приложить отдельный report с результатами S7/S8/licensing/visual checks.
