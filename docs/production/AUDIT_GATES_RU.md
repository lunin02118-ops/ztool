# Audit gates

Этот документ фиксирует правила допуска PR к merge в production-hardening
ветках.

## Branch model

Каждая фаза выполняется отдельной веткой:

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

## Required PR artifacts

В каждом PR обязателен файл:

```text
docs/audit/phase-XX-<short-name>-implementation-report.md
```

PR description и implementation report должны содержать:

- scope;
- changed files;
- behavior changes;
- backward compatibility;
- commands run;
- test results;
- manual checks, если затронут Windows/SolidWorks/client;
- security notes;
- migration notes;
- rollback plan;
- known limitations.

## Merge checklist

```text
[ ] Implementation report добавлен.
[ ] Изменённые файлы перечислены.
[ ] Команды тестирования и результаты приложены.
[ ] Security notes заполнены.
[ ] Rollback plan практичен.
[ ] Risk register обновлён.
[ ] P0 замечаний нет.
[ ] P1 замечания закрыты или явно deferred владельцем.
[ ] Для client/SolidWorks изменений есть manual smoke report.
[ ] Получена явная фраза: APPROVED FOR MERGE.
```

## Mandatory checks by area

Server:

```powershell
cd license-server
python -m pytest -q
```

Client tooling:

```powershell
cd client-core
./build.ps1
```

Release/package:

```powershell
Get-FileHash <artifact> -Algorithm SHA256
```

Documentation-only PR:

```powershell
git diff --check
```

## Forbidden without explicit approval

- менять legacy protocol без обратной совместимости;
- менять license blob format без `IsReg1`/`IsReg2` тестов;
- коммитить private keys, реальные DB, дампы памяти, токены;
- отключать проверку лицензии silent fallback;
- убирать hardware binding;
- мержить binary artifacts без manifest/hash;
- включать DEBUG/plaintext logs в production.
