#!/usr/bin/env python3
"""Compare original CHM screenshots with a recaptured RU screenshot set."""

from __future__ import annotations

import argparse
import hashlib
import json
import math
import sys
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable

try:
    from PIL import Image, ImageChops, ImageDraw, ImageFont, ImageOps
except ImportError as exc:  # pragma: no cover - environment guard
    raise SystemExit(
        "Pillow is required: python -m pip install pillow"
    ) from exc


IMAGE_EXTS = {".gif", ".jpg", ".jpeg", ".png"}

DEFAULT_ALLOW_UNCHANGED = {
    "basic/connect-sw.files/image005.png",
    "basic/material-library.files/image003.png",
    "basic/material-library.files/image004.jpg",
}


@dataclass(frozen=True)
class ImageInfo:
    path: Path
    rel: str
    sha256: str
    width: int
    height: int
    mode: str

    @property
    def aspect(self) -> float:
        return self.width / self.height if self.height else math.inf


@dataclass
class CompareResult:
    rel: str
    original: ImageInfo | None
    candidate: ImageInfo | None
    status: str
    issues: list[str]
    aspect_delta: float | None = None


def normalize_rel(path: Path) -> str:
    return path.as_posix()


def sha256_file(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as fh:
        for chunk in iter(lambda: fh.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def iter_images(root: Path) -> Iterable[Path]:
    for path in root.rglob("*"):
        if path.is_file() and path.suffix.lower() in IMAGE_EXTS:
            yield path


def open_first_frame(path: Path) -> Image.Image:
    im = Image.open(path)
    try:
        im.seek(0)
    except EOFError:
        pass
    return im.convert("RGB")


def image_info(root: Path, path: Path) -> ImageInfo:
    rel = normalize_rel(path.relative_to(root))
    with open_first_frame(path) as im:
        width, height = im.size
        mode = im.mode
    return ImageInfo(
        path=path,
        rel=rel,
        sha256=sha256_file(path),
        width=width,
        height=height,
        mode=mode,
    )


def load_inventory(root: Path) -> dict[str, ImageInfo]:
    return {normalize_rel(p.relative_to(root)): image_info(root, p) for p in iter_images(root)}


def compare_sets(
    original_root: Path,
    candidate_root: Path,
    *,
    allow_unchanged: set[str],
    aspect_tolerance: float,
    area_ratio_warning: float,
) -> list[CompareResult]:
    original = load_inventory(original_root)
    candidate = load_inventory(candidate_root)
    all_rels = sorted(set(original) | set(candidate))
    results: list[CompareResult] = []

    # Detect candidate frames whose pixels were reused for several manual slots.
    # The geometry checks below pass such frames as long as the dimensions line
    # up, so a single screenshot copy-pasted across distinct manual sections
    # would otherwise be reported as PASS even though its content is wrong for
    # all but (at most) one slot. Reuse is only legitimate when the ORIGINAL
    # CHM also shipped the same byte-identical image in those slots, so we flag
    # a duplicate only when the matching originals differ from each other.
    by_cand_sha: dict[str, list[str]] = {}
    for rel in all_rels:
        c = candidate.get(rel)
        if c is not None:
            by_cand_sha.setdefault(c.sha256, []).append(rel)
    dup_partners: dict[str, list[str]] = {}
    for rels in by_cand_sha.values():
        if len(rels) < 2:
            continue
        orig_tokens = {
            original[r].sha256 if r in original else f"__missing__:{r}"
            for r in rels
        }
        if len(orig_tokens) <= 1:
            continue  # originals identical too -> reuse mirrors the original
        for rel in rels:
            dup_partners[rel] = sorted(x for x in rels if x != rel)

    for rel in all_rels:
        o = original.get(rel)
        c = candidate.get(rel)
        issues: list[str] = []
        status = "PASS"
        aspect_delta = None

        if o is None:
            issues.append("extra_candidate_file")
            status = "WARN"
        elif c is None:
            issues.append("missing_candidate_file")
            status = "FAIL"
        else:
            if o.path.suffix.lower() != c.path.suffix.lower():
                issues.append("extension_changed")
                status = "FAIL"
            if o.sha256 == c.sha256 and rel not in allow_unchanged:
                issues.append("unchanged_not_allowlisted")
                status = "FAIL"

            aspect_delta = abs(o.aspect - c.aspect) / max(o.aspect, c.aspect)
            if aspect_delta > aspect_tolerance:
                issues.append(f"aspect_delta={aspect_delta:.3f}")
                status = "FAIL"

            o_area = max(o.width * o.height, 1)
            c_area = max(c.width * c.height, 1)
            area_ratio = c_area / o_area
            if area_ratio > area_ratio_warning or area_ratio < 1 / area_ratio_warning:
                issues.append(f"area_ratio={area_ratio:.2f}")
                if status == "PASS":
                    status = "WARN"

            if rel in dup_partners:
                issues.append(
                    "duplicate_candidate_shares_content_with="
                    + ",".join(dup_partners[rel])
                )
                status = "FAIL"

        results.append(CompareResult(rel, o, c, status, issues, aspect_delta))

    return results


def fit_thumb(path: Path, size: tuple[int, int]) -> Image.Image:
    try:
        with open_first_frame(path) as im:
            return ImageOps.contain(im, size).copy()
    except Exception:
        im = Image.new("RGB", size, "white")
        return im


def diff_thumb(original: Path, candidate: Path, size: tuple[int, int]) -> Image.Image:
    try:
        with open_first_frame(original) as o, open_first_frame(candidate) as c:
            c2 = c.resize(o.size)
            diff = ImageChops.difference(o, c2)
            diff = ImageOps.autocontrast(diff)
            return ImageOps.contain(diff, size).copy()
    except Exception:
        return Image.new("RGB", size, "white")


def draw_wrapped(draw: ImageDraw.ImageDraw, text: str, xy: tuple[int, int], width: int) -> None:
    font = ImageFont.load_default()
    words = text.replace("\\", "/").split("/")
    lines: list[str] = []
    current = ""
    for word in words:
        candidate = word if not current else f"{current}/{word}"
        if draw.textlength(candidate, font=font) <= width:
            current = candidate
        else:
            if current:
                lines.append(current)
            current = word
    if current:
        lines.append(current)
    y = xy[1]
    for line in lines[:4]:
        draw.text((xy[0], y), line, fill="black", font=font)
        y += 12


def write_contact_sheet(results: list[CompareResult], out_path: Path) -> None:
    thumb = (220, 140)
    row_h = 190
    text_w = 430
    pad = 12
    cols_w = thumb[0] * 3 + text_w + pad * 5
    height = max(row_h * len(results) + pad, row_h + pad)
    sheet = Image.new("RGB", (cols_w, height), "white")
    draw = ImageDraw.Draw(sheet)
    font = ImageFont.load_default()

    for idx, result in enumerate(results):
        y = pad + idx * row_h
        x = pad
        status_color = {"PASS": "#1f8f3a", "WARN": "#b7791f", "FAIL": "#c53030"}[result.status]
        draw.rectangle((0, y - 4, cols_w, y + row_h - 8), outline="#dddddd")
        draw.text((x, y), result.status, fill=status_color, font=font)
        draw_wrapped(draw, result.rel, (x, y + 18), text_w - 20)
        if result.issues:
            draw_wrapped(draw, ", ".join(result.issues), (x, y + 74), text_w - 20)
        if result.original and result.candidate and result.aspect_delta is not None:
            draw.text((x, y + 130), f"aspect delta: {result.aspect_delta:.3f}", fill="black", font=font)

        x += text_w + pad
        if result.original:
            im = fit_thumb(result.original.path, thumb)
            sheet.paste(im, (x, y + 20))
            draw.text((x, y), f"orig {result.original.width}x{result.original.height}", fill="black", font=font)
        x += thumb[0] + pad
        if result.candidate:
            im = fit_thumb(result.candidate.path, thumb)
            sheet.paste(im, (x, y + 20))
            draw.text((x, y), f"ru {result.candidate.width}x{result.candidate.height}", fill="black", font=font)
        x += thumb[0] + pad
        if result.original and result.candidate:
            im = diff_thumb(result.original.path, result.candidate.path, thumb)
            sheet.paste(im, (x, y + 20))
            draw.text((x, y), "diff", fill="black", font=font)

    out_path.parent.mkdir(parents=True, exist_ok=True)
    sheet.save(out_path, quality=92)


def write_reports(results: list[CompareResult], out_dir: Path) -> None:
    out_dir.mkdir(parents=True, exist_ok=True)
    data = []
    for r in results:
        data.append(
            {
                "path": r.rel,
                "status": r.status,
                "issues": r.issues,
                "aspect_delta": r.aspect_delta,
                "original": None
                if r.original is None
                else {
                    "sha256": r.original.sha256,
                    "width": r.original.width,
                    "height": r.original.height,
                },
                "candidate": None
                if r.candidate is None
                else {
                    "sha256": r.candidate.sha256,
                    "width": r.candidate.width,
                    "height": r.candidate.height,
                },
            }
        )

    (out_dir / "manual_screenshot_compare.json").write_text(
        json.dumps(data, ensure_ascii=False, indent=2),
        encoding="utf-8",
    )

    total = len(results)
    failed = sum(1 for r in results if r.status == "FAIL")
    warned = sum(1 for r in results if r.status == "WARN")
    passed = sum(1 for r in results if r.status == "PASS")
    overall = "PASS" if failed == 0 else "FAIL"

    lines = [
        "# Manual Screenshot Frame Compare",
        "",
        f"Overall: **{overall}**",
        "",
        f"- Total: {total}",
        f"- PASS: {passed}",
        f"- WARN: {warned}",
        f"- FAIL: {failed}",
        "",
        "Contact sheet: `manual_screenshot_compare_contact_sheet.jpg`",
        "",
        "| Status | File | Issues | Original | Candidate |",
        "|---|---|---|---|---|",
    ]
    for r in results:
        o_dims = "" if r.original is None else f"{r.original.width}x{r.original.height}"
        c_dims = "" if r.candidate is None else f"{r.candidate.width}x{r.candidate.height}"
        issues = ", ".join(r.issues)
        lines.append(f"| {r.status} | `{r.rel}` | {issues} | {o_dims} | {c_dims} |")
    (out_dir / "manual_screenshot_compare.md").write_text("\n".join(lines) + "\n", encoding="utf-8")

    write_contact_sheet(results, out_dir / "manual_screenshot_compare_contact_sheet.jpg")


def parse_args(argv: list[str]) -> argparse.Namespace:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--original", required=True, type=Path, help="Original extracted CHM source root")
    parser.add_argument("--candidate", required=True, type=Path, help="Recaptured RU CHM source root")
    parser.add_argument("--out", required=True, type=Path, help="Report output directory")
    parser.add_argument(
        "--allow-unchanged",
        action="append",
        default=[],
        help="Relative image path allowed to stay byte-identical; can be repeated",
    )
    parser.add_argument(
        "--aspect-tolerance",
        type=float,
        default=0.15,
        help="Relative aspect-ratio delta allowed before FAIL",
    )
    parser.add_argument(
        "--area-ratio-warning",
        type=float,
        default=4.0,
        help="Warn when candidate area differs by more than this factor",
    )
    parser.add_argument(
        "--no-fail",
        action="store_true",
        help="Always exit 0 after writing reports",
    )
    return parser.parse_args(argv)


def main(argv: list[str]) -> int:
    args = parse_args(argv)
    original = args.original.resolve()
    candidate = args.candidate.resolve()
    out_dir = args.out.resolve()
    if not original.is_dir():
        raise SystemExit(f"Original directory not found: {original}")
    if not candidate.is_dir():
        raise SystemExit(f"Candidate directory not found: {candidate}")

    allow_unchanged = set(DEFAULT_ALLOW_UNCHANGED)
    allow_unchanged.update(p.replace("\\", "/") for p in args.allow_unchanged)

    results = compare_sets(
        original,
        candidate,
        allow_unchanged=allow_unchanged,
        aspect_tolerance=args.aspect_tolerance,
        area_ratio_warning=args.area_ratio_warning,
    )
    write_reports(results, out_dir)

    failed = sum(1 for r in results if r.status == "FAIL")
    warned = sum(1 for r in results if r.status == "WARN")
    print(f"Compared {len(results)} images: FAIL={failed}, WARN={warned}, report={out_dir}")
    return 0 if args.no_fail or failed == 0 else 1


if __name__ == "__main__":
    raise SystemExit(main(sys.argv[1:]))
