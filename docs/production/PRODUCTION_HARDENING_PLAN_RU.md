# ZTool — production hardening, refactoring and audit-gated roadmap

Документ является рабочим ТЗ для агента-разработчика. Работы должны идти маленькими PR, каждый PR проходит отдельный аудит. Merge разрешается только после явного статуса `APPROVED FOR MERGE`.

> Условие: все работы выполняются только в рамках легальной миграции/поддержки продукта при наличии прав или разрешения правообладателя. Цель — сделать текущую реализацию лицензирования, локализации и сборки поддерживаемой, проверяемой и пригодной к production.

---

## 1. Общая стратегия

Текущий проект уже доказал работоспособность ключевых сценариев: совместимый TCP-сервер лицензирования, server-side тесты, редактируемое C# licensing core с reinjection в `ZTool.exe`, практическая RU-локализация и manual smoke в SolidWorks. Но production блокируют следующие риски:

1. `apply_register`, `register_confirm`, `apply_remove`, `remove_confirm` недостаточно связаны через серверное состояние.
2. Private key и секреты пока слишком файлово-простые для production.
3. TCP-протокол не имеет полноценной защиты от malformed/oversized frames, partial reads, idle connections и DoS.
4. SQLite используется без migrations, WAL policy, transaction boundary, pending state и нормальной backup/restore процедуры.
5. `device_limit` есть в схеме и CLI, но фактическая логика активации жёстко ведёт себя как `1 code = 1 machine`.
6. Локализация работает как binary patch pipeline, но нет release gate на остаточные Han-строки, whitelist и screenshot checks.
7. Reinjector/build pipeline должен стать fail-closed: expected hashes, strict matching, manifest, reproducibility.
8. Нет полноценного production deployment/runbook/monitoring/CI/CD.

---

## 2. Правила работы агента

### 2.1. Branching

Каждый этап — отдельная ветка и отдельный PR:

```text
phase-00-baseline-docs
phase-01-secrets-logging
phase-02-protocol-hardening
phase-03-db-migrations-policy
phase-04-activation-transfer-state
phase-05-ops-deploy-observability
phase-06-ci-test-quality
phase-07-localization-hardening
phase-08-client-core-reinjector-hardening
phase-09-threat-model-incident-runbooks
phase-10-release-packaging
```

### 2.2. Merge gate

PR нельзя мержить, пока не выполнены все пункты:

```text
[ ] Агент приложил implementation report.
[ ] Агент приложил полный список изменённых файлов.
[ ] Агент приложил команды тестирования и результаты.
[ ] Агент приложил manual verification, если этап затрагивает клиент/SolidWorks.
[ ] Агент описал backward compatibility.
[ ] Агент описал rollback plan.
[ ] Аудитор проверил PR.
[ ] Все замечания P0/P1 закрыты.
[ ] Получено явное разрешение: APPROVED FOR MERGE.
```

### 2.3. Implementation report

В каждом PR агент создаёт:

```text
docs/audit/phase-XX-<short-name>-implementation-report.md
```

Шаблон:

```markdown
# Phase XX — implementation report

## Scope
Что было изменено.

## Changed files
- path/to/file — что и зачем.

## Behavior changes
Что изменилось в поведении.

## Backward compatibility
Что осталось совместимым с текущим клиентом/сервером.

## Tests run
```bash
commands here
```

## Test results
Полный вывод или summary.

## Manual checks
Если применимо: Windows/SolidWorks/client activation/transfer/offline.

## Security notes
Что изменилось по секретам, логам, данным, протоколу.

## Migration notes
Нужны ли DB migrations/config/env changes.

## Rollback plan
Как откатить.

## Known limitations
Что осталось нерешённым.
```

### 2.4. Что запрещено без отдельного согласования

```text
[ ] Менять публичный legacy-протокол клиента без обратной совместимости.
[ ] Менять формат license blob без тестов IsReg1/IsReg2 и real-client проверки.
[ ] Коммитить private_key.txt, keypair_info.json, реальные license DB, дампы памяти, секреты.
[ ] Делать fallback, который фактически отключает проверку лицензии.
[ ] Убирать hardware binding.
[ ] Мержить бинарники без manifest/hashes.
[ ] Включать DEBUG/plaintext logs в production.
```

---

## 3. Общие команды проверки

### 3.1. License server

```bash
cd license-server
python -m pip install -e .[dev]
pytest -q
python -m compileall ztool_license_server tests
```

