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
       
let choice f n =
    match f with 
    | true -> cifrSum n
    | false -> factDown n

let cifrMult n =
    let rec cifrMult1 n curMult =
        if n = 0 then 0
        else
            let n1, cifr = updateVariables n
            let newMult = curMult * cifr
            cifrMult1 n1 newMult
    cifrMult1 n 1

let min n =
    let rec min1 n curMin =
        if n = 0 then curMin
        else
            let n1, cifr = updateVariables n
            let newMin = if cifr < curMin then cifr else curMin
            min1 n1 newMin
    min1 n 9

let max n =
    let rec max1 n curMax =
        if n = 0 then curMax
        else
            let n1, cifr = updateVariables n
            let newMax = if cifr > curMax then cifr else curMax
            max1 n1 newMax
    max1 n 0

let numBypass number func (acc: int option) =
    let accValue = defaultArg acc 0
    accValue + func number

let numBypassCond number func (acc : int option) predicate = 
    let rec bypass n curAcc =
        match n with
        | 0 -> curAcc
        | _ -> 
            let n1, digit = updateVariables n
            match predicate digit with
            | true -> bypass n1 (func curAcc digit)
            | false -> bypass n1 curAcc

    let initialAcc = defaultArg acc 0
    bypass (abs number) initialAcc


[<EntryPoint>]
let main(args : string[]) = 
    //let cifrSumResult = cifrSum 12345
    //System.Console.WriteLine "Sum of digits: "
    //System.Console.WriteLine cifrSumResult
    //let fact5Result = fact 5
    //System.Console.WriteLine "Fact 5: "
    //System.Console.WriteLine fact5Result
    //let fact5DownResult = factDown 5
    //System.Console.WriteLine "Fact5 Down"
    //System.Console.WriteLine fact5DownResult
    //let choiceT = choice true
    //System.Console.WriteLine "choiceT"
    //System.Console.WriteLine choiceT
    //let choiceF = choice false
    //System.Console.WriteLine "choiceF"
    //System.Console.WriteLine choiceF  

    ////С указанием начального значения
    //let numBypassSumRes = numBypass 123 (fun x -> cifrSum x) (Some 5)
    //System.Console.WriteLine "numBypassSumRes"
    //System.Console.WriteLine numBypassSumRes   
    //let numBypassMulRes = numBypass 513 (fun x -> cifrMult x) (Some 5)
    //System.Console.WriteLine "numBypassMulRes"
    //System.Console.WriteLine numBypassMulRes   
    //let numBypassMinRes = numBypass 123 (fun x -> min x) (Some 5)
    //System.Console.WriteLine "numBypassMinRes"
    //System.Console.WriteLine numBypassMinRes  
    //let numBypassMaxRes = numBypass 123 (fun x -> max x) (Some 5)
    //System.Console.WriteLine "numBypassMaxRes"
    //System.Console.WriteLine numBypassMaxRes    
    
    ////Без указания начального значения
    //let numBypassSumRes2 = numBypass 123 (fun x -> cifrSum x) None
    //System.Console.WriteLine "numBypassSumRes2"
    //System.Console.WriteLine numBypassSumRes2  
    //let numBypassMulRes2 = numBypass 513 (fun x -> cifrMult x) None
    //System.Console.WriteLine "numBypassMulRes2"
    //System.Console.WriteLine numBypassMulRes2   
    //let numBypassMinRes2 = numBypass 123 (fun x -> min x) None
    //System.Console.WriteLine "numBypassMinRes2"
    //System.Console.WriteLine numBypassMinRes2
    //let numBypassMaxRes2 = numBypass 123 (fun x -> max x) None
    //System.Console.WriteLine "numBypassMaxRes2"
    //System.Console.WriteLine numBypassMaxRes2  

    //С условием
    let sumEvenDigits = numBypassCond 123456 (+) (Some 0) (fun x -> x % 2 = 0)
    let multOddDigits = numBypassCond 123456 (*) (Some 1) (fun x -> x % 2 = 1)
    let sumGreaterThan5= numBypassCond 123456 (+) (Some 0) (fun x -> x > 5)
    System.Console.Write "Sum of even digits: " 
    System.Console.WriteLine sumEvenDigits
    System.Console.Write "Product of odd digits: " 
    System.Console.WriteLine multOddDigits
    System.Console.Write "Sum of digits > 5: " 
    System.Console.WriteLine sumGreaterThan5
    0
