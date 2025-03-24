open System

let task1 () = 
    let list = [1;2;3;4]
    let listQuad = List.map (fun i -> i * i) list
    let listCube = List.map (fun i -> i*i*i) list
    Console.WriteLine ("list of quads: {0}", String.Join("; ", listQuad))
    Console.WriteLine ("list of cubes: {0}", String.Join("; ", listCube))
    
    let sumListQuad = List.sum listQuad
    let sumListCube = List.sum listCube
    Console.WriteLine ("sum of listQuads: {0}", String.Join("; ",sumListQuad))
    Console.WriteLine ("sum of listCubes: {0}", String.Join("; ",sumListCube))


let task2 () = 
    let manList = [25.;37.;48.;60.]
    let womanList = [28.;43.]
    let manAvg = List.average manList
    let womanAvg = List.average womanList
    Console.WriteLine ("Average men age: {0}", String.Join("; ", manAvg))
    Console.WriteLine ("Average women age: {0}", String.Join("; ", womanAvg))
    
let task3 () =
    let list = [10.; 11.;12.5;15.;13.;7.5]
    let newList = List.map (fun x -> x + x / 100. * 15.) list
    Console.WriteLine ("New salary: {0}", String.Join("; ", newList))

let task4 () = 
    let list = [10;3;7;0]
    let norm = List.sum list / 4
    let list2 = [norm; norm; norm; norm]
    let list3 = List.map2(fun x y -> x - y) list list2
    let ans = list3
    Console.WriteLine("Сколько надо отнять: {0}", String.Join("; ", ans))

let task5 () = 
    let list = [1..20]
    let evenOnlyList = List.filter(fun x -> x % 2 = 0) list
    let ans = List.map (fun x -> x * x) evenOnlyList
    Console.WriteLine("Even quads: {0}", String.Join("; ", ans))

let task6 () = 
    let list = [1..20]
    let ans = List.filter(fun x -> x % 4 = 0) list
    Console.WriteLine("Vagoni-restorani: {0}", String.Join("; ", ans))

let task7 () =
    let list = [1..20]
    let ans = (list.Length - list.Length/3) * 20
    Console.WriteLine("passangers count: {0}", String.Join("; ", ans))

let task8 () = 
    let list1 = ['a';'b';'c';'d']
    let list2 = ['e';'f';'g']
    let list3 = ['h';'i']
    let result = list1 @ list2 @ list3
    Console.WriteLine("result list : {0}", String.Join("; ", result))

let task9 () = 
    let list = [1..20]
    let listQuad = List.map(fun x -> if x % 3 = 0 then x * x else x) list
    let listCube = List.map(fun x -> if x % 5 = 0 then x * x * x else x) list
    let result = listQuad @ listCube
    Console.WriteLine("result list: {0}", String.Join("; ", result))

let task10 () = 
    let input = Console.ReadLine()
    let list1 = input.Split(" ") |> Array.toList
    Console.WriteLine list1.Length
    Console.WriteLine list1.Head
    Console.WriteLine list1.Tail.Head
    Console.WriteLine list1.Tail.Tail.Head
    let listItem1 = list1.Item(1)
    Console.WriteLine listItem1

[<EntryPoint>]
let main(args : string[]) = 
    //let list1 = [1;2;3]
    //Console.WriteLine list1.Length
    //Console.WriteLine list1.Head
    //Console.WriteLine list1.Tail.Head
    //Console.WriteLine list1.Tail.Tail.Head
    //let listItem1 = list1.Item(1)
    //Console.WriteLine listItem1

    //task1 ()
    //task2 ()
    //task3 ()
    //task4 ()
    //task5 ()
    //task6 ()
    //task7 ()
    //task8 ()
    //task9 ()
    task10 ()

    0