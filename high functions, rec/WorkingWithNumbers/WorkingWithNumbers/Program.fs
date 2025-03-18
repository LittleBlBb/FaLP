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
    | true -> cifrSum
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

let numBypass number acc func =
    accValue + func number

[<EntryPoint>]
let main(args : string[]) = 
    let cifrSumResult = cifrSum 12345
    System.Console.WriteLine "Sum of digits: "
    System.Console.WriteLine cifrSumResult
    let fact5Result = fact 5
    System.Console.WriteLine "Fact 5: "
    System.Console.WriteLine fact5Result
    let fact5DownResult = factDown 5
    System.Console.WriteLine "Fact5 Down"
    System.Console.WriteLine fact5DownResult
    let choiceT = choice 123 true
    System.Console.WriteLine "choiceT"
    System.Console.WriteLine choiceT
    let choiceF = choice 5 false
    System.Console.WriteLine "choiceF"
    System.Console.WriteLine choiceF  
    let numBypassSumRes = numBypass 123 5 cifrSum
    System.Console.WriteLine "numBypassSumRes"
    System.Console.WriteLine numBypassSumRes   
    let numBypassMulRes = numBypass 513 cifrMult
    System.Console.WriteLine "numBypassMulRes"
    System.Console.WriteLine numBypassMulRes   
    let numBypassMinRes = numBypass 123 5 min
    System.Console.WriteLine "numBypassMinRes"
    System.Console.WriteLine numBypassMinRes  
    let numBypassMaxRes = numBypass 123 5 max
    System.Console.WriteLine "numBypassMaxRes"
    System.Console.WriteLine numBypassMaxRes 
    0
