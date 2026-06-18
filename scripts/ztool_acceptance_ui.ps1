<#
.SYNOPSIS
  Object-based Win32 helpers for ZTool acceptance tests.

.DESCRIPTION
  This file intentionally avoids hardcoded screen coordinates. It locates
  windows and child controls by process id, Win32 class and visible text, then
  invokes buttons with BM_CLICK. Use it from manual release evidence scripts
  when UIA does not expose legacy WinForms controls.
#>

$ErrorActionPreference = 'Stop'

if (-not ('ZToolAcceptanceWin32' -as [type])) {
Add-Type @'
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class ZToolAcceptanceWin32 {
  public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

  [DllImport("user32.dll")]
  public static extern bool EnumWindows(EnumWindowsProc cb, IntPtr lp);

  [DllImport("user32.dll")]
  public static extern bool EnumChildWindows(IntPtr hWnd, EnumWindowsProc cb, IntPtr lp);

  [DllImport("user32.dll")]
  public static extern bool IsWindowVisible(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint pid);

  [DllImport("user32.dll", CharSet=CharSet.Unicode)]
  public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

  [DllImport("user32.dll", CharSet=CharSet.Unicode)]
  public static extern int GetClassName(IntPtr hWnd, StringBuilder text, int count);

  [DllImport("user32.dll")]
  public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

  [DllImport("user32.dll")]
  public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

  [DllImport("user32.dll", SetLastError=true)]
  public static extern IntPtr SendMessageTimeout(
    IntPtr hWnd,
    uint msg,
    IntPtr wParam,
    IntPtr lParam,
    uint flags,
    uint timeout,
    out IntPtr result
  );

  [DllImport("user32.dll")]
  public static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

  public const uint BM_CLICK = 0x00F5;
  public const uint SMTO_ABORTIFHUNG = 0x0002;

  public struct RECT {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
  }

  public static string TextOf(IntPtr hWnd) {
    var text = new StringBuilder(512);
    GetWindowText(hWnd, text, text.Capacity);
    return text.ToString();
  }

  public static string ClassOf(IntPtr hWnd) {
    var text = new StringBuilder(256);
    GetClassName(hWnd, text, text.Capacity);
    return text.ToString();
  }

  public static List<string> TitlesForPid(int targetPid) {
    var result = new List<string>();
    EnumWindows((hWnd, lp) => {
      uint pid;
      GetWindowThreadProcessId(hWnd, out pid);
      if (pid == targetPid && IsWindowVisible(hWnd)) {
        string title = TextOf(hWnd);
        if (!String.IsNullOrWhiteSpace(title)) {
          result.Add(title);
        }
      }
      return true;
    }, IntPtr.Zero);
    return result;
  }

  public static List<string> DumpForPid(int targetPid) {
    var lines = new List<string>();
    EnumWindows((hWnd, lp) => {
      uint pid;
      GetWindowThreadProcessId(hWnd, out pid);
      if (pid == targetPid) {
        DumpOne(hWnd, lines, "top");
        EnumChildWindows(hWnd, (child, childLp) => {
          DumpOne(child, lines, "child");
          return true;
        }, IntPtr.Zero);
      }
      return true;
    }, IntPtr.Zero);
    return lines;
  }

  public static IntPtr FindChildByTextAndClass(int targetPid, string text, string classContains) {
    IntPtr found = IntPtr.Zero;
    EnumWindows((hWnd, lp) => {
      uint pid;
      GetWindowThreadProcessId(hWnd, out pid);
      if (pid == targetPid) {
        EnumChildWindows(hWnd, (child, childLp) => {
          uint childPid;
          GetWindowThreadProcessId(child, out childPid);
          if (childPid == targetPid && IsWindowVisible(child)) {
            string childText = TextOf(child);
            string childClass = ClassOf(child);
            if (childText == text && childClass.Contains(classContains)) {
              found = child;
              return false;
            }
          }
          return true;
        }, IntPtr.Zero);
      }
      return found == IntPtr.Zero;
    }, IntPtr.Zero);
    return found;
  }

  static void DumpOne(IntPtr hWnd, List<string> lines, string kind) {
    RECT rect;
    GetWindowRect(hWnd, out rect);
    lines.Add(
      kind +
      " hwnd=" + hWnd.ToInt64() +
      " visible=" + IsWindowVisible(hWnd) +
      " class=" + ClassOf(hWnd) +
      " text=" + TextOf(hWnd) +
      " rect=" + rect.Left + "," + rect.Top + "," + rect.Right + "," + rect.Bottom
    );
  }
}
'@
}

function Get-ZToolWindowTitles {
    param([Parameter(Mandatory = $true)][int]$ProcessId)
    [ZToolAcceptanceWin32]::TitlesForPid($ProcessId)
}

function Export-ZToolWindowTree {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][string]$Path
    )
    $lines = [ZToolAcceptanceWin32]::DumpForPid($ProcessId)
    Set-Content -LiteralPath $Path -Encoding UTF8 -Value $lines
}

function Invoke-ZToolButtonByText {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][string]$Text,
        [string]$ClassContains = 'BUTTON',
        [switch]$Async
    )

    $handle = [ZToolAcceptanceWin32]::FindChildByTextAndClass(
        $ProcessId,
        $Text,
        $ClassContains
    )
    if ($handle -eq [IntPtr]::Zero) {
        throw "ZTool button not found: text='$Text', class contains '$ClassContains', pid=$ProcessId"
    }

    if ($Async) {
        $posted = [ZToolAcceptanceWin32]::PostMessage(
            $handle,
            [ZToolAcceptanceWin32]::BM_CLICK,
            [IntPtr]::Zero,
            [IntPtr]::Zero
        )
        if (-not $posted) {
            throw "ZTool button click was not posted: text='$Text', hwnd=$($handle.ToInt64())"
        }
    } else {
        $result = [IntPtr]::Zero
        $sent = [ZToolAcceptanceWin32]::SendMessageTimeout(
            $handle,
            [ZToolAcceptanceWin32]::BM_CLICK,
            [IntPtr]::Zero,
            [IntPtr]::Zero,
            [ZToolAcceptanceWin32]::SMTO_ABORTIFHUNG,
            5000,
            [ref]$result
        )
        if ($sent -eq [IntPtr]::Zero) {
            throw "ZTool button click timed out or failed: text='$Text', hwnd=$($handle.ToInt64())"
        }
    }

    [ordered]@{
        process_id = $ProcessId
        text = $Text
        class_contains = $ClassContains
        hwnd = $handle.ToInt64()
        async = [bool]$Async
    }
}
