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


    string[,] names = new string[2, 1] {
        {"Select a character"}, //Eng
        {"Selecciona un personaje"} //Spa

    };


    public string getText(int i, int j)
    {

        return names[i, j];
    }



}