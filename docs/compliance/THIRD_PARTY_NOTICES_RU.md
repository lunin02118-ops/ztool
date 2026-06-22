# Third-party notices

Этот файл является рабочим notice dossier для P4 readiness. Перед production release он должен быть включён в release dossier/package или заменён generated notices artifact.

## NPOI

License: Apache-2.0.
Package files: `NPOI.dll`, `NPOI.OOXML.dll`, `NPOI.OpenXml4Net.dll`, `NPOI.OpenXmlFormats.dll`.

Required action: include Apache-2.0 notice and upstream copyright.

## ICSharpCode.SharpZipLib

License: MIT.
Package files: `ICSharpCode.SharpZipLib.dll`.

Required action: include MIT notice and upstream copyright.

## pycryptodome

License: BSD-2-Clause.
Server dependency in `license-server/pyproject.toml`.

Required action: include server dependency notice if server package is distributed.

## iTextSharp

License status: `AGPL-3.0-only` / commercial license decision required.
Package files: `itextsharp.dll`.

Required action before P4 GO: confirm commercial license, replace dependency, or formally accept AGPL obligations with legal sign-off.

## ZTool/SWTools modified runtime

License status: legal approval pending.
Package files: `SWTools.exe`, `SWTools.dll`, `SWTools-base.exe`, `help_ru.chm`, `ZTool_rsa.dll`.

Required action before P4 GO: document modification/rebrand/rekey/distribution rights.

## Unknown bundled DLLs

Components: `Ribbon.dll`, `ExpandableGridView.dll`.

Required action before P4 GO: identify upstream and license, or replace/remove.
