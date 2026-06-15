# ZTool — production hardening, refactoring and audit-gated roadmap

Документ предназначен для передачи агенту-разработчику как пошаговое ТЗ.  
Работы должны идти отдельными PR/ветками. После каждого этапа PR отдаётся на аудит; merge разрешается только после явного audit approval.

> Важное условие: работы допустимы только в рамках легальной миграции/поддержки продукта при наличии прав или разрешения правообладателя. Цель плана — сделать текущую реализацию лицензирования, локализации и сборки поддерживаемой, проверяемой и пригодной к production, а не обходить защиту стороннего продукта.

---

## 0. Общая стратегия

Текущий проект уже доказал работоспособность ключевых сценариев: есть TCP-сервер лицензирования, совместимый legacy-протокол, тесты server-side, pipeline для редактируемого C# licensing core и reinjection в `ZTool.exe`, а также практическая RU-локализация. Но production-готовность блокируют следующие классы рисков:

1. Недостаточная серверная state model: `apply_register`, `register_confirm`, `apply_remove`, `remove_confirm` должны быть связаны через pending state, TTL, hash/nonce и конкретную лицензию.
2. Секреты и RSA private key пока слишком файлово-простые для production.
3. Протокол TCP не имеет достаточной защиты от malformed/oversized frames, partial reads, timeout abuse и DoS.
4. БД SQLite используется без полноценной migration/state/transaction модели.
5. Есть расхождение между `device_limit` в схеме/CLI и фактической политикой `1 code = 1 machine`.
6. Локализация работает как binary patch pipeline, но нет release gate на остаточные Han-строки, whitelist и screenshot checks.
7. Reinjector/build pipeline нужно сделать fail-closed: hashes, strict matching, manifest, reproducibility.
8. Нет полноценного production deployment/runbook/backup/monitoring/CI/CD.

Все работы делятся на этапы. Каждый этап должен быть небольшим, reviewable и mergeable отдельно.

---

## 1. Правила работы агента

### 1.1. Branching

Агент создаёт отдельную ветку на каждый этап:

```text
hardening/00-baseline-docs
hardening/01-secrets-logging
hardening/02-protocol-hardening
hardening/03-db-state-model
hardening/04-activation-transfer-state
hardening/05-ops-deploy-observability
hardening/06-ci-test-quality
hardening/07-localization-hardening
hardening/08-client-core-reinjector-hardening
hardening/09-security-threat-model
hardening/10-release-packaging
```

Каждая ветка — отдельный PR.

### 1.2. Правило merge gate

PR нельзя мержить, пока не выполнены все пункты:

```text
[ ] Агент приложил implementation report.
[ ] Агент приложил список изменённых файлов.
[ ] Агент приложил команды тестирования и полный результат.
[ ] Агент приложил manual verification, если этап затрагивает клиент/SolidWorks.
[ ] Агент описал rollback.
[ ] Я провёл аудит PR.
[ ] Все замечания P0/P1 закрыты.
[ ] Получено явное разрешение: APPROVED FOR MERGE.
```

### 1.3. Формат отчёта агента в каждом PR

В каждом PR агент создаёт файл:

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

### 1.4. Что запрещено без отдельного согласования

```text
[ ] Менять публичный протокол клиента без обратной совместимости.
[ ] Менять формат license blob без тестов IsReg1/IsReg2.
[ ] Коммитить private_key.txt, keypair_info.json, реальные license DB, дампы памяти, секреты.
[ ] Делать silent fallback, который фактически отключает проверку лицензии.
[ ] Убирать hardware binding.
[ ] Мержить бинарники без manifest/hashes.
[ ] Включать DEBUG/plaintext logs в production.
```

---

## 2. Общие команды проверки

Агент должен поддерживать эти команды. Если команда пока не работает, этап должен либо исправить это, либо явно документировать причину.

### 2.1. Server tests

```bash
cd license-server
python -m pip install -e .[dev]
pytest -q
```

После добавления lint/security:

```bash
ruff check .
python -m compileall ztool_license_server tests
bandit -r ztool_license_server
```

### 2.2. Client-core build

На Windows:

```powershell
cd client-core
./build.ps1
```

Проверки после build:

```powershell
dotnet run -c Release --project tools/Reinjector -- --verify out/ZTool.exe
dotnet run -c Release --project tools/Localizer -- --scan out/ZTool.exe
```

### 2.3. Manual client checks

Для этапов, затрагивающих client-core, license protocol, registry или localization:

```text
[ ] Clean Windows VM / рабочая папка ASCII path.
[ ] Очистка старых ZTool registry keys.
[ ] RegAsm ZTool.dll.
[ ] Запуск SolidWorks user-context, не elevated PowerShell.
[ ] Вкладка ZTool видна.
[ ] Лента русская.
[ ] Кнопки открываются без crash.
[ ] ZTool.exe запускается.
[ ] Trial flow работает.
[ ] Online activation работает.
[ ] Register confirm работает.
[ ] Transfer-out работает через реальный UI, а не только raw TCP emulator.
[ ] Повторная активация после transfer работает.
```

---

# Phase 00 — baseline, repo hygiene, audit framework

## Цель

Зафиксировать текущую baseline-картину проекта и добавить документы/шаблоны, по которым дальше будут приниматься PR. Runtime-логику не менять.

## Branch

```text
hardening/00-baseline-docs
```

## Tasks

### 00.1. Добавить production docs layout

Создать:

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

`PRODUCTION_HARDENING_PLAN_RU.md` — этот документ.

`RELEASE_BASELINE_RU.md` должен содержать:

```text
- Git branch / commit.
- Hashes текущих runtime binaries: ZTool.exe, ZTool-base.exe, ZTool.dll, ZToolARM.dll, SolidWorksTools.dll, если есть.
- Server package version/hash.
- Python version.
- .NET SDK version.
- Текущий статус тестов.
- Текущий статус manual SolidWorks test.
- Текущие known blockers.
```

`RISK_REGISTER_RU.md` должен быть таблицей:

```text
ID | Risk | Severity | Area | Current mitigation | Target mitigation | Owner | Status
```

Начальные риски:

```text
R-001 register_confirm не связан с apply state.
R-002 remove_confirm не связан с pending transfer.
R-003 plaintext DEBUG logging.
R-004 private key file handling.
R-005 SQLite без migrations/transactions/WAL.
R-006 TCP frame parser без max body/negative length/timeouts.
R-007 device_limit mismatch.
R-008 binary patch/reinjection хрупкость.
R-009 localization не имеет full coverage gate.
R-010 no production deployment/runbook/backup/monitoring.
```

