# Phase 00 — baseline implementation report

## Scope

Добавлена production-hardening документация и audit framework. Runtime логика,
бинарники, серверный код и клиентский код не менялись.

## Changed files

- `docs/production/PRODUCTION_HARDENING_PLAN_RU.md` — основной roadmap по
  production hardening.
- `docs/production/RELEASE_BASELINE_RU.md` — baseline текущего `main`, хеши,
  тестовый статус и известные ограничения.
- `docs/production/RISK_REGISTER_RU.md` — стартовый register production-рисков.
- `docs/production/AUDIT_GATES_RU.md` — правила audit/merge gate для фаз.
- `docs/production/OPERATIONS_TODO_RU.md` — operations backlog для VPS/server
  deployment, backup, monitoring, release package.
- `docs/audit/README.md` — правила хранения implementation reports.
- `docs/audit/phase-00-baseline-implementation-report.md` — этот отчёт.
- `.github/PULL_REQUEST_TEMPLATE.md` — обязательный шаблон PR.
- `.gitignore` — добавлены локальные env/secrets/DB/dump/runtime ignores.
- `docs/INDEX.md` — добавлены ссылки на production hardening документы.
- `README.md` — добавлена ссылка на production hardening roadmap.

## Behavior changes

Нет. Phase 00 — documentation-only.

## Backward compatibility

Полная: runtime-файлы и протоколы не изменялись.

## Tests run

```powershell
git diff --check
cd license-server
python -m pytest -q
```

## Test results

```text
git diff --check: PASS
license-server: 66 passed, 1 skipped
```

Предупреждение `pytest_asyncio` про unset `asyncio_default_fixture_loop_scope`
зафиксировано в baseline и должно быть закрыто в Phase 06.

## Manual checks

Не выполнялись в этой фазе, потому что runtime/client/SolidWorks логика не
менялась. Последние live-проверки сохранены в `manual-test-reports/`.

## Security notes

- В `.gitignore` добавлены правила для локальных private keys, env-файлов,
  license DB, backups и dump-файлов.
- Реальные секреты не добавлялись.
- `license-server/keys/public_key.txt` остаётся tracked как публичный ключ;
  private key patterns игнорируются.

## Migration notes

Миграций нет.

## Rollback plan

Откатить PR целиком:

```powershell
git revert <merge-commit>
```

Так как изменений runtime нет, дополнительный rollback не требуется.

## Known limitations

- Это baseline/docs phase, не production hardening implementation.
- Корневые `ZTool.exe`/`ZTool.dll` не совпадают с live-tested recommended
  artifacts; риск R-009 оставлен открытым до Phase 10.
- CI в репозитории пока отсутствует.
