// Дополнительные сведения о F# см. на http://fsharp.net
// Дополнительную справку см. в проекте "Учебник по F#".
open System
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
    | [] -> let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

let theMostFrequenced list = List.nth list (List.findIndex (fun x -> x = (List.max (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))) (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))   

let f3 list = Set.toList (Set.ofList (List.filter (fun x -> (((x % 2) = 0)&&(((List.length (List.filter (fun elem -> elem = x) list)) % 2) = 0))) list))


let rec cifrSum (n : int) : int = 
    if n = 0 then 0
    else (n%10) + (cifrSum (n / 10))

let elOddOrCifrSumOdd (list : 'int list) = List.filter (fun x -> (((x % 2) = 0) || (((cifrSum x) % 2) = 0)))

let canBeSquare list = List.length (List.filter (fun x -> (List.exists (fun el -> el * el = x) list)) list)

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

let makeList3x3 list1 list2 list3 = List.zip3 (List.rev (List.sort list1)) (List.sortBy (fun x -> (cifrSum x)) list2) (List.rev (List.sortBy (fun x -> (delCount x)) list3))

type 'string btree = 
    Node of 'string * 'string btree * 'string btree
    | Nil

let prefix root left right = (root(); left(); right())
let infix root left right = (left(); root(); right())
let postfix root left right = (left(); right(); root())

let isGlobalMax list index = 
    index = List.findIndex (fun x -> x = List.max list) list

let beforeMinimalToTail list = 
    let minIndex = List.findIndex(fun x -> x = List.min list) list
    let rec loop currentIndex targetIndex newList=
        if currentIndex = targetIndex then newList
        else
            let tempList = newList @ [List.head newList]
            let updatedList = List.tail tempList
            let newIndex = currentIndex + 1 
            loop newIndex targetIndex updatedList
    loop 0 minIndex list

let twoMin list = 
    let minValue = List.min list
    let filtered = List.filter (fun x -> x <> minValue) list
    let secMin = List.min filtered
    minValue :: secMin :: []

let isAlternate list =
    let rec loop head tail = 
        if tail = [] then true
        else if (head * (List.head tail) >= 0) then false
        else
            loop tail.Head tail.Tail
    loop (List.head list) list.Tail

let countMinimal list =
    let min = List.min list
    List.length (List.filter(fun x -> x = min) list)

let average list = 
    List.sum list / List.length list

let filterBetweenAvgAndMax list = 
    let avg = average list
    let maxVal = List.max list
    List.filter(fun x -> x > avg && x < maxVal) list

let rec gcd a b = 
    if b = 0 then a
    else gcd b (a%b)

let divisors n =
    [1 .. int (sqrt (float n))]
    |> List.filter (fun x -> n % x = 0)
    |> List.collect (fun x -> [x; n / x])
    |> List.distinct
    |> List.sort

let buildPairs n =
    let divs = divisors n
    [ for x in divs do 
        let y = n / x
        let d = gcd x y
        let a = x / d
        let b = y / d
        yield (a, b) ]
    |> List.distinct

let readInput =
    Console.WriteLine("Input n:")
    let n = Convert.ToInt32(Console.ReadLine())
    if n <= 0 then
        Console.WriteLine("numberb must be positive")
        None
    else Some n


let rec writePairs = function
    | [] -> Console.WriteLine("Empty.")
            Console.ReadKey() |> ignore
    | (a, b) :: tail -> 
            Console.WriteLine(sprintf "(%d, %d)" a b)
            writePairs tail


[<EntryPoint>]
let main argv = 
    ////let l = readData

    ////System.Console.WriteLine(theMostFrequenced l)
    ////writeList (f3 l)

    //let zv = [5;4;1;2;3;4;5;1;1;1]
    //let zvAlt = [-1; 2; -5; 3; -4] 
    //let ans = isGlobalMax zv 2
    //Console.WriteLine(ans)

    //writeList(beforeMinimalToTail zv)
    //Console.WriteLine(isAlternate zv)
    //Console.WriteLine(isAlternate zvAlt)
    //Console.WriteLine(countMinimal zv)
    //writeList(filterBetweenAvgAndMax zv)
    
    ////17
    //match readInput with 
    //| None -> ()
    //| Some n -> 
    //    let result = buildPairs n
    //    Console.WriteLine("New list")
    //    writePairs result

    ////18
    //let arr1 = [|"andrey"; "vova"|]
    //let arr2 = [|"lera"; "liza"|]
    //let res18 = Array.concat ([arr1; arr2])
    //printf "%A" res18
    //let arr3 = [|1;2;3;4|]
    //let arr4 = [|4;3;2;1|]
    //let res181 = Array.concat ([arr3; arr4])
    //printf "%A" res181
    //19
    0



