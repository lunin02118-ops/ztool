#!/usr/bin/env python3
"""Capture curated SWTools visual-localization screenshots with JSON evidence.

The tool intentionally does not claim visual FULL PASS. It captures visible
windows, records runtime/process identity and extracts UIA visible text so a
reviewer can reject visible Han or clipped/dirty frames with evidence.
"""

from __future__ import annotations

import argparse
import datetime as dt
import hashlib
import importlib
import json
import re
import subprocess
import sys
from dataclasses import dataclass
from pathlib import Path
from typing import Any


def require_module(name: str) -> Any:
    try:
        return importlib.import_module(name)
    except Exception as exc:  # pragma: no cover - live environment guard
        raise SystemExit(f"Missing Python module '{name}': {exc}") from exc


psutil = require_module("psutil")
Desktop = require_module("pywinauto").Desktop
Image = require_module("PIL.Image")
ImageDraw = require_module("PIL.ImageDraw")
ImageGrab = require_module("PIL.ImageGrab")


HAN_RE = re.compile(r"[\u3400-\u4DBF\u4E00-\u9FFF\uF900-\uFAFF]")


@dataclass(frozen=True)
class Surface:
    surface_id: str
    title: str
    process: str
    window_contains: str
    required: bool = True
    notes: str = ""
    han_policy: str = "fail"
    process_names: tuple[str, ...] = ()
    text_contains: tuple[str, ...] = ()
    forbidden_text: tuple[str, ...] = ()


DEFAULT_SURFACES: list[Surface] = [
    Surface("L-01", "Main window", "SWTools.exe", "SWTools", True, "Ribbon + table after S7", "fail"),
    Surface(
        "L-13",
        "SolidWorks add-in",
        "SLDWORKS.exe",
        "SOLIDWORKS",
        True,
        "SWTools CommandManager tab/buttons; host SolidWorks model-tree Han is recorded for manual review",
        "record_only",
    ),
]


def sha256(path: Path) -> str:
    return hashlib.sha256(path.read_bytes()).hexdigest().upper()


def normalize_process_name(name: str) -> str:
    return name.lower().removesuffix(".exe") + ".exe"


def process_info(pid: int) -> dict[str, Any]:
    try:
        proc = psutil.Process(pid)
        return {
            "pid": pid,
            "name": proc.name(),
            "path": proc.exe(),
            "command_line": " ".join(proc.cmdline()),
        }
    except Exception as exc:
        return {"pid": pid, "error": str(exc)}


def repo_commit() -> str | None:
    try:
        completed = subprocess.run(
            ["git", "rev-parse", "HEAD"],
            check=True,
            stdout=subprocess.PIPE,
            stderr=subprocess.DEVNULL,
            text=True,
        )
        return completed.stdout.strip()
    except Exception:
        return None


def window_process_id(win: Any) -> int | None:
    try:
        return int(win.process_id())
    except Exception:
        pass
    try:
        return int(win.element_info.process_id)
    except Exception:
        return None


def rect_to_dict(rect: Any) -> dict[str, int]:
    return {
        "left": int(rect.left),
        "top": int(rect.top),
        "right": int(rect.right),
        "bottom": int(rect.bottom),
        "width": int(rect.width()),
        "height": int(rect.height()),
    }


def visible_texts(win: Any, limit: int = 500) -> list[str]:
    texts: list[str] = []
    try:
        title = win.window_text().strip()
        if title:
            texts.append(title)
    except Exception:
        pass
    try:
        descendants = win.descendants()
    except Exception:
        descendants = []
    for child in descendants:
        try:
            text = child.window_text().strip()
        except Exception:
            continue
        if text and text not in texts:
            texts.append(text)
        if len(texts) >= limit:
            break
    return texts


def surface_process_names(surface: Surface) -> set[str]:
    names = surface.process_names or (surface.process,)
    return {normalize_process_name(name) for name in names if str(name).strip()}


def surface_text_matches(surface: Surface, title: str, texts: list[str]) -> bool:
    if surface.window_contains and surface.window_contains.lower() not in title.lower():
        return False
    if not surface.text_contains:
        return True
    haystack = "\n".join([title, *texts]).lower()
    return all(value.lower() in haystack for value in surface.text_contains)