После добавления quality tools:

```bash
ruff check .
ruff format --check .
bandit -r ztool_license_server
```

### 3.2. Client-core build

На Windows:

```powershell
cd client-core
./build.ps1
```

После build:

```powershell
dotnet run -c Release --project tools/Reinjector -- --verify out/ZTool.exe
dotnet run -c Release --project tools/Localizer -- --scan out/ZTool.exe
```

### 3.3. Manual client checks

Для этапов, затрагивающих client-core, protocol, registry или localization:

```text
[ ] Clean Windows VM / рабочая папка ASCII path.
[ ] Очистка старых ZTool registry keys.
[ ] RegAsm ZTool.dll.
[ ] Запуск SolidWorks user-context, не elevated PowerShell.
[ ] Вкладка ZTool видна.
[ ] Лента русская.
[ ] Иконки есть.
[ ] Кнопки открываются без crash.
[ ] ZTool.exe запускается.
[ ] Trial flow работает.
[ ] Online activation работает.
[ ] Register confirm работает.
[ ] Transfer-out работает через UI.
[ ] Повторная активация после transfer работает.
```

---

# Phase 00 — baseline, repo hygiene, audit framework

## Цель

Зафиксировать текущую baseline-картину проекта и добавить документы/шаблоны для дальнейших PR. Runtime-логику не менять.

## Branch

```text
phase-00-baseline-docs
```

## Tasks

1. Создать структуру:

```text
docs/
  production/
    PRODUCTION_HARDENING_PLAN_RU.md
    RELEASE_BASELINE_RU.md
    RISK_REGISTER_RU.md
    AUDIT_GATES_RU.md
    OPERATIONS_TODO_RU.md
  audit/
    README.md
.github/
  PULL_REQUEST_TEMPLATE.md
```

2. В `RELEASE_BASELINE_RU.md` зафиксировать:

```text
- default branch;
- release branch/candidate branch;
- commit SHA;
- hash ZTool.exe;
- hash ZTool-base.exe;
- hash ZTool.dll;
- hash SolidWorksTools.dll;
- hash translation table;
- license-server test result;
- manual SolidWorks test result;
- known limitations.
```

3. В `RISK_REGISTER_RU.md` создать таблицу:

```text
ID | Risk | Severity | Area | Status | Mitigation | Owner | Target phase
```

Стартовые риски:

```text
R-001 register_confirm без строгой pending-state связи
R-002 remove_confirm принимает confirm без pending transfer
R-003 private key хранится файлово и может попасть в артефакты
R-004 DEBUG/plaintext logging раскрывает регистрационные данные
R-005 FrameParser допускает oversized/malformed frame abuse
R-006 SQLite без migrations/transactions/backup policy
R-007 device_limit не соответствует фактической логике
R-008 Localizer не имеет финального Han whitelist gate
R-009 Reinjector допускает fuzzy matching без baseline hash gate
R-010 Нет production runbook/monitoring/alerting
```

4. В `.gitignore` запретить:

```text
license-server/keys/private_key.txt
license-server/keys/keypair_info.json
license-server/*.db
license-server/*.db-*
*.dmp
*.dmp.part*
*.lic
*.log
.env
.env.*
```

5. PR template должен требовать:

```text
- phase number;
- scope;
- changed files;
- tests;
- security impact;
- migration impact;
- manual checks;
- rollback;
- audit checklist.
```

## Tests

```bash
git status --short
```

Runtime тесты не обязательны, потому что runtime-код не меняется.

## Acceptance criteria

```text
[ ] Добавлены документы baseline/audit/risk/operations.
[ ] Добавлен PR template.
[ ] Добавлен/обновлён .gitignore для секретов и runtime-файлов.
[ ] Нет изменений runtime-кода.
[ ] Есть implementation report.
```

## Audit checklist

```text
[ ] Документы не содержат секретов.
[ ] План по этапам совпадает с production roadmap.
[ ] Merge gate явно требует audit approval.
[ ] .gitignore закрывает private key, DB, dumps, env, logs.
[ ] PR template не позволяет мержить без тестов и rollback.
```

---

# Phase 01 — secrets, private key handling, logging hardening

## Цель

Исключить утечки private key, plaintext request body, registration code, machine code и password из production-логов и артефактов.

## Branch

```text
phase-01-secrets-logging
```

