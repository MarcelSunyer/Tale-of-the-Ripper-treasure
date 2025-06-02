INCLUDE ../Globals2.ink
-> main

=== main ===
Miss Disfortune: Capitan, no puedo hacerlo, esa cosa es horrible, no pienso enfrentarme a ese monstruo
*[Pedir amablemente]
Pico Pata Palo: Por favor Miss Disfortune, te necesitamos sin ti no podremos hacerlo. Te recompensare cuando terminemos
~MissDisfortune_Loyalty += 5

Miss Disfortune: De acuerdo lo hare, pero solo por esta vez. Espero que cumplas tu palabra
->END

*[Ordenar]
Pico Pata Palo: Es una orden grumete, tu trabajo es la batalla, así que prepararte para disparar
~MissDisfortune_Loyalty -=10
Miss Disfortune: No pienso luchar, no me gusta que me obliguen a hacer cosas que detesto Capitán.

->END
