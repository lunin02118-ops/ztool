# E2E S7 model-ready gate

Дата: 2026-06-25

Scope: предотвращение регресса, когда `SWTools.exe` открывается до окончания
загрузки сборки SolidWorks.

## Проблема

SolidWorks может вернуть целевую сборку как `ActiveDoc`, пока ещё открыто
штатное transient-окно загрузки:

```text
Открытие компонентов
Обновление сборки
Обновление графики
Загружается файл: ...\PArt-017.SLDASM
```

Если в этот момент вызвать `ZTool.SwAddin.openZtool(0)`, live S7 может упасть
на модальном окне SolidWorks или дать ложный blocker до `Подключить SW`.

## Контракт

Перед `openZtool(0)` S7 smoke обязан:

```text
[PASS] убедиться, что ActiveDoc == ожидаемая .SLDASM;
[PASS] дождаться стабильного интервала без transient loading dialog;
[FAIL] зафиксировать не-transient модальное окно как blocking_dialog;
[FAIL] зафиксировать timeout ожидания готовности модели;
[NEVER] закрывать transient loading dialog координатами, Enter, Escape или OK.
```

Transient loading dialog не является ошибкой и не закрывается тестом. Это
ожидаемое состояние SolidWorks, которое нужно переждать.

## Evidence

`scripts\swtools_s7_live_smoke.py` пишет:

```text
model_ready_gate.status
model_ready_gate.active_model
model_ready_gate.waited_seconds
model_ready_gate.stable_for_seconds
model_ready_gate.transient_dialog_count
model_ready_gate.transient_dialogs[]
model_ready_gate.blocking_dialog
```

`scripts\e2e\Invoke-SWToolsE2E.ps1` пробрасывает этот объект в:

```text
stages[07-s7-connect].details.model_ready_gate
```

`tools\e2e\assert_e2e_result.py --require-s7-model-ready` требует:

```text
07-s7-connect = PASS
model_ready_gate.status = PASS
model_ready_gate.active_model заполнен
```

## Не закрывает

```text
[ ] S8/BOM 1-8;
[ ] strict BOM filters 7/8;
[ ] branding/version/icon;
[ ] visual localization FULL PASS;
[ ] production GO.
```
