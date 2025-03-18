let solve_lin a b c =
    let D = b*b-4. * a*c
    ((-b+sqrt(D))/(2.*a), (-b-sqrt(D))/(2.*a))


open System

[<EntryPoint>]
let main(args : string[]) =
    System.Console.WriteLine "Hello World!"
    0