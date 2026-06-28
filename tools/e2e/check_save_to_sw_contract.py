#!/usr/bin/env python3
"""Guard the Save-to-SolidWorks contract from UI options to add-in writes.

This is a source-level regression gate for the full save path:

1. FrmSaveOption maps every user option into code.* runtime state.
2. Frmmain sends save options, units and row payloads through WM_COPYDATA.
3. The add-in receives the payload and writes document/config properties,
   material/color/summary info, optional delete/rename/reference-update and Save3.

The gate is intentionally static and mirrors the recovered original client
contract. It must catch accidental refactor/localization drift before a live
SolidWorks run. Live fixture tests still remain required for release evidence.
"""

from __future__ import annotations

import argparse
import sys
from pathlib import Path


REPO_ROOT = Path(__file__).resolve().parents[2]
CLIENT_DIR = "Z" + "Tool"
REQUEST_TOKEN = "Z" + "ToolRequest@001"


class ContractError(AssertionError):
    pass


def should_send_row(
    *,
    save_options: int,
    is_top_assembly: bool,
    any_changed: bool,
    row_changed: bool,
    has_error: bool,
    is_readonly: bool,
    is_filtered: bool,
) -> bool:
    """Pure model of Frmmain.sendsavelist row selection.

    save_options:
      0 = save all
      1 = save changed
      2 = save failed

    The recovered client keeps the top assembly as the final "End=True" row and
    applies fewer filters to it than to child rows. This is intentional parity
    with the source-recovered behavior and is guarded explicitly below.
    """

    if is_readonly:
        return False
    if is_top_assembly:
        if save_options == 1 and not any_changed:
            return False
        return True
    if save_options == 1 and not row_changed:
        return False
    if save_options == 2 and not has_error:
        return False
    if is_filtered:
        return False
    return True


def check_save_selection_matrix() -> None:
    cases = [
        ("save-all detail", True, dict(save_options=0, is_top_assembly=False, any_changed=False, row_changed=False, has_error=False, is_readonly=False, is_filtered=False)),
        ("save-all top assembly", True, dict(save_options=0, is_top_assembly=True, any_changed=False, row_changed=False, has_error=False, is_readonly=False, is_filtered=False)),
        ("changed-only detail unchanged", False, dict(save_options=1, is_top_assembly=False, any_changed=True, row_changed=False, has_error=False, is_readonly=False, is_filtered=False)),
        ("changed-only detail changed", True, dict(save_options=1, is_top_assembly=False, any_changed=True, row_changed=True, has_error=False, is_readonly=False, is_filtered=False)),
        ("changed-only top no changed rows", False, dict(save_options=1, is_top_assembly=True, any_changed=False, row_changed=False, has_error=False, is_readonly=False, is_filtered=False)),
        ("changed-only top with changed child", True, dict(save_options=1, is_top_assembly=True, any_changed=True, row_changed=False, has_error=False, is_readonly=False, is_filtered=False)),
        ("failed-only detail without error", False, dict(save_options=2, is_top_assembly=False, any_changed=False, row_changed=False, has_error=False, is_readonly=False, is_filtered=False)),
        ("failed-only detail with error", True, dict(save_options=2, is_top_assembly=False, any_changed=False, row_changed=False, has_error=True, is_readonly=False, is_filtered=False)),
        ("failed-only top assembly remains final row", True, dict(save_options=2, is_top_assembly=True, any_changed=False, row_changed=False, has_error=False, is_readonly=False, is_filtered=False)),
        ("read-only detail skipped", False, dict(save_options=0, is_top_assembly=False, any_changed=False, row_changed=True, has_error=True, is_readonly=True, is_filtered=False)),
        ("filtered detail skipped", False, dict(save_options=0, is_top_assembly=False, any_changed=False, row_changed=False, has_error=False, is_readonly=False, is_filtered=True)),
        ("filtered top assembly remains final row", True, dict(save_options=0, is_top_assembly=True, any_changed=False, row_changed=False, has_error=False, is_readonly=False, is_filtered=True)),
    ]
    for name, expected, kwargs in cases:
        actual = should_send_row(**kwargs)
        if actual is not expected:
            raise ContractError(f"save selection matrix failed: {name}: {actual} != {expected}")


