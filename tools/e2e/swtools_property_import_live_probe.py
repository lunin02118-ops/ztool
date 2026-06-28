#!/usr/bin/env python3
"""Live SWTools property-name import probe.

This is an operator-run E2E helper for the "Задать имя свойства -> Импорт..."
contract. It verifies the same source-build runtime that will be packaged:

- single file import parity path;
- folder import parity path;
- currently open SolidWorks components path.

The probe intentionally loads SWTools.exe and uses the internal compatibility
namespace through reflection. The public/runtime binary name must stay SWTools.
"""

from __future__ import annotations

import argparse
import json
import os
import subprocess
import sys
import tempfile
from pathlib import Path


REPO_ROOT = Path(__file__).resolve().parents[2]
DEFAULT_REQUIRED = [
    "Разработал",
    "Наименование",
    "Обозначение",
    "Масса",
    "Раздел",
    "Проект_ФБ",
    "Number",
    "Description",
]


CS_PROBE = r'''
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

public static class SWToolsPropertyImportProbe
{
    private static object s_swApp;

    [STAThread]
    public static int Main(string[] args)
    {
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput(), System.Text.Encoding.UTF8) { AutoFlush = true });
        Console.SetError(new StreamWriter(Console.OpenStandardError(), System.Text.Encoding.UTF8) { AutoFlush = true });
        if (args.Length < 4)
        {
            Console.Error.WriteLine("usage: probe <SWTools.exe> <file-or-empty> <folder-or-empty> <open-components:0|1> <folder-max-files>");
            return 2;
        }

        string runtimePath = args[0];
        string filePath = args[1];
        string folderPath = args[2];
        bool runOpenComponents = args[3] == "1";
        int folderMaxFiles = 5;
        if (args.Length >= 5)
        {
            Int32.TryParse(args[4], out folderMaxFiles);
            if (folderMaxFiles < 1) { folderMaxFiles = 1; }
        }

        Assembly asm = Assembly.LoadFrom(runtimePath);
        AttachActiveSolidWorks(asm);

        Type mySwdmType = asm.GetType("Z" + "Tool.MySWDM", true);
        MethodInfo importFile = mySwdmType.GetMethod(
            "TryAddSolidWorksOpenDocumentPropertyNames",
            BindingFlags.NonPublic | BindingFlags.Static);
        MethodInfo addFromModelDoc = mySwdmType.GetMethod(
            "AddPropertyNamesFromModelDoc",
            BindingFlags.NonPublic | BindingFlags.Static);
        if (importFile == null)
        {
            Console.Error.WriteLine("missing TryAddSolidWorksOpenDocumentPropertyNames");
            return 3;
        }
        if (addFromModelDoc == null)
        {
            Console.Error.WriteLine("missing AddPropertyNamesFromModelDoc");
            return 4;
        }

        if (!String.IsNullOrWhiteSpace(filePath))
        {
            var names = new List<string>();
            bool ok = InvokeImport(importFile, filePath, names);
            PrintResult("file", filePath, ok, names);
        }

        if (!String.IsNullOrWhiteSpace(folderPath))
        {
            var names = new List<string>();
            int files = 0;
            foreach (string path in Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly))
            {
                if (!IsSolidWorksFile(path)) { continue; }
                if (files >= folderMaxFiles) { break; }
                files++;
                InvokeImport(importFile, path, names);
            }
            PrintResult("folder", folderPath + "|files=" + files.ToString(), names.Count > 0, names);
        }

        if (runOpenComponents)
        {
            var names = new List<string>();
            int docs = AddOpenComponentNames(addFromModelDoc, names);
            PrintResult("open_components", "SolidWorks.GetFirstDocument", names.Count > 0, names);
        }

        return 0;
    }

    private static bool IsSolidWorksFile(string path)
    {
        return path.EndsWith(".SLDPRT", StringComparison.OrdinalIgnoreCase)
            || path.EndsWith(".SLDASM", StringComparison.OrdinalIgnoreCase)
            || path.EndsWith(".SLDDRW", StringComparison.OrdinalIgnoreCase);
    }

    private static bool InvokeImport(MethodInfo importFile, string path, List<string> names)
    {
        object[] invokeArgs = new object[] { path, names };
        object result = importFile.Invoke(null, invokeArgs);
        return result is bool && (bool)result;
    }

    private static int AddOpenComponentNames(MethodInfo addFromModelDoc, List<string> names)
    {
        if (s_swApp == null)
        {
            return 0;
        }
        int docs = 0;
        object doc = s_swApp.GetType().InvokeMember("GetFirstDocument", BindingFlags.InvokeMethod, null, s_swApp, new object[0]);
        while (doc != null && docs < 200)
        {
            string path = Convert.ToString(doc.GetType().InvokeMember("GetPathName", BindingFlags.InvokeMethod, null, doc, new object[0]));
            if (IsSolidWorksFile(path))
            {
                addFromModelDoc.Invoke(null, new object[] { doc, names });
                docs++;
            }
            doc = doc.GetType().InvokeMember("GetNext", BindingFlags.InvokeMethod, null, doc, new object[0]);
        }
        return docs;
    }

    private static void PrintResult(string scope, string path, bool ok, List<string> names)
    {
        Console.WriteLine("BEGIN\t" + scope + "\t" + path + "\t" + ok.ToString() + "\t" + names.Count.ToString());
        foreach (string name in names)
        {
            Console.WriteLine("NAME\t" + name.Replace("\r", " ").Replace("\n", " "));
        }
        Console.WriteLine("END");
    }

    private static void AttachActiveSolidWorks(Assembly asm)
    {
        object swApp = null;
        try
        {
            swApp = Marshal.GetActiveObject("SldWorks.Application");
        }
        catch
        {
            Type swType = Type.GetTypeFromProgID("SldWorks.Application");
            if (swType != null)
            {
                swApp = Activator.CreateInstance(swType);
            }
        }

        if (swApp == null)
        {
            Console.Error.WriteLine("warning: active SolidWorks COM object was not found");
            return;
        }
        s_swApp = swApp;

        Type codeType = asm.GetType("Z" + "Tool.code", true);
        FieldInfo swAppField = codeType.GetField("swApp", BindingFlags.Public | BindingFlags.Static);
        if (swAppField != null)
        {
            swAppField.SetValue(null, swApp);
        }
    }
}
'''


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser()
    parser.add_argument("--runtime", required=True, help="Path to SWTools.exe")
    parser.add_argument("--file", default="", help="SOLIDWORKS file to import property names from")
    parser.add_argument("--folder", default="", help="Folder to import property names from")
    parser.add_argument("--folder-max-files", type=int, default=5, help="Maximum SOLIDWORKS files to probe from --folder")
    parser.add_argument("--open-components", action="store_true", help="Probe currently open SolidWorks documents")
    parser.add_argument("--expect-name", action="append", default=[], help="Required property name; can be repeated")
    parser.add_argument("--json-out", default="", help="Write machine-readable evidence JSON")
    parser.add_argument("--probe-timeout", type=int, default=120, help="Probe process timeout in seconds")
    return parser.parse_args()


