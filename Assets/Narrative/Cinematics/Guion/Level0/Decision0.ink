INCLUDE ../../../globals.ink
{ 
- cuerpo == 0 : -> Main 
- cuerpo == 1: -> PostA
- cuerpo == 2: -> PostB
}

===Main===
#speaker:Ezequiel #portrait:Ez_normal #layout: Left
I was doing this for one last time... i guess.
But... something happened... Why i'm alive? 
I should have... dead?
But... now that i'm not. i have to be there fo my family.
    + [Leave it]
    #decision: true
    #body:uno
        -> A
    + [Carry]
    #decision: false
    #body:dos
        -> B

===A===
#speaker:Ezequiel #portrait:Ez_angry #layout: Left
No... no.. i have to be diferent!
#portrait:Ez_sad
If it's not for yourself, do it for them old man.
#mission: Enter the Boat
~ cuerpo = 1 
->END

===B===
#speaker:Ezequiel #portrait:Ez_angry #layout:Left
I promised it...
#portrait:Ez_sad
But...
#portrait:Ez_normal
We have to eat.
#mission: Enter the Boat #body 
~ cuerpo = 2
->END

===PostA===
#speaker:Ezequiel #portrait:Ez_sad #layout:Left
I won't.
Ezequiel... Just... Get on the boat.

->END

===PostB===
#speaker:Ezequiel #portrait:Ez_angry #layout:Left
Let's finish this.
->END
