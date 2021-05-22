using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cake : MonoBehaviour

{

    LanguageManager languageManager = new LanguageManager();
    
    [SerializeField] GameObject cakes;
    [SerializeField] Transform character;

    private static int totalPiezas = 11;
    private int piezaActual = 0;
    GameObject hijo;

    float nextPiece = 0;
    private static float timeInBetween = 10;
    private bool endedCake = false;



    [SerializeField] GameObject gameController;
    public TextMeshProUGUI textCharacter;
    [SerializeField] GameObject texto;
    private GameController gameControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(character.position, cakes.transform.position);
        if (!endedCake && dist <= 14 && Input.GetKey(KeyCode.Space) && Time.time >= nextPiece)
        {
            nextPiece += timeInBetween;
            if (piezaActual < totalPiezas)
            {
                hijo = cakes.transform.GetChild(piezaActual).gameObject;
                hijo.active = false;
                piezaActual++;

                FindObjectOfType<AudioManager>().Play("eatingSound");
                
                if (piezaActual == totalPiezas && gameControllerScript.getCharacter() == 1)
                {
                    endedCake = true;
                    textCharacter.text = languageManager.getText(gameControllerScript.getLanguage(), 3);
                    texto.active = true;
                }
            }         

        }

    }
}
