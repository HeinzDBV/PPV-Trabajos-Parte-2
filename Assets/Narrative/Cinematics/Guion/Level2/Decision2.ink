INCLUDE ../../../globals.ink
{ 
- madre == 0 : -> Main 
- madre == 1: -> PostA
- madre == 2: -> PostB
}





===Main===
#portrait:Ez_normal #layout: Left
Oh son...
I better get out of here to find you again.
But when I see you, i can´t help but remember...
Your mother...
She also suffered quite a lot, just like you.
If only I could help her get rid of the pain...

    + [Let her live]
    #decision: true
        -> A
    + [End her suffering]
    #decision: false
        -> B

===A===
#portrait:Ez_normal #layout: Left
I wish I could do something to help you.
#portrait:Ez_sad
But I just can´t...
I'm not brave enough.
#mission: Escape!

->END

===B===
#portrait:Ez_angry #layout: Left
Ngh...
#portrait:Ez_sad
I...
Sorry.
I'm so sorry.
#portrait:Ez_normal
I hope to see you again in another life.
#mission: Escape!
->END

===PostA===
#portrait:Ez_sad
I'm not brave enough.
#mission: Escape!

->END

===PostB===
#portrait:Ez_sad
I'm so sorry.
#mission: Escape!
->END
