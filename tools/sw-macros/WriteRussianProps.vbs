' =====================================================================
'  WriteRussianProps.vbs
'  Записывает в активную сборку SolidWorks (и во ВСЕ её компоненты)
'  пользовательские свойства с РУССКИМИ (ЕСКД) именами, которые должны
'  совпадать с <propname> / видимыми колонками в ZTool.settings.
'
'  Значения (по согласованию):
'    Обозначение  = имя файла без расширения (напр. 0614-P001)
'    Материал     = ссылка SolidWorks "SW-Material@<файл>"  (только детали)
'    Масса        = ссылка SolidWorks "SW-Mass@<файл>"      (резолвится SW)
'    Наименование, Тип, Версия, Обработка поверхности = создаются ПУСТЫМИ
'    Разработал, Дата разработки = НЕ трогаем (в маппинге не заданы)
'
'  Свойства пишутся на уровне документа ("") И на уровне активной
'  конфигурации — чтобы ZTool гарантированно их прочитал.
'
'  ЗАПУСК:
'    1. Откройте в SolidWorks сборку 0614-A00 (полностью разрешённую,
'       не Lightweight / не Large Design Review), сделайте её активной.
'    2. Двойной клик по этому файлу  ИЛИ  в консоли:  cscript WriteRussianProps.vbs
'    3. По завершении сохраните: макрос сохраняет каждый изменённый
'       документ сам (Save), но при желании сделайте "Сохранить всё".
' =====================================================================
Option Explicit

' --- Имена свойств (должны 1:1 совпадать с <propname> в ZTool.settings).
'     <mappingname> при этом остаётся Excel-anchor шаблона и может быть legacy/CN.
' ---
Dim P_NAME      : P_NAME    = "Наименование"
Dim P_DESIG     : P_DESIG   = "Обозначение"
Dim P_MATERIAL  : P_MATERIAL= "Материал"
Dim P_TYPE      : P_TYPE    = "Тип"
Dim P_VERSION   : P_VERSION = "Версия"
Dim P_SURFACE   : P_SURFACE = "Обработка поверхности"
Dim P_MASS      : P_MASS    = "Масса"

' --- Дефолтные значения «Тип» (временная заглушка под фильтр-режимы).
'     Фильтр «Обрабатываемые детали» ловит значение «Мех.обработка».
'     Подправьте под реальную классификацию (Покупное/Литьё/…) позже.
Dim T_PART      : T_PART    = "Мех.обработка"   ' для деталей
Dim T_ASSEMBLY  : T_ASSEMBLY= "Сборка"          ' для сборок

' --- Константы SolidWorks API ---
Const swDocPART          = 1
Const swDocASSEMBLY      = 2
Const swCustomInfoText   = 30   ' тип свойства: текст
Const swCustomPropertyDeleteAndAdd = 0  ' Add3: удалить старое и записать заново

Dim swApp
On Error Resume Next
Set swApp = GetObject(, "SldWorks.Application")
If Err.Number <> 0 Then Err.Clear
On Error GoTo 0
If Not IsObject(swApp) Then
    WScript.Echo "SolidWorks не запущен. Откройте SW и сборку 0614-A00, затем запустите снова."
    WScript.Quit 1
End If

Dim swModel
On Error Resume Next
Set swModel = swApp.ActiveDoc
If Err.Number <> 0 Then Err.Clear
On Error GoTo 0
If Not IsObject(swModel) Then
    WScript.Echo "Нет активного документа. Откройте сборку 0614-A00 и сделайте её активной."
    WScript.Quit 1
End If
If swModel Is Nothing Then
    WScript.Echo "Нет активного документа. Откройте сборку 0614-A00 и сделайте её активной."
    WScript.Quit 1
End If

' Словарь обработанных путей, чтобы не писать дважды в одну и ту же деталь
Dim seen
Set seen = CreateObject("Scripting.Dictionary")

Dim total : total = 0

