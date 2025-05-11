// Дополнительные сведения о F# см. на http://fsharp.net
// Дополнительную справку см. в проекте "Учебник по F#".
// Подключение системной библиотеки
open System

// Рекурсивная функция для чтения списка из n элементов
let rec readList n = 
    if n=0 then []  // Базовый случай: пустой список
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())  // Читаем элемент
    let Tail = readList (n-1)  // Рекурсивно читаем остальные элементы
    Head::Tail  // Собираем список

// Функция для чтения данных: сначала размер, затем элементы
let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())  // Читаем размер списка
    readList n  // Читаем сам список

// Рекурсивная функция для вывода списка
let rec writeList = function
    | [] -> let z = System.Console.ReadKey()  // Пустой список - ждем нажатия клавиши
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)  // Выводим текущий элемент
                       writeList tail  // Рекурсивно выводим хвост

// Находит самый часто встречающийся элемент в списке
let theMostFrequenced list = 
    List.nth list (List.findIndex (fun x -> x = (List.max (List.map (fun el -> 
        List.length (List.filter (fun elem -> (elem = el)) list)) list))) 
        (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list)

// Фильтрует четные элементы, встречающиеся четное количество раз
let f3 list = 
    Set.toList (Set.ofList (List.filter (fun x -> 
        ((x % 2) = 0) && (((List.length (List.filter (fun elem -> elem = x) list)) % 2) = 0))) list))

// Рекурсивно вычисляет сумму цифр числа
let rec cifrSum (n : int) : int = 
    if n = 0 then 0  // Базовый случай
    else (n%10) + (cifrSum (n / 10))  // Сумма последней цифры и суммы остальных

