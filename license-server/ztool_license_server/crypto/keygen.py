"""
RSA-1024 key pair generation in ZTool ComponentKey format.

Generates a new key pair where:
- Public key: used to embed in the re-built client (ComponentKey format)
- Private key: stored on the server for signing licenses (ComponentKey format with d instead of e)
"""

import os
import json
from Crypto.PublicKey import RSA

from .rsa_ztool import make_component_key, resolve_key


def generate_keypair(bits: int = 1024, e: int = 65537) -> dict:
    """
    Generate an RSA key pair and return both keys in ComponentKey format.

    Returns:
        dict with:
            - public_component_key: str (Base64, for embedding in client)
            - private_component_key: str (Base64, for server signing)
            - n_hex: str (modulus in hex, for reference)
            - d_hex: str (private exponent in hex, for reference)
    """
    key = RSA.generate(bits, e=e)

    n = key.n
    e_val = key.e
    d = key.d

    public_component_key = make_component_key(e_val, n)
    # Private key in same format but with d instead of e
    private_component_key = make_component_key(d, n)

    return {
        "public_component_key": public_component_key,
        "private_component_key": private_component_key,
        "n_hex": format(n, 'X'),
        "d_hex": format(d, 'X'),
        "e": e_val,
        "bits": bits,
    }


def save_keypair(keypair: dict, directory: str) -> None:
    """Save key pair to files in specified directory."""
    os.makedirs(directory, exist_ok=True)

    # Public key (safe to distribute / embed in client)
    pub_path = os.path.join(directory, "public_key.txt")
    with open(pub_path, 'w') as f:
        f.write(keypair["public_component_key"])

    # Private key (KEEP SECRET - server only)
    priv_path = os.path.join(directory, "private_key.txt")
    with open(priv_path, 'w') as f:
        f.write(keypair["private_component_key"])

    # Full key info (for backup)
    info_path = os.path.join(directory, "keypair_info.json")
    with open(info_path, 'w') as f:
        json.dump(keypair, f, indent=2)

    print(f"Keys saved to: {directory}")
    print(f"  Public key (for client):  {pub_path}")
    print(f"  Private key (for server): {priv_path}")


def load_keypair(directory: str) -> dict:
    """Load key pair from directory."""
    info_path = os.path.join(directory, "keypair_info.json")
    with open(info_path, 'r') as f:
        return json.load(f)


def verify_keypair(keypair: dict) -> bool:
    """Verify that the key pair works (encrypt with public, decrypt with private)."""
    from .rsa_ztool import encrypt_string, decrypt_string

    test_msg = "Hello123"
    encrypted = encrypt_string(test_msg, keypair["public_component_key"], encoding='utf-8')
    decrypted = decrypt_string(encrypted, keypair["private_component_key"], encoding='utf-8')

    if decrypted == test_msg:
        print("Key pair verification: OK")
        return True
    else:
        print(f"Key pair verification: FAILED (got '{decrypted}' instead of '{test_msg}')")
        return False


if __name__ == "__main__":
    print("Generating RSA-1024 key pair for ZTool license server...")
    kp = generate_keypair()
    print(f"\nPublic ComponentKey:\n{kp['public_component_key']}\n")
    print(f"Private ComponentKey:\n{kp['private_component_key'][:60]}...\n")

    verify_keypair(kp)

    save_dir = os.path.join(os.path.dirname(__file__), '..', '..', 'keys')
    save_keypair(kp, save_dir)
