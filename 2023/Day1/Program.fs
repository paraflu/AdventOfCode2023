open Utility.IO

module Day1 =
    let part1 filename =
        let rows = readAllLinesAsync filename |> Async.RunSynchronously

        let result = rows |> Seq.map (fun r -> 
                                            let first:char = r |> Seq.find (fun c -> c >= '0' && c <= '9') 
                                            let last:char = r |> Seq.rev  |> Seq.find (fun c -> c >= '0' && c <= '9') 
                                            int $"{first}{last}"
                                            ) |> Seq.reduce (+)
        printf "part1: %d\n" result


    let Number = [| "1"; "2"; "3"; "4"; "5"; "6"; "7";"8"; "9"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]

    let strRev (str:string) = str |> Seq.rev |> System.String.Concat

    let strToInt reverse (str:string) : int =
        let value = match reverse with 
                    | true -> strRev str
                    | _ -> str
        match value with
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


    let searchNumber reverse (str:string) = 
        let listOfSubstr = match reverse with
                            | true -> Number |> Array.map strRev
                            | false  -> Number

        let value = match reverse with    
                    | true -> strRev str
                    | false -> str

        let arr = listOfSubstr 
                                |> Array.map (fun n -> 
                                    // printf ">%s ~ %s = %d\n" str n (str.IndexOf(n))
                                    (value.IndexOf(n), n)
                    ) 
                            
        

        // printf "search number %A\n" arr

        arr   |> Array.filter (fun (x, _) -> x >= 0) |>  Array.sortBy (fun (x, y) -> x) 
    
    let extract reverse numbers =
        numbers 
        |> Array.map (fun (x, y) -> y) 
        |> Array.head 
        |> strToInt reverse

    let parserRow (r:string) : int =
        let first = r |> searchNumber false |> extract false
        let last = r |> searchNumber true |> extract true
        // printf "%s > %d%d\n" r first last
        int $"{first}{last}"
        
    let part2 filename =
        let rows = readAllLinesAsync filename |> Async.RunSynchronously

        let result = rows |> Seq.map parserRow |> Seq.reduce (+)
        printf "part2: %d\n" result


[<EntryPoint>]
let main args =
    Day1.part1 "day1.txt"
    Day1.part2 "day1.txt"

    // parserRow "194fivefkdk1" |> printf "%d\n"


    0
