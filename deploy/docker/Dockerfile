FROM python:3.12-slim

ENV PYTHONDONTWRITEBYTECODE=1 \
    PYTHONUNBUFFERED=1 \
    SWTOOLS_RUNTIME_ENV=production \
    SWTOOLS_LOG_LEVEL=INFO \
    SWTOOLS_HOST=0.0.0.0 \
    SWTOOLS_PORT=58000 \
    SWTOOLS_DB_PATH=/var/lib/swtools-license-server/licenses.db \
    SWTOOLS_PRIVATE_KEY_FILE=/etc/swtools-license-server/private_key.txt \
    SWTOOLS_PUBLIC_KEY_FILE=/etc/swtools-license-server/public_key.txt

RUN useradd --system --home /nonexistent --shell /usr/sbin/nologin swtools \
    && mkdir -p /app/license-server /var/lib/swtools-license-server /etc/swtools-license-server \
    && chown -R swtools:swtools /var/lib/swtools-license-server

WORKDIR /app/license-server
COPY license-server/ /app/license-server/
RUN python -m pip install --no-cache-dir -U pip \
    && python -m pip install --no-cache-dir .

USER swtools
EXPOSE 58000

CMD ["python", "-m", "swtools_license_server.server"]
