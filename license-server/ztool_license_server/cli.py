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
import os
from pathlib import Path
import sqlite3
import sys

from .crypto.keygen import (
    generate_keypair,
    save_keypair,
    save_keypair_files,
    verify_keypair,
)
from .crypto.rsa_ztool import decrypt_string, encrypt_string
from .license_blob import generate_offline_activation
from .machineid import is_valid_machine_code
from .db import LATEST_SCHEMA_VERSION, LicenseDB
from .config import ServerConfig
from .key_provider import KeyProvider
from .logging_utils import assert_safe_log_config


def cmd_keygen(args):
    """Generate RSA-1024 key pair."""
    config = _config_from_args(args)
    print("Generating RSA-1024 key pair...")
    kp = generate_keypair()
    print(f"Public ComponentKey (for client):\n{kp['public_component_key']}\n")
    verify_keypair(kp)
    if args.dir:
        save_keypair(kp, args.dir, write_debug_info=args.write_debug_key_info)
        location = args.dir
    elif config.private_key_file and config.public_key_file:
        save_keypair_files(
            kp,
            public_key_file=config.public_key_file,
            private_key_file=config.private_key_file,
            write_debug_info=args.write_debug_key_info,
        )
        location = f"{config.public_key_file} / {config.private_key_file}"
    else:
        save_keypair(kp, config.keys_dir, write_debug_info=args.write_debug_key_info)
        location = config.keys_dir
    print(f"\nDone. Keys saved to: {location}")
    print("IMPORTANT: Keep private_key.txt SECRET. Only distribute public_key.txt.")


def cmd_add_code(args):
    """Add a license code to the database."""
    config = _config_from_args(args)
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
    config = _config_from_args(args)
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
    config = _config_from_args(args)
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
    config = _config_from_args(args)
    db = LicenseDB(config.db_path)
    purged = db.purge_invalid_activations()
    print(f"Purged {purged} invalid activation(s).")
    db.close()


def cmd_cleanup_pending(args):
    """Expire stale pending activation/transfer rows."""
    config = _config_from_args(args)
    db = LicenseDB(config.db_path)
    activations, transfers = db.cleanup_expired_pending()
    print(f"Expired pending activations: {activations}")
    print(f"Expired pending transfers: {transfers}")
    db.close()


def _config_from_args(args) -> ServerConfig:
    config = ServerConfig.from_env()
    if getattr(args, "db", None):
        config.db_path = args.db
    if getattr(args, "keys_dir", None):
        config.keys_dir = args.keys_dir
    if getattr(args, "private_key_file", None):
        config.private_key_file = args.private_key_file
    if getattr(args, "public_key_file", None):
        config.public_key_file = args.public_key_file
    return config


def _require_existing_file(path: str, label: str) -> None:
    if not os.path.isfile(path):
        raise FileNotFoundError(f"{label} not found: {path}")


def cmd_healthcheck(args):
    """Check DB, schema, keypair and safe config."""
    config = _config_from_args(args)
    try:
        assert_safe_log_config(
            config.log_level,
            config.runtime_env,
            config.allow_debug_logging,
        )

        provider = KeyProvider.from_config(config)
        public_key = provider.load_public_key()
        private_key = provider.load_private_key()
        test_message = "healthcheck"
        encrypted = encrypt_string(test_message, public_key, encoding="utf-8")
        decrypted = decrypt_string(encrypted, private_key, encoding="utf-8")
        if decrypted != test_message:
            raise RuntimeError("keypair self-check failed")

        _require_existing_file(config.db_path, "Database")
        db = LicenseDB(config.db_path)
        try:
            if db.get_schema_version() != LATEST_SCHEMA_VERSION:
                raise RuntimeError(
                    f"schema version mismatch: {db.get_schema_version()} != {LATEST_SCHEMA_VERSION}"
                )
            db._conn.execute("BEGIN IMMEDIATE")
            db._conn.rollback()
            integrity = db._conn.execute("PRAGMA quick_check").fetchone()[0]
            if integrity.lower() != "ok":
                raise RuntimeError(f"db quick_check failed: {integrity}")
        finally:
            db.close()
    except Exception as exc:
        print(f"HEALTHCHECK FAIL: {exc}", file=sys.stderr)
        sys.exit(1)

    print("HEALTHCHECK OK")