## Tasks

### 01.1. Key provider abstraction

Создать:

```text
license-server/ztool_license_server/secrets.py
```

Интерфейс:

```python
class KeyProvider:
    def load_public_key(self) -> str: ...
    def load_private_key(self) -> str: ...
```

Реализации:

```text
FileKeyProvider — dev/staging only
EnvKeyProvider — private key из env/secret manager bridge
```

`server.py` не должен напрямую читать `private_key.txt`.

### 01.2. Permission check

Для `FileKeyProvider`:

```text
[ ] На Unix проверять mode private_key.txt.
[ ] Если файл group/world-readable — warning в dev, error в production.
[ ] Production определяется env `ZTOOL_ENV=production`.
```

### 01.3. Убрать keypair_info.json из production path

В `keygen.py`:

```text
[ ] По умолчанию не писать keypair_info.json.
[ ] Добавить флаг `--write-backup-info` только для offline/dev.
[ ] README: private key нельзя хранить в repo или release artifact.
```

### 01.4. Sanitized logging

Добавить:

```text
license-server/ztool_license_server/logging_utils.py
```

Функции:

```python
def hash_for_log(value: str) -> str: ...
def redact(value: str, keep: int = 4) -> str: ...
def request_id() -> str: ...
```

Запрещено логировать:

```text
- plaintext body;
- registration code полностью;
- password;
- raw machine code;
- private/public key values;
- license blob body.
```

Разрешено логировать:

```text
- request_id;
- sendtype;
- result;
- code_hash;
- machine_hash;
- remote_addr;
- latency_ms.
```

### 01.5. Production log level

```text
[ ] `ZTOOL_LOG_LEVEL=DEBUG` запрещён при `ZTOOL_ENV=production`.
[ ] При попытке запуска в production с DEBUG сервер должен падать fail-fast.
```

## Tests

Добавить:

```text
license-server/tests/test_secrets.py
license-server/tests/test_logging_redaction.py
```

Проверки:

```text
[ ] private key читается через KeyProvider.
[ ] keypair_info.json не создаётся по умолчанию.
[ ] DEBUG в production запрещён.
[ ] plaintext body/code/password/machine_code не попадают в caplog.
```

## Acceptance criteria

```text
[ ] server.py не читает private_key.txt напрямую.
[ ] Production DEBUG fail-fast.
[ ] Plaintext request body нигде не логируется.
[ ] Tests pass.
[ ] README обновлён.
```

## Audit checklist

```text
[ ] Нет секретов в diff.
[ ] Нет логирования decrypted body.
[ ] Private key path совместим с текущей dev-сборкой.
[ ] Backward compatibility с legacy-клиентом не нарушена.
```

---

# Phase 02 — TCP protocol hardening

## Цель

Сделать TCP transport устойчивым к malformed frames, partial reads, oversized body, idle connections и неизвестным sendtype.

## Branch

```text
phase-02-protocol-hardening
```

## Tasks

### 02.1. Protocol limits

В `config.py` добавить:

```python
max_body_size: int = 2 * 1024 * 1024
read_timeout_seconds: float = 10.0
idle_timeout_seconds: float = 30.0
max_frames_per_connection: int = 20
```

Env:

```text
ZTOOL_MAX_BODY_SIZE
ZTOOL_READ_TIMEOUT_SECONDS
ZTOOL_IDLE_TIMEOUT_SECONDS
ZTOOL_MAX_FRAMES_PER_CONNECTION
```

### 02.2. FrameParser validation

В `protocol/framing.py`:

```text
[ ] body_len < 0 => ProtocolError
[ ] body_len > max_body_size => ProtocolError
[ ] buffer > max_body_size + header => ProtocolError
[ ] sendtype/result int parsing без assert для runtime path
[ ] corrupted int field => ProtocolError
```

Добавить исключение:

```python
class ProtocolError(Exception): ...
```

### 02.3. Server connection handling

В `server.py`:

```text
[ ] reader.read обернуть в wait_for.
[ ] close connection on timeout.
[ ] close connection on ProtocolError.
[ ] max frames per connection.
[ ] unknown sendtype логировать sanitized и возвращать REGISTER_FAILED или закрывать соединение.
```

### 02.4. Client getreceive hardening

В `client-core/src/TCPClient.cs`:

