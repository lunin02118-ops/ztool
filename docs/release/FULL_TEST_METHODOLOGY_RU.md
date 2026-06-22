# Методика полного тестирования ZTool после рефакторинга (паритет с оригиналом)

Статус: актуализировано после рефакторинга (hardening PR #12–#22, BOM-шаблоны/русификация,
binderfix, pmpguard2, библиотека материалов PR #23, русские свойства PR #25,
PR #33: восстановление видимости колонок и удаление строк в «Разделить столбец»,
registry pre-flight: parent-value `AddInsStartup`, cached CommandManager tabs,
`Custom API Flyouts`, Explorer-launch и `LoadAddIn(<runtime>\ZTool.dll)`).

Цель документа — единая методика **полной** проверки всего функционала ZTool с
**паритетом к оригинальной китайской версии**: после рефакторинга поведение
русской сборки должно совпадать с оригиналом во всём, кроме намеренно
локализованных строк и принятых ограничений (легаси-крипто). Документ предназначен
для оператора с установленным SolidWorks; он дополняет
`docs/release/FINAL_ACCEPTANCE_TEST_PLAN_RU.md` (тот — релизный гейт, этот —
функциональная регрессия и паритет).

Важно: этот документ — **методика**, а не отчёт о прохождении. Полный статус
`FULL PASS` можно ставить только после заполненного журнала §15 с живым прогоном
в SolidWorks. Offline/pre-flight проверки из §13 подтверждают только готовность
к живому тесту, но не заменяют его.

### Единственная актуальная методика

Для текущего тестирования рабочим документом считается только этот файл:
`docs/release/FULL_TEST_METHODOLOGY_RU.md`.

Старые методики перенесены в `docs/archive/legacy-test-methods/` и имеют статус
**архив / не запускать напрямую**. Они оставлены для истории и восстановления
контекста, но не являются инструкцией для нового прогона. Если старый документ
противоречит этому файлу, выполнять этот файл.

---

## 1. Принцип паритета (A/B)

Паритет проверяется **сравнением «оригинал ↔ русская сборка»** на одной и той же
модели и в одинаковых условиях:

- **A (эталон):** оригинальный китайский ZTool (`ZTool.exe`/`ZTool.dll` из исходной
  поставки) на чистой ВМ.
- **B (проверяемое):** русская сборка из релиз-пакета (точные хеши — см. §2).
- На **одной и той же** тестовой сборке `0614-A00.SLDASM`, в одной версии SolidWorks
  (2025), при одинаковом `ZTool.settings` (с поправкой на язык).
- Для каждого теста фиксируется: результат A, результат B, вердикт **ПАРИТЕТ
  PASS/FAIL**, скриншоты обоих, заметки.

Если оригинальная сборка недоступна для прямого A/B — эталоном служит «ожидаемое»
поведение, описанное в этом документе и в исходных скриншотах пользователя; такой
тест помечается `эталон=док` (слабее, чем живое A/B).

### Формат тест-кейса

| Поле | Описание |
|------|----------|
| ID | Уникальный идентификатор (напр. `BOM-03`) |
| Предусловие | Состояние перед шагами |
| Шаги | Точная последовательность действий |
| Ожидаемо (эталон) | Поведение оригинала (A) или док-эталон |
| Факт (B) | Что показала русская сборка |
| Вердикт | ПАРИТЕТ PASS / FAIL / N/A |
| Доказательство | Скриншоты A и B, имя Excel-файла, лог |

---

## 2. Тестовая среда и предпосылки

- **ОС:** чистая Windows-ВМ; очищены прежние следы реестра/лицензии.
- **SolidWorks:** 2025 (обязательно), опционально 2024/2023 smoke.
- **Тестовая модель:** `TestModel/0614-A00.SLDASM` (29 поз., полный комплект в `TestModel/`).
- **Релиз-пакет:** `runtime/ZTool.exe`, `runtime/ZTool.dll`, `runtime/SolidWorksTools.dll`,
  `runtime/ZTool_rsa.dll`, `SolidWorksTemplates/MyMaterials.sldmat`,
  `Шаблоны спецификации/`. Хеши `runtime/*` совпадают с принятыми. Для
  `1.1.0-alfa` обязательная связка:
  `ZTool.exe`=`C7AB14910003D1F23E330B29D2E53F2B2BFF8ADA6BB29D27D80DC37786FCF37F`,
  `ZTool.dll`=`D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9`,
  `ZTool_rsa.dll`=`274A33F35B98437D57F7EADCE21CFE855D5285E9012C1C33733A3AB1F0EC2A90`.
- **Пакет pre-flight:** `scripts/verify_release_package.ps1 -RequireSolidWorksTools`
  → PASS; `manifest.git.dirty=false`; в пакете нет приватных ключей/БД/дампов/логов.
