"""
TCP frame protocol compatible with ZTool.TCPClient.

Frame format:
    [type: 10 bytes LE int] [length: 10 bytes LE int] [body: `length` bytes]

- int_to_Byte(v, 10): stores value as little-endian 4 bytes + 6 zero bytes (total 10)
- H_length = L_length = 10 (header field sizes)
- body = UTF-8 encoded AES-Base64 string (trimmed)
"""

import struct
from typing import Tuple, Optional


HEADER_FIELD_SIZE = 10  # Both type and length fields are 10 bytes


def encode_int_field(value: int) -> bytes:
    """
    Encode an integer into a 10-byte field (little-endian).

    ZTool's int_to_Byte(v, 10):
    - Stores value as 4-byte LE int
    - Remaining 6 bytes are zero-padded
    """
    le_bytes = struct.pack('<i', value)  # 4 bytes, little-endian signed int
    return le_bytes + b'\x00' * 6  # Pad to 10 bytes total


def decode_int_field(data: bytes) -> int:
    """
    Decode a 10-byte field into an integer.

    Only first 4 bytes are significant (little-endian int32).
    """
    assert len(data) == HEADER_FIELD_SIZE, f"Expected {HEADER_FIELD_SIZE} bytes, got {len(data)}"
    return struct.unpack('<i', data[:4])[0]


def build_frame(sendtype: int, body: bytes) -> bytes:
    """
    Build a complete frame for sending.

    Args:
        sendtype: Message type code (e.g. 128, 130)
        body: Already-encrypted body (UTF-8 encoded AES-Base64 string)

    Returns:
        Complete frame bytes: [type:10][length:10][body]
    """
    type_field = encode_int_field(sendtype)
    length_field = encode_int_field(len(body))
    return type_field + length_field + body


def build_response_frame(sendtype: int, encrypted_body: str) -> bytes:
    """
    Build a response frame with an encrypted body string.

    Args:
        sendtype: Message type code
        encrypted_body: AES-encrypted Base64 string (will be UTF-8 encoded)

    Returns:
        Complete frame bytes
    """
    body_bytes = encrypted_body.strip().encode('utf-8')
    return build_frame(sendtype, body_bytes)


class FrameParser:
    """
    Incremental frame parser for TCP streams.

    Handles fragmentation: accumulates data until a complete frame is available.
    """

    def __init__(self):
        self._buffer = bytearray()

    def feed(self, data: bytes) -> None:
        """Add received data to the internal buffer."""
        self._buffer.extend(data)

    def try_parse(self) -> Optional[Tuple[int, bytes]]:
        """
        Try to parse a complete frame from the buffer.

        Returns:
            (sendtype, body_bytes) if a complete frame is available, None otherwise.
        """
        header_total = HEADER_FIELD_SIZE * 2  # type + length

        if len(self._buffer) < header_total:
            return None

        sendtype = decode_int_field(bytes(self._buffer[:HEADER_FIELD_SIZE]))
        body_len = decode_int_field(bytes(self._buffer[HEADER_FIELD_SIZE:header_total]))

        total_frame_size = header_total + body_len
        if len(self._buffer) < total_frame_size:
            return None

        body = bytes(self._buffer[header_total:total_frame_size])
        # Remove parsed frame from buffer
        self._buffer = self._buffer[total_frame_size:]

        return (sendtype, body)

    def parse_all(self) -> list:
        """Parse all complete frames available in the buffer."""
        frames = []
        while True:
            result = self.try_parse()
            if result is None:
                break
            frames.append(result)
        return frames