```text
[ ] Реализовать ReadExact(Socket, byte[], offset, count).
[ ] Header читать строго 10+10 байт.
[ ] Проверять length >= 0.
[ ] Проверять length <= MaxReceiveBodyLength.
[ ] Тело читать строго length байт.
[ ] На ошибку показывать корректное сообщение связи.
```

Ограничение: не менять wire format.

## Tests

Добавить/расширить:

```text
license-server/tests/test_protocol_hardening.py
license-server/tests/test_integration_protocol_limits.py
```

Покрыть:

```text
[ ] fragmented header.
[ ] fragmented body.
[ ] multiple frames.
[ ] negative length.
[ ] huge length.
[ ] unknown sendtype.
[ ] idle timeout.
[ ] max frames per connection.
```

Для client-core минимум build + manual smoke.

## Acceptance criteria

```text
[ ] Wire compatibility сохранена.
[ ] Oversized/malformed frame не держит соединение бесконечно.
[ ] Partial reads корректно работают.
[ ] Tests pass.
[ ] Manual activation smoke PASS, если менялся клиент.
```

## Audit checklist

```text
[ ] Нет изменения формата `[type:10][len:10][body]`.
[ ] Limits конфигурируются env.
[ ] Ошибки не раскрывают sensitive data.
[ ] Нет regression в integration tests.
```

---

# Phase 03 — DB migrations, transactions, device_limit, password policy

## Цель

Привести БД к управляемому состоянию: versioned migrations, транзакции, корректный `device_limit`, password hashing, WAL/backup readiness.

## Branch

```text
phase-03-db-migrations-policy
```

## Tasks

### 03.1. DB migrations

Создать:

```text
license-server/ztool_license_server/migrations/
  __init__.py
  runner.py
  0001_initial.py
  0002_pending_state.py
```

Добавить таблицу:

```sql
schema_migrations(version TEXT PRIMARY KEY, applied_at TEXT NOT NULL)
```

`LicenseDB.__init__()` должен применять миграции идемпотентно.

### 03.2. WAL and busy timeout

При SQLite подключении:

```sql
PRAGMA journal_mode=WAL;
PRAGMA busy_timeout=5000;
PRAGMA foreign_keys=ON;
```

### 03.3. Transaction boundary

Добавить context manager:

```python
with db.transaction():
    validate_code
    check_password
    activate
    log_action
```

Не должно быть частичных состояний: activation без audit или audit без activation.

### 03.4. device_limit consistency

Выбрать и реализовать одну политику:

#### Вариант A — 1 code = 1 machine

```text
[ ] Удалить/задепрекейтить --limit из CLI.
[ ] README явно говорит: один код — одна машина, перенос через transfer.
[ ] DB column device_limit можно оставить только для будущего, но не показывать оператору.
```

#### Вариант B — N devices per code

```text
[ ] activate() использует get_device_limit(code).
[ ] same machine idempotent.
[ ] active count < limit разрешает новую машину.
[ ] active count >= limit возвращает DEVICE_LIMIT.
[ ] tests на limit=1/2/5.
```

Рекомендуемый production-вариант: если бизнес действительно продаёт один ключ на одну машину — выбрать A, чтобы не вводить оператора в заблуждение.

### 03.5. Password hashing

Если password feature остаётся:

```text
[ ] Добавить password_hash/password_algo/password_updated_at.
[ ] Хранить PBKDF2-HMAC-SHA256 или argon2id.
[ ] Plain password не хранить.
[ ] Миграция старых password: при первом успешном check перевести в hash или отдельная admin migration.
```

Если feature не нужна:

```text
[ ] Удалить password из CLI/UI path или задокументировать как deprecated.
```

## Tests

Добавить:

```text
license-server/tests/test_migrations.py
license-server/tests/test_transactions.py
license-server/tests/test_device_limit_policy.py
license-server/tests/test_password_hashing.py
```

## Acceptance criteria

```text
[ ] Новая БД создаётся миграциями.
[ ] Старая БД мигрируется без потери данных.
[ ] device_limit поведение соответствует документации.
[ ] Password не хранится открытым текстом, если feature включена.
[ ] Tests pass.
```

## Audit checklist

```text
[ ] Нет destructive migration без backup notes.
[ ] Есть rollback или downgrade instruction.
[ ] Активация и audit атомарны.
[ ] CLI больше не обещает неработающий limit.
```

---

# Phase 04 — stateful activation / register_confirm / transfer_confirm

## Цель

