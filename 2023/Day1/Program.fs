open Utility.IO

let day1_part1 filename =

    let rows = readAllTextAsync filename |> Async.RunSynchronously

    let maxCalories =
        rows.Trim().Split("\n\n")
        |> Seq.map (fun block -> block.Split("\n") |> Seq.map int |> Seq.reduce (+))
        |> Seq.max

    printf "part1: Max calories %d\n" maxCalories

let day1_part2 filename =
    let rows = readAllTextAsync filename |> Async.RunSynchronously

    let top3 =
        rows.Trim().Split("\n\n")
        |> Seq.map (fun block -> block.Split("\n") |> Seq.map int |> Seq.reduce (+))
        |> Seq.sortDescending
        |> Seq.take 3

        |> Seq.reduce (+)

    printf "part2: top3 %d\n" top3


[<EntryPoint>]
let main args =
    day1_part1 "day1"
    day1_part2 "day1"
    0
