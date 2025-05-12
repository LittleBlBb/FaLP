open System
open System.Collections.Generic

let isSpecialSumSet (set: int list) =
    let n = set.Length
    let sums = HashSet<int>()
    let allMasks = [1 .. (1 <<< n) - 1]

    let subsets = 
        allMasks 
        |> List.map (fun mask ->
            [0 .. n - 1] |> List.choose (fun i -> if (mask &&& (1 <<< i)) <> 0 then Some(set.[i]) else None)
        )

    subsets |> List.forall (fun subset ->
        let s = List.sum subset
        if sums.Contains s then false
        else
            sums.Add s |> ignore
            true
    )

let checkSecondProperty (set: int list) =
    let n = set.Length
    let allSubsets =
        [1 .. (1 <<< n) - 1]
        |> List.map (fun mask ->
            [0 .. n - 1] |> List.choose (fun i -> if (mask &&& (1 <<< i)) <> 0 then Some(set.[i]) else None)
        )

    allSubsets
    |> List.allPairs allSubsets
    |> List.forall (fun (a, b) ->
        if Set.intersect (Set.ofList a) (Set.ofList b) |> Set.isEmpty then
            let sa, sb = List.sum a, List.sum b
            let la, lb = List.length a, List.length b
            sa <> sb && (la <= lb || sa > sb) && (lb <= la || sb > sa)
        else true
    )

let generateNextCandidate (prevSet: int list) =
    let b = prevSet.[prevSet.Length / 2]
    [ b ] @ (prevSet |> List.map (fun x -> x + b))

let generateNeighbors (set: int list) =
    let rec gen acc prefix =
        match acc with
        | [] -> [prefix]
        | x::xs ->
            [-1; 0; 1]
            |> List.collect (fun d -> 
                let newVal = x + d
                if newVal > 0 && (prefix = [] || newVal > List.last prefix) then
                    gen xs (prefix @ [newVal])
                else []
            )
    gen set []

let findBestSpecialSumSet (n: int) : int list =
    let prevOptimum = [11; 18; 19; 20; 22; 25]
    let candidate = generateNextCandidate prevOptimum
    let neighbors = generateNeighbors candidate

    neighbors
    |> List.filter isSpecialSumSet
    |> List.filter checkSecondProperty
    |> List.minBy List.sum

let result = findBestSpecialSumSet 7
printfn "Optimal special sum set for n=7: %A" result
printfn "Sum: %d" (List.sum result)
printfn "Set string: %s" (String.concat "" (List.map string result))
