using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mirror : MonoBehaviour
{

    [SerializeField] GameObject character;
    //[SerializeField] Transform mirror;
    [SerializeField] GameObject gameController;
    public TextMeshProUGUI textCharacter;
    [SerializeField] GameObject texto; 

    private float nextMessage = 0;

    private GameController gameControllerScript;


    LanguageManager languageManager = new LanguageManager(); 
    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(character.transform.position, gameObject.transform.position);
        if (dist <= 15 && Time.time >= nextMessage && gameControllerScript.getCharacter() == 1)
        {
            nextMessage = Time.time + 30;
            textCharacter.text = languageManager.getText(gameControllerScript.getLanguage()*4+ gameControllerScript.getCharacter(), 1);
            texto.active = true;    
        }
    }
}
