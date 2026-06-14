"""
ZTool License Activation Server.

TCP server implementing the ZTool activation protocol:
- Frame format: [type:10 LE][len:10 LE][AES-encrypted body]
- Message types (Sendtype): 128-132
- AES key for body = str(sendtype)
"""

import asyncio
import logging

from .config import ServerConfig
from .key_provider import KeyProvider
from .logging_utils import configure_logging, payload_summary, redact_path
from .crypto.rsa_ztool import decrypt_string
from .crypto import aes_security_center as aes
from .crypto.aes_security_center import decrypt_message_body
from .protocol.framing import FrameParser, build_frame
from .protocol.framing import ProtocolError
from .protocol.dispatcher import REQUEST_SENDTYPES, Sendtype, Status, Result, status_to_result
from .license_blob import (
    generate_license_blob,
    getver_today,
    recover_raw_machine,
    build_confirm_transport,
)
from .machineid import is_valid_machine_code
from .db import LicenseDB


logger = logging.getLogger(__name__)


class LicenseServer:
    """Async TCP license activation server."""

    def __init__(self, config: ServerConfig):
        self.config = config
        self.db = LicenseDB(config.db_path)
        self._key_provider = KeyProvider.from_config(config)
        self._private_key = self._load_private_key()
        self._public_key = self._load_public_key()
        logger.info("License server initialized (port=%d)", config.port)

    def _load_private_key(self) -> str:
        """Load private key through the configured key provider."""
        try:
            return self._key_provider.load_private_key()
        except Exception:
            logger.error(
                "Private key load failed from %s",
                redact_path(self._key_provider.private_key_path),
            )
            raise

    def _load_public_key(self) -> str:
        """Load public key through the configured key provider."""
        try:
            return self._key_provider.load_public_key()
        except Exception:
            logger.error(
                "Public key load failed from %s",
                redact_path(self._key_provider.public_key_path),
            )
            raise

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
        parser = FrameParser(
            max_body_size=self.config.max_body_size,
            allowed_sendtypes=REQUEST_SENDTYPES,
        )
        frames_seen = 0

        try:
            while True:
                timeout = (
                    self.config.read_timeout_seconds
                    if parser.buffered_bytes
                    else self.config.idle_timeout_seconds
                )
                data = await asyncio.wait_for(reader.read(4096), timeout=timeout)
                if not data:
                    break

                parser.feed(data)
                for sendtype, body_bytes in parser.parse_all():
                    frames_seen += 1
                    if frames_seen > self.config.max_frames_per_connection:
                        logger.warning(
                            "Too many frames from %s: limit=%d",
                            addr,
                            self.config.max_frames_per_connection,
                        )
                        return
                    response = await self._process_message(sendtype, body_bytes)
                    if response is not None:
                        writer.write(response)
                        await writer.drain()

        except asyncio.TimeoutError:
            logger.info("Client timed out: %s", addr)
        except ProtocolError as e:
            logger.warning("Protocol error from %s: %s", addr, e)
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
            payload_bytes, payload_sha256 = payload_summary(plaintext)
            logger.debug(
                "Received message type=%d payload_bytes=%d payload_sha256=%s",
                sendtype,
                payload_bytes,
                payload_sha256,
            )
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
        # The client transmits GetMNum(_, True, True) == RSA(raw + getver); after
        # RSA-decryption we strip the trailing version suffix to recover the raw
        # "UUID|disk|board" string that IsReg1's GetMNum(_, False, False)==GD51(raw)
        # is computed over. An empty machine (hosts with no hardware IDs) stays "".
        machine_field = parts[2] if len(parts) > 2 else ""
        machine_code = recover_raw_machine(machine_field, self.config.client_version)

        with self.db.transaction():
            # Validate the registration code
            is_valid, error = self.db.validate_code(reg_code)
            if not is_valid:
                self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                                  result="rejected", details=error)
                return self._make_result(status_to_result(error, Result.INVALID_CODE))

            # Check password if set. check_password() returns True for codes that
            # have no password configured, so this also accepts password-less codes
            # while rejecting an empty/wrong password on a protected code (matching
            # _handle_apply_remove).
            if not self.db.check_password(reg_code, password):
                self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                                  result="wrong_password")
                return self._make_result(Result.WRONG_PASSWORD)

            # Reject anything that is not a genuine hardware fingerprint. Without
            # this an empty/garbage machine code would consume a license seat and be
            # handed a blob the client can never validate (IsReg1 needs a 36-char
            # GUID UUID), so the seat would be silently lost. This is the
            # hardware-binding check the activation flow was missing.
            if not is_valid_machine_code(machine_code):
                self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                                  result="rejected", details="invalid machine code")
                return self._make_result(Result.INFO_ERROR)

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
        sends SR.get_rginfo():

            line0..3 : the four registry branch strings (b0,b1,b2,b3) un-hexed
            line4    : RSA_enc(creation_time(HKLM\\...\\HTwk2RCBDL))  [b2's key]
            line5    : RSA_enc(creation_time(HKLM\\...\\98CqyvBZcg))  [b3's key]
            line6    : RSA_enc(DateTime.Now.ToString())

        The confirm response is consumed by the SAME SR.rg() but validated by
        IsReg2, which decrypts b0/b1 with GD51(creation_time) rather than the
        embedded seed/wrap-passphrase used by IsReg1. So we must rebuild b0/b1
        keyed by those two registry-key creation-time hashes (b2/b3 are reused
        verbatim) — echoing back the apply_register branches makes IsReg2 fail
        and the client shows "Регистрация не удалась".
        """
        lines = [ln.strip() for ln in plaintext.replace('\r\n', '\n').replace('\r', '\n').split('\n')]
        fields = [ln for ln in lines if ln]
        branches = fields[:4]

        if len(branches) != 4 or len(fields) < 6:
            self.db.log_action("register", result="error",
                               details=f"register confirm: expected 4 branches + 2 times, got {len(fields)} fields")
            return self._make_result(Result.INFO_ERROR)

        try:
            # The two registry-key creation times the client RSA-encrypted with
            # our public key; recover them with the private key.
            creation_time_b2 = decrypt_string(fields[4], self._private_key).strip()
            creation_time_b3 = decrypt_string(fields[5], self._private_key).strip()
            transport = build_confirm_transport(
                branches,
                creation_time_b2,
                creation_time_b3,
                public_key=self._public_key,
                private_key=self._private_key,
                client_version=self.config.client_version,
            )
        except Exception as e:
            self.db.log_action("register", result="error",
                               details=f"register confirm: blob rebuild failed: {e}")
            return self._make_result(Result.INFO_ERROR)

        self.db.log_action("register", result="success", details="register confirm")
        return self._make_result(Result.REGISTER_OK, transport)

    async def _handle_apply_remove(self, plaintext: str) -> bytes:
        """Handle Apply_Remove (129): License transfer/removal request."""
        parts = self._decrypt_request(plaintext)

        reg_code = parts[0] if len(parts) > 0 else ""
        password = parts[1] if len(parts) > 1 else ""
        # Same GetMNum(_, True, True) transport as apply_register: strip the
        # version suffix so the machine matches the raw value bound at activation.
        machine_field = parts[2] if len(parts) > 2 else ""
        machine_code = recover_raw_machine(machine_field, self.config.client_version)

        with self.db.transaction():
            # A transfer can only target a genuine, previously-bound fingerprint.
            if not is_valid_machine_code(machine_code):
                self.db.log_action("apply_remove", code=reg_code, machine_code=machine_code,
                                  result="rejected", details="invalid machine code")
                return self._make_result(Result.INFO_ERROR)

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

        # The multi-line (createinfo) format always carries at least the code
        # line followed by the machine line. The password line (index 2) is an
        # EMPTY string when the user leaves the "license protection password"
        # field blank — a fully legitimate, password-less activation — and the
        # trailing-blank strip above then collapses the body to just 2 lines
        # ([code, machine]). Any plaintext that contains a newline is therefore
        # the createinfo format; a single RSA blob (legacy emulator/tests) has
        # none and falls through to the backslash fallback below.
        if len(lines) >= 2 and lines[0].strip():
            code = _maybe_decrypt(lines[0])
            # Machine code (SR.GetMNum) is itself RSA-encrypted when present;
            # it is an empty line on hosts whose hardware IDs are unavailable.
            machine = _maybe_decrypt(lines[1])
            password = _maybe_decrypt(lines[2]) if len(lines) > 2 else ""
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
    parser.add_argument('--host', default=None, help='Bind address')
    parser.add_argument('--port', type=int, default=None, help='Port (default: 58000)')
    parser.add_argument('--keys-dir', default=None, help='Keys directory')
    parser.add_argument('--private-key-file', default=None, help='Private key file')
    parser.add_argument('--public-key-file', default=None, help='Public key file')
    parser.add_argument('--db', default=None, help='Database path')
    parser.add_argument('--log-level', default=None, help='Log level')
    parser.add_argument('--runtime-env', default=None, help='Runtime env: development/test/production')
    parser.add_argument('--max-body-size', type=int, default=None, help='Maximum request body size in bytes')
    parser.add_argument(
        '--max-frames-per-connection',
        type=int,
        default=None,
        help='Maximum frames accepted on one TCP connection',
    )
    parser.add_argument('--read-timeout-seconds', type=float, default=None, help='Partial-frame read timeout')
    parser.add_argument('--idle-timeout-seconds', type=float, default=None, help='Idle connection timeout')
    parser.add_argument(
        '--allow-debug-logging',
        action='store_true',
        default=None,
        help='Allow DEBUG logging in production for a controlled emergency window',
    )
    args = parser.parse_args()

    # Start from environment (ZTOOL_HOST/PORT/KEYS_DIR/DB_PATH/...) so env-only
    # launches work, then let explicit CLI flags take precedence.
    config = ServerConfig.from_env()
    if args.host is not None:
        config.host = args.host
    if args.port is not None:
        config.port = args.port
    if args.keys_dir:
        config.keys_dir = args.keys_dir
    if args.private_key_file:
        config.private_key_file = args.private_key_file
    if args.public_key_file:
        config.public_key_file = args.public_key_file
    if args.db:
        config.db_path = args.db
    if args.log_level:
        config.log_level = args.log_level
    if args.runtime_env:
        config.runtime_env = args.runtime_env
    if args.max_body_size is not None:
        config.max_body_size = args.max_body_size
    if args.max_frames_per_connection is not None:
        config.max_frames_per_connection = args.max_frames_per_connection
    if args.read_timeout_seconds is not None:
        config.read_timeout_seconds = args.read_timeout_seconds
    if args.idle_timeout_seconds is not None:
        config.idle_timeout_seconds = args.idle_timeout_seconds
    if args.allow_debug_logging is not None:
        config.allow_debug_logging = args.allow_debug_logging

    configure_logging(
        config.log_level,
        runtime_env=config.runtime_env,
        allow_debug_logging=config.allow_debug_logging,
    )

    server = LicenseServer(config)
    await server.start()


if __name__ == "__main__":
    asyncio.run(main())
