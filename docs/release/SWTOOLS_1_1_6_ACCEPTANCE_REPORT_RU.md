# SWTools 1.1.6 acceptance report

Дата: 2026-06-21/22
Ветка: `devin/1782091728-phaseD-addin-source`
Пакет: `releases/1.1.6/SWTools-1.1.6-Setup.exe`

## Артефакты

- Installer SHA256: `26aabcfbb6dec8538e96076df79d235a2b729bb73f2519d8b0513a03f155ab13`
- Installed `SWTools.exe` SHA256: `f418c7d81a735c309b4fb0709c8bd81333d95cfab9c7468aa2329add0a364e09`
- `SWTools.dll` SHA256: `5dbf9986a4fbce5e6ab8fa4269705732c6ba891d1b27988e60e10c191ae290c1`
- FileVersion/ProductVersion: `1.1.6`
- Runtime path after clean install: `C:\Program Files\SWTools\SWTools.exe`
- Expected hashes source of truth: `scripts/expected_release_hashes.json`, version `1.1.6`

## Installer Fix

Статус: PASS.

- Исправлен NSIS install-time patch `SWTools.settings`: `bomname` и `materialpath`
  переписываются на `C:\Program Files\SWTools\...`.
- Убрана ложная ошибка инсталлятора от `nsExec::ExecToStack`: helper пишет
  `OK: ...`, но ненулевой stdout больше не трактуется как failure.
- После patch-функции восстановлен `$0` для `RegAsm`, иначе следующая стадия
  могла использовать не тот путь.

Evidence:

- `manual-test-reports\2026-06-21-clean-install-1.1.6\04-install-1.1.6.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\05-installed-runtime-1.1.6.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\06-installed-bom-template-check.log`

## Clean Install And Licensing

Статус: PASS.

- Старая установка удалена.
- Перед clean-license проверкой очищены и сохранены в backup:
  - `HKCU\SOFTWARE\SWTools`
  - `HKCU\SOFTWARE\ZTool`
  - `HKLM\SOFTWARE\SolURxxCfNU`
  - `HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ`
- Найдена причина ложных clean PASS: клиент хранит часть license-state в legacy
  HKLM blob-ключах из `SR.IsReg2`; очистка только HKCU недостаточна.
- После полной очистки первый запуск показал «Лицензия не обнаружена».
- Production binding сброшен на боевом сервере, затем выполнена онлайн-активация
  тем же test-key.
- Полный ключ/пароль не попали в отчёт; фиксируются только mask/hash/length:
  - code mask: `DNBG...K953`
  - code SHA12: `41bae9af8041`
  - code segment lengths: `8,5,5,5,9`
  - password length: `12`
  - password SHA12: `0e10c16663ac`
- Ввод activation form выполнен через clipboard/real edit input с read-back; native
  `SetWindowText` для activation gate не использовался.
- После `Регистрация выполнена` старый PID завершился, новый SWTools PID стартовал
  автоматически.
- Server-side состояние после активации:
  - `current_activations=1`
  - `max_activations=1`
  - `machine_bound=true`
  - `is_active=1`
  - `is_revoked=0`
  - last activation log: `activate`, `success=1`, `error_message=accepted`

Evidence:

