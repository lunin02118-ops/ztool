"""
End-to-end integration tests for the license server.

An in-process client emulator exercises the full online activation protocol
over a real asyncio TCP socket against a freshly generated key pair:

    apply_register (128) -> register (130) -> verify_register (131)
                         -> apply_remove (129) -> verify_remove (132)

These tests validate the *internal* end-to-end consistency of the server
(framing + AES body layer + RSA request layer + signed license blob + device
bookkeeping). They do NOT prove byte-compatibility with the real ZTool client,
which requires reference vectors captured on a test bench (see migration plan
Phase 1/10).
"""

import asyncio

import pytest

from ztool_license_server.config import ServerConfig
from ztool_license_server.server import LicenseServer
from ztool_license_server.crypto.keygen import generate_keypair, save_keypair
from ztool_license_server.crypto.rsa_ztool import encrypt_string, decrypt_string
from ztool_license_server.crypto.aes_security_center import (
    encrypt_message_body,
    decrypt_message_body,
    PASSPHRASE_BINGYU,
)
from ztool_license_server.crypto import aes_security_center as aes
from ztool_license_server.license_blob import (
    getver_today, FIRST_LEN_B2, FIRST_LEN_B3, SUFFIX_LEN,
)
from ztool_license_server.protocol.framing import build_response_frame, FrameParser
from ztool_license_server.protocol.dispatcher import Sendtype, Status


CODE = "AAAAA-BBBBB-CCCCC-DDDDD-EEEEE"
MACHINE_A = "UUID-AAAA-1111|DISK-AAAA|BOARD-AAAA"
MACHINE_B = "UUID-BBBB-2222|DISK-BBBB|BOARD-BBBB"
MACHINE_C = "UUID-CCCC-3333|DISK-CCCC|BOARD-CCCC"


class ZToolClientEmulator:
    """Minimal emulation of the client transport (TCPClient.sendstring)."""

    def __init__(self, host, port, public_key):
        self.host = host
        self.port = port
        self.public_key = public_key

    async def _round_trip(self, sendtype: int, fields: list) -> str:
        reader, writer = await asyncio.open_connection(self.host, self.port)
        try:
            # Inner request: fields joined with '\' then RSA-encrypted with the
            # server's PUBLIC key, then AES-wrapped with key=str(sendtype).
            inner = "\\".join(fields)
            rsa_ct = encrypt_string(inner, self.public_key, encoding="utf-8")
            aes_body = encrypt_message_body(rsa_ct, sendtype)
            writer.write(build_response_frame(sendtype, aes_body))
            await writer.drain()

            parser = FrameParser()
            data = await asyncio.wait_for(reader.read(65536), timeout=5)
            parser.feed(data)
            frame = parser.try_parse()
            assert frame is not None, "no response frame received"
            resp_type, body = frame
            return decrypt_message_body(body.decode("utf-8"), resp_type)
        finally:
            writer.close()
            await writer.wait_closed()

    async def apply_register(self, code, machine, password=""):
        return await self._round_trip(Sendtype.APPLY_REGISTER, [code, password, machine])

    async def register(self, code, machine):
        payload = await self._round_trip(Sendtype.REGISTER, [code, machine])
        status, _, blob = payload.partition("\n")
        return status, blob

    async def verify_register(self, code, machine):
        return await self._round_trip(Sendtype.VERIFY_REGISTER, [code, machine])

    async def apply_remove(self, code, machine, password=""):
        return await self._round_trip(Sendtype.APPLY_REMOVE, [code, password, machine])

    async def verify_remove(self, code, machine):
        return await self._round_trip(Sendtype.VERIFY_REMOVE, [code, machine])

    def unwrap_license_blob(self, blob: str, client_version=ServerConfig.client_version) -> str:
        """Reverse the server's transport payload the way FrmRg.rg()+IsReg1 do.

        transport = AES_getver( "\\t".join([b0, b1, b2, b3]) )
        We undo the rg() AES layer, split the four branches, and reconstruct the
        bound machine code (loc_c == Concat(b2, b3)). Returns that machine code.
        """
        gv = getver_today(client_version, is_64bit=True)
        joined = aes.decrypt(blob, gv)
        b0_raw, b1_raw, b2_raw, b3_raw = (
            x.replace("\x00", "") for x in joined.split("\t")
        )

        def right(s, n):
            return s[len(s) - n:] if n <= len(s) else s

        # b2 / b3: pp = Right(b,10)+Left(b,first_len); ct = b[first_len: len-10]
        pp = right(b2_raw, SUFFIX_LEN) + b2_raw[:FIRST_LEN_B2]
        b2 = decrypt_string(aes.decrypt(b2_raw[FIRST_LEN_B2: len(b2_raw) - SUFFIX_LEN], pp), self.public_key).strip()
        pp = right(b3_raw, SUFFIX_LEN) + b3_raw[:FIRST_LEN_B3]
        b3 = decrypt_string(aes.decrypt(b3_raw[FIRST_LEN_B3: len(b3_raw) - SUFFIX_LEN], pp), self.public_key).strip()
        return b2 + b3


