using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager
{

    public enum language { English, Spanish }


    private language mLang;

    string[,] texts = new string[8, 10] {

        ///ENG 
        //General 
        {"Select a character", "Time to go to bed", "I can't go to bed yet", "Let's switch on the lights", "Let's switch off the lights", "Open the door", "Wait until the party ends", "", "", "Paused" },
        //TCA
        {"I cannot eat anymore, today was too much", "Who is that one on the mirror?? I don't like her!", "I can't stop!", "I wish I could be someone else",
            "I need to control myself but I can't, I'm useless","", "52.4kg. I'm so tired of this", "51.8kg. Today I didn't taste a bite", "52.8kg. I couldn't control myself", "52.5kg. I am trying"},
            //TAS
        { "They're my family but I feel like they were monsters", "Calm down, (?), calm down, just try to find your hidden spot", "Can't they stop looking at me?",
            "Please, leave. Please, leave", "I don't want to eat more", "Welcome", "I'm trying to relax", "I feel lonely, but it's ok", "I wish I could go out", "Tomorrow I will go buy something" },
            //Depression                   
        { "I don't feel fine, but at least I'm going to therapy on Monday", "Today I don't want to leave bed, I hate my life", "If only I could find something to have fun with",
            "", "", "I don't want to eat more", "It's hard to get up", "I think I'm better today", "Not really", "Crying is ok"}, 
        
        ///ESP 
        //General 
        {"Selecciona un personaje", "Es hora de ir a la cama", "No puedo irme a la cama ya", "Toca encender las luces", "Hora de apagar las luces", "Abre la puerta", "Espera hasta que acabe la fiesta", "", "", "Pausado"
        },
        //TCA
        {  "No puedo comer más, lo de hoy fue demasiado", "¿Quién es esa del espejo? ¡No me gusta!", "¡No puedo parar!", "Ojalá pudiera ser otra persona", 
            "NEcesito controlarme pero no puedo, soy inútil", "", "52.4kg. Estoy muy cansada de esto", "51.8kg. Hoy no probé bocado", "52.8kg. No he podido controlarme", "52.5kg. Lo estoy intentando"},

         //TAS
        { "Son mi familia pero siento como si fueran monstruos", "Cálmate, (?), cálmate, simplemente intenta encontrar tu escondrijo", "¿No pueden dejar de mirarme?", 
        "Por favor, iros. Por favor, iros", "No quiero comer más", "Bienvenidos", "Estoy intentando relajarme", "Me siento solo pero está bien", "Ojalá pudiera salir", "Mañana iré a comprar algo" },
         //Depression
        { "No me encuentro bien, pero al menos voy a terapia el lunes", "Hoy no quiero salir de la cama, odio mi vida", "Si tan solo pudiera encontrar algo que me divirtiera", 
        "", "", "No quiero comer más", "Es duro levantarme", "Creo que hoy estoy mejor", "En realidad no", "Llorar está bien"} 

    };


    public string getText(int i, int j)
    {

        return texts[i, j];
    }



}