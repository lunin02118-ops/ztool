# License lifecycle automation gate — 2026-06-30

Статус: **AUTOMATION READY / LIVE MUTATING RUN PENDING / Production GO: NO-GO**

## Что добавлено

- `scripts/swtools_license_lifecycle_acceptance.ps1` — единая обёртка для P0
  licensing lifecycle: no-license UI, production key provision/reset, activation
  через существующий `swtools_activation_acceptance.ps1`, server active-state,
  revoke/delete revoked key, repeat client check.
- `tools/e2e/assert_license_lifecycle_result.py` — machine-readable gate для
  `license-lifecycle-result.json`.
- `release-acceptance.yml` теперь запускает self-test этого assert-скрипта.

## Инварианты безопасности

- Raw license code/password не пишутся в result JSON и не должны попадать в Git.
- Любое действие, меняющее production backend или активирующее клиент, требует
  явный флаг `-AllowProductionMutation`.
- `production_go_allowed` всегда `false`; этот слой не является production
  approval.

## Полный боевой запуск

Пример команды для self-hosted Windows/SolidWorks машины, когда открыто окно
регистрации SWTools и подготовлен redacted локальный secret-файл:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File scripts\swtools_license_lifecycle_acceptance.ps1 `
  -SecretPath _local_artifacts\secrets\licenses\<license-secret>.txt `
  -ReportDir _local_artifacts\reports\p0-license-lifecycle\<timestamp> `
  -ProvisionProductionKey `
  -ResetProductionBinding `
  -RequireNoLicenseWindow `
  -FillActivationForm `
  -ClickActivate `
  -VerifyActiveServerState `
  -RevokeProductionKey `
  -DeleteRevokedProductionKey `
  -RepeatPostRevokeCheck `
  -AllowProductionMutation
```

Проверка результата:

```powershell
python tools\e2e\assert_license_lifecycle_result.py `
  _local_artifacts\reports\p0-license-lifecycle\<timestamp>\license-lifecycle-result.json `
  --require-no-license `
  --require-activation `
  --require-revoke `
  --require-delete `
  --require-repeat-check
```

## Что не закрыто этим PR

- Живой mutating run против production сервера не выполнялся в CI.
- Не заявляется Production GO.
- Не закрываются visual L-01..L-15, signing, accepted hashes и owner GO.
