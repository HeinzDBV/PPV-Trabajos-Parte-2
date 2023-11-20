INCLUDE Globals.ink

~ funcionEjemplo("imprimeEsto")

#speaker: Dr.Green
Hola! #portrait:dr_green_neutral #layout: Left #audio: robotVoice

-> mainConversation

===mainConversation===
¿Cómo te sientes hoy?
    *[Feliz]
    Eso tambien me pone <color=\#FBFF30>feliz</color> #portrait:dr_green_happy
    
    
    *[Triste]
    Eso me <color=\#FF1E35>entristece</color> tambien #portrait:dr_green_sad
    
    #speaker: Ms. Yellow
    - No confíes en el, no es un Doctor de verdad! #portrait:ms_Yellow_neutral #layout: Right #audio: heavyVoice
    ~ funcionEjemplo("Hhmm...")
  
#speaker: Dr.Green 
Bueno, tienes mas preguntas? #portrait:dr_green_neutral #layout: Left #audio: robotVoice
    * [Si]
        -> mainConversation
    * [No]
        Entonces Adios
        ->END