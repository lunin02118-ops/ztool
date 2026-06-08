"""
DES encryption/decryption for the offline activation path.

The client's offline-activation reader (FrmRg.Decryptstr) decrypts the
activation file with a DESCryptoServiceProvider initialised from two byte-array
fields, `desKey` and `desSIV`, then reads the plaintext with a StreamReader
(default UTF-8). The server must therefore DES-CBC encrypt the activation
payload with these exact key/IV values and Base64-encode it.

The key/IV were extracted from the client binary (ZTool .ctor field
initialisers, element-wise byte arrays):

    desKey = 37 17 0D 31 48 39 34 08
    desSIV = 27 22 1C 21 4B 4D 52 02

The offline payload (after DES decryption) is the same string the online server
returns and that FrmRg.rg() consumes:  AES_今天( '\t'.join(4 registry blobs) ).
"""

import base64
from Crypto.Cipher import DES
from Crypto.Util.Padding import pad, unpad


# Extracted from the client binary (FrmRg desKey / desSIV fields).
DES_KEY = bytes.fromhex('37170d3148393408')
DES_IV = bytes.fromhex('27221c214b4d5202')


def encrypt_offline(plaintext: str, key: bytes = DES_KEY, iv: bytes = DES_IV) -> str:
    """
    Encrypt for offline activation file/code.

    Returns Base64-encoded ciphertext.
    Compatible with Program.EncryptDES.
    """
    cipher = DES.new(key, DES.MODE_CBC, iv)
    # FrmRg.Decryptstr reads the decrypted stream with a default StreamReader
    # (UTF-8), so the payload is UTF-8 encoded.
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
