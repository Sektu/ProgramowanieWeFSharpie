//6. Utworzyć funkcję wczytującą liczby wprowadzane z klawiatury, aż do napotkania zera. Jako
//wyjście programu funkcja powinna zwrócić sumę wprowadzonych liczb oraz ich średnią
//geometryczną. Wskazówka: Można posłużyć się funkcją pomocniczą.

open System;

let calculateAverages input (sum, product) counter =
    match input with
    | 0 -> (sum, Math.Pow(product,  (1.0 / counter)))
    | _ -> ((sum + input), (product * Convert.ToDouble(input)))

let rec exerciseSix (sum, product) counter = 
    let isTrue, input = Int32.TryParse( Console.ReadLine() )
    match isTrue with
    | true ->   let result = calculateAverages input (sum, product) counter
                exerciseSix result (counter + 1.0)
    | false ->  (sum, product)

[<EntryPoint>]
let main argv = 
    let result = exerciseSix (0, 1.0) 0.0
    printfn "%A" result

    Console.ReadLine() |> ignore
    0
