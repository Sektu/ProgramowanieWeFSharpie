let RANGE_LIMIT = 9y;
let NONE_TRANSITION = 0y;

let rec printHugeNumber number:list<sbyte> =
    match number with
    | h::t -> 
            printf "%d" h
            printHugeNumber t
    | [] ->     
            printfn ""
            number  

let rec checkIfAnyElementIsMoreThan9 (number:list<sbyte>) (result:list<sbyte>) transition =
    match number with
    | head::tail -> let theeNumber = head + transition;
                    if( theeNumber > RANGE_LIMIT) 
                        then    let ten = (theeNumber / (RANGE_LIMIT + 1y))
                                let oneness = (theeNumber % (RANGE_LIMIT + 1y))
                                checkIfAnyElementIsMoreThan9 tail (oneness::result) ten     
                    else checkIfAnyElementIsMoreThan9 tail (theeNumber::result) NONE_TRANSITION     
    | [] -> if(transition > NONE_TRANSITION) 
                then transition::result
            else result

let checkHugeNumber (number:list<sbyte>) =
    let numberReversed = List.rev number
    checkIfAnyElementIsMoreThan9 numberReversed [] NONE_TRANSITION

let rec add (number1:list<sbyte>) (number2:list<sbyte>) result =
    match number1, number2 with
    | h1::t1, h2::t2 -> add t1 t2 ((h1+h2)::result)
    | _, h2::t2 ->  add [] t2 (h2::result);
    | h1::t1, _ ->  add t1 [] (h1::result);
    | _, _ -> result;

let addHugeNumbers (n1:list<sbyte>) (n2:list<sbyte>) =
    let number1 = List.rev n1;
    let number2 = List.rev n2;
    match number1, number2 with
    | [], [] -> []
    | _, [] -> n1
    | [], _ -> n2
    | _, _ -> if(number1.Length > number2.Length) 
                then add number1 number2 []
              else add number2 number1 []
                   

let zadanie13 =
    let liczba1 = [6y; 6y; 9y];
    let liczba2 = [5y; 4y; 3y];
    let wynik = addHugeNumbers liczba1 liczba2
    let wynikPoSprawdzeniu = checkHugeNumber wynik
    printHugeNumber wynikPoSprawdzeniu |> ignore
    

[<EntryPoint>]
let main argv = 
    zadanie13
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
