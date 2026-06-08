"""Entry point for `python -m ztool_license_server`."""

import asyncio
from .server import main

asyncio.run(main())
