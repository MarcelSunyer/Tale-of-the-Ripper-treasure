INCLUDE ../Globals2.ink
-> main

=== main ===
Miss Disfortune: Capitan, se que necesita de mi furza para derribar al Kraken, pero tengo demasiado miedo.
*[Pedir amablemente]
Pico Pata Palo: Por favor Miss Disfortune, te necesitamos sin ti no podremos hacerlo. Solo sera por esta vez, hazlo por mi
~MissDisfortune_Loyalty += 5

Miss Disfortune: Vale Capitan, lo hare, pero solo porque me lo pides tu.
->END

*[Ordenar]
Pico Pata Palo: Es una orden grumete, tu trabajo es la batalla, así que prepararte para disparar
~MissDisfortune_Loyalty -= 10

Miss Disfortune: No puedo Capitan, lo siento, mis piernas no me rsponden.

->END
