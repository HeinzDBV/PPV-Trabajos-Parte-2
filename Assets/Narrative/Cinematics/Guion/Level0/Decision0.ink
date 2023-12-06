INCLUDE ../../../globals.ink
{ 
- cuerpo == 0 : -> Main 
- cuerpo == 1: -> PostA
- cuerpo == 2: -> PostB
}





===Main===
#portrait:Ez_normal #layout: Left
Whe... where am i?
I... where... where is my boat. I remember the boat. It was dark, but i had my light...
My light... I have to find it.

    + [Leave it]
    #decision: true
        -> A
    + [Carry on the Boat]
    #decision: false
        -> B

===A===
#portrait:Ez_angry #layout: Left
No... no.. i have to be diferent!
#portrait:Ez_sad
If it's not for yourself, do it for them old man.
#mission: Enter the Boat

->END

===B===
#portrait:Ez_angry #layout: Left
I promised it...
#portrait:Ez_sad
But...
#portrait:Ez_normal
We have to eat.
#mission: Enter the Boat #body 
->END

===PostA===
#portrait:Ez_angry #layout: Left
I promised it...
#portrait:Ez_sad
But...
#portrait:Ez_normal
We have to eat.
#mission: Enter the Boat #body 
->END

===PostB===
#portrait:Ez_angry #layout: Left
I promised it...
#portrait:Ez_sad
But...
#portrait:Ez_normal
We have to eat.
#mission: Enter the Boat #body 
->END
