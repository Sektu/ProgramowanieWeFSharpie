//6. Utworzyć funkcję wczytującą liczby wprowadzane z klawiatury, aż do napotkania zera. Jako
//wyjście programu funkcja powinna zwrócić sumę wprowadzonych liczb oraz ich średnią
//geometryczną. Wskazówka: Można posłużyć się funkcją pomocniczą.

open System;

[<EntryPoint>]
let main argv = 
    let input = Console.ReadLine()
    printfn "%A" input
    Console.ReadLine() |> ignore
    0
