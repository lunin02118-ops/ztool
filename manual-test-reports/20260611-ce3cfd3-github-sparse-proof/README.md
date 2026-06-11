# GitHub-source retest proof, commit ce3cfd3

This report verifies that the tested build was taken from GitHub repo
`lunin02118-ops/ztool`, branch `integration/all-prs`, commit
`ce3cfd36a9edaf19672d11a4fa345f69734d3e53`.

Key proof:

- Runtime folder: `D:\Development\ztool\manual-test-github-sparse-ce3cfd3`
- `ZTool.exe` process path: `D:\Development\ztool\manual-test-github-sparse-ce3cfd3\ZTool.exe`
- `ZTool.exe` SHA256: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`
- `ZTool.dll` SHA256: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
- `ZTool-base.exe` was present but was not launched.

Result:

- PASS: launcher selects the patched `ZTool.exe`.
- PASS: update popup `3.8.5` does not appear.
- PASS: read from SW works; no more `0` positions.

See `LIVE_TEST_REPORT.md` and screenshots for details.
