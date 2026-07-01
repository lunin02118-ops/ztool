<#
.SYNOPSIS
  Object-based Win32 helpers for SWTools acceptance tests.

.DESCRIPTION
  This file intentionally avoids hardcoded screen coordinates. It locates
  windows and child controls by process id, Win32 class and visible text, then
  invokes buttons with BM_CLICK. Use it from manual release evidence scripts
  when UIA does not expose legacy WinForms controls.
#>

$ErrorActionPreference = 'Stop'

Add-Type -AssemblyName System.Windows.Forms

if (-not ('SWToolsAcceptanceWin32' -as [type])) {
Add-Type @'
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class SWToolsAcceptanceWin32 {
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

  [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
  public static extern bool SetWindowText(IntPtr hWnd, string text);

  [DllImport("user32.dll")]
  public static extern bool SetForegroundWindow(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern bool BringWindowToTop(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

  [DllImport("user32.dll")]
  public static extern IntPtr SetFocus(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern IntPtr SetActiveWindow(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern bool SetCursorPos(int x, int y);

  [DllImport("user32.dll")]
  public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

  [DllImport("kernel32.dll")]
  public static extern uint GetCurrentThreadId();

  [DllImport("user32.dll", SetLastError=true)]
  public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

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
  public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
  public const uint MOUSEEVENTF_LEFTUP = 0x0004;
  public const int SW_RESTORE = 9;

  public class WindowInfo {
    public string Kind { get; set; }
    public long Hwnd { get; set; }
    public long TopHwnd { get; set; }
    public bool Visible { get; set; }
    public string ClassName { get; set; }
    public string Text { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
  }

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
    foreach (var item in ControlsForPid(targetPid)) {
      lines.Add(
        item.Kind +
        " hwnd=" + item.Hwnd +
        " top_hwnd=" + item.TopHwnd +
        " visible=" + item.Visible +
        " class=" + item.ClassName +
        " text=" + item.Text +
        " rect=" + item.Left + "," + item.Top + "," + item.Right + "," + item.Bottom
      );
    }
    return lines;
  }

  public static List<WindowInfo> ControlsForPid(int targetPid) {
    var items = new List<WindowInfo>();
    EnumWindows((hWnd, lp) => {
      uint pid;
      GetWindowThreadProcessId(hWnd, out pid);
      if (pid == targetPid) {
        items.Add(InfoOf(hWnd, "top", hWnd));
        EnumChildWindows(hWnd, (child, childLp) => {
          items.Add(InfoOf(child, "child", hWnd));
          return true;
        }, IntPtr.Zero);
      }
      return true;
    }, IntPtr.Zero);
    return items;
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
            if (
              childText == text &&
              childClass.IndexOf(classContains, StringComparison.OrdinalIgnoreCase) >= 0
            ) {
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

  public static bool SetTextByHwnd(long hWnd, string text) {
    return SetWindowText(new IntPtr(hWnd), text);
  }

  public static bool ActivateAndFocus(long topHWnd, long childHWnd) {
    IntPtr top = new IntPtr(topHWnd);
    IntPtr child = new IntPtr(childHWnd);

    uint pid;
    uint targetThread = GetWindowThreadProcessId(child, out pid);
    uint currentThread = GetCurrentThreadId();
    bool attached = false;

    ShowWindow(top, SW_RESTORE);
    BringWindowToTop(top);
    SetForegroundWindow(top);

    if (targetThread != 0 && currentThread != targetThread) {
      attached = AttachThreadInput(currentThread, targetThread, true);
    }

    try {
      BringWindowToTop(top);
      SetActiveWindow(top);
      SetFocus(child);
      return true;
    } finally {
      if (attached) {
        AttachThreadInput(currentThread, targetThread, false);
      }
    }
  }

  public static bool ClickWindowCenter(long hWnd) {
    RECT rect;
    IntPtr handle = new IntPtr(hWnd);
    if (!GetWindowRect(handle, out rect)) {
      return false;
    }
    int x = rect.Left + Math.Max(1, (rect.Right - rect.Left) / 2);
    int y = rect.Top + Math.Max(1, (rect.Bottom - rect.Top) / 2);
    if (!SetCursorPos(x, y)) {
      return false;
    }
    mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, UIntPtr.Zero);
    mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, UIntPtr.Zero);
    return true;
  }

  static WindowInfo InfoOf(IntPtr hWnd, string kind, IntPtr topHWnd) {
    RECT rect;
    GetWindowRect(hWnd, out rect);
    return new WindowInfo {
      Kind = kind,
      Hwnd = hWnd.ToInt64(),
      TopHwnd = topHWnd.ToInt64(),
      Visible = IsWindowVisible(hWnd),
      ClassName = ClassOf(hWnd),
      Text = TextOf(hWnd),
      Left = rect.Left,
      Top = rect.Top,
      Right = rect.Right,
      Bottom = rect.Bottom
    };
  }
}
'@
}

function Get-SWToolsWindowTitles {
    param([Parameter(Mandatory = $true)][int]$ProcessId)
    [SWToolsAcceptanceWin32]::TitlesForPid($ProcessId)
}

function Export-SWToolsWindowTree {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][string]$Path
    )
    $lines = [SWToolsAcceptanceWin32]::DumpForPid($ProcessId)
    Set-Content -LiteralPath $Path -Encoding UTF8 -Value $lines
}

function Get-SWToolsWindowControls {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [string]$ClassContains = "",
        [string]$Text = "",
        [string]$WindowTitleContains = ""
    )
    $items = [SWToolsAcceptanceWin32]::ControlsForPid($ProcessId)
    if ($WindowTitleContains) {
        $topWindow = @(
            $items |
                Where-Object {
                    $_.Kind -eq 'top' -and
                    $_.Visible -and
                    $_.Text -like "*$WindowTitleContains*"
                } |
                Sort-Object Top, Left
        )
        if ($topWindow.Count -eq 0) {
            throw "SWTools top window not found: title contains '$WindowTitleContains', pid=$ProcessId"
        }
        $target = $topWindow[0]
        $items = @(
            $items |
                Where-Object {
                    $_.Hwnd -eq $target.Hwnd -or $_.TopHwnd -eq $target.Hwnd
                }
        )
    }
    if ($ClassContains) {
        $items = @($items | Where-Object { $_.ClassName -like "*$ClassContains*" })
    }
    if ($Text) {
        $items = @($items | Where-Object { $_.Text -eq $Text })
    }
    $items
}

function Set-SWToolsControlText {
    param(
        [Parameter(Mandatory = $true)][long]$Hwnd,
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text,
        [switch]$AllowUnsafeSetWindowText
    )

    if (-not $AllowUnsafeSetWindowText) {
        throw "SetWindowText is diagnostic-only and forbidden for activation gates. Use clipboard/UIA ValuePattern and server audit instead."
    }

    $ok = [SWToolsAcceptanceWin32]::SetTextByHwnd($Hwnd, $Text)
    if (-not $ok) {
        throw "Failed to set text for hwnd=$Hwnd"
    }

    [ordered]@{
        hwnd = $Hwnd
        length = $Text.Length
    }
}

function Set-SWToolsEditTextsByTopLeft {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][string[]]$Texts,
        [int]$Skip = 0,
        [string]$WindowTitleContains = "",
        [switch]$AllowUnsafeSetWindowText
    )

    if (-not $AllowUnsafeSetWindowText) {
        throw "SetWindowText is diagnostic-only and forbidden for activation gates. Use clipboard/UIA ValuePattern and server audit instead."
    }

    $edits = @(
        Get-SWToolsWindowControls -ProcessId $ProcessId -ClassContains 'EDIT' -WindowTitleContains $WindowTitleContains |
            Where-Object { $_.Visible } |
            Sort-Object Top, Left
    )

    if ($edits.Count -lt ($Skip + $Texts.Count)) {
        throw "Not enough EDIT controls: need $($Skip + $Texts.Count), found $($edits.Count), pid=$ProcessId"
    }

    $written = @()
    for ($i = 0; $i -lt $Texts.Count; $i++) {
        $target = $edits[$Skip + $i]
        Set-SWToolsControlText -Hwnd $target.Hwnd -Text $Texts[$i] -AllowUnsafeSetWindowText | Out-Null
        $written += [ordered]@{
            hwnd = $target.Hwnd
            index = $Skip + $i
            length = $Texts[$i].Length
            rect = "$($target.Left),$($target.Top),$($target.Right),$($target.Bottom)"
        }
    }
    $written
}

