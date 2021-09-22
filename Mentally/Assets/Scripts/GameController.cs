using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    LanguageManager lang = new LanguageManager();

    private int language = 0;
    public TextMeshProUGUI selectChar;
    public TextMeshProUGUI tasks;


    private float initTime;
    private int numcharacter = 0;

    private bool paused = true;
    [SerializeField] Image timeController;
    public float waitTime = 10.0f;


    [SerializeField] MeshRenderer[] paredes;
    [SerializeField] Material materialDep;
    [SerializeField] GameObject filtroDep;
    [SerializeField] GameObject[] notas;


    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject character;
    [SerializeField] GameObject cake;
    [SerializeField] GameObject lights; 

    private SimpleSampleCharacterControl characterScript;
    private Cake cakeScript;
    private Lamp lightScript; 


    private int currentNote = 0;
    public enum TasksEnum
    {
        None, Sleep, Eat, Clean, Switch

    }

    private TasksEnum currentTask = TasksEnum.None;

    // Start is called before the first frame update
    void Start()
    {
        selectChar.text = lang.getText(language * 4, 0);
        characterScript = character.GetComponent<SimpleSampleCharacterControl>();
        cakeScript = cake.GetComponent<Cake>();
        lightScript = lights.GetComponent<Lamp>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (!paused)
        {
            if (getCharacter() == 3)
            {
                timeController.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            }
            else
            {

                timeController.fillAmount -= 1.0f / waitTime * 2 * Time.deltaTime;
            }


            if (Time.time > initTime + 30 && Time.time < initTime + 35)
            {
                currentTask = TasksEnum.Switch;
                addTask(4);
            }

            if (Input.GetKeyDown("escape"))
            {
                paused = true;
                menuPausa.active = true; 
            }

        }



    }



    public void changeLanguage(int language)
    {
        this.language = language;
        this.Start();
    }


    public void startGame(int numcharacter)
    {
        initTime = Time.time;

        paused = false;
        this.numcharacter = numcharacter;

        switch (numcharacter)
        {
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

                foreach (MeshRenderer pared in paredes)
                {
                    pared.material = materialDep;

                }
                filtroDep.active = true;

                startGameDepression();
                break;
        }
    }


    public int getCharacter()
    {
        return this.numcharacter;
    }


    private void startGameTCA()
    {

    }

    private void startGameTAS()
    {

    }

    private void startGameDepression()
    {

    }

    public void addTask(int task)
    {
        tasks.text = lang.getText(language * 4, task);
    }


    public void addTask()
    {
        tasks.text = "";
    }

    public int getLanguage()
    {
        return this.language;
    }

    public TasksEnum getCurrentTask()
    {
        return currentTask;
    }

    public void setCurrentTask(TasksEnum currentTask)
    {
        this.currentTask = currentTask;
    }

    public void showNote()
    {
        this.notas[currentNote].active = true;
        this.notas[currentNote].GetComponentInChildren<TextMeshProUGUI>().text = lang.getText(language * 4 + numcharacter, currentNote + 5);
        this.currentNote++;
    }

    public bool getPaused()
    {
        return this.paused;
    }

    public void setPaused(bool paused)
    {
        this.paused = paused;
    }

    public void reset() {
        this.paused = true;
        currentTask = TasksEnum.None;
        timeController.fillAmount = 1;

        for (int i = 0; i < this.notas.Length; i++) {
            this.notas[currentNote].active = false;
            this.notas[currentNote].GetComponentInChildren<TextMeshProUGUI>().text = " "; 
            this.currentNote = 0;
        }
        characterScript.reset();
        addTask();
        filtroDep.active = false;
        cakeScript.reset();
        lightScript.reset();
        
    }
}
