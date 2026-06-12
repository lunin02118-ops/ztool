"""Live smoke test of every license-server mode over real TCP.

Exercises the full protocol against a running server (local or production) using
a throwaway code + machine fingerprint, so no real activation is touched:

    128 apply_register    -> 13 + license blob
    131 register_confirm  -> 12 + transport blob   (empty-creation-time path:
                                                     reproduces real clients whose
                                                     getregistryKeytime() returns "")
    129 apply_remove      -> 11 (transfer out)
    132 remove_confirm    ->  7 (transfer done)

This is a black-box check of the server's result codes and blob production; the
cryptographic IsReg1/IsReg2 validation is covered by the unit/integration tests
(`tests/test_license_blob.py`, `tests/test_integration.py`).

Usage (create the throwaway code on the server first, e.g.
``python -m ztool_license_server.cli add-code DEVIN-LIVE-CHECK --limit 5``):

    python tools/live_verify.py --host 185.112.102.122 --port 58000 \
        --pubkey ../client-rekey/new_key.txt --code DEVIN-LIVE-CHECK
"""
import argparse
import asyncio

from ztool_license_server.crypto.rsa_ztool import encrypt_string
from ztool_license_server.crypto.aes_security_center import encrypt_message_body
from ztool_license_server.crypto import aes_security_center as aes
from ztool_license_server.license_blob import getver_today, machine_version_suffix
from ztool_license_server.protocol.framing import build_frame, FrameParser
from ztool_license_server.protocol.dispatcher import Sendtype, Result


def parse_args():
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument("--host", required=True)
    p.add_argument("--port", type=int, default=58000)
    p.add_argument("--pubkey", required=True, help="server public key file (client_version key)")
    p.add_argument("--code", required=True, help="a throwaway registration code that exists on the server")
    p.add_argument("--machine", default="DEADBEEF-1111-2222-3333-444455556666|THROWAWAY-DISK|Default string",
                   help="throwaway fingerprint <36-char GUID>|<disk>|<board>")
    p.add_argument("--password", default="")
    p.add_argument("--client-version", default="1.0")
    return p.parse_args()


class LiveClient:
    def __init__(self, host, port, pub, client_version):
        self.host, self.port, self.pub, self.cv = host, port, pub, client_version

    def _rsa(self, v):
        return encrypt_string(v, self.pub, encoding="utf-8") if v else ""

    def _mfield(self, m):
        return self._rsa((m + "\n" + machine_version_suffix(self.cv))[:117])

    async def send(self, sendtype, lines):
        r, w = await asyncio.open_connection(self.host, self.port)
        try:
            body = encrypt_message_body("\n".join(lines), sendtype).encode("utf-8")
            w.write(build_frame(sendtype, body))
            await w.drain()
            parser, frame = FrameParser(), None
            while frame is None:
                data = await asyncio.wait_for(r.read(65536), timeout=10)
                if not data:
                    break
                parser.feed(data)
                frame = parser.try_parse()
            assert frame is not None, "no response frame"
            return frame
        finally:
            w.close()
            await w.wait_closed()


async def run(args):
    pub = open(args.pubkey, encoding="utf-8").read().strip()
    c = LiveClient(args.host, args.port, pub, args.client_version)
    gv = getver_today(args.client_version, is_64bit=True)
    machine = args.machine

    res, blob = await c.send(Sendtype.APPLY_REGISTER,
                             [c._rsa(args.code), c._mfield(machine), c._rsa(args.password), c._rsa("HOST\\user")])
    print(f"[128 apply_register]   result={res} (expect {Result.APPLY_OK})  blob={len(blob)}B")
    assert res == Result.APPLY_OK and blob, "apply_register failed"

    branches = aes.decrypt(blob.decode("utf-8"), gv).split("\t")
    # Empty creation-time lines: reproduces the real client whose
    # GetRegistrycreatedtime.getregistryKeytime() throws and returns "".
    confirm_lines = list(branches) + ["", "", c._rsa("6/12/2026 6:00:00")]
    res2, transport = await c.send(Sendtype.REGISTER_CONFIRM, confirm_lines)
    print(f"[131 register_confirm] result={res2} (expect {Result.REGISTER_OK})  blob={len(transport)}B  [empty ctimes]")
    assert res2 == Result.REGISTER_OK and transport, "register_confirm failed"

    res3, _ = await c.send(Sendtype.APPLY_REMOVE,
                           [c._rsa(args.code), c._mfield(machine), c._rsa(args.password), c._rsa("HOST\\user")])
    print(f"[129 apply_remove]     result={res3} (expect {Result.TRANSFER_OUT_OK})")
    assert res3 == Result.TRANSFER_OUT_OK, "apply_remove failed"

    res4, _ = await c.send(Sendtype.REMOVE_CONFIRM, [c._rsa("x")])
    print(f"[132 remove_confirm]   result={res4} (expect {Result.TRANSFER_DONE})")
    assert res4 == Result.TRANSFER_DONE, "remove_confirm failed"

    print("ALL MODES OK")


if __name__ == "__main__":
    asyncio.run(run(parse_args()))
