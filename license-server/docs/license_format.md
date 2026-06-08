# Формат лицензионного блоба и реестра ZTool (Фазы 5–7)

Документ описывает «ground truth», извлечённый декомпиляцией де-обфусцированного
клиента ZTool (методы `SR.IsReg1`, `SR.IsReg2`, `FrmRg.rg`, `FrmRg.Decryptstr`,
`SecurityCenter.EncriptStr/DecriptStr`, `RSAHelper.Encrypt/DecryptString`). На
его основе реализована серверная генерация лицензии (`license_blob.py`).

> ⚠️ Эталоны получены статическим анализом. Байтовая совместимость с
> неизменённым оригинальным клиентом подтверждается только на стенде с
> установленным ZTool (отдельный шаг).

## Криптопримитивы

| Примитив | Параметры |
|----------|-----------|
| RSA-1024 | без паддинга; строка делится по **128 символов**, каждый блок кодируется `Encoding.Default` (cp936); шифроблоки — HEX (upper), разделитель `@`. Подпись — закрытым ключом, проверка — открытым. |
| AES-128-CBC | `key = iv = MD5(passphrase, Encoding.Unicode)`; **открытый текст — UTF-16LE**; результат — Base64. |
| DES-CBC | `desKey = 37 17 0D 31 48 39 34 08`, `desSIV = 27 22 1C 21 4B 4D 52 02`; вход — UTF-8; результат — Base64. Только офлайн-активация. |

## AES-фразы (из строк клиента)

| Назначение | Фраза |
|------------|-------|
| `getver("今天。。。")` транспортного слоя | `<версия> (x64)` / `(x86)` |
| IsReg1 | `来生缘。。。` |
| GetMNum | `忘情水。。。` |
| общая | `冰雨。。。` |

## Ветки реестра (порядок == порядок `"\t"`-склейки в `rg()`)

| # | Ключ | Значение | first_len |
|---|------|----------|-----------|
| b0 | `Software\SolURxxCfNU\C4eHN4fjikBan` | `information` | — (без обёртки) |
| b1 | `SOFTWARE\Microsoft\MzORu8qE4HhZ\Jlj4aG8uZBvW` | `F2S6qCdziIAm` | 7 |
| b2 | `Software\SolURxxCfNU\HTwk2RCBDL` | `information` | 9 |
| b3 | `SOFTWARE\Microsoft\MzORu8qE4HhZ\98CqyvBZcg` | `information` | 9 |

Обёртка ветки: `b = prefix(first_len) + AES_ciphertext + suffix(10)`, где
`passphrase = suffix + prefix` (длина `first_len + 10`). IsReg1 восстанавливает:
`pp = Right(b,10) + Left(b,first_len)`, `ct = b.Substring(first_len, Len(b)-first_len-10)`.

## Транспортный слой

```
transport = AES_encrypt( "\t".join([b0, b1, b2, b3]),  passphrase = getver_today )
```

- Онлайн: возвращается в ответе REGISTER (`Sendtype 130`) как `SUCCESS\n<transport>`.
- Офлайн: `файл = Base64( DES_encrypt(transport) )`; `FrmRg.Decryptstr` снимает DES, далее общий `rg()`.

## Состав веток (инверсия IsReg1)

```
seed_F                — случайный сеанс-ключ (passphrase для AES внутри блоба)
dyn_key               — ComponentKey (открытый ключ), по умолчанию = серверный pub

b1 = wrap7(  AES( RSA_sign(seed_F) + "\n" + AES(dyn_key, seed_F),  pp_b1 )  )
b2 = wrap9(  AES( RSA_sign(mc_half1),  pp_b2 )  )
b3 = wrap9(  AES( RSA_sign(mc_half2),  pp_b3 )  )
b0 =          AES( RSA_sign(uuid36) + "\n" + RSA_sign(AES(machine_code, seed_F)) + "\n" + RSA_sign(reg_time),  seed_F )
```

### Проверки IsReg1 (что обязан удовлетворять блоб)

1. `len( RSA_decrypt(b0[0], dyn_key) ) == 36` — UUID оборудования.
2. `RSA_decrypt(b0[1], dyn_key)` → `AES_decrypt(.., seed_F) == GetMNum() == machine_code`.
3. `Concat(b2_dec, b3_dec) == machine_code` (две половины кода машины).
4. `ToDouble( RSA_decrypt(b0[2], dyn_key) ) != 0` — время регистрации (OADate).

Эмулятор всех проверок — `tests/test_license_blob.py::emulate_isreg1`.

## CLI офлайн-активации

```bash
python -m ztool_license_server.cli keygen --dir keys
python -m ztool_license_server.cli offline-activate "<MACHINE_CODE>" --out activation.lic
```