' 1) Сама сборка / активный документ
total = total + ProcessModel(swModel)

' 2) Все компоненты (всех уровней вложенности)
If swModel.GetType = swDocASSEMBLY Then
    Dim conf, rootComp, comps, i
    Set conf = swModel.GetActiveConfiguration
    Set rootComp = conf.GetRootComponent3(True)
    comps = swModel.GetComponents(False)   ' False = все компоненты, не только верхний уровень
    If IsArray(comps) Then
        For i = 0 To UBound(comps)
            Dim comp, cm
            Set comp = comps(i)
            If Not comp Is Nothing Then
                If comp.IsSuppressed = False Then
                    Set cm = comp.GetModelDoc2
                    If Not cm Is Nothing Then
                        total = total + ProcessModel(cm)
                    End If
                End If
            End If
        Next
    End If
End If

WScript.Echo "Готово. Обработано документов: " & total & _
             vbCrLf & "Проверьте вкладку 'Настраиваемые' и сделайте 'Сохранить всё' при необходимости."

' ---------------------------------------------------------------------
Function ProcessModel(model)
    ProcessModel = 0
    If model Is Nothing Then Exit Function

    Dim path : path = ""
    On Error Resume Next
    path = model.GetPathName
    On Error GoTo 0

    ' пропуск дубликатов и не сохранённых на диск (виртуальных) деталей
    If path = "" Then Exit Function
    If seen.Exists(LCase(path)) Then Exit Function
    seen.Add LCase(path), True

    Dim fname, desig
    fname = BaseName(path)          ' напр. 0614-P001.SLDPRT
    desig = StripExt(fname)         ' напр. 0614-P001

    Dim isPart : isPart = (model.GetType = swDocPART)

    Dim massVal, matVal, typeVal
    massVal = "SW-Mass@" & fname
    If isPart Then
        matVal  = "SW-Material@" & fname
        typeVal = T_PART
    Else
        matVal  = ""                ' у сборок нет единого материала
        typeVal = T_ASSEMBLY
    End If

    ' Пишем на уровне документа ("") ...
    WriteAll model, "", desig, matVal, massVal, typeVal
    ' ... и на уровне активной конфигурации (если применимо)
    Dim cfgName
    On Error Resume Next
    cfgName = model.ConfigurationManager.ActiveConfiguration.Name
    On Error GoTo 0
    If cfgName <> "" Then
        WriteAll model, cfgName, desig, matVal, massVal, typeVal
    End If

    ' Сохраняем документ
    Dim e, w
    e = 0 : w = 0
    On Error Resume Next
    model.Save3 1, e, w     ' 1 = swSaveAsOptions_Silent
    On Error GoTo 0

    ProcessModel = 1
End Function

' Записывает весь набор свойств в указанную конфигурацию (cfg="" = документ)
Sub WriteAll(model, cfg, desig, matVal, massVal, typeVal)
    Dim cpm
    Set cpm = model.Extension.CustomPropertyManager(cfg)
    SetProp cpm, P_NAME,     ""
    SetProp cpm, P_DESIG,    desig
    SetProp cpm, P_MATERIAL, matVal
    SetProp cpm, P_TYPE,     typeVal
    SetProp cpm, P_VERSION,  ""
    SetProp cpm, P_SURFACE,  ""
    SetProp cpm, P_MASS,     massVal
End Sub

Sub SetProp(cpm, name, value)
    On Error Resume Next
    cpm.Add3 name, swCustomInfoText, value, swCustomPropertyDeleteAndAdd
    On Error GoTo 0
End Sub

Function BaseName(p)
    Dim i : i = InStrRev(p, "\")
    If i > 0 Then BaseName = Mid(p, i + 1) Else BaseName = p
End Function

Function StripExt(n)
    Dim i : i = InStrRev(n, ".")
    If i > 0 Then StripExt = Left(n, i - 1) Else StripExt = n
End Function