// Фильтрует элементы: четные или с нечетной суммой цифр
let elOddOrCifrSumOdd (list : 'int list) = 
    List.filter (fun x -> (((x % 2) = 0) || (((cifrSum x) % 2) = 0)))

// Считает количество элементов, которые являются квадратами других элементов
let canBeSquare list = 
    List.length (List.filter (fun x -> (List.exists (fun el -> el * el = x) list)) list)

// Подсчитывает количество делителей числа
let delCount n = 
    let rec delCount n del count = 
        if del = n then count + 1  // n всегда делит само себя
        else    
            let del1 = del + 1
            if (n % del) = 0 then 
                let count1 = count + 1
                delCount n del1 count1  // Найден делитель
            else
                delCount n del1 count  // Не делитель
    delCount n 1 0  // Начинаем проверку с 1

// Создает список кортежей из трех списков с разными сортировками
let makeList3x3 list1 list2 list3 = 
    List.zip3 
        (List.rev (List.sort list1))  // 1-й список: обратная сортировка
        (List.sortBy (fun x -> (cifrSum x)) list2)  // 2-й список: сортировка по сумме цифр
        (List.rev (List.sortBy (fun x -> (delCount x)) list3))  // 3-й список: сортировка по количеству делителей

// Определение бинарного дерева
type 'string btree = 
    Node of 'string * 'string btree * 'string btree  // Узел с значением и двумя поддеревьями
    | Nil  // Пустой узел

// Варианты обхода дерева:
let prefix root left right = (root(); left(); right())  // Прямой обход (корень-лево-право)
let infix root left right = (left(); root(); right())   // Симметричный обход (лево-корень-право)
let postfix root left right = (left(); right(); root()) // Обратный обход (лево-право-корень)

// Проверяет, является ли элемент по индексу глобальным максимумом
let isGlobalMax list index = 
    index = List.findIndex (fun x -> x = List.max list) list

// Переносит элементы перед минимальным в конец списка
let beforeMinimalToTail list = 
    let minIndex = List.findIndex(fun x -> x = List.min list) list  // Находим индекс минимума
    let rec loop currentIndex targetIndex newList=
        if currentIndex = targetIndex then newList  // Базовый случай: дошли до минимума
        else
            let tempList = newList @ [List.head newList]  // Добавляем текущий элемент в конец
            let updatedList = List.tail tempList  // Удаляем его из начала
            let newIndex = currentIndex + 1 
            loop newIndex targetIndex updatedList  // Рекурсивный вызов
    loop 0 minIndex list  // Начинаем с первого элемента

// Находит два минимальных элемента
let twoMin list = 
    let minValue = List.min list  // Первый минимум
    let filtered = List.filter (fun x -> x <> minValue) list  // Фильтруем первый минимум
    let secMin = List.min filtered  // Второй минимум
    minValue :: secMin :: []  // Возвращаем список из двух минимумов

// Проверяет, чередуются ли знаки элементов
let isAlternate list =
    let rec loop head tail = 
        if tail = [] then true  // Базовый случай: дошли до конца
        else if (head * (List.head tail) >= 0) then false  // Нарушено чередование
        else
            loop tail.Head tail.Tail  // Проверяем следующую пару
    loop (List.head list) list.Tail  // Начинаем с первых двух элементов

// Считает количество минимальных элементов
let countMinimal list =
    let min = List.min list  // Находим минимум
    List.length (List.filter(fun x -> x = min) list)  // Считаем количество

// Вычисляет среднее значение элементов
let average list = 
    List.sum list / List.length list  // Сумма / количество

// Фильтрует элементы между средним и максимальным
let filterBetweenAvgAndMax list = 
    let avg = average list  // Среднее значение
    let maxVal = List.max list  // Максимальное значение
    List.filter(fun x -> x > avg && x < maxVal) list  // Фильтрация

// Рекурсивно вычисляет НОД (алгоритм Евклида)
let rec gcd a b = 
    if b = 0 then a  // Базовый случай
    else gcd b (a%b)  // Рекурсивный вызов

// Находит все делители числа
let divisors n =
    [1 .. int (sqrt (float n))]  // Проверяем до корня из n
    |> List.filter (fun x -> n % x = 0)  // Фильтруем делители
    |> List.collect (fun x -> [x; n / x])  // Добавляем парные делители
    |> List.distinct  // Удаляем дубликаты
    |> List.sort  // Сортируем

// Строит пары (a,b) такие, что a*b = n и НОД(a,b) = 1
let buildPairs n =
    let divs = divisors n  // Получаем все делители
    [ for x in divs do  // Для каждого делителя
        let y = n / x  // Находим парный делитель
        let d = gcd x y  // Находим их НОД
        let a = x / d  // Делим на НОД
        let b = y / d  // Делим на НОД
        yield (a, b) ]  // Возвращаем пару
    |> List.distinct  // Удаляем дубликаты

// Читает число с консоли с проверкой
let readInput =
    Console.WriteLine("Input n:")
    let n = Convert.ToInt32(Console.ReadLine())
    if n <= 0 then
        Console.WriteLine("number must be positive")
        None  // Некорректный ввод
    else Some n  // Корректный ввод

// Рекурсивно выводит список пар
let rec writePairs = function
    | [] -> Console.WriteLine("Empty.")  // Пустой список
            Console.ReadKey() |> ignore
    | (a, b) :: tail -> 
            Console.WriteLine(sprintf "(%d, %d)" a b)  // Выводим текущую пару
            writePairs tail  // Рекурсивно выводим остальные

// Перемешивает список случайным образом
let shuffle (rnd : Random) list = 
    let rec shuffleRec remaining acc = 
        match remaining with
        | [] -> acc  // Базовый случай: все элементы перемешаны
        | _ ->
            let index = rnd.Next(List.length remaining)  // Случайный индекс
            let item = List.item index remaining  // Выбираем элемент
            let rest = List.filter (fun x -> x <> item) remaining  // Удаляем его
            shuffleRec rest (item :: acc)  // Добавляем в результат и продолжаем
    shuffleRec list []  // Начинаем с исходного списка

// Перемешивает слова в строке случайным образом
let rndReplace (str : string) = 
    let rnd = Random()  // Генератор случайных чисел
    str.Split(' ')  // Разбиваем строку на слова
    |> Array.toList  // Преобразуем в список
    |> shuffle rnd  // Перемешиваем
    |> String.concat " "  // Собираем обратно в строку

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
    ////19
    //let str = "Какая-то строка с буквами из которых состоят слова, которые и образуют строку"
    //Console.WriteLine(rndReplace str)
    0  // Код завершения программы