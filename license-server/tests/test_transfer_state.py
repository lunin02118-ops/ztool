"""Stateful transfer tests."""

import pytest

from ztool_license_server.protocol.framing import FrameParser
from ztool_license_server.protocol.dispatcher import Result

from tests.test_integration import CODE, MACHINE_A, MACHINE_B, _make_server


def _decode_response(frame_bytes: bytes) -> tuple[int, str]:
    parser = FrameParser()
    parser.feed(frame_bytes)
    frame = parser.try_parse()
    assert frame is not None
    result, body = frame
    return result, body.decode("utf-8")


async def _remove_confirm_from_ip(server, client, branches: list, client_ip: str) -> tuple[int, str]:
    response = await server._handle_remove_confirm(
        client.rginfo_payload(branches=branches),
        client_ip=client_ip,
    )
    return _decode_response(response)


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

        code2, transfer_blob = await client.apply_remove(CODE, MACHINE_A)
        assert code2 == Result.TRANSFER_OUT_OK
        assert transfer_blob
        row = server.db._conn.execute("""
            SELECT transfer_branches_hash, transfer_blob_hash
            FROM pending_transfers
            WHERE code = ? AND machine_code = ? AND status = 'pending'
        """, (CODE, MACHINE_A)).fetchone()
        assert row["transfer_branches_hash"]
        assert row["transfer_blob_hash"]
        assert (await client.apply_register(CODE, MACHINE_B))[0] == Result.DEVICE_LIMIT

        assert (await client.remove_confirm())[0] == Result.TRANSFER_DONE
        code_b, blob_b = await client.apply_register(CODE, MACHINE_B)
        assert code_b == Result.APPLY_OK
        assert (await client.register_confirm(blob_b))[0] == Result.REGISTER_OK

    assert not server.db.is_machine_activated(CODE, MACHINE_A)
    assert server.db.is_machine_activated(CODE, MACHINE_B)


@pytest.mark.asyncio
async def test_transfer_confirm_rejects_cross_ip_even_with_valid_branches(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        assert (await client.register_confirm(blob))[0] == Result.REGISTER_OK

        code2, transfer_blob = await client.apply_remove(CODE, MACHINE_A)
        assert code2 == Result.TRANSFER_OUT_OK
        branches = client.transport_branches(transfer_blob)

        cross_ip_result, body = await _remove_confirm_from_ip(
            server,
            client,
            branches,
            client_ip="127.0.0.2",
        )
        assert cross_ip_result == Result.TRANSFER_FAILED
        assert body == ""
        assert server.db.is_machine_activated(CODE, MACHINE_A)

        same_ip_result, _ = await _remove_confirm_from_ip(
            server,
            client,
            branches,
            client_ip="127.0.0.1",
        )
        assert same_ip_result == Result.TRANSFER_DONE

    assert not server.db.is_machine_activated(CODE, MACHINE_A)


@pytest.mark.asyncio
async def test_same_ip_transfer_confirm_binds_by_branch_hash_not_latest_pending(tmp_path):
    server, aio_server, client = await _make_server(tmp_path, device_limit=2)
    async with aio_server:
        code_a, blob_a = await client.apply_register(CODE, MACHINE_A)
        assert code_a == Result.APPLY_OK
        assert (await client.register_confirm(blob_a))[0] == Result.REGISTER_OK

        code_b, blob_b = await client.apply_register(CODE, MACHINE_B)
        assert code_b == Result.APPLY_OK
        assert (await client.register_confirm(blob_b))[0] == Result.REGISTER_OK

        transfer_a_result, transfer_a_blob = await client.apply_remove(CODE, MACHINE_A)
        assert transfer_a_result == Result.TRANSFER_OUT_OK
        transfer_a_branches = client.transport_branches(transfer_a_blob)

        transfer_b_result, transfer_b_blob = await client.apply_remove(CODE, MACHINE_B)
        assert transfer_b_result == Result.TRANSFER_OUT_OK
        transfer_b_branches = client.transport_branches(transfer_b_blob)

        confirm_a, _ = await client.remove_confirm(branches=transfer_a_branches)
        assert confirm_a == Result.TRANSFER_DONE
        assert not server.db.is_machine_activated(CODE, MACHINE_A)
        assert server.db.is_machine_activated(CODE, MACHINE_B)

        confirm_b, _ = await client.remove_confirm(branches=transfer_b_branches)
        assert confirm_b == Result.TRANSFER_DONE

    assert not server.db.is_machine_activated(CODE, MACHINE_A)
    assert not server.db.is_machine_activated(CODE, MACHINE_B)


@pytest.mark.asyncio
async def test_transfer_confirm_rejects_modified_transfer_branches(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        assert (await client.register_confirm(blob))[0] == Result.REGISTER_OK

        code2, transfer_blob = await client.apply_remove(CODE, MACHINE_A)
        assert code2 == Result.TRANSFER_OUT_OK
        branches = client.transport_branches(transfer_blob)
        modified = list(branches)
        modified[0] = modified[0] + "x"

        modified_result, body = await client.remove_confirm(branches=modified)
        assert modified_result == Result.TRANSFER_FAILED
        assert body == ""
        assert server.db.is_machine_activated(CODE, MACHINE_A)

        valid_result, _ = await client.remove_confirm(branches=branches)
        assert valid_result == Result.TRANSFER_DONE

    assert not server.db.is_machine_activated(CODE, MACHINE_A)


@pytest.mark.asyncio
async def test_transfer_confirm_replay_is_rejected(tmp_path):
    server, aio_server, client = await _make_server(tmp_path)
    async with aio_server:
        code, blob = await client.apply_register(CODE, MACHINE_A)
        assert code == Result.APPLY_OK
        assert (await client.register_confirm(blob))[0] == Result.REGISTER_OK

        code2, transfer_blob = await client.apply_remove(CODE, MACHINE_A)
        assert code2 == Result.TRANSFER_OUT_OK
        branches = client.transport_branches(transfer_blob)

        first_result, _ = await client.remove_confirm(branches=branches)
        assert first_result == Result.TRANSFER_DONE
        second_result, body = await client.remove_confirm(branches=branches)
        assert second_result == Result.TRANSFER_FAILED
        assert body == ""

    assert not server.db.is_machine_activated(CODE, MACHINE_A)