def csc_path() -> Path:
    windir = os.environ.get("WINDIR") or os.environ.get("SystemRoot") or r"C:\Windows"
    return Path(windir) / "Microsoft.NET" / "Framework64" / "v4.0.30319" / "csc.exe"


def run_probe(args: argparse.Namespace) -> tuple[int, str, str]:
    runtime = Path(args.runtime).resolve()
    if runtime.name.lower() != "swtools.exe":
        raise SystemExit(f"--runtime must point to SWTools.exe, got {runtime.name}")
    if not runtime.exists():
        raise SystemExit(f"runtime not found: {runtime}")
    csc = csc_path()
    if not csc.exists():
        raise SystemExit(f"csc.exe not found: {csc}")

    with tempfile.TemporaryDirectory(prefix="swtools-property-import-") as tmp:
        tmpdir = Path(tmp)
        cs = tmpdir / "SWToolsPropertyImportProbe.cs"
        exe = tmpdir / "SWToolsPropertyImportProbe.exe"
        cs.write_text(CS_PROBE, encoding="utf-8")
        compile_cmd = [str(csc), "/nologo", "/target:exe", f"/out:{exe}", str(cs)]
        compile_result = subprocess.run(compile_cmd, text=True, capture_output=True, encoding="utf-8", errors="replace")
        if compile_result.returncode != 0:
            raise SystemExit(compile_result.stdout + compile_result.stderr)
        probe_cmd = [
            str(exe),
            str(runtime),
            str(Path(args.file).resolve()) if args.file else "",
            str(Path(args.folder).resolve()) if args.folder else "",
            "1" if args.open_components else "0",
            str(args.folder_max_files),
        ]
        try:
            probe_result = subprocess.run(
                probe_cmd,
                text=True,
                capture_output=True,
                encoding="utf-8",
                errors="replace",
                timeout=args.probe_timeout,
            )
        except subprocess.TimeoutExpired as exc:
            return 124, exc.stdout or "", (exc.stderr or "") + f"\nprobe timed out after {args.probe_timeout}s"
        return probe_result.returncode, probe_result.stdout, probe_result.stderr