### 00.2. Добавить `.gitignore`

Если `.gitignore` отсутствует, добавить:

```gitignore
# Python
__pycache__/
*.py[cod]
.pytest_cache/
.mypy_cache/
.ruff_cache/
.coverage
htmlcov/
.venv/
venv/

# license server runtime data
license-server/*.db
license-server/*.db-*
license-server/licenses.db
license-server/keys/private_key.txt
license-server/keys/public_key.txt
license-server/keys/keypair_info.json
license-server/keys/*.pem
license-server/keys/*.key

# logs
*.log
logs/

# .NET
bin/
obj/
client-core/out/

# Windows artifacts
Thumbs.db
*.user
*.suo

# secrets/env
.env
.env.*
!.env.example

# dumps
*.dmp
*.dump
*.dmp.part*
```

Важно: если какие-то бинарники уже intentionally committed, не удалять их в этой фазе без отдельного решения.

### 00.3. Добавить PR template

`.github/PULL_REQUEST_TEMPLATE.md`:

```markdown
## Phase
- [ ] 00 baseline
- [ ] 01 secrets/logging
- [ ] 02 protocol
- [ ] 03 DB/state
- [ ] 04 activation/transfer
- [ ] 05 ops/deploy
- [ ] 06 CI/tests
- [ ] 07 localization
- [ ] 08 client/reinjector
- [ ] 09 security
- [ ] 10 release

## Summary

## Changed files

## Tests run

## Results

## Migration / config changes

## Rollback

## Audit checklist
- [ ] No secrets committed
- [ ] No DEBUG/plaintext logs
- [ ] Backward compatibility considered
- [ ] Tests added/updated
- [ ] Docs updated
```

### 00.4. Зафиксировать текущие known facts

В `RELEASE_BASELINE_RU.md` не придумывать факты. Если хеш/версия неизвестны, писать `TBD` и команду, которой это получить.

Пример команд:

```powershell
Get-FileHash .\ZTool.exe -Algorithm SHA256
Get-FileHash .\ZTool.dll -Algorithm SHA256
(Get-Item .\ZTool.exe).VersionInfo
```

```bash
git rev-parse HEAD
python --version
cd license-server && pytest -q
```

## Acceptance criteria

```text
[ ] Добавлены docs/production/*.
[ ] Добавлен docs/audit/README.md.
[ ] Добавлен .github/PULL_REQUEST_TEMPLATE.md.
[ ] Добавлен или обновлён .gitignore.
[ ] Нет runtime code changes.
[ ] Нет новых бинарников, секретов, DB/dumps.
[ ] license-server pytest либо PASS, либо documented current failure без изменения логики.
```

## Audit checklist

Я проверяю:

```text
[ ] PR действительно documentation/hygiene only.
[ ] В .gitignore закрыты private key, DB, dumps, env.
[ ] Risk register содержит P0 risks.
[ ] PR template требует tests/rollback/security notes.
[ ] Ничего чувствительного не попало в diff.
```

## Merge gate

Merge разрешается после audit approval. Это foundation-PR; без него не начинать следующие этапы.

---

# Phase 01 — secrets, key management and logging hardening

## Цель

Исключить утечки чувствительных данных и подготовить production-safe работу с ключами.

## Branch

```text
hardening/01-secrets-logging
```

## Runtime compatibility

Legacy protocol и license blob не менять. Клиент не должен заметить изменений.

## Tasks

### 01.1. Ввести KeyProvider abstraction

Создать модуль:

```text
license-server/ztool_license_server/security/key_provider.py
```

Интерфейс:

```python
class KeyProvider:
    def load_private_key(self) -> str: ...
    def load_public_key(self) -> str: ...
```

Реализации:

```text
FileKeyProvider
EnvKeyProvider optional
```

`FileKeyProvider` должен:

```text
[ ] читать пути из ZTOOL_PRIVATE_KEY_FILE / ZTOOL_PUBLIC_KEY_FILE или legacy ZTOOL_KEYS_DIR;
[ ] проверять, что private key file существует;
[ ] в production проверять права файла: не world-readable, желательно 0600;
[ ] не логировать содержимое ключа;
[ ] логировать только fingerprint публичного ключа.
```

Fingerprint:

```text
SHA256(public_component_key)[:16]
```

### 01.2. Запретить production DEBUG и plaintext logs

В `ServerConfig` добавить:

```text
runtime_env: dev|test|production
allow_debug_logging: bool default false for production
```

Правило:

```text
if runtime_env == "production" and log_level == "DEBUG": fail startup
```

Убрать/заменить:

```python
logger.debug("Received type=%d, body=%s", sendtype, plaintext[:100])
```

На безопасное:

```python
logger.debug("Received message", extra={
  "sendtype": sendtype,
  "body_len": len(body_bytes),
  "request_id": request_id,
})
```

Если logging остаётся стандартным, не обязательно сразу JSON, но содержание должно быть redacted.

### 01.3. Redaction helpers

Создать:

```text
license-server/ztool_license_server/security/redaction.py
```

Функции:

```python
def hash_code(code: str) -> str: ...
def hash_machine(machine_code: str) -> str: ...
def safe_details(details: str) -> str: ...
```

Использовать в audit log и обычных логах там, где есть риск утечки.

Важно: DB `audit_log` может хранить `code` и `machine_code`, если это нужно бизнесу, но application logs/journal не должны содержать plaintext machine fingerprint и registration payload.

### 01.4. Изменить keygen production defaults

Текущий `keygen.py` пишет `keypair_info.json` с `d_hex`. Для production это опасно.

Изменить поведение:

```text
[ ] По умолчанию keygen пишет только public_key.txt и private_key.txt.
[ ] keypair_info.json пишется только с флагом --write-debug-key-info / --insecure-write-key-info.
[ ] CLI печатает предупреждение.
[ ] private_key.txt создаётся с mode 0600 на Unix.
[ ] public_key.txt может быть 0644.
```

### 01.5. Tests

Добавить тесты:

```text
license-server/tests/test_key_provider.py
license-server/tests/test_logging_redaction.py
```

Сценарии:

