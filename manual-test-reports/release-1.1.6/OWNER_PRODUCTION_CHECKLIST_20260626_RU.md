# Owner production checklist 2026-06-26

Статус: **PENDING OWNER CHECKS / PRODUCTION GO: NO-GO**.

Этот чеклист остается пользователю/аудитору после автоматических проходов PR #105.
Автоматика уже закрыла S7, S8 strict, branding/version/icon и visual surfaces
L-01, L-03, L-04, L-05, L-06, L-07, L-08, L-09, L-10, L-12, L-13, L-14.

## 1. Visual localization

Проверить вручную и приложить скриншоты/заметки:

- L-02 License dialogs: clean/no-license или activation flow. Проверить, что нет видимого старого бренда,
  нет иероглифов, текст/кнопки читаемы, контакты корректны.
- L-11 Context menu: открыть контекстное меню таблицы/материала реальным пользовательским действием.
  Проверить, что пункты читаемы, нет иероглифов и нет видимого старого бренда.
- L-15 Material/color: проверить выбор материала/цвета/случайной окраски на fixture-модели.
  Проверить, что действие применяется, текст читаем, нет иероглифов и нет видимого старого бренда.

После этого собрать cumulative visual manifest L-01..L-15 и прогнать strict validator.

## 2. Signing

Подписать production artifacts и повторить проверку без `-AllowUnsigned`:

```powershell
pwsh -NoProfile -File scripts\verify_authenticode.ps1 `
  -Path <final artifacts> `
  -ReportPath _local_artifacts\reports\p4-final\authenticode-production.json
```

Критерий: `SWTools.exe`, `SWTools.dll`, installer signed; unsigned artifacts отсутствуют.

## 3. Accepted Hashes

После owner decision обновить accepted release hashes только для реально принятого package.
Не продвигать hash, если после него был rebuild.

## 4. Final GO

Production release можно выдавать только после:

- full visual L-01..L-15 strict PASS;
- owner/auditor visual review PASS;
- Authenticode PASS без `-AllowUnsigned`;
- accepted hash promotion decision;
- явный owner Production GO.
