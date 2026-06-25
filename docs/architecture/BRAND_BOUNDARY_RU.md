# SWTools brand boundary

Дата: 2026-06-25
Статус: архитектурный контракт для следующего refactoring / release-hardening спринта.

## 1. Решение

Публичный продуктовый бренд: **SWTools**.

Внутреннее legacy-имя **ZTool** допускается только как compatibility identity, если его переименование может сломать:

- .NET `AssemblyName`;
- namespace / folder layout recovered source tree;
- COM / SolidWorks add-in registration identity;
- resource logical names, которые ожидаются runtime-кодом;
- сериализованные ключи, protocol keys, cryptographic / license handshake constants;
- documented compatibility comments explaining why the token must stay.

Любое видимое пользователю `ZTool` считается дефектом уровня P0 для production release.

## 2. Запрещённая зона: visible/public surface

`ZTool` не должен появляться в:

- window title / dialog title;
- `MessageBox`, `InputBox`, toast/status text;
- Ribbon, menu, context menu, toolbar, tooltip;
- CHM title, CHM body, HHC/HHK navigation, runtime help topics;
- installer UI, uninstall UI, Start Menu shortcuts if visible;
- release notes, release dossier, public-facing production docs;
- product metadata visible through file properties: ProductName, Company, FileDescription, Title;
- SolidWorks add-in manager Title / Description;
- registry Title / Description values written for visible add-in registration;
- screenshots and visual localization manifests.

## 3. Разрешённая зона: internal compatibility surface

`ZTool` may remain when removal is a compatibility risk and the location is not user-visible:

- `<AssemblyName>ZTool</AssemblyName>` in `client-src/ZTool.csproj` and `client-src-addin/ZTool.SwAddin.csproj`;
- namespace and source path names such as `client-src/ZTool/**` / `client-src-addin/ZTool/**`;
- COM identity and code that relies on assembly identity, provided visible registry values are `SWTools`;
- embedded resource logical names where the code resolves them by exact name;
- cryptographic/license protocol constants and persisted serialized keys;
- migration/deobfuscation tooling that refers to the original internal identity;
- architecture/audit documents that explicitly describe the compatibility boundary.

Internal allowance is not a blanket exception. If the same file contains visible string literals, those literals must still use `SWTools`.

## 4. Gate policy

Required gates before production GO:

```powershell
python tools/check_source_string_invariants.py --root client-src --root client-src-addin
python tools/chm-i18n/check_chm_brand.py help_ru.chm
python tools/chm-i18n/check_help_entry_routes.py --chm help_ru.chm
python tools/e2e/assert_visual_localization_manifest.py <manifest> --require-surface-file docs/localization/VISUAL_LOCALIZATION_SURFACES_L01_L15.json --require-profile-surfaces-captured --require-runtime-match --allow-warn
```

New refactoring work must add a dedicated brand-boundary gate:

```powershell
python tools/check_visible_brand_boundary.py --self-test
python tools/check_visible_brand_boundary.py
```

Expected behavior:

- unallowlisted internal `ZTool` token: FAIL;
- any user-visible `ZTool`: FAIL;
- documented internal compatibility token: PASS;
- forbidden text in visual manifest: FAIL;
- incomplete L-01..L-15 capture: FAIL for production acceptance.

## 5. Release decision rule

Production GO is forbidden until all conditions are true:

- source-built `SWTools.exe` and `SWTools.dll` are release inputs;
- release package manifest says `input_mode = source-build-output`;
- visible `ZTool = 0` across source-level public strings, CHM, installer and visual evidence;
- visible Han/CJK user-facing text = 0, except explicitly `record_only` host surfaces;
- S7 SolidWorks connection automation PASS;
- S8 BOM export automation PASS for all required modes;
- strict visual localization profile L-01..L-15 PASS;
- final release dossier generated from machine-readable artifacts;
- no P0/P1 defect remains open without owner-signed exception.

## 6. Non-goals

This contract does not require immediate renaming of internal namespaces, source directories, COM identities or assembly identities. That would be a separate compatibility migration and must not be bundled into release-hardening unless a full regression plan exists.
