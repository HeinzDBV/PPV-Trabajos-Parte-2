INCLUDE ../../../globals.ink
{ 
- hijo == 0 : -> Main 
- hijo == 1: -> PostA
- hijo == 2: -> PostB
}

===Main===
#portrait:Ez_sad #layout: Left
What is this?...
What's happening here?
Son... oh my dear son...
What happened to you?
#portrait:Ez_angry #layout: Left
When will you learn?... 
You have always worried me...
But yet you never seem to get better.

    + [Hug him]
    #decision: true
        -> A
    + [Teach him]
    #decision: false
        -> B

===A===
#portrait:Ez_sad #layout: Left
Oh god...
#portrait:Ez_sad
I wish I could hug you like this again...
#mission: Escape!

->END

===B===
#portrait:Ez_angry #layout: Left
When will you learn?!
#portrait:Ez_angry
...
...
..
.

#portrait:Ez_sad
I'm sorry.
#mission: Hide!
->END

===PostA===
I wish I could hug you like this again...
#mission: Escape!

->END

===PostB===
#portrait:Ez_sad
I'm sorry.
#mission: Hide!
->END
