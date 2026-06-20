"""
Message dispatcher for SWTools license protocol.

Sendtype codes (request header; verified from the de-obfuscated client):
    128 - Apply_register: activation request. Server replies result 13 + blob.
    129 - Apply_Remove: license transfer/removal request. Server replies 11.
    130 - register: legacy issuance step (unused by the real flow; kept routed).
    131 - register confirm: sent by the client AFTER it saves the 13 blob and
          passes IsReg1; carries SR.get_rginfo(). Server replies result 12.
    132 - remove confirm: sent after a successful 129 (11). Server replies 7.

Note the server response header carries the numeric Result code (below), NOT
the sendtype. The Status strings further down are the legacy human-readable
labels the DB layer still emits; status_to_result() maps them to Result codes.

Server response statuses (Chinese strings expected by client):
    注册成功 - Registration successful
    注册失败 - Registration failed
    无效注册码 - Invalid registration code
    注册信息错误 - Registration info error
    注册申请失败 - Registration application failed
    注册码已被其它电脑使用 - Code already used by another PC
    注册码已过期 - Registration code expired
    授权电脑数量已达上限 - Device limit reached
    密码错误 - Wrong password
    注册信息保存错误 - Registration info save error
    转出授权成功 - Transfer out successful
    转出授权失败 - Transfer out failed
    无需转出 - No transfer needed
    此电脑没有转出权限 - This PC has no transfer permission
    此注册码没有转出权限 - This code has no transfer permission
"""

from enum import IntEnum


class Sendtype(IntEnum):
    APPLY_REGISTER = 128
    APPLY_REMOVE = 129
    REGISTER = 130
    # NOTE: the real client uses 131 as the "register confirm" follow-up that it
    # sends AFTER a successful Apply_register (result code 13). It is NOT a
    # passive "verify" call. 132 is the analogous transfer-confirm follow-up.
    REGISTER_CONFIRM = 131
    VERIFY_REGISTER = 131
    REMOVE_CONFIRM = 132
    VERIFY_REMOVE = 132


REQUEST_SENDTYPES = frozenset({
    int(Sendtype.APPLY_REGISTER),
    int(Sendtype.APPLY_REMOVE),
    int(Sendtype.REGISTER),
    int(Sendtype.REGISTER_CONFIRM),
    int(Sendtype.REMOVE_CONFIRM),
})


class Result(IntEnum):
    """Numeric result codes the client reads from the FIRST 10-byte header
    field of the server response (``getreceive`` -> ``byte_to_Int`` ->
    ``SocketRecive`` compares the string form against these). Verified from the
    de-obfuscated client IL (``TCPClient.SocketRecive``).
    """
    INVALID_CODE = 1      # "Недопустимый регистрационный код"
    CODE_USED = 2         # "...уже используется на другом компьютере"
    EXPIRED = 3           # "Срок действия регистрационного кода истёк"
    REGISTER_FAILED = 4   # "Регистрация не удалась"
    INFO_ERROR = 6        # "Ошибка в сведениях о регистрации"
    TRANSFER_DONE = 7     # "Лицензия успешно перенесена"
    TRANSFER_FAILED = 8   # "Не удалось перенести лицензию"
    TRANSFER_OUT_OK = 11  # transfer apply accepted -> client sends 132
    REGISTER_OK = 12      # "Регистрация выполнена" (final success, after 131)
    APPLY_OK = 13         # apply accepted -> client saves blob, sends 131
    APPLY_FAILED = 16     # "Заявка на регистрацию не удалась"
    DEVICE_LIMIT = 17     # "Достигнут предел числа лицензированных компьютеров"
    WRONG_PASSWORD = 18   # "Неверный пароль"


# Map the (Chinese) status strings the DB layer returns to numeric Result codes.
STATUS_TO_RESULT = {
    "无效注册码": Result.INVALID_CODE,
    "注册码已被其它电脑使用": Result.CODE_USED,
    "注册码已过期": Result.EXPIRED,
    "注册失败": Result.REGISTER_FAILED,
    "注册信息错误": Result.INFO_ERROR,
    "注册申请失败": Result.APPLY_FAILED,
    "授权电脑数量已达上限": Result.DEVICE_LIMIT,
    "密码错误": Result.WRONG_PASSWORD,
    "注册信息保存错误": Result.INFO_ERROR,
    "转出授权成功": Result.TRANSFER_DONE,
    "转出授权失败": Result.REGISTER_FAILED,
    "无需转出": Result.REGISTER_FAILED,
    "此电脑没有转出权限": Result.REGISTER_FAILED,
    "此注册码没有转出权限": Result.REGISTER_FAILED,
}


def status_to_result(status: str, default: "Result") -> "Result":
    """Translate a DB/Status string into a numeric Result code."""
    return STATUS_TO_RESULT.get(status, default)


# Response status strings (must be exact — client matches these)
class Status:
    SUCCESS = "注册成功"
    FAILED = "注册失败"
    INVALID_CODE = "无效注册码"
    INFO_ERROR = "注册信息错误"
    APPLY_FAILED = "注册申请失败"
    CODE_USED = "注册码已被其它电脑使用"
    CODE_EXPIRED = "注册码已过期"
    DEVICE_LIMIT = "授权电脑数量已达上限"
    WRONG_PASSWORD = "密码错误"
    SAVE_ERROR = "注册信息保存错误"
    TRANSFER_SUCCESS = "转出授权成功"
    TRANSFER_FAILED = "转出授权失败"
    NO_TRANSFER_NEEDED = "无需转出"
    PC_NO_PERMISSION = "此电脑没有转出权限"
    CODE_NO_PERMISSION = "此注册码没有转出权限"
