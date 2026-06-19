"""Server-side protocol limit tests for Phase 02."""

import asyncio

import pytest

from swtools_license_server.config import ServerConfig
from swtools_license_server.crypto.keygen import generate_keypair, save_keypair
from swtools_license_server.protocol.dispatcher import Result
from swtools_license_server.protocol.framing import (
    HEADER_FIELD_SIZE,
    FrameParser,
    build_frame,
    encode_int_field,
)
from swtools_license_server.server import LicenseServer


async def _start_server(tmp_path, **config_overrides):
    kp = generate_keypair()
    keys_dir = tmp_path / "keys"
    save_keypair(kp, str(keys_dir))
    config = ServerConfig(
        host="127.0.0.1",
        port=0,
        keys_dir=str(keys_dir),
        db_path=str(tmp_path / "licenses.db"),
        **config_overrides,
    )
    server = LicenseServer(config)
    aio_server = await asyncio.start_server(server._handle_client, "127.0.0.1", 0)
    port = aio_server.sockets[0].getsockname()[1]
    return aio_server, port


async def _send_and_read(port, payload: bytes, read_timeout=1.0) -> bytes:
    reader, writer = await asyncio.open_connection("127.0.0.1", port)
    try:
        writer.write(payload)
        await writer.drain()
        try:
            return await asyncio.wait_for(reader.read(4096), timeout=read_timeout)
        except asyncio.TimeoutError:
            return b""
    finally:
        writer.close()
        await writer.wait_closed()


@pytest.mark.asyncio
async def test_invalid_utf8_body_returns_info_error(tmp_path):
    aio_server, port = await _start_server(tmp_path)
    async with aio_server:
        data = await _send_and_read(port, build_frame(128, b"\xff\xfe\xfa"))

    parser = FrameParser()
    parser.feed(data)
    result, body = parser.try_parse()
    assert result == Result.INFO_ERROR
    assert body == b""


@pytest.mark.asyncio
async def test_unknown_sendtype_closes_connection_safely(tmp_path):
    aio_server, port = await _start_server(tmp_path)
    async with aio_server:
        data = await _send_and_read(port, build_frame(999, b"ignored"))

    assert data == b""


@pytest.mark.asyncio
async def test_negative_length_closes_connection_safely(tmp_path):
    frame = encode_int_field(128) + encode_int_field(-1)
    aio_server, port = await _start_server(tmp_path)
    async with aio_server:
        data = await _send_and_read(port, frame)

    assert data == b""


@pytest.mark.asyncio
async def test_oversized_body_length_closes_connection_safely(tmp_path):
    frame = encode_int_field(128) + encode_int_field(8)
    aio_server, port = await _start_server(tmp_path, max_body_size=4)
    async with aio_server:
        data = await _send_and_read(port, frame)

    assert data == b""


@pytest.mark.asyncio
async def test_partial_frame_read_timeout_closes_connection(tmp_path):
    aio_server, port = await _start_server(
        tmp_path,
        read_timeout_seconds=0.05,
        idle_timeout_seconds=1.0,
    )
    async with aio_server:
        reader, writer = await asyncio.open_connection("127.0.0.1", port)
        try:
            writer.write(encode_int_field(128)[:HEADER_FIELD_SIZE])
            await writer.drain()
            data = await asyncio.wait_for(reader.read(1), timeout=1.0)
        finally:
            writer.close()
            await writer.wait_closed()

    assert data == b""


@pytest.mark.asyncio
async def test_max_frames_per_connection_closes_after_limit(tmp_path):
    aio_server, port = await _start_server(tmp_path, max_frames_per_connection=1)
    frame = build_frame(128, b"not-a-valid-aes-body")
    async with aio_server:
        reader, writer = await asyncio.open_connection("127.0.0.1", port)
        try:
            writer.write(frame + frame)
            await writer.drain()
            data = await asyncio.wait_for(reader.read(4096), timeout=1.0)
        finally:
            writer.close()
            await writer.wait_closed()

    parser = FrameParser()
    parser.feed(data)
    frames = parser.parse_all()
    assert len(frames) == 1
    assert frames[0] == (Result.INFO_ERROR, b"")
