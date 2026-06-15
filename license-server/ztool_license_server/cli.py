"""
Command-line interface for ZTool license server management.

Usage:
    python -m ztool_license_server.cli keygen [--dir keys/]
    python -m ztool_license_server.cli add-code <CODE> [--limit 1] [--expires 2027-01-01]
    python -m ztool_license_server.cli list-codes
    python -m ztool_license_server.cli list-activations
    python -m ztool_license_server.cli offline-activate <MACHINE_CODE> [--out file.lic]
"""

import argparse
import hashlib
import sys

from .crypto.keygen import generate_keypair, save_keypair, verify_keypair
from .license_blob import generate_offline_activation
from .machineid import is_valid_machine_code
from .db import LicenseDB
from .config import ServerConfig
from .key_provider import KeyProvider


def cmd_keygen(args):
    """Generate RSA-1024 key pair."""
    print("Generating RSA-1024 key pair...")
    kp = generate_keypair()
    print(f"Public ComponentKey (for client):\n{kp['public_component_key']}\n")
    verify_keypair(kp)
    save_keypair(kp, args.dir, write_debug_info=args.write_debug_key_info)
    print(f"\nDone. Keys saved to: {args.dir}")
    print("IMPORTANT: Keep private_key.txt SECRET. Only distribute public_key.txt.")


def cmd_add_code(args):
    """Add a license code to the database."""
    config = ServerConfig()
    if args.db:
        config.db_path = args.db
    db = LicenseDB(config.db_path)
    db.add_license_code(
        code=args.code,
        password=args.password or "",
        device_limit=args.limit,
        expires_at=args.expires,
        note=args.note or "",
    )
    print(f"Added code: {args.code} (limit={args.limit}, expires={args.expires})")
    db.close()


def cmd_list_codes(args):
    """List all license codes."""
    config = ServerConfig()
    if args.db:
        config.db_path = args.db
    db = LicenseDB(config.db_path)
    rows = db._conn.execute("SELECT * FROM license_codes").fetchall()
    if not rows:
        print("No codes in database.")
    else:
        print(f"{'Code':<30} {'Limit':<8} {'Expires':<22} {'Active':<8} {'Note'}")
        print("-" * 90)
        for row in rows:
            print(f"{row['code']:<30} {row['device_limit']:<8} {row['expires_at'] or 'never':<22} "
                  f"{'Yes' if row['is_active'] else 'No':<8} {row['note'] or ''}")
    db.close()


def cmd_list_activations(args):
    """List all activations."""
    config = ServerConfig()
    if args.db:
        config.db_path = args.db
    db = LicenseDB(config.db_path)
    rows = db._conn.execute(
        "SELECT a.*, l.device_limit FROM activations a "
        "JOIN license_codes l ON a.code = l.code "
        "ORDER BY a.activated_at DESC"
    ).fetchall()
    if not rows:
        print("No activations.")
    else:
        print(f"{'Code':<30} {'Machine SHA256':<16} {'Date':<22} {'Active'}")
        print("-" * 100)
        for row in rows:
            machine_hash = hashlib.sha256(row['machine_code'].encode('utf-8')).hexdigest()[:12]
            print(f"{row['code']:<30} {machine_hash:<16} {row['activated_at']:<22} "
                  f"{'Yes' if row['is_active'] else 'No'}")
    db.close()


def cmd_purge_invalid(args):
    """Deactivate license seats wrongly bound to empty/non-hardware machine codes."""
    config = ServerConfig()
    if args.db:
        config.db_path = args.db
    db = LicenseDB(config.db_path)
    purged = db.purge_invalid_activations()
    print(f"Purged {purged} invalid activation(s).")
    db.close()


def cmd_cleanup_pending(args):
    """Expire stale pending activation/transfer rows."""
    config = ServerConfig()
    if args.db:
        config.db_path = args.db
    db = LicenseDB(config.db_path)
    activations, transfers = db.cleanup_expired_pending()
    print(f"Expired pending activations: {activations}")
    print(f"Expired pending transfers: {transfers}")
    db.close()


