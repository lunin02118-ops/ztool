"""
Command-line interface for ZTool license server management.

Usage:
    python -m ztool_license_server.cli keygen [--dir keys/]
    python -m ztool_license_server.cli add-code <CODE> [--limit 3] [--expires 2027-01-01]
    python -m ztool_license_server.cli list-codes
    python -m ztool_license_server.cli list-activations
"""

import argparse
import os
import sys

from .crypto.keygen import generate_keypair, save_keypair, verify_keypair
from .db import LicenseDB
from .config import ServerConfig


def cmd_keygen(args):
    """Generate RSA-1024 key pair."""
    print("Generating RSA-1024 key pair...")
    kp = generate_keypair()
    print(f"Public ComponentKey (for client):\n{kp['public_component_key']}\n")
    verify_keypair(kp)
    save_keypair(kp, args.dir)
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
        print(f"{'Code':<30} {'Machine (first 40)':<42} {'Date':<22} {'Active'}")
        print("-" * 100)
        for row in rows:
            mc = row['machine_code'][:40] + "..." if len(row['machine_code']) > 40 else row['machine_code']
            print(f"{row['code']:<30} {mc:<42} {row['activated_at']:<22} "
                  f"{'Yes' if row['is_active'] else 'No'}")
    db.close()


def main():
    parser = argparse.ArgumentParser(description="ZTool License Server CLI")
    parser.add_argument('--db', default=None, help='Database path')
    sub = parser.add_subparsers(dest='command')

    # keygen
    p_keygen = sub.add_parser('keygen', help='Generate RSA key pair')
    p_keygen.add_argument('--dir', default='keys', help='Output directory')

    # add-code
    p_add = sub.add_parser('add-code', help='Add a license code')
    p_add.add_argument('code', help='License code (format: XXXXX-XXXXX-XXXXX-XXXXX-XXXXX)')
    p_add.add_argument('--password', default='', help='Optional protection password')
    p_add.add_argument('--limit', type=int, default=3, help='Device limit (default: 3)')
    p_add.add_argument('--expires', default=None, help='Expiry date (ISO format)')
    p_add.add_argument('--note', default='', help='Note')

    # list-codes
    sub.add_parser('list-codes', help='List license codes')

    # list-activations
    sub.add_parser('list-activations', help='List activations')

    args = parser.parse_args()

    if args.command == 'keygen':
        cmd_keygen(args)
    elif args.command == 'add-code':
        cmd_add_code(args)
    elif args.command == 'list-codes':
        cmd_list_codes(args)
    elif args.command == 'list-activations':
        cmd_list_activations(args)
    else:
        parser.print_help()


if __name__ == "__main__":
    main()