def read_source(*parts: str) -> str:
    return (REPO_ROOT.joinpath(*parts)).read_text(encoding="utf-8-sig")


def require(source: str, token: str, label: str) -> None:
    if token not in source:
        raise ContractError(f"{label}: missing {token!r}")


def require_all(source: str, tokens: list[tuple[str, str]], label: str) -> None:
    for token, reason in tokens:
        require(source, token, f"{label}: {reason}")


def require_order(source: str, tokens: list[str], label: str) -> None:
    pos = -1
    for token in tokens:
        next_pos = source.find(token, pos + 1)
        if next_pos < 0:
            raise ContractError(f"{label}: missing ordered token {token!r}")
        if next_pos < pos:
            raise ContractError(f"{label}: token order drifted at {token!r}")
        pos = next_pos


def extract_method(source: str, signature: str) -> str:
    start = source.find(signature)
    if start < 0:
        raise ContractError(f"method not found: {signature}")
    brace = source.find("{", start)
    if brace < 0:
        raise ContractError(f"method body not found: {signature}")
    depth = 0
    for pos in range(brace, len(source)):
        char = source[pos]
        if char == "{":
            depth += 1
        elif char == "}":
            depth -= 1
            if depth == 0:
                return source[start : pos + 1]
    raise ContractError(f"unterminated method body: {signature}")


def check_save_option_form(source: str) -> None:
    method = extract_method(source, "private void Save_Click(object sender, EventArgs e)")
    require_order(
        method,
        [
            "MyProject.Forms.Frmmain.DGV1.EndEdit();",
            "code.StartSwitch(status: true);",
            "Savecfg();",
            "code.propsaveplace = ComboBox1.SelectedIndex;",
            "code.DelOtherProp_place = ComboBox2.SelectedIndex;",
            "code.DelOtherProp = CheckBox1.Checked;",
            "code.DelCurProp_OtherPosition = CheckBox9.Checked;",
            "code.keepnullvalue = CheckBox2.Checked;",
            "code.CanSetUnit = CheckBox3.Checked;",
            "code.overwrite = CheckBox4.Checked;",
            "code.Updatereferencebool = CheckBox6.Checked;",
            "code.SkipReadOnly = CheckBox7.Checked;",
            "code.UpdatereferenceIncludesubfolders = CheckBox8.Checked;",
            "code.SaveAfterModify = CheckBox10.Checked;",
            "code.targetpath = LinkLabel1.Text;",
        ],
        "FrmSaveOption Save_Click option mapping",
    )
    require_all(
        method,
        [
            ("code.DelCurProp_OtherPosition_place = ComboBox3.SelectedIndex;", "custom/config delete scope"),
            ("code.DelCurProp_OtherPosition_place = ComboBox4.SelectedIndex;", "alternate delete scope"),
            ("code.oldfile_moveto = 1;", "move old file to recycle bin"),
            ("code.oldfile_moveto = 0;", "leave old file untouched"),
            ("code.oldfile_moveto = 2;", "move old file to selected folder"),
            ("Directory.Exists(code.targetpath)", "validate old-file target folder"),
            ('MessageBox.Show(this, "Сначала укажите путь перемещения старых файлов после переименования"', "block invalid old-file folder"),
            ('code.Updatereferencefolder += "\\\\";', "normalize reference-update folder slash"),
            ("code.Updatereferencefolder = code.SplitStr(code.Updatereferencefolder);", "normalize reference-update folder path"),
            ("Operators.CompareString(((Button)sender).Name, Save_Changed.Name", "changed-only button branch"),
            ("code.SaveOptions = 1;", "changed-only mode"),
            ("Operators.CompareString(((Button)sender).Name, Save_Failed.Name", "failed-only button branch"),
            ("code.SaveOptions = 2;", "failed-only mode"),
            ("code.SaveOptions = 0;", "save-all mode"),
            ("code.SetSWUnit();", "optional unit write"),
            ("MyProject.Forms.Frmmain.SaveToSW();", "dispatch to main save pipeline"),
        ],
        "FrmSaveOption Save_Click",
    )


