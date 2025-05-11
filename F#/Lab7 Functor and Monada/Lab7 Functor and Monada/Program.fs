// Подключение системной библиотеки
open System

// Определение типа Company (Компания) с полями id и name
type Company = {id: int; name: string; }

// Определение типа Movie (Фильм) с полями id, title, age (год выпуска) и companyId
type Movie = { id: int; title: string; age: int; companyId: int }

// Список компаний (инициализация данных)
let companies = [
    {id = 1; name = "Marvel"}  // Компания Marvel с id = 1
    {id = 2; name = "DC"}      // Компания DC с id = 2
]

// Список фильмов (инициализация данных)
let movies = [
    {id = 1; title = "Spider-Man"; age = 2002; companyId = 1}  // Фильм Marvel
    {id = 2; title = "The Dark Knight"; age = 2008; companyId = 2}  // Фильм DC
]

// Функция для поиска фильма по id (возвращает option)
let getMovieById (id:int): Movie option = 
    movies |> List.tryFind (fun m -> m.id = id)  // Ищем фильм в списке

// Функция для поиска компании по id (возвращает option)
let getCompanyById (id:int): Company option = 
    companies |> List.tryFind (fun c -> c.id = id)  // Ищем компанию в списке

// Функция для вывода деталей фильма и компании
let printMovieDetails (movie:Movie) (company:Company) = 
    Console.WriteLine("Movie: {0}", movie.title)      // Выводим название фильма
    Console.WriteLine("Company: {0}", company.name)  // Выводим название компании

// Функтор для работы с фильмами
type MovieFunctor() = 
    // Статический метод map для применения функции к фильму
    static member map f movie = 
        match f movie with
            | Some m -> m      // Если функция вернула Some, возвращаем значение
            | None -> failwith "The movie wasn't find"  // Иначе - исключение

// Функция для получения и вывода деталей фильма
let getMovieAndPrintDetails (movieId:int) = 
    // Вложенная функция для получения деталей фильма и компании
    let getMovieDetails movieId =
        getMovieById movieId  // Находим фильм
        |> Option.bind (fun movie ->  // Если фильм найден, ищем компанию
            getCompanyById movie.companyId 
            |> Option.map (fun company -> (movie, company)))  // Возвращаем кортеж

    // Применяем функтор и выводим результат
    MovieFunctor.map getMovieDetails movieId 
    |> (fun (movie, company) -> printMovieDetails movie company)

// Тестовая функция для обработки фильма
let testMovieProcessing movieId = getMovieAndPrintDetails movieId

// Точка входа в программу
[<EntryPoint>]
let main (args:string[]) = 
    testMovieProcessing 1  // Тестируем для фильма с id = 1 (Spider-Man)
    testMovieProcessing 2  // Тестируем для фильма с id = 2 (The Dark Knight)
    0  // Код успешного завершения