def find_window(surface: Surface) -> Any | None:
    expected_processes = surface_process_names(surface)
    candidates: list[tuple[int, Any]] = []
    # Prefer win32 wrappers for screenshots/text snapshots: full UIA traversal of
    # the SolidWorks host can block on large assemblies. UIA remains a fallback
    # for popup/menu surfaces that are not exposed well through win32.
    for backend in ("win32", "uia"):
        try:
            windows = Desktop(backend=backend).windows()
        except Exception:
            continue
        for win in windows:
            pid = window_process_id(win)
            if pid is None:
                continue
            try:
                proc_name = psutil.Process(pid).name()
                title = win.window_text().strip()
                rect = win.rectangle()
            except Exception:
                continue
            if normalize_process_name(proc_name) not in expected_processes:
                continue
            texts = visible_texts(win, limit=150) if surface.text_contains else []
            if not surface_text_matches(surface, title, texts):
                continue
            area = max(0, rect.width()) * max(0, rect.height())
            if area > 0:
                candidates.append((area, win))
    if not candidates:
        return None
    candidates.sort(key=lambda item: item[0], reverse=True)
    return candidates[0][1]


def capture_window(win: Any, output: Path) -> dict[str, Any]:
    rect = win.rectangle()
    bbox = (int(rect.left), int(rect.top), int(rect.right), int(rect.bottom))
    image = ImageGrab.grab(bbox=bbox)
    output.parent.mkdir(parents=True, exist_ok=True)
    image.save(output)
    return {
        "path": str(output),
        "sha256": sha256(output),
        "width": image.width,
        "height": image.height,
        "rectangle": rect_to_dict(rect),
    }


def safe_file_stem(value: str) -> str:
    stem = re.sub(r"[^A-Za-z0-9_.-]+", "-", value.strip())
    return stem.strip("-") or "surface"


def is_under(path: str | None, root: Path | None) -> bool | None:
    if root is None or not path:
        return None
    try:
        child = Path(path).resolve()
        parent = root.resolve()
        return child == parent or parent in child.parents
    except Exception:
        return False


def load_surfaces(path: Path | None) -> list[Surface]:
    if path is None:
        return DEFAULT_SURFACES
    data = json.loads(path.read_text(encoding="utf-8"))
    global_forbidden = tuple(str(value) for value in data.get("forbidden_text", []) if str(value).strip())
    surfaces: list[Surface] = []
    for item in data.get("surfaces", []):
        item_forbidden = item.get("forbidden_text", global_forbidden)
        surfaces.append(
            Surface(
                surface_id=str(item["id"]),
                title=str(item["title"]),
                process=str(item["process"]),
                window_contains=str(item.get("window_contains", "")),
                required=bool(item.get("required", True)),
                notes=str(item.get("notes", "")),
                han_policy=str(item.get("han_policy", "fail")),
                process_names=tuple(str(value) for value in item.get("process_names", []) if str(value).strip()),
                text_contains=tuple(str(value) for value in item.get("text_contains", []) if str(value).strip()),
                forbidden_text=tuple(str(value) for value in item_forbidden if str(value).strip()),
            )
        )
    return surfaces


def missing_item(surface: Surface) -> dict[str, Any]:
    return {
        "id": surface.surface_id,
        "title": surface.title,
        "process": surface.process,
        "process_names": sorted(surface_process_names(surface)),
        "window_contains": surface.window_contains,
        "text_contains": list(surface.text_contains),
        "forbidden_text": list(surface.forbidden_text),
        "required": surface.required,
        "notes": surface.notes,
        "han_policy": surface.han_policy,
        "status": "MISSING",
        "error": "matching top-level window not found",
    }


def profile_item(surface: Surface) -> dict[str, Any]:
    return {
        "id": surface.surface_id,
        "title": surface.title,
        "process": surface.process,
        "process_names": sorted(surface_process_names(surface)),
        "window_contains": surface.window_contains,
        "text_contains": list(surface.text_contains),
        "forbidden_text": list(surface.forbidden_text),
        "required": surface.required,
        "notes": surface.notes,
        "han_policy": surface.han_policy,
    }