def check_main_save_pipeline(source: str) -> None:
    save_to_sw = extract_method(source, "public void SaveToSW()")
    require_order(
        save_to_sw,
        [
            "sendsaveoptions();",
            "sendunitdata();",
            "sendsavelist();",
            "clearrowerror();",
            "SaveToSWBgWorker.RunWorkerAsync();",
        ],
        "Frmmain SaveToSW dispatch order",
    )

    worker = extract_method(source, "private void SaveToSWBgWorker_DoWork(object sender, DoWorkEventArgs e)")
    require_all(
        worker,
        [
            (REQUEST_TOKEN, "authenticated final execute request"),
            ("Encoding.Unicode.GetBytes(text)", "Unicode IPC payload"),
            ("int value = 34;", "execute-save message id"),
            ("code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);", "WM_COPYDATA dispatch"),
        ],
        "Frmmain SaveToSW background worker",
    )

    options = extract_method(source, "public void sendsaveoptions()")
    require_order(
        options,
        [
            REQUEST_TOKEN,
            "stringBuilder.AppendLine(Conversions.ToString(Handle.ToInt32()));",
            "stringBuilder.AppendLine(code.propsaveplace.ToString());",
            "stringBuilder.AppendLine(code.keepnullvalue.ToString());",
            "stringBuilder.AppendLine(code.DelCurProp_OtherPosition.ToString());",
            "stringBuilder.AppendLine(code.DelCurProp_OtherPosition_place.ToString());",
            "stringBuilder.AppendLine(code.DelOtherProp.ToString());",
            "stringBuilder.AppendLine(code.DelOtherProp_place.ToString());",
            "stringBuilder.AppendLine(code.CanSetUnit.ToString());",
            "stringBuilder.AppendLine(code.SaveAfterModify.ToString());",
            "stringBuilder.AppendLine(code.overwrite.ToString());",
            "stringBuilder.AppendLine(Conversions.ToString(code.oldfile_moveto));",
            "stringBuilder.AppendLine(code.Updatereferencebool.ToString());",
            "stringBuilder.AppendLine(code.UpdatereferenceIncludesubfolders.ToString());",
            "stringBuilder.AppendLine(code.Updatereferencefolder);",
            "stringBuilder.AppendLine(CConfigMng.Config.materialpath);",
            "stringBuilder.AppendLine(code.targetpath);",
            'stringBuilder.AppendLine(">");',
            "int value = 31;",
        ],
        "Frmmain save options IPC contract",
    )
    require(options, "Encoding.Unicode.GetBytes(text)", "Frmmain save options IPC encoding")

    units = extract_method(source, "public void sendunitdata()")
    require_all(
        units,
        [
            (REQUEST_TOKEN, "authenticated unit request"),
            ("int value = 32;", "unit message id"),
            ("Encoding.Unicode.GetBytes(text)", "Unicode unit payload"),
            ("stringBuilder.AppendLine(Conversions.ToString(code.UnitsSystem));", "unit system"),
            ("stringBuilder.AppendLine(Conversions.ToString(code.Basic_Length));", "basic length unit"),
            ("stringBuilder.AppendLine(Conversions.ToString(code.Mass_Mass));", "mass unit"),
            ("stringBuilder.AppendLine(Conversions.ToString(code.Motion_Energy));", "motion energy unit"),
        ],
        "Frmmain unit IPC contract",
    )

    rows = extract_method(source, "public void sendsavelist()")
    require_all(
        rows,
        [
            ("new CustomFilter(CConfigMng.Config.SaveToSWFilterRule)", "save filter rule source"),
            ("DGV1.Rows[num2].Tag", "changed-row detection"),
            ("code.SkipReadOnly && code.IsReadOnly", "read-only skip"),
            ("code.SaveOptions == 1 && !flag", "changed-only skips unchanged top assembly when no changed rows"),
            ("code.SaveOptions == 1 && !code.Cbool1", "changed-only skips unchanged detail rows"),
            ("code.SaveOptions == 2 && Operators.CompareString(DGV1.Rows[index].ErrorText", "failed-only skip"),
            ("customFilter.FilterByRule(index)", "user filter skip"),
            ('"CfgName\\u001e\\u001c"', "configuration payload"),
            ('"NewMaterial\\u001e\\u001c"', "material payload"),
            ('"ModelColor\\u001e\\u001c"', "color payload"),
            ('"Author\\u001e\\u001c"', "summary author payload"),
            ('"Comment\\u001e\\u001c"', "hex summary comment payload"),
            ('"Keywords\\u001e\\u001c"', "summary keywords payload"),
            ('"Subject\\u001e\\u001c"', "summary subject payload"),
            ('"Title\\u001e\\u001c"', "summary title payload"),
            ("Strings.InStr(1, DGV1.Columns[num8].Name, \"PropVal_\")", "dynamic property columns"),
            ("code.GetFieldType(DGV1.Columns[num8].ToolTipText)", "property type payload"),
            ("code.ToHexString", "property value hex encoding"),
            ("code.YesOrNo", "boolean property encoding"),
            ('"PropName\\u001e\\u001c"', "property payload"),
            ('"RowNumber\\u001e\\u001c"', "row number payload"),
            ('"End\\u001e\\u001cTrue"', "top assembly end marker"),
            ('"End\\u001e\\u001cFalse"', "detail/child marker"),
            ('"IsChanged\\u001e\\u001c"', "changed flag payload"),
            ('"NewPathName\\u001e\\u001c"', "new path payload"),
            ('"OldPathName\\u001e\\u001c"', "old path payload"),
            ("Encoding.Unicode.GetBytes(text5)", "Unicode row payload"),
            ("int value = 33;", "row-list message id"),
            ("code.SendMessage((int)code.Receiver_hWnd, 74, 0, ref lParam);", "row-list dispatch"),
        ],
        "Frmmain save row IPC contract",
    )


