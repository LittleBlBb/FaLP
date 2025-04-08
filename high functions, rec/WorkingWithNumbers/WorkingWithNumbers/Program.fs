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


type Widget = { ID: int; Rev: int }

let compareWidgets w1 w2 =
    if w1.ID < w2.ID then -1 else
    if w1.ID > w2.ID then 1 else
    if w1.Rev > w2.Rev then -1 else
    if w1.Rev > w2.Rev then 1 else
    0

let progLang input = 
    match input with 
        | "prolog" | "f#" -> "Podliza"
        | _ -> "ne podliza"

let progLangSupPos input = 
    match input with 
        | "prolog" | "f#" -> "Podliza"
        | _ -> "ne podliza"

let progLangCarr input = 
    match input with 
        | "prolog" | "f#" -> "Podliza"
        | _ -> "ne podliza"



////[<EntryPoint>]
////let main(args : string[]) = 
////    //let cifrSumResult = cifrSum 12345
////    //System.Console.WriteLine "Sum of digits: "
////    //System.Console.WriteLine cifrSumResult
////    //let fact5Result = fact 5
////    //System.Console.WriteLine "Fact 5: "
////    //System.Console.WriteLine fact5Result
////    //let fact5DownResult = factDown 5
////    //System.Console.WriteLine "Fact5 Down"
////    //System.Console.WriteLine fact5DownResult
////    //let choiceT = choice true
////    //System.Console.WriteLine "choiceT"
////    //System.Console.WriteLine choiceT
////    //let choiceF = choice false
////    //System.Console.WriteLine "choiceF"
////    //System.Console.WriteLine choiceF  

////    ////С указанием начального значения
////    //let numBypassSumRes = numBypass 123 (fun x -> cifrSum x) (Some 5)
////    //System.Console.WriteLine "numBypassSumRes"
////    //System.Console.WriteLine numBypassSumRes   
////    //let numBypassMulRes = numBypass 513 (fun x -> cifrMult x) (Some 5)
////    //System.Console.WriteLine "numBypassMulRes"
////    //System.Console.WriteLine numBypassMulRes   
////    //let numBypassMinRes = numBypass 123 (fun x -> min x) (Some 5)
////    //System.Console.WriteLine "numBypassMinRes"
////    //System.Console.WriteLine numBypassMinRes  
////    //let numBypassMaxRes = numBypass 123 (fun x -> max x) (Some 5)
////    //System.Console.WriteLine "numBypassMaxRes"
////    //System.Console.WriteLine numBypassMaxRes    
    
////    ////Без указания начального значения
////    //let numBypassSumRes2 = numBypass 123 (fun x -> cifrSum x) None
////    //System.Console.WriteLine "numBypassSumRes2"
////    //System.Console.WriteLine numBypassSumRes2  
////    //let numBypassMulRes2 = numBypass 513 (fun x -> cifrMult x) None
////    //System.Console.WriteLine "numBypassMulRes2"
////    //System.Console.WriteLine numBypassMulRes2   
////    //let numBypassMinRes2 = numBypass 123 (fun x -> min x) None
////    //System.Console.WriteLine "numBypassMinRes2"
////    //System.Console.WriteLine numBypassMinRes2
////    //let numBypassMaxRes2 = numBypass 123 (fun x -> max x) None
////    //System.Console.WriteLine "numBypassMaxRes2"
////    //System.Console.WriteLine numBypassMaxRes2  

////    ////С условием
////    //let sumEvenDigits = numBypassCond 123456 (+) (Some 0) (fun x -> x % 2 = 0)
////    //let multOddDigits = numBypassCond 123456 (*) (Some 1) (fun x -> x % 2 = 1)
////    //let sumGreaterThan5= numBypassCond 123456 (+) (Some 0) (fun x -> x > 5)
////    //System.Console.Write "Sum of even digits: " 
////    //System.Console.WriteLine sumEvenDigits
////    //System.Console.Write "Product of odd digits: " 
////    //System.Console.WriteLine multOddDigits
////    //System.Console.Write "Sum of digits > 5: " 
////    //System.Console.WriteLine sumGreaterThan5
    
    
////    //let list = [1;2;3]
////    //let listsItem2 = list.Item(0)
////    //Console.WriteLine list.Head
////    //Console.WriteLine list.Tail.Head
////    //Console.WriteLine listsItem2
////    //Console.WriteLine list.Length
////    Console.WriteLine("What is your favorite programming language?")
////    let readInput = Console.ReadLine().ToLower()
////    let printResult = progLang >> Console.WriteLine
////    readInput |> printResult

////    (Console.ReadLine >> (fun s -> s.ToLower()) >> progLang >> Console.WriteLine) ()

    

    



////    0

//// Дополнительные сведения о F# см. на http://fsharp.net
//// Дополнительную справку см. в проекте "Учебник по F#".

//let rec readList n = 
//    if n=0 then []
//    else
//    let Head = System.Convert.ToInt32(System.Console.ReadLine())
//    let Tail = readList (n-1)
//    Head::Tail

//let readData = 
//    let n=System.Convert.ToInt32(System.Console.ReadLine())
//    readList n

//let rec writeList = function 
//    |   [] -> System.Console.ReadKey() 
//    | (head : int)::tail -> 
//        System.Console.WriteLine(head) 
//        writeList tail  

//let max2 x y = if x > y then x else y

//let rec accCond list (f : int -> int -> int) p acc = 
//    match list with
//    | [] -> acc
//    | h::t ->
//                let newAcc = f acc h
//                if p h then accCond t f p newAcc
//                else accCond t f p acc

