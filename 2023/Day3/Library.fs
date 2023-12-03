namespace Day3
open Utility.IO

module Run =

    let trovaAdiacenti (arrayBidimensionale: 'a[,]) (riga: int) (colonna: int) =
        let maxRighe = Array2D.length1 arrayBidimensionale
        let maxColonne = Array2D.length2 arrayBidimensionale

        seq {
            // Controlla l'elemento sopra
            if riga > 0 then yield arrayBidimensionale.[riga - 1, colonna]

            // Controlla l'elemento sotto
            if riga < maxRighe - 1 then yield arrayBidimensionale.[riga + 1, colonna]

            // Controlla l'elemento a sinistra
            if colonna > 0 then yield arrayBidimensionale.[riga, colonna - 1]

            // Controlla l'elemento a destra
            if colonna < maxColonne - 1 then yield arrayBidimensionale.[riga, colonna + 1]

            // Se desideri controllare anche gli angoli, puoi aggiungere queste condizioni:
            // Controlla l'elemento in alto a sinistra
            if riga > 0 && colonna > 0 then yield arrayBidimensionale.[riga - 1, colonna - 1]

            // Controlla l'elemento in alto a destra
            if riga > 0 && colonna < maxColonne - 1 then yield arrayBidimensionale.[riga - 1, colonna + 1]

            // Controlla l'elemento in basso a sinistra
            if riga < maxRighe - 1 && colonna > 0 then yield arrayBidimensionale.[riga + 1, colonna - 1]

            // Controlla l'elemento in basso a destra
            if riga < maxRighe - 1 && colonna < maxColonne - 1 then yield arrayBidimensionale.[riga + 1, colonna + 1]
        }


    let part1 filename =

        let rows = readAllLinesAsync filename 
                     |> Async.RunSynchronously
        let result = 0
        result  

    let part2 filename =
        let rows = readAllLinesAsync filename 
                     |> Async.RunSynchronously
        let result = 0
        result  
