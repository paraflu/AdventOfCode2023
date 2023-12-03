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

    let filtraPerTipoColor colore sequenza =
        sequenza
        |> Seq.filter (fun c ->
            match c with
            | Red _ when colore = "Red" -> true
            | Green _ when colore = "Green" -> true
            | Blue _ when colore = "Blue" -> true
            | _ -> false
        )


    let RedCubes = 12
    let GreenCubes = 13
    let BlueCubes = 14

    let gameImpossible c =  match c with
                                    | Red(v) -> v > RedCubes
                                    | Green(v) -> v > GreenCubes
                                    | Blue(v) -> v > BlueCubes

    let parseGame row = 
        let matches = Regex.Matches(row, @"Game (?<gameno>\d+):", RegexOptions.Multiline)
        let gameNo = matches[0].Groups[1].Value |> int

        let gameSet = row.Split ";" 
                                    |>  Seq.map (fun pick -> 
                                        let m = Regex.Matches(pick, "(?<num>\d+)\s(?<color>red|green|blue)")

                                        let colors = m |> Seq.map (fun m -> 
                                                                        // printf "%A," m.Groups
                                                                        let color = match m.Groups["color"].Value with   
                                                                                        | "red" -> Red(m.Groups["num"].Value |> int)
                                                                                        | "green" -> Green(m.Groups["num"].Value |> int)
                                                                                        | "blue" -> Blue(m.Groups["num"].Value |> int)
                                                                                        | _ -> failwith "Color not found"
                                                                        color )
                                        colors)
        (gameNo, gameSet)

    let solutionPart1 row =
        
        let (gameNo, gameSet) = parseGame row

        match gameSet |> Seq.concat |> Seq.exists gameImpossible with
        | false -> gameNo
        | _ -> 0

    let solutioPart2 row = 
        let (_, gameSet) = parseGame row

        let maxRed = gameSet 
                        |> Seq.map (filtraPerTipoColor "Red")
                        |> Seq.concat
                        |> Seq.maxBy getColorValue
        let maxGreen = gameSet 
                        |> Seq.map (filtraPerTipoColor "Green")
                        |> Seq.concat
                        |> Seq.maxBy getColorValue

        let maxBlue = gameSet 
                        |> Seq.map ( filtraPerTipoColor "Blue")
                        |> Seq.concat
                        |> Seq.maxBy getColorValue

        [maxRed; maxGreen; maxBlue] |> Seq.ofList 
                                    |> Seq.map getColorValue 
                                    |> Seq.reduce (*)



    let part1 filename =

        let row = readAllLinesAsync filename 
                     |> Async.RunSynchronously
        
        let result= row |> Seq.map solutionPart1 |> Seq.sum

        result  

    let part2 filename =
        let result = readAllLinesAsync filename 
                            |> Async.RunSynchronously 
                            |> Seq.map solutioPart2 
                            |> Seq.sum

        result