function Set-SWToolsClipboardText {
    param([Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text)

    for ($attempt = 1; $attempt -le 5; $attempt++) {
        try {
            [System.Windows.Forms.Clipboard]::SetText($Text)
            return
        } catch {
            if ($attempt -eq 5) { throw }
            Start-Sleep -Milliseconds 100
        }
    }
}

function Focus-SWToolsControl {
    param(
        [Parameter(Mandatory = $true)][long]$TopHwnd,
        [Parameter(Mandatory = $true)][long]$Hwnd
    )

    [SWToolsAcceptanceWin32]::ActivateAndFocus($TopHwnd, $Hwnd) | Out-Null
    $clickPoint = [IntPtr]((5 -band 0xffff) -bor (5 -shl 16))
    [SWToolsAcceptanceWin32]::SendMessage(
        [IntPtr]$Hwnd,
        0x0201, # WM_LBUTTONDOWN
        [IntPtr]1,
        $clickPoint
    ) | Out-Null
    [SWToolsAcceptanceWin32]::SendMessage(
        [IntPtr]$Hwnd,
        0x0202, # WM_LBUTTONUP
        [IntPtr]0,
        $clickPoint
    ) | Out-Null
    [SWToolsAcceptanceWin32]::ClickWindowCenter($Hwnd) | Out-Null
    Start-Sleep -Milliseconds 120
}

function Get-SWToolsControlTextByHwnd {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][long]$Hwnd,
        [string]$WindowTitleContains = ""
    )

    $control = @(
        Get-SWToolsWindowControls -ProcessId $ProcessId -WindowTitleContains $WindowTitleContains |
            Where-Object { $_.Hwnd -eq $Hwnd }
    )
    if ($control.Count -ne 1) {
        throw "SWTools control not found for readback: hwnd=$Hwnd, pid=$ProcessId"
    }
    $control[0].Text
}

