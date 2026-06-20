# Декомпозиция исходников — Фаза 3b: ребрендинг SWTools + русификация в исходниках

Дата: 2026-06-20
Ветка: `devin/1782000000-phase3-rebrand-localization` (стек поверх Фазы 2 — `devin/1781976868-phase2-from-source-licensing`)
Скоуп: `client-src/` (сборка клиента из исходников)

## 1. Цель

Перенести все преобразования, которые сейчас выполняет бинарный инструмент
`client-core/tools/Localizer` (IL-перезапись готового `ZTool.exe`), в исходный код
форм/классов/ресурсов `client-src`, чтобы сборка из исходников давала тот же
результат, что и боевой реинжект: ребренд **SWTools**, полностью русский UI без
китайского, без вендорского апдейт-чека, корректные окна «О программе» и
«Лицензия не обнаружена», логотип/иконка с сайта.

Боевые сценарии, зависящие от SolidWorks, проверяет агент на машине с SW 2025
(см. ТЗ `from-source-phase-3b-acceptance-TZ_RU.md`). Здесь — только standalone
UI-верификация и сборка.

## 2. Что сделано (соответствие трансформам Localizer)

| Трансформ Localizer | Перенос в исходники |
|---|---|
| `DisableUpdateCheck` | `CheckUpdate.getinfo()` — без сетевого запроса (`findnew=false`); `CheckUpdate.LinkLabel1_LinkClicked()` — без запуска браузера; `Frmmain.haveupdate()` → `return false`; нейтрализованы вызовы `CheckUpdate.Show()` в ленте `Frmmain` и в стартовом пробинге `MyapplicationContext`; статус-строка → «Обновления отключены» |
| `BlankVendorContacts` | Очищены литералы `mail@z-tool.cn`, `www.z-tool.cn`, QQ, Taobao в `FrmRverify`, `FrmAbout`, `CheckUpdate` |
| `TuneFrmRg` | `FrmRg`: проценты 4 столбцов кнопок → 34/6/38/22; длинный лейбл пароля укорочён |
| `FixAboutTitle` | `FrmAbout.AboutBox1_Load`: разделители «О программе&nbsp;» + «&nbsp;—&nbsp;{0}» |
| `SetBrandAttributes` | `AssemblyInfo.cs`: `AssemblyProduct("SWTools")` (Company/Trademark — внутренние ключи, оставлены) |
| `RebrandClientStrings` | Точечные ldstr: `ZTool`→`SWTools`, `ZTool.lnk`→`SWTools.lnk`, `ZTool Updater`→`SWTools Updater`, реестр `SWTools` (SR.cs ×2, FrmRg.cs), ярлык (MyShellLink.cs, code.cs, FrmOptions.cs), Author BOM (Frmbom.cs) |
| `RetargetDllImport` | `ZTool.JDK/Prog1.cs`,`Prog2.cs`: `DllImport("ZToolARM.dll")`→`"SWToolsARM.dll"` (12 сайтов) |
| `PatchAboutBox` | Метод-хелпер `zt_AboutSetup()`, вызывается в конце `AboutBox1_Load`: лого-баннер (`SWToolsLogo.png`, 360×72), ссылка «Перейти на сайт», строка Email, ссылка «Связаться в MAX», MAX-QR, кнопка OK; старая таблица/кнопка лога скрыты; форма 360×342 |
| `PatchVerifyContacts` | Метод-хелпер `zt_VerifySetup()`, вызывается в конце `InitializeComponent`: скрыты вендорские грид-панели (TableLayoutPanel3/4), компактный баннер «Лицензия не обнаружена» (15.75pt Bold), Email, ссылка «Перейти на сайт», «Проба»→«Демо», MAX-QR поднят, форма 402×300 |
| `InjectMaxQr` | Аксессор `Resources.二维码` отдаёт MAX-QR из манифест-ресурса `MaxQr.png` |
| `ReplaceWin32AppIcon` / `RetargetFormIcons` | `app.ico` заменён на SWTools-иконку; `<ApplicationIcon>` в csproj; аксессор `Resources.ztool_11` → `SWToolsApp.ico`; иконки 7 вторичных форм репойнтнуты на этот аксессор |

Ассеты добавлены как embedded-ресурсы в `ZTool.csproj`:
`app.ico`→`SWToolsApp.ico`, `MaxQr.png`→`MaxQr.png`, `SWToolsLogo.png`→`SWToolsLogo.png`.

## 3. Сборка

`dotnet build ZTool.csproj -c Release` → **0 ошибок, 0 предупреждений**, получен
`bin\Release\net48\ZTool.exe` (3.27 МБ).

## 4. Standalone-верификация (без SolidWorks)

Запуск `ZTool.exe` рядом с нативной `SWToolsARM.dll` (донгл-DLL ставит инсталлятор;
для теста скопирована рядом с exe). Результаты (видео и скриншоты — в PR):

1. **Ребренд:** заголовок окна «SWTools 1.0(x64)», иконка — лого с сайта (S+W).
2. **UI полностью русский, китайского 0** — лента, меню File, оба диалога.
3. **«Лицензия не обнаружена» (FrmRverify):** компактный баннер, Email, «Перейти
   на сайт», MAX-QR, кнопки «Демо»/«Регистрация»/«Отмена»; вендорских контактов нет.
4. **«О программе» (FrmAbout):** заголовок «О программе SWTools — …», лого-баннер,
   ссылки сайт/Email/MAX, MAX-QR, OK; китайского/вендорских контактов нет.
5. **Апдейт-чек отключён:** при старте нет вендорского попапа; кнопка «Проверить
   обновления» инертна (нет окна, нет запуска браузера, нет китайского текста).

## 5. Что НЕ изменено (намеренно)

- **Имя сборки `ZTool`**, `AssemblyCompany`/`AssemblyTrademark` — внутренние ключи
  лицензионного хендшейка, сохранены.
- **Протокольные/хендшейк-ключи** (`冰雨。。。`, `来生缘。。。`, `忘情水。。。`,
  `今天。。。`, `笨小孩。。。`) и **CJK-имена шрифтов** (`微软雅黑` и т.п.) — не
  переводятся (это явно прописано в Localizer: «Font names and protocol keys MUST
  NOT be translated»). Внутренний ключ типа детали `零件` восстанавливается
  Localizer'ом и сохранён. Всё это не видно в UI.
- **Имя свойства-аксессора `二维码`** — внутренний идентификатор, репойнтнут на MAX-QR.

## 6. Открытые пункты для агента SW-2025

См. ТЗ `from-source-phase-3b-acceptance-TZ_RU.md`: активация/перенос лицензии с
донглом, запись в реестр `HKCU\SOFTWARE\SWTools`, ярлык `SWTools.lnk`, загрузка
нативной `SWToolsARM.dll`, живой BOM-экспорт.
