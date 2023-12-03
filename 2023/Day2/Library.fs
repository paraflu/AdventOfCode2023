namespace Day2
open Utility.IO
open System;
open System.Text.RegularExpressions;

module Run =

    type Color = 
        | Red of int
        | Green of int
        | Blue of int

    let getColorValue color =
        match color with
        | Red value -> value
        | Green value -> value
        | Blue value -> value
    let RedCubes = 12
    let GreenCubes = 13
    let BlueCubes = 14

    let isPossible game = 0

    let gameImpossible c =  match c with
                                    | Red(v) -> v > RedCubes
                                    | Green(v) -> v > GreenCubes
                                    | Blue(v) -> v > BlueCubes

    let parseGame row =
        printf "row %s\n" row
        // https://regex101.com/r/dUoG1y/1
        // let pattern = @"Game (?<gameno>\d+):(?<set>(\s((?<pick>(?<num>\d+) (?<color>red|green|blue))(?<continue>[,]{0,1}\s*))*);*)*"
        // let matches = Regex.Matches(row, pattern, RegexOptions.Multiline)
        // matches[0].Groups
        //  |> Seq.filter (fun g -> g.Name = "pick")
        //  |> Seq.map (fun m ->
        //                             match m["color"].Value with   
        //                             | "red" -> Red(m["num"].Value |> int)
        //                             | "green" -> Green(m["num"].Value |> int)
        //                             | "blue" -> Green(m["num"].Value |> int)
        //                             | _ -> failwith "Color not found"
        //             )
        // |> printf "ma %A\n" 
        let matches = Regex.Matches(row, @"Game (?<gameno>\d+):", RegexOptions.Multiline)
        let gameNo = matches[0].Groups[1].Value |> int
        let colors = row.Split ";" 
                    |>  Seq.map (fun pick -> 
                        let m = Regex.Matches(pick, "(?<num>\d+)\s(?<color>red|green|blue)")
                        m |> Seq.map (fun m -> 
                                                        printf "%A," m.Groups
                                                        match m.Groups["color"].Value with   
                                                        | "red" -> Red(m.Groups["num"].Value |> int)
                                                        | "green" -> Green(m.Groups["num"].Value |> int)
                                                        | "blue" -> Green(m.Groups["num"].Value |> int)
                                                        | _ -> failwith "Color not found"
                                                        |> gameImpossible
                        ) |> Seq.exists (fun x -> x)
                    ) 

        printf "\n%A\n" colors |> Seq.isEmpty
        match colors |> Seq.isEmpty with
        | true -> 0
        | _ -> gameNo

    let part1 filename =

        let row = readAllLinesAsync filename 
                     |> Async.RunSynchronously
        
        let result= row |> Seq.map parseGame |> Seq.sum

        // printf "[!] Part1 %d" result
        result  

    let part2 filename =
        let result = 0
        // printf "[!] Part2 %d" result
        result
