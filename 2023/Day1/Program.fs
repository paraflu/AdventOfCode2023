open Utility.IO
open Terminal.Gui
open System
open NStack

let day1_part1 filename =
    let rows = readAllLinesAsync filename |> Async.RunSynchronously

    let result = rows |> Seq.map (fun r -> 
                                        let first:char = r |> Seq.find (fun c -> c >= '0' && c <= '9') 
                                        let last:char = r |> Seq.rev  |> Seq.find (fun c -> c >= '0' && c <= '9') 
                                        int $"{first}{last}"
                                        ) |> Seq.reduce (+)
    printf "part1: %d\n" result


let Number = [| "0"; "1"; "2"; "3"; "4"; "5"; "6"; "7";"8"; "9"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]

let strToInt (str:string) : int =
    match str with
    | "0" | "one" -> 1
    | "2" | "two" ->  2
    | "3" | "three" -> 3
    | "4" | "four" -> 4
    | "5" | "five" -> 5
    | "6" | "six" -> 6
    | "7" | "seven" -> 7 
    | "8" | "eight" ->  8
    | "9" | "nine" -> 9
    | _ -> failwith "Impossibile decodificare il numero"

let searchNumber (str:string) = 
    Number |> Array.map (fun n -> (str.IndexOf(n), int n)) 

let parserRow (r:string) : int =
    let first:char = r |> searchNumber |> Array.head 
    match r.Substring(first, 1) with
        | "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" |"9" -> 
    let last:char = r |> Seq.rev |>  searchNumber |> Array.head |> strToInt
    int $"{first}{last}"
    
let day1_part2 filename =
    let rows = readAllLinesAsync filename |> Async.RunSynchronously

    let result rows |> Seq.map parseRow
    printf "part2: %d\n" 0

let ustr (x: string) = ustring.Make(x)

[<EntryPoint>]
let main args =
    day1_part1 "day1.txt"
    day1_part2 "day1.txt"
    0