def check_addin_save_receiver(source: str) -> None:
    require_all(
        source,
        [
            ("else if (f_ == (IntPtr)31)", "save options receiver"),
            ("array3.Length == 18", "save options payload length"),
            ("f_225 = Conversions.ToInteger(array3[2]);", "property placement option"),
            ("f_226 = Type_16.m_58(array3[3]);", "keep empty values option"),
            ("f_227 = Type_16.m_58(array3[4]);", "delete current property from other positions option"),
            ("f_228 = Conversions.ToInteger(array3[5]);", "delete current property scope"),
            ("f_229 = Type_16.m_58(array3[6]);", "delete extra properties option"),
            ("f_230 = Conversions.ToInteger(array3[7]);", "delete extra properties scope"),
            ("f_231 = Type_16.m_58(array3[8]);", "unit write option"),
            ("f_232 = Type_16.m_58(array3[9]);", "auto-save-after-modify option"),
            ("f_233 = Type_16.m_58(array3[10]);", "overwrite option"),
            ("f_234 = Conversions.ToInteger(array3[11]);", "old-file move option"),
            ("f_236 = Type_16.m_58(array3[12]);", "update references option"),
            ("f_237 = Type_16.m_58(array3[13]);", "update references include subfolders option"),
            ("f_238 = array3[14];", "reference-update folder"),
            ("f_239 = array3[15];", "material database path"),
            ("f_235 = array3[16];", "old-file move folder"),
            ("else if (f_ == (IntPtr)33)", "row-list receiver"),
            ("f_215 = type_2.f_67;", "row-list stored for final save"),
            ("else if (f_ == (IntPtr)34)", "final save trigger receiver"),
            ("SaveData2(f_215);", "SW2022+ save handler"),
            ("SaveData(f_215);", "legacy save handler"),
        ],
        "PMPHandler WM_COPYDATA save receiver",
    )

    for method_name in ("SaveData", "SaveData2"):
        method = extract_method(source, f"public void {method_name}(string str)")
        require_all(
            method,
            [
                ("addmaterialtosw();", "material database setup"),
                ('Operators.CompareString(array[0], "PropName"', "property payload parser"),
                ('Operators.CompareString(array[0], "Author"', "summary author parser"),
                ('Operators.CompareString(array[0], "Comment"', "hex summary comment parser"),
                ('Operators.CompareString(array[0], "Keywords"', "summary keywords parser"),
                ('Operators.CompareString(array[0], "Subject"', "summary subject parser"),
                ('Operators.CompareString(array[0], "Title"', "summary title parser"),
                ('Operators.CompareString(array[0], "CfgName"', "configuration parser"),
                ('Operators.CompareString(array[0], "NewMaterial"', "material parser"),
                ('Operators.CompareString(array[0], "ModelColor"', "color parser"),
                ('Operators.CompareString(array[0], "RowNumber"', "row number parser"),
                ('Operators.CompareString(array[0], "End"', "top assembly marker parser"),
                ('Operators.CompareString(array[0], "IsChanged"', "changed flag parser"),
                ('Operators.CompareString(array[0], "NewPathName"', "new path parser"),
                ('Operators.CompareString(array[0], "OldPathName"', "old path parser"),
                ("(!flag2 && flag && !f_232)", "unchanged top assembly is skipped unless auto-save is enabled"),
                ('text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase)', "part document type branch"),
                ("num4 = 1;", "part document type id"),
                ('text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase)', "assembly document type branch"),
                ("num4 = 2;", "assembly document type id"),
                ('text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase)', "drawing document type branch"),
                ("num4 = 3;", "drawing document type id"),
                ("f_206.GetOpenDocumentByName(text)", "reuse open document"),
                ("f_206.OpenDoc6(text, num4, 1, text3, ref Errors, ref Warnings)", "open unopened document silently"),
                ("modelDocExtension = modelDoc.Extension;", "extension access"),
                ("SetMaterialPropertyName2", "material write"),
                ("modelDoc.MaterialPropertyValues", "model color write"),
                ("set_SummaryInfo", "summary information write"),
                ("Modifyunit(modelDocExtension);", "unit write"),
                ("if (f_225 == 0)", "source location property mode"),
                ("else if (f_225 == 1)", "source location with custom fallback mode"),
                ("else if (f_225 == 2)", "custom property mode"),
                ("else if (f_225 == 3)", "current configuration mode"),
                ("get_CustomPropertyManager(text5)", "target custom property manager"),
                ("if (!f_226)", "do not keep empty values branch"),
                ("customPropertyManager.Delete(list[j]);", "empty property delete"),
                ("else", "keep empty values branch"),
                ("if (f_227)", "delete current property from other positions branch"),
                ("if (f_229)", "delete extra properties branch"),
                ("!string.Equals(text2, text, StringComparison.OrdinalIgnoreCase)", "rename decision"),
                ("ReName(modelDoc, text2, text, ref lErrors)", "rename call"),
                ("modelDoc.SetSaveFlag();", "dirty document flag"),
                ("if (f_232)", "auto-save branch"),
                ("if (flag3 && f_208 != 4)", "close only temporarily opened docs outside file import mode"),
                ("f_206.CloseDoc(text2);", "temporary document close"),
                ("sendmessageC(2, num.ToString());", "row progress callback"),
                ("sendmessageC(5, stringBuilder.ToString());", "row result callback"),
                ("Updatereference3(text6, list6, list5);", "reference update after rename"),
            ],
            f"PMPHandler {method_name} save mechanics",
        )
        if (
            "Type_19.m_78(customPropertyManager" not in method
            and 'NewLateBinding.LateGet(instance2, null, "Add3"' not in method
        ):
            raise ContractError(
                f"PMPHandler {method_name} save mechanics: missing non-empty property write"
            )
        if (
            "Type_19.m_78(customPropertyManager, list[j], Conversions.ToString(30), list3[j])" not in method
            and 'NewLateBinding.LateGet(instance3, null, "Add3"' not in method
        ):
            raise ContractError(
                f"PMPHandler {method_name} save mechanics: missing keep-empty property write"
            )
        if (
            "modelDoc.Save3(1, ref Errors2, ref Warnings2)" not in method
            and "modelDoc.Save3(5, ref Errors2, ref Warnings2)" not in method
        ):
            raise ContractError(f"PMPHandler {method_name} save mechanics: missing silent save")


