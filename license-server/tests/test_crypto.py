"""Tests for cryptographic modules."""

import pytest
from ztool_license_server.crypto.rsa_ztool import (
    resolve_key, make_component_key, encrypt_string, decrypt_string,
    ORIGINAL_PUBLIC_KEY,
)
from ztool_license_server.crypto.keygen import generate_keypair, verify_keypair
from ztool_license_server.crypto.aes_security_center import (
    encrypt, decrypt, encrypt_message_body, decrypt_message_body,
    PASSPHRASE_BINGYU,
)


class TestRSAComponentKey:
    """Test RSA key format parsing and generation."""

    @pytest.mark.skip(reason="Original key string is truncated in audit doc (reference only)")
    def test_resolve_original_key(self):
        """Parse the original embedded public key."""
        e, n = resolve_key(ORIGINAL_PUBLIC_KEY)
        assert e == 65537
        assert n.bit_length() == 1024

    def test_roundtrip_component_key(self):
        """Generate a key pair and verify ComponentKey roundtrip."""
        kp = generate_keypair()
        pub_key = kp["public_component_key"]

        e, n = resolve_key(pub_key)
        assert e == 65537
        assert n.bit_length() == 1024

        # Reconstruct and verify
        reconstructed = make_component_key(e, n)
        assert reconstructed == pub_key

    def test_encrypt_decrypt_roundtrip(self):
        """Encrypt with public key, decrypt with private key."""
        kp = generate_keypair()

        test_messages = ["Hello", "Test123", "A" * 50, "Short"]
        for msg in test_messages:
            encrypted = encrypt_string(msg, kp["public_component_key"], encoding='utf-8')
            assert '@' in encrypted or len(encrypted) > 0
            decrypted = decrypt_string(encrypted, kp["private_component_key"], encoding='utf-8')
            assert decrypted == msg, f"Failed for message: {msg}"

    def test_sign_verify_roundtrip(self):
        """Sign with private key (server), verify with public key (client)."""
        kp = generate_keypair()

        msg = "machine_code_test|2024/01/01 12:00:00|info"
        # Server signs with private key
        signed = encrypt_string(msg, kp["private_component_key"], encoding='utf-8')
        # Client verifies with public key
        verified = decrypt_string(signed, kp["public_component_key"], encoding='utf-8')
        assert verified == msg

    def test_block_boundary(self):
        """Test messages at block boundaries (128 bytes)."""
        kp = generate_keypair()

        # Exactly 128 bytes (1 block)
        msg_128 = "A" * 128
        encrypted = encrypt_string(msg_128, kp["public_component_key"], encoding='utf-8')
        decrypted = decrypt_string(encrypted, kp["private_component_key"], encoding='utf-8')
        assert decrypted == msg_128

        # 129 bytes (2 blocks)
        msg_129 = "B" * 129
        encrypted = encrypt_string(msg_129, kp["public_component_key"], encoding='utf-8')
        assert '@' in encrypted  # Should have 2 blocks
        decrypted = decrypt_string(encrypted, kp["private_component_key"], encoding='utf-8')
        assert decrypted == msg_129


class TestAESSecurityCenter:
    """Test AES encryption compatible with SecurityCenter."""

    def test_encrypt_decrypt_roundtrip(self):
        """Basic encrypt/decrypt roundtrip."""
        messages = [
            "Hello World",
            "测试数据",
            "Registration successful",
            "A" * 200,
        ]
        for msg in messages:
            encrypted = encrypt(msg, PASSPHRASE_BINGYU)
            decrypted = decrypt(encrypted, PASSPHRASE_BINGYU)
            assert decrypted == msg, f"Failed for: {msg}"

    def test_different_passphrases(self):
        """Different passphrases produce different ciphertexts."""
        msg = "test message"
        c1 = encrypt(msg, PASSPHRASE_BINGYU)
        c2 = encrypt(msg, "128")
        assert c1 != c2

    def test_message_body_encrypt(self):
        """Test TCP message body encryption with sendtype as key."""
        msg = "注册成功"
        for sendtype in [128, 129, 130, 131, 132]:
            encrypted = encrypt_message_body(msg, sendtype)
            decrypted = decrypt_message_body(encrypted, sendtype)
            assert decrypted == msg


class TestKeyGeneration:
    """Test key pair generation."""

    def test_generate_and_verify(self):
        """Generate a key pair and verify it works."""
        kp = generate_keypair()
        assert "public_component_key" in kp
        assert "private_component_key" in kp
        assert kp["e"] == 65537
        assert kp["bits"] == 1024
        assert verify_keypair(kp)

    def test_keys_are_different(self):
        """Two generated key pairs should be different."""
        kp1 = generate_keypair()
        kp2 = generate_keypair()
        assert kp1["public_component_key"] != kp2["public_component_key"]
