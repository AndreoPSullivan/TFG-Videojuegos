using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cake : MonoBehaviour

{

    LanguageManager languageManager = new LanguageManager();
    
    [SerializeField] GameObject cakes;
    [SerializeField] GameObject character;
    [SerializeField] private Animator m_animator = null;

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

    private float waitingTime = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = gameController.GetComponent<GameController>();

        if (!m_animator) { character.GetComponent<Animator>(); }
    }

    // Update is called once per frame
    void Update()
    {
        //TCA
        if (gameControllerScript.getCharacter() == 1 && cakes.transform.localScale.magnitude < (new Vector3(10,10, 10)).magnitude ){

            cakes.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f); 
        
        }

        float dist = Vector3.Distance(character.transform.position, cakes.transform.position);
        if (!endedCake && dist <= 14 && Input.GetKey(KeyCode.Space) && Time.time >= nextPiece)
        {
            m_animator.SetBool("Pickup", true);
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
                    textCharacter.text = languageManager.getText(gameControllerScript.getLanguage()*4+ gameControllerScript.getCharacter(),0);
                    texto.active = true;
                }
            }         

        }

    }
}
