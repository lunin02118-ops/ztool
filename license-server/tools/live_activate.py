"""
Live license-acquisition test client.

Connects to a running ZTool license server over real TCP (local or
production), performs an ``apply_register`` (sendtype 128) exactly the way the
re-keyed client does, decrypts the returned license transport, and validates it
the way the client's ``SR.IsReg1`` would. Prints a clear PASS/FAIL trace.

This is the standalone counterpart of ``tests/test_integration.py`` /
``tests/test_license_blob.py`` — useful for verifying "getting a license" works
end-to-end against a real server without a SolidWorks bench.

Usage:
    python tools/live_activate.py --host 127.0.0.1 --port 58000 \
        --pubkey keys/public_key.txt \
        --code AAAAA-BBBBB-CCCCC-DDDDD-EEEEE \
        --machine "12345678-90AB-CDEF-1234-567890ABCDEF|DISK01|BOARD01"

``--machine`` must be a genuine fingerprint (``<36-char GUID>|<disk>|<board>``);
the server rejects anything else. ``--password`` is only needed for codes that
were created with one.

NOTE: a successful run consumes the code's seat (device_limit). Use a throwaway
fingerprint for a code you want to keep free, then free the seat afterwards
(deactivate the activation) before the real machine activates.
"""

import argparse
import asyncio
import sys

from ztool_license_server.config import ServerConfig
from ztool_license_server.crypto.rsa_ztool import encrypt_string, decrypt_string
from ztool_license_server.crypto.aes_security_center import encrypt_message_body
from ztool_license_server.crypto import aes_security_center as aes
from ztool_license_server.license_blob import (
    getver_today, gd51, machine_version_suffix,
    FIRST_LEN_B1, FIRST_LEN_B2, FIRST_LEN_B3, SUFFIX_LEN,
)
from ztool_license_server.protocol.framing import build_frame, FrameParser
from ztool_license_server.protocol.dispatcher import Sendtype, Result


def _right(s, n):
    return s[len(s) - n:] if n <= len(s) else s


def _left(s, n):
    return s[:n]


def split_transport(transport, client_version):
    """AES-decrypt the getver-keyed transport into the 4 registry branches."""
    inner = aes.decrypt(transport, getver_today(client_version))
    return inner.split("\t")


def emulate_isreg1(branches, pub_key):
    """Faithful re-implementation of SR.IsReg1; returns (uuid, machine_hash, reg_time)."""
    b0_raw, b1_raw, b2_raw, b3_raw = (x.replace("\x00", "") for x in branches)

    pp = _right(b2_raw, SUFFIX_LEN) + _left(b2_raw, FIRST_LEN_B2)
    b2 = decrypt_string(aes.decrypt(b2_raw[FIRST_LEN_B2:len(b2_raw) - SUFFIX_LEN], pp), pub_key).strip()

    pp = _right(b3_raw, SUFFIX_LEN) + _left(b3_raw, FIRST_LEN_B3)
    b3 = decrypt_string(aes.decrypt(b3_raw[FIRST_LEN_B3:len(b3_raw) - SUFFIX_LEN], pp), pub_key).strip()

    pp = _right(b1_raw, SUFFIX_LEN) + _left(b1_raw, FIRST_LEN_B1)
    b1 = aes.decrypt(b1_raw[FIRST_LEN_B1:len(b1_raw) - SUFFIX_LEN], pp).strip()
    parts = b1.split("\n")
    assert len(parts) == 2, f"b1 must split into 2 parts, got {len(parts)}"
    seed_f = decrypt_string(parts[0], pub_key).strip()
    dyn_key = aes.decrypt(parts[1], seed_f).strip()

    arr3 = aes.decrypt(b0_raw, seed_f).strip().split("\n")
    assert len(arr3) == 3, f"b0 must split into 3 parts, got {len(arr3)}"
    out_uuid = decrypt_string(arr3[0], dyn_key).strip()
    out_reg_time = decrypt_string(arr3[2], dyn_key).strip()
    loc_c = aes.decrypt(decrypt_string(arr3[1], dyn_key).strip(), seed_f)

    assert len(out_uuid) == 36, f"uuid len {len(out_uuid)} != 36"
    assert loc_c and b2 and b3, "empty machine/branch values"
    assert b2 + b3 == loc_c, "Concat(b2,b3) != machine hash"
    assert float(out_reg_time) == 0.0, "reg_time must be 0 (perpetual)"
    return out_uuid, loc_c, out_reg_time


async def _send(host, port, sendtype, lines):
    reader, writer = await asyncio.open_connection(host, port)
    try:
        aes_body = encrypt_message_body("\n".join(lines), sendtype)
        writer.write(build_frame(sendtype, aes_body.encode("utf-8")))
        await writer.drain()
        parser = FrameParser()
        frame = None
        while frame is None:
            data = await asyncio.wait_for(reader.read(65536), timeout=10)
            if not data:
                break
            parser.feed(data)
            frame = parser.try_parse()
        assert frame is not None, "no response frame received"
        result_code, body = frame
        return result_code, body.decode("utf-8")
    finally:
        writer.close()
        await writer.wait_closed()


async def run(args):
    pub = open(args.pubkey, encoding="utf-8").read().strip()

    def rsa(v):
        return encrypt_string(v, pub, encoding="utf-8") if v else ""

    def mfield(m):
        transport = m + "\n" + machine_version_suffix(args.client_version)
        return rsa(transport[:117])

    print(f"== Live apply_register against {args.host}:{args.port} ==")
    print(f"   code={args.code!r} machine={args.machine!r}")
    result, body = await _send(
        args.host, args.port, Sendtype.APPLY_REGISTER,
        [rsa(args.code), mfield(args.machine), rsa(args.password), rsa("HOST\\user")],
    )
    print(f"[128 apply_register] result={result} (expect {Result.APPLY_OK}) blob_len={len(body)}")
    if result != Result.APPLY_OK:
        print(f"FAIL: server did not issue a license (result={result}). "
              f"Common causes: code not in DB ({Result.INFO_ERROR}=invalid code), "
              f"wrong password ({Result.WRONG_PASSWORD}), or seat limit reached.")
        return 1

    branches = split_transport(body, args.client_version)
    uuid, mhash, reg_time = emulate_isreg1(branches, pub)
    expected = gd51(args.machine)
    print(f"  IsReg1 OK: uuid={uuid} machine_hash={mhash} reg_time={reg_time}")
    print(f"  expected_hash={expected} -> {'MATCH' if mhash == expected else 'MISMATCH'}")
    if mhash != expected:
        print("FAIL: machine hash mismatch")
        return 1
    print("PASS: LIVE_ACTIVATION_OK")
    return 0


def main():
    p = argparse.ArgumentParser(description="Live ZTool license-acquisition test client.")
    p.add_argument("--host", default="127.0.0.1")
    p.add_argument("--port", type=int, default=58000)
    p.add_argument("--pubkey", required=True, help="Path to the server public_key.txt")
    p.add_argument("--code", default="AAAAA-BBBBB-CCCCC-DDDDD-EEEEE")
    p.add_argument("--machine",
                   default="12345678-90AB-CDEF-1234-567890ABCDEF|WD-DISKSERIAL01|BOARDID-XYZ",
                   help="Hardware fingerprint: '<36-char GUID>|<disk>|<board>'")
    p.add_argument("--password", default="")
    p.add_argument("--client-version", default=ServerConfig.client_version)
    args = p.parse_args()
    sys.exit(asyncio.run(run(args)))


if __name__ == "__main__":
    main()