def check_source() -> None:
    check_save_selection_matrix()
    check_save_option_form(read_source("client-src", CLIENT_DIR, "FrmSaveOption.cs"))
    check_main_save_pipeline(read_source("client-src", CLIENT_DIR, "Frmmain.cs"))
    check_addin_save_receiver(read_source("client-src-addin", CLIENT_DIR, "PMPHandler.cs"))


def self_test() -> None:
    check_save_selection_matrix()
    good_form = """
    private void Save_Click(object sender, EventArgs e)
    {
        MyProject.Forms.Frmmain.DGV1.EndEdit();
        code.StartSwitch(status: true);
        Savecfg();
        code.propsaveplace = ComboBox1.SelectedIndex;
        code.DelOtherProp_place = ComboBox2.SelectedIndex;
        code.DelOtherProp = CheckBox1.Checked;
        code.DelCurProp_OtherPosition_place = ComboBox3.SelectedIndex;
        code.DelCurProp_OtherPosition_place = ComboBox4.SelectedIndex;
        code.DelCurProp_OtherPosition = CheckBox9.Checked;
        code.keepnullvalue = CheckBox2.Checked;
        code.CanSetUnit = CheckBox3.Checked;
        code.overwrite = CheckBox4.Checked;
        code.Updatereferencebool = CheckBox6.Checked;
        code.SkipReadOnly = CheckBox7.Checked;
        code.UpdatereferenceIncludesubfolders = CheckBox8.Checked;
        code.SaveAfterModify = CheckBox10.Checked;
        code.targetpath = LinkLabel1.Text;
        code.oldfile_moveto = 1;
        code.oldfile_moveto = 0;
        code.oldfile_moveto = 2;
        if (!Directory.Exists(code.targetpath)) MessageBox.Show(this, "Сначала укажите путь перемещения старых файлов после переименования", "Сообщение");
        code.Updatereferencefolder += "\\\\";
        code.Updatereferencefolder = code.SplitStr(code.Updatereferencefolder);
        if (Operators.CompareString(((Button)sender).Name, Save_Changed.Name, TextCompare: false) == 0) code.SaveOptions = 1;
        else if (Operators.CompareString(((Button)sender).Name, Save_Failed.Name, TextCompare: false) == 0) code.SaveOptions = 2;
        else code.SaveOptions = 0;
        code.SetSWUnit();
        MyProject.Forms.Frmmain.SaveToSW();
    }
    """
    check_save_option_form(good_form)
    try:
        check_save_option_form(good_form.replace("code.SaveOptions = 2;", "code.SaveOptions = 1;"))
    except ContractError:
        pass
    else:
        raise ContractError("self-test failed: broken failed-only SaveOptions mapping passed")

    good_addin = f"""
    else if (f_ == (IntPtr)31) {{ string[] array3 = Strings.Split(type_2.f_67, "\\r\\n"); if (array3.Length == 18) {{
        f_225 = Conversions.ToInteger(array3[2]); f_226 = Type_16.m_58(array3[3]); f_227 = Type_16.m_58(array3[4]);
        f_228 = Conversions.ToInteger(array3[5]); f_229 = Type_16.m_58(array3[6]); f_230 = Conversions.ToInteger(array3[7]);
        f_231 = Type_16.m_58(array3[8]); f_232 = Type_16.m_58(array3[9]); f_233 = Type_16.m_58(array3[10]);
        f_234 = Conversions.ToInteger(array3[11]); f_236 = Type_16.m_58(array3[12]); f_237 = Type_16.m_58(array3[13]);
        f_238 = array3[14]; f_239 = array3[15]; f_235 = array3[16]; }} }}
    else if (f_ == (IntPtr)33) {{ f_215 = type_2.f_67; }}
    else if (f_ == (IntPtr)34) {{ SaveData2(f_215); SaveData(f_215); }}
    public void SaveData(string str) {{ {GOOD_SAVE_METHOD_BODY} }}
    public void SaveData2(string str) {{ {GOOD_SAVE_METHOD_BODY} }}
    """
    check_addin_save_receiver(good_addin)
    try:
        check_addin_save_receiver(good_addin.replace("customPropertyManager.Delete(list[j]);", ""))
    except ContractError:
        pass
    else:
        raise ContractError("self-test failed: missing empty-property delete passed")


