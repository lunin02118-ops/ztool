# Legal approval status

Дата: 2026-06-23

## Статус

`EXTERNALLY APPROVED (non-public attestation)`

Права на modification / reverse engineering / license-server replacement / rekey модифицированного third-party ZTool/SWTools runtime **урегулированы вне репозитория** (правообладатель ↔ release owner). В Git хранится **только эта redacted-аттестация** — без текста соглашений, подписей, PDF и персональных данных.

## Модель

```text
Rights resolved externally.
Repo contains only redacted attestation/status.
No legal documents in Git.
P4 blocker exists only if release owner cannot confirm external approval
or release scope exceeds approval.
```

## P4 impact

Не является безусловным P4 blocker. **P4 legal blocker срабатывает только если:** (a) release owner не может подтвердить внешнее одобрение, **или** (b) release scope выходит за рамки approved scope.

## Covered scope (покрыто внешним approval)

- Модификация / reverse engineering / debug модифицированного ZTool/SWTools runtime.
- Замена / миграция license-server, rekey, перевыпуск ключей.
- Использование для own professional/commercial purposes (internal/own-use).

## NOT covered (оценивается отдельно)

| Item | Risk | Required action |
|---|---|---|
| Публичное распространение третьим лицам | Вне covered scope (non-transferable) | Отдельное письменное согласие; репо остаётся private |
| Ребрендинг `ZTool` → `SWTools` (товарный знак) | IP остаётся у правообладателя | Уточнить допустимость бренда |
| `itextsharp.dll` | iText 5 AGPL/commercial | Подтвердить commercial license / заменить / принять AGPL obligations |
| `Ribbon.dll`, `ExpandableGridView.dll` | Upstream/license не подтверждены | Найти origin/license или заменить/исключить |
| `ZTool_rsa.dll` | legacy/runtime lineage | Входит в covered runtime scope; подтвердить вместе с runtime |

> External approval **не** является универсальной отмычкой: оно покрывает только ZTool/SWTools runtime от правообладателя, не третьи библиотеки.

## Distribution scope

Internal engineering / own-use only. Репозиторий — private.
