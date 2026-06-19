"""
Tests for license blob generation.

The key test is ``emulate_isreg1`` — a faithful Python re-implementation of the
client's SR.IsReg1 (decompiled from the de-obfuscated SWTools binary). It mirrors
the exact Right/Left/Substring recovery, the AES/RSA layering, the "\\n"/"\\t"
splits and every comparison IsReg1 makes. We assert that a server-generated
blob passes this validator and yields the expected machine code / reg-time.

This is self-consistent verification (both generator and emulator derive from
the same IL reading); byte-exact acceptance by the *unmodified* original client
still requires a hardware test bench and is documented as pending.
"""

import pytest

from swtools_license_server.crypto.keygen import generate_keypair
from swtools_license_server.crypto.rsa_swtools import decrypt_string
from swtools_license_server.crypto import aes_security_center as aes
from swtools_license_server.crypto import des_offline
from swtools_license_server.license_blob import (
    build_registry_branches,
    build_transport_payload,
    generate_license_blob,
    getver_today,
    gd51,
    default_reg_time,
    REGISTRY_PATHS,
    FIRST_LEN_B1,
    FIRST_LEN_B2,
    FIRST_LEN_B3,
    SUFFIX_LEN,
)

# A realistic machine code: "<36-char GUID>|<disk>|<board>"
MACHINE_CODE = "12345678-90AB-CDEF-1234-567890ABCDEF|WD-DISKSERIAL01|BOARDID-XYZ"
# IsReg1 compares the blob machine value against GetMNum(_, False, False) ==
# GD51(raw) (a 32-char uppercase MD5), not the raw machine string.
MACHINE_HASH = gd51(MACHINE_CODE)
CLIENT_VERSION = "1.0"


def _right(s: str, n: int) -> str:
    return s[len(s) - n:] if n <= len(s) else s


def _left(s: str, n: int) -> str:
    return s[:n]


def emulate_isreg1(branches, pub_key):
    """
    Faithful re-implementation of SR.IsReg1.

    `branches` are the four "\\t"-split elements [b0, b1, b2, b3] (in the client
    these come from un-hexing the four registry values; that hex layer is a
    client-internal round-trip and is identity here).

    Returns (ok, out_machine_code_uuid, out_reg_time).
    """
    b0_raw, b1_raw, b2_raw, b3_raw = (x.replace("\x00", "") for x in branches)

    # --- b2 (first_len 9): pp = Right(b,10)+Left(b,9); ct = b.Substring(9, len-19) ---
    pp = _right(b2_raw, SUFFIX_LEN) + _left(b2_raw, FIRST_LEN_B2)
    ct = b2_raw[FIRST_LEN_B2: len(b2_raw) - SUFFIX_LEN]
    b2 = aes.decrypt(ct, pp)
    b2 = decrypt_string(b2, pub_key).strip()

    # --- b3 (first_len 9) ---
    pp = _right(b3_raw, SUFFIX_LEN) + _left(b3_raw, FIRST_LEN_B3)
    ct = b3_raw[FIRST_LEN_B3: len(b3_raw) - SUFFIX_LEN]
    b3 = aes.decrypt(ct, pp)
    b3 = decrypt_string(b3, pub_key).strip()

    # --- b1 (first_len 7): pp 17 chars; ct = b.Substring(7, len-17) ---
    pp = _right(b1_raw, SUFFIX_LEN) + _left(b1_raw, FIRST_LEN_B1)
    ct = b1_raw[FIRST_LEN_B1: len(b1_raw) - SUFFIX_LEN]
    b1 = aes.decrypt(ct, pp).strip()
    parts2 = b1.split("\n")
    assert len(parts2) == 2, f"b1 must split into 2 parts, got {len(parts2)}"
    seed_f = decrypt_string(parts2[0], pub_key).strip()
    dyn_key = aes.decrypt(parts2[1], seed_f).strip()

    # --- b0 (unwrapped): AES_decrypt(b0_raw, F) then split into 3 "\n" parts ---
    b0 = aes.decrypt(b0_raw, seed_f)
    arr3 = b0.strip().split("\n")
    assert len(arr3) == 3, f"b0 must split into 3 parts, got {len(arr3)}"

    out_uuid = decrypt_string(arr3[0], dyn_key).strip()
    out_reg_time = decrypt_string(arr3[2], dyn_key).strip()
    loc_c = decrypt_string(arr3[1], dyn_key).strip()
    loc_c = aes.decrypt(loc_c, seed_f)  # IsReg1 does NOT Trim after this AES

    # IsReg1 predicates
    assert len(out_uuid) == 36, f"uuid len must be 36, got {len(out_uuid)}"
    # IsReg1's empty-machine guard: an empty machine (loc_c) is rejected before
    # the GetMNum comparison (verified from IL, SR.IsReg1 ~855-886).
    assert loc_c != "" and b2 != "" and b3 != ""
    assert b2 + b3 == loc_c, "Concat(b2,b3) must equal loc_c"
    # Verified from IsReg1 IL (~905-909): ``ToDouble(reg_time) == 0`` selects the
    # valid branch (``beq`` against 0.0). A perpetual license stores "0".
    assert float(out_reg_time) == 0.0, "ToDouble(reg_time) must be zero (perpetual)"

    return True, out_uuid, out_reg_time, loc_c


