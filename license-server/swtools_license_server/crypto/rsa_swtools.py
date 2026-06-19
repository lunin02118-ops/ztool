"""
RSA-1024 implementation compatible with ZTool_rsa.dll (ZTool_rsa.RSAHelper / BigInteger).

Key features matching the client:
- No padding (textbook RSA)
- Block size: 128 characters of plaintext per block
- Blocks encoded as hex strings, joined by '@'
- ComponentKey format: Base64( [len(exp)] || exp || modulus )
- e = 65537 (0x010001)
- modulus: 128 bytes (1024 bits)
"""

import base64
import struct
from typing import Tuple


def resolve_key(component_key: str) -> Tuple[int, int]:
    """
    Parse a ComponentKey string into (exponent, modulus) integers.

    Format: Base64( [1 byte: len(exp)] || [exp bytes] || [modulus bytes] )
    """
    raw = base64.b64decode(component_key)
    exp_len = raw[0]
    exp_bytes = raw[1:1 + exp_len]
    mod_bytes = raw[1 + exp_len:]

    exponent = int.from_bytes(exp_bytes, byteorder='big')
    modulus = int.from_bytes(mod_bytes, byteorder='big')
    return exponent, modulus


def make_component_key(exponent: int, modulus: int) -> str:
    """
    Serialize (exponent, modulus) into ComponentKey format.

    Format: Base64( [1 byte: len(exp)] || [exp bytes big-endian] || [modulus bytes big-endian] )
    """
    exp_bytes = exponent.to_bytes((exponent.bit_length() + 7) // 8, byteorder='big')
    mod_bytes = modulus.to_bytes(128, byteorder='big')  # 1024 bits = 128 bytes

    raw = bytes([len(exp_bytes)]) + exp_bytes + mod_bytes
    return base64.b64encode(raw).decode('ascii')


def encrypt_string(plaintext: str, component_key: str, encoding: str = 'cp936') -> str:
    """
    RSA encrypt a string, compatible with RSAHelper.EncryptString.

    Process:
    1. Encode plaintext to bytes using specified encoding (default: cp936/GBK for Chinese)
    2. Split into blocks of 128 characters (encoded with Encoding.Default)
    3. For each block: convert to big integer, compute m^e mod n
    4. Convert result to uppercase hex string
    5. Join blocks with '@'
    """
    exponent, modulus = resolve_key(component_key)

    blocks = []
    # RSAHelper.EncryptString splits the *string* into 128-CHARACTER blocks
    # (Substring(i*128, 128)) and encodes each block with Encoding.Default
    # (cp936). It is NOT a 128-byte split.
    block_size = 128
    for i in range(0, len(plaintext), block_size):
        chunk = plaintext[i:i + block_size]
        block = chunk.encode(encoding)
        m = int.from_bytes(block, byteorder='big')
        c = pow(m, exponent, modulus)
        hex_str = format(c, 'X')
        blocks.append(hex_str)

    return '@'.join(blocks)


def decrypt_string(ciphertext: str, component_key: str, encoding: str = 'cp936') -> str:
    """
    RSA decrypt a string, compatible with RSAHelper.DecryptString.

    This is used for verifying signatures (decrypt with public key = verify).
    Also used server-side with private key to sign (encrypt with private key = sign).

    Process:
    1. Split by '@' into hex blocks
    2. For each block: parse hex to int, compute c^d mod n (or c^e mod n for verify)
    3. Convert result to bytes (big-endian)
    4. Decode bytes using specified encoding
    """
    exponent, modulus = resolve_key(component_key)

    blocks = ciphertext.split('@')
    result = []

    # RSAHelper.DecryptString decodes each block separately with
    # Encoding.Default and appends the resulting string, so we mirror that
    # (BigInteger.getBytes() emits big-endian minimal bytes).
    for hex_block in blocks:
        if not hex_block:
            continue
        c = int(hex_block, 16)
        m = pow(c, exponent, modulus)
        byte_len = (m.bit_length() + 7) // 8
        if byte_len == 0:
            byte_len = 1
        m_bytes = m.to_bytes(byte_len, byteorder='big')
        result.append(m_bytes.decode(encoding))

    return ''.join(result)


def sign_string(plaintext: str, private_component_key: str, encoding: str = 'cp936') -> str:
    """
    Sign a string using private key (same as encrypt_string but with private key).

    The client verifies by calling DecryptString with public key.
    Server signs by calling EncryptString with private key (d instead of e).
    """
    return encrypt_string(plaintext, private_component_key, encoding)


# Original embedded public key from SWTools (for reference)
ORIGINAL_PUBLIC_KEY = (
    "AwEAAZ5qj1uplH7vvTuWxvXhT/eJcVyJYSl0KehsVQDCTG6IPI+Sb4kOyay4Gq4opHz4NflA6Lvo"
    "mma3wV9WcgzsINJg6hCHuaJ6yONm/zDfZwVPxWWVWJJOxcQcfWkcawp65kGOy31cCH1mL6VDHDgc"
    "W5QzwtlgvyYRLU6C7xHWyshir"
)
