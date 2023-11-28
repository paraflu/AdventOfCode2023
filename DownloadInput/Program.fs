open System
open CommandLine
open System.Collections
open System.Net
open FSharp.Data

type options =  {
      [<Option('d', "days", Required = true, HelpText = "Giorno da elaborare")>]
      day: int;
      [<Option('y', "year", Required = false, Default = 0, HelpText = "Anno di riferimento")>]
      year: int;
      [<Option('c', "cookie", Required = true, HelpText = "Cookie di sessione")>]
      cookie: string;
    }

let run (parsed: options) =
    let cc = CookieContainer()

    let cookie =
        Cookie("session", parsed.cookie, "/", "adventofcode.com")

    cc.Add cookie

    let year =  match parsed.year with 
                | 0 -> DateTime.Now.Year
                | _ -> parsed.year
    let url = sprintf "https://adventofcode.com/%d/day/%d/input"  year parsed.day
    let response =
        Http.RequestString(url, cookieContainer = cc)

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