Связать все шаги лицензирования через серверное состояние: pending activation, pending transfer, TTL, hash/nonce, code, machine_code.

## Branch

```text
phase-04-activation-transfer-state
```

## Tasks

### 04.1. Pending activation schema

Добавить таблицу:

```sql
pending_activations (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  code TEXT NOT NULL,
  machine_code TEXT NOT NULL,
  request_nonce TEXT NOT NULL,
  apply_blob_hash TEXT NOT NULL,
  client_ip TEXT,
  created_at TEXT NOT NULL,
  expires_at TEXT NOT NULL,
  confirmed_at TEXT,
  status TEXT NOT NULL
)
```

### 04.2. Pending transfer schema

```sql
pending_transfers (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  code TEXT NOT NULL,
  machine_code TEXT NOT NULL,
  request_nonce TEXT NOT NULL,
  created_at TEXT NOT NULL,
  expires_at TEXT NOT NULL,
  confirmed_at TEXT,
  status TEXT NOT NULL
)
```

### 04.3. Apply register creates pending state

`_handle_apply_register` должен:

```text
[ ] validate code/password/machine.
[ ] activate or ensure idempotent binding.
[ ] generate blob.
[ ] save pending activation with blob hash and TTL.
[ ] return APPLY_OK + blob.
```

TTL default:

```text
ZTOOL_PENDING_ACTIVATION_TTL_SECONDS=300
```

### 04.4. Register confirm validates pending state

`_handle_register_confirm` должен:

```text
[ ] parse branches.
[ ] recover machine_hash/uuid from branches.
[ ] map machine_hash to pending activation for same code/machine where possible.
[ ] require active non-expired pending activation.
[ ] mark confirmed.
[ ] log success with request_id.
[ ] reject orphan confirm.
```

Если legacy confirm не содержит code, допустим fallback mapping по `machine_hash + recent unconfirmed pending`, но это должно быть явно ограничено TTL и уникальностью.

### 04.5. Apply remove creates pending transfer

`_handle_apply_remove` должен:

```text
[ ] validate code/password/machine.
[ ] verify active binding.
[ ] mark binding transfer_pending или deactivate только после confirm — выбрать политику.
[ ] create pending transfer.
[ ] return TRANSFER_OUT_OK.
```

Рекомендуемая политика: не освобождать seat до `remove_confirm`, чтобы orphan remove не терял лицензию. Если legacy-клиент требует иначе, задокументировать.

### 04.6. Remove confirm validates pending transfer

`_handle_remove_confirm` должен:

```text
[ ] require active pending transfer.
[ ] complete deactivation.
[ ] mark transfer confirmed.
[ ] reject orphan confirm.
```

### 04.7. Cleanup

Добавить CLI:

```bash
python -m ztool_license_server.cli cleanup-pending
```

Он закрывает expired pending states.

## Tests

Добавить:

```text
license-server/tests/test_activation_state.py
license-server/tests/test_transfer_state.py
license-server/tests/test_pending_cleanup.py
```

Проверить:

```text
[ ] valid apply -> pending -> confirm -> confirmed.
[ ] orphan confirm rejected.
[ ] expired confirm rejected.
[ ] duplicate confirm idempotent or rejected consistently.
[ ] transfer without pending rejected.
[ ] transfer confirm frees seat only under выбранной политикой.
[ ] concurrent apply same code/machine.
[ ] concurrent apply different machine.
```

## Acceptance criteria

```text
[ ] register_confirm больше не является stateless echo.
[ ] remove_confirm больше не подтверждает всё подряд.
[ ] Все pending states имеют TTL.
[ ] Tests pass.
[ ] Real-client activation/transfer smoke PASS.
```

## Audit checklist

```text
[ ] Нет ломки legacy client flow.
[ ] Orphan confirm невозможен.
[ ] Transfer не теряет seat при сетевом сбое.
[ ] Audit log отражает apply/pending/confirm.
```

---

# Phase 05 — production deployment, observability, backup, runbook

## Цель

Сделать сервер разворачиваемым и сопровождаемым в production.

## Branch

```text
phase-05-ops-deploy-observability
```

## Tasks

Создать:

```text
deploy/
  systemd/ztool-license-server.service
  systemd/ztool-license-server.env.example
  docker/Dockerfile
  docker/docker-compose.yml
  backup/backup_sqlite.sh
  backup/restore_sqlite.md
  monitoring/METRICS_RU.md
  runbooks/PRODUCTION_RUNBOOK_RU.md
  runbooks/ROLLBACK_RU.md
```

