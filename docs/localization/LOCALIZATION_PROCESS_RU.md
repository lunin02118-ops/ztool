# Процесс локализации ZTool

Цель Phase 07 - не переводить строки “на глаз”, а держать локализацию как
проверяемый pipeline.

## Правило

Любая Han-строка в `ZTool.exe` должна быть в одном из состояний:

- переведена через `client-core/tools/Localizer/translations.tsv`;
- явно whitelisted как protocol key, font name, technical log или known
  remaining vendor/technical string;
- попала в `unclassified_han` и валит gate.

## Основной прогон

```powershell
cd D:\Development\ztool\repo-main
$env:DOTNET_ROOT='D:\Development\ztool\.dotnet'
$env:PATH='D:\Development\ztool\.dotnet;' + $env:PATH

python client-core\tools\localization_scan.py `
  --exe client-core\out\ZTool.exe `
  --translations client-core\tools\Localizer\translations.tsv `
  --whitelist-dir localization `
  --report localization-report.json `
  --fail-on-unclassified
```

Если `unclassified_han` не пустой:

1. если строка user-facing - добавить перевод в `translations.tsv`;
2. если строку нельзя переводить - добавить в соответствующий whitelist и
   объяснить причину;
3. если это новая видимая строка - приложить скрин к manual checklist.

## Генерация/обновление таблицы переводов

```powershell
dotnet run -c Release --project client-core\tools\Localizer -- `
  --gentable client-core\out\ZTool.exe client-core\tools\Localizer\translations.tsv
```

После `--gentable` обязательно прогнать `localization_scan.py` и проверить
пустые RU-ячейки.
