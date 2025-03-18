open System

let rec cifrSumUp n = 
    if n = 0 then 0
    else (n%10) + (cifrSumUp (n / 10))

[<EntryPoint>]
let main(args : string[]) = 
    let cifrSumResult = cifrSumUp 12345
    System.Console.WriteLine "Sum of digits: "
    System.Console.WriteLine cifrSumResult
    0
