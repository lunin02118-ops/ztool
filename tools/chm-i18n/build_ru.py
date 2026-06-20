# -*- coding: utf-8 -*-
# Rebuilds the Russian help_ru.chm from the original Chinese help.CHM.
# See README.md in this directory for the full procedure.
#   SRC : folder with the extracted (7-Zip) contents of help.CHM
#   OUT : output build folder (translated HTML/nav/images + .hhp)
# Both default to ./_chm_src and ./_chm_build next to this script; override
# with the CHM_SRC / CHM_OUT environment variables.
import os, re, json, shutil, sys
sys.stdout.reconfigure(encoding='utf-8')

HERE = os.path.dirname(os.path.abspath(__file__))
SRC = os.environ.get('CHM_SRC', os.path.join(HERE, '_chm_src'))
OUT = os.environ.get('CHM_OUT', os.path.join(HERE, '_chm_build'))
runs = json.load(open(os.path.join(HERE, 'runs.json'), encoding='utf-8'))
ru   = json.load(open(os.path.join(HERE, 'ru.json'), encoding='utf-8'))
assert len(runs) == len(ru), f'count mismatch {len(runs)} vs {len(ru)}'
TR = dict(zip(runs, ru))
# add HTML-entity-encoded variants (some runs contain < > & as &lt; &gt; &amp; in source)
for k in list(TR):
    esc = k.replace('&', '&amp;').replace('<', '&lt;').replace('>', '&gt;')
    if esc != k:
        TR.setdefault(esc, TR[k])
# longest-first replacement order
KEYS = sorted(TR.keys(), key=lambda s: -len(s))

cjk2ascii = {
 '功能介绍':'features', '安装说明':'installation', '激活授权与转出授权':'activation',
 '设置属性名称':'property-names', '设置材质库':'material-library',
 '连接SolidWorks':'connect-sw', '保存数据到SolidWorks':'save-to-sw',
 'BOM表模板制作和导出':'bom-template', '缩略图显示及操作':'thumbnails',
 '设置属性列自定义下拉菜单':'dropdown',
}
dir2ascii = {'基本操作':'basic', '进阶操作':'advanced'}
CJK = re.compile(r'[\u4e00-\u9fff]')

def ascii_relpath(rel):
    rel = rel.replace('\\', '/')
    d, fn = os.path.split(rel)
    stem = fn[:-4]
    astem = cjk2ascii.get(stem, stem)
    parts = [dir2ascii.get(p, p) for p in d.split('/') if p]
    return '/'.join(parts + [astem + '.htm'])

_WC = r'[0-9A-Za-z\u0400-\u04ff]'
_GLUE = re.compile('(' + _WC + r')((?:<[^>]+>)+)(?=' + _WC + ')')
def space_glue(html):
    # protect style/script/xml/comment blocks, re-space only the rest
    parts = re.split(r'(?is)(<style.*?</style>|<script.*?</script>|<xml.*?</xml>|<!--.*?-->)', html)
    for i in range(0, len(parts), 2):
        parts[i] = _GLUE.sub(r'\1 \2', parts[i])
    return ''.join(parts)

def translate_textnodes(html):
    # split into tags / text; skip style|script|xml regions
    parts = re.split(r'(<[^>]*>)', html)
    skip = 0
    out = []
    for seg in parts:
        if seg.startswith('<'):
            low = seg.lower()
            if re.match(r'<(style|script|xml)\b', low): skip += 1
            elif re.match(r'</(style|script|xml)\b', low): skip = max(0, skip-1)
            out.append(seg)
        else:
            if skip or not seg.strip():
                out.append(seg); continue
            s = seg
            for k in KEYS:
                if k and k in s:
                    s = s.replace(k, TR[k])
            out.append(s)
    return ''.join(out)

if os.path.isdir(OUT): shutil.rmtree(OUT)
os.makedirs(OUT)

htms = []
for dp, dn, fn in os.walk(SRC):
    for f in fn:
        if f.lower().endswith('.htm'):
            htms.append(os.path.relpath(os.path.join(dp, f), SRC))

files_list = []
img_exts = ('.png', '.gif', '.jpg', '.jpeg')
problems = []

