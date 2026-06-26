# S7 live harness: no-license dialog absent / demo probe hang

Дата: 2026-06-25

Статус: `HARNESS FIX / PRODUCT SOURCE UNCHANGED / PRODUCTION GO: NO-GO`

## Контекст

После merge #99/#100/#101 был запущен clean release E2E из пути вне репозитория:

```text
D:\SWToolsE2E\release-e2e-20260625-224553
```

Цель: получить чистый runtime path без `ztool` в видимых Help URL перед
последующей visual-localization съёмкой.

## Наблюдение

Build/package/preflight прошли, затем `07-s7-live-smoke` завис до timeout:

```text
E2E command timed out after 180 seconds.
```

При этом промежуточный `s7-live-smoke-result.json` уже доказал:

- runtime hashes OK;
- SolidWorks model-ready gate PASS;
- add-in object OK;
- `openZtool(0)` done;
- `SWTools.exe` запущен из ожидаемого clean runtime;
- receiver `Ztool_Receiver` найден в процессе SolidWorks.

## Причины

1. Когда license/trial dialog не показан, старый harness всё равно выполнял
fallback-поиск кнопки `Демо` внутри главного окна:

```python
main_win32 = Desktop(backend="win32").window(handle=main_hwnd)
invoke_text(main_win32, "Демо", timeout=1.0)
```

На живом `SWTools.exe` этот `win32.descendants()` мог зависнуть на главной форме.

2. `dismiss_license_dialog()` перед этим обходил descendants у всех top-level
окон процесса `SWTools.exe`. В список попадала большая главная WinForms-форма
`SWTools 1.1.6+...`, и её traversal тоже мог блокировать automation.

Обе причины относятся к test harness. Это не продуктовый баг и не IPC-регресс.

## Исправление

Если license/trial dialog отсутствует, harness больше не ищет `Демо` в главном
окне. Он фиксирует это в checks и сразу переходит к UIA/legacy invoke
`Подключить SW`:

```text
license/trial dialog not shown; skipping demo button probe
```

Кроме того, license-dialog scan теперь заранее отбрасывает главное окно
`SWTools` и служебные окна (`tooltips`, `GDI+`, broadcast, IME). Текст
сканируется только у небольших dialog-like top-level окон (`#32770` или
WinForms forms/dialogs), где действительно может быть license/trial prompt.

Продуктовый source/runtime behavior не менялся.

## Проверки

До clean rerun:

```powershell
python -m py_compile scripts\swtools_s7_live_smoke.py
```

После commit/amend выполнен clean release E2E:

```text
D:\SWToolsE2E\release-e2e-20260625-231119
```

Результат:

- wrapper status: `PASS`;
- `production_go_allowed=false`;
- dirty manifest: `false`;
- S7: `PASS`, `29` строк, `40` колонок;
- S8: `PASS`, `8/8`;
- strict BOM filters: `PASS`;
- branding/version/icon: `PASS`;
- runtime title: `SWTools 1.1.6+12e0ea2.clean(x64)`.

Фактический S7 evidence:

```text
D:\SWToolsE2E\release-e2e-20260625-231119\s7-live-smoke\s7-live-smoke-result.json
```

В нём зафиксировано:

- `license_dialog.found=true`;
- `license_dialog.dismissed=true`;
- `license_dialog.button=Демо`;
- `connect_invoke.result.attempts[0].action=invoke`;
- `status_text=Подключение завершено, затрачено 0,3 сек, всего 29 поз.`;
- `row_count=29`;
- `column_count=40`.

## Остаточный риск

- Нужно выполнить H-01..H-03 / L-01..L-15 visual capture из clean runtime path.
- Production GO остаётся `NO-GO` до visual FULL PASS, signing, final dossier,
  accepted hashes и owner GO.
