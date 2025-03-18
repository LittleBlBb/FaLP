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

[<EntryPoint>]
let main(args : string[]) = 
    let cifrSumResult = cifrSumUp 12345
    System.Console.WriteLine "Sum of digits: "
    System.Console.WriteLine cifrSumResult
    let cifrSumDownResult = cifrSum 12345
    System.Console.WriteLine "Sum of digits: "
    System.Console.WriteLine cifrSumDownResult
    0
