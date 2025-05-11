% Определение максимального из двух чисел
max(X, Y, X):- X > Y, !.  % Если X > Y, то X - максимум (отсечение)
max(_, Y, Y).              % Иначе Y - максимум

% Определение максимального из трех чисел
max(X, Y, Z, U):- max(X, Y, V), max(V, Z, U).

% Альтернативная реализация max для трех чисел
max3(X, Y, Z, X):- X > Y, X > Z, !.  % X максимальное
max3(_, Y, Z, Y):- Y > Z, !.          % Y максимальное
max3(_, _, Z, Z).                     % Z максимальное

% Аналогично для минимального значения
min(X, Y, X):- X < Y, !.
min(_, Y, Y).
min(X, Y, Z, U):- min(X, Y, V), min(V, Z, U).
min3(X, Y, Z, X):- X < Y, X < Z, !.
min3(_, Y, Z, Y):- Y < Z !.
min3(_, _, Z, Z).

% Сумма цифр числа (рекурсия вверх)
sumCifrUp(0, 0):- !.
sumCifrUp(N, Sum):- 
    Cifr is N mod 10,     % Получаем последнюю цифру
    N1 is N div 10,       % Убираем последнюю цифру
    sumCifrUp(N1, Sum1),  % Рекурсивный вызов
    Sum is Sum1 + Cifr.   % Суммируем цифры

% Сумма цифр числа (рекурсия вниз)
sumCifrDown(0, CurSum, CurSum):- !.
sumCifrDown(N, CurSum, Sum):- 
    Cifr is N mod 10,
    N1 is N div 10,
    CurSum1 is CurSum + Cifr,
    sumCifrDown(N1, CurSum1, Sum).
sumCifrDown(N, Sum):- sumCifrDown(N, 0, Sum).  % Обертка для вызова

% Проверка, что число свободно от квадратов (нет делителей-квадратов)
square_free(N) :- 
    \+ has_square_divisor(N, 2).  

% Проверка наличия квадратного делителя
has_square_divisor(N, Del) :- Del * Del > N, !.   % Прекращаем, если делитель слишком большой
has_square_divisor(N, Del) :- 0 is N mod (Del * Del), !, fail.  % Найден квадратный делитель
has_square_divisor(N, Del) :- NextDel is Del + 1, has_square_divisor(N, NextDel).  % Проверяем следующий делитель

% Чтение списка заданной длины
read_list(List, N) :- read_list(List, N, 0, []).
read_list(List, N, N, List) :- !.  % Базовый случай - достигли нужной длины
read_list(List, N, Count, TempList) :- 
    read(El),                      % Читаем элемент
    append(TempList, [El], NewTempList),  % Добавляем в список
    NewCount is Count + 1,         % Увеличиваем счетчик
    read_list(List, N, NewCount, NewTempList).  % Рекурсивный вызов

% Вывод списка
write_list([]) :- !.
write_list([H|T]) :- write(H), nl, write_list(T).

% Сумма элементов списка (рекурсия вверх)
sum_list_up([], 0).
sum_list_up([H|T], Sum) :-
    sum_list_up(T, SumTail),
    Sum is H + SumTail.

% Сумма элементов списка (рекурсия вниз)
sum_list_down(List, Sum) :- sum_list_down(List, 0, Sum).
sum_list_down([], Acc, Acc).
sum_list_down([H|T], Acc, Sum) :-
    NewAcc is Acc + H,
    sum_list_down(T, NewAcc, Sum).

% Программа для подсчета суммы элементов
sum_prog :-
    write("Kolichestvo elementov: "), nl, read(N),
    write("Vvedite elementy: "), nl, read_list(List, N),
    sum_list_down(List, Sum),
    write("Summa elementov: "), write(Sum), nl.

% Удаление элементов с заданной суммой цифр
rm_elements_with_sum_digits([], _, []) :- !.
rm_elements_with_sum_digits([H|T], Sum, Res) :-
    sum_digits_down(H, DigitSum),
    DigitSum =:= Sum, !,
    rm_elements_with_sum_digits(T, Sum, Res).
rm_elements_with_sum_digits([H|T], Sum, [H|ResTail]) :-
    rm_elements_with_sum_digits(T, Sum, ResTail).

% Минимальная цифра числа (рекурсия вниз)
minCifrDown(0, 9).
minCifrDown(N, Min):-
    N > 0,
    Digit is N mod 10,
    N1 is N // 10,
    minCifrDown(N1, RestMin),
    Min is min(Digit, RestMin).

% Минимальная цифра числа (рекурсия вверх)
minCifrUp(N, Min):- minCifrUp(N, 9, Min).
minCifrUp(0, Min, Min).
minCifrUp(N, Acc, Min):-
    N > 0,
    Digit is N mod 10,
    N1 is N // 10,
    NewAcc is min(Digit, Acc),
    minCifrUp(N1, NewAcc, Min).

% Произведение цифр, не делящихся на 5 (рекурсия вверх)
product_not_div_5_up(N, Prod) :-
    product_not_div_5_up_helper(N, 1, Prod).
product_not_div_5_up_helper(0, Prod, Prod).
product_not_div_5_up_helper(N, Acc, Prod) :-
    N > 0,
    Digit is N mod 10,
    (Digit mod 5 =\= 0 ->
        NewAcc is Acc * Digit
    ;
        NewAcc is Acc
    ),
    N1 is N // 10,
    product_not_div_5_up_helper(N1, NewAcc, Prod).

% Произведение цифр, не делящихся на 5 (рекурсия вниз)
product_not_div_5_down(N, Prod) :-
    digits_not_div_5_down(N, Digits),
    product_list(Digits, Prod).
digits_not_div_5_down(0, []).
digits_not_div_5_down(N, Digits) :-
    N > 0,
    Digit is N mod 10,
    N1 is N // 10,
    (Digit mod 5 =\= 0 ->
        digits_not_div_5_down(N1, Rest),
        Digits = [Digit|Rest]
    ;
        digits_not_div_5_down(N1, Digits)
    ).
product_list([], 1).
product_list([H|T], Prod) :-
    product_list(T, RestProd),
    Prod is H * RestProd.

% Нахождение НОД двух чисел
gcd(A, 0, A) :- !.
gcd(A, B, GCD) :-
    B > 0,
    Remainder is A mod B,
    gcd(B, Remainder, GCD).

% Чтение ввода для задачи 1.3
read_input_1_3(List, Index) :-
    write('Vvedite spisok: '), read(List),
    length(List, Length),
    write('Vvedite index: '), read(Index),
    Index >= 0, Index < Length.

% Проверка, является ли элемент глобальным максимумом
is_global_max(List, Index) :-
    nth0(Index, List, Element),  % Получаем элемент по индексу
    max_list(List, Max),         % Находим максимум списка
    Element =:= Max.             % Сравниваем

% Вывод результата для задачи 1.3
write_result_1_3(yes) :-
    write('Element iavliaetsia globalnym maksimumom.').
write_result_1_3(no) :-
    write('Element ne iavliaetsia globalnym maksimumom.').

% Основной предикат для задачи 1.3
main_1_3 :-
    read_input_1_3(List, Index),
    (is_global_max(List, Index) -> Result = yes ; Result = no),
    write_result_1_3(Result).

% [Остальные комментарии аналогичны...]