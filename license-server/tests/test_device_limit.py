"""Device-limit policy tests."""

from swtools_license_server.db import LicenseDB


def test_device_limit_two_allows_two_distinct_machines(tmp_path):
    db = LicenseDB(str(tmp_path / "limit2.db"))
    try:
        code = "LIMIT-TWO00-TESTS-CODE0-00001"
        db.add_license_code(code, device_limit=2)

        assert db.activate(code, "MACHINE_A")[0]
        assert db.activate(code, "MACHINE_B")[0]
        assert db.get_activation_count(code) == 2

        success, error = db.activate(code, "MACHINE_C")
        assert not success
        assert error == "授权电脑数量已达上限"
        assert db.get_activation_count(code) == 2
    finally:
        db.close()


def test_reactivation_same_machine_is_idempotent_with_limit_two(tmp_path):
    db = LicenseDB(str(tmp_path / "idempotent.db"))
    try:
        code = "LIMIT-TWO00-IDEMP-CODE0-00001"
        db.add_license_code(code, device_limit=2)

        assert db.activate(code, "MACHINE_A")[0]
        assert db.activate(code, "MACHINE_A")[0]
        assert db.get_activation_count(code) == 1
    finally:
        db.close()


def test_transfer_frees_only_specific_machine(tmp_path):
    db = LicenseDB(str(tmp_path / "transfer.db"))
    try:
        code = "LIMIT-TWO00-TRANS-CODE0-00001"
        db.add_license_code(code, device_limit=2)

        assert db.activate(code, "MACHINE_A")[0]
        assert db.activate(code, "MACHINE_B")[0]
        assert db.deactivate(code, "MACHINE_A")[0]

        assert not db.is_machine_activated(code, "MACHINE_A")
        assert db.is_machine_activated(code, "MACHINE_B")
        assert db.activate(code, "MACHINE_C")[0]
        assert db.get_activation_count(code) == 2
    finally:
        db.close()