```text
[ ] private key загружается из явных файлов.
[ ] missing private key => startup failure.
[ ] production + DEBUG => startup failure.
[ ] plaintext registration code не появляется в caplog.
[ ] machine_code не появляется в caplog.
[ ] redaction stable и deterministic.
[ ] keygen default не создаёт keypair_info.json.
```

## Acceptance criteria

```text
[ ] Server starts with legacy ZTOOL_KEYS_DIR.
[ ] Server starts with explicit ZTOOL_PRIVATE_KEY_FILE/ZTOOL_PUBLIC_KEY_FILE.
[ ] Production DEBUG запрещён.
[ ] Plaintext body не логируется.
[ ] keypair_info.json не создаётся по умолчанию.
[ ] pytest PASS.
[ ] README обновлён: production key handling.
```

## Audit checklist

Я проверяю:

```text
[ ] Нет ключей/секретов в diff.
[ ] Нет plaintext payload в logs.
[ ] Startup fails closed при небезопасной production конфигурации.
[ ] Backward compatibility сохранена.
[ ] Тесты реально ловят старое поведение.
```

---

# Phase 02 — TCP protocol hardening

## Цель

Сделать transport layer устойчивым к malformed frames, partial reads, oversized bodies, unknown sendtypes и timeout abuse.

## Branch

```text
hardening/02-protocol-hardening
```

## Tasks

### 02.1. Protocol limits

Ввести настройки:

```python
max_body_size: int = 2 * 1024 * 1024
max_frames_per_connection: int = 16
read_timeout_seconds: float = 10.0
idle_timeout_seconds: float = 30.0
```

В env:

```text
ZTOOL_MAX_BODY_SIZE
ZTOOL_MAX_FRAMES_PER_CONNECTION
ZTOOL_READ_TIMEOUT_SECONDS
ZTOOL_IDLE_TIMEOUT_SECONDS
```

### 02.2. FrameParser fail-closed

В `protocol/framing.py`:

```text
[ ] body_len < 0 => ProtocolError.
[ ] body_len > max_body_size => ProtocolError.
[ ] sendtype не в allowed request sendtypes => ProtocolError или controlled REGISTER_FAILED.
[ ] buffer growth ограничен.
[ ] parse errors не assert, а нормальные исключения.
```

Создать exception classes:

```python
class ProtocolError(Exception): ...
class FrameTooLarge(ProtocolError): ...
class InvalidFrame(ProtocolError): ...
```

### 02.3. Async server timeout handling

В `_handle_client`:

```text
[ ] read обёрнут в asyncio.wait_for.
[ ] idle timeout закрывает соединение.
[ ] ProtocolError логируется safely и соединение закрывается.
[ ] Не возвращать stack trace клиенту.
[ ] Не держать соединение бесконечно.
```

### 02.4. Client ReadExact

В `client-core/src/TCPClient.cs` заменить `getreceive()` на корректный read loop:

```csharp
private static byte[] ReadExact(Socket s, int len, int timeoutMs)
```

Требования:

```text
[ ] Header field 10 bytes читается через ReadExact.
[ ] Length field 10 bytes читается через ReadExact.
[ ] body_len проверяется: 0 <= len <= MAX_RESPONSE_BODY.
[ ] Body читается через ReadExact.
[ ] Ошибка связи даёт понятное RU-сообщение.
[ ] Нет фиксированного blind buffer на 10 MB.
```

Сохранить совместимость с текущим server response format.

### 02.5. Tests

Добавить/обновить:

```text
license-server/tests/test_protocol_limits.py
license-server/tests/test_malformed_frames.py
```

Сценарии:

```text
[ ] complete frame OK.
[ ] fragmented header OK.
[ ] fragmented body OK.
[ ] multiple frames OK within limit.
[ ] negative length rejected.
[ ] huge length rejected without buffer growth.
[ ] unknown sendtype rejected safely.
[ ] invalid UTF-8 body rejected safely.
[ ] invalid AES/Base64 returns INFO_ERROR and closes/continues as expected.
```

Для client-core — manual или unit-harness, если возможно:

```text
[ ] response header split into 1-byte chunks accepted.
[ ] response body split accepted.
[ ] oversized response rejected.
```

## Acceptance criteria

```text
[ ] Legacy activation tests still PASS.
[ ] Malformed/oversized frames covered.
[ ] Server no longer can be forced into unbounded buffer wait.
[ ] Client no longer assumes one Receive == full header.
[ ] Manual activation still PASS if client-core changed.
```

## Audit checklist

```text
[ ] Parser has explicit max body.
[ ] No assert for untrusted input.
[ ] Async handler has timeout.
[ ] Client ReadExact implemented correctly.
[ ] Backward compatibility confirmed by integration tests.
```

---

# Phase 03 — DB migrations, transactions, device_limit and password handling

## Цель

Сделать storage layer predictable, migration-safe and production-safe.

## Branch

```text
hardening/03-db-state-model
```

## Tasks

### 03.1. Schema versioning and migrations

Добавить:

```text
license-server/ztool_license_server/db/migrations.py
license-server/ztool_license_server/db/schema.py
```

Или оставить `db.py`, но ввести:

```text
schema_version table
migration runner
idempotent migrations
```

Минимальные migration versions:

```text
001_initial_existing_schema
002_password_hash_columns
003_pending_activation_transfer
004_indexes_constraints
```

### 03.2. SQLite production pragmas

При connect:

```sql
PRAGMA foreign_keys = ON;
PRAGMA journal_mode = WAL;
PRAGMA busy_timeout = 5000;
```

Опционально:

```sql
PRAGMA synchronous = NORMAL;
```

### 03.3. Transactions

Операции должны быть атомарными:

```text
validate_code + check_password + reserve/activate + audit
apply_remove + audit
confirm + state transition + audit
```

Создать helper:

```python
@contextmanager
def transaction(self): ...
```

### 03.4. Исправить device_limit mismatch

Выбрать target policy:

**Рекомендуемая политика:** `device_limit` поддерживается корректно, default = 1.

Тогда `activate/reserve` использует:

```python
limit = self.get_device_limit(code)
if active_count_for_distinct_machines >= limit: reject DEVICE_LIMIT
```

Сценарии:

```text
limit=1: поведение как сейчас.
limit=2: две разные машины активируются, третья rejected.
повторная активация той же машины idempotent.
transfer освобождает только конкретную машину.
```

Если бизнес решит строго `1 code = 1 machine`, тогда агент должен удалить `device_limit` из CLI/docs/schema или задокументировать deprecated, но не оставлять ложный параметр.