@pytest.fixture
def keypair():
    return generate_keypair()


class TestLicenseBlob:
    def test_registry_paths_layout(self):
        assert len(REGISTRY_PATHS) == 4
        assert REGISTRY_PATHS[0]["subkey"] == "C4eHN4fjikBan"
        assert REGISTRY_PATHS[1]["value_name"] == "F2S6qCdziIAm"
        assert REGISTRY_PATHS[2]["subkey"] == "HTwk2RCBDL"
        assert REGISTRY_PATHS[3]["subkey"] == "98CqyvBZcg"

    def test_branches_pass_isreg1(self, keypair):
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        branches = build_registry_branches(
            machine_code=MACHINE_CODE,
            pub_key=pub,
            priv_key=priv,
            reg_time=default_reg_time(),
            seed_f="seedF-0123456789",
            passphrase_b1=_make_pp(FIRST_LEN_B1),
            passphrase_b2=_make_pp(FIRST_LEN_B2),
            passphrase_b3=_make_pp(FIRST_LEN_B3),
        )
        assert len(branches) == 4
        ok, uuid, reg_time, loc_c = emulate_isreg1(branches, pub)
        assert ok
        assert uuid == MACHINE_CODE.split("|")[0]
        assert loc_c == MACHINE_HASH

    def test_transport_roundtrip_passes_isreg1(self, keypair):
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        transport = build_transport_payload(
            machine_code=MACHINE_CODE,
            pub_key=pub,
            priv_key=priv,
            reg_time=default_reg_time(),
            seed_f="seedF-0123456789",
            getver_today=gv,
            passphrase_b1=_make_pp(FIRST_LEN_B1),
            passphrase_b2=_make_pp(FIRST_LEN_B2),
            passphrase_b3=_make_pp(FIRST_LEN_B3),
        )
        # Client rg(): AES_decrypt(transport, getver) then split('\t')
        joined = aes.decrypt(transport, gv)
        branches = joined.split("\t")
        ok, uuid, reg_time, loc_c = emulate_isreg1(branches, pub)
        assert ok and loc_c == MACHINE_HASH

    def test_high_level_generate_passes_isreg1(self, keypair):
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        transport = generate_license_blob(
            machine_code=MACHINE_CODE,
            public_key=pub,
            private_key=priv,
            client_version=CLIENT_VERSION,
        )
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        branches = aes.decrypt(transport, gv).split("\t")
        ok, uuid, reg_time, loc_c = emulate_isreg1(branches, pub)
        assert ok and loc_c == MACHINE_HASH

    def test_wrong_machine_code_rejected(self, keypair):
        """A blob bound to a different machine must fail the GetMNum comparison."""
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        transport = generate_license_blob(
            machine_code=MACHINE_CODE,
            public_key=pub,
            private_key=priv,
            client_version=CLIENT_VERSION,
        )
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        branches = aes.decrypt(transport, gv).split("\t")
        ok, uuid, reg_time, loc_c = emulate_isreg1(branches, pub)
        # loc_c is GD51(bound machine); a different current machine hashes differently.
        assert loc_c == MACHINE_HASH
        assert loc_c != gd51("SOME-OTHER-MACHINE|D|B")

    def test_offline_des_roundtrip_passes_isreg1(self, keypair):
        """Phase 7: offline activation file = DES(transport)."""
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        transport = generate_license_blob(
            machine_code=MACHINE_CODE,
            public_key=pub,
            private_key=priv,
            client_version=CLIENT_VERSION,
        )
        # Server writes an offline file: Base64(DES-CBC(transport)).
        offline_file = des_offline.encrypt_offline(transport)
        # Client (Decryptstr) recovers the transport, then rg() runs.
        recovered = des_offline.decrypt_offline(offline_file)
        assert recovered == transport
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        branches = aes.decrypt(recovered, gv).split("\t")
        ok, uuid, reg_time, loc_c = emulate_isreg1(branches, pub)
        assert ok and loc_c == MACHINE_HASH


