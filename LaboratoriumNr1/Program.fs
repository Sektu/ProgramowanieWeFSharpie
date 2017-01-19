open System;
open System.Linq;

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
//i System.Console.CursorTop.
//
//
//
//a)
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
    | _ ->  drawStar7a currentRow 
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
            drawStar7b (currentRow * 2 - 1)
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
            drawStar7b currentRow
            printf "\n"
            exercise7c (treeHeight - 1) (currentRow + 1)

//8. Utworzyć funkcję która dla podanej liczby całkowitej dodatniej zwróci listę wszystkich
//podzielników większych od 1 i różnej od samej siebie.

let isDivider number divider =
    let result = (number / divider, number % divider)
    match result with
    | (_, 0) -> divider
    | (1, _) -> -2
    | (_, _) -> -1

let rec findAndAddDividerToList input dividersList currentDivider =
    let result = isDivider input currentDivider
    match result with
    | -2    -> dividersList
    | -1    -> findAndAddDividerToList input dividersList (currentDivider + 1)
    |  _    -> findAndAddDividerToList input (result::dividersList) (currentDivider + 1)

//9. Utworzyć funkcję sortującą w porządku nierosnącym listę liczb rzeczywistych.
//dziala, ale jak sa powtarzajace sie liczby to sie psuje :]   
let rec sortiren inputList list =
    match inputList with 
    | [] -> []
    | first::second::others -> 
        if(first > second) then sortiren (first::others) (second::list)
        else sortiren (second::others) (first::list)
    | _ -> inputList @ list

let zadanie9 =
    let lista = [1.6; 3.2; 2.4; 5.3; 4.3; 4.33];
    sortiren lista []

//10. Zdefiniuj funkcję, która dla liczby naturalnej k większej od zera zwróci: true gdy liczba jest
//postaci 4n+1, false gdy liczba jest postaci 4n+3 i wywoła się rekurencyjnie dla n gdy k jest równe
//2n.

let rec isNumberInGoodMood number =
    if (number % 2 = 0) then isNumberInGoodMood (number/2)
    else if ((number - 3) % 4 = 0) then false;
    else if ((number - 1) % 4 = 0) then true;
    else false;

let zadanie10 =
    let liczba = 24;
    isNumberInGoodMood liczba


[<EntryPoint>]
let main argv = 
    printfn "%A" zadanie10
    Console.ReadLine() |> ignore
    0