function Set-SWToolsEditTextByClipboard {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][long]$TopHwnd,
        [Parameter(Mandatory = $true)][long]$Hwnd,
        [Parameter(Mandatory = $true)][AllowEmptyString()][string]$Text,
        [string]$WindowTitleContains = "",
        [int]$Retries = 3
    )

    for ($attempt = 1; $attempt -le $Retries; $attempt++) {
        Focus-SWToolsControl -TopHwnd $TopHwnd -Hwnd $Hwnd
        [System.Windows.Forms.SendKeys]::SendWait('^a')
        Start-Sleep -Milliseconds 80
        [System.Windows.Forms.SendKeys]::SendWait('{BACKSPACE}')
        Start-Sleep -Milliseconds 80
        Set-SWToolsClipboardText -Text $Text
        [System.Windows.Forms.SendKeys]::SendWait('^v')
        Start-Sleep -Milliseconds 180

        $actual = Get-SWToolsControlTextByHwnd `
            -ProcessId $ProcessId `
            -Hwnd $Hwnd `
            -WindowTitleContains $WindowTitleContains
        if ($actual -eq $Text) {
            return [ordered]@{
                hwnd = $Hwnd
                length = $Text.Length
                exact_match = $true
                attempt = $attempt
            }
        }
    }

    $final = Get-SWToolsControlTextByHwnd `
        -ProcessId $ProcessId `
        -Hwnd $Hwnd `
        -WindowTitleContains $WindowTitleContains
    throw "Clipboard paste readback mismatch for hwnd=${Hwnd}: expected length=$($Text.Length), actual length=$($final.Length)"
}