### 03.5. Password hashing

Текущее поле `password` заменить или дополнить:

```text
password_hash TEXT
password_salt TEXT optional
password_algo TEXT default 'pbkdf2_sha256'
```

Поддержать миграцию:

```text
[ ] Старые plaintext password при первом запуске мигрируются в hash.
[ ] Или отдельная CLI команда migrate-passwords.
[ ] После миграции plaintext password очищается.
```

Минимально допустимо:

```python
hashlib.pbkdf2_hmac('sha256', password.encode(), salt, iterations=200_000)
```

Лучше использовать стандартную библиотеку без новых зависимостей, если dependency policy важна.

### 03.6. DB indexes

Добавить индексы:

```sql
CREATE INDEX IF NOT EXISTS idx_activations_code_active ON activations(code, is_active);
CREATE INDEX IF NOT EXISTS idx_activations_machine_active ON activations(machine_code, is_active);
CREATE INDEX IF NOT EXISTS idx_audit_timestamp ON audit_log(timestamp);
```

Для pending tables — см. Phase 04.

### 03.7. CLI updates

CLI должен:

```text
[ ] add-code хранит hash, если password задан.
[ ] list-codes не печатает password/hash.
[ ] list-activations имеет безопасный вывод machine fingerprint truncated/hash.
[ ] migrate command optional.
[ ] backup command optional.
```

## Tests

Добавить:

```text
license-server/tests/test_db_migrations.py
license-server/tests/test_device_limit.py
license-server/tests/test_password_hashing.py
license-server/tests/test_db_transactions.py
```

Сценарии:

```text
[ ] fresh DB migrates to latest schema.
[ ] existing old DB migrates.
[ ] plaintext password converts to hash.
[ ] correct password accepted.
[ ] wrong/empty password rejected for protected code.
[ ] no password code accepts blank.
[ ] limit=1 old behavior.
[ ] limit=2 works.
[ ] transaction rollback on failure.
```

## Acceptance criteria

```text
[ ] Existing tests PASS.
[ ] New migration tests PASS.
[ ] device_limit behavior is consistent with CLI/docs.
[ ] Passwords no longer stored in plaintext for new rows.
[ ] SQLite runs with foreign_keys/WAL/busy_timeout.
```

## Audit checklist

```text
[ ] Migration runner is idempotent.
[ ] No destructive migration without backup note.
[ ] Password hash migration safe.
[ ] device_limit mismatch closed.
[ ] DB operations are transactional.
```

---

# Phase 04 — stateful activation and transfer flow

## Цель

Связать `apply_register -> register_confirm` и `apply_remove -> remove_confirm` через серверное состояние. Убрать возможность подтверждать произвольный confirm без apply.

## Branch

```text
hardening/04-activation-transfer-state
```

## Design target

### 04.1. Pending activation

Добавить таблицу:

```sql
CREATE TABLE IF NOT EXISTS pending_activations (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    code TEXT NOT NULL,
    machine_code TEXT NOT NULL,
    machine_hash TEXT NOT NULL,
    apply_branches_hash TEXT NOT NULL,
    transport_hash TEXT NOT NULL,
    client_ip TEXT,
    created_at TEXT DEFAULT (datetime('now')),
    expires_at TEXT NOT NULL,
    confirmed_at TEXT,
    status TEXT NOT NULL DEFAULT 'pending',
    FOREIGN KEY(code) REFERENCES license_codes(code)
);
```

Индексы:

```sql
CREATE INDEX IF NOT EXISTS idx_pending_activation_hash ON pending_activations(apply_branches_hash, status);
CREATE INDEX IF NOT EXISTS idx_pending_activation_code_machine ON pending_activations(code, machine_code, status);
```

Flow:

```text
1. Apply_register validates code/password/machine.
2. Server reserves pending seat, not final active seat.
3. Server generates apply transport blob.
4. Server stores hash of the 4 apply branches / transport.
5. Client writes blob and sends register_confirm with those 4 branches.
6. Server parses confirm branches, computes hash, finds pending activation.
7. Server checks TTL/status/code/machine_hash.
8. Server returns confirm transport result 12.
9. Server marks activation active/confirmed.
```

Important: текущий protocol confirm не несёт code явно. Поэтому matching должен использовать hash of returned apply branches plus parsed machine hash. Если возможно без изменения клиента — добавить server-generated nonce внутрь blob только если клиент сохраняет/возвращает его неизменным и IsReg не ломается. Без необходимости не менять blob format.

### 04.2. Pending activation TTL

Default TTL:

```text
10 minutes
```

Env:

```text
ZTOOL_PENDING_ACTIVATION_TTL_SECONDS=600
```

Expired pending activations:

```text
[ ] не занимают seat;
[ ] могут быть очищены lazy при apply/confirm;
[ ] имеют CLI cleanup command.
```

### 04.3. Active activation status

Расширить `activations`:

```text
status: active|deactivated|pending optional
confirmed_at
last_seen_at optional
```

Или оставить активную запись только после confirm. Рекомендуется: active row создаётся только после successful confirm. Pending seat учитывается отдельно для лимита, чтобы не было гонок.

### 04.4. Pending transfer

Добавить таблицу:

```sql
CREATE TABLE IF NOT EXISTS pending_transfers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    code TEXT NOT NULL,
    machine_code TEXT NOT NULL,
    machine_hash TEXT NOT NULL,
    client_ip TEXT,
    created_at TEXT DEFAULT (datetime('now')),
    expires_at TEXT NOT NULL,
    confirmed_at TEXT,
    status TEXT NOT NULL DEFAULT 'pending',
    FOREIGN KEY(code) REFERENCES license_codes(code)
);
```

Flow target:

```text
1. apply_remove validates code/password/machine and active activation exists.
2. Server creates pending transfer.
3. Server returns result expected by real client.
4. Client performs local removal flow and sends remove_confirm.
5. remove_confirm matches pending transfer.
6. Server marks activation deactivated.
7. Server marks transfer confirmed.
```

Critical: verify real client semantics. Current client code calls `outrg(receive)` on result 11. Агент должен проверить, нужен ли non-empty removal transport blob. Нельзя считать transfer production-ready только по raw TCP emulator.

### 04.5. Confirm parsing hardening

`_handle_register_confirm` должен:

