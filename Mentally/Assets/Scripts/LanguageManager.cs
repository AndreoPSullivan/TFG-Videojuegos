using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager
{

    public enum language { English, Spanish }


    private language mLang;

    public enum word
    {
        SelectPlayer
    }
    private word mWord;


    string[,] names = new string[8, 5] {

        ///ENG 
        //General 
        {"Select a character", "Time to go to bed", "I can't go to bed yet", "Let's switch on the lights", "Let's switch off the lights" },
        //TCA
        {"I cannot eat anymore, today was too much", "Who is that one on the mirror?? I don't like her!", "I can't stop!", "I wish I could be someone else",
            "I need to control myself but I can't, I'm useless"},
            //TAS
        { "They're my family but I feel like they were monsters", "Calm down, (?), calm down, just try to find your hidden spot", "Can't they stop looking at me?",
            "Please, leave. Please, leave", "" },
            //Depression                   
        { "I don't feel fine, but at least I'm going to therapy on Monday", "Today I don't want to leave bed, I hate my life", "If only I could find something to have fun with",
            "", ""}, 
        
        ///ESP 
        //General 
        {"Selecciona un personaje", "Es hora de ir a la cama", "No puedo irme a la cama ya", "Toca encender las luces", "Hora de apagar las luces"
        },

        //TCA
        {  "No puedo comer más, lo de hoy fue demasiado", "¿Quién es esa del espejo? ¡No me gusta!", "¡No puedo parar!", "Ojalá pudiera ser otra persona", 
            "NEcesito controlarme pero no puedo, soy inútil"},

         //TAS
        { "Son mi familia pero siento como si fueran monstruos", "Cálmate, (?), cálmate, simplemente intenta encontrar tu escondrijo", "¿No pueden dejar de mirarme?", 
        "Por favor, iros. Por favor, iros", "" },
         //Depression
        { "No me encuentro bien, pero al menos voy a terapia el lunes", "Hoy no quiero salir de la cama, odio mi vida", "Si tan solo pudiera encontrar algo que me divirtiera", 
        "", "" } 

    };


    public string getText(int i, int j)
    {

        return names[i, j];
    }



}