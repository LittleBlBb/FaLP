let solve_lin a b c =
    let D = b*b-4. * a*c
    ((-b+sqrt(D))/(2.*a), (-b-sqrt(D))/(2.*a))


open System

[<EntryPoint>]
let main(args : string[]) =
    System.Console.WriteLine "Hello World!"
    let solve = solve_lin 3 4 2
    System.Console.WriteLine solve
    0