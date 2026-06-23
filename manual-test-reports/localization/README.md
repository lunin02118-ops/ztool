# Localization manual evidence

Этот каталог предназначен для curated summary reports. Сырые скриншоты,
видео, логи, временные HTML/JSON и большие evidence packs хранить в
`_local_artifacts\reports\localization-sprint-h\` до финального отбора.

## Перед merge Sprint H

Пользовательский аудит обязателен. Минимальный набор кадров:

```text
L-01-main-window.png
L-02-license-dialogs.png
L-03-bom-menu-8-modes.png
L-04-frmexportbom.png
L-05-frmmapping.png
L-06-filter-rules.png
L-07-options-tabs.png
L-08-save-options.png
L-09-filling-tabs.png
L-10-units.png
L-11-context-menus.png
L-12-help-ru.png
L-13-solidworks-addin.png
L-14-installer-ui.png
```

## Формат итогового отчёта

```text
Build/hash:
Operator:
Date:
Automated localization scan:
Screenshots reviewed:
Findings:
Decision: PASS / FAIL / PASS WITH EXCEPTIONS
```

Не коммитить private keys, license codes, server endpoints, customer data or
private approvals in screenshots.
