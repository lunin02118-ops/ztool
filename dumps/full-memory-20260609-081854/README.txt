Full SolidWorks memory dump for ZTool icon/resource extraction.

NOTE (2026-06-16): the 3 GB dump itself is NO LONGER stored in this Git
repository. It exceeded the Git LFS budget and broke clean `git clone`
(LFS smudge error on checkout of HEAD). The dump is a one-time RE source
artifact and is reproducible on the SolidWorks machine, so it has been
moved to external archival storage. This README is the recovery record.

Source (original capture):
D:\ztool-dump\manual-test-20260609-081854\SLDWORKS_1344_full.dmp

Reassembled file SHA256:
1E2BEFFBB9441485BB4C14A5FAA05E44B903CDBB10C71119B3BD0E10735F3595

Size:
3,076,015,006 bytes

Split parts (former repo files, now archived externally):
part001: 1,610,612,736 bytes  sha256 a5d8d80b76101097f7589df7aa0a39fa55c4f2d4d90cb9ae68ba67a2212ed33c
part002: 1,465,402,270 bytes  sha256 f5794a85f95c78121a21600bba027b97ad5984be3a0780f40eab8f8ba8af75a4

Where to get it:
- Archived outside Git (e.g. a GitHub Release asset of this repo, or a
  network drive / S3 bucket). Update this line with the exact location
  after upload. Verify with the SHA256 values above after download.

Rebuild on Windows (after downloading both parts):
copy /b SLDWORKS_1344_full.dmp.part001+SLDWORKS_1344_full.dmp.part002 SLDWORKS_1344_full.dmp

Context:
SolidWorks Premium 2025 SP3.0, live process dump from the manual ZTool test.
Needed to recover the protected ESYGdDVneyZGaacscwWoIlKTWklM satellite resources
used by ZTool.dll ribbon icons.
