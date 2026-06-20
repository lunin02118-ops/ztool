# Production risk register

Статус на `main` после PR #8 и PR #11. Severity:

- `P0` — production blocker, нельзя мержить фазу без закрытия или явного
  письменного исключения.
- `P1` — должен быть закрыт до production-ready release.
- `P2` — допустим как известное ограничение, если есть владелец и план.

| ID | Severity | Риск | Текущий статус | Фаза-владелец |
|----|----------|------|----------------|---------------|
| R-001 | P1 | `apply_register` / `register_confirm` недостаточно связаны pending state, TTL и hash/nonce. | Mitigated in Phase 04: pending activation by branch hash + TTL; confirm without matching apply rejected. Real-client smoke still required. | Phase 04 |
| R-002 | P1 | `apply_remove` / `remove_confirm` требуют stateful transfer model и idempotency policy. | Mitigated in Phase 04: pending transfer + TTL, transfer blob returned for `outrg`, `remove_confirm` bound by transfer branch hash + client IP, blind/cross-IP/replay confirm rejected. Manual smoke required. | Phase 04 |
| R-003 | P1 | Production logging может раскрывать plaintext/protocol payload при DEBUG. | Mitigated in Phase 01: production DEBUG fail-closed, protocol payload redacted to size/hash. | Phase 01 |
| R-004 | P1 | RSA private key хранится через простые файлы без production key lifecycle/runbook. | Mitigated in Phase 01/09: explicit key files, no default `keypair_info.json`, Unix 0600 check, key compromise runbook and rotation/customer migration procedure documented. | Phase 01, Phase 09 |
| R-005 | P1 | TCP protocol не имеет полного fail-closed parser/limits/timeout hardening. | Mitigated in Phase 02: server parser limits/timeouts + client `ReadExact`; real-client activation smoke remains required before release. | Phase 02 |
| R-006 | P1 | SQLite schema не имеет полноценной migration/transaction/state модели. | Mitigated in Phase 03: schema_version migrations, WAL/foreign_keys/busy_timeout, transaction helper, password hash migration. Pending state semantics continue in Phase 04. | Phase 03 |
| R-007 | P1 | `device_limit` в CLI/schema должен совпадать с фактической политикой лицензий. | Mitigated in Phase 03: `device_limit` now controls distinct active machines; default remains 1. | Phase 03 |
| R-008 | P1 | Нет CI/CD gates для server tests, client tooling, secret scan и release checks. | Partially mitigated in Phase 06: добавлены GitHub Actions для license-server, Windows client-core build и secret scan; нужен первый зелёный GitHub run после PR. | Phase 06 |
| R-009 | P0 | Корневые `ZTool.exe`/`ZTool.dll` не совпадают с live-tested recommended artifacts. | Mitigated in Phase 10: root `ZTool.exe` replaced with live-tested `ZTool_binderfix.exe` (`0BF4CB0B...9955864B`), root `ZTool.dll` replaced with `pmpguard2` (`D0535425...0E492EB9`), and release packager now uses root runtime artifacts by default. Final SolidWorks acceptance still required on the release package. | Phase 10 |
| R-010 | P1 | Release package не имеет manifest/SHA256SUMS и reproducibility gate. | Mitigated in Phase 06/08/10: добавлен `tools/release_manifest.py`; client-core build проверяет input hashes и пишет `ZTool.manifest.json`; release package script создаёт `manifest.json` и `SHA256SUMS.txt`. Финальный manual acceptance still required. | Phase 08, Phase 10 |
| R-011 | P2 | Localization binary patch pipeline требует machine-readable scan/whitelist/screenshot gates. | Partially mitigated in Phase 07: добавлены JSON scan, whitelist policy, translation validator и UI screenshot checklist. Manual screenshot evidence remains required for release. | Phase 07 |
| R-012 | P2 | SolidWorks manual smoke не автоматизирован и зависит от рабочей Windows/SW машины. | Accepted, documented | Cross-phase |
| R-013 | P1 | Cleaned production profile/package can lose the default material library and material-color behavior (`materialpath` empty, `usematerialcolor=false`, missing `SolidWorksTemplates`). | Mitigated in Phase 10 follow-up: release package copies `SolidWorksTemplates/`, normalizes `materialpath` to packaged `MyMaterials.sldmat`, restores `usematerialcolor=true`, and verifier fails if the material library gate is broken. Manual SolidWorks material/color smoke remains required. | Phase 10 |
| R-014 | P1 | Ops CLI может игнорировать `ZTOOL_*` env и писать/читать не ту DB/keys location; abuse fail2ban может не видеть wrong-password/invalid attempts. | Mitigated in prod-readiness follow-up: CLI management commands use `ServerConfig.from_env()` with CLI flags as overrides; keygen can write explicit env key files; server emits redacted journal `security event` warnings for wrong password / invalid code / invalid machine code. | Production readiness |
| R-015 | P1 | BOM export маппинг опирался на китайские defined names в шаблоне и `mappingname` в `SWTools.settings` (два рассинхронизированных набора), окно «Сопоставление» показывало только 2 расчётные колонки, кнопка «Импорт…» уплывала на resizable-форме, а десериализация конфигурации падала `System.Object из ZTool…`. | Mitigated in Phase 11: шаблон и settings переведены на единый русский набор anchors (китайский удалён полностью, включая legacy-токены фильтров `机加`/`外购`); `check_bom_template.py` подтверждает консистентность; Localizer расширяет «Сопоставление» на все `Col_*` и фиксирует якорь кнопки `Bottom\|Left`; VTBinder толерантно резолвит embedded assembly identity. Финальный SolidWorks-smoke на машине с SW 2025 по ТЗ остаётся обязательным. | Phase 11 |

## Правила обновления

- Каждый PR hardening-фазы должен обновлять этот register, если меняет риск.
- Нельзя закрывать риск без ссылки на тест/отчёт/коммит.
- Если риск переносится, нужен явный `Deferred until Phase XX` и причина.