def _make_pp(first_len: int) -> str:
    """Deterministic passphrase of the required length (first_len + 10)."""
    base = "PassPhrase0123456789ABCDEFGHIJ"
    return base[: first_len + SUFFIX_LEN]


# ---------------------------------------------------------------------------
# Register-confirm (result 12) — IsReg2 validation.
# ---------------------------------------------------------------------------

from swtools_license_server.crypto.rsa_swtools import encrypt_string
from swtools_license_server.license_blob import (
    build_confirm_transport,
    parse_apply_branches,
)

# Two registry-key creation-time strings (DateTime.ToString() form). IsReg2
# keys b0/b1 by GD51 of these, read live from the registry on the client.
CTIME_B2 = "2026/5/30 13:12:58"
CTIME_B3 = "2026/5/30 13:12:59"


def emulate_isreg2(branches, pub_key, creation_time_b2, creation_time_b3):
    """Faithful re-implementation of SR.IsReg2.

    Differs from IsReg1 only in the OUTER AES key of b0/b1: b0 is decrypted with
    GD51(creation_time(HTwk2RCBDL)) and b1 with GD51(creation_time(98CqyvBZcg)),
    and b1 is consumed un-wrapped (direct AES, no Right/Left passphrase).
    """
    b0_raw, b1_raw, b2_raw, b3_raw = (x.replace("\x00", "") for x in branches)
    txt = gd51(creation_time_b2)
    txt2 = gd51(creation_time_b3)

    # b2 / b3 — identical handling to IsReg1 (wrapped + RSA)
    pp = _right(b2_raw, SUFFIX_LEN) + _left(b2_raw, FIRST_LEN_B2)
    ct = b2_raw[FIRST_LEN_B2: len(b2_raw) - SUFFIX_LEN]
    b2 = decrypt_string(aes.decrypt(ct, pp), pub_key).strip()
    pp = _right(b3_raw, SUFFIX_LEN) + _left(b3_raw, FIRST_LEN_B3)
    ct = b3_raw[FIRST_LEN_B3: len(b3_raw) - SUFFIX_LEN]
    b3 = decrypt_string(aes.decrypt(ct, pp), pub_key).strip()

    # b1 — direct AES with txt2 (NOT wrapped), split into 2 "\n" parts
    b1 = aes.decrypt(b1_raw, txt2)
    a5 = b1.strip().split("\n")
    assert len(a5) == 2, f"b1 must split into 2 parts, got {len(a5)}"
    key2 = decrypt_string(a5[0], pub_key).strip()
    text7 = aes.decrypt(a5[1], key2)

    # b0 — direct AES with txt, split into 3 "\n" parts
    b0 = aes.decrypt(b0_raw, txt)
    a6 = b0.strip().split("\n")
    assert len(a6) == 3, f"b0 must split into 3 parts, got {len(a6)}"
    code = decrypt_string(a6[0], text7).strip()
    use_date = decrypt_string(a6[2], text7).strip()
    left = decrypt_string(a6[1], text7).strip()
    left = aes.decrypt(left, key2).strip()

    assert len(code) == 36, f"uuid len must be 36, got {len(code)}"
    assert left != "" and b2 != "" and b3 != ""
    assert left == b2 + b3, "Concat(b2,b3) must equal loc_c"
    assert float(use_date) == 0.0, "ToDouble(reg_time) must be zero"
    return True, code, use_date, left