def merge_previous_items(
    profile_surfaces: list[Surface],
    captured_items: list[dict[str, Any]],
    previous_manifest: Path | None,
    expected_runtime_dir: Path | None,
) -> tuple[list[dict[str, Any]], list[str]]:
    warnings: list[str] = []
    by_id: dict[str, dict[str, Any]] = {}
    if previous_manifest is not None:
        previous = json.loads(previous_manifest.read_text(encoding="utf-8"))
        previous_runtime = previous.get("expected_runtime_dir")
        current_runtime = str(expected_runtime_dir) if expected_runtime_dir else None
        if previous_runtime and current_runtime and previous_runtime != current_runtime:
            raise SystemExit(
                "Cannot merge visual localization manifests from different runtimes: "
                f"previous={previous_runtime}; current={current_runtime}"
            )
        for item in previous.get("surfaces", []):
            surface_id = str(item.get("id", ""))
            if surface_id:
                by_id[surface_id] = item
    for item in captured_items:
        surface_id = str(item.get("id", ""))
        if not surface_id:
            continue
        previous_item = by_id.get(surface_id)
        if item.get("status") == "MISSING" and previous_item and previous_item.get("status") == "CAPTURED":
            preserved = dict(previous_item)
            preserved["last_attempt_status"] = "MISSING"
            preserved["last_attempt_error"] = item.get("error")
            by_id[surface_id] = preserved
            warnings.append(f"{surface_id}: current attempt missing; preserved previous captured evidence")
            continue
        by_id[surface_id] = item

    merged: list[dict[str, Any]] = []
    for surface in profile_surfaces:
        item = dict(by_id.get(surface.surface_id, missing_item(surface)))
        item.update({key: value for key, value in profile_item(surface).items() if key not in item})
        merged.append(item)
    return merged, warnings


def write_contact_sheet(items: list[dict[str, Any]], output: Path) -> None:
    captured = [item for item in items if item.get("status") == "CAPTURED"]
    if not captured:
        return
    thumbs: list[tuple[dict[str, Any], Any]] = []
    thumb_w = 360
    thumb_h = 220
    for item in captured:
        image = Image.open(item["screenshot"]["path"]).convert("RGB")
        image.thumbnail((thumb_w, thumb_h))
        canvas = Image.new("RGB", (thumb_w, thumb_h), "white")
        x = (thumb_w - image.width) // 2
        y = (thumb_h - image.height) // 2
        canvas.paste(image, (x, y))
        thumbs.append((item, canvas))
    cols = 2
    label_h = 44
    rows = (len(thumbs) + cols - 1) // cols
    sheet = Image.new("RGB", (cols * thumb_w, rows * (thumb_h + label_h)), "white")
    draw = ImageDraw.Draw(sheet)
    for index, (item, thumb) in enumerate(thumbs):
        col = index % cols
        row = index // cols
        x = col * thumb_w
        y = row * (thumb_h + label_h)
        sheet.paste(thumb, (x, y + label_h))
        label = f"{item['id']} {item['title']} | Han={len(item.get('visible_han_texts', []))}"
        draw.text((x + 8, y + 8), label[:70], fill=(0, 0, 0))
    output.parent.mkdir(parents=True, exist_ok=True)
    sheet.save(output)


