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
from .crypto.aes_security_center import encrypt_message_body, decrypt_message_body
from .protocol.framing import FrameParser, build_response_frame
from .protocol.dispatcher import Sendtype, Status
from .license_blob import generate_license_blob
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
            # Decrypt body
            body_b64 = body_bytes.decode('utf-8').strip()
            plaintext = decrypt_message_body(body_b64, sendtype)
            logger.debug("Received type=%d, body=%s", sendtype, plaintext[:100])
        except Exception as e:
            logger.error("Failed to decrypt message type=%d: %s", sendtype, e)
            return self._make_error_response(sendtype, Status.INFO_ERROR)

        # Dispatch
        if sendtype == Sendtype.APPLY_REGISTER:
            return await self._handle_apply_register(plaintext)
        elif sendtype == Sendtype.REGISTER:
            return await self._handle_register(plaintext)
        elif sendtype == Sendtype.VERIFY_REGISTER:
            return await self._handle_verify_register(plaintext)
        elif sendtype == Sendtype.APPLY_REMOVE:
            return await self._handle_apply_remove(plaintext)
        elif sendtype == Sendtype.VERIFY_REMOVE:
            return await self._handle_verify_remove(plaintext)
        else:
            logger.warning("Unknown sendtype: %d", sendtype)
            return self._make_error_response(sendtype, Status.FAILED)

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
            return self._make_response(Sendtype.APPLY_REGISTER, Status.INFO_ERROR)

        reg_code = parts[0] if len(parts) > 0 else ""
        password = parts[1] if len(parts) > 1 else ""
        machine_code = parts[2] if len(parts) > 2 else ""

        # Validate the registration code
        is_valid, error = self.db.validate_code(reg_code)
        if not is_valid:
            self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                              result="rejected", details=error)
            return self._make_response(Sendtype.APPLY_REGISTER, error)

        # Check password if set
        if password and not self.db.check_password(reg_code, password):
            self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                              result="wrong_password")
            return self._make_response(Sendtype.APPLY_REGISTER, Status.WRONG_PASSWORD)

        # Application accepted — client should follow up with REGISTER (130)
        self.db.log_action("apply_register", code=reg_code, machine_code=machine_code,
                          result="accepted")
        return self._make_response(Sendtype.APPLY_REGISTER, Status.SUCCESS)

    async def _handle_register(self, plaintext: str) -> bytes:
        """
        Handle register (130): License issuance.

        After successful Apply_register, client sends register request.
        Server issues a signed license blob.
        """
        parts = self._decrypt_request(plaintext)

        reg_code = parts[0] if len(parts) > 0 else ""
        machine_code = parts[1] if len(parts) > 1 else ""

        # Validate
        is_valid, error = self.db.validate_code(reg_code)
        if not is_valid:
            self.db.log_action("register", code=reg_code, machine_code=machine_code,
                              result="rejected", details=error)
            return self._make_response(Sendtype.REGISTER, error)

        # Activate
        success, error = self.db.activate(reg_code, machine_code)
        if not success:
            self.db.log_action("register", code=reg_code, machine_code=machine_code,
                              result="limit_reached", details=error)
            return self._make_response(Sendtype.REGISTER, error)

        # Generate the license transport payload (the string FrmRg.rg()
        # consumes: AES_getver( "\t".join(4 registry branch blobs) )).
        blob = generate_license_blob(
            machine_code=machine_code,
            public_key=self._public_key,
            private_key=self._private_key,
            client_version=self.config.client_version,
        )

        # Response: success status + license blob
        response_payload = f"{Status.SUCCESS}\n{blob}"

        self.db.log_action("register", code=reg_code, machine_code=machine_code, result="success")
        return self._make_response(Sendtype.REGISTER, response_payload)

    async def _handle_verify_register(self, plaintext: str) -> bytes:
        """Handle verify_register (131): Check registration status."""
        parts = self._decrypt_request(plaintext)

        reg_code = parts[0] if len(parts) > 0 else ""
        machine_code = parts[1] if len(parts) > 1 else ""

        if self.db.is_machine_activated(reg_code, machine_code):
            self.db.log_action("verify_register", code=reg_code, machine_code=machine_code,
                              result="active")
            return self._make_response(Sendtype.VERIFY_REGISTER, Status.SUCCESS)
        else:
            self.db.log_action("verify_register", code=reg_code, machine_code=machine_code,
                              result="not_active")
            return self._make_response(Sendtype.VERIFY_REGISTER, Status.FAILED)

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
            return self._make_response(Sendtype.APPLY_REMOVE, Status.WRONG_PASSWORD)

        # Deactivate
        success, error = self.db.deactivate(reg_code, machine_code)
        if success:
            self.db.log_action("apply_remove", code=reg_code, machine_code=machine_code,
                              result="success")
            return self._make_response(Sendtype.APPLY_REMOVE, Status.TRANSFER_SUCCESS)
        else:
            self.db.log_action("apply_remove", code=reg_code, machine_code=machine_code,
                              result="failed", details=error)
            return self._make_response(Sendtype.APPLY_REMOVE, error)

    async def _handle_verify_remove(self, plaintext: str) -> bytes:
        """Handle verify_Remove (132): Verify transfer/removal."""
        parts = self._decrypt_request(plaintext)

        reg_code = parts[0] if len(parts) > 0 else ""
        machine_code = parts[1] if len(parts) > 1 else ""

        if not self.db.is_machine_activated(reg_code, machine_code):
            self.db.log_action("verify_remove", code=reg_code, machine_code=machine_code,
                              result="confirmed")
            return self._make_response(Sendtype.VERIFY_REMOVE, Status.TRANSFER_SUCCESS)
        else:
            self.db.log_action("verify_remove", code=reg_code, machine_code=machine_code,
                              result="still_active")
            return self._make_response(Sendtype.VERIFY_REMOVE, Status.TRANSFER_FAILED)

    def _decrypt_request(self, plaintext: str) -> list:
        """Decrypt an RSA-encrypted request body and split it into fields.

        The client encrypts request fields with the server's PUBLIC key, so the
        server reverses the operation with its PRIVATE key (c^d mod n). If RSA
        decryption fails (e.g. an unencrypted/test payload), the body is parsed
        as plaintext.

        Fields are separated by a backslash ('\\') per the client's createinfo logic.
        """
        try:
            decrypted = decrypt_string(plaintext, self._private_key, encoding='utf-8')
            return decrypted.split('\\')
        except Exception:
            return plaintext.split('\\')

    def _make_response(self, sendtype: int, body_text: str) -> bytes:
        """Create an encrypted response frame."""
        encrypted = encrypt_message_body(body_text, sendtype)
        return build_response_frame(sendtype, encrypted)

    def _make_error_response(self, sendtype: int, error_msg: str) -> bytes:
        """Create an error response frame."""
        return self._make_response(sendtype, error_msg)


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
