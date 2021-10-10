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
    public TextMeshProUGUI pauseText;

    private float initTime;
    private int numcharacter = 0;

    private bool paused = true;
    public bool musicOn = true;


    [SerializeField] Image timeController;
    private float waitTime = 10.0f;


    [SerializeField] MeshRenderer[] paredes;
    [SerializeField] Material materialDep;
    [SerializeField] GameObject filtroDep;
    [SerializeField] GameObject[] notas;


    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject character;
    [SerializeField] GameObject cake;
    [SerializeField] GameObject lights;
    [SerializeField] GameObject time;
    [SerializeField] GameObject controles;
    private bool controlesShown = true;

    [SerializeField] Material luz;

    private SimpleSampleCharacterControl characterScript;
    private Cake cakeScript;
    private Lamp lightScript;


    private int currentNote = 0;
    public enum TasksEnum
    {
        None, Sleep, Eat, Clean, Switch, OpenDoor, Party

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
            if (currentTask.Equals(TasksEnum.Party))
            {
                if (getCharacter() == 1)
                {
                    time.SetActive(true);
                    timeController.fillAmount -= 0.4f / (waitTime * 1.0f) * Time.deltaTime;
                }
                else if (getCharacter() == 2)
                {
                    time.SetActive(true);
                    timeController.fillAmount -= 0.4f / (waitTime * 2.8f) * Time.deltaTime;
                }
                else
                {

                    time.SetActive(true);
                    timeController.fillAmount -= 0.4f / (waitTime * 2.0f) * Time.deltaTime;
                }

                if (timeController.fillAmount <= 0.0f)
                {
                    currentTask = TasksEnum.Switch;
                    addTask(4);
                    time.SetActive(false);
                }
            }

            if (controlesShown && Time.time > initTime + 5) {
                controles.SetActive(false);
                controlesShown = false; 
            }

            if (Time.time > initTime + 30 && Time.time < initTime + 35)
            {
                currentTask = TasksEnum.Switch;
                addTask(4);
            }

            if (Input.GetKeyDown("escape"))
            {
                paused = true;
                menuPausa.SetActive(true);
                setTextPaused(); 
              
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
        luz.EnableKeyword("_EMISSION");
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
                filtroDep.SetActive(true);

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
        this.notas[currentNote].SetActive(true);
        this.notas[currentNote].GetComponentInChildren<TextMeshProUGUI>().text = lang.getText(language * 4 + numcharacter, currentNote + 6);
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

    public void reset()
    {
        this.paused = true;
        currentTask = TasksEnum.None;
        timeController.fillAmount = 1;

        for (int i = 0; i < this.notas.Length; i++)
        {
            this.notas[currentNote].SetActive(false);
            this.notas[currentNote].GetComponentInChildren<TextMeshProUGUI>().text = " ";
            this.currentNote = 0;
        }
        characterScript.reset();
        addTask();
        filtroDep.SetActive(false);
        cakeScript.reset();
        lightScript.reset();

    }

    public bool getMusicOn()
    {
        return musicOn;
    }

    public void setMusicOn(bool musicOn)
    {
        this.musicOn = musicOn;
    }

    public void setTextPaused() {
        pauseText.text = lang.getText(language * 4, 9);
    }

    public float getTimeControllerFilling() { 
        return this.timeController.fillAmount;             
    }
}
