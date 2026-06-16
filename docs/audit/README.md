# Audit reports

В этой папке хранятся implementation reports для фаз production hardening.

Отдельные post-factum gap-аудиты тоже лежат здесь, но не обязаны повторять
шаблон implementation report. Они фиксируют разрывы между hardening scope и
фактической production readiness.

## Naming

```text
phase-XX-<short-name>-implementation-report.md
```

Примеры:

```text
phase-00-baseline-implementation-report.md
phase-01-secrets-logging-implementation-report.md
```

Post-factum пример:

```text
refactor-production-readiness-gap-audit-2026-06-16_RU.md
```

## Required sections

Каждый отчёт должен содержать:

- Scope
- Changed files
- Behavior changes
- Backward compatibility
- Tests run
- Test results
- Manual checks
- Security notes
- Migration notes
- Rollback plan
- Known limitations

## Merge rule

PR hardening-фазы нельзя мержить, пока отчёт не заполнен и не пройден audit
gate из `docs/production/AUDIT_GATES_RU.md`.
