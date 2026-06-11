"""Tests for the TCP protocol framing."""

import pytest
from ztool_license_server.protocol.framing import (
    encode_int_field, decode_int_field, build_frame,
    build_response_frame, FrameParser, HEADER_FIELD_SIZE,
)
from ztool_license_server.protocol.dispatcher import Sendtype


class TestIntEncoding:
    """Test integer field encoding/decoding."""

    def test_encode_decode_roundtrip(self):
        """Encode and decode various integers."""
        values = [0, 1, 128, 130, 255, 1000, 65535, 2**20]
        for v in values:
            encoded = encode_int_field(v)
            assert len(encoded) == HEADER_FIELD_SIZE
            decoded = decode_int_field(encoded)
            assert decoded == v, f"Failed for value {v}"

    def test_field_is_10_bytes(self):
        """Encoded field is always exactly 10 bytes."""
        for v in [0, 128, 999999]:
            assert len(encode_int_field(v)) == 10

    def test_little_endian(self):
        """First 4 bytes are little-endian representation."""
        encoded = encode_int_field(128)
        # 128 in LE = 0x80, 0x00, 0x00, 0x00
        assert encoded[0] == 128
        assert encoded[1] == 0
        assert encoded[2] == 0
        assert encoded[3] == 0
        # Remaining 6 bytes are zero
        assert encoded[4:] == b'\x00' * 6


class TestFrameBuilding:
    """Test frame construction."""

    def test_build_frame(self):
        """Build a basic frame."""
        body = b"Hello"
        frame = build_frame(128, body)
        assert len(frame) == 10 + 10 + len(body)

        # Parse back
        sendtype = decode_int_field(frame[:10])
        body_len = decode_int_field(frame[10:20])
        assert sendtype == 128
        assert body_len == 5
        assert frame[20:] == body

    def test_build_response_frame(self):
        """Build a response frame with encrypted body string."""
        body_str = "encrypted_base64_data"
        frame = build_response_frame(130, body_str)
        assert len(frame) == 20 + len(body_str.encode('utf-8'))


class TestFrameParser:
    """Test incremental frame parsing."""

    def test_parse_complete_frame(self):
        """Parse a single complete frame."""
        body = b"test body content"
        frame = build_frame(130, body)

        parser = FrameParser()
        parser.feed(frame)
        result = parser.try_parse()

        assert result is not None
        sendtype, parsed_body = result
        assert sendtype == 130
        assert parsed_body == body

    def test_parse_fragmented(self):
        """Parse a frame received in fragments."""
        body = b"fragmented body"
        frame = build_frame(128, body)

        parser = FrameParser()

        # Feed first half
        mid = len(frame) // 2
        parser.feed(frame[:mid])
        assert parser.try_parse() is None  # Not complete yet

        # Feed second half
        parser.feed(frame[mid:])
        result = parser.try_parse()
        assert result is not None
        assert result == (128, body)

    def test_parse_multiple_frames(self):
        """Parse multiple frames concatenated together."""
        bodies = [b"first", b"second", b"third"]
        frames = b''.join(build_frame(128 + i, body) for i, body in enumerate(bodies))

        parser = FrameParser()
        parser.feed(frames)
        results = parser.parse_all()

        assert len(results) == 3
        assert results[0] == (128, b"first")
        assert results[1] == (129, b"second")
        assert results[2] == (130, b"third")

    def test_empty_body(self):
        """Parse frame with empty body."""
        frame = build_frame(131, b"")
        parser = FrameParser()
        parser.feed(frame)
        result = parser.try_parse()
        assert result == (131, b"")
