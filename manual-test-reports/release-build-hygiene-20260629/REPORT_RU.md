# Version/build hygiene после #106

Дата: 2026-06-29

Статус: BUILD HYGIENE ONLY

Production GO: NO-GO

## Что закрыто

Этот слой защищает сборку installer от stale package.

`scripts/build_client_installer.ps1` теперь по умолчанию принимает только package
текущей версии из `VERSION`.

Проверяются:

- `manifest.version`;
- `ProductVersion`;
- имя package root (`SWTools-<VERSION>`);
- `PackageName`.

Историческую пересборку старого package можно выполнить только явно через
`-AllowNonCurrentVersion`; в этом случае скрипт печатает предупреждение.

Gate теперь включает functional negative test: создаётся временный package
старой версии, запускается `scripts/build_client_installer.ps1`, и ожидается
ошибка `non-current installer package blocked` до любых проверок runtime-файлов.

## Что не закрыто

Этот PR не закрывает:

- bump версии;
- сборку installer;
- signing;
- live SolidWorks E2E;
- visual L-01..L-15;
- release dossier;
- accepted hash promotion;
- Production GO.

## Gates

Добавлен CI gate:

```powershell
python tools\e2e\check_client_installer_version_guard.py --self-test
python tools\e2e\check_client_installer_version_guard.py
```

Ожидаемый результат: `PASS`.
