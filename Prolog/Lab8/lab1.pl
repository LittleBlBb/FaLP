man:- man(X), print(X), nl, fail.
mother(X, Y):- parent(X, Y), woman(X).
mother(X):- parent(Y, X), woman(Y), print(Y).
brother(X, Y):- parent(Z, X), parent(Z, Y), man(X).
brothers(X):- parent(Y, X), parent(Y, Z), man(Z), print(Z), nl, fail.
sister(X, Y):- parent(Z, X), parent(Z, Y), woman(X).
b_s(X, Y):- brother(X, Y); sister(X, Y); parent(Z, X), parent(Z, Y).
b_s(X):- parent(Y, X), parent(Y, Z), print(Z), nl, fail.

%2

daughter(X, Y):- parent(Y, X), woman(X).
daughter(X):- parent(X, Y), woman(Y), print(Y), nl, fail.
wife(X, Y):- parent(X, Z), parent(Y, Z), woman(X).
wife(X):- parent(X, Z), parent(Y, Z), woman(Y), print(Y). 

%3

grand_parent(X, Y):- parent(X, Z), parent(Z, Y).
grand_son(X, Y):- grand_parent(Y, X), man(X).
grand_sons(X):- parent(X, Y), parent(Y, Z), man(Z), print(Z), nl, fail.
grand_ma_and_son(X, Y):- woman(X), man(Y), parent(X, Z), parent(Z, Y); man(X), woman(Y), parent(Y, Z), parent(Z, X).
uncle(X, Y):- brother(X, Z), parent(Z, Y). 
uncle(X):- parent(Y, X), brother(Y, Z), print(Z), nl, fail. %че-то не так.%