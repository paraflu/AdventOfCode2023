param(
    [int]
    $Day = $(get-date -format "dd"),
    [int]
    $Year = $(get-date -format "yyyy"),
    [string]
    $Cookie="53616c7465645f5f801f37af0b90d92cb48de785514fc93778d9e103394ee1069478dd97cbd6468c0d936ffb31d9abe69022a224d8339da0633cf856c89d9bbb"
)


if ($Day -gt 25) {
    $Day = 25
}

cd $PSScriptRoot/DownloadInput
write-host -ForegroundColor Green "Esportazione dati di input $Year del giorno $Day"
dotnet run -c Release -- -d $Day --year $Year -c "$Cookie"
cd $PSScriptRoot
