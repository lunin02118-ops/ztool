"""
Machine-code parsing (server side).

The client builds its hardware fingerprint in SR.GetMNum as:

    "<UUID>|<disk_serial>|<board_id>"      (trailing '|' trimmed)

optionally followed by a version suffix appended after "\\r\\n":

    "<UUID>|<disk>|<board>\\r\\n<version>"

and the whole string is truncated to its first 117 characters
(Mid(s, 1, 117)) before being RSA-encrypted and sent to the server.

This module parses the *decrypted* machine-code string the server receives
(after reversing the RSA layer) into structured fields and produces a stable
binding identifier used for device-limit bookkeeping.

Reference: LICENSING_migration_plan_ru.md, Phase 6 / Appendix A.
"""

import re
from dataclasses import dataclass
from typing import Optional


MAX_MACHINE_CODE_LEN = 117  # client uses Mid(s, 1, 117)
FIELD_SEPARATOR = "|"
VERSION_SEPARATOR = "\r\n"

# The client's SR.GetUUID validates the hardware UUID against
# ^[A-F0-9]{8}(-[A-F0-9]{4}){3}-[A-F0-9]{12}$ (a 36-char GUID) and IsReg1 later
# requires RSA_decrypt(b0[0]) to be exactly 36 chars. We accept the same shape
# (case-insensitive — WMI normally returns upper-case) so the server only ever
# binds/issues licenses for fingerprints the client can actually validate.
UUID_RE = re.compile(r"^[0-9A-Fa-f]{8}-([0-9A-Fa-f]{4}-){3}[0-9A-Fa-f]{12}$")


@dataclass
class MachineInfo:
    """Parsed hardware fingerprint."""

    uuid: str
    disk_serial: str
    board_id: str
    version: Optional[str] = None
    raw: str = ""

    @property
    def binding_id(self) -> str:
        """Stable identifier used to bind a license to a device.

        Excludes the version suffix so that a client version bump does not
        invalidate an existing activation.
        """
        return f"{self.uuid}{FIELD_SEPARATOR}{self.disk_serial}{FIELD_SEPARATOR}{self.board_id}"


def parse_machine_code(machine_code: str) -> MachineInfo:
    """Parse a decrypted machine-code string into a MachineInfo.

    Tolerates missing trailing fields (some hosts fail to report a disk or
    board id, leaving an empty component). Raises ValueError on empty input.
    """
    if machine_code is None:
        raise ValueError("machine_code is None")

    raw = machine_code
    # The client truncates to the first 117 chars; mirror that defensively.
    text = machine_code[:MAX_MACHINE_CODE_LEN]

    version: Optional[str] = None
    if VERSION_SEPARATOR in text:
        text, version = text.split(VERSION_SEPARATOR, 1)
        version = version.strip() or None

    # Trailing separators are trimmed by the client before sending.
    text = text.rstrip(FIELD_SEPARATOR)

    if not text:
        raise ValueError("empty machine code")

    parts = text.split(FIELD_SEPARATOR)
    uuid = parts[0] if len(parts) > 0 else ""
    disk_serial = parts[1] if len(parts) > 1 else ""
    board_id = parts[2] if len(parts) > 2 else ""

    return MachineInfo(
        uuid=uuid,
        disk_serial=disk_serial,
        board_id=board_id,
        version=version,
        raw=raw,
    )


def binding_id(machine_code: str) -> str:
    """Convenience helper returning the version-independent binding id."""
    return parse_machine_code(machine_code).binding_id


def is_valid_machine_code(machine_code: Optional[str]) -> bool:
    """Return True only for a genuine hardware fingerprint.

    A real SWTools client always sends ``<36-char GUID>|<disk>|<board>`` (the disk
    and board fields may be empty on some hosts, but the leading UUID is always a
    valid GUID — SR.GetUUID enforces it and IsReg1 requires its length to be 36).
    An empty, malformed, or non-GUID fingerprint (e.g. ``""`` or ``"x"``) must be
    rejected so it can neither consume a license seat nor receive a blob that the
    client would refuse anyway.
    """
    if not machine_code or not machine_code.strip():
        return False
    try:
        info = parse_machine_code(machine_code)
    except ValueError:
        return False
    return bool(UUID_RE.match(info.uuid.strip()))
