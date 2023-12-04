
namespace Day3
open Utility.IO
open System.Text.RegularExpressions

module Run =


    let parseNumberFromMatch (m:Match) : int =
        match m with 
        | m when m.Length = 0 -> 0
        | m -> m.Groups[1].Value |> int

    let searchInRow (row:string) pos: seq<int> =

        match row.[pos] with
        | x when x = '.' || (System.Char.IsDigit(x) |> not) -> 
            let before = Regex.Match(row.Substring(0, pos), @"(\d+)$") 
                        |> parseNumberFromMatch
                        
            let after = Regex.Match(row.Substring(pos+1), @"^(\d+)") 
                        |> parseNumberFromMatch

            seq { before; after }
        | x when System.Char.IsDigit(x) -> 
                let middle = Regex.Match(
                                    row.Substring((max 0 (pos-3))),
                                    @"[\.](\d+)[\.]")
                            |> parseNumberFromMatch
                seq { middle }
        | x -> failwith $"Carattere {x} non parsato"
        |> Seq.filter (fun x -> x <> 0)

    let getParts pos (rows:seq<string>) =
        rows 
        |> Seq.map (fun row -> searchInRow row pos) 

    let lines (rows:list<string>) idx = 
        match idx with
            | 0 -> [ rows.[0] ; rows.[1]]
            | x when x = (rows |> Seq.length) -> [rows.[x-1];rows.[x]]
            | x -> [rows.[x-1];rows.[x];rows.[x+1]]
    let parseGear (pattern:Regex) (rows:list<string>) idx   =

        pattern.Matches(rows.[idx]) 
            |> Seq.filter (fun m -> m.Length > 0) // seach any match
            |> Seq.map (fun x -> 
                lines rows idx 
                |> getParts x.Index  
                |> Seq.filter (fun s -> (Seq.length s) > 0)
                |> Seq.concat 
            ) 

    let part1 filename =
        let gearRegExp =    Regex(@"[^\d\.]")

        let rows = readAllLinesAsync filename 
                     |> Async.RunSynchronously
                     |> List.ofArray

        let result = rows 
                    |> Seq.mapi (fun idx  _ -> 
                                                parseGear gearRegExp rows idx
                                                |> Seq.map (fun s -> Seq.sum s)
                                )
                                |> Seq.map Seq.sum
                    |> Seq.sum
        result  

    let part2 filename =
        let gearRegExp =    Regex(@"\*")

        let rows = readAllLinesAsync filename 
                    |> Async.RunSynchronously
                    |> List.ofArray

        let result = rows 
                    |> Seq.mapi (fun idx  _ -> 
                                                parseGear gearRegExp rows idx
                                                |> Seq.filter (fun s -> Seq.length s = 2)
                                                |> Seq.map
                                                     (fun s ->
                                                                // let m = Seq.reduce (*) s
                                                                // printf "part2 %A\n" m
                                                                // m
                                                                Seq.reduce (*) s
                                                    )
                                )
                                |> Seq.map Seq.sum
                    |> Seq.sum
        result  
