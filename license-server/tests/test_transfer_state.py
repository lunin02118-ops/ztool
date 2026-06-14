"""Stateful transfer tests."""

import pytest

from ztool_license_server.protocol.dispatcher import Result

from tests.test_integration import CODE, MACHINE_A, MACHINE_B, _make_server


@pytest.mark.asyncio
async def test_remove_confirm_without_apply_remove_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, body = await client.remove_confirm()

    assert code == Result.TRANSFER_FAILED
    assert body == ""


@pytest.mark.asyncio
async def test_apply_remove_without_active_activation_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, body = await client.apply_remove(CODE, MACHINE_A)

    assert code == Result.REGISTER_FAILED
    assert body == ""


@pytest.mark.asyncio
async def test_remove_confirm_after_ttl_rejected_and_seat_stays_active(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    server.config.pending_transfer_ttl_seconds = -1
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        assert (await client.register_confirm(blob))[0] == Result.REGISTER_OK

        code2, transfer_blob = await client.apply_remove(CODE, MACHINE_A)
        assert code2 == Result.TRANSFER_OUT_OK
        assert transfer_blob
        code3, body = await client.remove_confirm()

    assert code3 == Result.TRANSFER_FAILED
    assert body == ""
    assert server.db.is_machine_activated(CODE, MACHINE_A)


@pytest.mark.asyncio
async def test_transfer_frees_seat_only_after_remove_confirm(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        assert (await client.register_confirm(blob))[0] == Result.REGISTER_OK

        assert (await client.apply_remove(CODE, MACHINE_A))[0] == Result.TRANSFER_OUT_OK
        assert (await client.apply_register(CODE, MACHINE_B))[0] == Result.DEVICE_LIMIT

        assert (await client.remove_confirm())[0] == Result.TRANSFER_DONE
        code_b, blob_b = await client.apply_register(CODE, MACHINE_B)
        assert code_b == Result.APPLY_OK
        assert (await client.register_confirm(blob_b))[0] == Result.REGISTER_OK

    assert not server.db.is_machine_activated(CODE, MACHINE_A)
    assert server.db.is_machine_activated(CODE, MACHINE_B)
