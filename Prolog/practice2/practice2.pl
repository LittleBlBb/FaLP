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

writeList([]):-!.
writeList([H|T]):- write(H), nl, writeList(T).

r_list(A,N):-r_list(A,N,0,[]).
r_list(A,N,N,A):-!.
r_list(A,N,K,B):-read(X),append(B,[X],B1),K1 is K+1,r_list(A,N,K1,B1).

sumListDown([], Sum, Sum):- !.
%sumListDown([H|T], CurSum, Sum):- sumCifrDown()
sumListDown([H|T], Sum):- sumListDown([H|T], 0, Sum).

myAppend([], Y, Y).
myAppend([H|T], Y, [H|T1]):- myAppend(T,Y,T1).

