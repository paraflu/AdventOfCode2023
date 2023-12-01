open Utility.IO
open Terminal.Gui
open System
open NStack

let day1_part1 filename =
    let rows = readAllLines filename |> Async.RunSynchronously
        |> seq.
    printf "part1: Max calories %d\n" 0

let day1_part2 filename =
    let rows = readAllTextAsync filename |> Async.RunSynchronously
    printf "part2: top3 %d\n" 0

let ustr (x: string) = ustring.Make(x)

[<EntryPoint>]
let main args =
    day1_part1 "day1.txt"
    day1_part2 "day1.txt"
    0
