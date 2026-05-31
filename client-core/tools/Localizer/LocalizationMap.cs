using System.Collections.Generic;

// Explicit Chinese -> Russian map for user-visible ZTool.exe strings.
// Only strings listed here are replaced; everything else (protocol keys such as
// "\u6765\u751f\u7f18\u3002\u3002\u3002", log format strings, font names like
// "\u5fae\u8f6f\u96c5\u9ed1", etc.) is intentionally left untouched so behaviour
// and key derivation are preserved.
internal static class LocalizationMap
{
    public static readonly Dictionary<string, string> Map = new Dictionary<string, string>
    {
        // Registration window title suffix (FrmRg.Reg_Load). The trailing
        // control chars are preserved verbatim.
        { "（x64） 注册\u001E\u001C", "(x64) Регистрация\u001E\u001C" },
        { "（x86） 注册\u001E\u001C", "(x86) Регистрация\u001E\u001C" },

        // Password field watermark (FrmRg: Reg_Load / CheckBox1_CheckedChanged /
        // password_LostFocus).
        { "请输入8-20位包含大小写字母和数字的密码",
          "Введите пароль: 8-20 символов (буквы верхнего и нижнего регистра и цифры)" },

        // Generic MessageBox caption used across the app ("Notice").
        { "提示", "Сообщение" },
    };
}
