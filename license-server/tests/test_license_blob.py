"""Tests for license blob generation."""

import pytest
from ztool_license_server.crypto.keygen import generate_keypair
from ztool_license_server.crypto.rsa_ztool import decrypt_string
from ztool_license_server.crypto.aes_security_center import decrypt, PASSPHRASE_BINGYU
from ztool_license_server.license_blob import (
    generate_license_blob, generate_all_registry_blobs, REGISTRY_PATHS,
)


@pytest.fixture
def keypair():
    """Generate a fresh key pair for testing."""
    return generate_keypair()


class TestLicenseBlob:
    """Test license blob generation and validation."""

    def test_generate_blob(self, keypair):
        """Generate a blob and verify it can be decrypted/verified."""
        machine_code = "UUID123|DISK456|BOARD789"
        blob = generate_license_blob(
            machine_code=machine_code,
            private_key=keypair["private_component_key"],
            reg_info="code:TEST-CODE",
            reg_time="2024/06/15 10:30:00",
        )

        # Blob should be non-empty Base64
        assert len(blob) > 0

        # Simulate client-side verification:
        # 1. Decrypt AES layer
        signed = decrypt(blob, PASSPHRASE_BINGYU)

        # 2. Verify RSA signature (decrypt with public key)
        inner = decrypt_string(signed, keypair["public_component_key"], encoding='utf-8')

        # 3. Parse fields
        parts = inner.split('\n')
        assert len(parts) >= 3
        assert parts[0] == machine_code
        assert parts[1] == "2024/06/15 10:30:00"
        assert parts[2] == "code:TEST-CODE"

    def test_generate_all_registry_blobs(self, keypair):
        """Generate blobs for all 4 registry branches."""
        machine_code = "TEST-MACHINE-CODE"
        blobs = generate_all_registry_blobs(
            machine_code=machine_code,
            private_key=keypair["private_component_key"],
            reg_info="test_reg",
        )

        assert len(blobs) == 4
        for path_key, blob_info in blobs.items():
            assert "registry_key" in blob_info
            assert "value_name" in blob_info
            assert "data" in blob_info
            assert len(blob_info["data"]) > 0

    def test_blob_cross_consistency(self, keypair):
        """All 4 blobs should decrypt to the same content."""
        machine_code = "CROSS-CHECK-MC"
        blobs = generate_all_registry_blobs(
            machine_code=machine_code,
            private_key=keypair["private_component_key"],
        )

        contents = set()
        for blob_info in blobs.values():
            signed = decrypt(blob_info["data"], PASSPHRASE_BINGYU)
            inner = decrypt_string(signed, keypair["public_component_key"], encoding='utf-8')
            contents.add(inner)

        # All branches should have consistent content
        assert len(contents) == 1
