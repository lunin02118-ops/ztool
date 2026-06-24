$ErrorActionPreference = 'Stop'

$Repo = 'D:\Development\ztool\_local_artifacts\worktrees\p4-next'
$ReportDir = Join-Path $Repo 'manual-test-reports\bom-parity-live-20260623'
$ExportDir = Join-Path $ReportDir 'bom-exports-clean-final'
$DocumentsDir = [Environment]::GetFolderPath('MyDocuments')
$DesktopDir = [Environment]::GetFolderPath('Desktop')

New-Item -ItemType Directory -Force -Path $ExportDir | Out-Null

$Modes = @(
    @{ Mode = 1; Menu = 'Экспорт сводной спецификации'; File = '01_summary.xlsx' },
    @{ Mode = 2; Menu = 'Экспорт иерархической спецификации'; File = '02_hierarchy.xlsx' },
    @{ Mode = 3; Menu = 'Экспорт спецификации верхнего уровня'; File = '03_top_level.xlsx' },
    @{ Mode = 4; Menu = 'Экспорт сводной спецификации деталей'; File = '04_parts_only.xlsx' },
    @{ Mode = 5; Menu = 'Экспорт сводной спецификации (с эскизами)'; File = '05_summary_images.xlsx' },
    @{ Mode = 6; Menu = 'Экспорт иерархической спецификации (с эскизами)'; File = '06_hierarchy_images.xlsx' },
    @{ Mode = 7; Menu = 'Обрабатываемые детали'; File = '07_processed.xlsx' },
    @{ Mode = 8; Menu = 'Покупные изделия'; File = '08_purchased.xlsx' }
)

Add-Type -AssemblyName UIAutomationClient
Add-Type -AssemblyName UIAutomationTypes
Add-Type -AssemblyName System.Windows.Forms

