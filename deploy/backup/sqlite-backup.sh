#!/usr/bin/env bash
set -euo pipefail

ENV_FILE="${1:-/etc/ztool-license-server/ztool-license-server.env}"

if [[ -f "$ENV_FILE" ]]; then
  set -a
  # shellcheck disable=SC1090
  source "$ENV_FILE"
  set +a
fi

PYTHON_BIN="${ZTOOL_PYTHON_BIN:-/opt/ztool-license-server/.venv/bin/python}"
DB_PATH="${ZTOOL_DB_PATH:-/var/lib/ztool-license-server/licenses.db}"
BACKUP_DIR="${ZTOOL_BACKUP_DIR:-/var/backups/ztool-license-server}"
RETENTION_DAYS="${ZTOOL_BACKUP_RETENTION_DAYS:-30}"
STAMP="$(date -u +%Y%m%dT%H%M%SZ)"
OUT="${BACKUP_DIR}/licenses-${STAMP}.db"

mkdir -p "$BACKUP_DIR"

"$PYTHON_BIN" -m ztool_license_server.cli --db "$DB_PATH" backup --out "$OUT"
"$PYTHON_BIN" -m ztool_license_server.cli verify-backup "$OUT"

find "$BACKUP_DIR" -type f -name 'licenses-*.db' -mtime +"$RETENTION_DAYS" -delete

echo "Backup verified: $OUT"
