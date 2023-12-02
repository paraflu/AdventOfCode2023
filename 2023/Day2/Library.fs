namespace Day2
open Utility.IO
open System;
open System.Text.RegularExpressions;

module Run =

    let parseGame row =
        let pattern = "Game (?<gameno>\d+):(\s(?<num>\d+) (?<color>red|green|blue)(?<continue>[,;])*"
        Regex.Matches(row, pattern, RegexOptions.Multiline)
                                |> Seq.map (fun m -> (m.Groups["color"].Value, m.Groups["num"].Value |> int))
                                |> Map.ofSeq
                                |> printf "%A\n" 


    let part1 filename =

        let row = readAllLinesAsync filename 
                     |> Async.RunSynchronously
        
        row |> Array.iter parseGame

        let result = 0
        // printf "[!] Part1 %d" result
        result  

    let part2 filename =
        let result = 0
        // printf "[!] Part2 %d" result
        result
