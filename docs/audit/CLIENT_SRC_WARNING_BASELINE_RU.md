# Client source warning baseline

Дата baseline: 2026-06-23
Scope: `client-src` + `client-src-addin`, `Release`, .NET SDK Windows runner/local.

Этот файл фиксирует текущие предупреждения from-source сборки. Они не являются
новой нормой качества для будущего кода: это контролируемый baseline для
восстановленных/decompiled исходников. Новый warning-код, изменение количества
или перенос warning в другой `file,line,column,code` должны либо устраняться,
либо явно обновлять этот файл и проходить ревью.

## Машинно-читаемый baseline

<!-- CLIENT_SRC_WARNING_BASELINE_JSON_START -->
{
  "schema": 1,
  "configuration": "Release",
  "generated_at": "2026-06-23T03:30:00Z",
  "projects": {
    "client-src": {
      "total": 123,
      "codes": {
        "CS0162": 24,
        "CS0169": 16,
        "CS0219": 42,
        "CS0414": 4,
        "CS0649": 31,
        "CS1717": 6
      },
      "warnings": [
        {
          "file": "client-src/ZTool.JDK/checklic.cs",
          "line": 42,
          "column": 5,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool.JDK/Prog1.cs",
          "line": 38,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool.JDK/Prog1.cs",
          "line": 40,
          "column": 7,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool.JDK/Prog1.cs",
          "line": 42,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool.JDK/Prog1.cs",
          "line": 44,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool.JDK/Prog1.cs",
          "line": 45,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool.JDK/Prog1.cs",
          "line": 46,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/boxset.cs",
          "line": 19,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/CheckUpdate.cs",
          "line": 87,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/CheckUpdate.cs",
          "line": 112,
          "column": 25,
          "code": "CS0414"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 835,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1039,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1326,
          "column": 7,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1342,
          "column": 13,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1343,
          "column": 13,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1344,
          "column": 13,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1535,
          "column": 13,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1536,
          "column": 13,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 1537,
          "column": 13,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/code.cs",
          "line": 3774,
          "column": 7,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/CustomComboBox1.cs",
          "line": 23,
          "column": 20,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/CustomFilter.cs",
          "line": 86,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/DataGridViewEX.cs",
          "line": 60,
          "column": 14,
          "code": "CS0414"
        },
        {
          "file": "client-src/ZTool/DataGridViewEX.cs",
          "line": 62,
          "column": 15,
          "code": "CS0414"
        },
        {
          "file": "client-src/ZTool/frm_copyswfile.cs",
          "line": 122,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/frm_copyswfile.cs",
          "line": 1057,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/frm_copyswfile.cs",
          "line": 1630,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmAbout.cs",
          "line": 20,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmAsk.cs",
          "line": 17,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/Frmbom.cs",
          "line": 1887,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmbomset.cs",
          "line": 21,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/Frmcompare.cs",
          "line": 74,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmCopy.cs",
          "line": 19,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmCopy.cs",
          "line": 65,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/Frmcustomsort.cs",
          "line": 21,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/Frmcustomsort.cs",
          "line": 937,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmexchangecol.cs",
          "line": 18,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmFilling.cs",
          "line": 3670,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmFilling.cs",
          "line": 4476,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmFilterrules.cs",
          "line": 107,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 1061,
          "column": 14,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 1105,
          "column": 23,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 1235,
          "column": 14,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 5142,
          "column": 12,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 6938,
          "column": 9,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 6942,
          "column": 9,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 6946,
          "column": 9,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 7024,
          "column": 7,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 7342,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9223,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9462,
          "column": 5,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9506,
          "column": 5,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9579,
          "column": 6,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9624,
          "column": 5,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9669,
          "column": 5,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9721,
          "column": 5,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 9810,
          "column": 6,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 10779,
          "column": 8,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 11923,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/Frmmain.cs",
          "line": 12543,
          "column": 5,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmmapping.cs",
          "line": 73,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/Frmmerge_split_pdf.cs",
          "line": 94,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmOptions.cs",
          "line": 229,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmOutputoptions.cs",
          "line": 79,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmOutputoptions.cs",
          "line": 4446,
          "column": 8,
          "code": "CS1717"
        },
        {
          "file": "client-src/ZTool/FrmOutputoptions.cs",
          "line": 6464,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmPreview.cs",
          "line": 21,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 53,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 159,
          "column": 15,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 165,
          "column": 15,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 167,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 169,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 188,
          "column": 15,
          "code": "CS0414"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 1721,
          "column": 12,
          "code": "CS1717"
        },
        {
          "file": "client-src/ZTool/FrmPrintoptions.cs",
          "line": 2309,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmRename.cs",
          "line": 101,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmReplace.cs",
          "line": 19,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmReplace.cs",
          "line": 655,
          "column": 11,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmReplace.cs",
          "line": 741,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmReplacePartslist.cs",
          "line": 452,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmReplacePartslist.cs",
          "line": 454,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmRg.cs",
          "line": 24,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmRg.cs",
          "line": 957,
          "column": 3,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmRg.cs",
          "line": 1122,
          "column": 11,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmRg.cs",
          "line": 1123,
          "column": 11,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmRverify.cs",
          "line": 18,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmRverify.cs",
          "line": 83,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmSaveOption.cs",
          "line": 22,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSaveOption.cs",
          "line": 1874,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmSelType.cs",
          "line": 17,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSelType2.cs",
          "line": 17,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSetDrwOption.cs",
          "line": 24,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSetDrwOption.cs",
          "line": 151,
          "column": 15,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/FrmSetDrwOption.cs",
          "line": 1651,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmSetDrwOption.cs",
          "line": 1652,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmSetDrwOption.cs",
          "line": 1653,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/FrmSetDrwOption.cs",
          "line": 2954,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmSetNewFolder.cs",
          "line": 20,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSplitcloumn.cs",
          "line": 51,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSplitcloumn.cs",
          "line": 2225,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmSuffixes.cs",
          "line": 18,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSWUnit.cs",
          "line": 19,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmSWUnit.cs",
          "line": 2050,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/FrmSWUnit.cs",
          "line": 2578,
          "column": 4,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/Frmsymbol.cs",
          "line": 20,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/FrmUpdatelog.cs",
          "line": 17,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/MyiTextSharp.cs",
          "line": 61,
          "column": 8,
          "code": "CS1717"
        },
        {
          "file": "client-src/ZTool/MyiTextSharp.cs",
          "line": 62,
          "column": 8,
          "code": "CS1717"
        },
        {
          "file": "client-src/ZTool/MyiTextSharp.cs",
          "line": 66,
          "column": 8,
          "code": "CS1717"
        },
        {
          "file": "client-src/ZTool/MyiTextSharp.cs",
          "line": 73,
          "column": 8,
          "code": "CS1717"
        },
        {
          "file": "client-src/ZTool/MyiTextSharp.cs",
          "line": 317,
          "column": 24,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 191,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 193,
          "column": 17,
          "code": "CS0169"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 209,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 695,
          "column": 7,
          "code": "CS0162"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 833,
          "column": 9,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 835,
          "column": 9,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 922,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 923,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 924,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/MySWDM.cs",
          "line": 925,
          "column": 10,
          "code": "CS0219"
        },
        {
          "file": "client-src/ZTool/SWList.cs",
          "line": 18,
          "column": 21,
          "code": "CS0649"
        },
        {
          "file": "client-src/ZTool/TCPClient.cs",
          "line": 226,
          "column": 6,
          "code": "CS0162"
        }
      ]
    },
    "client-src-addin": {
      "total": 6,
      "codes": {
        "CS0414": 6
      },
      "warnings": [
        {
          "file": "client-src-addin/ZTool/customsettings.cs",
          "line": 80,
          "column": 15,
          "code": "CS0414"
        },
        {
          "file": "client-src-addin/ZTool/Page_randomcolor.cs",
          "line": 28,
          "column": 14,
          "code": "CS0414"
        },
        {
          "file": "client-src-addin/ZTool/Page_randomcolor.cs",
          "line": 30,
          "column": 14,
          "code": "CS0414"
        },
        {
          "file": "client-src-addin/ZTool/Page_RepairReference.cs",
          "line": 35,
          "column": 14,
          "code": "CS0414"
        },
        {
          "file": "client-src-addin/ZTool/Page_RepairReference.cs",
          "line": 47,
          "column": 14,
          "code": "CS0414"
        },
        {
          "file": "client-src-addin/ZTool/Page_RepairReference.cs",
          "line": 49,
          "column": 14,
          "code": "CS0414"
        }
      ]
    }
  }
}
<!-- CLIENT_SRC_WARNING_BASELINE_JSON_END -->