```text
[ ] preserve interior blank lines where protocol requires;
[ ] validate exactly 4 branches + required time fields;
[ ] parse branches safely;
[ ] reject if no pending activation matches;
[ ] reject expired pending;
[ ] reject already confirmed pending unless idempotent retry allowed;
[ ] audit every rejection with redacted/hash details.
```

`_handle_remove_confirm` должен:

```text
[ ] parse real SR.get_rginfo() payload after SR.outrg();
[ ] bind by transfer branch hash + client IP, not by latest/global pending row;
[ ] reject if no pending transfer;
[ ] reject expired pending transfer;
[ ] finalize deactivation transactionally.
```

If legacy protocol does not provide enough information for secure remove_confirm, document the exact limitation and implement the strongest compatible binding. But the agent must not leave blind unconditional `TRANSFER_DONE`.

## Tests

Add:

```text
license-server/tests/test_activation_state.py
license-server/tests/test_transfer_state.py
license-server/tests/test_confirm_replay.py
```

Scenarios:

```text
[ ] confirm without apply rejected.
[ ] confirm with modified branches rejected.
[ ] confirm after TTL rejected.
[ ] apply + confirm accepted.
[ ] duplicate confirm idempotent or rejected by documented policy.
[ ] replay old confirm for new activation rejected.
[ ] pending apply reserves seat until TTL.
[ ] expired pending does not block valid activation.
[ ] apply_remove without active activation rejected.
[ ] remove_confirm without apply_remove rejected.
[ ] remove_confirm after TTL rejected.
[ ] transfer frees seat only after confirmed remove.
[ ] activation on another machine before transfer confirm rejected.
[ ] activation after transfer confirm accepted.
```

Manual:

```text
[ ] Real UI activation: PASS.
[ ] Real UI transfer: PASS.
[ ] Raw TCP emulator still PASS.
```

## Acceptance criteria

```text
[ ] register_confirm no longer succeeds without pending apply.
[ ] remove_confirm no longer succeeds unconditionally.
[ ] Replay tests PASS.
[ ] TTL cleanup works.
[ ] Manual real-client activation PASS.
[ ] Manual real-client transfer PASS or blocker documented and fixed before production gate.
```

## Audit checklist

```text
[ ] No blind confirm.
[ ] State transitions are transactional.
[ ] Pending states have TTL.
[ ] Replay is tested.
[ ] Compatibility with existing client proven.
```

---

# Phase 05 — operations, deployment, backup and observability

## Цель

Сделать сервер разворачиваемым и сопровождаемым в production.

## Branch

```text
hardening/05-ops-deploy-observability
```

## Tasks

### 05.1. Deployment layout

Добавить:

```text
deploy/
  systemd/
    ztool-license-server.service
    ztool-license-server.env.example
    README_RU.md
  docker/
    Dockerfile
    docker-compose.yml
    README_RU.md
  firewall/
    ufw-example.md
  backup/
    sqlite-backup.sh
    restore-drill.md
  monitoring/
    metrics.md
    alerts.md
```

### 05.2. systemd service

Service requirements:

```ini
[Unit]
Description=ZTool License TCP Server
After=network-online.target
Wants=network-online.target

[Service]
Type=simple
User=ztool
Group=ztool
WorkingDirectory=/opt/ztool-license-server
EnvironmentFile=/etc/ztool-license-server/ztool-license-server.env
ExecStart=/opt/ztool-license-server/.venv/bin/python -m ztool_license_server.server
Restart=on-failure
RestartSec=5
NoNewPrivileges=true
PrivateTmp=true
ProtectSystem=strict
ProtectHome=true
ReadWritePaths=/var/lib/ztool-license-server /var/log/ztool-license-server

[Install]
WantedBy=multi-user.target
```

Adjust if Python module entry differs.

### 05.3. Healthcheck

Add CLI command:

```bash
python -m ztool_license_server.cli healthcheck
```

Checks:

```text
[ ] DB readable/writable.
[ ] Schema latest.
[ ] Public/private key load OK.
[ ] Keypair self-check OK using test message.
[ ] Config valid.
```

Optional TCP healthcheck:

```bash
python -m ztool_license_server.cli tcp-smoke --host 127.0.0.1 --port 58000
```

Must not require real customer license code.

### 05.4. Backup/restore

SQLite backup must use SQLite backup API or safe `.backup`, not raw copy of hot DB.

Add CLI:

```bash
python -m ztool_license_server.cli backup --out /backup/licenses-YYYYMMDD.db
python -m ztool_license_server.cli verify-backup /backup/licenses-YYYYMMDD.db
```

Docs:

```text
[ ] Backup schedule.
[ ] Restore procedure.
[ ] Restore drill checklist.
[ ] Key backup separate from DB backup.
[ ] What happens if private key lost.
```

### 05.5. Structured audit events

Add structured audit event categories:

```text
activation.apply.accepted
activation.apply.rejected
activation.confirm.accepted
activation.confirm.rejected
transfer.apply.accepted
transfer.apply.rejected
transfer.confirm.accepted
transfer.confirm.rejected
protocol.invalid_frame
security.wrong_password
security.invalid_machine
```

### 05.6. Metrics

Minimum counters, even if only log-derived initially:

```text
ztool_activation_apply_total{result}
ztool_activation_confirm_total{result}
ztool_transfer_apply_total{result}
ztool_transfer_confirm_total{result}
ztool_invalid_frame_total{reason}
ztool_wrong_password_total
ztool_invalid_machine_total
ztool_license_db_errors_total
ztool_request_latency_ms
```

Implementation options:

```text
Option A: structured logs only + docs.
Option B: Prometheus textfile exporter.
Option C: small HTTP metrics endpoint bound to localhost only.
```

Prefer B or C if simple. Do not expose admin/metrics publicly.

### 05.7. Rate limiting / abuse control

Minimum in server:

```text
[ ] per-IP connection limit optional;
[ ] per-IP failed attempts window optional;
[ ] wrong password / invalid code attempts logged.
```

If not implemented in app, document firewall/fail2ban/nginx equivalent. Since protocol is raw TCP, fail2ban on logs may be easiest.

## Acceptance criteria

```text
[ ] systemd service example exists.
[ ] env example exists and has no secrets.
[ ] backup/restore docs exist.
[ ] healthcheck command works.
[ ] production runbook exists.
[ ] metrics/audit event list exists.
[ ] No DEBUG in production env example.
```

## Audit checklist

