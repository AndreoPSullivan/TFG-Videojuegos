using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    LanguageManager lang = new LanguageManager();

    int language = 0; 

    public TextMeshProUGUI selectChar;



    // Start is called before the first frame update
    void Start()
    {
        selectChar.text = lang.getText(language, 0); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeLanguage(int language) {

        this.language = language;
        this.Start(); 


    }
    public void startGame(int character)
    {

        switch (character){          

            //TCA
            case 1:
                startGameTCA();
                break;
            //TAS
            case 2:
                startGameTAS();
                break;
            //Depression
            default:
                startGameDepression();
                break;
        }
    }


    private void startGameTCA() {
        Debug.Log("comienza TCA");
    }

    private void startGameTAS() {
        Debug.Log("comienza TAS");
    }

    private void startGameDepression() {

        Debug.Log("comienza dep"); 
    }
}
