# ZTool License Server (Сценарий B)

Сервер активации лицензий ZTool — замена оригинального китайского сервера (`120.78.215.80:58000`).

## Архитектура

```
[ Пересобранный клиент с НАШИМ открытым ключом ]
        │  TCP (порт 58000), кадр [тип:10][длина:10][AES-Base64 тело]
        ▼
[ Наш сервер активации ]  --(подпись НАШИМ закрытым ключом)-->  лицензионный блоб
        │
        └── БД (SQLite): коды, привязки устройств, лимиты, сроки, переносы
```

## Компоненты

- `crypto/rsa_ztool.py` — RSA-1024 без паддинга, совместимая с `ZTool_rsa.dll`
- `crypto/aes_security_center.py` — AES-128-CBC совместимый с `ZTool.SecurityCenter`
- `crypto/des_offline.py` — DES для офлайн-активации
- `crypto/keygen.py` — Генерация ключевой пары в формате `ComponentKey`
- `protocol/framing.py` — Кадрирование TCP: [type:10 LE][len:10 LE][body]
- `protocol/dispatcher.py` — Диспетчер `Sendtype` (128-132)
- `server.py` — TCP-сервер (asyncio)
- `db.py` — SQLite-хранилище лицензий
- `config.py` — Конфигурация

## Запуск

```bash
python -m ztool_license_server.server --port 58000
```

Production-safe запуск:

```bash
export ZTOOL_RUNTIME_ENV=production
export ZTOOL_LOG_LEVEL=INFO
export ZTOOL_PRIVATE_KEY_FILE=/etc/ztool-license/private_key.txt
export ZTOOL_PUBLIC_KEY_FILE=/etc/ztool-license/public_key.txt
export ZTOOL_DB_PATH=/var/lib/ztool-license-server/licenses.db
export ZTOOL_MAX_BODY_SIZE=2097152
export ZTOOL_MAX_FRAMES_PER_CONNECTION=16
export ZTOOL_READ_TIMEOUT_SECONDS=10
export ZTOOL_IDLE_TIMEOUT_SECONDS=30
python -m ztool_license_server.server
```

В production `DEBUG` запрещён по умолчанию: сервер завершит старт, если
`ZTOOL_RUNTIME_ENV=production` и `ZTOOL_LOG_LEVEL=DEBUG`. Временный аварийный
режим включается только явно через `ZTOOL_ALLOW_DEBUG_LOGGING=1`; даже в этом
режиме расшифрованные protocol payload в application log не пишутся.

Ключи можно хранить как раньше в `ZTOOL_KEYS_DIR`, но для production
предпочтительны явные пути `ZTOOL_PRIVATE_KEY_FILE` и `ZTOOL_PUBLIC_KEY_FILE`.
На Unix private key в production должен иметь права `0600` или строже.

Генерация ключей:

```bash
python -m ztool_license_server.cli keygen --dir /etc/ztool-license
```

По умолчанию создаются только `public_key.txt` и `private_key.txt`.
Диагностический `keypair_info.json` с приватными компонентами пишется только
по явному флагу `--write-debug-key-info` и не предназначен для production.

## TCP protocol limits

Сервер fail-closed обрабатывает malformed/oversized кадры:

- `ZTOOL_MAX_BODY_SIZE` — максимум тела запроса, по умолчанию `2097152`.
- `ZTOOL_MAX_FRAMES_PER_CONNECTION` — максимум кадров на одно TCP-соединение,
  по умолчанию `16`.
- `ZTOOL_READ_TIMEOUT_SECONDS` — тайм-аут ожидания продолжения частичного
  кадра, по умолчанию `10`.
- `ZTOOL_IDLE_TIMEOUT_SECONDS` — тайм-аут простоя соединения без данных, по
  умолчанию `30`.

Отрицательная длина, неизвестный `sendtype`, тело больше лимита и переполнение
буфера закрывают соединение без stack trace для клиента.

## Привязка к оборудованию (валидация машинного кода)

Активация **жёстко привязывается к железу**. Сервер принимает заявку только если
машинный отпечаток клиента начинается с настоящего 36-символьного GUID (как его
формирует `SR.GetUUID` и требует `IsReg1`). Пустой или «мусорный» отпечаток
(например, хост без UUID или строка вроде `x`) отклоняется кодом `6`
(`注册信息错误` — «Ошибка в сведениях о регистрации») и **не занимает место
лицензии**. Это закрывает дыру, при которой сервер выдавал лицензию на любой/пустой
машинный код, а место в лимите при этом расходовалось.

Очистить уже занятые «битые» привязки (с пустым/невалидным `machine_code`) в
существующей БД:

```bash
python -m ztool_license_server.cli purge-invalid          # --db <path> при необходимости
python -m ztool_license_server.cli list-activations       # проверить результат
```

## Правовое замечание

Сервер предназначен для миграции СОБСТВЕННОЙ инфраструктуры лицензирования
при наличии прав на продукт ZTool или разрешения правообладателя.
