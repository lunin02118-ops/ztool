# Client-core binary build policy

`client-core/build.ps1` редактирует legacy `ZTool.exe` через binary
reinjection. Для production это должно быть fail-closed.

## Входы сборки

Файл `client-core/build-inputs.json` фиксирует SHA256:

- `ZTool-base.exe` - pristine re-keyed build input;
- `client-core/ref/ZTool.public.dll` - publicized compile-time reference;
- `client-core/ref/ZTool_rsa.dll` - RSA helper reference;
- `client-core/tools/Localizer/translations.tsv` - таблица переводов.

Без `-AllowUnknownInputs` build падает, если вход отсутствует или SHA256 не
совпадает.

```powershell
cd client-core
.\build.ps1
```

Для исследовательской сборки с другими входами:

```powershell
.\build.ps1 -AllowUnknownInputs -BaseExe D:\scratch\ZTool-base.exe
```

Такой output нельзя считать production candidate без нового manifest/audit.

## Output manifest

После успешного build создаётся:

```text
client-core/out/ZTool.manifest.json
```

В manifest фиксируются:

- git commit/branch/dirty;
- SHA256 всех входов;
- SHA256 `client-core/out/ZTool.exe`;
- `PublicKeyToken`;
- Win32 file/product version;
- `Reinjector --verify` exit code и dangling refs.

## PublicKeyToken policy

`PublicKeyToken` нельзя терять. SolidWorks add-in IPC сверяет token в
рукопожатии `ZToolRequest@001`; если token пустой/чужой, чтение из SW даёт
0 позиций.

Ожидаемый token текущей re-keyed ветки:

```text
f08fc7047657204e
```

Если этот token меняется, нужно отдельно менять/проверять handshake с
`ZTool.dll` и прогонять живой SolidWorks smoke.

## Reinjector strictness

`Reinjector` больше не делает fuzzy fallback при несовпадении сигнатур, если
не передан явный флаг `--allow-fuzzy-match`. Это снижает риск тихо заменить
не тот overload.

Если выбранный source type/method не найден в target binary, `Reinjector`
печатает `no target type` / `no target method`, не пишет output и завершает
работу с ненулевым exit code. Поэтому обычный `client-core/build.ps1` должен
падать fail-closed, а не выпускать частично reinjected `ZTool.exe`.

Exact-read логика TCP-клиента находится внутри существующего
`TCPClient.getreceive()`. Новый helper `TCPClient.ReadExact` не добавляется,
поэтому normal build не требует поддержки добавления новых методов в legacy
binary и не должен печатать `no target method TCPClient::ReadExact`.