def _apply_branches(pub, priv):
    return build_registry_branches(
        machine_code=MACHINE_CODE,
        pub_key=pub,
        priv_key=priv,
        reg_time=default_reg_time(),
        seed_f="seedF-0123456789",
        passphrase_b1=_make_pp(FIRST_LEN_B1),
        passphrase_b2=_make_pp(FIRST_LEN_B2),
        passphrase_b3=_make_pp(FIRST_LEN_B3),
    )


class TestConfirmBlob:
    def test_parse_apply_branches_recovers_fields(self, keypair):
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        branches = _apply_branches(pub, priv)
        parsed = parse_apply_branches(branches, pub)
        assert parsed["uuid36"] == MACHINE_CODE.split("|")[0]
        assert parsed["machine_hash"] == MACHINE_HASH
        assert float(parsed["reg_time"]) == 0.0

    def test_confirm_blob_passes_isreg2(self, keypair):
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        branches = _apply_branches(pub, priv)
        # apply branches must still pass IsReg1
        ok1, *_ = emulate_isreg1(branches, pub)
        assert ok1

        transport = build_confirm_transport(
            branches, CTIME_B2, CTIME_B3,
            public_key=pub, private_key=priv, client_version=CLIENT_VERSION,
        )
        # Client rg(): AES_decrypt(transport, getver) then split('\t')
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        confirm_branches = aes.decrypt(transport, gv).split("\t")
        assert len(confirm_branches) == 4
        ok2, code, use_date, left = emulate_isreg2(
            confirm_branches, pub, CTIME_B2, CTIME_B3)
        assert ok2
        assert code == MACHINE_CODE.split("|")[0]
        assert left == MACHINE_HASH

    def test_confirm_blob_b2_b3_reused(self, keypair):
        """b2/b3 are echoed verbatim so their registry creation time (and thus
        the IsReg2 key derivation) stays stable across the confirm rewrite."""
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        branches = _apply_branches(pub, priv)
        transport = build_confirm_transport(
            branches, CTIME_B2, CTIME_B3,
            public_key=pub, private_key=priv, client_version=CLIENT_VERSION,
        )
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        confirm_branches = aes.decrypt(transport, gv).split("\t")
        assert confirm_branches[2] == branches[2]
        assert confirm_branches[3] == branches[3]

    def test_confirm_blob_wrong_ctime_fails_isreg2(self, keypair):
        """If the server keyed b0/b1 by the wrong creation time, IsReg2 (which
        reads the real creation time) can no longer decrypt b0/b1."""
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        branches = _apply_branches(pub, priv)
        transport = build_confirm_transport(
            branches, CTIME_B2, CTIME_B3,
            public_key=pub, private_key=priv, client_version=CLIENT_VERSION,
        )
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        confirm_branches = aes.decrypt(transport, gv).split("\t")
        with pytest.raises(Exception):
            emulate_isreg2(confirm_branches, pub, "1999/1/1 0:0:0", CTIME_B3)

    def test_rsa_roundtrip_of_creation_times(self, keypair):
        """The client RSA-encrypts the creation times with our public key; the
        server recovers them with the private key (cp936, exact string)."""
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        enc = encrypt_string(CTIME_B2, pub)
        assert decrypt_string(enc, priv).strip() == CTIME_B2

    def test_echoing_apply_branches_fails_isreg2(self, keypair):
        """Regression guard for the original bug: returning the apply_register
        branches unchanged (keyed by getver) must NOT satisfy IsReg2."""
        pub = keypair["public_component_key"]
        priv = keypair["private_component_key"]
        branches = _apply_branches(pub, priv)
        # old behaviour: echo branches, transport-encrypt with getver
        gv = getver_today(CLIENT_VERSION, is_64bit=True)
        bad_transport = aes.encrypt("\t".join(branches), gv)
        bad_branches = aes.decrypt(bad_transport, gv).split("\t")
        with pytest.raises(Exception):
            emulate_isreg2(bad_branches, pub, CTIME_B2, CTIME_B3)