```text
[ ] Service runs as non-root.
[ ] Private key file path not in repo with real key.
[ ] Backup procedure is safe for SQLite.
[ ] Healthcheck fails closed on key/DB errors.
[ ] Docs are actionable.
```

---

# Phase 06 — CI, test quality and dependency management

## Цель

Сделать сборку и тестирование воспроизводимыми в CI.

## Branch

```text
hardening/06-ci-test-quality
```

## Tasks

### 06.1. Python dependency lock / dev tooling

Выбрать один подход:

```text
Option A: requirements-dev.txt + requirements.txt
Option B: pip-tools requirements.lock
Option C: uv.lock
```

Минимум добавить в `pyproject.toml`:

```text
ruff
bandit
pytest-cov
```

Optional:

```text
mypy or pyright
```

### 06.2. GitHub Actions

Добавить:

```text
.github/workflows/license-server.yml
.github/workflows/client-core-windows.yml
.github/workflows/secret-scan.yml
```

`license-server.yml`:

```yaml
- checkout
- setup-python 3.10/3.11/3.12 matrix optional
- pip install -e .[dev]
- ruff check .
- pytest -q --cov=ztool_license_server
- bandit -r ztool_license_server
```

`client-core-windows.yml`:

```yaml
runs-on: windows-latest
steps:
  - checkout
  - setup-dotnet
  - cd client-core
  - ./build.ps1
  - Reinjector --verify out/ZTool.exe
```

If binary inputs are too large or not available in CI, workflow must clearly skip with reason and run compile-only checks. But target state: full build works in CI.

### 06.3. Test categories

Mark tests:

```text
unit
integration
slow
manual
live
```

Use pytest markers:

```ini
[tool.pytest.ini_options]
markers = [
  "integration: ...",
  "live: ...",
]
```

### 06.4. Coverage targets

Minimum target:

```text
license-server: 75% initially
critical modules: protocol, db, license_blob, server handlers should be high coverage
```

Do not block all PRs immediately on high coverage if current code is below target; introduce ratchet:

```text
coverage must not decrease
```

### 06.5. Security tests

Add tests for:

```text
[ ] log redaction.
[ ] invalid frames.
[ ] replay confirm.
[ ] wrong password.
[ ] invalid machine.
[ ] expired code.
[ ] expired pending activation.
[ ] malformed RSA/AES payload.
```

### 06.6. Release artifact checks

Add script:

```text
tools/release_manifest.py or scripts/generate_release_manifest.py
```

Outputs:

```json
{
  "git_commit": "...",
  "files": {
    "ZTool.exe": "sha256:...",
    "ZTool.dll": "sha256:..."
  },
  "server": {
    "version": "...",
    "python": "..."
  },
  "tests": {
    "pytest": "..."
  }
}
```

## Acceptance criteria

```text
[ ] CI exists and runs license-server tests.
[ ] CI includes lint/security scan.
[ ] Windows client-core workflow exists or documented blocker.
[ ] pytest markers defined.
[ ] Release manifest script exists.
[ ] Existing tests PASS locally and in CI.
```

## Audit checklist

```text
[ ] CI cannot silently pass on failed tests.
[ ] Workflows do not print secrets.
[ ] Dependency policy clear.
[ ] Test markers sane.
[ ] Manifest reproducible.
```

---

# Phase 07 — localization hardening

## Цель

Превратить локализацию из разового binary patch в контролируемый localization pipeline with gates.

## Branch

```text
hardening/07-localization-hardening
```

## Tasks

### 07.1. Localization docs layout

Создать:

```text
docs/localization/
  LOCALIZATION_PROCESS_RU.md
  GLOSSARY_ZH_RU.md
  WHITELIST_POLICY_RU.md
  UI_SCREENSHOT_CHECKLIST_RU.md
localization/
  whitelist_protocol_keys.txt
  whitelist_font_names.txt
  whitelist_technical_logs.txt
  whitelist_known_chinese_remaining.txt
```

### 07.2. Localizer scan mode must produce machine-readable report

Current `Localizer` has scan/dump capabilities. Add/standardize:

```powershell
dotnet run -c Release --project client-core/tools/Localizer -- --scan-json client-core/out/ZTool.exe localization-report.json
```

Report fields:

```json
{
  "file": "ZTool.exe",
  "total_strings": 1234,
  "han_strings": 12,
  "translated": 1000,
  "whitelisted": 12,
  "unclassified_han": [],
  "errors": []
}
```

Build should fail if `unclassified_han` is non-empty.

### 07.3. Whitelist policy

Каждая оставшаяся китайская строка должна быть классифицирована:

```text
protocol_key       — нельзя переводить, используется в crypto/protocol
font_name          — нельзя переводить, используется в UI rendering
technical_log      — не user-facing, можно оставить
vendor_data        — убрать или заменить отдельно
settings_token     — нельзя переводить, используется как key/comparison token
unknown            — build fail
```

### 07.4. Translation table validation

Для `translations.tsv` добавить validator:

```text
[ ] no duplicate source strings unless intentional.
[ ] no empty RU for translatable strings.
[ ] no protocol key translated.
[ ] no font name translated.
[ ] escaped tabs/newlines valid.
[ ] file sorted or stable.
```

### 07.5. UI layout checks

Добавить checklist и, если возможно, инструмент:

```text
[ ] FrmRverify
[ ] FrmOptions
[ ] Registration dialog
[ ] Update dialog
[ ] Main ribbon tabs
[ ] File menu
[ ] BOM export dialogs
[ ] Save options
[ ] Error message boxes
[ ] SolidWorks add-in tab/buttons
```

For each screenshot:

```text
- no clipped critical text;
- no visible Han except whitelisted;
- buttons visible;
- no overlap;
- form opens without exception.
```

### 07.6. BOM template deterministic build

`build_ru_bom_template.py` currently selects first XLSX via glob. Make deterministic:

```text
[ ] Explicit SRC path constant or CLI arg.
[ ] Fail if source missing.
[ ] Fail if multiple candidates and no explicit source.
[ ] Verify shared string count.
[ ] Output hash logged.
```

### 07.7. Documentation reconciliation

Older docs may say `ZTool.dll` not localized; newer manual report says ribbon/DLL Russian. Update docs to avoid contradictions:

```text
[ ] Mark old audit as historical.
[ ] Add current localization status by artifact hash.
[ ] Add known remaining Chinese strings by category.
```

## Acceptance criteria