function Set-SWToolsRegistrationFieldsByClipboard {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][string]$RegistrationCode,
        [AllowEmptyString()][string]$Password = "",
        [string]$WindowTitleContains = "Регистрация"
    )

    $segments = @($RegistrationCode.Trim() -split '-')
    $expectedLengths = @(8, 5, 5, 5, 9)
    if ($segments.Count -ne 5) {
        throw "Registration code must contain 5 segments"
    }
    for ($i = 0; $i -lt $expectedLengths.Count; $i++) {
        if ($segments[$i].Length -ne $expectedLengths[$i]) {
            throw "Registration segment $($i + 1) length mismatch: expected $($expectedLengths[$i]), actual $($segments[$i].Length)"
        }
    }

    $edits = @(
        Get-SWToolsWindowControls -ProcessId $ProcessId -ClassContains 'EDIT' -WindowTitleContains $WindowTitleContains |
            Where-Object { $_.Visible } |
            Sort-Object Top, Left
    )

    if ($edits.Count -lt 7) {
        throw "Registration window must expose at least 7 EDIT controls, found $($edits.Count), pid=$ProcessId"
    }

    $topHwnd = [long]$edits[0].TopHwnd
    $targets = @($edits | Select-Object -Skip 1 -First 6)
    $values = @($segments + @($Password))
    $names = @('Licence1', 'Licence2', 'Licence3', 'Licence4', 'Licence5', 'password')
    $written = @()

    for ($i = 0; $i -lt $targets.Count; $i++) {
        $result = Set-SWToolsEditTextByClipboard `
            -ProcessId $ProcessId `
            -TopHwnd $topHwnd `
            -Hwnd ([long]$targets[$i].Hwnd) `
            -Text $values[$i] `
            -WindowTitleContains $WindowTitleContains
        $written += [ordered]@{
            name = $names[$i]
            hwnd = [long]$targets[$i].Hwnd
            expected_length = $values[$i].Length
            actual_length = $result['length']
            exact_match = $result['exact_match']
            attempt = $result['attempt']
            rect = "$($targets[$i].Left),$($targets[$i].Top),$($targets[$i].Right),$($targets[$i].Bottom)"
        }
    }

    $readback = @(
        Get-SWToolsWindowControls -ProcessId $ProcessId -ClassContains 'EDIT' -WindowTitleContains $WindowTitleContains |
            Where-Object { $_.Visible } |
            Sort-Object Top, Left |
            Select-Object -Skip 1 -First 6
    )
    for ($i = 0; $i -lt $readback.Count; $i++) {
        if ($readback[$i].Text -ne $values[$i]) {
            throw "Registration field final readback mismatch: $($names[$i]) expected length=$($values[$i].Length), actual length=$($readback[$i].Text.Length)"
        }
    }

    [ordered]@{
        process_id = $ProcessId
        window_title_contains = $WindowTitleContains
        segment_lengths = ($segments | ForEach-Object { $_.Length })
        password_length = $Password.Length
        all_exact_match = $true
        fields = $written
    }
}

function Invoke-SWToolsButtonByText {
    param(
        [Parameter(Mandatory = $true)][int]$ProcessId,
        [Parameter(Mandatory = $true)][string]$Text,
        [string]$ClassContains = 'BUTTON',
        [string]$WindowTitleContains = "",
        [switch]$Async
    )

    if ($WindowTitleContains) {
        $matched = @(
            Get-SWToolsWindowControls `
                -ProcessId $ProcessId `
                -ClassContains $ClassContains `
                -Text $Text `
                -WindowTitleContains $WindowTitleContains |
                Where-Object { $_.Visible }
        )
        $handle = if ($matched.Count -gt 0) { [IntPtr]::new([long]$matched[0].Hwnd) } else { [IntPtr]::Zero }
    } else {
        $handle = [SWToolsAcceptanceWin32]::FindChildByTextAndClass(
            $ProcessId,
            $Text,
            $ClassContains
        )
    }
    if ($handle -eq [IntPtr]::Zero) {
        throw "SWTools button not found: text='$Text', class contains '$ClassContains', window title contains '$WindowTitleContains', pid=$ProcessId"
    }

    if ($Async) {
        $posted = [SWToolsAcceptanceWin32]::PostMessage(
            $handle,
            [SWToolsAcceptanceWin32]::BM_CLICK,
            [IntPtr]::Zero,
            [IntPtr]::Zero
        )
        if (-not $posted) {
            throw "SWTools button click was not posted: text='$Text', hwnd=$($handle.ToInt64())"
        }
    } else {
        $result = [IntPtr]::Zero
        $sent = [SWToolsAcceptanceWin32]::SendMessageTimeout(
            $handle,
            [SWToolsAcceptanceWin32]::BM_CLICK,
            [IntPtr]::Zero,
            [IntPtr]::Zero,
            [SWToolsAcceptanceWin32]::SMTO_ABORTIFHUNG,
            5000,
            [ref]$result
        )
        if ($sent -eq [IntPtr]::Zero) {
            throw "SWTools button click timed out or failed: text='$Text', hwnd=$($handle.ToInt64())"
        }
    }

    [ordered]@{
        process_id = $ProcessId
        text = $Text
        class_contains = $ClassContains
        window_title_contains = $WindowTitleContains
        hwnd = $handle.ToInt64()
        async = [bool]$Async
    }
}
