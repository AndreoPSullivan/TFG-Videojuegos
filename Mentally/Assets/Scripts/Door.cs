using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Door : MonoBehaviour
{
    LanguageManager languageManager = new LanguageManager();

    [SerializeField] GameObject character;
    [SerializeField] GameObject gameController;
    [SerializeField] private Animator m_animator = null;


    [SerializeField] GameObject intruso1;
    [SerializeField] GameObject intruso2;

    GameController gameControllerScript;

    public TextMeshProUGUI textCharacter;
    [SerializeField] GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript = gameController.GetComponent<GameController>();

        if (!m_animator) { character.GetComponent<Animator>(); }

    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(character.transform.position, gameObject.transform.position);
        if (gameControllerScript.getCurrentTask() == GameController.TasksEnum.OpenDoor && dist <= 18 && Input.GetKey(KeyCode.Space))
        {
            m_animator.SetBool("Pickup", true);

            textCharacter.text = languageManager.getText(gameControllerScript.getLanguage() * 4 + gameControllerScript.getCharacter(), 5);
            texto.SetActive(true); 

            intruso1.SetActive(true); 
            intruso2.SetActive(true);

            gameControllerScript.setCurrentTask(GameController.TasksEnum.Party);
            gameControllerScript.addTask(6); 

        }

    }
}
