open System

let MkListChucrh n =
    let rec helper n list = 
        if n = 0 then list
        else
            Console.Write("Write {0} number: ", n)
            let item = Console.ReadLine() |> int
            let newList = fun cons nil -> cons item (list cons nil)
            helper (n - 1) newList
    if n <= 0 then 
        fun _ nil -> nil
    else
        Console.Write "Write 1-st number: "
        let head = Console.ReadLine() |> int
        helper (n-1) (fun cons nil -> cons head nil)

let toList church = 
    church (fun h t -> h :: t) []

[<EntryPoint>]
let main(args : string[]) =



    let listChurch = MkListChucrh 5
    let result = toList listChurch
    Console.WriteLine("result: list: {0}", String.Join("; ", result))
    0