# Help branding fix report

Дата: 2026-06-25

Scope: исправить blocker visual localization L-12, где русская справка могла
показывать legacy brand `ZTool` в заголовке/тексте.

## Изменения

- Пересобран `help_ru.chm` с видимым brand `SWTools`.
- `tools/chm-i18n/build_ru.py` теперь заменяет видимый `ZTool` -> `SWTools`
  при генерации HTML-тем и HHC/HHK навигации.
- Добавлен gate `tools/chm-i18n/check_chm_brand.py`:
  - сканирует бинарный CHM на запрещенный token;
  - декомпилирует CHM через `C:\Windows\hh.exe`;
  - проверяет декомпилированные `.htm/.hhc/.hhk` на запрещенный `ZTool`;
  - требует наличие `SWTools`.
- `release-acceptance` теперь запускается при изменении `help_ru.chm` и
  выполняет `Russian CHM brand gate`.
- Обновлен `docs/audit/BINARY_PROVENANCE_RU.md` с новым SHA256 `help_ru.chm`.

## Build/provenance notes

Локальный компилятор HTML Help был установлен только в `_local_artifacts`:

```text
D:\Development\ztool\_local_artifacts\tools\htmlhelp\extract\hhc.exe
```

Источник tool package:

```text
https://github.com/EWSoftware/SHFB/raw/master/ThirdPartyTools/htmlhelp.exe
SHA256: CF8FE5A02D3C2BF0C8728DD399DC3B2587C4139FFB23EF4268F34535A6157B87
```

При компиляции `hhc.exe` вывел warning:

```text
HHC6003: The file Itircl.dll has not been registered correctly.
```

CHM при этом был создан, открывается через `hh.exe`, декомпилируется обратно и
проходит brand/content checks. Warning сохраняется как остаточный риск для
финального release dossier: перед Production GO нужно подтвердить официальный
HTML Help Workshop toolchain или зарегистрированный full-text-search component.

## Evidence

Новый `help_ru.chm`:

```text
SHA256: 5E59B1BCF9AEEF552345E64276694494AA3A7B7419012428C619C37AFCD762D6
Size: 3599928 bytes
```

Декомпиляция нового CHM:

```text
text_files: 12
ZTool matches: 0
SWTools matches: 5 files
```

Machine gate:

```text
python tools\chm-i18n\check_chm_brand.py help_ru.chm --json-out _local_artifacts\reports\chm-help-branding-20260625\chm-brand-check.json
PASS
```

Visual L-12 capture:

```text
python scripts\swtools_visual_localization_capture.py --output-dir _local_artifacts\reports\chm-help-branding-20260625\visual-L12 --surface-file docs\localization\VISUAL_LOCALIZATION_SURFACES_L01_L15.json --surface-id L-12
PASS

window_title: SWTools — Руководство пользователя
forbidden_texts: []
visible_han_texts: []
screenshot_sha256: C561CA1FB55404D0A327CEC46892284AE396289EB63D85C75178FCC3426B8637
```

Visual manifest assertion:

```text
python tools\e2e\assert_visual_localization_manifest.py _local_artifacts\reports\chm-help-branding-20260625\visual-L12\visual-localization-manifest.json --require-surface L-12
PASS
```

## Remaining gates

`Visual FULL PASS` не заявлен.

Остается:

- проверить help buttons H-01..H-03 из runtime;
- доснять полный L-01..L-15 visual profile;
- пройти owner/auditor visual review;
- подтвердить final signing/package/release dossier.

Production GO: NO-GO.
Visual FULL PASS: NO-GO.
