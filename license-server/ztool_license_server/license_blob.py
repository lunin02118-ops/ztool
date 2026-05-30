"""
License blob generation — produces the exact payload that the ZTool client's
FrmRg.rg() consumes and that SR.IsReg1 / SR.IsReg2 validate.

This layout was reverse-engineered from the (de-obfuscated) client IL of
SR.IsReg1, SR.IsReg2 and FrmRg.rg. The server produces a single transport
string; the client's rg() splits it, hex-encodes each part and writes the four
registry branches itself, so the server never deals with the registry hex layer.

Transport string (what the server returns for register / writes into the
offline activation file, before the client's rg() runs)::

    transport = AES_encrypt( "\\t".join([b0, b1, b2, b3]), passphrase=getver_today )

where ``getver_today`` is ``SR.getver("今天。。。")`` on the client, i.e. the
client product version followed by " (x64)" / " (x86)". The client learns its
own version, the server reconstructs the same string from the version the
client reports in its request (see ServerConfig / handler wiring).

Registry branches (order matches FrmRg.rg writes / the "\\t" split order)::

    b0  Software\\SolURxxCfNU\\C4eHN4fjikBan              (value "information")
    b1  SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\Jlj4aG8uZBvW   (value "F2S6qCdziIAm")
    b2  Software\\SolURxxCfNU\\HTwk2RCBDL                 (value "information")
    b3  SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\98CqyvBZcg     (value "information")

Per-branch construction (inverse of IsReg1)::

    b2 = first9 + AES( RSA_sign(mc_half1), pp2 ) + last10 ;  pp2 = last10+first9
    b3 = first9 + AES( RSA_sign(mc_half2), pp3 ) + last10 ;  pp3 = last10+first9
    b1 = first7 + AES( RSA_sign(F) + "\\n" + AES(pubkey, F), pp1 ) + last10
                                                            ;  pp1 = last10+first7
    b0 = AES( RSA_sign(uuid36) + "\\n"
              + RSA_sign(AES(machine_code, F)) + "\\n"
              + RSA_sign(reg_time), key=F )

IsReg1 checks (all must hold):
    * 4 branches present
    * b1 → 2 "\\n" parts, b0 → 3 "\\n" parts
    * F           = RSA_decrypt(b1[0], pub)
    * dyn_key D   = AES_decrypt(b1[1], F)            (a ComponentKey; we use pub)
    * uuid36      = RSA_decrypt(b0[0], D)   and len == 36
    * reg_time    = RSA_decrypt(b0[2], D)   and ToDouble(reg_time) == 0
                    (verified from IsReg1 IL: ``beq`` against 0.0 -> valid; a
                    perpetual license stores "0". The on-screen "Action until"
                    is derived separately from the registry key creation time in
                    SR.get_rgtime, NOT from this field.)
    * loc_c       = AES_decrypt(RSA_decrypt(b0[1], D), F) == GetMNum() == machine_code
    * machine_code (and thus loc_c / b2+b3) MUST be non-empty: IsReg1 rejects an
      empty machine via an explicit guard before the GetMNum comparison.
    * mc_half1+mc_half2 (b2,b3 decrypted) == loc_c
"""

import hashlib
import secrets
import string
from datetime import datetime
from typing import List, Optional, Sequence, Tuple

from .crypto.rsa_ztool import sign_string
from .crypto import aes_security_center as aes
from .crypto import des_offline


_PP_ALPHABET = string.ascii_letters + string.digits


def _rand_str(n: int) -> str:
    return "".join(secrets.choice(_PP_ALPHABET) for _ in range(n))


# A perpetual license stores reg_time = "0": IsReg1 validates the field with
# ``Conversions.ToDouble(reg_time) == 0`` (verified from the de-obfuscated IL,
# SR.IsReg1 lines ~905-909: ``beq`` against the literal 0.0 selects the valid
# branch). The visible perpetual expiry is computed elsewhere
# (SR.get_rgtime, from the registry key creation time), not from this value.
PERPETUAL_REG_TIME = "0"