- **Конфиг:** `ZTool.settings` с `materialpath` → существующий `MyMaterials.sldmat`,
  `usematerialcolor=true` (см. §6 и PR #23), русскими `propname`/`namemapping`
  (PR #25) и `FilterRulesList`.

`verify_release_package.ps1` является pre-flight gate для свежего release
package. После запуска ZTool приложение может обновить `runtime/ZTool.settings`
(например, рабочие пути/пользовательские настройки), поэтому повторный verifier
на уже использованной live-папке может упасть по hash mismatch. Для immutable
release-проверки использовать свежесобранный пакет или пересобрать его после
ручного прогона.

### 2.1 Обязательная чистота реестра перед живым запуском

Перед каждым живым прогоном нельзя полагаться на состояние от прошлого теста:
старые `RegAsm CodeBase`, ключи SolidWorks AddIn и `HKCU\SOFTWARE\ZTool` могут
заставить SolidWorks загрузить не тот `ZTool.dll`/`ZTool.exe` или дать ложную
ошибку инициализации `.NET Framework`.

**Инцидент 2026-06-17: не путать с отсутствием .NET Framework.** Если
SolidWorks показывает `Не удалось загрузить Microsoft .NET Framework`,
первым делом считать это registry-preflight failure, а не ошибкой установки
.NET. Реальная причина повторного дефекта была такой:

- stale parent-value
  `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}=1`
  автозагружал старую надстройку;
- subkey при этом мог выглядеть чистым или иметь `0`, поэтому проверка только
  `...\AddInsStartup\{GUID}` недостаточна;
- cached tabs в
  `HKCU\SOFTWARE\SolidWorks\SOLIDWORKS 2025\User Interface\CommandManager`
  оставляли вторую вкладку ZTool, включая вкладку без названия;
- поиск только по `ZTool`/`59959DFA` недостаточен: пустая вкладка может
  сохраниться как anonymous `CommandManager\...\Tab*` без `ModuleName`/`RefName`,
  с `Tab Props = 0,1,1,-1` и кнопками ZTool (`41658..59425..41675`);
- cached flyout в
  `HKCU\SOFTWARE\SolidWorks\SOLIDWORKS 2025\User Interface\Custom API Flyouts`
  мог ссылаться на `{59959DFA-3229-4B86-852E-52ABF2BDB8C0}` и поднимать старую
  кнопку даже после очистки `CommandManager`;
- SolidWorks поднимал старую DLL/кнопку, а симптом выглядел как `.NET
  Framework` modal или дублированная вкладка.

Перед live-прогоном обязательное состояние:

- `HKCU\SOFTWARE\SolidWorks\AddInsStartup` value `{GUID}` = `0`;
- `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{GUID}` default = `0`;
- `HKCU\SOFTWARE\SolidWorks\SOLIDWORKS 2025\AddInsStartup` value `{GUID}` = `0`;
- `HKCU\SOFTWARE\SolidWorks\SOLIDWORKS 2025\AddInsStartup\{GUID}` default = `0`;
- `CommandManager` cache не содержит `ZTool`/`59959DFA`;
- `CommandManager` cache не содержит anonymous ZTool clones:
  `ModuleName`/`RefName` пустые, `Tab Props = 0,1,1,-1`, кнопки содержат
  `2,59425` и `41658..41675`;
- `Custom API Flyouts` cache не содержит `ZTool`/`59959DFA`;
- COM `CodeBase` указывает на текущий/clean `runtime\ZTool.dll`.

Если любой пункт не выполнен, не начинать BOM/цвета/REG-тесты: сначала backup,
targeted cleanup, `RegAsm /codebase` текущего runtime, повторный snapshot.

Обязательный порядок:

1. Закрыть SolidWorks и ZTool полностью.

   ```powershell
   Get-Process SLDWORKS,ZTool -ErrorAction SilentlyContinue | Stop-Process -Force
   ```

2. Нормализовать окружение процесса, из которого запускается тест.

   В Codex/PowerShell окружение может отличаться от обычного запуска с рабочего
   стола. Практически важный случай: пустой `$env:WINDIR` приводит к ложной
   ошибке SolidWorks «Не удалось загрузить Microsoft .NET Framework» или вечному
   `splash`, хотя запуск через ярлык/проводник у пользователя работает.

   ```powershell
   $env:WINDIR = 'C:\Windows'
   $env:SystemRoot = 'C:\Windows'
   $env:ComSpec = 'C:\Windows\system32\cmd.exe'

   if (-not $env:WINDIR -or -not (Test-Path "$env:WINDIR\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe")) {
       throw "Broken launch environment: WINDIR/RegAsm is not available"
   }
   ```

3. Сделать backup затрагиваемых веток реестра в папку отчёта.

   ```powershell
   $stamp = Get-Date -Format yyyyMMdd-HHmmss
   $backup = "manual-test-reports\registry-backup-$stamp"
   New-Item -ItemType Directory -Force $backup | Out-Null

   reg export HKCU\SOFTWARE\ZTool "$backup\HKCU_ZTool.reg" /y
   reg export "HKLM\SOFTWARE\SolidWorks" "$backup\HKLM_SolidWorks.reg" /y
   reg export "HKCU\SOFTWARE\SolidWorks" "$backup\HKCU_SolidWorks.reg" /y
   reg export "HKLM\SOFTWARE\Classes\ZTool.SwAddin" "$backup\HKLM_Classes_ZTool.SwAddin.reg" /y
   ```

4. Проверить и убрать старые следы `ZTool`/старых test-dir путей.

   ```powershell
   reg query HKLM\SOFTWARE\Classes /f ZTool /s /reg:64
   reg query HKLM\SOFTWARE\SolidWorks /f ZTool /s /reg:64
   reg query HKCU\SOFTWARE\SolidWorks /f ZTool /s /reg:64
   ```

   Если найден `CodeBase` или SolidWorks AddIn key, указывающий не на текущую
   тестовую папку `runtime`, тест **невалиден**: удалить stale-запись или
   перерегистрировать add-in из текущей папки.

   Отдельно обязательно проверить **оба** формата автозагрузки SolidWorks:
   parent-value и subkey. Практический дефект 2026-06-17: subkey выглядел
   чистым, но parent-value
   `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959DFA-...}=1` всё равно
   автозагружал старый ZTool и давал стартовый диалог SolidWorks
   «Не удалось загрузить Microsoft .NET Framework».

   ```powershell
   $guid = '{59959DFA-3229-4B86-852E-52ABF2BDB8C0}'
   $roots = @(
     'HKCU\SOFTWARE\SolidWorks\AddInsStartup',
     'HKCU\SOFTWARE\SolidWorks\SOLIDWORKS 2025\AddInsStartup'
   )

   foreach ($root in $roots) {
     reg query $root /v $guid
     reg query "$root\$guid" /ve
     reg add $root /v $guid /t REG_DWORD /d 0 /f
     reg add "$root\$guid" /ve /t REG_DWORD /d 0 /f
   }
   ```

   Значение `1` в любом из этих мест является blocker для live-прогона: сначала
   поставить `0`, затем перезапустить SolidWorks.

   Также очистить cached вкладки CommandManager, если в них есть ZTool/GUID,
   либо если это anonymous ZTool clone. Симптом stale cache: две вкладки, одна
   без названия, но фактически тоже ZTool; либо запуск старой кнопки после
   перерегистрации DLL. Перед удалением должен быть сделан backup из шага 3.
   Отдельно очистить `Custom API Flyouts`: это другой cache SolidWorks, он не
   удаляется кодом для `CommandManager`.

   ```powershell
    $guid = '{59959DFA-3229-4B86-852E-52ABF2BDB8C0}'
    $guidRe = '59959DFA|59959dfa|ZTool'
    $cm = 'HKCU:\SOFTWARE\SolidWorks\SOLIDWORKS 2025\User Interface\CommandManager'
    foreach ($ctx in 'AssyContext','PartContext','DrwContext') {
      $root = Join-Path $cm $ctx
      Get-ChildItem $root -ErrorAction SilentlyContinue |
        Where-Object { $_.PSChildName -match '^Tab\d+$' } |
        ForEach-Object {
          $props = Get-ItemProperty -LiteralPath $_.PSPath
          $children = Get-ChildItem -LiteralPath $_.PSPath -Recurse -ErrorAction SilentlyContinue
          $text = (($props | Out-String), ($children | ForEach-Object {
            Get-ItemProperty -LiteralPath $_.PSPath | Out-String
          })) -join "`n"
          $buttons = @($children | ForEach-Object {
            (Get-ItemProperty -LiteralPath $_.PSPath).PSObject.Properties |
              Where-Object { $_.Name -like 'Btn*' } |
              ForEach-Object { [string]$_.Value }
          })
          $buttonText = $buttons -join ';'
          $isNamedZTool = ($text -match $guidRe) -or
            ($props.ModuleName -eq $guid) -or
            ($props.RefName -eq 'ZTool') -or
            ($props.'Tab Props' -like 'ZTool,*')
          $isAnonymousZToolClone = (-not $props.ModuleName) -and
            (-not $props.RefName) -and
            ($props.'Tab Props' -eq '0,1,1,-1') -and
            ($buttons -contains '2,59425') -and
            ($buttonText -match '41658') -and
            ($buttonText -match '41675')

          if ($isNamedZTool -or $isAnonymousZToolClone) {
            Remove-Item -LiteralPath $_.PSPath -Recurse -Force
          }
        }
    }
   ```

   ```powershell
   $flyouts = 'HKCU:\SOFTWARE\SolidWorks\SOLIDWORKS 2025\User Interface\Custom API Flyouts'
   Get-ChildItem $flyouts -ErrorAction SilentlyContinue |
     ForEach-Object {
       $self = Get-ItemProperty -LiteralPath $_.PSPath | Out-String
       $children = Get-ChildItem -LiteralPath $_.PSPath -Recurse -ErrorAction SilentlyContinue |
         ForEach-Object { Get-ItemProperty -LiteralPath $_.PSPath | Out-String }
       if ((($self, $children) -join "`n") -match $guidRe) {
         Remove-Item -LiteralPath $_.PSPath -Recurse -Force
       }
     }
   ```

   Не использовать `RegAsm /u` как штатную очистку: на рабочей машине это уже
   давало модальный диалог `Cannot delete a subkey tree because the subkey does
   not exist`. Предпочтительный путь: backup, targeted delete/stale cleanup,
   затем обычный `RegAsm /codebase` текущего runtime.

5. Зарегистрировать именно текущий `runtime\ZTool.dll`.

   ```powershell
   Push-Location <runtime>
   & "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe" .\ZTool.dll /codebase
   Pop-Location
   ```

6. Повторно проверить, что `CodeBase` в `HKLM\SOFTWARE\Classes` указывает на
   текущий `runtime\ZTool.dll`, а не на старую папку.

   ```powershell
   reg query HKLM\SOFTWARE\Classes /f "<runtime>\ZTool.dll" /s /reg:64
   ```

   Для детерминированного load-smoke в этой среде использовать путь к DLL:
   `swApp.LoadAddIn("<runtime>\ZTool.dll")`. Загрузка по одному GUID может вернуть
   `3`, даже если COM registration корректный; это не заменяет проверку ленты,
   но помогает быстро отличить проблему загрузки DLL от проблемы cached UI.

7. Для тестов лицензирования на чистой машине дополнительно очистить **весь**
   license state. Для BOM/цветов/экспорта этот шаг выполнять только если нужен
   именно clean-license сценарий.

   Инцидент 2026-06-21 (SWTools 1.1.6): очистка только `HKCU\SOFTWARE\SWTools`
   даёт ложный clean PASS. Клиент также читает legacy HKLM-blob ключи из
   `SR.IsReg2`; если их не удалить, установленное приложение может стартовать
   как активированное без нового online activation.

   ```powershell
   reg delete HKCU\SOFTWARE\SWTools /f
   reg delete HKCU\SOFTWARE\ZTool /f
   reg delete HKLM\SOFTWARE\SolURxxCfNU /f
   reg delete HKLM\SOFTWARE\Microsoft\MzORu8qE4HhZ /f
   ```

   Перед удалением обязательно сделать `reg export` этих веток в report dir.
   После удаления первый запуск установленного клиента должен показывать
   «Лицензия не обнаружена»; иначе license gate считается невалидным.

Если после этого SolidWorks всё равно показывает «Не удалось загрузить Microsoft
.NET Framework», сначала проверить `$env:WINDIR`, `$env:SystemRoot`, затем
повторить registry pre-flight, parent-value `AddInsStartup`, cached
CommandManager tabs и `CodeBase`; не продолжать
BOM/цветовые тесты из такой сессии.

> SolidWorks для теста открывать **через файл сборки**
> `TestModel/0614-A00.SLDASM` (проводник/ассоциация `.SLDASM`). Для автоматизации
> допустимо `explorer.exe "<полный-путь-к-SLDASM>"`. Не использовать прямой
> `Start-Process <file.SLDASM>` из PowerShell/Codex и не стартовать `SldWorks.exe`
> отдельно из shell: это даёт другой init-контекст и может приводить
> к ошибке загрузки .NET. ZTool запускать только из ленты SolidWorks
> («Управление файлами» стартует `runtime/ZTool.exe`).

Перед любым живым тестом зафиксировать, что реально запущена нужная сборка:

```powershell
Get-Process ZTool | Select-Object Id,Path,MainWindowTitle
Get-FileHash (Get-Process ZTool).Path -Algorithm SHA256
```

Если путь не из тестового runtime-каталога или hash не совпадает с ожидаемым,
тест невалиден: сначала исправить регистрацию/путь запуска.

### 2.2 Протокол живой автоматизации

Живой прогон должен быть воспроизводимым и не должен зависеть от DPI, положения
окна, масштаба монитора или случайного клика. Основной способ автоматизации:
UIA/WinForms/SolidWorks COM-локаторы по имени окна, `AutomationId`, тексту
кнопки/заголовка, process path/hash и значениям ячеек. Скриншоты нужны как
артефакты, но сами по себе не являются доказательством прохождения gate.

Жёсткое правило: координатные клики **запрещены для зачёта acceptance-gate**.
Координата может использоваться только как временная диагностика для скриншота
или локализации проблемы, но такой шаг не считается прохождением теста.
Засчитывается только объектное действие, где в отчёте есть:

- какой процесс/окно управлялись (`pid`, `Path`, `SHA256`);
- какой UIA/WinForms control найден (`AutomationId`/text/class/rect);
- значение до действия и после действия (`ValuePattern`, Excel/COM read-back);
- скриншот контрольной точки.

Если контрол не найден объектно, результат gate — `FAIL/NO-GO`, а не попытка
кликнуть "примерно туда". Для legacy WinForms, где UIA не видит вложенные
контролы, использовать Win32 child-window locator (`pid` + class + visible text)
и `BM_CLICK`; reusable helper: `scripts/ztool_acceptance_ui.ps1`. Для кнопок,
которые выполняют сеть, запись лицензии или открывают модальные окна, запускать
действие через `Invoke-ZToolButtonByText ... -Async`, чтобы тестовый runner не
зависал на UI thread и мог продолжить сбор evidence.

**Инцидент 2026-06-18: `SetWindowText` запрещён для ввода activation gate.**
Native `SetWindowText`/`GetWindowText` на WinForms `TextBox` может показать в
окне и в Win32 read-back правильные сегменты ключа, но managed
`TextBox.Text` остаётся старым; сервер в этом случае получает прежний код. Такой
прогон считается ложным PASS и должен быть забракован. Для ввода ключа
засчитываются только:

- ручной copy/paste пользователем с последующим server audit;
- UIA `ValuePattern.SetValue` с UIA `CurrentValue` read-back для каждого
  сегмента;
- настоящий клавиатурный paste в сфокусированный control с read-back через UIA
  или подтверждением по server audit.

Для masked password field `ValuePattern.SetValue` может быть недоступен. Тогда
пароль вводится вручную copy/paste, либо acceptance-код создаётся без пароля, а
password-protected activation проверяется отдельным ручным gate. Полный ключ и
пароль запрещено писать в отчёт: только маска, длина и SHA12.

**Инцидент 2026-06-21: production backend оказался MySQL, не SQLite.**
Перед генерацией/удалением/проверкой ключа обязательно читать backend из
`ztool-tcp-server.service` runtime environment (`/proc/<MainPID>/environ`), а не
из предположений и не из наличия `/opt/ztool-tcp-server/licenses.db`. Если
`ZTOOL_DB_BACKEND=mysql`, единственный источник истины — таблица MySQL
`license_keys`; SQLite-файл может содержать похожий ключ, но клиент его никогда
не увидит. Симптом ошибки: локально созданный ключ есть в `licenses.db`, клиент
подключается к `license.vizbuka.ru:58000`, сервер отвечает
`Недопустимый регистрационный код`, а MySQL `activation_log` не содержит
успешной попытки для этого ключа.

Для production clean-install gate использовать один и тот же test-key secret из
`_local_artifacts\secrets\licenses\...` на весь прогон. Рекомендуемый helper:

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass `
  -File scripts\swtools_activation_acceptance.ps1 `
  -SecretPath _local_artifacts\secrets\licenses\swtools-1.1.5-clean-install-license-*.txt `
  -ReportDir manual-test-reports\YYYY-MM-DD-clean-install-X.Y.Z `
  -ProvisionProductionKey `
  -ClickActivate
