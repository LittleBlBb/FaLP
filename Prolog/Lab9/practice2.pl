max(X, Y, X):- X > Y, !.
max(_, Y, Y). 
max(X, Y, Z, U):- max(X, Y, V), max(V, Z, U).
max3(X, Y, Z, X):- X > Y, X > Z, !.
max3(_, Y, Z, Y):- Y > Z, !.
max3(_, _, Z, Z).

min(X, Y, X):- X < Y, !.
min(_, Y, Y).
min(X, Y, Z, U):- min(X, Y, V), min(V, Z, U).
min3(X, Y, Z, X):- X < Y, X < Z, !.
min3(_, Y, Z, Y):- Y < Z !.
min3(_, _, Z, Z).

sumCifrUp(0, 0):- !.
sumCifrUp(N, Sum):- Cifr is N mod 10, 
					N1 is N div 10,
					sumCifrUp(N1, Sum1),
					Sum is Sum1 + Cifr.

sumCifrDown(0, CurSum, CurSum):- !.
sumCifrDown(N, CurSum, Sum):- Cifr is N mod 10,
							  N1 is N div 10,
							  CurSum1 is CurSum + Cifr,
							  sumCifrDown(N1, CurSum1, Sum).
sumCifrDown(N, Sum):- sumCifrDown(N, 0, Sum).

square_free(N) :- 
    \+ has_square_divisor(N, 2).  

has_square_divisor(N, Del) :- Del * Del > N, !.   
has_square_divisor(N, Del) :- 0 is N mod (Del * Del), !, fail.
has_square_divisor(N, Del) :- NextDel is Del + 1, has_square_divisor(N, NextDel).

read_list(List, N) :- read_list(List, N, 0, []).
read_list(List, N, N, List) :- !.
read_list(List, N, Count, TempList) :- 
    read(El),
    append(TempList, [El], NewTempList),
    NewCount is Count + 1,
    read_list(List, N, NewCount, NewTempList).

% write_list(+List)
write_list([]) :- !.
write_list([H|T]) :- write(H), nl, write_list(T).

% sum_list_up(+List, ?Sum)
sum_list_up([], 0).

sum_list_up([H|T], Sum) :-
    sum_list_up(T, SumTail),
    Sum is H + SumTail.

% sum_list_down(+List, ?Sum)
sum_list_down(List, Sum) :- sum_list_down(List, 0, Sum).

sum_list_down([], Acc, Acc).
sum_list_down([H|T], Acc, Sum) :-
    NewAcc is Acc + H,
    sum_list_down(T, NewAcc, Sum).

% sum_prog
sum_prog :-
    write("Count elements: "), nl, read(N),
    write("Enter elements: "), nl, read_list(List, N),
    sum_list_down(List, Sum),
    write("Sum elements: "), write(Sum), nl.

% rm_elements_with_sum_digits(+List, +Sum, -Res)
rm_elements_with_sum_digits([], _, []) :- !.

rm_elements_with_sum_digits([H|T], Sum, Res) :-
    sum_digits_down(H, DigitSum),
    DigitSum =:= Sum, !,
    rm_elements_with_sum_digits(T, Sum, Res).

rm_elements_with_sum_digits([H|T], Sum, [H|ResTail]) :-
    rm_elements_with_sum_digits(T, Sum, ResTail).

minCifrDown(0, 9).
minCifrDown(N, Min):-
	N > 0,
	Digit is N mod 10,
	N1 is N // 10,
	minCifrDown(N1, RestMin),
	Min is min(Digit, RestMin).

minCifrUp(N, Min):- minCifrUp(N, 9, Min).
minCifrUp(0, Min, Min).
minCifrUp(N, Acc, Min):-
	N > 0,
	Digit is N mod 10,
	N1 is N // 10,
	NewAcc is min(Digit, Acc),
	minCifrUp(N1, NewAcc, Min).

% Рекурсия вверх
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

% Рекурсия вниз
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

% Предикат чтения
read_input_1_3(List, Index) :-
    write('Введите список: '), read(List),
    length(List, Length),
    write('Введите индекс: '), read(Index),
    Index >= 0, Index < Length.

% Предикат логики
is_global_max(List, Index) :-
    nth0(Index, List, Element),  % Получаем элемент по индексу
    max_list(List, Max),         % Находим максимум списка
    Element =:= Max.             % Проверяем, равен ли элемент максимуму

% Предикат вывода
write_result_1_3(yes) :-
    write('Элемент является глобальным максимумом.').
write_result_1_3(no) :-
    write('Элемент не является глобальным максимумом.').

% Главный предикат
main_1_3 :-
    read_input_1_3(List, Index),
    (is_global_max(List, Index) -> Result = yes ; Result = no),
    write_result_1_3(Result).

% Предикат чтения (переиспользуем из задачи 1.3)
read_input_1_15(List, Index) :-
    read_input_1_3(List, Index).

% Предикат логики
is_local_min(List, Index) :-
    length(List, Length),
    (Index =:= 0 ->              % Первый элемент
        nth0(0, List, Elem),
        nth0(1, List, Next),
        Elem < Next
    ; Index =:= Length - 1 ->    % Последний элемент
        nth0(Index, List, Elem),
        nth0(Index - 1, List, Prev),
        Elem < Prev
    ; otherwise ->               % Средний элемент
        nth0(Index, List, Elem),
        nth0(Index - 1, List, Prev),
        nth0(Index + 1, List, Next),
        Elem < Prev,
        Elem < Next
    ).

% Предикат вывода
write_result_1_15(yes) :-
    write('Элемент является локальным минимумом.').
write_result_1_15(no) :-
    write('Элемент не является локальным минимумом.').