def default_reg_time(when: Optional[datetime] = None) -> str:
    """Registration-time field for a perpetual license.

    IsReg1 requires ``Conversions.ToDouble(reg_time) == 0``, so a perpetual
    license stores ``"0"``. (Earlier revisions stored a non-zero OADate, which
    made IsReg1 reject the blob -- the client saved it but reported a
    "failed to save registration info" error.)
    """
    return PERPETUAL_REG_TIME


# Registry branches in the order FrmRg.rg() writes them (== "\t" split order).
REGISTRY_PATHS = [
    {"key": r"Software\SolURxxCfNU", "subkey": "C4eHN4fjikBan", "value_name": "information"},
    {"key": r"SOFTWARE\Microsoft\MzORu8qE4HhZ", "subkey": "Jlj4aG8uZBvW", "value_name": "F2S6qCdziIAm"},
    {"key": r"Software\SolURxxCfNU", "subkey": "HTwk2RCBDL", "value_name": "information"},
    {"key": r"SOFTWARE\Microsoft\MzORu8qE4HhZ", "subkey": "98CqyvBZcg", "value_name": "information"},
]

# Per-branch "first N" prefix length (last-10 suffix is constant). N=9 for the
# HTwk2RCBDL/98CqyvBZcg branches, N=7 for the Jlj4aG8uZBvW branch. b0 is unwrapped.
FIRST_LEN_B1 = 7
FIRST_LEN_B2 = 9
FIRST_LEN_B3 = 9
SUFFIX_LEN = 10


def _wrap_branch(ciphertext: str, passphrase: str, first_len: int) -> str:
    """
    Wrap an AES ciphertext so that IsReg1's Right/Left/Substring recovery yields
    back (ciphertext, passphrase).

    IsReg1 reconstructs the passphrase as Right(b, 10) + Left(b, first_len), i.e.
    suffix(10) + prefix(first_len), and the ciphertext as
    b.Substring(first_len, Len(b) - first_len - 10).

    So passphrase must be exactly (first_len + 10) chars; we set
    prefix = passphrase[10:]  and  suffix = passphrase[:10].
    """
    if len(passphrase) != first_len + SUFFIX_LEN:
        raise ValueError(
            f"passphrase must be {first_len + SUFFIX_LEN} chars, got {len(passphrase)}"
        )
    suffix = passphrase[:SUFFIX_LEN]
    prefix = passphrase[SUFFIX_LEN:]
    return prefix + ciphertext + suffix


def gd51(s: str) -> str:
    """Reproduce ``code.GD51(s)`` from the client IL: the uppercase hex MD5 of
    ``UTF8(s)`` (each byte ``ToString("X2")``), i.e. a 32-char hash string."""
    return hashlib.md5(s.encode("utf-8")).hexdigest().upper()


def machine_version_suffix(client_version: str, is_64bit: bool = True) -> str:
    """The suffix ``GetMNum(_, True, True)`` appends to the raw machine string
    before RSA-encrypting it for transport: ``code.getver("", False)`` returns
    ``Application.ProductVersion + " (x64)"/" (x86)"`` (verified from IL)."""
    return f"{client_version}{' (x64)' if is_64bit else ' (x86)'}"


def recover_raw_machine(machine_field: str, client_version: str, is_64bit: bool = True) -> str:
    """Recover the raw ``UUID|disk|board`` string the client's GetMNum produced.

    ``createinfo`` transmits the machine field as
    ``RSA( Mid(raw + "\\n" + getver, 1, 117) )`` (``GetMNum(_, True, True)``):
    verified from SR.GetMNum IL, which does ``Concat(raw, "\\n", getver(...))``
    before ``Mid(.,1,117)`` and RSA. The server has already RSA-decrypted the
    field (``machine_field``). IsReg1 compares the blob's machine value against
    ``GetMNum(_, False, False) == GD51(raw)``, so we must recover the exact
    ``raw`` (no version tail). Since ``raw`` (UUID|disk|board) never contains a
    newline, the raw string is everything before the first ``"\\n"``. A
    no-newline legacy form (``raw + getver``) is handled by stripping the
    version suffix as a fallback. (``raw + "\\n" + getver`` is well under the
    117-char Mid cap for real hardware IDs, so no truncation occurs.)
    """
    s = machine_field.strip()
    if "\n" in s:
        return s.split("\n", 1)[0].strip()
    suffix = machine_version_suffix(client_version, is_64bit)
    if suffix and s.endswith(suffix):
        s = s[: -len(suffix)]
    return s.strip()


