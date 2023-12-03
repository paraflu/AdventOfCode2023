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

type Result = Loose | Draw | Win

let castResult res = 
    match res with 
    | "X" -> Result.Loose
    | "Y" -> Result.Draw
    | "Z" -> Result.Win
    | _ -> failwith (sprintf "Valore errato '%s'" res)

let day2_part1 filename =

    let response = readAllLinesAsync filename
                                        |> Async.RunSynchronously
                                        |> Seq.map (fun s -> s.Split(' '))
                                        |> Seq.map (fun a ->
                                            let x = (castHim a.[0], castMe a.[1])
                                            match x with
                                            | ( Him.Rock, Me.Rock ) -> 1 + 3
                                            | ( Him.Paper, Me.Rock ) -> 1 + 0
                                            | ( Him.Scissor, Me.Rock )  -> 1 + 6
                                            | ( Him.Rock, Me.Paper ) -> 2 + 6
                                            | ( Him.Paper, Me.Paper ) -> 2 + 3
                                            | ( Him.Scissor, Me.Paper ) -> 2 + 0
                                            | ( Him.Rock, Me.Scissor ) -> 3 + 0
                                            | ( Him.Paper, Me.Scissor ) -> 3 + 6
                                            | ( Him.Scissor, Me.Scissor ) -> 3 + 3
                                            | _ -> -1
                                        )
                                        |> Seq.reduce (+)


    printf "part1: %d\n" response

let day2_part2 filename =

    let response = readAllLinesAsync filename
                    |> Async.RunSynchronously
                    |> Seq.map (fun s -> s.Split(' '))
                    |> Seq.map (fun a ->
                        let x = (castHim a.[0], castResult a.[1])
                        match x with
                        | ( Him.Rock, Result.Draw ) -> 1 + 3
                        | ( Him.Paper, Result.Loose ) -> 1 + 0
                        | ( Him.Scissor, Result.Win )  -> 1 + 6
                        | ( Him.Rock, Result.Win ) -> 2 + 6
                        | ( Him.Paper, Result.Draw ) -> 2 + 3
                        | ( Him.Scissor, Result.Loose ) -> 2 + 0
                        | ( Him.Rock, Result.Loose ) -> 3 + 0
                        | ( Him.Paper, Result.Win ) -> 3 + 6
                        | ( Him.Scissor, Result.Draw ) -> 3 + 3
                        | _ -> -1
                    )
                    |> Seq.reduce (+)


    printf "part2: %d\n" response
 

[<EntryPoint>]
let main args =
    banner 2023 2
    day2_part1 "day2"
    day2_part2 "day2"
    0
