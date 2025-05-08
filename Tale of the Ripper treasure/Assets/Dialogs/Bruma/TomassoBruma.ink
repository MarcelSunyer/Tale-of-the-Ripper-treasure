INCLUDE ../Globals.ink

-> main
=== main ===
Tomasso: Capitano, es preciosa pero no me agrada cuando me agarran *se rie*. Apreciaría una ayuda.

*[Tirar de él]
    Pico Pata Palo: Tranquilo, te tengo.
    
    Tomasso: ¡¡AARGH!! ¡Mi brazo de picar!
    ~Tomasso_Loyalty -= 20
    ->END
*[Atacar a la sirena]
    Pico Pata Palo: Le rebanaré el brazo a la sirena, mi fiel amigo, ¡estáte quieto!
    
    Tomasso: ¿Quieto? Aunque me esté haciendo daño sigue siendo una belleza, mi capitano.
    ~Tomasso_Loyalty -= 10
    ->END
*[Convencer al cocinero]
    Pico Pata Palo: ¿No crees que sería buena idea un caldo de sirena?
    
    Tomasso: ¡Tiene toda la razón de los mares, capitano! Intentaré mantenerla estable para que tenga un corte limpio.
    ~Tomasso_Loyalty += 20
    ->END