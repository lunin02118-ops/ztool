"""
License blob generation — creates the exact format stored in Windows registry
that ZTool.SR.IsReg1/IsReg2 validates.

Registry layout (4 branches, HKLM):
    Software\\SolURxxCfNU\\C4eHN4fjikBan          → "information"
    Software\\SolURxxCfNU\\HTwk2RCBDL             → "information"
    SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\Jlj4aG8uZBvW → "F2S6qCdziIAm"
    SOFTWARE\\Microsoft\\MzORu8qE4HhZ\\98CqyvBZcg   → "information"

Validation flow (client-side, SR.IsReg1/IsReg2):
    1. Read values from registry branches
    2. Decrypt AES layer: SecurityCenter.DecriptStr(value, passphrase)
    3. Decrypt/verify RSA layer: RSAHelper.DecryptString(…, PUBLIC_KEY)
    4. Parse fields (separators: | and \\n): machine_code, registration_time, reg_info
    5. Compare machine_code with current PC (Operators.CompareString)
    6. Cross-check between branches

Server must produce:
    license_blob = AES_Encrypt( RSA_Sign(fields), passphrase )
    where RSA_Sign = encrypt with PRIVATE key (client verifies with public key)
    fields include: machine_code | registration_time | registration_info

Note: The exact separator and field order needs confirmation from dynamic analysis.
Current best guess from IL analysis:
    inner = machine_code + "\\n" + DateTime.Now.ToString() + "\\n" + reg_info
    signed = RSAHelper.EncryptString(inner, PRIVATE_KEY)   # server signs
    blob = SecurityCenter.EncriptStr(signed, passphrase)   # AES wrap
"""

from datetime import datetime
from typing import Optional

from .crypto.rsa_ztool import sign_string
from .crypto.aes_security_center import encrypt, PASSPHRASE_BINGYU


# Registry paths where blobs are stored
REGISTRY_PATHS = [
    {
        "key": r"Software\SolURxxCfNU",
        "value_name": "C4eHN4fjikBan",
        "data_name": "information",
    },
    {
        "key": r"Software\SolURxxCfNU",
        "value_name": "HTwk2RCBDL",
        "data_name": "information",
    },
    {
        "key": r"SOFTWARE\Microsoft\MzORu8qE4HhZ",
        "value_name": "Jlj4aG8uZBvW",
        "data_name": "F2S6qCdziIAm",
    },
    {
        "key": r"SOFTWARE\Microsoft\MzORu8qE4HhZ",
        "value_name": "98CqyvBZcg",
        "data_name": "information",
    },
]


def generate_license_blob(
    machine_code: str,
    private_key: str,
    reg_info: str = "",
    passphrase: str = PASSPHRASE_BINGYU,
    reg_time: Optional[str] = None,
) -> str:
    """
    Generate a license blob for storage in the Windows registry.

    Args:
        machine_code: The client's machine code (hardware fingerprint)
        private_key: Server's private ComponentKey for RSA signing
        reg_info: Registration info string (code details, etc.)
        passphrase: AES passphrase for outer encryption layer
        reg_time: Registration timestamp (defaults to now)

    Returns:
        Encrypted blob string (ready to write to registry value)
    """
    if reg_time is None:
        reg_time = datetime.now().strftime("%Y/%m/%d %H:%M:%S")

    # Build inner fields (separator: \n based on IL analysis of get_rgtime/get_rginfo)
    inner_fields = f"{machine_code}\n{reg_time}\n{reg_info}"

    # RSA sign: encrypt with private key (client will decrypt/verify with public key)
    signed = sign_string(inner_fields, private_key, encoding='utf-8')

    # AES wrap: outer encryption layer
    blob = encrypt(signed, passphrase)

    return blob


def generate_all_registry_blobs(
    machine_code: str,
    private_key: str,
    reg_info: str = "",
    passphrase: str = PASSPHRASE_BINGYU,
) -> dict:
    """
    Generate blobs for all 4 registry branches.

    The cross-check between branches means all must contain consistent data.
    Currently we write the same blob to all 4 (simplification based on IL analysis).

    Returns:
        Dict mapping registry path info to blob values.
    """
    blob = generate_license_blob(machine_code, private_key, reg_info, passphrase)

    results = {}
    for path_info in REGISTRY_PATHS:
        key = path_info["key"]
        value_name = path_info["value_name"]
        data_name = path_info["data_name"]
        results[f"{key}\\{value_name}"] = {
            "registry_key": f"HKLM\\{key}",
            "value_name": data_name,
            "data": blob,
        }

    return results
