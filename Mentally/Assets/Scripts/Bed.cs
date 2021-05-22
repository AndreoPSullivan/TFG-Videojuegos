using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bed : MonoBehaviour
{

    [SerializeField] GameObject character;
    [SerializeField] Transform bed;
    [SerializeField] GameObject controller;
    [SerializeField] Transform lookAtBed;

    private GameController gameController;
    private SimpleSampleCharacterControl characterScript;

    LanguageManager languageManager = new LanguageManager(); 

    public TextMeshProUGUI textCharacter;
    [SerializeField] GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        gameController = controller.GetComponent<GameController>();

        characterScript = character.GetComponent<SimpleSampleCharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(character.transform.position, bed.position);
        if (dist <= 15)
        {

            if (gameController.getCurrentTask() == GameController.TasksEnum.Sleep)
            {              
                characterScript.GoToBed(bed, lookAtBed);              
                
            }
            else {
                textCharacter.text = languageManager.getText(gameController.getLanguage(), 2);
                texto.active = true;
            }
           
        }
    }
}