def run() -> int:
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")
    parser = argparse.ArgumentParser()
    parser.add_argument("--output-dir", required=True, type=Path)
    parser.add_argument("--surface-file", type=Path)
    parser.add_argument(
        "--surface-id",
        action="append",
        dest="surface_ids",
        help="Capture only this surface id. Can be passed multiple times. Combine with --merge-manifest for cumulative evidence.",
    )
    parser.add_argument(
        "--merge-manifest",
        type=Path,
        help="Merge current capture into an existing manifest from the same runtime.",
    )
    parser.add_argument(
        "--expected-runtime-dir",
        type=Path,
        help="If provided, captured SWTools.exe must run from this runtime directory.",
    )
    parser.add_argument(
        "--require-all-captured",
        action="store_true",
        help="Fail if any required surface is missing. Use for release/owner evidence runs.",
    )
    args = parser.parse_args()

    output_dir = args.output_dir.resolve()
    screenshots_dir = output_dir / "screenshots"
    expected_runtime_dir = args.expected_runtime_dir.resolve() if args.expected_runtime_dir else None
    output_dir.mkdir(parents=True, exist_ok=True)
    surfaces = load_surfaces(args.surface_file)
    surface_ids = set(args.surface_ids or [])
    if surface_ids:
        known_ids = {surface.surface_id for surface in surfaces}
        unknown = sorted(surface_ids - known_ids)
        if unknown:
            raise SystemExit(f"Unknown visual localization surface id(s): {', '.join(unknown)}")
        capture_surfaces = [surface for surface in surfaces if surface.surface_id in surface_ids]
    else:
        capture_surfaces = surfaces

    captured_items: list[dict[str, Any]] = []
    for surface in capture_surfaces:
        item: dict[str, Any] = profile_item(surface)
        win = find_window(surface)
        if win is None:
            captured_items.append(missing_item(surface))
            continue
        pid = window_process_id(win)
        title = win.window_text().strip()
        texts = visible_texts(win)
        han_texts = sorted({text for text in texts if HAN_RE.search(text)})
        forbidden_texts = sorted(
            {
                text
                for text in texts
                for forbidden in surface.forbidden_text
                if forbidden.lower() in text.lower()
            }
        )
        proc = process_info(pid or -1)
        runtime_path_match = None
        if "swtools.exe" in surface_process_names(surface):
            runtime_path_match = is_under(proc.get("path"), expected_runtime_dir)
        screenshot = capture_window(win, screenshots_dir / f"{surface.surface_id}-{safe_file_stem(surface.title)}.png")
        item.update(
            {
                "status": "CAPTURED",
                "window_title": title,
                "process_info": proc,
                "runtime_path_match": runtime_path_match,
                "screenshot": screenshot,
                "visible_text_count": len(texts),
                "visible_text_sample": texts[:120],
                "visible_han_texts": han_texts,
                "forbidden_texts": forbidden_texts,
            }
        )
        captured_items.append(item)

    merge_warnings: list[str] = []
    if args.merge_manifest is not None:
        items, merge_warnings = merge_previous_items(
            surfaces,
            captured_items,
            args.merge_manifest.resolve(),
            expected_runtime_dir,
        )
    else:
        items = captured_items

    missing_required = [item["id"] for item in items if item.get("required") and item.get("status") != "CAPTURED"]
    han_surface_ids = [item["id"] for item in items if item.get("visible_han_texts")]
    blocking_han_surface_ids = [
        item["id"]
        for item in items
        if item.get("visible_han_texts") and item.get("han_policy", "fail") != "record_only"
    ]
    recorded_han_surface_ids = [
        item["id"]
        for item in items
        if item.get("visible_han_texts") and item.get("han_policy") == "record_only"
    ]
    runtime_mismatch_ids = [
        item["id"] for item in items if item.get("runtime_path_match") is False
    ]
    forbidden_text_surface_ids = [item["id"] for item in items if item.get("forbidden_texts")]
    status = "PASS"
    if blocking_han_surface_ids or runtime_mismatch_ids or forbidden_text_surface_ids:
        status = "FAIL"
    elif missing_required or recorded_han_surface_ids:
        status = "PASS_WITH_WARN"

    manifest = {
        "status": status,
        "production_go_allowed": False,
        "created_utc": dt.datetime.now(dt.timezone.utc).isoformat(),
        "git_commit": repo_commit(),
        "expected_runtime_dir": str(expected_runtime_dir) if expected_runtime_dir else None,
        "summary": {
            "surface_count": len(items),
            "captured_count": sum(1 for item in items if item.get("status") == "CAPTURED"),
            "attempted_surface_ids": [surface.surface_id for surface in capture_surfaces],
            "missing_required": missing_required,
            "han_surface_ids": han_surface_ids,
            "blocking_han_surface_ids": blocking_han_surface_ids,
            "recorded_han_surface_ids": recorded_han_surface_ids,
            "runtime_mismatch_ids": runtime_mismatch_ids,
            "forbidden_text_surface_ids": forbidden_text_surface_ids,
            "merge_warnings": merge_warnings,
        },
        "surfaces": items,
    }
    manifest_path = output_dir / "visual-localization-manifest.json"
    manifest_path.write_text(json.dumps(manifest, ensure_ascii=False, indent=2), encoding="utf-8")
    write_contact_sheet(items, output_dir / "visual-localization-contact-sheet.jpg")
    print(json.dumps(manifest, ensure_ascii=False, indent=2))
    if status == "FAIL":
        return 1
    if args.require_all_captured and missing_required:
        return 1
    return 0


if __name__ == "__main__":
    raise SystemExit(run())
