# ZTool

**ZTool** — надстройка и приложение для **SolidWorks**: управление файлами,
автоматическое заполнение свойств, генерация и экспорт спецификаций (BOM),
пакетная печать/конвертация и переименование компонентов. В комплект входит
собственный сервер лицензирования.

> Репозиторий — это **релизный дистрибутив** (скомпилированные .NET-сборки),
> а также вспомогательный код, инструменты патчинга и документация. Полного
> исходного кода клиентских бинарников здесь нет (см. `AUDIT_ru.md`).

## С чего начать

- Полный указатель документации: **[`docs/INDEX.md`](docs/INDEX.md)**.
- Справка пользователя: `help.CHM` (китайский оригинал) и
  **`help_ru.chm`** (русский перевод).

## Рекомендуемая связка для развёртывания

Актуально после слияния **PR #8** (merge `78e679c`). Обе сборки прошли живые
ретесты в SolidWorks 2025 на сборке `0614-A00.SLDASM` (8/8 режимов BOM):

| Модуль      | Назначение                         | SHA256 (начало)        |
|-------------|------------------------------------|------------------------|
| `ZTool.exe` | главное приложение (`binderfix`)   | `0BF4CB0B…9955864B`    |
| `ZTool.dll` | надстройка SolidWorks (`pmpguard2`)| `D053542…92EB9`        |

Что внесено в PR #8:

1. **Шаблоны/экспорт BOM** — Arial, русификация, корректные имена столбцов;
   8/8 режимов экспорта проходят.
2. **`pmpguard2`** в `ZTool.dll` — снята гонка инициализации (модальное окно
   «Ссылка на объект не указывает на экземпляр…»).
3. **`binderfix`** в `ZTool.exe` — защита небезопасной десериализации:
   - `VTBinder` — version-tolerant привязка типов в конфиге (шрифт/цвет,
     таблица автозаполнения);
   - `SafeListBinder` — allow-list при вставке из буфера обмена (только
     `List<string>`/`string`/`string[]`, остальное отклоняется).

Подробности и результаты ретестов: [`manual-test-reports/SUMMARY.md`](manual-test-reports/SUMMARY.md).

## Структура репозитория

| Путь                       | Что внутри                                                        |
|----------------------------|-------------------------------------------------------------------|
| `ZTool.exe`, `ZTool.dll`   | основные сборки (рекомендуемые версии — см. таблицу выше)          |
| `ZToolARM.dll`, `*.dll`    | нативная библиотека и сторонние зависимости (NPOI, iTextSharp …)   |
| `ZTool.settings`           | основной конфиг (`CConfigDO`)                                     |
| `help.CHM` / `help_ru.chm` | справка пользователя (оригинал / русский перевод)                 |
| `client-core/`             | C#-код и инструменты клиента ([README](client-core/README.md))    |
| `client-core/tools/BinderInject/` | dnlib-патчер десериализации ([README](client-core/tools/BinderInject/README.md)) |
| `client-rekey/`            | работа с лицензионными ключами ([README](client-rekey/README.md)) |
| `license-server/`          | Python TCP-сервер активации ([README](license-server/README.md))  |
| `tools/chm-i18n/`          | пересборка `help_ru.chm` ([README](tools/chm-i18n/README.md))     |
| `manual-test-reports/`     | отчёты живого тестирования в SolidWorks (PR #8)                   |
| `docs/`                    | планы, аудит документации, указатель                              |
| `dumps/`                   | дампы/восстановленные сборки (диагностика)                        |

## Сборка лицензионного сервера

См. [`license-server/README.md`](license-server/README.md). Кратко:

```bash
cd license-server
python -m venv .venv && . .venv/bin/activate   # Windows: .venv\Scripts\activate
pip install -e .
python -m ztool_license_server
```

## Документация

Все документы на русском. Полный список с описанием и статусом актуальности —
в [`docs/INDEX.md`](docs/INDEX.md).

## Production hardening

Текущий `main` считается рабочей baseline-версией, а подготовка к production
ведётся отдельными фазовыми ветками `hardening/XX-*`. Стартовая дорожная карта:
[`docs/production/PRODUCTION_HARDENING_PLAN_RU.md`](docs/production/PRODUCTION_HARDENING_PLAN_RU.md).

Перед мержем hardening PR обязательны audit gates из
[`docs/production/AUDIT_GATES_RU.md`](docs/production/AUDIT_GATES_RU.md) и
implementation report в `docs/audit/`.
