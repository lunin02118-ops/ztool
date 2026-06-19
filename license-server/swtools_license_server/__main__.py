"""Entry point for `python -m swtools_license_server`."""

import asyncio
from .server import main

asyncio.run(main())