```

Helper обязан печатать только mask/SHA12/length, добавлять ключ в фактический
backend production-сервиса, заполнять форму без `SetWindowText` и затем
подтверждать результат server-side состоянием `current_activations=1`,
`machine_bound=true`. Скриншоты с полным ключом/паролем считаются секретными
локальными артефактами и не коммитятся.

Запускать helper через `pwsh`, а не Windows PowerShell 5.1: файл хранится в
UTF-8 и содержит русские UI-литералы (`Регистрация`, `Активация онлайн`).
Запуск через старый `powershell.exe` может превратить эти строки в mojibake и
дать ложный отказ поиска окна/кнопки.

Обязательный порядок:

1. Открыть `TestModel/0614-A00.SLDASM` через проводник/ассоциацию `.SLDASM`.
2. Развернуть окно SolidWorks на основном мониторе.
3. Запустить ZTool только кнопкой ленты SolidWorks (`Управление файлами`).
4. Развернуть окно `ZTool 1.0(x64)`.
5. Проверить, что ZTool видит 29 строк после `Подключить SW`.
6. Управлять ZTool через UIA/WinForms/Win32 locator. Для ribbon-кнопок, где
   `InvokePattern` объявлен, но не исполняет действие, допустим только
   object-located action по найденному элементу (`AutomationElement` или
   `HWND`/text/class), а не координата из таблицы.
7. После каждого критического шага сохранять JSON/TXT dump и скриншот в папку
   отчёта:
   `01-sw-open.png`, `02-ztool-connected.png`, `03-export-menu.png`,
   `04-bom-XX-save-dialog.png`, `05-bom-XX-result.xlsx`.

PowerShell-заготовка для фиксации текущего окна:

Если автоматизация ищет русские кнопки/диалоги (`Нет`, `Подключить SW`,
`Экспорт выполнен`), запускать runner из UTF-8-aware shell (`pwsh`) или хранить
скрипт в корректной кодировке. `powershell.exe` 5.1 без UTF-8 BOM уже приводил
к неверному matching русских строк и невалидному Save As вводу.

```powershell
$z = Get-Process ZTool | Select-Object -First 1
Add-Type @'
using System;
using System.Runtime.InteropServices;
public class WinRect {
  [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
  [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
  public struct RECT { public int Left; public int Top; public int Right; public int Bottom; }
}
'@
[WinRect]::ShowWindow($z.MainWindowHandle, 3) | Out-Null # maximize
$r = New-Object WinRect+RECT
[WinRect]::GetWindowRect($z.MainWindowHandle, [ref]$r) | Out-Null
"ZTool rect: $($r.Left),$($r.Top),$($r.Right),$($r.Bottom)"
```

Минимальные объектные локаторы ZTool:

- No-license gate:
  `Invoke-ZToolButtonByText -ProcessId <pid> -Text 'Проба'` из
  `scripts/ztool_acceptance_ui.ps1`; evidence должен содержать
  `window-tree.txt`, `hwnd`, title countdown и факт выхода процесса.
- Online activation gate:
  `Invoke-ZToolButtonByText -ProcessId <pid> -Text 'Регистрация'`, затем ввод
  ключа/пароля только в найденные `EDIT` controls с сохранением `window-tree`;
  `Invoke-ZToolButtonByText -ProcessId <pid> -Text 'Активация онлайн' -Async`.
  Evidence: `hwnd` кнопки, `window-tree` до/после, server row state, старый/new
  process id после restart. Координатный клик по кнопке активации не засчитывать.
  Формат актуального кода клиента: 5 сегментов `8-5-5-5-9`, всего 36 символов
  с дефисами; старые ключи `8-5-5-5-8` для этой сборки невалидны.

| Действие | Locator | Ожидаемо |
|----------|---------|----------|
| `Подключить SW` | UIA text `Подключить SW`; чаще `SplitButton` under tab `Главная` | Status содержит `Подключение завершено`, таблица `DGV1` содержит 29 строк |
| `Сохранить в SW` | UIA text `Сохранить в SW`; чаще верхний `SplitButton`, не generic `Button` | После повторного `Подключить SW` значения вернулись из SolidWorks |
| `Задать имя свойства` | UIA Button text `Задать имя свойства`; dialog `Frmsetpropname`; grid `DGV1` | В строках есть `Наименование`, `Обозначение`, `Материал`, `Тип`, `Версия`, `Обработка поверхности`, `Дата разработки`, `Масса`; расчетные колонки `Масса ед._кг` и `Габаритные размеры` проверяются отдельно через сопоставление BOM |
| `PropSwitch` | `StatusStrip1`: text `Вычисленное значение`/`Выражение свойства`; rightmost empty status `Button` before that text | Для записи свойств включён режим `Выражение свойства`, то есть видимы editable `PropVal_*`, а не read-only `PropResolvedVal_*` |
| `Столбец заполнения` | UIA Button text `Столбец заполнения`; dialog `FrmFilling`; `ComboBox1`, `TextBox1`, `OK_Button` | `ComboBox1` содержит и выбирает нужный столбец, `TextBox1` содержит marker, после `OK` ячейки изменились |
| BOM export | UIA tab `Спецификация`, menu item by visible text / exported file path | Создан `.xlsx`, валидатор и Excel read-back PASS |

Для стандартного окна сохранения Excel не использовать случайный выбор папки
мышью. В поле `Имя файла` вставить полный путь вида
`<report>\bom-exports\BOM-01-summary.xlsx` и нажать `Enter`. Если диалог
открылся не в том каталоге, это не ошибка ZTool, но в отчёте фиксируется
скриншотом.

Если появляется модальное окно `Вопрос / Получить данные заново?`, выбрать
`Да` для контрольного перечитывания или `Нет` перед независимым COM read-back;
решение зафиксировать в отчёте. Если появляется
`Не удалось загрузить Microsoft .NET Framework`, вернуться в §2.1: это не
валидная ZTool-сессия.

### 2.3 Правильный способ запуска SolidWorks для теста

Для живого теста запрещены два проблемных сценария:

- запускать `SldWorks.exe` напрямую из Codex/PowerShell без открытия модели;
- открывать отдельные `.SLDPRT` и оставлять их активными перед проверкой ZTool.

Правильный сценарий:

1. Закрыть `SLDWORKS` и `ZTool`.
2. Выполнить §2.1.
3. Открыть именно `TestModel/0614-A00.SLDASM` через проводник/ассоциацию файла.
4. Дождаться, что в заголовке SolidWorks активна сборка `0614-A00.SLDASM`.
5. Запустить ZTool только с ленты SolidWorks → `ZTool` → `Управление файлами`.
6. Сразу зафиксировать `Get-Process ZTool | Select Id,Path,MainWindowTitle`.

Если активным стал файл детали (`*.SLDPRT`), тест остановить: закрыть ZTool,
активировать/переоткрыть `0614-A00.SLDASM` и только после этого запускать ZTool.
Иначе вкладки/лента SolidWorks будут отличаться от сборочного режима, а
объектные локаторы и ожидаемые команды из §2.2 станут недействительными.

---

## 3. Карта функционала (что тестируем — всё)

| Обл. | Область функционала | Раздел |
|------|---------------------|--------|
| A | Лицензирование/активация (x86/x64, trial, online, перенос, MNum, ветки реестра) | §4 |
| B | Подключение SW и чтение данных (Поз., чтение по спецификации, чтение всех) | §5 |
| C | Экспорт спецификации — 8 режимов | §6.1 |
| D | Свойства и маппинг (русские имена, заполнение колонок) | §6.2 |
| E | Цвета ячеек: материал и покраска (паритет оттенков) | §6.3 |
| F | Оформление таблицы: повторы, выделение строки, высота, цвет строки | §6.4 |
| G | Эскизы/изображения в спецификации | §6.5 |
| H | Фильтр-режимы (Обрабатываемые/Покупные/Поверхность/Недостающие свойства) | §6.6 |
| I | Пакетные операции (формат, печать, чертежи, синхронизация имён) | §7 |
| J | Буфер обмена (copy/paste, allow-list) | §8 |
| K | Сохранение в новую папку, переименование по правилам, read-only | §9 |
| L | Превью, горячие клавиши | §10 |
| M | Локализация UI (нет иероглифов, шрифт, CJK=0) | §11 |
| N | Стабильность/регрессии рефакторинга | §12 |

---

## 4. Область A — Лицензирование и активация

| ID | Шаги | Ожидаемо (эталон) |
|----|------|-------------------|
| LIC-01 | Чистая ВМ, первый запуск | Стартует триал; диалог активации **на русском** |
| LIC-02 | Онлайн-активация валидным кодом | Успех; после перезапуска остаётся активирован |
| LIC-03 | Неверный код | Отказ; сообщение **RU** |
| LIC-04 | Неверный пароль кода | Отказ; сообщение **RU** |
| LIC-05 | Просроченный код | Отказ |
| LIC-06 | Превышение `device_limit` | Отказ (лимит устройств) |
| LIC-07 | Перенос лицензии (transfer-out) через UI | Успех; повторная активация на др. машине проходит |
| LIC-08 | Повтор подтверждения (replay) | Отклонён |
| LIC-09 | Сервер недоступен | Корректное сообщение **RU**, без краша |
| LIC-10 | x86 и x64 ветки регистрации | Регистрация в правильной ветке реестра (b0–b3); MNum-привязка по железу |
| LIC-11 | Нажать `OK` в сообщении `Регистрация выполнена` | Старый PID завершается, стартует новый PID ZTool, окно регистрации не появляется |

Паритет: тексты диалогов локализованы (RU) — это намеренное отличие; **логика**
активации/переноса/привязки должна совпадать с оригиналом 1:1.

Контрольные условия для лицензирования:

- Source of truth на боевом сервере — backend из `ZTOOL_DB_BACKEND`. Для текущего
  production `ztool-tcp-server.service` это MySQL-таблица `license_keys`; старый
  `/opt/ztool-tcp-server/licenses.db` может быть stale и не доказывает состояние
  лицензии.
- Если ключ создан в SQLite при активном `ZTOOL_DB_BACKEND=mysql`, gate считается
  `FAIL`: клиент такой ключ не увидит. Нужно добавить/удалить ключ в MySQL через
  production DB adapter и повторить активацию тем же test-key secret.
- Нельзя деплоить локальный checkout поверх production, пока production-only
  backend/adapters не синхронизированы в репозиторий или не зафиксированы в
  отдельном deployment plan.
- Нельзя выводить `systemctl show ... -p Environment` в лог/чат: там могут быть
  DB passwords и ключевые пути. Скрипты должны читать environment внутри
  процесса и печатать только redacted status.
- После успешной активации недостаточно увидеть modal `Регистрация выполнена`.
  Обязателен PID-restart: старый процесс должен выйти, новый процесс должен
  подняться уже активированным. `Application.Restart()` без явного запуска нового
  процесса считается запрещённой реализацией для этого gate, потому что уже
  ловился Ribbon COM `E_NOINTERFACE` и зависание на старом процессе.
- Если правка делается через IL-reinjector, помнить ограничение: текущий
  reinjector заменяет существующие методы и не добавляет новые. Restart-логику
  встраивать в существующий метод или сначала расширять reinjector.

---

## 5. Область B — Подключение SW и чтение данных

| ID | Шаги | Ожидаемо |
|----|------|----------|
| RD-01 | Открыть через проводник `TestModel/0614-A00.SLDASM`, лента → «Управление файлами» | Стартует `runtime/ZTool.exe`, лента/иконки видны |
| RD-02 | «Подключить SW» | Прочитано **29 поз.** (как в оригинале) |
| RD-03 | Чтение «по спецификации» | Отфильтрованный набор компонентов = оригинал |
| RD-04 | Чтение «все» | Полный набор = оригинал |
| RD-05 | Виртуальные компоненты / `Excludevirtual` | Поведение исключения = оригинал |

---

## 6. Область C–H — Спецификация (ядро)

### 6.1 Экспорт: 8 режимов (BOM-01…BOM-08)

Для **каждого** режима: экспорт → открыть Excel → сверить с оригиналом.

| ID | Режим | Ожидаемо (эталон) |
|----|-------|-------------------|
| BOM-01 | Сводная спецификация | N строк, все колонки, без вложенности |
| BOM-02 | Иерархическая | Уровни (1,2…), отступы |
| BOM-03 | Верхний уровень | Только прямые дочерние (Level 1) |
| BOM-04 | Сводная спецификация деталей | Без подсборок, только .SLDPRT; **режим не падает** (см. N) |
| BOM-05 | Сводная (с эскизами) | То же, что BOM-01 + колонка эскизов с картинками |
| BOM-06 | Иерархическая (с эскизами) | То же, что BOM-02 + эскизы |
| BOM-07 | Обрабатываемые детали | Только `Тип∈{Мех.обработка;Листовая;Литьё;Сварка}` |
| BOM-08 | Покупные изделия | Только `Тип∈{Покупное;Стандартное}` |

Для `BOM-07`/`BOM-08` нулевой результат на демо-модели без совпадающих значений
свойства `Тип` фиксируется как `WARN`, а не как сбой экспорта: важно, что файл
создан и фильтр не возвращает полный нефильтрованный список. Строгий filter
`PASS` требует fixture-модель с заполненным `Тип`.

Строгий gate для `BOM-07`/`BOM-08`:

- подготовить fixture-копию модели, где `Тип` непустой у проверяемых деталей;
- экспортировать все 8 режимов через UI ZTool;
- `BOM-07` должен иметь `rows > 0`, непустой столбец `Тип` и только значения
  `Мех.обработка`/эквиваленты из `FilterRulesList`;
- `BOM-08` должен иметь `rows > 0`, непустой столбец `Тип` и только значения
  `Покупное`/`Стандартное`/эквиваленты из `FilterRulesList`;
- пустой `Тип` в любой строке `BOM-07`/`BOM-08` = `FAIL`.

**Критерии PASS (каждый режим):** Excel создан без ошибок; № п/п последователен;
«Количество» — числа > 0 и **= сумме** одинаковых поз. (служебная вычисляемая
колонка, не свойство); `Масса ед. кг` и `Габаритные размеры` заполнены из
расчетных колонок ZTool, а не из пользовательских свойств; набор/порядок
колонок = шаблон; эскизы присутствуют для эскизных режимов. **Паритет:** число
строк, разбивка количеств и состав колонок совпадают с оригиналом.

### 6.2 Область D — Свойства и маппинг

| ID | Шаги | Ожидаемо |
|----|------|----------|
| PROP-01 | Сверить русские `propname`/видимые колонки с legacy `mappingname` anchors шаблона | Колонки `Наименование/Обозначение/Материал/Тип/Версия/Обработка поверхности/Масса` читают русские свойства модели, а `mappingname` указывает на существующие anchors `零件名称/图号/材质/类型/版本/表面处理/重量` |
| PROP-01A | Сверить постоянные расчетные BOM-колонки в окне сопоставления и шаблоне | В `FrmMapping` видны `Масса ед._кг` и `Габаритные размеры`; в `ZTool.settings` есть `Col_Weight -> МассаЕдКг` и `Col_bound -> ГабаритныеРазмеры`; в Excel Name Manager anchors указывают на `J6` и `P6` |
| PROP-02 | Модель с заполненными русскими свойствами | Значения попадают в соответствующие колонки |
| PROP-03 | Модель без свойства | Пустая ячейка, без ошибки/сдвига колонок |
| PROP-04 | `Материал`/`Масса` как ссылки SW (`SW-Material@`,`SW-Mass@`) | Резолвятся в значения (resolved value) |

#### PROP-NAMES-REGRESSION — список имён свойств

Этот gate обязателен перед сборкой/пушем после любых правок `Frmsetpropname`,
`Frmmain.insetpropcol`, импорта свойств, версии сборки или reinject/localizer
пайплайна. Он ловит регрессию, когда после удаления свойств в таблице остаются
старые `PropVal_*`/`PropResolvedVal_*`, ручные свойства не создают колонки или
`Импорт... -> Получить из файла` перестаёт подтягивать имена из модели.

Команды из корня репозитория:

```powershell
dotnet build -c Release client-core\tools\PropertyNamesRegression\PropertyNamesRegression.csproj
client-core\tools\PropertyNamesRegression\bin\Release\net48\PropertyNamesRegression.exe client-core\out\SWTools.exe "D:\1602.00.003 Фланец.SLDPRT"
```

PASS-критерии:

- `TITLE_SOURCE` остаётся `ZTool, Version=1.0.0.0, ... PublicKeyToken=f08fc7047657204e`.
  Это совместимость с оригиналом; отображаемая версия SWTools поднимается через
  `AssemblyFileVersion`/`AssemblyInformationalVersion`, а не через identity.
- `CLEAR_PROP_COLUMNS=0`: после удаления всех свойств в настройке не осталось
  property-колонок в main grid.
- `MANUAL_PROP_COLUMNS` содержит обе ручные колонки `ManualRegression_A` и
  `ManualRegression_B`.
- `IMPORT_RUNSW=True`, `IMPORT_OPENDOC_OPENED=True`, `IMPORT_BACKEND_COUNT >= 40`.
- `IMPORT_GRID_COUNT` совпадает с количеством импортированных имён, а среди них
  есть `Разработал`, `Наименование`, `Обозначение`, `Масса`, `Проект_ФБ`,
  `Материал_ФБ`.
- Финальная строка `RESULT=PASS`.

Автоматизация `OpenFileDialog` не засчитывается как gate: она нестабильна в
WinForms/COM окружении. Скрипт проверяет бизнес-логику после выбора файла через
реальный SolidWorks COM backend; живой smoke-клик `Импорт... -> Получить из
файла` выполняется отдельно и подтверждается скрином/логом только как UI-smoke.

#### PROP-RUNBOOK — свойства: read-back и запись

Раздел состоит из двух разных gates. Их нельзя смешивать.

`PROP-READ-EXPORT` — обязательный gate для релиза: свойства уже есть в
модели, ZTool читает их из SolidWorks и экспортирует в BOM.

1. Выполнить §2.1–§2.3, открыть fixture-копию `0614-A00.SLDASM`, запустить
   ZTool из ленты.
2. Заполнить свойства fixture-модели через штатный SolidWorks property workflow
   или через SolidWorks COM-скрипт тестовой подготовки. Это подготовка данных,
   а не проверка ZTool-write.
3. `Подключить SW`: подтвердить 29 строк и считать через UIA/COM/Excel
   значения `Наименование`, `Обозначение`, `Материал`, `Тип`, `Версия`,
   `Обработка поверхности`, `Дата разработки`, `Масса`, а в окне сопоставления
   BOM отдельно подтвердить расчетные `Масса ед._кг` и `Габаритные размеры`.
4. Экспортировать BOM через ZTool UI и проверить Excel read-back. Для строгого
   `BOM-07/08` `Тип` должен быть непустым и попадать в `FilterRulesList`.

PASS: после `Подключить SW` и после BOM-export значения взяты из SolidWorks и
есть в Excel. FAIL: ZTool читает 29 строк, но русские свойства пустые/смещены,
или BOM не содержит ожидаемые значения.

`PROP-WRITE-ZTOOL` — отдельный gate функции записи ZTool в SolidWorks. Он
засчитывается только если доказаны все три состояния: изменено в UI ZTool,
сохранено через `Сохранить в SW`, перечитано из SolidWorks после повторного
`Подключить SW`.

Штатный порядок `PROP-WRITE-ZTOOL`:

1. Открыть fixture-копию модели. Никогда не писать в исходный `TestModel`.
2. `Подключить SW`; сохранить UIA dump таблицы `DGV1` и screenshot.
3. Проверить `Задать имя свойства`: dialog `Frmsetpropname` должен содержать
   нужные русские имена свойств. Важно: этот диалог настраивает имена свойств,
   но сам по себе не создаёт видимые data-колонки в main grid.
4. Найти редактируемый столбец объектно: UIA/WinForms header/value dump,
   не координата. Для записи выбирать именно editable `PropVal_*`
   (`21,23,...,37` в default `columnInfolist`), а не read-only
   `PropResolvedVal_*` с тем же заголовком; дубликат заголовка нормален.
   Перед изменением записать `before`. Обязательный guard: `StatusStrip1`
   должен показывать `Выражение свойства`. Если видно `Вычисленное значение`,
   сначала переключить `PropSwitch` объектно найденной status-кнопкой; иначе
   открытая колонка будет `PropResolvedVal_*` и запись в SolidWorks не пройдёт.
5. Изменить значение штатным UI ZTool:
   - inline edit допустим только если после ввода `ValuePattern`/WinForms
     read-back показывает новое значение;
   - `Столбец заполнения` допустим только если dialog `FrmFilling` содержит
     выбранный столбец в `ComboBox1` (например, `Наименование`), `TextBox1`
     содержит заданное значение, а после `OK` ячейки реально изменились.
     Если `ComboBox1` содержит только `Сводка_*` или не содержит нужное
     свойство, это не баг диалога, а неверный режим/столбец: вернуться к
     `PropSwitch=Выражение свойства` и выбрать editable `PropVal_*`.
6. Нажать `Сохранить в SW`. В ribbon UIA эта команда может быть `SplitButton`;
   locator должен кликать найденный объект, обычно верхнюю часть split-button,
   и ждать `FrmSaveOption`. В окне `Параметры сохранения` выбрать
   `Save_Changed` (`Сохранять только изменённые`) или, если сценарий явно
   требует полного сохранения fixture, `Save_All`; затем ждать статуса
   `Сохранение завершено...` и закрыть информационный `Вопрос`.
7. Повторно выполнить `Подключить SW` и подтвердить, что marker вернулся из
   SolidWorks. Дополнительно прочитать то же свойство через SolidWorks COM.

PASS: `before != marker`, после UI edit `DGV1 == marker`, после
`Сохранить в SW` и повторного `Подключить SW` `DGV1 == marker`, COM read-back
того же документа/свойства тоже `marker` в нужном scope (`Default` или global,
который соответствует строке/конфигурации ZTool).

FAIL/NO-GO:

- marker не виден в UI до `Сохранить в SW`;
- marker виден в UI, но пропал после повторного `Подключить SW`;
- `Столбец заполнения` открыт, но combo выбора столбца пустой;
- `Столбец заполнения` открыт в режиме `Вычисленное значение`, combo содержит
  только `Сводка_*`/другие нецелевые столбцы или выбран не тот столбец
  (`Сводка_Тема` вместо `Наименование`);
- inline edit/F2/clipboard не меняет `ValuePattern`;
- редактировался `PropResolvedVal_*` или другая look-alike колонка вместо
  `PropVal_*`;
- `Сохранить в SW` найден как text, но не был реально вызван (`Button` vs
  `SplitButton`);
- результат подтверждён только скриншотом или координатным кликом без
  read-back.

### 6.3 Область E — Цвета ячеек: материал и покраска (паритет оттенков) ⚑

> Это явно отмеченный пользователем дефект: «цвета ячеек при выборе материала и
> покраске не соответствуют цветам/оттенкам деталей в сборке, хотя в оригинале
> соответствуют». Раздел — приоритетный.

Предпосылки: `usematerialcolor=true` и валидный `materialpath`
(`SolidWorksTemplates/MyMaterials.sldmat`) — обеспечивает **PR #23**. Без этого цвета не
подхватываются (исходная причина: было `usematerialcolor=false`, пустой
`materialpath`).

| ID | Шаги | Ожидаемо (эталон = оригинал) |
|----|------|------------------------------|
| COL-UI-01 | Назначить детали материал X из библиотеки → подключить модель в UI | Ячейка `Материал` в таблице ZTool залита **цветом материала X** из `MyMaterials.sldmat`; оттенок = оригиналу |
| COL-UI-02 | Несколько деталей с разными материалами | У каждой — свой корректный цвет; соответствие материал→цвет = оригинал |
| COL-UI-03 | Задать детали внешний вид/«покраску» (appearance RGB) в сборке | Цвет ячейки соответствует цвету/оттенку детали в сборке (как в оригинале) |
| COL-UI-04 | Деталь без материала/покраски | Цвет по умолчанию (`rowcolor`), как в оригинале |
| COL-UI-05 | Сверка A/B по палитре | Поячеечная сверка оттенков original↔RU: **совпадение RGB** |
| COL-XLSX-01 | Экспорт BOM после `COL-UI-*` | **Accepted out of scope для текущего релиза**: цветной Excel не является release gate, если `COL-UI-*` PASS |

Метод UI-сверки оттенков: запустить одну модель в A/original и B/RU, подключить
SolidWorks, сохранить скриншоты таблицы ZTool, сравнить material-column pixels
по RGB и row-index. Если `rowheight` отличается, сравнивать индексы строк на
видимом пересечении, а не число видимых прямоугольников. FAIL — если
оттенок/соответствие material-row отличается от оригинала.

Метод XLSX-сверки оттенков отдельный: экспортировать одну модель в A и B, открыть
оба Excel или разобрать `openpyxl`, сравнить `cell.fill` соответствующих ячеек.
По продуктному решению текущего релиза принимается **UI-only material parity**:
`COL-UI PASS` закрывает цветовой gate, а отсутствие non-default fills в XLSX
не блокирует release. `COL-XLSX` возвращается в release gate только если цветной
Excel будет явно восстановлен как требование.

### 6.4 Область F — Оформление таблицы

| ID | Шаги | Ожидаемо |
|----|------|----------|
| FMT-01 | `markrepeat` (отметка повторов) | Повторяющиеся поз. отмечены так же, как в оригинале (или выкл. при `-1`) |
| FMT-02 | `colorselrow` (подсветка выбранной строки) | Поведение подсветки = оригинал |
| FMT-03 | `rowheight`/`rowcolor` | Высота/базовый цвет строки = конфиг/оригинал |

### 6.5 Область G — Эскизы/изображения

| ID | Шаги | Ожидаемо |
|----|------|----------|
| IMG-01 | Эскизные режимы (`insertimagebool`/режим с эскизами) | В колонке эскизов — изображения компонентов |
| IMG-02 | `image_size` (64×64) и `image_lockratio` | Размер/пропорции эскизов = конфиг; без искажений |

### 6.6 Область H — Фильтр-режимы

| ID | Шаги | Ожидаемо |
|----|------|----------|
| FLT-01 | «Обрабатываемые детали» | Состав = детали с `Тип`, содержащим обрабатывающие значения |
| FLT-02 | «Покупные изделия» | Состав = детали с `Тип∈{Покупное;Стандартное}` |
| FLT-03 | «С/без обработки поверхности» | Фильтр по `Тип` И `Обработка поверхности` (пусто/не пусто) |
| FLT-04 | «Недостающие обязательные свойства» | Ловит поз. с пустыми обязательными свойствами |

> Зависимость: свойство `Тип` должно быть заполнено в моделях (значения должны
> совпадать со значениями в `FilterRulesList`). Иначе фильтры вернут пусто/всё.

---

## 7. Область I — Пакетные операции

| ID | Форма / действие | Ожидаемо |
|----|------------------|----------|
| BAT-01 | `FrmOutputlist` — пакетное преобразование формата | Список загружается; конвертация форматов = оригинал |
| BAT-02 | `FrmPrintlist` — пакетная печать | Очередь/печать = оригинал |
| BAT-03 | `FrmSetDrwlist` — настройка списка чертежей | Поведение = оригинал |
| BAT-04 | `FrmSyncDrwName` — синхронизация имён чертежей | Имена синхронизируются = оригинал |

---

## 8. Область J — Буфер обмена (allow-list)

| ID | Шаги | Ожидаемо |
|----|------|----------|
| CLP-01 | В `FrmOutputlist`: «копировать» строки | «Успешно скопировано N поз.» |
| CLP-02 | Очистить список → «вставить» | Возвращаются N строк (round-trip) |
| CLP-03 | Регресс безопасности | Без ошибки `0x80131044`/`ZBinderDonor`; вредоносный payload в буфере **отклоняется** (SafeListBinder allow-list: только `List<string>`) |

---

## 9. Область K — Сохранение/переименование/read-only

| ID | Шаги | Ожидаемо |
|----|------|----------|
| SAV-01 | Сохранение в новую папку (`CheckBox6=Обновлять ссылки`) | Файлы сохранены, ссылки обновлены |
| SAV-02 | Переименование по правилам (`ReNameRule`/фильтры) | Имена по правилам = оригинал |
| SAV-03 | `ReadOnlyFolder` | Защита от записи соблюдается |

---

## 10. Область L — Превью и горячие клавиши

| ID | Шаги | Ожидаемо |
|----|------|----------|
| PRV-01 | Превью компонента | Картинка превью; позиция окна (`FrmPreviewLocation`) |
| PRV-02 | Горячие клавиши превью (`Preview_Hotkey`) | Реакция = оригинал |

---

## 11. Область M — Локализация UI

| ID | Проверка | Ожидаемо |
|----|----------|----------|
| LOC-01 | `tools/Localizer`/`localization_scan.py` | `unclassified_han=0` (нет «потерянных» иероглифов) |
| LOC-02 | Все формы/меню/сообщения | На русском; шрифт читаемый (Arial), без «кракозябр», CJK=0 |
| LOC-03 | `MANUAL_SCREENSHOTS_CHECKLIST_RU.md` + `tools/chm-i18n/compare_manual_screenshots.py` | Скриншоты help_ru.chm сравнены файл-в-файл с оригиналом; `manual_screenshot_compare.md` без `FAIL`; contact sheet просмотрен |
| LOC-04 | Русская справка `help_ru.chm` | Содержание/индекс/темы на русском |
| LOC-05 | Диалог `Параметры` → вкладка `Эскиз` (`FrmOptions`) | Подписи, combo и кнопки не перекрываются; окно можно увеличить; скриншот сохранён в evidence |

---

## 12. Область N — Стабильность и регрессии рефакторинга

Целенаправленные регресс-тесты под то, что менял рефакторинг:

| ID | Что проверяем | Ожидаемо |
|----|---------------|----------|
| REG-01 | Режим 4 (иерархическая с эскизами) | **Не падает** (был фикс шаблонов) |
| REG-02 | Init-race модалка «Ссылка на объект…» | Не появляется (`ZTool.dll` pmpguard2) |
| REG-03 | Десериализация конфига (version-tolerant) | VTBinder: конфиг читается на разных версиях |
| REG-04 | Буфер обмена | SafeListBinder allow-list (см. CLP-03) |
| REG-05 | Библиотека материалов/цвета | Цвета по материалу/покраске (см. §6.3) — после PR #23 |
| REG-06 | Запуск из пакета | Лента стартует именно `runtime/ZTool.exe` (а не системный) |
| REG-07 | Новых Application Error/.NET Runtime/WER/dump | Нет (проверить Event Viewer после прогона) |
| REG-08 | Дефолтная видимость колонок | После чистого профиля служебные SummaryInfo-колонки (`Сводка_Автор`, `Сводка_Ключевые слова`, `Сводка_Примечание`, `Сводка_Заголовок`, `Сводка_Тема`) скрыты и не мешают основной таблице |
| REG-09 | Диалог «Разделить столбец» | В `dgv_split`, `dgv_match`, `dgv2` выбранная строка удаляется клавишей `Delete`; лишние строки правил можно убрать без правки XML |

Для `REG-09` выбрать именно строку через левый row header, затем нажать
`Delete`. Если фокус находится внутри editable `ComboBox` ячейки, Delete может
обработаться редактором ячейки и не доказывает работу `SplitGrid_KeyDown`.

---

## 13. Автоматизированные проверки и живой прогон

### 13.1 Offline/pre-flight проверки (можно без SolidWorks)

Гонять до SW-приёмки; все должны быть PASS. Эти проверки **не доказывают**
паритет с оригиналом, а только подтверждают, что сборка/профиль/шаблоны готовы к
живому тесту.

Перед запуском проверить toolchain:

- `python --version` — совместимая версия Python; CI использует 3.12.
- `dotnet --list-sdks` — должен показать установленный SDK. Одного .NET Runtime
  недостаточно: `client-core/build.ps1`, `Localizer`, `Reinjector` и
  `localization_scan.py` используют `dotnet build/run`.
  Если SDK установлен в `C:\Program Files\dotnet`, но старая shell пишет
  `dotnet is not recognized`, открыть новый терминал или временно добавить путь
  в текущий процесс:
  `$env:PATH = 'C:\Program Files\dotnet;' + $env:PATH`.

- `Get-FileHash .\ZTool.exe -Algorithm SHA256`
- `Get-FileHash .\ZTool.dll -Algorithm SHA256`
- `python client-core/tools/check_bom_template.py ZTool.settings`
- `python client-core/tools/check_bom_template.py client-core/dist/ZTool.settings`
- `check_bom_template.py` обязан подтвердить anchors `МассаЕдКг` (`J6`) и
  `ГабаритныеРазмеры` (`P6`); отсутствие этих расчетных колонок блокирует релиз.
- `scripts/verify_release_package.ps1 -PackageRoot <pkg> -RequireSolidWorksTools`
  (падает при отсутствии библиотеки материалов или `usematerialcolor=false`)
- `powershell -NoProfile -ExecutionPolicy Bypass -File client-core/build.ps1`
- `dotnet run -c Release --project client-core/tools/Reinjector -- --verify client-core/out/ZTool.exe`
- `python tools/secret_scan.py`
- `git diff --check`
- Лиценз-сервер: `pytest -q license-server`, `ruff check`, `bandit` — чисто.

Для уже созданных Excel-файлов после живого экспорта:

- `python client-core/tools/validate_bom_exports.py <папка-с-8-xlsx>`
- Для строгого `BOM-07`/`BOM-08`: отдельно проверить, что в экспортированных
  файлах столбец `Тип` непустой и содержит только ожидаемые значения фильтра.

Итог `PASS/WARN` допустим для smoke-прогона, если предупреждения относятся только
к `BOM-07`/`BOM-08` с 0 строк на модели без `Тип`. Для `FULL PASS` такие
предупреждения нужно закрыть отдельной моделью/эталоном, где фильтры возвращают
ожидаемые непустые подмножества. Зафиксированный эталон строгого fixture-прогона
2026-06-17: `BOM-07` = 18 строк только `Мех.обработка`, `BOM-08` = 6 строк
только `Покупное`, пустых `Тип` = 0.

Важно: `client-core/tools/run_all_bom_exports.ps1` **не нажимает UI ZTool** и не
создаёт Excel-файлы сам. Он только создаёт чистую папку и печатает чеклист для
оператора. До появления 8 реальных `.xlsx` это не тест экспорта.

Перед UI-экспортом отключить `Показывать рядом` в ZTool. Если preview оставлен
включённым, всплывающее окно модели может перекрыть вкладку `Спецификация` и
оператор/скрипт нажмёт не тот ribbon element; такой прогон считать
невалидным и повторить после снятия preview.

### 13.2 Живой SolidWorks-прогон (обязателен для FULL PASS)

1. Выполнить registry pre-flight из §2.1: закрыть SW/ZTool, сохранить backup
   реестра, нормализовать `$env:WINDIR/SystemRoot/ComSpec`, убрать stale
   `CodeBase`, зарегистрировать текущий `runtime\ZTool.dll`.
2. Открыть `TestModel/0614-A00.SLDASM` через проводник/ассоциацию `.SLDASM`
   (`explorer.exe "<полный-путь>"` для автоматизации; не прямой
   `Start-Process <file.SLDASM>`).
3. На ленте SolidWorks открыть ZTool → `Управление файлами`.
4. Зафиксировать путь/hash процесса `ZTool.exe` командами из §2.
5. Нажать `Подключить SW`; ожидаемо 29 позиций.
6. Прогнать `PROP-RUNBOOK`: обязательно закрыть `PROP-READ-EXPORT`
   (fixture-свойства → ZTool read-back → BOM/Excel read-back). Если заявляется
   функция записи из ZTool, отдельно закрыть `PROP-WRITE-ZTOOL` по §6.2;
   без UI marker + `Сохранить в SW` + повторный read-back это `NO-GO`, а не PASS.
7. Проверить, что SummaryInfo-колонки не показаны по умолчанию (`REG-08`).
8. Прогнать «Разделить столбец»: на каждой вкладке выбрать строку через row
   header и удалить тестовую строку клавишей `Delete` (`REG-09`).
9. Экспортировать все 8 режимов BOM в отдельную папку.
10. Запустить `validate_bom_exports.py` на папку с экспортами.
11. Для `FULL PASS` закрыть строгий fixture gate `BOM-07`/`BOM-08`: оба файла
    непустые, фильтр применён, столбец `Тип` не содержит пустых значений.
12. Выполнить цветовые A/B проверки §6.3 против оригинала. Для текущего релиза
    release gate — `COL-UI`; `COL-XLSX` принят out of scope.
13. Проверить Event Viewer: нет новых `Application Error`, `.NET Runtime`, WER/dump.

Если любой из шагов 1–13 пропущен, итоговый статус — не `FULL PASS`, а
`PARTIAL / offline checked`.

---

## 14. Go / No-Go

GO только если:

- все области §4–§12 — ПАРИТЕТ PASS (или отличие явно принято как локализация/легаси);
- §6.3 `COL-UI` (цвета материал/покраска в таблице ZTool) — PASS против
  оригинала; `COL-XLSX` принят out of scope для текущего релиза;
- BOM 8/8 режимов — PASS, включая строгий fixture gate `BOM-07`/`BOM-08` с
  непустым `Тип`;
- после live-загрузки SolidWorks видна ровно одна вкладка `ZTool`; пустая
  adjacent-вкладка или anonymous `CommandManager` clone является NO-GO;
- §13 (авто-проверки) — PASS;
- релиз-пакет verifier — PASS; есть пакет/инструкция отката;
- нет новых краш/WER/dump.

---

## 15. Журнал результатов (шаблон)

Отчёты складывать в `manual-test-reports/` (имя: `FULL_TEST_<дата>.md`) и
артефакты рядом:

```text
manual-test-reports/FULL_TEST_<дата>/
  report.md
  hashes.txt
  processes.txt
  screenshots/
  bom-exports/
  event-viewer/
```

| ID | Вердикт | A (оригинал) | B (русская) | Доказательство | Заметки |
|----|---------|--------------|-------------|----------------|---------|
| BOM-01 | | | | | |
| … | | | | | |
| COL-01 | | | | | |
| … | | | | | |

Хеши проверенной связки и окружение фиксировать в шапке отчёта.