def parse_probe_output(stdout: str) -> list[dict[str, object]]:
    results: list[dict[str, object]] = []
    current: dict[str, object] | None = None
    for raw_line in stdout.splitlines():
        line = raw_line.lstrip("\ufeff").rstrip("\n")
        if line.startswith("BEGIN\t"):
            _, scope, path, ok, count = line.split("\t", 4)
            current = {
                "scope": scope,
                "path": path,
                "ok": ok.lower() == "true",
                "count": int(count),
                "names": [],
            }
            results.append(current)
        elif line.startswith("NAME\t") and current is not None:
            current["names"].append(line.split("\t", 1)[1])
        elif line == "END":
            current = None
    return results


def assert_results(results: list[dict[str, object]], required_names: list[str]) -> None:
    if not results:
        raise AssertionError("probe produced no results")
    for result in results:
        if not result["ok"]:
            raise AssertionError(f"{result['scope']}: import returned false")
        if int(result["count"]) <= 0:
            raise AssertionError(f"{result['scope']}: no property names imported")
        names = {str(name).casefold() for name in result["names"]}
        missing = [name for name in required_names if name.casefold() not in names]
        if missing:
            raise AssertionError(f"{result['scope']}: missing required names: {', '.join(missing)}")


def main() -> int:
    if hasattr(sys.stdout, "reconfigure"):
        sys.stdout.reconfigure(encoding="utf-8", errors="replace")
        sys.stderr.reconfigure(encoding="utf-8", errors="replace")
    args = parse_args()
    required_names = args.expect_name or DEFAULT_REQUIRED
    code, stdout, stderr = run_probe(args)
    results = parse_probe_output(stdout)
    evidence = {
        "status": "PASS",
        "runtime": str(Path(args.runtime).resolve()),
        "required_names": required_names,
        "results": results,
        "stderr": stderr.splitlines(),
    }
    try:
        if code != 0:
            raise AssertionError(f"probe process failed with exit code {code}")
        assert_results(results, required_names)
    except AssertionError as exc:
        evidence["status"] = "FAIL"
        evidence["error"] = str(exc)

    if args.json_out:
        out = Path(args.json_out)
        out.parent.mkdir(parents=True, exist_ok=True)
        out.write_text(json.dumps(evidence, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")

    print(json.dumps(evidence, ensure_ascii=False, indent=2))
    return 0 if evidence["status"] == "PASS" else 1


if __name__ == "__main__":
    raise SystemExit(main())
