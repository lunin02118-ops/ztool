# Указатель документации ZTool

Все документы на русском языке. Главная рабочая методика тестирования после
рефакторинга — `docs/release/FULL_TEST_METHODOLOGY_RU.md`.

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
| [`client-core/BINARY_BUILD_POLICY_RU.md`](client-core/BINARY_BUILD_POLICY_RU.md) | Правила fail-closed client-core build, input hashes, manifest, PublicKeyToken | актуален |
| [`security/THREAT_MODEL_RU.md`](security/THREAT_MODEL_RU.md) | Threat model production-системы лицензирования | актуален |
| [`security/KEY_COMPROMISE_RUNBOOK_RU.md`](security/KEY_COMPROMISE_RUNBOOK_RU.md) | Runbook при компромиссе RSA private key | актуален |
| [`security/ABUSE_RATE_LIMIT_POLICY_RU.md`](security/ABUSE_RATE_LIMIT_POLICY_RU.md) | Abuse/rate-limit policy и fail2ban пример | актуален |
| [`security/DATA_RETENTION_PRIVACY_RU.md`](security/DATA_RETENTION_PRIVACY_RU.md) | Data retention, privacy и redaction policy | актуален |
| [`release/FULL_TEST_METHODOLOGY_RU.md`](release/FULL_TEST_METHODOLOGY_RU.md) | **Единственная актуальная методика полного тестирования всего функционала с паритетом к оригиналу**; включает запуск через `.SLDASM`, registry pre-flight, координаты UI, свойства, BOM и цвета | актуален |
| [`release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md`](release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md) | Финальный план приёмочного тестирования release package | актуален |
| [`release/PRODUCTION_READINESS_REPORT_RU.md`](release/PRODUCTION_READINESS_REPORT_RU.md) | Шаблон production readiness report | актуален |
| [`../ЗАДАНИЕ_И_МЕТОДИКА_АУДИТА.md`](<../ЗАДАНИЕ_И_МЕТОДИКА_АУДИТА.md>) | Задание и методика аудита | актуален |
| [`archive/legacy-test-methods/README.md`](archive/legacy-test-methods/README.md) | Архив старых методик тестирования; использовать только как историческую справку | архив |
| [`archive/legacy-test-methods/МЕТОДИКА_ПРОВЕРКИ.md`](<archive/legacy-test-methods/МЕТОДИКА_ПРОВЕРКИ.md>) | Старая общая методика проверки | архив / не запускать напрямую |
| [`archive/legacy-test-methods/МЕТОДИКА_ТЕСТА_ПРИЛОЖЕНИЯ.md`](<archive/legacy-test-methods/МЕТОДИКА_ТЕСТА_ПРИЛОЖЕНИЯ.md>) | Старая методика теста приложения | архив / не запускать напрямую |
| [`archive/legacy-test-methods/МЕТОДИКА_ДАМПА_DLL.md`](<archive/legacy-test-methods/МЕТОДИКА_ДАМПА_DLL.md>) | Старая методика снятия дампа `ZTool.dll` | архив / по необходимости |
| [`archive/legacy-test-methods/МЕТОДИКА_ТЕСТА_DLL.md`](<archive/legacy-test-methods/МЕТОДИКА_ТЕСТА_DLL.md>) | Старая методика теста `ZTool.dll` | архив / не запускать напрямую |
| [`archive/legacy-test-methods/МЕТОДИКА_ТЕСТИРОВАНИЯ_BOM.md`](<archive/legacy-test-methods/МЕТОДИКА_ТЕСТИРОВАНИЯ_BOM.md>) | Старая методика тестирования BOM-шаблонов | архив / не запускать напрямую |

## Аудит и русификация

| Документ | Описание | Статус |
|----------|----------|--------|
| [`audit/README.md`](audit/README.md) | Правила implementation reports для hardening фаз | актуален |
| [`audit/phase-00-baseline-implementation-report.md`](audit/phase-00-baseline-implementation-report.md) | Отчёт Phase 00 baseline docs | актуален |
| [`audit/phase-10-release-packaging-implementation-report.md`](audit/phase-10-release-packaging-implementation-report.md) | Отчёт Phase 10 release packaging | актуален |
| [`audit/prod-readiness-audit-followup-2026-06-15.md`](audit/prod-readiness-audit-followup-2026-06-15.md) | Follow-up по блокерам B-1/B-2 из production readiness audit | актуален |
| [`audit/refactor-production-readiness-gap-audit-2026-06-16_RU.md`](audit/refactor-production-readiness-gap-audit-2026-06-16_RU.md) | Gap-аудит: почему hardening не закрыл клиентский SolidWorks-паритет и цвет/запуск | актуален |
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
