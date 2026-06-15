FROM python:3.12-slim

ENV PYTHONDONTWRITEBYTECODE=1 \
    PYTHONUNBUFFERED=1 \
    ZTOOL_RUNTIME_ENV=production \
    ZTOOL_LOG_LEVEL=INFO \
    ZTOOL_HOST=0.0.0.0 \
    ZTOOL_PORT=58000 \
    ZTOOL_DB_PATH=/var/lib/ztool-license-server/licenses.db \
    ZTOOL_PRIVATE_KEY_FILE=/etc/ztool-license-server/private_key.txt \
    ZTOOL_PUBLIC_KEY_FILE=/etc/ztool-license-server/public_key.txt

RUN useradd --system --home /nonexistent --shell /usr/sbin/nologin ztool \
    && mkdir -p /app/license-server /var/lib/ztool-license-server /etc/ztool-license-server \
    && chown -R ztool:ztool /var/lib/ztool-license-server

WORKDIR /app/license-server
COPY license-server/ /app/license-server/
RUN python -m pip install --no-cache-dir -U pip \
    && python -m pip install --no-cache-dir .

USER ztool
EXPOSE 58000

CMD ["python", "-m", "ztool_license_server.server"]
