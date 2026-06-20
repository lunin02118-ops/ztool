"""Stateful activation tests."""

import pytest

from swtools_license_server.crypto import aes_security_center as aes
from swtools_license_server.license_blob import generate_license_blob, getver_today
from swtools_license_server.protocol.dispatcher import Result, Sendtype

from tests.test_integration import CODE, MACHINE_A, MACHINE_B, _make_server


@pytest.mark.asyncio
async def test_register_confirm_without_pending_apply_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    blob = generate_license_blob(
        machine_code=MACHINE_A,
        public_key=client.public_key,
        private_key=server._private_key,
        client_version=server.config.client_version,
    )
    async with aio_server:
        code, body = await client.register_confirm(blob)

    assert code == Result.INFO_ERROR
    assert body == ""
    assert server.db.get_activation_count(CODE) == 0


@pytest.mark.asyncio
async def test_register_confirm_with_modified_branches_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        branches = aes.decrypt(
            blob,
            getver_today(server.config.client_version, is_64bit=True),
        ).split("\t")
        branches[0] = branches[0] + "tamper"
        ts = client._rsa("1.0")
        code2, body = await client._send(Sendtype.REGISTER_CONFIRM, branches + [ts, ts, ts])

    assert code2 == Result.INFO_ERROR
    assert body == ""
    assert server.db.get_activation_count(CODE) == 0


@pytest.mark.asyncio
async def test_register_confirm_after_ttl_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    server.config.pending_activation_ttl_seconds = -1
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        code2, body = await client.register_confirm(blob)

    assert code2 == Result.INFO_ERROR
    assert body == ""
    assert server.db.get_activation_count(CODE) == 0


@pytest.mark.asyncio
async def test_duplicate_register_confirm_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        assert (await client.register_confirm(blob))[0] == Result.REGISTER_OK
        code2, body = await client.register_confirm(blob)

    assert code2 == Result.INFO_ERROR
    assert body == ""
    assert server.db.get_activation_count(CODE) == 1


@pytest.mark.asyncio
async def test_expired_pending_does_not_block_new_machine(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    server.config.pending_activation_ttl_seconds = -1
    async with aio_server:
        assert (await client.apply_register(CODE, MACHINE_A))[0] == Result.APPLY_OK
        # The expired pending seat is lazily cleaned before this apply.
        code_b, blob_b = await client.apply_register(CODE, MACHINE_B)
        assert code_b == Result.APPLY_OK
        # Restore TTL before confirming the second machine's fresh blob.
        server.config.pending_activation_ttl_seconds = 600
        # blob_b was already created with expired TTL, so request a new one.
        code_b2, blob_b2 = await client.apply_register(CODE, MACHINE_B)
        assert code_b2 == Result.APPLY_OK
        assert (await client.register_confirm(blob_b2))[0] == Result.REGISTER_OK

    assert server.db.get_activation_count(CODE) == 1
    assert server.db.is_machine_activated(CODE, MACHINE_B)