```text
[ ] Localization scan JSON exists.
[ ] Build fails on unclassified Han strings.
[ ] Whitelist files exist.
[ ] Translation table validator exists.
[ ] BOM template build deterministic.
[ ] Current localization docs match actual build.
[ ] Manual UI screenshot checklist completed for release candidate.
```

## Audit checklist

```text
[ ] Protocol keys are not translated.
[ ] Remaining Chinese strings are classified.
[ ] No broad regex translation that can hit keys.
[ ] BOM script deterministic.
[ ] Docs no longer contradict current state.
```

---

# Phase 08 — client-core and reinjector hardening

## Цель

Сделать binary reinjection pipeline максимально fail-closed and reproducible.

## Branch

```text
hardening/08-client-core-reinjector-hardening
```

## Tasks

### 08.1. Strict input hashes

Create:

```text
client-core/build-inputs.json
```

Example:

```json
{
  "ZTool-base.exe": {
    "sha256": "...",
    "description": "pristine rekeyed build input"
  },
  "ref/ZTool.public.dll": {
    "sha256": "..."
  },
  "ref/ZTool_rsa.dll": {
    "sha256": "..."
  }
}
```

`build.ps1` must:

```text
[ ] verify input hashes before build;
[ ] fail unless -AllowUnknownInputs passed;
[ ] write output manifest.
```

### 08.2. Strict method matching

Reinjector currently has fallback behavior when multiple methods match. Harden:

```text
[ ] Build a manifest of target methods: type, name, signature, metadata token, original IL hash.
[ ] Before replacing method, verify original IL hash matches expected.
[ ] If mismatch — fail.
[ ] No fallback to first candidate unless explicit --allow-fuzzy-match.
```

Create:

```text
client-core/reinject-manifest.json
```

### 08.3. Output manifest

After build create:

```text
client-core/out/ZTool.manifest.json
```

Fields:

```json
{
  "git_commit": "...",
  "base_exe_sha256": "...",
  "output_exe_sha256": "...",
  "translation_table_sha256": "...",
  "replaced_methods": [
    {
      "type": "ZTool.TCPClient",
      "method": "getreceive",
      "old_il_sha256": "...",
      "new_il_sha256": "..."
    }
  ],
  "dangling_refs": 0,
  "public_key_token": "...",
  "win32_version": "..."
}
```

### 08.4. Client TCP hardening verification

If Phase 02 changed `TCPClient.getreceive`, Phase 08 must add C# or harness checks around it where feasible.

### 08.5. Separate binary artifacts policy

Document:

```text
[ ] Which binaries are source inputs.
[ ] Which binaries are generated outputs.
[ ] Which binaries are committed.
[ ] Which binaries are release artifacts only.
[ ] How to verify hash before running.
```

### 08.6. Strong name/public key token policy

Current comments say preserving public key token is required for IPC with SolidWorks add-in. Document in production docs:

```text
[ ] Do not strip public key token unless add-in handshake is changed.
[ ] Verify token in build.
[ ] Add test/manifest field for token.
```

## Acceptance criteria

```text
[ ] build.ps1 fails on unexpected base exe hash.
[ ] Reinjector fails on original IL hash mismatch.
[ ] Output manifest generated.
[ ] Dangling refs check remains mandatory.
[ ] Public key token documented and verified.
```

## Audit checklist

```text
[ ] No fuzzy method replacement by default.
[ ] Hash mismatches fail closed.
[ ] Manifest is complete.
[ ] Build remains reproducible.
[ ] Manual smoke test done if runtime behavior changed.
```

---

# Phase 09 — security threat model and policy hardening

## Цель

Документировать threat model, residual risks и operational security controls.

## Branch

```text
hardening/09-security-threat-model
```

## Tasks

### 09.1. Threat model

Create:

```text
docs/security/THREAT_MODEL_RU.md
```

Sections:

```text
1. Assets
   - private signing key
   - license DB
   - license codes
   - machine fingerprints
   - release binaries
   - admin/operator access
2. Trust boundaries
   - client is untrusted
   - TCP network untrusted
   - server process trusted if host secure
   - DB trusted only with file permissions/backups
3. Attackers
   - random internet scanner
   - user with valid code trying multiple devices
   - user replaying old blobs
   - operator mistake
   - leaked private key
4. Threats
   - replay confirm
   - machine spoofing
   - brute force code/password
   - DoS oversized frames
   - key exfiltration
   - malicious modified client
   - logs leaking PII/secrets
5. Mitigations
6. Residual risks
7. Incident response
```

### 09.2. Key compromise runbook

Create:

```text
docs/security/KEY_COMPROMISE_RUNBOOK_RU.md
```

Include:

```text
[ ] How to detect.
[ ] Immediate shutdown/rotate.
[ ] Generate new key pair.
[ ] Rebuild client with new public key.
[ ] Invalidate old server key.
[ ] Customer migration plan.
[ ] Audit DB/logs.
```

### 09.3. Abuse/rate limit policy

Document:

```text
[ ] invalid code threshold.
[ ] wrong password threshold.
[ ] per-IP fail2ban example.
[ ] how to unblock legitimate customer.
```

### 09.4. Data retention / privacy

Document:

```text
[ ] What is stored: license code, machine fingerprint/hash, timestamps.
[ ] Why it is stored.
[ ] Retention period for audit logs.
[ ] How to delete customer data.
[ ] Logs redaction policy.
```

## Acceptance criteria

```text
[ ] Threat model exists.
[ ] Key compromise runbook exists.
[ ] Abuse policy exists.
[ ] Data retention policy exists.
[ ] Residual risks explicit.
```

## Audit checklist

```text
[ ] Threat model matches actual implementation.
[ ] No false claims of cryptographic strength.
[ ] Residual legacy crypto risks documented.
[ ] Operational response is actionable.
```

---

# Phase 10 — final release packaging and production readiness gate

## Цель

Собрать production release candidate с manifest, checksums, docs, deployment package and final test evidence.

## Branch

```text
hardening/10-release-packaging
```

## Tasks

### 10.1. Release package layout

Create script:

```text
scripts/build_release_package.ps1
```

Output:

```text
release/ZTool-<version>-<date>/
  runtime/
    ZTool.exe
    ZTool.dll
    ZToolARM.dll
    SolidWorksTools.dll
    ZTool.settings
    other required dlls
  license-server/
    source-or-wheel
    deploy examples
  docs/
    INSTALL_RU.md
    OPERATIONS_RU.md
    RELEASE_NOTES_RU.md
    ROLLBACK_RU.md
  manifest.json
  SHA256SUMS.txt
```

