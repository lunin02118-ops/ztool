import qrcode
from qrcode.constants import ERROR_CORRECT_M
from PIL import Image, ImageDraw, ImageFont

# Regenerates tools/Localizer/max_qr.png (the contact QR shown in the license /
# About windows). The Localizer embeds this PNG and points get_<QR>() at it.
# Requires: pip install "qrcode[pil]"
URL = "https://max.ru/u/f9LHodD0cOLc5SX8zsbZvz3TMwMzyunwK6GAYYw79SkF1lZ0YUlZknFImsU"

import os
OUT = os.path.join(os.path.dirname(os.path.abspath(__file__)), "max_qr.png")

# Canvas 3:1 to match the PictureBox (384x128 / 288x112, SizeMode=Zoom)
W, H = 840, 280
canvas = Image.new("RGB", (W, H), "white")
draw = ImageDraw.Draw(canvas)

# --- QR on the left ---
qr = qrcode.QRCode(version=None, error_correction=ERROR_CORRECT_M, box_size=10, border=2)
qr.add_data(URL)
qr.make(fit=True)
qr_img = qr.make_image(fill_color="black", back_color="white").convert("RGB")
qr_side = 248
qr_img = qr_img.resize((qr_side, qr_side), Image.NEAREST)
qx = (280 - qr_side) // 2
qy = (H - qr_side) // 2
canvas.paste(qr_img, (qx, qy))

# --- Text on the right ---
def font(sz, bold=False):
    path = r"C:\Windows\Fonts\arialbd.ttf" if bold else r"C:\Windows\Fonts\arial.ttf"
    return ImageFont.truetype(path, sz)

tx = 300
lines = [
    ("Поддержка в мессенджере MAX", font(31, True), (0, 0, 0)),
    ("Наведите QR или нажмите «Max»", font(25, False), (110, 110, 110)),
    ("консультация и помощь", font(25, False), (110, 110, 110)),
]
# vertical layout
gap = 14
heights = []
for txt, f, _ in lines:
    bbox = draw.textbbox((0, 0), txt, font=f)
    heights.append(bbox[3] - bbox[1])
total = sum(heights) + gap * (len(lines) - 1)
cy = (H - total) // 2
for (txt, f, color), h in zip(lines, heights):
    bbox = draw.textbbox((0, 0), txt, font=f)
    draw.text((tx, cy - bbox[1]), txt, font=f, fill=color)
    cy += h + gap

canvas.save(OUT, "PNG")
print("saved", OUT, canvas.size)
