# S7 receiver handle recovery live report

Дата: 2026-06-25

Статус: `S7/S8/branding PASS / PRODUCTION GO: NO-GO / VISUAL FULL PASS: NO-GO`

## Контекст

Цель проверки: закрыть регресс `Подключить SW`, где SWTools запускался рядом с
SolidWorks, но таблица не заполнялась или E2E зависал на скрытом/устаревшем
окне.

Проверка выполнялась на реальной Windows/SolidWorks 2025 машине.

## Причина

Найдены три связанные причины.

1. Add-in мог повторно использовать устаревший `PMPHandler.Handle`.
   Объект формы ещё существовал, но native window handle уже мог быть
   недействителен. В этом случае `openZtool` передавал SWTools неверный receiver
   handle.

2. `PMPHandler.sendmessageC` отправлял `WM_COPYDATA` через синхронный
   `SendMessage` на сохранённый `f_207`. Если `f_207` указывал на старый или
   зависший SWTools window, SolidWorks/add-in мог зависнуть до live timeout.

3. E2E S7 harness подключался к SWTools через process-wide UIA
   `Application.connect(process=...)`. На живой машине SWTools иногда имел
   скрытые WinForms top-level windows, из-за чего process-wide UIA connect мог
   зависать до получения grid evidence.

4. Internal receiver window на живой машине является hidden top-level
   WinForms window SolidWorks PID, а не child window desktop root. Глобальный
   `EnumChildWindows(GetDesktopWindow())` мог зависнуть до первого checkpoint.

## Исправления

- `SwAddin.EnsurePMP()` теперь проверяет не только managed form state, но и
  `IsHandleCreated` + native `IsWindow(handle)`. Если handle мёртвый, handler
  пересоздаётся.
- `SwAddin.openZtool()` больше не показывает ложный SolidWorks dialog
  `Тайм-аут соединения` при ожидании окна SWTools. После запуска процесса
  выполняется короткий `WaitForInputIdle(3000)`, а live evidence проверяется
  отдельным S7 gate.
- `PMPHandler.sendmessageC()` теперь валидирует `f_207` и использует
  `SendMessageTimeout(..., SMTO_ABORTIFHUNG, ...)`. Старый/зависший receiver
  сбрасывается вместо блокировки SolidWorks.
- `scripts/swtools_s7_live_smoke.py` перешёл на handle-first path: находит
  главный SWTools window по PID/hwnd, восстанавливает его через Win32 и уже
  затем оборачивает конкретный hwnd в UIA object. Process-wide UIA connect
  больше не используется.
- S7 harness пишет промежуточный JSON checkpoint после запуска, после выбора
  main hwnd, после invoke `Подключить SW` и во время polling. Это оставляет
  diagnosable evidence даже при timeout.
- Receiver discovery в S7 harness теперь process-scoped: `EnumWindows` +
  проверка SolidWorks PID и title, без обхода всего desktop child tree.

## Live evidence

Основной live прогон:

```text
D:\Development\ztool\_local_artifacts\reports\s7-receiver-handle-recovery-authoritative-20260625
```

Ключевые результаты:

```text
e2e-result.json: PASS
production_go_allowed: false
07-s7-connect: PASS
08-s8-bom-export: PASS
09-excel-validation: PASS
10-branding-version: PASS
```

S7:

```text
rows: 29
columns: 40
status: Подключение завершено, затрачено 0,3 сек, всего 29 поз.
model_ready_gate: PASS
receiver_windows_after_launch: internal receiver found in SolidWorks PID
SWTools main hwnd: found by process-scoped Win32 enumeration
```

S8 strict BOM:

```text
mode 1 rows: 29
mode 2 rows: 32
mode 3 rows: 6
mode 4 rows: 25
mode 5 rows: 29
mode 6 rows: 32
mode 7 rows: 18
mode 8 rows: 6
strict filters: PASS
semantic Excel validation: PASS
```

Branding/version/icon:

```text
branding/version stage: PASS
icon_hash_match: true
```

## Gates

Выполнено:

```powershell
dotnet build <add-in project> -c Release `
  -p:SolidWorksDir="C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS"

python -m py_compile scripts\swtools_s7_live_smoke.py

python tools\e2e\assert_e2e_result.py `
  D:\Development\ztool\_local_artifacts\reports\s7-receiver-handle-recovery-authoritative-20260625\e2e-result.json `
  --expect-status PASS `
  --require-stage-pass 07-s7-connect `
  --require-stage-pass 08-s8-bom-export `
  --require-stage-pass 09-excel-validation `
  --require-stage-pass 10-branding-version `
  --require-s7-min-rows 29 `
  --require-s7-min-columns 30 `
  --require-s7-model-ready `
  --require-s8-mode-count 8 `
  --require-s8-all-pass `
  --require-s8-strict-filters `
  --require-branding-version

python tools\secret_scan.py
git diff --check
python tools\check_visible_brand_boundary.py
```

## Граница

Этот fix закрывает live S7 receiver/IPC regression и укрепляет S7 automation.
Он не является production GO. До production GO остаются full visual localization
acceptance, signing, final release dossier, accepted hash decision и owner GO.
