"""Tests for database operations."""

import os
import tempfile
import pytest
from ztool_license_server.db import LicenseDB


@pytest.fixture
def db():
    """Create a temporary database for testing."""
    fd, path = tempfile.mkstemp(suffix='.db')
    os.close(fd)
    database = LicenseDB(path)
    yield database
    database.close()
    os.unlink(path)


class TestLicenseDB:
    """Test license database operations."""

    def test_add_and_validate_code(self, db):
        """Add a code and validate it."""
        db.add_license_code("TEST1-TEST2-TEST3-TEST4-TEST5", device_limit=2)
        is_valid, error = db.validate_code("TEST1-TEST2-TEST3-TEST4-TEST5")
        assert is_valid
        assert error == ""

    def test_invalid_code(self, db):
        """Validate a non-existent code."""
        is_valid, error = db.validate_code("NONEXISTENT")
        assert not is_valid
        assert error == "无效注册码"

    def test_activate_and_check(self, db):
        """One code binds to exactly ONE machine; a different machine is
        rejected until the license is transferred off the first."""
        code = "ACTIV-ATION-TESTT-CODEE-12345"
        db.add_license_code(code)

        # First machine activates.
        success, error = db.activate(code, "MACHINE_CODE_1")
        assert success
        assert db.is_machine_activated(code, "MACHINE_CODE_1")

        # Same machine again is idempotent (still success, no extra seat).
        success, error = db.activate(code, "MACHINE_CODE_1")
        assert success
        assert db.get_activation_count(code) == 1

        # A different machine is rejected — only one machine per code.
        success, error = db.activate(code, "MACHINE_CODE_2")
        assert not success
        assert "上限" in error  # Device limit reached (1 per code)
        assert db.get_activation_count(code) == 1

        # After transferring the license off machine 1, machine 2 may bind.
        db.deactivate(code, "MACHINE_CODE_1")
        success, error = db.activate(code, "MACHINE_CODE_2")
        assert success
        assert db.get_activation_count(code) == 1

    def test_activate_rejects_empty_machine_code(self, db):
        """Defense-in-depth: the DB must never bind a seat to a blank
        fingerprint (would defeat hardware-locking)."""
        code = "EMPTY-MACHN-TESTS-CODE0-00001"
        db.add_license_code(code, device_limit=2)

        for bad in ("", "   ", None):
            success, error = db.activate(code, bad)
            assert not success
            assert error == "注册信息错误"
        # No seat consumed by the rejected attempts.
        assert db.get_activation_count(code) == 0

    def test_duplicate_activation(self, db):
        """Activating same machine twice should succeed (idempotent)."""
        code = "DUPLI-CATE0-TESTS-CODE0-00001"
        db.add_license_code(code, device_limit=1)

        success, _ = db.activate(code, "MACHINE_1")
        assert success

        # Same machine again — should succeed (already activated)
        success, _ = db.activate(code, "MACHINE_1")
        assert success

    def test_deactivate(self, db):
        """Deactivate (transfer) a license."""
        code = "TRANS-FER00-TESTS-CODE0-00001"
        db.add_license_code(code, device_limit=2)

        db.activate(code, "MACHINE_A")
        assert db.is_machine_activated(code, "MACHINE_A")

        success, _ = db.deactivate(code, "MACHINE_A")
        assert success
        assert not db.is_machine_activated(code, "MACHINE_A")

    def test_deactivate_not_active(self, db):
        """Deactivate a non-active license should fail."""
        code = "NOACT-IVATE-TESTS-CODE0-00001"
        db.add_license_code(code)

        success, error = db.deactivate(code, "MACHINE_X")
        assert not success
        assert "无需转出" in error

    def test_password_check(self, db):
        """Test password validation."""
        code = "PASSW-ORD00-TESTS-CODE0-00001"
        db.add_license_code(code, password="MySecret123")

        assert db.check_password(code, "MySecret123")
        assert not db.check_password(code, "WrongPassword")

    def test_no_password_always_passes(self, db):
        """Code without password should accept any password check."""
        code = "NOPAS-SWORD-TESTS-CODE0-00001"
        db.add_license_code(code, password="")

        assert db.check_password(code, "")
        assert db.check_password(code, "anything")

    def test_purge_invalid_activations(self, db):
        """Legacy bad rows (empty/non-GUID machine_code) must be purgeable so a
        polluted production DB can be cleaned, while valid rows are untouched."""
        code = "PURGE-INVAL-TESTS-CODE0-00001"
        db.add_license_code(code, device_limit=5)
        good = "12345678-90AB-CDEF-1234-567890ABCDEF|DISK|BOARD"
        db.activate(code, good)
        # Insert legacy bad rows directly (pre-validation could create these).
        db._conn.execute(
            "INSERT INTO activations (code, machine_code, is_active) VALUES (?, '', 1)",
            (code,))
        db._conn.execute(
            "INSERT INTO activations (code, machine_code, is_active) VALUES (?, 'x', 1)",
            (code,))
        db._conn.commit()
        assert db.get_activation_count(code) == 3

        purged = db.purge_invalid_activations()
        assert purged == 2
        # Only the genuine fingerprint remains active.
        assert db.get_activation_count(code) == 1
        assert db.is_machine_activated(code, good)

    def test_audit_log(self, db):
        """Test audit logging."""
        db.log_action("test_action", code="CODE1", machine_code="MC1",
                      result="success", details="Test details")

        rows = db._conn.execute("SELECT * FROM audit_log").fetchall()
        assert len(rows) == 1
        assert rows[0]['action'] == "test_action"
        assert rows[0]['result'] == "success"
