# SWTools license-server: Docker deployment

Docker-вариант удобен для staging или изолированного VPS. Для production через
systemd проще контролировать права ключей и backup, но оба варианта используют
одни и те же env-переменные.

## Подготовка

```bash
cd deploy/docker
mkdir -p data keys
cp ../systemd/swtools-license-server.env.example .env
```

Положите `private_key.txt` и `public_key.txt` в `deploy/docker/keys/`.
Файл `.env` не должен попадать в git, если в нём есть реальные пути/секреты.

## Запуск

```bash
docker compose up -d --build
docker compose logs -f
```

Healthcheck из контейнера:

```bash
docker compose exec swtools-license-server \
  python -m swtools_license_server.cli healthcheck
```

Backup:

```bash
docker compose exec swtools-license-server \
  python -m swtools_license_server.cli backup --out /var/lib/swtools-license-server/licenses-backup.db
docker compose exec swtools-license-server \
  python -m swtools_license_server.cli verify-backup /var/lib/swtools-license-server/licenses-backup.db
```