GOOD_SAVE_METHOD_BODY = r'''
    addmaterialtosw();
    Operators.CompareString(array[0], "PropName", TextCompare: false);
    Operators.CompareString(array[0], "Author", TextCompare: false);
    Operators.CompareString(array[0], "Comment", TextCompare: false);
    Operators.CompareString(array[0], "Keywords", TextCompare: false);
    Operators.CompareString(array[0], "Subject", TextCompare: false);
    Operators.CompareString(array[0], "Title", TextCompare: false);
    Operators.CompareString(array[0], "CfgName", TextCompare: false);
    Operators.CompareString(array[0], "NewMaterial", TextCompare: false);
    Operators.CompareString(array[0], "ModelColor", TextCompare: false);
    Operators.CompareString(array[0], "RowNumber", TextCompare: false);
    Operators.CompareString(array[0], "End", TextCompare: false);
    Operators.CompareString(array[0], "IsChanged", TextCompare: false);
    Operators.CompareString(array[0], "NewPathName", TextCompare: false);
    Operators.CompareString(array[0], "OldPathName", TextCompare: false);
    if ((!flag2 && flag && !f_232)) {}
    text.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase); num4 = 1;
    text.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase); num4 = 2;
    text.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase); num4 = 3;
    f_206.GetOpenDocumentByName(text);
    f_206.OpenDoc6(text, num4, 1, text3, ref Errors, ref Warnings);
    modelDocExtension = modelDoc.Extension;
    SetMaterialPropertyName2();
    modelDoc.MaterialPropertyValues = values;
    set_SummaryInfo();
    Modifyunit(modelDocExtension);
    if (f_225 == 0) {} else if (f_225 == 1) {} else if (f_225 == 2) {} else if (f_225 == 3) {}
    get_CustomPropertyManager(text5);
    if (!f_226) { customPropertyManager.Delete(list[j]); NewLateBinding.LateGet(instance2, null, "Add3", args); }
    else { NewLateBinding.LateGet(instance3, null, "Add3", args); }
    if (f_227) {}
    if (f_229) {}
    if (!string.Equals(text2, text, StringComparison.OrdinalIgnoreCase)) { ReName(modelDoc, text2, text, ref lErrors); }
    modelDoc.SetSaveFlag();
    if (f_232) { modelDoc.Save3(1, ref Errors2, ref Warnings2); }
    if (flag3 && f_208 != 4) { f_206.CloseDoc(text2); }
    sendmessageC(2, num.ToString());
    sendmessageC(5, stringBuilder.ToString());
    Updatereference3(text6, list6, list5);
'''


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--self-test", action="store_true")
    args = parser.parse_args(argv)
    try:
        if args.self_test:
            self_test()
        else:
            check_source()
    except ContractError as exc:
        print(f"FAIL: {exc}")
        return 1
    print("save-to-sw contract: PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
