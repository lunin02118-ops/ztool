# Client source warning baseline

Дата baseline: 2026-06-23
Scope: `client-src` + `client-src-addin`, `Release`, .NET SDK Windows runner/local.

Этот файл фиксирует текущие предупреждения from-source сборки. Они не являются
новой нормой качества для будущего кода: это контролируемый baseline для
восстановленных/decompiled исходников. Новый warning-код или изменение количества
должны либо устраняться, либо явно обновлять этот файл и проходить ревью.

## Машинно-читаемый baseline

<!-- CLIENT_SRC_WARNING_BASELINE_JSON_START -->
{
  "schema": 1,
  "configuration": "Release",
  "generated_at": "2026-06-23T03:30:00Z",
  "projects": {
    "client-src": {
      "total": 123,
      "codes": {
        "CS0162": 24,
        "CS0169": 16,
        "CS0219": 42,
        "CS0414": 4,
        "CS0649": 31,
        "CS1717": 6
      }
    },
    "client-src-addin": {
      "total": 6,
      "codes": {
        "CS0414": 6
      }
    }
  }
}
<!-- CLIENT_SRC_WARNING_BASELINE_JSON_END -->

## Классификация

| Code | Project | Count | Class | Decision |
|---|---:|---:|---|---|
| `CS0162` | `client-src` | 24 | benign decompiler/control-flow artifact | Оставить до плановой чистки; не менять поведение ради косметики. |
| `CS0169` | `client-src` | 16 | benign WinForms/decompiler field artifact | Оставить; часто это поля форм/старых обработчиков. |
| `CS0219` | `client-src` | 42 | benign decompiler local artifact | Оставить; переменные появились при восстановлении IL. |
| `CS0414` | `client-src` | 4 | benign decompiler field artifact | Оставить; не влияет на runtime. |
| `CS0649` | `client-src` | 31 | benign WinForms designer/component artifact | Оставить; типично для восстановленных форм. |
| `CS1717` | `client-src` | 6 | suspicious-but-known decompiler assignment artifact | Не править без parity-теста конкретного метода. |
| `CS0414` | `client-src-addin` | 6 | benign recovered add-in field artifact | Оставить до semantic cleanup Sprint H/I. |

## Проверка

```powershell
pwsh -NoProfile -File scripts/check_client_src_warnings.ps1
```

Ожидаемый результат: `client source warning baseline: PASS`.

## Политика изменения

1. Если warning можно безопасно убрать локальной правкой без изменения поведения,
   сначала убрать его и обновить baseline вниз.
2. Если warning добавлен новой разработкой, это blocker.
3. Если warning является артефактом recovery/decompiler и убрать его нельзя без
   риска parity-регрессии, обновить baseline в этом файле и объяснить причину в PR.