## Классификация

| Code | Project | Count | Class | Decision |
|---|---:|---:|---|---|
| `CS0162` | `client-src` | 24 | benign decompiler/control-flow artifact | Оставить до плановой чистки; не менять поведение ради косметики. |
| `CS0169` | `client-src` | 16 | benign WinForms/decompiler field artifact | Оставить; часто это поля форм/старых обработчиков. |
| `CS0219` | `client-src` | 42 | benign decompiler local artifact | Оставить; переменные появились при восстановлении IL. |
| `CS0414` | `client-src` | 4 | benign decompiler field artifact | Оставить; не влияет на runtime. |
| `CS0649` | `client-src` | 31 | benign WinForms designer/component artifact | Оставить; типично для восстановленных форм. |
| `CS1717` | `client-src` | 6 | suspicious-but-known decompiler assignment artifact | Не править без parity-теста конкретного метода. |
| `CS0414` | `client-src-addin` | 6 | benign recovered add-in field artifact | Оставить до semantic cleanup Sprint H/I. |

## Проверка

```powershell
pwsh -NoProfile -File scripts/check_client_src_warnings.ps1
```

Ожидаемый результат: `client source warning baseline: PASS`.

## Политика изменения

1. Если warning можно безопасно убрать локальной правкой без изменения поведения,
   сначала убрать его и обновить baseline вниз.
2. Если warning добавлен новой разработкой, это blocker.
3. Если warning переехал между файлами/строками при рефакторинге, это тоже
   baseline drift и требует осознанного обновления exact identity list.
4. Если warning является артефактом recovery/decompiler и убрать его нельзя без
   риска parity-регрессии, обновить baseline в этом файле и объяснить причину в PR.
