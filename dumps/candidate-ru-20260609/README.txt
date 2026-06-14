Кандидат русифицированной ZTool.dll (анпак из live-дампа SolidWorks)
====================================================================

АКТУАЛЬНЫЙ ФАЙЛ (с иконками): ZTool_ru_candidate2.dll
SHA256: eea7c9ae89edb139ed029f2b4fbb0c1d27459ccb31d1b8d60d0560cf15ba0961

ЗАЩИЩЁННЫЙ ВАРИАНТ (defensive): ZTool_ru_candidate2_pmpguard.dll
SHA256: 7ca18a535871d8c9f10c6c9bdde8bd931f8be2118b7b6590d12deb8313036fd0
  Идентичен candidate2, но тело ZTool.PMPHandler.DefWndProc обёрнуто в
  try/catch(System.Exception) (патчер: client-core/tools/PmpGuardPatch).
  Цель: init-race на этапе IPC-рукопожатия WM_COPYDATA («Подключить SW»)
  больше не валит аддин NullReferenceException — ранний/неполный пакет
  просто игнорируется. Поведение во всём остальном без изменений.
  ВНИМАНИЕ: preflight-проверка хеша ждёт eea7c9...ba0961 — для этого варианта
  ожидаемый хеш 7ca18a...036fd0 (это нормально, не ошибка).

ЗАЩИЩЁННЫЙ ВАРИАНТ v2 (defensive, РЕКОМЕНДУЕТСЯ): ZTool_ru_candidate2_pmpguard2.dll
SHA256: d053542521a6d869b2208d8c5a45d894f0fb6786cab8a78f9af7762d0e492eb9
  = pmpguard.dll (обёртка DefWndProc) + дополнительный патч модалок NullReference.
  В методах чтения SW ZTool.PMPHandler.GetDataByBom / GetDataFromSel /
  GetDataFromVis каждый внутренний catch(Exception) и логирует ошибку через
  sendmessageC(6, ex.ToString()), и показывал модалку MessageBox.Show(ex.Message).
  При раннем/повторном «Подключить SW» SolidWorks COM отдаёт null посреди чтения,
  ловится здесь -> пользователь видел «Ссылка на объект не указывает на экземпляр
  объекта». Патч вставляет перед каждым MessageBox.Show проверку
  «if (ex is NullReferenceException) -> пропустить показ» (5 точек: 1+1+3).
  Итог: транзиентные null по-прежнему уходят в лог (sendmessageC), но модалку
  больше не показывают; для всех остальных исключений модалка остаётся.
  Патчер (воспроизводимо): client-core/tools/NullModalGuard
    NullModalGuard <in.dll> patch  <out.dll>   — применить (5/5)
    NullModalGuard <out.dll> verify            — проверить (VERIFY: PASS)
  Применяется поверх pmpguard.dll, поэтому содержит обе защиты.
  preflight ждёт eea7c9...ba0961 — для этого варианта ожидаемый хеш
  d053542...92eb9 (это нормально, не ошибка).

Предыдущий (без иконок):      ZTool_ru_candidate1.dll
SHA256: bc04c6994469ba717ace5ab1ff541a6da1fc96b32d83266e04f9d40d85c31647

Происхождение:
  Источник = dumps/manual-test-20260609-081854/ZTool_dumped.dll (live-дамп из SLDWORKS.exe).
  Обработка (dnlib):
    1) нейтрализован загрузчик протектора <Module>.cctor (чтобы не перешифровывал уже расшифрованные тела);
    2) русифицировано 180 строк (351 ldstr): лента + кнопки/сообщения/тултипы;
       намеренно НЕ переведены 8 «логических» строк (шрифты 微软雅黑/宋体, плейсхолдеры $图号$/<配置名称> и т.п.);
    3) ИКОНКИ И РЕСУРСЫ ФОРМ восстановлены из полного 3 ГБ дампа процесса:
       23 ресурса (ZTool.ToolbarLarge_32.bmp 576x32 = 18 иконок, _24/_16-страйпы,
       MainIcon*, flyGroupicon*, slddrw, opened_folder, .resources форм) извлечены
       из рантайм-сателлита протектора ESYGdDVneyZGaacscwWoIlKTWklM (найден в дампе),
       и встроены в саму ZTool.dll как EmbeddedResource (зависимость от сателлита убрана).
       Иконки байт-в-байт оригинальные → на ленте выглядят как в исходной версии.
    4) снят strong-name. GUID аддона сохранён: 59959DFA-3229-4B86-852E-52ABF2BDB8C0.

Проверка на стороне сборщика:
  Assembly.LoadFile OK; класс ZTool.SwAddin : ISwAddin (GUID 59959DFA-...) на месте;
  23 EmbeddedResource (162272 байт) читаются; все картинки декодируются GDI (валидные).

Как тестировать (см. МЕТОДИКА_ТЕСТА_DLL.md в корне репо):
  1. Get-FileHash <файл> -Algorithm SHA256  -> должно быть eea7c9ae...ba0961
  2. Переименовать в ZTool.dll, рядом положить SolidWorksTools.dll (+ ZTool.exe для кнопок-лаунчеров).
  3. Прогон с шага 3.1 (LoadFile / RegAsm / реестр), затем 4-5 в SolidWorks.
  4. Проверить, что на ленте ZTool появились ИКОНКИ кнопок (раньше были пустые).

Известные ограничения:
  - Защита протектора снята (неизбежно при анпаке).

ВНИМАНИЕ: это тестовый артефакт, НЕ боевая замена ZTool.dll. В боевой релиз попадёт
только после подтверждённого теста в SolidWorks.
