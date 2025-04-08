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

[<EntryPoint>]

let main argv = 
    //let l = readData

    //System.Console.WriteLine(theMostFrequenced l)
    //writeList (f3 l)

    let zv = [5;4;1;2;3;4;5]
    let ans = isGlobalMax zv 2
    Console.WriteLine(ans)

    writeList(beforeMinimalToTail zv)



    0


