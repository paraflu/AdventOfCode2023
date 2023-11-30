open Utility.IO

// type You = 'A' | 'B' | 'C'
type Him = 
    | Rock = 'A'
    | Paper = 'B'
    | Scissor = 'C'

type Me = 
    | Rock = 'X'
    | Paper = 'Y'
    | Scissor = 'Z'

let castHim him =
    match him with
    |"A" -> Him.Rock
    |"B" -> Him.Paper
    |"C" -> Him.Scissor
    | _ -> failwith "Valore errato"
    
let castMe me =
    match me with
    | "X" -> Me.Rock
    | "Y" -> Me.Paper
    | "Z" -> Me.Scissor
    | _ -> failwith (sprintf "Valore errato '%s'" me)
let day2_part1 filename =

    let response = readAllLinesAsync filename
                                        |> Async.RunSynchronously
                                        |> Seq.map (fun s -> s.Split(' '))
                                        |> Seq.map (fun a ->
                                            let x = (castHim a.[0], castMe a.[1])
                                            match x with
                                            | ( Him.Rock, Me.Rock ) -> (1 + 1)
                                            | ( Him.Paper, Me.Rock ) -> (1 + 2) 
                                            | ( Him.Scissor, Me.Rock ) -> (1 + 3) * 2
                                            | ( Him.Rock, Me.Paper ) -> (2 + 1) * 2
                                            | ( Him.Paper, Me.Paper ) -> (2 + 2) 
                                            | ( Him.Scissor, Me.Paper ) -> (2 + 3) 
                                            | ( Him.Rock, Me.Scissor ) -> (3 + 1)  
                                            | ( Him.Paper, Me.Scissor ) -> (3 + 2) * 2
                                            | ( Him.Scissor, Me.Scissor ) -> (3 + 3)
                                            | _ -> -1
                                        )
                                        |> Seq.reduce (+)


    printf "part1: %d\n" response

let day2_part2 filename =
    let rows = readAllTextAsync filename |> Async.RunSynchronously

    printf "part2: %d\n" 0
 

[<EntryPoint>]
let main args =
    banner 2023 2
    day2_part1 "day2"
    day2_part2 "day2"
    0
