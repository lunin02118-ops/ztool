#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""Extract user-string (#US heap) literals from a .NET assembly (PE/CLI).

Pure-Python, no dependencies, cross-platform. Used by check_string_invariants.py
to compare the original vendor binary against the localized one at the level of
*string literals* (ECMA-335 #US heap), independent of how the bytes are laid out.

The #US heap stores each ldstr literal as: a compressed-integer byte length,
then that many bytes = UTF-16LE chars + 1 trailing flag byte.
"""
import struct
import sys

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")


def _u16(b, o):
    return struct.unpack_from("<H", b, o)[0]


def _u32(b, o):
    return struct.unpack_from("<I", b, o)[0]


def _read_compressed_uint(b, o):
    """ECMA-335 II.23.2 compressed unsigned integer. Returns (value, nbytes)."""
    b0 = b[o]
    if b0 & 0x80 == 0:
        return b0, 1
    if b0 & 0xC0 == 0x80:
        return ((b0 & 0x3F) << 8) | b[o + 1], 2
    if b0 & 0xE0 == 0xC0:
        return (((b0 & 0x1F) << 24) | (b[o + 1] << 16) |
                (b[o + 2] << 8) | b[o + 3]), 4
    raise ValueError("bad compressed integer at %d" % o)


def _sections(data):
    pe = _u32(data, 0x3C)
    if data[pe:pe + 4] != b"PE\x00\x00":
        raise ValueError("not a PE file")
    coff = pe + 4
    num_sections = _u16(data, coff + 2)
    opt_size = _u16(data, coff + 16)
    opt = coff + 20
    magic = _u16(data, opt)
    # data directories start at 96 (PE32) / 112 (PE32+) into the optional header
    dd_off = opt + (112 if magic == 0x20B else 96)
    # COM descriptor (CLI header) is data directory index 14
    cli_rva = _u32(data, dd_off + 14 * 8)
    sec_off = opt + opt_size
    secs = []
    for i in range(num_sections):
        s = sec_off + i * 40
        vsize = _u32(data, s + 8)
        vaddr = _u32(data, s + 12)
        raw_size = _u32(data, s + 16)
        raw_ptr = _u32(data, s + 20)
        secs.append((vaddr, vsize, raw_ptr, raw_size))
    return secs, cli_rva


def _rva_to_off(secs, rva):
    for vaddr, vsize, raw_ptr, raw_size in secs:
        if vaddr <= rva < vaddr + max(vsize, raw_size):
            return raw_ptr + (rva - vaddr)
    raise ValueError("rva 0x%x not in any section" % rva)


def _metadata_root(data):
    secs, cli_rva = _sections(data)
    cli = _rva_to_off(secs, cli_rva)
    meta_rva = _u32(data, cli + 8)
    meta_off = _rva_to_off(secs, meta_rva)
    if _u32(data, meta_off) != 0x424A5342:  # 'BSJB'
        raise ValueError("bad metadata signature")
    ver_len = _u32(data, meta_off + 12)
    o = meta_off + 16 + ((ver_len + 3) & ~3)
    o += 2  # flags
    nstreams = _u16(data, o)
    o += 2
    streams = {}
    for _ in range(nstreams):
        soff = _u32(data, o)
        ssize = _u32(data, o + 4)
        o += 8
        name_start = o
        while data[o] != 0:
            o += 1
        name = data[name_start:o].decode("ascii")
        o = (o + 1 + 3) & ~3  # name is null-terminated, padded to 4 bytes
        streams[name] = (meta_off + soff, ssize)
    return streams


def extract_us_strings(path):
    """Return the list of user-string literals in the assembly's #US heap."""
    data = open(path, "rb").read()
    streams = _metadata_root(data)
    if "#US" not in streams:
        return []
    base, size = streams["#US"]
    out = []
    o = 1  # index 0 is the empty blob
    end = base + size
    p = base + o
    while p < end:
        blob_len, n = _read_compressed_uint(data, p)
        p += n
        if blob_len == 0:
            continue
        raw = data[p:p + blob_len]
        p += blob_len
        # last byte is the "extra data" flag, the rest is UTF-16LE text
        text = raw[:-1].decode("utf-16-le", "replace")
        out.append(text)
    return out


if __name__ == "__main__":
    for s in extract_us_strings(sys.argv[1]):
        print(repr(s))
