# Threat model ZTool production

## Assets

- RSA private signing key сервера лицензий.
- RSA public key, встроенный в клиент.
- SQLite license DB: license codes, password hashes, activations, pending state,
  audit log.
- License codes и optional protection passwords.
- Machine fingerprints клиентов.
- Release binaries: `ZTool.exe`, `ZTool.dll`, settings, server package.
- Admin/operator SSH доступ к VPS и GitHub repository access.
- Backups БД и key backups.

## Trust boundaries

- Клиент недоверенный: пользователь может модифицировать exe, повторять старые
  пакеты, слать raw TCP frames.
- TCP network недоверенная: порт 58000 может получать malformed/oversized
  frames и brute-force попытки.
- Server process trusted только если VPS, OS user, key files и deploy pipeline
  защищены.
- SQLite DB trusted только при корректных file permissions, backups и restore
  drill.
- GitHub repository trusted только для source/build metadata. Private keys,
  production DB и dumps не должны попадать в git.

## Attackers

- Random internet scanner на TCP 58000.
- Пользователь с валидным кодом, пытающийся активировать больше устройств.
- Пользователь, replaying old `register_confirm` / `remove_confirm` packets.
- Пользователь с modified client, который пытается обойти UI checks.
- Operator mistake: неправильный env, DEBUG logs, не тот binary artifact.
- Leaked private key или leaked SSH deploy key.

## Threats and mitigations

| Threat | Mitigation |
| --- | --- |
| Replay confirm | Phase 04 pending activation/transfer state + TTL + branch hash |
| Device limit bypass | Phase 03 distinct active machine count by `device_limit` |
| Empty/fake machine code | Machine GUID validation before activation |
| Wrong password brute force | Audit rows + Phase 05 fail2ban/firewall policy |
| Oversized/malformed TCP frames | Phase 02 parser limits, timeouts, unknown sendtype rejection |
| Plaintext payload in logs | Phase 01 redaction and production DEBUG fail-closed |
| Private key in repo/package | `.gitignore`, secret scan, explicit key paths, keygen safe defaults |
| Hot SQLite copy corruption | Phase 05 SQLite backup API and verify-backup |
| Wrong binary input | Phase 08 build input SHA256 gate |
| Lost PublicKeyToken | Phase 08 manifest and PublicKeyToken policy |

## Residual risks

- Legacy protocol uses weak/old primitives for compatibility: RSA-1024 without
  modern padding and fixed passphrase-derived AES/DES flows. Do not market this
  as modern cryptographic protection.
- Client remains untrusted. Server-side state is authoritative, but a modified
  client can bypass local UI/trial behavior.
- `remove_confirm` legacy payload does not carry code/machine; server uses the
  strongest compatible binding available from Phase 04.
- Rate limiting is currently perimeter-based (firewall/fail2ban), not an
  in-process token bucket.
- Manual SolidWorks smoke is still required before production release.

## Incident response

1. Preserve evidence: copy service logs, audit DB backup, current release
   manifest, running service env.
2. Stop or firewall the service if active exploitation is suspected.
3. If private key leak is possible, follow `KEY_COMPROMISE_RUNBOOK_RU.md`.
4. If abuse/brute force, follow `ABUSE_RATE_LIMIT_POLICY_RU.md`.
5. Do not edit production DB manually before taking backup.
6. Record incident timeline and postmortem in `docs/audit/` or issue tracker.
