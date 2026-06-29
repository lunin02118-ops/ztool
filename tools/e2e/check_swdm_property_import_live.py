#!/usr/bin/env python3
"""Live native SolidWorks Document Manager property import gate.

This gate validates the exact native mechanism used by
``Задать имя свойства -> Импорт... -> Получить из файла/папки``:

    SwDocumentMgr.SwDMClassFactory -> GetApplication(key) -> GetDocument(...)

The key is read from a local secret source and is never printed. The gate does
not use SolidWorks OpenDoc6, UI automation, or any live SolidWorks fallback.
"""

from __future__ import annotations

import argparse
import hashlib
import json
import os
import shutil
import subprocess
import sys
import textwrap
from pathlib import Path


REPO_ROOT = Path(__file__).resolve().parents[2]
WORK_DIR = REPO_ROOT / "_local_artifacts" / "probes" / "swdm-property-import-live"
INTEROP = Path(r"C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\SolidWorks.Interop.swdocumentmgr.dll")
CSC = Path(r"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe")


CS_SOURCE = r'''
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using SolidWorks.Interop.swdocumentmgr;

public static class Probe
{
    private static readonly string[] Extensions = new[] { ".sldprt", ".sldasm" };

    public static int Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var options = ParseArgs(args);
        string key = File.ReadAllText(options["keyFile"], Encoding.UTF8).Trim();
        var factory = (SwDMClassFactory)Activator.CreateInstance(Type.GetTypeFromProgID("SwDocumentMgr.SwDMClassFactory"));
        var app = factory.GetApplication(key);
        var files = ResolveFiles(options);
        var names = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
        var fileReports = new List<string>();
        foreach (string file in files)
        {
            SwDmDocumentOpenError err;
            SwDMDocument doc = app.GetDocument(file, DocumentType(file), true, out err);
            if (doc == null || err != SwDmDocumentOpenError.swDmDocumentOpenErrorNone)
            {
                fileReports.Add(JsonObject(
                    "path", file,
                    "open_error", err.ToString(),
                    "doc_null", doc == null ? "true" : "false",
                    "property_count", "0"));
                continue;
            }
            int before = names.Count;
            AddNames(names, doc.GetCustomPropertyNames());
            var cfgMgr = doc.ConfigurationManager;
            object cfgNamesObj = cfgMgr == null ? null : cfgMgr.GetConfigurationNames();
            Array cfgNames = cfgNamesObj as Array;
            if (cfgNames != null)
            {
                foreach (object cfgNameObj in cfgNames)
                {
                    string cfgName = Convert.ToString(cfgNameObj);
                    var cfg = cfgMgr.GetConfigurationByName(cfgName) as SwDMConfiguration8;
                    if (cfg != null)
                    {
                        AddNames(names, cfg.GetCustomPropertyNames());
                    }
                }
            }
            doc.CloseDoc();
            fileReports.Add(JsonObject(
                "path", file,
                "open_error", err.ToString(),
                "doc_null", "false",
                "property_count", (names.Count - before).ToString()));
        }

        string json = "{"
            + "\"status\":\"PASS\","
            + "\"mode\":\"" + Escape(options.ContainsKey("folder") ? "folder" : "file") + "\","
            + "\"key_sha12\":\"" + Escape(Sha12(key)) + "\","
            + "\"file_count\":" + files.Count + ","
            + "\"property_count\":" + names.Count + ","
            + "\"properties\":[" + string.Join(",", names.Select(n => "\"" + Escape(n) + "\"")) + "],"
            + "\"files\":[" + string.Join(",", fileReports) + "]"
            + "}";
        Console.WriteLine(json);
        return 0;
    }

    private static Dictionary<string, string> ParseArgs(string[] args)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < args.Length; i += 2)
        {
            result[NormalizeOptionName(args[i])] = args[i + 1];
        }
        if (!result.ContainsKey("keyFile"))
        {
            throw new ArgumentException("--key-file is required");
        }
        if (!result.ContainsKey("file") && !result.ContainsKey("folder"))
        {
            throw new ArgumentException("--file or --folder is required");
        }
        return result;
    }

    private static string NormalizeOptionName(string value)
    {
        string name = value.TrimStart('-');
        if (name == "key-file") return "keyFile";
        return name;
    }

    private static List<string> ResolveFiles(Dictionary<string, string> options)
    {
        if (options.ContainsKey("file"))
        {
            return new List<string> { Path.GetFullPath(options["file"]) };
        }
        string root = Path.GetFullPath(options["folder"]);
        return Directory.EnumerateFiles(root, "*.*", SearchOption.AllDirectories)
            .Where(p => Extensions.Contains(Path.GetExtension(p), StringComparer.OrdinalIgnoreCase))
            .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    private static SwDmDocumentType DocumentType(string file)
    {
        string ext = Path.GetExtension(file).ToLowerInvariant();
        if (ext == ".sldprt") return SwDmDocumentType.swDmDocumentPart;
        if (ext == ".sldasm") return SwDmDocumentType.swDmDocumentAssembly;
        throw new ArgumentException("Unsupported SOLIDWORKS document type: " + file);
    }

    private static void AddNames(SortedSet<string> names, object raw)
    {
        Array values = raw as Array;
        if (values != null)
        {
            foreach (object value in values)
            {
                string text = Convert.ToString(value).Trim();
                if (text.Length > 0)
                {
                    names.Add(text);
                }
            }
        }
    }

    private static string JsonObject(params string[] parts)
    {
        var fields = new List<string>();
        for (int i = 0; i < parts.Length; i += 2)
        {
            string value = parts[i + 1];
            int parsed;
            bool literal = value == "true" || value == "false" || int.TryParse(value, out parsed);
            fields.Add("\"" + Escape(parts[i]) + "\":" + (literal ? value : "\"" + Escape(value) + "\""));
        }
        return "{" + string.Join(",", fields) + "}";
    }

    private static string Escape(string value)
    {
        return value.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }

    private static string Sha12(string value)
    {
        using (var sha = System.Security.Cryptography.SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "").Substring(0, 12).ToLowerInvariant();
        }
    }
}
'''