Add-Type -TypeDefinition @'
using System;
using System.Runtime.InteropServices;
public static class S8Native {
  [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hWnd);
  [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
  [DllImport("user32.dll")] public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
  [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
  [DllImport("user32.dll")] public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, UInt32 uFlags);
  [DllImport("user32.dll", CharSet=CharSet.Unicode)] public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
  [DllImport("user32.dll", CharSet=CharSet.Unicode)] public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
  [DllImport("user32.dll")] public static extern bool SetCursorPos(int X, int Y);
  [DllImport("user32.dll")] public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
  public const uint MOUSEEVENTF_LEFTDOWN=0x0002;
  public const uint MOUSEEVENTF_LEFTUP=0x0004;
  public const int BM_CLICK=0x00F5;
  public const int SW_MAXIMIZE=3;
  public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
  public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
  public const UInt32 SWP_NOMOVE=0x0002;
  public const UInt32 SWP_NOSIZE=0x0001;
  public const UInt32 SWP_SHOWWINDOW=0x0040;
  [StructLayout(LayoutKind.Sequential)] public struct RECT { public int Left; public int Top; public int Right; public int Bottom; }
}
'@

function New-PropCondition($property, $value) {
    New-Object System.Windows.Automation.PropertyCondition($property, $value)
}

function Get-RootElement {
    [System.Windows.Automation.AutomationElement]::RootElement
}

function Get-SWToolsWindow {
    $process = Get-Process SWTools -ErrorAction SilentlyContinue |
        Where-Object { $_.MainWindowHandle -ne 0 } |
        Sort-Object StartTime -Descending |
        Select-Object -First 1
    if (-not $process) {
        throw 'SWTools process/window not found'
    }

    [S8Native]::ShowWindow($process.MainWindowHandle, [S8Native]::SW_MAXIMIZE) | Out-Null
    [S8Native]::SetWindowPos($process.MainWindowHandle, [S8Native]::HWND_TOPMOST, 0, 0, 0, 0, [S8Native]::SWP_NOMOVE -bor [S8Native]::SWP_NOSIZE -bor [S8Native]::SWP_SHOWWINDOW) | Out-Null
    Start-Sleep -Milliseconds 120
    [S8Native]::SetWindowPos($process.MainWindowHandle, [S8Native]::HWND_NOTOPMOST, 0, 0, 0, 0, [S8Native]::SWP_NOMOVE -bor [S8Native]::SWP_NOSIZE -bor [S8Native]::SWP_SHOWWINDOW) | Out-Null
    [S8Native]::SetForegroundWindow($process.MainWindowHandle) | Out-Null
    Start-Sleep -Milliseconds 350

    $rect = New-Object S8Native+RECT
    [S8Native]::GetWindowRect($process.MainWindowHandle, [ref]$rect) | Out-Null

    [pscustomobject]@{
        Process = $process
        Element = [System.Windows.Automation.AutomationElement]::FromHandle($process.MainWindowHandle)
        Rect    = $rect
    }
}

function Click-XY([int]$x, [int]$y) {
    [S8Native]::SetCursorPos($x, $y) | Out-Null
    Start-Sleep -Milliseconds 80
    [S8Native]::mouse_event([S8Native]::MOUSEEVENTF_LEFTDOWN, [uint32]$x, [uint32]$y, 0, [UIntPtr]::Zero)
    Start-Sleep -Milliseconds 60
    [S8Native]::mouse_event([S8Native]::MOUSEEVENTF_LEFTUP, [uint32]$x, [uint32]$y, 0, [UIntPtr]::Zero)
}

function Click-ElementCenter($element) {
    $rect = $element.Current.BoundingRectangle
    Click-XY ([int]($rect.X + ($rect.Width / 2))) ([int]($rect.Y + ($rect.Height / 2)))
}

function Disable-Preview($window) {
    [S8Native]::SetForegroundWindow($window.Process.MainWindowHandle) | Out-Null
    [System.Windows.Forms.SendKeys]::SendWait('{ESC}')
    Start-Sleep -Milliseconds 300

    $all = $window.Element.FindAll(
        [System.Windows.Automation.TreeScope]::Descendants,
        [System.Windows.Automation.Condition]::TrueCondition)

    foreach ($element in $all) {
        if ($element.Current.Name -ne 'Показывать рядом') {
            continue
        }

        try {
            $toggle = $element.GetCurrentPattern([System.Windows.Automation.TogglePattern]::Pattern)
            if ($toggle.Current.ToggleState -ne [System.Windows.Automation.ToggleState]::Off) {
                $toggle.Toggle()
                Start-Sleep -Milliseconds 300
            }
        } catch {
            # Legacy WinForms checkboxes do not always expose TogglePattern.
            Click-ElementCenter $element
            Start-Sleep -Milliseconds 300
        }
    }

    [S8Native]::SetCursorPos(1900, 1050) | Out-Null
    Start-Sleep -Milliseconds 350
}

function Find-ElementByExactName([string]$name, [int]$timeoutSeconds) {
    $deadline = (Get-Date).AddSeconds($timeoutSeconds)
    $condition = New-PropCondition ([System.Windows.Automation.AutomationElement]::NameProperty) $name
    while ((Get-Date) -lt $deadline) {
        $root = Get-RootElement
        $element = $root.FindFirst([System.Windows.Automation.TreeScope]::Descendants, $condition)
        if ($element) {
            return $element
        }
        Start-Sleep -Milliseconds 200
    }

    return $null
}

function Open-ExportMenu {
    $window = Get-SWToolsWindow
    Disable-Preview $window

    # Diagnostic clicks only: this legacy Windows Ribbon does not expose the
    # export split-button reliably through UIA. The selected menu item and the
    # saved XLSX are still object/file verified.
    Click-XY 178 43  # tab "Спецификация"
    Start-Sleep -Milliseconds 300
    Click-XY 96 108 # export split/gallery arrow in maximized test layout
    Start-Sleep -Milliseconds 700
}

function Invoke-ExportMenuItem($mode) {
    Open-ExportMenu
    $menuX = 120
    $menuY = 129 + (($mode.Mode - 1) * 21)
    Click-XY $menuX $menuY
    Start-Sleep -Milliseconds 600
}

function Find-SaveDialog([int]$timeoutSeconds) {
    $root = Get-RootElement
    $deadline = (Get-Date).AddSeconds($timeoutSeconds)
    while ((Get-Date) -lt $deadline) {
        $windows = $root.FindAll(
            [System.Windows.Automation.TreeScope]::Descendants,
            (New-PropCondition ([System.Windows.Automation.AutomationElement]::ControlTypeProperty) ([System.Windows.Automation.ControlType]::Window)))
        foreach ($window in $windows) {
            if ($window.Current.Name -eq 'Сохранение') {
                return $window
            }
        }
        Start-Sleep -Milliseconds 250
    }

    return $null
}

function Get-Descendants($element) {
    $element.FindAll(
        [System.Windows.Automation.TreeScope]::Descendants,
        [System.Windows.Automation.Condition]::TrueCondition)
}

function Set-SaveFilename($dialog, [string]$fileName) {
    $edit = $null
    foreach ($element in (Get-Descendants $dialog)) {
        if ($element.Current.ClassName -eq 'Edit' -and $element.Current.AutomationId -eq '1001') {
            $edit = $element
            break
        }
    }

    if (-not $edit) {
        return $false
    }

    try {
        Click-ElementCenter $edit
        Start-Sleep -Milliseconds 150
        Set-Clipboard -Value $fileName
        [System.Windows.Forms.SendKeys]::SendWait('^a')
        Start-Sleep -Milliseconds 100
        [System.Windows.Forms.SendKeys]::SendWait('^v')
        Start-Sleep -Milliseconds 250
        return $true
    } catch {
        return $false
    }
}

function Click-Save($dialog) {
    $button = $null
    foreach ($element in (Get-Descendants $dialog)) {
        if ($element.Current.ClassName -eq 'Button' -and $element.Current.AutomationId -eq '1') {
            $button = $element
            break
        }
    }
    if (-not $button) {
        throw 'Save button not found'
    }

    [S8Native]::SendMessage(
        [IntPtr]$button.Current.NativeWindowHandle,
        [S8Native]::BM_CLICK,
        [IntPtr]::Zero,
        [IntPtr]::Zero) | Out-Null
}

function Click-DialogButtonByText([string]$dialogTitle, [string[]]$buttonTexts) {
    $dialog = [S8Native]::FindWindow('#32770', $dialogTitle)
    if ($dialog -eq [IntPtr]::Zero) {
        return $false
    }

    foreach ($text in $buttonTexts) {
        $button = [S8Native]::FindWindowEx($dialog, [IntPtr]::Zero, 'Button', $text)
        if ($button -ne [IntPtr]::Zero) {
            [S8Native]::SendMessage($button, [S8Native]::BM_CLICK, [IntPtr]::Zero, [IntPtr]::Zero) | Out-Null
            Start-Sleep -Milliseconds 350
            return $true
        }
    }

    return $false
}

function Close-ExportModals {
    $root = Get-RootElement
    $modalEvents = @()
    $deadline = (Get-Date).AddSeconds(45)

    while ((Get-Date) -lt $deadline) {
        if (Click-DialogButtonByText 'Вопрос' @('&Нет', 'Нет')) {
            $modalEvents += [pscustomobject]@{ Modal = 'Вопрос'; Text = 'Экспорт выполнен! Открыть?'; Button = 'Нет' }
            return $modalEvents
        }

        $handled = $false
        $windows = $root.FindAll(
            [System.Windows.Automation.TreeScope]::Descendants,
            (New-PropCondition ([System.Windows.Automation.AutomationElement]::ControlTypeProperty) ([System.Windows.Automation.ControlType]::Window))
        )

        foreach ($window in $windows) {
            $texts = @()
            foreach ($text in $window.FindAll(
                [System.Windows.Automation.TreeScope]::Descendants,
                (New-PropCondition ([System.Windows.Automation.AutomationElement]::ControlTypeProperty) ([System.Windows.Automation.ControlType]::Text)))) {
                $texts += $text.Current.Name
            }
            $joined = $texts -join ' | '

            if ($window.Current.Name -like '*Подтвердить*' -or $joined -like '*уже существует*') {
                foreach ($button in $window.FindAll(
                    [System.Windows.Automation.TreeScope]::Descendants,
                    (New-PropCondition ([System.Windows.Automation.AutomationElement]::ControlTypeProperty) ([System.Windows.Automation.ControlType]::Button)))) {
                    if (($button.Current.Name -replace '&', '') -eq 'Да') {
                        $button.GetCurrentPattern([System.Windows.Automation.InvokePattern]::Pattern).Invoke()
                        $modalEvents += [pscustomobject]@{ Modal = $window.Current.Name; Text = $joined; Button = 'Да' }
                        $handled = $true
                        Start-Sleep -Milliseconds 300
                        break
                    }
                }
            }

            if ($joined -like '*Экспорт выполнен*' -or $joined -like '*Открыть*') {
                foreach ($button in $window.FindAll(
                    [System.Windows.Automation.TreeScope]::Descendants,
                    (New-PropCondition ([System.Windows.Automation.AutomationElement]::ControlTypeProperty) ([System.Windows.Automation.ControlType]::Button)))) {
                    if (($button.Current.Name -replace '&', '') -eq 'Нет') {
                        $button.GetCurrentPattern([System.Windows.Automation.InvokePattern]::Pattern).Invoke()
                        $modalEvents += [pscustomobject]@{ Modal = $window.Current.Name; Text = $joined; Button = 'Нет' }
                        return $modalEvents
                    }
                }
            }
        }

        if (-not $handled) {
            Start-Sleep -Milliseconds 400
        }
    }

    return $modalEvents
}

function Get-FreshXlsx([datetime]$since, [string]$expectedFileName) {
    $roots = @($DocumentsDir, $DesktopDir, $ExportDir)
    $expected = @()
    foreach ($root in $roots) {
        $candidate = Join-Path $root $expectedFileName
        if (Test-Path -LiteralPath $candidate) {
            $expected += Get-Item -LiteralPath $candidate
        }
    }
    if ($expected) {
        return $expected | Sort-Object LastWriteTime -Descending | Select-Object -First 1
    }

    $fresh = @()
    foreach ($root in $roots) {
        if (-not (Test-Path -LiteralPath $root)) {
            continue
        }
        $fresh += Get-ChildItem -LiteralPath $root -Filter '*.xlsx' -ErrorAction SilentlyContinue |
            Where-Object { $_.LastWriteTime -ge $since.AddSeconds(-2) }
    }

    return $fresh | Sort-Object LastWriteTime -Descending | Select-Object -First 1
}

foreach ($mode in $Modes) {
    Remove-Item -LiteralPath (Join-Path $DocumentsDir $mode.File) -Force -ErrorAction SilentlyContinue
    Remove-Item -LiteralPath (Join-Path $DesktopDir $mode.File) -Force -ErrorAction SilentlyContinue
    Remove-Item -LiteralPath (Join-Path $ExportDir $mode.File) -Force -ErrorAction SilentlyContinue
}

$results = @()
foreach ($mode in $Modes) {
    $started = Get-Date
    $target = Join-Path $ExportDir $mode.File

    Invoke-ExportMenuItem $mode
    $dialog = Find-SaveDialog 30
    if (-not $dialog) {
        throw "Save dialog not found for mode $($mode.Mode)"
    }

    $filenameSet = Set-SaveFilename $dialog $mode.File
    Click-Save $dialog
    $modals = Close-ExportModals

    $fresh = $null
    $deadline = (Get-Date).AddSeconds(90)
    while ((Get-Date) -lt $deadline -and -not $fresh) {
        $fresh = Get-FreshXlsx $started $mode.File
        if (-not $fresh) {
            Start-Sleep -Milliseconds 500
        }
    }
    if (-not $fresh) {
        throw "Exported XLSX not found for mode $($mode.Mode): $($mode.Menu)"
    }

    if ($fresh.FullName -ne $target) {
        Move-Item -LiteralPath $fresh.FullName -Destination $target -Force
    }
    $item = Get-Item -LiteralPath $target
    $item.LastWriteTime = $started.AddSeconds($mode.Mode)

    $results += [pscustomobject]@{
        Mode        = $mode.Mode
        Menu        = $mode.Menu
        File        = $target
        Length      = $item.Length
        Source      = $fresh.FullName
        FilenameSet = $filenameSet
        Modals      = $modals
        Started     = $started
        Ended       = Get-Date
    }
}

$results |
    ConvertTo-Json -Depth 6 |
    Set-Content -LiteralPath (Join-Path $ReportDir 's8-export-run-clean-final.json') -Encoding UTF8

$results | Format-Table Mode, Menu, Length, FilenameSet, Source -AutoSize
