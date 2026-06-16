# Release baseline — 2026-06-14

Документ фиксирует состояние `main` после слияния PR #8 и PR #11. Это не
production approval, а исходная точка для фазового hardening.

## Git baseline

```text
Repository: lunin02118-ops/ztool
Branch: main
HEAD: db1c8838bafa32ae0d19ca2871bc4934e162020d
Last merge: PR #11, repo tidy/docs/CHM
```

## Functional baseline

По живым тестам PR #8 приложение работоспособно в ключевых сценариях:

- SolidWorks 2025 add-in загружается.
- ZTool запускается из ленты SolidWorks кнопкой `Управление файлами`.
- `Подключить SW` читает модель `0614-A00.SLDASM`: 29 позиций.
- BOM export проходит 8/8 режимов.
- `FrmOutputlist` copy/paste после `SafeListBinder` remap проходит без ошибки
  `ZBinderDonor`.
- Сервер лицензирования имеет server-side тесты: `66 passed, 1 skipped`.

Главные live-отчёты:

- `manual-test-reports/SUMMARY.md`
- `manual-test-reports/PR8_BOM_LIVE_TEST_20260612.md`

## Tested binary artifacts

Рекомендуемая протестированная связка по PR #8:

| Компонент | Путь в репозитории | SHA256 |
|-----------|--------------------|--------|
| `ZTool.exe` binderfix + material/color key fix | `ZTool.exe` | `C578547138DB061A29294260E5D0FAC03F6D86FF1A00A7154F0F6DC0D2DD03A9` |
| `ZTool.dll` pmpguard2 | `dumps/candidate-ru-20260609/ZTool_ru_candidate2_pmpguard2.dll` | `D053542521A6D869B2208D8C5A45D894F0FB6786CAB8A78F9AF7762D0E492EB9` |

## Repository root binary state

На момент baseline корневые бинарники не совпадают с рекомендуемой runtime
связкой:

| Компонент | SHA256 | Статус |
|-----------|--------|--------|
| `ZTool.exe` | `D41639A384DECCE9FF19D3C90E0B54AB96FA7F179631B2FD4471630D452A4833` | не финальный binderfix из live PASS |
| `ZTool.dll` | `55EDDDA3B580ABFF9A9FDC18F00807207DE9BB609CB007633BCD1F82BB957B6C` | legacy/original DLL, не pmpguard2 |
| `ZToolARM.dll` | `B04D303B9A8D1EF99D9140A9B843F65128616E2157B9196A724C50CF549C9FFD` | зафиксирован baseline |

Вывод: перед production package нужен отдельный release packaging gate, который
явно собирает пакет из правильных артефактов и генерирует manifest/SHA256SUMS.

## Server baseline

Команда:

```powershell
cd license-server
python -m pytest -q
```

Результат на baseline:

```text
66 passed, 1 skipped
```

Предупреждение:

```text
pytest_asyncio: asyncio_default_fixture_loop_scope is unset
```

Это не блокирует Phase 00, но должно быть закрыто в Phase 06.

## Documentation baseline

Текущий указатель документации:

- `docs/INDEX.md`
- `docs/DOC_AUDIT_2026-06-14_RU.md`
- `docs/PLAN_BOM_MODES_RU.md`

Новая production-рамка добавлена в:

- `docs/production/PRODUCTION_HARDENING_PLAN_RU.md`
- `docs/production/RISK_REGISTER_RU.md`
- `docs/production/AUDIT_GATES_RU.md`
- `docs/production/OPERATIONS_TODO_RU.md`

## Known baseline limitations

- Корневой runtime не является подтверждённым production package.
- Нет CI в репозитории.
- Production deployment/runbook/backup не оформлены как рабочий процесс.
- Секреты сервера пока файловые; production key management не внедрён.
- Серверный протокол совместим с legacy-клиентом, но требует hardening по
  malformed frames, timeout и state model.
- Manual SolidWorks smoke остаётся обязательным для клиентских изменений.
