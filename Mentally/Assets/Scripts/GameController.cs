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
    public TextMeshProUGUI tasks; 

     

    private float initTime;
    private float today = 1;
    private float dayTime;
    private float nightTime;

    private static float dayDuration = 5;
    private float nextDay = 5;
    private static float timeSwitchLight = 1;
    private bool started = false;


    private int character = 0;

   
    [SerializeField] Image timeController;
    public float waitTime = 10.0f;

    public enum TasksEnum
    { 
        None, Sleep, Eat, Clean, Switch   
    
    }

    private TasksEnum currentTask = TasksEnum.None; 

    // Start is called before the first frame update
    void Start()
    {
        selectChar.text = lang.getText(language, 0);
        today = 1;
    }

    // Update is called once per frame
    void Update()
    {        
        
        if (started)
        {
            timeController.fillAmount -= 1.0f / waitTime * Time.deltaTime;


            if (Time.time > initTime + 30  && Time.time < initTime + 35) {
                currentTask = TasksEnum.Switch;
                addTask(0);
            }

        }

    }


   
    public void changeLanguage(int language) {
        this.language = language;
        this.Start(); 
    }


    public void startGame(int character)
    {
        initTime = Time.time;
        dayTime += initTime + dayDuration; 
        nightTime += initTime; 
        started = true;

        this.character = character; 

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


    public int getCharacter() {
        return this.character; 
    }

    private void startGameTCA() {
                
    }

    private void startGameTAS() {
       
    }

    private void startGameDepression() {

    }

    public void addTask(int task) { 
        tasks.text = lang.getText(language, task);
    }


    public void addTask()
    {
        tasks.text = ""; 
    }

    public int getLanguage() {
        return this.language; 
    }

    public TasksEnum getCurrentTask() {
        return currentTask; 
    }

    public void setCurrentTask(TasksEnum currentTask) {
        this.currentTask = currentTask; 
    }
}
