# Legal approval status

Дата: 2026-06-22

## Статус

`BLOCKED / PENDING APPROVAL`

Юридическое право на modification/rebrand/rekey/distribution modified third-party ZTool/SWTools runtime не подтверждено в репозитории.

## P4 impact

Это P4 blocker. Технические gates могут готовить evidence, но final GO невозможен до заполнения `docs/compliance/LEGAL_APPROVAL_TEMPLATE_RU.md` и сохранения approval evidence.

## Known high-risk items

| Item | Risk | Required action |
|---|---|---|
| ZTool/SWTools runtime | Право на модификацию и распространение не зафиксировано | Legal approval |
| `ZTool_rsa.dll` | Часть legacy/runtime lineage | Legal approval вместе с runtime |
| `itextsharp.dll` | Возможная AGPL/commercial obligation | Подтвердить commercial license, заменить библиотеку или формально принять AGPL obligations |
| `Ribbon.dll`, `ExpandableGridView.dll` | Upstream/license не подтверждены | Найти origin/license или заменить/исключить |

## Distribution scope

Пока approval не получен, допустимый scope: internal engineering/testing only.
