
namespace Day4 
open Utility.IO
open System.Text.RegularExpressions

module Run =

    let rec score (winsize: list<int>) = 
          match winsize with
            | [] -> 0
            | [_] -> 1
            | _ :: tail -> ( 2 * score tail)

    let getCards cardList =
        let matches = Regex.Matches(cardList, @"(\d+)\s*" )
        matches 
        |> Seq.cast<Match> 
        |> Seq.map (fun g -> g.Groups[1].Value |> int)
        |> Set.ofSeq

    let parseCard row = 
            let matches = 
                Regex.Matches(row, @"Card\s+(\d+):\s*(.*)$")

            let m = matches.[0]
            // let cardNo = m.Groups[1].Value |> int
            // let cardList = Regex.Matches(m.Groups[2].Value, @"(\d+)[\s\]*"s)
            let split = Regex.Split(m.Groups[2].Value, @"\|") 
            let cardList = split|> Array.head |> getCards

            let mineCard = split|> Array.rev |> Array.head |> getCards


            let winner = Set.intersect mineCard cardList |> Set.toList

                
            let s= score winner
            s


    let part1 filename =
        let rows = readAllLinesAsync filename 
                     |> Async.RunSynchronously
                     |> List.ofArray

       
        let result = rows |> Seq.map parseCard |> Seq.sum   

        result

    let part2 filename =
        let rows = readAllLinesAsync filename 
                     |> Async.RunSynchronously
                     |> List.ofArray
                     

        let result = 0
        result