def cmd_backup(args):
    """Create a safe SQLite backup using sqlite3 backup API."""
    config = _config_from_args(args)
    _require_existing_file(config.db_path, "Database")
    out_path = args.out
    out_dir = os.path.dirname(os.path.abspath(out_path))
    if out_dir:
        os.makedirs(out_dir, exist_ok=True)
    src = sqlite3.connect(config.db_path)
    try:
        dst = sqlite3.connect(out_path)
        try:
            src.backup(dst)
        finally:
            dst.close()
    finally:
        src.close()
    print(f"Backup written to: {out_path}")


def cmd_verify_backup(args):
    """Verify a backup DB without mutating it."""
    _require_existing_file(args.path, "Backup")
    uri = f"{Path(args.path).resolve().as_uri()}?mode=ro"
    conn = sqlite3.connect(uri, uri=True)
    conn.row_factory = sqlite3.Row
    try:
        integrity = conn.execute("PRAGMA integrity_check").fetchone()[0]
        if integrity.lower() != "ok":
            print(f"BACKUP FAIL: integrity_check={integrity}", file=sys.stderr)
            sys.exit(1)
        row = conn.execute("SELECT MAX(version) AS version FROM schema_version").fetchone()
        version = int(row["version"] or 0)
        if version != LATEST_SCHEMA_VERSION:
            print(
                f"BACKUP FAIL: schema version {version} != {LATEST_SCHEMA_VERSION}",
                file=sys.stderr,
            )
            sys.exit(1)
    finally:
        conn.close()
    print("BACKUP OK")


def cmd_offline_activate(args):
    """Produce an offline activation file for a given machine code."""
    config = _config_from_args(args)
    if not is_valid_machine_code(args.machine_code):
        print("ERROR: machine code is not a valid hardware fingerprint "
              "(expected '<36-char GUID>|<disk>|<board>'). Refusing to issue "
              "a license the client cannot validate.", file=sys.stderr)
        sys.exit(1)
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
    p_keygen.add_argument('--dir', default=None,
                          help='Output directory (overrides ZTOOL_KEYS_DIR / explicit key files)')
    p_keygen.add_argument('--keys-dir', default=None,
                          help='Output directory, same as --dir (kept for config symmetry)')
    p_keygen.add_argument('--private-key-file', default=None,
                          help='Explicit private key output path')
    p_keygen.add_argument('--public-key-file', default=None,
                          help='Explicit public key output path')
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

    # healthcheck
    p_health = sub.add_parser('healthcheck', help='Check DB, keys and config')
    p_health.add_argument('--keys-dir', default=None, help='Directory with public/private keys')
    p_health.add_argument('--private-key-file', default=None, help='Explicit private key file')
    p_health.add_argument('--public-key-file', default=None, help='Explicit public key file')

    # backup
    p_backup = sub.add_parser('backup', help='Create SQLite backup using backup API')
    p_backup.add_argument('--out', required=True, help='Output backup DB path')

    # verify-backup
    p_verify = sub.add_parser('verify-backup', help='Verify backup DB integrity and schema')
    p_verify.add_argument('path', help='Backup DB path')

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
    elif args.command == 'healthcheck':
        cmd_healthcheck(args)
    elif args.command == 'backup':
        cmd_backup(args)
    elif args.command == 'verify-backup':
        cmd_verify_backup(args)
    elif args.command == 'offline-activate':
        cmd_offline_activate(args)
    else:
        parser.print_help()


if __name__ == "__main__":
    main()
