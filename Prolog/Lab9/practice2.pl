max(X, Y, X):- X > Y, !.
max(_, Y, Y). 
max(X, Y, Z, U):- max(X, Y, V), max(V, Z, U).
max3(X, Y, Z, X):- X > Y, X > Z, !.
max3(_, Y, Z, Y):- Y > Z, !.
max3(_, _, Z, Z).

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