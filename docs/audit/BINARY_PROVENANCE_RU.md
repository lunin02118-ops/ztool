# Binary provenance matrix

Generated: 2026-06-22T19:14:35Z

| Artifact | Current path | Role | Origin class | Expected SHA256 | Actual SHA256 | Status | Notes |
|---|---|---|---|---|---|---|---|
| Setup installer | `releases/1.1.6/SWTools-1.1.6-Setup.exe` | installer | generated release artifact | `26aabcfbb6dec8538e96076df79d235a2b729bb73f2519d8b0513a03f155ab13` | `not present` | BLOCKED | Exact release installer. |
| Client EXE | `SWTools.exe` | loose client binary | historical/non-authoritative | `f418c7d81a735c309b4fb0709c8bd81333d95cfab9c7468aa2329add0a364e09` | `a57441105c5d02f8c01f920ac23e56a94ca027615520e7c29c5fb1c57fd73ec5` | WARN | Must not be used as release source unless hash matches accepted package. |
| Add-in DLL | `SWTools.dll` | loose add-in binary | historical/non-authoritative | `5dbf9986a4fbce5e6ab8fa4269705732c6ba891d1b27988e60e10c191ae290c1` | `d053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9` | WARN | Must not be used as release source unless hash matches accepted package. |
| Base EXE | `SWTools-base.exe` | legacy base input | patched legacy input | `` | `c10ce334fdbbbc05b8186a6e657a22c1ed4add8bd638c59d65e5b6798cb4b18d` | INFO | Lineage diagnostic only. |
| Ribbon runtime | `Ribbon.dll` | runtime dependency | bundled third-party | `57e026815738a47e988048b95b354ab107cd80e559d0775d0897d68950e24e8e` | `57e026815738a47e988048b95b354ab107cd80e559d0775d0897d68950e24e8e` | PASS | License/origin review required. |
| Expandable grid runtime | `ExpandableGridView.dll` | runtime dependency | bundled third-party | `89ec31d68a132c02f725903d52d5c5c7c422a2aa997a8a8444685a4374cefcc0` | `89ec31d68a132c02f725903d52d5c5c7c422a2aa997a8a8444685a4374cefcc0` | PASS | License/origin review required. |
| RSA helper | `client-core/ref/ZTool_rsa.dll` | runtime dependency | bundled legacy runtime | `274a33f35b98437d57f7eadce21cfe855d5285e9012c1c33733a3ab1f0ec2a90` | `274a33f35b98437d57f7eadce21cfe855d5285e9012c1c33733a3ab1f0ec2a90` | PASS | Distribution rights tied to runtime approval. |
| Russian help | `help_ru.chm` | user help | generated/packaged asset | `` | `9a8a7da1ea91ca6e51ae745ba5a4f7caa8314f8ecfc32e1e827aeac42a2a8646` | INFO | Need CHM source/build evidence. |
| Runtime settings | `SWTools.settings` | config | repository asset | `` | `f969e4475f5b0a256171fbbdd6d93c2f0ca4a0771f49829efaa1b3d644a7500a` | INFO | Path-patched during package build. |

Loose root binaries are non-authoritative unless their hashes match `scripts/expected_release_hashes.json`.
