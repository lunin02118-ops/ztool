"""
AES encryption/decryption compatible with ZTool.SecurityCenter.

Algorithm:
- Aes.Create("AES")
- key = IV = MD5( Encoding.Unicode.GetBytes(passphrase) )  [16 bytes]
- BlockSize = 128, Mode = CBC, Padding = PKCS7
- Output: Base64 string

Known passphrases (used as AES keys for different fields/channels):
- "冰雨。。。" — machine code field / general
- "忘情水。。。" — another field
- "今天。。。" — version info
- "来生缘。。。" — yet another field

The key for TCP message bodies is ToString((int)sendtype), e.g. "128", "130", etc.
"""

import base64
import hashlib
from Crypto.Cipher import AES
from Crypto.Util.Padding import pad, unpad


# Known passphrases from the client
PASSPHRASE_BINGYU = "冰雨。。。"
PASSPHRASE_WANGQINGSHUI = "忘情水。。。"
PASSPHRASE_JINTIAN = "今天。。。"
PASSPHRASE_LAISHENGYUAN = "来生缘。。。"


def _derive_key(passphrase: str) -> bytes:
    """
    Derive AES key from passphrase, matching SecurityCenter logic:
    key = MD5( Encoding.Unicode.GetBytes(passphrase) )

    .NET Encoding.Unicode = UTF-16LE
    """
    passphrase_bytes = passphrase.encode('utf-16-le')
    return hashlib.md5(passphrase_bytes).digest()  # 16 bytes = 128 bit key


def encrypt(plaintext: str, passphrase: str) -> str:
    """
    Encrypt string using SecurityCenter-compatible AES.

    Returns Base64-encoded ciphertext.
    """
    key = _derive_key(passphrase)
    iv = key  # IV = key in SecurityCenter

    cipher = AES.new(key, AES.MODE_CBC, iv)
    # SecurityCenter.EncriptStr feeds Encoding.Unicode.GetBytes(text) to
    # TransformFinalBlock, i.e. the plaintext is UTF-16LE encoded (NOT UTF-8).
    plaintext_bytes = plaintext.encode('utf-16-le')
    padded = pad(plaintext_bytes, AES.block_size)
    ciphertext = cipher.encrypt(padded)
    return base64.b64encode(ciphertext).decode('ascii')


def decrypt(ciphertext_b64: str, passphrase: str) -> str:
    """
    Decrypt Base64-encoded ciphertext using SecurityCenter-compatible AES.

    Returns plaintext string.
    """
    key = _derive_key(passphrase)
    iv = key  # IV = key in SecurityCenter

    ciphertext = base64.b64decode(ciphertext_b64)
    cipher = AES.new(key, AES.MODE_CBC, iv)
    decrypted = unpad(cipher.decrypt(ciphertext), AES.block_size)
    # DecriptStr returns Encoding.Unicode.GetString(...) → UTF-16LE.
    return decrypted.decode('utf-16-le')


def encrypt_message_body(plaintext: str, sendtype: int) -> str:
    """
    Encrypt a TCP message body.
    Key is derived from the string representation of the sendtype code.
    e.g., sendtype=128 → passphrase="128"
    """
    return encrypt(plaintext, str(sendtype))


def decrypt_message_body(ciphertext_b64: str, sendtype: int) -> str:
    """
    Decrypt a TCP message body.
    Key is derived from the string representation of the sendtype code.
    """
    return decrypt(ciphertext_b64, str(sendtype))
