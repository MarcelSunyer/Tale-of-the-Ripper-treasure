INCLUDE ../Globals.ink

->main
=== main ===

Tomasso Quesini: ¡¡Capitano, es un Kraken!! Qué plato crees que sería más sabroso, ¿Un rissoto con Kraken o lasaña de Kraken?
*[Serio]
~Tomasso_Loyalty -= 5
    
    Pico Pata Palo: No es momento de bromas Tomasso
    Tomasso Quesini: No es ninguna broma Capitano, un ingrediente así no se ve todos los días
    Pico Pata Palo: No te precipites, hay que pensar en la supervivencia del barco
    Lealtad de Tomasso = {Tomasso_Loyalty}
    ->END
*[Bromear]
~Tomasso_Loyalty += 5
    Pico Pata Palo: Mientras sepa bien bebiendo Ron cualquier cosa.
    Tomasso Quesini: Siempre pensando en el ron Capitano. No se preocupe, déjemelo a mí, le prepararé el mejor plato de Kraken
    Pico Pata Palo: Tranquilízate un poco Tomasso, aún no he decidido qué hacer
    Lealtad de Tomasso = {Tomasso_Loyalty}
    ->END
