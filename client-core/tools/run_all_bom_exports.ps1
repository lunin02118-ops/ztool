# run_all_bom_exports.ps1
# Инструкция для последовательного экспорта всех 8 режимов BOM.
# Запускать на тестовой машине с открытым SolidWorks и подключённой сборкой.
#
# ВАЖНО: Перед запуском убедитесь:
#   1. ZTool.settings содержит 8 пресетов (pre-flight PASS)
#   2. SolidWorks открыт с тестовой сборкой
#   3. ZTool запущен и подключён (Подключить SW)
#   4. Папка для экспорта существует
#
# Использование:
#   .\run_all_bom_exports.ps1
#
# Скрипт НЕ автоматизирует экспорт (требуется UI ZTool).
# Он создаёт пустую папку для каждого прогона и выводит чеклист.

param(
    [string]$ExportDir = "D:\ztool-pr8-test\bom-exports\full-test"
)

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  ТЕСТИРОВАНИЕ 8 РЕЖИМОВ ЭКСПОРТА BOM" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Create clean export directory
if (Test-Path $ExportDir) {
    $ts = Get-Date -Format "yyyyMMdd-HHmm"
    $backup = "${ExportDir}_backup_${ts}"
    Write-Host "Папка $ExportDir существует. Переименовываю в $backup" -ForegroundColor Yellow
    Rename-Item $ExportDir $backup
}
New-Item -ItemType Directory -Path $ExportDir -Force | Out-Null
Write-Host "Создана папка: $ExportDir" -ForegroundColor Green
Write-Host ""

# Checklist
$modes = @(
    @{N=1; Name="Экспорт сводной спецификации";            Type="type=0"; Notes="Сводка, без эскизов, без фильтра"}
    @{N=2; Name="Экспорт иерархической спецификации";      Type="type=1"; Notes="Иерархия (вложенность), без эскизов"}
    @{N=3; Name="Экспорт спецификации верхнего уровня";    Type="type=2"; Notes="Только Level 1 (прямые дочерние)"}
    @{N=4; Name="Экспорт сводной спецификации деталей";    Type="type=3"; Notes="Только .SLDPRT, без подсборок"}
    @{N=5; Name="Экспорт сводной спецификации (с эскизами)"; Type="type=0+img"; Notes="Как №1 + миниатюры в колонке M"}
    @{N=6; Name="Экспорт иерархической спецификации (с эскизами)"; Type="type=1+img"; Notes="Как №2 + миниатюры в колонке M"}
    @{N=7; Name="Обрабатываемые детали";                   Type="type=0+filter"; Notes="Фильтр по Тип (заглушки). Может быть пуст!"}
    @{N=8; Name="Покупные изделия";                        Type="type=0+filter"; Notes="Фильтр по Тип (заглушки). Может быть пуст!"}
)

Write-Host "ПОРЯДОК ЭКСПОРТА (выполняйте последовательно):" -ForegroundColor White
Write-Host "Путь сохранения для всех: $ExportDir" -ForegroundColor White
Write-Host ""

foreach ($m in $modes) {
    Write-Host ("  [{0}] {1}" -f $m.N, $m.Name) -ForegroundColor Yellow
    Write-Host ("      {0} | {1}" -f $m.Type, $m.Notes) -ForegroundColor Gray
}

Write-Host ""
Write-Host "ДЕЙСТВИЯ ДЛЯ КАЖДОГО РЕЖИМА:" -ForegroundColor White
Write-Host "  1. ZTool → меню Спецификация → Экспорт спецификации → выбрать режим"
Write-Host "  2. Сохранить в папку: $ExportDir"
Write-Host "  3. Записать: создался ли файл? Была ли ошибка?"
Write-Host "  4. Перейти к следующему режиму"
Write-Host ""
Write-Host "ПОСЛЕ ЗАВЕРШЕНИЯ ВСЕХ 8:" -ForegroundColor Green
Write-Host "  python client-core\tools\validate_bom_exports.py `"$ExportDir`""
Write-Host ""
Write-Host "КРИТЕРИИ PASS/FAIL:" -ForegroundColor White
Write-Host "  - № п/п (A): заполнен 1..N"
Write-Host "  - Кол-во (G): числа > 0"
Write-Host "  - Путь (O): абсолютные пути"
Write-Host "  - type=1 (иерархия): строк >= type=0 (вложенные компоненты)"
Write-Host "  - type=2 (верхний): строк < type=0 (только Level 1)"
Write-Host "  - type=3 (детали): строк <= type=0 (без подсборок)"
Write-Host "  - img=true: картинки в колонке M"
Write-Host "  - filter: может быть пуст (заглушки); НЕ является FAIL"
Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