### 05.1. systemd

Service должен:

```text
[ ] запускаться от отдельного пользователя ztool-license;
[ ] иметь WorkingDirectory=/opt/ztool-license-server;
[ ] читать env file;
[ ] Restart=on-failure;
[ ] NoNewPrivileges=true;
[ ] PrivateTmp=true;
[ ] ProtectSystem=strict где возможно;
[ ] ReadWritePaths только для DB/log dirs.
```

### 05.2. Healthcheck

Добавить CLI:

```bash
python -m ztool_license_server.cli healthcheck
```

Проверяет:

```text
[ ] DB доступна.
[ ] migrations applied.
[ ] keys loadable.
[ ] config valid.
```

### 05.3. Metrics

Минимум structured log metrics или `/metrics` отдельным HTTP endpoint, если допустимо.

Метрики:

```text
activation_apply_total{result}
activation_confirm_total{result}
transfer_apply_total{result}
transfer_confirm_total{result}
invalid_machine_total
invalid_code_total
wrong_password_total
protocol_error_total
request_latency_ms
active_licenses
pending_activations
pending_transfers
```

### 05.4. Backup/restore

Для SQLite:

```text
[ ] backup через sqlite backup API или `.backup`, не простое копирование live DB.
[ ] retention policy.
[ ] restore drill инструкция.
[ ] backup encryption если есть PII/секреты.
```

## Tests

```bash
python -m ztool_license_server.cli healthcheck
python -m ztool_license_server.cli backup --out /tmp/test.db
```

## Acceptance criteria

```text
[ ] Есть systemd unit и env example.
[ ] Есть runbook запуска/остановки/логов/rollback.
[ ] Есть backup/restore инструкция.
[ ] Есть healthcheck.
[ ] Нет секретов в env.example.
```

## Audit checklist

```text
[ ] systemd hardening не ломает доступ к DB/keys.
[ ] Backup procedure безопасна для live DB.
[ ] Runbook понятен оператору без устных инструкций.
```

---

# Phase 06 — CI/CD, test quality, security scan

## Цель

Сделать проверку PR автоматической и повторяемой.

## Branch

```text
phase-06-ci-test-quality
```

## Tasks

Создать:

```text
.github/workflows/license-server-ci.yml
.github/workflows/client-core-ci.yml
.github/workflows/security-scan.yml
```

### 06.1. Python CI

```yaml
- checkout
- setup-python 3.10/3.11/3.12
- pip install -e license-server[dev]
- pytest -q
- ruff check
- python -m compileall
```

### 06.2. Client-core CI

Если GitHub Windows runner доступен:

```yaml
runs-on: windows-latest
steps:
  - checkout
  - setup-dotnet
  - cd client-core
  - ./build.ps1
  - dotnet run -c Release --project tools/Reinjector -- --verify out/ZTool.exe
```

Если бинарные артефакты слишком тяжёлые или runner не подходит — документировать manual CI limitation.

### 06.3. Security scan

```text
[ ] secret scanning через gitleaks/trufflehog.
[ ] bandit для Python.
[ ] dependency review.
```

### 06.4. Coverage gates

Не требовать высокий процент формально, но добавить минимальные regression gates:

```text
[ ] protocol tests
[ ] crypto compatibility tests
[ ] license blob tests
[ ] integration flow tests
[ ] pending state tests
[ ] localization scan tests
```

## Acceptance criteria

```text
[ ] CI запускается на PR.
[ ] Python tests mandatory.
[ ] Security scan не падает на false positives без documented suppression.
[ ] Client build либо автоматизирован, либо явно вынесен в manual gate.
```

---

# Phase 07 — localization hardening

## Цель

Превратить RU-локализацию из разового binary patch в управляемый release gate.

## Branch

```text
phase-07-localization-hardening
```

## Tasks

Создать:

```text
localization/
  README_RU.md
  glossary_zh_ru.tsv
  whitelist_protocol_keys.txt
  whitelist_fonts.txt
  whitelist_technical.txt
  scan_expected_remaining_han.txt
```

### 07.1. Localizer scan gate

`Localizer --scan` должен возвращать machine-readable report:

```json
{
  "han_total": 0,
  "translated": 0,
  "whitelisted": 0,
  "unknown": []
}
```