async def _make_server(tmp_path, device_limit=2, password=""):
    kp = generate_keypair()
    keys_dir = tmp_path / "keys"
    save_keypair(kp, str(keys_dir))
    config = ServerConfig(
        host="127.0.0.1",
        port=0,
        keys_dir=str(keys_dir),
        db_path=str(tmp_path / "licenses.db"),
    )
    server = LicenseServer(config)
    server.db.add_license_code(CODE, password=password, device_limit=device_limit)
    aio_server = await asyncio.start_server(server._handle_client, "127.0.0.1", 0)
    port = aio_server.sockets[0].getsockname()[1]
    client = ZToolClientEmulator("127.0.0.1", port, kp["public_component_key"])
    return server, aio_server, client


@pytest.mark.asyncio
async def test_full_online_activation_flow(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        # 1. Apply for registration
        assert await client.apply_register(CODE, MACHINE_A) == Status.SUCCESS

        # 2. Register -> receive a signed license blob
        status, blob = await client.register(CODE, MACHINE_A)
        assert status == Status.SUCCESS
        assert blob, "expected a license blob in the register response"

        # 3. The blob must decrypt + verify and rebuild our exact machine code
        #    (loc_c == Concat(b2, b3) == the bound machine code).
        bound_machine = client.unwrap_license_blob(blob)
        assert bound_machine == MACHINE_A

        # 4. Verify the activation is recognised
        assert await client.verify_register(CODE, MACHINE_A) == Status.SUCCESS


@pytest.mark.asyncio
async def test_invalid_code_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        status = await client.apply_register("ZZZZZ-ZZZZZ-ZZZZZ-ZZZZZ-ZZZZZ", MACHINE_A)
        assert status == Status.INVALID_CODE


@pytest.mark.asyncio
async def test_device_limit_enforced(tmp_path):
    server, aio_server, client = await _make_server(tmp_path, device_limit=2)
    async with aio_server:
        s1, _ = await client.register(CODE, MACHINE_A)
        s2, _ = await client.register(CODE, MACHINE_B)
        assert s1 == Status.SUCCESS and s2 == Status.SUCCESS

        # third distinct device exceeds the limit
        s3, _ = await client.register(CODE, MACHINE_C)
        assert s3 == Status.DEVICE_LIMIT


@pytest.mark.asyncio
async def test_transfer_out_flow(tmp_path):
    server, aio_server, client = await _make_server(tmp_path, device_limit=1)
    async with aio_server:
        s1, _ = await client.register(CODE, MACHINE_A)
        assert s1 == Status.SUCCESS

        # limit reached for a different machine
        s2, _ = await client.register(CODE, MACHINE_B)
        assert s2 == Status.DEVICE_LIMIT

        # transfer the license off MACHINE_A
        assert await client.apply_remove(CODE, MACHINE_A) == Status.TRANSFER_SUCCESS
        assert await client.verify_remove(CODE, MACHINE_A) == Status.TRANSFER_SUCCESS

        # the freed slot now allows MACHINE_B
        s3, _ = await client.register(CODE, MACHINE_B)
        assert s3 == Status.SUCCESS


@pytest.mark.asyncio
async def test_wrong_password_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path, password="secret123")
    async with aio_server:
        assert await client.apply_register(CODE, MACHINE_A, password="wrong") == Status.WRONG_PASSWORD
        assert await client.apply_register(CODE, MACHINE_A, password="secret123") == Status.SUCCESS
