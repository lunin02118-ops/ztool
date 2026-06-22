"""In-process rate limiting for the license server."""

from __future__ import annotations

import time
from dataclasses import dataclass
from typing import Callable


@dataclass(frozen=True)
class RateLimitDecision:
    """Decision returned by a rate limiter check."""

    allowed: bool
    remaining: int
    retry_after_seconds: float
    reset_after_seconds: float


class FixedWindowRateLimiter:
    """Small fixed-window limiter keyed by client identity.

    The perimeter firewall/fail2ban remains mandatory for public deployment;
    this limiter is a defense-in-depth guard inside the Python process.
    """

    def __init__(
        self,
        *,
        enabled: bool = True,
        max_requests: int = 120,
        window_seconds: float = 60.0,
        max_keys: int = 10_000,
        time_func: Callable[[], float] | None = None,
    ):
        if max_requests < 1:
            raise ValueError("max_requests must be >= 1")
        if window_seconds <= 0:
            raise ValueError("window_seconds must be > 0")
        if max_keys < 1:
            raise ValueError("max_keys must be >= 1")
        self.enabled = enabled
        self.max_requests = max_requests
        self.window_seconds = float(window_seconds)
        self.max_keys = max_keys
        self._time = time_func or time.monotonic
        self._windows: dict[str, tuple[float, int]] = {}
        self._next_cleanup_at = 0.0

    def check(self, key: str) -> RateLimitDecision:
        """Consume one request slot for ``key`` and return the decision."""
        if not self.enabled:
            return RateLimitDecision(
                allowed=True,
                remaining=self.max_requests,
                retry_after_seconds=0.0,
                reset_after_seconds=0.0,
            )

        now = self._time()
        self._cleanup_if_needed(now)
        key = key or "-"

        if key not in self._windows and len(self._windows) >= self.max_keys:
            # If all tracked windows are still active, fail closed for new keys
            # instead of letting a source-IP spray grow memory without bound.
            return RateLimitDecision(
                allowed=False,
                remaining=0,
                retry_after_seconds=self.window_seconds,
                reset_after_seconds=self.window_seconds,
            )

        started_at, count = self._windows.get(key, (now, 0))
        elapsed = now - started_at
        if elapsed >= self.window_seconds:
            started_at, count, elapsed = now, 0, 0.0

        reset_after = max(0.0, self.window_seconds - elapsed)
        if count >= self.max_requests:
            return RateLimitDecision(
                allowed=False,
                remaining=0,
                retry_after_seconds=reset_after,
                reset_after_seconds=reset_after,
            )

        count += 1
        self._windows[key] = (started_at, count)
        return RateLimitDecision(
            allowed=True,
            remaining=max(0, self.max_requests - count),
            retry_after_seconds=0.0,
            reset_after_seconds=reset_after,
        )

    def _cleanup_if_needed(self, now: float) -> None:
        if now < self._next_cleanup_at:
            return
        self._next_cleanup_at = now + min(self.window_seconds, 60.0)
        expired_before = now - self.window_seconds
        self._windows = {
            key: value
            for key, value in self._windows.items()
            if value[0] > expired_before
        }