def _split_hash(machine_hash: str) -> Tuple[str, str]:
    """Split the 32-char machine hash into two halves (16 + 16) whose
    concatenation is the original (IsReg1 checks ``b2 + b3 == GD51(raw)``)."""
    mid = len(machine_hash) // 2
    return machine_hash[:mid], machine_hash[mid:]


def _uuid36(machine_code: str) -> str:
    """
    The first field of the (raw) machine code is the hardware UUID. IsReg1
    requires ``RSA_decrypt(b0[0])`` to be exactly 36 characters (a GUID with
    dashes); the version suffix is appended after the last ``|`` so the first
    ``|``-field is unaffected.
    """
    uuid = machine_code.split("|", 1)[0].strip()
    return uuid


def build_registry_branches(
    machine_code: str,
    pub_key: str,
    priv_key: str,
    reg_time: str,
    seed_f: str,
    passphrase_b1: str,
    passphrase_b2: str,
    passphrase_b3: str,
    dyn_key: Optional[str] = None,
) -> List[str]:
    """
    Build the four branch strings [b0, b1, b2, b3] (the elements rg() splits by
    "\\t"). ``dyn_key`` is the ComponentKey embedded in b1[1] and used to verify
    the b0 fields; it defaults to ``pub_key`` (whose private half is priv_key).

    The passphrases must be (first_len + 10) chars: 17 for b1, 19 for b2/b3.
    """
    if dyn_key is None:
        dyn_key = pub_key

    # ``machine_code`` is the RAW "UUID|disk|board" GetMNum string. IsReg1
    # compares the blob's machine value (V_12) and b2+b3 against
    # ``GetMNum(_, False, False) == GD51(raw)`` (a 32-char uppercase MD5), while
    # the 36-char uuid field (b0[0]) is the raw first "|"-segment.
    machine_hash = gd51(machine_code)
    mc_half1, mc_half2 = _split_hash(machine_hash)
    uuid36 = _uuid36(machine_code)

    # --- b2 / b3 : the two machine-HASH halves, RSA-signed then AES-wrapped ---
    b2_inner = sign_string(mc_half1, priv_key)
    b2_ct = aes.encrypt(b2_inner, passphrase_b2)
    b2 = _wrap_branch(b2_ct, passphrase_b2, FIRST_LEN_B2)

    b3_inner = sign_string(mc_half2, priv_key)
    b3_ct = aes.encrypt(b3_inner, passphrase_b3)
    b3 = _wrap_branch(b3_ct, passphrase_b3, FIRST_LEN_B3)

    # --- b1 : seed F (RSA-signed) + dynamic ComponentKey (AES-wrapped with F) ---
    b1_part0 = sign_string(seed_f, priv_key)
    b1_part1 = aes.encrypt(dyn_key, seed_f)
    b1_plain = b1_part0 + "\n" + b1_part1
    b1_ct = aes.encrypt(b1_plain, passphrase_b1)
    b1 = _wrap_branch(b1_ct, passphrase_b1, FIRST_LEN_B1)

    # --- b0 : uuid36, AES(machine_hash,F), reg_time — each RSA-signed (dyn_key) --
    b0_part0 = sign_string(uuid36, priv_key)
    b0_part1 = sign_string(aes.encrypt(machine_hash, seed_f), priv_key)
    b0_part2 = sign_string(reg_time, priv_key)
    b0_plain = b0_part0 + "\n" + b0_part1 + "\n" + b0_part2
    b0 = aes.encrypt(b0_plain, seed_f)

    return [b0, b1, b2, b3]