Build должен падать, если есть unknown Han строки.

### 07.2. TSV validation

Добавить tool/test:

```text
[ ] дубликаты zh запрещены;
[ ] пустой RU допускается только с явным комментарием;
[ ] protocol keys не должны присутствовать в translation map;
[ ] font names не должны переводиться;
[ ] строки с управляющими символами корректно escaped/unescaped.
```

### 07.3. Screenshot checklist

Создать:

```text
docs/localization/RU_SCREENSHOT_CHECKLIST.md
```

Окна:

```text
[ ] License dialog.
[ ] Options.
[ ] Ribbon.
[ ] File menu.
[ ] About.
[ ] Update disabled/redirected path.
[ ] BOM export.
[ ] Save options.
[ ] SolidWorks add-in tab.
```

### 07.4. BOM template determinism

`build_ru_bom_template.py`:

```text
[ ] не брать первый glob-match;
[ ] принимать explicit source path;
[ ] проверять expected shared string count;
[ ] генерировать hash report.
```

## Tests

```bash
python build_ru_bom_template.py --check
```

На Windows:

```powershell
dotnet run -c Release --project client-core/tools/Localizer -- --scan client-core/out/ZTool.exe
```

## Acceptance criteria

```text
[ ] Unknown Han строк нет или все явно whitelisted.
[ ] Protocol keys не переведены.
[ ] BOM template deterministic.
[ ] Screenshot checklist заполнен для release candidate.
```

---

# Phase 08 — client-core, Reinjector, build reproducibility

## Цель

Сделать binary build/reinject pipeline безопасным, воспроизводимым и fail-closed.

## Branch

```text
phase-08-client-core-reinjector-hardening
```

## Tasks

### 08.1. Build manifest

После `build.ps1` генерировать:

```text
client-core/out/build-manifest.json
```

Поля:

```json
{
  "base_exe_sha256": "...",
  "output_exe_sha256": "...",
  "ztool_public_ref_sha256": "...",
  "ztool_rsa_ref_sha256": "...",
  "translation_table_sha256": "...",
  "replaced_methods": [],
  "tool_versions": {},
  "build_time_utc": "...",
  "git_commit": "..."
}
```

### 08.2. Expected baseline hashes

Создать:

```text
client-core/build-baseline.json
```

Содержит expected hashes входных бинарников. Если hash не совпадает — build падает, если не передан явный `-AllowNewBaseline`.

### 08.3. Reinjector strict mode

Reinjector должен:

```text
[ ] matching по exact full type + method signature;
[ ] проверять expected original IL hash;
[ ] не использовать fuzzy fallback silently;
[ ] выводить полный replaced method report;
[ ] fail если метод не найден или найден неоднозначно.
```

### 08.4. Preserve public key token rationale

Оставить документ:

```text
docs/production/CLIENT_STRONG_NAME_AND_TOKEN_RATIONALE_RU.md
```

Описать, почему public key token нельзя сбрасывать и как это связано с IPC/SolidWorks add-in.

### 08.5. Release artifact layout

Определить:

```text
release/
  ZTool.exe
  ZTool.dll
  ZToolARM.dll
  SolidWorksTools.dll
  ZTool.settings
  templates/
  checksums.txt
  build-manifest.json
  RELEASE_NOTES_RU.md
```

## Tests

```powershell
cd client-core
./build.ps1
Test-Path out/build-manifest.json
dotnet run -c Release --project tools/Reinjector -- --verify out/ZTool.exe
```

Manual SolidWorks smoke обязателен.

## Acceptance criteria

```text
[ ] Build падает при неожиданном base exe hash.
[ ] Reinjector не делает ambiguous method replacement.
[ ] build-manifest создаётся.
[ ] Manual SolidWorks smoke PASS.
```

---

# Phase 09 — threat model and incident runbooks

## Цель

Зафиксировать security model и подготовить реакции на инциденты.

## Branch

```text
phase-09-threat-model-incident-runbooks
```

## Tasks

Создать:

```text
docs/security/THREAT_MODEL_RU.md
docs/security/INCIDENT_RESPONSE_RU.md
docs/security/KEY_ROTATION_RU.md
docs/security/ABUSE_AND_RATE_LIMIT_RU.md
```

Threat model должен покрыть:

