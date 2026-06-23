# Шаблон redacted attestation для SWTools/ZTool

> Цель: зафиксировать **факт** внешнего одобрения и его scope **без хранения юр-документов в Git**.
> НЕ вкладывать сюда: текст соглашения, PDF, сканы, подписи, персональные данные.

## Attestation (заполняет release owner)

| Поле | Значение |
|---|---|
| External approval существует (yes/no) | TBD |
| Approved scope: modification | TBD |
| Approved scope: reverse engineering / debug | TBD |
| Approved scope: license-server replacement / migration | TBD |
| Approved scope: rekey / перевыпуск ключей | TBD |
| Approved scope: rebrand | TBD (часто NOT covered) |
| Approved scope: distribution третьим лицам | TBD (часто NOT covered) |
| Release scope ⊆ approved scope (yes/no) | TBD |
| Ссылка на внешнее хранилище документа (вне Git) | TBD |
| Ответственный (release owner) | TBD |
| Дата | TBD |

## Правило P4

- Если «External approval существует» = no → **P4 legal blocker**.
- Если «Release scope ⊆ approved scope» = no → **P4 legal blocker**.
- Иначе legal-гейт считается закрытым (без хранения юр-документов в Git).
