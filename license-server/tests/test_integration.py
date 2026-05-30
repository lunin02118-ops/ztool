"""
End-to-end integration tests for the license server.

An in-process client emulator exercises the *real* ZTool activation protocol
over a real asyncio TCP socket against a freshly generated key pair, matching
the de-obfuscated client (FrmRg.createinfo / TCPClient.SocketRecive / SR.rg /
SR.get_rginfo):

    apply_register (128) -> server replies result 13 + license blob
    register confirm (131, SR.get_rginfo) -> server replies result 12
    apply_remove (129) -> result 11 -> remove confirm (132) -> result 7

Wire facts these tests pin down:
  * Requests are newline-joined fields, each RSA-encrypted with the server's
    PUBLIC key, then AES-wrapped with passphrase = str(sendtype). The header's
    first 10-byte field is the SENDTYPE.
  * Responses put the numeric RESULT code in the first 10-byte header field
    (NOT the sendtype). The body is RAW (no str(sendtype) AES layer): for
    success it is the transport blob SR.rg() consumes; for errors it is empty.

These tests validate the internal end-to-end consistency of the server. They do
NOT by themselves prove byte-compatibility with the real client on a bench.
"""

import asyncio

import pytest

from ztool_license_server.config import ServerConfig
from ztool_license_server.server import LicenseServer
from ztool_license_server.crypto.keygen import generate_keypair, save_keypair
from ztool_license_server.crypto.rsa_ztool import encrypt_string, decrypt_string
from ztool_license_server.crypto.aes_security_center import (
    encrypt_message_body,
)
from ztool_license_server.crypto import aes_security_center as aes
from ztool_license_server.license_blob import (
    getver_today, gd51, machine_version_suffix,
    FIRST_LEN_B2, FIRST_LEN_B3, SUFFIX_LEN,
)
from ztool_license_server.protocol.framing import build_frame, FrameParser
from ztool_license_server.protocol.dispatcher import Sendtype, Result


CODE = "AAAAA-BBBBB-CCCCC-DDDDD-EEEEE"
MACHINE_A = "UUID-AAAA-1111|DISK-AAAA|BOARD-AAAA"
MACHINE_B = "UUID-BBBB-2222|DISK-BBBB|BOARD-BBBB"
MACHINE_C = "UUID-CCCC-3333|DISK-CCCC|BOARD-CCCC"
# The real client always sends a password field (validated 8-20 chars); for
# codes with no server-side password the value is irrelevant.
DUMMY_PW = "Testpass123"


class ZToolClientEmulator:
    """Emulation of the real client transport (TCPClient.sendstring +
    FrmRg.createinfo + TCPClient.getreceive + SR.rg/get_rginfo)."""

    def __init__(self, host, port, public_key):
        self.host = host
        self.port = port
        self.public_key = public_key

    def _rsa(self, value: str) -> str:
        if not value:
            return ""
        return encrypt_string(value, self.public_key, encoding="utf-8")

    async def _send(self, sendtype: int, lines: list) -> tuple:
        """Send one request frame, return (result_code:int, raw_body:str)."""
        reader, writer = await asyncio.open_connection(self.host, self.port)
        try:
            # createinfo: AppendLine-joined fields -> AES(str(sendtype)).
            inner = "\n".join(lines)
            aes_body = encrypt_message_body(inner, sendtype)
            writer.write(build_frame(sendtype, aes_body.encode("utf-8")))
            await writer.drain()

            # Read until a full frame parses. Over a real network the response
            # (result code + license blob) can span several TCP segments, so a
            # single read() may only return the header/first chunk.
            parser = FrameParser()
            frame = None
            while frame is None:
                data = await asyncio.wait_for(reader.read(65536), timeout=5)
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

    def _machine_field(self, machine, client_version=ServerConfig.client_version):
        """Model GetMNum(_, True, True): the client builds
        ``Concat(raw, "\\n", getver(...))``, takes ``Mid(.,1,117)`` and
        RSA-encrypts it. (verified from SR.GetMNum IL: separator is a newline.)"""
        transport = machine + "\n" + machine_version_suffix(client_version)
        return self._rsa(transport[:117])

    async def apply_register(self, code, machine, password=DUMMY_PW):
        """Sendtype 128. createinfo(true, false) field order:
        RSA(code), RSA(GetMNum), RSA(password), RSA(MachineName\\user)."""
        lines = [self._rsa(code), self._machine_field(machine), self._rsa(password),
                 self._rsa("HOST\\user")]
        return await self._send(Sendtype.APPLY_REGISTER, lines)

    async def register_confirm(self, blob, client_version=ServerConfig.client_version):
        """Sendtype 131. SR.get_rginfo(): the four registry branch ciphertexts
        (un-hexed) plus three RSA-encrypted timestamps."""
        gv = getver_today(client_version, is_64bit=True)
        branches = aes.decrypt(blob, gv).split("\t")
        ts = self._rsa("1.0")
        lines = list(branches) + [ts, ts, ts]
        return await self._send(Sendtype.REGISTER_CONFIRM, lines)

    async def apply_remove(self, code, machine, password=DUMMY_PW):
        lines = [self._rsa(code), self._machine_field(machine), self._rsa(password),
                 self._rsa("HOST\\user")]
        return await self._send(Sendtype.APPLY_REMOVE, lines)

    async def remove_confirm(self):
        return await self._send(Sendtype.REMOVE_CONFIRM, [self._rsa("x")])

    def unwrap_license_blob(self, blob: str, client_version=ServerConfig.client_version) -> str:
        """Reverse the transport payload the way FrmRg.rg()+IsReg1 do, returning
        the bound machine value (loc_c == Concat(b2, b3) == GD51(raw machine))."""
        gv = getver_today(client_version, is_64bit=True)
        joined = aes.decrypt(blob, gv)
        b0_raw, b1_raw, b2_raw, b3_raw = (
            x.replace("\x00", "") for x in joined.split("\t")
        )

        def right(s, n):
            return s[len(s) - n:] if n <= len(s) else s

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
        # 1. Apply for registration -> result 13 + license blob.
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        assert blob, "expected a license blob in the apply_register response"

        # 2. The blob must decrypt + verify and rebuild GD51(machine) -- the
        #    value IsReg1 compares against GetMNum(_, False, False).
        assert client.unwrap_license_blob(blob) == gd51(MACHINE_A)

        # 3. Register confirm (SR.get_rginfo) -> result 12 + transport blob.
        code2, transport = await client.register_confirm(blob)
        assert code2 == Result.REGISTER_OK
        assert client.unwrap_license_blob(transport) == gd51(MACHINE_A)