```text
[ ] private key compromise;
[ ] license DB compromise;
[ ] replay old server response;
[ ] fake client flood;
[ ] brute force registration code;
[ ] malicious machine_code payload;
[ ] log leakage;
[ ] stolen activated registry blob;
[ ] update channel replacing patched client;
[ ] admin/operator mistake.
```

Incident runbooks:

```text
[ ] private key leaked;
[ ] DB corrupted;
[ ] license codes abused;
[ ] production server down;
[ ] accidental DEBUG logs with sensitive data;
[ ] bad release artifact shipped;
 [ ] client cannot activate after release.
```

## Acceptance criteria

```text
[ ] Threat model reviewed.
[ ] Key rotation plan exists.
[ ] Incident response has concrete commands/checklists.
[ ] No secrets in docs.
```

---

# Phase 10 — final release packaging and production readiness gate

## Цель

Собрать production release candidate и провести финальный go/no-go аудит.

## Branch

```text
phase-10-release-packaging
```

## Tasks

### 10.1. Release manifest

Создать финальный:

```text
release/RELEASE_MANIFEST.json
```

Поля:

```json
{
  "release_version": "1.0.0-prod-rc1",
  "git_commit": "...",
  "server_commit": "...",
  "client_build_manifest": "...",
  "artifacts": [
    {"path": "ZTool.exe", "sha256": "..."},
    {"path": "ZTool.dll", "sha256": "..."}
  ],
  "tests": {
    "license_server_pytest": "...",
    "client_build": "...",
    "solidworks_manual": "...",
    "activation_live": "...",
    "transfer_live": "..."
  },
  "known_limitations": []
}
```

### 10.2. Final production checklist

Создать:

```text
docs/production/GO_NO_GO_CHECKLIST_RU.md
```

Checklist:

```text
[ ] Все Phase 00–09 merged.
[ ] CI зелёный.
[ ] No secrets in repo.
[ ] Private key хранится вне repo/release.
[ ] Production DEBUG запрещён.
[ ] TCP limits включены.
[ ] Pending activation/transfer включены.
[ ] DB migrations applied.
[ ] Backup/restore drill выполнен.
[ ] Monitoring configured.
[ ] SolidWorks smoke PASS.
[ ] Online activation PASS.
[ ] Transfer PASS.
[ ] Offline activation PASS, если поставляется.
[ ] Rollback artifact exists.
[ ] Release manifest hashes verified.
```

### 10.3. Final audit request

PR должен содержать:

```text
[ ] release artifacts list;
[ ] test results;
[ ] manual screenshots/reports;
[ ] server deployment notes;
[ ] rollback notes;
[ ] known limitations.
```

## Final audit statuses

Аудитор выдаёт один из статусов:

```text
GO FOR PRODUCTION
GO FOR LIMITED PILOT ONLY
NO-GO — BLOCKERS FOUND
```

---

## 4. Приоритеты исправлений

### P0 — блокеры production

```text
[ ] Secrets/private key hardening.
[ ] Plaintext logging removal.
[ ] TCP limits/timeouts.
[ ] Stateful register_confirm/remove_confirm.
[ ] DB migrations and transaction boundaries.
[ ] device_limit policy fixed.
[ ] Production deployment/runbook/backup.
[ ] Release manifest and hashes.
```

### P1 — обязательные до широкого rollout

```text
[ ] CI/CD.
[ ] Security scanning.
[ ] Localization scan gate.
[ ] Reinjector strict matching.
[ ] Client ReadExact.
[ ] Manual SolidWorks matrix.
```

### P2 — улучшения поддерживаемости

```text
[ ] Admin API/RBAC.
[ ] PostgreSQL/MySQL migration.
[ ] Metrics endpoint.
[ ] Screenshot automation.
[ ] More source recovery from binary.
[ ] Full release packaging automation.
```

---

## 5. Правило аудита после каждого PR

После того как агент создаёт PR, аудитор проверяет:

```text
1. Соответствие scope этапа.
2. Отсутствие неожиданных runtime changes.
3. Совместимость с legacy client protocol.
4. Безопасность секретов и логов.
5. Наличие тестов.
6. Наличие rollback plan.
7. Наличие implementation report.
8. Отсутствие production blockers.
```

Результат аудита публикуется как PR review:

```text
APPROVED FOR MERGE
```

или:

```text
CHANGES REQUESTED

P0:
- ...

P1:
- ...

P2:
- ...
```

Merge выполняется только после закрытия всех P0/P1.