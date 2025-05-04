open System;
type Company = {id: int; name: string; }
type Movie = { id: int; title: string; age: int; companyId: int }

let companies = [
    {id = 1; name = "Marvel"}
    {id = 2; name = "DC"}
]

let movies = [
    {id = 1; title = "Spider-Man"; age = 2002; companyId = 1}
    {id = 2; title = "The Dark Knight"; age = 2008; companyId = 2}
]

let getMovieById (id:int): Movie option = 
    movies |> List.tryFind (fun m -> m.id = id)

let getCompanyById (id:int): Company option = 
    companies |> List.tryFind (fun c -> c.id = id)

let printMovieDetails (movie:Movie) (company:Company) = 
    Console.WriteLine("Movie: {0}", movie.title)
    Console.WriteLine("Company: {0}", company.name)

type MovieFunctor() = 
    static member map f movie = 
        match f movie with
            | Some m -> m
            | None -> failwith "The movie wasn't find"

let getMovieAndPrintDetails (movieId:int) = 
    let getMovieDetails movieId =
        getMovieById movieId |> Option.bind (fun movie -> getCompanyById movie.companyId |> Option.map (fun company -> (movie, company)))

    MovieFunctor.map getMovieDetails movieId |> (fun (movie, company) -> printMovieDetails movie company)


let testMovieProcessing movieId = getMovieAndPrintDetails movieId

[<EntryPoint>]
let main (args:string[]) = 
    testMovieProcessing 1
    testMovieProcessing 2
    0