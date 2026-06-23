# Legacy crypto risk acceptance

Дата: 2026-06-23

## Scope

SWTools client compatibility requires legacy primitives:

- RSA-1024 without modern padding, compatible with `ZTool_rsa.dll`;
- AES-128-CBC with legacy `SecurityCenter` key/IV derivation;
- DES for offline activation compatibility.

These primitives are retained only to interoperate with the accepted SWTools
client protocol. They are not a pattern for new protocol design.

## Accepted residual risk

| Risk | Decision |
|---|---|
| Legacy crypto is weaker than modern authenticated encryption | Accepted for compatibility; perimeter TLS/VPN/firewall remains required for public deployment |
| RSA-1024 key compromise requires client public-key migration | Accepted; follow key compromise runbook before issuing new production keys |
| DES offline activation is legacy-only | Accepted only for explicit offline activation workflow; online activation remains preferred |

## Required controls

- Private key stored outside repository.
- Unix production private key permissions: `0600` or stricter.
- `healthcheck` must pass after deployment and after key rotation.
- `SWTOOLS_LOG_LEVEL=DEBUG` is blocked in production unless explicitly allowed
  for a controlled emergency window.
- No plaintext protocol payloads, full hardware fingerprints or private key
  material may be logged.
- Public internet exposure requires firewall/fail2ban plus in-process rate
  limiter.

## Review trigger

This acceptance must be revisited if:

- client protocol is replaced from source;
- public-key/key format changes;
- offline activation is removed;
- production exposure changes from private/VPN to public internet.
