# Этап E: депрекейт IL-reinjection в релизном пути

Дата: 2026-06-22

## Решение

Дефолтная сборка релизного пакета переведена на исходники:

- `client-src/ZTool.csproj` -> runtime `SWTools.exe`;
- `client-src-addin/ZTool.SwAddin.csproj` -> runtime `SWTools.dll`;
- `scripts/build_release_package.ps1` по умолчанию выполняет from-source build и берёт runtime-зависимости из `client-src/bin/Release/net48`.

IL-reinjection больше не является источником релизных бинарей и не блокирует стандартный PR/merge путь.

## Что оставлено

Инструменты `client-core/tools/*` не удалены. Они остаются как исторический reference/diagnostic слой для сравнения с принятым бинарём и локализационными проверками.

Workflow `.github/workflows/client-core-windows.yml` переведён в ручной legacy-режим `workflow_dispatch`. Его можно запускать вручную для smoke-проверки старого reinjection pipeline, но он больше не обязателен для релизной поставки.

## Инварианты, которые нельзя ломать

- внутреннее имя сборок остаётся `ZTool`;
- add-in COM GUID остаётся `59959DFA-3229-4B86-852E-52ABF2BDB8C0`;
- EXE IPC token `code.Getpkt()` остаётся `9EF1CBF0BCFAD9F118EA30863B1874`;
- `ZTool_rsa.dll` в from-source output обязан совпадать с `client-core/ref/ZTool_rsa.dll`.

## Открытые решения

Корневые бинарные файлы `SWTools.exe`/`SWTools.dll` пока не удаляются и не обновляются в этом PR. Их судьба должна быть согласована отдельно: удалить из репозитория или обновить до from-source output.

Остаточные CJK-строки, влияющие на паритет с оригиналом, также не меняются молча. Перенос brand-значений из `AddinBrandPatch` в исходники возможен отдельным PR после подтверждения паритета.
