
namespace Day4 
open Utility.IO

module Run =

    let part1 filename =
        let rows = readAllLinesAsync filename 
                     |> Async.RunSynchronously
                     |> List.ofArray

        0

    let part2 filename =
        let rows = readAllLinesAsync filename 
                     |> Async.RunSynchronously
                     |> List.ofArray

        0