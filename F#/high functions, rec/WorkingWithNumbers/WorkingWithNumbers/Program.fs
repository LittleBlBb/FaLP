// Подключаем системные библиотеки для ввода/вывода
open System

// Функция для разбиения числа на последнюю цифру и оставшуюся часть
let updateVariables n =
    let n1 = n / 10      // Получаем число без последней цифры
    let cifr = n % 10    // Получаем последнюю цифру
    n1, cifr             // Возвращаем кортеж из двух значений

// Рекурсивная функция для подсчета суммы цифр числа
let rec cifrSumUp n = 
    if n = 0 then 0      // Базовый случай: если число 0, сумма 0
    else (n%10) + (cifrSumUp (n / 10))  // Складываем последнюю цифру с суммой остальных

// Хвосторекурсивная версия суммы цифр
let cifrSum n =
    let rec cifrSum1 n curSum =
        if n = 0 then curSum  // Базовый случай: возвращаем накопленную сумму
        else
            let n1, cifr = updateVariables n  // Разбиваем число
            let newSum = curSum + cifr        // Добавляем цифру к сумме
            cifrSum1 n1 newSum                // Рекурсивный вызов с остатком числа
    cifrSum1 n 0  // Начинаем с суммы 0

// Рекурсивный расчет факториала
let rec fact n =
    if n = 1 || n = 0 then 1   // 0! и 1! равны 1
    else n * (fact (n-1))       // n! = n * (n-1)!

// Хвосторекурсивный расчет факториала
let factDown n =
    let rec factDown1 n curMul =
        if n = 1 || n = 0 then curMul  // Базовый случай: возвращаем произведение
        else
            let newMul = curMul * n    // Умножаем текущий результат на n
            let n1 = n - 1             // Уменьшаем n
            factDown1 n1 newMul        // Рекурсивный вызов
    factDown1 n 1  // Начинаем с 1

// Выбор между суммой цифр и факториалом
let choice f n =
    match f with 
    | true -> cifrSum n    // Если true - сумма цифр
    | false -> factDown n  // Если false - факториал

// Расчет произведения цифр числа
let cifrMult n =
    let rec cifrMult1 n curMult =
        if n = 0 then 0  // Особый случай: для 0 произведение 0
        else
            let n1, cifr = updateVariables n  // Разбиваем число
            let newMult = curMult * cifr      // Умножаем цифру на произведение
            cifrMult1 n1 newMult              // Рекурсивный вызов
    cifrMult1 n 1  // Начинаем с 1

// Поиск минимальной цифры в числе
let min n =
    let rec min1 n curMin =
        if n = 0 then curMin  // Базовый случай: возвращаем минимум
        else
            let n1, cifr = updateVariables n  // Разбиваем число
            let newMin = if cifr < curMin then cifr else curMin  // Обновляем минимум
            min1 n1 newMin                    // Рекурсивный вызов
    min1 n 9  // Начинаем с 9 (максимальная цифра)

// Поиск максимальной цифры в числе
let max n =
    let rec max1 n curMax =
        if n = 0 then curMax  // Базовый случай: возвращаем максимум
        else
            let n1, cifr = updateVariables n  // Разбиваем число
            let newMax = if cifr > curMax then cifr else curMax  // Обновляем максимум
            max1 n1 newMax                    // Рекурсивный вызов
    max1 n 0  // Начинаем с 0 (минимальная цифра)

// Применение функции к числу с аккумулятором
let numBypass number func (acc: int option) =
    let accValue = defaultArg acc 0  // Аккумулятор по умолчанию 0
    accValue + func number          // Прибавляем результат функции

// Обход числа с условием
let numBypassCond number func (acc : int option) predicate = 
    let rec bypass n curAcc =
        match n with
        | 0 -> curAcc  // Базовый случай
        | _ -> 
            let n1, digit = updateVariables n  // Разбиваем число
            match predicate digit with
            | true -> bypass n1 (func curAcc digit)  // Если условие выполняется
            | false -> bypass n1 curAcc              // Если не выполняется
    let initialAcc = defaultArg acc 0  // Инициализация аккумулятора
    bypass (abs number) initialAcc     // Работаем с модулем числа

