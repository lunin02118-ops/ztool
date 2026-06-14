# Phase 02 implementation report — TCP protocol hardening

## Scope

Phase 02 усиливает transport layer сервера лицензий и клиентский TCP receive
path. Цель: malformed/oversized frames, partial reads и timeout abuse не должны
держать соединение бесконечно или приводить к неограниченному росту буфера.

Эта ветка сделана поверх Phase 01 (`hardening/01-secrets-logging` / PR #13),
чтобы продолжить работу без ожидания merge. Перед финальным merge её нужно
ребейзнуть на `main`, если Phase 01 уже будет слита.

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
- Добавлен `ReadExact(Socket, len, timeoutMs)`.
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
python -m pytest -q

cd D:\Development\ztool\repo-main\client-core
D:\Development\ztool\.dotnet\dotnet.exe build -c Release ZTool.Core.csproj

cd D:\Development\ztool\repo-main
git diff --check
```

## Test results

- `python -m pytest -q`: `84 passed, 2 skipped`
- `D:\Development\ztool\.dotnet\dotnet.exe build -c Release ZTool.Core.csproj`:
  build succeeded, `0` warnings, `0` errors.
- `git diff --check`: PASS; только Windows warning о будущей замене LF на CRLF.

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

## Rollback plan

Откатить PR Phase 02. Сервер вернётся к старому permissive parser, клиентский
`getreceive()` вернётся к старой receive-loop логике. Формат данных и БД не
меняются, миграция данных не требуется.

## Known limitations

- Client-side partial-response unit harness пока не добавлен: C# source
  собирается, но socket-level тест живого `TCPClient` остаётся manual/Phase 06.
- Значения лимитов выбраны консервативно и могут быть уточнены после
  production traffic наблюдений.
