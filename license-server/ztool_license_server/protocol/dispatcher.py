"""
Message dispatcher for ZTool license protocol.

Sendtype codes:
    128 - Apply_register: Registration application (activation request)
    129 - Apply_Remove: License removal/transfer request
    130 - register: Registration (license issuance)
    131 - verify_register: Verify registration status
    132 - verify_Remove: Verify removal/transfer

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
    VERIFY_REGISTER = 131
    VERIFY_REMOVE = 132


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
