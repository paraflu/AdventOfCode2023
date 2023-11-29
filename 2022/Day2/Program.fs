open Utility.IO

type You = 'A' | 'B' | 'C'
type Other = 'X' | 'Y' | 'Z'

let match elf1 elf2 =
    match (elf1, elf2) 
let day2_part1 filename =

    readAllLinesAsync filename
    |> Async.RunSynchronously
    |> Seq.map (fun s -> s.Split())
    |> Seq.map match

    printf "part1: %d\n" 0

let day2_part2 filename =
    let rows = readAllTextAsync filename |> Async.RunSynchronously

    printf "part2: %d\n" 0


[<EntryPoint>]
let main args =
    banner 2023 2
    day2_part1 "day2"
    day2_part2 "day2"
    0