@pytest.mark.asyncio
async def test_activation_without_password(tmp_path):
    """Real GUI regression: FrmRg.createinfo(false, false) with the license
    protection password left blank emits only [RSA(code), RSA(GetMNum)] because
    RSAHelper.EncryptString("") == "" and the trailing AppendLine/Trim collapses
    the empty password line away. The server must still accept this 2-line,
    password-less apply (result 13 + blob), not reject it as INFO_ERROR(6)."""
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        lines = [client._rsa(CODE), client._machine_field(MACHINE_A)]  # no pw, no optional
        code, blob = await client._send(Sendtype.APPLY_REGISTER, lines)
        assert code == Result.APPLY_OK, f"expected 13, got {code}"
        assert blob, "expected a license blob"
        assert client.unwrap_license_blob(blob) == gd51(MACHINE_A)

        code2, transport = await client.register_confirm(blob)
        assert code2 == Result.REGISTER_OK


@pytest.mark.asyncio
async def test_invalid_code_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, body = await client.apply_register("ZZZZZ-ZZZZZ-ZZZZZ-ZZZZZ-ZZZZZ", MACHINE_A)
        assert code == Result.INVALID_CODE
        assert body == ""


@pytest.mark.asyncio
async def test_device_limit_enforced(tmp_path):
    server, aio_server, client = await _make_server(tmp_path, device_limit=2)
    async with aio_server:
        c1, _ = await client.apply_register(CODE, MACHINE_A)
        c2, _ = await client.apply_register(CODE, MACHINE_B)
        assert c1 == Result.APPLY_OK and c2 == Result.APPLY_OK

        # third distinct device exceeds the limit
        c3, _ = await client.apply_register(CODE, MACHINE_C)
        assert c3 == Result.DEVICE_LIMIT


@pytest.mark.asyncio
async def test_transfer_out_flow(tmp_path):
    server, aio_server, client = await _make_server(tmp_path, device_limit=1)
    async with aio_server:
        c1, _ = await client.apply_register(CODE, MACHINE_A)
        assert c1 == Result.APPLY_OK

        # limit reached for a different machine
        c2, _ = await client.apply_register(CODE, MACHINE_B)
        assert c2 == Result.DEVICE_LIMIT

        # transfer the license off MACHINE_A: 129 -> 11, then 132 -> 7
        cr, _ = await client.apply_remove(CODE, MACHINE_A)
        assert cr == Result.TRANSFER_OUT_OK
        cc, _ = await client.remove_confirm()
        assert cc == Result.TRANSFER_DONE

        # the freed slot now allows MACHINE_B
        c3, _ = await client.apply_register(CODE, MACHINE_B)
        assert c3 == Result.APPLY_OK


@pytest.mark.asyncio
async def test_wrong_password_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path, password="secret123")
    async with aio_server:
        cw, _ = await client.apply_register(CODE, MACHINE_A, password="wrong")
        assert cw == Result.WRONG_PASSWORD
        cok, _ = await client.apply_register(CODE, MACHINE_A, password="secret123")
        assert cok == Result.APPLY_OK
