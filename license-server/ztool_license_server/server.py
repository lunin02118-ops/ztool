"""
ZTool License Activation Server.

TCP server implementing the ZTool activation protocol:
- Frame format: [type:10 LE][len:10 LE][AES-encrypted body]
- Message types (Sendtype): 128-132
- AES key for body = str(sendtype)
"""

import asyncio
import logging
import os
import sys
from datetime import datetime

from .config import ServerConfig
from .crypto.rsa_ztool import decrypt_string
from .crypto import aes_security_center as aes
from .crypto.aes_security_center import decrypt_message_body
from .protocol.framing import FrameParser, build_frame
from .protocol.dispatcher import Sendtype, Status, Result, status_to_result
from .license_blob import generate_license_blob, getver_today
from .db import LicenseDB


logger = logging.getLogger(__name__)


class LicenseServer:
    """Async TCP license activation server."""

    def __init__(self, config: ServerConfig):
        self.config = config
        self.db = LicenseDB(config.db_path)
        self._private_key = self._load_private_key()
        self._public_key = self._load_public_key()
        logger.info("License server initialized (port=%d)", config.port)

    def _load_private_key(self) -> str:
        """Load private key from keys directory."""
        path = os.path.join(self.config.keys_dir, 'private_key.txt')
        if not os.path.exists(path):
            logger.error("Private key not found at %s. Run keygen first.", path)
            raise FileNotFoundError(f"Private key not found: {path}")
        with open(path, 'r') as f:
            return f.read().strip()

    def _load_public_key(self) -> str:
        """Load public key from keys directory."""
        path = os.path.join(self.config.keys_dir, 'public_key.txt')
        if not os.path.exists(path):
            logger.error("Public key not found at %s. Run keygen first.", path)
            raise FileNotFoundError(f"Public key not found: {path}")
        with open(path, 'r') as f:
            return f.read().strip()

    async def start(self):
        """Start the TCP server."""
        server = await asyncio.start_server(
            self._handle_client, self.config.host, self.config.port
        )
        addr = server.sockets[0].getsockname()
        logger.info("License server listening on %s:%d", addr[0], addr[1])

        async with server:
            await server.serve_forever()

    async def _handle_client(self, reader: asyncio.StreamReader, writer: asyncio.StreamWriter):
        """Handle a single client connection."""
        addr = writer.get_extra_info('peername')
        logger.info("Client connected: %s", addr)
        parser = FrameParser()

        try:
            while True:
                data = await reader.read(4096)
                if not data:
                    break

                parser.feed(data)
                for sendtype, body_bytes in parser.parse_all():
                    response = await self._process_message(sendtype, body_bytes)
                    if response is not None:
                        writer.write(response)
                        await writer.drain()

        except (ConnectionResetError, BrokenPipeError):
            logger.info("Client disconnected: %s", addr)
        except Exception as e:
            logger.error("Error handling client %s: %s", addr, e, exc_info=True)
        finally:
            writer.close()
            await writer.wait_closed()
            logger.info("Connection closed: %s", addr)

    async def _process_message(self, sendtype: int, body_bytes: bytes) -> bytes:
        """
        Process a received message and return the response frame.

        Args:
            sendtype: Message type code
            body_bytes: Raw body bytes (AES-encrypted, Base64-encoded, UTF-8)

        Returns:
            Response frame bytes
        """
        try:
            # Decrypt body. Requests are AES-encrypted by the client's
            # sendstring() with passphrase = str(sendtype).
            body_b64 = body_bytes.decode('utf-8').strip()
            plaintext = decrypt_message_body(body_b64, sendtype)
            logger.debug("Received type=%d, body=%s", sendtype, plaintext[:100])
        except Exception as e:
            logger.error("Failed to decrypt message type=%d: %s", sendtype, e)
            return self._make_result(Result.INFO_ERROR)

        # Dispatch. The real client flow is:
        #   128 apply_register  -> server replies 13 + license blob
        #   131 register confirm -> server replies 12 (final success)
        #   129 apply_remove     -> server replies 11 (then client sends 132)
        #   132 remove confirm   -> server replies 7  (transfer done)
        if sendtype == Sendtype.APPLY_REGISTER:          # 128
            return await self._handle_apply_register(plaintext)
        elif sendtype in (Sendtype.REGISTER_CONFIRM, Sendtype.REGISTER):  # 131 / 130
            return await self._handle_register_confirm(plaintext)
        elif sendtype == Sendtype.APPLY_REMOVE:          # 129
            return await self._handle_apply_remove(plaintext)
        elif sendtype == Sendtype.REMOVE_CONFIRM:        # 132
            return await self._handle_remove_confirm(plaintext)
        else:
            logger.warning("Unknown sendtype: %d", sendtype)
            return self._make_result(Result.REGISTER_FAILED)

    async def _handle_apply_register(self, plaintext: str) -> bytes:
        """
        Handle Apply_register (128): Registration application.

        Client sends: RSA_encrypted(reg_code + separator + password + machine_code)
        The exact format of the payload depends on createinfo/FrmRg logic.

        For now we parse the decrypted plaintext which contains:
        - Registration code (5 parts: L1-L2-L3-L4-L5)
        - Optional password
        - Machine code

        Separated by backslash '\\' based on IL analysis.
        """
        parts = self._decrypt_request(plaintext)

        if len(parts) < 2:
            self.db.log_action("apply_register", result="error", details="Invalid payload format")
            return self._make_result(Result.INFO_ERROR)

        reg_code = parts[0] if len(parts) > 0 else ""
        password = parts[1] if len(parts) > 1 else ""
        machine_code = parts[2] if len(parts) > 2 else ""

        # Validate the registration code
        is_valid, error = self.db.validate_code(reg_code)
        if not is_valid:
            self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                              result="rejected", details=error)
            return self._make_result(status_to_result(error, Result.INVALID_CODE))

        # Check password if set
        if password and not self.db.check_password(reg_code, password):
            self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                              result="wrong_password")
            return self._make_result(Result.WRONG_PASSWORD)

        # Bind the seat to this machine (idempotent for repeats).
        success, error = self.db.activate(reg_code, machine_code)
        if not success:
            self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                              result="limit_reached", details=error)
            return self._make_result(status_to_result(error, Result.DEVICE_LIMIT))

        # Generate the license transport payload (the string FrmRg.rg()
        # consumes: AES_getver( "\t".join(4 registry branch blobs) )). The real
        # client delivers the blob in THIS (apply_register) response with result
        # code 13, then saves it (SR.rg), validates IsReg1, and follows up with
        # a 131 (register confirm) carrying SR.get_rginfo().
        blob = generate_license_blob(
            machine_code=machine_code,
            public_key=self._public_key,
            private_key=self._private_key,
            client_version=self.config.client_version,
        )

        self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                          result="accepted")
        return self._make_result(Result.APPLY_OK, blob)

    async def _handle_register_confirm(self, plaintext: str) -> bytes:
        """
        Handle register confirm (Sendtype 131): final activation step.

        After the client saves the blob from the apply_register (13) response it
        sends SR.get_rginfo() — the four registry branch ciphertexts (un-hexed)
        followed by three RSA-encrypted timestamps. We reconstruct the transport
        payload from those four branches and return it with result code 12, which
        the client re-saves (SR.rg) and validates with IsReg2 -> "Регистрация
        выполнена". IsReg2 reads the registry already populated at step 13, so
        this response simply has to be a well-formed transport blob.
        """
        lines = [ln.strip() for ln in plaintext.replace('\r\n', '\n').replace('\r', '\n').split('\n')]
        branches = [ln for ln in lines if ln][:4]

        if len(branches) != 4:
            self.db.log_action("register", result="error",
                               details=f"register confirm: expected 4 branches, got {len(branches)}")
            return self._make_result(Result.INFO_ERROR)

        transport = aes.encrypt(
            "\t".join(branches),
            getver_today(self.config.client_version),
        )
        self.db.log_action("register", result="success", details="register confirm")
        return self._make_result(Result.REGISTER_OK, transport)

    async def _handle_apply_remove(self, plaintext: str) -> bytes:
        """Handle Apply_Remove (129): License transfer/removal request."""
        parts = self._decrypt_request(plaintext)

        reg_code = parts[0] if len(parts) > 0 else ""
        password = parts[1] if len(parts) > 1 else ""
        machine_code = parts[2] if len(parts) > 2 else ""

        # Check password
        if not self.db.check_password(reg_code, password):
            self.db.log_action("apply_remove", code=reg_code, machine_code=machine_code,
                              result="wrong_password")
            return self._make_result(Result.WRONG_PASSWORD)

        # Deactivate. On success reply 11 -> the client runs SR.outrg() and then
        # sends a 132 (remove confirm), which we answer with 7 (transfer done).
        success, error = self.db.deactivate(reg_code, machine_code)
        if success:
            self.db.log_action("apply_remove", code=reg_code, machine_code=machine_code,
                              result="success")
            return self._make_result(Result.TRANSFER_OUT_OK)
        else:
            self.db.log_action("apply_remove", code=reg_code, machine_code=machine_code,
                              result="failed", details=error)
            return self._make_result(status_to_result(error, Result.REGISTER_FAILED))

    async def _handle_remove_confirm(self, plaintext: str) -> bytes:
        """Handle remove confirm (Sendtype 132): finalise a transfer/removal."""
        self.db.log_action("remove_confirm", result="confirmed")
        return self._make_result(Result.TRANSFER_DONE)

    def _decrypt_request(self, plaintext: str) -> list:
        """Parse a decrypted request body into ``[code, password, machine, *extra]``.

        Ground truth is the real client's ``ZTool.FrmRg.createinfo`` (verified by
        IL): it builds the payload with ``StringBuilder.AppendLine`` (so fields are
        separated by a newline) in this order:

            line 0: RSAHelper.EncryptString(reg_code, server_public_key)
            line 1: SR.GetMNum(...)  -- machine fingerprint, RSA-encrypted when
                                        present; an EMPTY line on hosts whose
                                        hardware IDs (UUID/disk/board) are absent
            line 2: RSAHelper.EncryptString(password, server_public_key)
            line 3: RSAHelper.EncryptString(MachineName\\UserName, pub)  -- optional
            line 4: SR.get_rgtime()                                      -- optional

        Every populated field is individually RSA-encrypted with the server's
        PUBLIC key, so we recover each with the PRIVATE key (c^d mod n). We
        normalise the result to the order the handlers expect:
        ``[code, password, machine, *extra]``.

        A legacy fallback (single RSA blob split on backslash) is kept so the
        in-process emulator and existing integration tests keep working.
        """
        def _maybe_decrypt(field: str) -> str:
            field = field.strip()
            if not field:
                return field
            try:
                return decrypt_string(field, self._private_key, encoding='utf-8')
            except Exception:
                return field

        lines = [ln for ln in plaintext.replace('\r\n', '\n').replace('\r', '\n').split('\n')]
        # Strip trailing blank lines produced by the final AppendLine/Trim.
        while lines and not lines[-1].strip():
            lines.pop()

        if len(lines) >= 3 and lines[0].strip() and lines[2].strip():
            code = _maybe_decrypt(lines[0])
            # Machine code (SR.GetMNum) is itself RSA-encrypted when present;
            # it is an empty line on hosts whose hardware IDs are unavailable.
            machine = _maybe_decrypt(lines[1])
            password = _maybe_decrypt(lines[2])
            extra = [_maybe_decrypt(ln) for ln in lines[3:]]
            return [code, password, machine] + extra

        # Legacy fallback: whole body RSA-encrypted, fields joined by backslash.
        try:
            decrypted = decrypt_string(plaintext, self._private_key, encoding='utf-8')
            return decrypted.split('\\')
        except Exception:
            return plaintext.split('\\')

    def _make_result(self, result_code: int, body: str = "") -> bytes:
        """Build a response frame the client understands.

        The client's ``getreceive`` reads the FIRST 10-byte header field as the
        numeric RESULT code (not the sendtype) and reads the body RAW (it does
        not transport-decrypt the response — SR.rg AES-decrypts it later with the
        getver passphrase). So success responses carry the already-encrypted
        transport blob as the body; error responses carry an empty body.
        """
        return build_frame(int(result_code), body.strip().encode('utf-8'))


async def main():
    """Entry point for the license server."""
    import argparse

    parser = argparse.ArgumentParser(description="ZTool License Activation Server")
    parser.add_argument('--host', default='0.0.0.0', help='Bind address')
    parser.add_argument('--port', type=int, default=58000, help='Port (default: 58000)')
    parser.add_argument('--keys-dir', default=None, help='Keys directory')
    parser.add_argument('--db', default=None, help='Database path')
    parser.add_argument('--log-level', default='INFO', help='Log level')
    args = parser.parse_args()

    logging.basicConfig(
        level=getattr(logging, args.log_level.upper()),
        format='%(asctime)s [%(levelname)s] %(name)s: %(message)s'
    )

    config = ServerConfig(
        host=args.host,
        port=args.port,
    )
    if args.keys_dir:
        config.keys_dir = args.keys_dir
    if args.db:
        config.db_path = args.db

    server = LicenseServer(config)
    await server.start()


if __name__ == "__main__":
    asyncio.run(main())
