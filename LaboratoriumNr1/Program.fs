open System;

//6. Utworzyć funkcję wczytującą liczby wprowadzane z klawiatury, aż do napotkania zera. Jako
//wyjście programu funkcja powinna zwrócić sumę wprowadzonych liczb oraz ich średnią
//geometryczną. Wskazówka: Można posłużyć się funkcją pomocniczą.

let calculateAverages(input, (sum, product), counter) =
    match input with
    | 0 -> (sum, Math.Pow(product,  (1.0 / counter)))
    | _ -> ((sum + input), (product * Convert.ToDouble(input)))

let rec exercise6 (sum, product) counter = 
    let isTrue, input = Int32.TryParse( Console.ReadLine() )
    match isTrue with
    | true -> exercise6 ( calculateAverages( input, (sum, product), counter) ) (counter + 1.0)
    | false -> (sum, product)

//7. Utworzyć funkcje rysujące piramidy z gwiazdek o poniższym kształcie przy zadanej liczbie
//wierszy nie większej niż parametry okna. Liczbę znaków mieszczących się w oknie można
//odczytać za pomocą właściwości: System.Console.WindowWidth i System.Console.WindowHeight.
//Nie można posługiwać się właściwościami System.Console.CursorLeft
//i System.Console.CursorTop.////a)
//*
//**
//***
//****
//*****
let rec drawStar7a currentRow =
    match currentRow with
    | 0 ->  printf "\n"
            ()
    | _ ->  printf "*"
            drawStar7a (currentRow - 1) 

let rec exercise7a treeHeight currentRow =
    match treeHeight with
    | 0 ->  ()
    | _ ->  drawStar7a (currentRow + 1)
            exercise7a (treeHeight - 1) (currentRow + 1)
//b
//    *
//   ***
//  *****
// *******
//*********
let rec drawStar7b amount =
    match amount with
    | 0 ->  ()
    | _ ->  printf "*"
            drawStar7b (amount - 1)

let rec drawEmptySigns7b treeHeight =
    match treeHeight with
    | 0 ->  ()
    | _ ->  printf " "
            drawEmptySigns7b (treeHeight - 1)

let rec exercise7b treeHeight currentRow =
    match treeHeight with
    | 0 ->  ()
    | _ ->  drawEmptySigns7b (treeHeight - 1)
            drawStar7b ((currentRow * 2) + 1)
            printf "\n"
            exercise7b (treeHeight - 1) (currentRow + 1)
//c
//    *
//   **
//  ***
// ****
//*****
let rec exercise7c treeHeight currentRow =
    match treeHeight with 
    | 0 ->  ()
    | _ ->  drawEmptySigns7b (treeHeight - 1)
            drawStar7b (currentRow + 1)
            printf "\n"
            exercise7c (treeHeight - 1) (currentRow + 1)

[<EntryPoint>]
let main argv = 
    //printfn "window_width = %d, window_height = %d" Console.WindowWidth Console.WindowHeight
    
    exercise7a 5 0 
    printfn ""
    exercise7b 5 0
    printfn ""
    exercise7c 5 0
    Console.ReadLine() |> ignore
    0
