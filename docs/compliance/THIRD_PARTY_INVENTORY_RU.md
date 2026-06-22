# Third-party inventory

Источник машинно-проверяемых данных: `docs/compliance/third_party_inventory.json`.

| Component | Paths | Origin class | License | Status | Exception |
|---|---|---|---|---|---|
| ZTool/SWTools runtime | `SWTools.exe`, `SWTools.dll`, `SWTools-base.exe`, `help_ru.chm` | modified-third-party-runtime | LEGAL-APPROVAL-PENDING | review_required | LEGAL-PENDING-ZTOOL-RUNTIME |
| Ribbon.dll | `Ribbon.dll`, `client-src/ZTool.Ribbon.dll` | bundled-third-party-runtime | UNKNOWN | review_required | LEGAL-PENDING-RIBBON |
| ExpandableGridView.dll | `ExpandableGridView.dll`, `client-src/ZTool.ExpandableGridView.dll` | bundled-third-party-runtime | UNKNOWN | review_required | LEGAL-PENDING-EXPANDABLEGRIDVIEW |
| ICSharpCode.SharpZipLib | `ICSharpCode.SharpZipLib.dll`, `client-src/ZTool.ICSharpCode.SharpZipLib.dll` | third-party-library | MIT | allowed |  |
| iTextSharp | `itextsharp.dll` | third-party-library | AGPL-3.0-only | review_required | LEGAL-PENDING-ITEXTSHARP |
| NPOI | `NPOI*.dll` | third-party-library | Apache-2.0 | allowed |  |
| ZTool_rsa.dll | `client-core/ref/ZTool_rsa.dll`, `client-src/ZTool.ZTool_rsa.dll` | bundled-third-party-runtime | LEGAL-APPROVAL-PENDING | review_required | LEGAL-PENDING-ZTOOL-RSA |
| pycryptodome | `license-server/pyproject.toml` | python-dependency | BSD-2-Clause | allowed |  |
| pytest/ruff/bandit tooling | `license-server/pyproject.toml` | python-dev-dependency | MIXED-OSS-DEV-ONLY | allowed |  |

## P4 gaps

- Неизвестные licenses (`UNKNOWN`) должны быть заменены на точные SPDX IDs.
- `LEGAL-APPROVAL-PENDING` должен быть закрыт signed approval.
- `AGPL-3.0-only` должен иметь approved commercial license, replacement plan или explicit AGPL obligation acceptance.