// Тип данных Widget с ID и версией
type Widget = { ID: int; Rev: int }

// Сравнение Widget'ов по ID и версии
let compareWidgets w1 w2 =
    if w1.ID < w2.ID then -1 else     // Сначала по ID
    if w1.ID > w2.ID then 1 else
    if w1.Rev > w2.Rev then -1 else   // Потом по версии (убывание)
    if w1.Rev > w2.Rev then 1 else
    0

// Проверка языка программирования
let progLang input = 
    match input with 
        | "prolog" | "f#" -> "Подлиза"  // Любимые языки
        | _ -> "не подлиза"             // Остальные

// [Аналогичные функции с разными именами]
let progLangSupPos input = progLang input
let progLangCarr input = progLang input

// Чтение списка из n чисел
let rec readList n = 
    if n=0 then []  // Пустой список
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())  // Читаем элемент
    let Tail = readList (n-1)                                     // Читаем хвост
    Head::Tail                                                    // Собираем список

// Чтение данных (сначала размер, потом элементы)
let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())  // Читаем размер
    readList n                                               // Читаем список

// Вывод списка
let rec writeList = function 
    |   [] -> System.Console.ReadKey()  // Пустой список - ждем нажатия
    | (head : int)::tail -> 
        System.Console.WriteLine(head)  // Печатаем голову
        writeList tail                  // Печатаем хвост

// Поиск максимума из двух чисел
let max2 x y = if x > y then x else y

// Обобщенная функция аккумуляции с условием
let rec accCond list (f : int -> int -> int) p acc = 
    match list with
    | [] -> acc  // Возвращаем аккумулятор
    | h::t ->
                let newAcc = f acc h  // Применяем функцию
                if p h then accCond t f p newAcc  // Если условие выполняется
                else accCond t f p acc            // Если нет

// Поиск минимума в списке
let listMin list = 
    match list with 
    |[] -> 0  // Пустой список - возвращаем 0
    | h::t -> accCond list (fun x y -> if x < y then x else y) (fun x -> true) h

// Поиск максимума в списке
let listMax list = 
    match list with 
    |[] -> 0  // Пустой список - возвращаем 0
    | h::t -> accCond list max2 (fun x -> true) h

// Сумма элементов списка
let listSum list = accCond list (fun x y -> x + y) (fun x -> true) 0

// Произведение элементов списка
let listPr list = accCond list (fun x y -> x * y) (fun x -> true) 1

// Поиск максимального четного/нечетного элемента
let f6 list = 
    match list with
    |[] -> 0
    | h::t ->   if (h % 2 = 0) then accCond t max2 (fun x -> ((x % 2) = 0)) h
                else accCond t max2 (fun x -> ((x % 2) <> 0) ) h

// Подсчет количества вхождений элемента в список
let rec frequency list elem count =
        match list with
        |[] -> count  // Конец списка - возвращаем счетчик
        | h::t -> 
                        let count1 = count + 1
                        if h = elem then frequency t elem count1  // Нашли элемент
                        else frequency t elem count               // Не нашли

// Создание списка частот элементов
let rec freqList list mainList curList = 
        match list with
        | [] -> curList  // Возвращаем список частот
        | h::t -> 
                    let freqElem = frequency mainList h 0  // Считаем частоту
                    let newList = curList @ [freqElem]     // Добавляем в результат
                    freqList t mainList newList            // Продолжаем обработку

// Поиск позиции элемента в списке (начиная с 1)
let pos list el = 
    let rec pos1 list el num = 
        match list with
            |[] -> 0  // Элемент не найден
            |h::t ->    if (h = el) then num  // Нашли на текущей позиции
                        else 
                            let num1 = num + 1
                            pos1 t el num1    // Ищем дальше
    pos1 list el 1  // Начинаем с позиции 1

// Получение элемента по позиции (начиная с 1)
let getIn list pos = 
    let rec getIn1 list num curNum = 
        match list with 
            |[] -> 0  // Позиция за пределами списка
            |h::t -> if num = curNum then h  // Нашли нужный элемент
                     else 
                            let newNum = curNum + 1
                            getIn1 t num newNum  // Продолжаем поиск
    getIn1 list pos 1  // Начинаем с позиции 1

