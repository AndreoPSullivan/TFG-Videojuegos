using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Lamp : MonoBehaviour
{

    [SerializeField] GameObject character;
    [SerializeField] private Animator m_animator = null;

    [SerializeField]
    Light light;

    [SerializeField]
    Light light2;

    [SerializeField]
    Light light3;

    [SerializeField]
    Material luz;

    [SerializeField] GameObject gameController;
    private GameController gameControllerScript;

    private bool _switchOffLight = false;
    private float waitTime = 0.02f;
    public TextMeshProUGUI textCharacter;
    [SerializeField] GameObject texto;


    LanguageManager languageManager = new LanguageManager();

    bool pulsed = false;
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
        if (dist <= 20 && gameControllerScript.getCurrentTask() == GameController.TasksEnum.Switch && (Input.GetKey(KeyCode.Space) || pulsed))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_animator.SetBool("Pickup", true);
            }
            pulsed = true;
            if (!_switchOffLight)
            {
                light.intensity -= 0.02f / waitTime * Time.deltaTime;
                light2.intensity -= 0.02f / waitTime * Time.deltaTime;
                light3.intensity -= 0.02f / waitTime * Time.deltaTime;
                luz.DisableKeyword("_EMISSION");

                if (light.intensity <= 0 && light2.intensity <= 0 && light3.intensity <= 0)
                {
                    _switchOffLight = true;
                    pulsed = false;
                    gameControllerScript.setCurrentTask(GameController.TasksEnum.Sleep);
                    gameControllerScript.addTask(1);
                }

                //TODO Finally the end of the day; Time to go to bed
                textCharacter.text = languageManager.getText(gameControllerScript.getLanguage()*4+gameControllerScript.getCharacter(), 4);
                texto.active = true;
            }
            else
            {
                light.intensity += 0.02f / waitTime * Time.deltaTime;
                light2.intensity += 0.02f / waitTime * Time.deltaTime;
                light3.intensity += 0.02f / waitTime * Time.deltaTime;
                luz.EnableKeyword("_EMISSION");

                if (light.intensity >= 2 && light2.intensity >= 3 && light3.intensity >= 3)
                {
                    _switchOffLight = false;
                    pulsed = false;
                    //TODO nextTASK 
                    gameControllerScript.setCurrentTask(GameController.TasksEnum.None);
                    gameControllerScript.addTask(0);
                }
            }

        }

    }


}





