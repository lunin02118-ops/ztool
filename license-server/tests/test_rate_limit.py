"""Rate-limit tests for Sprint E production hardening."""

import asyncio
import logging

import pytest

from swtools_license_server.config import ServerConfig
from swtools_license_server.crypto.keygen import generate_keypair, save_keypair
from swtools_license_server.protocol.dispatcher import Result
from swtools_license_server.protocol.framing import FrameParser, build_frame
from swtools_license_server.rate_limit import FixedWindowRateLimiter
from swtools_license_server.server import LicenseServer


class Clock:
    def __init__(self):
        self.value = 0.0

    def __call__(self):
        return self.value

    def advance(self, seconds: float):
        self.value += seconds


def test_fixed_window_rate_limiter_blocks_until_window_resets():
    clock = Clock()
    limiter = FixedWindowRateLimiter(
        max_requests=2,
        window_seconds=10,
        time_func=clock,
    )

    first = limiter.check("127.0.0.1")
    second = limiter.check("127.0.0.1")
    blocked = limiter.check("127.0.0.1")

    assert first.allowed
    assert first.remaining == 1
    assert second.allowed
    assert second.remaining == 0
    assert not blocked.allowed
    assert blocked.retry_after_seconds == 10

    clock.advance(10)
    reset = limiter.check("127.0.0.1")
    assert reset.allowed
    assert reset.remaining == 1


def test_fixed_window_rate_limiter_can_be_disabled():
    limiter = FixedWindowRateLimiter(enabled=False, max_requests=1, window_seconds=60)

    assert limiter.check("same-ip").allowed
    assert limiter.check("same-ip").allowed


def test_fixed_window_rate_limiter_rejects_invalid_limits():
    with pytest.raises(ValueError, match="max_requests"):
        FixedWindowRateLimiter(max_requests=0)
    with pytest.raises(ValueError, match="window_seconds"):
        FixedWindowRateLimiter(window_seconds=0)
    with pytest.raises(ValueError, match="max_keys"):
        FixedWindowRateLimiter(max_keys=0)


def test_fixed_window_rate_limiter_caps_tracked_keys():
    limiter = FixedWindowRateLimiter(max_requests=10, window_seconds=60, max_keys=1)

    assert limiter.check("first").allowed
    assert not limiter.check("second").allowed


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


@pytest.mark.asyncio
async def test_server_rate_limit_closes_connection_after_limit(tmp_path, caplog):
    aio_server, port = await _start_server(
        tmp_path,
        rate_limit_max_requests=1,
        rate_limit_window_seconds=60,
        max_frames_per_connection=10,
    )
    frame = build_frame(128, b"not-a-valid-aes-body")

    async with aio_server:
        caplog.set_level(logging.WARNING, logger="swtools_license_server.server")
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
    assert frames == [(Result.INFO_ERROR, b"")]
    assert "rate_limit event" in caplog.text
    assert "result=limited" in caplog.text
