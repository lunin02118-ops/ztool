# SSH keys audit

Date: 2026-06-12
Machine: `VladimirWorkPC`
Directory: `C:\Users\VladimirWorkPC\.ssh`

No private key material or plaintext passwords are included in this report.

## Inventory

| File | Size | Last write | Type / status |
| --- | ---: | --- | --- |
| `id_rsa` | 3294 | 2026-04-06 13:43 | RSA private key |
| `id_rsa.pub` | 744 | 2026-04-06 13:43 | public key for `id_rsa` |
| `rheolab_deploy` | 3294 | 2026-04-12 10:20 | RSA private key |
| `rheolab_deploy.pub` | 741 | 2026-04-12 10:20 | public key for `rheolab_deploy` |
| `authorized_keys` | 18 | 2026-04-18 08:03 | invalid/corrupted public-key line; removed 2026-06-12 |
| `config` | 0 | 2026-04-08 23:19 | empty |
| `known_hosts` | 3833 | 2026-06-09 15:27 | 16 host-key entries |
| `known_hosts.old` | 2612 | 2026-04-10 08:39 | old backup, 10 host-key entries |

## Private keys

| Key | Fingerprint | Comment | Passphrase | `.pub` material match |
| --- | --- | --- | --- | --- |
| `id_rsa` | `SHA256:KIs9YrF5IBLboGAVrYF8N09ylKePP7CDJz2TLZu1TeE` | `cliproxy-vps-temp` | none | yes |
| `rheolab_deploy` | `SHA256:J0jxCNlKvjZhcDb7OIGNhKbqAvxjiqnPa+ZgjT13Rck` | `rheolab-deploy` | none | yes |

Both keys are RSA-4096 in legacy PEM private-key format.

## Effective SSH access

Checked with key-only auth as `root`, command limited to `whoami`/`hostname`.

| Key | Host | Result |
| --- | --- | --- |
| `id_rsa` | non-license VPS #1 | OK, `root` |
| `id_rsa` | non-license VPS #2 | OK, `root` |
| `id_rsa` | non-license VPS #3 | OK, `root` |
| `id_rsa` | non-license VPS #4 | authentication failed |
| `id_rsa` | `185.112.102.122` / `license.vizbuka.ru` | authentication failed |
| `rheolab_deploy` | `185.112.102.122` / `license.vizbuka.ru` | OK, `root`, `vm3776683.firstbyte.club` |
| `rheolab_deploy` | non-license VPS hosts | authentication failed |

License server check: `185.112.102.122:58000` is reachable, and `ztool-tcp-server.service` is active on `vm3776683.firstbyte.club`.

## Usage references

`id_rsa` is referenced by three local ops inventory entries for non-license VPS hosts.

`rheolab_deploy` is referenced by one local ops inventory entry for the license VPS.

The license server inventory points to:

- host: `license.vizbuka.ru`
- public IP: `185.112.102.122`
- user: `root`
- key: `C:\Users\VladimirWorkPC\.ssh\rheolab_deploy`
- dashboard: `https://license.vizbuka.ru/admin/`

## ACL / permissions

All files in `C:\Users\VladimirWorkPC\.ssh` are readable/writable by:

- `VLAD-HOME-PC\VladimirWorkPC`
- `BUILTIN\Администраторы`
- `NT AUTHORITY\СИСТЕМА`

This is typical for a local admin workstation, but both private keys have no passphrase, so compromise of this Windows account or admin context gives immediate root access to the listed VPS hosts.

## Findings

1. High risk: both private keys are unencrypted, no passphrase.
2. High risk: `id_rsa` is a broad shared root key for at least three VPS hosts.
3. High risk: `rheolab_deploy` gives root access to the production license/update server at `185.112.102.122`.
4. Resolved: malformed `authorized_keys` (`ssh-ed25519` plus invalid bytes) was removed from `C:\Users\VladimirWorkPC\.ssh`.
5. Medium risk: `known_hosts` contains valid current entries, but `known_hosts.old` is stale and can be archived outside `.ssh` if not needed.
6. Low risk: `config` is empty, so commands rely on explicit `-i` paths and scripts instead of named host aliases.

## Recommendations

1. Do not delete `rheolab_deploy` before finishing ZTool license-server work; it is the current key for production license VPS.
2. After the current testing is finished, rotate `rheolab_deploy` on `license.vizbuka.ru` and replace it with a passphrase-protected key.
3. Split `id_rsa` into per-server keys; remove the shared key from VPS hosts where it is not required.
4. Replace direct `root` login with a named sudo user where practical.
5. Keep `authorized_keys` absent unless this Windows machine is intentionally configured as an SSH server.
6. Add explicit aliases to `C:\Users\VladimirWorkPC\.ssh\config` to reduce wrong-key/wrong-server mistakes.
