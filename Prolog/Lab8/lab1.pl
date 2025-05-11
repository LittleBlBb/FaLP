% Вывод всех мужчин
man:- man(X), print(X), nl, fail.

% Определение матери (X - мать Y)
mother(X, Y):- parent(X, Y), woman(X).

% Вывод матери для X
mother(X):- parent(Y, X), woman(Y), print(Y).

% Определение брата (X - брат Y)
brother(X, Y):- parent(Z, X), parent(Z, Y), man(X).

% Вывод всех братьев для X
brothers(X):- parent(Y, X), parent(Y, Z), man(Z), print(Z), nl, fail.

% Определение сестры (X - сестра Y)
sister(X, Y):- parent(Z, X), parent(Z, Y), woman(X).

% Определение родственника (брат, сестра или просто общий родитель)
b_s(X, Y):- brother(X, Y); sister(X, Y); parent(Z, X), parent(Z, Y).

% Вывод всех родственников для X
b_s(X):- parent(Y, X), parent(Y, Z), print(Z), nl, fail.

% Определение дочери (X - дочь Y)
daughter(X, Y):- parent(Y, X), woman(X).

% Вывод всех дочерей для X
daughter(X):- parent(X, Y), woman(Y), print(Y), nl, fail.

% Определение жены (X - жена Y)
wife(X, Y):- parent(X, Z), parent(Y, Z), woman(X).

% Вывод жены для X
wife(X):- parent(X, Z), parent(Y, Z), woman(Y), print(Y). 

% Определение дедушки/бабушки (X - дед/бабушка Y)
grand_parent(X, Y):- parent(X, Z), parent(Z, Y).

% Определение внука (X - внук Y)
grand_son(X, Y):- grand_parent(Y, X), man(X).

% Вывод всех внуков для X
grand_sons(X):- parent(X, Y), parent(Y, Z), man(Z), print(Z), nl, fail.

% Определение связи бабушка-внук или дедушка-внучка
grand_ma_and_son(X, Y):- 
    woman(X), man(Y), parent(X, Z), parent(Z, Y); 
    man(X), woman(Y), parent(Y, Z), parent(Z, X).

% Определение дяди (X - дядя Y)
uncle(X, Y):- brother(X, Z), parent(Z, Y). 

% Вывод всех дядей для X (закомментировано - возможно, неверная реализация)
uncle(X):- parent(Y, X), brother(Y, Z), print(Z), nl, fail.