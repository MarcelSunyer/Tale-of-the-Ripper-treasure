INCLUDE ../Globals2.ink
-> main

=== main ===
Miss Disfortune: Capitan, ya le he dicho que me niego a luchar contra el Kraken.
*[Pedir amablemente]
Pico Pata Palo: Miss, debes luchar, si no moriremos todos aquí, huir tampoco nos asegura sobrevivir.
~MissDisfortune_Loyalty += 5

Miss Disfortune: Vale, lo hare, pero espero recibir una alta recompensa por esto.
->END

*[Ordenar]
Pico Pata Palo: Es una orden grumete, cualquiera que suba en este barco debe cumplir mis ordenes.
~MissDisfortune_Loyalty -= 10

Miss Disfortune: No voy ha hacerlo, que seas el Capitan no indica que vaya ha hacer todo lo que me digas.

->END
