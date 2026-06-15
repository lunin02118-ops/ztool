# Phase 02 implementation report — TCP protocol hardening

## Scope

Phase 02 усиливает transport layer сервера лицензий и клиентский TCP receive
path. Цель: malformed/oversized frames, partial reads и timeout abuse не должны
держать соединение бесконечно или приводить к неограниченному росту буфера.

Эта ветка перебазирована на `main` после merge PR #13.

## Changed files

- `license-server/ztool_license_server/config.py`
- `license-server/ztool_license_server/protocol/framing.py`
- `license-server/ztool_license_server/protocol/dispatcher.py`
- `license-server/ztool_license_server/server.py`
- `license-server/tests/test_protocol.py`
- `license-server/tests/test_protocol_limits.py`
- `client-core/src/TCPClient.cs`
- `license-server/README.md`
- `docs/production/RISK_REGISTER_RU.md`
- `docs/audit/phase-02-protocol-hardening-implementation-report.md`

## Behavior changes

Server:

- Добавлены лимиты:
  - `max_body_size` / `ZTOOL_MAX_BODY_SIZE`, default `2 MiB`;
  - `max_frames_per_connection` / `ZTOOL_MAX_FRAMES_PER_CONNECTION`, default `16`;
  - `read_timeout_seconds` / `ZTOOL_READ_TIMEOUT_SECONDS`, default `10`;
  - `idle_timeout_seconds` / `ZTOOL_IDLE_TIMEOUT_SECONDS`, default `30`.
- `FrameParser` больше не использует `assert` для untrusted input.
- `body_len < 0` => `InvalidFrame`.
- `body_len > max_body_size` => `FrameTooLarge`.
- unknown request `sendtype` в server mode => `InvalidFrame`.
- parser buffer ограничен `20 + max_body_size`.
- `_handle_client` закрывает соединение при protocol error/timeout/frame-limit
  без stack trace для клиента.

Client:

- `TCPClient.getreceive()` больше не предполагает, что один `Receive()` вернёт
  весь header/body.
- Exact-read логика встроена прямо в существующий `getreceive()`, без добавления
  нового метода. Это важно для текущего Reinjector: он переносит тела
  существующих методов, но не добавляет новые методы в target exe.
- Response body проверяется: `0 <= len <= 10 MiB`.
- Blind preallocation `byte[10485760]` заменена на точный body buffer.

## Backward compatibility

- Формат frame `[type:10][length:10][body]` не менялся.
- Response result-code semantics не менялись.
- Legacy activation integration tests проходят без изменений.
- Клиентский `getreceive()` сохраняет прежнюю сигнатуру.

## Commands run

```powershell
cd D:\Development\ztool\repo-main\license-server
python -m pytest -q --color=no

cd D:\Development\ztool\repo-main\client-core
$env:PATH='D:\Development\ztool\.dotnet;' + $env:PATH
.\build.ps1

dotnet run -c Release --project tools\Reinjector -- --verify out\ZTool.exe

cd D:\Development\ztool\repo-main
git diff --check --color=never origin/main...HEAD
```

## Test results

- `python -m pytest -q --color=no`: `84 passed, 2 skipped`.
- `client-core\build.ps1`: PASS.
  - `ZTool.Core.csproj`: build succeeded, `0` warnings, `0` errors.
  - Reinjector: `methods replaced=31 skipped(extern)=3`.
  - BinderInject verify: `VERIFY: PASS`.
  - Final output: `client-core\out\ZTool.exe`.
- `dotnet run -c Release --project tools\Reinjector -- --verify out\ZTool.exe`:
  `dangling typerefs = 0`.
- `git diff --check --color=never origin/main...HEAD`: PASS, no output.
- Changed-file secrets scan: no forbidden secret-like filenames and no
  high-confidence secret pattern matches.

Pre-fix validation note: full `client-core\build.ps1` emitted
`! no target method TCPClient::ReadExact`, proving that adding a new helper
method was not safe for the current Reinjector. The helper was removed and the
exact-read loop was kept inside `getreceive()`.

## Security notes

- `R-005` mitigated at code/test level.
- Сервер больше не ждёт бесконечно тело oversized/partial frame.
- Unknown sendtype и malformed header закрывают соединение fail-closed.

## Manual checks

Перед production release всё равно нужен real-client smoke:

- activation online;
- register confirm;
- transfer out/confirm;
- сетевой ответ, разбитый на несколько TCP-сегментов.
- SolidWorks/runtime smoke of the rebuilt `client-core\out\ZTool.exe`.

## Rollback plan

Откатить PR Phase 02. Сервер вернётся к старому permissive parser, клиентский
`getreceive()` вернётся к старой receive-loop логике. Формат данных и БД не
меняются, миграция данных не требуется.

## Known limitations

- Client-side partial-response unit harness пока не добавлен: полный
  `client-core\build.ps1` и `Reinjector --verify` проходят, но socket-level
  тест живого `TCPClient` остаётся manual/Phase 06.
- Значения лимитов выбраны консервативно и могут быть уточнены после
  production traffic наблюдений.
