Full SolidWorks memory dump for ZTool icon/resource extraction.

NOTE (2026-06-16): the 3 GB dump itself is NO LONGER stored in this Git
repository. It exceeded the Git LFS budget and broke clean `git clone`
(LFS smudge error on checkout of HEAD). The dump is a one-time RE source
artifact and is reproducible on the SolidWorks machine (see "How to
recover the dump" below). This README is the recovery record.

Source (original capture):
D:\ztool-dump\manual-test-20260609-081854\SLDWORKS_1344_full.dmp

Reassembled file SHA256:
1E2BEFFBB9441485BB4C14A5FAA05E44B903CDBB10C71119B3BD0E10735F3595

Size:
3,076,015,006 bytes

Split parts (former repo files, removed from Git):
part001: 1,610,612,736 bytes  sha256 a5d8d80b76101097f7589df7aa0a39fa55c4f2d4d90cb9ae68ba67a2212ed33c
part002: 1,465,402,270 bytes  sha256 f5794a85f95c78121a21600bba027b97ad5984be3a0780f40eab8f8ba8af75a4

How to recover the dump:

Option A — regenerate it (canonical, always available). The dump is a
reproducible RE artifact, not unique data. On the SolidWorks machine:
  1. Open the assembly TestModel/0614-A00.SLDASM and run the ZTool add-in
     so SLDWORKS.exe loads ZTool.dll (the protected satellite resources are
     mapped into the process).
  2. Take a FULL process dump of SLDWORKS.exe, e.g.:
       procdump64 -ma SLDWORKS.exe SLDWORKS_full.dmp
     (or Task Manager > Details > SLDWORKS.exe > "Create dump file").
  This yields an equivalent dump; exact bytes/SHA256 will differ per run,
  which is fine — only the embedded ZTool resources matter.

Option B — download the archived copy of THIS exact dump (optional).
  If the original parts were uploaded somewhere (e.g. a GitHub Release asset
  of this repo, or a network drive / S3 bucket), fetch both parts and verify
  against the per-part SHA256 above. Archive location (fill in if used): <none yet>

Rebuild on Windows (only for Option B, after downloading both parts):
copy /b SLDWORKS_1344_full.dmp.part001+SLDWORKS_1344_full.dmp.part002 SLDWORKS_1344_full.dmp

Context:
SolidWorks Premium 2025 SP3.0, live process dump from the manual ZTool test.
Needed to recover the protected ESYGdDVneyZGaacscwWoIlKTWklM satellite resources
used by ZTool.dll ribbon icons.
