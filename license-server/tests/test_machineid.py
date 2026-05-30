"""Tests for server-side machine-code parsing."""

import pytest

from ztool_license_server.machineid import (
    parse_machine_code,
    binding_id,
    is_valid_machine_code,
    MAX_MACHINE_CODE_LEN,
)


GUID = "12345678-90AB-CDEF-1234-567890ABCDEF"


def test_parse_full():
    info = parse_machine_code("UUID-1234|DISK-5678|BOARD-9012")
    assert info.uuid == "UUID-1234"
    assert info.disk_serial == "DISK-5678"
    assert info.board_id == "BOARD-9012"
    assert info.version is None
    assert info.binding_id == "UUID-1234|DISK-5678|BOARD-9012"


def test_parse_with_version_suffix():
    info = parse_machine_code("UUID|DISK|BOARD\r\n2.5.1")
    assert info.version == "2.5.1"
    # version must not change the binding id
    assert info.binding_id == "UUID|DISK|BOARD"
    assert binding_id("UUID|DISK|BOARD\r\n9.9.9") == info.binding_id


def test_trailing_separator_trimmed():
    info = parse_machine_code("UUID|DISK|")
    assert info.uuid == "UUID"
    assert info.disk_serial == "DISK"
    assert info.board_id == ""
    assert info.binding_id == "UUID|DISK|"


def test_missing_fields():
    info = parse_machine_code("ONLY-UUID")
    assert info.uuid == "ONLY-UUID"
    assert info.disk_serial == ""
    assert info.board_id == ""


def test_truncated_to_117_chars():
    long_code = "U" * 200 + "|DISK|BOARD"
    info = parse_machine_code(long_code)
    assert len(info.raw) == len(long_code)
    # parsing operates on the first 117 chars only
    assert len(info.uuid) <= MAX_MACHINE_CODE_LEN


def test_empty_raises():
    with pytest.raises(ValueError):
        parse_machine_code("")
    with pytest.raises(ValueError):
        parse_machine_code("|||")
    with pytest.raises(ValueError):
        parse_machine_code(None)


def test_is_valid_machine_code_accepts_real_fingerprints():
    # Full GUID|disk|board, and GUID-only / missing trailing fields, are valid.
    assert is_valid_machine_code(f"{GUID}|WD-DISK01|BOARD-XYZ")
    assert is_valid_machine_code(GUID)
    assert is_valid_machine_code(f"{GUID}||")
    # Version suffix must not affect validity.
    assert is_valid_machine_code(f"{GUID}|D|B\r\n5.0.0.0")
    # GUID is matched case-insensitively (WMI usually returns upper-case).
    assert is_valid_machine_code(GUID.lower())


@pytest.mark.parametrize("bad", [
    "", "   ", None,
    "x",                       # junk
    "|||",                     # only separators
    "DISK-ONLY|BOARD",         # first field is not a GUID
    "12345678-90AB-CDEF-1234", # GUID too short
    "ZZZZZZZZ-90AB-CDEF-1234-567890ABCDEF",  # non-hex
])
def test_is_valid_machine_code_rejects_junk(bad):
    assert not is_valid_machine_code(bad)