### 10.2. Release notes

`RELEASE_NOTES_RU.md`:

```text
[ ] Version.
[ ] Git commit.
[ ] What changed.
[ ] Known limitations.
[ ] Required server env.
[ ] Required client files.
[ ] Upgrade path.
[ ] Rollback path.
```

### 10.3. Final test plan

Create:

```text
docs/release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md
```

Must include:

```text
Server:
[ ] fresh install
[ ] migration from previous DB
[ ] key load
[ ] healthcheck
[ ] backup/restore
[ ] online activation valid code
[ ] invalid code
[ ] wrong password
[ ] expired code
[ ] device limit
[ ] transfer
[ ] replay confirm rejected
[ ] malformed frame rejected
[ ] oversized frame rejected

Client:
[ ] clean Windows VM
[ ] RegAsm
[ ] no existing registry license
[ ] trial starts
[ ] activation dialog RU
[ ] online activation succeeds
[ ] app restarts and remains licensed
[ ] transfer via UI succeeds
[ ] reactivation on second machine succeeds
[ ] invalid code message RU
[ ] wrong password message RU
[ ] server unavailable message RU

SolidWorks:
[ ] SW 2025 smoke
[ ] optional SW 2024 smoke
[ ] optional SW 2023 smoke
[ ] ZTool ribbon visible
[ ] icons visible
[ ] connect SW
[ ] read by BOM: expected rows
[ ] read all: expected rows
[ ] save/export basic smoke

Localization:
[ ] no unclassified Han strings
[ ] screenshot checklist complete
[ ] BOM template RU

Ops:
[ ] systemd service starts
[ ] service restarts on failure
[ ] logs redacted
[ ] DEBUG disabled
[ ] backup exists
[ ] restore drill completed
```

### 10.4. Final production readiness report

Create:

```text
docs/release/PRODUCTION_READINESS_REPORT_RU.md
```

Structure:

```text
1. Executive summary
2. Scope
3. Release artifacts and hashes
4. Test evidence
5. Security controls
6. Operational controls
7. Known residual risks
8. Rollback plan
9. Go/No-Go recommendation
```

### 10.5. Release gate

Production Go only if:

```text
[ ] All Phase 00–10 PRs merged.
[ ] No open P0/P1 in risk register.
[ ] Final acceptance tests PASS.
[ ] Real UI transfer PASS.
[ ] Private key not in repo/package.
[ ] Logs redacted.
[ ] Backup/restore proven.
[ ] Release manifest and SHA256SUMS generated.
[ ] Rollback package available.
```

## Acceptance criteria

```text
[ ] Release package builds reproducibly.
[ ] Manifest and SHA256SUMS exist.
[ ] Final test plan completed.
[ ] Production readiness report exists.
[ ] No P0/P1 risks open.
```

## Audit checklist

```text
[ ] Artifacts match manifest hashes.
[ ] Test evidence is tied to exact commit/hash.
[ ] Release package contains no private key/DB/dumps.
[ ] Rollback instructions are practical.
[ ] Final Go/No-Go can be made confidently.
```

---

# 3. Cross-phase technical notes

## 3.1. Legacy crypto risk handling

Do not replace RSA/AES/DES primitives in the legacy protocol unless client compatibility is intentionally broken and a migration plan exists. Current primitives are weak by modern standards, but they are part of the compatibility layer. Production mitigation is:

```text
[ ] private key protection;
[ ] no plaintext logs;
[ ] replay/state checks;
[ ] rate limiting;
[ ] transport perimeter/firewall;
[ ] release artifact integrity;
[ ] threat model documents residual crypto weakness.
```

## 3.2. Client is untrusted

Never rely on the client for authoritative licensing decisions beyond what legacy protocol forces. Server must enforce:

```text
[ ] code validity;
[ ] expiration;
[ ] password;
[ ] device limit;
[ ] pending state;
[ ] transfer state;
[ ] audit.
```

## 3.3. Avoid silent compatibility fallbacks

Fallbacks are allowed only if:

```text
[ ] they are documented;
[ ] tests cover both primary and fallback path;
[ ] fallback does not weaken licensing state;
[ ] fallback logs a warning without leaking secrets.
```

## 3.4. Manual SolidWorks testing remains mandatory

Server-side tests are not enough. Any change to these areas requires real Windows/SolidWorks smoke:

```text
client-core/src/SR.cs
client-core/src/TCPClient.cs
client-core/tools/Reinjector
client-core/tools/Localizer
ZTool.settings
ZTool.dll-related files
license blob format
register confirm format
transfer flow
```

## 3.5. Audit response format

After each PR I will return one of:

```text
APPROVED FOR MERGE
```

or

```text
CHANGES REQUESTED
- P0: ...
- P1: ...
- P2: ...
```

Severity:

```text
P0 — must fix before merge; production blocker or correctness/security issue.
P1 — should fix before merge unless explicitly deferred.
P2 — can defer with issue/risk register entry.
```

---

# 4. Suggested implementation order summary

```text
00 baseline docs and repo hygiene
01 secrets/logging
02 protocol hardening
03 DB/migrations/device_limit/passwords
04 stateful activation/transfer
05 ops/deploy/backup/monitoring
06 CI/tests/dependency quality
07 localization hardening
08 client-core/reinjector hardening
09 security threat model
10 release packaging/final gate
```

Do not start Phase 10 until Phases 01–09 are merged or explicitly accepted as deferred risks.

---

# 5. Minimum viable production cut

If time is limited, the minimum production cut is:

```text
Phase 00
Phase 01
Phase 02
Phase 03 device_limit/password/WAL subset
Phase 04 register/transfer state
Phase 05 systemd + backup + runbook subset
Phase 06 CI server tests subset
Phase 10 final package/report
```

Localization hardening and reinjector strictness can be partly parallelized, but should not be skipped for long-term maintainability.

---

# 6. Immediate instructions for the implementation agent

1. Start with `hardening/00-baseline-docs`.
2. Add this file as `docs/production/PRODUCTION_HARDENING_PLAN_RU.md`.
3. Add the docs and templates listed in Phase 00.
4. Do not touch runtime logic in Phase 00.
5. Open PR with `docs/audit/phase-00-baseline-implementation-report.md`.
6. Wait for audit before merge.
7. Continue phase-by-phase only after merge approval.