def cmd_offline_activate(args):
    """Produce an offline activation file for a given machine code."""
    config = ServerConfig()
    if not is_valid_machine_code(args.machine_code):
        print("ERROR: machine code is not a valid hardware fingerprint "
              "(expected '<36-char GUID>|<disk>|<board>'). Refusing to issue "
              "a license the client cannot validate.", file=sys.stderr)
        sys.exit(1)
    if args.keys_dir:
        config.keys_dir = args.keys_dir
    if args.private_key_file:
        config.private_key_file = args.private_key_file
    if args.public_key_file:
        config.public_key_file = args.public_key_file
    provider = KeyProvider.from_config(config)
    try:
        public_key = provider.load_public_key()
        private_key = provider.load_private_key()
    except Exception as exc:
        print(f"ERROR: key pair not available: {exc}. Run 'keygen' first.",
              file=sys.stderr)
        sys.exit(1)

    payload = generate_offline_activation(
        machine_code=args.machine_code,
        public_key=public_key,
        private_key=private_key,
        client_version=args.client_version,
        is_64bit=not args.x86,
    )
    if args.out:
        with open(args.out, 'w', encoding='utf-8') as f:
            f.write(payload)
        print(f"Offline activation file written to: {args.out}")
    else:
        print(payload)


def main():
    parser = argparse.ArgumentParser(description="ZTool License Server CLI")
    parser.add_argument('--db', default=None, help='Database path')
    sub = parser.add_subparsers(dest='command')

    # keygen
    p_keygen = sub.add_parser('keygen', help='Generate RSA key pair')
    p_keygen.add_argument('--dir', default='keys', help='Output directory')
    p_keygen.add_argument(
        '--write-debug-key-info',
        action='store_true',
        help='Also write keypair_info.json with private exponent metadata (not for production)',
    )

    # add-code
    p_add = sub.add_parser('add-code', help='Add a license code')
    p_add.add_argument('code', help='License code (format: XXXXX-XXXXX-XXXXX-XXXXX-XXXXX)')
    p_add.add_argument('--password', default='', help='Optional protection password')
    p_add.add_argument('--limit', type=int, default=1, help='Device limit (default: 1 — one machine per code)')
    p_add.add_argument('--expires', default=None, help='Expiry date (ISO format)')
    p_add.add_argument('--note', default='', help='Note')

    # list-codes
    sub.add_parser('list-codes', help='List license codes')

    # list-activations
    sub.add_parser('list-activations', help='List activations')

    # purge-invalid
    sub.add_parser('purge-invalid',
                   help='Deactivate seats bound to empty/non-hardware machine codes')

    # cleanup-pending
    sub.add_parser('cleanup-pending',
                   help='Expire stale pending activation/transfer rows')

    # offline-activate
    p_off = sub.add_parser('offline-activate',
                           help='Generate an offline activation file for a machine code')
    p_off.add_argument('machine_code', help='Machine code reported by the client')
    p_off.add_argument('--keys-dir', default=None, help='Directory with public/private keys')
    p_off.add_argument('--private-key-file', default=None, help='Explicit private key file')
    p_off.add_argument('--public-key-file', default=None, help='Explicit public key file')
    p_off.add_argument('--client-version', default=ServerConfig.client_version,
                       help='Client product version (default: %(default)s)')
    p_off.add_argument('--x86', action='store_true', help='Target 32-bit client (default: x64)')
    p_off.add_argument('--out', default=None, help='Output file (default: stdout)')

    args = parser.parse_args()

    if args.command == 'keygen':
        cmd_keygen(args)
    elif args.command == 'add-code':
        cmd_add_code(args)
    elif args.command == 'list-codes':
        cmd_list_codes(args)
    elif args.command == 'list-activations':
        cmd_list_activations(args)
    elif args.command == 'purge-invalid':
        cmd_purge_invalid(args)
    elif args.command == 'cleanup-pending':
        cmd_cleanup_pending(args)
    elif args.command == 'offline-activate':
        cmd_offline_activate(args)
    else:
        parser.print_help()


if __name__ == "__main__":
    main()
