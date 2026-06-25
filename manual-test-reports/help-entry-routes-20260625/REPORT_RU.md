# H-01..H-03 help entry route regression report

Дата: 2026-06-25

## Статус

`PARTIAL PASS / PRODUCTION GO: NO-GO / VISUAL FULL PASS: NO-GO`

Этот PR закрывает machine-readable regression для runtime-кнопок справки
H-01..H-03. Полный visual FULL PASS по L-01..L-15 и ручной owner/auditor review
остаются обязательными перед production GO.

## Что было найдено

После #91 прямое открытие `help_ru.chm` и brand gate проходили, но source-код
runtime-кнопок справки всё ещё ссылался на старые китайские CHM routes:

| ID | Source | Старый route |
|---|---|---|
| H-01 | `client-src/ZTool/Frmexportbom.cs` | `/进阶操作/BOM表模板制作和导出.htm` |
| H-02 | `client-src/ZTool/FrmPreview.cs` | `/进阶操作/缩略图显示及操作.htm` |
| H-03 | `client-src/ZTool/FrmSaveOption.cs` | `/基本操作/保存数据到SolidWorks.htm` |

В пересобранном русском `help_ru.chm` эти файлы уже переименованы в ASCII:

| ID | Реальный topic в `help_ru.chm` |
|---|---|
| H-01 | `advanced/bom-template.htm` |
| H-02 | `advanced/thumbnails.htm` |
| H-03 | `basic/save-to-sw.htm` |

Это означало, что #91 закрыл видимый brand справки, но не доказывал, что
runtime-кнопки помощи открывают существующие русские страницы.

## Исправление

- `Frmexportbom`: route изменён на `/advanced/bom-template.htm`.
- `FrmPreview`: route изменён на `/advanced/thumbnails.htm`.
- `FrmSaveOption`: оба route изменены на `/basic/save-to-sw.htm`.
- Старые help-path литералы удалены из `tools/string_invariants/source_allowed_han.tsv`.
- Добавлен gate `tools/chm-i18n/check_help_entry_routes.py`.
- `release-acceptance.yml` теперь запускает `Russian CHM help entry route gate`.

## Проверки

```text
python tools\chm-i18n\check_help_entry_routes.py --self-test
PASS

python tools\chm-i18n\check_help_entry_routes.py --chm help_ru.chm
PASS: H-01..H-03 source routes point to existing CHM topics.

python tools\chm-i18n\check_chm_brand.py help_ru.chm
PASS

python tools\check_source_string_invariants.py --root client-src --root client-src-addin
PASS: distinct CJK literals found = 35; old help-path debt removed.

dotnet build client-src\ZTool.csproj -c Release -warnaserror:false
PASS: 0 errors; 123 known warnings.
```

## Остаточный риск

- Этот PR не утверждает visual FULL PASS.
- Нужно отдельно выполнить live visual capture H-01..H-03 из UI и полный профиль
  L-01..L-15.
- `help.CHM` в корне остаётся исходным китайским артефактом; релизный пакет
  копирует `help_ru.chm` как runtime `help.CHM`, поэтому gate проверяет именно
  `help_ru.chm`.