def build_transport_payload(
    machine_code: str,
    pub_key: str,
    priv_key: str,
    reg_time: str,
    seed_f: str,
    getver_today: str,
    passphrase_b1: str,
    passphrase_b2: str,
    passphrase_b3: str,
    dyn_key: Optional[str] = None,
) -> str:
    """
    Build the full transport string the server returns / writes to the offline
    file: AES_encrypt( "\\t".join([b0, b1, b2, b3]), passphrase=getver_today ).
    """
    branches = build_registry_branches(
        machine_code=machine_code,
        pub_key=pub_key,
        priv_key=priv_key,
        reg_time=reg_time,
        seed_f=seed_f,
        passphrase_b1=passphrase_b1,
        passphrase_b2=passphrase_b2,
        passphrase_b3=passphrase_b3,
        dyn_key=dyn_key,
    )
    joined = "\t".join(branches)
    return aes.encrypt(joined, getver_today)


def getver_today(client_version: str, is_64bit: bool = True) -> str:
    """
    Reproduce ``SR.getver("今天。。。", True)`` on the client (verified from IL):

        ver  = Application.ProductVersion + (" (x64)" | " (x86)")
        return code.GD51(ver)

    where ``code.GD51(s)`` is the uppercase hex MD5 of ``UTF8(s)`` (ToString("X2")
    per byte). This 32-char hex string is the AES passphrase ``rg()`` feeds to
    SecurityCenter.DecriptStr to decrypt the transport payload.
    """
    suffix = " (x64)" if is_64bit else " (x86)"
    ver = f"{client_version}{suffix}"
    return hashlib.md5(ver.encode("utf-8")).hexdigest().upper()


def generate_license_blob(
    machine_code: str,
    public_key: str,
    private_key: str,
    *,
    client_version: str,
    is_64bit: bool = True,
    reg_time: Optional[str] = None,
    seed_f: Optional[str] = None,
    passphrases: Optional[Sequence[str]] = None,
    dyn_key: Optional[str] = None,
) -> str:
    """
    High-level entry point: build the transport payload the server returns for a
    REGISTER request (and the plaintext of an offline activation file).

    ``client_version`` is the version the client reports (used to derive the
    rg() transport passphrase). ``reg_time`` defaults to an OADate string for
    "now"; ``seed_f`` and ``passphrases`` are randomised when omitted.
    """
    seed = seed_f or _rand_str(16)
    if passphrases is None:
        pp1 = _rand_str(FIRST_LEN_B1 + SUFFIX_LEN)
        pp2 = _rand_str(FIRST_LEN_B2 + SUFFIX_LEN)
        pp3 = _rand_str(FIRST_LEN_B3 + SUFFIX_LEN)
    else:
        pp1, pp2, pp3 = passphrases
    rt = reg_time if reg_time is not None else default_reg_time()
    return build_transport_payload(
        machine_code=machine_code,
        pub_key=public_key,
        priv_key=private_key,
        reg_time=rt,
        seed_f=seed,
        getver_today=getver_today(client_version, is_64bit),
        passphrase_b1=pp1,
        passphrase_b2=pp2,
        passphrase_b3=pp3,
        dyn_key=dyn_key,
    )


def generate_offline_activation(
    machine_code: str,
    public_key: str,
    private_key: str,
    *,
    client_version: str,
    is_64bit: bool = True,
) -> str:
    """
    Phase 7: produce an offline activation file payload for a machine code.

    The client's FrmRg.Decryptstr DES-decrypts this file and feeds the result to
    the same rg() consumer used online, so the offline payload is simply the
    transport payload wrapped in the DES-CBC layer (Base64-encoded).
    """
    transport = generate_license_blob(
        machine_code=machine_code,
        public_key=public_key,
        private_key=private_key,
        client_version=client_version,
        is_64bit=is_64bit,
    )
    return des_offline.encrypt_offline(transport)
