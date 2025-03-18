open System

let updateVariables n =
    let n1 = n / 10
    let cifr = n % 10
    n1, cifr

let rec cifrSumUp n = 
    if n = 0 then 0
    else (n%10) + (cifrSumUp (n / 10))

let cifrSum n =
    let rec cifrSum1 n curSum =
        if n = 0 then curSum
        else
            let n1, cifr = updateVariables n
            let newSum = curSum + cifr
            cifrSum1 n1 newSum
    cifrSum1 n 0

let rec fact n =
    if n = 1 || n = 0 then 1
    else n * (fact (n-1))

let factDown n =
    let rec factDown1 n curMul =
        if n = 1 || n = 0 then curMul
        else
            let newMul = curMul * n
            let n1 = n - 1
            factDown1 n1 newMul
    factDown1 n 1

let choice n f =
    match f with 
    | true -> cifrSum n
    | false -> factDown n

[<EntryPoint>]
let main(args : string[]) = 
    let cifrSumResult = cifrSumUp 12345
    System.Console.WriteLine "Sum of digits: "
    System.Console.WriteLine cifrSumResult
    let cifrSumDownResult = cifrSum 12345
    System.Console.WriteLine "Sum of digits: "
    System.Console.WriteLine cifrSumDownResult
    let choiceT = choice 123 true
    System.Console.WriteLine "choiceT"
    System.Console.WriteLine choiceT
    let choiceF = choice 5 false
    System.Console.WriteLine "choiceF"
    System.Console.WriteLine choiceF  
    0
