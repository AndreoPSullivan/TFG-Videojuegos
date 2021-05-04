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


    string[,] names = new string[2, 2] {
        {"Select a character", "Time to go to bed"}, //Eng
        {"Selecciona un personaje", "Es hora de ir a la cama"} //Spa

    };


    public string getText(int i, int j)
    {

        return names[i, j];
    }



}