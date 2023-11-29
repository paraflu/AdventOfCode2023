#!/bin/bash
red=$(tput setaf 1)
green=$(tput setaf 2)
yellow=$(tput setaf 3)
reset=$(tput sgr0)

options=$(getopt -l "day:,year:,cookie" -o "d:y:c:" -a -- "$@")

eval set -- "$options"

day=$(date +"%d")
year=$(date +"%Y")
cookie="53616c7465645f5f801f37af0b90d92cb48de785514fc93778d9e103394ee1069478dd97cbd6468c0d936ffb31d9abe69022a224d8339da0633cf856c89d9bbb"

while :; do
    case "$1" in
    -c | --cookie)
        cookie=$2
        shift
        ;;
    -d | --days)
        day=$2
        shift
        ;;
    -y | --year)
        year=$2
        shift
        ;;
    --)
        shift
        break
        ;;
    esac
    shift
done

day=$((day <= 25 ? day : 25))

(
    cd DownloadInput >/dev/null 2>&1 || exit
    printf "\n${green}Download input data for day ${yellow}%d${green} of ${yellow}AdventOfCode%d${green}...${reset}\n\n" "$day" "$year"
    dotnet run -c Release -- -d "$day" \
        --year "${year:-2022}" \
        -c "$cookie"
)
