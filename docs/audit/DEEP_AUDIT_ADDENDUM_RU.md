# Deep Audit — поправки к P4-плану

**Дата:** 2026-06-23  
**Источник:** внешний Deep Audit кодовой базы (артефакты `DEEP_AUDIT_ztool_RU.md`, `REAUDIT_ztool_vs_plan_RU.md`).  
**Назначение:** зафиксировать темы, которые Deep Audit добавляет к текущему плану (`docs/production/ZTOOL_P4_PERFECTION_PLAN_RU.md`, `docs/audit/REFACTORING_PLAN_2026-06-16_RU.md`) — учтённые лишь частично либо не выделенные как отдельные дорожки.

---

## 3. Что Deep Audit добавляет к P4-плану

Deep Audit поднимает несколько тем, которые наш план либо учитывал частично, либо не выделял как отдельные дорожки.

### 3.1 Legal/IP: изменить модель, не публиковать документы

Deep Audit ставит legal/IP как главный риск, потому что видит deobfuscation, publicize, patch/reinject, rekey, rebrand, replacement license-server tooling.

С учётом уточнения корректная модель:

```text
Rights resolved externally.
Repo contains only redacted attestation/status.
No legal documents in Git.
P4 blocker exists only if release owner cannot confirm external approval
or release scope exceeds approval.
```

**Что это меняет в нашем процессе (Sprint B — Legal/compliance closure):**

- Права на модификацию/реконфигурацию third-party ZTool/SWTools runtime урегулированы **вне репозитория** (между правообладателем и release owner); репозиторий **не** является местом хранения правоустанавливающих документов.
- В Git хранится **только redacted attestation/status** — краткая отметка факта урегулирования прав и охвата (scope), без персональных данных, подписей и текста соглашений.
- **Никаких юридических документов в Git** (подписанные PDF, сканы, полные тексты соглашений) — их следует убрать из трекинга и держать во внешнем доверенном хранилище.
- **P4 legal blocker** срабатывает **только** если: (a) release owner не может подтвердить внешнее одобрение, **или** (b) охват релиза (release scope) выходит за рамки одобренного.

**Action items:**

1. Заменить любые правоустанавливающие документы в Git на redacted attestation (`docs/legal/ATTESTATION_RU.md` — факт урегулирования + scope + ответственный + дата; без текста соглашения/подписей).
2. Провести ревизию `docs/legal/` и истории на предмет полных юр-документов/PDF и вынести их во внешнее хранилище.
3. В Sprint B / Definition of Done добавить гейт: «release scope ⊆ approved scope; release owner подтвердил внешнее одобрение» — иначе legal blocker.