def sha12(data: bytes) -> str:
    return hashlib.sha256(data).hexdigest()[:12]


def resolve_key_file(arg: str | None) -> Path:
    value = arg or os.environ.get("SWTOOLS_SWDM_KEY_FILE")
    if value:
        return Path(value)
    default = Path(os.environ.get("ProgramData", r"C:\ProgramData")) / "SWTools" / "swdm.key"
    return default


def build_probe() -> Path:
    if not INTEROP.exists():
        raise SystemExit(f"SolidWorks Document Manager interop not found: {INTEROP}")
    if not CSC.exists():
        raise SystemExit(f"C# compiler not found: {CSC}")
    WORK_DIR.mkdir(parents=True, exist_ok=True)
    source = WORK_DIR / "SwdmPropertyImportLiveProbe.cs"
    exe = WORK_DIR / "SwdmPropertyImportLiveProbe.exe"
    source.write_text(CS_SOURCE, encoding="utf-8")
    shutil.copy2(INTEROP, WORK_DIR / INTEROP.name)
    subprocess.run(
        [
            str(CSC),
            "/nologo",
            f"/r:{INTEROP}",
            f"/out:{exe}",
            str(source),
        ],
        check=True,
    )
    return exe


def run_probe(exe: Path, key_file: Path, mode_path: Path, folder: bool) -> dict:
    command = [str(exe), "--key-file", str(key_file), "--folder" if folder else "--file", str(mode_path)]
    completed = subprocess.run(command, check=True, text=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE, encoding="utf-8")
    if completed.stderr.strip():
        raise SystemExit(completed.stderr.strip())
    return json.loads(completed.stdout)


def assert_properties(result: dict, expected: list[str]) -> None:
    properties = {str(item).casefold() for item in result.get("properties", [])}
    missing = [name for name in expected if name.casefold() not in properties]
    if missing:
        raise AssertionError(f"missing expected properties: {missing}")
    if result.get("property_count", 0) <= 0:
        raise AssertionError("no property names were imported")
    bad_files = [
        item
        for item in result.get("files", [])
        if item.get("open_error") != "swDmDocumentOpenErrorNone" or item.get("doc_null") is True
    ]
    if bad_files:
        raise AssertionError(f"SWDM open failures: {bad_files[:3]}")


def main(argv: list[str]) -> int:
    parser = argparse.ArgumentParser()
    parser.add_argument("--key-file", help="Local secret file with SWDM key. Defaults to SWTOOLS_SWDM_KEY_FILE or %ProgramData%\\SWTools\\swdm.key.")
    parser.add_argument("--file", type=Path, help="SOLIDWORKS file to import property names from.")
    parser.add_argument("--folder", type=Path, help="Folder to import property names from recursively.")
    parser.add_argument("--expect-name", action="append", default=["Разработал", "Наименование", "Обозначение", "Масса"])
    parser.add_argument("--json-out", type=Path)
    args = parser.parse_args(argv)

    if bool(args.file) == bool(args.folder):
        raise SystemExit("Specify exactly one of --file or --folder")

    key_file = resolve_key_file(args.key_file)
    if not key_file.exists():
        raise SystemExit(f"SWDM key secret file not found: {key_file}")

    key_bytes = key_file.read_bytes()
    exe = build_probe()
    result = run_probe(exe, key_file, args.folder or args.file, folder=bool(args.folder))
    assert_properties(result, args.expect_name)
    result["key_file_sha12"] = sha12(key_bytes)
    result["key_file_length"] = len(key_bytes)
    result["key_file_path"] = str(key_file)
    if args.json_out:
        args.json_out.parent.mkdir(parents=True, exist_ok=True)
        args.json_out.write_text(json.dumps(result, ensure_ascii=False, indent=2), encoding="utf-8")
    print(json.dumps({k: result[k] for k in ("status", "mode", "file_count", "property_count", "key_sha12")}, ensure_ascii=False))
    return 0


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
