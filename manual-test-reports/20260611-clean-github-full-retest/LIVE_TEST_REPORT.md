# LIVE_TEST_REPORT

Дата: 2026-06-11
Репо: `lunin02118-ops/ztool`
Ветка: `integration/all-prs`
HEAD: `870b178c1535a97aea6737d5f1745885a1260569`

## 1. Окружение

- Рабочая папка: `D:\ztool-test`
- Путь ASCII: да
- SolidWorks: `SOLIDWORKS Premium 2025 SP3.0`
- Тестовая модель: `D:\ztool-test\TestModel\0614-A00.SLDASM`

## 2. Хеши

- `ZTool.dll`: `EEA7C9AE89EDB139ED029F2B4FBB0C1D27459CCB31D1B8D60D0560CF15BA0961`
- `ZTool.exe`: `8EAF413F4C5DF5A6D307DBDA98F2C2C1D4A7BDE93621A38FCEA85519526F37C8`
- `SolidWorksTools.dll`: `3D84174F61C58BB1327281C73495934233080A9BF0EA71B777B304F6C6CA14C3`

## 3. Очистка

- Полностью очищены старые ZTool-копии в рабочей зоне.
- Удалены старые ZTool-следы из реестра.
- После очистки остались только свежие ключи, созданные `RegAsm` для текущего `D:\ztool-test\ZTool.dll`.

## 4. Регистрация

- `RegAsm /codebase`: OK
- `HKLM\SOFTWARE\Classes\CLSID\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}`: текущий `CodeBase` -> `file:///D:/ztool-test/ZTool.DLL`
- `HKCU\SOFTWARE\SolidWorks\AddInsStartup\{59959DFA-3229-4B86-852E-52ABF2BDB8C0}`: управляемо, использовался `0` для старта без автозагрузки и `1` для проверки автозапуска

## 5. SolidWorks / DLL

- Запуск через `explorer.exe` + ярлык SOLIDWORKS 2025: OK
- Ошибки `.NET Framework` при правильном user-context запуске: нет
- Вкладка `ZTool` видна
- Иконки на ленте: есть
- Язык ленты: русский
- In-DLL кнопки: открываются, падений нет

Скриншот:
- [ztool-sw-after-open-model.png](./ztool-sw-after-open-model.png)

## 6. EXE

После `Проба` в окне лицензии:
- окно на русском
- `ZTool.exe` запускается из `D:\ztool-test\ZTool.exe`
- хеш процесса: совпадает с эталоном `8EAF413F...26F37C8`

Лицензия:
- после полной чистки реестра появляется окно `Действующая лицензия не обнаружена!`
- это ожидаемо после удаления license-ключей
- кнопка `Проба` переводит в trial

Скриншот:
- [ztool-after-management-click-2.png](./ztool-after-management-click-2.png)

## 7. Чтение из SolidWorks

### Режим 1: `Чтение по спецификации`

- Старт: `Подключить SW`
- Результат: `Подключение завершено, затрачено 0,2 сек, всего 29 поз.`
- Строк в таблице: `29`

Скриншот:
- [ztool-after-connect-click-2.png](./ztool-after-connect-click-2.png)

### Режим 2: `Читать всё`

- Выбран режим из выпадающего меню `Подключить SW`
- Повторный `Подключить SW`
- Результат: `Подключение завершено, затрачено 0,2 сек, всего 29 поз.`
- Строк в таблице: `29`

Скриншот:
- [ztool-read-all-final.png](./ztool-read-all-final.png)

## 8. Сервер лицензий

- `python -m pip install -e .`: OK
- `pytest -q`: `66 passed, 1 skipped`
- `ServerConfig.from_env()` читает `ZTOOL_HOST`, `ZTOOL_PORT`, `ZTOOL_KEYS_DIR`, `ZTOOL_DB_PATH`: OK

## 9. Итог

- DLL: PASS
- EXE: PASS
- Чтение из SW: PASS, `29 поз.` в обоих режимах
- Сервер лицензий: PASS

## 10. Примечание

- Ошибка `Не удалось загрузить Microsoft .NET Framework` воспроизводилась только при неверном elevated-запуске из PowerShell. Корректный запуск через `explorer.exe` / user-context проходит нормально.
