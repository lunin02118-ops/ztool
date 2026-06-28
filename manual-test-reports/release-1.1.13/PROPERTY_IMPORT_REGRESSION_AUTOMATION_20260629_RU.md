# SWTools 1.1.13: простая автоматическая регрессия импорта свойств

Дата: 2026-06-29
Scope: `Задать имя свойства -> Импорт...`

## 1. Цель

Проверить регрессию импорта имён свойств без ручного тыканья и без координат:

- `Получить из файла`;
- `Получить из папки`;
- `Получить из открытых в SolidWorks компонентов`.

Это backend/core regression gate по тому же принципу, что BOM automation:
запускается текущий `SWTools.exe`, probe вызывает реальный импортный путь через
reflection и пишет JSON evidence.

## 2. Что не менялось

Runtime/product code этим проходом не менялся.

Удалена из рабочей папки временная UI-автоматизация, которая пыталась вести окно
`Импорт...` через WinForms/UIA. Она не нужна для этого regression gate и не
должна считаться проверкой механики импорта.

## 3. Source of truth

Автоматический gate уже есть в репозитории:

```powershell
python tools\e2e\check_property_import_contract.py --self-test
python tools\e2e\check_property_import_contract.py
```

Он подключён к `release-acceptance.yml` и защищает контракт:

- document-level property names;
- configuration-level property names;
- parity path через active SolidWorks `ModelDoc`;
- запрет silent-empty результата при ошибке SWDM.

Live probe:

```powershell
python tools\e2e\swtools_property_import_live_probe.py `
  --runtime client-src\bin\Release\net48\SWTools.exe `
  --file "D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT" `
  --folder "D:\1602.00.000 Шнек" `
  --folder-max-files 5 `
  --open-components `
  --json-out _local_artifacts\reports\automation-no-manual-20260629-015122\property-import-current-source-default-probe-20260629\property-import-current-source-default-probe.json
```

## 4. Результат live regression

Runtime:

```text
D:\Development\ztool\_local_artifacts\worktrees\p4-next-20260626\client-src\bin\Release\net48\SWTools.exe
```

HEAD:

```text
6f488e3
```

Результат:

| Сценарий | Статус | Кол-во имён |
|---|---:|---:|
| Файл `D:\1602.00.000 Шнек\1602.00.003 Фланец.SLDPRT` | PASS | 46 |
| Папка `D:\1602.00.000 Шнек`, первые 5 SW-файлов | PASS | 91 |
| Открытые SolidWorks компоненты | PASS | 86 |

Обязательный контрактный набор найден:

- `Разработал`;
- `Наименование`;
- `Обозначение`;
- `Масса`;
- `Раздел`;
- `Проект_ФБ`;
- `Number`;
- `Description`.

## 5. Важное уточнение по `Материал` / `Тип`

Не надо требовать `Материал` и `Тип` как обязательные имена для каждого
отдельного файла. На проверенном файле `1602.00.003 Фланец.SLDPRT` список имён
содержит 46 свойств, но именно `Материал` и `Тип` как custom property names там
отсутствуют.

При этом сценарии папки и открытых компонентов находят `Материал`, потому что
он присутствует в других документах/компонентах набора.

Иными словами:

- отсутствие `Материал` / `Тип` в одном конкретном файле не является регрессией
  импорта;
- регрессия была бы, если бы файл/папка/открытые компоненты возвращали пустой
  список или теряли контрактные имена.

## 6. Почему ручной тест мог показывать старую проблему

Скриншоты ручного теста показывали установленный runtime вида:

```text
SWTools 1.1.11+9588cd3.clean(x64)
```

Это не текущий source runtime из этого прохода. Для ручного UI-подтверждения
нужно сначала пересобрать и установить пакет из текущего head, иначе проверяется
устаревшая сборка.

## 7. Production boundary

Этим проходом закрыта автоматическая core-регрессия импорта свойств.

Не заявляется:

- full UI PASS окна `Импорт...`;
- production GO;
- signing / accepted hashes;
- full visual L-01..L-15.

Следующий ручной слой допустим только после установки пакета, собранного из
того же commit, что прошёл live probe.
