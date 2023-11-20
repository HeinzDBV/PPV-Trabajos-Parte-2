INCLUDE Globals.ink

//Nos movemos a un Nudo dependiendo de si se ha escogido un Pokemon
{pokemon_name == "" : -> main | ->already_chosen}

=== main ===
Bienvenido al mundo de Pokemon. #audio: heavyVoice
    + [Charmander]
        -> choose("Charmander")
    + [Bulbasaur]
        -> choose("Bulbasaur")
    + [Squirtle]
        -> choose("Squirtle")


=== choose(pokemon) ===
~ pokemon_name = pokemon
ESCOGISTE A {pokemon} #audio: heavyVoice
-> END


=== already_chosen ===
YA ESCOGISTE A {pokemon_name} #audio: heavyVoice
->END