- `manual-test-reports\2026-06-21-clean-install-1.1.6\15-full-license-registry-clean.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\17-license-not-found-targets.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\activation-form-readback-redacted.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\activation-restart-redacted.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\activation-server-state-redacted.out.log`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\20-post-activation-local-state.json`

## SolidWorks Live Smoke

Статус: PASS.

- SolidWorks 2025 открыт с `TestModel\0614-A00.SLDASM`.
- SWTools запущен из установленного runtime.
- После `Подключить SW`: статус `Подключение завершено`, найдено `29` уникальных
  строк (`0..28`), видны ключевые заголовки таблицы.
- Проверены установочные registry keys SolidWorks add-in: Title `SWTools`,
  Description `SWTools SolidWorks Add-in`, autoload включён.

Evidence:

- `manual-test-reports\2026-06-21-clean-install-1.1.6\22-solidworks-model-launch.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\23-solidworks-model-loaded.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\30-connect-sw-uia-candidates-1.1.6.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\34-connect-second-split-summary-1.1.6.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\35-grid-and-export-targets-1.1.6.json`

## Property Import Button Click

Статус: PASS.

- Проверен установленный runtime: `C:\Program Files\SWTools\SWTools.exe`.
- SHA256 установленного exe:
  `5a9c43e3559064ce3a2a913e3297d117ec0f9ecd4c9867b6367b86b256362397`.
- Через WinForms/Reflection harness открыта реальная форма
  `ZTool.Frmsetpropname` (`Задать имя свойства`).
- До клика проверено состояние `MySWDM`: `isok=true`, `err=null`.
- Выполнен реальный путь кнопки:
  - `Button1.PerformClick()` для кнопки `Импорт...`;
  - `AddPropertyNamesFromfile.PerformClick()` для пункта `Получить из файла`.
- Результат: стандартный file dialog открылся, окно `Ошибка` не появилось.
- Это закрывает конкретный регресс из лога:
  `ISwDMClassFactory.GetApplication()` / `MySWDM..ctor()` больше не отдаёт
  `System.Object` из `ZTool, PublicKeyToken=f08fc...` на установленном 1.1.6.

Evidence summary:

```json
{
  "exe": "C:\\Program Files\\SWTools\\SWTools.exe",
  "exe_sha256": "5a9c43e3559064ce3a2a913e3297d117ec0f9ecd4c9867b6367b86b256362397",
  "form_created": true,
  "my_swdm_isok_before_click": true,
  "my_swdm_err_before_click": null,
  "import_button_text": "Импорт...",
  "menu_item_text": "Получить из файла",
  "import_button_perform_click": true,
  "menu_item_perform_click": true,
  "saw_open_file_dialog": true,
  "saw_error_dialog": false,
  "pass": true
}
```

## BOM/Excel Export

Статус: PASS/WARN.

- Экспорт выполнен через живой UI SWTools: ribbon `Экспорт спецификации` →
  gallery mode → `SaveFileDialog`.
- Сохранено 8 `.xlsx` файлов.
- Валидатор `client-core\tools\validate_bom_exports.py`:
  - режимы 1-6: PASS, данные есть;
  - режимы 5-6: embedded sketches present;
  - режимы 7-8: WARN, фильтры вернули 0 строк, потому что в demo-model нет
    совпадающего свойства `Тип` для строгой filter-проверки.
- Расчётные колонки подтверждены Excel read-back:
  - `Кол-во`: заполнено;
  - `Масса ед. кг`: заполнено;
  - `Габаритные размеры`: заполнено;
  - `Путь`: заполнено.
- Установленный `SWTools.settings` прошёл `check_bom_template.py`: `Col_Weight`
  привязан к `МассаЕдКг`, `Col_bound` к `ГабаритныеРазмеры`; dev-path в settings
  отсутствует.

Evidence:

- `manual-test-reports\2026-06-21-clean-install-1.1.6\bom-exports\*.xlsx`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\62-validate-bom-exports-all.log`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\63-bom-export-calculated-columns.json`
- `manual-test-reports\2026-06-21-clean-install-1.1.6\06-installed-bom-template-check.log`

## Gates

Статус: PASS.

- `pwsh` parse для изменённых scripts: PASS.
- `scripts\verify_release_package.ps1 -PackageRoot releases\1.1.6\package\SWTools-1.1.6 -RequireSolidWorksTools -AllowDirtyManifest`: PASS.
- `python client-core\tools\check_bom_template.py "C:\Program Files\SWTools\SWTools.settings"`: PASS.
- `python -m pytest license-server`: `117 passed, 2 skipped`.
- `python tools\secret_scan.py`: PASS.
- `git diff --check`: PASS.

Residual risk: строгий PASS фильтровых режимов 7/8 требует demo-model с
заполненным русским свойством `Тип`; текущая модель валидирует сам экспорт и
пустой результат фильтра как ожидаемый WARN.