for rel in htms:
    raw = open(os.path.join(SRC, rel), 'rb').read()
    try: html = raw.decode('gb2312')
    except: html = raw.decode('gbk', 'replace')
    stem = os.path.basename(rel)[:-4]
    astem = cjk2ascii.get(stem, stem)
    # 1) rewrite this topic's .files folder prefix -> ascii (covers img + vml)
    html = html.replace(stem + '.files', astem + '.files')
    # 2) translate visible text nodes
    html = translate_textnodes(html)
    # 2b) re-space glued run boundaries (CJK needs no spaces between styled
    #     spans, Cyrillic does) — insert a space where two word chars are
    #     separated only by inline tags, skipping style/script/xml/comments
    html = space_glue(html)
    # 3) charset -> utf-8
    html = re.sub(r'(?i)charset=gb2312', 'charset=utf-8', html)
    # write
    arel = ascii_relpath(rel)
    ap = os.path.join(OUT, arel)
    os.makedirs(os.path.dirname(ap), exist_ok=True)
    open(ap, 'w', encoding='utf-8').write(html)
    files_list.append(arel.replace('/', '\\'))
    # leftover VISIBLE CJK check: strip style/script/xml/comments first
    vis = re.sub(r'(?is)<style.*?</style>', ' ', html)
    vis = re.sub(r'(?is)<script.*?</script>', ' ', vis)
    vis = re.sub(r'(?is)<xml.*?</xml>', ' ', vis)
    vis = re.sub(r'(?is)<!--.*?-->', ' ', vis)
    leftover = set()
    for seg in re.split(r'(<[^>]*>)', vis):
        if not seg.startswith('<') and CJK.search(seg):
            for m in re.findall(r'[\u4e00-\u9fff]+', seg):
                if m not in ('初始化',): leftover.add(m)
    if leftover:
        problems.append((arel, sorted(leftover)[:20]))
    # 4) copy images from sibling .files
    srcfiles = os.path.join(SRC, os.path.dirname(rel), stem + '.files')
    dstfiles = os.path.join(OUT, os.path.dirname(arel), astem + '.files')
    if os.path.isdir(srcfiles):
        for img in os.listdir(srcfiles):
            if img.lower().endswith(img_exts):
                os.makedirs(dstfiles, exist_ok=True)
                shutil.copy2(os.path.join(srcfiles, img), os.path.join(dstfiles, img))
                files_list.append(os.path.join(os.path.dirname(arel), astem + '.files', img).replace('/', '\\'))

# ---- HHC / HHK transform ----
def path_map(p):
    p = p.replace('\\', '/')
    d, fn = os.path.split(p)
    if fn.lower().endswith('.htm'):
        stem = fn[:-4]; fn = cjk2ascii.get(stem, stem) + '.htm'
    parts = [dir2ascii.get(x, x) for x in d.split('/') if x]
    return '/'.join(parts + [fn]) if parts else fn

def transform_nav(srcfile, dstfile):
    raw = open(srcfile, 'rb').read()
    try: t = raw.decode('gb2312')
    except: t = raw.decode('gbk', 'replace')
    def repl_name(m):
        val = m.group(1)
        return m.group(0).replace('"'+val+'"', '"'+TR.get(val, val)+'"')
    t = re.sub(r'(?i)name="Name"\s+value="([^"]*)"', repl_name, t)
    def repl_local(m):
        val = m.group(1)
        return m.group(0).replace('"'+val+'"', '"'+path_map(val)+'"')
    t = re.sub(r'(?i)name="Local"\s+value="([^"]*)"', repl_local, t)
    # ensure the navigation pane renders with the Russian (cp1251) charset:
    # normalize any existing Font param to charset 204, else inject a
    # site-properties OBJECT carrying that Font right after <BODY>.
    if re.search(r'(?i)name="Font"', t):
        t = re.sub(r'(?i)(name="Font"\s+value="[^",]*,[^",]*),[^"]*"',
                   r'\1,204"', t)
    else:
        site = ('<OBJECT type="text/site properties">\r\n'
                '\t<param name="Font" value="MS Sans Serif,9,204">\r\n'
                '</OBJECT>\r\n')
        t = re.sub(r'(?i)(<BODY>)', r'\1\r\n' + site, t, count=1)
    open(dstfile, 'w', encoding='cp1251', errors='replace').write(t)

src_hhc = os.path.join(SRC, 'TOC-Created-By-Easy-CHM.HHC')
src_hhk = os.path.join(SRC, 'Index-Created-By-Easy-CHM.HHK')
transform_nav(src_hhc, os.path.join(OUT, 'toc.hhc'))
transform_nav(src_hhk, os.path.join(OUT, 'index.hhk'))

# ---- HHP project ----
hhp = []
hhp.append('[OPTIONS]')
hhp.append('Compatibility=1.1 or later')
hhp.append('Compiled file=help_ru.chm')
hhp.append('Contents file=toc.hhc')
hhp.append('Index file=index.hhk')
hhp.append('Binary Index=No')
hhp.append('Default topic=features.htm')
hhp.append('Display compile progress=Yes')
hhp.append('Full-text search=Yes')
hhp.append('Language=0x419 Russian (Russia)')
hhp.append('Title=SWTools — Руководство пользователя')
hhp.append('')
hhp.append('[FILES]')
seen = set()
for f in files_list:
    if f not in seen:
        seen.add(f); hhp.append(f)
hhp.append('')
open(os.path.join(OUT, 'help_ru.hhp'), 'w', encoding='cp1251', errors='replace').write('\r\n'.join(hhp))

print('topics:', len(htms), 'files listed:', len(seen))
print('PROBLEMS (leftover CJK in text):', len(problems))
for a, l in problems:
    print('  ', a, l)