// Поиск элемента с максимальной частотой
let f7 list = 
    let fL = freqList list list []  // Получаем список частот
    (listMax fL) |> (pos fL) |> (getIn list)  // Находим элемент с макс. частотой

// Фильтрация списка по условию
let filter list pr = 
    let rec filter1 list pr newList = 
        match list with
        | [] -> newList  // Возвращаем отфильтрованный список
        | h::t ->
                let newnewList = newList @ [h]
                if pr h then filter1 list pr newnewList  // Условие выполняется
                else filter1 list pr newList             // Условие не выполняется
    filter1 list pr []  // Начинаем с пустого списка

// Проверка на четность
let even n = ((n % 2) = 0)

// Условие для f8: четное число и четное количество вхождений
let f8Cond list el = (even el) && (even (frequency list el 0))

// Фильтрация по условию f8
let f8 list = filter list (f8Cond list)

// Удаление всех вхождений элемента из списка
let delEL list el = filter list (fun x -> (x <> el))

// Удаление дубликатов из списка
let uniq list = 
    let rec uniq1 list newList = 
        match list with
            |[] -> newList  // Возвращаем уникальные элементы
            | h::t -> 
                        let listWithout = delEL t h  // Удаляем текущий элемент из хвоста
                        let newnewList = newList @ [h]  // Добавляем элемент в результат
                        uniq1 listWithout newnewList    // Продолжаем обработку
    uniq1 list []  // Начинаем с пустого списка

// [Повторное определение суммы цифр]
let rec cifrSum n = 
    if n = 0 then 0
    else (n%10) + (cifrSum (n / 10))

// Условие для f9: сумма цифр > 9 или число четное
let f9Cond el = ((cifrSum el) > 9) || (even el)

// Фильтрация по условию f9
let f9 list = filter list f9Cond

// Функция-счетчик
let count x y = x + 1

// Условие для f10: элемент является квадратом какого-то числа из списка
let f10Cond list El = (accCond list count (fun x -> ((x * x) = El)) 0) > 0

// Подсчет количества квадратов в списке
let f10 list = accCond list count (f10Cond list) 0   

// Альтернативная реализация f2 с использованием List-функций
let f2 list = List.nth list (List.findIndex (fun x -> x = (List.max (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))) (List.map (fun el -> List.length (List.filter (fun elem -> (elem = el)) list)) list))   

// Альтернативная реализация f3 с использованием Set
let f3 list = Set.toList (Set.ofList (List.filter (fun x -> (((x % 2) = 0)&&(((List.length (List.filter (fun elem -> elem = x) list)) % 2) = 0))) list))

// Подсчет количества делителей числа
let delCount n = 
    let rec delCount n del count = 
        if del = n then count + 1  // n всегда делитель самого себя
        else    let del1 = del + 1
                if (n % del) = 0 then 
                                        let count1 = count + 1
                                        delCount n del1 count1  // Нашли делитель
                else
                                        delCount n del1 count    // Не делитель
    delCount n 1 0  // Начинаем проверку с 1

// Специальное "застегивание" трех списков с разными сортировками
let f6 list1 list2 list3 = List.zip3 (List.rev (List.sort list1)) (List.sortBy (fun x -> (cifrSum x)) list2) (List.rev (List.sortBy (fun x -> (delCount x)) list3))

// Определение бинарного дерева
type 'string btree = 
    Node of 'string * 'string btree * 'string btree  // Узел с значением и поддеревьями
    | Nil  // Пустой узел

// Варианты обхода дерева
let prefix root left right = (root(); left(); right())  // Прямой обход (К-Л-П)
let infix root left right = (left(); root(); right())   // Симметричный обход (Л-К-П)
let postfix root left right = (left(); right(); root()) // Обратный обход (Л-П-К)

[<EntryPoint>]
let main argv = 
    let l = readData  // Читаем входные данные
    System.Console.WriteLine(f2 l)  // Выводим результат f2
    writeList (f3 l)               // Выводим результат f3
    0  // Код успешного завершения