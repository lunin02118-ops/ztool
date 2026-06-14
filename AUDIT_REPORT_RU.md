# Отчет аудита ZTool: русификация и сервер лицензирования

Дата проверки: 2026-05-30

> **Документ исторический.** Зафиксировано состояние **до** PR #8. Утверждение
> «код не изменялся» относится к этому аудиту, а не к текущему репозиторию:
> после слияния PR #8 (merge `78e679c`) бинарники `ZTool.exe`/`ZTool.dll`
> обновлены. Текущий статус — в разделе [«Актуализация (PR #8)»](#актуализация-pr-8)
> в конце файла. Сводный указатель документации: [`docs/INDEX.md`](docs/INDEX.md).

## Краткий итог

Проведен аудит текущего пакета ZTool, PR-веток с русификацией и сервером лицензирования, а также боевое тестирование уже развернутого TCP-сервера лицензий.

Код в рамках проверки не изменялся. Выполнялись только чтение, запуск тестов, SSH-инвентаризация сервера и сетевой TCP-smoke через реальный порт лицензирования.

Итог по серверу лицензирования: боевой TCP-сервис работает, принимает корректную активацию, отклоняет неверный код, возвращает валидный license blob и проходит цикл переноса лицензии.

Итог по SolidWorks 2025: SolidWorks 2025 установлен, ZTool add-in зарегистрирован и включен на автозагрузку, но автоматический COM-запуск SolidWorks в текущей среде завис более чем на 120 секунд. Полный UI-тест внутри SolidWorks 2025 не подтвержден.

## Проверенная среда

### Локальная машина

- Репозиторий: `D:\Development\ztool\ZTool-original`
- SolidWorks: `C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SLDWORKS.exe`
- Версия SolidWorks: `33.3.0.0092` (SolidWorks 2025)
- ZTool.exe: версия `3.8.4`
- ZTool.dll: версия `1.8.3.0`

### Сервер лицензирования

- Сервис: `ztool-tcp-server.service`
- Рабочая директория: `/opt/ztool-tcp-server`
- Запуск: `/opt/ztool-tcp-server/.venv/bin/python -m ztool_license_server`
- Порт: `58000`
- Bind: `0.0.0.0`
- БД: `/opt/ztool-tcp-server/licenses.db`
- Статус systemd: `active (running)`

## Локальные тесты Python

После установки недостающих зависимостей (`pluggy`, `iniconfig`, `pytest-asyncio`) были запущены не-сетевые тесты сервера лицензирования:

```text
39 passed, 1 skipped
```

Покрытие этого прогона:

- RSA-compatible crypto
- AES/DES helpers
- license blob generation
- SQLite DB logic
- machine id parsing
- protocol framing

Полный локальный async/TCP pytest изначально блокировался состоянием Windows Winsock/Python `asyncio`. Для боевого теста был использован реальный VPS и live TCP-сервис.

## Боевой TCP-тест сервера лицензий

Тест выполнялся против реального сервиса на порту `58000`, а не против in-process mock.

### Сценарий 1: неверный код

Ожидаемо отклонен:

```text
BAD_CODE_RESULT 1
BODY_LEN 0
```

В audit log сервера появилась запись:

```text
action=apply_register
result=rejected
details=无效注册码
```

### Сценарий 2: apply_register

Корректный тестовый код принят:

```text
APPLY_RESULT 13
BLOB_LEN 14808
```

License blob был расшифрован и проверен:

```text
BLOB_MACHINE_HASH 04954FDA2FE12FA38F180E15F18C5CFA
EXPECTED_HASH     04954FDA2FE12FA38F180E15F18C5CFA
```

Это подтверждает, что сервер выдал blob, привязанный к ожидаемому machine fingerprint.

### Сценарий 3: register_confirm

Финальный confirm прошел:

```text
CONFIRM_RESULT 12
LIVE_TCP_TEST_OK
```

### Сценарий 4: перенос лицензии

Проверен полный цикл переноса:

```text
APPLY_REMOVE_RESULT 11
REMOVE_CONFIRM_RESULT 7
REAPPLY_RESULT 13
LIVE_TRANSFER_CYCLE_OK
```

В БД после цикла активная запись была пересоздана для тестового machine code.

## SolidWorks 2025 / ZTool

### Что подтверждено

SolidWorks 2025 установлен:

```text
SLDWORKS.exe
ProductVersion: 33.3.0.0092
```

ZTool add-in зарегистрирован:

```text
CLSID: {59959DFA-3229-4B86-852E-52ABF2BDB8C0}
Title: ZTool
Description: ZTool - инструменты для SolidWorks
AddInsStartup: 1
```

### Что не подтверждено

Автоматический COM smoke-test:

```powershell
New-Object -ComObject SldWorks.Application
```

не завершился за 120 секунд. После таймаута активного `SLDWORKS.exe` процесса не было, оставался только `sldworks_fs.exe`.

Вывод: наличие SW 2025 и регистрация add-in подтверждены, но полноценный запуск UI/ZTool внутри SolidWorks 2025 требует отдельной ручной проверки в интерактивной сессии.

## Архитектура лицензирования по PR #4

Ключевой поток:

1. TCP frame: `[type:10 LE][len:10 LE][body]`
2. Body: AES Base64, passphrase = строка sendtype (`"128"`, `"131"`, ...)
3. Request fields: RSA-encrypted lines
4. Server:
   - decrypt body
   - decrypt RSA fields
   - validate code/password
   - bind machine code
   - generate license blob
5. Client receives numeric result code:
   - `13`: apply accepted
   - `12`: final registration success
   - `11`: transfer-out accepted
   - `7`: transfer done

Критичные файлы:

- `license-server/ztool_license_server/server.py`
- `license-server/ztool_license_server/db.py`
- `license-server/ztool_license_server/license_blob.py`
- `license-server/ztool_license_server/protocol/framing.py`
- `license-server/ztool_license_server/protocol/dispatcher.py`
- `license-server/ztool_license_server/crypto/rsa_ztool.py`
- `license-server/ztool_license_server/crypto/aes_security_center.py`

## Найденные риски

### 1. Сервер допускает активацию с пустым machine code

В боевой БД обнаружена активная запись лицензии с пустым `machine_code`.

Это опасно по двум причинам:

- сервер считает место лицензии занятым;
- клиентская проверка лицензии, по описанию в `license_blob.py`, требует непустой machine code.

В коде `server.py` machine code восстанавливается так:

```text
machine_field = parts[2] if len(parts) > 2 else ""
machine_code = recover_raw_machine(machine_field, ...)
success, error = self.db.activate(reg_code, machine_code)
```

Явной серверной проверки `machine_code != ""` перед `activate()` нет.

### 2. DEBUG-логирование включено на боевом сервисе

В systemd drop-in включено:

```text
Environment=ZTOOL_LOG_LEVEL=DEBUG
```

В `server.py` есть debug-лог входящего plaintext:

```text
logger.debug("Received type=%d, body=%s", sendtype, plaintext[:100])
```

Это может раскрывать части регистрационных запросов в journal. Для production лучше выключить DEBUG.

### 3. RSA без padding и AES-CBC с IV=key

В коде прямо зафиксировано:

```text
rsa_ztool.py: No padding (textbook RSA)
aes_security_center.py: iv = key
```

Это сделано ради совместимости с оригинальным клиентом, но криптографически слабее современных схем. Менять это без изменения клиента нельзя, но риск надо учитывать.

### 4. register_confirm не связывается с кодом/активацией

`register_confirm` принимает первые 4 непустые строки, шифрует их и возвращает result `12`.

Из-за протокола это совместимо с клиентом, но серверная сторона не проверяет, что confirm относится к последнему apply для того же кода/machine. Это стоит учитывать при дальнейшей защите production.

### 5. SolidWorks UI smoke не завершился

ZTool add-in зарегистрирован, но автоматический запуск SolidWorks 2025 через COM завис. Это не доказывает поломку ZTool, но оставляет непокрытым главный пользовательский сценарий внутри SW 2025.

## Вывод

Сервер лицензирования на реальном VPS работает и прошел live TCP-тесты:

- invalid code reject;
- apply register;
- license blob machine binding verification;
- register confirm;
- transfer-out;
- remove confirm;
- re-apply.

Главный технический риск сейчас не в TCP-сервере как таковом, а в production-hardening:

- запрет пустого machine code;
- выключение DEBUG-логирования;
- проверка связности confirm с apply;
- полный ручной UI-тест ZTool внутри SolidWorks 2025.

## Актуализация (PR #8)

Дата: 2026-06-14. PR #8 слит в `main` (merge `78e679c`, родители `1cb83bd` + `12de27f`).

В отличие от исходного аудита (где «код не изменялся»), в рамках PR #8 бинарники
**были изменены** и проверены живыми ретестами в SolidWorks 2025 на сборке
`0614-A00.SLDASM` (8/8 режимов BOM, copy/paste). Закрыты три фронта:

1. **Шаблоны/экспорт BOM** — Arial, русификация, корректные имена столбцов; 8/8 режимов PASS.
2. **`pmpguard2`** в `ZTool.dll` — снята гонка инициализации (модальное окно
   «Ссылка на объект не указывает на экземпляр…»).
3. **`binderfix`** в `ZTool.exe` — защита небезопасной десериализации:
   `VTBinder` (version-tolerant привязка типов в конфиге — шрифт/цвет, таблица
   автозаполнения) + `SafeListBinder` (allow-list при вставке из буфера обмена:
   только `List<string>`/`string`/`string[]`, остальное отклоняется).

Уточнение по «варианту E» (сетевой BinaryFormatter): живого сетевого стока нет —
лиценз-клиент работает по строковому протоколу с RSA/AES-шифрованием, без
Remoting/`BinaryFormatter` на недоверенных байтах. Единственной реальной точкой
небезопасной десериализации был буфер обмена; он закрыт `SafeListBinder`.

**Рекомендуемая связка для деплоя (обе retested GREEN):**

| Модуль      | Версия      | SHA256 (начало)     |
|-------------|-------------|---------------------|
| `ZTool.exe` | `binderfix` | `0BF4CB0B…9955864B` |
| `ZTool.dll` | `pmpguard2` | `D053542…92EB9`     |

Подробности и журналы ретестов: [`manual-test-reports/SUMMARY.md`](manual-test-reports/SUMMARY.md),
[`manual-test-reports/PR8_BOM_LIVE_TEST_20260612.md`](manual-test-reports/PR8_BOM_LIVE_TEST_20260612.md).

Риски по серверу лицензий из этого отчёта (пустой machine code, DEBUG-логирование,
связность confirm/apply) к PR #8 не относятся и остаются открытыми (production-hardening).

