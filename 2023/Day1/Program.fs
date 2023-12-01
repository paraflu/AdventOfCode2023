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
    | "1" | "one" -> 1
    | "2" | "two" ->  2
    | "3" | "three" -> 3
    | "4" | "four" -> 4
    | "5" | "five" -> 5
    | "6" | "six" -> 6
    | "7" | "seven" -> 7 
    | "8" | "eight" ->  8
    | "9" | "nine" -> 9
    | _ -> failwith $"Impossibile decodificare il numero {str}"

let searchNumber (str:string) = 
    Number 
    |> Array.map (fun n -> 
                                // printf ">%s ~ %s = %d\n" str n (str.IndexOf(n))
                                (str.IndexOf(n), n)
                ) 
    |> Array.filter (fun (x, _) -> x >= 0)
    |> Array.sortBy (fun (x, y) -> x) 
   
let extract numbers =
    numbers 
    |> Array.map (fun (x, y) -> y) 
    |> Array.head 
    |> strToInt

let parserRow (r:string) : int =
    let first = r |> searchNumber |> extract
    let last = r |> searchNumber |> Array.rev |> extract
    printf "%s > %d%d\n" r first last
    int $"{first}{last}"
    
let day1_part2 filename =
    let rows = readAllLinesAsync filename |> Async.RunSynchronously

    let result = rows |> Seq.map parserRow |> Seq.reduce (+)
    printf "part2: %d\n" result

let ustr (x: string) = ustring.Make(x)

[<EntryPoint>]
let main args =
    // day1_part1 "day1.txt"
    day1_part2 "day1.txt"
    0
