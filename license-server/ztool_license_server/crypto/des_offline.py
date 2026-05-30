"""
DES encryption/decryption for offline activation path.

Used by FrmRg.Decryptstr and Program.EncryptDES.
DESCryptoServiceProvider with specific key and IV.

Note: The exact desKey and desSIV values need to be confirmed
from the client binary (dynamic extraction recommended).
These are placeholder values that will be updated after stend testing.
"""

import base64
from Crypto.Cipher import DES
from Crypto.Util.Padding import pad, unpad


# Placeholder — to be extracted from client binary
# These should be 8 bytes each for DES
DES_KEY = b'\x00' * 8  # TODO: Extract from FrmRg
DES_IV = b'\x00' * 8   # TODO: Extract from FrmRg


def encrypt_offline(plaintext: str, key: bytes = DES_KEY, iv: bytes = DES_IV) -> str:
    """
    Encrypt for offline activation file/code.

    Returns Base64-encoded ciphertext.
    Compatible with Program.EncryptDES.
    """
    cipher = DES.new(key, DES.MODE_CBC, iv)
    plaintext_bytes = plaintext.encode('utf-8')
    padded = pad(plaintext_bytes, DES.block_size)
    ciphertext = cipher.encrypt(padded)
    return base64.b64encode(ciphertext).decode('ascii')


def decrypt_offline(ciphertext_b64: str, key: bytes = DES_KEY, iv: bytes = DES_IV) -> str:
    """
    Decrypt offline activation file/code.

    Compatible with FrmRg.Decryptstr.
    """
    ciphertext = base64.b64decode(ciphertext_b64)
    cipher = DES.new(key, DES.MODE_CBC, iv)
    decrypted = unpad(cipher.decrypt(ciphertext), DES.block_size)
    return decrypted.decode('utf-8')