//let listMin list = 
//    match list with 
//    |[] -> 0
//    | h::t -> accCond list (fun x y -> if x < y then x else y) (fun x -> true) h

//let listMax list = 
//    match list with 
//    |[] -> 0
//    | h::t -> accCond list max2 (fun x -> true) h

//let listSum list = accCond list (fun x y -> x + y) (fun x -> true) 0

//let listPr list = accCond list (fun x y -> x * y) (fun x -> true) 1

//let f6 list = 
//    match list with
//    |[] -> 0
//    | h::t ->   if (h % 2 = 0) then accCond t max2 (fun x -> ((x % 2) = 0)) h
//                else accCond t max2 (fun x -> ((x % 2) <> 0) ) h

//let rec frequency list elem count =
//        match list with
//        |[] -> count
//        | h::t -> 
//                        let count1 = count + 1
//                        if h = elem then frequency t elem count1 
//                        else frequency t elem count

//let rec freqList list mainList curList = 
//        match list with
//        | [] -> curList
//        | h::t -> 
//                    let freqElem = frequency mainList h 0
//                    let newList = curList @ [freqElem]
//                    freqList t mainList newList

//let pos list el = 
//    let rec pos1 list el num = 
//        match list with
//            |[] -> 0
//            |h::t ->    if (h = el) then num
//                        else 
//                            let num1 = num + 1
//                            pos1 t el num1
//    pos1 list el 1

//let getIn list pos = 
//    let rec getIn1 list num curNum = 
//        match list with 
//            |[] -> 0
//            |h::t -> if num = curNum then h
//                     else 
//                            let newNum = curNum + 1
//                            getIn1 t num newNum
//    getIn1 list pos 1

//let f7 list = 
//    let fL = freqList list list []
//    (listMax fL) |> (pos fL) |> (getIn list)           

//let filter list pr = 
//    let rec filter1 list pr newList = 
//        match list with
//        | [] -> newList
//        | h::t ->
//                let newnewList = newList @ [h]
//                if pr h then filter1 list pr newnewList
//                else filter1 list pr newList
//    filter1 list pr [] 

//let even n = ((n % 2) = 0)

//let f8Cond list el = (even el) && (even (frequency list el 0))

//let f8 list = filter list (f8Cond list)

//let delEL list el = filter list (fun x -> (x <> el))

//let uniq list = 
//    let rec uniq1 list newList = 
//        match list with
//            |[] -> newList
//            | h::t -> 
//                        let listWithout = delEL t h
//                        let newnewList = newList @ [h]
//                        uniq1 listWithout newnewList
//    uniq1 list [] 

//let rec cifrSum n = 
//    if n = 0 then 0
//    else (n%10) + (cifrSum (n / 10))

//let f9Cond el = ((cifrSum el) > 9) || (even el)

//let f9 list = filter list f9Cond

//let count x y = x + 1

//let f10Cond list El = (accCond list count (fun x -> ((x * x) = El)) 0) > 0

//let f10 list = accCond list count (f10Cond list) 0   

//[<EntryPoint>]
//let main argv = 
//    //writeList readData

    


//    let l = readData

//    System.Console.WriteLine(accCond [1;2;3;4] (fun x y -> x + y) (fun x -> x % 2 = 0) 0)
//    System.Console.WriteLine(accCond [1;2;3;4] (fun x y -> x + y) (fun x -> x % 2 = 1) 0)
//    System.Console.WriteLine(accCond [1;2;3;4] max2 (fun x -> x % 2 = 0))



//    let sum : int = listSum l
//    let pr : int= listPr l
//    let min : int= listMin l
//    let max : int= listMax l
//    System.Console.WriteLine((sum,pr,min,max))
    
//    let ans = f7 l
//    System.Console.WriteLine(ans)
//    let z = System.Console.ReadKey()
//    0


// Дополнительные сведения о F# см. на http://fsharp.net
// Дополнительную справку см. в проекте "Учебник по F#".
let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let f2 list = List.nth list (List.findIndex (fun x -> x = (List.max (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))) (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))   

let f3 list = Set.toList (Set.ofList (List.filter (fun x -> (((x % 2) = 0)&&(((List.length (List.filter (fun elem -> elem = x) list)) % 2) = 0))) list))


let rec cifrSum (n : int) : int = 
    if n = 0 then 0
    else (n%10) + (cifrSum (n / 10))

let f4 (list : 'int list) = List.filter (fun x -> (((x % 2) = 0) || (((cifrSum x) % 2) = 0)))

let f5 list = List.length (List.filter (fun x -> (List.exists (fun el -> el * el = x) list)) list)

let delCount n = 
    let rec delCount n del count = 
        if del = n then count + 1
        else    let del1 = del + 1
                if (n % del) = 0 then 
                                        let count1 = count + 1
                                        delCount n del1 count1
                else
                                        delCount n del1 count
    delCount n 1 0

let f6 list1 list2 list3 = List.zip3 (List.rev (List.sort list1)) (List.sortBy (fun x -> (cifrSum x)) list2) (List.rev (List.sortBy (fun x -> (delCount x)) list3))

type 'string btree = 
    Node of 'string * 'string btree * 'string btree
    | Nil

let prefix root left right = (root(); left(); right())
let infix root left right = (left(); root(); right())
let postfix root left right = (left(); right(); root())



[<EntryPoint>]

let main argv = 
    let l = readData
    System.Console.WriteLine(f2 l)
    writeList (f3 l)

    