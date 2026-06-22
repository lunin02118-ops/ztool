# From-source closure status

Дата: 2026-06-22

## Статус

`IN PROGRESS`

Этот baseline PR создан поверх `#66` и не включает ещё изменения `#65`.

`#65 Phase E: build release package from source` закрывает главный source-of-truth разрыв: релизный пакет должен брать `SWTools.exe` из `client-src` и `SWTools.dll` из `client-src-addin`, а legacy reinjection становится ручным diagnostic path.

## Что считается authoritative

До merge `#65` authoritative release artifact остаётся только пакет/installer, чей hash закреплён в `scripts/expected_release_hashes.json`.

Loose root binaries:

- `SWTools.exe`;
- `SWTools.dll`;
- `SWTools-base.exe`;

не считаются authoritative release artifacts, если их hash не совпадает с `scripts/expected_release_hashes.json`.

## P4 blocker

P4 нельзя закрыть, пока одно из двух не выполнено:

1. `#65` merged, expected hashes обновлены под deterministic from-source outputs, release package rebuilt from source; или
2. split source/reinjection/runtime официально принят в release dossier с binary provenance для каждого patch step.

## Следующее действие

После merge `#65` нужно перегенерировать `docs/audit/BINARY_PROVENANCE_RU.md`:

```powershell
pwsh -NoProfile -File scripts/generate_binary_provenance.ps1
pwsh -NoProfile -File scripts/verify_binary_provenance.ps1
```
