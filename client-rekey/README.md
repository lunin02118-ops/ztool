# Перевыпуск клиента SWTools под наш сервер лицензирования

Этот каталог содержит инструмент и исходные данные для **перевыпуска
де-обфусцированного `SWTools.exe`** (из ветки русификации) так, чтобы клиент
работал с нашим сервером лицензий вместо вендорского.

## Что меняется в `SWTools.exe`

Патчер (`Program.cs`, на базе [dnlib](https://github.com/0xd4d/dnlib))
правит готовую сборку на уровне IL, без перекомпиляции исходников:

1. **Публичный RSA-ключ (ComponentKey).** Все вхождения вендорского ключа
   `AwEAAZ5q…Wyshir` (строки `ldstr`) заменяются на наш серверный публичный
   ключ `AwEAAaw…Ty8An`. Длина обоих ключей одинакова (176 символов Base64,
   RSA-1024, exp `010001`, 128-байтовый модуль). Найдено и заменено **18**
   вхождений (createinfo / IsReg1 / IsReg2 / Decrypt / TCPClient и т.д.).

2. **Адрес сервера.** В `TCPClient.Connect()` адрес и порт хранятся как
   RSA-зашифрованные hex-константы, которые клиент расшифровывает своим
   публичным ключом:
   ```csharp
   IPAddress address = IPAddress.Parse(RSAHelper.DecryptString(ip_address, ключ));
   int port          = Convert.ToInt32(RSAHelper.DecryptString(ip_port,    ключ));
   ```
   Старые константы (вендорский `120.78.215.80:58000`) заменены на новые,
   зашифрованные **нашим приватным ключом** под значения
   `<LICENSE_SERVER_IP>` и `58000`. Проверено: расшифровка нашим публичным
   ключом (то, что делает клиент) возвращает ровно этот IP и порт.

3. **Версия.** Клиент берёт `Application.ProductVersion` (+ `" (x64)"`) для
   вычисления транспортного пароля `getver = MD5(версия + " (x64)")`. Раньше
   `AssemblyFileVersion = 3.8.4`. Проставлены `AssemblyInformationalVersion = "1.0"`
   (его WinForms читает в первую очередь) и `AssemblyFileVersion = "1.0"`, чтобы
   `ProductVersion == "1.0"` и совпадал с `client_version` сервера.

## Исходные/новые значения

| Файл | Содержимое |
|------|-----------|
| `orig_key.txt` / `new_key.txt`   | вендорский / наш публичный ключ |
| `orig_ip.txt`  / `new_ip.txt`    | hex адреса (старый / новый, под наш публичный ключ) |
| `orig_port.txt`/ `new_port.txt`  | hex порта (старый / новый) |

`new_ip.txt` / `new_port.txt` — это **шифртекст** (подпись), а не приватный
ключ. Но это operational rekey input material, поэтому P4 repo hygiene policy
требует хранить эти файлы вне Git:

```text
_local_artifacts\secrets\client-rekey\
```

В репозитории остаются только код патчера и документация. Регенерация входных
файлов выполняется на сервере/машине, где лежит приватный ключ:
```python
from swtools_license_server.crypto.rsa_swtools import sign_string, decrypt_string
priv = open("keys/private_key.txt").read().strip()
pub  = open("keys/public_key.txt").read().strip()
ip   = sign_string("<LICENSE_SERVER_IP>", priv)
port = sign_string("58000", priv)
assert decrypt_string(ip, pub)  == "<LICENSE_SERVER_IP>"
assert decrypt_string(port, pub) == "58000"
```

## Как собрать перевыпущенный `SWTools.exe`

Нужен .NET SDK. Вход — де-обфусцированный `SWTools.exe` из ветки русификации.

```bash
dotnet build patcher.csproj -c Release -o bin
dotnet bin/patcher.dll <вход SWTools.exe> <выход SWTools.exe> ..\_local_artifacts\secrets\client-rekey
```

Патчер печатает счётчики замен и **прерывается, если что-то не найдено**
(`keyHits/ipHits/portHits` должны быть > 0). Ожидаемо:
`keyHits=18 ipHits=2 portHits=2 fileVerUpdated=True infoVerAdded=True`.

## Проверка

- Статически: в перевыпущенной сборке нет вендорского ключа/адреса; наш ключ
  ×18, новый ip/port ×2; версия `1.0`.
- Криптографически: `new_ip`/`new_port` расшифровываются нашим публичным
  ключом в `<LICENSE_SERVER_IP>` / `58000` (тем же алгоритмом, что проходит
  живые тесты сервера).
- **Остаётся проверить на машине с SolidWorks** (фаза 10): что перевыпущенная
  сборка корректно грузится надстройкой и проходит полный цикл активации.
  Надстройка `SWTools.dll` в ветке русификации **не** распаковывалась и здесь
  не перевыпускается.
