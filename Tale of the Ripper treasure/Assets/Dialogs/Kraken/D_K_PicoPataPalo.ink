INCLUDE ../Globals2.ink

===main===
Pico Pata Palo (mente): Que deberiamos hacer, ¿Huir o luchar contra el Kaken?
*[Huir]
~MrDisfortune_Loyalty += 10
~MissDisfortune_Loyalty += 15
~Tomasso_Loyalty -= 15
Pico Pata Palo: Escuchad grumetes, vamos a huir, no vale la pena enfrentarnos a esta criatura si no hay seguridad de llevarnos algo a cambio.
Pico Pata Palo: Tomasso, Mr. Disfortune, usad los cañones para mantener a raya el Kraken, yo controlare el barco. Miss Disfortune descansa.
~FightDecision = false
->END
*[Luchar]
~MrDisfortune_Loyalty -= 10
~MissDisfortune_Loyalty -= 15
~Tomasso_Loyalty += 15
Pico Pata Palo: Escuchad grumetes, el Kraken es un tesoro que no podemos perder, vamos a enfrentarnos a él y pasar a la historia como los primeros en vencerlo
Pico Pata Palo: Tomasso, Mr. Disfortune, usad los cañones y causadle el máximo daño posible, yo controlare el barco. Miss Disfortune ayudanos 
~FightDecision = true

->END