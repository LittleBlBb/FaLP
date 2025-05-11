% Определение вершин и ребер графа
vertex(1). vertex(2). vertex(3). vertex(4). vertex(5).
edge(1,2). edge(2,3). edge(3,4). edge(1,3). edge(5,4). edge(5,1).

% Проверка смежности вершин
adjacent(V, W) :- edge(V, W); edge(W, V).

% Проверка независимости множества
independent([]).
independent([V|Vs]) :-
    \+ (member(U, Vs), adjacent(V, U)),
    independent(Vs).

% Проверка доминирования множества
dominating(S) :-
    findall(V, vertex(V), Vertices),
    forall(member(W, Vertices), (member(W, S); adjacent_to_s(W, S))).

% Проверка смежности вершины с множеством
adjacent_to_s(W, S) :-
    member(V, S),
    adjacent(V, W).

% Проверка, является ли множество ядром
is_core(S) :-
    independent(S),
    dominating(S).

% Генерация всех подмножеств
subset([], []).
subset([X|Xs], [X|Ys]) :- subset(Xs, Ys).
subset([_|Xs], Ys) :- subset(Xs, Ys).

% Поиск и вывод всех ядер
find_core :-
    findall(V, vertex(V), Vertices),
    subset(Vertices, S),
    is_core(S),
    write('Yadro: '), write(S), nl,
    fail.