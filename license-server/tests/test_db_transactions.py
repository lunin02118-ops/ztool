"""Transaction behavior tests."""

import pytest

from swtools_license_server.db import LicenseDB


def test_transaction_rolls_back_code_and_audit(tmp_path):
    db = LicenseDB(str(tmp_path / "rollback.db"))
    code = "ROLLB-ACK00-TESTS-CODE0-00001"
    try:
        with pytest.raises(RuntimeError):
            with db.transaction():
                db.add_license_code(code)
                db.log_action("test", code=code, result="before failure")
                raise RuntimeError("boom")

        is_valid, error = db.validate_code(code)
        assert not is_valid
        assert error == "无效注册码"
        rows = db._conn.execute("SELECT * FROM audit_log WHERE code = ?", (code,)).fetchall()
        assert rows == []
    finally:
        db.close()


def test_nested_transaction_commits_once(tmp_path):
    db = LicenseDB(str(tmp_path / "nested.db"))
    code = "NESTE-D0000-TESTS-CODE0-00001"
    try:
        with db.transaction():
            db.add_license_code(code)
            with db.transaction():
                db.log_action("nested", code=code, result="ok")

        assert db.validate_code(code)[0]
        rows = db._conn.execute("SELECT * FROM audit_log WHERE code = ?", (code,)).fetchall()
        assert len(rows) == 1
    finally:
        db.close()
