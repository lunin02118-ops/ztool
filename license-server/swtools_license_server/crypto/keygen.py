"""
RSA-1024 key pair generation in SWTools ComponentKey format.

Generates a new key pair where:
- Public key: used to embed in the re-built client (ComponentKey format)
- Private key: stored on the server for signing licenses (ComponentKey format with d instead of e)
"""

import json
import os
from Crypto.PublicKey import RSA

from .rsa_swtools import make_component_key, resolve_key


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


def _chmod_private_key(path: str) -> None:
    """Restrict private key file permissions where chmod semantics are useful."""
    if os.name != "nt":
        os.chmod(path, 0o600)


def save_keypair(keypair: dict, directory: str, write_debug_info: bool = False) -> None:
    """Save key pair to files in specified directory."""
    os.makedirs(directory, exist_ok=True)

    # Public key (safe to distribute / embed in client)
    pub_path = os.path.join(directory, "public_key.txt")
    with open(pub_path, 'w', encoding='utf-8') as f:
        f.write(keypair["public_component_key"])

    # Private key (KEEP SECRET - server only)
    priv_path = os.path.join(directory, "private_key.txt")
    with open(priv_path, 'w', encoding='utf-8') as f:
        f.write(keypair["private_component_key"])
    _chmod_private_key(priv_path)

    if write_debug_info:
        # Full key info includes d_hex and is intentionally opt-in only.
        info_path = os.path.join(directory, "keypair_info.json")
        with open(info_path, 'w', encoding='utf-8') as f:
            json.dump(keypair, f, indent=2)

    print(f"Keys saved to: {directory}")
    print(f"  Public key (for client):  {pub_path}")
    print(f"  Private key (for server): {priv_path}")
    if write_debug_info:
        print(f"  Debug key info:           {os.path.join(directory, 'keypair_info.json')}")


def save_keypair_files(
    keypair: dict,
    public_key_file: str,
    private_key_file: str,
    write_debug_info: bool = False,
) -> None:
    """Save key pair to explicit public/private key files."""
    os.makedirs(os.path.dirname(os.path.abspath(public_key_file)), exist_ok=True)
    os.makedirs(os.path.dirname(os.path.abspath(private_key_file)), exist_ok=True)

    with open(public_key_file, 'w', encoding='utf-8') as f:
        f.write(keypair["public_component_key"])

    with open(private_key_file, 'w', encoding='utf-8') as f:
        f.write(keypair["private_component_key"])
    _chmod_private_key(private_key_file)

    if write_debug_info:
        info_path = os.path.join(
            os.path.dirname(os.path.abspath(private_key_file)),
            "keypair_info.json",
        )
        with open(info_path, 'w', encoding='utf-8') as f:
            json.dump(keypair, f, indent=2)

    print("Keys saved to explicit files:")
    print(f"  Public key (for client):  {public_key_file}")
    print(f"  Private key (for server): {private_key_file}")
    if write_debug_info:
        print(f"  Debug key info:           {info_path}")


def load_keypair(directory: str) -> dict:
    """Load key pair from directory."""
    info_path = os.path.join(directory, "keypair_info.json")
    if os.path.exists(info_path):
        with open(info_path, 'r', encoding='utf-8') as f:
            return json.load(f)

    pub_path = os.path.join(directory, "public_key.txt")
    priv_path = os.path.join(directory, "private_key.txt")
    with open(pub_path, 'r', encoding='utf-8') as f:
        public_key = f.read().strip()
    with open(priv_path, 'r', encoding='utf-8') as f:
        private_key = f.read().strip()
    return {
        "public_component_key": public_key,
        "private_component_key": private_key,
    }


def verify_keypair(keypair: dict) -> bool:
    """Verify that the key pair works (encrypt with public, decrypt with private)."""
    from .rsa_swtools import encrypt_string, decrypt_string

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
    print("Generating RSA-1024 key pair for SWTools license server...")
    kp = generate_keypair()
    print(f"\nPublic ComponentKey:\n{kp['public_component_key']}\n")
    print("Private ComponentKey: written to private_key.txt (not printed)\n")

    verify_keypair(kp)

    save_dir = os.path.join(os.path.dirname(__file__), '..', '..', 'keys')
    save_keypair(kp, save_dir)
