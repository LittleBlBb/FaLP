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