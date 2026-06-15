# Указатель документации ZTool

Все документы на русском языке. Статус актуальности — на момент слияния
**PR #8** (merge `78e679c`, дата 2026-06-14).

Полный аудит документации (что актуально, что устарело, найденный мусор):
[`DOC_AUDIT_2026-06-14_RU.md`](DOC_AUDIT_2026-06-14_RU.md).

## Точки входа

| Документ | Описание |
|----------|----------|
| [`../README.md`](../README.md) | Корневой обзор проекта, рекомендуемая связка для деплоя |
| `../help_ru.chm` | Русская справка пользователя (перевод `help.CHM`) |
| [`../tools/chm-i18n/README.md`](../tools/chm-i18n/README.md) | Как пересобрать русскую справку |

## Отчёты тестирования (актуальны, PR #8)

| Документ | Описание |
|----------|----------|
| [`../manual-test-reports/SUMMARY.md`](../manual-test-reports/SUMMARY.md) | Сводный итог по PR #8 (3 фронта, рекомендуемая связка, хеши) |
| [`../manual-test-reports/PR8_BOM_LIVE_TEST_20260612.md`](../manual-test-reports/PR8_BOM_LIVE_TEST_20260612.md) | Живые ретесты в SolidWorks 2025 (8/8 режимов, copy/paste) |

## Планы и методики

| Документ | Описание | Статус |
|----------|----------|--------|
| [`production/PRODUCTION_HARDENING_PLAN_RU.md`](production/PRODUCTION_HARDENING_PLAN_RU.md) | Production hardening roadmap по фазам 00–10 | актуален |
| [`production/RELEASE_BASELINE_RU.md`](production/RELEASE_BASELINE_RU.md) | Baseline текущего `main`: хеши, тесты, ограничения | актуален |
| [`production/RISK_REGISTER_RU.md`](production/RISK_REGISTER_RU.md) | Production risk register | актуален |
| [`production/AUDIT_GATES_RU.md`](production/AUDIT_GATES_RU.md) | Audit/merge gates для hardening PR | актуален |
| [`production/OPERATIONS_TODO_RU.md`](production/OPERATIONS_TODO_RU.md) | Operations backlog для production deployment | актуален |
| [`PLAN_BOM_MODES_RU.md`](PLAN_BOM_MODES_RU.md) | План по режимам экспорта BOM | актуален |
| [`localization/LOCALIZATION_PROCESS_RU.md`](localization/LOCALIZATION_PROCESS_RU.md) | Проверяемый процесс локализации и JSON scan gate | актуален |
| [`localization/WHITELIST_POLICY_RU.md`](localization/WHITELIST_POLICY_RU.md) | Правила whitelist для оставшихся Han-строк | актуален |
| [`localization/UI_SCREENSHOT_CHECKLIST_RU.md`](localization/UI_SCREENSHOT_CHECKLIST_RU.md) | Ручной UI checklist для release candidate | актуален |
| [`../ЗАДАНИЕ_И_МЕТОДИКА_АУДИТА.md`](<../ЗАДАНИЕ_И_МЕТОДИКА_АУДИТА.md>) | Задание и методика аудита | актуален |
| [`../МЕТОДИКА_ПРОВЕРКИ.md`](<../МЕТОДИКА_ПРОВЕРКИ.md>) | Общая методика проверки | актуален |
| [`../МЕТОДИКА_ТЕСТА_ПРИЛОЖЕНИЯ.md`](<../МЕТОДИКА_ТЕСТА_ПРИЛОЖЕНИЯ.md>) | Методика теста всего приложения (DLL+EXE+сервер) | актуален |
| [`../МЕТОДИКА_ДАМПА_DLL.md`](<../МЕТОДИКА_ДАМПА_DLL.md>) | Методика снятия дампа `ZTool.dll` | актуален |
| [`../МЕТОДИКА_ТЕСТА_DLL.md`](<../МЕТОДИКА_ТЕСТА_DLL.md>) | Методика теста `ZTool.dll` | актуален |
| [`../Шаблоны спецификации/МЕТОДИКА_ТЕСТИРОВАНИЯ_BOM.md`](<../Шаблоны спецификации/МЕТОДИКА_ТЕСТИРОВАНИЯ_BOM.md>) | Методика тестирования шаблонов BOM | актуален |

## Аудит и русификация

| Документ | Описание | Статус |
|----------|----------|--------|
| [`audit/README.md`](audit/README.md) | Правила implementation reports для hardening фаз | актуален |
| [`audit/phase-00-baseline-implementation-report.md`](audit/phase-00-baseline-implementation-report.md) | Отчёт Phase 00 baseline docs | актуален |
| [`../AUDIT_ru.md`](<../AUDIT_ru.md>) | Аудит дистрибутива и методика русификации | исторический (см. раздел «Актуализация PR #8» в конце) |
| [`../AUDIT_REPORT_RU.md`](<../AUDIT_REPORT_RU.md>) | Отчёт аудита: русификация + сервер лицензий | исторический (см. раздел «Актуализация PR #8» в конце) |

> Оба аудита написаны 29–30 мая 2026 и фиксировали состояние **до** PR #8
> (тогда «код/бинарь не изменялся»). В конец каждого добавлен раздел
> **«Актуализация (PR #8)»** с текущим статусом и хешами.

## Лицензирование

| Документ | Описание |
|----------|----------|
| [`../LICENSING_audit_ru.md`](<../LICENSING_audit_ru.md>) | Аудит подсистемы лицензирования |
| [`../LICENSING_migration_plan_ru.md`](<../LICENSING_migration_plan_ru.md>) | План миграции лицензирования (не реализован) |
| [`../license-server/README.md`](../license-server/README.md) | Сервер активации (запуск, протокол) |
| [`../license-server/docs/license_format.md`](../license-server/docs/license_format.md) | Формат лицензионного blob |

## README подсистем

| Документ | Описание |
|----------|----------|
| [`../client-core/README.md`](../client-core/README.md) | Клиентский C#-код и инструменты |
| [`../client-core/tools/BinderInject/README.md`](../client-core/tools/BinderInject/README.md) | Патчер десериализации (`VTBinder` + `SafeListBinder`) |
| [`../client-rekey/README.md`](../client-rekey/README.md) | Работа с лицензионными ключами |
| [`../Шаблоны спецификации/README.md`](<../Шаблоны спецификации/README.md>) | Шаблоны спецификаций BOM |
