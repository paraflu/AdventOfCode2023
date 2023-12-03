namespace Day2
open Utility.IO
open System;
open System.Text.RegularExpressions;

module Run =

    type Color = 
        | Red of int
        | Green of int
        | Blue of int

    let RedCubes = 12
    let GreenCubes = 13
    let BlueCubes = 14

    let isPossible game = 0

    let parseGame row =
        printf "row %s\n" row
        // https://regex101.com/r/dUoG1y/1
        let pattern = @"Game (?<gameno>\d+):(?<set>(\s((?<pick>(?<num>\d+) (?<color>red|green|blue))(?<continue>[,]{0,1}\s*))*);*)*"
        let matches = Regex.Matches(row, pattern, RegexOptions.Multiline)
        matches |> Seq.map (fun m ->
                                    match m.Groups["color"].Value with   
                                    | "red" -> Red(m.Groups["num"].Value |> int)
                                    | "green" -> Green(m.Groups["num"].Value |> int)
                                    | "blue" -> Green(m.Groups["num"].Value |> int)
                                    | _ -> failwith "Color not found"
                    )
        |> printf "ma %A\n" 


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
