open System
open CommandLine
open System.Collections
open System.Net
open FSharp.Data

// For more information see https://aka.ms/fsharp-console-apps
// printfn "Hello from F#"

// Console.ReadLine() |> ignore

type options =
    { [<Option('d', "days", Required = true, HelpText = "Giorno da elaborare")>]
      day: int
      [<Option('c', "cookie", Required = true, HelpText = "Cookie di sessione")>]
      cookie: string }

let run (parsed: options) =
    let cc = CookieContainer()

    let cookie =
        Cookie("session", parsed.cookie, "/", "adventofcode.com")

    cc.Add cookie

    let response =
        Http.RequestString("https://adventofcode.com/2022/day/1/input", cookieContainer = cc)

    printf "%s" response



let fail (list_errors: seq<Error>) =
    list_errors |> Seq.iter (fun x -> printf "%A" x)

[<EntryPoint>]
let main argv =
    let result =
        CommandLine.Parser.Default.ParseArguments<options>(argv)

    match result with
    | :? Parsed<options> as parsed -> run parsed.Value
    | :? NotParsed<options> as notParsed -> fail notParsed.Errors
    | _ -> failwith "invalid parser result"

    0
