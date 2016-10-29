//6. Utworzyć funkcję wczytującą liczby wprowadzane z klawiatury, aż do napotkania zera. Jako
//wyjście programu funkcja powinna zwrócić sumę wprowadzonych liczb oraz ich średnią
//geometryczną. Wskazówka: Można posłużyć się funkcją pomocniczą.

open System;

let rec calculateSumOfInputNumbers (sum, product) count = 
    let inputInt = Int32.Parse( Console.ReadLine() )
    let inputDouble = Convert.ToDouble(inputInt)
    if inputInt <> 0 then calculateSumOfInputNumbers ((sum + inputInt), (product * inputDouble)) (count + 1.0)
    else (sum, product ** count)

[<EntryPoint>]
let main argv = 
    let result = calculateSumOfInputNumbers (0, 1.0) 0.0
    printfn "%A" result
    //printfn "%A" (9.0 ** 0.5)
    Console.ReadLine() |> ignore
    0