% Главный предикат
main_1_15 :-
    read_input_1_15(List, Index),
    (is_local_min(List, Index) -> Result = yes ; Result = no),
    write_result_1_15(Result).

% Предикат чтения
read_input_1_27(List) :-
    write('Введите список: '), read(List).

% Предикат логики
cyclic_shift_left(List, Shifted) :-
    append(Tail, [Head], List),  % Разделяем список на хвост и голову
    append([Head], Tail, Shifted). % Собираем новый список с головой в начале

% Предикат вывода
write_result_1_27(Shifted) :-
    write('Сдвинутый список: '), write(Shifted).

% Главный предикат
main_1_27 :-
    read_input_1_27(List),
    cyclic_shift_left(List, Shifted),
    write_result_1_27(Shifted).

% Определяем профессии и фамилии
task4Solve :-
    Professions = [слесарь, токарь, сварщик],
    Surnames = [борисов, иванов, семенов],
    
    % Генерируем перестановку фамилий для профессий
    permutation(Surnames, [Slesar, Tokar, Svarschik]),
    
    % Условия задачи
    Slesar \= борисов,  % Слесарь не Борисов (у Борисова есть сестра)
    Slesar \= семенов,  % Слесарь не Семенов (Семенов старше токаря, а слесарь младший)
    Tokar \= семенов,   % Токарь не Семенов (Семенов старше токаря)
    
    % Вывод результата
    write('Слесарь: '), write(Slesar), nl,
    write('Токарь: '), write(Tokar), nl,
    write('Сварщик: '), write(Svarschik), nl.

% Predicate for reading input
read_input_1(Number) :-
    write('Введите число: '), read(Number),
    Number > 0.

% Predicate for logic: finds the maximum prime divisor
max_prime_divisor(Number, MaxPrime) :-
    findall(Div, (between(2, Number, Div), Number mod Div =:= 0, is_prime(Div)), Primes),
    max_list(Primes, MaxPrime).

% Helper predicate: checks if a number is prime
is_prime(2).
is_prime(3).
is_prime(N) :-
    N > 3,
    N mod 2 =\= 0,
    \+ (between(3, sqrt(N), I), I mod 2 =\= 0, N mod I =:= 0).

% Predicate for output
write_result_1(MaxPrime) :-
    write('Максимальный простой делитель: '), write(MaxPrime), nl.

% Main predicate to tie it all together
main_1 :-
    read_input_1(Number),
    max_prime_divisor(Number, MaxPrime),
    write_result_1(MaxPrime).

% Predicate for reading input (reused from Task 1)
read_input_2(Number) :-
    read_input_1(Number).

% Predicate for logic: computes GCD of max odd non-prime divisor and digit product
gcd_max_odd_nonprime_and_digit_product(Number, GCD) :-
    findall(Div, (between(1, Number, Div), Number mod Div =:= 0, odd(Div), not(is_prime(Div))), Divisors),
    max_list(Divisors, MaxOddNonPrime),
    digit_product(Number, Product),
    gcd(MaxOddNonPrime, Product, GCD).

% Helper predicate: checks if a number is odd
odd(N) :- N mod 2 =\= 0.

% Helper predicate: computes product of digits
digit_product(0, 1).
digit_product(N, Product) :-
    N > 0,
    Digit is N mod 10,
    N1 is N // 10,
    digit_product(N1, RestProduct),
    Product is Digit * RestProduct.

% Helper predicate: computes GCD of two numbers
gcd(A, 0, A).
gcd(A, B, GCD) :-
    B > 0,
    Remainder is A mod B,
    gcd(B, Remainder, GCD).

% Predicate for output
write_result_2(GCD) :-
    write('НОД максимального нечетного непростого делителя и произведения цифр: '), write(GCD), nl.

% Main predicate to tie it all together
main_2 :-
    read_input_2(Number),
    gcd_max_odd_nonprime_and_digit_product(Number, GCD),
    write_result_2(GCD).

% Predicate for reading input
read_input_1_39(List) :-
    write('Введите список: '), read(List).

% Predicate for logic: constructs list with even-indexed elements then odd-indexed
even_then_odd(List, Result) :-
    findall(Elem, (nth0(Index, List, Elem), even(Index)), EvenIndexed),
    findall(Elem, (nth0(Index, List, Elem), odd(Index)), OddIndexed),
    append(EvenIndexed, OddIndexed, Result).

% Helper predicate: checks if index is even
even(Index) :- Index mod 2 =:= 0.

% Helper predicate: checks if index is odd (reused from Task 2)
odd(Index) :- Index mod 2 =\= 0.

% Predicate for output
write_result_1_39(Result) :-
    write('Элементы с четными индексами, затем с нечетными: '), write(Result), nl.

% Main predicate to tie it all together
main_1_39 :-
    read_input_1_39(List),
    even_then_odd(List, Result),
    write_result_1_39(Result).

% Predicate for reading input (reused from Task 1.39)
read_input_1_51(List) :-
    read_input_1_39(List).

% Predicate for logic: builds L1 (unique elements) and L2 (counts)
unique_and_counts(List, L1, L2) :-
    sort(List, L1),
    maplist(count_occurrences(List), L1, L2).

% Helper predicate: counts occurrences of an element in the list
count_occurrences(List, Elem, Count) :-
    include(=(Elem), List, Occurrences),
    length(Occurrences, Count).

% Predicate for output
write_result_1_51(L1, L2) :-
    write('L1 (уникальные элементы): '), write(L1), nl,
    write('L2 (количество вхождений): '), write(L2), nl.

% Main predicate to tie it all together
main_1_51 :-
    read_input_1_51(List),
    unique_and_counts(List, L1, L2),
    write_result_1_51(L1, L2).